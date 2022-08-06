namespace Footballers.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var coaches = context.Coaches
                .ToArray()
                .Where(x => x.Footballers.Count > 0)
                .Select(x => new CoachXmlExportModel
                {
                    FootballersCount = x.Footballers.Count,
                    CoachName = x.Name,
                    Footballers = x.Footballers.Select(x => new FootballerXmlExportModel
                    {
                        Name = x.Name,
                        Position = Enum.GetName(typeof(PositionType), x.PositionType)
                    })
                    .OrderBy(x => x.Name)
                    .ToArray()
                })
                .OrderByDescending(x => x.FootballersCount)
                .ThenBy(x => x.CoachName)
                .ToArray();

            var sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(CoachXmlExportModel[]), new XmlRootAttribute("Coaches"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            var writer = new StringWriter(sb);

            serializer.Serialize(writer, coaches, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                .ToArray()
                .Where(x => x.TeamsFootballers.Any(x => x.Footballer.ContractStartDate >= date))
                .Select(x => new
                {
                    Name = x.Name,
                    Footballers = x.TeamsFootballers
                    .Where(x => x.Footballer.ContractStartDate >= date)
                    .Select(x => new
                    {
                        FootballerName = x.Footballer.Name,
                        ContractStartDate = x.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                        ContractEndDate = x.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                        BestSkillType = Enum.GetName(typeof(BestSkillType), x.Footballer.BestSkillType),
                        PositionType = Enum.GetName(typeof(PositionType), x.Footballer.PositionType)
                    })
                    .OrderByDescending(x => DateTime.ParseExact(x.ContractEndDate, "d", CultureInfo.InvariantCulture))
                    .ThenBy(x => x.FootballerName)
                })
                .OrderByDescending(x => x.Footballers.Count())
                .ThenBy(x => x.Name)
                .Take(5);

            return JsonConvert.SerializeObject(teams, Formatting.Indented);
        }
    }
}
