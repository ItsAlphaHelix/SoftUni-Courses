namespace MusicHub.Data.MapperProfilers
{
    using AutoMapper;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class SongPerformerDtoProfile : Profile
    {
        public SongPerformerDtoProfile()
        {
            this.CreateMap<SongPerformer, SongPerformerDto>();
        }
    }
}
