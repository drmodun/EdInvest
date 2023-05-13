using API.Routes;
using Shared.Models.Items;
using Shared.Contracts.Requests.Items.Item;
using Shared.Contracts.Responses.Category;
using Shared.Contracts.Responses.Items.Item;
using Domain.Mappers;
using Domain.Repositories.Implementations;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Responses.Items.Application;
using Shared.Contracts.Items.Item;
using Domain.Validation;

namespace API.Controllers
{
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly BaseService<Item, ItemMapper, ItemRepo<Item, GetItemRequest, GetAllItemsRequest>, WriteRepo<Item, Guid>,
                CreateItemRequest, UpdateItemRequest, GetItemRequest, GetAllItemsRequest, Guid, GetItemResponse,
                GetAllItemsResponse, ItemValidation<Item>
                > _itemService;

        public ItemController(BaseService<Item, ItemMapper, ItemRepo<Item,GetItemRequest, GetAllItemsRequest>, WriteRepo<Item, Guid>,
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
            return await _itemService.GetById(request);
        }
        
        [HttpDelete(AppRoutes.Item.Delete)]
        public async Task<ActionResult<DeleteItemReponse>> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var deletion = await _itemService.Delete(id, cancellationToken);
            return new DeleteItemReponse { Success = deletion };

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
