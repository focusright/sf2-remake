using System;
using Microsoft.Xna.Framework;

namespace SF2_1 {
    class Picture {
        private Vector2 offset;
        private Rectangle frame;

        public Vector2 Offset { get { return offset; } }
        public Rectangle Frame { get { return frame; } }

        public Picture(Rectangle frame, Vector2 offset) {
            this.frame = frame;
            this.offset = offset;
        }
    }
}
