using System.Net;
using System.Net.Mail;
using WebSiteMachines.Interfaces;

namespace WebSiteMachines.Repositories
{
	public class EmailSenderService : IEmailSender
	{
		private readonly IConfiguration _configuration;

		public EmailSenderService(Castle.Core.Configuration.IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task SendEmailAsync(string email, string subject, string message)
		{
			var smtpServer = _configuration["EmailSettings:SmtpServer"];
			var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]);
			var senderEmail = _configuration["EmailSettings:Username"];
			var senderPassword = _configuration["EmailSettings:Password"];

			using (var smtpClient = new SmtpClient(smtpServer, smtpPort))
			{
				smtpClient.Credentials = new NetworkCredential(username, password);
				smtpClient.EnableSsl = true;

				var mailMessage = new MailMessage
				{
					From = new MailAddress(username),
					Subject = subject,
					Body = message,
					IsBodyHtml = true
				};

				mailMessage.To.Add(email);

				await smtpClient.SendMailAsync(mailMessage);
			}
		}
	}
}
