// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonButtonDesigner
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

namespace System.Windows.Forms
{
  internal class RibbonButtonDesigner : RibbonElementWithItemCollectionDesigner
  {
    public override Ribbon Ribbon => this.Component is RibbonButton component ? component.Owner : (Ribbon) null;

    public override RibbonItemCollection Collection => this.Component is RibbonButton component ? component.DropDownItems : (RibbonItemCollection) null;

    protected override void AddButton(object sender, EventArgs e) => base.AddButton(sender, e);
  }
}
