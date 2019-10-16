using MailChimp.Net;
using MailChimp.Net.Models;
using NKN.Common;
using NKN.Core.ViewModels.Partials.Forms;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NKN.Core.Controllers.Surface
{
	public class NewsletterFormController : BaseSurfaceController
	{
		[ChildActionOnly]
		public ActionResult NewsletterForm()
		{
			return PartialView(new NewsletterFormViewModel());
		}

		[HttpPost]
		public async Task<string> SubscribeForm(string emailAddress)
		{
			Regex emailRegex = new Regex(AppSettings.EmailRegex);

			if (!string.IsNullOrEmpty(emailAddress) && emailRegex.IsMatch(emailAddress))
			{
				var member = new Member
				{
					EmailAddress = emailAddress,
					StatusIfNew = Status.Pending,
					EmailType = "html",
					IpSignup = Request.UserHostAddress,

					MergeFields = new Dictionary<string, object>
				{
					{"EMAILADDRESS", emailAddress }
				}
				};

				try
				{
					MailChimpManager Manager = new MailChimpManager(AppSettings.MailchimpApiKey);
					var result = await Manager.Members.AddOrUpdateAsync(AppSettings.MailchimpListId, member);
				}
				catch (Exception ex)
				{
					return UmbracoDictionary.Mailchimp.FailedMessage;
				}
				return UmbracoDictionary.Mailchimp.SucceededMessage;
			}

			return UmbracoDictionary.Mailchimp.FailedMessage;
		}
	}
}
