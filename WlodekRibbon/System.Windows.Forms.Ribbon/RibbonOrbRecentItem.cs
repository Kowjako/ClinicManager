// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonOrbRecentItem
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Drawing;

namespace System.Windows.Forms
{
  public class RibbonOrbRecentItem : RibbonButton
  {
    public RibbonOrbRecentItem()
    {
    }

    public RibbonOrbRecentItem(string text)
      : this()
    {
      this.Text = text;
    }

    internal override Rectangle OnGetImageBounds(
      RibbonElementSizeMode sMode,
      Rectangle bounds)
    {
      return Rectangle.Empty;
    }

    internal override Rectangle OnGetTextBounds(
      RibbonElementSizeMode sMode,
      Rectangle bounds)
    {
      Rectangle textBounds = base.OnGetTextBounds(sMode, bounds);
      textBounds.X = this.Bounds.Left + 3;
      return textBounds;
    }
  }
}
