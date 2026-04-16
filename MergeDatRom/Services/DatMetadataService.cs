using MergeDatRom.Models;
using System.ComponentModel;

namespace MergeDatRom.Services
{
    public class DatMetadataService
    {
        private readonly LoggingService _loggingService;

        public DatMetadataService(LoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        internal BindingList<DatMetadata> GetDatMetadata(List<string> datFilePaths)
        {
            _loggingService.Log("Loading DAT metadata.");

            BindingList<DatMetadata> datMetadataList = new BindingList<DatMetadata>();

            foreach (string datFilePath in datFilePaths)
            {
                try
                {
                    DatMetadata datMetadata = new DatMetadata(datFilePath);
                    datMetadataList.Add(datMetadata);
                    _loggingService.Log("Loaded DAT metadata from: " + datFilePath);
                }
                catch (Exception ex)
                {
                    _loggingService.Log($"ERROR loading DAT metadata from '{datFilePath}': {ex.Message}");
                }
            }

            return datMetadataList;
        }
    }
}