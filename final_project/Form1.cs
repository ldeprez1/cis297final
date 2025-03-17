namespace final_project
{
    public partial class Form1 : Form
    {
        internal class Bullet
        {
            private int x, y, vX, vY; //x position, y position, velocity
            private int wW, wH; //window width and height
            private PictureBox icon; //visually represents the bullet
            public Bullet()
            { // basic constructor
                x = 0; y = 0; vX = 0; vY = 0; wW = 0; wH = 0;
                icon = new PictureBox();
            }
            public Bullet(int x, int y, int vX, int vY, PictureBox icon, int wW, int wH)
            { //specific constructor
                this.x = x;
                this.y = y;
                this.vX = vX;
                this.vY = vY;
                this.icon = icon;
                this.wW = wW;
                this.wH = wH;
            }
            public void SetAll(int x, int y, int vX, int vY, PictureBox icon, int wW, int wH)
            {
                this.x = x;
                this.y = y;
                this.vX = vX;
                this.vY = vY;
                this.icon = icon;
                this.wW = wW;
                this.wH = wH;
            }
            public void SetPos(int x, int y)
            { //manually set position
                this.x = x;
                this.y = y;
            }
            public void UpdatePos()
            { //update the position based on the velocity of a the bullet, then sees if they hit a wall
                x += vX;
                y += vY;
                icon.Location = new Point(x, y);
            }
            public bool WallCheck()
            { //when a bullet passes a wall, it will be teleported off screen in the top left corner of the screen until needed
                //returns true if bullet is still onScreen, else returns false
                if ((x + icon.Width < 0 || y + icon.Height < 0) || (x > wW || y > wH))
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
            playerBullet.SetAll(playerBulletTest.Location.X, playerBulletTest.Location.Y, 1, -2, playerBulletTest, this.Width, this.Height);
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
    }
}
