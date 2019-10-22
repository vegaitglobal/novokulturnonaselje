using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Partials.Layout;
using NKN.Core.ViewModels.Partials.NestedContent;
using NKN.Models.Extensions;
using NKN.Models.Generated;
using System.Collections.Generic;
using System.Linq;

namespace NKN.Core.ViewModels.Pages
{
	public class NewsLandingViewModel : PageViewModel
	{
		public NewsLandingViewModel(IPageContext<NewsLanding> context) : base(context)
		{
			Banner = new BannerViewModel(context.WithComposition(context.Page));
			NewsPreviews = context.Page.Descendants<NewsContainer>(nd => true)
				.Select(nc => nc.Descendants<DetailsPage>(nd => true))
				.SelectMany(nd => nd)
				.Where(nd => nd.Id != context.Page.HighlightedNews.Id)
				.OrderByDescending(nd => nd.ReleaseDate)
				.Select(nd => new DetailsPagePreviewViewModel(nd))
				.ToList();

			HighlightedNewsPreview = new DetailsPagePreviewViewModel(context.Page.HighlightedNews as DetailsPage);
			FirstRowNews = GetNews().Take(3);
			SecondRowNews = GetNews().Skip(FirstRowNews.Count());
			LastRowItems = GetLastSectionNews();
			ArchiveNews = NewsPreviews.Skip(FirstRowNews.Count() + SecondRowNews.Count() + LastRowItems.Count());
			ContactBlock = context.WithNestedContent(context.Page.ContactUsBlock?.FirstOrDefault()).ToViewModel<WriteUsViewModel>();
		}

		public BannerViewModel Banner { get; set; }
		public WriteUsViewModel ContactBlock { get; }

		#region NewsSection
		public IEnumerable<DetailsPagePreviewViewModel> NewsPreviews { get; private set; }
		public IEnumerable<DetailsPagePreviewViewModel> FirstRowNews { get; }
		public IEnumerable<DetailsPagePreviewViewModel> SecondRowNews { get; }
		public IEnumerable<DetailsPagePreviewViewModel> LastRowItems { get; }
		public IEnumerable<DetailsPagePreviewViewModel> ArchiveNews { get; }
		public bool IsArchive { get; set; }

		public DetailsPagePreviewViewModel HighlightedNewsPreview { get; private set; }

		private IEnumerable<DetailsPagePreviewViewModel> GetNews()
		{
			IList<DetailsPagePreviewViewModel> news = new List<DetailsPagePreviewViewModel>();

			foreach (var newItem in NewsPreviews.Take(6))
			{
				news.Add(newItem);
			}
			return news;
		}

		private IEnumerable<DetailsPagePreviewViewModel> GetLastSectionNews()
		{
			IList<DetailsPagePreviewViewModel> news = new List<DetailsPagePreviewViewModel>();

			foreach (var newItem in NewsPreviews.Skip(GetNews().Count()).Take(6))
			{
				news.Add(newItem);
			}
			return news;
		}
		
		#endregion



	}
}