using StarWarsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsAPI
{
    public static class StarWarsFilmExt
    {
        async public static Task<IEnumerable<People>> GetPeopleAsync(this Film f)
        {
            StarWarsAPIClient api = new StarWarsAPIClient();
            return await api.GetListAsync<People>(f.characters);

        }    
        
    }
}
