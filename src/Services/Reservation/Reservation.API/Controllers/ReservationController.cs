using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Reservation.API.Controllers
{
    using Reservation.API.Application.Commands;
    using Reservation.Domain.AggregatesModel.ReservationAggregate;
    using System.Threading.Tasks;

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


        [HttpPost]
        public async Task<ActionResult< Reservation>> MakeReservationAsync([FromBody] MakeReservationCommand makeReservationCommand)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                makeReservationCommand.GetType(),
                nameof(makeReservationCommand.EmployeeId),
                makeReservationCommand.EmployeeId,
                makeReservationCommand);

            return await _mediator.Send(makeReservationCommand);
        }

        
    }
}
