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

        //for player movement
        public bool moveLeft;
        public bool moveRight;
        public int playerSpeed = 12;

        //for custom fonts
        PrivateFontCollection customFonts;

        abstract public class DamagableEntity : GameEntity //inherited by generic enemy class, please have player class inherit this too
        {
            public static DamagableEntity[] DamagableEntities { get; private set; } = new DamagableEntity[damagableListSize]; //this is the list of all damagable entities
           
            abstract public void Hit(); //call when you hit an entity

            public DamagableEntity(double x, double y, PictureBox sprite, double width, double height) : base(x, y, sprite, width, height) { AddToList(); }

            public DamagableEntity(PictureBox sprite, double width, double height) : base(sprite, width, height) { AddToList(); }


            //internal use only
            private static int damagableListSize = entityListSize;
            private void AddToList() //adds new entity to list
            {
                for (int i = 0; i < damagableListSize; i++)
                {
                    if (DamagableEntities[i] == null)
                    {
                        DamagableEntities[i] = this;
                        return; //return id of the element !
                    }
                }



                //if list is full
                int temp = damagableListSize; //keep track of prior size
                Expand();
                AllEntities[temp] = this; //put in first newly expanded slot
                return;

            }
            private static void Expand() //doubles array size if full
            {
                DamagableEntity[] newEntities = new DamagableEntity[damagableListSize * 2];

                for (int i = 0; i < damagableListSize; i++)
                {
                    newEntities[i] = DamagableEntities[i];
                }
                DamagableEntities = newEntities;
                damagableListSize = damagableListSize * 2;
            }

        }



        internal class Bullet : GameEntity
        {
            private int x, y, vX, vY; //x position, y position, velocity
            private PictureBox icon, source; //visually represents the bullet
            private bool returnToSender;
            public Bullet() : base(0, 0, new PictureBox(), 10, 10)
            { // basic constructor
                x = 0; y = 0; vX = 0; vY = 0;
                icon = base.SpriteObject;
                source = base.SpriteObject;
                returnToSender = false;
            }
            public Bullet(int x, int y, int vX, int vY, PictureBox icon, PictureBox source, bool r2s) : base(x, y, icon, 10, 10)
            { //specific constructor
                this.x = x;
                this.y = y;
                this.vX = vX;
                this.vY = vY;
                this.icon = icon;
                this.source = source;
                returnToSender = r2s;
            }
            public void SetAll(int x, int y, int vX, int vY, PictureBox icon, PictureBox source, bool r2s)
            {
                this.x = x;
                this.y = y;
                this.vX = vX;
                this.vY = vY;
                this.icon = icon;
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
                if ((x + icon.Width < LeftCoord || y + icon.Height < TopCoord) || (x > RightCoord || y > BottomCoord))
                {
                    if (!returnToSender)
                    {
                        x = 0 - icon.Width;
                        y = 0 - icon.Height;
                    } else
                    {
                        x = source.Location.X + source.Width / 2;
                        y = source.Location.Y;
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
            playerBullet.SetAll(playerBulletTest.Location.X, playerBulletTest.Location.Y, 0, -1, playerBulletTest, player ,true);
            Enemy.ScoreLabel = scoreLabel;

            //FONT
            customFonts = new PrivateFontCollection();
            customFonts.AddFontFile("Resources\\ka1.ttf");

            ResizeThings();



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




        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            ResizeThings();
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
