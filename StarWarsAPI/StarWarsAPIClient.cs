using StarWarsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsAPI
{

    public class StarWarsAPIClient
    {
        readonly protected string BaseAddress = @"http://swapi.co/api/";
        readonly protected string AcceptHeader = "application/json";



        /// <summary>
        /// Helper method to create a HttpClient object
        /// </summary>
        /// <returns></returns>
        HttpClient GetClient()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(BaseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(AcceptHeader));

            return client;
        }

        public async Task<T> GetAsync<T>(string url)
        {

            T result = default(T);

            using (HttpClient client = GetClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                //throw if error
                response.EnsureSuccessStatusCode();
                result = await response.Content.ReadAsAsync<T>();
            }

            return result;
        }


        public async Task<IEnumerable<T>> GetListAsync<T>(IEnumerable<string> urls)
        {
           
            Task<IEnumerable<T>> t = Task.Run(() =>
            {
                List<T> items = new List<T>();
                foreach (var url in urls)
                {
                    T item = GetAsync<T>(url).Result;
                    items.Add(item);

                }
                return items.AsEnumerable();
            });

            return await t;

        }


        #region Get methods

        public async Task<People> GetPeopleAsync(string name)
        {
            string url = string.Format("{0}/?search={1}", "films", name);
            return await GetAsync<People>(url);
        }
     

        public async Task<Film> GetFilmAsync(string title)
        {
            string url = string.Format("{0}/?search={1}", "films", title);
            return await GetAsync<Film>(url);
        }

  

        #endregion

    }
}
