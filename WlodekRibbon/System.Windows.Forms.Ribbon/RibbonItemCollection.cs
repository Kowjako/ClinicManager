// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonItemCollection
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms.Classes.Collections;

namespace System.Windows.Forms
{
  [Editor(typeof (RibbonItemCollectionEditor), typeof (UITypeEditor))]
  public class RibbonItemCollection : RibbonCollectionBase<RibbonItem>
  {
    internal RibbonItemCollection()
      : base((Ribbon) null)
    {
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RibbonPanel OwnerPanel { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RibbonTab OwnerTab { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RibbonItem OwnerItem { get; private set; }

    internal void SetOwnerTab(RibbonTab tab)
    {
      this.OwnerTab = tab;
      foreach (RibbonItem ribbonItem in (List<RibbonItem>) this)
        ribbonItem.SetOwnerTab(tab);
    }

    internal void SetOwnerPanel(RibbonPanel panel)
    {
      this.OwnerPanel = panel;
      foreach (RibbonItem ribbonItem in (List<RibbonItem>) this)
        ribbonItem.SetOwnerPanel(panel);
    }

    internal void SetOwnerItem(RibbonItem item)
    {
      this.OwnerItem = item;
      foreach (RibbonItem ribbonItem in (List<RibbonItem>) this)
        ribbonItem.SetOwnerItem(item);
    }

    internal override void SetOwner(Ribbon owner)
    {
      base.SetOwner(owner);
      foreach (RibbonItem ribbonItem in (List<RibbonItem>) this)
        ribbonItem.SetOwner(owner);
    }

    internal override void SetOwner(RibbonItem item)
    {
      item.SetOwner(this.Owner);
      item.SetOwnerPanel(this.OwnerPanel);
      item.SetOwnerTab(this.OwnerTab);
      item.SetOwnerItem(this.OwnerItem);
    }

    internal override void ClearOwner(RibbonItem item) => item.ClearOwner();

    internal override void UpdateRegions()
    {
      try
      {
        this.OwnerTab?.UpdatePanelsRegions();
        if (this.Owner == null || this.Owner.IsDisposed)
          return;
        this.Owner.UpdateRegions();
        this.Owner.Invalidate();
      }
      catch
      {
      }
    }

    internal int GetItemsLeft(IEnumerable<RibbonItem> items)
    {
      if (this.Count == 0)
        return 0;
      int num = int.MaxValue;
      foreach (RibbonItem ribbonItem in items)
      {
        Rectangle bounds = ribbonItem.Bounds;
        if (bounds.X < num)
        {
          bounds = ribbonItem.Bounds;
          num = bounds.X;
        }
      }
      return num;
    }

    internal int GetItemsRight(IEnumerable<RibbonItem> items)
    {
      if (this.Count == 0)
        return 0;
      int num = int.MinValue;
      foreach (RibbonItem ribbonItem in items)
      {
        Rectangle bounds = ribbonItem.Bounds;
        if (bounds.Right > num)
        {
          bounds = ribbonItem.Bounds;
          num = bounds.Right;
        }
      }
      return num;
    }

    internal int GetItemsTop(IEnumerable<RibbonItem> items)
    {
      if (this.Count == 0)
        return 0;
      int num = int.MaxValue;
      foreach (RibbonItem ribbonItem in items)
      {
        Rectangle bounds = ribbonItem.Bounds;
        if (bounds.Y < num)
        {
          bounds = ribbonItem.Bounds;
          num = bounds.Y;
        }
      }
      return num;
    }

    internal int GetItemsBottom(IEnumerable<RibbonItem> items)
    {
      if (this.Count == 0)
        return 0;
      int num = int.MinValue;
      foreach (RibbonItem ribbonItem in items)
      {
        Rectangle bounds = ribbonItem.Bounds;
        if (bounds.Bottom > num)
        {
          bounds = ribbonItem.Bounds;
          num = bounds.Bottom;
        }
      }
      return num;
    }

    internal int GetItemsWidth(IEnumerable<RibbonItem> items) => this.GetItemsRight(items) - this.GetItemsLeft(items);

    internal int GetItemsHeight(IEnumerable<RibbonItem> items) => this.GetItemsBottom(items) - this.GetItemsTop(items);

    internal Rectangle GetItemsBounds(IEnumerable<RibbonItem> items) => Rectangle.FromLTRB(this.GetItemsLeft(items), this.GetItemsTop(items), this.GetItemsRight(items), this.GetItemsBottom(items));

    internal int GetItemsLeft()
    {
      if (this.Count == 0)
        return 0;
      int num = int.MaxValue;
      foreach (RibbonItem ribbonItem in (List<RibbonItem>) this)
      {
        Rectangle bounds = ribbonItem.Bounds;
        if (bounds.X < num)
        {
          bounds = ribbonItem.Bounds;
          num = bounds.X;
        }
      }
      return num;
    }

    internal int GetItemsRight()
    {
      if (this.Count == 0)
        return 0;
      int num = int.MinValue;
      foreach (RibbonItem ribbonItem in (List<RibbonItem>) this)
      {
        if (ribbonItem.Visible && ribbonItem.Bounds.Right > num)
          num = ribbonItem.Bounds.Right;
      }
      if (num == int.MinValue)
        num = 0;
      return num;
    }

    internal int GetItemsTop()
    {
      if (this.Count == 0)
        return 0;
      int num = int.MaxValue;
      foreach (RibbonItem ribbonItem in (List<RibbonItem>) this)
      {
        Rectangle bounds = ribbonItem.Bounds;
        if (bounds.Y < num)
        {
          bounds = ribbonItem.Bounds;
          num = bounds.Y;
        }
      }
      return num;
    }

    internal int GetItemsBottom()
    {
      if (this.Count == 0)
        return 0;
      int num = int.MinValue;
      foreach (RibbonItem ribbonItem in (List<RibbonItem>) this)
      {
        if (ribbonItem.Visible && ribbonItem.Bounds.Bottom > num)
          num = ribbonItem.Bounds.Bottom;
      }
      if (num == int.MinValue)
        num = 0;
      return num;
    }

    internal int GetItemsWidth() => this.GetItemsRight() - this.GetItemsLeft();

    internal int GetItemsHeight() => this.GetItemsBottom() - this.GetItemsTop();

    internal Rectangle GetItemsBounds() => Rectangle.FromLTRB(this.GetItemsLeft(), this.GetItemsTop(), this.GetItemsRight(), this.GetItemsBottom());

    internal void MoveTo(Point p) => this.MoveTo((IEnumerable<RibbonItem>) this, p);

    internal void MoveTo(IEnumerable<RibbonItem> items, Point p)
    {
      Rectangle itemsBounds = this.GetItemsBounds(items);
      foreach (RibbonItem ribbonItem1 in items)
      {
        Rectangle bounds1 = ribbonItem1.Bounds;
        int num1 = bounds1.X - itemsBounds.Left;
        bounds1 = ribbonItem1.Bounds;
        int num2 = bounds1.Y - itemsBounds.Top;
        RibbonItem ribbonItem2 = ribbonItem1;
        Point location = new Point(p.X + num1, p.Y + num2);
        bounds1 = ribbonItem1.Bounds;
        Size size = bounds1.Size;
        Rectangle bounds2 = new Rectangle(location, size);
        ribbonItem2.SetBounds(bounds2);
      }
    }

    internal void CenterItemsInto(Rectangle rectangle) => this.CenterItemsInto((IEnumerable<RibbonItem>) this, rectangle);

    internal void CenterItemsVerticallyInto(Rectangle rectangle) => this.CenterItemsVerticallyInto((IEnumerable<RibbonItem>) this, rectangle);

    internal void CenterItemsHorizontallyInto(Rectangle rectangle) => this.CenterItemsHorizontallyInto((IEnumerable<RibbonItem>) this, rectangle);

    internal void CenterItemsInto(IEnumerable<RibbonItem> items, Rectangle rectangle)
    {
      int x = rectangle.Left + (rectangle.Width - this.GetItemsWidth()) / 2;
      int y = rectangle.Top + (rectangle.Height - this.GetItemsHeight()) / 2;
      this.MoveTo(items, new Point(x, y));
    }

    internal void CenterItemsVerticallyInto(IEnumerable<RibbonItem> items, Rectangle rectangle)
    {
      int itemsLeft = this.GetItemsLeft(items);
      int y = rectangle.Top + (rectangle.Height - this.GetItemsHeight(items)) / 2;
      this.MoveTo(items, new Point(itemsLeft, y));
    }

    internal void CenterItemsHorizontallyInto(IEnumerable<RibbonItem> items, Rectangle rectangle)
    {
      int x = rectangle.Left + (rectangle.Width - this.GetItemsWidth(items)) / 2;
      int itemsTop = this.GetItemsTop(items);
      this.MoveTo(items, new Point(x, itemsTop));
    }

    private void CheckRestrictions(RibbonItem item)
    {
      if (this.OwnerItem == null && item is RibbonDescriptionMenuItem)
        throw new ApplicationException("The RibbonDescriptionMenuItem item is not supported on a panel");
    }

    public override void Add(RibbonItem item)
    {
      this.CheckRestrictions(item);
      item.SetOwner(this.Owner);
      item.SetOwnerPanel(this.OwnerPanel);
      item.SetOwnerTab(this.OwnerTab);
      item.SetOwnerItem(this.OwnerItem);
      base.Add(item);
    }

    public override void AddRange(IEnumerable<RibbonItem> items)
    {
      foreach (RibbonItem ribbonItem in items)
      {
        this.CheckRestrictions(ribbonItem);
        ribbonItem.SetOwner(this.Owner);
        ribbonItem.SetOwnerPanel(this.OwnerPanel);
        ribbonItem.SetOwnerTab(this.OwnerTab);
        ribbonItem.SetOwnerItem(this.OwnerItem);
      }
      base.AddRange(items);
    }

    public override void Insert(int index, RibbonItem item)
    {
      this.CheckRestrictions(item);
      item.SetOwner(this.Owner);
      item.SetOwnerPanel(this.OwnerPanel);
      item.SetOwnerTab(this.OwnerTab);
      base.Insert(index, item);
    }
  }
}
