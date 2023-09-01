using IndentRainbow.Logic.Colors;
using IndentRainbow.Logic.Drawing;

namespace IndentRainbow.Logic.Classification
{
	public abstract class LineDecoratorBase : ILineDecorator
    {

        internal readonly IBackgroundTextIndexDrawer drawer;
        internal readonly IRainbowBrushGetter colorGetter;
        internal readonly IIndentValidator validator;
        // 为了使测试更容易,我们为此使用了一个setter.
#pragma warning disable CA1051 // 不声明可见的实例字段
        public bool detectErrors = true;
#pragma warning restore CA1051 // 不声明可见的实例字段

        public LineDecoratorBase(IBackgroundTextIndexDrawer drawer, IRainbowBrushGetter colorGetter, IIndentValidator validator)
        {
            this.drawer = drawer;
            this.colorGetter = colorGetter;
            this.validator = validator;
        }

        public abstract void DecorateLine(string text, int drawStartIndex);

        /// <summary>
        /// 计算压痕块的长度.
        /// 如果缩进有效,则返回正值,否则返回负数
        /// 例如,对于缩进长度4,文本“text”（4个空格）将返回4,
        /// 但是文本“text”（5个空格）对于缩进长度4返回-5.
        /// </summary>
        /// <remarks>
        /// 出于性能原因而不是返回包含布尔值和整数的元组,
        /// 该方法只返回一个整数.
        /// </remarks>
        /// <param name="text">包含要分析的行的文本</param>
        /// <param name="start">线路起点</param>
        /// <param name="end">行的末尾</param>
        /// <returns>如果缩进是有效的,则有效缩进块的长度,
        /// 否则,有效的缩进长度乘以-1</returns>
        protected int GetIndentLengthIfValid(string text)
        {
            var tabSize = validator.GetIndentBlockLength();
            var validTabLength = 0;
            var charIndex = 0;
            for (; charIndex < text.Length - tabSize + 1; charIndex += tabSize)
            {
                var cutOut = text.Substring(charIndex, tabSize);
                var tabCutOut = text.Substring(charIndex, 1);
                if (validator.IsValidIndent(cutOut))
                {
                    validTabLength += tabSize;
                }
                else if (validator.IsValidIndent(tabCutOut))
                {
                    charIndex -= (tabSize - 1);
                    validTabLength += 1;
                }
                else
                {
                    if (validator.IsIncompleteIndent(cutOut))
                    {
                        var index = 0;
                        while (index < cutOut.Length && (cutOut[index] == ' ' || cutOut[index] == '\t'))
                        {
                            index++;
                            validTabLength++;
                        }
                        validTabLength *= -1;
                    }
                    break;
                }
            }
            if (text.Length - charIndex < tabSize)
            {
                //检查文本的最后剩余部分是否为有效缩进
                var cutOut = text.Substring(charIndex, text.Length - charIndex);
                var index = 0;
                while (index < cutOut.Length && (cutOut[index] == ' ' || cutOut[index] == '\t'))
                {
                    index++;
                    validTabLength++;
                }
                if (validator.IsIncompleteIndent(cutOut))
                {
                    validTabLength *= -1;
                }
            }

            return validTabLength;
        }
    }
}
