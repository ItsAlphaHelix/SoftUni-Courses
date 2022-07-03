namespace SoftUni
{
    using SoftUni.Data;
    using SoftUni.Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();
            var result = RemoveTown(db);
            Console.WriteLine(result);

        }
        public static string GetEmployeesFullInformation(SoftUniContext context) //Task 03.
        {
            var employees = context.Employees
                .Select(x => new
                {
                    x.EmployeeId,
                    x.FirstName,
                    x.LastName,
                    x.MiddleName,
                    x.JobTitle,
                    x.Salary
                })
                .ToList()
                .OrderBy(x => x.EmployeeId);

            StringBuilder sb = new StringBuilder();

            foreach (var person in employees)
            {
                sb.AppendLine($"{person.FirstName} {person.LastName} {person.MiddleName} {person.JobTitle} {person.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context) //Task 04.
        {
            var employees = context.Employees
                .Select(x => new
                {
                    x.FirstName,
                    x.Salary
                })
                .ToList()
                .OrderBy(x => x.FirstName)
                .Where(x => x.Salary > 50000);

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context) //Task 05.
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                .Where(x => x.Department.Name == "Research and Development")
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    deppName = x.Department.Name,
                    salary = x.Salary,
                })
                .OrderBy(x => x.salary)
                .ThenByDescending(x => x.firstName)
                .ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.firstName} {e.lastName} from {e.deppName} - ${e.salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context) //Task 06.
        {
            var lastNameNakov = context.Employees.First(x => x.LastName == "Nakov");

            var address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(address);
            lastNameNakov.Address = address;

            context.SaveChanges();

            var employees = context.Employees
                 .OrderByDescending(x => x.AddressId)
                 .Take(10)
                 .Select(x => x.Address.AddressText)
                 .ToList();

            return String.Join("\n", employees);

        }

        public static string GetEmployeesInPeriod(SoftUniContext context) //Task 07.
        {
            StringBuilder sb = new StringBuilder();

            var employee = context.Employees
                .Where(x => x.EmployeesProjects.Any(x => x.Project.StartDate.Year >= 2001 && x.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    employeeFullName = string.Concat(x.FirstName, " ", x.LastName),
                    managerFullName = string.Concat(x.Manager.FirstName, " ", x.Manager.LastName),
                    Project = x.EmployeesProjects.Select(x => new
                    {
                        ProjectName = x.Project.Name,
                        ProjectStartDate = x.Project.StartDate,
                        ProjectEndDate = x.Project.EndDate
                    })
                })
                .Take(10)
                .ToList();

            foreach (var e in employee)
            {
                sb.AppendLine($"{e.employeeFullName} - Manager: {e.managerFullName}");

                foreach (var p in e.Project)
                {
                    var projcetEnd = p.ProjectEndDate.HasValue ? p.ProjectEndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished";

                    sb.AppendLine($"--{p.ProjectName} - {p.ProjectStartDate.ToString("M/d/yyyy h:mm:ss tt")} - {projcetEnd}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context) //Task 08.
        {
            StringBuilder sb = new StringBuilder();

            var employeeAddresses = context.Addresses
                .Select(x => new
                {
                    AddressText = x.AddressText,
                    TownName = x.Town.Name,
                    Count = x.Employees.Count()
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TownName)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .ToList();

            foreach (var ea in employeeAddresses)
            {
                sb.AppendLine($"{ea.AddressText}, {ea.TownName} - {ea.Count} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context) //Task 09.
        {
            var employee = context.Employees
                .Where(x => x.EmployeeId == 147)
                .Select(x => new
                {
                   FirstName = x.FirstName,
                   LastName = x.LastName,
                   JobTitle = x.JobTitle,
                   Projects = x.EmployeesProjects
                   .OrderBy(x => x.Project.Name)
                   .Select(x => new
                   {
                       ProjectName = x.Project.Name
                   })
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employee)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");

                foreach (var p in e.Projects)
                {
                    sb.AppendLine($"{p.ProjectName}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context) //Task 10.
        {
            var employees = context.Departments
                .Where(x => x.Employees.Count() > 5)
                .OrderBy(x => x.Employees.Count())
                .ThenBy(x => x.Name)
                .Select(x => new
                {
                    depName = x.Name,
                    managerFirstName = x.Manager.FirstName,
                    managerLastName = x.Manager.LastName,
                    Employees = x.Employees.Select(x => new
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        JobTitle = x.JobTitle
                    })
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName)
                    .ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var d in employees)
            {
                sb.AppendLine($"{d.depName} - {d.managerFirstName} {d.managerLastName}");

                foreach (var e in d.Employees)
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context) //Task 11.
        {
            var project = context.Projects
                .Select(x => new
                {
                    Name = x.Name,
                    Description = x.Description,
                    StartDate = x.StartDate
                })
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .OrderBy(x => x.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var p in project)
            {
                sb.AppendLine($"{p.Name}\n{p.Description}\n{String.Format(new CultureInfo("en-US"), "{0:M/d/yyyy h:mm:ss tt}", p.StartDate)}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context) //Task 12
        {

            var employeeDeparment = context.Employees
                .Where(x => x.Department.Name == "Engineering" || x.Department.Name == "Tool Design" || x.Department.Name == "Marketing" || x.Department.Name == "Information Services");

            foreach (var ed in employeeDeparment)
            {
                ed.Salary *= 1.12M;
            }

            context.SaveChanges();

            var employee = context.Employees
                .Where(x => x.Department.Name == "Engineering" || x.Department.Name == "Tool Design" || x.Department.Name == "Marketing" || x.Department.Name == "Information Services")
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Salary = x.Salary
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employee)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context) //Task 13.
        {
            var employee = context.Employees
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    JobTitle = x.JobTitle,
                    Salary = x.Salary
                })
                .Where(x => x.FirstName.StartsWith("Sa"))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employee)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context) //Task 14.
        {
            var projectid = context.Projects.Find(2);

            var employeeProjects = context.EmployeesProjects.Where(x => x.ProjectId == 2).ToList();

            foreach (var project in employeeProjects)
            {
                context.EmployeesProjects.Remove(project);
            }

            context.Projects.Remove(projectid);

            context.SaveChanges();


            var projects = context.Projects.Take(10).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var p in projects)
            {
                sb.AppendLine($"{p.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context) //Task 15.
        {
            var targetTown = context.Towns.FirstOrDefault(x => x.Name == "Seattle");
            var employeesFromSeattle = context.Employees
                .Where(x => x.Address.TownId == targetTown.TownId)
                .ToArray();

            foreach (var e in employeesFromSeattle)
            {
                e.AddressId = null;
            }

            var addressesInSeattle = context.Addresses
                .Where(x => x.Town.Name == "Seattle")
                .ToArray();
            var totalAddresses = addressesInSeattle.Count();

            foreach (var address in addressesInSeattle)
            {
                context.Addresses.Remove(address);
            }

            context.Towns.Remove(targetTown);
            context.SaveChanges();

            return $"{totalAddresses} addresses in Seattle were deleted";
        }
    }
}
