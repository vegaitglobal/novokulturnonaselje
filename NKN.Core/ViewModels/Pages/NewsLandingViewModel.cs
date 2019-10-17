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
				.Select(nc => nc.Descendants<NewsDetails>(nd => true))
				.SelectMany(nd => nd)
				.Where(nd => nd.Id != context.Page.HighlightedNews.Id)
				.OrderByDescending(nd => nd.ReleaseDate)
				.Select(nd => new NewsDetailPreviewViewModel(nd))
				.ToList();

			HighlightedNewsPreview = new NewsDetailPreviewViewModel(context.Page.HighlightedNews as NewsDetails);
			FirstRowNews = GetNews().Take(3);
			SecondRowNews = GetNews().Skip(FirstRowNews.Count());
			LastRowItems = GetLastSectionNews();
			ArchiveNews = NewsPreviews.Skip(FirstRowNews.Count() + SecondRowNews.Count() + LastRowItems.Count());

			ContactBlock = context.WithNestedContent(context.Page.ContactUsBlock?.FirstOrDefault()).ToViewModel<WriteUsViewModel>();
			NewsletterBlock = context.WithNestedContent(context.Page.NewsletterBlock?.FirstOrDefault()).ToViewModel<NewsletterBlockViewModel>();
		}

		public BannerViewModel Banner { get; set; }
		public WriteUsViewModel ContactBlock { get; }
		public NewsletterBlockViewModel NewsletterBlock { get; }

		#region NewsSection
		public IEnumerable<NewsDetailPreviewViewModel> NewsPreviews { get; private set; }
		public IEnumerable<NewsDetailPreviewViewModel> FirstRowNews { get; }
		public IEnumerable<NewsDetailPreviewViewModel> SecondRowNews { get; }
		public IEnumerable<NewsDetailPreviewViewModel> LastRowItems { get; }
		public IEnumerable<NewsDetailPreviewViewModel> ArchiveNews { get; }

		public NewsDetailPreviewViewModel HighlightedNewsPreview { get; private set; }

		private IEnumerable<NewsDetailPreviewViewModel> GetNews()
		{
			IList<NewsDetailPreviewViewModel> news = new List<NewsDetailPreviewViewModel>();

			foreach (var newItem in NewsPreviews.Take(6))
			{
				news.Add(newItem);
			}
			return news;
		}

		private IEnumerable<NewsDetailPreviewViewModel> GetLastSectionNews()
		{
			IList<NewsDetailPreviewViewModel> news = new List<NewsDetailPreviewViewModel>();

			foreach (var newItem in NewsPreviews.Skip(GetNews().Count()).Take(6))
			{
				news.Add(newItem);
			}
			return news;
		}
		
		#endregion



	}
}