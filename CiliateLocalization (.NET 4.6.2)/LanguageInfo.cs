namespace CiliateLocalization
{
	public class LanguageInfo : ILanguageInfo
	{
		public ushort NumericId { get; }
		public string TextId { get; }
		public string Name0 { get; }
		public string Name1 { get; }

		public LanguageInfo(ushort numericId, string textId, string name0, string name1)
		{
			NumericId = numericId; TextId = textId; Name0 = name0; Name1 = name1;
		}
	}
}