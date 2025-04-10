namespace final_project;

using System;
using System.Drawing;
using System.Security.Policy;
using static final_project.Form1;

public class Bullet : GameEntity
{
    private int x, y, vX, vY; //x position, y position, velocity
                              //private PictureBox icon;
    GameEntity source; //visually represents the bullet
    private bool returnToSender;

    public const  int bulletSizeX = 2;
    public const int bulletSizeY = 5;
    public Bullet(Control parent, GameEntity source) : base(0, 0, new PictureBox(), 10, 10)
    { // basic constructor
        x = 0; y = 0; vX = 0; vY = 0;
        //icon = base.SpriteObject;
        this.source = source;
        SpriteObject.Parent = parent;
        SpriteObject.BackColor = Color.White;
        RefreshPos();


        returnToSender = false;

    }
    public Bullet(int x, int y, int vX, int vY, Control parent, GameEntity source, bool r2s) : base(x, y, new PictureBox(), bulletSizeX, bulletSizeY)
    { //specific constructor
        this.x = x;
        this.y = y;
        this.vX = vX;
        this.vY = vY;
        // this.icon = icon; base.SpriteObject = icon;


        SpriteObject.Parent = parent;
        SpriteObject.BackColor = Color.White;
        RefreshPos();

        base.UpdatePos(x, y);
        this.source = source;
        returnToSender = r2s;
    }
    public Bullet(int x, int y, int vX, int vY, int w, int h, Control parent, GameEntity source, bool r2s) : base(x, y, new PictureBox(), w, h)
    { //constructor with width and height
        this.x = x;
        this.y = y;
        this.vX = vX;
        this.vY = vY;
        // this.icon = icon; base.SpriteObject = icon;

        SpriteObject.Parent = parent;
        SpriteObject.BackColor = Color.White;
        RefreshPos();

        base.UpdatePos(x, y);
        this.source = source;
        returnToSender = r2s;
    }
    //public void SetAll(int x, int y, int vX, int vY, PictureBox icon, GameEntity source, bool r2s)
    //{
    //    this.x = x;
    //    this.y = y;
    //    this.vX = vX;
    //    this.vY = vY;
    //    this.icon = icon;
    //    base.SpriteObject = icon;
    //    base.UpdatePos(x, y);
    //    this.source = source;
    //    returnToSender = r2s;
    //}
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
        if ((base.xCoord + base.width < 0 || base.yCoord + base.height < 0) || (base.xCoord > GameEntity.MAX_XCOORD || base.yCoord > GameEntity.MAX_YCOORD))
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