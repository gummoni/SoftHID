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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbTest = new System.Windows.Forms.GroupBox();
            this.btTest = new System.Windows.Forms.Button();
            this.tbTest = new System.Windows.Forms.TextBox();
            this.btScript = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tbTrigger = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tbScript = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.lbScript = new System.Windows.Forms.ListBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dgTimer = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgCommand = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pgSetting = new System.Windows.Forms.PropertyGrid();
            this.btSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gbTest.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTimer)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCommand)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbTest);
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
            // gbTest
            // 
            this.gbTest.Controls.Add(this.btTest);
            this.gbTest.Controls.Add(this.tbTest);
            this.gbTest.Location = new System.Drawing.Point(393, 12);
            this.gbTest.Name = "gbTest";
            this.gbTest.Size = new System.Drawing.Size(378, 45);
            this.gbTest.TabIndex = 7;
            this.gbTest.TabStop = false;
            this.gbTest.Text = "テスト";
            // 
            // btTest
            // 
            this.btTest.Location = new System.Drawing.Point(297, 16);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(75, 23);
            this.btTest.TabIndex = 8;
            this.btTest.Text = "テスト";
            this.btTest.UseVisualStyleBackColor = true;
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
            // 
            // tbTest
            // 
            this.tbTest.Location = new System.Drawing.Point(6, 18);
            this.tbTest.Name = "tbTest";
            this.tbTest.Size = new System.Drawing.Size(285, 19);
            this.tbTest.TabIndex = 7;
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
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 78);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(860, 368);
            this.tabControl1.TabIndex = 1;
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tbTrigger);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(852, 342);
            this.tabPage3.TabIndex = 7;
            this.tabPage3.Text = "トリガー";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tbTrigger
            // 
            this.tbTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTrigger.Location = new System.Drawing.Point(3, 3);
            this.tbTrigger.Multiline = true;
            this.tbTrigger.Name = "tbTrigger";
            this.tbTrigger.Size = new System.Drawing.Size(846, 336);
            this.tbTrigger.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tbScript);
            this.tabPage4.Controls.Add(this.splitter1);
            this.tabPage4.Controls.Add(this.lbScript);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(852, 342);
            this.tabPage4.TabIndex = 8;
            this.tabPage4.Text = "マクロ";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tbScript
            // 
            this.tbScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbScript.Location = new System.Drawing.Point(172, 0);
            this.tbScript.Multiline = true;
            this.tbScript.Name = "tbScript";
            this.tbScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbScript.Size = new System.Drawing.Size(680, 342);
            this.tbScript.TabIndex = 2;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(164, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 342);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // lbScript
            // 
            this.lbScript.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbScript.FormattingEnabled = true;
            this.lbScript.ItemHeight = 12;
            this.lbScript.Location = new System.Drawing.Point(0, 0);
            this.lbScript.Name = "lbScript";
            this.lbScript.Size = new System.Drawing.Size(164, 342);
            this.lbScript.TabIndex = 0;
            this.lbScript.SelectedIndexChanged += new System.EventHandler(this.lbScript_SelectedIndexChanged);
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
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgTimer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgTimer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTimer.Location = new System.Drawing.Point(0, 0);
            this.dgTimer.Name = "dgTimer";
            this.dgTimer.ReadOnly = true;
            this.dgTimer.RowTemplate.Height = 21;
            this.dgTimer.Size = new System.Drawing.Size(852, 342);
            this.dgTimer.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgCommand);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(852, 342);
            this.tabPage2.TabIndex = 6;
            this.tabPage2.Text = "命令一覧";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgCommand
            // 
            this.dgCommand.AllowUserToAddRows = false;
            this.dgCommand.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgCommand.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgCommand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCommand.Location = new System.Drawing.Point(3, 3);
            this.dgCommand.Name = "dgCommand";
            this.dgCommand.ReadOnly = true;
            this.dgCommand.RowTemplate.Height = 21;
            this.dgCommand.Size = new System.Drawing.Size(846, 336);
            this.dgCommand.TabIndex = 2;
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
            this.pgSetting.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgSetting_PropertyValueChanged);
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
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 446);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "fmMain";
            this.Text = "Wurmマクロ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmMain_FormClosed);
            this.panel1.ResumeLayout(false);
            this.gbTest.ResumeLayout(false);
            this.gbTest.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTimer)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCommand)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PropertyGrid pgSetting;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dgTimer;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Button btScript;
        private System.Windows.Forms.GroupBox gbTest;
        private System.Windows.Forms.Button btTest;
        private System.Windows.Forms.TextBox tbTest;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgCommand;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox tbTrigger;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox tbScript;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ListBox lbScript;
        private System.Windows.Forms.Button btSave;
    }
}

