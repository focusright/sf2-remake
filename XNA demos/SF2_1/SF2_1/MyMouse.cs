using System;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SD = System.Drawing;
using SDI = System.Drawing.Imaging;


namespace SF2_1 {
    class MyMouse : DrawableGameComponent {
        Texture2D MouseTexture;
        Rectangle MouseRectangle;

        public MyMouse(Game game) : base(game) { }

        protected override void LoadContent() {
            MouseTexture = LoadDyamicBMP(CreateCircle(8, SD.Brushes.Black), this.GraphicsDevice);
            MouseRectangle = new Rectangle(0, 0, MouseTexture.Width, MouseTexture.Height);
        }

        public override void Update(GameTime gameTime) {
            MouseState MS = UpdateMouse(gameTime);

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime) {
            SpriteBatch spriteBatch = ((SF2_1)this.Game).SpriteBatch;

            spriteBatch.Begin();
            spriteBatch.Draw(MouseTexture, MouseRectangle, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }


        private MouseState UpdateMouse(GameTime gameTime) {
            MouseState NewState = Mouse.GetState();
            MouseRectangle.X = Mouse.GetState().X - MouseTexture.Width / 2;
            MouseRectangle.Y = Mouse.GetState().Y - MouseTexture.Height / 2;

            return NewState;
        }

        public static Texture2D LoadDyamicBMP(SD.Bitmap bitmap, GraphicsDevice GD) {
            Texture2D ret = new Texture2D(GD, bitmap.Width, bitmap.Height, 0, TextureUsage.AutoGenerateMipMap, SurfaceFormat.Color);
            SDI.BitmapData data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);
            int bufferSize = data.Height * data.Stride;
            byte[] bytes = new byte[bufferSize];
            Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
            ret.SetData(bytes);
            bitmap.UnlockBits(data);
            return ret;
        }
        public static SD.Bitmap CreateCircle(int size, SD.Brush brush) {
            SD.Bitmap bitmap = new SD.Bitmap(size, size);
            SD.Graphics bitmapGraphics = SD.Graphics.FromImage(bitmap);
            bitmapGraphics.Clear(SD.Color.Transparent);
            bitmapGraphics.FillEllipse(brush, new SD.Rectangle(0, 0, size, size));
            bitmapGraphics.Dispose();
            return bitmap;
        }
    }
}
