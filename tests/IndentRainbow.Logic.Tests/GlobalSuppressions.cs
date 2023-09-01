// 代码分析使用此文件来维护SuppressMessage
// 应用于此项目的属性.
// 项目级抑制没有目标或已给定
// 一个特定的目标,其作用域为名称空间、类型、成员等.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "This naming scheme is fine in testing project")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "传递给方法的所有参数都由MSTest处理")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "这在测试项目中很好,因为所有的东西都是英文的")]