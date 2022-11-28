namespace PowerShell_Dism
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.comboBoxDismCommand = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnWimRemount = new System.Windows.Forms.Button();
            this.btnWimDismount = new System.Windows.Forms.Button();
            this.btnWimMount = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRun);
            this.groupBox1.Controls.Add(this.comboBoxDismCommand);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(140, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 139);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(235, 93);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(89, 23);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // comboBoxDismCommand
            // 
            this.comboBoxDismCommand.FormattingEnabled = true;
            this.comboBoxDismCommand.Items.AddRange(new object[] {
            "Get-WindowsOptionalFeature -Online",
            "Get-WindowsOptionalFeature -Online -FeatureName IIS-WebServer"});
            this.comboBoxDismCommand.Location = new System.Drawing.Point(136, 45);
            this.comboBoxDismCommand.Name = "comboBoxDismCommand";
            this.comboBoxDismCommand.Size = new System.Drawing.Size(377, 23);
            this.comboBoxDismCommand.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dism Command:";
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxOutput.Location = new System.Drawing.Point(68, 316);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.Size = new System.Drawing.Size(680, 148);
            this.richTextBoxOutput.TabIndex = 1;
            this.richTextBoxOutput.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnWimRemount);
            this.groupBox2.Controls.Add(this.btnWimDismount);
            this.groupBox2.Controls.Add(this.btnWimMount);
            this.groupBox2.Location = new System.Drawing.Point(140, 197);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(531, 83);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // btnWimRemount
            // 
            this.btnWimRemount.Location = new System.Drawing.Point(390, 37);
            this.btnWimRemount.Name = "btnWimRemount";
            this.btnWimRemount.Size = new System.Drawing.Size(97, 23);
            this.btnWimRemount.TabIndex = 2;
            this.btnWimRemount.Text = "Remount WIM";
            this.btnWimRemount.UseVisualStyleBackColor = true;
            this.btnWimRemount.Click += new System.EventHandler(this.btnWimRemount_Click);
            // 
            // btnWimDismount
            // 
            this.btnWimDismount.Location = new System.Drawing.Point(188, 37);
            this.btnWimDismount.Name = "btnWimDismount";
            this.btnWimDismount.Size = new System.Drawing.Size(97, 23);
            this.btnWimDismount.TabIndex = 1;
            this.btnWimDismount.Text = "Dismount WIM";
            this.btnWimDismount.UseVisualStyleBackColor = true;
            this.btnWimDismount.Click += new System.EventHandler(this.btnWimDismount_Click);
            // 
            // btnWimMount
            // 
            this.btnWimMount.Location = new System.Drawing.Point(63, 37);
            this.btnWimMount.Name = "btnWimMount";
            this.btnWimMount.Size = new System.Drawing.Size(97, 23);
            this.btnWimMount.TabIndex = 0;
            this.btnWimMount.Text = "Mount WIM";
            this.btnWimMount.UseVisualStyleBackColor = true;
            this.btnWimMount.Click += new System.EventHandler(this.btnWimMount_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 484);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 506);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBoxOutput);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox comboBoxDismCommand;
        private Label label1;
        private Button btnRun;
        private RichTextBox richTextBoxOutput;
        private Label label2;
        private GroupBox groupBox2;
        private Button btnWimDismount;
        private Button btnWimMount;
        private Button btnWimRemount;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}