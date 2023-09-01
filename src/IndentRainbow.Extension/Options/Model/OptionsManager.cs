using System.Collections.Generic;
using System.Windows.Media;
using IndentRainbow.Logic.Parser;
using Microsoft.VisualStudio.Settings;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Settings;
using static IndentRainbow.Logic.Parser.ColorParser;

namespace IndentRainbow.Extension.Options
{
	internal static partial class OptionsManager
	{

        /// <summary>
        /// 用于检查数据是否已加载的标志.
        /// </summary>
        private static bool loadedFromStorage = false;

        /// <summary>
        /// 获取WritableSettingsStore类的实例,
        ///  其将被设置为已经创建了必要的集合.
        /// </summary>
        /// <returns>WritableSettingsStore实例  可写入设置存储实例 </returns>
        private static WritableSettingsStore GetWritableSettingsStore()
		{
			ThreadHelper.ThrowIfNotOnUIThread();
			SettingsManager settingsManager = new ShellSettingsManager(ServiceProvider.GlobalProvider);
			WritableSettingsStore settingsStore = settingsManager.GetWritableSettingsStore(SettingsScope.UserSettings);
			settingsStore.SetupIndentRainbowCollection();
			return settingsStore;
		}

        /// <summary>
        /// 已保存的缩进大小值.该值保存为静态字段以获得更好的性能
        /// </summary>
        public static OptionsField<int> indentSize = new OptionsField<int>(DefaultRainbowIndentOptions.defaultIndentSize);

        /// <summary>
        /// 颜色字符串的保存值.该值保存为静态字段以获得更好的性能
        /// </summary>
        public static OptionsField<string> hexCodes = new OptionsField<string>(DefaultRainbowIndentOptions.defaultColors);

        /// <summary>
        /// 笔刷阵列的保存值.该值保存为静态字段以获得更好的性能
        /// </summary>
        public static OptionsField<Color[]> colors = new OptionsField<Color[]>(
			ColorParser.ConvertStringToColorArray(DefaultRainbowIndentOptions.defaultColors, DefaultRainbowIndentOptions.defaultOpacityMultiplier));

        /// <summary>
        /// 应用于所有颜色的不透明度乘数
        /// </summary>
        public static OptionsField<double> opacityMultiplier = new OptionsField<double>(DefaultRainbowIndentOptions.defaultOpacityMultiplier);

        /// <summary>
        /// 应用于绘图的高亮显示模式
        /// </summary>
        public static OptionsField<HighlightingMode> highlightingMode = new OptionsField<HighlightingMode>(DefaultRainbowIndentOptions.defaultHighlightingMode);

        /// <summary>
        /// 应用于绘图的颜色模式
        /// </summary>
        public static OptionsField<ColorMode> colorMode = new OptionsField<ColorMode>(DefaultRainbowIndentOptions.defaultColorMode);
        /// <summary>
        /// 淡入淡出颜色标志确定是否淡入淡出
        /// </summary>
        public static OptionsField<bool> fadeColors = new OptionsField<bool>(DefaultRainbowIndentOptions.defaultFadeColors);

        /// <summary>
        /// 检测错误标志,用于确定是否会突出显示错误
        /// </summary>
        public static OptionsField<bool> detectErrors = new OptionsField<bool>(DefaultRainbowIndentOptions.defaultDetectErrorsFlag);

        /// <summary>
        /// 用于突出显示错误颜色的错误颜色
        ///</summary>
        public static OptionsField<string> errorColor = new OptionsField<string>(DefaultRainbowIndentOptions.defaultErrorColor);

        /// <summary>
        /// 包含文件扩展名缩进大小的字符串
        /// </summary>
        public static OptionsField<string> fileExtensionsString = new OptionsField<string>(DefaultRainbowIndentOptions.defaultFileExtensionsIndentSizes);

        /// <summary>
        /// 包含语言扩展及其缩进大小
        /// </summary>
        public static OptionsField<Dictionary<string, int>> fileExtensionsDictionary = new OptionsField<Dictionary<string, int>>(new Dictionary<string, int>());

        /// <summary>
        /// 错误画笔的保存值
        /// </summary>
        public static OptionsField<Brush> errorBrush = new OptionsField<Brush>(
			ColorParser.ConvertStringToBrush(DefaultRainbowIndentOptions.defaultErrorColor, DefaultRainbowIndentOptions.defaultOpacityMultiplier));

        /// <summary>
        /// 从设置存储加载设置
        /// </summary>
        public static void LoadSettings()
		{
			ThreadHelper.ThrowIfNotOnUIThread();
			if (!loadedFromStorage)
			{
				var settingsStore = GetWritableSettingsStore();
				indentSize.Set(settingsStore.LoadIndentSize());
				hexCodes.Set(settingsStore.LoadColors());
				opacityMultiplier.Set(settingsStore.LoadOpacityMultiplier());
				highlightingMode.Set(settingsStore.LoadHighlightingMode());
				colorMode.Set(settingsStore.LoadColorMode());
				fadeColors.Set(settingsStore.LoadFadeColors());
				errorColor.Set(settingsStore.LoadErrorColor());
				detectErrors.Set(settingsStore.LoadDetectErrorsFlag());
				fileExtensionsString.Set(settingsStore.LoadFileExtensionsIndentSizes());
				//This fields have to be initialized after the other fields since they depend on them
				loadedFromStorage = true;
				colors.Set(ConvertStringToColorArray(hexCodes.Get(), opacityMultiplier.Get()));
				errorBrush.Set(ConvertStringToBrush(errorColor.Get(), opacityMultiplier.Get()));
				fileExtensionsDictionary.Set(LanguageParser.CreateDictionaryFromString(fileExtensionsString.Get()));
			}
		}

        /// <summary>
        /// 将设置保存到设置存储
        /// </summary>
        /// <param name="newIndentSize">指定用于缩进检测的空格数的缩进大小</param>
        /// <param name="colors">字符串形式的颜色</param>
        public static void SaveSettings(int newIndentSize, string newFileExtensionsString, string newHexCodes, double newOpacityMultiplier, HighlightingMode newHighlightingMode, ColorMode newColorMode, bool newFadeColors, string newErrorColor, bool newDetectError)
		{
			ThreadHelper.ThrowIfNotOnUIThread();
			var settingsStore = GetWritableSettingsStore();
			settingsStore.SaveIndentSize(newIndentSize);
			settingsStore.SaveFileExtensionsIndentSizes(newFileExtensionsString);
			settingsStore.SaveColors(newHexCodes);
			settingsStore.SaveOpacityMultiplier(newOpacityMultiplier);
			settingsStore.SaveHighlightingMode(newHighlightingMode);
			settingsStore.SaveColorMode(newColorMode);
			settingsStore.SaveDetectErrorsFlag(newDetectError);
			settingsStore.SaveErrorColor(newErrorColor);
			settingsStore.SaveFadeColors(newFadeColors);

			indentSize.Set(newIndentSize);
			fileExtensionsString.Set(newFileExtensionsString);
			fileExtensionsDictionary.Set(LanguageParser.CreateDictionaryFromString(newFileExtensionsString));
			hexCodes.Set(newHexCodes);
			colors.Set(ConvertStringToColorArray(newHexCodes, newOpacityMultiplier));
			opacityMultiplier.Set(newOpacityMultiplier);
			fadeColors.Set(newFadeColors);
			highlightingMode.Set(newHighlightingMode);
			colorMode.Set(newColorMode);
			errorColor.Set(newErrorColor);
			detectErrors.Set(newDetectError);
			errorBrush.Set(ConvertStringToBrush(newErrorColor, newOpacityMultiplier));
		}
	}
}
