using Microsoft.AspNetCore.Mvc;
using PlaceRentalApp.Core.Entities;
using PlaceRentalApp.API.Models;
using PlaceRentalApp.API.Persistence;

namespace PlaceRentalApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly PlaceRentalDbContext _context;

        public UserController(PlaceRentalDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post(CreateUserInputModel model)
        {
            var user = new User(model.FullName, model.Email, model.BirtDate);

            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, model);
        }

    }
}
 