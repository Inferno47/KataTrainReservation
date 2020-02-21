using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataTrainReservation
{
    public class Reservation : IEquatable<Reservation>
    {
        public static Reservation Of(string trainId, string bookingId, List<Seat> seats)
        {
            return new Reservation(trainId, bookingId, seats);
        }

        public static Reservation Empty(string trainId)
        {
            return new Reservation(trainId, "", new List<Seat>());
        }

        public string TrainId { get; private set; }

        public string BookingId { get; private set; }

        public List<Seat> Seats { get; private set; }

        private Reservation(string trainId, string bookingId, List<Seat> seats)
        {
            this.TrainId = trainId;
            this.BookingId = bookingId;
            this.Seats = seats;
        }

        public bool Equals(Reservation other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return TrainId == other.TrainId && BookingId == other.BookingId && Seats.SequenceEqual(other.Seats);
        }
    }
}
