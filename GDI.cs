using Microsoft.VisualBasic;
using System.Drawing;
using System.Runtime.Versioning;
using static MagmaMc.GDI.Utils;
namespace MagmaMc.GDI
{
    /*
     * Static Line Generator *
     * Dynamic Line Generator *
     * TernaryRasterOptions *
     */

    public static class GDI
    {
#if DEBUG
        private static void Main(string[] args)
        {
            while (true)
            {
                Thread.Sleep(100);
                Line.Render(Color.Red, 500, 2000,  200, 600);
                Rectangle.Render(TernaryRaster.WHITENESS, new Point(100,200), new Point(50,50));
            }
        }
#else
        private static void Main(string[] args) => throw new NotImplementedException();
#endif
    }

}