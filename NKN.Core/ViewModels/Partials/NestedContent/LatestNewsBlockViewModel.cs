using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Models.Generated;
using System.Collections.Generic;
using System.Linq;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
	public class LatestNewsBlockViewModel : INestedContentViewModel
	{
		public LatestNewsBlockViewModel(INestedContentContext<LatestNewsBlock> context)
		{
			Title = context.NestedContent.Title;
			LatestNews = context.LatestNews?.ToViewModel<DetailsPagePreviewViewModel>().ToList();
		}
		public string Title { get; }
		public IList<DetailsPagePreviewViewModel> LatestNews { get; }
	}
}
