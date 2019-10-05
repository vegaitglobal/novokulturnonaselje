using NKN.Core.ViewModels.Shared;
using NKN.Models.Generated;

namespace NKN.Core.ViewModels.Partials.NestedContent
{
    public class FriendOrganizationViewModel
    {
        public FriendOrganizationViewModel(FriendOrganization model)
        {
            Image = model.Image.AsViewModel();
            Title = model.Title;
            FacebookLink = model.FacebookLink;
            YouTubeLink = model.YouTubeLink;
            InstagramLink = model.InstagramLink;
        }

        public ImageViewModel Image { get; set; }
        public string Title { get; set; }
        public string FacebookLink { get; set; }
        public string YouTubeLink { get; set; }
        public string InstagramLink { get; set; }
    }
}
