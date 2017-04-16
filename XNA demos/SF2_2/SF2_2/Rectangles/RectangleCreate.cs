using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace SF2_2
{
    public class RectangleCreate : DrawableGameComponent
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D rectangle;

        public RectangleCreate(Game game) : base(game) { }

        public Texture2D CreateRectangle(int width, int height)        {
            // create the rectangle texture, ,but it will have no color! lets fix that
            Texture2D rectangleTexture = new Texture2D( GraphicsDevice, width, height, 1, 
                                                        TextureUsage.None, SurfaceFormat.Color);

            //set the color to the amount of pixels
            Color[] color = new Color[width * height];

            //loop through all the colors setting them to whatever values we want
            for (int i = 0; i < color.Length; i++)
                color[i] = Color.LightCoral;
            
            //set the color data on the texture
            rectangleTexture.SetData(color);
            return rectangleTexture;
        }

        protected override void LoadContent()        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            rectangle = CreateRectangle(40, 80);
        }

        public override void Draw(GameTime gameTime)        {
            spriteBatch.Begin();
            spriteBatch.Draw(rectangle, Vector2.Zero, Color.White);
            spriteBatch.End();
        }
    }
}