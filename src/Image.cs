using System;
using System.Collections.Generic;
using System.Drawing;
using static MagmaMc.GDI.src.Utils;
namespace MagmaMc.GDI.src
{
    public static class Image
    {

        #region Static
        public static IntPtr BaseWindow { get; private set; } = GetDesktopWindow();
        public static IntPtr Window { get; private set; }
        public static Graphics ScreenGraphics { get; private set; }

        public static void StartRender()
        {
            Window = GetDC(BaseWindow);
            ScreenGraphics = Graphics.FromHdc(Window);
        }
        public static void EndRender() => ReleaseDC(BaseWindow, Window);
        #endregion

        public static void Render(Bitmap BitmapImage, ushort PosX, ushort PosY, float ResX, float ResY)
        {
            StartRender();
            BitmapImage.SetResolution(ResX, ResY);
            ScreenGraphics.DrawImage(BitmapImage, PosX, PosY);
            EndRender();
        }

        public static void Render(Icon IconImage, Point Position) =>
                Render(IconImage.ToBitmap(), (ushort)Position.X, (ushort)Position.Y, 1, 1);

        public static void Render(Icon IconImage, Point Position, Point Resolution) =>
                Render(IconImage.ToBitmap(), (ushort)Position.X, (ushort)Position.Y, Resolution.X, Resolution.Y);


        public static void Render(Bitmap BitmapImage, Point Position) =>
                Render(BitmapImage, (ushort)Position.X, (ushort)Position.Y, BitmapImage.HorizontalResolution, BitmapImage.VerticalResolution);

        public static void Render(Bitmap BitmapImage, Point Position, Point Resolution) =>
                Render(BitmapImage, (ushort)Position.X, (ushort)Position.Y, Resolution.X, Resolution.Y);
    }
}
