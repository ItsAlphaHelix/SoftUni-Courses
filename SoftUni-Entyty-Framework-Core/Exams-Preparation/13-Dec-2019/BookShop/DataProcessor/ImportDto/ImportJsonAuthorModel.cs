namespace BookShop.DataProcessor.ImportDto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ImportJsonAuthorModel
    {
        [Required]
        [StringLength(30 , MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{3}-[0-9]{3}-[0-9]{4}")]
        public string Phone { get; set; } 

        public IEnumerable<ImportJsonBookIdsModel> Books { get; set; }
    }
}
