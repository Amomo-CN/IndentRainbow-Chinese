using IndentRainbow.Extension.Drawing;
using IndentRainbow.Extension.Options;
using IndentRainbow.Logic.Classification;
using IndentRainbow.Logic.Colors;
using IndentRainbow.Logic.Drawing;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Formatting;
using Microsoft.VisualStudio.TextManager.Interop;
using static IndentRainbow.Logic.Parser.ColorParser;

namespace IndentRainbow.Extension
{
    /// <summary>
    /// 使用所有必要的组件装饰文本
    /// </summary>
    public sealed class Indent
    {
        /// <summary>
        /// 装饰层.
        /// </summary>
        private readonly IAdornmentLayer layer;

        /// <summary>
        /// 创建装饰的文本视图.
        /// </summary>
        private readonly IWpfTextView view;

        /// <summary>
        /// 用于绘制彩虹效果的背景抽屉
        /// </summary>
        private readonly IBackgroundTextIndexDrawer drawer;

        /// <summary>
        /// 用于获取压痕级别的正确颜色的Color getter
        /// </summary>
        private readonly IRainbowBrushGetter colorGetter;

        /// <summary>
        /// 用于检查给定字符串是否为有效缩进的验证器
        ///</summary>
        private readonly IIndentValidator validator;

        /// <summary>
        /// 用于装饰线条的装饰器
        /// </summary>
        private readonly ILineDecorator decorator;

        /// <summary>
        /// 初始化<see-cref=“Indent”/>类的新实例.
        /// </summary>
        /// <param name="view">用于创建装饰的文本视图</param>
        //  忽略警告,因为此装饰始终在UI线程上
#pragma warning disable VSTHRD010
        public Indent(IWpfTextView view)
        {
            if (view == null)
            {
                return;
            }
            layer = view.GetAdornmentLayer("Indent");

            this.view = view;
            this.view.LayoutChanged += OnLayoutChanged;
            drawer = new BackgroundTextIndexDrawer(layer, this.view);

            colorGetter = new RainbowBrushGetter(OptionsManager.colors.Get(), OptionsManager.errorBrush.Get(), OptionsManager.colorMode.Get(), OptionsManager.fadeColors.Get());
            validator = new IndentValidator(
                OptionsManager.indentSize.Get()
            );


            string filePath = GetPath(view);
            if(filePath != null)
            {
                var filePathSplit = filePath.Split('.');
                var extension = filePathSplit[filePathSplit.Length - 1];
                if (OptionsManager.fileExtensionsDictionary.Get().ContainsKey(extension))
                {
                    validator = new IndentValidator(OptionsManager.fileExtensionsDictionary.Get()[extension]);
                }
            }
            var highlightingMode = OptionsManager.highlightingMode.Get();

            if (OptionsManager.highlightingMode.Get() == HighlightingMode.Monocolor)
            {
                decorator = new MonocolorLineDecorator(
                    drawer, colorGetter, validator)
                {
                    detectErrors = OptionsManager.detectErrors.Get()
                };
            }
            else
            {
                decorator = new AlternatingLineDecorator(
                    drawer, colorGetter, validator)
                {
                    detectErrors = OptionsManager.detectErrors.Get()
                };
            }
        }

        /// <summary>
        /// 通过向任何重新格式化的行添加装饰来处理视图中显示的文本何时更改
        /// </summary>
        /// <remarks><para>每当呈现的文本显示在 <see cref="ITextView"/> changes.</para>
        /// <para>每当视图进行布局时（调用DisplayTextLineContainingBufferPosition或响应文本或分类更改时会发生这种情况）,就会引发它.</para>
        /// <para>每当视图水平滚动或大小发生变化时,它也会升高.</para>
        /// </remarks>
        /// <param name="sender">事件发件人.</param>
        /// <param name="e">事件自变量.</param>
        internal void OnLayoutChanged(object sender, TextViewLayoutChangedEventArgs e)
        {
            foreach (ITextViewLine line in e.NewOrReformattedLines)
            {
                CreateVisuals(line);
            }
        }

        /// <summary>
        /// 检索相关信息以将其传递给行装饰器
        /// </summary>
        /// <param name="line">添加装饰的行</param>
        private void CreateVisuals(ITextViewLine line)
        {
            int start = line.Start;
            int length = line.End - start;

            string text = line.Snapshot.GetText(start, length);
            decorator.DecorateLine(text, start);
        }

        private static string GetPath(IWpfTextView textView)
        {
            textView.TextBuffer.Properties.TryGetProperty(typeof(IVsTextBuffer), out IVsTextBuffer bufferAdapter);

            if (!(bufferAdapter is IPersistFileFormat persistFileFormat))
            {
                return null;
            }
            persistFileFormat.GetCurFile(out string filePath, out _);
            return filePath;
        }
    }
}
