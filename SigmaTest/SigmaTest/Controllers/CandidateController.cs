using BusinessLayer.MediatR;
using DataModel;
using DataModel.DataModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SigmaTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CandidateController(IMediator mediator)
        {
                _mediator=mediator;
        }

        [HttpPost("create-update-Candidate")]
        public async Task<IActionResult> UpdateCreateCandidate([FromBody] Candidate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse()
                {
                    StatusCode=500,
                    Success=false,
                    Message="Invalid Data"
                });
            }

            var response = await _mediator.Send(new UpdateCreateCandidateCommand(model));
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
