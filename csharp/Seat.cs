using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataTrainReservation
{
    public class Seat : IEquatable<Seat>
    {
        public static Seat Of(string coach, int seatNumber, string bookingReference)
        {
            return new Seat(coach, seatNumber, bookingReference);
        }

        public string BookingReference { get; private set; }
        public string Coach { get; private set; }
        public int SeatNumber { get; private set; }

        private Seat(string coach, int seatNumber, string bookingReference)
        {
            BookingReference = bookingReference;
            this.Coach = coach;
            this.SeatNumber = seatNumber;
        }

        public bool Equals(Seat other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Coach == other.Coach && SeatNumber == other.SeatNumber && BookingReference == other.BookingReference;
        }
    }
}
