using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Extensions;
using NKN.Models.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace NKN.Core.ViewModels.Partials.Layout
{
	public class HeaderViewModel
	{
		public HeaderViewModel(ICompositionContext<IHeader> header)
		{
			if (header == null) throw new ArgumentNullException(nameof(header));

			Logo = (header.Home.Logo as Image).ToViewModel();
			LogoBlack = (header.Home.LogoBlack as Image).ToViewModel();
			LogoUrl = header.Home.AncestorOrSelf<Home>().Url;
			FacebookLink = header.Home.FacebookLink;
			InstagramLink = header.Home.InstagramLink;
			YouTubeLink = header.Home.YouTubeLink;
			NavigationItems = header.Home.AncestorOrSelf<Home>().GetNavigationItems<IPage>();
			Cultures = header.Home.Cultures;
			CurrentPage = header.CurrentPage;
			HomeName = header.Home.GetCultureFromDomains().Split('-')[0].ToUpper();

		}
		public string HomeName { get; }
		public IPage CurrentPage {get;}
		public IReadOnlyDictionary<string,PublishedCultureInfo> Cultures { get; }
        public ImageViewModel Logo { get; }
        public ImageViewModel LogoBlack { get; }
        public string LogoUrl { get; }
        public string FacebookLink { get; }
        public string InstagramLink { get; }
        public string YouTubeLink { get; }
        public IEnumerable<IPage> NavigationItems { get; }

	}
}