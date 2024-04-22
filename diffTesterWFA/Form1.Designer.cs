namespace diffTesterWFA
{
    partial class Form1
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
            this.getButton = new System.Windows.Forms.Button();
            this.setRightButton = new System.Windows.Forms.Button();
            this.setLeftButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.setRightTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.setLeftTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // getButton
            // 
            this.getButton.Location = new System.Drawing.Point(176, 67);
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(96, 23);
            this.getButton.TabIndex = 13;
            this.getButton.Text = "Get";
            this.getButton.UseVisualStyleBackColor = true;
            this.getButton.Click += new System.EventHandler(this.getButton_Click);
            // 
            // setRightButton
            // 
            this.setRightButton.Location = new System.Drawing.Point(278, 38);
            this.setRightButton.Name = "setRightButton";
            this.setRightButton.Size = new System.Drawing.Size(155, 23);
            this.setRightButton.TabIndex = 12;
            this.setRightButton.Text = "Set right";
            this.setRightButton.UseVisualStyleBackColor = true;
            this.setRightButton.Click += new System.EventHandler(this.setRightButton_Click);
            // 
            // setLeftButton
            // 
            this.setLeftButton.Location = new System.Drawing.Point(22, 38);
            this.setLeftButton.Name = "setLeftButton";
            this.setLeftButton.Size = new System.Drawing.Size(148, 23);
            this.setLeftButton.TabIndex = 11;
            this.setLeftButton.Text = "Set left";
            this.setLeftButton.UseVisualStyleBackColor = true;
            this.setLeftButton.Click += new System.EventHandler(this.setLeftButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Right set:";
            // 
            // setRightTextBox
            // 
            this.setRightTextBox.Location = new System.Drawing.Point(333, 12);
            this.setRightTextBox.Name = "setRightTextBox";
            this.setRightTextBox.Size = new System.Drawing.Size(100, 20);
            this.setRightTextBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Left set:";
            // 
            // setLeftTextBox
            // 
            this.setLeftTextBox.Location = new System.Drawing.Point(70, 12);
            this.setLeftTextBox.Name = "setLeftTextBox";
            this.setLeftTextBox.Size = new System.Drawing.Size(100, 20);
            this.setLeftTextBox.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 137);
            this.Controls.Add(this.getButton);
            this.Controls.Add(this.setRightButton);
            this.Controls.Add(this.setLeftButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.setRightTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.setLeftTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getButton;
        private System.Windows.Forms.Button setRightButton;
        private System.Windows.Forms.Button setLeftButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox setRightTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox setLeftTextBox;
    }
}

