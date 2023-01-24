using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Metadata;
using System.Reflection;
using static MagmaMc.GDI.Utils;
using Rect = System.Drawing.Rectangle;
namespace MagmaMc.GDI
{
    public static class Box
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


        public static void Render(TernaryRaster TernaryRaster, Rect Source, Rect Destination)
        {
            StartRender();
            StretchBlt(Window, 
                Destination.X, Destination.Y, Destination.Width, Destination.Height, // Destination
                Window, 
                Source.X, Source.Y, Source.Width, Source.Height, // Source
                TernaryRaster);
            EndRender();
        }

        public static void Render(TernaryRaster TernaryRaster, Rect Source, Rect Destination, byte RandomNumber = 2)
        {
            Random R = new Random();
            Source.X = Source.X + R.Next(-RandomNumber, RandomNumber);
            Source.Y = Source.Y + R.Next(-RandomNumber, RandomNumber);
            Source.Width = Source.Width + R.Next(-RandomNumber, RandomNumber);
            Source.Height = Source.Height + R.Next(-RandomNumber, RandomNumber);
            Render(TernaryRaster, Source, Destination);
        }

        public static void Render(TernaryRaster TernaryRaster, Rect Source, Rect Destination, byte RandomPosition = 2, byte RandomScale = 2)
        {
            Random R = new Random();
            Source.X = Source.X + R.Next(-RandomPosition, RandomPosition);
            Source.Y = Source.Y + R.Next(-RandomPosition, RandomPosition);
            Source.Width = Source.Width + R.Next(-RandomScale, RandomScale);
            Source.Height = Source.Height + R.Next(-RandomScale, RandomScale);
            Render(TernaryRaster, Source, Destination);
        }


        public static void Render(Pen Pen, UInt16 PosX, UInt16 PosY, UInt16 ScaleX, UInt16 ScaleY, bool Fill = false)
        {
            StartRender();
            Rect rect = new Rect(new Point(PosX, PosY), new Size(ScaleX, ScaleY));
            if (Fill)
                ScreenGraphics.FillRectangle(new SolidBrush(Pen.Color), rect);
            else
                ScreenGraphics.DrawRectangle(Pen, rect);
            EndRender();
        }
        public static void Render(Pen Pen, Point Position, Point Scale, bool Fill = false) => 
            Render(Pen, (UInt16)Position.X, (UInt16)Position.Y, (UInt16)Scale.X, (UInt16)Scale.Y, Fill);

        public static void Render(Color Color, Point Position, Point Scale, bool Fill = false) => 
            Render(new Pen(Color, 2), (UInt16)Position.X, (UInt16)Position.Y, (UInt16)Scale.X, (UInt16)Scale.Y, Fill);

        public static void Render(Color Color, Byte Width, Point Position, Point Scale, bool Fill = false) =>
            Render(new Pen(Color, Width), (UInt16)Position.X, (UInt16)Position.Y, (UInt16)Scale.X, (UInt16)Scale.Y, Fill);
        public static void Render(Color Color, Byte Width, UInt16 PosX, UInt16 PosY, UInt16 ScaleX, UInt16 ScaleY, bool Fill = false) =>
            Render(new Pen(Color, Width), (UInt16)PosX, (UInt16)PosY, (UInt16)ScaleX, (UInt16)ScaleY, Fill);

    }
}
