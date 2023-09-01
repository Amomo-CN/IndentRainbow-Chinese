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
    /// ʹ�����б�Ҫ�����װ���ı�
    /// </summary>
    public sealed class Indent
    {
        /// <summary>
        /// װ�β�.
        /// </summary>
        private readonly IAdornmentLayer layer;

        /// <summary>
        /// ����װ�ε��ı���ͼ.
        /// </summary>
        private readonly IWpfTextView view;

        /// <summary>
        /// ���ڻ��Ʋʺ�Ч���ı�������
        /// </summary>
        private readonly IBackgroundTextIndexDrawer drawer;

        /// <summary>
        /// ���ڻ�ȡѹ�ۼ������ȷ��ɫ��Color getter
        /// </summary>
        private readonly IRainbowBrushGetter colorGetter;

        /// <summary>
        /// ���ڼ������ַ����Ƿ�Ϊ��Ч��������֤��
        ///</summary>
        private readonly IIndentValidator validator;

        /// <summary>
        /// ����װ��������װ����
        /// </summary>
        private readonly ILineDecorator decorator;

        /// <summary>
        /// ��ʼ��<see-cref=��Indent��/>�����ʵ��.
        /// </summary>
        /// <param name="view">���ڴ���װ�ε��ı���ͼ</param>
        //  ���Ծ���,��Ϊ��װ��ʼ����UI�߳���
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
        /// ͨ�����κ����¸�ʽ���������װ����������ͼ����ʾ���ı���ʱ����
        /// </summary>
        /// <remarks><para>ÿ�����ֵ��ı���ʾ�� <see cref="ITextView"/> changes.</para>
        /// <para>ÿ����ͼ���в���ʱ������DisplayTextLineContainingBufferPosition����Ӧ�ı���������ʱ�ᷢ�����������,�ͻ�������.</para>
        /// <para>ÿ����ͼˮƽ�������С�����仯ʱ,��Ҳ������.</para>
        /// </remarks>
        /// <param name="sender">�¼�������.</param>
        /// <param name="e">�¼��Ա���.</param>
        internal void OnLayoutChanged(object sender, TextViewLayoutChangedEventArgs e)
        {
            foreach (ITextViewLine line in e.NewOrReformattedLines)
            {
                CreateVisuals(line);
            }
        }

        /// <summary>
        /// ���������Ϣ�Խ��䴫�ݸ���װ����
        /// </summary>
        /// <param name="line">���װ�ε���</param>
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
