// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonForm
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.ComponentModel;
using System.Diagnostics;
using System.Security.Permissions;
using System.Windows.Forms.RibbonHelpers;

namespace System.Windows.Forms
{
  public class RibbonForm : Form, IRibbonForm
  {
    private bool? _isopeninvisualstudiodesigner;

    public RibbonForm()
    {
      if (this.IsOpenInVisualStudioDesigner())
        return;
      if (WinApi.IsWindows && !WinApi.IsGlassEnabled)
      {
        this.FormBorderStyle = FormBorderStyle.None;
        this.SetStyle(ControlStyles.ResizeRedraw, true);
        this.SetStyle(ControlStyles.Opaque, WinApi.IsGlassEnabled);
        this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        this.DoubleBuffered = true;
      }
      this.Helper = new RibbonFormHelper((Form) this);
    }

    protected bool IsOpenInVisualStudioDesigner()
    {
      if (!this._isopeninvisualstudiodesigner.HasValue)
      {
        this._isopeninvisualstudiodesigner = new bool?(LicenseManager.UsageMode == LicenseUsageMode.Designtime || this.DesignMode);
        if (!this._isopeninvisualstudiodesigner.Value)
        {
          try
          {
            using (Process currentProcess = Process.GetCurrentProcess())
              this._isopeninvisualstudiodesigner = new bool?(currentProcess.ProcessName.ToLowerInvariant().Contains("devenv"));
          }
          catch
          {
          }
        }
      }
      return this._isopeninvisualstudiodesigner.Value;
    }

    protected override void OnNotifyMessage(Message m) => base.OnNotifyMessage(m);

    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    protected override void WndProc(ref Message m)
    {
      if (this.IsOpenInVisualStudioDesigner())
      {
        base.WndProc(ref m);
      }
      else
      {
        if (this.Helper.WndProc(ref m))
          return;
        base.WndProc(ref m);
      }
    }

    protected override CreateParams CreateParams
    {
      [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)] get
      {
        CreateParams createParams = base.CreateParams;
        if (!this.IsOpenInVisualStudioDesigner() && WinApi.IsWindows && !WinApi.IsGlassEnabled)
          createParams.Style |= 917504;
        return createParams;
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (this.IsOpenInVisualStudioDesigner())
        base.OnPaint(e);
      else
        this.Helper.Form_Paint((object) this, e);
    }

    public RibbonFormHelper Helper { get; }
  }
}
