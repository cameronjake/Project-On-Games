using System;
using System.Security.Policy;
using GXPEngine;

public class Enemy : Character{
    private int health = 4;
    private int _S;

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
            if (GameObj is Sprite){ }
        }
    }
}