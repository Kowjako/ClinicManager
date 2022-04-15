// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonLabel
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
  public class RibbonLabel : RibbonItem
  {
    private int _labelWidth;
    private const int spacing = 3;

    protected virtual int MeasureHeight() => this.Owner != null ? 16 + this.Owner.ItemMargin.Vertical : 20;

    public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
    {
      if (!this.Visible && (this.Site == null || !this.Site.DesignMode))
        return new Size(0, 0);
      Font font = new Font("Microsoft Sans Serif", 8f);
      if (this.Owner != null)
        font = this.Owner.Font;
      this.SetLastMeasuredSize(new Size(string.IsNullOrEmpty(this.Text) ? 0 : (this._labelWidth > 0 ? this._labelWidth : e.Graphics.MeasureString(this.Text, font).ToSize().Width + 6), this.MeasureHeight()));
      return this.LastMeasuredSize;
    }

    public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
    {
      if (this.Owner == null)
        return;
      this.Owner.Renderer.OnRenderRibbonItem(new RibbonItemRenderEventArgs(this.Owner, e.Graphics, this.Bounds, (RibbonItem) this));
      StringFormat format = StringFormatFactory.CenterNoWrap(StringTrimming.None);
      format.Alignment = (StringAlignment) this.TextAlignment;
      Rectangle bounds = Rectangle.FromLTRB(this.Bounds.Left + 3, this.Bounds.Top + this.Owner.ItemMargin.Top, this.Bounds.Right - 3, this.Bounds.Bottom - this.Owner.ItemMargin.Bottom);
      this.Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(this.Owner, e.Graphics, this.Bounds, (RibbonItem) this, bounds, this.Text, format));
    }

    public override void SetBounds(Rectangle bounds) => base.SetBounds(bounds);

    [Description("Sets the width of the label portion of the control")]
    [Category("Appearance")]
    [DefaultValue(0)]
    public int LabelWidth
    {
      get => this._labelWidth;
      set
      {
        if (this._labelWidth == value)
          return;
        this._labelWidth = value;
        this.NotifyOwnerRegionsChanged();
      }
    }
  }
}
