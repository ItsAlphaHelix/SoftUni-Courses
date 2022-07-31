
namespace Theatre.DataProcessor.ImportDto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TheatreJsonImportModel
    {
        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Name { get; set; }

        [Range(1, 10)]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Director { get; set; }

        public IEnumerable<TicketJsonImportModel> Tickets { get; set; }
    }
}