using API.Routes;
using Domain.Mappers;
using Domain.Repositories.Implementations;
using Domain.Services;
using Domain.Validation;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Items.Item;
using Shared.Contracts.Requests.Items.Item;
using Shared.Contracts.Responses.Items.Item;
using Shared.Models.Items;

namespace API.Controllers
{
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly BaseService<Item, ItemMapper, ItemRepo<Item, GetItemRequest, GetAllItemsRequest>, WriteRepo<Item, Guid>,
                CreateItemRequest, UpdateItemRequest, GetItemRequest, GetAllItemsRequest, Guid, GetItemResponse,
                GetAllItemsResponse, ItemValidation<Item>
                > _itemService;

        public ItemController(BaseService<Item, ItemMapper, ItemRepo<Item, GetItemRequest, GetAllItemsRequest>, WriteRepo<Item, Guid>,
                CreateItemRequest, UpdateItemRequest, GetItemRequest, GetAllItemsRequest, Guid, GetItemResponse,
                GetAllItemsResponse, ItemValidation<Item>
                > service)
        {
            _itemService = service;
        }
        [HttpGet(AppRoutes.Item.Get)]
        public async Task<ActionResult<GetItemResponse>> Get([FromRoute] Guid id)
        {
            var request = new GetItemRequest { Id = id };
            var item = await _itemService.GetById(request);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpDelete(AppRoutes.Item.Delete)]
        public async Task<ActionResult<DeleteItemReponse>> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var deletion = await _itemService.Delete(id, cancellationToken);
            var response = new DeleteItemReponse { Success = deletion };
            return (bool)response.Success ? Ok(response) : BadRequest(response);

        }
        [HttpGet(AppRoutes.Item.GetAll)]
        public async Task<ActionResult<GetAllItemsResponse>> GetAll([FromQuery] GetAllItemsRequest options)
        {
            var items = await _itemService.GetAll(options);
            return new GetAllItemsResponse
            {
                Items = items,
            };
        }

    }
}
