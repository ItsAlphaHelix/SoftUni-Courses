using AutoMapper;
using MusicHub.Data.Models;
using MusicHub.Data.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicHub.Data.MapperProfilers
{
    public class SongDtoProfile : Profile
    {
        public SongDtoProfile()
        {
            this.CreateMap<Song, SongDto>();
        }
    }
}
