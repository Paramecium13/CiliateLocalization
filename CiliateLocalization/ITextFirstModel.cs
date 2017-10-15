using System;
using System.Collections.Generic;
using System.Text;

namespace CiliateLocalization
{
	public interface ITextFirstModel
	{
		void AddLanguageInfo(ushort numericId, string textId, string name0, string name1);
		IText AddText(string textId, string defaultTranslation);
	}
}
