using System;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SD = System.Drawing;
using SDI = System.Drawing.Imaging;


namespace SF2_2 {
    class Picture {
        private Texture2D texture;
        private Rectangle rectangle;

        public Texture2D Texture { get { return texture; } }
        public Rectangle Rectangle { get { return rectangle; } }

        public Picture(Texture2D t, Rectangle r) {
            texture = t;
            rectangle = r;
        }
    }

    class GDCInterface  {
        Texture2D texture;
        Rectangle rectangle;
        GraphicsDevice GD;

        public GDCInterface(GraphicsDevice GD) {
            this.GD = GD;
        }

        public Picture GetTexture(int width, int height) {
            SD.Bitmap bitmap = CreateRectangle(width, height, SD.Brushes.White);
            texture = LoadDyamicBMP(bitmap, GD);
            rectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            return new Picture(texture, rectangle);
        }

        private Texture2D LoadDyamicBMP(SD.Bitmap bitmap, GraphicsDevice GD) {
            Texture2D ret = new Texture2D(GD, bitmap.Width, bitmap.Height, 0, TextureUsage.None, SurfaceFormat.Color);
            SDI.BitmapData data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);
            int bufferSize = data.Height * data.Stride;
            byte[] bytes = new byte[bufferSize];
            Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
            ret.SetData(bytes);
            bitmap.UnlockBits(data);
            return ret;
        }

        private SD.Bitmap CreateRectangle(int width, int height, SD.Brush brush) {
            SD.Bitmap bitmap = new SD.Bitmap(width, height);
            SD.Graphics bitmapGraphics = SD.Graphics.FromImage(bitmap);
            bitmapGraphics.Clear(SD.Color.Transparent);
            bitmapGraphics.FillRectangle(brush, new SD.Rectangle(0, 0, width, height));
            bitmapGraphics.Dispose();
            return bitmap;
        }
    }
}
