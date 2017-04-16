using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SF2_2 {
    class Walk : Interruptable {
        public Walk(Rect_Pos rp) : base(rp) { }

        protected override void MoveAlgorithm() {

        }
    }

    class Crouch : Interruptable {
        public Crouch(Rect_Pos rp) : base(rp) { }

        protected override void MoveAlgorithm() {

        }
    }
}
