using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lottery.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LotteryController : ControllerBase
    {
        private static readonly string[] MockTitles = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly string[] MockNames = new[]
        {
            "Creator A", "Creator B", "Creator C", "Creator D"
        };

        private static readonly string[] MockDescriptions = new[]
        {
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed eu erat vehicula, pretium justo vitae, egestas libero. Suspendisse potenti. Donec interdum accumsan felis, vitae condimentum magna. Etiam sagittis, nulla in convallis molestie, dui est sollicitudin elit, ut sollicitudin metus risus eu urna. Vivamus at sagittis nunc. Duis euismod mattis nisi. Morbi rutrum nisl eu lacinia rutrum.", 
            "Curabitur ullamcorper lacus sit amet sagittis rhoncus. Nullam varius tortor vitae lectus faucibus, et vestibulum justo congue. Cras sit amet ornare nunc, a blandit quam.", 
            "Sed facilisis quis dui et ornare. Curabitur non pulvinar risus. Aenean mi dui, tempor volutpat consectetur hendrerit, tincidunt quis est. Duis aliquam malesuada felis. Proin nisi augue, tristique id purus vitae, suscipit ornare ipsum. Fusce ultricies neque mauris, et dapibus dui imperdiet quis. Integer laoreet laoreet sem, vitae cursus ligula finibus sed. Sed rutrum in sapien sed sodales."
        };

        private readonly ILogger<LotteryController> _logger;

        public LotteryController(ILogger<LotteryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var rng = new Random();
            var loteryCollection = Enumerable.Range(1, 5).Select(index => new Lottery(
                Guid.NewGuid(),
                MockTitles[rng.Next(MockTitles.Length)],
                MockDescriptions[rng.Next(MockDescriptions.Length)],
                "https://mdbootstrap.com/img/Photos/Others/img%20(27).jpg",
                DateTime.Today,
                DateTime.UtcNow,
                MockNames[rng.Next(MockNames.Length)]
            ))
            .ToArray();

            return Ok(loteryCollection);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var lotery = new Lottery(
                Guid.NewGuid(),
                MockTitles[0],
                MockDescriptions[0],
                "https://mdbootstrap.com/img/Photos/Others/img%20(27).jpg",
                DateTime.Today,
                DateTime.UtcNow,
                MockNames[0]
            );

            return Ok(lotery);
        }

        [HttpGet("{id}/participants")]
        public IActionResult GetParticipants(Guid id)
        {
            var rng = new Random();
            var participants = Enumerable.Range(1, 30).Select(index => new Participant(
                Guid.NewGuid(),
                id,
                MockNames[rng.Next(MockNames.Length)],
                $"{MockNames[rng.Next(MockNames.Length)].Replace(" ", "")}@gmail.com"
            )).ToList();
            for(int i = 0; i < participants.Count(); i++)
            {
                participants[i].AddRandomNumbers(5);
            }
            return Ok(participants);
        }

        [HttpPost("Upload")]
        public IActionResult Upload([FromForm(Name = "files")] List<IFormFile> files)
        {
            return Ok(files.Count);
        }
    }
}
