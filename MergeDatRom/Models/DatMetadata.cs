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
        public string Tag { get; set; } = string.Empty;

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

            using (XmlReader reader = XmlReader.Create(DatFilePath))
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