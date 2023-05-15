using Shared.Contracts.Requests.Category;
using Shared.Contracts.Responses.Category;
using Shared.Models;

namespace Domain.Mappers
{
    public class CategoryMapper : IMapper<Category, GetCategoryResponse, CreateCategoryRequest, UpdateCategoryRequest>
    {
        private readonly SubcategoryMapper _subcategoryMapper;

        public CategoryMapper(SubcategoryMapper subcategoryMapper)
        {
            _subcategoryMapper = subcategoryMapper;
        }

        public GetCategoryResponse ToDTO(Category entity)
        {
            var response = new GetCategoryResponse()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Subcategories = entity.Subcategories.Select(_subcategoryMapper.ToDTO).ToList()//.Select,


            };
            return response;
        }
        public Category ToEntity(CreateCategoryRequest request)
        {
            var newCategory = new Category()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
            };
            return newCategory;
        }
        public Category ToUpdatedEntity(UpdateCategoryRequest request)
        {
            var updatedCategory = new Category()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
            };
            return updatedCategory;
        }
    }
}
