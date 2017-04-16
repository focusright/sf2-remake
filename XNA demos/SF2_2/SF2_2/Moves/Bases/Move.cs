using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SF2_2 {
    abstract class Move {
        public bool isInMotion = false;
        private float TotalElapsed = 0f;
        protected int FramesPerSecond = 30;
        protected float TimePerFrame;
        protected Rect_Pos rp;

        public Move(Rect_Pos rp) {
            TimePerFrame = 1f / FramesPerSecond;
            this.rp = rp;
        }

        public void Update(GameTime gameTime) {
            if (isInMotion) {
                float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                TotalElapsed += elapsed;

                if (TotalElapsed >= TimePerFrame) {
                    MoveAlgorithm();
                    TotalElapsed = 0;
                }
            }
        }

        protected abstract void MoveAlgorithm();

    }
}
