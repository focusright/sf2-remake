using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SF2_1 {
    abstract class Move {
        protected int index = 0;
        protected Picture[] Animation_Frames;
        //protected Sound
        protected bool isLooped = false;

        public event Action AnimationFinished;

        public virtual int FrameCount { get { return 5; } }
        public virtual int FramesPerSecond { get { return 10; } }

        //public Picture this[int index] {
        //    get { return Animation_Frames[index]; }
        //}

        public Picture CurrentPicture { get { return Animation_Frames[index]; } }

        public Move() {
            Animation_Frames = new Picture[FrameCount];
        }

        public void Reset() {
            index = 0;
        }

        public void AdvanceFrame() {
            index++;

            if(isLooped)
                index = index % FrameCount;

            if(index >= FrameCount) {
                index--;
                if(AnimationFinished != null)
                    AnimationFinished();
            }
                
        }


        //Development nub
        public void SetFrame(int i) {
            index = i;
        }

    }
}
