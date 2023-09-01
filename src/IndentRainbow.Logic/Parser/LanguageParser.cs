using System;
using System.Collections.Generic;

namespace IndentRainbow.Logic.Parser
{
    public static class LanguageParser
    {
        /// <summary>
        ///返回通过分析字符串创建的词典
        /// </summary>
        /// <param name="input">包含文件扩展名和缩进大小的输入字符串</param>
        /// <returns>填好的词典</returns>
        public static Dictionary<string, int> CreateDictionaryFromString(string input)
        {
            var dictionary = new Dictionary<string, int>();
            if (input is null)
            {
                return dictionary;
            }
            var entries = input.Split(';');
            foreach (var s in entries)
            {
                try
                {
                    var splittedData = s.Split(':');
                    if (splittedData.Length < 2)
                    {
                        continue;
                    }
                    var fileExtensions = splittedData[0].Split(',');
                    var indentationSize = int.Parse(splittedData[1], System.Globalization.CultureInfo.InvariantCulture);
                    foreach (var fileExtension in fileExtensions)
                    {
                        try
                        {
                            dictionary.Add(fileExtension, indentationSize);
                        }
                        catch (ArgumentException) { }
                    }

                }
                catch (FormatException) { }
                catch (OverflowException) { }
            }
            return dictionary;
        }

        /// <summary>
        /// 将给定的字典转换为字符串
        /// </summary>
        /// <param name="dictionary">要转换的词典</param>
        /// <returns>字典的字符串“表示”</returns>
        public static string ConvertDictionaryToString(Dictionary<string, int> dictionary)
        {
            var result = "";
            foreach (var key in dictionary?.Keys)
            {
                result += key + ":" + dictionary[key] + ";";
            }
            return result;
        }
    }
}
