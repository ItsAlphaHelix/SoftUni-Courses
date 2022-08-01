namespace TeisterMask.DataProcessor.ImportDto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Project")]
    public class ProjectImportXmlModel
    {
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }
        
        [Required]
        public string OpenDate { get; set; }

        public string DueDate { get; set; }

        [XmlArray]
        public TaskImportXmlModel[] Tasks { get; set; }
    }
}