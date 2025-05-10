using Azure.Core;
using Resend;
using RigelSolarAPI.Dto;

namespace RigelSolarAPI.Utils;

public class SendEmail
{
    private readonly IResend _resend;

    public SendEmail(IResend resend)
    {
        _resend = resend;
    }


    public async Task Execute(EnviarEmailDTO request)
    {
        var message = new EmailMessage();
        message.From = request.From;
        message.To.Add(request.To);
        message.Subject = request.Subject;
        message.HtmlBody = $"<strong>{request.Content}</strong>";

        await _resend.EmailSendAsync(message);
    }
}
