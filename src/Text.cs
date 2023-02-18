using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagmaMc.GDI
{
    public class Text
    {
        private static ScreenRenderer Renderer = new ScreenRenderer();
        /// <summary>
        /// Renders Text To The Display
        /// </summary>
        /// <param name="text">The String</param>
        /// <param name="Brush"></param>
        /// <param name="x">Position</param>
        /// <param name="y">Position</param>
        /// <param name="Font">Font To Display Text In</param>
        public static void Render(string text, Brush Brush, short x, short y, Font Font)
        {
            Renderer.StartRender();
            Renderer.ScreenGraphics.DrawString(text, (Font ?? new Font("Segoe UI Light", 15)), Brush, new Point(x, y));
            Renderer.EndRender();
        }

        /// <summary>
        /// Renders Text To The Display
        /// </summary>
        /// <param name="text">The String</param>
        /// <param name="x">Position</param>
        /// <param name="y">Position</param>
        /// <param name="Font">Font To Display Text In</param>
        public static void Render(string text, short x, short y, Font Font = null) => 
                Render(text, new SolidBrush(Color.WhiteSmoke), x, y, Font);

        /// <summary>
        /// Renders Text To The Display
        /// </summary>
        /// <param name="text">The String</param>
        /// <param name="Color">Color To Render The Text In</param>
        /// <param name="x">Position</param>
        /// <param name="y">Position</param>
        /// <param name="Font">Font To Display Text In</param>
        public static void Render(string text, Color Color, short x, short y, Font Font = null) => 
                Render(text, new SolidBrush(Color), x, y, Font);

        /// <summary>
        /// Renders Text To The Display
        /// </summary>
        /// <param name="text">The String</param>
        /// <param name="Position"></param>
        /// <param name="Font">Font To Display Text In</param>
        public static void Render(string text, Point Position, Font Font = null) =>
                Render(text, new SolidBrush(Color.WhiteSmoke), (short)Position.X, (short)Position.Y, Font);

        /// <summary>
        /// Renders Text To The Display
        /// </summary>
        /// <param name="text">The String</param>
        /// <param name="Color">Color To Render The Text In</param>
        /// <param name="Position"></param>
        /// <param name="Font">Font To Display Text In</param>
        public static void Render(string text, Color Color, Point Position, Font Font = null) => 
                Render(text, new SolidBrush(Color), (short)Position.X, (short)Position.Y, Font);
    }
}
