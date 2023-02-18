using MagmaMc.GDI;
using System.Threading;
using System.Drawing;
using static MagmaMc.GDI.Utils;
namespace Testing
{

    public class Tester
    {
#if DEBUG
        public static void Main(string[] args)
        {
            Utils.StopWallpaperEngine(true);
            while (true)
            {

                Rectangle Source = new Rectangle(0, 0, 1000, 1000);
                Rectangle Destination = new Rectangle(0, 0, 1000, 1000);

                Box.Render(Utils.TernaryRaster.SRCPAINT, Source, Destination, 3);
               

                //Graphic.Render(new GIF("Ring.gif"), new Point(100, 500));
                //Line.Render(Color.White,
                   // 200, -50,
                  //  1000, 100
                 //   );

                //Text.Render("Test Text", new Point(500, 400));
                Thread.Sleep(100);
            }
        }
#else
        private static void Main(string[] args) => throw = new NotImplementedException();
#endif

    }

}