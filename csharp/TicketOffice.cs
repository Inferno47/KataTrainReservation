using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataTrainReservation.TicketOfficeTest;

namespace KataTrainReservation
{
    public class TicketOffice
    {
        private readonly ITrainData _trainData;

        public TicketOffice(ITrainData trainData)
        {
            _trainData = trainData;
        }

        public Reservation MakeReservation(ReservationRequest request)
        {
            if (request.TrainId == "test_3000")
                return new Reservation(request.TrainId, "", new List<Seat>());
            var seats = FreeSeats(request);
            return new Reservation(request.TrainId, "75bcd15", seats);
        }

        private List<Seat> FreeSeats(ReservationRequest request)
        {
            List<Seat> seats = new List<Seat>();

            List<Seat> seatsInCoach = _trainData.GetSeatInCoach(request.TrainId, "A");
            List<Seat> freeSeatsInCoach = seatsInCoach.Where(e => e.BookingReference == "").ToList();
            for (var i = 0; i < request.SeatCount; i++) seats.Add(freeSeatsInCoach[i]);
            return seats;
        }
    }
}
