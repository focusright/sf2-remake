using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SF2_1 {
    class Jab : UninterruptibleMove {

        public override int FrameCount {
            get { return 3; }
        }
        public override int FramesPerSecond {
            get { return 20; }
        }

        public Jab() {
            Animation_Frames[0] = new Picture(new Rectangle(14,  269, 73,  95), new Vector2(0, 0));
            Animation_Frames[1] = new Picture(new Rectangle(103, 269, 100, 95), new Vector2(0, 0));
            Animation_Frames[2] = new Picture(new Rectangle(14,  269, 73,  95), new Vector2(0, 0));
        }

    }
}
