using EliquidStore.Core.Models;
using EliquidStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EliquidStore.DataAccess.Repositories;

public class EliquidsRepository : IEliquidsRepository
{
    private readonly EliquidStoreDbContext _context;
    
    public EliquidsRepository(EliquidStoreDbContext context)
    {
        _context = context;
    }

    public async Task<List<Eliquid>> Get()
    {
        var eliquidEntities = await _context.Eliquids
            .AsNoTracking()
            .ToListAsync();

        var eliquids = eliquidEntities
            .Select(e => Eliquid.Create(e.Id, e.Name, e.Flavor, e.Capacity).eliquid)
            .ToList();
        return eliquids;
    }

    public async Task<Guid> Create(Eliquid eliquid)
    {
        var eliquidEntity = new EliquidEntity
        {
            Id = eliquid.Id,
            Name = eliquid.Name,
            Flavor = eliquid.Flavor,
            Capacity = eliquid.Capacity,
        };

        await _context.Eliquids.AddAsync(eliquidEntity);
        await _context.SaveChangesAsync();

        return eliquidEntity.Id;
    }

    public async Task<Guid> Update(Guid id, string name, string flavor, int capacity)
    {
        await _context.Eliquids
            .Where(e => e.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(e => e.Name, e => name)
                .SetProperty(e => e.Flavor, e => flavor)
                .SetProperty(e => e.Capacity, e => capacity));

        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _context.Eliquids
            .Where(e => e.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }
}