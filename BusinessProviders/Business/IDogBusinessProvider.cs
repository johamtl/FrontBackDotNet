using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonContracts;

namespace BusinessProviders.Business
{
    public interface IDogBusinessProvider
    {
         List<Dog> GetDog();
         List<Dog> GetDogById(int id);
         Boolean PostNewDog(Dog newDog);
         Boolean DeleteDog(int id);

    }
}
