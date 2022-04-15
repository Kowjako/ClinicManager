// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonDescriptionMenuItem
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
  public class RibbonDescriptionMenuItem : RibbonButton
  {
    public RibbonDescriptionMenuItem()
    {
      this.DropDownArrowDirection = RibbonArrowDirection.Left;
      this.SetDropDownMargin(new Padding(10));
    }

    public RibbonDescriptionMenuItem(string text)
      : this((Image) null, text, (string) null)
    {
    }

    public RibbonDescriptionMenuItem(string text, string description)
      : this((Image) null, text, description)
    {
    }

    public RibbonDescriptionMenuItem(Image image, string text, string description)
    {
      this.Image = image;
      this.Text = text;
      this.Description = description;
    }

    public Rectangle DescriptionBounds { get; set; }

    [Browsable(false)]
    public override Image LargeImage
    {
      get => base.Image;
      set => base.Image = value;
    }

    [DefaultValue(null)]
    [Browsable(true)]
    [Category("Appearance")]
    public override Image Image
    {
      get => base.Image;
      set
      {
        base.Image = value;
        this.SmallImage = value;
      }
    }

    [Browsable(false)]
    public override Image SmallImage
    {
      get => base.SmallImage;
      set => base.SmallImage = value;
    }

    [DefaultValue(null)]
    public string Description { get; set; }

    protected override void OnPaintText(RibbonElementPaintEventArgs e)
    {
      if (e.Mode == RibbonElementSizeMode.DropDown)
      {
        StringFormat format = StringFormatFactory.NearCenter();
        this.Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(this.Owner, e.Graphics, e.Clip, (RibbonItem) this, this.TextBounds, this.Text, Color.Empty, FontStyle.Bold, format));
        format.Alignment = StringAlignment.Near;
        this.Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(this.Owner, e.Graphics, e.Clip, (RibbonItem) this, this.DescriptionBounds, this.Description, format));
      }
      else
        base.OnPaintText(e);
    }

    public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
    {
      if (!this.Visible && !this.Owner.IsDesignMode())
      {
        this.SetLastMeasuredSize(new Size(0, 0));
        return this.LastMeasuredSize;
      }
      Size size = base.MeasureSize(sender, e);
      size.Height = 52;
      this.SetLastMeasuredSize(size);
      return size;
    }

    internal override Rectangle OnGetTextBounds(
      RibbonElementSizeMode sMode,
      Rectangle bounds)
    {
      Rectangle textBounds = base.OnGetTextBounds(sMode, bounds);
      this.DescriptionBounds = textBounds;
      textBounds.Height = 20;
      Rectangle descriptionBounds = this.DescriptionBounds;
      int left = descriptionBounds.Left;
      int bottom1 = textBounds.Bottom;
      descriptionBounds = this.DescriptionBounds;
      int right = descriptionBounds.Right;
      descriptionBounds = this.DescriptionBounds;
      int bottom2 = descriptionBounds.Bottom;
      this.DescriptionBounds = Rectangle.FromLTRB(left, bottom1, right, bottom2);
      return textBounds;
    }
  }
}
