﻿using NUnit.Framework;
using ProceduralLevel.Common.Parsing;
using ProceduralLevel.GameConsole.Logic;
using System.Collections.Generic;

namespace ProceduralLevel.GameConsole.Editor.Test
{
	public class QueryTokenizerTest
	{
		private QueryTokenizer m_Tokenizer = new QueryTokenizer();

		[Test]
		public void TokenizeBasic()
		{
			m_Tokenizer.Tokenize("test param1 123 arg=value");
			List<Token> tokens = m_Tokenizer.Flush();
			Assert.AreEqual(9, tokens.Count);
			TestHelper.CheckToken(tokens[0], false, "test");
			TestHelper.CheckToken(tokens[1], true, " ");
			TestHelper.CheckToken(tokens[2], false, "param1");
			TestHelper.CheckToken(tokens[3], true, " ");
			TestHelper.CheckToken(tokens[4], false, "123");
			TestHelper.CheckToken(tokens[5], true, " ");
			TestHelper.CheckToken(tokens[6], false, "arg");
			TestHelper.CheckToken(tokens[7], true, "=");
			TestHelper.CheckToken(tokens[8], false, "value");
		}

		[Test]
		public void EscapedValues()
		{
			//only separator tokens can be escaped
			m_Tokenizer.Tokenize("\\\" \\escaped");
			List<Token> tokens = m_Tokenizer.Flush();
			Assert.AreEqual(2, tokens.Count);
			TestHelper.CheckToken(tokens[0], true, "\\");
			TestHelper.CheckToken(tokens[1], false, "\" \\escaped");
		}
	}
}

