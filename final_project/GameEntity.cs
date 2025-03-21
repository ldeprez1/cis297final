namespace final_project;

using System;

public class GameEntity         // class for entities USE THIS FOR ENTITIES
{
    double xCoord; // 0 - 12000
    double yCoord; // 0 - 10000
    double realX;
    double realY;
    static double topCoord = 0;
    static double bottomCoord = 0;
    static double leftCoord = 0;
    static double rightCoord = 0;
    double width; // 0 - 120
    double height; // 0 - 100

    public static double GetTop() { return topCoord; }
    public static double GetBottom() { return bottomCoord; }
    public static double GetLeft() { return leftCoord; }
    public static double GetRight() { return rightCoord; }

    public static void SetTop(double x) { topCoord = x; }
    public static void SetBottom(double x) {  bottomCoord = x; }
    public static void Setleft(double x) {  leftCoord = x; }
    public static void SetRight(double x) { rightCoord = x; }

    protected PictureBox spriteObject;

    public GameEntity(double x, double y, PictureBox sprite, double width, double height) // create at location
    {
        xCoord = x;
        yCoord = y;
        spriteObject = sprite;
        this.width = width;
        this.height = height;

        realX = ((rightCoord - leftCoord)) * xCoord / 12000;
        realY = ((bottomCoord - topCoord)) * yCoord / 10000;

        spriteObject.Location = new Point(((int)realX), ((int)realY));
        spriteObject.Size = new Size(((int)(((rightCoord - leftCoord)) * width / 120)), ((int)(((bottomCoord - topCoord)) * height / 100)));
    }

    public GameEntity(PictureBox sprite, double width, double height) // create offscreen
    {
        xCoord = -1000; 
        yCoord = -1000;
        spriteObject = sprite;
        this.width = width;
        this.height = height;

        realX = ((rightCoord - leftCoord)) * xCoord / 12000;
        realY = ((bottomCoord - topCoord)) * yCoord / 10000;

        spriteObject.Location = new Point(((int)realX), ((int)realY));
        spriteObject.Size = new Size(((int)(((rightCoord - leftCoord)) * width / 120)), ((int)(((bottomCoord - topCoord)) * height / 100)));
    }

    public void UpdatePos(double x, double y) // CALL THIS FUNCTION FOR UPDATING POSITION
    {
        xCoord = x;
        yCoord = y;

        realX = ((rightCoord - leftCoord)) * xCoord / 12000;
        realY = ((bottomCoord - topCoord)) * yCoord / 10000;

        spriteObject.Location = new Point(((int)realX), ((int)realY));
    }
    
    public void UpdatePosRelative(double x, double y) // CALL THIS TO MOVE BY AN AMOUNT RELATIVE TO CURRENT LOCATION
    {
        UpdatePos(xCoord + x, yCoord + y);
    }
    public void RefreshPos()
    {
        UpdatePos(xCoord, yCoord);

        //size

        spriteObject.Size = new Size(((int)(((rightCoord - leftCoord)) * width / 120)), ((int)(((bottomCoord - topCoord)) * height / 100)));

    }
}
