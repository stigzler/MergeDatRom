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
        private readonly DatMetadataService _datMetadataService;
        private readonly LoggingService _loggingService;

        private readonly BindingList<DatMetadata> _datMetadatas = new BindingList<DatMetadata>();
        private bool _suppressSelectionChanged;

        public Main(DatMetadataService datMetadataService, LoggingService loggingService)
        {
            _datMetadataService = datMetadataService;
            _loggingService = loggingService;
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            MainLB.DataSource = _datMetadatas;
            MainLB.DisplayMember = nameof(DatMetadata.DatName);

            MethodCB.DataSource = Enum.GetValues<MergeType>();
            TagPositionCB.DataSource = Enum.GetValues<TagPosition>();

            _loggingService.LogClear();
            _loggingService.Log("Starting application.");
        }

        private void darkModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DarkMode = !this.DarkMode;
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

            _loggingService.Log($"User selected {ofd.FileNames.Length} DAT files to load:{Environment.NewLine}"
                + String.Join(Environment.NewLine, ofd.FileNames));

            LoadDatFiles(ofd.FileNames.ToList());
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

        private void PriorityUpBT_Click(object sender, EventArgs e)
        {
            MoveSelectedDat(-1);
        }

        private void PriorityDownBT_Click(object sender, EventArgs e)
        {
            MoveSelectedDat(1);
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

        private void MainLB_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void MainLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressSelectionChanged) return;
            MainPG.SelectedObject = MainLB.SelectedItem;
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
                    case MergeType.PriorityOnly: // Only use priority
                                                 // Keep games[0], discard others (logic depends on your export)
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

            Debug.WriteLine($"Merge process completed. Final game counts:{nameGroups.Count}");
        }

        private void ApplyTag(XElement game)
        {
            var meta = game.Annotation<DatMetadata>();
            if (meta == null || string.IsNullOrEmpty(meta.Tag)) return;

            var nameAttr = game.Attribute("name");
            if (nameAttr != null)
                nameAttr.Value = $"{nameAttr.Value} ({meta.Tag})";

            var descElem = game.Element("description");
            if (descElem != null)
                descElem.Value = $"{descElem.Value} ({meta.Tag})";
        }

        private void MergeBT_Click(object sender, EventArgs e)
        {
            ProcessMerge(_datMetadatas, (MergeType)MethodCB.SelectedItem);
        }
    }
}