using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace SF2_1 {
    public class SF2_1 : Microsoft.Xna.Framework.Game {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        private Texture2D background;

        public SpriteBatch SpriteBatch {
            get { return this.spriteBatch; }
        }

        public SF2_1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 550;

            Components.Add(new RyuAnimation(this));
            Components.Add(new MyMouse(this));
        }

        protected override void Initialize() {
            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Arial");
            background = Content.Load<Texture2D>("Stage_Blanka");
        }

        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            UpdateKeyboard();

            base.Update(gameTime);
        }

        private void UpdateKeyboard() {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.DarkGreen);

            spriteBatch.Begin();

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //spriteBatch.DrawString(font, "GameTime: " + elapsed.ToString(), Vector2.Zero, Color.White);
            //spriteBatch.Draw(background, Vector2.Zero, new Rectangle(0, 0, background.Width, background.Height), Color.White, 0f, Vector2.Zero, 3f, SpriteEffects.None, 0f);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
