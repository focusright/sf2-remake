using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SF2_1 {
    class Fierce : UninterruptibleMove {

        public override int FramesPerSecond {
            get { return 7; }
        }

        public Fierce() {
            Animation_Frames[0] = new Picture(new Rectangle(250, 268, 65,  95), new Vector2(0, 0));
            Animation_Frames[1] = new Picture(new Rectangle(330, 268, 80,  95), new Vector2(0, 0));
            Animation_Frames[2] = new Picture(new Rectangle(430, 268, 112, 95), new Vector2(0, 0));
            Animation_Frames[3] = new Picture(new Rectangle(330, 268, 80,  95), new Vector2(0, 0));
            Animation_Frames[4] = new Picture(new Rectangle(250, 268, 65,  95), new Vector2(0, 0));
        }

    }
}
