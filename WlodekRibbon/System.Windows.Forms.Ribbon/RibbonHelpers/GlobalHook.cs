// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonHelpers.GlobalHook
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace System.Windows.Forms.RibbonHelpers
{
  internal class GlobalHook : IDisposable
  {
    private GlobalHook.HookProcCallBack _HookProc;
    private IntPtr _handle;
    private GlobalHook.HookTypes _hookType;

    public event MouseEventHandler MouseClick;

    public event MouseEventHandler MouseDoubleClick;

    public event MouseEventHandler MouseWheel;

    public event MouseEventHandler MouseDown;

    public event MouseEventHandler MouseUp;

    public event MouseEventHandler MouseMove;

    public event KeyEventHandler KeyDown;

    public event KeyEventHandler KeyUp;

    public event KeyPressEventHandler KeyPress;

    public GlobalHook(GlobalHook.HookTypes hookType)
    {
      this._hookType = hookType;
      this.InstallHook();
    }

    ~GlobalHook() => this.Dispose(false);

    protected virtual void OnMouseClick(MouseEventArgs e)
    {
      if (this.MouseClick == null)
        return;
      this.MouseClick((object) this, e);
    }

    protected virtual void OnMouseDoubleClick(MouseEventArgs e)
    {
      if (this.MouseDoubleClick == null)
        return;
      this.MouseDoubleClick((object) this, e);
    }

    protected virtual void OnMouseWheel(MouseEventArgs e)
    {
      if (this.MouseWheel == null)
        return;
      this.MouseWheel((object) this, e);
    }

    protected virtual void OnMouseDown(MouseEventArgs e)
    {
      if (this.MouseDown == null)
        return;
      this.MouseDown((object) this, e);
    }

    protected virtual void OnMouseUp(MouseEventArgs e)
    {
      if (this.MouseUp == null)
        return;
      this.MouseUp((object) this, e);
    }

    protected virtual void OnMouseMove(MouseEventArgs e)
    {
      if (this.MouseMove == null)
        return;
      this.MouseMove((object) this, e);
    }

    protected virtual void OnKeyDown(KeyEventArgs e)
    {
      if (this.KeyDown == null)
        return;
      this.KeyDown((object) this, e);
    }

    protected virtual void OnKeyUp(KeyEventArgs e)
    {
      if (this.KeyUp == null)
        return;
      this.KeyUp((object) this, e);
    }

    protected virtual void OnKeyPress(KeyPressEventArgs e)
    {
      if (this.KeyPress == null)
        return;
      this.KeyPress((object) this, e);
    }

    private IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam)
    {
      if (code < 0)
        return WinApi.CallNextHookEx(this._handle, code, wParam, lParam);
      switch (this._hookType)
      {
        case GlobalHook.HookTypes.Mouse:
          return this.MouseProc(code, wParam, lParam);
        case GlobalHook.HookTypes.Keyboard:
          return this.KeyboardProc(code, wParam, lParam);
        default:
          throw new ArgumentException("HookType not supported");
      }
    }

    private IntPtr KeyboardProc(int code, IntPtr wParam, IntPtr lParam)
    {
      WinApi.KeyboardLLHookStruct structure = (WinApi.KeyboardLLHookStruct) Marshal.PtrToStructure(lParam, typeof (WinApi.KeyboardLLHookStruct));
      int int32 = wParam.ToInt32();
      bool flag1 = false;
      if (int32 == 256 || int32 == 260)
      {
        KeyEventArgs e = new KeyEventArgs((Keys) structure.vkCode);
        this.OnKeyDown(e);
        flag1 = e.Handled;
      }
      else if (int32 == 257 || int32 == 261)
      {
        KeyEventArgs e = new KeyEventArgs((Keys) structure.vkCode);
        this.OnKeyUp(e);
        flag1 = e.Handled;
      }
      if (int32 == 256 && this.KeyPress != null)
      {
        byte[] numArray = new byte[256];
        byte[] lpwTransKey = new byte[2];
        WinApi.GetKeyboardState(numArray);
        switch (WinApi.ToAscii(structure.vkCode, structure.scanCode, numArray, lpwTransKey, structure.flags))
        {
          case 1:
          case 2:
            int num1 = ((int) WinApi.GetKeyState(16) & 128) == 128 ? 1 : 0;
            bool flag2 = (uint) WinApi.GetKeyState(20) > 0U;
            char upper = (char) lpwTransKey[0];
            int num2 = flag2 ? 1 : 0;
            if ((num1 ^ num2) != 0 && char.IsLetter(upper))
              upper = char.ToUpper(upper);
            KeyPressEventArgs e = new KeyPressEventArgs(upper);
            this.OnKeyPress(e);
            flag1 |= e.Handled;
            break;
        }
      }
      return !flag1 ? WinApi.CallNextHookEx(this._handle, code, wParam, lParam) : (IntPtr) 1;
    }

    private IntPtr MouseProc(int code, IntPtr wParam, IntPtr lParam)
    {
      WinApi.MouseLLHookStruct structure = (WinApi.MouseLLHookStruct) Marshal.PtrToStructure(lParam, typeof (WinApi.MouseLLHookStruct));
      int int32 = wParam.ToInt32();
      int x = structure.pt.x;
      int y = structure.pt.y;
      int delta = (int) (short) (structure.mouseData >> 16 & (int) ushort.MaxValue);
      switch (int32)
      {
        case 512:
          this.OnMouseMove(new MouseEventArgs(MouseButtons.None, 0, x, y, delta));
          break;
        case 513:
          this.OnMouseDown(new MouseEventArgs(MouseButtons.Left, 0, x, y, delta));
          break;
        case 514:
          this.OnMouseUp(new MouseEventArgs(MouseButtons.Left, 0, x, y, delta));
          this.OnMouseClick(new MouseEventArgs(MouseButtons.Left, 0, x, y, delta));
          break;
        case 515:
          this.OnMouseDoubleClick(new MouseEventArgs(MouseButtons.Left, 0, x, y, delta));
          break;
        case 516:
          this.OnMouseDown(new MouseEventArgs(MouseButtons.Right, 0, x, y, delta));
          break;
        case 517:
          this.OnMouseUp(new MouseEventArgs(MouseButtons.Right, 0, x, y, delta));
          break;
        case 518:
          this.OnMouseDoubleClick(new MouseEventArgs(MouseButtons.Right, 0, x, y, delta));
          break;
        case 519:
          this.OnMouseDown(new MouseEventArgs(MouseButtons.Middle, 0, x, y, delta));
          break;
        case 520:
          this.OnMouseUp(new MouseEventArgs(MouseButtons.Middle, 0, x, y, delta));
          break;
        case 521:
          this.OnMouseDoubleClick(new MouseEventArgs(MouseButtons.Middle, 0, x, y, delta));
          break;
        case 522:
          this.OnMouseWheel(new MouseEventArgs(MouseButtons.None, 0, x, y, delta));
          break;
        case 523:
          this.OnMouseDown(new MouseEventArgs(MouseButtons.XButton1, 0, x, y, delta));
          break;
        case 524:
          this.OnMouseUp(new MouseEventArgs(MouseButtons.XButton1, 0, x, y, delta));
          break;
        case 525:
          this.OnMouseDoubleClick(new MouseEventArgs(MouseButtons.XButton1, 0, x, y, delta));
          break;
      }
      return WinApi.CallNextHookEx(this._handle, code, wParam, lParam);
    }

    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    private void InstallHook()
    {
      if (this._handle != IntPtr.Zero)
        throw new InvalidOperationException("Hook is already installed");
      int idHook;
      switch (this._hookType)
      {
        case GlobalHook.HookTypes.Mouse:
          idHook = 14;
          break;
        case GlobalHook.HookTypes.Keyboard:
          idHook = 13;
          break;
        default:
          throw new ArgumentException("HookType is not supported");
      }
      this._HookProc = new GlobalHook.HookProcCallBack(this.HookProc);
      this._handle = WinApi.SetWindowsHookEx(idHook, this._HookProc, Process.GetCurrentProcess().MainModule.BaseAddress, 0);
      int lastWin32Error = Marshal.GetLastWin32Error();
      if (this._handle == IntPtr.Zero)
        throw new Win32Exception(lastWin32Error);
    }

    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    private void Unhook()
    {
      if (!(this._handle != IntPtr.Zero))
        return;
      try
      {
        if (!WinApi.UnhookWindowsHookEx(this._handle))
        {
          Win32Exception win32Exception = new Win32Exception(Marshal.GetLastWin32Error());
          if (win32Exception.NativeErrorCode != 0)
            throw win32Exception;
        }
        this._handle = IntPtr.Zero;
      }
      catch (Exception ex)
      {
      }
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!(this._handle != IntPtr.Zero))
        return;
      this.Unhook();
    }

    public enum HookTypes
    {
      Mouse,
      Keyboard,
    }

    internal delegate IntPtr HookProcCallBack(int nCode, IntPtr wParam, IntPtr lParam);
  }
}
