using System.Text;
using Umbraco.Core;
using NKN.Common.Extensions;

namespace NKN.Search.Models
{
	internal class NestedContentIndexData
	{
		public string Title { get; set; }

		public string Text { get; set; }

		public string GetSearchableContent()
		{
			StringBuilder builder = new StringBuilder();

			builder.TryAppendLine(Title);
			builder.TryAppendLine(Text?.StripHtml());
			
			return builder.ToString();
		}
	}
}
