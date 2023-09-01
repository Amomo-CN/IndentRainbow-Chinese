using System;
using System.Globalization;
using Microsoft.VisualStudio.Settings;
using static IndentRainbow.Logic.Parser.ColorParser;

namespace IndentRainbow.Extension.Options
{
	public static class WritableSettingsStoreExtensions
	{

		public const string CollectionName = "IndentRainbow";
		public const string IndentSizePropertyName = "IndentSize";
		public const string FileExtensionSizesPropertyName = "FileExtensionSizes";
		public const string FolorsPropertyName = "Colors";
		public const string HighlightingModePropertyName = "HighlightingMode";
		public const string ColorModePropertyName = "ColorMode";
		public const string OpacityMultiplierPropertyName = "OpacityMultiplier";
		public const string DetectErrorsPropertyName = "DetectErrors";
		public const string errorColorPropertyName = "ErrorColor";
		public const string FadeColorsPropertyName = "FadeColors";


        /// <summary>
        /// 使用特定的集合和属性名称将给定的缩进大小保存到设置存储中
        /// </summary>
        /// <param name="store">可写设置存储</param>
        /// <param name="indentSize">要保存的缩进大小</param>
        public static void SaveIndentSize(this WritableSettingsStore store, int indentSize)
		{
			store?.SetInt32(CollectionName, IndentSizePropertyName, indentSize);
		}

        /// <summary>
        /// 将文件扩展名字符串保存到存储
        /// </summary>
        /// <param name="store">要使用的商店</param>
        /// <param name="fileExtensions">文件扩展名字符串</param>
        public static void SaveFileExtensionsIndentSizes(this WritableSettingsStore store, string fileExtensions)
		{
			store?.SetString(CollectionName, FileExtensionSizesPropertyName, fileExtensions);
		}

        /// <summary>
        /// 保存给定的字符串（表示颜色）
        /// </summary>
        /// <param name="store">可写设置存储</param>
        /// <param name="colors">要保存的颜色</param>
        public static void SaveColors(this WritableSettingsStore store, string colors)
		{
			store?.SetString(CollectionName, FolorsPropertyName, colors);
		}

        /// <summary>
        /// 保存不透明度倍增
        /// </summary>
        /// <param name="store">可写设置存储</param>
        /// <param name="opacityMultiplier">要保存的不透明度乘数</param>
        public static void SaveOpacityMultiplier(this WritableSettingsStore store, double opacityMultiplier)
		{
			store?.SetString(CollectionName, OpacityMultiplierPropertyName, opacityMultiplier.ToString(CultureInfo.CurrentCulture));
		}

        /// <summary>
        /// 保存高亮显示模式
        /// </summary>
        /// <param name="store">可写设置存储</param>
        /// <param name="highlightingMode">要保存的高亮显示模式</param>
        public static void SaveHighlightingMode(this WritableSettingsStore store, HighlightingMode highlightingMode)
		{
			store?.SetString(CollectionName, HighlightingModePropertyName, highlightingMode.ToString());
		}

        /// <summary>
        /// 保存颜色模式
        /// </summary>
        /// <param name="store">可写设置存储</param>
        /// <param name="colorMode">要保存的高亮显示模式</param>
        public static void SaveColorMode(this WritableSettingsStore store, ColorMode colorMode)
		{
			store?.SetString(CollectionName, ColorModePropertyName, colorMode.ToString());
		}

        /// <summary>
        /// 保存渐变色标志
        /// </summary>
        /// <param name="store">可写设置存储</param>
        /// <param name="fadeColors">要保存的渐变色标志</param>
        public static void SaveFadeColors(this WritableSettingsStore store, bool fadeColors)
		{
			store?.SetBoolean(CollectionName, FadeColorsPropertyName, fadeColors);
		}

        /// <summary>
        /// 保存检测错误标志
        /// </summary>
        /// <param name="store">可写设置存储</param>
        /// <param name="detectErrors">要保存的检测错误标志</param>
        public static void SaveDetectErrorsFlag(this WritableSettingsStore store, bool detectErrors)
		{
			store?.SetBoolean(CollectionName, DetectErrorsPropertyName, detectErrors);
		}

        /// <summary>
        /// 保存错误颜色
        /// </summary>
        /// <param name="store">可写设置存储</param>
        /// <param name="errorColor">要保存的错误颜色</param>
        public static void SaveErrorColor(this WritableSettingsStore store, string errorColor)
		{
			store?.SetString(CollectionName, errorColorPropertyName, errorColor);
		}

        /// <summary>
        /// 从设置存储加载缩进大小.
        /// </summary>
        /// <param name="store">可写设置存储</param>
        /// <returns>保存的缩进大小,如果找不到,则为默认缩进大小</returns>
        public static int LoadIndentSize(this WritableSettingsStore store)
		{
			if (store == null)
			{
				return DefaultRainbowIndentOptions.defaultIndentSize;
			}
			if (!store.PropertyExists(CollectionName, IndentSizePropertyName))
			{
				store.SaveIndentSize(DefaultRainbowIndentOptions.defaultIndentSize);
				return DefaultRainbowIndentOptions.defaultIndentSize;
			}
			else
			{
				return store.GetInt32(CollectionName, IndentSizePropertyName);
			}
		}

        /// <summary>
        /// 从存储加载文件扩展名字符串
        /// </summary>
        /// <param name="store">要使用的商店</param>
        /// <returns>存储的文件扩展名字符串,如果找不到,则为默认缩进大小</returns>
        public static string LoadFileExtensionsIndentSizes(this WritableSettingsStore store)
		{
			if (store == null)
			{
				return "";
			}
			if (!store.PropertyExists(CollectionName, FileExtensionSizesPropertyName))
			{
				store.SaveFileExtensionsIndentSizes(DefaultRainbowIndentOptions.defaultFileExtensionsIndentSizes);
				return DefaultRainbowIndentOptions.defaultFileExtensionsIndentSizes;
			}
			else
			{
				return store.GetString(CollectionName, FileExtensionSizesPropertyName);
			}
		}

        /// <summary>
        /// 从设置存储加载颜色字符串
        /// </summary>
        /// <param name="store">可写设置存储</param>
        /// <returns>´颜色字符串,如果找不到,则为默认颜色</returns>
        public static string LoadColors(this WritableSettingsStore store)
		{
			if (store == null)
			{
				return "";
			}
			if (!store.PropertyExists(CollectionName, FolorsPropertyName))
			{
				store.SaveColors(DefaultRainbowIndentOptions.defaultColors);
				return DefaultRainbowIndentOptions.defaultColors;
			}
			else
			{
				return store.GetString(CollectionName, FolorsPropertyName);
			}
		}

        /// <summary>
        /// 加载不透明度乘数
        /// </summary>
        /// <param name="store">可写设置存储</param>
        /// <returns>不透明度乘数,如果未找到,则为默认不透明度乘数</returns>
        public static double LoadOpacityMultiplier(this WritableSettingsStore store)
		{
			var opacMultiplier = DefaultRainbowIndentOptions.defaultOpacityMultiplier;
			if (store == null)
			{
				return opacMultiplier;
			}
			if (!store.PropertyExists(CollectionName, OpacityMultiplierPropertyName))
			{
				store.SaveOpacityMultiplier(opacMultiplier);
			}
			else
			{
                // 无论发生什么,opacMultiplier都会有一个有效的值,因为这是由输入表单确保的
#pragma warning disable CA1806 // 不要忽略方法结果
                double.TryParse(store.GetString(CollectionName, OpacityMultiplierPropertyName), out opacMultiplier);
#pragma warning restore CA1806 //不要忽略方法结果
            }
            return opacMultiplier;

		}

        /// <summary>
        /// 加载高亮显示模式
        /// </summary>
        /// <param name="store">可写设置存储</param>
        /// <returns>高亮显示模式,如果未找到,则为默认高亮显示模式</returns>
        public static HighlightingMode LoadHighlightingMode(this WritableSettingsStore store)
		{
			var highlightingMode = DefaultRainbowIndentOptions.defaultHighlightingMode;
			if (store == null)
			{
				return highlightingMode;
			}
			if (!store.PropertyExists(CollectionName, HighlightingModePropertyName))
			{
				store.SaveHighlightingMode(highlightingMode);
			}
			else
			{
				highlightingMode = (HighlightingMode)Enum.Parse(typeof(HighlightingMode),
					store.GetString(CollectionName, HighlightingModePropertyName));
			}
			return highlightingMode;
		}

        /// <summary>
        /// 加载颜色模式
        /// </summary>
        /// <param name="store">可写设置存储</param>
        /// <returns>颜色模式,如果找不到,则为默认颜色模式</returns>
        public static ColorMode LoadColorMode(this WritableSettingsStore store)
		{
			var colorMode = DefaultRainbowIndentOptions.defaultColorMode;
			if (store == null)
			{
				return colorMode;
			}

			if (!store.PropertyExists(CollectionName, ColorModePropertyName))
			{
				store.SaveColorMode(colorMode);
			}
			else
			{
				colorMode = (ColorMode)Enum.Parse(typeof(ColorMode),
					store.GetString(CollectionName, ColorModePropertyName));
			}
			return colorMode;
		}

        /// <summary>
        /// 加载渐变色标志
        /// </summary>
        /// <param name="store">可写设置存储</param>
        /// <returns>淡入淡出颜色标志,如果未找到,则为默认检测错误标志</returns>
        public static bool LoadFadeColors(this WritableSettingsStore store)
		{
			var fadeColorsFlag = DefaultRainbowIndentOptions.defaultFadeColors;
			if (store == null)
			{
				return fadeColorsFlag;
			}
			if (!store.PropertyExists(CollectionName, FadeColorsPropertyName))
			{
				store.SaveFadeColors(fadeColorsFlag);
			}
			else
			{
				fadeColorsFlag = store.GetBoolean(CollectionName, FadeColorsPropertyName);
			}
			return fadeColorsFlag;
		}
        /// <summary>
        /// 加载检测错误标志
        /// </summary>
        /// <param name="store">可写设置存储</param>
        /// <returns>检测错误标志,如果未找到,则为默认检测错误标志</returns>
        public static bool LoadDetectErrorsFlag(this WritableSettingsStore store)
		{
			var detectErrorFlag = DefaultRainbowIndentOptions.defaultDetectErrorsFlag;
			if (store == null)
			{
				return detectErrorFlag;
			}
			if (!store.PropertyExists(CollectionName, DetectErrorsPropertyName))
			{
				store.SaveDetectErrorsFlag(detectErrorFlag);
			}
			else
			{
				detectErrorFlag = store.GetBoolean(CollectionName, DetectErrorsPropertyName);
			}
			return detectErrorFlag;
		}

        /// <summary>
        /// 加载错误颜色
        /// </summary>
        /// <param name="store">可写设置存储</param>
        /// <returns>错误颜色,或者如果找不到,则为默认错误颜色</returns>
        public static string LoadErrorColor(this WritableSettingsStore store)
		{
			var errorColor = DefaultRainbowIndentOptions.defaultErrorColor;
			if (store == null)
			{
				return errorColor;
			}
			if (!store.PropertyExists(CollectionName, errorColorPropertyName))
			{
				store.SaveErrorColor(errorColor);
			}
			else
			{
				errorColor = store.GetString(CollectionName, errorColorPropertyName);
			}
			return errorColor;
		}

        /// <summary>
        /// 设置设置存储.
        /// 如果此扩展设置不存在,则为其创建默认集合
        /// </summary>
        /// <param name="store"></param>
        public static void SetupIndentRainbowCollection(this WritableSettingsStore store)
		{
			if (store == null)
			{
				return;
			}
			if (!store.CollectionExists(CollectionName))
			{
				store.CreateCollection(CollectionName);
			}
		}
	}
}
