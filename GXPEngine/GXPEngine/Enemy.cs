using System;
using GXPEngine;

public class Enemy : Character{
    private int health = 100;

    public Enemy(String filename, int cols, int rows, int frames) : base(filename, cols, rows, frames){
        x = Game.main.width / 3;
        y = Game.main.height / 2;
        SetOrigin(40, 110);
        SetFrame(0);
    }

    public void getHit(){
        this.health--;
    }

    public void Update(){
        Console.WriteLine(health);
        if (health <= 0){
            Destroy();
        }
        base.Update();
    }

    public void MoveToPlayer(){
        Player player = Game.main.GetPlayer();
        if (this.x > player.x){
            float distance = x - player.x;
            Move(distance, 0);
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