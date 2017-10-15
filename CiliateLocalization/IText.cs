using System;
using System.Collections.Generic;
using System.Text;

namespace CiliateLocalization
{
	public interface IText
	{
		uint NumericId { get; }
		string TextId { get; }
		string DefaultText { get; }
		void SetTranslation(ushort languageIndex, string translation);
		void SetTranslation(string languageId, string translation);
		string GetTranslation(ushort languageIndex);
		string GetTranslation(string languageId);
	}
}
