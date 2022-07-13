namespace MusicHub.Data.MapperProfilers
{
    using AutoMapper;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class SongDtoProfileTwo : Profile
    {
        public SongDtoProfileTwo()
        {
            this.CreateMap<Song, SongDtoTwo>()
            .ForMember(x => x.SongPerformers, options => options.MapFrom(x => x.SongPerformers.Select(x => new SongPerformer
             {
                 Performer = x.Performer
             })
            .OrderBy(x => x.Performer.FirstName)
            .ThenBy(x => x.Performer.LastName)));
        }
    }
}
