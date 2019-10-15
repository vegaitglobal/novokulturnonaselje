using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
	public class FutureProjectItemViewModel : INestedContentViewModel
	{
		public FutureProjectItemViewModel(INestedContentContext<FutureProjectItem> item)
		{
			Title = item.NestedContent.Title;
			Text = item.NestedContent.Text;
			Image = (item.NestedContent.Image as Image)?.ToViewModel();
		}
		public string Title { get; }
		public string Text { get; }
		public ImageViewModel Image { get; }
	}
}
