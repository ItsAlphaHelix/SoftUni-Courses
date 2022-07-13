namespace MusicHub.Data.Models.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class SongDtoTwo
    {
        public string Name { get; set; }

        public string WriterName { get; set; }

        public ICollection<SongPerformerDto> SongPerformers { get; set; }
        public string AlbumProducerName { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
