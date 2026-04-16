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

        internal BindingList<DatMetadata> GetDatMetadata()
        {
            _loggingService.Log("Loading DAT metadata.");
            return new BindingList<DatMetadata>();
        }
    }
}
