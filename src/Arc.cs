using System;
using System.Collections.Generic;
using System.Drawing;
using MagmaMc.GDI;
namespace MagmaMc.GDI
{
    public class Arc
    {
        private static ScreenRenderer Renderer = new ScreenRenderer();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PosX">X Position To Create The Arc At</param>
        /// <param name="PosY">Y Position To Create The Arc At</param>
        /// <param name="Width">Arc Line Width</param>
        /// <param name="Height">Arc Line Height</param>
        /// <param name="StartAngle">How Much To Start The Angle At</param>
        /// <param name="SweepAngle"></param>
        public static void Render(short PosX, short PosY, ushort Width, ushort Height, float StartAngle, float SweepAngle)
        {
            Renderer.StartRender();
            Renderer.ScreenGraphics.DrawArc(Pens.Red, new Rectangle(PosX, PosY, Width, Height), StartAngle, SweepAngle);
            Renderer.EndRender();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Position">Position To Create The Arc At</param>
        /// <param name="Size">Width And Height Of The Arc Line</param>
        /// <param name="Height">Arc Line Height</param>
        /// <param name="StartAngle">How Much To Start The Angle At</param>
        public static void Render(Point Position, Point Size, float StartAngle, float SweepAngle) =>
                Render((short)Position.X, (short)Position.Y, (ushort)Size.X, (ushort)Size.Y, StartAngle, SweepAngle);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect">X, Y, Width, Height</param>
        /// <param name="Height">Arc Line Height</param>
        /// <param name="StartAngle">How Much To Start The Angle At</param>
        public static void Render(Rectangle rect, float StartAngle, float SweepAngle) =>
                Render((short)rect.X, (short)rect.Y, (ushort)rect.Width, (ushort)rect.Height, StartAngle, SweepAngle);
    }
}
