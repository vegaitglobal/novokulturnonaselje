using Umbraco.Core.Composing;
using Umbraco.Web;

namespace NKN.Core
{
    public static class UmbracoDictionary
    {
        public static class Forms
        {
            public static class Labels
            {
                public static string FullName => UmbracoHelper.GetDictionaryValue("Forms.Labels.FullName");
            }
        }

		public static class ProjectLanding
		{
			public static string RealizedProjects => UmbracoHelper.GetDictionaryValue("ProjectLanding.RealizedProjects");
			public static string FutureProjects => UmbracoHelper.GetDictionaryValue("ProjectLanding.FutureProjects");
			public static string ViewMore => UmbracoHelper.GetDictionaryValue("ProjectLanding.ViewMore");
		}
		public static class UmbracoValidation
		{
			public static string Required => UmbracoHelper.GetDictionaryValue("UmbracoValidation.Required");
			public static string StringLenght => UmbracoHelper.GetDictionaryValue("UmbracoValidation.StringLength");
			public static string EmailAddress => UmbracoHelper.GetDictionaryValue("UmbracoValidation.EmailAddress");
			
		}

		public static class NewsletterModule
		{
			public static string ValidEmail => UmbracoHelper.GetDictionaryValue("NewsletterBlock.ValidEmail");
		}
		public static class Mailchimp
		{
			public static string SucceededMessage => UmbracoHelper.GetDictionaryValue("Mailchimp.SucceededMessage");
			public static string FailedMessage => UmbracoHelper.GetDictionaryValue("Mailchimp.FailedMessage");
			public static string SubscribeButton => UmbracoHelper.GetDictionaryValue("Mailchimp.SubscribeButton");
		}

		private static UmbracoHelper UmbracoHelper =>
            (UmbracoHelper)Current.Factory.GetInstance(typeof(UmbracoHelper));
    }
}