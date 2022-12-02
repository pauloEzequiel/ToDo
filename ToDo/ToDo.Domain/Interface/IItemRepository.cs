using ToDo.Domain.Entities;

namespace ToDo.Domain.Interface
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();
        Task<Item> GetItemAsync(Guid Id);
        Task AddAsync(Item item);
        Task DeleteAsync(Guid Id);
        Task EditAsync(Item item);
    }
}
