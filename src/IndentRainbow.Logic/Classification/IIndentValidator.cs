namespace IndentRainbow.Logic.Classification
{
    public interface IIndentValidator
    {

        /// <summary>
        /// 检查给定字符串是否为有效缩进
        /// </summary>
        /// <param name="text">The indent to prove</param>
        /// <returns>如果字符串是有效的缩进,则返回true;如果不是,则返回false</returns>
        bool IsValidIndent(string text);

        /// <summary>
        /// 获取当前缩进块的长度,例如4个空格的缩进
        /// </summary>
        /// <returns>缩进块的长度</returns>
        int GetIndentBlockLength();

        /// <summary>
        /// 返回显示的子字符串中存在的缩进级别
        /// </summary>
        /// <param name="text">将解析的文本</param>
        /// <param name="start">压痕的起始位置</param>
        /// <param name="length">压痕块的长度</param>
        /// <returns></returns>
		int GetIndentLevelCount(string text, int length);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">要分析的文本</param>
        /// <returns>当给定字符串的缩进不完整/不正确时,返回true,否则为false</returns>
        bool IsIncompleteIndent(string text);
    }
}
