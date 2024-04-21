// using System.Numerics;

// using Bogus;

// using MegaApp.Domain.Entities;
// using MegaApp.Persistance.DatabaseContext;
// using MegaApp.Persistance.DatabaseContext.Configurations;

// using Microsoft.EntityFrameworkCore;

// namespace MegaApp.DataGenerator;
// public class Categories
// {
//     public string CategoryName { get; set; }
// }
// public class Vehicle
// {
//     public Guid Id { get; set; }
//     public Guid EmployeeId { get; set; }
//     public string Manufacturer { get; set; }
//     public string Fuel { get; set; }
// }
// public class Employee
// {
//     public Guid Id { get; set; }
//     public string FirstName { get; set; }
//     public string LastName { get; set; }
//     public string Address { get; set; }
//     public string Email { get; set; }
//     public string AboutMe { get; set; }
//     public int YearsOld { get; set; }
//     public Personality Personality { get; set; }
//     public List<Vehicle> Vehicles { get; set; }
// }

// public class Personality
// {

// }
// public static class _test
// {
//     public static readonly List<Employee> Employees = new();
//     public static readonly List<Vehicle> Vehicles = new();

//     private static Faker<Employee> GetEmployeeGenerator()
//     {
//         return new Faker<Employee>()
//             .RuleFor(e => e.Id, _ => Guid.NewGuid())
//             .RuleFor(e => e.FirstName, f => f.Name.FirstName())
//             .RuleFor(e => e.LastName, f => f.Name.LastName())
//             .RuleFor(e => e.Address, f => f.Address.FullAddress())
//             .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.FirstName, e.LastName))
//             .RuleFor(e => e.AboutMe, f => f.Lorem.Paragraph(1))
//             .RuleFor(e => e.YearsOld, f => f.Random.Int(18, 90))
//             .RuleFor(e => e.Personality, f => f.PickRandom<Personality>())
//             .RuleFor(e => e.Vehicles, (_, e) =>
//             {
//                 return GetBogusVehicleData(e.Id);
//             });
//     }
//     public const int NumberOfEmployees = 5;
//     public const int NumberOfVehiclesPerEmployee = 2;

//     private static List<Vehicle> GetBogusVehicleData(Guid employeeId)
//     {
//         var vehicleGenerator = GetVehicleGenerator(employeeId);
//         var generatedVehicles = vehicleGenerator.Generate(NumberOfVehiclesPerEmployee);
//         Vehicles.AddRange(generatedVehicles);
//         return generatedVehicles;
//     }
//     private static Faker<Vehicle> GetVehicleGenerator(Guid employeeId)
//     {
//         return new Faker<Vehicle>()
//             .RuleFor(v => v.Id, _ => Guid.NewGuid())
//             .RuleFor(v => v.EmployeeId, _ => employeeId)
//             .RuleFor(v => v.Manufacturer, f => f.Vehicle.Manufacturer())
//             .RuleFor(v => v.Fuel, f => f.Vehicle.Fuel());
//     }

//     public static void InitBogusData()
//     {
//         var employeeGenerator = GetEmployeeGenerator();
//         var generatedEmployees = employeeGenerator.Generate(NumberOfEmployees);
//         Employees.AddRange(generatedEmployees);
//     }

// public static List<Categories> CategoriesList(int count = 4)
// {
//     var fake = new Faker<Categories>()
//         .RuleFor(c => c.CategoryName, f => f.Commerce.Categories(1)[0]);

//     return fake.Generate(count);
// }

// public static List<Products> ProductsList(int productCount, int categoryCount)
// {
//     Faker<Products> fake = new Faker<Products>()
//         .RuleFor(p => p.ProductName, f => f.Address.County())
//         .RuleFor(p => p.UnitPrice, f => f.Random.Decimal(10, 45))
//         .RuleFor(p => p.UnitsInStock, f => f.Random.Short(1, 5))
//         .RuleFor(p => p.CategoryId, f => f.Random.Int(1, categoryCount));

//     return fake.Generate(productCount);
// }

// public static async Task<(bool success, Exception exception)> CreateDatabaseAndPopulate(int productCount)
// {
//     try
//     {
//         await using var context = new NorthWindContext();
//         await context.Database.EnsureDeletedAsync();
//         await context.Database.EnsureCreatedAsync();

//         List<Categories> categories = CategoriesList();
//         await context.AddRangeAsync(categories);

//         List<Products> products = ProductsList(productCount, categories.Count);
//         await context.AddRangeAsync(products);
//         await context.SaveChangesAsync();

//         return (true, null);
//     }
//     catch (Exception localException)
//     {
//         return (false, localException);
//     }
// }
// private static async Task Initialize(int count)
// {
//     AnsiConsole.MarkupLine("[skyblue1]Creating and populating database[/]");

//     var (success, exception) = await BogusOperations.CreateDatabaseAndPopulate(count);

//     if (!success)
//     {
//         AnsiConsole.Clear();
//         AnsiConsole.MarkupLine("[red]Failed to create and populated[/]");
//         Console.WriteLine(exception.Message);
//     }
// }
// }

