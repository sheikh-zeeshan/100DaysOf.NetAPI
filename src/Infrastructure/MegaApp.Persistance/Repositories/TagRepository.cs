
using MegaApp.Application.Interfaces.Persistance;
using MegaApp.Domain.Entities;
using MegaApp.Persistance.Common;
using MegaApp.Persistance.DatabaseContext;
using MegaApp.Persistance.DatabaseContext.Configurations;

using Microsoft.EntityFrameworkCore;


namespace MegaApp.Persistance.Repositories;

public class TagRepository : BaseRepository<Tag>, ITagRepository
{
    public TagRepository(MegaDbContext context) : base(context)
    { }

    public async Task UpsertTags(List<Tag> tags, int userID)
    {
        foreach (var tag in tags)
        {
            var id = await _context.Tags
              .Upsert(tag)
              .On(v => new { v.Desciption })
              .WhenMatched(v => new Tag
              {
                  Id = v.Id + 1,
              })
              .RunAsync();
        }

    }
}