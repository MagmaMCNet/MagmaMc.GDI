using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MagmaMc.GDI.src
{
    public static class Utils
    {

        /// <summary>
        /// Is Here Becuase Wallpaper Engine Breaks With Rendering
        /// </summary>
        /// <param name="AskUser"></param>

        public static void StopWallpaperEngine(bool AskUser)
        {
            Process[] processes = Process.GetProcessesByName("wallpaper32");
            if (processes.Length == 0)
                return;
            if (AskUser)
            {
                Console.Write("Application Is Asking To Force Close Wallpaper Engine Becuase Of Will Be Unable To Render Properly,\nWould You Like It To Do This (Y: Yes, N: No): ");
                char key = Console.ReadKey().KeyChar;
                if (key == 'n')
                    return;

            }
            foreach (Process process in processes)
            {
                process.Kill();
            }
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
            None = 0,
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
