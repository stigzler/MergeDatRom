using MergeDatRom.Models;
using MergeDatRom.Services;
using stigzler.Winforms.Base;
using stigzler.Winforms.Base.Forms.BaseForm;
using System.ComponentModel;
using System.Diagnostics;
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

            // Pass 1: Load and Group
            foreach (var meta in datList)
            {
                var doc = XDocument.Load(meta.DatFilePath);
                foreach (var gameNode in doc.Descendants("game"))
                {
                    // Attach the metadata object so we know the Tag/Priority of this specific node
                    gameNode.AddAnnotation(meta);

                    string gameName = gameNode.Attribute("name")?.Value ?? "Unknown";
                    if (!nameGroups.ContainsKey(gameName))
                        nameGroups[gameName] = new List<XElement>();

                    nameGroups[gameName].Add(gameNode);
                }
            }

            // Pass 2: Resolve Conflicts
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

            bool success = _datMetadataService.CreateMergedDatFile(nameGroups, sfd.FileName, MergeDatNameTB.Text,
                MergeDatDescTB.Text, MergeDatAuthorTB.Text, MergeDatCategoryTB.Text);

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
                else
                {
                    SetWarning($"Merge failed. Please check the logs for details");
                }
            }
        }

        private void AlsoTagDescChB_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DefaultAlsoTagDesc = AlsoTagDescChB.Checked;
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
                SetWarning($"No DAT files loaded. Please load DAT files before merging");
                return;
            }

            if (_datMetadatas.Count < 2)
            {
                SetWarning($"You need at least 2 Dats to merge");
                return;
            }

            // Checks:
            // If not PriotiyOnly Merge type, ensure tags are set on each DatMetadata and warn if not
            if (mergeType != MergeType.KeepPriorityOnly && _datMetadatas.Any(meta => string.IsNullOrEmpty(meta.Tag)))
            {
                WarningLB.Visible = true;
                SetWarning($"Tag gamename selected, but not all tags are set. Please update");
                return;
            }

            WarningLB.Visible = false;
            ProcessMerge(_datMetadatas, (MergeType)MethodCB.SelectedItem);
        }

        private void MergeDatAuthorTB_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DefaultAuthor = MergeDatAuthorTB.Text;
        }

        private void MergeDatCategoryTB_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DefaultCategory = MergeDatCategoryTB.Text;
        }

        private void MergeDatDescTB_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DefaultDesc = MergeDatDescTB.Text;
        }

        private void MergeDatNameTB_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DefaultName = MergeDatNameTB.Text;
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

        private void OpenFileAfterCreatedChB_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.OPenFileAfterCreated = OpenFileAfterCreatedChB.Checked;
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
    }
}