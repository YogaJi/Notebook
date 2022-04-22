using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NoteBook.Services
{
    public class GreetingClientModel
    {
        private string BASE_URL = "https://localhost:44346/api/";

        public Task<HttpResponseMessage> FindAll()
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                return client.GetAsync("Greeting");
            }
            catch
            {
                return null;
            }
        }
    }
}
