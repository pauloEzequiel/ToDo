using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Dtos.Item;
using ToDo.Application.Interfaces;
using ToDo.Domain.Entities;
using ToDo.Domain.Interface;

namespace ToDo.Application.AppServices
{
    public  class ItemAppService: IItemAppService
    {
        private readonly IItemRepository _repository;
        private readonly IMapper _mapper;

        public ItemAppService(IItemRepository repositoy, IMapper mapper)
        {
            _repository = repositoy;
            _mapper= mapper;
        }

        public async Task CreatedItemAsync(CreatedItemRequestDto createdItemRequestDto)
        {
            try
            {
                var item = new Item(createdItemRequestDto.Description);
                await _repository.AddAsync(item);
            }
            catch 
            {
                throw;
            }

        }

        public async Task ChangeCheckAsync(Guid itemId)
        {
            var item = await _repository.GetItemAsync(itemId);

            if (item == null) return;

            item.MarkAsDoneOrUnDone();

            await _repository.EditAsync(item);
        }

        public async Task DeleteItem(Guid itemId)
        {
            var item = await _repository.GetItemAsync(itemId);

            if (item == null) return;


            await _repository.DeleteAsync(item.Id);
        }

        public async Task<IEnumerable<ItemResrponseDto>> GetItemAsync()
        {
            try
            {
                var items = await _repository.GetAllAsync();
                return _mapper.Map <IEnumerable<ItemResrponseDto>> (items);
            }
            catch
            {
                throw;
            }
        }
    }
}
