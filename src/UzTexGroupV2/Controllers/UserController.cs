using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UzTexGroupV2.Application.EntitiesDto;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Filters;
using UzTexGroupV2.Infrastructure.Repositories;

namespace UzTexGroupV2.Controllers;

[Route("/{langCode}/[controller]")]
[ApiController]
public class UserController : LocalizedControllerBase
{
    private readonly UserService userService;
    public UserController(LocalizedUnitOfWork localizedUnitOfWork, UserService userService) : base(localizedUnitOfWork)
    {
        this.userService = userService;
    }

    //[HttpGet]
    //[ResponeFilter]
    //public List<int> GetData()
    //{
    //    Console.WriteLine(base.Request.RouteValues["langCode"]);

    //    return new List<int>() { 1, 2, 3 };
    //}
    [HttpPost]
    public async ValueTask<ActionResult<UserDto>> PostUserAsync(
        [FromBody] CreateUserDto createUserDto)
    {
        var createdUser = await this.userService
            .CreateUserAsync(createUserDto);

        return Created("", createdUser);
    }

    [HttpGet]
    public async ValueTask<ActionResult<UserDto>> GetAllUsers()
    {
        var users = await this.userService
            .RetrieveAllUsersAsync();

        return Ok(users);
    }

    [HttpGet("{id:guid}")]
    public async ValueTask<ActionResult<UserDto>> GetUserByIdAsync(
        Guid userId)
    {
        var user = await this.userService
            .RetrieveByIdUserAsync(userId);

        return Ok(user);
    }

    [HttpPut]
    public async ValueTask<ActionResult<UserDto>> PutUserAsync(
        [FromBody] ModifyUserDto modifyUserDto)
    {
        var modifiedUser = await this.userService
            .ModifyUserAsync(modifyUserDto);

        return Ok(modifiedUser);
    }

    [HttpDelete("{userId:guid}")]
    public async ValueTask<ActionResult<UserDto>> DeleteUserAsync(
        Guid userId)
    {
        var removed = await this.userService
            .DeleteUserAsync(userId);

        return Ok(removed);
    }
}
