using System;
using Umbraco.Web;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;

namespace NKN.Core.ViewModels.Partials.Layout
{
    public class HeaderViewModel
    {
        public HeaderViewModel(IHeader header)
        {
            if (header == null) throw new ArgumentNullException(nameof(header));

            Logo = (header.Logo as Image).ToViewModel();
            LogoUrl = header.AncestorOrSelf<Home>().Url;
        }

        public ImageViewModel Logo { get; }
        public string LogoUrl { get; }
    }
}