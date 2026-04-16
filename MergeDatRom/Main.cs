using MergeDatRom.Models;
using MergeDatRom.Services;
using stigzler.Winforms.Base;
using stigzler.Winforms.Base.Forms.BaseForm;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace MergeDatRom
{
    public partial class Main : BaseForm
    {
        private readonly DatMetadataService _datMetadataService;
        private readonly LoggingService _loggingService;

        private BindingList<DatMetadata> _datMetadatas = new BindingList<DatMetadata>();

        public Main(DatMetadataService datMetadataService, LoggingService loggingService)
        {
            _datMetadataService = datMetadataService;
            _loggingService = loggingService;
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
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
            _datMetadatas = _datMetadataService.GetDatMetadata();
        }
    }
}