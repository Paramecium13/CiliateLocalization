using CiliateLocalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWriter
{
	static class Program
	{
		static void Main(/*string[] args*/)
		{
			var langs = new ProtoLanguage[]
			{
				new ProtoLanguage{ Index = 0, Name0 = "a", Name1= "B", TextId = "a", Translations = new Dictionary<uint, string>
					{ {0,"a" },{1,"z" },{2,"a" },{3,"v" } }},
				new ProtoLanguage{ Index = 1, Name0 = "a", Name1= "B", TextId = "b", Translations = new Dictionary<uint, string>
					{ {0,"s" },{1,"d" },{2,"d" },{3,"v" } }},
				new ProtoLanguage{ Index = 2, Name0 = "a", Name1= "B", TextId = "c", Translations = new Dictionary<uint, string>
					{ {0,"a" },{1,"x" },{2,"s" },{3,"f" } }},
				new ProtoLanguage{ Index = 3, Name0 = "a", Name1= "B", TextId = "d", Translations = new Dictionary<uint, string>
					{ {0,"x" },{1,"r" },{2,"x" },{3,"z" } }},
				new ProtoLanguage{ Index = 4, Name0 = "a", Name1= "B", TextId = "e", Translations = new Dictionary<uint, string>
					{ {0,"x" },{1,"f" },{2,"l" },{3,"f" } }
				}
			};
			var transIds = new Dictionary<string, uint>
			{
				{"w",0},{"x",1 },{"y",2 },{"z",3 }
			};
			var langMod = new LanguageFirstModel(langs, transIds);
			var json = langMod.JsonSerialize();
			using (var fs = File.OpenWrite(@"..\..\..\a.json"))
			using (var stream = new StreamWriter(fs))
			using (var jsonTextWriter = new JsonTextWriter(stream))
			{
				json.WriteTo(jsonTextWriter);
			}

		}
	}
}
