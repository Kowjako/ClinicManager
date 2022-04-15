// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonCanvasEventArgs
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Drawing;

namespace System.Windows.Forms
{
  public class RibbonCanvasEventArgs : EventArgs
  {
    public RibbonCanvasEventArgs(
      Ribbon owner,
      Graphics g,
      Rectangle bounds,
      Control canvas,
      object relatedObject)
    {
      this.Owner = owner;
      this.Graphics = g;
      this.Bounds = bounds;
      this.Canvas = canvas;
      this.RelatedObject = relatedObject;
    }

    public object RelatedObject { get; set; }

    public Ribbon Owner { get; set; }

    public Graphics Graphics { get; set; }

    public Rectangle Bounds { get; set; }

    public Control Canvas { get; set; }
  }
}
