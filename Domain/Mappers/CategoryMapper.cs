﻿using Data.Entities;
using Data.Entities.Models;
using Data.Entities.Models.Items;
using Domain.Contracts.Requests.Category;
using Domain.Contracts.Responses.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public class CategoryMapper 
    {

        public static GetCategoryResponse ToDTO(Category entity)
        {
            var response = new GetCategoryResponse()
            {
                Id = entity.Id,
                Name = entity.Name,
                Subcategories = entity.Subcategories.Select(SubcategoryMapper.ToDTO).ToList()//.Select,
                

            };
            return response;
        }
        public static Category ToEntity(CreateCategoryRequest request)
        {
            var newCategory = new Category()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
            };
            return newCategory;
        } 
        public static Category ToUpdatedEntity(UpdateCategoryRequest request)
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