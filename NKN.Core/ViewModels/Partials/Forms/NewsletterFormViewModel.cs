using NKN.Core.Validations;

namespace NKN.Core.ViewModels.Partials.Forms
{
	public class NewsletterFormViewModel
	{

		[UmbracoRequired("NewsletterBlock.ValidEmail")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 50)]
		[UmbracoEmail(ErrorMessageDictionaryKey = "UmbracoValidation.EmailAddress")]
		public string EmailAddress { get; set; }
	}
}
