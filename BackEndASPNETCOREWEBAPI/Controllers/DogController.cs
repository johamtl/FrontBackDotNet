#define ENABLE_OBO
using Microsoft.AspNetCore.Mvc;
using CommonContracts;
using BusinessProviders.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;
// 1. define Post/Get/Put/Delete here before test these actions in Postman

namespace ASPNETCOREWEBAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [RequiredScope("access_as_user")]
    public class DogController : ControllerBase
    {
        private readonly IDogBusinessProvider _dogBusinessProvider;
        static readonly string[] scopeRequiredByApi = new string[] { "access_as_user" };
        public DogController(IDogBusinessProvider dogBusinessProvider)
        {
            //mySQL.TryCreateDogTable();
            _dogBusinessProvider = dogBusinessProvider;
        }

        //GET: api/Dog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dog>>> GetDog()
        {
            HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);
            return _dogBusinessProvider.GetDog();
        }

        //GET: api/Dog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Dog>>> GetDogById(int id)
        {
            return _dogBusinessProvider.GetDogById(id);
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
