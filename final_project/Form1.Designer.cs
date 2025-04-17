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
            backgroundPanel.Controls.Add(playerCopySprite);
            backgroundPanel.Controls.Add(startGameButton);
            backgroundPanel.Controls.Add(playerSprite);
            backgroundPanel.Controls.Add(labelGameStart);
            backgroundPanel.Controls.Add(scorePanel);
            backgroundPanel.Controls.Add(panel2);
            backgroundPanel.Dock = DockStyle.Fill;
            backgroundPanel.Location = new Point(0, 0);
            backgroundPanel.Margin = new Padding(5, 4, 5, 4);
            backgroundPanel.Name = "backgroundPanel";
            backgroundPanel.Size = new Size(501, 462);
            backgroundPanel.TabIndex = 1;
            // 
            // playerCopySprite
            // 
            playerCopySprite.Location = new Point(330, 292);
            playerCopySprite.Name = "playerCopySprite";
            playerCopySprite.Size = new Size(80, 45);
            playerCopySprite.SizeMode = PictureBoxSizeMode.StretchImage;
            playerCopySprite.TabIndex = 9;
            playerCopySprite.TabStop = false;
            // 
            // startGameButton
            // 
            startGameButton.AutoSize = true;
            startGameButton.Location = new Point(192, 198);
            startGameButton.Margin = new Padding(2);
            startGameButton.Name = "startGameButton";
            startGameButton.Size = new Size(91, 31);
            startGameButton.TabIndex = 8;
            startGameButton.Text = "Start!";
            startGameButton.UseVisualStyleBackColor = true;
            startGameButton.Click += startGameButton_Click;
            // 
            // playerSprite
            // 
            playerSprite.BackColor = Color.Transparent;
            playerSprite.Location = new Point(70, 269);
            playerSprite.Margin = new Padding(5, 4, 5, 4);
            playerSprite.Name = "playerSprite";
            playerSprite.Size = new Size(114, 68);
            playerSprite.SizeMode = PictureBoxSizeMode.StretchImage;
            playerSprite.TabIndex = 5;
            playerSprite.TabStop = false;
            // 
            // labelGameStart
            // 
            labelGameStart.ForeColor = SystemColors.ButtonHighlight;
            labelGameStart.Location = new Point(214, 174);
            labelGameStart.Margin = new Padding(5, 0, 5, 0);
            labelGameStart.Name = "labelGameStart";
            labelGameStart.Size = new Size(50, 20);
            labelGameStart.TabIndex = 3;
            labelGameStart.Text = "label1";
            // 
            // scorePanel
            // 
            scorePanel.BackColor = Color.White;
            scorePanel.Controls.Add(panel1);
            scorePanel.Cursor = Cursors.SizeAll;
            scorePanel.Dock = DockStyle.Bottom;
            scorePanel.ForeColor = SystemColors.Control;
            scorePanel.Location = new Point(0, 382);
            scorePanel.Margin = new Padding(5, 4, 5, 4);
            scorePanel.Name = "scorePanel";
            scorePanel.Padding = new Padding(2);
            scorePanel.Size = new Size(501, 80);
            scorePanel.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(scoreLabel);
            panel1.Controls.Add(livesLabel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(2, 2);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(497, 76);
            panel1.TabIndex = 0;
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Dock = DockStyle.Right;
            scoreLabel.Font = new Font("Microsoft Sans Serif", 30F, FontStyle.Regular, GraphicsUnit.Pixel);
            scoreLabel.ForeColor = SystemColors.ControlLight;
            scoreLabel.Location = new Point(377, 0);
            scoreLabel.Margin = new Padding(5, 0, 5, 0);
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
            livesLabel.Margin = new Padding(5, 0, 5, 0);
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
            panel2.Location = new Point(-69, 0);
            panel2.Margin = new Padding(5, 4, 5, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(0, 392);
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
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(501, 462);
            Controls.Add(backgroundPanel);
            Margin = new Padding(2);
            Name = "Form1";
            StartPosition = FormStartPosition.Manual;
            Text = "Galiga";
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
    }
}
