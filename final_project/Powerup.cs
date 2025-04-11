namespace final_project;

using System;
using System.Drawing;
using System.Security.Policy;
using static final_project.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

public class Powerup : GameEntity
{
    private double v, xPos, yPos;
    public int type { get; set; }
    static Random rnd = new Random();
    GameEntity source;
    public bool active { get; set; }
    public Powerup(GameEntity source, Control parent) : base(0, 0, new PictureBox(), 0, 0)
    { //basic constructor
        v = 0; xPos = 0; yPos = 0;
        type = 0;
        active = false;
        this.source = source;
        SpriteObject.Parent = parent;
        SpriteObject.BackColor = Color.FromArgb(255, 0, 184, 37);
    }
    public Powerup(double v, double x, double y, int type, GameEntity source, Control parent) : base(x, y, new PictureBox(), 10, 10)
    { //more speccific constructor establishing 
        this.type = type;
        this.v = v; xPos = x; yPos = y;
        SetPos(x, y);
        active = false;
        switch (type)
        { //assign different colors to different powerups
            default:
                SpriteObject.BackColor = Color.FromArgb(255, 0, 184, 37);
                break;
        }
        this.source = source;
        SpriteObject.Parent = parent;
    }
    public Powerup(double v, double x, double y, int type, GameEntity source, Control parent, float w, float h) : base(x, y, new PictureBox(), w, h)
    { //same constructor as before but with width and height for baseclass stuff
        this.v = v; xPos = x; yPos = y;
        active = false;
        SetPos(x, y);
        this.type = type;
        switch (type)
        { //assign different colors to different powerups
            default:
                SpriteObject.BackColor = Color.FromArgb(255, 0, 184, 37);
                break;
        }
        this.source = source;
        SpriteObject.Parent = parent;
    }
    public void UpdatePos()
    {
        if (active)
        {
            base.UpdatePos(0, yCoord + v);
        }
        OOB();
    }
    public void SetPos(double x, double y)
    {
        xPos = x;
        yPos = y;
        base.UpdatePos(xPos, yPos);
    }
    static public bool DoesSpawn(int hit)
    {
        if (rnd.Next(0, 1001) >= hit)
        {
            return (true);
        }
        return (false);
    }
    private void OOB()
    { //out of bounds check. handled by class so we dont need to.
        if (yCoord > 12000) active = false;
    }
}
