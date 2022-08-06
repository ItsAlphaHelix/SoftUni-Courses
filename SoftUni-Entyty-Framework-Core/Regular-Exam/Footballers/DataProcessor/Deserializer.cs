namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var output = new StringBuilder();
            List<Coach> coachesList = new List<Coach>();

            var serializer = new XmlSerializer(typeof(CoachXmlImportModel[]), new XmlRootAttribute("Coaches"));
            var reader = new StringReader(xmlString);

            var xmlCoaches = (CoachXmlImportModel[])serializer.Deserialize(reader);

            foreach (var xmlCoache in xmlCoaches)
            {
                if (!IsValid(xmlCoache))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var coach = new Coach
                {
                    Name = xmlCoache.Name,
                    Nationality = xmlCoache.Nationality,
                };

                foreach (var xmlFootballer in xmlCoache.Footballers)
                {
                    var isParsedStartDate = DateTime.TryParseExact(xmlFootballer.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime contractStartDate);

                    var isParsedEndDate = DateTime.TryParseExact(xmlFootballer.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime contractEndDate);

                    var isParsedBestSkillType = Enum.TryParse<BestSkillType>(xmlFootballer.BestSkillType, out var bestSkillType);

                    var isParsedPositionType = Enum.TryParse<PositionType>(xmlFootballer.PositionType, out var positionType);

                    if (!IsValid(xmlFootballer) || contractStartDate > contractEndDate || !isParsedStartDate || !isParsedEndDate || !isParsedBestSkillType || !isParsedPositionType)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    coach.Footballers.Add(new Footballer
                    {
                        Name = xmlFootballer.Name,
                        ContractStartDate = contractStartDate,
                        ContractEndDate = contractEndDate,
                        BestSkillType = bestSkillType,
                        PositionType = positionType,
                    });
                }

                coachesList.Add(coach);
                output.AppendLine(String.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
            }

            context.Coaches.AddRange(coachesList);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var output = new StringBuilder();
            List<Team> teamsList = new List<Team>();

            var jsonTeams = JsonConvert.DeserializeObject<IEnumerable<TeamJsonImportModel>>(jsonString);

            foreach (var jsonTeam in jsonTeams)
            {
                if (!IsValid(jsonTeam) || jsonTeam.Trophies <= 0)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var team = new Team
                {
                    Name = jsonTeam.Name,
                    Nationality = jsonTeam.Nationality,
                    Trophies = jsonTeam.Trophies,
                };

                var uniqueIdFootballers = jsonTeam.Footballers.Distinct();

                foreach (var footballerId in uniqueIdFootballers)
                {
                    var footballer = context.Footballers.Find(footballerId);

                    if (footballer == null)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    team.TeamsFootballers.Add(new TeamFootballer
                    {
                        Team = team,
                        Footballer = footballer,
                    });
                }

                output.AppendLine(String.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
                teamsList.Add(team);
            }

            context.Teams.AddRange(teamsList);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
