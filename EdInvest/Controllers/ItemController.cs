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

namespace API.Controllers
{
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly BaseService<Item, ItemMapper, ItemRepo<Item, GetAllItemsRequest>, WriteRepo<Item, Guid>,
                CreateItemRequest, UpdateItemRequest, GetItemRequest, GetAllItemsRequest, Guid, GetItemResponse,
                GetAllItemsResponse, List<Item>
                > _itemService;

        public ItemController(BaseService<Item, ItemMapper, ItemRepo<Item, GetAllItemsRequest>, WriteRepo<Item, Guid>,
                CreateItemRequest, UpdateItemRequest, GetItemRequest, GetAllItemsRequest, Guid, GetItemResponse,
                GetAllItemsResponse, List<Item>
                > service)
        {
            _itemService = service;
        }
        [HttpGet(AppRoutes.Item.Get)]
        public async Task<ActionResult<GetItemResponse>> Get([FromQuery] GetItemRequest request)
        {
            return await _itemService.GetById(request.Id);
        }
        [HttpPost(AppRoutes.Item.Create)]
        
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
