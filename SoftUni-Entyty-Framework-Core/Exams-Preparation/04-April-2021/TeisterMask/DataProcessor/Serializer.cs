namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                .ToArray()
                .Where(x => x.Tasks.Any())
                .Select(x => new ProjectXmlExportModel
                {
                    TasksCount = x.Tasks.Count,
                    ProjectName = x.Name,
                    HasEndDate = x.DueDate.HasValue ? "Yes" : "No",
                    Tasks = x.Tasks.Select(x => new TaskXmlExportModel
                    {
                        Name = x.Name,
                        Label = x.LabelType
                    })
                    .OrderBy(x => x.Name)
                    .ToArray()
                })
                .OrderByDescending(x => x.TasksCount)
                .ThenBy(x => x.ProjectName)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ProjectXmlExportModel[]), new XmlRootAttribute("Projects"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            serializer.Serialize(writer, projects, namespaces);

            return sb.ToString().TrimEnd();
        }
        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .ToList()
                .Where(x => x.EmployeesTasks.Any())
                .Select(x => new
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks
                    .Where(x => x.Task.OpenDate >= date)
                    .Select(x => new
                    {
                        TaskName = x.Task.Name,
                        OpenDate = x.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = x.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = Enum.GetName(typeof(LabelType), x.Task.LabelType),
                        ExecutionType = Enum.GetName(typeof(ExecutionType), x.Task.ExecutionType)
                    })
                    .OrderByDescending(x => DateTime.ParseExact(x.DueDate, "d", CultureInfo.InvariantCulture))
                    .ThenBy(x => x.TaskName)
                })
                .OrderByDescending(x => x.Tasks.Count())
                .ThenBy(x => x.Username)
                .Take(10);

            return JsonConvert.SerializeObject(employees, Formatting.Indented);
        }
    }
}