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
            this.hookGameButton = new System.Windows.Forms.Button();
            this.mainTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.crAmmoCheck = new System.Windows.Forms.CheckBox();
            this.crAmmoBox = new System.Windows.Forms.TextBox();
            this.healthCheck = new System.Windows.Forms.CheckBox();
            this.healthTextBox = new System.Windows.Forms.TextBox();
            this.setHacksButton = new System.Windows.Forms.Button();
            this.healthTimer = new System.Windows.Forms.Timer(this.components);
            this.ammoCRTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hookGameButton
            // 
            this.hookGameButton.Location = new System.Drawing.Point(12, 12);
            this.hookGameButton.Name = "hookGameButton";
            this.hookGameButton.Size = new System.Drawing.Size(260, 23);
            this.hookGameButton.TabIndex = 0;
            this.hookGameButton.Text = "Hook Game (Status: Not Connected)";
            this.hookGameButton.UseVisualStyleBackColor = true;
            this.hookGameButton.Click += new System.EventHandler(this.hookGameButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.crAmmoCheck);
            this.groupBox1.Controls.Add(this.crAmmoBox);
            this.groupBox1.Controls.Add(this.healthCheck);
            this.groupBox1.Controls.Add(this.healthTextBox);
            this.groupBox1.Controls.Add(this.setHacksButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 167);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available Hacks";
            // 
            // crAmmoCheck
            // 
            this.crAmmoCheck.AutoSize = true;
            this.crAmmoCheck.Location = new System.Drawing.Point(162, 48);
            this.crAmmoCheck.Name = "crAmmoCheck";
            this.crAmmoCheck.Size = new System.Drawing.Size(90, 17);
            this.crAmmoCheck.TabIndex = 4;
            this.crAmmoCheck.Text = "Freeze Ammo";
            this.crAmmoCheck.UseVisualStyleBackColor = true;
            // 
            // crAmmoBox
            // 
            this.crAmmoBox.Location = new System.Drawing.Point(6, 45);
            this.crAmmoBox.Name = "crAmmoBox";
            this.crAmmoBox.Size = new System.Drawing.Size(131, 20);
            this.crAmmoBox.TabIndex = 3;
            this.crAmmoBox.Enter += new System.EventHandler(this.crAmmoBox_Enter);
            this.crAmmoBox.Leave += new System.EventHandler(this.crAmmoBox_Leave);
            // 
            // healthCheck
            // 
            this.healthCheck.AutoSize = true;
            this.healthCheck.Location = new System.Drawing.Point(162, 21);
            this.healthCheck.Name = "healthCheck";
            this.healthCheck.Size = new System.Drawing.Size(92, 17);
            this.healthCheck.TabIndex = 2;
            this.healthCheck.Text = "Freeze Health";
            this.healthCheck.UseVisualStyleBackColor = true;
            // 
            // healthTextBox
            // 
            this.healthTextBox.Location = new System.Drawing.Point(6, 19);
            this.healthTextBox.Name = "healthTextBox";
            this.healthTextBox.Size = new System.Drawing.Size(131, 20);
            this.healthTextBox.TabIndex = 1;
            this.healthTextBox.Enter += new System.EventHandler(this.textBox1_Enter);
            this.healthTextBox.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // setHacksButton
            // 
            this.setHacksButton.Location = new System.Drawing.Point(212, 138);
            this.setHacksButton.Name = "setHacksButton";
            this.setHacksButton.Size = new System.Drawing.Size(42, 23);
            this.setHacksButton.TabIndex = 0;
            this.setHacksButton.Text = "Set";
            this.setHacksButton.UseVisualStyleBackColor = true;
            this.setHacksButton.Click += new System.EventHandler(this.setHacksButton_Click);
            // 
            // healthTimer
            // 
            this.healthTimer.Interval = 250;
            this.healthTimer.Tick += new System.EventHandler(this.healthTimer_Tick);
            // 
            // ammoCRTimer
            // 
            this.ammoCRTimer.Interval = 250;
            this.ammoCRTimer.Tick += new System.EventHandler(this.ammoCRTimer_Tick);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 232);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.hookGameButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dishonored Trainer: v1";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button hookGameButton;
        private System.Windows.Forms.ToolTip mainTooltip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button setHacksButton;
        private System.Windows.Forms.Timer healthTimer;
        private System.Windows.Forms.CheckBox healthCheck;
        private System.Windows.Forms.TextBox healthTextBox;
        private System.Windows.Forms.TextBox crAmmoBox;
        private System.Windows.Forms.Timer ammoCRTimer;
        private System.Windows.Forms.CheckBox crAmmoCheck;
    }
}

