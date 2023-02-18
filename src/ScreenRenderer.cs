using System;
using System.Drawing;

namespace MagmaMc.GDI
{
#if NET5_0_OR_GREATER
    [SupportedOSPlatform("windows")]
#endif
    public class ScreenRenderer
    {
        public IntPtr BaseWindow { get; private set; } = Utils.GetDesktopWindow();
        public IntPtr Screen { get; private set; }
        public Graphics ScreenGraphics { get; private set; }

        /// <summary>
        /// Call This Before Using <c>ScreenGraphics</c> or <c>Screen</c>
        /// </summary>
        public void StartRender()
        {
            if (Screen != IntPtr.Zero)
                return;
            Screen = Utils.GetDC(BaseWindow);
            ScreenGraphics = Graphics.FromHdc(Screen);
        }


        /// <summary>
        /// Call this After Rendering Objects To Screen On That Frame
        /// Not needed
        /// </summary>
        [Obsolete]
        public void EndRender() => Utils.ReleaseDC(BaseWindow, Screen);

        /// <summary>
        /// Static Version Of ScreenRenderer For Static Classes|Functions
        /// </summary>
        public static ScreenRenderer Renderer { get; private set; } = new ScreenRenderer();

    }
}
