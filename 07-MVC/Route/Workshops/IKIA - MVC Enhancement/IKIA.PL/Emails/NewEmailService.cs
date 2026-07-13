using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace IKIA.PL.Emails
{
    public class NewEmailService : INewEmailService
	{
		private readonly NewEmailSettings _options;

		public NewEmailService(IOptions<NewEmailSettings> options)
        {
			_options = options.Value;
		}
        public void SendEmail(string to, string subject, string body)
		{
			var Email = new MimeMessage()
			{
				Sender = MailboxAddress.Parse(_options.Email),
				Subject = subject,
				

			};
			Email.To.Add(MailboxAddress.Parse(to));
			Email.From.Add(new MailboxAddress(_options.DisplayName, _options.Email));

			var builder = new BodyBuilder();
			builder.TextBody = body;
			
			Email.Body = builder.ToMessageBody();

			using var smtp = new SmtpClient();        // MailKit.Net.Smtp not the other one from the system 
			smtp.Connect(_options.Host, _options.Port , MailKit.Security.SecureSocketOptions.StartTls  /*port of gmail 587 uses Tls*/);
			smtp.Authenticate(_options.Email, _options.Password);
			smtp.Send(Email);
			smtp.Disconnect(true);
		}
	}
}
