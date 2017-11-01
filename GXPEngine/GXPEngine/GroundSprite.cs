using System;
using GXPEngine;

public class GroundSprite : Sprite{
    private float Xv;
    private int Movespeed = 5;
    private float Yv = 0;
    readonly float gravity = 0.98f;

    public GroundSprite(String filename, float x, float y) : base(filename){
//            SetOrigin(64,64);
        this.x = x;
        this.y = y;
    }

    void Update(){
        Xv = (Convert.ToInt32(Input.GetKey(Key.A)) - Convert.ToInt32(Input.GetKey(Key.D))) * Movespeed;
        x += Xv;

        if (OnGround()){
//            y = MyGame.groundY[(int) Utils.Clamp(this.x, 0, MyGame.main.width - 1)];
            Yv = 0;
        }
        else{
            Yv += gravity;
        }
//        if (Input.GetKeyDown(Key.W)){
//            Yv = 23;
//        }
//        y -= Yv;
//        else{
//            Yv += gravity;
//        }
    }

    public bool onGround(){
        
    }
    
}