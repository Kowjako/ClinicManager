// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonOrbMenuItemDesigner
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.ComponentModel.Design;

namespace System.Windows.Forms
{
  internal class RibbonOrbMenuItemDesigner : RibbonElementWithItemCollectionDesigner
    {
    public override Ribbon Ribbon => this.Component is RibbonButton component ? component.Owner : (Ribbon) null;

    public override RibbonItemCollection Collection => this.Component is RibbonButton component ? component.DropDownItems : (RibbonItemCollection) null;

    protected override DesignerVerbCollection OnGetVerbs() => new DesignerVerbCollection(new DesignerVerb[2]
    {
      new DesignerVerb("Add DescriptionMenuItem", AddDescriptionMenuItem),
      new DesignerVerb("Add Separator", AddSeparator)
    });
  }
}
