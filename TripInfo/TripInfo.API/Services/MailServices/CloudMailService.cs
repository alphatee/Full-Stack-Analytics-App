using TripInfo.API.Services.TripInfoServices;

namespace TripInfo.API.Services.MailServices
{
    public class CloudMailService : IMailService
    {
        private readonly string _mailTo = string.Empty;
        private readonly string _mailFrom = string.Empty;
        private readonly ITripInfoService _tripInfoService;

        public CloudMailService(IConfiguration configuration, ITripInfoService tripInfoService)
        {
            _mailTo = configuration["mailSettings:mailToAddress"];
            _mailFrom = configuration["mailSettings:mailFromAddress"];
            _tripInfoService = tripInfoService ?? throw new ArgumentNullException(nameof(tripInfoService));
            // Console.WriteLine("CloudMailService initialized with ITripInfoService"); // Temporary log
        }

        public void Send(string subject, string message)
        {
            // send mail - output to Console window
            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, " +
                $"with {nameof(CloudMailService)}.");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }

        public void SendMostValuableCustomerInformation(string subject, string message)
        {
            // send mail - output to Console window
            Console.WriteLine($"\nMail from {_mailFrom} to {_mailTo}, " +
                $"with {nameof(CloudMailService)}.\n");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }
    }
}
