using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace TypingMatrix {
    class Letter {
        public const int MIN_DROPSPEED = 1;
        public const int MAX_DROPSPEED = 10;
        
        public char character = '\0';
        private Vector2 fontPos;
        private int dropSpeed;
        private GraphicsDeviceManager graphics;

        private Keys _Key;
        public Keys Key {
            get { return _Key; }
        }

        private bool _missed = false;
        public bool Missed {
            get { return _missed; }
        }

        public Letter(Keys key, char chara, GraphicsDeviceManager g) {
            _Key = key;
            character = chara;

            Random rand = new Random();
            dropSpeed = rand.Next(MIN_DROPSPEED, MAX_DROPSPEED);

            graphics = g;
            int viewportWidth = g.GraphicsDevice.Viewport.Width;
            int fontXpos = viewportWidth - rand.Next(viewportWidth);
            fontPos = new Vector2(fontXpos, 0);
        }

        public bool IsPressed {
            get {
                if (Keyboard.GetState().IsKeyDown(_Key))
                    return true;
                else
                    return false;
            }
        }

        public void Update() {
            fontPos.Y += dropSpeed;

            if (fontPos.Y >= graphics.GraphicsDevice.Viewport.Height) {
                dropSpeed = 0;
                _missed = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font1) {
            // Draw Hello World
            string output = character.ToString();

            // Find the center of the string
            //Vector2 FontOrigin = font1.MeasureString(output) / 2;
            Vector2 FontOrigin = Vector2.Zero;
            spriteBatch.DrawString(font1, output, fontPos, Color.White, 0, FontOrigin, 2.0f, SpriteEffects.None, 0.5f);
        }
    }
}
