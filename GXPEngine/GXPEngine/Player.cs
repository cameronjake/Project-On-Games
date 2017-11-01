 using System;

using GXPEngine;

public class Player : Character
{
    private bool lumi = true;
    private static int SWITCH_LENGTH = 15000;
    private int health = 100;
    public static int souls = 0;
    private int _nocCost = -2;

    public  Player(string filename, int cols, int rows, int frames) : base(filename, cols, rows, frames)
    {
        x = Game.main.width / 2;
        y = Game.main.height / 2;
        SetOrigin(64,128);
        SetFrame(0);
    }

    public int getHealth()
    {
        return health;
    }

    public void changeplayer()
    {
        
       
        if (!lumi)
        {
            changeToLumi();
          AddChild(new Timer(2000,changeToNoc));

        }
        else if (lumi)
        {
            changeToNoc();
            souls-=2;
            Console.WriteLine("Souls: " + souls);
            AddChild(new Timer(SWITCH_LENGTH,changeToLumi));
            SetOrigin(40, 110);
        }
    }

    public void changeToNoc(){
        lumi = false;
        ChangeSprite("zombie_tilesheet.png",9,3,24);
        SetOrigin(40, 110);

    }

    public void changeToLumi(){
        lumi = true;
        ChangeSprite("player_tilesheet.png", 8, 4, 33);
        SetOrigin(40, 110);


    }

    public int GetSouls()
    {
        return souls;
    }

    public float getX(){
        return x;
    }

 
    
    void Update()
    {
//        Console.WriteLine("X: " + x + " Y: " + y);

        base.Update();
    }
    
}