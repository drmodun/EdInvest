using API.Routes;
using Domain.Mappers;
using Domain.Repositories.Implementations;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using Shared.Models.Users;
using Shared.Contracts.Requests.Users.User;
using Shared.Contracts.Responses.Users.User;
using Domain.Repositories.Interfaces;
using Shared.Contracts.Requests.Users.User;
using Shared.Contracts.Requests.Users.Investor;
using Shared.Contracts.Requests.Users.Student;

namespace API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BaseService<User, UserMapper, UserRepo<User, GetUserRequest, GetAllUsersRequest>, WriteRepo<User, Guid>,
                CreateUserRequest, UpdateUserRequest, GetUserRequest,
                GetAllUsersRequest, Guid, GetUserResponse,
                GetAllUsersResponse, List<User>
                > _userSvice;

        public UserController(BaseService<User, UserMapper, UserRepo<User, GetUserRequest, GetAllUsersRequest>, WriteRepo<User, Guid>,
                CreateUserRequest, UpdateUserRequest, GetUserRequest,
                GetAllUsersRequest, Guid, GetUserResponse,
                GetAllUsersResponse, List<User>
                > userSvice)
        {
            _userSvice = userSvice;
        }
        [HttpGet(AppRoutes.User.Get)]
        public async Task<ActionResult<GetUserResponse>> Get([FromRoute] Guid id)
        {
            var request = new GetUserRequest
            {Id = id};
            return await _userSvice.GetById(request);
        }
        //no reason to be able to create a user which is of an unknown type 
        [HttpDelete(AppRoutes.User.Delete)]
        public async Task<ActionResult<DeleteUserResponse>> Delete([FromRoute] DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var item = await _userSvice.Delete(request.Id, cancellationToken);
            return new DeleteUserResponse
            {
                Success = item,
            };
        }
        [HttpGet(AppRoutes.User.GetAll)]
        public async Task<ActionResult<GetAllUsersResponse>> GetAll([FromQuery] GetAllUsersRequest request)
        {
            var items = await _userSvice.GetAll(request);
            return new GetAllUsersResponse
            {
                Users = items,
            };

        }

    }
}
