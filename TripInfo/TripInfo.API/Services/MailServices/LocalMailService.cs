namespace TripInfo.API.Services.MailServices
{
    public class LocalMailService : IMailService
    {
        private readonly string _mailTo = string.Empty;
        private readonly string _mailFrom = string.Empty;

        public LocalMailService(IConfiguration configurtion) // inject IConfiguration, registered in program.cs with builder.ConfigureAppConfiguration (peek inside and see configuration for appsettings.json)
        {
            _mailTo = configurtion["mailSettings:mailToAddress"];
            _mailFrom = configurtion["mailSettings:mailFromAddress"];
        }

        public void Send(string subject, string message)
        {
            // send mail - output to Console window
            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, " +
                $"with {nameof(LocalMailService)}.");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }

        public void SendMostValuableCustomerInformation(string subject, string message)
        {
            // send mail - output to Console window
            Console.WriteLine($"\nMail from {_mailFrom} to {_mailTo}, " +
                $"with {nameof(LocalMailService)}.\n");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }
    }
}
