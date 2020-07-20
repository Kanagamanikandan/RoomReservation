using Reservation.API.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.API.Application.Queries
{
    public interface IReservationQueries
    {
        Task<IEnumerable<MeetingRoom>> GetAvailableMeetingRooms(ReservationRequestDto reservationRequest);
    }
}
