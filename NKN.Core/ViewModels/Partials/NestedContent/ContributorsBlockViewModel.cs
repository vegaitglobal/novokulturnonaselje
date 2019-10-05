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
            Contributors = context.NestedContent.Contributors?.OfType<FriendOrganization>();
        }

        public IEnumerable<FriendOrganization> Contributors { get; set; }

    }
}
