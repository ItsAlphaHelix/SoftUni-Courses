namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Initializer;
    using MusicHub.Data.Config;
    using MusicHub.Data.MapperProfilers;
    using MusicHub.Data.Models.Dtos;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            var result = ExportSongsAboveDuration(context, 9);

            Console.WriteLine(result);
        }
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId) //Task 02.
        {

            var albums = context.Albums
                .ProjectTo<AlbumDto>(Config.config)
                .ToList()
                .Where(x => x.ProducerId == producerId)
                .OrderByDescending(x => x.Price);

            StringBuilder sb = new StringBuilder();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");

                int countOfSongs = 1;
               foreach (var song in album.Songs)
               {
                    sb.AppendLine($"---#{countOfSongs++}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price:F2}");
                    sb.AppendLine($"---Writer: {song.WriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration) //Task 03.
        {
            var songs = context.Songs
                .ProjectTo<SongDtoTwo>(Config.config)
                .ToList()
               .Where(x => x.Duration.TotalSeconds > duration)
               .OrderBy(x => x.Name)
               .ThenBy(x => x.WriterName);


            int counter = 1;

            StringBuilder sb = new StringBuilder();

            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{counter++}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.WriterName}");
                foreach (var name in song.SongPerformers)
                {
                    sb.AppendLine($"---Performer: {name.PerformerFirstName} {name.PerformerLastName}");
                }
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducerName}");
                sb.AppendLine($"---Duration: {song.Duration}");
            }

            return sb.ToString().TrimEnd();         
        }
    }
}
