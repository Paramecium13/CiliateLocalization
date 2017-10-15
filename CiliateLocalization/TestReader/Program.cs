using CiliateLocalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestReader
{
	static class Program
	{
		static int Main(string[] args)
		{
			JObject json;
			using (var fs = File.OpenRead(@"..\..\..\..\a.json"))
			using (var s = new StreamReader(fs))
			using (var jr = new JsonTextReader(s))
				json = (JObject)JToken.ReadFrom(jr);

			var langMod = LanguageFirstModel.FromJson(json);
			return 0;
		}
	}
}
