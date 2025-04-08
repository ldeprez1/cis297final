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
            fontDialog1 = new FontDialog();
            backgroundPanel = new Panel();
            startGameButton = new Button();
            powerUpBoxTest = new PictureBox();
            enemyTestBullet = new PictureBox();
            playerSprite = new PictureBox();
            labelGameStart = new Label();
            scorePanel = new Panel();
            scoreLabel = new Label();
            livesLabel = new Label();
            panel2 = new Panel();
            mainTimer = new System.Windows.Forms.Timer(components);
            iframetimer = new System.Windows.Forms.Timer(components);
            piercingTimer = new System.Windows.Forms.Timer(components);
            playerShoot = new System.Windows.Forms.Timer(components);
            backgroundPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)powerUpBoxTest).BeginInit();
            ((System.ComponentModel.ISupportInitialize)enemyTestBullet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)playerSprite).BeginInit();
            scorePanel.SuspendLayout();
            SuspendLayout();
            // 
            // backgroundPanel
            // 
            backgroundPanel.BackColor = SystemColors.ActiveCaption;
            backgroundPanel.Controls.Add(startGameButton);
            backgroundPanel.Controls.Add(powerUpBoxTest);
            backgroundPanel.Controls.Add(enemyTestBullet);
            backgroundPanel.Controls.Add(playerSprite);
            backgroundPanel.Controls.Add(labelGameStart);
            backgroundPanel.Controls.Add(scorePanel);
            backgroundPanel.Controls.Add(panel2);
            backgroundPanel.Dock = DockStyle.Fill;
            backgroundPanel.Location = new Point(0, 0);
            backgroundPanel.Margin = new Padding(7, 6, 7, 6);
            backgroundPanel.Name = "backgroundPanel";
            backgroundPanel.Size = new Size(814, 739);
            backgroundPanel.TabIndex = 1;
            // 
            // startGameButton
            // 
            startGameButton.Location = new Point(312, 315);
            startGameButton.Name = "startGameButton";
            startGameButton.Size = new Size(150, 46);
            startGameButton.TabIndex = 8;
            startGameButton.Text = "Start!";
            startGameButton.UseVisualStyleBackColor = true;
            startGameButton.Click += startGameButton_Click;
            // 
            // powerUpBoxTest
            // 
            powerUpBoxTest.BackColor = Color.LawnGreen;
            powerUpBoxTest.Location = new Point(420, 73);
            powerUpBoxTest.Margin = new Padding(4);
            powerUpBoxTest.Name = "powerUpBoxTest";
            powerUpBoxTest.Size = new Size(52, 49);
            powerUpBoxTest.SizeMode = PictureBoxSizeMode.StretchImage;
            powerUpBoxTest.TabIndex = 7;
            powerUpBoxTest.TabStop = false;
            // 
            // enemyTestBullet
            // 
            enemyTestBullet.BackColor = Color.Yellow;
            enemyTestBullet.Location = new Point(700, 235);
            enemyTestBullet.Margin = new Padding(4);
            enemyTestBullet.Name = "enemyTestBullet";
            enemyTestBullet.Size = new Size(74, 77);
            enemyTestBullet.SizeMode = PictureBoxSizeMode.StretchImage;
            enemyTestBullet.TabIndex = 6;
            enemyTestBullet.TabStop = false;
            // 
            // playerSprite
            // 
            playerSprite.BackColor = SystemColors.Control;
            playerSprite.Location = new Point(700, 798);
            playerSprite.Margin = new Padding(7, 6, 7, 6);
            playerSprite.Name = "playerSprite";
            playerSprite.Size = new Size(186, 109);
            playerSprite.TabIndex = 5;
            playerSprite.TabStop = false;
            // 
            // labelGameStart
            // 
            labelGameStart.AutoSize = true;
            labelGameStart.Location = new Point(347, 280);
            labelGameStart.Margin = new Padding(7, 0, 7, 0);
            labelGameStart.Name = "labelGameStart";
            labelGameStart.Size = new Size(78, 32);
            labelGameStart.TabIndex = 3;
            labelGameStart.Text = "label1";
            // 
            // scorePanel
            // 
            scorePanel.BackColor = SystemColors.ActiveCaptionText;
            scorePanel.Controls.Add(scoreLabel);
            scorePanel.Controls.Add(livesLabel);
            scorePanel.Cursor = Cursors.SizeAll;
            scorePanel.Dock = DockStyle.Bottom;
            scorePanel.Location = new Point(0, 611);
            scorePanel.Margin = new Padding(7, 6, 7, 6);
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
            scoreLabel.Margin = new Padding(7, 0, 7, 0);
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
            livesLabel.Margin = new Padding(7, 0, 7, 0);
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
            panel2.Location = new Point(-112, 0);
            panel2.Margin = new Padding(7, 6, 7, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(0, 628);
            panel2.TabIndex = 0;
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
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 739);
            Controls.Add(backgroundPanel);
            Margin = new Padding(4, 2, 4, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.Manual;
            Text = "Galiga";
            WindowState = FormWindowState.Minimized;
            SizeChanged += Form1_SizeChanged;
            KeyDown += Key_Down;
            KeyPress += Form1_KeyPress;
            KeyUp += Key_Up;
            backgroundPanel.ResumeLayout(false);
            backgroundPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)powerUpBoxTest).EndInit();
            ((System.ComponentModel.ISupportInitialize)enemyTestBullet).EndInit();
            ((System.ComponentModel.ISupportInitialize)playerSprite).EndInit();
            scorePanel.ResumeLayout(false);
            scorePanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private FontDialog fontDialog1;
        private Panel backgroundPanel;
        private Panel panel2;
        private Panel scorePanel;
        private System.Windows.Forms.Timer mainTimer;
        private Label livesLabel;
        private Label scoreLabel;
        private Label labelGameStart;
        private PictureBox playerSprite;
        private PictureBox enemyTestBullet;
        private System.Windows.Forms.Timer iframetimer;
        private PictureBox powerUpBoxTest;
        private System.Windows.Forms.Timer piercingTimer;
        private System.Windows.Forms.Timer playerShoot;
        private Button startGameButton;
    }
}
