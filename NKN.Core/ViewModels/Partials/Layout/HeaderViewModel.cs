using System;
using Umbraco.Web;
using NKN.Core.Extensions;
using NKN.Models.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;
using NKN.Core.ViewModels.Partials.NestedContent;
using System.Linq;
using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;

namespace NKN.Core.ViewModels.Partials.Layout
{
    public class HeaderViewModel : INestedContentViewModel
    {
        public HeaderViewModel(IHeader header)
        {
            if (header == null) throw new ArgumentNullException(nameof(header));

            Logo = (header.Logo as Image).ToViewModel();
            LogoBlack = (header.LogoBlack as Image).ToViewModel();
            LogoUrl = header.AncestorOrSelf<Home>().Url;
            FacebookLink = header.AncestorOrSelf<Home>().FacebookLink;
            InstagramLink = header.AncestorOrSelf<Home>().InstagramLink;
            YouTubeLink = header.AncestorOrSelf<Home>().YouTubeLink;
            NavigationItems = header.AncestorOrSelf<Home>().GetNavigationItems<IPage>();
        }

        public ImageViewModel Logo { get; }
        public ImageViewModel LogoBlack { get; }
        public string LogoUrl { get; }
        public string FacebookLink { get; }
        public string InstagramLink { get; }
        public string YouTubeLink { get; }
        public IEnumerable<IPage> NavigationItems { get; }
    }
}