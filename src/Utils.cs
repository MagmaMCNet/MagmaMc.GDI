using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace MagmaMc.GDI
{
    /// <summary>
    /// GIF Image Base Class
    /// </summary>
    public class GIF
    {
        public int Frames { get; private set; }
        public Image Image { get; private set; }
        public FrameDimension Dimension { get; private set; }
        // Image Settings
        public float HorizontalResolution { get; private set; }
        public float VerticalResolution { get; private set; }

        public GIF(string Path)
        {
            Image = Image.FromFile(Path);
            Set();
        }
        public GIF(Image IMG)
        {
            Image = Image = IMG;
            Set();
        }

        private void Set()
        {
            HorizontalResolution = Image.HorizontalResolution;
            VerticalResolution = Image.VerticalResolution;
            Dimension = new FrameDimension(Image.FrameDimensionsList[0]);
            Frames = Image.GetFrameCount(Dimension);

        }
    }
        public static class Utils
    {

        /// <summary>
        /// Is Here Becuase Wallpaper Engine Breaks The Rendering On Every Frame It Updates
        /// </summary>
        /// <param name="AskUser"></param>

        public static void StopWallpaperEngine(bool AskUser = true)
        {
            bool CanClose = !AskUser;
            Process[] WallpaperEngine = Process.GetProcessesByName("wallpaper32");
            if (WallpaperEngine.Length == 0)
                return;
            if (AskUser)
            {
                while (true)
                {
                    Console.Clear();
                    Console.Write(
                     "\nMagmaMc.GDI:\n" +
                     " There Is A Problem With Rendering Graphics To Screen With Wallpaper Engine,\n" +
                     " The Program Is Asking To Force Close It,\n" +
                     " Would You Like To Force Close It,\n" +
                     " (Y | n):");
                    char key = Console.ReadKey().KeyChar;
                    if (key == 'n' || key == 'N')
                    {
                        CanClose = false;
                        return;
                    }
                    else if (key == 'y' || key == 'Y')
                    {
                        Console.WriteLine();
                        CanClose = true;
                        break;
                    }
                }
            }
            if (CanClose)
                foreach (Process process in WallpaperEngine) { process.Kill(); }
        }


#region Imports
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();


        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("gdi32.dll")]
        public static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest,
        int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc,
        TernaryRaster dwRop);


        public enum TernaryRaster
        {
            NONE = 0,
            SRCCOPY = 0x00CC0020,
            SRCPAINT = 0x00EE0086,
            SRCAND = 0x008800C6,
            SRCINVERT = 0x00660046,
            SRCERASE = 0x00440328,
            NOTSRCCOPY = 0x00330008,
            NOTSRCERASE = 0x001100A6,
            MERGECOPY = 0x00C000CA,
            MERGEPAINT = 0x00BB0226,
            PATCOPY = 0x00F00021,
            PATPAINT = 0x00FB0A09,
            PATINVERT = 0x005A0049,
            DSTINVERT = 0x00550009,
            BLACKNESS = 0x00000042,
            WHITENESS = 0x00FF0062,
        }
#endregion

    }
}
