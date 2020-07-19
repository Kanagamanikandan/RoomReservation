using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Reservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ReservationController> _logger;
        public ReservationController(IMediator mediator, ILogger<ReservationController> logger, IHttpContextAccessor httpContext)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public ActionResult GetReservation()
        {
            _logger.LogInformation("----- Get Reservation ---------");
            return Ok("ok");
        }

        
    }
}
