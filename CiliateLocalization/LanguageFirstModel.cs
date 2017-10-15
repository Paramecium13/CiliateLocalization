using CiliateLocalization.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CiliateLocalization
{
	public class ProtoLanguage : ILanguageInfo
	{
		public ushort Index { get; set; }

		public string TextId { get; set; }

		public string Name0 { get; set; }

		public string Name1 { get; set; }

		public readonly Dictionary<uint, string> Translations = new Dictionary<uint, string>();
	}

	public class LanguageFirstModel : ILanguageFirstModel
	{
		private readonly IdMap<uint> TranslationIds;

		private readonly IdMap<ushort> LanguageIds;

		private readonly Dictionary<ushort, Language> Languages;

		public ILanguage DefaultLanguage => Languages[0];

		public LanguageFirstModel(IEnumerable<Language> languages, IReadOnlyDictionary<string,uint> translationIds)
		{
			Languages = languages.ToDictionary(l => l.Index);
			LanguageIds = new IdMap<ushort>(languages.ToDictionary(l => l.TextId, l => l.Index)
				, x => (ushort)(x + 1),
				(x, y) => x == y);
			TranslationIds = new IdMap<uint>(translationIds, x => (uint)(x + 1),
				(x, y) => x == y);
		}

		public LanguageFirstModel(IEnumerable<ProtoLanguage> languages, IReadOnlyDictionary<string,uint> translationIds)
		{
			Languages = languages.Select(l => new Language(l.Index, l.TextId, this, l.Name0, l.Name1))
				.ToDictionary(l => l.Index);
			LanguageIds = new IdMap<ushort>(languages.ToDictionary(l => l.TextId, l => l.Index)
				, x => (ushort)(x + 1),
				(x, y) => x == y);
			TranslationIds = new IdMap<uint>(translationIds, x => (uint)(x + 1),
				(x, y) => x == y);
		}

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

		public JObject JsonSerialize()
		{
			var json = new JObject();

			var translationIds = new JObject();
			foreach (var item in TranslationIds.Ids)
			{
				translationIds.Add(item.Key, new JValue(item.Value));
			}
			json.Add("TranslationIds", translationIds);

			var jLangs = new JObject();
			foreach (var lang in Languages.Values.OrderBy(l => l.Index))
			{
				var jLang = new JObject();
				jLang.Add("Index", lang.Index);
				jLang.Add("Name0", lang.Name0);
				jLang.Add("Name1", lang.Name1);
				jLang.Add("TextId", lang.TextId);
				jLang.Add("Translations", new JObject(lang.Translations));
				jLangs.Add(lang.TextId, jLang);
			}
			json.Add("Languages", jLangs);
			return json;
		}

		public static LanguageFirstModel FromJson(JObject json)
			=> new LanguageFirstModel(json);

		private LanguageFirstModel(JObject json)
		{
			var transIds =
				json["TranslationIds"]
				.ToDictionary(j => ((JProperty)j).Name,j=> (uint)((JRaw)j).Value);
			var jLangs = json["Languages"];
			Languages = jLangs.Cast<JObject>()
				.Select(j => new Language(j.Value<ushort>("Index"), j.Value<string>("TextId"), this, j.Value<string>("Name0"), j.Value<string>("Name1")))
				.ToDictionary(l => l.Index);
			LanguageIds = new IdMap<ushort>(Languages.Values.ToDictionary(l => l.TextId, l => l.Index)
				, x => (ushort)(x + 1),
				(x, y) => x == y);
			TranslationIds = new IdMap<uint>(transIds, x => (uint)(x + 1),
				(x, y) => x == y);
		}
	}
}
