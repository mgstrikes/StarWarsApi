using StarWarsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsAPI
{
    public static class StarWarsPeopleExt
    {
        

        async public static Task<IEnumerable<Film>> GetFilmAsync(this People p)
        {
            StarWarsAPIClient api = new StarWarsAPIClient();
            return await api.GetListAsync<Film>(p.films);

        }

      
    }
}
