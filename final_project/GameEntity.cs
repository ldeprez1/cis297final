namespace final_project;

using System;

public class GameEntity         // class for entities USE THIS FOR ENTITIES
{
    int xCoord; // 0 - 120
    int yCoord; // 0 - 100
    int realX;
    int realY;
    static int topCoord = 0;
    static int bottomCoord = 500;
    static int leftCoord = 0;
    static int rightCoord = 600;

    public static int GetTop() { return topCoord; }
    public static int GetBottom() { return bottomCoord; }
    public static int GetLeft() { return leftCoord; }
    public static int GetRight() { return rightCoord; }

    public static void SetTop(int x) { topCoord = x; }
    public static void SetBottom(int x) {  bottomCoord = x; }
    public static void Setleft(int x) {  leftCoord = x; }
    public static void SetRight(int x) { rightCoord = x; }

    protected PictureBox spriteObject;

    public GameEntity(int x, int y, PictureBox sprite) // create at location
    {
        xCoord = x;
        yCoord = y;
        spriteObject = sprite;
    }

    public GameEntity(PictureBox sprite) // create offscreen
    {
        xCoord = -1000; 
        yCoord = -1000;
        spriteObject = sprite;
    }

    public void UpdatePos(int x, int y) // CALL THIS FUNCTION FOR UPDATING POSITION
    {
        xCoord = x;
        yCoord = y;

        realX = ((rightCoord - leftCoord) / 120) * xCoord + leftCoord;
        realY = ((bottomCoord - topCoord) / 100) * yCoord + topCoord;

        spriteObject.Location = new Point(realX, realY);
    }
    
    public void UpdatePosRelative(int x, int y) // CALL THIS TO MOVE BY AN AMOUNT RELATIVE TO CURRENT LOCATION
    {
        UpdatePos(xCoord + x, yCoord + y);
    }
    public void RefreshPos()
    {
        UpdatePos(xCoord, yCoord);
    }
}
