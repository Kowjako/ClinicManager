// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonOrbMenuItem
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
  [Designer(typeof (RibbonOrbMenuItemDesigner))]
  public class RibbonOrbMenuItem : RibbonButton
  {
    public RibbonOrbMenuItem()
    {
      this.DropDownArrowDirection = RibbonArrowDirection.Left;
      this.SetDropDownMargin(new Padding(10));
      this.DropDownShowing += new EventHandler(this.RibbonOrbMenuItem_DropDownShowing);
    }

    public RibbonOrbMenuItem(string text)
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

    private void RibbonOrbMenuItem_DropDownShowing(object sender, EventArgs e)
    {
      if (this.DropDown == null)
        return;
      this.DropDown.DrawIconsBar = false;
    }

    public override void OnMouseEnter(MouseEventArgs e)
    {
      base.OnMouseEnter(e);
      if (RibbonDesigner.Current != null)
        return;
      if (this.Owner.OrbDropDown.LastPoppedMenuItem != null)
        this.Owner.OrbDropDown.LastPoppedMenuItem.CloseDropDown();
      if (this.Style != RibbonButtonStyle.DropDown && this.Style != RibbonButtonStyle.SplitDropDown)
        return;
      this.ShowDropDown();
      this.Owner.OrbDropDown.LastPoppedMenuItem = this;
    }

    public override void OnMouseLeave(MouseEventArgs e) => base.OnMouseLeave(e);

    internal override Point OnGetDropDownMenuLocation() => this.Owner == null ? base.OnGetDropDownMenuLocation() : new Point(this.Owner.RectangleToScreen(this.Bounds).Right, this.Owner.OrbDropDown.RectangleToScreen(this.Owner.OrbDropDown.ContentRecentItemsBounds).Top);

    internal override Size OnGetDropDownMenuSize()
    {
      Rectangle recentItemsBounds = this.Owner.OrbDropDown.ContentRecentItemsBounds;
      recentItemsBounds.Inflate(-1, -1);
      return recentItemsBounds.Size;
    }

    public override void OnClick(EventArgs e) => base.OnClick(e);
  }
}
