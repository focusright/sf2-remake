using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SF2_1 {
    class Walk_Backwards: InterruptibleMove {

        public override int FrameCount {
            get { return 6; }
        }

        public Walk_Backwards()   {
            Animation_Frames[0] = new Picture(new Rectangle(535, 125, 75, 97), new Vector2(0, 0));
            Animation_Frames[1] = new Picture(new Rectangle(621, 125, 75, 97), new Vector2(0, 0));
            Animation_Frames[2] = new Picture(new Rectangle(706, 125, 75, 97), new Vector2(0, 0));
            Animation_Frames[3] = new Picture(new Rectangle(792, 125, 75, 97), new Vector2(0, 0));
            Animation_Frames[4] = new Picture(new Rectangle(877, 125, 75, 97), new Vector2(0, 0));
            Animation_Frames[5] = new Picture(new Rectangle(966, 125, 75, 97), new Vector2(0, 0));

            isLooped = true;
        }

    }
}
