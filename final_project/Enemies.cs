using final_project.Properties;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static final_project.Form1;

namespace final_project
{
    abstract public class Enemy : GameEntity
    {
        public static Random rnd = new Random();

        protected int shootChance = 100; // 0 - 100


        private const int randStart = 0;
        private const int randEnd = 25;

        private static int bulletTimer = rnd.Next(0, randEnd);
        public static List<Bullet> enemyBullets { get; } = new List<Bullet>();
        public static int GlobalScore { get; set; } = 0;
        public static Label? ScoreLabel { get; set; }

        int score;
        int vX { get; set; } 
        int vY { get; set; }

        public bool dead { get; private set; } = false; //please delete enemy objects when they are hit, but just in case

        public void Shoot()
        {
            if (bulletTimer < 1)
            {
                if(rnd.Next(0, 100) < shootChance)
                {
                    Bullet enemyBullet = new Bullet((int)(xCoord + (width * 50 - Bullet.bulletSizeX * 50)), (int)(yCoord + (height * 100)), 0, 150, SpriteObject.Parent, this, true);
                    enemyBullets.Add(enemyBullet);
                }
                bulletTimer = rnd.Next(randStart * Waves.currentEnemies.Count, randEnd * Waves.currentEnemies.Count);
                return;
            }
            bulletTimer -= 1;
        }
        public void Hit() //call when you hit an enemy with a bullet
        {
            if (!dead)
            {
                GlobalScore = GlobalScore + score;
                if (ScoreLabel != null)
                    ScoreLabel.Text = "SCORE\r\n" + GlobalScore;

                //just in case it doesnt get deleted
                dead = true;
               // SpriteObject.Visible = false;
                AllEntities[ID] = null; // remove itself from the entities array
            }
        }

        public Enemy(double x, double y, PictureBox sprite, double width, double height, int score, int vX, int vY) : base(x, y, sprite, width, height)
        {
            this.vX = vX;
            this.vY = vY;
            this.score = score;
        }

        public Enemy(PictureBox sprite, double width, double height, int score) : base(sprite, width, height)
        {
            this.score = score;
        }
        public void UpdatePos()
        { //velocity change
            base.UpdatePos(xCoord + vX, yCoord + vY);
        }

        abstract public void move();

    }

    //basic enemy type
    public class GroupEnemy : Enemy
    {
        int startX;
        int endX;
        bool moveRight = true;
        int moveDown;
        int speed;

        public GroupEnemy(int spawnx, int startx, int endx, int y, int speed, Control p, bool moveRight) : base(spawnx, y, new PictureBox(), 8, 8, 100, 0, 0)
        {
            this.moveRight = moveRight;
            SpriteObject.Parent = p;
            RefreshPos();
            //SpriteObject.BackColor = Color.MediumPurple;
            SpriteObject.Image = Image.FromFile("Resources\\enemyTest.png");
            SpriteObject.SizeMode = PictureBoxSizeMode.StretchImage;
            this.speed = speed;
            startX = startx;
            endX = endx - 10*100; //subtract size times 100
        }

        override public void move()
        {
            
            if(moveRight)
            {
                if(moveDown > 0)
                {
                    UpdatePosRelative(0, speed);
                    if (yCoord < MAX_YCOORD - 1500 && yCoord > 0)
                        moveDown--;
                    if (yCoord > MAX_YCOORD)
                        UpdatePos(xCoord, -800);
                }
                else if (xCoord < endX)
                {
                    UpdatePosRelative(speed, 0);
                }
                else
                {
                    moveRight = false;
                    moveDown = (12 * 100) / speed;
                }
            }
            else if(moveDown > 0)
            {
                if(yCoord < MAX_YCOORD - 1500 && yCoord > 0)
                    moveDown--;
                UpdatePosRelative(0, speed);
                if (yCoord > MAX_YCOORD)
                    UpdatePos(xCoord, -800);
            }
            else
            {
                if (xCoord > startX)
                {
                    UpdatePosRelative(speed * -1, 0);
                }
                else
                {
                    moveRight = true;
                    moveDown = (12 * 100) / speed;
                }
            }
        }



    }
    public class ChaserEnemy : Enemy
    {
        int speed;
        public ChaserEnemy(int spawnY, int speed, Control p, bool mL): base ((mL? -800: 12000), spawnY, new PictureBox(), 8, 8, 350, speed, 0)
        { //mL, aka moving left, determines if starting on the left or right side of the screen. no reason to set manually :)
            SpriteObject.Parent = p;
            RefreshPos();
            this.speed = speed;
            SpriteObject.Image = Image.FromFile("Resources\\thatAsshole.png");
            SpriteObject.SizeMode = PictureBoxSizeMode.StretchImage;
            shootChance = 0;
        }
        public override void move()
        {
            UpdatePos(xCoord + speed, 0);
            if ((xCoord + width * 100 < 0 ) || (xCoord > MAX_XCOORD) )
            { //switch speed if it goes offscreen
                speed *= -1;
            }
        }
    }
    public class Phaser : Enemy
    {
        private int frameCounter = 0;
        private const int teleportFrames = 30;
        public Phaser(int StartX, int StartY, Control p) : base(StartX, StartY, new PictureBox(), 8, 8, 500, 0, 0)
        {
            SpriteObject.Parent = p;
            RefreshPos();
            SpriteObject.Image = Image.FromFile("Resources\\phaser.png");
            SpriteObject.SizeMode = PictureBoxSizeMode.StretchImage;
            //SpriteObject.BackColor = Color.MediumPurple;

        }
        public void Teleport()
        {
            SpriteObject.Visible = false;
            System.Windows.Forms.Timer flickerBack = new System.Windows.Forms.Timer();
            flickerBack.Interval = 1;
            flickerBack.Tick += (s, ev) =>
            {
                SpriteObject.Visible = true;
                ((System.Windows.Forms.Timer)s!).Stop();
                ((System.Windows.Forms.Timer)s!).Dispose();
            };
            flickerBack.Start();

            double newX = rnd.Next(0, MAX_XCOORD - SpriteObject.Width * 100);
            double newY = rnd.Next(0, MAX_YCOORD / 2);
            UpdatePos(newX, newY);
        }
        public override void move()
        {

            frameCounter++;

            if (frameCounter >= teleportFrames)
            {
                frameCounter = 0;
                Teleport();
            }

        }
    }

}
