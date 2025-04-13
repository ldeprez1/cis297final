using final_project.Properties;
using System.Drawing.Text;
using System.Media;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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



        int gameState = 0;

        //current score of the player
        static public int playerScore = 0;

        //for when player is hit
        int lives = 9;
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


        //for custom fonts
        PrivateFontCollection customFonts;

        //for bullet checking
        List<Bullet> bullets;

        //for powerup movements
        List<Powerup> powerups;

        //for player/players
        public static Player playerBox;
        List<Player> players = new List<Player>();

        public Form1()
        {
            InitializeComponent();
            mainTimer.Start();

            Waves.parent = this.backgroundPanel; //set parent for wave functions

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

            //bullet setup
            bullets = new List<Bullet> { };

            //powerup setup
            powerups = new List<Powerup>();

            //FONT setup
            customFonts = new PrivateFontCollection();
            customFonts.AddFontFile("Resources\\ka1.ttf");
            
            //player setup
            playerBox = new Player(5500, 8800, playerSprite);
            players = new List<Player>();
            players.Add(playerBox);
            //playerSprite.BringToFront();
            Waves.currentEnemies.Add(new ChaserEnemy(0, 200, Waves.parent, true));
           Waves.currentEnemies.Add(new ChaserEnemy(0, 200, Waves.parent, false));
            Waves.currentEnemies.Add(new Phaser(5000, 800, Waves.parent));
            ResizeThings();




            //test code

        }


        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            ResizeThings();
        }


        private void mainEventTimer(object sender, EventArgs e)
        {
            CheckGameState();

            //move player
            if (moveLeft) playerBox.Move(Keys.Left);
            if (moveRight) playerBox.Move(Keys.Right);
            if (moveUp) playerBox.Move(Keys.Up);
            if (moveDown) playerBox.Move(Keys.Down);

            if (Waves.currentEnemies.Count == 0)
                Waves.nextWave();
        }

        private void CheckGameState()
        { //checks GameState. Default, Zero, is to START THE GAME. One Calls to update all sprite locations and run collision calculations. 2 is GAME OVER
            switch (gameState)
            {
                case 1:
                    labelGameStart.Visible = false; startGameButton.Visible = false; startGameButton.Enabled = false;
                    backgroundPanel.SendToBack();
                    RunGameLogic();
                    break;
                case 2:
                    backgroundPanel.BringToFront();
                    labelGameStart.BringToFront(); startGameButton.BringToFront(); labelGameStart.Visible = true; startGameButton.Visible = true; startGameButton.Enabled = true;
                    labelGameStart.Text = "GAME OVER! Try Again?";
                    break;
                default:
                    backgroundPanel.BringToFront();
                    labelGameStart.BringToFront(); startGameButton.BringToFront(); labelGameStart.Visible = true; startGameButton.Visible = true; startGameButton.Enabled = true;
                    labelGameStart.Text = "Welcome to Galaga-Like!";
                    break;
            }
        }
        private void RunGameLogic()
        {
            if (lives == 0)
            { //immediately stops this entire thing if lives becomes 0
                gameState = 2;
                return;
            }
            List<Powerup> toRemove = new List<Powerup>();
            foreach (Powerup powerup in powerups)
            { //update position of any active powerups. Active status is false by default, can be manually set. check for Active is in the class itself :>
                powerup.UpdatePos();
                if (powerup.SpriteObject.Bounds.IntersectsWith(playerBox.SpriteObject.Bounds))
                {
                    toRemove.Add(powerup);
                    switch (powerup.type)
                    {
                        default:
                            //case 0 and default case, piercing
                            piercingPower = true;
                            piercingTimer.Enabled = true;
                            playerBox.SpriteObject.Image = Image.FromFile("Resources\\ship_sprite_powerup.png");
                            break;
                    }
                }
            }
            toRemove.Clear();
            List<Bullet> remove = new List<Bullet>();
            foreach (Bullet bullet in bullets)
            { //updates all player bullet positions
                bullet.UpdatePos();
                if (!(bullet.WallCheck()))
                {
                    remove.Add(bullet);
                }
            }


            List<Enemy> killed = new List<Enemy>();


            foreach (Enemy enemy in Waves.currentEnemies)
            { //updates all enemy positions and then compares each enemy with player bullets
                enemy.move();
                enemy.Shoot();
                if (enemy.SpriteObject.Bounds.IntersectsWith(playerBox.SpriteObject.Bounds) && !iFrame) //check for collisions between player and enemies
                {
                    lives--;
                    livesLabel.Text = $"Lives: {Environment.NewLine} {lives}";
                    playerBox.SpriteObject.Visible = false;
                    iframetimer.Start();
                    iFrame = true;
                    dead = true;
                }
                foreach (Bullet bullet in bullets)
                {
                    if (bullet.SpriteObject.Bounds.IntersectsWith(enemy.SpriteObject.Bounds))
                    {
                        killed.Add(enemy);
                        remove.Add(bullet);
                        if (Powerup.DoesSpawn(0))
                        {
                            Powerup p = new Powerup(enemy.xCoord, enemy.yCoord, 5, 0, enemy, enemy.SpriteObject.Parent);
                            p.SetPos(enemy.xCoord, enemy.yCoord);
                            p.active = true;
                            powerups.Add(p);
                        }
                    }
                }
            }


            if (!piercingPower)
            {
                foreach (Enemy enemy in killed)
                {
                    enemy.Hit();
                    backgroundPanel.Controls.Remove(enemy.SpriteObject);
                    Waves.currentEnemies.Remove(enemy);
                }
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
                    lives--;
                    livesLabel.Text = $"Lives: {Environment.NewLine} {lives}";
                    iframetimer.Start();
                    playerBox.SpriteObject.Visible = false;
                    dead = true;
                    iFrame = true;
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

            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = true;
                playerBox.Move(Keys.Right);
            }
            if (e.KeyCode == Keys.Up)
            {
                moveUp = true;
                playerBox.Move(Keys.Up);
            }
            if (e.KeyCode == Keys.Down)
            {   
                moveDown = true;
                playerBox.Move(Keys.Down);
            }
            if (e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
                if (!dead)
                {
                    playerBox.FireBullet(bullets);
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

            if (scorePanel.Height > 0 && customFonts != null)
            {
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
                    iFrameCounter++;
                    break;
                case 10:
                    dead = false;
                    playerBox.SpriteObject.Visible = true;
                    iFrameCounter++;
                    break;
                case > 10 and < 30:
                    if(iFrameCounter % 2 == 0)
                    {
                        playerBox.SpriteObject.Visible = true;
                    }
                    else
                    {
                        playerBox.SpriteObject.Visible = false;
                    }
                    iFrameCounter++;
                    break;
                case 30:
                    playerBox.SpriteObject.Visible = true;
                    iframetimer.Stop();
                    iFrame = false;
                    iFrameCounter = 0;
                    break;
            }
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
            lives = 9;
            livesLabel.Text = $"Lives: {Environment.NewLine} {lives}";
            playerScore = 0;
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
            playerBox.UpdatePos(5500, 8800);
            iFrame = false;
            piercingPower = false;
            foreach (Player p in players)
                p.resetShoot();
            firing = true;

        }
    }

}
