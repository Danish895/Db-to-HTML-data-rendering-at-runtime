using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace GenericModelToHTML.Service
{
    public class EmailService : IEmailService
    {
            private readonly IConfiguration _config;


            public EmailService(IConfiguration config)
            {
                _config = config;

            }

            public bool sendEmail(string Body)
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("dkhan895@gmail.com"));
                email.To.Add(MailboxAddress.Parse("dkhan895@gmail.com"));
                email.Subject = "Html Template";
                email.Body = new TextPart(TextFormat.Html) { Text = Body };

                using var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("dkhan895@gmail.com", "muxlnuozyheyzxrs");
                smtp.Send(email);
                smtp.Disconnect(true);

                return true;
            }
        }
}
