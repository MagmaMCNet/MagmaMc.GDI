using System.Drawing;

namespace MagmaMc.GDI
{
    public class Line
    {
        private static ScreenRenderer Renderer = new ScreenRenderer();
        private readonly Pen DrawingPen;

        
        public Line(Pen Pen)
        {
            DrawingPen = Pen;

        }

        // Dynamic

        public void Render(Point StartPoint, Point EndPoint)
        {
            Renderer.StartRender();
            Renderer.ScreenGraphics.DrawLine(DrawingPen, StartPoint, EndPoint);
            Renderer.EndRender();
        }

        /// <summary>
        /// Render Line On To The Users Display
        /// </summary>
        /// <param name="StartX">The Start Points X Value</param>
        /// <param name="StartY">The Start Points Y Value</param>
        /// <param name="EndX">The End Points X Value</param>
        /// <param name="EndY">The End Points Y Value</param>
        public void Render(short StartX, short StartY, short EndX, short EndY)
        {
            Renderer.StartRender();
            Renderer.ScreenGraphics.DrawLine(DrawingPen, new Point(StartX, StartY), new Point(EndX, EndY));
            Renderer.EndRender();
        }

        // Static 

        /// <summary>
        /// Render Line On To The Users Display
        /// </summary>
        /// <param name="Pen">Pen Object</param>
        /// <param name="StartX">The Start Point X Value</param>
        /// <param name="StartY">The Start Point Y Value</param>
        /// <param name="EndX">The End Point X Value</param>
        /// <param name="EndY">The End Point Y Value</param>
        public static void Render(Pen Pen, short StartX, short StartY, short EndX, short EndY)
        {
            Renderer.StartRender();
            Renderer.ScreenGraphics.DrawLine(Pen, new Point(StartX, StartY), new Point(EndX, EndY));
            Renderer.EndRender();

        }
        
        /// <summary>
        /// Render Line On To The Users Display
        /// </summary>
        /// <param name="color">Color Of Which To Render The Line</param>
        /// <param name="StartPoint">Start Point Of Line</param>
        /// <param name="EndPoint">End Point Of Line</param>
        public static void Render(Color color, Point StartPoint, Point EndPoint) => 
                Render(new Pen(color, 2), (short)StartPoint.X, (short)StartPoint.Y, (short)EndPoint.X, (short)EndPoint.Y);

        /// <summary>
        /// Render Line On To The Users Display
        /// </summary>
        /// <param name="color">Color Of Which To Render The Line</param>
        /// <param name="Width">How Thick The Render The Line</param>
        /// <param name="StartPoint">Start Point Of Line</param>
        /// <param name="EndPoint">End Point Of Line</param>
        public static void Render(Color color, byte Width, Point StartPoint, Point EndPoint) => 
                Render(new Pen(color, Width), (short)StartPoint.X, (short)StartPoint.Y, (short)EndPoint.X, (short)EndPoint.Y);

        /// <summary>
        /// Render Line On To The Users Display
        /// </summary>
        /// <param name="color">Color Of Which To Render The Line</param>
        /// <param name="StartX">The Start Point X Value</param>
        /// <param name="StartY">The Start Point Y Value</param>
        /// <param name="EndX">The End Point X Value</param>
        /// <param name="EndY">The End Point Y Value</param>
        public static void Render(Color color, short StartX, short StartY, short EndX, short EndY) => 
                Render(new Pen(color, 2), StartX, StartY, EndX, EndY);

        /// <summary>
        /// Render Line On To The Users Display
        /// </summary>
        /// <param name="color">Color Of Which To Render The Line</param>
        /// <param name="Width">How Thick The Render The Line</param>
        /// <param name="StartX">The Start Point X Value</param>
        /// <param name="StartY">The Start Point Y Value</param>
        /// <param name="EndX">The End Point X Value</param>
        /// <param name="EndY">The End Point Y Value</param>
        public static void Render(Color color, byte Width, short StartX, short StartY, short EndX, short EndY) => 
            Render(new Pen(color, Width), StartX, StartY, EndX, EndY);
    }
}
