namespace IndentRainbow.Extension.Options.View
{
	partial class OptionsForm
	{
        /// <summary> 
        /// 必需的设计器变量.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理正在使用的任何资源.
        ///</summary>
        /// <param name="disposing">清理正在使用的任何资源.
        ///</summary>.</param>
        protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        #region Component Designer generated code

        /// <summary> 
        /// 设计器支持所需的方法-不要修改
        /// 使用代码编辑器显示此方法的内容.
        /// </summary>
        private void InitializeComponent()
		{
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.optionsPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.restartDisclaimer = new System.Windows.Forms.Label();
            this.mainLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // main布局
            // 
            this.mainLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainLayout.AutoSize = true;
            this.mainLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.linkLabel1, 0, 2);
            this.mainLayout.Controls.Add(this.optionsPropertyGrid, 0, 0);
            this.mainLayout.Controls.Add(this.restartDisclaimer, 0, 1);
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 3;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.Size = new System.Drawing.Size(1082, 534);
            this.mainLayout.TabIndex = 0;
            // 
            // 链接标签1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(25, 108);
            this.linkLabel1.Location = new System.Drawing.Point(0, 514);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(1082, 20);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "对于bug和功能请求,GitHub上打开一个问题:https://github.com/chingucoding/IndentRainbow";
            this.linkLabel1.UseCompatibleTextRendering = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // 选项属性网格
            // 
            this.optionsPropertyGrid.CategorySplitterColor = System.Drawing.SystemColors.ButtonShadow;
            this.optionsPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsPropertyGrid.Location = new System.Drawing.Point(3, 3);
            this.optionsPropertyGrid.Name = "optionsPropertyGrid";
            this.optionsPropertyGrid.Size = new System.Drawing.Size(1076, 482);
            this.optionsPropertyGrid.TabIndex = 1;
            this.optionsPropertyGrid.Click += new System.EventHandler(this.optionsPropertyGrid_Click);
            // 
            // restartDisclaimer
            // 
            this.restartDisclaimer.AutoSize = true;
            this.restartDisclaimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.restartDisclaimer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartDisclaimer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.restartDisclaimer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.restartDisclaimer.Location = new System.Drawing.Point(0, 494);
            this.restartDisclaimer.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.restartDisclaimer.Name = "restartDisclaimer";
            this.restartDisclaimer.Size = new System.Drawing.Size(1082, 14);
            this.restartDisclaimer.TabIndex = 2;
            this.restartDisclaimer.Text = "请注意,只有在重新打开文档或重新启动Visual Studio后,更改才会生效.";
            this.restartDisclaimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.restartDisclaimer.Click += new System.EventHandler(this.restartDisclaimer_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainLayout);
            this.Name = "OptionsForm";
            this.Size = new System.Drawing.Size(1082, 534);
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainLayout;
		private System.Windows.Forms.PropertyGrid optionsPropertyGrid;
		private System.Windows.Forms.Label restartDisclaimer;
		private System.Windows.Forms.LinkLabel linkLabel1;
	}
}
