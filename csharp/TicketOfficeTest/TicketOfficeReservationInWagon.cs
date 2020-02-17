using System.Collections.Generic;
using NUnit.Framework;

namespace KataTrainReservation.TicketOfficeTest
{
    [TestFixture]
    public class TicketOfficeReservationInCoach
    {
    
        [Test]
        public void reserve1SeatsInEmptyCoachReturnSuccessReservation()
        {
            Reservation expected = new Reservation("local_1000", "75bcd15", new List<Seat>() {new Seat("A", 1)});
            TicketOffice ticketOffice = new TicketOffice();
            Reservation result = ticketOffice.MakeReservation(new ReservationRequest("local_1000", 1));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void reserve2SeatsInEmptyCoachReturnSuccessReservation()
        {
            Reservation expected = new Reservation("local_1000", "75bcd15", new List<Seat>() { new Seat("A", 1), new Seat("A", 2) });
            TicketOffice ticketOffice = new TicketOffice();
            Reservation result = ticketOffice.MakeReservation(new ReservationRequest("local_1000", 2));

            Assert.AreEqual(expected, result);
        }


    }
}
