using NKN.Models.DocumentTypes;

namespace NKN.Core.Contexts
{
	public interface ISeoContext<out T> : ISiteContext where T : class, ISeo
	{
		T Seo { get; }
	}
}
