using ManagingRealEstate.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;

namespace ManagingRealEstate.API.Database;

public class ApplicationDbContext : DbContext, IDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        var transaction = await Database.BeginTransactionAsync();
        try
        {
            await SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task RollbackTransactionAsync()
    {
        var transaction = await Database.BeginTransactionAsync();
        await transaction.RollbackAsync();
    }

    public async Task<T> ExecuteInTransactionAsync<T>(Func<Task<T>> operation)
    {
        using var transaction = await BeginTransactionAsync();
        try
        {
            var result = await operation();
            await CommitTransactionAsync();
            return result;
        }
        catch
        {
            await RollbackTransactionAsync();
            throw;
        }
    }
}
