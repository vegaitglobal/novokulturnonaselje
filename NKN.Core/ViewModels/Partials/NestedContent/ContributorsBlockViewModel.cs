using NKN.Core.Contexts;
using NKN.Models.Generated;
using System.Collections.Generic;
using System.Linq;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
    public class ContributorsBlockViewModel : INestedContentViewModel
    {
        public ContributorsBlockViewModel(INestedContentContext<ContributorsBlock> context)
        {
            Title = context.NestedContent.Title;
            Text = context.NestedContent.Text;
            Contributors = context.NestedContent.Contributors?.OfType<FriendOrganization>().Select(model => new FriendOrganizationViewModel(model));
            ShowSocialLinks = context.NestedContent.ShowSocialLinks;
            ShowContributorTitles = context.NestedContent.ShowContributorTitles;
            IncludeHover = context.NestedContent.IncludeHover;
        }

        public string Title { get; set; }
        public string Text { get; set; }
        public IEnumerable<FriendOrganizationViewModel> Contributors { get; set; }
        public bool ShowSocialLinks { get; set; }
        public bool ShowContributorTitles { get; set; }
        public bool IncludeHover { get; set; }
    }
}
