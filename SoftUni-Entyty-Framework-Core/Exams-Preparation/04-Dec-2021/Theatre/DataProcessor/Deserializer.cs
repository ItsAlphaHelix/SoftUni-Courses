namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder output = new StringBuilder();
            List<Play> playsList = new List<Play>();

            XmlSerializer serializer = new XmlSerializer(typeof(PlayXmlImportModel[]), new XmlRootAttribute("Plays"));
            StringReader reader = new StringReader(xmlString);

            var xmlPlays = (PlayXmlImportModel[])serializer.Deserialize(reader);

            foreach (var xmlPlay in xmlPlays)
            {
                var isParsedGenre = Enum.TryParse<Genre>(xmlPlay.Genre, out var genre);

                var oneHourDuration = new TimeSpan(01, 00, 00);

                var playDuration = TimeSpan.Parse(xmlPlay.Duration, CultureInfo.InvariantCulture);
                
                if (!IsValid(xmlPlay) || !isParsedGenre || playDuration < oneHourDuration)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var play = new Play
                {
                    Title = xmlPlay.Title,
                    Duration = playDuration,
                    Rating = xmlPlay.Rating,
                    Genre = genre,
                    Description = xmlPlay.Description,
                    Screenwriter = xmlPlay.Screenwriter,
                };

                playsList.Add(play);

                output.AppendLine(String.Format(SuccessfulImportPlay, play.Title, play.Genre, play.Rating));
            }

            context.Plays.AddRange(playsList);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder output = new StringBuilder();
            List<Cast> castsList = new List<Cast>();

            XmlSerializer serializer = new XmlSerializer(typeof(CastXmlImportModel[]), new XmlRootAttribute("Casts"));
            StringReader reader = new StringReader(xmlString);

            var xmlCasts = (CastXmlImportModel[])serializer.Deserialize(reader);

            foreach (var xmlCast in xmlCasts)
            {
                if (!IsValid(xmlCast))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var cast = new Cast
                {
                    FullName = xmlCast.FullName,
                    IsMainCharacter = xmlCast.IsMainCharacter,
                    PhoneNumber = xmlCast.PhoneNumber,
                    PlayId = xmlCast.PlayId
                };

                castsList.Add(cast);
                output.AppendLine(String.Format(SuccessfulImportActor, cast.FullName, cast.IsMainCharacter ? "main" : "lesser"));
            }

            context.Casts.AddRange(castsList);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();
            List<Theatre> theatresList = new List<Theatre>();

            var jsonTheatres = JsonConvert.DeserializeObject<IEnumerable<TheatreJsonImportModel>>(jsonString);

            foreach (var jsonTheatre in jsonTheatres)
            {
                if (!IsValid(jsonTheatre))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var ticket in jsonTheatre.Tickets)
                {
                    if (!IsValid(ticket))
                    {
                        output.AppendLine(ErrorMessage);
                    }
                }

                var theatre = new Theatre
                {
                    Name = jsonTheatre.Name,
                    NumberOfHalls = jsonTheatre.NumberOfHalls,
                    Director = jsonTheatre.Director,
                    Tickets = jsonTheatre.Tickets
                    .Where(x => IsValid(x))
                    .Select(x => new Ticket
                    {
                        Price = x.Price,
                        RowNumber = x.RowNumber,
                        PlayId = x.PlayId,
                    }).ToList()
                };

                theatresList.Add(theatre);
                output.AppendLine(String.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count()));
            }

            context.Theatres.AddRange(theatresList);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
