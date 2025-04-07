using System.Drawing.Text;
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
        public class Powerup : GameEntity
        {
            private float v, xPos, yPos;
            public int type { get; set; }
            private PictureBox icon;
            static Random rnd = new Random();
            public bool active { get; set; }
            public Powerup() : base(0, 0, new PictureBox(), 0, 0)
            { //basic constructor
                v = 0; xPos = 0; yPos = 0;
                type = 0;
                icon = base.SpriteObject;
                active = false;
            }
            public Powerup(float v, float x, float y, int type, PictureBox icon) : base(x, y, icon, 10, 10)
            { //more speccific constructor establishing 
                this.type = type;
                this.v = v; xPos = x; yPos = y;
                this.icon = icon;
                SetPos(x, y);
                active = false;
            }
            public Powerup(float v, float x, float y, int type, PictureBox icon, float w, float h) : base(x, y, icon, w, h)
            { //same constructor as before but with width and height for baseclass stuff
                this.v = v; xPos = x; yPos = y;
                this.icon = icon;
                active = false;
                SetPos(x, y);
                this.type = type;
            }
            public void UpdatePos()
            {
                if (active)
                {
                    base.UpdatePos(0, yCoord + v);
                }
                OOB();
            }
            public void SetPos(float x, float y)
            {
                xPos = x;
                yPos = y;
                base.UpdatePos(xPos, yPos);
            }
            public void DoesSpawn(int hit, float x, float y)
            {
                if (rnd.Next(0, 1001) >= hit)
                {
                    SetPos(x, y);
                    active = true;
                }
            }
            private void OOB()
            { //out of bounds check. handled by class so we dont need to.
                if (yCoord > 12000) active = false;
            }
        }

        /*
          
         move player up and down too?
        bound player movement by the edges
          
         */


        /*
          
         enemy movement controlled by waves/groups? 
         to avoid collisions between multiple of same enemy type
          
         */

        //form size


        int HEIGHT_OFFSET = 56;
        int WIDTH_OFFSET = 22;
        float scoreHeight;
        int iFrameCounter = 0;
        //for player movement
        public bool moveLeft;
        public bool moveRight;
        public bool iFrame = false;
        public bool piercingPower = false;
        public bool firing = true;
        //public int playerSpeed = 12;
        private Player playerBox;

        //current score of the player
        static public int playerScore = 0;


        //for custom fonts
        PrivateFontCollection customFonts;

        //for enemy management
        List<Enemy> currentEnemies;
        //for bullet checking
        List<Bullet> bullets;
        List<Bullet> enemyBullets;
        //for powerup movements
        List<Powerup> powerups;

        public class Player : GameEntity
        {
            public const double PlayerWidth = 10;  // Width of the player sprite
            public const double PlayerHeight = 10; // Height of the player sprite
            public const double playerSpeed = 120;

            public Player(double x, double y, PictureBox sprite) : base(x, y, sprite, PlayerWidth, PlayerHeight) { }

            public void Move(Keys direction)
            {
                switch (direction)
                {
                    case Keys.Left:
                        if (xCoord > 0)
                        {
                            UpdatePosRelative(-playerSpeed, 0);  // Move left
                        }
                        break;
                    case Keys.Right:
                        if (xCoord + width < 11000)
                        {
                            UpdatePosRelative(playerSpeed, 0);   // Move right
                        }
                        break;
                    case Keys.Up:
                        if (yCoord > TopCoord)
                        {
                            UpdatePosRelative(0, -playerSpeed);
                        }
                        break;
                    case Keys.Down:
                        if (yCoord + height < 8940)
                            UpdatePosRelative(0, playerSpeed);
                        break;
                }
            }
            public void Refresh()
            {
                RefreshPos();
            }

        }
        internal class Bullet : GameEntity
        {
            private int x, y, vX, vY; //x position, y position, velocity
            private PictureBox icon;
            GameEntity source; //visually represents the bullet
            private bool returnToSender;
            public Bullet() : base(0, 0, new PictureBox(), 10, 10)
            { // basic constructor
                x = 0; y = 0; vX = 0; vY = 0;
                icon = base.SpriteObject;
                source = new GameEntity(0, 0, SpriteObject, 10, 10);
                returnToSender = false;
            }
            public Bullet(int x, int y, int vX, int vY, PictureBox icon, GameEntity source, bool r2s) : base(x, y, icon, 10, 10)
            { //specific constructor
                this.x = x;
                this.y = y;
                this.vX = vX;
                this.vY = vY;
                this.icon = icon; base.SpriteObject = icon;
                base.UpdatePos(x, y);
                this.source = source;
                returnToSender = r2s;
            }
            public Bullet(int x, int y, int vX, int vY, int w, int h, PictureBox icon, GameEntity source, bool r2s) : base(x, y, icon, w, h)
            { //constructor with width and height
                this.x = x;
                this.y = y;
                this.vX = vX;
                this.vY = vY;
                this.icon = icon; base.SpriteObject = icon;
                base.UpdatePos(x, y);
                this.source = source;
                returnToSender = r2s;
            }
            /*public void SetAll(int x, int y, int vX, int vY, PictureBox icon, GameEntity source, bool r2s)
            {
                this.x = x;
                this.y = y;
                this.vX = vX;
                this.vY = vY;
                this.icon = icon;
                base.SpriteObject = icon;
                base.UpdatePos(x, y);
                this.source = source;
                returnToSender = r2s;
            }*/
            public void SetPos(int x, int y)
            { //manually set position
                this.x = x;
                this.y = y;
                base.UpdatePos(x, y);
            }
            public void UpdatePos()
            { //update the position based on the velocity of a the bullet, then sees if they hit a wall
                x += vX;
                y += vY;
                base.UpdatePos(x, y);
            }
            public bool WallCheck()
            { /*
               * when a bullet passes the screen it will either be warped offscreen to the top right of the screen if returnToSender is
               * false, or to (x = Middle of Source, y = Same as source). To make sure things look right visually, make sure that
               * all sources are layered above their respective bullets
               */
                if ((base.xCoord + base.width < 0 || base.yCoord + base.height < 0) || (base.xCoord > 12000 || base.yCoord > 10000))
                {
                    if (!returnToSender)
                    {
                        x = 0 - (int)source.width;
                        y = 0 - (int)source.height;
                    }
                    else
                    {
                        x = (int)(source.xCoord + source.width / 2);
                        y = (int)source.yCoord;
                    }
                    SetPos(x, y);
                    return false;
                }
                return true;
            }
        }
        //Bullet playerBullet = new Bullet();
        Bullet testBullet;


        public Form1()
        {
            InitializeComponent();
            mainTimer.Start();

            //might help fix any offsets
            HEIGHT_OFFSET = this.Height - this.backgroundPanel.Height;
            WIDTH_OFFSET = this.Width - this.backgroundPanel.Width;

            this.backgroundPanel.Dock = DockStyle.None;
            this.backgroundPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            this.backgroundPanel.Height = this.Height - HEIGHT_OFFSET;
            this.backgroundPanel.Width = this.backgroundPanel.Height;
            this.backgroundPanel.Location = new Point((this.Width - this.backgroundPanel.Width - HEIGHT_OFFSET) / 2, 0);
            this.scorePanel.Height = this.backgroundPanel.Height / 6;

            Enemy.ScoreLabel = scoreLabel;
            currentEnemies = new List<Enemy> { };
            currentEnemies.Add(new Enemy(testEnemyBox.Location.X * 20, testEnemyBox.Location.Y, testEnemyBox, 10, 10, 600, 0, 25));
            testBullet = new Bullet((int)currentEnemies.ElementAt<Enemy>(0).xCoord, (int)currentEnemies.ElementAt<Enemy>(0).yCoord, 0, 100, enemyTestBullet, currentEnemies.ElementAt<Enemy>(0), true); //creates a test bullet with source of enemy 1
            bullets = new List<Bullet> { };
            powerups = new List<Powerup>();
            enemyBullets = new List<Bullet>();
            enemyBullets.Add(testBullet);
            //bullets.Add(playerBullet);
            powerups.Add(new Powerup(4, 5500, 100, 0, powerUpBoxTest, 10, 10));
            powerups.ElementAt<Powerup>(0).active = true;
            //FONT
            customFonts = new PrivateFontCollection();
            customFonts.AddFontFile("Resources\\ka1.ttf");
            //PictureBox playerSprite = new PictureBox(); // player sprite
            playerBox = new Player(5500, 8800, playerSprite); // player definition
            //playerBullet.SetAll(playerBulletTest.Location.X * 20, playerBulletTest.Location.Y * 10, 0, -100, playerBulletTest, playerBox, true);
            //Controls.Add(playerSprite); //no idea wtf this does but it broke something
            playerSprite.BringToFront();
            ResizeThings();

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        { //test to see

        }




        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            ResizeThings();
        }


        private void mainEventTimer(object sender, EventArgs e)
        {
            foreach (Powerup powerup in powerups)
            { //update position of any active powerups. Active status is false by default, can be manually set. check for Active is in the class itself :>
                powerup.UpdatePos();
                if (powerup.SpriteObject.Bounds.IntersectsWith(playerBox.SpriteObject.Bounds))
                { 
                    powerup.SetPos(-9000, -9000);
                    powerup.active = false;
                    switch (powerup.type)
                    {
                        default:
                            //case 0 and default case, piercing
                            piercingPower = true;
                            piercingTimer.Enabled = true;
                            playerBox.SpriteObject.BackColor = Color.FromArgb(255, 10, 0, 156);
                            break;
                    }
                }
            }
            foreach (Bullet bullet in bullets)
            { //updates all player bullet positions
                bullet.UpdatePos();
                bullet.WallCheck();
            }
            Bullet? killedEnemy = null;
            try
            {
                foreach (Enemy enemy in currentEnemies)
                { //updates all enemy positions and then compares each enemy with player bullets
                    enemy.UpdatePos();
                    if (enemy.SpriteObject.Bounds.IntersectsWith(playerBox.SpriteObject.Bounds) && !iFrame) //check for collisions between player and enemies
                    {
                        iframetimer.Start();
                        iFrame = true;
                    }
                    foreach (Bullet bullet in bullets)
                    {
                        enemy.Hit();
                        currentEnemies.Remove(enemy);
                        if (bullet.SpriteObject.Bounds.IntersectsWith(enemy.SpriteObject.Bounds))
                        {
                            enemy.Hit();
                            killedEnemy = bullet;
                            currentEnemies.Remove(enemy);//will throw exception here
                        }
                    }
                }
            }
            catch (Exception) // delete the bullet that killed
            {
                if (killedEnemy != null && !piercingPower) //but only when the piercing powerup is not enabled :>
                    bullets.Remove(killedEnemy);
            }
            //label1.Text = $"Player bullet Pos: X:{playerBullet.xCoord} Y: {playerBullet.yCoord}";
            //bullets if for PlayerBullets. enemy bullets is for enemy bullets
            foreach (Bullet bullet in enemyBullets)
            { //updates enemy bullets and then checks for collisions
                bullet.UpdatePos();
                if (bullet.SpriteObject.Bounds.IntersectsWith(playerBox.SpriteObject.Bounds) && !iFrame)
                {
                    iframetimer.Start();
                    iFrame = true;
                }
            }
        }
        private void FireBullet()
        {
            double playerX = playerBox.xCoord + playerBox.width / 2;
            double playerY = playerBox.yCoord;

            //PictureBox bulletSprite = new PictureBox();
            


            Bullet playerBullet = new Bullet((int)playerX, (int)playerY, 0, -100, playerBulletTest, playerBox, true);
            bullets.Add(playerBullet);

        }
        private void Key_Down(object sender, KeyEventArgs e) // When Key is pressed
        {
            if (e.KeyCode == Keys.Left)
            {
                // moveLeft = true;
                playerBox.Move(Keys.Left);

            }
            if (e.KeyCode == Keys.Right)
            {
                //moveRight = true;
                playerBox.Move(Keys.Right);
            }
            if (e.KeyCode == Keys.Up)
            {
                playerBox.Move(Keys.Up);
            }
            if (e.KeyCode == Keys.Down)
            {
                playerBox.Move(Keys.Down);
            }
            if (e.KeyCode == Keys.Space && firing)
            {
                FireBullet();
               
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
            if(e.KeyCode == Keys.Space)
            {
                
            }
        }

        private void ResizeThings()
        {
            this.MinimumSize = new Size(this.Height - HEIGHT_OFFSET + WIDTH_OFFSET, 0);

            backgroundPanel.Width = backgroundPanel.Height;

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
                livesLabel.Font = new Font(customFonts.Families[0], ((float)(scorePanel.Height * 0.15)), livesLabel.Font.Style);
                livesLabel.Padding = new Padding(((int)(scorePanel.Width * 0.2)), ((int)(scorePanel.Height * 0.1)), 0, 0);

                scoreLabel.Font = new Font(customFonts.Families[0], ((float)(scorePanel.Height * 0.15)), scoreLabel.Font.Style);
                scoreLabel.Padding = new Padding(0, ((int)(scorePanel.Height * 0.1)), ((int)(scorePanel.Width * 0.2)), 0);
            }
        }

        private void iframetimer_Tick(object sender, EventArgs e)
        {
            if (iFrameCounter % 2 == 0)
            { //if the iframe counter is odd, transparency is set to half
                playerBox.SpriteObject.BackColor = Color.FromArgb(127, 255, 255, 255);
            }
            else
            { //otherwise full
                playerBox.SpriteObject.BackColor = Color.FromArgb(255, 255, 255, 255);
            }
            iFrameCounter++;
            if (iFrameCounter < 10)
            { //less than 1 second, player is moved to the original spawn, and invisible
                playerBox.SpriteObject.BackColor = Color.FromArgb(0, 255, 255, 255);
                playerBox.UpdatePos(5500, 8800);
            } //remaining 2 sec of iframes do nothing special
            if (iFrameCounter == 30)
            { //after 3 seconds, iframes turn off and the counter resets
                iframetimer.Stop();
                iFrame = false;
                iFrameCounter = 0;
            }
        }

        private void piercingTimer_Tick(object sender, EventArgs e)
        { //timer for piercing power up. BUT if we want we can repurpose it to be a generalized powerup timer. last 5 seconds, then disables itself
            //and returns character to base color.

            piercingPower = false;
            playerBox.SpriteObject.BackColor = Color.FromArgb(255, 255, 255, 255);
            piercingTimer.Enabled = false;
        }
    }
}
