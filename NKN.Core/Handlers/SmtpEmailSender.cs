using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace NKN.Core.Handlers
{
	public class SmtpEmailSender : IDisposable
	{
		public SmtpEmailSender()
		{
			// Getting the information from web config, smtp section.
			Smtp = new SmtpClient();
		}

		public SmtpClient Smtp { get; }

		public void SendEmail(string senderEmail, string subject, string body, string recieverEmail)
		{
			using (MailMessage mail = new MailMessage(senderEmail, recieverEmail))
			{
				mail.Subject = subject;
				mail.Body = body;
				mail.IsBodyHtml = true;

				Smtp.Send(mail);
			}
		}

		public void Dispose()
		{
			Smtp.Dispose();
		}
	}
}
