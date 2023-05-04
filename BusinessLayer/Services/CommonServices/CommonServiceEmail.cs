using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BusinessLayer.Services.CommonServices;

public class CommonServiceEmail
{
    private readonly string _adminEmail;
    private readonly string _key;

    public CommonServiceEmail(IConfiguration configuration)
    {
        _adminEmail = configuration["SendGrid:DefaultSenderMail"];
        _key = configuration["SendGrid:Key"];
    }

    public void SendMultipleMessages(List<EmailAddress> to, string templateId, object content)
    {
        var client = new SendGridClient(_key);
        var message = new SendGridMessage();
        message.SetFrom(_adminEmail);
        message.AddTos(to);
        message.SetTemplateId(templateId);
        message.SetTemplateData(content);
        Console.WriteLine(client.SendEmailAsync(message).Result);
    }

    public void SendSingleMessage(string to, string templateId, object content)
    {
        var client = new SendGridClient(_key);
        var message = new SendGridMessage();
        message.SetFrom(_adminEmail);
        message.AddTo(to);
        message.SetTemplateId(templateId);
        message.SetTemplateData(content);
        Console.WriteLine(client.SendEmailAsync(message).Result);
    }
}