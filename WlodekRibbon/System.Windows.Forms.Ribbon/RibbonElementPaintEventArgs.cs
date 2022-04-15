// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonElementPaintEventArgs
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Drawing;

namespace System.Windows.Forms
{
  public class RibbonElementPaintEventArgs : EventArgs
  {
    internal RibbonElementPaintEventArgs(
      Rectangle clip,
      Graphics graphics,
      RibbonElementSizeMode mode)
    {
      this.Clip = clip;
      this.Graphics = graphics;
      this.Mode = mode;
    }

    internal RibbonElementPaintEventArgs(
      Rectangle clip,
      Graphics graphics,
      RibbonElementSizeMode mode,
      Control control)
      : this(clip, graphics, mode)
    {
      this.Control = control;
    }

    public Rectangle Clip { get; }

    public Graphics Graphics { get; }

    public RibbonElementSizeMode Mode { get; }

    public Control Control { get; }
  }
}
