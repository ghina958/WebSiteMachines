﻿
using System.Net;
using System.Net.Mail;
using WebSiteMachines.Interfaces;

namespace WebSiteMachines.Repositories
{
	public class EmailSenderService : IEmailSender
	{
		private readonly IConfiguration _configuration;

		public EmailSenderService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task SendEmailAsync(string email, string subject, string message)
		{
			var smtpServer = _configuration["EmailSettings:SmtpServer"];
			var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]);
			var senderEmail = _configuration["EmailSettings:SenderEmail"];
			var senderPassword = _configuration["EmailSettings:SenderPassword"];

			var smtpClient = new SmtpClient(smtpServer)
			{
				Port = smtpPort,
				Credentials = new NetworkCredential(senderEmail, senderPassword),
				EnableSsl = true,
			};

			var mailMessage = new MailMessage
			{
				From = new MailAddress(senderEmail),
				Subject = subject,
				Body = message,
				IsBodyHtml = true,
			};

			mailMessage.To.Add(email);

			await smtpClient.SendMailAsync(mailMessage);
		}
	}
}
