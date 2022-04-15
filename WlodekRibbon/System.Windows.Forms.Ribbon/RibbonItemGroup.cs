// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonItemGroup
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
  [Designer(typeof (RibbonItemGroupDesigner))]
  public class RibbonItemGroup : 
    RibbonItem,
    IContainsSelectableRibbonItems,
    IContainsRibbonComponents
  {
    public RibbonItemGroup()
    {
      this.Items = new RibbonItemGroupItemCollection(this);
      this.Items.SetOwnerItem((RibbonItem) this);
      this.DrawBackground = true;
    }

    public RibbonItemGroup(IEnumerable<RibbonItem> items)
      : this()
    {
      this.Items.AddRange(items);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (RibbonDesigner.Current == null)
        {
          try
          {
            foreach (Component component in (List<RibbonItem>) this.Items)
              component.Dispose();
          }
          catch (InvalidOperationException ex)
          {
            if (!this.IsOpenInVisualStudioDesigner())
              throw;
          }
        }
      }
      base.Dispose(disposing);
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override bool Checked
    {
      get => base.Checked;
      set => base.Checked = value;
    }

    [DefaultValue(true)]
    [Category("Appearance")]
    [Description("Background drawing should be avoided when group contains only TextBoxes and ComboBoxes")]
    public bool DrawBackground { get; set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RibbonItem FirstItem => this.Items.Count > 0 ? this.Items[0] : (RibbonItem) null;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RibbonItem LastItem => this.Items.Count > 0 ? this.Items[this.Items.Count - 1] : (RibbonItem) null;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public RibbonItemGroupItemCollection Items { get; }

    protected override bool ClosesDropDownAt(Point p) => false;

    public override void SetBounds(Rectangle bounds)
    {
      base.SetBounds(bounds);
      int x = bounds.Left;
      foreach (RibbonItem ribbonItem in (List<RibbonItem>) this.Items)
      {
        ribbonItem.SetBounds(new Rectangle(new Point(x, bounds.Top), ribbonItem.LastMeasuredSize));
        x = ribbonItem.Bounds.Right + 1;
      }
    }

    public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
    {
      if (this.DrawBackground)
        this.Owner.Renderer.OnRenderRibbonItem(new RibbonItemRenderEventArgs(this.Owner, e.Graphics, e.Clip, (RibbonItem) this));
      foreach (RibbonItem ribbonItem in (List<RibbonItem>) this.Items)
      {
        if (ribbonItem.Visible || this.Owner.IsDesignMode())
          ribbonItem.OnPaint((object) this, new RibbonElementPaintEventArgs(ribbonItem.Bounds, e.Graphics, RibbonElementSizeMode.Compact));
      }
      if (!this.DrawBackground)
        return;
      this.Owner.Renderer.OnRenderRibbonItemBorder(new RibbonItemRenderEventArgs(this.Owner, e.Graphics, e.Clip, (RibbonItem) this));
    }

    public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
    {
      if (!this.Visible && !this.Owner.IsDesignMode())
      {
        this.SetLastMeasuredSize(new Size(0, 0));
        return this.LastMeasuredSize;
      }
      int val2 = 16;
      int num1 = 0;
      int num2 = 16;
      foreach (RibbonItem ribbonItem in (List<RibbonItem>) this.Items)
      {
        Size size = ribbonItem.MeasureSize((object) this, new RibbonElementMeasureSizeEventArgs(e.Graphics, RibbonElementSizeMode.Compact));
        num1 += size.Width + 1;
        num2 = Math.Max(num2, size.Height);
      }
      int width = Math.Max(num1 - 1, val2);
      if (this.Site != null && this.Site.DesignMode)
        width += 10;
      Size size1 = new Size(width, num2);
      this.SetLastMeasuredSize(size1);
      return size1;
    }

    internal override void SetOwnerPanel(RibbonPanel ownerPanel)
    {
      base.SetOwnerPanel(ownerPanel);
      this.Items.SetOwnerPanel(ownerPanel);
    }

    internal override void SetOwner(Ribbon owner)
    {
      base.SetOwner(owner);
      this.Items.SetOwner(owner);
    }

    internal override void SetOwnerTab(RibbonTab ownerTab)
    {
      base.SetOwnerTab(ownerTab);
      this.Items.SetOwnerTab(ownerTab);
    }

    internal override void SetOwnerItem(RibbonItem ownerItem) => base.SetOwnerItem(ownerItem);

    internal override void ClearOwner()
    {
      List<RibbonItem> ribbonItemList = new List<RibbonItem>((IEnumerable<RibbonItem>) this.Items);
      base.ClearOwner();
      foreach (RibbonItem ribbonItem in ribbonItemList)
        ribbonItem.ClearOwner();
    }

    internal override void SetSizeMode(RibbonElementSizeMode sizeMode)
    {
      base.SetSizeMode(sizeMode);
      foreach (RibbonItem ribbonItem in (List<RibbonItem>) this.Items)
        ribbonItem.SetSizeMode(RibbonElementSizeMode.Compact);
    }

    public override string ToString() => "Group: " + (object) this.Items.Count + " item(s)";

    public IEnumerable<RibbonItem> GetItems() => (IEnumerable<RibbonItem>) this.Items;

    public Rectangle GetContentBounds()
    {
      Rectangle bounds = this.Bounds;
      int left = bounds.Left + 1;
      bounds = this.Bounds;
      int top = bounds.Top + 1;
      bounds = this.Bounds;
      int right = bounds.Right - 1;
      bounds = this.Bounds;
      int bottom = bounds.Bottom;
      return Rectangle.FromLTRB(left, top, right, bottom);
    }

    public IEnumerable<Component> GetAllChildComponents() => (IEnumerable<Component>) this.Items.ToArray();
  }
}
