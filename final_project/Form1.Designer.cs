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
            backgroundPanel = new Panel();
            CreditsButton = new Button();
            label2 = new Label();
            finalScore = new Label();
            label1 = new Label();
            playerCopySprite = new PictureBox();
            startGameButton = new Button();
            playerSprite = new PictureBox();
            labelGameStart = new Label();
            scorePanel = new Panel();
            panel1 = new Panel();
            scoreLabel = new Label();
            livesLabel = new Label();
            panel2 = new Panel();
            mainTimer = new System.Windows.Forms.Timer(components);
            iframetimer = new System.Windows.Forms.Timer(components);
            piercingTimer = new System.Windows.Forms.Timer(components);
            trishotTimer = new System.Windows.Forms.Timer(components);
            doubleTimer = new System.Windows.Forms.Timer(components);
            backgroundPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)playerCopySprite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)playerSprite).BeginInit();
            scorePanel.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // backgroundPanel
            // 
            backgroundPanel.BackColor = SystemColors.ActiveCaptionText;
            backgroundPanel.Controls.Add(CreditsButton);
            backgroundPanel.Controls.Add(label2);
            backgroundPanel.Controls.Add(finalScore);
            backgroundPanel.Controls.Add(label1);
            backgroundPanel.Controls.Add(playerCopySprite);
            backgroundPanel.Controls.Add(startGameButton);
            backgroundPanel.Controls.Add(playerSprite);
            backgroundPanel.Controls.Add(labelGameStart);
            backgroundPanel.Controls.Add(scorePanel);
            backgroundPanel.Controls.Add(panel2);
            backgroundPanel.Dock = DockStyle.Fill;
            backgroundPanel.Location = new Point(0, 0);
            backgroundPanel.Margin = new Padding(4, 3, 4, 3);
            backgroundPanel.Name = "backgroundPanel";
            backgroundPanel.Size = new Size(438, 346);
            backgroundPanel.TabIndex = 1;
            // 
            // CreditsButton
            // 
            CreditsButton.AutoSize = true;
            CreditsButton.Location = new Point(168, 202);
            CreditsButton.Margin = new Padding(2);
            CreditsButton.Name = "CreditsButton";
            CreditsButton.Size = new Size(80, 26);
            CreditsButton.TabIndex = 12;
            CreditsButton.Text = "Credits";
            CreditsButton.UseVisualStyleBackColor = true;
            CreditsButton.Click += CreditsButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 2;
            label2.Text = "v1.0.1";
            // 
            // finalScore
            // 
            finalScore.ForeColor = SystemColors.ButtonHighlight;
            finalScore.Location = new Point(177, 176);
            finalScore.Name = "finalScore";
            finalScore.Size = new Size(54, 19);
            finalScore.TabIndex = 11;
            finalScore.Text = "A Game By:\r\nOut of Bounds Exception\r\n\r\nLouis Deprez\r\nLyla Kerr\r\nArmoni Myles";
            finalScore.TextAlign = ContentAlignment.TopCenter;
            finalScore.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 10;
            label1.Text = "label1";
            // 
            // playerCopySprite
            // 
            playerCopySprite.Location = new Point(289, 219);
            playerCopySprite.Margin = new Padding(3, 2, 3, 2);
            playerCopySprite.Name = "playerCopySprite";
            playerCopySprite.Size = new Size(70, 34);
            playerCopySprite.SizeMode = PictureBoxSizeMode.StretchImage;
            playerCopySprite.TabIndex = 9;
            playerCopySprite.TabStop = false;
            // 
            // startGameButton
            // 
            startGameButton.AutoSize = true;
            startGameButton.Location = new Point(168, 148);
            startGameButton.Margin = new Padding(2);
            startGameButton.Name = "startGameButton";
            startGameButton.Size = new Size(80, 26);
            startGameButton.TabIndex = 8;
            startGameButton.Text = "Start!";
            startGameButton.UseVisualStyleBackColor = true;
            startGameButton.Click += startGameButton_Click;
            // 
            // playerSprite
            // 
            playerSprite.BackColor = Color.Transparent;
            playerSprite.Location = new Point(61, 202);
            playerSprite.Margin = new Padding(4, 3, 4, 3);
            playerSprite.Name = "playerSprite";
            playerSprite.Size = new Size(100, 51);
            playerSprite.SizeMode = PictureBoxSizeMode.StretchImage;
            playerSprite.TabIndex = 5;
            playerSprite.TabStop = false;
            // 
            // labelGameStart
            // 
            labelGameStart.ForeColor = SystemColors.ButtonHighlight;
            labelGameStart.Location = new Point(187, 130);
            labelGameStart.Margin = new Padding(4, 0, 4, 0);
            labelGameStart.Name = "labelGameStart";
            labelGameStart.Size = new Size(44, 15);
            labelGameStart.TabIndex = 3;
            labelGameStart.Text = "Galvaders";
            // 
            // scorePanel
            // 
            scorePanel.BackColor = Color.White;
            scorePanel.Controls.Add(panel1);
            scorePanel.Cursor = Cursors.SizeAll;
            scorePanel.Dock = DockStyle.Bottom;
            scorePanel.ForeColor = SystemColors.Control;
            scorePanel.Location = new Point(0, 286);
            scorePanel.Margin = new Padding(4, 3, 4, 3);
            scorePanel.Name = "scorePanel";
            scorePanel.Padding = new Padding(2);
            scorePanel.Size = new Size(438, 60);
            scorePanel.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(scoreLabel);
            panel1.Controls.Add(livesLabel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(434, 56);
            panel1.TabIndex = 0;
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Dock = DockStyle.Right;
            scoreLabel.Font = new Font("Microsoft Sans Serif", 30F, FontStyle.Regular, GraphicsUnit.Pixel);
            scoreLabel.ForeColor = SystemColors.ControlLight;
            scoreLabel.Location = new Point(314, 0);
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
            panel2.Location = new Point(-60, 0);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(0, 294);
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
            // trishotTimer
            // 
            trishotTimer.Interval = 5000;
            trishotTimer.Tick += trishotTimer_Tick;
            // 
            // doubleTimer
            // 
            doubleTimer.Interval = 5000;
            doubleTimer.Tick += doubleTick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(438, 346);
            Controls.Add(backgroundPanel);
            Margin = new Padding(2);
            Name = "Form1";
            StartPosition = FormStartPosition.Manual;
            Text = "Galvaders";
            ResizeEnd += Form1_SizeChanged;
            SizeChanged += ResizeHelp;
            KeyDown += Key_Down;
            KeyUp += Key_Up;
            backgroundPanel.ResumeLayout(false);
            backgroundPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)playerCopySprite).EndInit();
            ((System.ComponentModel.ISupportInitialize)playerSprite).EndInit();
            scorePanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private System.Windows.Forms.Timer iframetimer;
        private System.Windows.Forms.Timer piercingTimer;
        private Button startGameButton;
        private Panel panel1;
        private System.Windows.Forms.Timer trishotTimer;
        private PictureBox playerCopySprite;
        private System.Windows.Forms.Timer doubleTimer;
        private Label finalScore;
        private Label label1;
        private Label label2;
        private Button CreditsButton;
    }
}
