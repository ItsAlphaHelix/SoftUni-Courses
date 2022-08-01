
namespace TeisterMask.DataProcessor.ExportDto
{
    using System;
    using System.Xml.Serialization;

    [XmlType("Project")]
    public class ProjectXmlExportModel
    {
        [XmlAttribute]

        public int TasksCount { get; set; }

        public string ProjectName { get; set; }

        public string HasEndDate { get; set; }

        [XmlArray]

        public TaskXmlExportModel[] Tasks { get; set; }
    }
}
