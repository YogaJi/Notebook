using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NoteBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NoteBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private string BASE_URL = "https://localhost:44346/api/";
        public async Task<ActionResult> Index()
        {
            List<Greeting> Greets = new List<Greeting>();
            
            using (var client = new HttpClient())
            {
              
                client.BaseAddress = new Uri(BASE_URL);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("Greeting");
              
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var Response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    Greets = JsonConvert.DeserializeObject<List<Greeting>>(Response);

                }
                return View(Greets);
            }
        }

    }

}

