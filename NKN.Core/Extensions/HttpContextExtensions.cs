using System.Web;

namespace NKN.Core.Extensions
{
	/// <summary>
	/// <see cref="HttpContextBase"/> extension methods.
	/// </summary>
	public static class HttpContextExtensions
	{
		/// <summary>
		/// Converts <paramref name="context"/> to <see cref="HttpContextBase"/> type.
		/// </summary>
		/// <param name="context">HTTP context.</param>
		/// <returns><see cref="HttpContextBase"/> instance created from <paramref name="context"/>.</returns>
		public static HttpContextBase ToBase(this HttpContext context)
			=> new HttpContextWrapper(context);
		
	}
}
