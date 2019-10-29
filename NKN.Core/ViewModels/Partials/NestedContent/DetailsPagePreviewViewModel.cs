using NKN.Common;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;
using System.Linq;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
    public class DetailsPagePreviewViewModel
    {
        public DetailsPagePreviewViewModel(DetailsPage content)
        {
            PageTitle = content.PageTitle;
            SmallImage = content.SmallImage?.ToViewModel();
            ReleaseDate = content.ReleaseDate.ToString(AppSettings.DateFormat);
            Summary = string.Join(string.Empty, content.Summary.ToCharArray().Take(150));
            SummaryHighlighted = string.Join(string.Empty, content.Summary.ToCharArray().Take(200));
			PageUrl = content.Url;
        }

        public string PageTitle { get;  }
        public ImageViewModel SmallImage { get; }
        public string ReleaseDate { get; }
        public string Summary { get;  }
        public string SummaryHighlighted { get; }
		public string PageUrl { get; }
    }
}