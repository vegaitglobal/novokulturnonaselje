using NKN.Models.Generated;

namespace NKN.Core.ViewModels.Shared
{
	public class LanguageLinkViewModel : LinkViewModel
	{
		public LanguageLinkViewModel(IPage page, string language) : base(page.Url, language)
		{
		}
	}
}
