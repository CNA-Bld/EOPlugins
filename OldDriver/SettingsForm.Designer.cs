namespace OldDriver
{
    partial class SettingsForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageAutoRefresh = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.mapPointInput = new System.Windows.Forms.TextBox();
            this.mainSwitch = new System.Windows.Forms.CheckBox();
            this.labelList = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.tabControl.SuspendLayout();
            this.tabPageAutoRefresh.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageAutoRefresh);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(400, 300);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageAutoRefresh
            // 
            this.tabPageAutoRefresh.Controls.Add(this.tableLayoutPanel1);
            this.tabPageAutoRefresh.Location = new System.Drawing.Point(8, 39);
            this.tabPageAutoRefresh.Name = "tabPageAutoRefresh";
            this.tabPageAutoRefresh.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAutoRefresh.Size = new System.Drawing.Size(384, 253);
            this.tabPageAutoRefresh.TabIndex = 0;
            this.tabPageAutoRefresh.Text = "自动刷新";
            this.tabPageAutoRefresh.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.buttonRemove, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonAdd, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.mapPointInput, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.mainSwitch, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listBox, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(378, 247);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // buttonRemove
            // 
            this.buttonRemove.AutoSize = true;
            this.buttonRemove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRemove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRemove.Location = new System.Drawing.Point(274, 209);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(101, 35);
            this.buttonRemove.TabIndex = 16;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.remove_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.AutoSize = true;
            this.buttonAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAdd.Location = new System.Drawing.Point(208, 209);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(60, 35);
            this.buttonAdd.TabIndex = 15;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.add_Click);
            // 
            // mapPointInput
            // 
            this.mapPointInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapPointInput.Location = new System.Drawing.Point(3, 209);
            this.mapPointInput.Name = "mapPointInput";
            this.mapPointInput.Size = new System.Drawing.Size(199, 31);
            this.mapPointInput.TabIndex = 14;
            // 
            // mainSwitch
            // 
            this.mainSwitch.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.mainSwitch, 3);
            this.mainSwitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSwitch.Location = new System.Drawing.Point(3, 3);
            this.mainSwitch.Name = "mainSwitch";
            this.mainSwitch.Size = new System.Drawing.Size(372, 29);
            this.mainSwitch.TabIndex = 7;
            this.mainSwitch.Text = "启用自动刷新";
            this.mainSwitch.UseVisualStyleBackColor = true;
            // 
            // labelList
            // 
            this.labelList.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelList, 3);
            this.labelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelList.Location = new System.Drawing.Point(3, 35);
            this.labelList.Name = "labelList";
            this.labelList.Size = new System.Drawing.Size(372, 50);
            this.labelList.TabIndex = 12;
            this.labelList.Text = "自动刷新的地图点（格式形如 5-1-2 或 5-1-A）";
            // 
            // listBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.listBox, 3);
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 25;
            this.listBox.Location = new System.Drawing.Point(3, 88);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(372, 115);
            this.listBox.TabIndex = 10;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "SettingsForm";
            this.Size = new System.Drawing.Size(400, 300);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPageAutoRefresh.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageAutoRefresh;
        private System.Windows.Forms.Label labelList;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.CheckBox mainSwitch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox mapPointInput;
    }
}
