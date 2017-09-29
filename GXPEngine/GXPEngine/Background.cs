using System;
using System.Collections;
using GXPEngine;

    public class Background
    {
        public CollisionManager collisionManager;
        public static Array groundtiles;
        public Background()
        {
             collisionManager = new CollisionManager();

            
            for (int i = 0; i < Game.main.width; i++)
            {
                if (i % 1024 == 0)
                {
                    Sprite backgroundSprite = new Sprite("colored_desert.png")
                    {
                        x = i,
                        y = -100
                    };
                    Game.main.AddChild(backgroundSprite);
                    
                }
            }
            for (int i = 0; i < Game.main.width; i++)
            {
                for (int j = 0; j < Game.main.height; j++)
                {
                    if (j % 64 != 0) continue;
                    if (i % 64 != 0) continue;
                    if (i / 64 == 6 || i / 64 == 8)
                    {
                        if (j / 64 == 7)
                        {
                            GroundSprite groundSprite = new GroundSprite("SandMid.png")
                            {
                                x = i,
                                y = j
                            };
                            Game.main.AddChild(groundSprite);
                            collisionManager.Add(groundSprite);
                        }
                    }
                    if (j / 64 == 10)
                    {
                        if (i % 64 == 0)
                        {
                            GroundSprite groundSprite = new GroundSprite("SandMid.png")
                            {
                                x = i,
                                y = j
                            };
                            Game.main.AddChild(groundSprite);
                            collisionManager.Add(groundSprite);
                        }
                    }
                    if (j / 64 == 11)
                    {
                        if (i % 64 == 0)
                        {
                            GroundSprite groundSprite = new GroundSprite("SandCenter.png")
                            {
                                x = i,
                                y = j
                            };
                            Game.main.AddChild(groundSprite);

                        }
                    }
                }
            }
        }

      
        
    }
