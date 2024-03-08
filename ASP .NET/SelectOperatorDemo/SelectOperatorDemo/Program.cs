using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class Employee
{
    public int? ID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Salary { get; set; }

    public static List<Employee> GetEmployees()
    {
        List<Employee> list = new List<Employee>
        {
            new Employee { ID = 1, FirstName = "Divyank", LastName = "Raja", Salary = 10 },
            new Employee { ID = 2, FirstName = "Devanshu", LastName = "shah", Salary = 20 },
            new Employee { ID = 3, FirstName = "Mubin", LastName = "seta", Salary = 5 },
            new Employee { ID = 4, FirstName = "Uttam", LastName = "Naga", Salary = 6 },
            new Employee { ID = 5, FirstName = "Karan", LastName = "Khut", Salary = 7 },
            new Employee { ID = 6, FirstName = "Kishan", LastName = "Moliya", Salary = 10}
        };
        return list;
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("---------Using Query Syntax--------");
        List<Employee> basicQuery = (from emp in Employee.GetEmployees() select emp).ToList();
        foreach(Employee emp in basicQuery)
        {
            Console.WriteLine($"ID : {emp.ID} Name : {emp.FirstName} {emp.LastName}");
        }
        /*IEnumerable<Employee> basicMethod = Employee.GetEmployees().ToList();
        Console.WriteLine("---------Using Method Syntax--------");
        foreach (Employee emp in basicMethod)
        {
            Console.WriteLine($"ID : {emp.ID} Name : {emp.FirstName} {emp.LastName}");
        }*/
        Console.ReadKey();
    }
}