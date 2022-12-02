using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Dtos.Item;

namespace ToDo.Application.Interfaces
{
    public interface IItemAppService
    {
        Task<IEnumerable<ItemResrponseDto>> GetItemAsync();
        Task CreatedItemAsync(CreatedItemRequestDto createdItemRequestDto);
        Task DeleteItem(Guid itemId);
        Task ChangeCheckAsync(Guid itemId);
       
    }
}
