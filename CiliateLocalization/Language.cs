using System;
using System.Collections.Generic;
using System.Text;

namespace CiliateLocalization
{
	public class Language : ILanguage, ILanguageInfo
	{
		public ushort Index { get; }

		public string TextId { get; }

		public string Name0 { get; }

		public string Name1 { get; }

		protected Dictionary<uint, string> _Translations = new Dictionary<uint, string>();

		internal IReadOnlyDictionary<uint, string> Translations => _Translations;

		private readonly LanguageFirstModel Model;

		internal Language(ushort numericId, string textId, LanguageFirstModel model, string name0, string name1)
		:this(numericId, textId, model, new Dictionary<uint, string>(), name0, name1) {}

		internal Language(ushort numericId, string textId, LanguageFirstModel model, Dictionary<uint,string> translations, string name0, string name1)
		{
			Index = numericId; TextId = textId; Name0 = name0; Name1 = name1; Model = model; _Translations = translations;
		}

		public void SetTranslation(string id, string translation)
		{
			SetTranslation(Model.GetOrAddTranslationId(id), translation);
		}

		public void SetTranslation(uint id, string translation)
		{
			if (_Translations.ContainsKey(id))
				_Translations[id] = translation;
			else
				_Translations.Add(id, translation);
		}

		public string GetTranslation(string id) => _Translations[Model.GetTranslationId(id)];

		public string GetTranslation(uint id) => _Translations[id];
	}
}
