using System;
using System.Security.Policy;
using GXPEngine;
using GXPEngine.Core;

public class Enemy : Character{
    private int health = 4;
    private int _S;
    private int Movespeed = 5;

    public Enemy(String filename, int cols, int rows, int frames) : base(filename, cols, rows, frames){
        x = Game.main.width / 3;
        y = Game.main.height / 2;
        SetOrigin(40, 110);
        SetFrame(0);
    }

    public new void getHit(){
        this.health--;
        Console.WriteLine("Health: " + health);
    }


    public void Update(){
        Console.WriteLine(health);
        if (health <= 0){
            Destroy();
            Player.souls += 1;
            Console.WriteLine("Souls: " + Player.souls);
        }
        base.Update();
        
        Xv = (Convert.ToInt32(Input.GetKey(Key.A)) - Convert.ToInt32(Input.GetKey(Key.D))) * Movespeed;
        x += Xv;
        
    }

    public void MoveToPlayer(int min,int max){
  
        if (this.x < min){
            Xv = 4;
        }else if (this.x > Game.main.width - max){
            Xv = -4;
        }else if (Xv == 0){
                
            Xv = 4;
                
        }
            
    
    }

    public void OnCollision(GameObject GameObj){
        if (GameObj is Bullet){
            getHit();
            GameObj.Destroy();
            
        }if (GameObj is GroundSprite){
            GroundSprite groundSprite = (GroundSprite) GameObj;
            Rectangle rectangle =
                new Rectangle(groundSprite.x, groundSprite.y, groundSprite.width, groundSprite.height);

            if (y >= rectangle.top){
                y = rectangle.y - 1;
            }
            if (x - 64 >= rectangle.left || x <= rectangle.right && y > rectangle.bottom){
                if (x - 64 >= rectangle.left && y > rectangle.bottom){
//                    x = rectangle.left - 1;
                    Xv = -5;
                }
                else if (x <= rectangle.right + 32 && y > rectangle.bottom){
//                    x = rectangle.right + 1;
                    Xv = 5;
                }
            }
//            if (y < GameObj.y + 65){
//                y = GameObj.y;
//                onground = true;
//            }
            else{
                onground = false;
            }
//            if (x >= GameObj.x && x <= GameObj.x +32){
//                x = GameObj.x-1;
//            }else if (x >= GameObj.x && x <= GameObj.x + 64){
//                x = GameObj.x + 65;
//            }


//            Console.WriteLine("x: " + GameObj.x + " y: " + GameObj.y);
        }
    }
}