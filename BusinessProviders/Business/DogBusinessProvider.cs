using CommonContracts;
using DataProviders.Data;

namespace BusinessProviders.Business
{
    public class DogBusinessProvider: IDogBusinessProvider
    {
        public DogBusinessProvider()
        {
        }
        //GET: api/Dog
       public List<Dog> GetDog()
        {
            List<Dog> dogList = new List<Dog>();
            dogList = mySQL.DisplayDogs();
            return dogList;
        }

        //GET: api/Dog/5
        public List<Dog> GetDogById(int id)
        {
            List<Dog> dogResult = mySQL.searchDogById(id);

            if (dogResult == null || dogResult.Count == 0)
            {
                return null;
            }
            return dogResult;
        }

        // POST: api/Dog
        public Boolean PostNewDog(Dog newDog)
        {
            return mySQL.AddDog(newDog.Weight, newDog.Name, newDog.Breed, newDog.Id);
        }

        // DELETE: api/Dog/5
        public  Boolean DeleteDog(int id)
        {
            return mySQL.DeleteDog(id);
        }
    }
}
