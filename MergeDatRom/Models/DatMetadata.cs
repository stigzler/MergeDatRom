using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml;

namespace MergeDatRom.Models
{
    internal class DatMetadata
    {
        [ReadOnly(true)]
        public string DatDescription { get; set; } = string.Empty;

        [ReadOnly(true)]
        public string DatFilePath { get; set; } = string.Empty;

        [ReadOnly(true)]
        public string DatName { get; set; } = string.Empty;

        //public uint Priority { get; set; } = 0;
        [Description("When adding a file type Tag, what to tag these files as")]
        public string Tag { get; set; } = string.Empty;

        [Description("If a filename contains this tag, exclude it from the merged DAT. " +
            "Separate multiple tags with a comma, without parenthesis or square brackets")]
        public string ExcludeTags { get; set; } = string.Empty;

        [Description("If a filename contains this tag, include it in the merged DAT. In priority order. If tag is identified, skips all other checks. Still processes dats in order." +
            "Separate multiple tags with a comma, without parenthesis or square brackets")]
        public string IncludeTags { get; set; } = string.Empty;

        public DatMetadata(string datFilePath)
        {
            DatFilePath = datFilePath;
            if (File.Exists(datFilePath))
            {
                PopulateHeaderInfo();
            }
            else
            {
                DatName = "{Could Not Load DAT}";
                DatDescription = "{Could Not Load DAT}";
            }
        }

        public void PopulateHeaderInfo()
        {
            if (!File.Exists(DatFilePath)) return;

            var settings = new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Ignore
            };

            using (XmlReader reader = XmlReader.Create(DatFilePath, settings))
            {
                while (reader.Read())
                {
                    // We only care about the <header> section
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "name":
                                this.DatName = reader.ReadElementContentAsString();
                                break;

                            case "description":
                                this.DatDescription = reader.ReadElementContentAsString();
                                break;
                        }
                    }

                    // Once we hit the first <game> tag, the header is over. Stop reading.
                    if (reader.Name == "game") break;
                }
            }
        }
    }
}