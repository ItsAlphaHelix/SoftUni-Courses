namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            StringBuilder output = new StringBuilder();
            List<Country> countriesList = new List<Country>();
            XmlSerializer serializer = new XmlSerializer(typeof(CountryXmlImportModel[]), new XmlRootAttribute("Countries"));
            StringReader reader = new StringReader(xmlString);

            var xmlCountries = (CountryXmlImportModel[])serializer.Deserialize(reader);

            foreach (var xmlCountry in xmlCountries)
            {
                if (!IsValid(xmlCountry))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var country = new Country
                {
                    CountryName = xmlCountry.CountryName,
                    ArmySize = xmlCountry.ArmySize,
                };

                countriesList.Add(country);
                output.AppendLine(String.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            context.Countries.AddRange(countriesList);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            StringBuilder output = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(ManufacturerXmlImportModel[]), new XmlRootAttribute("Manufacturers"));
            StringReader reader = new StringReader(xmlString);
            List<Manufacturer> manufacturersList = new List<Manufacturer>();

            var xmlManufacturers = (ManufacturerXmlImportModel[])serializer.Deserialize(reader);

            foreach (var xmlManufacturer in xmlManufacturers)
            {

                if (!IsValid(xmlManufacturer) || manufacturersList.Any(x => x.ManufacturerName == xmlManufacturer.ManufacturerName) || manufacturersList.Any(x => x.Founded == xmlManufacturer.Founded))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var manafacture = new Manufacturer
                {
                    ManufacturerName = xmlManufacturer.ManufacturerName,
                    Founded = xmlManufacturer.Founded
                };

                var countriesTowns = xmlManufacturer.Founded.Split(", ");

                List<string> listOfCountriesTowns = new List<string>();

                int count = 0;

                for (int i = countriesTowns.Length - 1; i >= 0; i--)
                {
                    count++;

                    listOfCountriesTowns.Add(countriesTowns[i]);

                    if (count == 2)
                    {
                        break;
                    }
                }

                listOfCountriesTowns.Reverse();

                manufacturersList.Add(manafacture);
                output.AppendLine(String.Format(SuccessfulImportManufacturer, manafacture.ManufacturerName, string.Join(", ", listOfCountriesTowns)));
            }

            context.Manufacturers.AddRange(manufacturersList);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            StringBuilder output = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(ShellXmlImportModel[]), new XmlRootAttribute("Shells"));
            StringReader reader = new StringReader(xmlString);
            List<Shell> shellsList = new List<Shell>();

            var xmlShells = (ShellXmlImportModel[])serializer.Deserialize(reader);

            foreach (var xmlShell in xmlShells)
            {
                if (!IsValid(xmlShell))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var shell = new Shell
                {
                    ShellWeight = xmlShell.ShellWeight,
                    Caliber = xmlShell.Caliber,
                };

                shellsList.Add(shell);
                output.AppendLine(String.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }

            context.Shells.AddRange(shellsList);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();
            List<Gun> gunsList = new List<Gun>();
            var jsonGuns = JsonConvert.DeserializeObject<IEnumerable<GunJsonImportModel>>(jsonString);

            foreach (var jsonGun in jsonGuns)
            {

                var isParsedGun = Enum.TryParse<GunType>(jsonGun.GunType, out var gunType);

                if (!IsValid(jsonGun) || !isParsedGun)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }


                var gun = new Gun
                {
                    ManufacturerId = jsonGun.ManufacturerId,
                    GunWeight = jsonGun.GunWeight,
                    BarrelLength = jsonGun.BarrelLength,
                    NumberBuild = jsonGun.NumberBuild,
                    Range = jsonGun.Range,
                    GunType = gunType,
                    ShellId = jsonGun.ShellId,
                    CountriesGuns = jsonGun.Countries.Select(x => new CountryGun
                    {
                        CountryId = x.Id
                    }).ToList()
                };

                gunsList.Add(gun);
                output.AppendLine(String.Format(SuccessfulImportGun, gun.GunType, gun.GunWeight, gun.BarrelLength));
            }

            context.Guns.AddRange(gunsList);
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
