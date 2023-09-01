namespace IndentRainbow.Logic.Classification
{
	public class IndentValidator : IIndentValidator
	{

		private readonly string indentation = "    ";
		private const string tabString = "\t";
		public IndentValidator(int indentSize)
		{
			var accumulator = "";
			for (var i = 0; i < indentSize; i++)
			{
				accumulator += " ";
			}
			indentation = accumulator;
		}

		public int GetIndentBlockLength()
		{
			return indentation.Length;
		}

		public bool IsIncompleteIndent(string text)
		{
			var cleaned = text?.Replace("\t", "");
            // 字符串仅由制表符组成,是有效的,因此返回false;
            if (cleaned.Length == 0 || cleaned[0] != ' ')
			{
				return false;
			}
            // 字符串仅由制表符和空格组成,是有效的,因此返回false
            if (cleaned.Replace(" ", "").Length == 0)
			{
				return false;
			}
            // 检查其余部分是否为有效缩进
            return !IsValidIndent(text);
		}

		public int GetIndentLevelCount(string text, int length)
		{
			var tabCount = 0;
			var spaceCount = 0;
			if(text == null)
			{
				return 0;
			}
			for (int i = 0; i < length; i++)
			{
				if (text[i] == '\t')
				{
					tabCount++;
				}
				else if (text[i] == ' ')
				{
					spaceCount++;
				}
			}
			return tabCount + (spaceCount / GetIndentBlockLength());
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
		public bool IsValidIndent(string text)
		{
			if (text.Equals(indentation, System.StringComparison.InvariantCultureIgnoreCase)
				|| text.Equals(tabString, System.StringComparison.InvariantCultureIgnoreCase))
			{
				return true;
			}
			return false;
		}
	}
}
