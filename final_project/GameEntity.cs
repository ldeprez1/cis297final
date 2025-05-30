﻿namespace final_project;

using System;
using System.Drawing;
using System.Security.Policy;

public class GameEntity         // class for entities USE THIS FOR ENTITIES
{
    static protected int entityListSize = 20; //default list size
    public static GameEntity?[] AllEntities { get; private set; } = new GameEntity?[entityListSize];

    public PictureBox SpriteObject { get; set; }

    public static double TopCoord { get; set; } = 0;
    public static double BottomCoord { get; set; } = 0;
    public static double LeftCoord { get; set; } = 0;
    public static double RightCoord { get; set; } = 0;

    public const int MAX_XCOORD = 12000;
    public const int MAX_YCOORD = 10000;
    public const int MAX_WIDTH = 120;
    public const int MAX_HEIGHT = 100;
    public double xCoord { get; private set; } // 0 - 12000
    public double yCoord { get; private set; } // 0 - 10000
    public double width { get; private set; } // 0 - 120
    public double height { get; private set; } // 0 - 100

    protected int ID;


    public void UpdatePos(double x, double y) // CALL THIS FUNCTION FOR UPDATING POSITION
    {
        xCoord = x;
        yCoord = y;

        realX = ((RightCoord - LeftCoord)) * xCoord / MAX_XCOORD;
        realY = ((BottomCoord - TopCoord)) * yCoord / MAX_YCOORD;

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

        SpriteObject.Size = new Size(Math.Max(((int)(((RightCoord - LeftCoord)) * width / MAX_WIDTH)), 1), Math.Max(((int)(((BottomCoord - TopCoord)) * height / MAX_HEIGHT)), 1));
    }



    public GameEntity(double x, double y, PictureBox sprite, double width, double height) // create at location
    {
        xCoord = x;
        yCoord = y;
        SpriteObject = sprite;
        this.width = width;
        this.height = height;


        //realX = ((RightCoord - LeftCoord)) * xCoord / MAX_XCOORD;
        //realY = ((BottomCoord - TopCoord)) * yCoord / MAX_YCOORD;

        //SpriteObject.Location = new Point(((int)realX), ((int)realY));
        //SpriteObject.Size = new Size(((int)(((RightCoord - LeftCoord)) * width / MAX_WIDTH)), ((int)(((BottomCoord - TopCoord)) * height / MAX_HEIGHT)));


        AddToList();

        RefreshPos();
    }

    public GameEntity(PictureBox sprite, double width, double height) // create offscreen
    {
        xCoord = -1000;
        yCoord = -1000;
        SpriteObject = sprite;
        this.width = width;
        this.height = height;


        //realX = ((RightCoord - LeftCoord)) * xCoord / MAX_XCOORD;
        //realY = ((BottomCoord - TopCoord)) * yCoord / MAX_YCOORD;

        //SpriteObject.Location = new Point(((int)realX), ((int)realY));
        //SpriteObject.Size = new Size(((int)(((RightCoord - LeftCoord)) * width / MAX_WIDTH)), ((int)(((BottomCoord - TopCoord)) * height / MAX_HEIGHT)));


        AddToList();

        RefreshPos();
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
                this.ID = i;
                return; //return id of the element !
            }
        }



        //if list is full
        int temp = entityListSize; //keep track of prior size
        Expand();
        AllEntities[temp] = this; //put in first newly expanded slot
        this.ID = temp;
        return;

    }

    private static void Expand() //doubles array size if full
    {
        GameEntity?[] newEntities = new GameEntity?[entityListSize * 2];

        for (int i = 0; i < entityListSize; i++)
        {
            newEntities[i] = AllEntities[i];
        }
        AllEntities = newEntities;
        entityListSize = entityListSize * 2;
    }

}
