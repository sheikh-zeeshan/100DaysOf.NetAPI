/*
An unhandled exception of type 'System.InvalidOperationException' occurred in Microsoft.EntityFrameworkCore.dll: 
'The entity type 'TenantHostel' requires a primary key to be defined. If you intended to use a keyless entity type,
 call 'HasNoKey' in 'OnModelCreating'.
*/

using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Text.Json;

using Bogus;
using Bogus.DataSets;

using MegaApp.Domain.Entities;
using MegaApp.Persistance.DatabaseContext;
using MegaApp.Persistance.DatabaseContext.Configurations;

using Microsoft.EntityFrameworkCore;

using static Bogus.DataSets.Name;

namespace MegaApp.DataGenerator;


public static class SeedDataGenerator
{
    // #region "data from json files"

    // }
    // public static string readJsonFile(string path)
    // {
    //     using StreamReader reader = new(path);
    //     var json = reader.ReadToEnd();
    //List<TenantAddress> data = JsonSerializer.Deserialize<List<TenantAddress>>(json);
    //     return json;
    // }


    // #endregion "data from json files"

    static MegaDbContext dataGeneratorContext = new MegaDbContext();

    static List<TenantHostel> listOfHostels = null;
    static List<Tag> listOfTags = null;

    static List<Tenant> listOfTenants = null;

    static List<HostelRoom> listOfhostelRooms = null;

    public static void CalibrateInMemoryData()
    {
        listOfTenants = dataGeneratorContext.Tenants.ToList();
        listOfHostels = dataGeneratorContext.TenantHostels.ToList();
        listOfTags = dataGeneratorContext.Tags.ToList();
        listOfhostelRooms = dataGeneratorContext.HostelRooms.ToList();
    }

    #region "data from bogus package"
    static int Addressid = 1;
    static int _tenantId = 1;

    const int NoOfTenants = 500;
    const int NoOfHostels = 1100;

    #region "Bogus data for Tenant and Address"
    public static void InitTenantAndAddressBogusData()
    {
        List<Tenant> tenants = new List<Tenant>();

        var tenantAndAddressGenerator = GetTenantAddressesGenerator();

        var generatedTenantWithAddresses = tenantAndAddressGenerator.Generate(NoOfTenants);

        tenants.AddRange(generatedTenantWithAddresses);

        dataGeneratorContext.Tenants.AddRange(tenants);
        var result = dataGeneratorContext.SaveChanges();

    }
    private static Faker<Tenant> GetTenantAddressesGenerator()
    {
        return new Faker<Tenant>()
            .RuleFor(e => e.Id, _ => _tenantId++)
            .RuleFor(e => e.TenantName, f => f.Company.CompanyName())
            .RuleFor(e => e.Description, f => f.Lorem.Paragraph(1))
            .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.TenantName))
            .RuleFor(e => e.Phone, f => f.Phone.PhoneNumber())
            /*
            .RuleFor(p => p.Phones, f => f.Make(3, () => f.Phone.PhoneNumber()))
            // generate 8 phones
            .RuleFor(p => p.Phones, f => Enumerable.Range(1, 8).Select(x => f.PickRandom(phones)).ToList())
            // generate 1 to 5 phones
            .RuleFor(p => p.Phones, f => Enumerable.Range(1, f.Random.Int(1, 5)).Select(x => f.PickRandom(phones)).ToList())
            */

            //.RuleFor(e => e.Address, f => f.Address.FullAddress())
            .RuleFor(e => e.TenantHostels, _ => null)
            .RuleFor(e => e.Address, (_, e) =>
            {
                return GetBogusAddressData(e.Id);
            });

    }

    private static MegaApp.Domain.Entities.Address GetBogusAddressData(int id)
    {

        return new Faker<MegaApp.Domain.Entities.Address>()
            .RuleFor(e => e.Id, _ => Addressid++)
            .RuleFor(e => e.City, f => f.Address.City())
            .RuleFor(e => e.State, f => f.Address.State())
            .RuleFor(e => e.ZipCode, f => f.Address.ZipCode())
            .RuleFor(e => e.AddressLine1, f => f.Address.StreetAddress())
            .RuleFor(e => e.AddressLine2, f => f.Address.SecondaryAddress())
            .RuleFor(e => e.AddressTypeId, _ => (int)AddressType.Tenant)
            .RuleFor(e => e.ParentId, _ => id)
         ;
    }
    #endregion "Bogus data for Tenant and Address"
    static int _tenantHostel = 1;

    #region "Bogus data for Hostel and employees"
    public static void InitTenantHostelAndEmployees()
    {
        List<TenantHostel> tenants = new List<TenantHostel>();

        var hostelAndEmployeeGenerator = GetTenantHostelsAndEmployeesGenerator();

        var generatedTenantWithAddresses = hostelAndEmployeeGenerator.Generate(NoOfHostels);

        tenants.AddRange(generatedTenantWithAddresses);

        dataGeneratorContext.TenantHostels.AddRange(tenants);
        var result = dataGeneratorContext.SaveChanges();

    }
    private static Faker<TenantHostel> GetTenantHostelsAndEmployeesGenerator()
    {
        return new Faker<TenantHostel>()
                   .RuleFor(e => e.Id, _ => _tenantHostel++)
                   .RuleFor(e => e.Name, f => f.Company.CompanyName())
                   .RuleFor(e => e.IsActive, f => f.Random.Bool())
                    .RuleFor(e => e.IsDeleted, f => f.Random.Bool())
                   .RuleFor(e => e.TenantId, f => f.PickRandom(listOfHostels).Id)  //f.Random.Int(1, 500)
                   .RuleFor(e => e.HostelRooms, _ => null)
                   .RuleFor(e => e.Tags, _ => null)
                   .RuleFor(e => e.TenantHostelTag, _ => null)
                   .RuleFor(e => e.TenantHostEmployees, (_, e) =>
                   {
                       return GetBogusTenantEmployeesData(e.Id, e.TenantId);
                   });
    }
    static List<TenantHostelEmployee> s_tenantHostelEmployees = new List<TenantHostelEmployee>();
    static Random s_random = new Random();
    private static List<TenantHostelEmployee> GetBogusTenantEmployeesData(int hostelId, int? tenantId)
    {
        var hostelAndEmployeeGenerator = GetTenantHostelEmployees(hostelId, tenantId);
        var generatedData = hostelAndEmployeeGenerator.Generate(s_random.Next(2, 3));
        s_tenantHostelEmployees.AddRange(generatedData);
        return generatedData;

    }

    private static Faker<TenantHostelEmployee> GetTenantHostelEmployees(int hostelId, int? tenantId)
    {
        return new Faker<TenantHostelEmployee>()
            .RuleFor(e => e.Id, _ => _tenantId++)
            .RuleFor(e => e.FirstName, f => f.Person.FirstName)
            .RuleFor(e => e.LastName, f => f.Person.LastName)
            .RuleFor(e => e.IsDeleted, f => f.Random.Bool())
            .RuleFor(e => e.TenantHostelId, _ => hostelId)
            .RuleFor(e => e.TenantId, _ => tenantId.Value);

    }
    #endregion "Bogus data for Hostel and employees"

    #region "Bogus for tags and hostel tags"
    static int _tagId = 1;
    static int _hostelTagId = 1;
    static int noOfHostelTags = 2500;
    public static void InitTagsAndHostelTags()
    {
        List<TenantHostelTag> tenantHostelTags = new List<TenantHostelTag>();

        var tenantHostelTagGenerator = GetTenantHostelTagGenerator();

        //var hostelTags = tenantHostelTagGenerator.Generate(noOfHostelTags);

        var hostelTags = tenantHostelTagGenerator
              .Generate(noOfHostelTags)
              .GroupBy(c => new { c.TagId, c.TenantHostelId })
              .Select(c => c.FirstOrDefault())
              .ToList();  //remove duplicate

        tenantHostelTags.AddRange(hostelTags);

        dataGeneratorContext.TenantHostelTags.AddRange(tenantHostelTags);
        var result = dataGeneratorContext.SaveChanges();
    }


    private static Faker<TenantHostelTag> GetTenantHostelTagGenerator()
    {

        Faker<TenantHostelTag> TenantHostelTagFaker = new Faker<TenantHostelTag>()
                 .StrictMode(false)
                 //.UseSeed(noOfHostelTags)  //It's a good idea to set a specific seed to generate different result of each Faker
                 .RuleFor(e => e.Id, _ => _hostelTagId++)
                 .RuleFor(s => s.TagId, f => f.PickRandom(listOfTags).Id)  //lookup existing value in Grades
                 .RuleFor(s => s.TenantHostelId, f => f.PickRandom(listOfHostels).Id);



        return TenantHostelTagFaker;
    }

    public static void InitTagsHashSet()
    {
        string hashSet = @"#hotel #travel #restaurant #vacation #hotels #holiday #love #luxury #resort #design #interiordesign #food #hospitality #instagood #hotellife #photography #travelgram #summer #relax #nature #architecture #tourism #bar #spa #turismo #luxuryhotel #beach #cafe #hotelroom #instagram";
        List<string> hashSets = hashSet.Split("#").ToList();

        List<Tag> tags = hashSets.Select(e => new Tag { Id = _tagId++, Desciption = e.Trim() }).ToList();
        dataGeneratorContext.Tags.AddRange(tags);
        dataGeneratorContext.SaveChanges();

    }
    #endregion "Bogus for tags and hostel tags"


    #region "Bogus data for Hostel Room and occupantnat"
    static int noOfHostelRoomCount = 2000;
    public static void InitTenantHostelRoom()
    {

        var hostelAndEmployeeGenerator = new Faker<HostelRoom>()
                        .RuleFor(e => e.Id, _ => _tenantHostel++)
                        .RuleFor(e => e.Name, f => f.Company.CompanyName())
                        .RuleFor(e => e.Desciption, f => f.Random.Word())
                        .RuleFor(e => e.IsDeleted, f => f.Random.Bool())
                        .RuleFor(e => e.TenantHostel, f => f.PickRandom(listOfHostels))
                        .RuleFor(e => e.TenantHostelId, (f, e) => e.TenantHostel.Id)
                        .RuleFor(e => e.TenantId, (f, e) => e.TenantHostel.TenantId)
                        .RuleFor(e => e.RoomOccupants, _ => null)
                        //.RuleSet
                        .Generate(noOfHostelRoomCount)
                        ;

        dataGeneratorContext.HostelRooms.AddRange(hostelAndEmployeeGenerator);
        try
        {
            var result = dataGeneratorContext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    // static List<RoomOccupant> s_roomOccupants = new List<RoomOccupant>();
    static int noOfRoomOccupant = 2000;
    static int _roomOccupantId = 1;
    public static void InitRoomOccuptantData()
    {
        //    FirstName,LastName,Description,HostelRoomId,HostelRoom,TenantId
        var roomOccupants = new Faker<RoomOccupant>()
                        .RuleFor(e => e.Id, _ => _roomOccupantId++)
                        .RuleFor(e => e.FirstName, f => f.Person.FirstName)
                        .RuleFor(e => e.LastName, f => f.Person.LastName)
                        .RuleFor(e => e.Description, f => f.Random.Word())
                        .RuleFor(e => e.IsDeleted, f => f.Random.Bool())
                        .RuleFor(e => e.HostelRoom, f => f.PickRandom(listOfhostelRooms))

                        .RuleFor(e => e.HostelRoomId, (f, e) => e.HostelRoom.Id)
                        .RuleFor(e => e.TenantId, (f, e) => e.HostelRoom.TenantId)
                        //.RuleSet
                        .Generate(noOfRoomOccupant)
                        ;

        dataGeneratorContext.RoomOccupants.AddRange(roomOccupants);
        try
        {
            var result = dataGeneratorContext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion "Bogus data for Hostel Room and occupantnat"

    static int _userAppId = 1;
    static int appUserCount = 2000;
    public static void InitAppUserData()
    {
        /*
            var items = new []{"kiwi", "orange", "cherry", "apple"};
            var weights = new[]{0.1f, 0.1f, 0.2f, 0.6f};
        */
        //    FPhoneNo,UserName
        var appUsers = new Faker<AppUser>()
                        .RuleFor(e => e.Id, _ => _userAppId++)
                        .RuleFor(e => e.FirstName, f => f.Person.FirstName)
                        .RuleFor(e => e.LastName, f => f.Person.LastName)
                        .RuleFor(e => e.FullName, (f, e) => $"{e.FirstName} {e.LastName}")
                        .RuleFor(e => e.Email, (f, e) => f.Internet.Email($"{e.FirstName}.{e.LastName}"))
                        .RuleFor(e => e.Password, f => f.Internet.Password())
                        .RuleFor(e => e.UserName, (f, e) => f.Internet.AdvUserName(e.FirstName, e.LastName))
                        .RuleFor(e => e.PhoneNo, f => f.Phone.PhoneNumber())
                        /*
                        .RuleFor(u => u.BirthDate, f => f.Date.PastOffset(60, DateTime.Now.AddYears(-18)).Date.ToShortDateString())
                        .RuleFor(u => u.MiddleName, f => f.Name.FirstName(f.Person.Gender).OrNull(f, .2f))
                        .RuleFor(u => u.Salutation, f => f.Name.Prefix(f.Person.Gender))
                        .RuleFor(c => field, x => x.PickRandom("Option1", "Option2", "Option3", "Option4"))
                         .RuleFor(x => x.Fruit, f => f.Random.WeightedRandom(items, weights))
                        .Rules((setter, entity) =>
                        {
                            var randomRecord = setter.PickRandom(data); // Here we pick random data from our source collection

                            entity.Field1 = randomRecord.SomeField1;
                            entity.Field2 = randomRecord.SomeField2;
                            entity.Field3 = $"{entity.Field1} {entity.Field2}";
                        }*/

                        .Generate(appUserCount)
                        ;

        dataGeneratorContext.AppUsers.AddRange(appUsers);
        try
        {
            var result = dataGeneratorContext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion "data from bogus package"
    static int nameIndex = 1;

    static List<string> standardNames = new List<string>()
    {
        "Casual leave",
        "Paternity leave",
        "Compensatory",
        "Leave",
        "Sick leave",
        "Holiday",
        "Annual leave",
        "Bereavement leave",
        "Maternity",
        "Privilege leave",
    };
    public static void InitLeaveTypeData()
    {
        var index = 1;

        var fakerLeaveTypes = new Faker<LeaveType>()
           .RuleFor(o => o.Id, f => index++)
           .RuleFor(o => o.Name, a => GetNextNameOfLeaveType())
           .RuleFor(o => o.DefaultDays, f => f.Random.Int(4, 60))
           .Generate(standardNames.Count);

        dataGeneratorContext.LeaveTypes.AddRange(fakerLeaveTypes);
        var result = dataGeneratorContext.SaveChanges();
    }
    private static string GetNextNameOfLeaveType()
    {
        if (nameIndex >= standardNames.Count)
            nameIndex = 0;
        return standardNames[nameIndex++];
    }

    static int _leaveAllocationId = 1;
    public static void InitLeaveAllocationData()
    {
        // var appUsers = new Faker<LeaveAllocation>()
        //                        .RuleFor(e => e.Id, _ => _leaveAllocationId++)

        //                        .RuleFor(e => e.NumberOfDays, f => f.Random.Int(1, 60))
        //                        .RuleFor(e => e.Period, f => f.Random.Int(1, 5))

        //                        .RuleFor(e => e.LeaveType, f => f.Person.FirstName)
        //                        .RuleFor(e => e.LeaveTypeId, f => f.Person.FirstName)

        //                        .RuleFor(e => e.TenantHostelEmployee, f => f.Internet.Password())
        //                        .RuleFor(e => e.EmployeeId, f => f.Person.FirstName)


        //                        .Generate(appUserCount)
        //                        ;

        // dataGeneratorContext.LeaveAllocations.AddRange(appUsers);
        // try
        // {
        //     var result = dataGeneratorContext.SaveChanges();
        // }
        // catch (Exception ex)
        // {
        //     throw ex;
        // }
    }
}

public static class MyExtensions
{
    public static string Prefix2(this Bogus.DataSets.Name name, Gender gender)
    {
        if (gender == Gender.Male)
        {
            return name.Random.ArrayElement(new[] { "Mr.", "Dr." });
        }
        return name.Random.ArrayElement(new[] { "Miss", "Ms.", "Mrs." });
    }
    public static string AdvUserName(this Internet internet, string firstName, string lastName)
    {
        return $"{firstName[0]}{lastName}".ToLower();
    }
    public static string AdvPassword(this Internet internet)
    {

        var r = internet.Random;

        var number = r.Replace("#");  // length 1
        var letter = r.Replace("?");  // length 2
        var lowerLetter = letter.ToLower(); //length 3
        var symbol = r.Char((char)33, (char)47); //length 4 - ascii range 33 to 47

        var padding = r.String2(r.Number(2, 6)); //length 6 - 10

        return new string(r.Shuffle(number + letter + lowerLetter + symbol + padding).ToArray());
    }
}