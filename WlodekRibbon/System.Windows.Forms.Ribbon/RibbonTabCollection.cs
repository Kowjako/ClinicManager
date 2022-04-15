// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonTabCollection
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Windows.Forms.Classes.Collections;

namespace System.Windows.Forms
{
  public sealed class RibbonTabCollection : RibbonCollectionBase<RibbonTab>
  {
    internal RibbonTabCollection(Ribbon owner)
      : base(owner)
    {
      if (owner == null)
        throw new ArgumentNullException(nameof (owner));
    }

    internal override void SetOwner(RibbonTab item) => item.SetOwner(this.Owner);

    internal override void ClearOwner(RibbonTab item) => item.ClearOwner();

    internal override void UpdateRegions()
    {
      try
      {
        this.Owner.OnRegionsChanged();
      }
      catch
      {
      }
    }

    public new bool Remove(RibbonTab tab)
    {
      if (tab == this.Owner.ActiveTab)
      {
        if (this.Owner.Tabs.IndexOf(tab) > 0)
        {
          this.Owner.ActiveTab = this.Owner.Tabs[this.Owner.Tabs.IndexOf(tab) - 1];
          this.Owner.Tabs.Remove(tab);
        }
        else if (this.Owner.Tabs.IndexOf(tab) < this.Owner.Tabs.Count - 1)
        {
          this.Owner.ActiveTab = this.Owner.Tabs[this.Owner.Tabs.IndexOf(tab) + 1];
          this.Owner.Tabs.Remove(tab);
        }
      }
      return base.Remove(tab);
    }
  }
}
