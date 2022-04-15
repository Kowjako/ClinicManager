// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonQuickAccessToolbarItemCollection
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace System.Windows.Forms
{
  [Editor(typeof (RibbonQuickAccessToolbarItemCollectionEditor), typeof (UITypeEditor))]
  public class RibbonQuickAccessToolbarItemCollection : RibbonItemCollection
  {
    internal RibbonQuickAccessToolbarItemCollection(RibbonQuickAccessToolbar toolbar)
    {
      this.OwnerToolbar = toolbar;
      this.SetOwner(toolbar.Owner);
    }

    internal override sealed void SetOwner(Ribbon owner) => base.SetOwner(owner);

    public RibbonQuickAccessToolbar OwnerToolbar { get; }

    public override void Add(RibbonItem item)
    {
      item.MaxSizeMode = RibbonElementSizeMode.Compact;
      base.Add(item);
    }

    public override void AddRange(IEnumerable<RibbonItem> items)
    {
      foreach (RibbonItem ribbonItem in items)
        ribbonItem.MaxSizeMode = RibbonElementSizeMode.Compact;
      base.AddRange(items);
    }

    public override void Insert(int index, RibbonItem item)
    {
      item.MaxSizeMode = RibbonElementSizeMode.Compact;
      base.Insert(index, item);
    }
  }
}
