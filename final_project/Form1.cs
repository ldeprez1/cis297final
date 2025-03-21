namespace final_project
{
    public partial class Form1 : Form
    {
        //test 1
        //form size
        const int HEIGHT_OFFSET = 39;
        const int WIDTH_OFFSET = 16;

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

     

        internal class Bullet : GameEntity
        {
            private int x, y, vX, vY; //x position, y position, velocity
            private PictureBox icon; //visually represents the bullet
            public Bullet() : base(0, 0, new PictureBox())
            { // basic constructor
                x = 0; y = 0; vX = 0; vY = 0;
                icon = base.spriteObject;
            }
            public Bullet(int x, int y, int vX, int vY, PictureBox icon) : base(x, y, icon)
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
            backgroundPanel.Width = backgroundPanel.Height;

            GameEntity.Setleft((this.Width - backgroundPanel.Width - WIDTH_OFFSET) / 2);
            //leftCoord = (this.Width - backgroundPanel.Width - WIDTH_OFFSET) / 2; 

            GameEntity.SetRight(1 - (this.Width - backgroundPanel.Width - WIDTH_OFFSET) / 2);
            //rightCoord = 1 - (this.Width - backgroundPanel.Width - WIDTH_OFFSET) / 2;

            GameEntity.SetBottom(Convert.ToInt32(backgroundPanel.Width / 1.2));
            //bottomCoord = Convert.ToInt32(backgroundPanel.Width / 1.2);

            backgroundPanel.Location = new Point(GameEntity.GetLeft(), GameEntity.GetTop());
            //backgroundPanel.Location = new Point(leftCoord, topCoord);
            scorePanel.Height = backgroundPanel.Height - GameEntity.GetBottom();
            //scorePanel.Height = backgroundPanel.Height - bottomCoord;
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Width - WIDTH_OFFSET < this.Height - HEIGHT_OFFSET)
            {
                this.Size = new Size(this.Height - HEIGHT_OFFSET + WIDTH_OFFSET, this.Height);
            }
            foreach(GameEntity curEntity in allEntities)
            {
                curEntity.RefreshPos();
            }
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
                moveLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = true;
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


        

    }
}
