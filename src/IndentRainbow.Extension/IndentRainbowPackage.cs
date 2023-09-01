using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using IndentRainbow.Extension.Options;
using Microsoft.VisualStudio.Shell;

namespace IndentRainbow.Extension
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    ///是实现IVsPackage接口并将其自身注册到shell中.
    ///此程序包使用在托管程序包框架（MPF）中定义的帮助程序类
    ///要做到这一点:它派生自Package类,该类提供
    ///IVsPackage接口,并使用框架中定义的注册属性
    ///向shell注册自身及其组件.这些属性告诉pkgdef的创建
    ///实用程序将哪些数据放入.pkgdef文件.
    /// </para>
    /// <para>
    /// 为了加载到VS中,包必须由&lt;Asset Type=“Microsoft.VisualStudio.VsPack”…&gt;在.vsixmanifest文件中.
    /// </para>
    /// </remarks>
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // 有关此程序包的信息以获取帮助/关于
    [Guid(PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    [ProvideOptionPage(typeof(OptionsPage), "彩虹缩进", "常规设置", 101, 107, true)]
    public sealed class IndentRainbowPackage : AsyncPackage
    {
        /// <summary>
        ///IndentRainbowPackage GUID字符串.
        /// </summary>
        public const string PackageGuidString = "353923c7-98ec-4646-bf78-c0680b7cf00c";
    }
}
