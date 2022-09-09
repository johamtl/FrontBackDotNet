#define ENABLE_OBO
using Microsoft.AspNetCore.Mvc;
using CommonContracts;
using BusinessProviders.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;
using Microsoft.AspNetCore.Cors;
// 1. define Post/Get/Put/Delete here before test these actions in Postman

namespace ASPNETCOREWEBAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [RequiredScope("access_as_user")] //if token has scp, use this one
    public class DogController : ControllerBase
    {
        private readonly IDogBusinessProvider _dogBusinessProvider;
        public DogController(IDogBusinessProvider dogBusinessProvider)
        {
            _dogBusinessProvider = dogBusinessProvider;
        }

        //GET: api/Dog
        [HttpGet]
        //[Authorize(Roles = "ReadApi")]// -- if token has roles, use this one
        public async Task<ActionResult<IEnumerable<Dog>>> GetDog()
        {
            return _dogBusinessProvider.GetDog();
        }

        //GET: api/Dog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Dog>>> GetDogById(int id)
        {
            return _dogBusinessProvider.GetDogById(id);
        }

        // PUT: api/Dog/5 -- To be continued
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
                return _dogBusinessProvider.PostNewDog(newDog);
            }
            return false;
        }

        // DELETE: api/Dog/5
        [HttpDelete("{id}")]
        public Boolean DeleteDog(int id)
        {
            return _dogBusinessProvider.DeleteDog(id);
        }
    }
}
