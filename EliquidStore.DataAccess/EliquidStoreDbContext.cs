using EliquidStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EliquidStore.DataAccess;

public class EliquidStoreDbContext : DbContext
{
    public EliquidStoreDbContext(DbContextOptions<EliquidStoreDbContext> options)
        : base(options)
    {
    }

    public DbSet<EliquidEntity> Eliquids { get; set; }
}