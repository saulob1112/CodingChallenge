using CodingChallenge.Models;
using CodingChallenge.Services;
using CodingChallenge.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.ConcreteServices
{
    public class UniversityService : IUniversityService
    {
        public async Task<IList<University>> GetUniversitiesAsync()
        {
            string url = APIConstants.URL_API;
            HttpClient client = new HttpClient();
            var httpResponse = await client.GetAsync(url);

            IList<University> universities = null;
            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();

                universities = JsonConvert.DeserializeObject<List<University>>(content);
            }

            return universities;
        }
    }
}
