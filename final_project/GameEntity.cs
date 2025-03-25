namespace final_project;

using System;
using System.Drawing;
using System.Security.Policy;

public class GameEntity         // class for entities USE THIS FOR ENTITIES
{
    static protected int entityListSize = 20; //default list size
    public static GameEntity[] AllEntities { get; private set; } = new GameEntity[entityListSize];

    public PictureBox SpriteObject { get; set; }

    public static double TopCoord { get; set; } = 0;
    public static double BottomCoord { get; set; } = 0;
    public static double LeftCoord { get; set; } = 0;
    public static double RightCoord { get; set; } = 0;

    public double xCoord { get; private set; } // 0 - 12000
    public double yCoord { get; private set; } // 0 - 10000
    public double width { get; private set; } // 0 - 120
    public double height { get; private set; } // 0 - 100


    public void UpdatePos(double x, double y) // CALL THIS FUNCTION FOR UPDATING POSITION
    {
        xCoord = x;
        yCoord = y;

        realX = ((RightCoord - LeftCoord)) * xCoord / 12000;
        realY = ((BottomCoord - TopCoord)) * yCoord / 10000;

        SpriteObject.Location = new Point(((int)realX), ((int)realY));
    }
    
    public void UpdatePosRelative(double x, double y) // CALL THIS TO MOVE BY AN AMOUNT RELATIVE TO CURRENT LOCATION
    {
        UpdatePos(xCoord + x, yCoord + y);
    }
    public void RefreshPos()
    {
        UpdatePos(xCoord, yCoord);

        //size

        SpriteObject.Size = new Size(((int)(((RightCoord - LeftCoord)) * width / 120)), ((int)(((BottomCoord - TopCoord)) * height / 100)));

    }



    public GameEntity(double x, double y, PictureBox sprite, double width, double height) // create at location
    {
        xCoord = x;
        yCoord = y;
        SpriteObject = sprite;
        this.width = width;
        this.height = height;

        realX = ((RightCoord - LeftCoord)) * xCoord / 12000;
        realY = ((BottomCoord - TopCoord)) * yCoord / 10000;

        SpriteObject.Location = new Point(((int)realX), ((int)realY));
        SpriteObject.Size = new Size(((int)(((RightCoord - LeftCoord)) * width / 120)), ((int)(((BottomCoord - TopCoord)) * height / 100)));

        AddToList();
    }

    public GameEntity(PictureBox sprite, double width, double height) // create offscreen
    {
        xCoord = -1000;
        yCoord = -1000;
        SpriteObject = sprite;
        this.width = width;
        this.height = height;

        realX = ((RightCoord - LeftCoord)) * xCoord / 12000;
        realY = ((BottomCoord - TopCoord)) * yCoord / 10000;

        SpriteObject.Location = new Point(((int)realX), ((int)realY));
        SpriteObject.Size = new Size(((int)(((RightCoord - LeftCoord)) * width / 120)), ((int)(((BottomCoord - TopCoord)) * height / 100)));

        AddToList();
    }





    //internal use only
    
    double realX;
    double realY;


    private void AddToList() //adds new game entity to list
    {
        for (int i = 0; i < entityListSize; i++)
        {
            if (AllEntities[i] == null)
            {
                AllEntities[i] = this;
                return; //return id of the element !
            }
        }



        //if list is full
        int temp = entityListSize; //keep track of prior size
        Expand();
        AllEntities[temp] = this; //put in first newly expanded slot
        return;

    }

    private static void Expand() //doubles array size if full
    {
        GameEntity[] newEntities = new GameEntity[entityListSize * 2];

        for (int i = 0; i < entityListSize; i++)
        {
            newEntities[i] = AllEntities[i];
        }
        AllEntities = newEntities;
        entityListSize = entityListSize * 2;
    }

}
