using NKN.Core.Contexts;
using NKN.Models.Generated;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
    public class StatisticItemViewModel : INestedContentViewModel
    {
        public StatisticItemViewModel(INestedContentContext<StatisticItem> context)
        {
            Number = context.NestedContent.Number;
            Text = context.NestedContent.Text;
        }

        public int Number { get; }
        public string Text { get; }
    }
}