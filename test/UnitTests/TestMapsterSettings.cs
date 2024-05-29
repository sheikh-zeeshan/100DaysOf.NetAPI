using Mapster;

namespace UnitTests;

public class TestMapsterSettings
{
    [Fact]
    public void MapEntityToDTOs()
    {
        MappingConfig.Configure();

        // Create a source object
        var source = new EntitySource
        {
            FirstName = "John",
            LastName = "Doe",
            Age = 30,
            Email = "john.doe@example.com",
            Address = new EntitySourceAddress
            {
                Street = "123 Main St",
                City = "Springfield",
                PostalCode = "12345"
            }
        };

        // Map to destination object
        var destination = source.Adapt<DTODestination>();

        Assert.NotNull(destination.Location);
    }
}

public static class MappingConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<EntitySource, DTODestination>.NewConfig()
            .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}")
            .Map(dest => dest.EmailAddress, src => src.Email)
            .Map(dest => dest.Location, src => src.Address.Adapt<DTODestinationLocation>());

        TypeAdapterConfig<EntitySourceAddress, DTODestinationLocation>.NewConfig()
            .Map(dest => dest.StreetAddress, src => src.Street)
            .Map(dest => dest.CityName, src => src.City)
            .Map(dest => dest.ZipCode, src => src.PostalCode);
    }
}
public class EntitySource
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public EntitySourceAddress Address { get; set; }
}

public class EntitySourceAddress
{
    public string Street { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
}

public class DTODestination
{
    public string FullName { get; set; }
    public int Age { get; set; }
    public string EmailAddress { get; set; }
    public DTODestinationLocation Location { get; set; }
}

public class DTODestinationLocation
{
    public string StreetAddress { get; set; }
    public string CityName { get; set; }
    public string ZipCode { get; set; }
}