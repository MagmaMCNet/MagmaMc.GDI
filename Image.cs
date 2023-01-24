using System;
using System.Collections.Generic;
using System.Drawing;
using static MagmaMc.GDI.Utils;
namespace MagmaMc.GDI
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

        public static void Render(Bitmap BitmapImage, UInt16 PosX, UInt16 PosY, float ResX, float ResY)
        {
            StartRender();
            BitmapImage.SetResolution(ResX, ResY);
            ScreenGraphics.DrawImage(BitmapImage, PosX, PosY);
            EndRender();
        }

        public static void Render(Icon IconImage, Point Position) => 
                Render(IconImage.ToBitmap(), (UInt16)Position.X, (UInt16)Position.Y, 1, 1);

        public static void Render(Icon IconImage, Point Position, Point Resolution) => 
                Render(IconImage.ToBitmap(), (UInt16)Position.X, (UInt16)Position.Y, Resolution.X, Resolution.Y);


        public static void Render(Bitmap BitmapImage, Point Position) =>
                Render(BitmapImage, (UInt16)Position.X, (UInt16)Position.Y, BitmapImage.HorizontalResolution, BitmapImage.VerticalResolution);

        public static void Render(Bitmap BitmapImage, Point Position, Point Resolution) => 
                Render(BitmapImage, (UInt16)Position.X, (UInt16)Position.Y, Resolution.X, Resolution.Y);
    }
}
