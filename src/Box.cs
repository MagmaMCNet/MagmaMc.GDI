using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Metadata;
using System.Reflection;
using static MagmaMc.GDI.src.Utils;
using Rect = System.Drawing.Rectangle;

namespace MagmaMc.GDI.src
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


        public static void Render(Pen Pen, ushort PosX, ushort PosY, ushort ScaleX, ushort ScaleY, bool Fill = false)
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
            Render(Pen, (ushort)Position.X, (ushort)Position.Y, (ushort)Scale.X, (ushort)Scale.Y, Fill);

        public static void Render(Color Color, Point Position, Point Scale, bool Fill = false) =>
            Render(new Pen(Color, 2), (ushort)Position.X, (ushort)Position.Y, (ushort)Scale.X, (ushort)Scale.Y, Fill);

        public static void Render(Color Color, byte Width, Point Position, Point Scale, bool Fill = false) =>
            Render(new Pen(Color, Width), (ushort)Position.X, (ushort)Position.Y, (ushort)Scale.X, (ushort)Scale.Y, Fill);
        public static void Render(Color Color, byte Width, ushort PosX, ushort PosY, ushort ScaleX, ushort ScaleY, bool Fill = false) =>
            Render(new Pen(Color, Width), PosX, PosY, ScaleX, ScaleY, Fill);

    }
}
