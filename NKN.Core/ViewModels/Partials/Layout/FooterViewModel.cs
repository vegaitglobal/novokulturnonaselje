using NKN.Core.ViewModels.Partials.NestedContent;
using NKN.Models.Extensions;
using NKN.Models.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Web;

namespace NKN.Core.ViewModels.Partials.Layout
{
    public class FooterViewModel : INestedContentViewModel
    {
        public FooterViewModel(IFooter footer)
        {
            if (footer == null) throw new ArgumentNullException(nameof(footer));

            CopyrightText = footer.CopyrightText;
            Pages = footer.AncestorOrSelf<Home>().Children<FooterPages>()
                .SelectMany(child => child.Children<IPage>())
                .Distinct();
        }

        public string CopyrightText { get; }
        public IEnumerable<IPage> Pages { get; }
    }
}