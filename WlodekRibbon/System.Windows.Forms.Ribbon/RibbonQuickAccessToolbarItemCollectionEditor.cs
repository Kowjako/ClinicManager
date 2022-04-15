// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonQuickAccessToolbarItemCollectionEditor
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.ComponentModel.Design;

namespace System.Windows.Forms
{
  public class RibbonQuickAccessToolbarItemCollectionEditor : CollectionEditor
  {
    public RibbonQuickAccessToolbarItemCollectionEditor()
      : base(typeof (RibbonQuickAccessToolbarItemCollection))
    {
    }

    protected override Type CreateCollectionItemType() => typeof (RibbonItem);

    protected override Type[] CreateNewItemTypes() => new Type[9]
    {
      typeof (RibbonButton),
      typeof (RibbonComboBox),
      typeof (RibbonSeparator),
      typeof (RibbonTextBox),
      typeof (RibbonColorChooser),
      typeof (RibbonCheckBox),
      typeof (RibbonUpDown),
      typeof (RibbonLabel),
      typeof (RibbonHost)
    };
  }
}
