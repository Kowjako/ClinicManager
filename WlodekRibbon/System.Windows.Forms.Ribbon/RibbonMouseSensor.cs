// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonMouseSensor
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections.Generic;
using System.Drawing;

namespace System.Windows.Forms
{
  public class RibbonMouseSensor : IDisposable
  {
    private RibbonItem _lastMouseDown;

    private RibbonMouseSensor()
    {
      this.Tabs = new List<RibbonTab>();
      this.Panels = new List<RibbonPanel>();
      this.Items = new List<RibbonItem>();
    }

    public RibbonMouseSensor(Control control, Ribbon ribbon)
      : this()
    {
      this.Control = control ?? throw new ArgumentNullException(nameof (control));
      this.Ribbon = ribbon ?? throw new ArgumentNullException(nameof (ribbon));
      this.AddHandlers();
    }

    public RibbonMouseSensor(
      Control control,
      Ribbon ribbon,
      IEnumerable<RibbonTab> tabs,
      IEnumerable<RibbonPanel> panels,
      IEnumerable<RibbonItem> items)
      : this(control, ribbon)
    {
      if (tabs != null)
        this.Tabs.AddRange(tabs);
      if (panels != null)
        this.Panels.AddRange(panels);
      if (items == null)
        return;
      this.Items.AddRange(items);
    }

    public RibbonMouseSensor(Control control, Ribbon ribbon, RibbonTab tab)
      : this(control, ribbon)
    {
      this.Tabs.Add(tab);
      this.Panels.AddRange((IEnumerable<RibbonPanel>) tab.Panels);
      foreach (RibbonPanel panel in (List<RibbonPanel>) tab.Panels)
        this.Items.AddRange((IEnumerable<RibbonItem>) panel.Items);
    }

    public RibbonMouseSensor(Control control, Ribbon ribbon, IEnumerable<RibbonItem> itemsSource)
      : this(control, ribbon)
    {
      this.ItemsSource = itemsSource;
      foreach (RibbonItem ribbonItem in itemsSource)
      {
        if (ribbonItem.Selected)
          this.HittedItem = ribbonItem;
      }
    }

    public Control Control { get; }

    public bool Disposed { get; private set; }

    internal RibbonTab HittedTab { get; set; }

    internal bool HittedTabScroll => this.HittedTabScrollLeft || this.HittedTabScrollRight;

    internal bool HittedTabScrollLeft { get; set; }

    internal bool HittedTabScrollRight { get; set; }

    internal RibbonPanel HittedPanel { get; set; }

    internal RibbonItem HittedItem { get; set; }

    internal RibbonItem HittedSubItem { get; set; }

    [Obsolete("use IsSuspended")]
    public bool IsSupsended => this.IsSuspended;

    public bool IsSuspended { get; private set; }

    public IEnumerable<RibbonItem> ItemsSource { get; set; }

    public List<RibbonItem> Items { get; }

    public RibbonPanel PanelLimit { get; set; }

    public List<RibbonPanel> Panels { get; }

    public Ribbon Ribbon { get; }

    internal RibbonTab SelectedTab { get; set; }

    internal RibbonPanel SelectedPanel { get; set; }

    internal RibbonItem SelectedItem { get; set; }

    internal RibbonItem SelectedSubItem { get; set; }

    public RibbonTab TabLimit { get; set; }

    public List<RibbonTab> Tabs { get; }

    private void AddHandlers()
    {
      if (this.Control == null)
        throw new ArgumentNullException("Control", "Control is Null, cant Add RibbonMouseSensor Handles");
      this.Control.MouseMove += new MouseEventHandler(this.Control_MouseMove);
      this.Control.MouseLeave += new EventHandler(this.Control_MouseLeave);
      this.Control.MouseDown += new MouseEventHandler(this.Control_MouseDown);
      this.Control.MouseUp += new MouseEventHandler(this.Control_MouseUp);
      this.Control.MouseClick += new MouseEventHandler(this.Control_MouseClick);
      this.Control.MouseDoubleClick += new MouseEventHandler(this.Control_MouseDoubleClick);
    }

    private void Control_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (this.IsSuspended || this.Disposed)
        return;
      if (this.HittedPanel != null)
        this.HittedPanel.OnDoubleClick((EventArgs) e);
      if (this.HittedItem != null)
        this.HittedItem.OnDoubleClick((EventArgs) e);
      if (this.HittedSubItem == null)
        return;
      this.HittedSubItem.OnDoubleClick((EventArgs) e);
    }

    private void Control_MouseClick(object sender, MouseEventArgs e)
    {
      if (this.IsSuspended || this.Disposed)
        return;
      if (this.HittedPanel != null)
        this.HittedPanel.OnClick((EventArgs) e);
      if (this.HittedItem != null && this.HittedItem == this._lastMouseDown)
        this.HittedItem.OnClick((EventArgs) e);
      if (this.HittedSubItem == null)
        return;
      this.HittedSubItem.OnClick((EventArgs) e);
    }

    private void Control_MouseUp(object sender, MouseEventArgs e)
    {
      if (this.IsSuspended || this.Disposed)
        return;
      if (this.HittedTab != null)
      {
        if (this.HittedTab.ScrollLeftVisible)
        {
          this.HittedTab.SetScrollLeftPressed(false);
          this.Control.Invalidate(this.HittedTab.ScrollLeftBounds);
        }
        if (this.HittedTab.ScrollRightVisible)
        {
          this.HittedTab.SetScrollRightPressed(false);
          this.Control.Invalidate(this.HittedTab.ScrollRightBounds);
        }
      }
      if (this.HittedPanel != null)
      {
        this.HittedPanel.SetPressed(false);
        this.HittedPanel.OnMouseUp(e);
        this.Control.Invalidate(this.HittedPanel.Bounds);
      }
      if (this.HittedItem != null)
      {
        this.HittedItem.SetPressed(false);
        this.HittedItem.OnMouseUp(e);
        this.Control.Invalidate(this.HittedItem.Bounds);
      }
      if (this.HittedSubItem == null)
        return;
      this.HittedSubItem.SetPressed(false);
      this.HittedSubItem.OnMouseUp(e);
      this.Control.Invalidate(Rectangle.Intersect(this.HittedItem.Bounds, this.HittedSubItem.Bounds));
    }

    private void Control_MouseDown(object sender, MouseEventArgs e)
    {
      if (this.IsSuspended || this.Disposed)
        return;
      this.HitTest(e.Location);
      this._lastMouseDown = this.HittedItem;
      if (this.HittedTab != null)
      {
        if (this.HittedTabScrollLeft)
        {
          this.HittedTab.SetScrollLeftPressed(true);
          this.Control.Invalidate(this.HittedTab.ScrollLeftBounds);
        }
        if (this.HittedTabScrollRight)
        {
          this.HittedTab.SetScrollRightPressed(true);
          this.Control.Invalidate(this.HittedTab.ScrollRightBounds);
        }
      }
      if (this.HittedPanel != null)
      {
        this.HittedPanel.SetPressed(true);
        this.HittedPanel.OnMouseDown(e);
        this.Control.Invalidate(this.HittedPanel.Bounds);
      }
      if (this.HittedItem != null)
      {
        this.HittedItem.SetPressed(true);
        this.HittedItem.OnMouseDown(e);
        this.Control.Invalidate(this.HittedItem.Bounds);
      }
      if (this.HittedSubItem == null)
        return;
      this.HittedSubItem.SetPressed(true);
      this.HittedSubItem.OnMouseDown(e);
      this.Control.Invalidate(Rectangle.Intersect(this.HittedItem.Bounds, this.HittedSubItem.Bounds));
    }

    private void Control_MouseLeave(object sender, EventArgs e)
    {
      if (this.IsSuspended)
        return;
      int num = this.Disposed ? 1 : 0;
    }

    private void Control_MouseMove(object sender, MouseEventArgs e)
    {
      if (this.IsSuspended || this.Disposed)
        return;
      this.HitTest(e.Location);
      if (this.SelectedPanel != null && this.SelectedPanel != this.HittedPanel)
      {
        this.SelectedPanel.SetSelected(false);
        this.SelectedPanel.OnMouseLeave(e);
        this.Control.Invalidate(this.SelectedPanel.Bounds);
      }
      if (this.SelectedItem != null && this.SelectedItem != this.HittedItem)
      {
        this.SelectedItem.SetSelected(false);
        this.SelectedItem.OnMouseLeave(e);
        this.Control.Invalidate(this.SelectedItem.Bounds);
      }
      if (this.SelectedSubItem != null && this.SelectedSubItem != this.HittedSubItem)
      {
        this.SelectedSubItem.SetSelected(false);
        this.SelectedSubItem.OnMouseLeave(e);
        this.Control.Invalidate(Rectangle.Intersect(this.SelectedItem.Bounds, this.SelectedSubItem.Bounds));
      }
      if (this.HittedTab != null)
      {
        if (this.HittedTab.ScrollLeftVisible)
        {
          this.HittedTab.SetScrollLeftSelected(this.HittedTabScrollLeft);
          this.Control.Invalidate(this.HittedTab.ScrollLeftBounds);
        }
        if (this.HittedTab.ScrollRightVisible)
        {
          this.HittedTab.SetScrollRightSelected(this.HittedTabScrollRight);
          this.Control.Invalidate(this.HittedTab.ScrollRightBounds);
        }
      }
      if (this.HittedPanel != null)
      {
        if (this.HittedPanel == this.SelectedPanel)
        {
          this.HittedPanel.OnMouseMove(e);
        }
        else
        {
          this.HittedPanel.SetSelected(true);
          this.HittedPanel.OnMouseEnter(e);
          this.Control.Invalidate(this.HittedPanel.Bounds);
        }
      }
      if (this.HittedItem != null)
      {
        if (this.HittedItem == this.SelectedItem)
        {
          this.HittedItem.OnMouseMove(e);
        }
        else
        {
          this.HittedItem.SetSelected(true);
          this.HittedItem.OnMouseEnter(e);
          this.Control.Invalidate(this.HittedItem.Bounds);
        }
      }
      if (this.HittedSubItem == null)
        return;
      if (this.HittedSubItem == this.SelectedSubItem)
      {
        this.HittedSubItem.OnMouseMove(e);
      }
      else
      {
        this.HittedSubItem.SetSelected(true);
        this.HittedSubItem.OnMouseEnter(e);
        this.Control.Invalidate(Rectangle.Intersect(this.HittedItem.Bounds, this.HittedSubItem.Bounds));
      }
    }

    internal void HitTest(Point p)
    {
      this.SelectedTab = this.HittedTab;
      this.SelectedPanel = this.HittedPanel;
      this.SelectedItem = this.HittedItem;
      this.SelectedSubItem = this.HittedSubItem;
      this.HittedTab = (RibbonTab) null;
      this.HittedTabScrollLeft = false;
      this.HittedTabScrollRight = false;
      this.HittedPanel = (RibbonPanel) null;
      this.HittedItem = (RibbonItem) null;
      this.HittedSubItem = (RibbonItem) null;
      if (this.TabLimit != null && this.TabLimit.Visible)
      {
        if (this.TabLimit.TabContentBounds.Contains(p))
          this.HittedTab = this.TabLimit;
      }
      else
      {
        foreach (RibbonTab tab in this.Tabs)
        {
          if (tab.Visible && tab.TabContentBounds.Contains(p))
          {
            this.HittedTab = tab;
            break;
          }
        }
      }
      if (this.HittedTab != null)
      {
        this.HittedTabScrollLeft = this.HittedTab.ScrollLeftVisible && this.HittedTab.ScrollLeftBounds.Contains(p);
        this.HittedTabScrollRight = this.HittedTab.ScrollRightVisible && this.HittedTab.ScrollRightBounds.Contains(p);
      }
      if (this.HittedTabScroll)
        return;
      if (this.PanelLimit != null && this.PanelLimit.Visible)
      {
        if (this.PanelLimit.Bounds.Contains(p))
          this.HittedPanel = this.PanelLimit;
      }
      else
      {
        foreach (RibbonPanel panel in this.Panels)
        {
          if (panel.Visible && panel.Bounds.Contains(p))
          {
            this.HittedPanel = panel;
            break;
          }
        }
      }
      IEnumerable<RibbonItem> ribbonItems = (IEnumerable<RibbonItem>) this.Items;
      if (this.ItemsSource != null)
        ribbonItems = this.ItemsSource;
      foreach (RibbonItem ribbonItem in ribbonItems)
      {
        if ((ribbonItem.OwnerPanel == null || !ribbonItem.OwnerPanel.OverflowMode || this.Control is RibbonPanelPopup) && ribbonItem.Visible && ribbonItem.Bounds.Contains(p))
        {
          this.HittedItem = ribbonItem;
          break;
        }
      }
      IContainsSelectableRibbonItems hittedItem1 = this.HittedItem as IContainsSelectableRibbonItems;
      IScrollableRibbonItem hittedItem2 = this.HittedItem as IScrollableRibbonItem;
      if (hittedItem1 == null)
        return;
      Rectangle rect = hittedItem2 != null ? hittedItem2.ContentBounds : this.HittedItem.Bounds;
      foreach (RibbonItem ribbonItem in hittedItem1.GetItems())
      {
        if (ribbonItem.Visible)
        {
          Rectangle bounds = ribbonItem.Bounds;
          bounds.Intersect(rect);
          if (bounds.Contains(p))
            this.HittedSubItem = ribbonItem;
        }
      }
    }

    private void RemoveHandlers()
    {
      this.Control.MouseMove -= new MouseEventHandler(this.Control_MouseMove);
      this.Control.MouseLeave -= new EventHandler(this.Control_MouseLeave);
      this.Control.MouseDown -= new MouseEventHandler(this.Control_MouseDown);
      this.Control.MouseUp -= new MouseEventHandler(this.Control_MouseUp);
      this.Control.MouseClick -= new MouseEventHandler(this.Control_MouseClick);
      this.Control.MouseDoubleClick -= new MouseEventHandler(this.Control_MouseDoubleClick);
    }

    public void Resume() => this.IsSuspended = false;

    public void Suspend() => this.IsSuspended = true;

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposing)
        return;
      this.Disposed = true;
      this.RemoveHandlers();
    }
  }
}
