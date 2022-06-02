
using Microsoft.AspNetCore.Mvc;
using FrontBackClassLib;
using ASPNETCOREWEBAPI.Data;
using ASPNETCOREWEBAPI.Business;

// 1. define Post/Get/Put/Delete here before test these actions in Postman

namespace ASPNETCOREWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        public DogController(TodoContext context)
        {
            //mySQL.TryCreateDogTable();
        }

        //GET: api/Dog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dog>>> GetDog()
        {
            return DogBusiness.GetDog();
        }

        //GET: api/Dog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Dog>>> GetDogById(int id)
        {
            return DogBusiness.GetDogById(id);
        }

        // PUT: api/Dog/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutNewDog(int id, Dog newDog)
        //{
        //    if (id != newDog.Id)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //       mySQL.AddDog(newDog.Weight, newDog.Name, newDog.Breed, id);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {     
        //            return NotFound();
        //    }

        //    return NoContent();
        //}

        // POST: api/Dog
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754     

        [HttpPost]
        public Boolean PostNewDog(Dog newDog)
        {
            if (typeof(Dog).IsInstanceOfType(newDog))
            {
                return DogBusiness.PostNewDog(newDog);
            }
            return false;
        }

        // DELETE: api/Dog/5
        [HttpDelete("{id}")]
        public Boolean DeleteDog(int id)
        {
            return DogBusiness.DeleteDog(id);
        }
    }
}
