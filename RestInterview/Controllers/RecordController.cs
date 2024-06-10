using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RestInterview.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecordController : ControllerBase
    {
        private IMediator _mediator;
        public RecordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allRecords = _mediator.Send(new RecordQuery()).Result;
            if (allRecords.IsSuccess)
            {
                return Ok(allRecords.Value);
            }
            else
            {
                return NotFound("not records found");
            }
        }
    }
}
