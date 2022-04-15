// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonContextCollection
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Windows.Forms.Classes.Collections;

namespace System.Windows.Forms
{
  public sealed class RibbonContextCollection : RibbonCollectionBase<RibbonContext>
  {
    internal RibbonContextCollection(Ribbon owner)
      : base(owner)
    {
      if (owner == null)
        throw new ArgumentNullException(nameof (owner));
    }

    public void Remove(RibbonContext context)
    {
      foreach (RibbonTab contextualTab in context.ContextualTabs)
        contextualTab.Context = (RibbonContext) null;
      base.Remove(context);
    }

    public new int RemoveAll(Predicate<RibbonContext> predicate) => throw new NotSupportedException("RibbonContextCollectin.RemoveAll function is not supported");

    public new void RemoveAt(int index)
    {
      foreach (RibbonTab contextualTab in this[index].ContextualTabs)
        contextualTab.Context = (RibbonContext) null;
      base.RemoveAt(index);
    }

    public new void RemoveRange(int index, int count) => throw new NotSupportedException("RibbonContextCollection.RemoveRange function is not supported");

    internal override void SetOwner(RibbonContext item) => item.SetOwner(this.Owner);

    internal override void ClearOwner(RibbonContext item) => item.ClearOwner();

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
  }
}
