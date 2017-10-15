using System;
using System.Collections.Generic;
using System.Text;

namespace CiliateLocalization
{
	public class Text : IText
	{
		public uint NumericId { get; }

		public string TextId { get; }

		public string DefaultText => Translations[0];

		private readonly TextFirstModel Model;

		private readonly Dictionary<ushort, string> Translations;

		internal Text(uint numericId, string textId, TextFirstModel model, Dictionary<ushort,string> translations)
		{
			NumericId = numericId; TextId = textId; Model = model; Translations = translations;
		}

		internal Text(uint numericId, string textId, TextFirstModel model):this(numericId,textId,model,new Dictionary<ushort, string>())
		{}

		public string GetTranslation(ushort languageIndex) => Translations[languageIndex];

		public string GetTranslation(string languageId) => Translations[Model.GetLanguageIndex(languageId)];

		public void SetTranslation(ushort languageIndex, string translation)
		{
			if (Translations.ContainsKey(languageIndex))
				Translations[languageIndex] = translation;
			else
				Translations.Add(languageIndex, translation);
		}

		public void SetTranslation(string languageId, string translation)
		{
			SetTranslation(Model.GetLanguageIndex(languageId), translation);
		}
	}
}
