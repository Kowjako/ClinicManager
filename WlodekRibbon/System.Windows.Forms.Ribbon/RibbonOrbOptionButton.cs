// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonOrbOptionButton
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
  public class RibbonOrbOptionButton : RibbonButton
  {
    public RibbonOrbOptionButton()
    {
    }

    public RibbonOrbOptionButton(string text)
      : this()
    {
      this.Text = text;
    }

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
  }
}
