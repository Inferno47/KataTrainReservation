using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataTrainReservation
{
    public class Seat : IEquatable<Seat>
    {
        public string Coach { get; private set; }
        public int SeatNumber { get; private set; }

        public Seat(string coach, int seatNumber)
        {
            this.Coach = coach;
            this.SeatNumber = seatNumber;
        }

        public bool Equals(Seat other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Coach == other.Coach && SeatNumber == other.SeatNumber;
        }

        public static bool operator ==(Seat left, Seat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Seat left, Seat right)
        {
            return !Equals(left, right);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Coach != null ? Coach.GetHashCode() : 0) * 397) ^ SeatNumber;
            }
        }
    }
}
