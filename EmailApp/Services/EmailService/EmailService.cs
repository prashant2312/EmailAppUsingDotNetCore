using MailKit.Net.Smtp;
using MimeKit;

namespace EmailApp.Services.EmailService
{
    public class EmailService : IEmailService
    {
        IConfiguration _config;
        public EmailService(IConfiguration config)
        {
_config= config;
        }
        public void SendEmail(EmailDTO request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = request.Body };
            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHosts").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUserName").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
