using NKN.Models.DocumentTypes.Compositions;
using NKN.Models.Generated;
using System.Collections.Generic;

namespace NKN.Core.Contexts
{
	public interface ICompositionContext<out T> : ISiteContext where T : ICompositions
	{
		T Composition { get; }

	}
}
