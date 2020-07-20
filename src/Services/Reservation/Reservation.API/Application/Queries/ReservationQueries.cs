using Dapper;
using Microsoft.Data.SqlClient;
using Reservation.API.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.API.Application.Queries
{
    public class ReservationQueries : IReservationQueries
    {
        public ReservationQueries(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        private readonly string _connectionString = string.Empty;

        public async Task<IEnumerable<MeetingRoom>> GetAvailableMeetingRooms(ReservationRequestDto request)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<MeetingRoom>(@"SELECT mr.Id MeetingRoomId, OfficeId, Capacity, NumberOfChairs
                FROM reservation.meetingRooms mr
                WHERE  NOT EXISTS ( SELECT * FROM reservation.reservations r
				WHERE r.MeetingRoomId = mr.Id  AND OfficeId = @OfficeId
				AND r.ReservationDate = @ReservationDate
				AND ((@STARTTIME BETWEEN r.StartTime AND r.EndTime)
				OR (@ENDTIME BETWEEN r.StartTime AND r.EndTime)) )",
                new { request.OfficeId, request.ReservationDate, request.StartTime, request.EndTime });
            }
        }
    }
}
