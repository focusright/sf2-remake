using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace SF2_2 {
    class Player : DrawableGameComponent {

        int width = 100;
        int height = 200;
        
        SpriteBatch spriteBatch;
        Texture2D texture;
        MoveManager MM;
        Rect_Pos RP;

        public Player(Game game) : base(game) {
            DrawOrder = 1000;
            Viewport vp = game.GraphicsDevice.Viewport;
            Vector2 pos = new Vector2(vp.Width / 2, vp.Height / 2);
            Rectangle r = new Rectangle((int)pos.X, (int)pos.Y, width, height);
            RP = new Rect_Pos(r, pos);
            MM = new MoveManager(RP);
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = new Texture2D(GraphicsDevice, 1, 1);
            texture.SetData(new Color[] { Color.White });
        }

        KeyboardState PKS;
        bool isCrouching = false;
        public override void Update(GameTime gameTime) {
            KeyboardState CKS = Keyboard.GetState();

            if (!MM.isRunning) {
                int crouchHeight = height - height / 3;

                if (CKS.IsKeyDown(Keys.Down) && !PKS.IsKeyDown(Keys.Down)) {
                    RP.Rectangle.Height = crouchHeight;
                    RP.Rectangle.Y += height / 3;
                    isCrouching = true;
                }
                else if (CKS.IsKeyUp(Keys.Down) && PKS.IsKeyDown(Keys.Down) && isCrouching) {
                    RP.Rectangle.Height = height;
                    RP.Rectangle.Y -= height / 3;
                    isCrouching = false;
                }

                if (!isCrouching) {
                    if (CKS.IsKeyDown(Keys.Left))
                        RP.Rectangle.X -= 5;
                    if (CKS.IsKeyDown(Keys.Right))
                        RP.Rectangle.X += 5;
                }
            }

            if (CKS.IsKeyDown(Keys.Right) && CKS.IsKeyDown(Keys.Up) && !(PKS.IsKeyDown(Keys.Right) && PKS.IsKeyDown(Keys.Up))) {
                MM.Start(MoveList.JumpForward);
            } else if (CKS.IsKeyDown(Keys.Left) && CKS.IsKeyDown(Keys.Up) && !(PKS.IsKeyDown(Keys.Left) && PKS.IsKeyDown(Keys.Up))) {
                MM.Start(MoveList.JumpBackward);
            } else if (CKS.IsKeyDown(Keys.Up) && !PKS.IsKeyDown(Keys.Up)) {
                MM.Start(MoveList.JumpUp);
            }

            if (CKS.IsKeyDown(Keys.A) && !PKS.IsKeyDown(Keys.A)) {

            }

            PKS = CKS;
            MM.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, RP.Rectangle, Color.LightCyan);
            spriteBatch.End();
        }
    }
}
