namespace VaporStore.DataProcessor
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
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			var output = new StringBuilder();
			var games = JsonConvert
				.DeserializeObject<IEnumerable<GameDeveloperInputModel>>(jsonString);
			foreach (var jsonGame in games)
			{
				if (!IsValid(jsonGame) || jsonGame.Tags.Count() == 0)
				{
					// Invalid data
					output.AppendLine("Invalid Data");
					continue;
				}

				// Valid data
				var genre = context.Genres.FirstOrDefault(x => x.Name == jsonGame.Genre)
					?? new Genre { Name = jsonGame.Genre };
				var developer = context.Developers.FirstOrDefault(x => x.Name == jsonGame.Developer)
					?? new Developer { Name = jsonGame.Developer };

				var game = new Game
				{
					Name = jsonGame.Name,
					Genre = genre,
					Developer = developer,
					Price = jsonGame.Price,
					ReleaseDate = jsonGame.ReleaseDate.Value,
				};
				foreach (var jsonTag in jsonGame.Tags)
				{
					var tag = context.Tags.FirstOrDefault(x => x.Name == jsonTag)
						?? new Tag { Name = jsonTag };
					game.GameTags.Add(new GameTag { Tag = tag });
				}

				context.Games.Add(game);
				context.SaveChanges();
				output.AppendLine($"Added {jsonGame.Name} ({jsonGame.Genre}) with {jsonGame.Tags.Count()} tags");
			}

			return output.ToString();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			var output = new StringBuilder();
			var usersList = new List<User>();
			var users = JsonConvert.DeserializeObject<IEnumerable<UserCardInputModel>>(jsonString);

            foreach (var jsonUser in users)
            {
                if (!IsValid(jsonUser) || !jsonUser.Cards.All(IsValid))
                {
					output.AppendLine("Invalid Data");
					continue;
                }

				var usersCards = new User
				{
					FullName = jsonUser.FullName,
					Username = jsonUser.Username,
					Email = jsonUser.Email,
					Age = jsonUser.Age,
					Cards = jsonUser.Cards.Select(x => new Card
                    {
						Number = x.Number,
						Cvc = x.CVC,
						Type = Enum.Parse<CardType>(x.Type)
                    }).ToList()
				};

				usersList.Add(usersCards);
				output.AppendLine($"Imported {usersCards.Username} with {usersCards.Cards.Count} cards");
            }

			context.Users.AddRange(usersList);
			context.SaveChanges();

			return output.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			var output = new StringBuilder();
			var purchasesList = new List<Purchase>();
			var serializer = new XmlSerializer(typeof(PurchaseInputModel[]), new XmlRootAttribute("Purchases"));
			var reader = new StringReader(xmlString);

			var deserializedPurchases = (PurchaseInputModel[])serializer.Deserialize(reader);

            foreach (var xmlPurchase in deserializedPurchases)
            {
                if (!IsValid(xmlPurchase))
                {
					output.AppendLine("Invalid Data");
					continue;
				}

				bool isParsedDate = DateTime.TryParseExact(xmlPurchase.Date,
					"dd/MM/yyyy HH:mm",
					CultureInfo.InvariantCulture, DateTimeStyles.None, out var date
					);

                if (!isParsedDate)
                {
					output.AppendLine("Invalid Data");
					continue;
				}

				var puchases = new Purchase
				{
					Game = context.Games.FirstOrDefault(x => x.Name == xmlPurchase.Title),
					Type = xmlPurchase.Type.Value,
					ProductKey = xmlPurchase.Key,
					Card = context.Cards.FirstOrDefault(x => x.Number == xmlPurchase.Card),
					Date = date
				};

				purchasesList.Add(puchases);
				output.AppendLine($"Imported {puchases.Game.Name} for {puchases.Card.User.Username}");
			}

			context.Purchases.AddRange(purchasesList);
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