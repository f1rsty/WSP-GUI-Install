namespace WSPInstaller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.installButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.fntButton = new System.Windows.Forms.RadioButton();
            this.lapButton = new System.Windows.Forms.RadioButton();
            this.bayButton = new System.Windows.Forms.RadioButton();
            this.cmiButton = new System.Windows.Forms.RadioButton();
            this.macButton = new System.Windows.Forms.RadioButton();
            this.oakButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // installButton
            // 
            this.installButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(164)))));
            this.installButton.FlatAppearance.BorderSize = 0;
            this.installButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.installButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installButton.ForeColor = System.Drawing.Color.White;
            this.installButton.Location = new System.Drawing.Point(57, 307);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(75, 37);
            this.installButton.TabIndex = 0;
            this.installButton.Text = "Install";
            this.installButton.UseVisualStyleBackColor = false;
            this.installButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(164)))));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.Color.White;
            this.cancelButton.Location = new System.Drawing.Point(255, 307);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 37);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // fntButton
            // 
            this.fntButton.AutoSize = true;
            this.fntButton.Location = new System.Drawing.Point(139, 148);
            this.fntButton.Name = "fntButton";
            this.fntButton.Size = new System.Drawing.Size(89, 17);
            this.fntButton.TabIndex = 2;
            this.fntButton.TabStop = true;
            this.fntButton.Text = "McLaren Flint";
            this.fntButton.UseVisualStyleBackColor = true;
            // 
            // lapButton
            // 
            this.lapButton.AutoSize = true;
            this.lapButton.Location = new System.Drawing.Point(139, 171);
            this.lapButton.Name = "lapButton";
            this.lapButton.Size = new System.Drawing.Size(103, 17);
            this.lapButton.TabIndex = 3;
            this.lapButton.TabStop = true;
            this.lapButton.Text = "McLaren Lapeer";
            this.lapButton.UseVisualStyleBackColor = true;
            // 
            // bayButton
            // 
            this.bayButton.AutoSize = true;
            this.bayButton.Location = new System.Drawing.Point(139, 194);
            this.bayButton.Name = "bayButton";
            this.bayButton.Size = new System.Drawing.Size(88, 17);
            this.bayButton.TabIndex = 4;
            this.bayButton.TabStop = true;
            this.bayButton.Text = "McLaren Bay";
            this.bayButton.UseVisualStyleBackColor = true;
            // 
            // cmiButton
            // 
            this.cmiButton.AutoSize = true;
            this.cmiButton.Location = new System.Drawing.Point(139, 216);
            this.cmiButton.Name = "cmiButton";
            this.cmiButton.Size = new System.Drawing.Size(103, 17);
            this.cmiButton.TabIndex = 5;
            this.cmiButton.TabStop = true;
            this.cmiButton.Text = "McLaren Central";
            this.cmiButton.UseVisualStyleBackColor = true;
            // 
            // macButton
            // 
            this.macButton.AutoSize = true;
            this.macButton.Location = new System.Drawing.Point(139, 239);
            this.macButton.Name = "macButton";
            this.macButton.Size = new System.Drawing.Size(111, 17);
            this.macButton.TabIndex = 6;
            this.macButton.TabStop = true;
            this.macButton.Text = "McLaren Macomb";
            this.macButton.UseVisualStyleBackColor = true;
            // 
            // oakButton
            // 
            this.oakButton.AutoSize = true;
            this.oakButton.Location = new System.Drawing.Point(139, 262);
            this.oakButton.Name = "oakButton";
            this.oakButton.Size = new System.Drawing.Size(110, 17);
            this.oakButton.TabIndex = 7;
            this.oakButton.TabStop = true;
            this.oakButton.Text = "McLaren Oakland";
            this.oakButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Select your site:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(124, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "WSP Installer";
            // 
            // Form1
            // 
            this.AcceptButton = this.installButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::WSPInstaller.Properties.Resources.McLaren_Hospital;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(380, 360);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.oakButton);
            this.Controls.Add(this.macButton);
            this.Controls.Add(this.cmiButton);
            this.Controls.Add(this.bayButton);
            this.Controls.Add(this.lapButton);
            this.Controls.Add(this.fntButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.installButton);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WSP Installer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button installButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.RadioButton fntButton;
        private System.Windows.Forms.RadioButton lapButton;
        private System.Windows.Forms.RadioButton bayButton;
        private System.Windows.Forms.RadioButton cmiButton;
        private System.Windows.Forms.RadioButton macButton;
        private System.Windows.Forms.RadioButton oakButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

