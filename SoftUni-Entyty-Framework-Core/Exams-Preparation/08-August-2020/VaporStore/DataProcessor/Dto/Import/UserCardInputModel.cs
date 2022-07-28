namespace VaporStore.DataProcessor.Dto.Import
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class UserCardInputModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        [RegularExpression(@"([A-Z]{1}[a-z]+)\s([A-Z]{1}[a-z]+)")]
        public string FullName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }

        public IEnumerable<CardInputModel> Cards { get; set; }
    }
}
//text, which has two words, consisting of Latin letters. Both start with an upper letter and are followed by lower letters. The two words are separated by a single space (ex. "John Smith")
