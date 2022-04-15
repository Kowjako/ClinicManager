// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonButtonCollection
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections.Generic;
using System.ComponentModel;

namespace System.Windows.Forms
{
  public class RibbonButtonCollection : RibbonItemCollection
  {
    internal RibbonButtonCollection(RibbonButtonList list) => this.OwnerList = list;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RibbonButtonList OwnerList { get; }

    private void CheckRestrictions(RibbonButton button)
    {
      if (button == null)
        throw new ArgumentNullException(nameof (button), "The RibbonButtonList only accepts button in the Buttons collection");
      if (button.Style != RibbonButtonStyle.Normal)
        throw new ArgumentException("The only style supported by the RibbonButtonList is Normal");
    }

    public override void Add(RibbonItem item)
    {
      this.CheckRestrictions(item as RibbonButton);
      item.SetOwner(this.Owner);
      item.SetOwnerPanel(this.OwnerPanel);
      item.SetOwnerTab(this.OwnerTab);
      item.SetOwnerItem(this.OwnerItem);
      item.Click += new EventHandler(this.OwnerList.item_Click);
      base.Add(item);
    }

    public override void AddRange(IEnumerable<RibbonItem> items)
    {
      foreach (RibbonItem ribbonItem in items)
      {
        this.CheckRestrictions(ribbonItem as RibbonButton);
        ribbonItem.SetOwner(this.Owner);
        ribbonItem.SetOwnerPanel(this.OwnerPanel);
        ribbonItem.SetOwnerTab(this.OwnerTab);
        ribbonItem.SetOwnerItem(this.OwnerItem);
      }
      base.AddRange(items);
    }

    public override void Insert(int index, RibbonItem item)
    {
      this.CheckRestrictions(item as RibbonButton);
      item.SetOwner(this.Owner);
      item.SetOwnerPanel(this.OwnerPanel);
      item.SetOwnerTab(this.OwnerTab);
      item.SetOwnerItem((RibbonItem) this.OwnerList);
      base.Insert(index, item);
    }
  }
}
