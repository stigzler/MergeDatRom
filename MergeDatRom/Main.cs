using MergeDatRom.Models;
using MergeDatRom.Services;
using stigzler.Winforms.Base;
using stigzler.Winforms.Base.Forms.BaseForm;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace MergeDatRom
{
    public partial class Main : BaseForm
    {
        private readonly BindingList<DatMetadata> _datMetadatas = new BindingList<DatMetadata>();
        private readonly DatMetadataService _datMetadataService;
        private readonly LoggingService _loggingService;
        private bool _suppressSelectionChanged;
        private string _warningMessageRightPadding = "     ";

        public Main(DatMetadataService datMetadataService, LoggingService loggingService)
        {
            _datMetadataService = datMetadataService;
            _loggingService = loggingService;
            InitializeComponent();
        }

        internal void ProcessMerge(IEnumerable<DatMetadata> datList, MergeType mergeType)
        {
            // Key: Game Name, Value: List of XML nodes from different DATs
            var nameGroups = new Dictionary<string, List<XElement>>(StringComparer.OrdinalIgnoreCase);
            bool stripTags = StripTagsChB.Checked;
            bool useSquareBrackets = UseTagSquareChB.Checked;
            bool useBrackets = UseTagBracketChB.Checked;
            bool preserveMultiDisc = PreserveMultiDiscFormatsChB.Checked;
            string globalExcludeTags = ExcludeTagsTB.Text;
            string globalIncludeTags = IncludeTagsTB.Text;

            // Pass 1: Load, filter, and group games from each DAT file individually
            foreach (var meta in datList)
            {
                var doc = XDocument.Load(meta.DatFilePath);

                // Group games within the current DAT
                var gamesInCurrentDat = new Dictionary<string, List<XElement>>(StringComparer.OrdinalIgnoreCase);

                // Combine global and local exclude tags
                string combinedExcludeTags = meta.ExcludeTags;
                if (!string.IsNullOrEmpty(globalExcludeTags))
                {
                    if (!string.IsNullOrEmpty(combinedExcludeTags))
                    {
                        combinedExcludeTags = $"{globalExcludeTags},{combinedExcludeTags}";
                    }
                    else
                    {
                        combinedExcludeTags = globalExcludeTags;
                    }
                }
                var excludeTagPatterns = ParseExcludeTags(combinedExcludeTags);

                foreach (var gameNode in doc.Descendants("game"))
                {
                    string originalGameName = gameNode.Attribute("name")?.Value ?? "Unknown";

                    // Exclusion Check
                    var gameTags = ExtractTags(originalGameName, useSquareBrackets, useBrackets);
                    bool isExcluded = excludeTagPatterns.Any(pattern =>
                        gameTags.Any(gameTag => pattern.IsMatch(gameTag))
                    );
                    if (isExcluded)
                    {
                        continue; // Skip this game
                    }

                    // Grouping
                    string gameName;
                    if (stripTags)
                    {
                        if (preserveMultiDisc && IsMultiDisc(originalGameName))
                        {
                            gameName = GetMultiDiscGameBaseName(originalGameName);
                        }
                        else
                        {
                            gameName = GetGameBaseName(originalGameName);
                        }
                    }
                    else
                    {
                        gameName = originalGameName;
                    }

                    // _loggingService.Log($"[DEBUG] Original: '{originalGameName}', IsMulti: {IsMultiDisc(originalGameName)}, Key: '{gameName}'");

                    if (!gamesInCurrentDat.ContainsKey(gameName))
                    {
                        gamesInCurrentDat[gameName] = new List<XElement>();
                    }
                    gamesInCurrentDat[gameName].Add(gameNode);
                }

                // In-DAT Resolution (using IncludeTags)
                // Combine global and local include tags
                string combinedIncludeTags = meta.IncludeTags;
                if (!string.IsNullOrEmpty(globalIncludeTags))
                {
                    if (!string.IsNullOrEmpty(combinedIncludeTags))
                    {
                        combinedIncludeTags = $"{globalIncludeTags},{combinedIncludeTags}";
                    }
                    else
                    {
                        combinedIncludeTags = globalIncludeTags;
                    }
                }
                var includeTags = (combinedIncludeTags ?? "").Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();

                foreach (var gameName in gamesInCurrentDat.Keys)
                {
                    var candidates = gamesInCurrentDat[gameName];
                    XElement winner;

                    if (candidates.Count > 1)
                    {
                        winner = FindBestCandidate(candidates, includeTags, useSquareBrackets, useBrackets);
                    }
                    else
                    {
                        winner = candidates.First();
                    }

                    // Add the winner from this DAT to the main collection
                    winner.AddAnnotation(meta);
                    if (!nameGroups.ContainsKey(gameName))
                    {
                        nameGroups[gameName] = new List<XElement>();
                    }
                    nameGroups[gameName].Add(winner);
                }
            }

            // Pass 2: Resolve Conflicts (between DATs)
            foreach (var group in nameGroups)
            {
                var games = group.Value;
                if (games.Count <= 1) continue; // No conflict

                switch (mergeType)
                {
                    case MergeType.KeepPriorityOnly: // Only use priority
                                                     // Keep games[0], discard others (logic depends on your export)
                        games.RemoveAll(g => g != games[0]);
                        break;

                    case MergeType.TagAllButPriority: // Tag lower conflicting games
                        for (int i = 1; i < games.Count; i++)
                        {
                            ApplyTag(games[i]);
                        }
                        break;

                    case MergeType.TagAll: // Tag all conflicting games
                        foreach (var g in games)
                        {
                            ApplyTag(g);
                        }
                        break;
                }
            }

            SaveFileDialog sfd = new SaveFileDialog()
            {
                Title = "Choose where to save the merged DAT file",
                Filter = "DAT files|*.dat",
                InitialDirectory = Properties.Settings.Default.LastChosenSaveDir,
                FileName = Helpers.String.ToFileSafe(MergeDatDescTB.Text) + ".dat",
                OverwritePrompt = true
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            Properties.Settings.Default.LastChosenSaveDir = Path.GetDirectoryName(sfd.FileName);

            // Sort the games alphabetically by name before saving
            var sortedNameGroups = new SortedDictionary<string, List<XElement>>(nameGroups, StringComparer.OrdinalIgnoreCase);

            // Create MergeSettings object from UI
            var mergeSettings = new MergeSettings
            {
                Method = (MergeType)MethodCB.SelectedItem,
                TagPosition = (TagPosition)TagPositionCB.SelectedItem,
                AlsoTagDesc = AlsoTagDescChB.Checked,
                OpenFileAfterCreated = OpenFileAfterCreatedChB.Checked,
                StripTagsForMatching = StripTagsChB.Checked,
                UseSquareBrackets = UseTagSquareChB.Checked,
                UseBrackets = UseTagBracketChB.Checked,
                GlobalIncludeTags = IncludeTagsTB.Text,
                GlobalExcludeTags = ExcludeTagsTB.Text,
                PreserveMultiDisc = PreserveMultiDiscFormatsChB.Checked
            };

            bool success = _datMetadataService.CreateMergedDatFile(sortedNameGroups, sfd.FileName, MergeDatNameTB.Text,
                MergeDatDescTB.Text, MergeDatAuthorTB.Text, MergeDatCategoryTB.Text,
                _datMetadatas, mergeSettings);

            if (success)
            {
                WarningLB.Visible = true;
                WarningLB.Image = Properties.Resources.tick;
                WarningLB.Text = $"Merge successful{_warningMessageRightPadding}";

                if (OpenFileAfterCreatedChB.Checked)
                {
                    {
                        try
                        {
                            Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                        }
                        catch (Exception ex)
                        {
                            _loggingService.Log($"Failed to open merged file: {ex.Message}");
                        }
                    }
                }
            }
            else
            {
                SetWarning($"Merge failed. Please check the logs for details");
            }
        }

        private List<Regex> ParseExcludeTags(string tagsCsv)
        {
            var patterns = new List<Regex>();
            if (string.IsNullOrEmpty(tagsCsv)) return patterns;

            var tags = tagsCsv.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            foreach (var tag in tags)
            {
                string pattern = Regex.Escape(tag);
                if (pattern.EndsWith(@"\*"))
                {
                    pattern = "^" + pattern.Substring(0, pattern.Length - 2) + ".*";
                }
                else
                {
                    pattern = "^" + pattern + "$";
                }
                patterns.Add(new Regex(pattern, RegexOptions.IgnoreCase));
            }
            return patterns;
        }

        private List<string> ExtractTags(string gameName, bool useSquare, bool useBrackets)
        {
            var tags = new List<string>();
            if (!useSquare && !useBrackets) return tags;

            // Temporarily remove the date tag so it's not extracted as a regular tag
            var dateRegex = new Regex(@"\s\((?:\d{4}-\d{2}-\d{2}|\d{2}[xX]{2}|\d{4})\)");
            var nameWithoutDate = dateRegex.Replace(gameName, "", 1); // Replace only the first occurrence

            var patterns = new List<string>();
            if (useSquare) patterns.Add(@"\[(.*?)\]");
            if (useBrackets) patterns.Add(@"\((.*?)\)");

            if (!patterns.Any()) return tags;

            var pattern = string.Join("|", patterns);

            var matches = Regex.Matches(nameWithoutDate, pattern);
            foreach (Match match in matches)
            {
                // Find the first successful capture group
                var capturedTag = match.Groups.Cast<Group>().Skip(1).FirstOrDefault(g => g.Success)?.Value;
                if (capturedTag != null)
                {
                    tags.Add(capturedTag);
                }
            }
            return tags;
        }

        private XElement FindBestCandidate(List<XElement> candidates, List<string> includeTags, bool useSquare, bool useBrackets)
        {
            // Pre-calculate tags for each candidate to avoid repeated extraction
            var candidatesWithTags = candidates.Select(c => new
            {
                Node = c,
                Tags = ExtractTags(c.Attribute("name")?.Value ?? "", useSquare, useBrackets)
            }).ToList();

            foreach (var includeTag in includeTags)
            {
                XElement winner = null;

                if (includeTag.Equals("notag", StringComparison.OrdinalIgnoreCase))
                {
                    winner = candidatesWithTags
                        .FirstOrDefault(c => !c.Tags.Any())?.Node;
                }
                else if (includeTag.Equals("anytag", StringComparison.OrdinalIgnoreCase))
                {
                    winner = candidatesWithTags
                        .Where(c => c.Tags.Any())
                        .OrderByDescending(c => c.Tags.Count)
                        .FirstOrDefault()?.Node;
                }
                else // Handle regular tags
                {
                    winner = candidatesWithTags
                        .FirstOrDefault(c => c.Tags.Contains(includeTag, StringComparer.OrdinalIgnoreCase))?.Node;
                }

                if (winner != null)
                {
                    return winner; // Found a winner based on the current includeTag, so we're done.
                }
            }

            // Fallback: If no includeTag matched, return the first candidate from the original list
            return candidates.First();
        }

        private void ApplyTag(XElement game)
        {
            var meta = game.Annotation<DatMetadata>();
            if (meta == null || string.IsNullOrEmpty(meta.Tag)) return;

            var nameAttr = game.Attribute("name");

            if (nameAttr != null)
            {
                switch (TagPositionCB.SelectedItem)
                {
                    case TagPosition.Prefix:
                        nameAttr.Value = $"({meta.Tag}) {nameAttr.Value}";
                        break;

                    case TagPosition.Suffix:
                        nameAttr.Value = $"{nameAttr.Value} ({meta.Tag})";
                        break;
                }
            }

            if (AlsoTagDescChB.Checked)
            {
                var descElem = game.Element("description");
                if (descElem != null)
                {
                    switch (TagPositionCB.SelectedItem)
                    {
                        case TagPosition.Prefix:
                            descElem.Value = $"({meta.Tag}) {descElem.Value}";
                            break;

                        case TagPosition.Suffix:
                            descElem.Value = $"{descElem.Value} ({meta.Tag})";
                            break;
                    }
                }
            }
        }

        private void darkModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DarkMode = !this.DarkMode;
        }

        private void LoadDatFiles(List<string> filenames)
        {
            var datmetadatas = _datMetadataService.GetDatMetadata(filenames);
            _datMetadatas.Clear();

            foreach (var datmetadata in datmetadatas)
            {
                _datMetadatas.Add(datmetadata);
            }

            if (_datMetadatas.Count > 0)
            {
                MainLB.SelectedIndex = 0;
            }
            else
            {
                MainPG.SelectedObject = null;
            }
        }

        private void LoadDatsBT_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "Please choose the DAT files to merge (ensure same and correct schema)",
                Filter = "DAT, DATZ and XML files|*.dat;*.datz;*.xml",
                Multiselect = true,
                InitialDirectory = Properties.Settings.Default.LastChosenDatDir
            };

            var res = ofd.ShowDialog();
            if (res != DialogResult.OK) return;

            Properties.Settings.Default.LastChosenDatDir = Path.GetDirectoryName(ofd.FileNames.FirstOrDefault() ?? string.Empty);

            _loggingService.Log($"User selected {ofd.FileNames.Length} DAT files to load:{Environment.NewLine}"
                + String.Join(Environment.NewLine, ofd.FileNames));

            LoadDatFiles(ofd.FileNames.ToList());
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            MainLB.DataSource = _datMetadatas;
            MainLB.DisplayMember = nameof(DatMetadata.DatName);

            MethodCB.DataSource = Enum.GetValues<MergeType>();
            TagPositionCB.DataSource = Enum.GetValues<TagPosition>();

            MergeDatNameTB.Text = Properties.Settings.Default.DefaultName;
            MergeDatDescTB.Text = Properties.Settings.Default.DefaultDesc;
            MergeDatAuthorTB.Text = Properties.Settings.Default.DefaultAuthor;
            MergeDatCategoryTB.Text = Properties.Settings.Default.DefaultCategory;
            AlsoTagDescChB.Checked = Properties.Settings.Default.DefaultAlsoTagDesc;
            OpenFileAfterCreatedChB.Checked = Properties.Settings.Default.OPenFileAfterCreated;
            StripTagsChB.Checked = Properties.Settings.Default.StripTagsForMatch;
            PreserveMultiDiscFormatsChB.Checked = Properties.Settings.Default.PreserveMultiDisc;
            UseTagBracketChB.Checked = Properties.Settings.Default.IncludeBracketTags;
            UseTagSquareChB.Checked = Properties.Settings.Default.IncludeSquareTags;
            MethodCB.Text = Properties.Settings.Default.DefaultMethod;
            TagPositionCB.Text = Properties.Settings.Default.DefaultTagPosition;

            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            VersionLB.Text = $"V{version.Major}.{version.Minor}.{version.Build}";

            _loggingService.LogClear();
            _loggingService.Log("Starting application.");
        }

        private void MainLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressSelectionChanged) return;
            MainPG.SelectedObject = MainLB.SelectedItem;
        }

        private void MainLB_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void MergeBT_Click(object sender, EventArgs e)
        {
            MergeType mergeType = (MergeType)MethodCB.SelectedItem;

            if (_datMetadatas.Count == 0)
            {
                SetCritical($"No DAT files loaded. Please load DAT files before merging");
                return;
            }

            if (_datMetadatas.Count < 2)
            {
                SetCritical($"You need at least 2 Dats to merge");
                return;
            }

            // Checks:
            // If not PriotiyOnly Merge type, ensure tags are set on each DatMetadata and warn if not
            if (mergeType != MergeType.KeepPriorityOnly && _datMetadatas.Any(meta => string.IsNullOrEmpty(meta.Tag)))
            {
                WarningLB.Visible = true;
                SetCritical($"Tag gamename selected, but not all tags are set. Please update");
                return;
            }

            WarningLB.Visible = false;
            ProcessMerge(_datMetadatas, (MergeType)MethodCB.SelectedItem);
        }

        private void SetDefaults()
        {
            Properties.Settings.Default.DefaultName = MergeDatNameTB.Text;
            Properties.Settings.Default.DefaultDesc = MergeDatDescTB.Text;
            Properties.Settings.Default.DefaultCategory = MergeDatCategoryTB.Text;
            Properties.Settings.Default.DefaultAuthor = MergeDatAuthorTB.Text;
            Properties.Settings.Default.DefaultAlsoTagDesc = AlsoTagDescChB.Checked;
            Properties.Settings.Default.OPenFileAfterCreated = OpenFileAfterCreatedChB.Checked;
            Properties.Settings.Default.StripTagsForMatch = StripTagsChB.Checked;
            Properties.Settings.Default.PreserveMultiDisc = PreserveMultiDiscFormatsChB.Checked;
            Properties.Settings.Default.IncludeSquareTags = UseTagSquareChB.Checked;
            Properties.Settings.Default.IncludeBracketTags = UseTagBracketChB.Checked;
            Properties.Settings.Default.DefaultMethod = MethodCB.Text;
            Properties.Settings.Default.DefaultTagPosition = TagPositionCB.Text;
        }

        private void MoveSelectedDat(int direction)
        {
            var index = MainLB.SelectedIndex;
            var newIndex = index + direction;

            if (index < 0 || newIndex < 0 || newIndex >= _datMetadatas.Count) return;

            var selectedDatMetadata = (DatMetadata?)MainLB.SelectedItem;
            if (selectedDatMetadata is null) return;

            _suppressSelectionChanged = true;
            try
            {
                _datMetadatas.RemoveAt(index);
                _datMetadatas.Insert(newIndex, selectedDatMetadata);
                MainLB.SelectedItem = selectedDatMetadata;
                MainPG.SelectedObject = selectedDatMetadata;
            }
            finally
            {
                _suppressSelectionChanged = false;
            }
        }

        private void PriorityDownBT_Click(object sender, EventArgs e)
        {
            MoveSelectedDat(1);
        }

        private void PriorityUpBT_Click(object sender, EventArgs e)
        {
            MoveSelectedDat(-1);
        }

        private void SetWarning(string message)
        {
            WarningLB.Visible = true;
            WarningLB.Image = Properties.Resources.exclamation__frame;
            WarningLB.Text = message + _warningMessageRightPadding;
        }

        private void SetCritical(string message)
        {
            WarningLB.Visible = true;
            WarningLB.Image = Properties.Resources.exclamation_red;
            WarningLB.Text = message + _warningMessageRightPadding;
        }

        private void SetSuccess(string message)
        {
            WarningLB.Visible = true;
            WarningLB.Image = Properties.Resources.tick;
            WarningLB.Text = message + _warningMessageRightPadding;
        }

        private string GetGameBaseName(string name)
        {
            // Regex to find date tags like (1987), (19xx), or (2024-03-07)
            var regex = new Regex(@"\s\((\d{4}-\d{2}-\d{2}|\d{2}[xX]{2}|\d{4})\)");
            var match = regex.Match(name);

            if (match.Success)
            {
                // Return the part of the name before the date tag + the date tag itself
                return name.Substring(0, match.Index) + match.Value;
            }

            // Fallback for non-TOSEC style names: strip all tags.
            int tagStartIndex = name.IndexOfAny(new[] { '(', '[' });
            if (tagStartIndex > 0)
            {
                return name.Substring(0, tagStartIndex).TrimEnd();
            }

            return name; // Return original name if no tags found
        }

        private bool IsMultiDisc(string gameName)
        {
            // Regex to detect (Disk...), (Disc...), (Side...), or (Part...) tags. Case-insensitive.
            // Using word boundaries to be more robust.
            return Regex.IsMatch(gameName, @"\b(Disk|Disc|Side|Part)\b", RegexOptions.IgnoreCase);
        }

        private string GetMultiDiscGameBaseName(string name)
        {
            // For multi-disc games, the key is the name with alternate version tags (e.g., [a], [a2]) removed.
            var alternateVersionRegex = new Regex(@"\s*\[[^\]]*\]");
            return alternateVersionRegex.Replace(name, "").Trim();
        }

        private void StripTagsChB_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void LoadSetupBT_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "Please choose a previously merged DAT file to load its setup",
                Filter = "DAT files|*.dat",
                Multiselect = false,
                InitialDirectory = Properties.Settings.Default.LastChosenSaveDir
            };

            if (ofd.ShowDialog() != DialogResult.OK) return;

            _loggingService.Log($"User chose Load Setup form file: {ofd.FileName}");
            bool success = LoadSetupFromFile(ofd.FileName);

            if (success) { SetSuccess("Successfully loaded setup."); }
        }

        private bool LoadSetupFromFile(string filePath)
        {
            XElement headerNode = null;

            // Use XmlReader to efficiently find and read the entire <header> element
            using (var reader = XmlReader.Create(filePath))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement() && reader.Name == "header")
                    {
                        headerNode = XNode.ReadFrom(reader) as XElement;
                        break;
                    }
                    // Optimization: stop if we're past the header section
                    if (reader.IsStartElement() && reader.Name == "game")
                    {
                        break;
                    }
                }
            }

            if (headerNode == null)
            {
                SetCritical($"No header. Not MergeDatRom dat file.");
                return false;
            }

            if (headerNode.Element("tool") == null || headerNode.Element("tool")?.Value != "MergeDatRom")
            {
                SetCritical($"Incorrect tool element. Not MergeDatRom dat file.");
                return false;
            }

            var setupNode = headerNode.Element("setup");
            if (setupNode == null)
            {
                SetCritical($"No setup details. Not MergeDatRom dat file.");
                return false;
            }

            // --- Restore Header Details ---
            MergeDatNameTB.Text = headerNode.Element("name")?.Value;
            MergeDatDescTB.Text = headerNode.Element("description")?.Value;
            MergeDatAuthorTB.Text = headerNode.Element("author")?.Value;
            MergeDatCategoryTB.Text = headerNode.Element("category")?.Value;

            // --- Restore Global Settings ---
            var globalSettings = setupNode.Element("GlobalSettings");
            if (globalSettings != null)
            {
                if (Enum.TryParse<MergeType>(globalSettings.Element("Method")?.Value, out var method))
                    MethodCB.SelectedItem = method;

                if (Enum.TryParse<TagPosition>(globalSettings.Element("TagPosition")?.Value, out var tagPos))
                    TagPositionCB.SelectedItem = tagPos;

                AlsoTagDescChB.Checked = bool.Parse(globalSettings.Element("AlsoTagDesc")?.Value ?? "false");
                OpenFileAfterCreatedChB.Checked = bool.Parse(globalSettings.Element("OpenFileAfterCreated")?.Value ?? "false");
                StripTagsChB.Checked = bool.Parse(globalSettings.Element("StripTagsForMatching")?.Value ?? "false");
                UseTagSquareChB.Checked = bool.Parse(globalSettings.Element("UseSquareBrackets")?.Value ?? "false");
                UseTagBracketChB.Checked = bool.Parse(globalSettings.Element("UseBrackets")?.Value ?? "false");
                PreserveMultiDiscFormatsChB.Checked = bool.Parse(globalSettings.Element("PreserveMultiDisc")?.Value ?? "false");
                IncludeTagsTB.Text = globalSettings.Element("GlobalIncludeTags")?.Value ?? string.Empty;
                ExcludeTagsTB.Text = globalSettings.Element("GlobalExcludeTags")?.Value ?? string.Empty;
            }

            // --- Restore Source DATs ---
            var sourceDats = setupNode.Element("SourceDats");
            if (sourceDats != null)
            {
                var sourceDatList = sourceDats.Elements("Dat").ToList();
                var filePathsToLoad = new List<string>();
                var missingFiles = new List<string>();

                foreach (var datNode in sourceDatList)
                {
                    var path = datNode.Element("FilePath")?.Value;
                    if (File.Exists(path))
                    {
                        filePathsToLoad.Add(path);
                    }
                    else
                    {
                        missingFiles.Add(path);
                    }
                }

                // Load the available DATs
                LoadDatFiles(filePathsToLoad);

                // Now apply the saved settings to the loaded DATs
                foreach (var datNode in sourceDatList)
                {
                    var path = datNode.Element("FilePath")?.Value;
                    var loadedDat = _datMetadatas.FirstOrDefault(d => d.DatFilePath.Equals(path, StringComparison.OrdinalIgnoreCase));

                    if (loadedDat != null)
                    {
                        loadedDat.Tag = datNode.Element("Tag")?.Value ?? string.Empty;
                        loadedDat.ExcludeTags = datNode.Element("ExcludeTags")?.Value ?? string.Empty;
                        loadedDat.IncludeTags = datNode.Element("IncludeTags")?.Value ?? string.Empty;
                    }
                }

                // Refresh the property grid to show the newly applied settings
                if (MainLB.SelectedItem != null)
                {
                    MainPG.SelectedObject = MainLB.SelectedItem;
                    MainPG.Refresh();
                }

                // Report any missing files
                if (missingFiles.Any())
                {
                    foreach (var missingFile in missingFiles)
                    {
                        _loggingService.Log($"DAT file from setup not found: {missingFile}");
                        SetWarning($"DAT/s no longer available. See log file for details.");
                    }
                    return false; // Indicate that not all files were loaded successfully
                }
            }
            return true;
        }

        private void SetDefaultsBT_Click(object sender, EventArgs e)
        {
            SetDefaults();
            SetSuccess("Defaults Saved");
        }
    }
}