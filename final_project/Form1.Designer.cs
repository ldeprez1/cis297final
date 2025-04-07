﻿namespace final_project
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
            powerUpBoxTest = new PictureBox();
            enemyTestBullet = new PictureBox();
            playerSprite = new PictureBox();
            testEnemyBox = new PictureBox();
            label1 = new Label();
            testBox1 = new PictureBox();
            scorePanel = new Panel();
            scoreLabel = new Label();
            livesLabel = new Label();
            panel2 = new Panel();
            player = new PictureBox();
            mainTimer = new System.Windows.Forms.Timer(components);
            iframetimer = new System.Windows.Forms.Timer(components);
            piercingTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)playerBulletTest).BeginInit();
            backgroundPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)powerUpBoxTest).BeginInit();
            ((System.ComponentModel.ISupportInitialize)enemyTestBullet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)playerSprite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)testEnemyBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)testBox1).BeginInit();
            scorePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            SuspendLayout();
            // 
            // playerBulletTest
            // 
            playerBulletTest.BackColor = SystemColors.ActiveCaption;
            playerBulletTest.Image = (Image)resources.GetObject("playerBulletTest.Image");
            playerBulletTest.InitialImage = (Image)resources.GetObject("playerBulletTest.InitialImage");
            playerBulletTest.Location = new Point(384, 867);
            playerBulletTest.Margin = new Padding(0);
            playerBulletTest.Name = "playerBulletTest";
            playerBulletTest.Size = new Size(102, 109);
            playerBulletTest.TabIndex = 0;
            playerBulletTest.TabStop = false;
            // 
            // backgroundPanel
            // 
            backgroundPanel.BackColor = SystemColors.ActiveCaption;
            backgroundPanel.Controls.Add(powerUpBoxTest);
            backgroundPanel.Controls.Add(enemyTestBullet);
            backgroundPanel.Controls.Add(playerSprite);
            backgroundPanel.Controls.Add(testEnemyBox);
            backgroundPanel.Controls.Add(label1);
            backgroundPanel.Controls.Add(testBox1);
            backgroundPanel.Controls.Add(scorePanel);
            backgroundPanel.Controls.Add(playerBulletTest);
            backgroundPanel.Controls.Add(panel2);
            backgroundPanel.Dock = DockStyle.Fill;
            backgroundPanel.Location = new Point(0, 0);
            backgroundPanel.Margin = new Padding(6);
            backgroundPanel.Name = "backgroundPanel";
            backgroundPanel.Size = new Size(814, 739);
            backgroundPanel.TabIndex = 1;
            // 
            // powerUpBoxTest
            // 
            powerUpBoxTest.BackColor = Color.LawnGreen;
            powerUpBoxTest.Location = new Point(419, 74);
            powerUpBoxTest.Name = "powerUpBoxTest";
            powerUpBoxTest.Size = new Size(52, 50);
            powerUpBoxTest.TabIndex = 7;
            powerUpBoxTest.TabStop = false;
            // 
            // enemyTestBullet
            // 
            enemyTestBullet.BackColor = Color.Yellow;
            enemyTestBullet.Location = new Point(700, 234);
            enemyTestBullet.Name = "enemyTestBullet";
            enemyTestBullet.Size = new Size(75, 77);
            enemyTestBullet.TabIndex = 6;
            enemyTestBullet.TabStop = false;
            // 
            // playerSprite
            // 
            playerSprite.BackColor = SystemColors.Control;
            playerSprite.Location = new Point(700, 797);
            playerSprite.Margin = new Padding(6);
            playerSprite.Name = "playerSprite";
            playerSprite.Size = new Size(185, 109);
            playerSprite.TabIndex = 5;
            playerSprite.TabStop = false;
            // 
            // testEnemyBox
            // 
            testEnemyBox.Image = (Image)resources.GetObject("testEnemyBox.Image");
            testEnemyBox.InitialImage = (Image)resources.GetObject("testEnemyBox.InitialImage");
            testEnemyBox.Location = new Point(159, 253);
            testEnemyBox.Margin = new Padding(6);
            testEnemyBox.Name = "testEnemyBox";
            testEnemyBox.Size = new Size(115, 114);
            testEnemyBox.TabIndex = 4;
            testEnemyBox.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 19);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(78, 32);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // testBox1
            // 
            testBox1.BackColor = SystemColors.ActiveCaptionText;
            testBox1.Location = new Point(414, 490);
            testBox1.Margin = new Padding(6);
            testBox1.Name = "testBox1";
            testBox1.Size = new Size(106, 78);
            testBox1.TabIndex = 2;
            testBox1.TabStop = false;
            // 
            // scorePanel
            // 
            scorePanel.BackColor = SystemColors.ActiveCaptionText;
            scorePanel.Controls.Add(scoreLabel);
            scorePanel.Controls.Add(livesLabel);
            scorePanel.Cursor = Cursors.SizeAll;
            scorePanel.Dock = DockStyle.Bottom;
            scorePanel.Location = new Point(0, 611);
            scorePanel.Margin = new Padding(6);
            scorePanel.Name = "scorePanel";
            scorePanel.Size = new Size(814, 128);
            scorePanel.TabIndex = 1;
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Dock = DockStyle.Right;
            scoreLabel.Font = new Font("Microsoft Sans Serif", 30F, FontStyle.Regular, GraphicsUnit.Pixel);
            scoreLabel.ForeColor = SystemColors.ControlLight;
            scoreLabel.Location = new Point(694, 0);
            scoreLabel.Margin = new Padding(6, 0, 6, 0);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(120, 72);
            scoreLabel.TabIndex = 1;
            scoreLabel.Text = "SCORE\r\n67986\r\n";
            scoreLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // livesLabel
            // 
            livesLabel.AutoSize = true;
            livesLabel.Dock = DockStyle.Left;
            livesLabel.Font = new Font("Microsoft Sans Serif", 30F, FontStyle.Regular, GraphicsUnit.Pixel);
            livesLabel.ForeColor = SystemColors.ControlLight;
            livesLabel.Location = new Point(0, 0);
            livesLabel.Margin = new Padding(6, 0, 6, 0);
            livesLabel.Name = "livesLabel";
            livesLabel.Size = new Size(101, 72);
            livesLabel.TabIndex = 0;
            livesLabel.Text = "LIVES\r\n9\r\n";
            livesLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.Location = new Point(-114, 0);
            panel2.Margin = new Padding(6);
            panel2.Name = "panel2";
            panel2.Size = new Size(0, 627);
            panel2.TabIndex = 0;
            // 
            // player
            // 
            player.BackColor = SystemColors.ActiveCaptionText;
            player.Location = new Point(1251, 595);
            player.Margin = new Padding(6, 3, 6, 3);
            player.Name = "player";
            player.Size = new Size(84, 78);
            player.TabIndex = 2;
            player.TabStop = false;
            // 
            // mainTimer
            // 
            mainTimer.Interval = 20;
            mainTimer.Tick += mainEventTimer;
            // 
            // iframetimer
            // 
            iframetimer.Tick += iframetimer_Tick;
            // 
            // piercingTimer
            // 
            piercingTimer.Interval = 5000;
            piercingTimer.Tick += piercingTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 739);
            Controls.Add(player);
            Controls.Add(backgroundPanel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.Manual;
            Text = "Galiga";
            WindowState = FormWindowState.Minimized;
            SizeChanged += Form1_SizeChanged;
            KeyDown += Key_Down;
            KeyPress += Form1_KeyPress;
            KeyUp += Key_Up;
            ((System.ComponentModel.ISupportInitialize)playerBulletTest).EndInit();
            backgroundPanel.ResumeLayout(false);
            backgroundPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)powerUpBoxTest).EndInit();
            ((System.ComponentModel.ISupportInitialize)enemyTestBullet).EndInit();
            ((System.ComponentModel.ISupportInitialize)playerSprite).EndInit();
            ((System.ComponentModel.ISupportInitialize)testEnemyBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)testBox1).EndInit();
            scorePanel.ResumeLayout(false);
            scorePanel.PerformLayout();
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
        private Label livesLabel;
        private PictureBox testBox1;
        private Label scoreLabel;
        private Label label1;
        private PictureBox testEnemyBox;
        private PictureBox playerSprite;
        private PictureBox enemyTestBullet;
        private System.Windows.Forms.Timer iframetimer;
        private PictureBox powerUpBoxTest;
        private System.Windows.Forms.Timer piercingTimer;
    }
}
