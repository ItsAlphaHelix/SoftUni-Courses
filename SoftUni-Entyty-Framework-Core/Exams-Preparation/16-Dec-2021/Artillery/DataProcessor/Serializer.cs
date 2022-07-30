
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context.Shells
                .ToList()
                .Where(x => x.ShellWeight > shellWeight)
                .Select(x => new
                {
                    ShellWeight = x.ShellWeight,
                    Caliber = x.Caliber,
                    Guns = x.Guns
                    .Where(x => x.GunType.ToString() == "AntiAircraftGun")
                    .Select(x => new
                    {
                        GunType = Enum.GetName(typeof(GunType), x.GunType),
                        GunWeight = x.GunWeight,
                        BarrelLength = x.BarrelLength,
                        Range = x.Range > 3000 ? "Long-range" : "Regular range"
                    })
                    .OrderByDescending(x => x.GunWeight)
                })
                .OrderBy(x => x.ShellWeight);

             return JsonConvert.SerializeObject(shells, Formatting.Indented);
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var guns = context.Guns
                .Where(x => x.Manufacturer.ManufacturerName == manufacturer)
                .Select(x => new GunXmlExportModel
                {
                    Manufacturer = x.Manufacturer.ManufacturerName,
                    GunType = x.GunType.ToString(),
                    GunWeight = x.GunWeight,
                    BarrelLength = x.BarrelLength,
                    Range = x.Range,
                    Countries = x.CountriesGuns
                    .Where(x => x.Country.ArmySize > 4500000)
                    .Select(x => new CountryXmlExportModel
                    {
                        Country = x.Country.CountryName,
                        ArmySize = x.Country.ArmySize
                    })
                    .OrderBy(x => x.ArmySize)
                    .ToArray()
                })
                .OrderBy(x => x.BarrelLength)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(GunXmlExportModel[]), new XmlRootAttribute("Guns"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            serializer.Serialize(writer, guns, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
