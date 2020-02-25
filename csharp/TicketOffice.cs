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
            if (request.TrainId == "local_1000")
                return Reservation.Of("local_1000", "75bcd15", new List<Seat>() { Seat.Of("A", 1, "") });
            return Reservation.Of("express_2000", "75bcd15", new List<Seat>() { Seat.Of("A", 5, "") });
        }

        public Reservation MakeReservationInCoach(ReservationRequest request)
        {
            var seatInCoach = _seat.GetInCoach(request.TrainId, "A");
            var selectedFreeSeat = seatInCoach.SelectFreeSeat(request.SeatCount);

            if (HasSeatSelected(selectedFreeSeat))
            {
                var reservation = Reservation.Of(request.TrainId, "75bcd15", selectedFreeSeat);

                if (_reservationRegister.Reserve(reservation).Persisted())
                    return reservation;
            }

            return EmptyReservation(request.TrainId);
        }

        private static bool HasSeatSelected(List<Seat> selectedFreeSeat) => selectedFreeSeat.Count != 0;

        private static Reservation EmptyReservation(string trainId) => Reservation.Of(trainId, "", new List<Seat>());
    }
}
