using System.Data.Common;
using System.Diagnostics;

using MegaApp.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MegaApp.Persistance.DatabaseContext;

/*
Logging, Auditing and Tracing
Modifying Commands
Caching
Validation and Business Logic
Row level security
Database error handling
*/

public class PerformanceInterceptor : DbCommandInterceptor
{
    private const long QuerySlowThreshold = 100; // milliseconds

    public override InterceptionResult<DbDataReader> ReaderExecuting(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        var originalResult = base.ReaderExecuting(command, eventData, result);

        stopwatch.Stop();
        if (stopwatch.ElapsedMilliseconds > QuerySlowThreshold)
        {
            Console.WriteLine($"Slow Query Detected: {command.CommandText}");
        }

        return originalResult;
    }
}

public class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Deleted && entry.Entity is TenantHostelEmployee entity)
            {
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }

        return base.SavingChanges(eventData, result);
    }
}