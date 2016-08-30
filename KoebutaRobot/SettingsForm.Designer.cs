namespace KoebutaRobot
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxEnabled = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTargetID = new System.Windows.Forms.TextBox();
            this.textBoxTarget = new System.Windows.Forms.TextBox();
            this.textBoxSelectedPoints = new System.Windows.Forms.TextBox();
            this.checkBoxOnlySelectedPoints = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.checkBoxEnabled, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxServer, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTargetID, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTarget, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxSelectedPoints, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxOnlySelectedPoints, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 200);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // checkBoxEnabled
            // 
            this.checkBoxEnabled.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxEnabled, 2);
            this.checkBoxEnabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxEnabled.Location = new System.Drawing.Point(3, 3);
            this.checkBoxEnabled.Name = "checkBoxEnabled";
            this.checkBoxEnabled.Size = new System.Drawing.Size(394, 29);
            this.checkBoxEnabled.TabIndex = 0;
            this.checkBoxEnabled.Text = "Enabled";
            this.checkBoxEnabled.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server";
            // 
            // textBoxServer
            // 
            this.textBoxServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxServer.Location = new System.Drawing.Point(197, 38);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(200, 31);
            this.textBoxServer.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Target";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Target ID";
            // 
            // textBoxTargetID
            // 
            this.textBoxTargetID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTargetID.Location = new System.Drawing.Point(197, 112);
            this.textBoxTargetID.Name = "textBoxTargetID";
            this.textBoxTargetID.Size = new System.Drawing.Size(200, 31);
            this.textBoxTargetID.TabIndex = 7;
            // 
            // textBoxTarget
            // 
            this.textBoxTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTarget.Location = new System.Drawing.Point(197, 75);
            this.textBoxTarget.Name = "textBoxTarget";
            this.textBoxTarget.Size = new System.Drawing.Size(200, 31);
            this.textBoxTarget.TabIndex = 6;
            this.textBoxTarget.TextChanged += new System.EventHandler(this.textBoxTarget_TextChanged);
            // 
            // textBoxSelectedPoints
            // 
            this.textBoxSelectedPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSelectedPoints.Location = new System.Drawing.Point(197, 149);
            this.textBoxSelectedPoints.Multiline = true;
            this.textBoxSelectedPoints.Name = "textBoxSelectedPoints";
            this.textBoxSelectedPoints.Size = new System.Drawing.Size(200, 48);
            this.textBoxSelectedPoints.TabIndex = 9;
            // 
            // checkBoxOnlySelectedPoints
            // 
            this.checkBoxOnlySelectedPoints.AutoSize = true;
            this.checkBoxOnlySelectedPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxOnlySelectedPoints.Location = new System.Drawing.Point(3, 149);
            this.checkBoxOnlySelectedPoints.Name = "checkBoxOnlySelectedPoints";
            this.checkBoxOnlySelectedPoints.Size = new System.Drawing.Size(188, 48);
            this.checkBoxOnlySelectedPoints.TabIndex = 10;
            this.checkBoxOnlySelectedPoints.Text = "Report Only on";
            this.checkBoxOnlySelectedPoints.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SettingsForm";
            this.Size = new System.Drawing.Size(400, 200);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxEnabled;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTargetID;
        private System.Windows.Forms.TextBox textBoxTarget;
        private System.Windows.Forms.TextBox textBoxSelectedPoints;
        private System.Windows.Forms.CheckBox checkBoxOnlySelectedPoints;
    }
}