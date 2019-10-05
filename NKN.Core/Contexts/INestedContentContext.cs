using NKN.Models.DocumentTypes;

namespace NKN.Core.Contexts
{
    public interface INestedContentContext<out T> : ISiteContext where T : INestedContent
    {
        T NestedContent { get; }
    }
}