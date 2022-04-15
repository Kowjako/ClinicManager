// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonColorChooser
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace System.Windows.Forms
{
  public class RibbonColorChooser : RibbonButton
  {
    private Color _color;

    public event EventHandler ColorChanged;

    public RibbonColorChooser()
    {
      this._color = Color.Transparent;
      this.ImageColorHeight = 8;
      this.SmallImageColorHeight = 4;
    }

    [Description("Height of the color preview on the large image")]
    [Category("Appearance")]
    [DefaultValue(8)]
    public int ImageColorHeight { get; set; }

    [Description("Height of the color preview on the small image")]
    [Category("Appearance")]
    [DefaultValue(4)]
    public int SmallImageColorHeight { get; set; }

    [Category("Appearance")]
    public Color Color
    {
      get => this._color;
      set
      {
        this._color = value;
        this.RedrawItem();
        this.OnColorChanged(EventArgs.Empty);
      }
    }

    private Image CreateColorBmp(Color c)
    {
      Bitmap bitmap = new Bitmap(16, 16);
      using (Graphics graphics = Graphics.FromImage((Image) bitmap))
      {
        using (SolidBrush solidBrush = new SolidBrush(c))
          graphics.FillRectangle((Brush) solidBrush, new Rectangle(0, 0, 15, 15));
        graphics.DrawRectangle(Pens.DimGray, new Rectangle(0, 0, 15, 15));
      }
      return (Image) bitmap;
    }

    protected void OnColorChanged(EventArgs e)
    {
      if (this.ColorChanged == null)
        return;
      this.ColorChanged((object) this, e);
    }

    public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
    {
      base.OnPaint(sender, e);
      Color color = this.Color.Equals((object) Color.Transparent) ? Color.White : this.Color;
      int num = e.Mode == RibbonElementSizeMode.Large ? this.ImageColorHeight : this.SmallImageColorHeight;
      int left = this.ImageBounds.Left;
      int top = this.ImageBounds.Bottom - num;
      Rectangle imageBounds = this.ImageBounds;
      int right = imageBounds.Right;
      imageBounds = this.ImageBounds;
      int bottom = imageBounds.Bottom;
      Rectangle rect = Rectangle.FromLTRB(left, top, right, bottom);
      SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
      e.Graphics.SmoothingMode = SmoothingMode.None;
      using (SolidBrush solidBrush = new SolidBrush(color))
        e.Graphics.FillRectangle((Brush) solidBrush, rect);
      if (this.Color.Equals((object) Color.Transparent))
        e.Graphics.DrawRectangle(Pens.DimGray, rect);
      e.Graphics.SmoothingMode = smoothingMode;
    }
  }
}
