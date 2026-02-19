using Microsoft.AspNetCore.Mvc;
using MyApi.Services;

namespace MyApi.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var items = _itemService.GetAll();
            return Ok(items);
        }

        [HttpPost]
        public IActionResult Post([FromBody] string newItem)
        {
            _itemService.Add(newItem);

            return CreatedAtAction(nameof(Get), new { id = newItem }, newItem);
        }
    }

