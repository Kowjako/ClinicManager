// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonPanelPopup
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
  [ToolboxItem(false)]
  public class RibbonPanelPopup : RibbonPopup
  {
    private bool _ignoreNext;

    internal RibbonPanelPopup(RibbonPanel panel)
    {
      this.SetStyle(ControlStyles.Opaque, false);
      this.DoubleBuffered = true;
      this.Sensor = new RibbonMouseSensor((Control) this, panel.Owner, (IEnumerable<RibbonItem>) panel.Items)
      {
        PanelLimit = panel
      };
      this.Panel = panel;
      this.Panel.PopUp = (Control) this;
      panel.Owner.SuspendSensor();
      using (Graphics graphics = this.CreateGraphics())
      {
        panel.overflowBoundsBuffer = panel.Bounds;
        this.Size = panel.SwitchToSize((Control) this, graphics, this.GetSizeMode(panel));
      }
      foreach (RibbonItem ribbonItem in (List<RibbonItem>) panel.Items)
        ribbonItem.SetCanvas((Control) this);
    }

    public RibbonMouseSensor Sensor { get; }

    public RibbonPanel Panel { get; }

    public RibbonElementSizeMode GetSizeMode(RibbonPanel pnl) => pnl.FlowsTo == RibbonPanelFlowDirection.Right ? RibbonElementSizeMode.Medium : RibbonElementSizeMode.Large;

    public void IgnoreNextClickDeactivation() => this._ignoreNext = true;

    protected override void OnMouseDown(MouseEventArgs e) => base.OnMouseDown(e);

    protected override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);
      if (!this._ignoreNext)
        return;
      this._ignoreNext = false;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      this.Panel.Owner.Renderer.OnRenderPanelPopupBackground(new RibbonCanvasEventArgs(this.Panel.Owner, e.Graphics, new Rectangle(Point.Empty, this.ClientSize), (Control) this, (object) this.Panel));
      foreach (RibbonItem ribbonItem in (List<RibbonItem>) this.Panel.Items)
        ribbonItem.OnPaint((object) this, new RibbonElementPaintEventArgs(e.ClipRectangle, e.Graphics, RibbonElementSizeMode.Large));
      this.Panel.Owner.Renderer.OnRenderRibbonPanelBackground(new RibbonPanelRenderEventArgs(this.Panel.Owner, e.Graphics, e.ClipRectangle, this.Panel, (Control) this));
      this.Panel.Owner.Renderer.OnRenderRibbonPanelText(new RibbonPanelRenderEventArgs(this.Panel.Owner, e.Graphics, e.ClipRectangle, this.Panel, (Control) this));
    }

    protected override void OnClosed(EventArgs e)
    {
      foreach (RibbonItem ribbonItem in (List<RibbonItem>) this.Panel.Items)
        ribbonItem.SetCanvas((Control) null);
      this.Panel.SetPressed(false);
      this.Panel.SetSelected(false);
      this.Panel.Owner.UpdateRegions();
      this.Panel.Owner.Refresh();
      this.Panel.PopUp = (Control) null;
      this.Panel.Owner.ResumeSensor();
      this.Panel.PopupShowed = false;
      this.Panel.Owner.RedrawArea(this.Panel.Bounds);
      base.OnClosed(e);
    }
  }
}
