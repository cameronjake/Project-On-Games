using System;

namespace GXPEngine{
    public class Star : Sprite{
        public Star(string filename) : base(filename){
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            x = rnd.Next(0,1920);
            y = rnd.Next(0,600);
            SetScaleXY(rnd.Next(1, 4));
            
        }
    }
}