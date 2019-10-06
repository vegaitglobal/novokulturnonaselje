using NKN.Common;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;
using System.Linq;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
    public class NewsDetailPreviewViewModel
    {
        public NewsDetailPreviewViewModel(NewsDetail news)
        {
            PageTitle = news.PageTitle;
            SmallImage = (news.SmallImage as Image).ToViewModel();
            ReleaseDate = news.ReleaseDate.ToString(AppSettings.DateFormat);
            Summary = string.Join(string.Empty, news.Summary.ToCharArray().Take(150));
            SummaryHighlighted = string.Join(string.Empty, news.Summary.ToCharArray().Take(200));
            Link = new LinkViewModel(news.Url, "Saznaj Vise", "");
        }

        public string PageTitle { get; private set; }
        public ImageViewModel SmallImage { get; private set; }
        public string ReleaseDate { get; private set; }
        public string Summary { get; private set; }
        public string SummaryHighlighted { get; private set; }
        public LinkViewModel Link { get; private set; }
    }
}