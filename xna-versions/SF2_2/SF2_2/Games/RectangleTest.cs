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
    public class RectangleTest : Microsoft.Xna.Framework.Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GDCInterface GI;
        Picture pic;
        RectangleOverlay rol;
        RectangleCreate rc;

        public RectangleTest() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize() {
            GI = new GDCInterface(GraphicsDevice);
            pic = GI.GetTexture(64, 256);
            rol = new RectangleOverlay(new Rectangle(100, 200, 200, 100), Color.LightCyan, this);
            Components.Add(rol);
            rc = new RectangleCreate(this);
            Components.Add(rc);

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
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            spriteBatch.Draw(pic.Texture, pic.Rectangle, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
