using System;
using System.Collections.Generic;
using System.Text;

namespace MusicHub.Data.Models.Dtos
{
    public class AlbumDto
    {
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public decimal Price { get; set; }

        public int? ProducerId { get; set; }

        public string ProducerName { get; set; }

        public ICollection<SongDto> Songs { get; set; }
    }
}
