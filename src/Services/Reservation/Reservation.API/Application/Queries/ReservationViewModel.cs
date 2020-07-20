using Reservation.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.API.Application.Queries
{
    public class MeetingRoom
    {
        public int MeetingRoomId { get; set; }
        public int OfficeId { get; set; }

        public int Capacity { get; set; }
        public int NumberOfChairs { get; set; }
    }
}
