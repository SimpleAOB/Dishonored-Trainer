namespace Dishonored_Trainer
{
    partial class mainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.hookGameButton = new System.Windows.Forms.Button();
            this.mainTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.breathCheck = new System.Windows.Forms.CheckBox();
            this.healthTimer = new System.Windows.Forms.Timer(this.components);
            this.manaTimer = new System.Windows.Forms.Timer(this.components);
            this.breathTimer = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.manaCheck = new System.Windows.Forms.CheckBox();
            this.healthCheck = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // hookGameButton
            // 
            this.hookGameButton.Location = new System.Drawing.Point(12, 12);
            this.hookGameButton.Name = "hookGameButton";
            this.hookGameButton.Size = new System.Drawing.Size(285, 23);
            this.hookGameButton.TabIndex = 0;
            this.hookGameButton.Text = "Hook Game (Status: Not Connected)";
            this.hookGameButton.UseVisualStyleBackColor = true;
            this.hookGameButton.Click += new System.EventHandler(this.hookGameButton_Click);
            // 
            // breathCheck
            // 
            this.breathCheck.AutoSize = true;
            this.breathCheck.Location = new System.Drawing.Point(6, 6);
            this.breathCheck.Name = "breathCheck";
            this.breathCheck.Size = new System.Drawing.Size(103, 17);
            this.breathCheck.TabIndex = 0;
            this.breathCheck.Text = "Unlimited Breath";
            this.mainTooltip.SetToolTip(this.breathCheck, "You cna stay underwater for ever");
            this.breathCheck.UseVisualStyleBackColor = true;
            // 
            // healthTimer
            // 
            this.healthTimer.Interval = 250;
            this.healthTimer.Tick += new System.EventHandler(this.healthTimer_Tick);
            // 
            // manaTimer
            // 
            this.manaTimer.Interval = 250;
            this.manaTimer.Tick += new System.EventHandler(this.manaTimer_Tick);
            // 
            // breathTimer
            // 
            this.breathTimer.Interval = 250;
            this.breathTimer.Tick += new System.EventHandler(this.breathTimer_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 55);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(285, 157);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.manaCheck);
            this.tabPage1.Controls.Add(this.healthCheck);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(277, 131);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main Hacks";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // manaCheck
            // 
            this.manaCheck.AutoSize = true;
            this.manaCheck.Location = new System.Drawing.Point(6, 46);
            this.manaCheck.Name = "manaCheck";
            this.manaCheck.Size = new System.Drawing.Size(99, 17);
            this.manaCheck.TabIndex = 11;
            this.manaCheck.Text = "Unlimited Mana";
            this.manaCheck.UseVisualStyleBackColor = true;
            // 
            // healthCheck
            // 
            this.healthCheck.AutoSize = true;
            this.healthCheck.Location = new System.Drawing.Point(6, 6);
            this.healthCheck.Name = "healthCheck";
            this.healthCheck.Size = new System.Drawing.Size(103, 17);
            this.healthCheck.TabIndex = 10;
            this.healthCheck.Text = "Unlimited Health";
            this.healthCheck.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.breathCheck);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(277, 131);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Misc";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 225);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.hookGameButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dishonored Trainer: v1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button hookGameButton;
        private System.Windows.Forms.ToolTip mainTooltip;
        private System.Windows.Forms.Timer healthTimer;
        private System.Windows.Forms.Timer manaTimer;
        private System.Windows.Forms.Timer breathTimer;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox manaCheck;
        private System.Windows.Forms.CheckBox healthCheck;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox breathCheck;
    }
}

