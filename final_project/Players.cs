namespace final_project;

using System;
using System.Drawing;
using System.Media;
using System.Security.Policy;
using static final_project.Form1;


public class Player : GameEntity
{
    public const double PlayerWidth = 10;  // Width of the player sprite
    public const double PlayerHeight = 10; // Height of the player sprite
    public const double playerSpeed = 80;
    bool playerCanShoot = true;
    System.Windows.Forms.Timer playerShoot = new System.Windows.Forms.Timer();
    static SoundPlayer gunshot = new SoundPlayer("Resources\\gunshot.wav");


    public Player(double x, double y, PictureBox sprite) : base(x, y, sprite, PlayerWidth, PlayerHeight)
    {
        SpriteObject.Image = Image.FromFile("Resources\\ship_sprite.png");
        SpriteObject.SizeMode = PictureBoxSizeMode.StretchImage;
        playerShoot.Interval = 300;
        playerShoot.Tick += new EventHandler(playerShoot_Tick);
    }

    private void playerShoot_Tick(object sender, EventArgs e)
    {
        playerCanShoot = true;
        playerShoot.Stop();
    }

    public void Move(Keys direction)
    {
        double dX = 0; //diagonal x
        double dY = 0; //diagonal y

        if (direction == Keys.Left)
        {
            dX = -playerSpeed;
        }
        if (direction == Keys.Right)
        {
            dX = playerSpeed;
        }
        if (direction == Keys.Up)
        {
            dY = -playerSpeed;
        }
        if (direction == Keys.Down)
        {
            dY = playerSpeed;
        }

        switch (direction)
        {
            case Keys.Left:
                if (xCoord > 0)
                {
                    UpdatePosRelative(dX, 0);  // Move left
                }
                break;
            case Keys.Right:
                if (xCoord + width * 100 < MAX_XCOORD)
                {
                    UpdatePosRelative(dX, 0);   // Move right
                }
                break;
            case Keys.Up:
                if (yCoord > TopCoord)
                {
                    UpdatePosRelative(0, dY);
                }
                break;
            case Keys.Down:
                if (yCoord + height * 100 + 100 < MAX_YCOORD)
                    UpdatePosRelative(0, dY);
                break;
        }
    }
    public void Refresh()
    {
        RefreshPos();
    }

    public void FireBullet(List<Bullet> bullets)
    {
        double playerX = xCoord + width / 2;
        double playerY = yCoord;

        //PictureBox bulletSprite = new PictureBox();

        if (playerCanShoot && bullets.Count < 3)
        {
            Bullet playerBullet = new Bullet((int)(playerX + (width * 50 - Bullet.bulletSizeX * 50)), (int)playerY - (Bullet.bulletSizeY * 100), 0, -150, SpriteObject.Parent, this, true);
            bullets.Add(playerBullet);
            gunshot.Play();
            playerCanShoot = false;
            playerShoot.Start();
        }
    }

    public void resetShoot()
    {
        playerCanShoot = true;
    }
}
