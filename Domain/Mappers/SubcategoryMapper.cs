using Data.Entities;
using Data.Entities.Models;
using Data.Entities.Models.Items;
using Domain.Contracts.Requests.Subcategory;
using Domain.Contracts.Responses.Subcategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public class SubcategoryMapper
    {
        private readonly EdInvestContext _context;

        public static GetSubcategoryResponse ToDTO(Subcategory subcategory)
        {
            var response = new GetSubcategoryResponse()
            {
                Id = subcategory.Id,
                Name = subcategory.Name,
                CategoryId = subcategory.CatgoryId,
                Description = subcategory.Description,

            };
            return response;
        }
        public static Subcategory ToEntity(CreateSubcategoryRequest request)
        {
            var entity = new Subcategory()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                CatgoryId = request.CategoryId
            };
            return entity;
        }
        public static Subcategory ToUpdatedEntity(UpdateSubcategoryRequest request)
        {
            var entity = new Subcategory()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                CatgoryId = request.CategoryId
            };
            return entity;
        }
    }
}
