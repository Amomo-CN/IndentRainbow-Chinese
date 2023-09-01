# IndentRainbow
<p align="center">
    <img src="./docs/IndentRainbow.png">
</p>


此项目为  IndentRainbow 汉化版
                                    -------我是真的不懂英文 
原地址  https://github.com/chingucoding/IndentRainbow

### 用于缩进级别着色的Visual Studio扩展.
您可以在 [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=chingucoding.IndentRainbow).
扩展的屏幕截图可以在<a></a>[this folder]（./docs）或上面链接的扩展页面上找到.

### Summary
此扩展的目的是使在源代码中更容易区分不同级别的缩进.
这是通过对源代码中的缩进进行着色来完成的.

### Project structure
本项目结构如下:
* src
    * 缩进彩虹扩展<-VSIX扩展
    * 缩进彩虹逻辑<-扩展的核心逻辑
* tests
    * IndentRainbow.Logic.Tests<-核心逻辑的单元测试.

若要构建该项目,您需要安装Visual Studio 2017和“Visual Studio扩展开发”功能.请注意,VS 2017需要能够为2019之前的Visual Studio版本编译扩展.

### Inspiration
此项目的灵感来自VS代码的此项目/扩展:

[https://github.com/oderwat/vscode-indent-rainbow](https://github.com/oderwat/vscode-indent-rainbow)