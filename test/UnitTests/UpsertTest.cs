using MegaApp.Persistance.DatabaseContext;
using MegaApp.Persistance.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UnitTests;

public class UpsertTest
{
    [Fact]
    public async void TestTagsUpsert()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();


        var optionBuilder = new DbContextOptionsBuilder<MegaDbContext>();
        optionBuilder.UseSqlite("Data Source=10.1.25.208\\mcp_uat;Initial Catalog=ClaimProcessor;Persist Security Info=True;User ID=Claim;Password=Tracker1102;Encrypt=False");

        var context = new MegaDbContext(optionBuilder.Options, configuration);

        var repoTenant = new TenantRepository(context);

        var reportTag = new TagRepository(context);

        var tags = await reportTag.GetAllAsync(new CancellationToken { });
        tags.Add(new MegaApp.Domain.Entities.Tag { Desciption = "Test" });

        var editTag = tags.FirstOrDefault(x => x.Id == 5);
        editTag.Desciption = editTag.Desciption + "__";

        await reportTag.UpsertTags(tags, 3);

        var tags2 = await reportTag.GetAllAsync(new CancellationToken { });

    }
}