namespace MusicHub.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Writer
    {
        public Writer()
        {
            this.Songs = new HashSet<Song>();
        }
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        public string Pseudonym { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
