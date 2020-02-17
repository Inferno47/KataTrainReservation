using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataTrainReservation
{
    public class Reservation : IEquatable<Reservation>
    {
        public string TrainId { get; private set; }
        public string BookingId { get; private set; }
        public List<Seat> Seats { get; private set; }

        public Reservation(string trainId, string bookingId, List<Seat> seats)
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

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Reservation) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (TrainId != null ? TrainId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BookingId != null ? BookingId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Seats != null ? Seats.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Reservation left, Reservation right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Reservation left, Reservation right)
        {
            return !Equals(left, right);
        }
    }
}
