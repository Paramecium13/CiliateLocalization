using System;
using System.Collections.Generic;
using System.Text;

namespace CiliateLocalization
{
	public interface ILanguage
	{
		void SetTranslation(string id, string translation);
		void SetTranslation(uint id, string translation);
		string GetTranslation(string id);
		string GetTranslation(uint id);
	}
}
