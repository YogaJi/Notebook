using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GreetingController : ControllerBase
    {

        
        private readonly ILogger<GreetingController> _logger;

        public GreetingController(ILogger<GreetingController> logger)
        {
            _logger = logger;
        }

        private static readonly string[] Summaries = new[]
       {
            "Someone else doesn't have to be wrong for you to be right. There are many roads to what's right. " +
            "You cannot judge others by your own past. They are living a different life than you. What might be " +
            "good for one person may not be good for another. What might be bad for one person might change another " +
            "person's life for the better. You have to allow people to make their own mistakes and their own. " +
            "Nobody is perfect, and nobody deserves to be perfect. Nobody has it easy. You never know what people are going through. Every one of us has issues. So don't belittle yourself or anyone else. Everybody is fighting their own unique war..",
            "The happiest people I know keep an open mind to new ideas and ventures, use their leisure time as a means of mental development, and love good music, good books, good pictures, good company and good conversation. And oftentimes they are also the cause of happiness in others – me in particular.",
            "Feelings change, people change, and time keeps rolling. You can hold on to past mistakes or you can create your own happiness. A smile is a choice, not a miracle. True happiness comes from within. Don't make the mistake of waiting on someone or something to come along and make you happy.",
            "Everything is a life lesson. Everyone you meet, everything you encounter, etc. They're all part of the learning experience we call ‘life.’ Never forget to acknowledge the lesson, especially when things don’t go your way. If you don't get a job that you wanted or a relationship doesn't work, it only means something better is out there waiting. And the lesson you just learned is the first step towards it.",
            "Regardless of how filthy your past has been, your future is still spotless. Don't start your day with the broken pieces of yesterday. Every day is a fresh start. Each day is a new beginning. Every morning we wake up is the first day of the rest of our life.",
            "Doing something and getting it wrong is at least ten times more productive than doing nothing.",
            "Someone will always be better looking. Someone will always be smarter. Someone will always be more charismatic. But they will never be you – with your exact ideas, knowledge and skills.",
            "Everyone makes mistakes. If you can't forgive others, don't expect others to forgive you. To forgive is to set a prisoner free and discover the prisoner was you.",
            "Some people succeed because they are destined to, but most people succeed because they are determined to!",
            "Life isn’t about waiting for the storm to pass, it’s about learning to dance in the rain."
        };
        [HttpGet]
        public string Get()
        {
            /*var rng = new Random();
            int r = rng.Next(Summaries.Count);*/
            return Summaries.OrderBy(x => Guid.NewGuid()).FirstOrDefault();

        }
    }
}
