using NKN.Models.DocumentTypes.Compositions;

namespace NKN.Core.Contexts
{
	public interface ICompositionContext<out T> : ISiteContext where T : ICompositions
	{
		T Composition { get; }
	}
}
