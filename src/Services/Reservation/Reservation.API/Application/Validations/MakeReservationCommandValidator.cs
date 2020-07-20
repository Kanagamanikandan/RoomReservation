using Reservation.API.Application.Commands;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;

namespace Reservation.API.Application.Validations
{
    public class MakeReservationCommandValidator : AbstractValidator<MakeReservationCommand>
    {
        public MakeReservationCommandValidator(ILogger<MakeReservationCommandValidator> logger)
        {
            RuleFor(command => command.MeetingRoomId).NotEmpty();
            RuleFor(command => command.ReservationDate).NotEmpty()
                .Must(BeValidReservationDate)
                .WithMessage("Please specify a reservation date");
            RuleFor(command => command.StartTime).NotEmpty();
            RuleFor(command => command.EndTime).NotEmpty()
                .GreaterThan(c => c.StartTime)
                .WithMessage("Please specify a valid start time and end time");

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }

        private bool BeValidReservationDate(DateTime date)
        {
            return date.Date >= DateTime.UtcNow.Date;
        }
    }
}
