namespace final_project;

using System;
using System.Drawing;
using System.Security.Policy;

public class GameEntity         // class for entities USE THIS FOR ENTITIES
{
    static int entityListSize = 20;
    public static GameEntity[] allEntities { get; private set; } = new GameEntity[entityListSize];

    int ID;

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

        addToList();
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

        addToList();
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




    //internal use only

    private void addToList() //adds new game entity to list
    {
        for (int i = 0; i < entityListSize; i++)
        {
            if (allEntities[i] == null)
            {
                allEntities[i] = this;
                return; //return id of the element !
            }
        }



        //if list is full
        int temp = entityListSize; //keep track of prior size
        expand();
        allEntities[temp] = this; //put in first newly expanded slot
        return;

    }

    private static void expand() //doubles array size if full
    {
        GameEntity[] newEntities = new GameEntity[entityListSize * 2];

        for (int i = 0; i < entityListSize; i++)
        {
            newEntities[i] = allEntities[i];
        }
        allEntities = newEntities;
        entityListSize = entityListSize * 2;
    }

}
