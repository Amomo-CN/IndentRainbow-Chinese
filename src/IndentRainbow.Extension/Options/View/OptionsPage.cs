using System;
using System.ComponentModel;
using System.Windows.Forms;

using IndentRainbow.Extension.Options.View;

using Microsoft.VisualStudio.Shell;

using static IndentRainbow.Logic.Parser.ColorParser;

namespace IndentRainbow.Extension.Options
{
    /// <summary>
    /// ���������ʺ���չ��ѡ��ҳ.
    /// ���غͱ��浽�洢�ѱ�����,��
    /// û�м򵥵ķ�������ʹ�ñ��������
    /// Ĭ��ѡ��ҳ��û�����ڼ������õ������.
    /// </summary>
    // ��ҳ����Visual Studioʵ����,���ʹ������
#pragma warning disable CA1812 // ����δʵ�������ڲ���

    public class OptionsPage : DialogPage
#pragma warning restore CA1812 // ����δʵ�������ڲ���
    {
        protected override IWin32Window Window
        {
            get
            {
                var page = new OptionsForm(this);
                return page;
            }
        }

        [Category("����")]
        [DisplayName("����������С")]
        [Description("���������Ŀռ���")]
        public int IndentSize { get; set; }

        [Category("����")]
        [DisplayName("�ļ��ض���������С")]
        [Description("�����ļ���չ��ʹ�õĿռ���. " +
            "Ӧ�ڸ�ʽ��ָ���ļ���չ�� " +
            "'�ļ���չ��':'dent-size';'��һ���ļ���չ��':'ext-indent-size';" +
            "����:'cs:4;js:2'.������Ҫ���¼����ĵ�����������VS.")]
        public string FileSpecificIndentSizes { get; set; }

        [Category("��ɫ")]
        [DisplayName("��ɫ�б�")]
        [Description("���������������ɫ." + "��ɫ������ARGBʮ�������ṩ,���ұ����ö��ŷָ�.")]
        public string Colors { get; set; }

        [Category("��ɫ")]
        [DisplayName("һ�㲻͸����")]
        [Description("��Ӧ����������ɫ�Ĳ�͸����.�������ɫ�Ĳ�͸����Ϊ0.5,���Ҹ�ֵΪ0.5,����Ƹ���ɫʱ��͸����Ϊ0.25")]
        public double OpacityMultiplier { get; set; }

        [Category("����ģʽ")]
        [DisplayName("������ʾģʽ")]
        [Description("���Ż����������ʺ�����.\r\n" +
            "Monocolor= ���� / Alternating= ����")]
        public HighlightingMode HighlightingMode { get; set; }

        [Category("��ɫ����")]
        [DisplayName("��ɫģʽ")]
        [Description("������ÿ�������������ɫ���Խ��仹�Ǵ�ɫ.\r\n" +
            "Gradient=���� / Solid=��ɫ")]
        public ColorMode ColorMode { get; set; }

        [Category("��ɫ")]
        [DisplayName("���뵭��")]
        [Description("���ô�������ɫ�Ǵ�ɫ���ǽ�������ʧ")]
        public bool FadeColors { get; set; }

        [Category("ͻ����ʾ����")]
        [DisplayName("ͻ����ʾ���������")]
        [Description("ȷ���Ƿ��⵽��ͻ����ʾ����/���������,�����Ƿ�Ӧ������Ϊ��ȷ������")]
        public bool HighglightErrors { get; set; }

        [Category("ͻ����ʾ����")]
        [DisplayName("ѹ����ɫ����")]
        [Description("��ѹ����ȱ��/������ʱ,�����ڻ��Ƶ���ɫ")]
        public string ErrorColor { get; set; }

        /// <summary>
        /// �Ӵ洢�м��ش˱������ò�����ֵ.
        /// </summary>
        public override void LoadSettingsFromStorage()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            OptionsManager.LoadSettings();
            IndentSize = OptionsManager.indentSize.Get();
            Colors = OptionsManager.hexCodes.Get();
            FileSpecificIndentSizes = OptionsManager.fileExtensionsString.Get();
            OpacityMultiplier = OptionsManager.opacityMultiplier.Get();
            HighglightErrors = OptionsManager.detectErrors.Get();
            ErrorColor = OptionsManager.errorColor.Get();
            HighlightingMode = OptionsManager.highlightingMode.Get();
            ColorMode = OptionsManager.colorMode.Get();
            FadeColors = OptionsManager.fadeColors.Get();
        }

        /// <summary>
        /// �����ñ��浽�洢��
        /// </summary>
        public override void SaveSettingsToStorage()
        {
            if (FileSpecificIndentSizes is null)
            {
                FileSpecificIndentSizes = "";
            }
            if (Colors is null)
            {
                Colors = "";
            }
            if (ErrorColor is null)
            {
                ErrorColor = "";
            }
            ThreadHelper.ThrowIfNotOnUIThread();
            OptionsManager.SaveSettings(IndentSize,
                FileSpecificIndentSizes,
                Colors,
                OpacityMultiplier,
                HighlightingMode,
                ColorMode,
                FadeColors,
                ErrorColor,
                HighglightErrors);
        }
    }
}