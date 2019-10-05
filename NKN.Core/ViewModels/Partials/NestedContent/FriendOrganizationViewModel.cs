using NKN.Core.Extensions;
using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
    public class FriendOrganizationViewModel
    {
        public FriendOrganizationViewModel(FriendOrganization model)
        {
            Image = (model.Image as Image).ToViewModel();
            Title = model.Title;
            FacebookLink = model.FacebookLink;
            YouTubeLink = model.YouTubeLink;
            InstagramLink = model.InstagramLink;
            ExternalLink = model.ExternalLink;
            InternalLink = model.InternalLink.ToViewModel();
        }

        public ImageViewModel Image { get; set; }
        public string Title { get; set; }
        public string FacebookLink { get; set; }
        public string YouTubeLink { get; set; }
        public string InstagramLink { get; set; }
        public string ExternalLink { get; set; }
        public LinkViewModel InternalLink { get; set; }
    }
}
