using System;
using System.Drawing;
using static MagmaMc.GDI.Utils;
using Rect = System.Drawing.Rectangle;
namespace MagmaMc.GDI
{
    public class Box
    {

        private static ScreenRenderer Renderer = new ScreenRenderer();

        public static void Fill(Color Color)
        {
            Renderer.StartRender();
            Renderer.ScreenGraphics.FillRectangle(new SolidBrush(Color), new Rect(0, 0, 1000000, 199929));
            Renderer.EndRender();

        }

        /// <summary>
        /// Renders A Box On To The Screen
        /// </summary>s
        /// <param name="TernaryRaster">TernaryRasterOperations</param>
        /// <param name="Source">Gets Image From Display Using Rectangle</param>
        /// <param name="Destination">Sets Image On Display Using Rectangle</param>
        public static void Render(TernaryRaster TernaryRaster, Rect Source, Rect Destination) =>
                Render(TernaryRaster, Source, Destination, 0, 0);

        /// <summary>
        /// Renders A Box On To The Screen
        /// </summary>
        /// <param name="TernaryRaster">TernaryRasterOperations</param>
        /// <param name="Source">Gets Image From Display Using Rectangle</param>
        /// <param name="Destination">Sets Image On Display Using Rectangle</param>
        /// <param name="RandomNumber">How Much noise The Image Position And Scale Has</param>
        public static void Render(TernaryRaster TernaryRaster, Rect Source, Rect Destination, byte RandomNumber = 2) =>
                Render(TernaryRaster, Source, Destination, RandomNumber, RandomNumber);

        /// <summary>
        /// Renders A Box On To The Screen
        /// </summary>
        /// <param name="TernaryRaster">TernaryRasterOperations</param>
        /// <param name="Source">Gets Image From Display Using Rectangle</param>
        /// <param name="Destination">Sets Image On Display Using Rectangle</param>
        /// <param name="RandomPosition">How Much Noise The Image Position Has</param>
        /// <param name="RandomScale">How Much Noise The Image Scale Has</param>
        public static void Render(TernaryRaster TernaryRaster, Rect Source, Rect Destination, byte RandomPosition = 2, byte RandomScale = 2)
        {
            Renderer.StartRender();
            Random R = new Random();
            Source.X = Source.X + R.Next(-RandomPosition, RandomPosition);
            Source.Y = Source.Y + R.Next(-RandomPosition, RandomPosition);
            Source.Width = Source.Width + R.Next(-RandomScale, RandomScale);
            Source.Height = Source.Height + R.Next(-RandomScale, RandomScale);
            StretchBlt(Renderer.Screen, 
                Source.X, Source.Y, Source.Width, Source.Height, Renderer.Screen, 
                Destination.X, Destination.Y, Destination.Width, Destination.Height, TernaryRaster);
        }


        /// <summary>
        /// Renders A Box On To The Screen
        /// </summary>
        /// <param name="Pen"></param>
        /// <param name="PosX">Start Position Of The Box</param>
        /// <param name="PosY">Start Position Of The Box</param>
        /// <param name="ScaleX">Width Of Box Anchored On The TopLeft</param>
        /// <param name="ScaleY">Height Of Box Anchored On The TopLeft</param>
        /// <param name="Fill">Fill In The Box With Set Color</param>
        public static void Render(Pen Pen, short PosX, short PosY, ushort ScaleX, ushort ScaleY, bool Fill = false)
        {
            Renderer.StartRender();
            Rect rect = new Rect(new Point(PosX, PosY), new Size(ScaleX, ScaleY));
            if (Fill)
                Renderer.ScreenGraphics.FillRectangle(new SolidBrush(Pen.Color), rect);
            else
                Renderer.ScreenGraphics.DrawRectangle(Pen, rect);
            Renderer.EndRender();
        }

        /// <summary>
        /// Renders A Box On To The Screen
        /// </summary>
        /// <param name="Pen">Pen To Draw Box With</param>
        /// <param name="Position">Position To Start The Box At</param>
        /// <param name="Scale">Width And Height Of The Box Anchored At The TopLeft</param>
        /// <param name="Fill">Fill In The Box With Set Color</param>
        public static void Render(Pen Pen, Point Position, Point Scale, bool Fill = false) =>
            Render(Pen, (short)Position.X, (short)Position.Y, (ushort)Scale.X, (ushort)Scale.Y, Fill);

        /// <summary>
        /// Renders A Box On To The Screen
        /// </summary>
        /// <param name="Color">Color To Draw Box With</param>
        /// <param name="Position">Position To Start The Box At</param>
        /// <param name="Scale">Width And Height Of The Box Anchored At The TopLeft</param>
        /// <param name="Fill">Fill In The Box With Set Color</param>
        public static void Render(Color Color, Point Position, Point Scale, bool Fill = false) =>
            Render(new Pen(Color, 2), (short)Position.X, (short)Position.Y, (ushort)Scale.X, (ushort)Scale.Y, Fill);

        /// <summary>
        /// Renders A Box On To The Screen
        /// </summary>
        /// <param name="Color">Color To Draw Box With</param>
        /// <param name="Width">How Thick The Border Is</param>
        /// <param name="Position">Position To Start The Box At</param>
        /// <param name="Scale">Width And Height Of The Box Anchored At The TopLeft</param>
        /// <param name="Fill">Fill In The Box With Set Color</param>
        public static void Render(Color Color, byte Width, Point Position, Point Scale, bool Fill = false) =>
            Render(new Pen(Color, Width), (short)Position.X, (short)Position.Y, (ushort)Scale.X, (ushort)Scale.Y, Fill);

        /// <summary>
        /// Renders A Box On To The Screen
        /// </summary>
        /// <param name="Color">Color To Draw Box With</param>
        /// <param name="Width">How Thick The Border Is</param>
        /// <param name="PosX">Start Position Of The Box</param>
        /// <param name="PosY">Start Position Of The Box</param>
        /// <param name="ScaleX">Width Of Box Anchored On The TopLeft</param>
        /// <param name="ScaleY">Height Of Box Anchored On The TopLeft</param>
        /// <param name="Fill">Fill In The Box With Set Color</param>
        public static void Render(Color Color, byte Width, short PosX, short PosY, ushort ScaleX, ushort ScaleY, bool Fill = false) =>
            Render(new Pen(Color, Width), PosX, PosY, ScaleX, ScaleY, Fill);

    }
}
