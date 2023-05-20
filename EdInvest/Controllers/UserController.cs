using API.Auth;
using API.Routes;
using Domain.Mappers;
using Domain.Repositories.Implementations;
using Domain.Services;
using Domain.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Constants;
using Shared.Contracts.Requests;
using Shared.Contracts.Requests.Users.User;
using Shared.Contracts.Responses.Users.User;
using Shared.Models.Users;

namespace API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BaseService<User, UserMapper, UserRepo<User, GetUserRequest, GetAllUsersRequest>, WriteRepo<User, Guid>,
                CreateUserRequest, UpdateUserRequest, GetUserRequest,
                GetAllUsersRequest, Guid, GetUserResponse,
                GetAllUsersResponse, UserValidation<User>
                > _userService;
        private readonly IdentityService _identityService;

        public UserController(BaseService<User, UserMapper, UserRepo<User, GetUserRequest, GetAllUsersRequest>, WriteRepo<User, Guid>,
                CreateUserRequest, UpdateUserRequest, GetUserRequest,
                GetAllUsersRequest, Guid, GetUserResponse,
                GetAllUsersResponse, UserValidation<User>
                > userService, IdentityService identityService)
        {
            _userService = userService;
            _identityService = identityService;
        }
        [HttpGet(AppRoutes.User.Get)]
        public async Task<ActionResult<GetUserResponse>> Get([FromRoute] Guid id)
        {
            var request = new GetUserRequest
            { Id = id };
            var item = await _userService.GetById(request);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        //no reason to be able to create a user which is of an unknown type 
        [Authorize(AuthConstants.TrustMemberPolicyName)]
        [HttpDelete(AppRoutes.User.Delete)]
        public async Task<ActionResult<DeleteUserResponse>> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {

            var item = await _userService.Delete(id, cancellationToken);
            var response = new DeleteUserResponse
            {
                Success = item,
            };
            return (bool)response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpGet(AppRoutes.User.GetAll)]
        public async Task<ActionResult<GetAllUsersResponse>> GetAll([FromQuery] GetAllUsersRequest request)
        {
            var items = await _userService.GetAll(request);
            return new GetAllUsersResponse
            {
                Users = items,
            };

        }
        [HttpPost(AppRoutes.User.Login)]
        public async Task<ActionResult<string?>> GetJWT([FromBody] LoginUserRequset request)
        {
            var jwt = await _identityService.LoginUser(request);
            if (jwt == null)
                return NotFound();
            return jwt;
        }
        [HttpGet(AppRoutes.User.GetMe)]
        public async Task<ActionResult<GetUserResponse?>> GetMe()
        {
            var id = HttpContext.GetUserId();
            if (id == null)
                return NotFound(HttpContext.GetUserId());
            var user = await _userService.GetById(new GetUserRequest { Id = (Guid)id });
            if (user == null)
                return NotFound(HttpContext.GetUserId());
            return Ok(user);
        }

    }
}
