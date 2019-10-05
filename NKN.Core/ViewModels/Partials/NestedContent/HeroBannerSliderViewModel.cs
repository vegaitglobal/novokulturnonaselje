using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Models.Generated;
using System.Collections.Generic;
using System.Linq;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
    public class HeroBannerSliderViewModel : INestedContentViewModel
    {
        public HeroBannerSliderViewModel(INestedContentContext<HeroBannerSlider> context)
        {
            Slides = context.NestedContent.BannerSlides
                .Select(sl => context.WithNestedContent(sl).AsViewModel<BannerSlideViewModel>())
                .ToList();
     
        }
        public IEnumerable<BannerSlideViewModel> Slides { get; private set; }
    }
}