using Microsoft.VisualBasic;
using System.Drawing;
using System.Runtime.Versioning;
using static MagmaMc.GDI.src.Utils;
using System.Windows;
using System.Threading;

namespace MagmaMc.GDI.src
{
    /*
     * Static Line Generator *
     * Dynamic Line Generator *
     * Square Generator *
     * TernaryRasterOptions *
     */

    public static class GDI
    {
#if DEBUG
        private static void Main(string[] args)
        {
            StopWallpaperEngine(true);
            while (true)
            {
                Thread.Sleep(100);


                Line.Render(Color.White, new Point(200, 50), new Point(1000, 100));

                Image.Render((Bitmap)System.Drawing.Image.FromFile("icon.png"), new Point(100, 500));

                Box.Render(new Pen(Color.White), new Point(300, 200), new Point(300, 200), true);

            }
        }
#else
        private static void Main(string[] args) => throw new NotImplementedException();
#endif
    }

}