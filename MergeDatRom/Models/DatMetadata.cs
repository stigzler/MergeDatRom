using System;
using System.Collections.Generic;
using System.Text;

namespace MergeDatRom.Models
{
    internal class DatMetadata
    {
        public string DatFilePath { get; set; } = string.Empty;
        public string DatName { get; set; } = string.Empty;
        public string DatDescription { get; set; } = string.Empty;
        public uint Priority { get; set; } = 0;
        public string Tag { get; set; } = string.Empty;
    }
}