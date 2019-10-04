using NKN.Models.Generated;

namespace NKN.Core.Contexts
{
    public interface ISiteContext
    {
        IPage CurrentPage { get; }
        Home Home { get; }
        ISiteSettings SiteSettings { get; }
    }
}