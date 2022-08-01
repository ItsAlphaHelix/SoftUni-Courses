using System.Xml.Serialization;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Task")]
    public class TaskXmlExportModel
    {
        public string Name { get; set; }

        public LabelType Label { get; set; }
    }
}