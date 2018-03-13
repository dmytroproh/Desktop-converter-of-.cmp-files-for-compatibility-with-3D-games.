namespace jsonEditorTestApp
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ViewTextForm : Form
    {
        private Button buttonClose;
        private Button buttonSave;
        private CheckBox checkBoxWrap;
        private IContainer components;
        private RichTextBox richTextBox;

        public ViewTextForm(string title, string text)
        {
            this.InitializeComponent();
            this.Text = title;
            if (text[0] == '{')
            {
                this.richTextBox.Rtf = text;
            }
            else
            {
                this.richTextBox.Text = text;
            }
            string[] lines = this.richTextBox.Lines;
            string str = "";
            foreach (string str2 in lines)
            {
                if (str2.Length > str.Length)
                {
                    str = str2;
                }
            }
            Size size = TextRenderer.MeasureText(str, this.richTextBox.Font);
            size.Width += new VScrollBar().Size.Width;
            if (size.Width < this.richTextBox.Size.Width)
            {
                base.Size = new Size((base.Size.Width - this.richTextBox.Size.Width) + size.Width, base.Size.Height);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                FileName = this.Text,
                Filter = "Text (*.txt)|*.txt",
                DefaultExt = "txt"
            };
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                this.richTextBox.SaveFile(dialog.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void checkBoxWrap_CheckedChanged(object sender, EventArgs e)
        {
            this.richTextBox.WordWrap = this.checkBoxWrap.Checked;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.buttonSave = new Button();
            this.checkBoxWrap = new CheckBox();
            this.buttonClose = new Button();
            this.richTextBox = new RichTextBox();
            ToolStripContainer container = new ToolStripContainer();
            container.ContentPanel.SuspendLayout();
            container.SuspendLayout();
            base.SuspendLayout();
            container.BottomToolStripPanelVisible = false;
            container.ContentPanel.Controls.Add(this.buttonSave);
            container.ContentPanel.Controls.Add(this.checkBoxWrap);
            container.ContentPanel.Controls.Add(this.buttonClose);
            container.ContentPanel.Size = new Size(0x31b, 0x2f);
            container.Dock = DockStyle.Bottom;
            container.LeftToolStripPanelVisible = false;
            container.Location = new Point(0, 0x1c7);
            container.Name = "toolStripContainer1";
            container.RightToolStripPanelVisible = false;
            container.Size = new Size(0x31b, 0x2f);
            container.TabIndex = 5;
            container.Text = "toolStripContainer1";
            container.TopToolStripPanelVisible = false;
            this.buttonSave.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.buttonSave.Location = new Point(0x273, 12);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new Size(0x4b, 0x17);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "&Save...";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new EventHandler(this.buttonSave_Click);
            this.checkBoxWrap.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.checkBoxWrap.AutoSize = true;
            this.checkBoxWrap.Location = new Point(12, 0x10);
            this.checkBoxWrap.Name = "checkBoxWrap";
            this.checkBoxWrap.Size = new Size(0x34, 0x11);
            this.checkBoxWrap.TabIndex = 4;
            this.checkBoxWrap.Text = "&Wrap";
            this.checkBoxWrap.UseVisualStyleBackColor = true;
            this.checkBoxWrap.CheckedChanged += new EventHandler(this.checkBoxWrap_CheckedChanged);
            this.buttonClose.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.buttonClose.DialogResult = DialogResult.Cancel;
            this.buttonClose.Location = new Point(0x2c4, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new Size(0x4b, 0x17);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new EventHandler(this.buttonClose_Click);
            this.richTextBox.DetectUrls = false;
            this.richTextBox.Dock = DockStyle.Fill;
            this.richTextBox.Font = new Font("Courier New", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.richTextBox.Location = new Point(0, 0);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            this.richTextBox.Size = new Size(0x31b, 0x1c7);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            this.richTextBox.WordWrap = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.buttonClose;
            base.ClientSize = new Size(0x31b, 0x1f6);
            base.Controls.Add(this.richTextBox);
            base.Controls.Add(container);
            base.Name = "ViewTextForm";
            base.ShowIcon = false;
            this.Text = "View";
            container.ContentPanel.ResumeLayout(false);
            container.ContentPanel.PerformLayout();
            container.ResumeLayout(false);
            container.PerformLayout();
            base.ResumeLayout(false);
        }
    }
}
