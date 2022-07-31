namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theateres = context.Theatres
                .ToList()
                .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count >= 20)
                .Select(x => new
                {
                    Name = x.Name,
                    Halls = x.NumberOfHalls,
                    TotalIncome = x.Tickets
                    .Where(x => x.RowNumber >= 1 && x.RowNumber <= 5)
                    .Sum(x => x.Price),
                    Tickets = x.Tickets
                    .Where(x => x.RowNumber >= 1 && x.RowNumber <= 5)
                    .Select(x => new
                    {
                        Price = decimal.Parse(x.Price.ToString("F2")),
                        RowNumber = x.RowNumber
                    })
                    .OrderByDescending(x => x.Price)
                })
                .OrderByDescending(x => x.Halls)
                .ThenBy(x => x.Name);

            return JsonConvert.SerializeObject(theateres, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays
                .Where(x => x.Rating <= rating)
                .Select(x => new PlayXmlExportModel
                {
                    Title = x.Title,
                    Duration = x.Duration.ToString("c", CultureInfo.InvariantCulture),
                    Rating = x.Rating == 0 ? "Premier" : x.Rating.ToString(),
                    Genre = x.Genre,
                    Actors = x.Casts
                    .Where(x => x.IsMainCharacter == true)
                    .Select(x => new ActorXmlExportModel
                    {
                        FullName = x.FullName,
                        MainCharacter = $"Plays main character in '{x.Play.Title}'."
                    })
                    .OrderByDescending(x => x.FullName)
                    .ToArray()
                })
                .OrderBy(x => x.Title)
                .ThenByDescending(x => x.Genre)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(PlayXmlExportModel[]), new XmlRootAttribute("Plays"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            serializer.Serialize(writer, plays, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
