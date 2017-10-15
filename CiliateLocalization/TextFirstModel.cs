using CiliateLocalization.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace CiliateLocalization
{
	public class TextFirstModel : ITextFirstModel
	{
		private readonly List<LanguageInfo> _LanguageInfo;

		public IReadOnlyList<ILanguageInfo> LanguageInfo => _LanguageInfo;

		public ILanguageInfo DefaultLanguage { get; }

		private readonly IdMap<ushort> LanguageIds;

		private readonly IdMap<uint> TextIds;

		private readonly Dictionary<uint, Text> Texts;

		// Constructor...

		public void AddLanguageInfo(ushort numericId, string textId, string name0, string name1)
		{
			_LanguageInfo.Add(new LanguageInfo(numericId, textId, name0, name1));
		}

		public ushort AddLanguageInfo(string textId, string name0, string name1)
		{
			var numericId = LanguageIds.GetOrAddId(textId);
			_LanguageInfo.Add(new LanguageInfo(numericId, textId, name0, name1));
			return numericId;
		}

		public IText AddText(string textId, string defaultTranslation)
		{
			throw new NotImplementedException();
		}

		public IText GetText(string textId)
		{
			throw new NotImplementedException();
		}

		public IText GetText(uint numericId)
		{
			throw new NotImplementedException();
		}

		internal ushort GetLanguageIndex(string textId) => LanguageIds.GetId(textId);
	}
}
