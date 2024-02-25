using EliquidStore.Core.Models;
using EliquidStore.DataAccess.Repositories;

namespace EliquidStore.Application.Services;

public class EliquidsService : IEliquidsService
{
    private readonly IEliquidsRepository _eliquidsRepository;
    
    public EliquidsService(IEliquidsRepository eliquidsRepository)
    {
        _eliquidsRepository = eliquidsRepository;
    }

    public async Task<List<Eliquid>> GetAllEliquids()
    {
        return await _eliquidsRepository.Get();
    }

    public async Task<Guid> CreateEliquid(Eliquid eliquid)
    {
        return await _eliquidsRepository.Create(eliquid);
    }

    public async Task<Guid> UpdateEliquid(Guid id, string name, string flavor, int capacity)
    {
        return await _eliquidsRepository.Update(id, name, flavor, capacity);
    }

    public async Task<Guid> DeleteEliquid(Guid id)
    {
        return await _eliquidsRepository.Delete(id);
    }
}