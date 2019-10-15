using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NKN.Core.ViewModels.Partials.Layout
{
	public class FooterViewModel
    {
        public FooterViewModel(ICompositionContext<IFooter> footer)
        {
            if (footer == null) throw new ArgumentNullException(nameof(footer));

            CopyrightText = footer.Composition.CopyrightText;
			HygieneLinks = footer.Composition.HygieneLinks?.Select(h => h.ToViewModel()).ToList();
		}

        public string CopyrightText { get; }
		public IReadOnlyList<LinkViewModel> HygieneLinks { get; }
    }
}