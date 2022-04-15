// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.LayoutHelper
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Drawing;

namespace System.Windows.Forms
{
  public class LayoutHelper
  {
    private readonly Ribbon _ribbon;

    public LayoutHelper(Ribbon ribbon) => this._ribbon = ribbon;

    public Rectangle CalcNewPosition(
      Rectangle reference,
      Rectangle rect,
      LayoutHelper.RTLLayoutPosition type,
      int distance)
    {
      return this._ribbon.RightToLeft == RightToLeft.No && type == LayoutHelper.RTLLayoutPosition.Near || this._ribbon.RightToLeft == RightToLeft.Yes && type == LayoutHelper.RTLLayoutPosition.Far ? new Rectangle(reference.Left - distance - rect.Width, rect.Y, rect.Width, rect.Height) : new Rectangle(reference.Right + distance, rect.Y, rect.Width, rect.Height);
    }

    public Point CalcNewPosition(
      Rectangle reference,
      Point point,
      LayoutHelper.RTLLayoutPosition type,
      int distance)
    {
      return this._ribbon.RightToLeft == RightToLeft.No && type == LayoutHelper.RTLLayoutPosition.Near || this._ribbon.RightToLeft == RightToLeft.Yes && type == LayoutHelper.RTLLayoutPosition.Far ? new Point(reference.Left - distance, point.Y) : new Point(reference.Right + distance, point.Y);
    }

    public Rectangle CalcNewPosition(
      Point reference,
      Rectangle rect,
      LayoutHelper.RTLLayoutPosition type,
      int distance)
    {
      return this._ribbon.RightToLeft == RightToLeft.No && type == LayoutHelper.RTLLayoutPosition.Near || this._ribbon.RightToLeft == RightToLeft.Yes && type == LayoutHelper.RTLLayoutPosition.Far ? new Rectangle(reference.X - distance - rect.Width, rect.Y, rect.Width, rect.Height) : new Rectangle(reference.X + distance, rect.Y, rect.Width, rect.Height);
    }

    public enum RTLLayoutPosition
    {
      Near,
      Far,
    }
  }
}
