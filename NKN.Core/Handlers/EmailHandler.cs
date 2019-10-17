using NKN.Common;
using NKN.Core.ViewModels.Partials.Forms;
using System;
using System.Configuration;
using System.Net.Configuration;
using System.Text;
using System.Web.Mvc;

namespace NKN.Core.Handlers
{
	public class EmailHandler
	{
		public bool ContactUs(ContactFormViewModel model, string adminEmailAddress)
		{
			if (string.IsNullOrEmpty(adminEmailAddress)) adminEmailAddress = AppSettings.AdminEmailAdress;
			StringBuilder subject = new StringBuilder();
			subject.Append("Podaci sa kontakt forme: ");

			StringBuilder body = new StringBuilder();
			body.Append($"Ime i prezime: {model.FullName}");
			body.AppendLine($"E-mail: {model.Email}");
			body.AppendLine($"Poruka: {model.Message}");

			string senderEmail = AppSettings.AdminEmailAdress;
			return SendEmail(senderEmail, subject.ToString(), MvcHtmlString.Create(body.ToString().Replace("\n", "<br/>")).ToString(), adminEmailAddress);

		}
				/// <summary>
		/// Tries to send email three times, third time using the sender email address from Web.Config.
		/// </summary>
		private bool SendEmail(string senderEmail, string subject, string body, string recieverEmail)
		{
			try
			{
				SendSmptEmail(senderEmail, subject, body, recieverEmail);
				return true;
			}
			catch (Exception ex1)
			{
				try
				{
					SendSmptEmail(senderEmail, subject, body, recieverEmail);
					return true;
				}
				catch (Exception ex2)
				{
					try
					{
						SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");

						SendSmptEmail(senderEmail, subject, body, recieverEmail);
						return true;
					}
					catch (Exception ex3)
					{
						return false;
					}

				}
			}
		}

		/// <summary>
		/// Send mail.
		/// </summary
		private void SendSmptEmail(string senderEmail, string subject, string body, string recieverEmail)
		{
			using (SmtpEmailSender email = new SmtpEmailSender())
			{
				email.SendEmail(senderEmail, subject, body, recieverEmail);
			}
		}
	}
}
