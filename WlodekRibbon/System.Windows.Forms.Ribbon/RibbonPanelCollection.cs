// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonPanelCollection
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms.Classes.Collections;

namespace System.Windows.Forms
{
  public sealed class RibbonPanelCollection : RibbonCollectionBase<RibbonPanel>
  {
    public RibbonPanelCollection(RibbonTab ownerTab)
      : base((Ribbon) null)
    {
      this.OwnerTab = ownerTab ?? throw new ArgumentNullException(nameof (ownerTab));
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Ribbon Owner => base.Owner ?? this.OwnerTab.Owner;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RibbonTab OwnerTab { get; private set; }

    internal override void SetOwner(RibbonPanel item)
    {
      item.SetOwner(this.Owner);
      item.SetOwnerTab(this.OwnerTab);
    }

    internal override void ClearOwner(RibbonPanel item) => item.ClearOwner();

    internal override void UpdateRegions()
    {
      try
      {
        this.OwnerTab.UpdatePanelsRegions();
        if (this.Owner == null || this.Owner.IsDisposed)
          return;
        this.Owner.UpdateRegions();
        this.Owner.Invalidate();
      }
      catch
      {
      }
    }

    internal override void SetOwner(Ribbon owner)
    {
      base.SetOwner(owner);
      foreach (RibbonPanel ribbonPanel in (List<RibbonPanel>) this)
        ribbonPanel.SetOwner(owner);
    }

    internal void SetOwnerTab(RibbonTab ownerTab)
    {
      this.OwnerTab = ownerTab;
      foreach (RibbonPanel ribbonPanel in (List<RibbonPanel>) this)
        ribbonPanel.SetOwnerTab(this.OwnerTab);
    }
  }
}
