namespace final_project
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            playerBulletTest = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)playerBulletTest).BeginInit();
            SuspendLayout();
            // 
            // playerBulletTest
            // 
            playerBulletTest.Image = (Image)resources.GetObject("playerBulletTest.Image");
            playerBulletTest.InitialImage = (Image)resources.GetObject("playerBulletTest.InitialImage");
            playerBulletTest.Location = new Point(420, 817);
            playerBulletTest.Name = "playerBulletTest";
            playerBulletTest.Size = new Size(100, 100);
            playerBulletTest.TabIndex = 0;
            playerBulletTest.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(974, 929);
            Controls.Add(playerBulletTest);
            Name = "Form1";
            StartPosition = FormStartPosition.Manual;
            Text = "Galiga";
            KeyPress += Form1_KeyPress;
            ((System.ComponentModel.ISupportInitialize)playerBulletTest).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox playerBulletTest;
    }
}
