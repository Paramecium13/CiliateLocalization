﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CiliateLocalization
{
	public interface ILanguageInfo
	{
		ushort Index { get; }
		string TextId { get; }
		string Name0 { get; }
		string Name1 { get; }
	}
}
