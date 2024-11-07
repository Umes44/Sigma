using BusinessLayer.MediatR;
using DataModel;
using DataModel.DataModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
namespace SigmaTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CandidateController> _logger;
        public CandidateController(IMediator mediator, ILogger<CandidateController> logger)
        {
                _mediator=mediator;
            _logger=logger;
        }
       
        [HttpPost("create-update-Candidate")]
       
        public async Task<IActionResult> UpdateCreateCandidate([FromBody] CandidateVM model)
        {

            _logger.LogInformation($"{DateTime.Now}-- Candidate Information Storage Start");
            if (!ModelState.IsValid)
            {
                _logger.LogInformation($"{DateTime.Now}-- Model State is Not Valid");
                return BadRequest(new ApiResponse()
                {
                    StatusCode=500,
                    Success=false,
                    Message="Invalid Data"
                });
            }
            var response = await _mediator.Send(new UpdateCreateCandidateCommand(model));
            _logger.LogInformation($"{DateTime.Now}--{response.Message}");
            switch (response.StatusCode)
            {
                case StatusCodes.Status200OK:
                    return Ok(response);
                case StatusCodes.Status500InternalServerError:
                    return BadRequest(response);          
                default:
                    return BadRequest(response);
            }
        }
    }
}
