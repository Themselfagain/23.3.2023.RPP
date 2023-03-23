using DbFirstDemo.Data.Models;
using System;
using System.Linq;
using System.Text;

namespace DbFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();
            //var result = AllEmployes(context);
            //var result = GetEmployeesWithSalaryOver50000(context);
            //var result = GetEmployeesFromResearchAndDevelopment(context);
            //var result = GetCountOfEmployees(context);
            //var result = GetEmployeesWithFirstNameStartWithN(context);
            //var result = GetFirstTenEmployeesWithDepartment(context);
            //var result = GetEmployeesFromSalesAndMarketing(context);
            //Console.WriteLine(result);
            AddNewProject(context);
            AddTown(context);
            AddEmployeeWithProject(context);
        }

        private static void AddEmployeeWithProject(SoftUniContext context)
        {
            var employee = new Employee { FirstName = "Ani", LastName = "Ivanova", JobTitle = "Designer", HireDate = DateTime.UtcNow, Salary = 2000, DepartmentId = 2 };
            context.Employees.Add(employee);
            employee.EmployeesProjects.Add(new EmployeesProject { Project = new Project { Name = "TTT", StartDate = DateTime.UtcNow } });
            context.SaveChanges();
        }

        private static void AddTown(SoftUniContext context)
        {
            var town = new Town()
            {
                Name = "Pernik"
            };
            context.Towns.Add(town);
            context.SaveChanges();
        }

        private static void AddNewProject(SoftUniContext context)
        {
            var project = new Project()
            {
                Name = "Judge System",
                StartDate = DateTime.UtcNow
            };
            context.Projects.Add(project);
            context.SaveChanges();
        }

        private static object GetEmployeesFromSalesAndMarketing(SoftUniContext context)
        {
            var employees = context.Employees.Where(x => x.Department.Name == "Sales"|| x.Department.Name == "Marketing").Select(x => new { x.FirstName, x.LastName, x.Salary, DepartmentName = x.Department.Name }).OrderBy(x => x.DepartmentName).ThenBy(x => x.Salary).ToList();
            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:f2}");

            }
            var result = sb.ToString().Trim();
            return result;
        }

        private static object GetFirstTenEmployeesWithDepartment(SoftUniContext context)
        {
        
            var employees = context.Employees.Select(x => new { x.FirstName, x.LastName, DepartmentName = x.Department.Name }).OrderBy(x => x.FirstName).ThenBy(x => x.LastName).Take(10).ToList();
            var sb = new StringBuilder();
            foreach (var item in employees)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} {item.DepartmentName}");
            }
            var result = sb.ToString().TrimEnd();
            return result;
        }


        private static object GetEmployeesWithFirstNameStartWithN(SoftUniContext context)
        {
            var employees = context.Employees.Where(x => x.FirstName.StartsWith("N")).Select(x => new { x.FirstName, x.LastName, x.Salary}).OrderByDescending(x => x.Salary).ToList();
            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.Salary:f2}");

            }
            var result = sb.ToString().Trim();
            return result;
        }

        private static object GetCountOfEmployees(SoftUniContext context)
        {
            var employees = context.Employees.Count();
            var result = employees;
            return result;
        }

        private static object GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees.Where(x=>x.Department.Name == "Research and Development").Select(x => new { x.FirstName, x.LastName, x.Salary, DepartmentName = x.Department.Name }).OrderBy(x => x.Salary).ThenBy(x=>x.FirstName).ToList();
            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:f2}");

            }
            var result = sb.ToString().Trim();
            return result;
        }

        private static object GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees.Select(x => new { x.FirstName, x.Salary }).Where(x => x.Salary>50000).OrderBy(x=>x.FirstName).ToList();
            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");

            }
            var result = sb.ToString().Trim();
            return result;

        }

        private static object AllEmployes(SoftUniContext context)
        {
            var employees = context.Employees.Select(x => new { x.EmployeeId, x.FirstName, x.LastName, x.MiddleName, x.JobTitle, x.Salary }).OrderBy(x => x.EmployeeId).ToList();
            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.Append($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2} ||| ");

            }
            var result = sb.ToString().Trim();
            return result;
        }
    }
}
