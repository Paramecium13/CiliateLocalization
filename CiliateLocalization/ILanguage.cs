using System;
using System.Collections.Generic;
using System.Text;

namespace CiliateLocalization
{
	public interface ILanguage
	{
		void AddTranslation(string id, string translation);
		void AddTranslation(uint id, string translation);
		string GetTranslation(string id);
		string GetTranslation(uint id);
	}
}
