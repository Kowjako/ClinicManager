// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonHelpers.WinApi
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using Microsoft.Win32;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;

namespace System.Windows.Forms.RibbonHelpers
{
  public static class WinApi
  {
    public const int SWP_NOSIZE = 1;
    public const int SWP_NOMOVE = 2;
    public const int SWP_NOZORDER = 4;
    public const int SWP_NOREDRAW = 8;
    public const int SWP_NOACTIVATE = 16;
    public const int SWP_FRAMECHANGED = 32;
    public const int SWP_DRAWFRAME = 32;
    public const int SWP_SHOWWINDOW = 64;
    public const int SWP_HIDEWINDOW = 128;
    public const int SWP_NOCOPYBITS = 256;
    public const int SWP_NOOWNERZORDER = 512;
    public const int SWP_NOREPOSITION = 512;
    public const int SWP_NOSENDCHANGING = 1024;
    public const int WM_MOUSEFIRST = 512;
    public const int WM_MOUSEMOVE = 512;
    public const int WM_LBUTTONDOWN = 513;
    public const int WM_LBUTTONUP = 514;
    public const int WM_LBUTTONDBLCLK = 515;
    public const int WM_RBUTTONDOWN = 516;
    public const int WM_RBUTTONUP = 517;
    public const int WM_RBUTTONDBLCLK = 518;
    public const int WM_MBUTTONDOWN = 519;
    public const int WM_MBUTTONUP = 520;
    public const int WM_MBUTTONDBLCLK = 521;
    public const int WM_MOUSEWHEEL = 522;
    public const int WM_XBUTTONDOWN = 523;
    public const int WM_XBUTTONUP = 524;
    public const int WM_XBUTTONDBLCLK = 525;
    public const int WM_MOUSELAST = 525;
    public const int WM_KEYDOWN = 256;
    public const int WM_KEYUP = 257;
    public const int WM_SYSKEYDOWN = 260;
    public const int WM_SYSKEYUP = 261;
    public const byte VK_SHIFT = 16;
    public const byte VK_CAPITAL = 20;
    public const byte VK_NUMLOCK = 144;
    private const int DTT_COMPOSITED = 8192;
    private const int DTT_GLOWSIZE = 2048;
    private const int DT_SINGLELINE = 32;
    private const int DT_CENTER = 1;
    private const int DT_VCENTER = 4;
    private const int DT_NOPREFIX = 2048;
    public const int CS_DROPSHADOW = 131072;
    public const int WH_MOUSE_LL = 14;
    public const int WH_KEYBOARD_LL = 13;
    public const int WH_MOUSE = 7;
    public const int WH_KEYBOARD = 2;
    public const int WM_NCLBUTTONDOWN = 161;
    public const int WM_NCLBUTTONUP = 162;
    internal const int WM_NCRBUTTONUP = 165;
    public const int WM_SIZE = 5;
    public const int WM_ERASEBKGND = 20;
    public const int WM_NCCALCSIZE = 131;
    public const int WM_NCHITTEST = 132;
    public const int WM_NCMOUSEMOVE = 160;
    public const int WM_NCMOUSELEAVE = 674;
    public const int WM_NCPAINT = 133;
    public const int WM_NCACTIVATE = 134;
    public const int WM_SYSCOMMAND = 274;
    public const int WM_WINDOWPOSCHANGING = 70;
    public const int WM_WINDOWPOSCHANGED = 71;
    public const int WM_PAINT = 15;
    public const int WM_ACTIVATE = 6;
    public const int WM_THEMECHANGED = 794;
    internal const int MF_BYCOMMAND = 0;
    internal const int MF_BYPOSITION = 1024;
    internal const int MF_ENABLED = 0;
    internal const int MF_GRAYED = 1;
    internal const int MF_DISABLED = 2;
    public const int SC_RESTORE = 61728;
    internal const int SC_SIZE = 61440;
    internal const int SC_MOVE = 61456;
    internal const int SC_MINIMIZE = 61472;
    internal const int SC_MAXIMIZE = 61488;
    internal const int SC_CLOSE = 61536;
    public const int BI_RGB = 0;
    public const int DIB_RGB_COLORS = 0;
    public const int SRCCOPY = 13369376;
    public const uint TPM_LEFTBUTTON = 0;
    public const uint TPM_RETURNCMD = 256;
    private static int[] mfFlags = new int[2]{ 1, 0 };

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool RedrawWindow(
      IntPtr hWnd,
      [In] ref WinApi.RECT lprcUpdate,
      IntPtr hrgnUpdate,
      uint flags);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool RedrawWindow(
      IntPtr hWnd,
      IntPtr lprcUpdate,
      IntPtr hrgnUpdate,
      uint flags);

    [DllImport("user32.dll")]
    internal static extern bool SetWindowPos(
      IntPtr hWnd,
      IntPtr hWndInsertAfter,
      int X,
      int Y,
      int cx,
      int cy,
      uint uFlags);

    [DllImport("user32")]
    internal static extern bool GetCursorPos(out WinApi.POINT lpPoint);

    [DllImport("user32")]
    internal static extern int ToAscii(
      int uVirtKey,
      int uScanCode,
      byte[] lpbKeyState,
      byte[] lpwTransKey,
      int fuState);

    [DllImport("user32")]
    internal static extern int GetKeyboardState(byte[] pbKeyState);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    internal static extern short GetKeyState(int vKey);

    [DllImport("user32.dll")]
    internal static extern int GetWindowRect(IntPtr hwnd, ref WinApi.RECT lpRect);

    [DllImport("user32.dll")]
    internal static extern IntPtr GetDCEx(IntPtr hwnd, IntPtr hrgnclip, uint fdwOptions);

    [DllImport("user32.dll")]
    internal static extern IntPtr SetWindowsHookEx(
      int idHook,
      GlobalHook.HookProcCallBack lpfn,
      IntPtr hInstance,
      int threadId);

    [DllImport("user32.dll")]
    internal static extern bool UnhookWindowsHookEx(IntPtr idHook);

    [DllImport("user32.dll")]
    internal static extern IntPtr CallNextHookEx(
      IntPtr idHook,
      int nCode,
      IntPtr wParam,
      IntPtr lParam);

    [DllImport("user32.dll")]
    internal static extern IntPtr GetDC(IntPtr hdc);

    [DllImport("gdi32.dll")]
    internal static extern int SaveDC(IntPtr hdc);

    [DllImport("user32.dll")]
    internal static extern int ReleaseDC(IntPtr hdc, IntPtr state);

    [DllImport("UxTheme.dll", CharSet = CharSet.Unicode)]
    private static extern int DrawThemeTextEx(
      IntPtr hTheme,
      IntPtr hdc,
      int iPartId,
      int iStateId,
      string text,
      int iCharCount,
      int dwFlags,
      ref WinApi.RECT pRect,
      ref WinApi.DTTOPTS pOptions);

    [DllImport("UxTheme.dll", CharSet = CharSet.Unicode)]
    internal static extern int DrawThemeText(
      IntPtr hTheme,
      IntPtr hdc,
      int iPartId,
      int iStateId,
      string text,
      int iCharCount,
      int dwFlags1,
      int dwFlags2,
      ref WinApi.RECT pRect);

    [DllImport("gdi32.dll")]
    private static extern IntPtr CreateDIBSection(
      IntPtr hdc,
      ref WinApi.BITMAPINFO pbmi,
      uint iUsage,
      IntPtr ppvBits,
      IntPtr hSection,
      uint dwOffset);

    [DllImport("gdi32.dll")]
    internal static extern bool BitBlt(
      IntPtr hdc,
      int nXDest,
      int nYDest,
      int nWidth,
      int nHeight,
      IntPtr hdcSrc,
      int nXSrc,
      int nYSrc,
      uint dwRop);

    [DllImport("gdi32.dll")]
    internal static extern IntPtr CreateCompatibleDC(IntPtr hDC);

    [DllImport("gdi32.dll")]
    internal static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

    [DllImport("gdi32.dll")]
    internal static extern bool DeleteObject(IntPtr hObject);

    [DllImport("gdi32.dll")]
    internal static extern bool DeleteDC(IntPtr hdc);

    [DllImport("dwmapi.dll")]
    internal static extern int DwmExtendFrameIntoClientArea(IntPtr hdc, ref WinApi.MARGINS marInset);

    [DllImport("dwmapi.dll")]
    internal static extern int DwmDefWindowProc(
      IntPtr hwnd,
      int msg,
      IntPtr wParam,
      IntPtr lParam,
      out IntPtr result);

    [DllImport("dwmapi.dll")]
    internal static extern int DwmIsCompositionEnabled(ref int pfEnabled);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    internal static extern IntPtr SendMessage(
      IntPtr hWnd,
      int Msg,
      IntPtr wParam,
      IntPtr lParam);

    [DllImport("user32.dll")]
    internal static extern bool PostMessage(IntPtr hWnd, uint msg, UIntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll")]
    internal static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

    [DllImport("user32.dll")]
    internal static extern uint TrackPopupMenuEx(
      IntPtr hmenu,
      uint fuFlags,
      int x,
      int y,
      IntPtr hwnd,
      IntPtr lptpm);

    [DllImport("user32.dll")]
    internal static extern bool SetMenuDefaultItem(IntPtr hMenu, uint uItem, uint fByPos);

    [DllImport("user32.dll")]
    internal static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

    [DllImport("user32.dll")]
    internal static extern int GetSystemMetrics(WinApi.SystemMetric smIndex);

    public static bool IsWindows => Environment.OSVersion.Platform == PlatformID.Win32NT;

    public static bool IsVista => WinApi.IsWindows && Environment.OSVersion.Version.Major >= 6;

    public static bool IsXP => WinApi.IsWindows && Environment.OSVersion.Version.Major >= 5;

    public static string ReleaseID => WinApi.OSVersion.ReleaseId;

    public static bool IsWin10 => WinApi.IsWindows && WinApi.OSVersion.Version.Major == 6 && WinApi.OSVersion.Version.Minor == 3;

    public static bool IsGlassEnabled
    {
      get
      {
        if (!WinApi.IsVista)
          return false;
        int pfEnabled = 0;
        WinApi.DwmIsCompositionEnabled(ref pfEnabled);
        return pfEnabled > 0;
      }
    }

    public static void InvalidateWindow(IntPtr hDC) => WinApi.RedrawWindow(hDC, IntPtr.Zero, IntPtr.Zero, 1281U);

    public static void InvalidateNC(IntPtr hDC) => WinApi.SetWindowPos(hDC, IntPtr.Zero, 0, 0, 0, 0, 55U);

    public static short HiWord(int dwValue) => (short) (dwValue >> 16 & (int) ushort.MaxValue);

    public static short LoWord(int dwValue) => (short) (dwValue & (int) ushort.MaxValue);

    public static IntPtr MakeLParam(int LoWord, int HiWord) => new IntPtr(HiWord << 16 | LoWord & (int) ushort.MaxValue);

    internal static int Get_X_LParam(int dwValue) => (int) (short) (dwValue & (int) ushort.MaxValue);

    internal static int Get_Y_LParam(int dwValue) => (int) (short) (dwValue >> 16 & (int) ushort.MaxValue);

    public static void FillForGlass(Graphics g, Rectangle r)
    {
      WinApi.RECT rect = new WinApi.RECT()
      {
        Left = r.Left,
        Right = r.Right,
        Top = r.Top,
        Bottom = r.Bottom
      };
      IntPtr hdc = g.GetHdc();
      IntPtr compatibleDc = WinApi.CreateCompatibleDC(hdc);
      IntPtr hObject = IntPtr.Zero;
      WinApi.BITMAPINFO pbmi = new WinApi.BITMAPINFO();
      pbmi.bmiHeader.biHeight = -(rect.Bottom - rect.Top);
      pbmi.bmiHeader.biWidth = rect.Right - rect.Left;
      pbmi.bmiHeader.biPlanes = (short) 1;
      pbmi.bmiHeader.biSize = Marshal.SizeOf(typeof (WinApi.BITMAPINFOHEADER));
      pbmi.bmiHeader.biBitCount = (short) 32;
      pbmi.bmiHeader.biCompression = 0;
      if (WinApi.SaveDC(compatibleDc) != 0)
      {
        IntPtr dibSection = WinApi.CreateDIBSection(compatibleDc, ref pbmi, 0U, (IntPtr) 0, IntPtr.Zero, 0U);
        if (!(dibSection == IntPtr.Zero))
        {
          hObject = WinApi.SelectObject(compatibleDc, dibSection);
          WinApi.BitBlt(hdc, rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top, compatibleDc, 0, 0, 13369376U);
        }
        WinApi.SelectObject(compatibleDc, hObject);
        WinApi.DeleteObject(dibSection);
                WinApi.ReleaseDC(compatibleDc, (IntPtr)0);
        WinApi.DeleteDC(compatibleDc);
      }
      g.ReleaseHdc();
    }

    public static void DrawTextOnGlass(
      Graphics graphics,
      string text,
      Font font,
      Rectangle bounds,
      int glowSize)
    {
      if (!WinApi.IsGlassEnabled)
        return;
      IntPtr num = IntPtr.Zero;
      try
      {
        num = graphics.GetHdc();
        IntPtr compatibleDc = WinApi.CreateCompatibleDC(num);
        IntPtr zero = IntPtr.Zero;
        int dwFlags = 2085;
        WinApi.BITMAPINFO pbmi = new WinApi.BITMAPINFO();
        pbmi.bmiHeader.biHeight = -bounds.Height;
        pbmi.bmiHeader.biWidth = bounds.Width;
        pbmi.bmiHeader.biPlanes = (short) 1;
        pbmi.bmiHeader.biSize = Marshal.SizeOf(typeof (WinApi.BITMAPINFOHEADER));
        pbmi.bmiHeader.biBitCount = (short) 32;
        pbmi.bmiHeader.biCompression = 0;
        if (WinApi.SaveDC(compatibleDc) == 0)
          return;
        IntPtr dibSection = WinApi.CreateDIBSection(compatibleDc, ref pbmi, 0U, (IntPtr) 0, IntPtr.Zero, 0U);
        if (dibSection == IntPtr.Zero)
          return;
        IntPtr hObject1 = WinApi.SelectObject(compatibleDc, dibSection);
        IntPtr hfont = font.ToHfont();
        IntPtr hObject2 = WinApi.SelectObject(compatibleDc, hfont);
        try
        {
          VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(VisualStyleElement.Window.Caption.Active);
          WinApi.DTTOPTS pOptions = new WinApi.DTTOPTS()
          {
            dwSize = (uint) Marshal.SizeOf(typeof (WinApi.DTTOPTS)),
            dwFlags = 10240,
            iGlowSize = glowSize
          };
          WinApi.RECT pRect = new WinApi.RECT(0, 0, bounds.Width, bounds.Height);
          WinApi.DrawThemeTextEx(visualStyleRenderer.Handle, compatibleDc, 0, 0, text, -1, dwFlags, ref pRect, ref pOptions);
          WinApi.BitBlt(num, bounds.Left, bounds.Top, bounds.Width, bounds.Height, compatibleDc, 0, 0, 13369376U);
        }
        catch (Exception ex)
        {
        }
        WinApi.SelectObject(compatibleDc, hObject1);
        WinApi.SelectObject(compatibleDc, hObject2);
        WinApi.DeleteObject(dibSection);
        WinApi.DeleteObject(hfont);
        WinApi.ReleaseDC(compatibleDc, (IntPtr)0);
        WinApi.DeleteDC(compatibleDc);
      }
      finally
      {
        if (num != IntPtr.Zero)
          graphics.ReleaseHdc(num);
      }
    }

    public static void ShowSystemMenu(Form form, int xMouse, int yMouse)
    {
      IntPtr menu = WinApi.GetSystemMenu(form.Handle, false);
      FormBorderStyle formBorderStyle = form.FormBorderStyle;
      FormWindowState windowState = form.WindowState;
      if (formBorderStyle == FormBorderStyle.FixedSingle || formBorderStyle == FormBorderStyle.Sizable || formBorderStyle == FormBorderStyle.FixedToolWindow || formBorderStyle == FormBorderStyle.SizableToolWindow)
      {
        UpdateItem(61728U, (uint) windowState > 0U, true);
        UpdateItem(61456U, windowState != FormWindowState.Maximized, false);
        UpdateItem(61440U, windowState != FormWindowState.Maximized && (formBorderStyle == FormBorderStyle.Sizable || formBorderStyle == FormBorderStyle.SizableToolWindow), false);
        UpdateItem(61472U, form.MinimizeBox && (formBorderStyle == FormBorderStyle.FixedSingle || formBorderStyle == FormBorderStyle.Sizable), false);
        UpdateItem(61488U, form.MaximizeBox && (formBorderStyle == FormBorderStyle.FixedSingle || formBorderStyle == FormBorderStyle.Sizable) && windowState != FormWindowState.Maximized, true);
      }
      WinApi.SetMenuDefaultItem(menu, 61536U, 0U);
      UIntPtr zero = UIntPtr.Zero;
      UIntPtr wParam = (UIntPtr) WinApi.TrackPopupMenuEx(menu, (uint) (256UL | (ulong) WinApi.GetSystemMetrics(WinApi.SystemMetric.SM_MENUDROPALIGNMENT)), xMouse, yMouse, form.Handle, IntPtr.Zero);
      if (wParam == UIntPtr.Zero)
        return;
      WinApi.PostMessage(form.Handle, 274U, wParam, IntPtr.Zero);

      void UpdateItem(uint ID, bool enable, bool makeDefaultIfEnabled)
      {
        int index = 0;
        if (enable)
          index = 1;
        WinApi.EnableMenuItem(menu, ID, (uint) (0 | WinApi.mfFlags[index]));
        if (!(makeDefaultIfEnabled & enable))
          return;
        WinApi.SetMenuDefaultItem(menu, ID, 0U);
      }
    }

    public static void ShowSystemMenu(Form form)
    {
      WinApi.POINT lpPoint;
      if (!WinApi.GetCursorPos(out lpPoint))
        return;
      WinApi.ShowSystemMenu(form, lpPoint.x, lpPoint.y);
    }

    [StructLayout(LayoutKind.Sequential)]
    internal class MouseLLHookStruct
    {
      public WinApi.POINT pt;
      public int mouseData;
      public int flags;
      public int time;
      public int extraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal class KeyboardLLHookStruct
    {
      public int vkCode;
      public int scanCode;
      public int flags;
      public int time;
      public int dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal class MouseHookStruct
    {
      public WinApi.POINT pt;
      public int hwnd;
      public int wHitTestCode;
      public int dwExtraInfo;
    }

    internal struct POINT
    {
      public int x;
      public int y;

      public POINT(int x, int y)
      {
        this.x = x;
        this.y = y;
      }
    }

    internal struct DTTOPTS
    {
      public uint dwSize;
      public uint dwFlags;
      public uint crText;
      public uint crBorder;
      public uint crShadow;
      public int iTextShadowType;
      public WinApi.POINT ptShadowOffset;
      public int iBorderSize;
      public int iFontPropId;
      public int iColorPropId;
      public int iStateId;
      public int fApplyOverlay;
      public int iGlowSize;
      public IntPtr pfnDrawTextCallback;
      public int lParam;
    }

    private struct RGBQUAD
    {
      public readonly byte rgbBlue;
      public readonly byte rgbGreen;
      public readonly byte rgbRed;
      public readonly byte rgbReserved;
    }

    private struct BITMAPINFOHEADER
    {
      public int biSize;
      public int biWidth;
      public int biHeight;
      public short biPlanes;
      public short biBitCount;
      public int biCompression;
      public readonly int biSizeImage;
      public readonly int biXPelsPerMeter;
      public readonly int biYPelsPerMeter;
      public readonly int biClrUsed;
      public readonly int biClrImportant;
    }

    private struct BITMAPINFO
    {
      public WinApi.BITMAPINFOHEADER bmiHeader;
      public readonly WinApi.RGBQUAD bmiColors;
    }

    public struct RECT
    {
      public int Left;
      public int Top;
      public int Right;
      public int Bottom;

      public RECT(int left, int top, int right, int bottom)
      {
        this.Left = left;
        this.Top = top;
        this.Right = right;
        this.Bottom = bottom;
      }

      public RECT(Rectangle rectangle)
      {
        this.Left = rectangle.X;
        this.Top = rectangle.Y;
        this.Right = rectangle.Right;
        this.Bottom = rectangle.Bottom;
      }
    }

    internal struct NCCALCSIZE_PARAMS
    {
      public WinApi.RECT rect0;
      public WinApi.RECT rect1;
      public WinApi.RECT rect2;
      public IntPtr lppos;
    }

    internal struct MARGINS
    {
      public int cxLeftWidth;
      public int cxRightWidth;
      public int cyTopHeight;
      public int cyBottomHeight;

      public MARGINS(int Left, int Right, int Top, int Bottom)
      {
        this.cxLeftWidth = Left;
        this.cxRightWidth = Right;
        this.cyTopHeight = Top;
        this.cyBottomHeight = Bottom;
      }
    }

    [Flags]
    internal enum DCX
    {
      DCX_CACHE = 2,
      DCX_CLIPCHILDREN = 8,
      DCX_CLIPSIBLINGS = 16, // 0x00000010
      DCX_EXCLUDERGN = 64, // 0x00000040
      DCX_EXCLUDEUPDATE = 256, // 0x00000100
      DCX_INTERSECTRGN = 128, // 0x00000080
      DCX_INTERSECTUPDATE = 512, // 0x00000200
      DCX_LOCKWINDOWUPDATE = 1024, // 0x00000400
      DCX_NORECOMPUTE = 1048576, // 0x00100000
      DCX_NORESETATTRS = 4,
      DCX_PARENTCLIP = 32, // 0x00000020
      DCX_VALIDATE = 2097152, // 0x00200000
      DCX_WINDOW = 1,
    }

    public enum SystemMetric
    {
      SM_CXSCREEN = 0,
      SM_CYSCREEN = 1,
      SM_CXVSCROLL = 2,
      SM_CYHSCROLL = 3,
      SM_CYCAPTION = 4,
      SM_CXBORDER = 5,
      SM_CYBORDER = 6,
      SM_CXDLGFRAME = 7,
      SM_CXFIXEDFRAME = 7,
      SM_CYDLGFRAME = 8,
      SM_CYFIXEDFRAME = 8,
      SM_CYVTHUMB = 9,
      SM_CXHTHUMB = 10, // 0x0000000A
      SM_CXICON = 11, // 0x0000000B
      SM_CYICON = 12, // 0x0000000C
      SM_CXCURSOR = 13, // 0x0000000D
      SM_CYCURSOR = 14, // 0x0000000E
      SM_CYMENU = 15, // 0x0000000F
      SM_CXFULLSCREEN = 16, // 0x00000010
      SM_CYFULLSCREEN = 17, // 0x00000011
      SM_CYKANJIWINDOW = 18, // 0x00000012
      SM_MOUSEPRESENT = 19, // 0x00000013
      SM_CYVSCROLL = 20, // 0x00000014
      SM_CXHSCROLL = 21, // 0x00000015
      SM_DEBUG = 22, // 0x00000016
      SM_SWAPBUTTON = 23, // 0x00000017
      SM_CXMIN = 28, // 0x0000001C
      SM_CYMIN = 29, // 0x0000001D
      SM_CXSIZE = 30, // 0x0000001E
      SM_CYSIZE = 31, // 0x0000001F
      SM_CXFRAME = 32, // 0x00000020
      SM_CXSIZEFRAME = 32, // 0x00000020
      SM_CYFRAME = 33, // 0x00000021
      SM_CYSIZEFRAME = 33, // 0x00000021
      SM_CXMINTRACK = 34, // 0x00000022
      SM_CYMINTRACK = 35, // 0x00000023
      SM_CXDOUBLECLK = 36, // 0x00000024
      SM_CYDOUBLECLK = 37, // 0x00000025
      SM_CXICONSPACING = 38, // 0x00000026
      SM_CYICONSPACING = 39, // 0x00000027
      SM_MENUDROPALIGNMENT = 40, // 0x00000028
      SM_PENWINDOWS = 41, // 0x00000029
      SM_DBCSENABLED = 42, // 0x0000002A
      SM_CMOUSEBUTTONS = 43, // 0x0000002B
      SM_SECURE = 44, // 0x0000002C
      SM_CXEDGE = 45, // 0x0000002D
      SM_CYEDGE = 46, // 0x0000002E
      SM_CXMINSPACING = 47, // 0x0000002F
      SM_CYMINSPACING = 48, // 0x00000030
      SM_CXSMICON = 49, // 0x00000031
      SM_CYSMICON = 50, // 0x00000032
      SM_CYSMCAPTION = 51, // 0x00000033
      SM_CXSMSIZE = 52, // 0x00000034
      SM_CYSMSIZE = 53, // 0x00000035
      SM_CXMENUSIZE = 54, // 0x00000036
      SM_CYMENUSIZE = 55, // 0x00000037
      SM_ARRANGE = 56, // 0x00000038
      SM_CXMINIMIZED = 57, // 0x00000039
      SM_CYMINIMIZED = 58, // 0x0000003A
      SM_CXMAXTRACK = 59, // 0x0000003B
      SM_CYMAXTRACK = 60, // 0x0000003C
      SM_CXMAXIMIZED = 61, // 0x0000003D
      SM_CYMAXIMIZED = 62, // 0x0000003E
      SM_NETWORK = 63, // 0x0000003F
      SM_CLEANBOOT = 67, // 0x00000043
      SM_CXDRAG = 68, // 0x00000044
      SM_CYDRAG = 69, // 0x00000045
      SM_SHOWSOUNDS = 70, // 0x00000046
      SM_CXMENUCHECK = 71, // 0x00000047
      SM_CYMENUCHECK = 72, // 0x00000048
      SM_SLOWMACHINE = 73, // 0x00000049
      SM_MIDEASTENABLED = 74, // 0x0000004A
      SM_MOUSEWHEELPRESENT = 75, // 0x0000004B
      SM_XVIRTUALSCREEN = 76, // 0x0000004C
      SM_YVIRTUALSCREEN = 77, // 0x0000004D
      SM_CXVIRTUALSCREEN = 78, // 0x0000004E
      SM_CYVIRTUALSCREEN = 79, // 0x0000004F
      SM_CMONITORS = 80, // 0x00000050
      SM_SAMEDISPLAYFORMAT = 81, // 0x00000051
      SM_IMMENABLED = 82, // 0x00000052
      SM_CXFOCUSBORDER = 83, // 0x00000053
      SM_CYFOCUSBORDER = 84, // 0x00000054
      SM_TABLETPC = 86, // 0x00000056
      SM_MEDIACENTER = 87, // 0x00000057
      SM_STARTER = 88, // 0x00000058
      SM_SERVERR2 = 89, // 0x00000059
      SM_MOUSEHORIZONTALWHEELPRESENT = 91, // 0x0000005B
      SM_CXPADDEDBORDER = 92, // 0x0000005C
      SM_DIGITIZER = 94, // 0x0000005E
      SM_MAXIMUMTOUCHES = 95, // 0x0000005F
      SM_REMOTESESSION = 4096, // 0x00001000
      SM_SHUTTINGDOWN = 8192, // 0x00002000
      SM_REMOTECONTROL = 8193, // 0x00002001
    }

    public enum HitTest
    {
      HTERROR = -2, // 0xFFFFFFFE
      HTTRANSPARENT = -1, // 0xFFFFFFFF
      HTNOWHERE = 0,
      HTCLIENT = 1,
      HTCAPTION = 2,
      HTSYSMENU = 3,
      HTGROWBOX = 4,
      HTSIZE = 4,
      HTMENU = 5,
      HTHSCROLL = 6,
      HTVSCROLL = 7,
      HTMINBUTTON = 8,
      HTREDUCE = 8,
      HTMAXBUTTON = 9,
      HTZOOM = 9,
      HTLEFT = 10, // 0x0000000A
      HTRIGHT = 11, // 0x0000000B
      HTTOP = 12, // 0x0000000C
      HTTOPLEFT = 13, // 0x0000000D
      HTTOPRIGHT = 14, // 0x0000000E
      HTBOTTOM = 15, // 0x0000000F
      HTBOTTOMLEFT = 16, // 0x00000010
      HTBOTTOMRIGHT = 17, // 0x00000011
      HTBORDER = 18, // 0x00000012
      HTCLOSE = 20, // 0x00000014
      HTHELP = 21, // 0x00000015
    }

    private static class OSVersion
    {
      private static string id;
      private static string caption;
      private static Version version;

      private static void init()
      {
        RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion");
        string str1 = (string) registryKey.GetValue("ProductName");
        string str2 = (string) registryKey.GetValue("CurrentVersion");
        string str3 = (string) registryKey.GetValue("CurrentBuild");
        string str4 = (string) registryKey.GetValue("ReleaseId");
        WinApi.OSVersion.caption = string.IsNullOrEmpty(str1) ? "Unknown" : str1;
        WinApi.OSVersion.id = string.IsNullOrEmpty(str4) ? string.Empty : str4;
        WinApi.OSVersion.version = new Version(string.IsNullOrEmpty(str2) ? "0.0" : str2 + "." + (string.IsNullOrEmpty(str3) ? "0" : str3) + ".0");
      }

      public static string Caption
      {
        get
        {
          if (WinApi.OSVersion.caption == null)
            WinApi.OSVersion.init();
          return WinApi.OSVersion.caption;
        }
      }

      public static Version Version
      {
        get
        {
          if (WinApi.OSVersion.version == (Version) null)
            WinApi.OSVersion.init();
          return WinApi.OSVersion.version;
        }
      }

      public static string ReleaseId
      {
        get
        {
          if (WinApi.OSVersion.id == null)
            WinApi.OSVersion.init();
          return WinApi.OSVersion.id;
        }
      }
    }
  }
}
