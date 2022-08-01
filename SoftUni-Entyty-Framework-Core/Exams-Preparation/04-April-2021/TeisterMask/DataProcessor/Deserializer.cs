namespace TeisterMask.DataProcessor
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
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {

            //StringBuilder sb = new StringBuilder();
            //List<Project> projects = new List<Project>();

            //XmlSerializer serializer = new XmlSerializer(typeof(ProjectImportXmlModel[]), new XmlRootAttribute("Projects"));
            //using StringReader reader = new StringReader(xmlString);

            //var deserialize = (ProjectImportXmlModel[])serializer.Deserialize(reader);

            //foreach (var projectItem in deserialize)
            //{
            //    if (!IsValid(projectItem))
            //    {
            //        sb.AppendLine(ErrorMessage);
            //        continue;
            //    }

            //    DateTime projectOpenDate;
            //    DateTime projectDueDate;
            //    var checkProjectOpenDate = DateTime.TryParseExact(projectItem.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
            //        DateTimeStyles.None, out projectOpenDate);
            //    var checkProjectDueDate = DateTime.TryParseExact(projectItem.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
            //        DateTimeStyles.None, out projectDueDate);

            //    Project project = new Project()
            //    {
            //        Name = projectItem.Name,
            //        OpenDate = projectOpenDate,
            //        DueDate = projectDueDate,
            //    };

            //    foreach (var taskItem in projectItem.Tasks)
            //    {
            //        if (!IsValid(taskItem))
            //        {
            //            sb.AppendLine(ErrorMessage);
            //            continue;
            //        }

            //        DateTime taskOpenDate;
            //        DateTime taskDueDate;
            //        var checkTaskOpenDate = DateTime.TryParseExact(taskItem.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
            //            DateTimeStyles.None, out taskOpenDate);
            //        var checkTaskDueDate = DateTime.TryParseExact(taskItem.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
            //            DateTimeStyles.None, out taskDueDate);

            //        if (!checkTaskOpenDate || !checkTaskDueDate)
            //        {
            //            sb.AppendLine(ErrorMessage);
            //            continue;
            //        }

            //        if (taskOpenDate < projectOpenDate)
            //        {
            //            sb.AppendLine(ErrorMessage);
            //            continue;
            //        }

            //        if (projectDueDate.Year > 0001 && taskDueDate > projectDueDate)
            //        {
            //            sb.AppendLine(ErrorMessage);
            //            continue;
            //        }

            //        project.Tasks.Add(new Task()
            //        {
            //            Name = taskItem.Name,
            //            OpenDate = taskOpenDate,
            //            DueDate = taskDueDate,
            //            ExecutionType = Enum.Parse<ExecutionType>(taskItem.ExecutionType),
            //            LabelType = Enum.Parse<LabelType>(taskItem.LabelType)
            //        });
            //    }

            //    projects.Add(project);
            //    sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count()));
            //}

            //context.Projects.AddRange(projects);
            //context.SaveChanges();

            //return sb.ToString().TrimEnd();

            StringBuilder output = new StringBuilder();
            List<Project> projectsList = new List<Project>();

            XmlSerializer serializer = new XmlSerializer(typeof(ProjectImportXmlModel[]), new XmlRootAttribute("Projects"));
            StringReader reader = new StringReader(xmlString);

            var xmlProjects = (ProjectImportXmlModel[])serializer.Deserialize(reader);

            foreach (var xmlProject in xmlProjects)
            {
                if (!IsValid(xmlProject))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var openDate = DateTime.ParseExact(xmlProject.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                var isParsedDueDate = DateTime.TryParseExact(xmlProject.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDate);

                var nullableDueDate = isParsedDueDate ? (DateTime?)dueDate : null;

                var project = new Project
                {
                    Name = xmlProject.Name,
                    OpenDate = openDate,
                    DueDate = nullableDueDate,
                };

                foreach (var xmlTask in xmlProject.Tasks)
                {
                    var isParsedOpenDateTask = DateTime.TryParseExact(xmlTask.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime openDateTask);

                    var isParsedDueDateTask = DateTime.TryParseExact(xmlTask.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDateTask);


                    if (!IsValid(xmlTask) || openDateTask < openDate || dueDateTask > nullableDueDate || !isParsedOpenDateTask || !isParsedDueDateTask)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    project.Tasks.Add(new Task
                    {
                        Name = xmlTask.Name,
                        OpenDate = openDateTask,
                        DueDate = dueDateTask,
                        ExecutionType = Enum.Parse<ExecutionType>(xmlTask.ExecutionType),
                        LabelType = Enum.Parse<LabelType>(xmlTask.LabelType)
                    });
                }

                projectsList.Add(project);
                output.AppendLine(String.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            context.Projects.AddRange(projectsList);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();
            List<Employee> employeesList = new List<Employee>();
            
            var jsonEmployees = JsonConvert.DeserializeObject<IEnumerable<EmployeeJsonImportModel>>(jsonString);

            foreach (var jsonEmployee in jsonEmployees)
            {
                if (!IsValid(jsonEmployee))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = jsonEmployee.Username,
                    Email = jsonEmployee.Email,
                    Phone = jsonEmployee.Phone,
                };

                var uniqueTaskIds = jsonEmployee.Tasks.Distinct();

                foreach (var jsonTask in uniqueTaskIds)
                {
                    var task = context.Tasks.Find(jsonTask);

                    if (task == null)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask
                    {
                        Employee = employee,
                        Task = task
                    });
                }

                employeesList.Add(employee);
                output.AppendLine(String.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(employeesList);
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