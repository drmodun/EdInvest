using API.Routes;
using Domain.Mappers;
using Domain.Repositories.Implementations;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Requests.Category;
using Shared.Contracts.Responses.Category;
using Shared.Models;

namespace API.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly BaseService<Category, CategoryMapper, CategoryRepo, WriteRepo<Category, Guid>,
                CreateCategoryRequest, UpdateCategoryRequest, GetCategoryRequest,
                GetAllCategoriesRequest, Guid, GetCategoryResponse,
                GetAllCategoriesResponse, List<Category>
                > _categoryService;

        public CategoryController(BaseService<Category, CategoryMapper, CategoryRepo, WriteRepo<Category, Guid>,
                CreateCategoryRequest, UpdateCategoryRequest, GetCategoryRequest,
                GetAllCategoriesRequest, Guid, GetCategoryResponse,
                GetAllCategoriesResponse, List<Category>
                > categorService){
            _categoryService = categorService;
        }
        [HttpGet(AppRoutes.Category.Get)]
        public async Task<ActionResult<GetCategoryResponse>> Get([FromQuery] GetCategoryRequest request)
        {
            return await _categoryService.GetById(request.Id);
        }
        [HttpPost(AppRoutes.Category.Create)]
        public async Task<ActionResult<CreateCategoryResponse>> Post([FromBody] CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var item = await _categoryService.Create(request, cancellationToken);
            return new CreateCategoryResponse
            {
                Success = item==null,
                Category = item,
            };
        }
        [HttpPut(AppRoutes.Category.Update)]
        public async Task<ActionResult<UpdateCategoryResponse>> Update([FromBody] CreateCategoryRequest request, [FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var updateRequest =
                new UpdateCategoryRequest
                {
                    Name = request.Name,
                    Description = request.Description,
                    Id = id,
                };
            var item = await _categoryService.Update(updateRequest, cancellationToken);
            return new UpdateCategoryResponse
            {
                Success = item==null,
                Category = item,
            };
        }
        [HttpDelete(AppRoutes.Category.Delete)]
        public async Task<ActionResult<DeleteCategoryResponse>> Delete([FromQuery] DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            var item = await _categoryService.Delete(request.Id, cancellationToken);
            return new DeleteCategoryResponse
            {
                Success = item,
            };
        }
        [HttpGet(AppRoutes.Category.GetAll)]
        public async Task<ActionResult<GetAllCategoriesResponse>> GetAll([FromQuery] GetAllCategoriesRequest request)
        {
            var items = await _categoryService.GetAll(request);
            return new GetAllCategoriesResponse
            {
                Categories = items,
            };

        }

    }
}
