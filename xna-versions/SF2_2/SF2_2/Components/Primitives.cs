using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SF2_2 {
    class Rect_Pos {
        public Rectangle Rectangle;
        public Vector2 Position;

        public Rect_Pos(Rectangle rectangle, Vector2 position) {
            this.Rectangle = rectangle;
            this.Position = position;
        }
    }
}
