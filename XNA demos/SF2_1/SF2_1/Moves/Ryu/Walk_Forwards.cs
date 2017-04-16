using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SF2_1 {
    class Walk_Forwards : InterruptibleMove {

        public override int FrameCount {
            get { return 6; }
        }

        public Walk_Forwards()   {
            Animation_Frames[0] = new Picture(new Rectangle(0,   125, 75, 97), new Vector2(0, 0));
            Animation_Frames[1] = new Picture(new Rectangle(76,  125, 75, 97), new Vector2(0, 0));
            Animation_Frames[2] = new Picture(new Rectangle(160, 125, 75, 97), new Vector2(0, 0));
            Animation_Frames[3] = new Picture(new Rectangle(250, 125, 75, 97), new Vector2(0, 0));
            Animation_Frames[4] = new Picture(new Rectangle(340, 125, 75, 97), new Vector2(0, 0));
            Animation_Frames[5] = new Picture(new Rectangle(420, 125, 75, 97), new Vector2(0, 0));

            isLooped = true;
        }

    }
}
