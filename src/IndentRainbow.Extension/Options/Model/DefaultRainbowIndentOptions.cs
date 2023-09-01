using System.ComponentModel;
using static IndentRainbow.Logic.Parser.ColorParser;

namespace IndentRainbow.Extension.Options
{
    public enum HighlightingMode
    {
        [Description("渐变颜色")]
        Alternating = 0,
        [Description("纯色")]
        Monocolor = 1
    }

    internal static class DefaultRainbowIndentOptions
    {
        public const int defaultIndentSize = 4;
        public const string defaultFileExtensionsIndentSizes = "";
        public const string defaultColors = "#FF00FEEC,#FF016EFE,#FFB103F8,#FFE10073,#FFFD8C01,#FFFFFC00,#FF09F901";
        public const double defaultOpacityMultiplier = 1.0;
        public const HighlightingMode defaultHighlightingMode = HighlightingMode.Alternating;
        public const ColorMode defaultColorMode = ColorMode.Solid;
        public const bool defaultFadeColors = false;

        // Constants for errors
        public const string defaultErrorColor = "#40a80000";
        public const bool defaultDetectErrorsFlag = true;
    }
}
