using System.Globalization;
using TripInfo.API.Entities;
using TripInfo.API.Services.TripInfoServices;

namespace TripInfo.API.Services.MailServices;

public class EmailService : IEmailService
{
    private readonly IMailService _mailService;
    private readonly ITripInfoService _tripInfoService;

    public EmailService(IMailService mailService,
                        ITripInfoService tripInfoService)
    {
        _mailService = mailService ??
            throw new ArgumentNullException(nameof(mailService));
        _tripInfoService = tripInfoService ??
            throw new ArgumentNullException(nameof(tripInfoService));
    }

    public async Task SendSumOfTipsByGroup(Func<Task<IEnumerable<MetaData>>> getMetaData, string subject, string groupBy)
    {
        var metaData = await getMetaData();

        // Initialize the email body
        string emailBody = $"The Number of Groups are {metaData.Count()}\n";

        // Iterate through each group and add groupBy and tip
        for (int i = 0; i < metaData.Count(); i++)
        {
            var tipAmount = metaData.ElementAt(i).Tip;
            var formattedTip = tipAmount.ToString("C", CultureInfo.CurrentCulture);

            if (groupBy == "Month")
            {
                emailBody += $"\nMonth: {metaData.ElementAt(i).DateTime.ToString("MMMM")}\n";
            }
            else
            {
                emailBody += $"\n{groupBy}: {metaData.ElementAt(i).GetType().GetProperty(groupBy)?.GetValue(metaData.ElementAt(i), null)}\n";
            }

            emailBody += $"Tip: {formattedTip}\n";
        }

        // Send the email
        _mailService.Send($"{groupBy} Tip's Information by Group", emailBody);
    }
}


//  Please note that using concrete classes instead of interfaces for dependency injection can make your code harder to test and less flexible.