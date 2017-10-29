using System;
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
    private int direction = -1;

    public Character(String filename, int cols, int rows, int frames) : base(filename, cols, rows, frames){
        SetFrame(20);
    }

    public void Update(){
        if (Yv < 0){
            SetFrame(20);
//            this.changeFromTexture("player_jump.png");
        }
        else if (Yv > 0){
            SetFrame(4);
//            this.changeFromTexture("player_fall.png");
        }
        else if (Yv == 0 && Xv == 0){
            SetFrame(0);
//            this.changeFromTexture("player_idle.png");
        }
        else if (Xv < 0 && Xv > -4){
            SetFrame(19);
//            this.changeFromTexture("player_walk1.png");
        }
        else if (Xv < 0){
            if (x / 10 % 2 == 0){
                SetFrame(10);
            }
            else if (x / 10 % 2 != 0){
                SetFrame(9);
            }
            //            this.changeFromTexture("player_walk2.png");
        }
        else if (Xv > 0){
            if (x / 10 % 2 == 0){
                SetFrame(10);
            }
            else if (x / 10 % 2 != 0){
                SetFrame(9);
            }

            //            this.changeFromTexture("player_walk2.png");
        }
        if (Xv < 0){
            Mirror(true, false);
            direction = -1;
        }
        else if (Xv > 0){
            Mirror(false, false);
            direction = 1;
        }

        if (GetType() == typeof(Player)){
            Xv = (Convert.ToInt32(Input.GetKey(Key.D)) - Convert.ToInt32(Input.GetKey(Key.A))) * Movespeed;
        }
        

        x += Xv;

        if (xv < Xv){
            xv += 0.1f;
        }
        y += Yv;
        x += Xv;


        if (OnGround()){
            y = MyGame.groundY[(int) Utils.Clamp(this.x, 0, MyGame.main.width - 1)];
            Yv = 0;
        }
        else{
            Yv += gravity;
        }

        if (OnGround()){
            if (GetType() == typeof(Player)){
                if (Input.GetKey(Key.W)){
                    Console.WriteLine("jump");
                    Jump();
                }
            }
        }

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
            if (y >= GameObj.y){
                y = GameObj.y;
            }
            else if (y == GameObj.y)
            {
                y = GameObj.y;
            }
            else if (y > GameObj.y)
            {
                y = GameObj.y;
            }
            Console.WriteLine("hit!");
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