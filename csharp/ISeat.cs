namespace KataTrainReservation
{
    public interface ISeat
    {
        Coach GetInCoach(string train, string coach);
        Train GetInTrain(string train);
    }
}