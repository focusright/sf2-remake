using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SF2_2 {
    abstract class Jump : Interruptable {
        bool isJumpingUp = true;
        int jumpHeight = 100;

        public Jump(Rect_Pos rp) : base(rp) {}

        protected override void MoveAlgorithm() {
            if (isJumpingUp) {
                if (rp.Rectangle.Y >= jumpHeight)
                    JumpUpAlgorithm();
                else
                    isJumpingUp = false;
            } else {
                ComingDownAlgorithm();
                if (rp.Rectangle.Y >= rp.Position.Y) {
                    isInMotion = false;
                    isJumpingUp = true;
                    rp.Rectangle.Y = (int)rp.Position.Y;
                }
            }
        }

        protected abstract void JumpUpAlgorithm();
        protected abstract void ComingDownAlgorithm();

        public void Start() {
            if (!isInMotion) {
                rp.Position.X = rp.Rectangle.X;
                rp.Position.Y = rp.Rectangle.Y;
                isInMotion = true;
            }
        }
    }

    class JumpUp : Jump {
        public JumpUp(Rect_Pos rp) : base(rp) { }
        protected override void JumpUpAlgorithm() {
            rp.Rectangle.Y -= 20;
        }
        protected override void ComingDownAlgorithm() {
            rp.Rectangle.Y += 20;
        }
    }

    class JumpForward : Jump {
        public JumpForward(Rect_Pos rp) : base(rp) { }
        protected override void JumpUpAlgorithm() {
            rp.Rectangle.Y -= 20;
            rp.Rectangle.X += 10;
        }
        protected override void ComingDownAlgorithm() {
            rp.Rectangle.Y += 20;
            rp.Rectangle.X += 10;
        }
    }

    class JumpBackward : Jump {
        public JumpBackward(Rect_Pos rp) : base(rp) { }
        protected override void JumpUpAlgorithm() {
            rp.Rectangle.Y -= 20;
            rp.Rectangle.X -= 10;
        }
        protected override void ComingDownAlgorithm() {
            rp.Rectangle.Y += 20;
            rp.Rectangle.X -= 10;
        }
    }
}
