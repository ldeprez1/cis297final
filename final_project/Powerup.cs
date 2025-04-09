namespace final_project;

using System;
using System.Drawing;
using System.Security.Policy;
using static final_project.Form1;

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
