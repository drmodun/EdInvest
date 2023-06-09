﻿using API.Routes;
using Domain.Mappers;
using Domain.Repositories.Implementations;
using Domain.Services;
using Domain.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Constants;
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
                GetAllCategoriesResponse, CategoryValidation
                > _categoryService;

        public CategoryController(BaseService<Category, CategoryMapper, CategoryRepo, WriteRepo<Category, Guid>,
                CreateCategoryRequest, UpdateCategoryRequest, GetCategoryRequest,
                GetAllCategoriesRequest, Guid, GetCategoryResponse,
                GetAllCategoriesResponse, CategoryValidation
                > categorService)
        {
            _categoryService = categorService;
        }
        [HttpGet(AppRoutes.Category.Get)]
        public async Task<ActionResult<GetCategoryResponse>> Get([FromRoute] Guid id)
        {
            var request = new GetCategoryRequest
            {
                Id = id,
            };
            var item = await _categoryService.GetById(request);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        [Authorize(AuthConstants.AdminUserPolicyName)]

        [HttpPost(AppRoutes.Category.Create)]
        public async Task<ActionResult<CreateCategoryResponse>> Post([FromBody] CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var item = await _categoryService.Create(request, cancellationToken);
            var response = new CreateCategoryResponse
            {
                Success = item != null,
                Category = item,
            };
            return (bool)response.Success ? Ok(response) : BadRequest(response);

        }
        [Authorize(AuthConstants.AdminUserPolicyName)]

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
            var item = await _categoryService.Update(updateRequest, cancellationToken, updateRequest.Id);
            var response = new UpdateCategoryResponse
            {
                Success = item != null,
                Category = item,
            };
            return (bool)response.Success ? Ok(response) : BadRequest(response);

        }
        [Authorize(AuthConstants.AdminUserPolicyName)]
        [HttpDelete(AppRoutes.Category.Delete)]
        public async Task<ActionResult<DeleteCategoryResponse>> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var item = await _categoryService.Delete(id, cancellationToken);
            var response = new DeleteCategoryResponse
            {
                Success = item,
            };
            return (bool)response.Success ? Ok(response) : BadRequest(response);

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
