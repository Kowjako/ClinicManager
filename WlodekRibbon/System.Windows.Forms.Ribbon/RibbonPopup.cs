// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonPopup
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Permissions;
using System.Windows.Forms.RibbonHelpers;

namespace System.Windows.Forms
{
  [ToolboxItem(false)]
  public class RibbonPopup : Control
  {
    public event EventHandler Showed;

    public event EventHandler Closed;

    public event ToolStripDropDownClosingEventHandler Closing;

    public event CancelEventHandler Opening;

    public RibbonPopup()
    {
      this.SetStyle(ControlStyles.Opaque, true);
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.SetStyle(ControlStyles.Selectable, false);
      this.BorderRoundness = 3;
    }

    [Browsable(false)]
    public int BorderRoundness { get; set; }

    internal RibbonWrappedDropDown WrappedDropDown { get; set; }

    public void Show(Point screenLocation)
    {
      if (this.WrappedDropDown == null)
      {
        ToolStripControlHost stripControlHost = new ToolStripControlHost((Control) this);
        RibbonWrappedDropDown ribbonWrappedDropDown = new RibbonWrappedDropDown();
        ribbonWrappedDropDown.AutoClose = RibbonDesigner.Current != null;
        this.WrappedDropDown = ribbonWrappedDropDown;
        this.WrappedDropDown.Items.Add((ToolStripItem) stripControlHost);
        this.WrappedDropDown.Padding = Padding.Empty;
        this.WrappedDropDown.Margin = Padding.Empty;
        stripControlHost.Padding = Padding.Empty;
        stripControlHost.Margin = Padding.Empty;
        this.WrappedDropDown.Opening += new CancelEventHandler(this.ToolStripDropDown_Opening);
        this.WrappedDropDown.Closing += new ToolStripDropDownClosingEventHandler(this.ToolStripDropDown_Closing);
        this.WrappedDropDown.Closed += new ToolStripDropDownClosedEventHandler(this.ToolStripDropDown_Closed);
        this.WrappedDropDown.Size = this.Size;
      }
      this.WrappedDropDown.Show(screenLocation);
      RibbonPopupManager.Register(this);
      this.OnShowed(EventArgs.Empty);
    }

    private void ToolStripDropDown_Opening(object sender, CancelEventArgs e) => this.OnOpening(e);

    protected virtual void OnOpening(CancelEventArgs e)
    {
      if (this.Opening == null)
        return;
      this.Opening((object) this, e);
    }

    private void ToolStripDropDown_Closing(object sender, ToolStripDropDownClosingEventArgs e) => this.OnClosing(e);

    private void ToolStripDropDown_Closed(object sender, ToolStripDropDownClosedEventArgs e) => this.OnClosed(EventArgs.Empty);

    public void Close()
    {
      if (this.WrappedDropDown == null)
        return;
      this.WrappedDropDown.Close();
    }

    protected virtual void OnClosing(ToolStripDropDownClosingEventArgs e)
    {
      if (this.Closing == null)
        return;
      this.Closing((object) this, e);
    }

    protected virtual void OnClosed(EventArgs e)
    {
      RibbonPopupManager.Unregister(this);
      if (this.Closed == null)
        return;
      this.Closed((object) this, e);
    }

    protected virtual void OnShowed(EventArgs e)
    {
      if (this.Showed == null)
        return;
      this.Showed((object) this, e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      using (GraphicsPath path = RibbonProfessionalRenderer.RoundRectangle(new Rectangle(Point.Empty, this.Size), this.BorderRoundness))
      {
        using (Region region = new Region(path))
          this.WrappedDropDown.Region = region;
      }
    }

    protected override CreateParams CreateParams
    {
      [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)] get
      {
        CreateParams createParams = base.CreateParams;
        if (WinApi.IsXP)
          createParams.ClassStyle |= 131072;
        return createParams;
      }
    }
  }
}
