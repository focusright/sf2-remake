using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SF2_2 {
    abstract class Uninterruptable : Move {
        public Uninterruptable(Rect_Pos rp) : base(rp) { }
    }
}
