using System;

using GXPEngine;
    public class Star : Sprite{
        private readonly float Movespeed = 2;
        private float Xv;
        
        public Star(string filename) : base(filename){
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            x = rnd.Next(0,1920);
            y = rnd.Next(0,1080);
            SetScaleXY(rnd.Next(1, 4));
            
        }

        void Update(){
            Xv = (Convert.ToInt32(Input.GetKey(Key.A)) - Convert.ToInt32(Input.GetKey(Key.D))) * Movespeed;
            x += Xv;
            if (x < 0){
                x = Game.main.width;
            }else if (x > Game.main.width){
                x = 0;
            }
        }
        
    }
    
    
