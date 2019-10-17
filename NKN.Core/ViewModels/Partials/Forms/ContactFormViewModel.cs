using NKN.Core.Validations;

namespace NKN.Core.ViewModels.Partials.Forms
{
	public class ContactFormViewModel
	{
		[UmbracoRequired("UmbracoValidation.Required")]
		public string FullName { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 300)]
		public string Message { get; set; }

		[UmbracoRequired("UmbracoValidation.Required")]
		[UmbracoStringLength("UmbracoValidation.StringLength", 40)]
		[UmbracoEmail(ErrorMessageDictionaryKey = "UmbracoValidation.EmailAddress")]
		public string Email { get; set; }
	}
}
