using Galvaders.Properties;
using System;
using System.Drawing.Text;
using System.Media;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static final_project.Form1;

namespace final_project
{
    public partial class Form1 : Form
    {

        /*

        powerup idea
        random chance from killing enemy
        higher score enemy = higher chance

        */
        bool credits = false;

        //checks GameState. Default, Zero, is to START THE GAME. One Calls to update all sprite locations and run collision calculations. 2 is GAME OVER. 3 is do nothing
        int gameState = 0;


        //for when player is hit
        int iFrameCounter = 0;
        public bool dead = false;
        public bool iFrame = false;

        //for resizing
        bool fullscreen = false;
        int HEIGHT_OFFSET = 56;
        int WIDTH_OFFSET = 22;

        //for player movement
        public bool moveLeft;
        public bool moveRight;
        public bool moveUp;
        public bool moveDown;


        public bool firing = true;              //what is this used for? is it redundant?


        //for powerups
        public bool piercingPower = false;
        public bool sheild = false;
        public static bool trishot = false;
        public bool copy = false;

        //for custom fonts
        PrivateFontCollection customFonts;

        //for bullet checking
        List<Bullet> bullets;
        public static List<Enemy> killed;
        public static List<Bullet> remove;
        //for powerup movements
        List<Powerup> powerups;

        //for player/players
        public static Player playerBox;
        public Player playerCopy = null;
        List<Player> players = new List<Player>();

        static SoundPlayer death = new SoundPlayer("Resources\\death.wav");
        public Form1()
        {
            InitializeComponent();
            mainTimer.Start();

            Waves.parent = this.backgroundPanel; //set parent for wave functions
            killed = new List<Enemy>();
            //fix offsets
            HEIGHT_OFFSET = this.Height - this.backgroundPanel.Height;
            WIDTH_OFFSET = this.Width - this.backgroundPanel.Width;
            this.backgroundPanel.Dock = DockStyle.None;
            this.backgroundPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            this.backgroundPanel.Height = this.Height - HEIGHT_OFFSET;
            this.backgroundPanel.Width = this.backgroundPanel.Height;
            this.scorePanel.Height = this.backgroundPanel.Height / 6;
            this.backgroundPanel.Location = new Point((this.Width - this.backgroundPanel.Height - HEIGHT_OFFSET) / 2, 0);

            //Enemy class setup
            Enemy.ScoreLabel = scoreLabel;
            Enemy.livesText = livesLabel;

            //bullet setup
            bullets = new List<Bullet> { };
            remove = new List<Bullet>();
            //powerup setup
            powerups = new List<Powerup>();

            //FONT setup
            customFonts = new PrivateFontCollection();
            customFonts.AddFontFile("Resources\\ka1.ttf");

            //player setup
            playerBox = new Player(5500, 8800, playerSprite);
            //playerCopy = new Player(6500, 8800, playerCopySprite);
            playerCopySprite.Enabled = false;
            players = new List<Player>();
            players.Add(playerBox);
            //playerSprite.BringToFront();
            //Waves.currentEnemies.Add(new ChaserEnemy(0, 200, Waves.parent, true));
            //Waves.currentEnemies.Add(new ChaserEnemy(0, 200, Waves.parent, false));
            //Waves.currentEnemies.Add(new SplitterEnemy(0, 500, 11500, 2500, 15, Waves.parent, true));
            Waves.currentEnemies.Add(new Miniboss(Waves.parent)); //keep this one for the title it looks cool :>
            //Waves.currentEnemies.Add(new ChaserEnemy(0, 200, Waves.parent, true));
            //Waves.currentEnemies.Add(new ChaserEnemy(0, 200, Waves.parent, false));
            //Waves.currentEnemies.Add(new SplitterEnemy(0, 500, 11500 , 2500, 15, Waves.parent, true));
            this.Width = (int)(Screen.FromControl(this).WorkingArea.Width * 0.75);
            this.Height = (int)(Screen.FromControl(this).WorkingArea.Height * 0.75);

            this.Location = new Point((int)(Screen.FromControl(this).WorkingArea.Width * 0.125), (int)(Screen.FromControl(this).WorkingArea.Height * 0.125));


            ResizeThings();
        }


        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            ResizeThings();
        }


        private void mainEventTimer(object sender, EventArgs e)
        {
            switch (gameState)
            {
                case 0:
                    showTitle();
                    gameState = 3;
                    break;
                case 1:
                    RunGameLogic();
                    break;
                case 2:
                    backgroundPanel.BringToFront();
                    labelGameStart.BringToFront(); startGameButton.BringToFront(); finalScore.BringToFront();
                    labelGameStart.Visible = true; startGameButton.Visible = true; startGameButton.Enabled = true;
                    finalScore.Visible = true;
                    scorePanel.Visible = true;
                    playerSprite.Visible = true;
                    if (copy && playerCopy != null)
                    {
                        playerCopySprite.Visible = true;
                    }
                    labelGameStart.Text = "GAME OVER!";
                    finalScore.Text = $"Score:{Enemy.GlobalScore}";
                    startGameButton.Text = "TRY AGAIN?";
                    iFrameCounter = 30;
                    gameState = 3;
                    break;
            }


            //move player
            if (moveLeft) playerBox.Move(Keys.Left);
            if (moveRight) playerBox.Move(Keys.Right);
            if (moveUp) playerBox.Move(Keys.Up);
            if (moveDown) playerBox.Move(Keys.Down);

            if (copy && playerCopy != null)
            {
                if (moveLeft) playerCopy.Move(Keys.Left);
                if (moveRight) playerCopy.Move(Keys.Right);
                if (moveUp) playerCopy.Move(Keys.Up);
                if (moveDown) playerCopy.Move(Keys.Down);
            }

            if (Waves.currentEnemies.Count == 0)
                Waves.nextWave();
        }
        public void showTitle()
        {
            backgroundPanel.BringToFront();
            labelGameStart.BringToFront();
            startGameButton.BringToFront();
            labelGameStart.Visible = true; startGameButton.Visible = true; startGameButton.Enabled = true;
            scorePanel.Visible = false;
            playerSprite.Visible = false;
            playerCopySprite.Visible = false;
        }
        //private void CheckGameState()
        //{ //checks GameState. Default, Zero, is to START THE GAME. One Calls to update all sprite locations and run collision calculations. 2 is GAME OVER
        //    switch (gameState)
        //    {
        //        case 1:

        //            break;
        //        case 2:
        //            backgroundPanel.BringToFront();
        //            labelGameStart.BringToFront(); startGameButton.BringToFront();
        //            labelGameStart.Visible = true; startGameButton.Visible = true; startGameButton.Enabled = true;
        //            scorePanel.Visible = true;
        //            playerSprite.Visible = true;
        //            playerCopySprite.Visible = true;
        //            labelGameStart.Text = "GAME OVER!";
        //            startGameButton.Text = "TRY AGAIN?";
        //            iFrameCounter = 30;
        //            break;
        //        default:
        //            showTitle();
        //            break;
        //    }
        //}
        private void RunGameLogic()
        {
            finalScore.Visible = false;
            if (playerBox.lives == 0)
            { //immediately stops this entire thing if lives becomes 0
                gameState = 2;
                return;
            }

            List<Powerup> toRemove = new List<Powerup>();
            foreach (Powerup powerup in powerups)
            { //update position of any active powerups. Active status is false by default, can be manually set. check for Active is in the class itself :>
                powerup.UpdatePos();
                if (!powerup.active) toRemove.Add(powerup);
                if (powerup.SpriteObject.Bounds.IntersectsWith(playerBox.SpriteObject.Bounds))
                {
                    toRemove.Add(powerup);
                    switch (powerup.type)
                    {
                        case 3:
                            copy = true;
                            doubleTimer.Enabled = true;
                            if (playerCopy == null)
                            {
                                playerCopy = new Player(playerBox.xCoord + 800, playerBox.yCoord, playerCopySprite);
                                playerCopySprite.Visible = true;
                                playerCopySprite.Enabled = true;
                                backgroundPanel.Controls.Add(playerCopy.SpriteObject);
                            }
                            break;
                        case 2://trishot
                            trishot = true;
                            trishotTimer.Enabled = true;
                            break;
                        case 1: //sheild
                            sheild = true;
                            playerBox.SpriteObject.BackColor = Color.FromArgb(127, 224, 177, 7);
                            break;
                        default:
                            //case 0 and default case, piercing
                            piercingPower = true;
                            piercingTimer.Enabled = true;
                            playerBox.SpriteObject.Image = Image.FromFile("Resources\\ship_sprite_powerup.png");
                            break;
                    }
                }
            }

            foreach (Powerup p in toRemove)
            {
                backgroundPanel.Controls.Remove(p.SpriteObject);
                powerups.Remove(p);
            }
            toRemove.Clear();


            toRemove.Clear();
            foreach (Bullet bullet in bullets)
            { //updates all player bullet positions
                bullet.UpdatePos();
                if (!(bullet.WallCheck()))
                {
                    remove.Add(bullet);
                }
            }


            foreach (Enemy enemy in Waves.currentEnemies.ToList())
            { //updates all enemy positions and then compares each enemy with player bullets
                enemy.move();
                enemy.Shoot();
                if (enemy.SpriteObject.Bounds.IntersectsWith(playerBox.SpriteObject.Bounds) && !iFrame) //check for collisions between player and enemies
                {
                    playerBox.lives--;
                    livesLabel.Text = $"Lives: {Environment.NewLine} {playerBox.lives}";
                    playerBox.SpriteObject.Visible = false;
                    iframetimer.Start();
                    death.Play();
                    iFrame = true;
                    dead = true;
                }
                foreach (Bullet bullet in bullets)
                {
                    if (bullet.SpriteObject.Bounds.IntersectsWith(enemy.SpriteObject.Bounds))
                    {
                        if (enemy.boss)
                        {
                            if (enemy.health == 0)
                            {
                                killed.Add(enemy);
                            }
                            else
                            {
                                enemy.Hit();
                            }
                        }

                        else
                        {
                            killed.Add(enemy);
                            if (Powerup.DoesSpawn(enemy.score, 2501))
                            { //chance for a piercing powerup to spawn
                                Powerup p = new Powerup(325, enemy.xCoord, enemy.yCoord, 0, enemy, enemy.SpriteObject.Parent, 4, 4);
                                p.active = true;
                                powerups.Add(p);
                            }
                            if (Powerup.DoesSpawn(enemy.score, 4001))
                            { //sheild powerup spawn
                                Powerup p = new Powerup(350, enemy.xCoord, enemy.yCoord, 1, enemy, enemy.SpriteObject.Parent, 4, 4);
                                p.active = true;
                                powerups.Add(p);
                            }
                            if (Powerup.DoesSpawn(enemy.score, 1501))
                            {
                                Powerup p = new Powerup(200, enemy.xCoord, enemy.yCoord, 2, enemy, enemy.SpriteObject.Parent, 4, 4);
                                p.active = true;
                                powerups.Add(p);
                            }
                            if (Powerup.DoesSpawn(enemy.score, 500))
                            {
                                Powerup p = new Powerup(200, enemy.xCoord, enemy.yCoord, 3, enemy, enemy.SpriteObject.Parent, 4, 4);
                                p.active = true;
                                powerups.Add(p);
                            }
                        }


                        if (!piercingPower) remove.Add(bullet);

                    }
                }
            }
            foreach (Enemy enemy in killed)
            {
                enemy.Hit();
                backgroundPanel.Controls.Remove(enemy.SpriteObject);
                Waves.currentEnemies.Remove(enemy);
            }

            killed.Clear();
            foreach (Bullet bullet in remove)
            {
                backgroundPanel.Controls.Remove(bullet.SpriteObject);
                bullets.Remove(bullet);
            }
            remove.Clear();
            //label1.Text = $"Player bullet Pos: X:{playerBullet.xCoord} Y: {playerBullet.yCoord}";
            //bullets if for PlayerBullets. enemy bullets is for enemy bullets


            Bullet? Hit = null;
            foreach (Bullet bullet in Enemy.enemyBullets)
            { //updates enemy bullets and then checks for collisions
                bullet.UpdatePos();

                if (bullet.SpriteObject.Bounds.IntersectsWith(playerBox.SpriteObject.Bounds) && !iFrame)
                {
                    if (sheild)
                    {
                        playerBox.SpriteObject.BackColor = Color.FromArgb(0, 0, 0, 0);
                        iFrame = true;
                        iFrameCounter = 10;
                        sheild = false;
                        iframetimer.Enabled = true;
                    }
                    else
                    {
                        playerBox.lives--;
                        death.Play();
                        iFrameCounter = 0;
                        livesLabel.Text = $"Lives: {Environment.NewLine} {playerBox.lives}";
                        playerBox.SpriteObject.Visible = false;
                        dead = true;
                        iFrame = true;
                        iframetimer.Start();

                        if (copy && playerCopy != null)
                        {
                            backgroundPanel.Controls.Remove(playerCopy.SpriteObject);
                            playerCopySprite.Visible = false;
                            playerCopy = null;
                            copy = false;
                        }
                    }
                    Hit = bullet;
                }
                if (copy && playerCopy != null && bullet.SpriteObject.Bounds.IntersectsWith(playerCopy.SpriteObject.Bounds))
                {
                    // Remove the player copy if hit
                    backgroundPanel.Controls.Remove(playerCopy.SpriteObject);
                    playerCopySprite.Visible = false;
                    playerCopy = null;
                    copy = false;

                    Hit = bullet;
                }

                if (!(bullet.WallCheck()))
                {
                    remove.Add(bullet);
                }
            }
            if (Hit != null)
            {
                backgroundPanel.Controls.Remove(Hit.SpriteObject);
                Enemy.enemyBullets.Remove(Hit);
            }
            foreach (Bullet bullet in remove)
            {
                backgroundPanel.Controls.Remove(bullet.SpriteObject);
                Enemy.enemyBullets.Remove(bullet);
            }
            remove.Clear();


        }

        private void Key_Down(object sender, KeyEventArgs e) // When Key is pressed
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = true;
                playerBox.Move(Keys.Left);
                if (copy && playerCopy != null)
                {
                    playerCopy.Move(Keys.Left);
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = true;
                playerBox.Move(Keys.Right);
                if (copy && playerCopy != null)
                {
                    playerCopy.Move(Keys.Right);
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                moveUp = true;
                playerBox.Move(Keys.Up);
                if (copy && playerCopy != null)
                {
                    playerCopy.Move(Keys.Up);
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                moveDown = true;
                playerBox.Move(Keys.Down);
                if (copy && playerCopy != null)
                {
                    playerCopy.Move(Keys.Down);
                }
            }
            if (e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
                if (!dead)
                {
                    playerBox.FireBullet(bullets);
                    if (copy && playerCopy != null)
                    {
                        playerCopy.FireBullet(bullets);
                    }
                }

            }


        }

        private void Key_Up(object sender, KeyEventArgs e) // When Key is let go
        {

            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                moveUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                moveDown = false;
            }

            if (moveLeft) playerBox.Move(Keys.Left);
            if (moveRight) playerBox.Move(Keys.Right);
            if (moveUp) playerBox.Move(Keys.Up);
            if (moveDown) playerBox.Move(Keys.Down);

            if (copy && playerCopy != null)
            {
                if (moveLeft) playerCopy.Move(Keys.Left);
                if (moveRight) playerCopy.Move(Keys.Right);
                if (moveUp) playerCopy.Move(Keys.Up);
                if (moveDown) playerCopy.Move(Keys.Down);
            }
        }


        private void ResizeHelp(object sender, EventArgs e)
        {
            if ((this.WindowState == FormWindowState.Maximized) != fullscreen)
            {
                ResizeThings();
                fullscreen = !fullscreen;
            }
        }



        private void ResizeThings()
        {
            backgroundPanel.Width = backgroundPanel.Height;

            if (backgroundPanel.Width > this.Width - WIDTH_OFFSET)
                this.Size = new Size(backgroundPanel.Width + WIDTH_OFFSET, this.Height);

            GameEntity.LeftCoord = ((this.Width - backgroundPanel.Width - WIDTH_OFFSET) / 2);
            //leftCoord = (this.Width - backgroundPanel.Width - WIDTH_OFFSET) / 2; 

            GameEntity.RightCoord = (GameEntity.LeftCoord + backgroundPanel.Width);
            //rightCoord = 1 - (this.Width - backgroundPanel.Width - WIDTH_OFFSET) / 2;

            GameEntity.BottomCoord = (Convert.ToInt32(backgroundPanel.Width / 1.2));
            //bottomCoord = Convert.ToInt32(backgroundPanel.Width / 1.2);

            backgroundPanel.Location = new Point(((int)GameEntity.LeftCoord), ((int)GameEntity.TopCoord));
            //backgroundPanel.Location = new Point(leftCoord, topCoord);
            scorePanel.Height = ((int)(backgroundPanel.Height - GameEntity.BottomCoord));
            //scorePanel.Height = backgroundPanel.Height - bottomCoord;



            if (this.Width - WIDTH_OFFSET < this.Height - HEIGHT_OFFSET)
            {
                this.Size = new Size(this.Height - HEIGHT_OFFSET + WIDTH_OFFSET, this.Height);
            }
            if (GameEntity.AllEntities != null)
            {
                foreach (GameEntity curEntity in GameEntity.AllEntities)
                {
                    if (curEntity != null)
                    {
                        curEntity.RefreshPos();
                    }
                }
            }
            // Calculate central area for label and button
            int centerY = backgroundPanel.Top + (backgroundPanel.Height / 2);

            // Resize and center labelGameStart
            //labelGameStart.AutoSize = false;
            labelGameStart.Size = new Size((int)(backgroundPanel.Width * 0.8), (int)(backgroundPanel.Height * 0.1));
            labelGameStart.TextAlign = ContentAlignment.MiddleCenter;
            labelGameStart.Location = new Point(
                (this.backgroundPanel.Width - labelGameStart.Width) / 2,
                centerY - labelGameStart.Height - 10 // slight offset upward
            );

            // Resize and center startGameButton just below the label

            startGameButton.Size = new Size((int)(backgroundPanel.Width * 0.5), (int)(backgroundPanel.Height * 0.08));
            startGameButton.Location = new Point(
                (this.backgroundPanel.Width - startGameButton.Width) / 2,
                labelGameStart.Bottom + 10
            );


            //resize and center credits button
            if(credits == true)
            {
                CreditsButton.Size = new Size((int)(backgroundPanel.Width * 0.25), (int)(backgroundPanel.Height * 0.04));
                CreditsButton.Location = new Point(
                    (this.backgroundPanel.Width - CreditsButton.Width) / 2,
                    (int)(backgroundPanel.Bottom * 0.75));
            }
            else
            {
                CreditsButton.Size = new Size((int)(backgroundPanel.Width * 0.5), (int)(backgroundPanel.Height * 0.08));
                CreditsButton.Location = new Point(
                    (this.backgroundPanel.Width - CreditsButton.Width) / 2,
                    startGameButton.Bottom + 10);
            }


            finalScore.Size = new Size((int)(backgroundPanel.Width * 0.5), (int)(backgroundPanel.Height * 0.15));
            finalScore.Location = new Point(
                (this.backgroundPanel.Width - finalScore.Width)/2,
                startGameButton.Bottom + 10
            );

            if (scorePanel.Height > 0 && customFonts != null)
            {
                startGameButton.Font = new Font(customFonts.Families[0], backgroundPanel.Height * 0.035f, FontStyle.Regular);
                if(credits == true)
                {
                    CreditsButton.Font = new Font(customFonts.Families[0], backgroundPanel.Height * 0.0175f, FontStyle.Regular);
                    finalScore.Font = new Font(customFonts.Families[0], backgroundPanel.Height * 0.0125f, FontStyle.Bold);

                }
                else
                {
                    CreditsButton.Font = new Font(customFonts.Families[0], backgroundPanel.Height * 0.035f, FontStyle.Regular);
                    finalScore.Font = new Font(customFonts.Families[0], backgroundPanel.Height * 0.02f, FontStyle.Bold);
                }

                labelGameStart.Font = new Font(customFonts.Families[0], backgroundPanel.Height * 0.04f, FontStyle.Bold);


                livesLabel.Font = new Font(customFonts.Families[0], ((float)(scorePanel.Height * 0.17)), livesLabel.Font.Style);
                livesLabel.Padding = new Padding(((int)(scorePanel.Width * 0.17)), ((int)(scorePanel.Height * 0.1)), 0, 0);

                scoreLabel.Font = new Font(customFonts.Families[0], ((float)(scorePanel.Height * 0.17)), scoreLabel.Font.Style);
                scoreLabel.Padding = new Padding(0, ((int)(scorePanel.Height * 0.1)), ((int)(scorePanel.Width * 0.17)), 0);
            }
            scorePanel.Padding = new Padding((int)(Math.Max((scorePanel.Height * 0.05), 1)));
        }

        private void iframetimer_Tick(object sender, EventArgs e)
        {
            switch (iFrameCounter)
            {
                case < 10:
                    playerBox.UpdatePos(5500, 8800);
                    break;
                case 10:
                    dead = false;
                    playerBox.SpriteObject.Visible = true;
                    break;
                case > 10 and < 30:
                    if (iFrameCounter % 2 == 0)
                    {
                        playerBox.SpriteObject.Visible = true;
                    }
                    else
                    {
                        playerBox.SpriteObject.Visible = false;
                    }
                    break;
                case 30:
                    playerBox.SpriteObject.Visible = true;
                    iframetimer.Stop();
                    dead = false;
                    iFrame = false;
                    iFrameCounter = 0;
                    break;

            }

            iFrameCounter++;
        }

        private void piercingTimer_Tick(object sender, EventArgs e)
        { //timer for piercing power up. BUT if we want we can repurpose it to be a generalized powerup timer. last 5 seconds, then disables itself
            //and returns character to base color.

            piercingPower = false;
            playerBox.SpriteObject.Image = Image.FromFile("Resources\\ship_sprite.png");
            piercingTimer.Enabled = false;
        }



        private void startGameButton_Click(object sender, EventArgs e)
        { //reset ANY AND ALL VARIABLES, other than gamestate, which it sets to 1
            gameState = 1;
            playerBox.lives = 5;
            livesLabel.Text = $"Lives: {Environment.NewLine} {playerBox.lives}";
            Enemy.GlobalScore = 0;
            scoreLabel.Text = $"Score: {Environment.NewLine} {Enemy.GlobalScore}";
            List<Bullet> allBullets = new List<Bullet>();
            foreach (Bullet b in bullets) //removing bullets on screen
            {
                allBullets.Add(b);
            }
            foreach (Bullet b in allBullets)
            {
                backgroundPanel.Controls.Remove(b.SpriteObject);
                bullets.Remove(b);
            }
            allBullets.Clear();
            foreach (Bullet b in Enemy.enemyBullets)
            {
                allBullets.Add(b);
            }
            foreach (Bullet b in allBullets)
            {
                backgroundPanel.Controls.Remove(b.SpriteObject);
                backgroundPanel.Controls.Remove(b.SpriteObject);

            }
            allBullets.Clear();
            List<Enemy> allEnemies = new List<Enemy>(); //resetting enemies
            foreach (Enemy en in Waves.currentEnemies)
            {
                allEnemies.Add(en);
            }
            foreach (Enemy en in allEnemies)
            {
                backgroundPanel.Controls.Remove(en.SpriteObject);
                Waves.currentEnemies.Remove(en);
            }
            allEnemies.Clear();
            Waves.resetWaves();
            playerBox.UpdatePos(5500, 8800);
            iFrame = false;
            piercingPower = false;
            sheild = false;
            foreach (Player p in players)
                p.resetShoot();
            firing = true;
            trishot = false;
            sheild = false;
            copy = false;

            if (playerCopy != null)
            {
                backgroundPanel.Controls.Remove(playerCopy.SpriteObject);
                playerCopy = null;
                playerCopySprite.Visible = false;
            }


            labelGameStart.Visible = false; startGameButton.Visible = false; startGameButton.Enabled = false; CreditsButton.Visible = false; CreditsButton.Enabled = false;
            scorePanel.Visible = true;
            playerSprite.Visible = true;
            playerCopySprite.Visible = false;
            backgroundPanel.SendToBack();
            ResizeThings();
        }

        private void trishotTimer_Tick(object sender, EventArgs e)
        {
            trishot = false;
            trishotTimer.Enabled = false;
        }

        private void doubleTick(object sender, EventArgs e)
        {
            copy = false;
            doubleTimer.Enabled = false;
            playerCopySprite.Enabled = false;
            playerCopySprite.Visible = false;
            playerCopy = null;

        }

        private void CreditsButton_Click(object sender, EventArgs e)
        {
            if (credits == false)
            {
                credits = true;
                startGameButton.Visible = false;
                finalScore.Visible = true;
                CreditsButton.Text = "Main Menu";
            }
            else
            {
                credits = false;
                startGameButton.Visible = true;
                finalScore.Visible= false;
                CreditsButton.Text = "Credits";
            }
            ResizeThings();
            return;
        }
    }

}
