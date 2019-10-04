using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace NKN.Core.Extensions
{
	/// <summary>
	/// <see cref="UmbracoContext"/> extension methods.
	/// </summary>
	public static class UmbracoContextExtensions
	{
		/// <summary>
		/// Returns root node of the domain provided <paramref name="context"/> is associated with.
		/// </summary>
		/// <param name="context">Umbraco Context.</param>
		/// <param name="currentUrl">The current request URL.</param>
		/// <returns>Domain root node or the first node in the content tree.</returns>
		public static IPublishedContent TypedContentAtDomainRoot(this UmbracoContext context, string currentUrl)
			=> context.Content.GetAtRoot().FirstOrDefault(r => currentUrl.StartsWith(r.Url));
	}
}
