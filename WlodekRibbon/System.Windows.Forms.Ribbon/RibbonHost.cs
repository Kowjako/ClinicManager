// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonHost
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
  public class RibbonHost : RibbonItem
  {
    private Control ctl;
    private Font ctlFont;
    private Size ctlSize;
    private RibbonElementSizeMode _lastSizeMode;

    public event MouseEventHandler ClientMouseMove;

    [Description("Occurs when the SizeMode of the Controls container is changing. if you manually set the size of the control you need to set the Handled flag to true.")]
    public event RibbonHost.RibbonHostSizeModeHandledEventHandler SizeModeChanging;

    public Control HostedControl
    {
      get => this.ctl;
      set
      {
        this.ctl = value;
        this.NotifyOwnerRegionsChanged();
        if (this.ctl == null || this.Site != null)
          return;
        this.ctlFont = this.ctl.Font;
        this.ctlSize = this.ctl.Size;
        this.ctl.MouseMove += new MouseEventHandler(this.ctl_MouseMove);
        this.CanvasChanged += new EventHandler(this.RibbonHost_CanvasChanged);
        if (this.OwnerTab != null)
          this.Owner.ActiveTabChanged += new EventHandler(this.Owner_ActiveTabChanged);
        if (this.Owner != null)
          this.Owner.Controls.Add(this.ctl);
        this.ctl.Font = this.ctlFont;
        this.ctl.Visible = false;
      }
    }

    public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
    {
      if (this.Owner == null)
        return;
      StringFormat format = StringFormatFactory.CenterNoWrap(StringTrimming.None);
      if (this.Site != null && this.Site.DesignMode)
      {
        this.Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(this.Owner, e.Graphics, this.Bounds, (RibbonItem) this, this.Bounds, this.Site.Name, format));
      }
      else
      {
        this.Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(this.Owner, e.Graphics, this.Bounds, (RibbonItem) this, this.Bounds, this.Text, format));
        if (this.ctl == null)
          return;
        if (this.ctl.Parent != this.Canvas)
          this.Canvas.Controls.Add(this.ctl);
        Control ctl = this.ctl;
        Rectangle bounds = this.Bounds;
        int left = bounds.Left;
        int top;
        if (this.SizeMode != RibbonElementSizeMode.DropDown)
        {
          bounds = this.Bounds;
          top = bounds.Top;
        }
        else
        {
          bounds = this.Bounds;
          top = bounds.Top;
        }
        Point point = new Point(left, top);
        ctl.Location = point;
        this.ctl.Visible = true;
        this.ctl.BringToFront();
      }
    }

    public override void SetBounds(Rectangle bounds) => base.SetBounds(bounds);

    public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
    {
      if (this.Site != null && this.Site.DesignMode && this.Owner != null)
        this.SetLastMeasuredSize(new Size(Convert.ToInt32(e.Graphics.MeasureString(this.Site.Name, this.Owner.Font).Width), 20));
      else if (this.ctl == null || !this.Visible)
      {
        this.SetLastMeasuredSize(new Size(0, 0));
      }
      else
      {
        this.ctl.Visible = false;
        if (this._lastSizeMode != e.SizeMode)
        {
          this._lastSizeMode = e.SizeMode;
          RibbonHostSizeModeHandledEventArgs e1 = new RibbonHostSizeModeHandledEventArgs(e.Graphics, e.SizeMode);
          this.OnSizeModeChanging(ref e1);
        }
        this.SetLastMeasuredSize(new Size(this.ctl.Size.Width, this.ctl.Size.Height));
      }
      return this.LastMeasuredSize;
    }

    public void HostCompleted()
    {
      Point position = Cursor.Position;
      int x = position.X;
      position = Cursor.Position;
      int y = position.Y;
      this.OnClick((EventArgs) new MouseEventArgs(MouseButtons.Left, 1, x, y, 0));
    }

    public virtual void OnSizeModeChanging(ref RibbonHostSizeModeHandledEventArgs e)
    {
      if (this.SizeModeChanging == null)
        return;
      this.SizeModeChanging((object) this, e);
    }

    private void PlaceControls()
    {
      if (this.ctl == null || this.Site != null)
        return;
      Control ctl = this.ctl;
      Rectangle bounds = this.Bounds;
      int x = bounds.Left + 1;
      bounds = this.Bounds;
      int y = bounds.Top + 1;
      Point point = new Point(x, y);
      ctl.Location = point;
      if (!(this.Canvas is Ribbon) || this.OwnerPanel == null || this.OwnerPanel.SizeMode != RibbonElementSizeMode.Overflow)
        return;
      this.ctl.Visible = false;
    }

    private void ctl_MouseMove(object sender, MouseEventArgs e)
    {
      if (this.OwnerItem == null)
      {
        this.Owner.OnRibbonHostMouseMove(new MouseEventArgs(e.Button, e.Clicks, this.Owner.PointToClient(this.ctl.PointToScreen(e.Location)).X, this.Owner.PointToClient(this.ctl.PointToScreen(e.Location)).Y, e.Delta));
      }
      else
      {
        int button = (int) e.Button;
        int clicks = e.Clicks;
        Rectangle bounds = this.Bounds;
        int x = bounds.Left + e.X;
        bounds = this.Bounds;
        int y = bounds.Top + e.Y;
        int delta = e.Delta;
        MouseEventArgs e1 = new MouseEventArgs((MouseButtons) button, clicks, x, y, delta);
        if (this.ClientMouseMove != null)
          this.ClientMouseMove((object) this, e1);
      }
      this.OnMouseMove(e);
    }

    private void Owner_ActiveTabChanged(object sender, EventArgs e)
    {
      if (this.ctl == null || this.OwnerTab == null || this.Owner.ActiveTab == this.OwnerTab)
        return;
      this.ctl.Visible = false;
    }

    private void RibbonHost_CanvasChanged(object sender, EventArgs e)
    {
      if (this.ctl == null)
        return;
      this.Canvas.Controls.Add(this.ctl);
      this.ctl.Font = this.ctlFont;
    }

    internal override void SetSizeMode(RibbonElementSizeMode sizeMode)
    {
      base.SetSizeMode(sizeMode);
      if (this.ctl == null || this.OwnerPanel == null || this.OwnerPanel.SizeMode != RibbonElementSizeMode.Overflow)
        return;
      this.ctl.Visible = false;
    }

    public delegate void RibbonHostSizeModeHandledEventHandler(
      object sender,
      RibbonHostSizeModeHandledEventArgs e);
  }
}
