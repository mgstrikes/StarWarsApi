using StarWarsAPI;
using StarWarsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                var query = "A new Hope";
                GetPeople(query.Replace(" ","+"));
              

                Console.WriteLine("Press any key to exit");

                Console.ReadKey();

            }

            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
            }

        }


        static void GetPeople(string name)
        {
            var api = new StarWarsAPIClient();

            var people = api.GetPeopleAsync(name).Result;
            Console.WriteLine(people.name);
           

            foreach (var film in people.GetFilmAsync().Result)
            {
                Console.WriteLine(film.title);
            }         
        }
    }
}
