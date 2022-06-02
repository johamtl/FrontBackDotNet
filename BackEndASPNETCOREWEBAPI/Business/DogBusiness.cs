using FrontBackClassLib;
using ASPNETCOREWEBAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREWEBAPI.Business
{
    public class DogBusiness
    {
        //GET: api/Dog
       public static List<Dog> GetDog()
        {
            List<Dog> dogList = new List<Dog>();
            dogList = mySQL.DisplayDogs();
            return dogList;
        }

        //GET: api/Dog/5
        public static List<Dog> GetDogById(int id)
        {
            List<Dog> dogResult = mySQL.searchDogById(id);

            if (dogResult == null || dogResult.Count == 0)
            {
                return null;
            }
            return dogResult;
        }

        // POST: api/Dog
        public static Boolean PostNewDog(Dog newDog)
        {
            return mySQL.AddDog(newDog.Weight, newDog.Name, newDog.Breed, newDog.Id);
        }

        // DELETE: api/Dog/5
        public static Boolean DeleteDog(int id)
        {
            return mySQL.DeleteDog(id);
        }
    }
}
