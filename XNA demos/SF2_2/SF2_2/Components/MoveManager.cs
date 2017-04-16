using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SF2_2 {
    class MoveManager {
        Dictionary<MoveList, Jump> collection = new Dictionary<MoveList, Jump>();

        JumpUp       ju;
        JumpForward  jf;
        JumpBackward jb;

        public MoveManager(Rect_Pos rp) {
            ju = new JumpUp(rp);
            jf = new JumpForward(rp);
            jb = new JumpBackward(rp);

            collection.Add(MoveList.JumpUp, ju);
            collection.Add(MoveList.JumpForward, jf);
            collection.Add(MoveList.JumpBackward, jb);
        }

        public bool isRunning {
            get {
                bool ret = collection[0].isInMotion;
                foreach (Jump ja in collection.Values)
                    ret = ret || ja.isInMotion;

                return ret;
            }
        }

        public void Start(MoveList animation) {
            if (!isRunning) {
                switch (animation) {
                    case MoveList.JumpForward:
                        jf.Start();
                        break;
                    case MoveList.JumpBackward:
                        jb.Start();
                        break;
                    case MoveList.JumpUp:
                        ju.Start();
                        break;
                }
            }
        }

        public void Update(GameTime gameTime) {
            if (isRunning) {
                jf.Update(gameTime);
                jb.Update(gameTime);
                ju.Update(gameTime);
            }
        }
    }
}
