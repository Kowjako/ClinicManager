// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonToolTipRenderEventArgs
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Drawing;

namespace System.Windows.Forms
{
  public class RibbonToolTipRenderEventArgs : RibbonRenderEventArgs
  {
    private Font font = new Font("Arial", 8f);

    public RibbonToolTipRenderEventArgs(Ribbon owner, Graphics g, Rectangle clip, string text)
      : base(owner, g, clip)
    {
      this.Text = text;
    }

    public RibbonToolTipRenderEventArgs(
      Ribbon owner,
      Graphics g,
      Rectangle clip,
      string Text,
      Image tipImage)
      : base(owner, g, clip)
    {
      this.Text = Text;
      this.TipImage = tipImage;
    }

    public RibbonToolTipRenderEventArgs(
      Ribbon owner,
      Graphics g,
      Rectangle clip,
      string Text,
      Image tipImage,
      Color color,
      FontStyle style,
      StringFormat format,
      Font font)
      : base(owner, g, clip)
    {
      this.Text = Text;
      this.Color = this.Color;
      this.Style = style;
      this.Format = format;
      this.TipImage = tipImage;
      this.Font = font;
    }

    public string Text { get; set; }

    public Color Color { get; set; }

    public StringFormat Format { get; set; }

    public FontStyle Style { get; set; }

    public Font Font
    {
      get => this.font;
      set => this.font = value;
    }

    public Image TipImage { get; set; }
  }
}
