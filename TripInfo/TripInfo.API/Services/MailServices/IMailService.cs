namespace TripInfo.API.Services.MailServices
{
    public interface IMailService
    {
        void Send(string subject, string message);
        void SendMostValuableCustomerInformation(string subject, string message);
    }
}