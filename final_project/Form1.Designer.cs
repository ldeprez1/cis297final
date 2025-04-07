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
            playerShoot = new System.Windows.Forms.Timer(components);
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
            playerBulletTest.Location = new Point(206, 406);
            playerBulletTest.Margin = new Padding(0);
            playerBulletTest.Name = "playerBulletTest";
            playerBulletTest.Size = new Size(55, 51);
            playerBulletTest.SizeMode = PictureBoxSizeMode.StretchImage;
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
            backgroundPanel.Margin = new Padding(4, 3, 4, 3);
            backgroundPanel.Name = "backgroundPanel";
            backgroundPanel.Size = new Size(438, 346);
            backgroundPanel.TabIndex = 1;
            // 
            // powerUpBoxTest
            // 
            powerUpBoxTest.BackColor = Color.LawnGreen;
            powerUpBoxTest.Location = new Point(226, 34);
            powerUpBoxTest.Margin = new Padding(2);
            powerUpBoxTest.Name = "powerUpBoxTest";
            powerUpBoxTest.Size = new Size(28, 23);
            powerUpBoxTest.SizeMode = PictureBoxSizeMode.StretchImage;
            powerUpBoxTest.TabIndex = 7;
            powerUpBoxTest.TabStop = false;
            // 
            // enemyTestBullet
            // 
            enemyTestBullet.BackColor = Color.Yellow;
            enemyTestBullet.Location = new Point(377, 110);
            enemyTestBullet.Margin = new Padding(2);
            enemyTestBullet.Name = "enemyTestBullet";
            enemyTestBullet.Size = new Size(40, 36);
            enemyTestBullet.SizeMode = PictureBoxSizeMode.StretchImage;
            enemyTestBullet.TabIndex = 6;
            enemyTestBullet.TabStop = false;
            // 
            // playerSprite
            // 
            playerSprite.BackColor = SystemColors.Control;
            playerSprite.Location = new Point(377, 374);
            playerSprite.Margin = new Padding(4, 3, 4, 3);
            playerSprite.Name = "playerSprite";
            playerSprite.Size = new Size(100, 51);
            playerSprite.TabIndex = 5;
            playerSprite.TabStop = false;
            // 
            // testEnemyBox
            // 
            testEnemyBox.Image = (Image)resources.GetObject("testEnemyBox.Image");
            testEnemyBox.InitialImage = (Image)resources.GetObject("testEnemyBox.InitialImage");
            testEnemyBox.Location = new Point(86, 118);
            testEnemyBox.Margin = new Padding(4, 3, 4, 3);
            testEnemyBox.Name = "testEnemyBox";
            testEnemyBox.Size = new Size(62, 53);
            testEnemyBox.SizeMode = PictureBoxSizeMode.StretchImage;
            testEnemyBox.TabIndex = 4;
            testEnemyBox.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // testBox1
            // 
            testBox1.BackColor = SystemColors.ActiveCaptionText;
            testBox1.Location = new Point(223, 230);
            testBox1.Margin = new Padding(4, 3, 4, 3);
            testBox1.Name = "testBox1";
            testBox1.Size = new Size(57, 37);
            testBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            testBox1.TabIndex = 2;
            testBox1.TabStop = false;
            // 
            // scorePanel
            // 
            scorePanel.BackColor = SystemColors.ControlDark;
            scorePanel.Controls.Add(scoreLabel);
            scorePanel.Controls.Add(livesLabel);
            scorePanel.Cursor = Cursors.SizeAll;
            scorePanel.Dock = DockStyle.Bottom;
            scorePanel.Location = new Point(0, 286);
            scorePanel.Margin = new Padding(4, 3, 4, 3);
            scorePanel.Name = "scorePanel";
            scorePanel.Size = new Size(438, 60);
            scorePanel.TabIndex = 1;
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Dock = DockStyle.Right;
            scoreLabel.Font = new Font("Microsoft Sans Serif", 30F, FontStyle.Regular, GraphicsUnit.Pixel);
            scoreLabel.ForeColor = SystemColors.ControlLight;
            scoreLabel.Location = new Point(318, 0);
            scoreLabel.Margin = new Padding(4, 0, 4, 0);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(120, 72);
            scoreLabel.TabIndex = 1;
            scoreLabel.Text = "SCORE\r\n0";
            scoreLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // livesLabel
            // 
            livesLabel.AutoSize = true;
            livesLabel.Dock = DockStyle.Left;
            livesLabel.Font = new Font("Microsoft Sans Serif", 30F, FontStyle.Regular, GraphicsUnit.Pixel);
            livesLabel.ForeColor = SystemColors.ControlLight;
            livesLabel.Location = new Point(0, 0);
            livesLabel.Margin = new Padding(4, 0, 4, 0);
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
            panel2.Location = new Point(-61, 0);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(0, 294);
            panel2.TabIndex = 0;
            // 
            // player
            // 
            player.BackColor = SystemColors.ActiveCaptionText;
            player.Location = new Point(674, 279);
            player.Margin = new Padding(4, 2, 4, 2);
            player.Name = "player";
            player.Size = new Size(46, 37);
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
            // playerShoot
            // 
            playerShoot.Interval = 300;
            playerShoot.Tick += playerShoot_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 346);
            Controls.Add(player);
            Controls.Add(backgroundPanel);
            Margin = new Padding(2, 1, 2, 1);
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
        private System.Windows.Forms.Timer playerShoot;
    }
}
