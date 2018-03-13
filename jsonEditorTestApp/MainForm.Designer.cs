namespace jsonEditorTestApp
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.FvFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.SelectFVbutton = new System.Windows.Forms.Button();
            this.SelectLVButton = new System.Windows.Forms.Button();
            this.LVFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tbParameter = new System.Windows.Forms.TextBox();
            this.tbVertexNumber = new System.Windows.Forms.TextBox();
            this.SetDPButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // FvFileDialog
            // 
            this.FvFileDialog.FileName = "MOMO_FV.DLL";
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ExecuteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExecuteButton.Location = new System.Drawing.Point(50, 146);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(261, 31);
            this.ExecuteButton.TabIndex = 2;
            this.ExecuteButton.Text = "Set Diffuse Parameter from file";
            this.ExecuteButton.UseVisualStyleBackColor = false;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // SelectFVbutton
            // 
            this.SelectFVbutton.AutoEllipsis = true;
            this.SelectFVbutton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SelectFVbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectFVbutton.Location = new System.Drawing.Point(50, 36);
            this.SelectFVbutton.Name = "SelectFVbutton";
            this.SelectFVbutton.Size = new System.Drawing.Size(261, 34);
            this.SelectFVbutton.TabIndex = 8;
            this.SelectFVbutton.Text = "Import and Convert";
            this.SelectFVbutton.UseVisualStyleBackColor = false;
            this.SelectFVbutton.Click += new System.EventHandler(this.SelectFVbutton_Click);
            // 
            // SelectLVButton
            // 
            this.SelectLVButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SelectLVButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectLVButton.Location = new System.Drawing.Point(50, 92);
            this.SelectLVButton.Name = "SelectLVButton";
            this.SelectLVButton.Size = new System.Drawing.Size(261, 33);
            this.SelectLVButton.TabIndex = 9;
            this.SelectLVButton.Text = "Export";
            this.SelectLVButton.UseVisualStyleBackColor = false;
            this.SelectLVButton.Click += new System.EventHandler(this.SelectLVButton_Click);
            // 
            // tbParameter
            // 
            this.tbParameter.Location = new System.Drawing.Point(223, 192);
            this.tbParameter.Name = "tbParameter";
            this.tbParameter.Size = new System.Drawing.Size(88, 20);
            this.tbParameter.TabIndex = 10;
            // 
            // tbVertexNumber
            // 
            this.tbVertexNumber.Location = new System.Drawing.Point(108, 192);
            this.tbVertexNumber.Name = "tbVertexNumber";
            this.tbVertexNumber.Size = new System.Drawing.Size(60, 20);
            this.tbVertexNumber.TabIndex = 11;
            // 
            // SetDPButton
            // 
            this.SetDPButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SetDPButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SetDPButton.Location = new System.Drawing.Point(50, 249);
            this.SetDPButton.Name = "SetDPButton";
            this.SetDPButton.Size = new System.Drawing.Size(261, 34);
            this.SetDPButton.TabIndex = 12;
            this.SetDPButton.Text = "Set Diffuse Parameter into position";
            this.SetDPButton.UseVisualStyleBackColor = false;
            this.SetDPButton.Click += new System.EventHandler(this.SetDPButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(47, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Position";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(174, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Value";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(88, 226);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(81, 17);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "All positions";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(360, 295);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SetDPButton);
            this.Controls.Add(this.tbVertexNumber);
            this.Controls.Add(this.tbParameter);
            this.Controls.Add(this.SelectLVButton);
            this.Controls.Add(this.SelectFVbutton);
            this.Controls.Add(this.ExecuteButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VMeshData Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog FvFileDialog;
        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.Button SelectFVbutton;
        private System.Windows.Forms.Button SelectLVButton;
        private System.Windows.Forms.SaveFileDialog LVFileDialog;
        private System.Windows.Forms.TextBox tbParameter;
        private System.Windows.Forms.TextBox tbVertexNumber;
        private System.Windows.Forms.Button SetDPButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

