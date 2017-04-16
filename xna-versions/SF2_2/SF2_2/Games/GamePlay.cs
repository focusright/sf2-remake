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

namespace SF2_2 {
    public class GamePlay : Microsoft.Xna.Framework.Game {
        const int SCREENWIDTH = 800;
        const int SCREENHEIGHT = 600;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player P1;

        public GamePlay() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = SCREENWIDTH;
            graphics.PreferredBackBufferHeight = SCREENHEIGHT;
        }

        protected override void Initialize() {
            P1 = new Player(this);
            Components.Add(P1);

            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        protected override void Update(GameTime gameTime) {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.DarkBlue);

            spriteBatch.Begin();
            Texture2D groundTexture = new Texture2D(GraphicsDevice, 1, 1);
            groundTexture.SetData(new Color[] { Color.White });
            Rectangle groundRectangle = new Rectangle(0, 500, 800, 100);
            spriteBatch.Draw(groundTexture, groundRectangle, Color.Brown);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
