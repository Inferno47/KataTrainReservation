namespace KataTrainReservation
{
    public interface ISeat
    {
        Coach GetInCoach(string train, string coach);
    }
}