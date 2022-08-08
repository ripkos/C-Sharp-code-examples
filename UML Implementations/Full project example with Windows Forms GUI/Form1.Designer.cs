
namespace masimplement
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
            this.prototyIntroductionPage1 = new PrototypeIntroductionPage.PrototyIntroductionPage();
            this.SuspendLayout();
            // 
            // prototyIntroductionPage1
            // 
            this.prototyIntroductionPage1.Location = new System.Drawing.Point(3, 3);
            this.prototyIntroductionPage1.Name = "prototyIntroductionPage1";
            this.prototyIntroductionPage1.Size = new System.Drawing.Size(800, 450);
            this.prototyIntroductionPage1.TabIndex = 0;
            this.prototyIntroductionPage1.Load += new System.EventHandler(this.prototyIntroductionPage1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(797, 449);
            this.Controls.Add(this.prototyIntroductionPage1);
            this.Name = "Form1";
            this.Text = "MAS Project";
            this.ResumeLayout(false);

        }

        #endregion

        private PrototypeIntroductionPage.PrototyIntroductionPage prototyIntroductionPage1;
    }
}

