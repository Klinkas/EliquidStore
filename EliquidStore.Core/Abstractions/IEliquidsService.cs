using EliquidStore.Core.Models;

namespace EliquidStore.Application.Services;

public interface IEliquidsService
{
    Task<List<Eliquid>> GetAllEliquids();
    
    Task<Guid> CreateEliquid(Eliquid eliquid);
    
    Task<Guid> UpdateEliquid(Guid id, string name, string flavor, int capacity);
    
    Task<Guid> DeleteEliquid(Guid id);
}