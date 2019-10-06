using NKN.Core.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
    public class NewsDetailPreviewViewModel
    {
        public NewsDetailPreviewViewModel(NewsDetail news)
        {
            SmallImage = (news.SmallImage as Image).ToViewModel();
            ReleaseDate = news.ReleaseDate;
            Summary = news.Summary;
            Link = new LinkViewModel(news.Url, "Saznaj Vise" ,"");
        }

        public ImageViewModel SmallImage { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public string Summary { get; private set; }
        public LinkViewModel Link { get; private set; }

    }
}
