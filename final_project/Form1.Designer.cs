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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            fontDialog1 = new FontDialog();
            playerBulletTest = new PictureBox();
            backgroundPanel = new Panel();
            scorePanel = new Panel();
            panel2 = new Panel();
            mainTimer = new System.Windows.Forms.Timer(components);
            player = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)playerBulletTest).BeginInit();
            backgroundPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            SuspendLayout();
            // 
            // playerBulletTest
            // 
            playerBulletTest.BackColor = SystemColors.ActiveCaption;
            playerBulletTest.Image = (Image)resources.GetObject("playerBulletTest.Image");
            playerBulletTest.InitialImage = (Image)resources.GetObject("playerBulletTest.InitialImage");
            playerBulletTest.Location = new Point(235, 543);
            playerBulletTest.Margin = new Padding(0);
            playerBulletTest.Name = "playerBulletTest";
            playerBulletTest.Size = new Size(63, 67);
            playerBulletTest.TabIndex = 0;
            playerBulletTest.TabStop = false;
            playerBulletTest.Click += playerBulletTest_Click;
            // 
            // backgroundPanel
            // 
            backgroundPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            backgroundPanel.BackColor = SystemColors.ActiveCaption;
            backgroundPanel.Controls.Add(player);
            backgroundPanel.Controls.Add(scorePanel);
            backgroundPanel.Controls.Add(playerBulletTest);
            backgroundPanel.Controls.Add(panel2);
            backgroundPanel.Location = new Point(0, 0);
            backgroundPanel.Margin = new Padding(3, 4, 3, 4);
            backgroundPanel.Name = "backgroundPanel";
            backgroundPanel.Size = new Size(686, 800);
            backgroundPanel.TabIndex = 1;
            backgroundPanel.SizeChanged += Form1_SizeChanged;
            // 
            // scorePanel
            // 
            scorePanel.BackColor = SystemColors.ActiveCaptionText;
            scorePanel.Cursor = Cursors.SizeAll;
            scorePanel.Dock = DockStyle.Bottom;
            scorePanel.Location = new Point(0, 667);
            scorePanel.Margin = new Padding(3, 4, 3, 4);
            scorePanel.Name = "scorePanel";
            scorePanel.Size = new Size(686, 133);
            scorePanel.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.Location = new Point(23, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(0, 377);
            panel2.TabIndex = 0;
            // 
            // mainTimer
            // 
            mainTimer.Interval = 20;
            mainTimer.Tick += mainEventTimer;
            // 
            // player
            // 
            player.BackColor = SystemColors.ActiveCaptionText;
            player.Location = new Point(445, 540);
            player.Name = "player";
            player.Size = new Size(53, 49);
            player.TabIndex = 2;
            player.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 800);
            Controls.Add(backgroundPanel);
            Margin = new Padding(2, 1, 2, 1);
            Name = "Form1";
            StartPosition = FormStartPosition.Manual;
            Text = "Galiga";
            ResizeEnd += Form1_ResizeEnd;
            KeyDown += Key_Down;
            KeyPress += Form1_KeyPress;
            KeyUp += Key_Up;
            ((System.ComponentModel.ISupportInitialize)playerBulletTest).EndInit();
            backgroundPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)player).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private FontDialog fontDialog1;
        private PictureBox playerBulletTest;
        private Panel backgroundPanel;
        private Panel panel2;
        private Panel scorePanel;
        private System.Windows.Forms.Timer mainTimer;
        private PictureBox player;
    }
}
