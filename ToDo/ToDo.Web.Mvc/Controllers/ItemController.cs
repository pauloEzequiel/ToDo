using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Dtos.Item;
using ToDo.Application.Interfaces;
using ToDo.Domain.Entities;
using ToDo.Domain.Interface;
using ToDo.Web.Mvc.Models;

namespace ToDo.Web.Mvc.Controllers
{
    public class ItemController : Controller
    {
        protected IItemAppService _service;

        public ItemController(IItemAppService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _service.GetItemAsync();

            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Description")] CreateItemModel createItemModel)
        {
            if (ModelState.IsValid)
            {
                var item = new CreatedItemRequestDto() { Description = createItemModel.Description };
                await _service.CreatedItemAsync(item);
                return RedirectToAction(nameof(Index));
            }

            return View(createItemModel);
        }

        [HttpGet]
        [Route("check/{id}")]
        public async Task<IActionResult> Check(string id)
        {
            await _service.ChangeCheckAsync(new Guid(id));

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteItem(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
