using EliquidStore.Core.Models;

namespace EliquidStore.DataAccess.Repositories;

public interface IEliquidsRepository
{
    Task<List<Eliquid>> Get();
    Task<Guid> Create(Eliquid eliquid);
    Task<Guid> Update(Guid id, string name, string flavor, int capacity);
    Task<Guid> Delete(Guid id);
}