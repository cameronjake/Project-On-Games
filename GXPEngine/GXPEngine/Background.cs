using System;
using System.Collections;
using GXPEngine;
using GXPEngine.Managers;

//using TiledSharp;

public class Background : Sprite{
    public CollisionManager collisionManager;
    public static Array groundtiles;
    private int Movespeed = 4;
    private float Xv;


    GroundSprite backgroundSprite;

    public Background() : base("background middle 2.png"){
//        SetOrigin(width,0);
//        collisionManager = new CollisionManager();

    }






//        for (int i = 0; i < Game.main.width; i++){
//            for (int j = 0; j < Game.main.height; j++){
//                if (j % 64 != 0) continue;
//                if (i % 64 != 0) continue;
//                if (i / 64 == 6 || i / 64 == 8){
//                    if (j / 64 == 7){
//                        GroundSprite groundSprite = new GroundSprite("SandMid.png") {
//                            x = i,
//                            y = j
//                        };
//                        Game.main.AddChild(groundSprite);
//                        collisionManager.Add(groundSprite);
//                    }
//                }
//                if (j / 64 == 10){
//                    if (i % 64 == 0){
//                        GroundSprite groundSprite = new GroundSprite("SandMid.png") {
//                            x = i,
//                            y = j
//                        };
//                        Game.main.AddChild(groundSprite);
//                        collisionManager.Add(groundSprite);
//                    }
//                }
//                if (j / 64 == 11){
//                    if (i % 64 == 0){
//                        GroundSprite groundSprite = new GroundSprite("SandCenter.png") {
//                            x = i,
//                            y = j
//                        };
//                        Game.main.AddChild(groundSprite);
//                    }
//                }
//            }
//        }
    
//    void Update(){
//        Xv = (Convert.ToInt32(Input.GetKey(Key.A)) - Convert.ToInt32(Input.GetKey(Key.D))) * Movespeed;
//        x += Xv;
//        if (x < 0-width){
//            x = Game.main.width;
//            Background bg = new Background();
//            bg.x = width;
//        }else if (x > Game.main.width){
//            x = 0;
//        }
//    }
}