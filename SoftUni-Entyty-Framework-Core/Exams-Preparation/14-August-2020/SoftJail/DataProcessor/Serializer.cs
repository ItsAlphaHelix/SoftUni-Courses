namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {

            var prisoners = context.Prisoners
                .ToList()
                .Where(x => ids.Contains(x.Id))
                .Select(x => new PrisonerCellOfficerByIdExportModel
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers.Select(x => new OfficerExportModel
                    {
                        OfficerName = x.Officer.FullName,
                        Department = x.Officer.Department.Name
                    })
                    .OrderBy(x => x.OfficerName)
                    .ToList(),
                    TotalOfficerSalary = x.PrisonerOfficers.Sum(x => x.Officer.Salary)
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id);

            return JsonConvert.SerializeObject(prisoners, Formatting.Indented);
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string[] names = prisonersNames.Split(",").ToArray();

            //StringBuilder sb = new StringBuilder();
            //var serializer = new XmlSerializer(typeof(PrisonerInboxExportModel[]), new XmlRootAttribute("Prisoners"));
            //var namespaces = new XmlSerializerNamespaces();
            //namespaces.Add("", "");
            //var writer = new StringWriter(sb);

            var ids = new[] { 2, 3, 8 };

            var prisoners = context.Prisoners
                .ToArray()
                .Where(x => names.Contains(x.FullName))
                .Select(x => new PrisonerInboxExportModel
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd"),
                    Mails = x.Mails.Select(x => new MailExportModel
                    {
                        Description = new string(x.Description.Reverse().ToArray())
                    }).ToArray()
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            //This is Xml-Facade.
            //For more information click here -> https://github.com/StoyanShopov/XmlFacade
            var serializered = XmlConverter.Serialize<PrisonerInboxExportModel[]>(prisoners, "Prisoners");

             // serializer.Serialize(writer, prisoners, namespaces);

            return serializered.ToString();
        }
    }
}