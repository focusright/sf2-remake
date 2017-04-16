using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SF2_1 {
    class Idle : InterruptibleMove {

        public Idle() {
            Animation_Frames[0] = new Picture(new Rectangle(3,   10, 65, 95), new Vector2(0, 0));
            Animation_Frames[1] = new Picture(new Rectangle(91,  10, 65, 95), new Vector2(0, 0));
            Animation_Frames[2] = new Picture(new Rectangle(180, 10, 65, 95), new Vector2(0, 0));
            Animation_Frames[3] = new Picture(new Rectangle(273, 10, 65, 95), new Vector2(0, 0));
            Animation_Frames[4] = new Picture(new Rectangle(361, 10, 65, 95), new Vector2(0, 0));

            isLooped = true;
        }
    }
}
