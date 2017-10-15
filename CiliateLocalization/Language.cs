using System;
using System.Collections.Generic;
using System.Text;

namespace CiliateLocalization
{
	public class Language : ILanguage, ILanguageInfo
	{
		public ushort NumericId { get; }

		public string TextId { get; }

		public string Name0 { get; }

		public string Name1 { get; }

		protected Dictionary<uint, string> Translations = new Dictionary<uint, string>();

		private readonly LanguageFirstModel Model;

		internal Language(ushort numericId, string textId, LanguageFirstModel model, string name0, string name1)
		:this(numericId, textId, model, new Dictionary<uint, string>(), name0, name1) {}

		internal Language(ushort numericId, string textId, LanguageFirstModel model, Dictionary<uint,string> translations, string name0, string name1)
		{
			NumericId = numericId; TextId = textId; Name0 = name0; Name1 = name1; Model = model; Translations = translations;
		}

		public void SetTranslation(string id, string translation)
		{
			SetTranslation(Model.GetOrAddTranslationId(id), translation);
		}

		public void SetTranslation(uint id, string translation)
		{
			if (Translations.ContainsKey(id))
				Translations[id] = translation;
			else
				Translations.Add(id, translation);
		}

		public string GetTranslation(string id) => Translations[Model.GetTranslationId(id)];

		public string GetTranslation(uint id) => Translations[id];
	}
}
