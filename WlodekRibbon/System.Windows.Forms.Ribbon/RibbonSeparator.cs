// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonSeparator
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
  public sealed class RibbonSeparator : RibbonItem
  {
    public RibbonSeparator() => this.DropDownWidth = RibbonSeparatorDropDownWidth.Partial;

    public RibbonSeparator(string text)
      : this()
    {
      this.Text = text;
    }

    public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
    {
      if ((this.Owner == null || !this.DrawBackground) && !this.Owner.IsDesignMode())
        return;
      this.Owner.Renderer.OnRenderRibbonItem(new RibbonItemRenderEventArgs(this.Owner, e.Graphics, e.Clip, (RibbonItem) this));
      if (string.IsNullOrEmpty(this.Text))
        return;
      RibbonRenderer renderer = this.Owner.Renderer;
      Ribbon owner = this.Owner;
      Graphics graphics = e.Graphics;
      Rectangle clip = e.Clip;
      int left = this.Bounds.Left + this.Owner.ItemMargin.Left;
      int top1 = this.Bounds.Top;
      Padding itemMargin = this.Owner.ItemMargin;
      int top2 = itemMargin.Top;
      int top3 = top1 + top2;
      int right1 = this.Bounds.Right;
      itemMargin = this.Owner.ItemMargin;
      int right2 = itemMargin.Right;
      int right3 = right1 - right2;
      int bottom1 = this.Bounds.Bottom;
      itemMargin = this.Owner.ItemMargin;
      int bottom2 = itemMargin.Bottom;
      int bottom3 = bottom1 - bottom2;
      Rectangle bounds = Rectangle.FromLTRB(left, top3, right3, bottom3);
      string text = this.Text;
      RibbonTextEventArgs e1 = new RibbonTextEventArgs(owner, graphics, clip, (RibbonItem) this, bounds, text, FontStyle.Bold);
      renderer.OnRenderRibbonItemText(e1);
    }

    public override void SetBounds(Rectangle bounds) => base.SetBounds(bounds);

    public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
    {
      if (e.SizeMode == RibbonElementSizeMode.DropDown)
      {
        if (string.IsNullOrEmpty(this.Text))
        {
          this.SetLastMeasuredSize(new Size(1, 2));
        }
        else
        {
          Size size = e.Graphics.MeasureString(this.Text, new Font(this.Owner.Font, FontStyle.Bold)).ToSize();
          this.SetLastMeasuredSize(new Size(size.Width + this.Owner.ItemMargin.Horizontal + 1, size.Height + this.Owner.ItemMargin.Vertical));
        }
      }
      else if (this.OwnerPanel == null)
      {
        this.SetLastMeasuredSize(new Size(7, this.Owner.QuickAccessToolbar.ContentBounds.Height - this.Owner.QuickAccessToolbar.Padding.Vertical));
      }
      else
      {
        int height = this.OwnerPanel.ContentBounds.Height;
        Padding padding = this.Owner.ItemPadding;
        int vertical1 = padding.Vertical;
        int num = height - vertical1;
        padding = this.Owner.ItemMargin;
        int vertical2 = padding.Vertical;
        this.SetLastMeasuredSize(new Size(4, num - vertical2));
      }
      return this.LastMeasuredSize;
    }

    [DefaultValue(true)]
    [Category("Appearance")]
    [Description("Background drawing should be avoided when group contains only TextBoxes and ComboBoxes")]
    public bool DrawBackground { get; set; } = true;

    [DefaultValue(0)]
    [Category("Appearance")]
    [Description("The width of the Separator bar when displayed on a drop down")]
    public RibbonSeparatorDropDownWidth DropDownWidth { get; set; }
  }
}
