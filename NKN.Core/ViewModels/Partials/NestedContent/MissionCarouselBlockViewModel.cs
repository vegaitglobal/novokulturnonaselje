using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;
using System.Collections.Generic;
using System.Linq;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
    public class MissionCarouselBlockViewModel : INestedContentViewModel
    {
        public MissionCarouselBlockViewModel(INestedContentContext<MissionCarouselBlock> context)
        {
            Title = context.NestedContent.Title;
            BackgroundImage = (context.NestedContent.BackgroundImage as Image).ToViewModel();
            Items = context.NestedContent.Items.Select(i => context.WithNestedContent(i).ToViewModel<MissionItemViewModel>());
        }

        public string Title { get; private set; }
        public ImageViewModel BackgroundImage { get; private set; }
        public IEnumerable<MissionItemViewModel> Items { get; private set; }
    }
}