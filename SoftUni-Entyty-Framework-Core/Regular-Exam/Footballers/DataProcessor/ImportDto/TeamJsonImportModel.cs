using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Footballers.DataProcessor.ImportDto
{
    public class TeamJsonImportModel
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression(@"[A-z\d\-\s.]+")]
        public string Name { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Nationality { get; set; }

        public int Trophies { get; set; }

        public int[] Footballers { get; set; }
    }
}

//• Id – integer, Primary Key
//• Name – text with length [3, 40]. May contain letters (lower and upper case), digits, spaces, a dot sign ('.') and a dash ('-'). (required)
//• Nationality – text with length [2, 40] (required)
//• Trophies – integer(required)
//• TeamsFootballers – collection of type TeamFootballer