﻿using Galvaders.Properties;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static final_project.Form1;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace final_project
{
    abstract public class Enemy : GameEntity
    {
        public static Random rnd = new Random();

        protected int shootChance = 100; // 0 - 100


        public static Label? livesText;

        public bool boss = false;
        public int health = 0;

        public const int randStart = 0;
        public const int randEnd = 25;

        public static int bulletTimer = rnd.Next(0, randEnd);
        public static List<Bullet> enemyBullets { get; } = new List<Bullet>();
        public static int GlobalScore { get; set; } = 0;
        private static int livesScore = 0;
        public static Label? ScoreLabel { get; set; }

        public int score;


        public bool dead { get; private set; } = false; //please delete enemy objects when they are hit, but just in case

        public virtual void Shoot()
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
        virtual public void Hit() //call when you hit an enemy with a bullet
        {
            if (boss && health > 0)
            {
                health--;
                return;
            }


            if (!dead)
            {
                GlobalScore = GlobalScore + score;
                livesScore = livesScore + score;

                if(livesScore >= 16000)
                {
                    livesScore -= 16000;
                    playerBox.lives++;
                    livesText.Text = $"Lives: {Environment.NewLine} {playerBox.lives}";
                }


                if (ScoreLabel != null)
                    ScoreLabel.Text = "SCORE\r\n" + GlobalScore;

                //just in case it doesnt get deleted
                dead = true;
               // SpriteObject.Visible = false;
                AllEntities[ID] = null; // remove itself from the entities array
            }
        }

        public Enemy(double x, double y, PictureBox sprite, double width, double height, int score) : base(x, y, sprite, width, height)
        {
            this.score = score;
        }

        public Enemy(PictureBox sprite, double width, double height, int score) : base(sprite, width, height)
        {
            this.score = score;
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

        public GroupEnemy(int spawnx, int startx, int endx, int y, int speed, Control p, bool moveRight) : base(spawnx, y, new PictureBox(), 8, 8, 100)
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
        int bulletActiveFrames = 0;
        double destX, destY;
        Bullet assholeBeam;
        int speed;
        int shootPhase = 0;
        double yVal;
        bool canAttack = true;
        bool bulletActive = false;
        public ChaserEnemy(int spawnY, int speed, Control p, bool mL) : base((mL ? -800 : 12000), spawnY, new PictureBox(), 8, 8, 350)
        { //mL, aka moving left, determines if starting on the left or right side of the screen. no reason to set manually :)
            yVal = spawnY;
            SpriteObject.Parent = p;
            RefreshPos();
            this.speed = speed;
            SpriteObject.Image = Image.FromFile("Resources\\thatAsshole.png");
            SpriteObject.SizeMode = PictureBoxSizeMode.StretchImage;
            shootChance = 0;
        }
        public override void move()
        {
            
            double dx = 0, dy = 0;
                switch (shootPhase)
            {
                case 1:
                    //calculate the next point to move to
                    double currDistance = Math.Sqrt(Math.Pow(destX-xCoord,2)+Math.Pow(destY-yCoord, 2));
                    dx = (destX - xCoord) / currDistance;
                    dy = (destY - yCoord) / currDistance;
                    UpdatePosRelative(speed * dx, speed * dy);
                    if (yCoord > destY)
                    {
                        shootPhase = 2;
                    }
                    break;
                case 2:
                    if (!bulletActive)
                    {
                        assholeBeam = new Bullet((int)this.xCoord-300, (int)this.yCoord + (int)this.height, 0, 0, 15, 20, SpriteObject.Parent, this, true);
                        assholeBeam.SpriteObject.BackColor = Color.FromArgb(0, 0, 0, 0);
                        Enemy.enemyBullets.Add(assholeBeam);
                        assholeBeam.SpriteObject.Image = Image.FromFile("Resources\\assholeBeam.png");
                        assholeBeam.SpriteObject.SizeMode = PictureBoxSizeMode.StretchImage;
                        bulletActive = true;
                    }
                    
                   
                    shootPhase = 3;
                    break;

                case 3:
                    //go back to yVal
                    if(yCoord > yVal + 200) // 200 for a bit of a buffer so if spawned at top they dont go partially offscreen
                    {
                       UpdatePosRelative(0, speed * -1);
                    } else
                    {
                        shootPhase = 0;
                        canAttack = true;
                    }
                        
                    break;

                default: //back and forth behavior
                    UpdatePosRelative(speed, 0);
                    if ((xCoord + width * 100 < 0) || (xCoord > MAX_XCOORD))
                    { //switch speed if it goes offscreen
                        speed *= -1;
                    }
                    break;
            }
            if (bulletActive)
            {
                bulletActiveFrames++;
                if((bulletActiveFrames >= 25 || dead) && assholeBeam!= null)
                {
                    deleteBullet();
                    bulletActive = false;
                    bulletActiveFrames = 0;
                }
            }
            //unsure why they randomly decide to go offscreen. gonna add this here to remove them from the enemies list if they do. player gets no score. Bug into feature?
            if(yCoord < -100)
            {
                // Form1.killed.Add(this);
                //GlobalScore -= 350;
                speed *= -1;
            }
        }

        private void deleteBullet()
        {
            if (assholeBeam != null)
            {
                if (assholeBeam.SpriteObject.Parent != null)
                    assholeBeam.SpriteObject.Parent.Controls.Remove(assholeBeam.SpriteObject);
                enemyBullets.Remove(assholeBeam);
                assholeBeam = null;
            }
        }

        public override void Hit()
        {
            base.Hit();
            if (bulletActive) { deleteBullet(); return; }
        }

        override public void Shoot()
        {
            if (canAttack)
            {
                if (rnd.Next(0, 1001) > 995)
                {
                    destX = playerBox.xCoord; //only change player position when in normal movement phase!!
                    destY = playerBox.yCoord - 1000;
                    shootPhase = 1;
                    canAttack = false;
                }
            }
            
        }
    }
    public class Phaser : Enemy
    {
        private int frameCounter = 0;
        private const int teleportFrames = 30;
        public Phaser(int StartX, int StartY, Control p) : base(StartX, StartY, new PictureBox(), 8, 8, 250)
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
            System.Windows.Forms.Timer flicker = new System.Windows.Forms.Timer();
            flicker.Interval = 1;
            flicker.Tick += (s, ev) =>
            {
                SpriteObject.Visible = true;
                ((System.Windows.Forms.Timer)s!).Stop();
                ((System.Windows.Forms.Timer)s!).Dispose();
            };
            flicker.Start();

            double newX = rnd.Next(0, MAX_XCOORD - (int)(width * 100));
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

    public class SplitterEnemy : Enemy
    { //splitter enemy uses the same logic as the basic enemy for moving and being made. However, it is bigger, shoots 2 shots, and splits into 2 regular group enemies
        int startX;
        int endX;
        bool moveRight = true;
        int moveDown;
        int speed;
        public SplitterEnemy(int spawnx, int startx, int endx, int y, int speed, Control p, bool moveRight) : base(spawnx, y, new PictureBox(), 16, 16, 400)
        {
            this.moveRight = moveRight;
            SpriteObject.Parent = p;
            RefreshPos();
            //SpriteObject.BackColor = Color.MediumPurple;
            SpriteObject.Image = Image.FromFile("Resources\\splitterSprite.png");
            SpriteObject.SizeMode = PictureBoxSizeMode.StretchImage;
            this.speed = speed;
            startX = startx;
            endX = endx - 10 * 100; //subtract size times 100
        }
        override public void move()
        {

            if (moveRight)
            {
                if (moveDown > 0)
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
            else if (moveDown > 0)
            {
                if (yCoord < MAX_YCOORD - 1500 && yCoord > 0)
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
        public override void Shoot()
        {
            shootChance = 50;
            if (bulletTimer < 1)
            {
                if (rnd.Next(0, 101) < shootChance)
                {
                    Bullet enemyBullet1 = new Bullet((int)(xCoord - 10), (int)(yCoord + (height * 100)), 0, 150, SpriteObject.Parent, this, true);
                    Bullet enemyBullet2 = new Bullet((int)(xCoord + 1500), (int)(yCoord + (height * 100)), 0, 150, SpriteObject.Parent, this, true);
                    enemyBullets.Add(enemyBullet1);
                    enemyBullets.Add(enemyBullet2);
                }
                bulletTimer = rnd.Next(randStart * Waves.currentEnemies.Count, randEnd * Waves.currentEnemies.Count);
                return;
            }
            bulletTimer -= 1;
        }
        public override void Hit()
        {
            base.Hit();
            GroupEnemy e1 = new GroupEnemy((int)xCoord - 10, startX, endX, (int)(yCoord + (height * 100)), speed * 2, SpriteObject.Parent, false);
            GroupEnemy e2 = new GroupEnemy((int)xCoord + 1500, startX, endX, (int)(yCoord + (height * 100)), speed * 2, SpriteObject.Parent, true);
            Waves.currentEnemies.Add(e1);
            Waves.currentEnemies.Add(e2);
        }

    }



    public class Miniboss : Enemy
    {
        bool attacking = false;
        int atkCounter = 5;
        double yVal = 200;
        bool rightMove;
        int speed;

        public Miniboss(Control p) : base(3500, 200, new PictureBox(), 50, 50, Math.Min(((int)(Math.Log2((float)Waves.waveNum) * 10)) * 100, 10000))
        {
            SpriteObject.Parent = p;
            RefreshPos();
            SpriteObject.Image = Image.FromFile("Resources\\miniboss.png"); 
            SpriteObject.SizeMode = PictureBoxSizeMode.StretchImage;
            boss = true;
            health = Math.Min((int)(Math.Log2(Waves.waveNum / 2.0) * 5), 29); // max of 30 health
            speed = (int)(Math.Log2(Waves.waveNum * 2)) * 10;
            rightMove = rnd.Next(0, 2) == 0;
        }
        public override void move()
        {
            if(!attacking)
            {
                if(rightMove)
                {
                    UpdatePosRelative(speed, 0);
                    if(xCoord > MAX_XCOORD - 5000)
                        rightMove = false;
                }
                else
                {
                    UpdatePosRelative(speed * -1, 0);
                    if (xCoord < 0)
                        rightMove = true;
                }
            }
        }

        override public void Shoot()
        {
            base.Shoot();

            if (Waves.currentEnemies.Count < 2)
            {
                if (atkCounter <= 0)
                {


                    switch (rnd.Next(0, Math.Min((Waves.waveNum / 5), 2)))
                    {
                        case 0:
                            Waves.currentEnemies.Add(new Boulder(SpriteObject.Parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -1000, 2 * (int)(10 * Math.Log2(Waves.waveNum))));
                            Waves.currentEnemies.Add(new Boulder(SpriteObject.Parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -3000, 2 * (int)(10 * Math.Log2(Waves.waveNum))));
                            Waves.currentEnemies.Add(new Boulder(SpriteObject.Parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -5000, 2 * (int)(10 * Math.Log2(Waves.waveNum))));
                            Waves.currentEnemies.Add(new Boulder(SpriteObject.Parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -7000, 2 * (int)(10 * Math.Log2(Waves.waveNum))));
                            Waves.currentEnemies.Add(new Boulder(SpriteObject.Parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -9000, 2 * (int)(10 * Math.Log2(Waves.waveNum))));
                            break;
                        case 1:
                            Waves.currentEnemies.Add(new ChaserEnemy(0, 200, Waves.parent, true));
                            Waves.currentEnemies.Add(new ChaserEnemy(0, 200, Waves.parent, false));
                            Waves.currentEnemies.Add(new ChaserEnemy(500, 150, Waves.parent, true));
                            Waves.currentEnemies.Add(new ChaserEnemy(500, 150, Waves.parent, false));
                            break;
                    }

                    atkCounter = rnd.Next(0, 20);

                }
                else
                {
                    atkCounter--;
                }

            }

        }
    }



    public class Boulder : Enemy
    {
        int speed;
          
        public Boulder(Control p, double x, double y, int s) :  base(x, y, new PictureBox(), 10, 10, 50)
        {
            SpriteObject.Parent = p;
            RefreshPos();
            SpriteObject.Image = Image.FromFile("Resources\\boulder.png");
            SpriteObject.SizeMode = PictureBoxSizeMode.StretchImage;
            speed = s;
            boss = true;
            health = 4;
        }

        public override void Shoot()
        {
            return;
        }

        public override void move()
        {
            UpdatePosRelative(0, speed);
            if(yCoord > MAX_YCOORD)
            {
                score = 0; //no score if goes offscreen
                health = 0;
                Hit();
                if(SpriteObject.Parent != null)
                    SpriteObject.Parent.Controls.Remove(SpriteObject);
                Waves.currentEnemies.Remove(this);
            }
        }

    }

}
