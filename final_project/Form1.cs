using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace final_project
{
    public partial class Form1 : Form
    {
        
        //form size
        const int HEIGHT_OFFSET = 39;
        const int WIDTH_OFFSET = 16;
        float scoreHeight;

        //for player movement
        public bool moveLeft;
        public bool moveRight;
        //public int playerSpeed = 12;
        private Player playerBox;

        //current score of the player
        static  public int playerScore = 0;


        //for custom fonts
        PrivateFontCollection customFonts;

        //for enemy management
        List<Enemy> currentEnemies;
        //for bullet checking
        List<Bullet> bullets;
        
        public class Player : GameEntity
        {
            public const double PlayerWidth = 10;  // Width of the player sprite
            public const double PlayerHeight = 10; // Height of the player sprite
            public const double playerSpeed = 60;

            public Player(double x, double y, PictureBox sprite) : base(x, y, sprite, PlayerWidth, PlayerHeight) { }

            public void Move(Keys direction)
            {
                switch (direction)
                {
                    case Keys.Left:
                        UpdatePosRelative(-playerSpeed, 0);  // Move left
                        break;
                    case Keys.Right:
                        UpdatePosRelative(playerSpeed, 0);   // Move right
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
                source = new GameEntity(0,0, SpriteObject, 10,10);
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
            public void SetAll(int x, int y, int vX, int vY, PictureBox icon, GameEntity source, bool r2s)
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
            }
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
                    } else
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
        Bullet playerBullet = new Bullet();
        

        public Form1()
        {
            InitializeComponent();
            mainTimer.Start();
            
            Enemy.ScoreLabel = scoreLabel;
            currentEnemies = new List<Enemy> { };
            currentEnemies.Add(new Enemy(testEnemyBox.Location.X*20, testEnemyBox.Location.Y, testEnemyBox, 10, 10, 600, 0, 25));
            bullets = new List<Bullet> { };
            bullets.Add(playerBullet);
            //FONT
            customFonts = new PrivateFontCollection();
            customFonts.AddFontFile("Resources\\ka1.ttf");
            //PictureBox playerSprite = new PictureBox(); // player sprite
            playerBox = new Player(5500, 8800, playerSprite); // player definition
            playerBullet.SetAll(playerBulletTest.Location.X * 20, playerBulletTest.Location.Y * 10, 0, -100, playerBulletTest, playerBox, true);
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

            foreach(Bullet bullet in bullets)
            { //updates all bullet positions
                bullet.UpdatePos();
                bullet.WallCheck();
            }
            Bullet? killedEnemy = null;
            try
            {
                foreach (Enemy enemy in currentEnemies)
                { //updates all enemy positions and then compares each enemy with all bullets
                    enemy.UpdatePos();
                    foreach (Bullet bullet in bullets)
                    {
                        if (bullet.SpriteObject.Bounds.IntersectsWith(enemy.SpriteObject.Bounds))
                        {
                            enemy.Hit();
                            killedEnemy = bullet;
                            currentEnemies.Remove(enemy);//will throw exception here
                        }
                    }
                }
            }
            catch(Exception) // delete the bullet that killed
            {
                if(killedEnemy != null)
                    bullets.Remove(killedEnemy);
            }
            label1.Text = $"Player bullet Pos: X:{playerBullet.xCoord} Y: {playerBullet.yCoord}";
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


    }
}
