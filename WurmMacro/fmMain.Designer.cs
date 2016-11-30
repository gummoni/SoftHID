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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbTest = new System.Windows.Forms.GroupBox();
            this.btTest = new System.Windows.Forms.Button();
            this.tbTest = new System.Windows.Forms.TextBox();
            this.btScript = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tbMemo = new System.Windows.Forms.TextBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tbTrigger = new System.Windows.Forms.TextBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tbPassive = new System.Windows.Forms.TextBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.lbPassive = new System.Windows.Forms.ListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tbActive = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.lbActive = new System.Windows.Forms.ListBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tbTimer = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgCommand = new System.Windows.Forms.DataGridView();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pgSetting = new System.Windows.Forms.PropertyGrid();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btReadme = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gbTest.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCommand)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btReadme);
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
            this.btTest.Enabled = false;
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
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage8);
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
            this.tabPage6.Controls.Add(this.tbMemo);
            this.tabPage6.Controls.Add(this.tbLog);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(852, 342);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "ログ";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tbMemo
            // 
            this.tbMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMemo.Location = new System.Drawing.Point(0, 0);
            this.tbMemo.Multiline = true;
            this.tbMemo.Name = "tbMemo";
            this.tbMemo.Size = new System.Drawing.Size(852, 342);
            this.tbMemo.TabIndex = 2;
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
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.tbPassive);
            this.tabPage7.Controls.Add(this.splitter2);
            this.tabPage7.Controls.Add(this.lbPassive);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(852, 342);
            this.tabPage7.TabIndex = 9;
            this.tabPage7.Text = "常時実行";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tbPassive
            // 
            this.tbPassive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPassive.Location = new System.Drawing.Point(175, 3);
            this.tbPassive.Multiline = true;
            this.tbPassive.Name = "tbPassive";
            this.tbPassive.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbPassive.Size = new System.Drawing.Size(674, 336);
            this.tbPassive.TabIndex = 5;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(167, 3);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(8, 336);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // lbPassive
            // 
            this.lbPassive.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbPassive.FormattingEnabled = true;
            this.lbPassive.ItemHeight = 12;
            this.lbPassive.Location = new System.Drawing.Point(3, 3);
            this.lbPassive.Name = "lbPassive";
            this.lbPassive.Size = new System.Drawing.Size(164, 336);
            this.lbPassive.TabIndex = 3;
            this.lbPassive.SelectedIndexChanged += new System.EventHandler(this.lbPassive_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tbActive);
            this.tabPage4.Controls.Add(this.splitter1);
            this.tabPage4.Controls.Add(this.lbActive);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(852, 342);
            this.tabPage4.TabIndex = 8;
            this.tabPage4.Text = "スクリプト";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tbActive
            // 
            this.tbActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbActive.Location = new System.Drawing.Point(172, 0);
            this.tbActive.Multiline = true;
            this.tbActive.Name = "tbActive";
            this.tbActive.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbActive.Size = new System.Drawing.Size(680, 342);
            this.tbActive.TabIndex = 2;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(164, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 342);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // lbActive
            // 
            this.lbActive.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbActive.FormattingEnabled = true;
            this.lbActive.ItemHeight = 12;
            this.lbActive.Location = new System.Drawing.Point(0, 0);
            this.lbActive.Name = "lbActive";
            this.lbActive.Size = new System.Drawing.Size(164, 342);
            this.lbActive.TabIndex = 0;
            this.lbActive.SelectedIndexChanged += new System.EventHandler(this.lbScript_SelectedIndexChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.tbTimer);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(852, 342);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "タイマー";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tbTimer
            // 
            this.tbTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTimer.Location = new System.Drawing.Point(0, 0);
            this.tbTimer.Multiline = true;
            this.tbTimer.Name = "tbTimer";
            this.tbTimer.Size = new System.Drawing.Size(852, 342);
            this.tbTimer.TabIndex = 0;
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgCommand.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgCommand.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgCommand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCommand.Location = new System.Drawing.Point(3, 3);
            this.dgCommand.Name = "dgCommand";
            this.dgCommand.ReadOnly = true;
            this.dgCommand.RowTemplate.Height = 21;
            this.dgCommand.Size = new System.Drawing.Size(846, 336);
            this.dgCommand.TabIndex = 2;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(852, 342);
            this.tabPage8.TabIndex = 10;
            this.tabPage8.Text = "メモ";
            this.tabPage8.UseVisualStyleBackColor = true;
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
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btReadme
            // 
            this.btReadme.Location = new System.Drawing.Point(771, 12);
            this.btReadme.Name = "btReadme";
            this.btReadme.Size = new System.Drawing.Size(75, 60);
            this.btReadme.TabIndex = 8;
            this.btReadme.Text = "readme";
            this.btReadme.UseVisualStyleBackColor = true;
            this.btReadme.Click += new System.EventHandler(this.btReadme_Click);
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
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
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
        private System.Windows.Forms.TextBox tbActive;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ListBox lbActive;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbTimer;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TextBox tbPassive;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ListBox lbPassive;
        private System.Windows.Forms.TextBox tbMemo;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Button btReadme;
    }
}

