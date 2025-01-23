using Microsoft.AspNetCore.Mvc;
using PlaceRentalApp.API.Models;

namespace PlaceRentalApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        //GET api/places?search=casa&startDate=2025-01-20
        [HttpGet]
        public IActionResult Get(string search, DateTime startDate, DateTime endDate)
        {
            return Ok();
        }

        //GET api/places/1234
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        { 
            return Ok();
        }

        //POST api/places
        [HttpPost]
        public IActionResult Post(CreatePlaceInputModel model) 
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }

        //PUT api/places/1234
        [HttpPut("{id}")]
        public IActionResult Put(int id,UpdatePlaceInputModel model) 
        { 
            return NoContent();
        }
        
        // DELETE api/places/1234
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }

        // POST api/places/1234/amenities
        [HttpPost("{id}/amenities")]
        public IActionResult PostAmenity(int id, CreateAmenityInputModel model)
        {
            return NoContent();
        }


        // POST api/places/1234/books
        [HttpPost("{id}/books")]
        public IActionResult PostBook(int id, CreateBookInputModel model)
        {
            return NoContent();
        }

        //POST api/places/1234/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, CreateCommentInputModel model)
        {
            return NoContent();
        }

        // POST api/places/1234/photos
        [HttpPost("{id}/photos")]
        public IActionResult PostPhoto(int id, IFormFile file)
        {
            var description = $"File: {file.FileName}, Size: {file.Length}";

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);

                var fileBytes = ms.ToArray();
                var base64 = Convert.ToBase64String(fileBytes);

                return Ok(new { description, base64 });
            }
        }
    }
}
