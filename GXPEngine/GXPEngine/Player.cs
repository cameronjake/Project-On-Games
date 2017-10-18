using System;
using GXPEngine;

public class Player : Character
{
    private int NocOrLumi = 1;

    private int health = 100;

    public Player(string filename, int cols, int rows, int frames) : base(filename, cols, rows, frames)
    {
        x = Game.main.width / 2;
        y = Game.main.height / 2;
        SetOrigin(40, 110);
        SetFrame(0);
    }

    public int getHealth()
    {
        return health;
    }

    public int changeplayer()
    {
        
        NocOrLumi = NocOrLumi * -1;
        //TODO: link to score system
        if (NocOrLumi == -1)
        {
            ChangeSprite("zombie_tilesheet.png", 9, 3, 24);
            SetOrigin(40, 110);
        }
        else if (NocOrLumi == 1)
        {
            ChangeSprite("player_tilesheet.png", 9, 3, 24);
            SetOrigin(40, 110);
        }
        return NocOrLumi;
    }

    void Update()
    {
        Console.WriteLine("X: " + x + " Y: " + y);

        base.Update();
    }
}