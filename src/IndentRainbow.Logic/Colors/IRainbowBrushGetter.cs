using System.Windows.Media;

namespace IndentRainbow.Logic.Colors
{
	public interface IRainbowBrushGetter
	{

        /// <summary>
        /// 返回索引指定的颜色.
        /// 大于颜色列表的索引,应在开始时进行处理
        /// </summary>
        /// <param name="rainbowIndex">颜色的索引（从0开始）</param>
        /// <param name="numberOfColorsInRainbow">将用于该颜色的彩虹包含的颜色数</param>
        /// <returns>位于指定索引处的笔刷</return
        Brush GetColorByIndex(int rainbowIndex, int numberOfColorsInRainbow);

        /// <summary>
        /// 此方法是用于错误/错误压痕的颜色的getter
        /// </summary>
        /// <returns>返回用于缩进错误的颜色</Returns>
        Brush ErrorBrush { get; }
	}
}
