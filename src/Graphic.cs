using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;
using static MagmaMc.GDI.Utils;

namespace MagmaMc.GDI
{
    public class Graphic : ScreenRenderer
    {

        /// <summary>
        /// Renders A Bitmap Image To The Display
        /// </summary>
        public static void Render(Bitmap BitmapImage, short PositionX, short PositionY, float ResX, float ResY)
        {
            Renderer.StartRender();
            BitmapImage.SetResolution(ResX*BitmapImage.HorizontalResolution, ResY * BitmapImage.VerticalResolution);
            Renderer.ScreenGraphics.DrawImage(BitmapImage, PositionX, PositionY);
            Renderer.EndRender();
        }

        /// <summary>
        /// Renders A Icon Image To The Display
        /// </summary>
        public static void Render(Icon IconImage, Point Position) =>
                Render(IconImage.ToBitmap(), (short)Position.X, (short)Position.Y, 1, 1);

        /// <summary>
        /// Renders A Icon Image To The Display
        /// </summary>
        public static void Render(Icon IconImage, Point Position, PointF Resolution) =>
                Render(IconImage.ToBitmap(), (short)Position.X, (short)Position.Y, Resolution.X, Resolution.Y);



        /// <summary>
        /// Renders A Icon Image To The Display
        /// </summary>
        public static void Render(Icon IconImage, short PositionX, short PositionY) =>
                Render(IconImage.ToBitmap(), PositionX, PositionY, 1, 1);



        /// <summary>
        /// Renders A Icon Image To The Display
        /// </summary>
        public static void Render(Icon IconImage, short PositionX, short PositionY, float ResolutionX, float ResolutionY) =>
                Render(IconImage.ToBitmap(), PositionX, PositionY, ResolutionX, ResolutionY);




        /// <summary>
        /// Renders A Bitmap Image To The Display
        /// </summary>
        public static void Render(Bitmap BitmapImage, short PositionX, short PositionY) =>
                Render(BitmapImage, (short)PositionX, PositionY, 1, 1);


        /// <summary>
        /// Renders A Bitmap Image To The Display
        /// </summary>
        public static void Render(Bitmap BitmapImage, Point Position, PointF Resolution) =>
                Render(BitmapImage, (short)Position.X, (short)Position.Y, Resolution.X, Resolution.Y);




        /// <summary>
        /// Renders A Image To The Display
        /// </summary>
        public static void Render(Image Image, Point Position) =>
                Render((Bitmap)Image, (short)Position.X, (short)Position.Y, 1, 1);

        /// <summary>
        /// Renders A Image To The Display
        /// </summary>
        public static void Render(Image Image, Point Position, PointF Resolution) =>
                Render((Bitmap)Image, (short)Position.X, (short)Position.Y, Resolution.X, Resolution.Y);

        /// <summary>
        /// Renders A Image To The Display
        /// </summary>
        public static void Render(Image Image, short PositionX, short PositionY) =>
                Render((Bitmap)Image, PositionX, PositionY, 1, 1);

        /// <summary>
        /// Renders A Image To The Display
        /// </summary>
        public static void Render(Image Image, short PositionX, short PositionY, float ResolutionX, float ResolutionY) =>
                Render((Bitmap)Image, PositionX, PositionY, ResolutionX, ResolutionY);



        /// <summary>
        /// Renders A GIF To The Display
        /// </summary>
        public static void Render(
            GIF Image, short PosX, short PosY, float ResX, float ResY, bool Play = true, ulong Loop = 1, ushort Delay = 10, ushort Frame = 0, bool await = true)
        {

            Task t = Task.Run(() =>
            {
                bool Rendered = false;
                while (!Rendered) 
                    try
                    {
                        ScreenRenderer screenRenderer = new ScreenRenderer();
                        screenRenderer.StartRender();
                        if (Play)

                            for (ulong i = 0; i < Loop; i++)
                                for (int Index = 0; Index < Image.Frames; Index++)
                                {
                                    Image.Image.SelectActiveFrame(Image.Dimension, Index);
                                    Bitmap bitmap = (Bitmap)Image.Image;
                                    bitmap.SetResolution(ResX * bitmap.HorizontalResolution, ResY * bitmap.VerticalResolution);
                                    screenRenderer.ScreenGraphics.DrawImage(bitmap, new Point(PosX, PosY));
                                    Thread.Sleep(Delay);
                                }
                        else
                        {
                            Image.Image.SelectActiveFrame(Image.Dimension, Frame);
                            Bitmap bitmap = (Bitmap)Image.Image;
                            bitmap.SetResolution(ResX * bitmap.HorizontalResolution, ResY * bitmap.VerticalResolution);
                            screenRenderer.ScreenGraphics.DrawImage(bitmap, new Point(PosX, PosY));
                        }
                        screenRenderer.EndRender();
                        Rendered = true;
                    } catch { }
            });
            if (await)
                t.Wait();
        }


        /// <summary>
        /// Renders A GIF To The Display
        /// </summary>
        public static void Render(GIF Image, Point Position,
            bool Play = true, ulong Loop = 1, ushort Delay = 10, ushort Frame = 0, bool await = true) =>
                Render(Image, (short)Position.X, (short)Position.Y, 1, 1, Play, Loop, Delay, Frame, await);

        /// <summary>
        /// Renders A GIF To The Display
        /// </summary>
        public static void Render(GIF Image, Point Position, PointF Resolution,
            bool Play = true, ulong Loop = 1, ushort Delay = 10, ushort Frame = 0, bool await = true) =>
                Render(Image, (short)Position.X, (short)Position.Y, Resolution.X, Resolution.Y, Play, Loop, Delay, Frame, await);


    }
}
