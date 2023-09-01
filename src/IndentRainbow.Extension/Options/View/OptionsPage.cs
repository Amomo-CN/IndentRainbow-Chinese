using System;
using System.ComponentModel;
using System.Windows.Forms;

using IndentRainbow.Extension.Options.View;

using Microsoft.VisualStudio.Shell;

using static IndentRainbow.Logic.Parser.ColorParser;

namespace IndentRainbow.Extension.Options
{
    /// <summary>
    /// 这是缩进彩虹扩展的选项页.
    /// 加载和保存到存储已被覆盖,自
    /// 没有简单的方法加载使用保存的设置
    /// 默认选项页面没有用于加载设置的软件包.
    /// </summary>
    // 此页面由Visual Studio实例化,因此使用它！
#pragma warning disable CA1812 // 避免未实例化的内部类

    public class OptionsPage : DialogPage
#pragma warning restore CA1812 // 避免未实例化的内部类
    {
        protected override IWin32Window Window
        {
            get
            {
                var page = new OptionsForm(this);
                return page;
            }
        }

        [Category("缩进")]
        [DisplayName("调整缩进大小")]
        [Description("用于缩进的空间量")]
        public int IndentSize { get; set; }

        [Category("缩进")]
        [DisplayName("文件特定的缩进大小")]
        [Description("基于文件扩展名使用的空间量. " +
            "应在格式中指定文件扩展名 " +
            "'文件扩展名':'dent-size';'下一个文件扩展名':'ext-indent-size';" +
            "例如:'cs:4;js:2'.更改需要重新加载文档或重新启动VS.")]
        public string FileSpecificIndentSizes { get; set; }

        [Category("颜色")]
        [DisplayName("颜色列表")]
        [Description("用于缩进级别的颜色." + "颜色必须以ARGB十六进制提供,并且必须用逗号分隔.")]
        public string Colors { get; set; }

        [Category("颜色")]
        [DisplayName("一般不透明度")]
        [Description("将应用于所有颜色的不透明度.如果该颜色的不透明度为0.5,并且该值为0.5,则绘制该颜色时不透明度为0.25")]
        public double OpacityMultiplier { get; set; }

        [Category("高亮模式")]
        [DisplayName("高亮显示模式")]
        [Description("横着还是竖着填充彩虹缩进.\r\n" +
            "Monocolor= 横着 / Alternating= 竖着")]
        public HighlightingMode HighlightingMode { get; set; }

        [Category("颜色过度")]
        [DisplayName("颜色模式")]
        [Description("更改在每个缩进步骤后颜色是以渐变还是纯色.\r\n" +
            "Gradient=渐变 / Solid=纯色")]
        public ColorMode ColorMode { get; set; }

        [Category("颜色")]
        [DisplayName("淡入淡出")]
        [Description("设置代码中颜色是纯色还是渐渐的消失")]
        public bool FadeColors { get; set; }

        [Category("突出显示错误")]
        [DisplayName("突出显示错误的缩进")]
        [Description("确定是否检测到并突出显示错误/错误的缩进,或者是否应将其视为正确的缩进")]
        public bool HighglightErrors { get; set; }

        [Category("突出显示错误")]
        [DisplayName("压痕颜色错误")]
        [Description("当压痕有缺陷/不完整时,将用于绘制的颜色")]
        public string ErrorColor { get; set; }

        /// <summary>
        /// 从存储中加载此表单的设置并设置值.
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
        /// 将设置保存到存储器
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