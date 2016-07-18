namespace PDMToCHM
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnBrow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnBuild = new System.Windows.Forms.Button();
            this.txtMulItem = new System.Windows.Forms.TextBox();
            this.txtChmName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnBrow
            // 
            this.BtnBrow.Location = new System.Drawing.Point(617, 21);
            this.BtnBrow.Name = "BtnBrow";
            this.BtnBrow.Size = new System.Drawing.Size(99, 36);
            this.BtnBrow.TabIndex = 0;
            this.BtnBrow.Text = "浏览(可多选)";
            this.BtnBrow.UseVisualStyleBackColor = true;
            this.BtnBrow.Click += new System.EventHandler(this.BtnBrow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pdm 文件路径：";
            // 
            // BtnBuild
            // 
            this.BtnBuild.Location = new System.Drawing.Point(617, 96);
            this.BtnBuild.Name = "BtnBuild";
            this.BtnBuild.Size = new System.Drawing.Size(99, 42);
            this.BtnBuild.TabIndex = 3;
            this.BtnBuild.Text = "生成";
            this.BtnBuild.UseVisualStyleBackColor = true;
            this.BtnBuild.Click += new System.EventHandler(this.BtnBuild_Click);
            // 
            // txtMulItem
            // 
            this.txtMulItem.Location = new System.Drawing.Point(107, 9);
            this.txtMulItem.Multiline = true;
            this.txtMulItem.Name = "txtMulItem";
            this.txtMulItem.Size = new System.Drawing.Size(486, 57);
            this.txtMulItem.TabIndex = 4;
            // 
            // txtChmName
            // 
            this.txtChmName.Location = new System.Drawing.Point(107, 111);
            this.txtChmName.Name = "txtChmName";
            this.txtChmName.Size = new System.Drawing.Size(486, 21);
            this.txtChmName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Chm文件名称：";
            // 
            // labMsg
            // 
            this.labMsg.AutoSize = true;
            this.labMsg.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labMsg.Location = new System.Drawing.Point(14, 165);
            this.labMsg.Name = "labMsg";
            this.labMsg.Size = new System.Drawing.Size(0, 10);
            this.labMsg.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 183);
            this.Controls.Add(this.labMsg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtChmName);
            this.Controls.Add(this.txtMulItem);
            this.Controls.Add(this.BtnBuild);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnBrow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pdm To CHM";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnBrow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnBuild;
        private System.Windows.Forms.TextBox txtMulItem;
        private System.Windows.Forms.TextBox txtChmName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labMsg;
    }
}

