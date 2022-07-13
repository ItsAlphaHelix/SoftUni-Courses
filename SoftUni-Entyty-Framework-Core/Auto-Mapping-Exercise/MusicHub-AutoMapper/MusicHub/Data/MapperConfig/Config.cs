namespace MusicHub.Data.Config
{
    using AutoMapper;
    using MusicHub.Data.MapperProfilers;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Config
    {
           public static MapperConfiguration config = new MapperConfiguration(config =>
            {
                config.AddProfile<AlbumDtoProfile>();
                config.AddProfile<SongDtoProfile>();
                config.AddProfile<SongDtoProfileTwo>();
                config.AddProfile<SongPerformerDtoProfile>();
            });
    }
}
