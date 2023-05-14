using API.Routes;
using Domain.Mappers;
using Domain.Repositories.Implementations;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Requests.Subcategory;
using Shared.Contracts.Responses.Subcategory;
using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using Domain.Validation;
using Microsoft.AspNetCore.Authorization;
using Shared.Constants;

namespace API.Controllers
{
    [ApiController]
    public class SubcategoryController : ControllerBase
    {
        private readonly BaseService<Subcategory, SubcategoryMapper, SubcategoryRepo, WriteRepo<Subcategory, Guid>,
                CreateSubcategoryRequest, UpdateSubcategoryRequest, GetSubcategoryRequest,
                GetAllSubcategoriesRequest, Guid, GetSubcategoryResponse,
                GetAllSubcategoriesReponse, SubcategoryValidation
                > _subcategoryService;

        public SubcategoryController(BaseService<Subcategory, SubcategoryMapper, SubcategoryRepo, WriteRepo<Subcategory, Guid>,
                CreateSubcategoryRequest, UpdateSubcategoryRequest, GetSubcategoryRequest,
                GetAllSubcategoriesRequest, Guid, GetSubcategoryResponse,
                GetAllSubcategoriesReponse, SubcategoryValidation
                > subcategoryService)
        {
            _subcategoryService = subcategoryService;
        }
        [HttpGet(AppRoutes.Subcategory.Get)]
        public async Task<ActionResult<GetSubcategoryResponse>> Get([FromRoute] Guid id)
        {
            var request = new GetSubcategoryRequest
            {
                Id = id,
            };
            return await _subcategoryService.GetById(request);
        }
        [Authorize(AuthConstants.AdminUserPolicyName)]

        [HttpPost(AppRoutes.Subcategory.Create)]
        public async Task<ActionResult<CreateSubcategoryResponse>> Post([FromBody] CreateSubcategoryRequest request, CancellationToken cancellationToken)
        {
            var item = await _subcategoryService.Create(request, cancellationToken);
            return new CreateSubcategoryResponse
            {
                Success = item != null,
                Subcategory = item,
            };
        }
        [Authorize(AuthConstants.AdminUserPolicyName)]

        [HttpPut(AppRoutes.Subcategory.Update)]
        public async Task<ActionResult<UpdateSubcategoryResponse>> Update([FromBody] CreateSubcategoryRequest request, [FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var updateRequest =
                new UpdateSubcategoryRequest
                {
                    Name = request.Name,
                    Description = request.Description,
                    CategoryId = request.CategoryId,
                    Id = id,
                };
            var item = await _subcategoryService.Update(updateRequest, cancellationToken);
            return new UpdateSubcategoryResponse
            {
                Success = item != null,
                Subcategory = item,
            };
        }
        [Authorize(AuthConstants.AdminUserPolicyName)]

        [HttpDelete(AppRoutes.Subcategory.Delete)]
        public async Task<ActionResult<DeleteSubcategoryResponse>> Delete([FromRoute] Guid  id, CancellationToken cancellationToken)
        {
            var item = await _subcategoryService.Delete(id, cancellationToken);
            return new DeleteSubcategoryResponse
            {
                Success = item,
            };
        }
        [HttpGet(AppRoutes.Subcategory.GetAll)]
        public async Task<ActionResult<GetAllSubcategoriesReponse>> GetAll([FromQuery] GetAllSubcategoriesRequest request)
        {
            var items = await _subcategoryService.GetAll(request);
            return new GetAllSubcategoriesReponse
            {
                Subcategories = items,
            };

        }

    }
}
