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
        private readonly ISeat _seat;
        private readonly IReservationRegister _reservationRegister;

        public TicketOffice(ISeat seat, IReservationRegister reservationRegister)
        {
            _seat = seat;
            _reservationRegister = reservationRegister;
        }

        public Reservation MakeReservation(ReservationRequest request)
        {
            var seatInCoach = _seat.GetInCoach(request.TrainId, "A");
            var seats = seatInCoach.SelectSeat(request.SeatCount);

            var reservation = Reservation.Of(request.TrainId, seats.Count > 0 ? "75bcd15" : "", seats);
            Result registrationResult = _reservationRegister.Reserve(reservation);
            return registrationResult.IfFound() ? reservation : Reservation.Empty(request.TrainId);
        }
    }
}
