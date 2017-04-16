using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SF2_2 {
    abstract class Interruptable : Move {
        public Interruptable(Rect_Pos rp) : base(rp) { }
    }
}
