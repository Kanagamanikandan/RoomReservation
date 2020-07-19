using Microsoft.Extensions.Hosting;
using Reservation.Domain.AggregatesModel.MeetingRoomAggregate;
using Reservation.Domain.AggregatesModel.OfficeAggregate;
using Reservation.Domain.SharedKernel;
using Reservation.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.API.Infrastructure
{
    public class ReservationContextSeed
    {
        public async Task SeedAsync(ReservationContext context, IHostEnvironment env)
        {
            using (context)
            {
                if (!context.Offices.Any())
                {
                    context.Offices.AddRange(
                        new Office("Amsterdam", new TimeSpan(08, 30, 00), new TimeSpan(17, 00, 00)) { Id = 1 },
                        new Office("Berlin", new TimeSpan(08, 30, 00), new TimeSpan(20, 00, 00)) { Id = 2 }
                       );
                    await context.SaveChangesAsync();
                }

                if (!context.MeetingRooms.Any())
                {
                    context.MeetingRooms.AddRange(
                        new MeetingRoom("101", 10, 1, 10) { Id = 1 },
                        new MeetingRoom("102", 20, 1, 20) { Id = 2 },
                        new MeetingRoom("103", 10, 1, 0) { Id = 3 },
                        new MeetingRoom("201", 10, 1, 10) { Id = 4 },
                        new MeetingRoom("202", 20, 1, 20) { Id = 5 },
                        new MeetingRoom("203", 10, 1, 0) { Id = 6 }
                    );
                    await context.SaveChangesAsync();
                };
            }
        }
    }
}
