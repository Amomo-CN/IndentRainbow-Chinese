using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;

namespace IndentRainbow.Logic.Parser
{
	public static class ColorParser
	{
		public enum ColorMode
		{
			[Description("Solid")]
			Solid = 0,
			[Description("Gradient")]
			Gradient = 1,
		}

        /// <summary>
        /// 将给定字符串转换为笔刷数组.
        /// 颜色必须使用“,”分隔,并且颜色必须为ARGB十六进制格式
        /// </summary>
        /// <param name="colors"></param>
        /// <returns></returns>
        public static Color[] ConvertStringToColorArray(string colors, double opacityMultiplier)
		{
			if (string.IsNullOrEmpty(colors))
			{
				return Array.Empty<Color>();
			}
			var splitColors = colors.Split(',');
			var colorCount = splitColors.Length;

			List<Color> colorList = new List<Color>();
			
			for (var i = 0; i < colorCount; i++)
			{
				try
				{
					var color = (Color)ColorConverter.ConvertFromString(splitColors[i]);
					color.A = (byte)Math.Floor(color.A * opacityMultiplier);
					colorList.Add(color);
				}
				catch (FormatException) { }
			}
			return colorList.ToArray();
		}

		public static Brush ConvertStringToBrush(string color, double opacityMultiplier)
		{
			if (string.IsNullOrEmpty(color))
			{
				return null;
			}
			try
			{
				var brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
				double alphaOfBrush = (brush.Color.A);
				var brushColor = brush.Color;
				brushColor.A = (byte)Math.Floor(alphaOfBrush * opacityMultiplier);
				brush.Color = brushColor;
				return brush;
			}
			catch (NullReferenceException)
			{
				return null;
			}
		}
	}
}
