using NKN.Common;
using NKN.Core.Handlers;
using NKN.Core.ViewModels.Partials.Forms;
using System.Web.Mvc;

namespace NKN.Core.Controllers.Surface.Partials
{
	public class ContactFormController : BaseSurfaceController
	{
		[ChildActionOnly]
		public ActionResult ContactForm()
		{
			return PartialView(new ContactFormViewModel());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SubmitForm(ContactFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return CurrentUmbracoPage();
			}

			EmailHandler emailSender = new EmailHandler();

			bool sentMail = emailSender.ContactUs(model, AppSettings.AdminEmailAdress);

			if (!sentMail)
			{
				TempData[Constants.Constants.TempDataFail] = "fail";
				return CurrentUmbracoPage();
			}
			TempData[Constants.Constants.TempDataSuccess] = "success";

			return RedirectToCurrentUmbracoPage();

		}
	}
}
