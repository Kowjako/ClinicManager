// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonItemGroupItemCollection
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections.Generic;

namespace System.Windows.Forms
{
  public class RibbonItemGroupItemCollection : RibbonItemCollection
  {
    internal RibbonItemGroupItemCollection(RibbonItemGroup ownerGroup) => this.OwnerGroup = ownerGroup;

    public RibbonItemGroup OwnerGroup { get; }

    public override void Add(RibbonItem item)
    {
      item.MaxSizeMode = RibbonElementSizeMode.Compact;
      item.SetOwnerItem((RibbonItem) this.OwnerGroup);
      base.Add(item);
    }

    public override void AddRange(IEnumerable<RibbonItem> items)
    {
      foreach (RibbonItem ribbonItem in items)
      {
        ribbonItem.MaxSizeMode = RibbonElementSizeMode.Compact;
        ribbonItem.SetOwnerItem((RibbonItem) this.OwnerGroup);
      }
      base.AddRange(items);
    }

    public override void Insert(int index, RibbonItem item)
    {
      item.MaxSizeMode = RibbonElementSizeMode.Compact;
      item.SetOwnerItem((RibbonItem) this.OwnerGroup);
      base.Insert(index, item);
    }
  }
}
