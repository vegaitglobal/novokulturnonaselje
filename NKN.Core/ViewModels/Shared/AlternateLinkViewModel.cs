namespace NKN.Core.ViewModels.Shared
{
	public class AlternateLinkViewModel
	{
		public AlternateLinkViewModel(string language, string url)
		{
			Language = language;
			Url = url;
		}

		public string Language { get; }
		public string Url { get; }
	}
}
