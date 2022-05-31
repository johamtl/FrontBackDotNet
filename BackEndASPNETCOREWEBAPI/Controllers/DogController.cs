﻿
using Microsoft.AspNetCore.Mvc;
using ASPNETCOREWEBAPI.Models;

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
            List<Dog> dogList = new List<Dog>();
            dogList = mySQL.DisplayDogs();
            return dogList;
        }

        //GET: api/Dog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Dog>>> GetDogById(int id)
        {
            List<Dog> dogResult = mySQL.searchDogById(id);

            if (dogResult == null || dogResult.Count == 0)
            {
                return NotFound();
            }
            return dogResult;
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
        public bool PostNewDog(Dog newDog)
        {
           return mySQL.AddDog(newDog.Weight, newDog.Name,newDog.Breed,newDog.Id);
        }

        // DELETE: api/Dog/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteDog(int id)
        {
            return mySQL.DeleteDog(id);
        }
    }
}
