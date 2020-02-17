using System.Collections.Generic;

namespace KataTrainReservation.TicketOfficeTest
{
    public interface ITrainData
    {
        List<Seat> GetSeatInCoach(string train, string coach);
    }
}