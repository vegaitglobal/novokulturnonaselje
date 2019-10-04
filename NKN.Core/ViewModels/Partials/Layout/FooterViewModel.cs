using System;
using NKN.Models.Generated;

namespace NKN.Core.ViewModels.Partials.Layout
{
    public class FooterViewModel
    {
        public FooterViewModel(IFooter footer)
        {
            if (footer == null) throw new ArgumentNullException(nameof(footer));

            CopyrightText = footer.CopyrightText;
        }

        public string CopyrightText { get; }
    }
}