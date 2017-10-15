using CiliateLocalization.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace CiliateLocalization
{
	public class LanguageFirstModel : ILanguageFirstModel
	{
		private readonly IdMap<uint> TranslationIds;

		private readonly IdMap<ushort> LanguageIds;

		private readonly Dictionary<ushort, Language> Languages;

		public ILanguage DefaultLanguage { get; }


		public ILanguage AddLanguage(string textId, string name0, string name1)
		{
			if (LanguageIds.Ids.ContainsKey(textId))
				throw new ArgumentException();
			var id = LanguageIds.GetOrAddId(textId);
			var language = new Language(id, textId, this, name0, name1);
			Languages.Add(id, language);
			return language;
		}

		public ILanguage GetLanguage(string textId)
			=> Languages[LanguageIds.GetId(textId)];

		public ILanguage GetLanguage(ushort numericId)
			=> Languages[numericId];

		internal uint GetOrAddTranslationId(string textId)
			=> TranslationIds.GetOrAddId(textId);

		internal uint GetTranslationId(string textId)
			=> TranslationIds.GetId(textId);
	}
}
