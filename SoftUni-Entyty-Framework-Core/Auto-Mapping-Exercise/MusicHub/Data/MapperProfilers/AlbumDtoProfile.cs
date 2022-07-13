namespace MusicHub.Data.MapperProfilers
{
    using AutoMapper;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Dtos;
    using System;
    using System.Linq;

    public class AlbumDtoProfile : Profile
    {
        public AlbumDtoProfile()
        {
            this.CreateMap<Album, AlbumDto>()
                .ForMember(x => x.Songs, option => option.MapFrom(x => x.Songs.Select(x => new Song
                {
                    Name = x.Name,
                    Price = x.Price,
                    Writer = x.Writer
                })
                .OrderByDescending(x => x.Name)
                .ThenBy(x => x.Writer.Name)));     
        }
    }
}
