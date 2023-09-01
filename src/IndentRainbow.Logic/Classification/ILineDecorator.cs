namespace IndentRainbow.Logic.Classification
{
    public interface ILineDecorator
    {
        /// <summary>
        /// 处理给定的字符串并在正确的位置绘制相关的突出显示,
        /// 如果<see cref=“IIndentValidator”/>验证位置
        /// </summary>
        /// <param name="text">文本的字符串</param>
        /// <param name="drawingStartIndex">行相对于总文档的起始位置（用于呈现）</param>
        void DecorateLine(string text, int drawStartIndex);
    }
}