namespace MusicHub.Data.Models.Dtos
{
    using AutoMapper;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    public class SongDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string WriterName { get; set; }
    }
}
