using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;

namespace IndentRainbow.Extension
{
    /// <summary>
    /// 建立<see cref=“IAdormentLayer”/>以放置装饰,并导出<see cref=“IWpfTextViewCreationListener”/>
    /// 在<see-cref=“IWpfTextView”/>的创建事件上实例化装饰
    /// </summary>
    [Export(typeof(IWpfTextViewCreationListener))]
    [ContentType("text")]
    [TextViewRole(PredefinedTextViewRoles.Document)]
    internal sealed class IndentTextViewCreationListener : IWpfTextViewCreationListener
    {
        // 禁用“从不将字段分配给…”和“从不使用字段”编译器的警告.对正:该字段由MEF使用.
#pragma warning disable 649, 169

        /// <summary>
        /// 定义装饰的装饰层.此层已排序
        /// 在Z顺序的选择层之后
        /// </summary>
        [Export(typeof(AdornmentLayerDefinition))]
        [Name("Indent")]
        [Order(After = PredefinedAdornmentLayers.Selection, Before = PredefinedAdornmentLayers.Text)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Code Quality", "IDE0051:Remove unused private members", Justification = "Used by Visual Studio")]
        private readonly AdornmentLayerDefinition editorAdornmentLayer;

#pragma warning restore 649, 169

        #region IWpfTextViewCreationListener

        /// <summary>
        /// 当在具有匹配内容类型的文本数据模型上创建具有匹配角色的文本视图时调用.
        /// 在创建textView时实例化缩进管理器.
        /// </summary>
        /// <param name="textView">The <see cref="IWpfTextView"/> 装饰应该放在上面</param>
        public void TextViewCreated(IWpfTextView textView)
        {
            // 装饰将监听任何更改布局的事件（文本更改、滚动等）
            //当我们创建装饰时,我们不再需要引用,因为所有必要的事情都是在创建对象时完成的
#pragma warning disable CA1806 // 不要忽略方法结果
            new Indent(textView);
#pragma warning restore CA1806 // 不要忽略方法结果
        }

        #endregion
    }
}
