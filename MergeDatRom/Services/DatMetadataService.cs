using MergeDatRom.Models;
using System.ComponentModel;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace MergeDatRom.Services
{
    public class DatMetadataService
    {
        private readonly LoggingService _loggingService;

        public DatMetadataService(LoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        internal bool CreateMergedDatFile(IDictionary<string, List<XElement>> nameGroups,
            string filename, string name, string description, string author, string category)
        {
            try
            {
                _loggingService.Log($"Creating merged DAT file: {filename}");

                var outputDirectory = Path.GetDirectoryName(filename);
                if (!string.IsNullOrWhiteSpace(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";

                var header = new XElement("header",
                    new XElement("name", name ?? string.Empty),
                    new XElement("description", description ?? string.Empty),
                    new XElement("date", DateTime.Now.ToString("yyyyMMdd-HHmmss")),
                    new XElement("author", author ?? string.Empty),
                    new XElement("category", category ?? string.Empty)
                );

                var root = new XElement("datafile",
                    new XAttribute(XNamespace.Xmlns + "xsi", xsi),
                    new XAttribute(xsi + "schemaLocation", "https://datomatic.no-intro.org/stuff https://datomatic.no-intro.org/stuff/schema_nointro_datfile_v3.xsd"),
                    header
                );

                foreach (var gameGroup in nameGroups.Values)
                {
                    foreach (var game in gameGroup)
                    {
                        root.Add(new XElement(game));
                    }
                }

                var doc = new XDocument(new XDeclaration("1.0", "utf-8", null), root);

                var settings = new XmlWriterSettings
                {
                    Indent = true,
                    OmitXmlDeclaration = false,
                    Encoding = new UTF8Encoding(false)
                };

                using var writer = XmlWriter.Create(filename, settings);
                doc.Save(writer);

                _loggingService.Log($"Merged DAT file created successfully with {root.Elements("game").Count()} game entries: {filename}");
                return true;
            }
            catch (Exception ex)
            {
                _loggingService.Log($"ERROR creating merged DAT file '{filename}': {ex.Message}");
                return false;
            }
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