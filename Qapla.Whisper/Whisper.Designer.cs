namespace Qapla.Whisper
{
    partial class Whisper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Whisper));
            recordButton = new Button();
            resultText = new TextBox();
            SuspendLayout();
            // 
            // recordButton
            // 
            recordButton.Location = new Point(12, 12);
            recordButton.Name = "recordButton";
            recordButton.Size = new Size(193, 85);
            recordButton.TabIndex = 0;
            recordButton.Text = "Start Recording";
            recordButton.UseVisualStyleBackColor = true;
            recordButton.Click += RecordButton_Click;
            // 
            // resultText
            // 
            resultText.Location = new Point(24, 69);
            resultText.Multiline = true;
            resultText.Name = "resultText";
            resultText.ScrollBars = ScrollBars.Vertical;
            resultText.Size = new Size(141, 28);
            resultText.TabIndex = 1;
            resultText.Visible = false;
            // 
            // Whisper
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(217, 110);
            Controls.Add(resultText);
            Controls.Add(recordButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Whisper";
            Text = "Qapla - Whipser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button recordButton;
        private TextBox resultText;
    }
}
