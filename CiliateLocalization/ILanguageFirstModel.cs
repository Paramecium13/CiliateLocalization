using System;
using System.Collections.Generic;
using System.Text;

namespace CiliateLocalization
{
	public interface ILanguageFirstModel
	{
		ILanguage DefaultLanguage { get; }
		ILanguage AddLanguage(string textId, string name0, string name1);
		ILanguage GetLanguage(string textId);
		ILanguage GetLanguage(ushort numericId);
	}
}
