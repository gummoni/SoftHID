namespace WurmMacro
{
    partial class fmMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btSave = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pgSetting = new System.Windows.Forms.PropertyGrid();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dgTimer = new System.Windows.Forms.DataGridView();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.btScript = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTimer)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btScript);
            this.panel1.Controls.Add(this.btSave);
            this.panel1.Controls.Add(this.btStop);
            this.panel1.Controls.Add(this.btStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 78);
            this.panel1.TabIndex = 0;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(189, 12);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 60);
            this.btSave.TabIndex = 2;
            this.btSave.Text = "設定保存";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btStop
            // 
            this.btStop.BackColor = System.Drawing.Color.Lime;
            this.btStop.Location = new System.Drawing.Point(93, 12);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(75, 60);
            this.btStop.TabIndex = 1;
            this.btStop.Text = "停止";
            this.btStop.UseVisualStyleBackColor = false;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(12, 12);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 60);
            this.btStart.TabIndex = 0;
            this.btStart.Text = "実行";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 78);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(860, 368);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pgSetting);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(852, 342);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "設定";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pgSetting
            // 
            this.pgSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgSetting.Location = new System.Drawing.Point(3, 3);
            this.pgSetting.Name = "pgSetting";
            this.pgSetting.Size = new System.Drawing.Size(846, 336);
            this.pgSetting.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dgTimer);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(852, 342);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "タイマー";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dgTimer
            // 
            this.dgTimer.AllowUserToAddRows = false;
            this.dgTimer.AllowUserToDeleteRows = false;
            this.dgTimer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTimer.Location = new System.Drawing.Point(0, 0);
            this.dgTimer.Name = "dgTimer";
            this.dgTimer.ReadOnly = true;
            this.dgTimer.RowTemplate.Height = 21;
            this.dgTimer.Size = new System.Drawing.Size(852, 342);
            this.dgTimer.TabIndex = 1;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.tbLog);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(852, 342);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "ログ";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tbLog
            // 
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Location = new System.Drawing.Point(0, 0);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(852, 342);
            this.tbLog.TabIndex = 1;
            // 
            // btScript
            // 
            this.btScript.Location = new System.Drawing.Point(270, 12);
            this.btScript.Name = "btScript";
            this.btScript.Size = new System.Drawing.Size(117, 60);
            this.btScript.TabIndex = 4;
            this.btScript.Text = "スクリプトフォルダ";
            this.btScript.UseVisualStyleBackColor = true;
            this.btScript.Click += new System.EventHandler(this.btScript_Click);
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 446);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "fmMain";
            this.Text = "Wurmマクロ";
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTimer)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.PropertyGrid pgSetting;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dgTimer;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Button btScript;
    }
}

