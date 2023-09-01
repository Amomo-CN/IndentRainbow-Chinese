using System.Windows.Media;

namespace IndentRainbow.Logic.Drawing
{
    public interface IBackgroundTextIndexDrawer
    {

        /// <summary>
        /// 从给定的索引开始绘制一个背景框,其长度以给定的颜色指定.
        /// 索引和长度被指定为字符索引或要覆盖的字符数.
        /// </summary>
        /// <param name="firstIndex">要在其中启动框的字符的索引（包括）</param>
        /// <param name="length">要绘制的背景框的长度,
        ///  以字符指定</param>
        /// <param name="drawBrush">用于绘图的画笔</param>
        void DrawBackground(int firstIndex, int length, Brush drawBrush);
    }
}
