using Data.Entities;
using Shared.Models;
using Shared.Models.Items;
using Shared.Contracts.Requests.Subcategory;
using Shared.Contracts.Responses.Subcategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public class SubcategoryMapper : IMapper<Subcategory, GetSubcategoryResponse, CreateSubcategoryRequest, UpdateSubcategoryRequest>
    {

        public   GetSubcategoryResponse ToDTO(Subcategory entity)
        {
            var response = new GetSubcategoryResponse()
            {
                Id = entity .Id,
                Name =  entity .Name,
                CategoryId = entity .CategoryId,
                Description = entity .Description,

            };
            return response;
        }
        public   Subcategory ToEntity(CreateSubcategoryRequest request)
        {
            var entity = new Subcategory()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                CategoryId = request.CategoryId
            };
            return entity;
        }
        public   Subcategory ToUpdatedEntity(UpdateSubcategoryRequest request)
        {
            var entity = new Subcategory()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                CategoryId = request.CategoryId
            };
            return entity;
        }
    }
}
