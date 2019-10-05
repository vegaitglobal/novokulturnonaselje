using NKN.Models.Generated;

namespace NKN.Core.Contexts
{
    public interface IPageContext<out T> : ISiteContext where T : class, IPage
    {
        T Page { get; }
    }
}