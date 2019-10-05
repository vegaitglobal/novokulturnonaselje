using NKN.Core.Contexts;
using NKN.Core.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;
using System.Collections.Generic;
using System.Linq;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
    public class StatisticsBlockViewModel : INestedContentViewModel
    {
        public StatisticsBlockViewModel(INestedContentContext<StatisticsBlock> context)
        {
            BackgroundImage = (context.NestedContent.BackgroundImage as Image).ToViewModel();
            StatisticItems = context.NestedContent.StatisticItems.Select(i => context.WithNestedContent(i).ToViewModel<StatisticItemViewModel>());
        }

        public ImageViewModel BackgroundImage { get; private set; }
        public IEnumerable<StatisticItemViewModel> StatisticItems { get; private set; }
    }
}