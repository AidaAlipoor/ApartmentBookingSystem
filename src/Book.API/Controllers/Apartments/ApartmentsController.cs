using Book.Application.Apartment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers.Apartments
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ApartmentsController(IMediator sender)
        {
            _mediator = sender;
        }

        [HttpGet]
        public async Task<IActionResult> SearchApartments(
            DateOnly startDate,
            DateOnly endDate,
            CancellationToken cancellationToken)
        {
            var query = new SearchApartmentsQuery(startDate, endDate);

            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result.Value);
        }
    }
}
