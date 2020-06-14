using Lottery.Application.Commands;
using Lottery.Application.Queries;
using Lottery.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        private readonly IMediator _mediator;

        public LotteryController(ILogger<LotteryController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var raffleCollection = await _mediator.Send(new GetRaffleQuery());
            return Ok(raffleCollection);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var raffleCollection = await _mediator.Send(new GetRaffleByIdQuery(id));
            return Ok(raffleCollection);
        }

        [HttpGet("{id}/participants")]
        public async Task<IActionResult> GetParticipants(Guid id)
        {
            var raffleCollection = await _mediator.Send(new GetRaffleParticipantsQuery(id));
            return Ok(raffleCollection);
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> Upload([FromForm(Name = "files")] List<IFormFile> files)
        {
            var raffleCollection = await _mediator.Send(new UploadRaffleFileCommand("", "", null));
            return Ok(files.Count);
        }
    }
}
