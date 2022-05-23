
namespace WinFormsGame
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.playerBox = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.BackgroundMap = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.playerBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundMap)).BeginInit();
            this.SuspendLayout();
            // 
            // playerBox
            // 
            this.playerBox.Location = new System.Drawing.Point(325, 235);
            this.playerBox.Name = "playerBox";
            this.playerBox.Size = new System.Drawing.Size(115, 151);
            this.playerBox.TabIndex = 0;
            this.playerBox.TabStop = false;
            this.playerBox.Click += new System.EventHandler(this.pictureBox2_Click_1);
            // 
            // BackgroundMap
            // 
            this.BackgroundMap.Location = new System.Drawing.Point(12, 12);
            this.BackgroundMap.Name = "BackgroundMap";
            this.BackgroundMap.Size = new System.Drawing.Size(100, 50);
            this.BackgroundMap.TabIndex = 1;
            this.BackgroundMap.TabStop = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(982, 571);
            this.Controls.Add(this.BackgroundMap);
            this.Controls.Add(this.playerBox);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playerBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox playerBox;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.BindingSource bindingSource1;
        public System.Windows.Forms.PictureBox BackgroundMap;
    }
}

