using System;
using System.Collections;
using GXPEngine;
//using TiledSharp;

public class Background : GameObject{
    public CollisionManager collisionManager;
    public static Array groundtiles;


    Sprite backgroundSprite;

    public Background(){
        collisionManager = new CollisionManager();

        
       
        
        backgroundSprite = new Sprite("colored_desert.png"){
            x = 0,
            y = 0
        };
        Game.main.AddChild(backgroundSprite);

       

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
    }

//    public void StayOnScreen(){
//        if (backgroundSprite.x > Game.main.width + backgroundSprite.width * 0.5f){
//            backgroundSprite.x = -backgroundSprite.width * 0.5f;
//        }
//    }

//    public void Update(){
//        StayOnScreen();
//        backgroundSprite.x += -5;
//    }
}