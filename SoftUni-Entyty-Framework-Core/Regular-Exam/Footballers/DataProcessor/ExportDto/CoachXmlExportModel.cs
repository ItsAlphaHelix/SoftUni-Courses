using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Coach")]
    public class CoachXmlExportModel
    {
        [XmlAttribute]
        public int FootballersCount { get; set; }

        public string CoachName { get; set; }

        [XmlArray]
        public FootballerXmlExportModel[] Footballers { get; set; }
    }
}
