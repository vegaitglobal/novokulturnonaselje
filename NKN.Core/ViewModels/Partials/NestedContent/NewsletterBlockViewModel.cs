using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
	public class NewsletterBlockViewModel : INestedContentViewModel
	{
		public NewsletterBlockViewModel(INestedContentContext<NewsletterBlock> context)
		{
			Title = context.NestedContent.Title;
			Text = context.NestedContent.Text;
			BackgroundImage = (context.NestedContent.BackgroundImage as Image)?.ToViewModel();
		}
		public ImageViewModel BackgroundImage { get; }
		public string Title { get; }
		public string Text { get; }
	}
}
