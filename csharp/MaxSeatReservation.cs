namespace KataTrainReservation
{
    public class MaxSeatReservation
    {
        public static MaxSeatReservation Of(int maxReservedSeat)
        {
            return new MaxSeatReservation(maxReservedSeat);
        }

        private MaxSeatReservation(int maxReservedSeat)
        {
            MaxReservedSeat = maxReservedSeat;
        }

        public int MaxReservedSeat { get; private set; }
    }
}