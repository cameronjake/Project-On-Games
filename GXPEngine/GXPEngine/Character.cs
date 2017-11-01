using System;
using System.Drawing.Drawing2D;
using GXPEngine;
using GXPEngine.Core;

public class Character : AnimationSprite{
    private int health = 100;
    public float Xv;
    private float xv;
    private int Movespeed = 5;
    readonly float gravity = 0.98f;
    private float Yv;
    private float yv;
    private bool jump;
    private bool onground;
    public int direction = -1;
    private int animationDrawFrames;
    private int step;

    public Character(String filename, int cols, int rows, int frames) : base(filename, cols, rows, frames){
        SetFrame(20);

        animationDrawFrames = 16;
        step = 0;
    }

    public void Update()
    {
        step = step + 1;
        if (step > animationDrawFrames)
        {
            NextFrame();
            step = 0;
        }


//        if (GetType() == typeof(Player)){
//            Xv = (Convert.ToInt32(Input.GetKey(Key.D)) - Convert.ToInt32(Input.GetKey(Key.A))) * Movespeed;
//        }
        

//        x += Xv;

//        if (xv < Xv){
//            xv += 0.1f;
//        }
        y += Yv;
//        x += Xv;


        if (OnGround()){
//            y = MyGame.groundY[(int) Utils.Clamp(this.x, 0, MyGame.main.width - 1)];
            Yv = 0;
        }
        else{
            Yv += gravity;
        }

//        if (OnGround()){
//            if (GetType() == typeof(Player)){
//                if (Input.GetKey(Key.W)){
//                    Console.WriteLine("jump");
//                    Jump();
//                }
//            }
//        }

        if (x > Game.main.width - 32){
            x = Game.main.width - 31;
        }
        else if (x < 31){
//            x = Game.main.width + 40;
            x = 32;
        }
    }


    public void OnCollision(GameObject GameObj){
        if (GameObj is GroundSprite){
            if (y < GameObj.y +65){
                y = GameObj.y;
                onground = true;
            }
            if (x >= GameObj.x && x <= GameObj.x +32){
                x = GameObj.x-1;
            }else if (x >= GameObj.x && x <= GameObj.x + 64){
                x = GameObj.x + 65;
            }
            
            
            
//            Console.WriteLine("x: " + GameObj.x + " y: " + GameObj.y);
        }
        if (GameObj is Sprite){ }
    }

    public int getDirection(){
        return direction;
    }

    public void Jump(){
        Yv = -23;
    }

    public void getHit(){
        this.health--;
    }

    public bool OnGround(){
        return this.y >= MyGame.groundY[(int) Utils.Clamp(this.x, 0, MyGame.main.width - 1)];
    }
}