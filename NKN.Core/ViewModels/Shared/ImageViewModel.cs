using Umbraco.Web;
using NKN.Models.Generated;

namespace NKN.Core.ViewModels.Shared
{
    public class ImageViewModel
    {
        public ImageViewModel(string url, string alternateText = null)
        {
            Url = url;
            AlternateText = alternateText;
        }

        public ImageViewModel(Image image) : this(image.Url(), image.AlternateText)
        {
        }

        public string Url { get; }
        public string AlternateText { get; }
    }
}