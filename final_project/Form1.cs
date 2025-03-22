using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace final_project
{
    public partial class Form1 : Form
    {
        
        //form size
        const int HEIGHT_OFFSET = 39;
        const int WIDTH_OFFSET = 16;
        float scoreHeight;

        //for OBJECT PLACEMENT ==> CHANGE if default window size changes
        //int topCoord = 0;
        //int bottomCoord = 500;
        //int leftCoord = 0;
        //int rightCoord = 600;
        //for player movement
        public bool moveLeft;
        public bool moveRight;
        public int playerSpeed = 12;



        List<GameEntity> allEntities; // PLEASE ADD ALL ENTITIES TO THIS LIST WHEN CREATED

        //debug
        GameEntity testEntity;
        PrivateFontCollection customFonts;




        internal class Bullet : GameEntity
        {
            private int x, y, vX, vY; //x position, y position, velocity
            private PictureBox icon; //visually represents the bullet
            public Bullet() : base(0, 0, new PictureBox(), 10, 10)
            { // basic constructor
                x = 0; y = 0; vX = 0; vY = 0;
                icon = base.spriteObject;
            }
            public Bullet(int x, int y, int vX, int vY, PictureBox icon) : base(x, y, icon, 10, 10)
            { //specific constructor
                this.x = x;
                this.y = y;
                this.vX = vX;
                this.vY = vY;
                this.icon = icon;
            }
            public void SetAll(int x, int y, int vX, int vY, PictureBox icon)
            {
                this.x = x;
                this.y = y;
                this.vX = vX;
                this.vY = vY;
                this.icon = icon;
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
            { //when a bullet passes a wall, it will be teleported off screen in the top left corner of the screen until needed
                //returns true if bullet is still onScreen, else returns false
                if ((x + icon.Width < GetLeft() || y + icon.Height < GetTop()) || (x > GetRight() || y > GetBottom()))
                {
                    x = 0 - icon.Width;
                    y = 0 - icon.Height;
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
            playerBullet.SetAll(playerBulletTest.Location.X, playerBulletTest.Location.Y, 0, -1, playerBulletTest);
            allEntities = new List<GameEntity> { };


            //FONT
            customFonts = new PrivateFontCollection();
            customFonts.AddFontFile("Resources\\ka1.ttf");


            ResizeThings();


           
            //debug
            testEntity = new GameEntity(100, 500, testBox1, 10, 10);
            allEntities.Add(testEntity);
            label1.Text = AppDomain.CurrentDomain.BaseDirectory;

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        { //test to see
            if (e.KeyChar == ' ')
            {
                while (playerBullet.WallCheck())
                {
                    playerBullet.UpdatePos();
                }
            }
        }

        private void playerBulletTest_Click(object sender, EventArgs e)
        {

        }




        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            ResizeThings();
            //debug
            player.Location = new Point(((int)GameEntity.GetRight()), 50);
            //livesLabel.Text = "Left: " + GameEntity.GetLeft() + " Right: " + GameEntity.GetRight();

        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            /*if (this.Width - WIDTH_OFFSET < this.Height - HEIGHT_OFFSET)
            {
                this.Size = new Size(this.Height - HEIGHT_OFFSET + WIDTH_OFFSET, this.Height);
            }
            foreach(GameEntity curEntity in allEntities)
            {
                curEntity.RefreshPos();
            }
            //debug
            player.Location = new Point(((int)GameEntity.GetRight()), 50);
            label1.Text = "Left: " + GameEntity.GetLeft() + " Right: " + GameEntity.GetRight();*/
        }

        private void mainEventTimer(object sender, EventArgs e)
        {
            if (moveLeft)
            {
                player.Left -= playerSpeed;
            }
            if (moveRight)
            {
                player.Left += playerSpeed;
            }

        }

        private void Key_Down(object sender, KeyEventArgs e) // When Key is pressed
        {
            if (e.KeyCode == Keys.Left)
            {
                //moveLeft = true;
                //debug code
                testEntity.UpdatePosRelative(-100, 0);
                // testBox1.Size = new Size(testBox1.Width + 1, testBox1.Height + 1);
            }
            if (e.KeyCode == Keys.Right)
            {
                //moveRight = true;
                testEntity.UpdatePosRelative(100, 0);
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
            backgroundPanel.Width = backgroundPanel.Height;

            GameEntity.Setleft((this.Width - backgroundPanel.Width - WIDTH_OFFSET) / 2);
            //leftCoord = (this.Width - backgroundPanel.Width - WIDTH_OFFSET) / 2; 

            GameEntity.SetRight(GameEntity.GetLeft() + backgroundPanel.Width);
            //rightCoord = 1 - (this.Width - backgroundPanel.Width - WIDTH_OFFSET) / 2;

            GameEntity.SetBottom(Convert.ToInt32(backgroundPanel.Width / 1.2));
            //bottomCoord = Convert.ToInt32(backgroundPanel.Width / 1.2);

            backgroundPanel.Location = new Point(((int)GameEntity.GetLeft()), ((int)GameEntity.GetTop()));
            //backgroundPanel.Location = new Point(leftCoord, topCoord);
            scorePanel.Height = ((int)(backgroundPanel.Height - GameEntity.GetBottom()));
            //scorePanel.Height = backgroundPanel.Height - bottomCoord;

            if (this.Width - WIDTH_OFFSET < this.Height - HEIGHT_OFFSET)
            {
                this.Size = new Size(this.Height - HEIGHT_OFFSET + WIDTH_OFFSET, this.Height);
            }
            if (allEntities != null)
            {
                foreach (GameEntity curEntity in allEntities)
                {
                    curEntity.RefreshPos();
                }
            }

            if (scorePanel.Height > 0)
            {
                livesLabel.Font = new Font(customFonts.Families[0], ((float)(scorePanel.Height * 0.15)), livesLabel.Font.Style);
                livesLabel.Padding = new Padding(((int)(scorePanel.Width * 0.2)), ((int)(scorePanel.Height * 0.1)), 0, 0);

                scoreLabel.Font = new Font(customFonts.Families[0], ((float)(scorePanel.Height * 0.15)), scoreLabel.Font.Style);
                scoreLabel.Padding = new Padding(0, ((int)(scorePanel.Height * 0.1)), ((int)(scorePanel.Width * 0.2)), 0);
            }
        }


    }
}
