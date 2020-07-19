using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reservation.Domain.AggregatesModel.ReservationAggregate;
using System;

namespace Reservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ReservationController> _logger;

        private readonly IReservationRepository _reservationRepository;
        public ReservationController(IMediator mediator,
            ILogger<ReservationController> logger,
            IReservationRepository reservationRepository)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
        }

        [HttpGet]
        public ActionResult GetReservation()
        {
            _logger.LogInformation("----- Get Reservation ---------");
            return Ok("ok");
        }

        
    }
}
