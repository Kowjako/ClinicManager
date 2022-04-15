// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonTextEventArgs
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Drawing;

namespace System.Windows.Forms
{
  public class RibbonTextEventArgs : RibbonItemBoundsEventArgs
  {
    public RibbonTextEventArgs(
      Ribbon owner,
      Graphics g,
      Rectangle clip,
      RibbonItem item,
      Rectangle bounds,
      string text)
      : base(owner, g, clip, item, bounds)
    {
      this.Text = text;
      this.Style = FontStyle.Regular;
      this.Format = new StringFormat();
      this.Color = Color.Empty;
    }

    public RibbonTextEventArgs(
      Ribbon owner,
      Graphics g,
      Rectangle clip,
      RibbonItem item,
      Rectangle bounds,
      string text,
      FontStyle style)
      : base(owner, g, clip, item, bounds)
    {
      this.Text = text;
      this.Style = style;
      this.Format = new StringFormat();
      this.Color = Color.Empty;
    }

    public RibbonTextEventArgs(
      Ribbon owner,
      Graphics g,
      Rectangle clip,
      RibbonItem item,
      Rectangle bounds,
      string text,
      StringFormat format)
      : base(owner, g, clip, item, bounds)
    {
      this.Text = text;
      this.Style = FontStyle.Regular;
      this.Format = format;
      this.Color = Color.Empty;
    }

    public RibbonTextEventArgs(
      Ribbon owner,
      Graphics g,
      Rectangle clip,
      RibbonItem item,
      Rectangle bounds,
      string text,
      Color color,
      FontStyle style,
      StringFormat format)
      : base(owner, g, clip, item, bounds)
    {
      this.Text = text;
      this.Style = style;
      this.Format = format;
      this.Color = color;
    }

    public Color Color { get; set; }

    public string Text { get; set; }

    public StringFormat Format { get; set; }

    public FontStyle Style { get; set; }
  }
}
