using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlaceRentalApp.Application.Models;
using PlaceRentalApp.Application.Services.Interfaces;
using PlaceRentalApp.Infrastructure.Persistence;

namespace PlaceRentalApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);

            if(!result.IsSuccess)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(CreateUserInputModel model)
        {
            var result = _userService.InsertUser(model);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginInputModel model)
        {
            var result = _userService.Login(model);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
