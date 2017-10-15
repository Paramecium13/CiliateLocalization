using System;
using System.Collections.Generic;
using System.Text;

namespace CiliateLocalization
{
	public interface ITextFirstModel
	{
		IReadOnlyList<ILanguageInfo> LanguageInfo { get; }

		ILanguageInfo DefaultLanguage { get; }

		void AddLanguageInfo(ushort numericId, string textId, string name0, string name1);
		IText AddText(string textId, string defaultTranslation);
		IText GetText(string textId);
		IText GetText(uint numericId);
	}
}
