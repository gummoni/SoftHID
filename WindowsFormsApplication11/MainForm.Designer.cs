namespace WindowsFormsApplication11
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btStart = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.tbLogPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbPassiveEventScript = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tbEvent = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbPassiveCombatScript = new System.Windows.Forms.TextBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.tbCombat = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgStatus = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tcActive = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tbAction = new System.Windows.Forms.TextBox();
            this.cbAction = new System.Windows.Forms.ComboBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tbMacro = new System.Windows.Forms.TextBox();
            this.cbMacro = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStatus)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tcActive.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btStart);
            this.panel1.Controls.Add(this.btSave);
            this.panel1.Controls.Add(this.tbLogPath);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 44);
            this.panel1.TabIndex = 2;
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(436, 11);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 21);
            this.btStart.TabIndex = 4;
            this.btStart.Text = "実行";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(517, 11);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(71, 21);
            this.btSave.TabIndex = 3;
            this.btSave.Text = "保存";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // tbLogPath
            // 
            this.tbLogPath.Location = new System.Drawing.Point(78, 13);
            this.tbLogPath.Name = "tbLogPath";
            this.tbLogPath.Size = new System.Drawing.Size(352, 19);
            this.tbLogPath.TabIndex = 1;
            this.tbLogPath.Text = "D:\\game\\wurm\\players\\gummo\\logs";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ログフォルダ";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 44);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(687, 502);
            this.splitContainer1.SplitterDistance = 318;
            this.splitContainer1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 502);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "パッシブ";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 15);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(312, 484);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbPassiveEventScript);
            this.tabPage1.Controls.Add(this.splitter1);
            this.tabPage1.Controls.Add(this.tbEvent);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(304, 458);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Event";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbPassiveEventScript
            // 
            this.tbPassiveEventScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPassiveEventScript.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbPassiveEventScript.Location = new System.Drawing.Point(3, 123);
            this.tbPassiveEventScript.Multiline = true;
            this.tbPassiveEventScript.Name = "tbPassiveEventScript";
            this.tbPassiveEventScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbPassiveEventScript.Size = new System.Drawing.Size(298, 332);
            this.tbPassiveEventScript.TabIndex = 2;
            this.tbPassiveEventScript.Text = "; 構文説明\r\n; [検索文字],[有効時間s],[状態名]\r\n;\r\n; 検索文字... 正規表現で文字列検索を行う\r\n; 有効時間... 検索ヒットしてから状態" +
    "保持時間\r\n; 状態名　... 状態名\r\n";
            // 
            // splitter1
            // 
            this.splitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(3, 120);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(298, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // tbEvent
            // 
            this.tbEvent.BackColor = System.Drawing.Color.Silver;
            this.tbEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbEvent.Location = new System.Drawing.Point(3, 3);
            this.tbEvent.Multiline = true;
            this.tbEvent.Name = "tbEvent";
            this.tbEvent.ReadOnly = true;
            this.tbEvent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbEvent.Size = new System.Drawing.Size(298, 117);
            this.tbEvent.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbPassiveCombatScript);
            this.tabPage2.Controls.Add(this.splitter2);
            this.tabPage2.Controls.Add(this.tbCombat);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(304, 458);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Combat";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbPassiveCombatScript
            // 
            this.tbPassiveCombatScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPassiveCombatScript.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbPassiveCombatScript.Location = new System.Drawing.Point(3, 123);
            this.tbPassiveCombatScript.Multiline = true;
            this.tbPassiveCombatScript.Name = "tbPassiveCombatScript";
            this.tbPassiveCombatScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbPassiveCombatScript.Size = new System.Drawing.Size(298, 332);
            this.tbPassiveCombatScript.TabIndex = 3;
            this.tbPassiveCombatScript.Text = "; 構文説明\r\n; [検索文字],[有効時間s],[状態名]\r\n;\r\n; 検索文字... 正規表現で文字列検索を行う\r\n; 有効時間... 検索ヒットしてから状態" +
    "保持時間\r\n; 状態名　... 状態名\r\n";
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(3, 120);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(298, 3);
            this.splitter2.TabIndex = 2;
            this.splitter2.TabStop = false;
            // 
            // tbCombat
            // 
            this.tbCombat.BackColor = System.Drawing.Color.Silver;
            this.tbCombat.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbCombat.Location = new System.Drawing.Point(3, 3);
            this.tbCombat.Multiline = true;
            this.tbCombat.Name = "tbCombat";
            this.tbCombat.ReadOnly = true;
            this.tbCombat.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbCombat.Size = new System.Drawing.Size(298, 117);
            this.tbCombat.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgStatus);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(304, 458);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "状況把握";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgStatus
            // 
            this.dgStatus.AllowUserToAddRows = false;
            this.dgStatus.AllowUserToDeleteRows = false;
            this.dgStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgStatus.Location = new System.Drawing.Point(3, 3);
            this.dgStatus.Name = "dgStatus";
            this.dgStatus.ReadOnly = true;
            this.dgStatus.RowTemplate.Height = 21;
            this.dgStatus.Size = new System.Drawing.Size(298, 452);
            this.dgStatus.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tcActive);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 502);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "アクティブ";
            // 
            // tcActive
            // 
            this.tcActive.Controls.Add(this.tabPage4);
            this.tcActive.Controls.Add(this.tabPage5);
            this.tcActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcActive.Location = new System.Drawing.Point(3, 15);
            this.tcActive.Name = "tcActive";
            this.tcActive.SelectedIndex = 0;
            this.tcActive.Size = new System.Drawing.Size(359, 484);
            this.tcActive.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tbAction);
            this.tabPage4.Controls.Add(this.cbAction);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(351, 458);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "アクション";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tbAction
            // 
            this.tbAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAction.Location = new System.Drawing.Point(0, 20);
            this.tbAction.Multiline = true;
            this.tbAction.Name = "tbAction";
            this.tbAction.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbAction.Size = new System.Drawing.Size(351, 438);
            this.tbAction.TabIndex = 4;
            // 
            // cbAction
            // 
            this.cbAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbAction.FormattingEnabled = true;
            this.cbAction.Location = new System.Drawing.Point(0, 0);
            this.cbAction.Name = "cbAction";
            this.cbAction.Size = new System.Drawing.Size(351, 20);
            this.cbAction.TabIndex = 3;
            this.cbAction.SelectedIndexChanged += new System.EventHandler(this.cbAction_SelectedIndexChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.tbMacro);
            this.tabPage5.Controls.Add(this.cbMacro);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(351, 458);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "マクロ";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tbMacro
            // 
            this.tbMacro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMacro.Location = new System.Drawing.Point(3, 23);
            this.tbMacro.Multiline = true;
            this.tbMacro.Name = "tbMacro";
            this.tbMacro.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbMacro.Size = new System.Drawing.Size(345, 432);
            this.tbMacro.TabIndex = 2;
            // 
            // cbMacro
            // 
            this.cbMacro.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbMacro.FormattingEnabled = true;
            this.cbMacro.Location = new System.Drawing.Point(3, 3);
            this.cbMacro.Name = "cbMacro";
            this.cbMacro.Size = new System.Drawing.Size(345, 20);
            this.cbMacro.TabIndex = 1;
            this.cbMacro.SelectedIndexChanged += new System.EventHandler(this.cbMacroSelect_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 546);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Wurmサポツール";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgStatus)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tcActive.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbLogPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tbPassiveEventScript;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox tbEvent;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tbPassiveCombatScript;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.TextBox tbCombat;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tcActive;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox tbMacro;
        private System.Windows.Forms.ComboBox cbMacro;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox tbAction;
        private System.Windows.Forms.ComboBox cbAction;
    }
}

