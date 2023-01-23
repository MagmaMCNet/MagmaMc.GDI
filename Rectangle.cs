using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Metadata;
using System.Reflection;
using static MagmaMc.GDI.Utils;
using Rect = System.Drawing.Rectangle;
namespace MagmaMc.GDI
{
    public class Rectangle
    {
        #region Static
        private static IntPtr BaseWindow = GetDesktopWindow();
        private static IntPtr Window;
        private static Graphics ScreenGraphics;
        public TernaryRaster DefaultSetting { get; private set; } = TernaryRaster.None;
        public Pen DrawingPen { get; private set; }

        public static void StartRender()
        {
            Window = GetDC(BaseWindow);
            ScreenGraphics = Graphics.FromHdc(Window);
        }
        public static void EndRender() => ReleaseDC(BaseWindow, Window);
        #endregion


        public static void Render(TernaryRaster TRO, Point Position, Point Scale)
        {
            StartRender();
            Rect rect = new Rect(Position, (Size)Scale);
            StretchBlt(Window, rect.X, rect.Y, rect.Width, rect.Height, Window, rect.Width, rect.Height, rect.Width, rect.Height, TRO);
            EndRender();
        }
        public static void Render(Pen Pen, Point Position, Point Scale)
        {
            StartRender();
            Rect rect = new Rect(Position, (Size)Scale);
            ScreenGraphics.DrawRectangle(Pen, rect);
            EndRender();
        }


    }
}
