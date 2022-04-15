// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonDesigner
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Permissions;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;
using System.Windows.Forms.RibbonHelpers;

namespace System.Windows.Forms
{
  [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
  public class RibbonDesigner : ControlDesigner
  {
    internal static RibbonDesigner Current;
    private IRibbonElement _selectedElement;
    private Adorner _quickAccessAdorner;
    private Adorner _orbAdorner;
    private Adorner _tabAdorner;

    public RibbonDesigner() => RibbonDesigner.Current = this;

    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
      if (RibbonDesigner.Current != this)
        return;
      RibbonDesigner.Current = (RibbonDesigner) null;
    }

    public IRibbonElement SelectedElement
    {
      get => this._selectedElement;
      set
      {
        if (this.Ribbon == null)
          return;
        this._selectedElement = value;
        if (this.GetService(typeof (ISelectionService)) is ISelectionService service && value != null)
        {
          Component[] componentArray = new Component[1]
          {
            value as Component
          };
          service.SetSelectedComponents((ICollection) componentArray, SelectionTypes.Click);
        }
        if (value is RibbonButton ribbonButton)
          ribbonButton.ShowDropDown();
        this.Ribbon.Refresh();
      }
    }

    public Ribbon Ribbon => this.Control as Ribbon;

    public virtual void CreateItem(Ribbon ribbon, RibbonItemCollection collection, Type t)
    {
      if (!(this.GetService(typeof (IDesignerHost)) is IDesignerHost service) || collection == null || ribbon == null)
        return;
      DesignerTransaction transaction = service.CreateTransaction("AddRibbonItem_" + this.Component.Site.Name);
      MemberDescriptor property = (MemberDescriptor) TypeDescriptor.GetProperties((object) this.Component)["Items"];
      this.RaiseComponentChanging(property);
      RibbonItem component = service.CreateComponent(t) as RibbonItem;
      if (!(component is RibbonSeparator))
        component.Text = component.Site.Name;
      collection.Add(component);
      ribbon.OnRegionsChanged();
      this.RaiseComponentChanged(property, (object) null, (object) null);
      transaction.Commit();
    }

    private void CreateOrbItem(string collectionName, RibbonItemCollection collection, Type t)
    {
      if (this.Ribbon == null)
        return;
      IDesignerHost service = this.GetService(typeof (IDesignerHost)) as IDesignerHost;
      DesignerTransaction transaction = service.CreateTransaction("AddRibbonOrbItem_" + this.Component.Site.Name);
      MemberDescriptor property = (MemberDescriptor) TypeDescriptor.GetProperties((object) this.Ribbon.OrbDropDown)[collectionName];
      this.RaiseComponentChanging(property);
      RibbonItem component = service.CreateComponent(t) as RibbonItem;
      if (!(component is RibbonSeparator))
        component.Text = component.Site.Name;
      collection.Add(component);
      this.Ribbon.OrbDropDown.OnRegionsChanged();
      this.RaiseComponentChanged(property, (object) null, (object) null);
      transaction.Commit();
      this.Ribbon.OrbDropDown.SelectOnDesigner(component);
      this.Ribbon.OrbDropDown.WrappedDropDown.Size = this.Ribbon.OrbDropDown.Size;
    }

    public void CreateOrbMenuItem(Type t) => this.CreateOrbItem("MenuItems", (RibbonItemCollection) this.Ribbon.OrbDropDown.MenuItems, t);

    public void CreateOrbRecentItem(Type t) => this.CreateOrbItem("RecentItems", (RibbonItemCollection) this.Ribbon.OrbDropDown.RecentItems, t);

    public void CreateOrbOptionItem(Type t) => this.CreateOrbItem("OptionItems", (RibbonItemCollection) this.Ribbon.OrbDropDown.OptionItems, t);

    private void AssignEventHandler()
    {
    }

    private void SelectRibbon()
    {
      if (!(this.GetService(typeof (ISelectionService)) is ISelectionService service))
        return;
      Component[] componentArray = new Component[1]
      {
        (Component) this.Ribbon
      };
      service.SetSelectedComponents((ICollection) componentArray, SelectionTypes.Click);
    }

    public override DesignerVerbCollection Verbs => new DesignerVerbCollection()
    {
      new DesignerVerb("Add Tab", new EventHandler(this.AddTabVerb)),
      new DesignerVerb("Add Context", new EventHandler(this.AddContextVerb))
    };

    public void AddTabVerb(object sender, EventArgs e)
    {
      if (!(this.Control is Ribbon control) || !((this.GetService(typeof (IDesignerHost)) is IDesignerHost service ? service.CreateComponent(typeof (RibbonTab)) : (IComponent) null) is RibbonTab ribbonTab))
        return;
      ribbonTab.Text = ribbonTab.Site.Name;
      this.Ribbon.Tabs.Add(ribbonTab);
      control.Refresh();
    }

    public void AddContextVerb(object sender, EventArgs e)
    {
      if (!(this.Control is Ribbon control) || !((this.GetService(typeof (IDesignerHost)) is IDesignerHost service ? service.CreateComponent(typeof (RibbonContext)) : (IComponent) null) is RibbonContext ribbonContext))
        return;
      ribbonContext.Text = ribbonContext.Site.Name;
      Random random = new Random();
      ribbonContext.GlowColor = Color.FromArgb(random.Next(155, (int) byte.MaxValue), random.Next(155, (int) byte.MaxValue), random.Next(155, (int) byte.MaxValue));
      this.Ribbon.Contexts.Add(ribbonContext);
      control.Refresh();
    }

    protected override void WndProc(ref Message m)
    {
      if (m.HWnd == this.Control.Handle)
      {
        switch (m.Msg)
        {
          case 513:
            return;
          case 514:
          case 517:
            this.HitOn((int) WinApi.LoWord((int) m.LParam), (int) WinApi.HiWord((int) m.LParam));
            return;
          case 515:
            this.AssignEventHandler();
            break;
          case 516:
            return;
        }
      }
      base.WndProc(ref m);
    }

    private void HitOn(int x, int y)
    {
      if (this.Ribbon.Tabs.Count == 0 || this.Ribbon.ActiveTab == null)
      {
        this.SelectRibbon();
      }
      else
      {
        if (this.Ribbon == null)
          return;
        if (this.Ribbon.TabHitTest(x, y))
          this.SelectedElement = (IRibbonElement) this.Ribbon.ActiveTab;
        else if (this.Ribbon.ContextHitTest(x, y))
        {
          foreach (RibbonContext context in (List<RibbonContext>) this.Ribbon.Contexts)
          {
            if (context.Bounds.Contains(x, y))
            {
              this.SelectedElement = (IRibbonElement) context;
              break;
            }
          }
        }
        else
        {
          if (this.Ribbon.ActiveTab.TabContentBounds.Contains(x, y))
          {
            if (this.Ribbon.ActiveTab.ScrollLeftBounds.Contains(x, y) && this.Ribbon.ActiveTab.ScrollLeftVisible)
            {
              this.Ribbon.ActiveTab.ScrollLeft();
              this.SelectedElement = (IRibbonElement) this.Ribbon.ActiveTab;
              return;
            }
            if (this.Ribbon.ActiveTab.ScrollRightBounds.Contains(x, y) && this.Ribbon.ActiveTab.ScrollRightVisible)
            {
              this.Ribbon.ActiveTab.ScrollRight();
              this.SelectedElement = (IRibbonElement) this.Ribbon.ActiveTab;
              return;
            }
          }
          if (this.Ribbon.ActiveTab.TabContentBounds.Contains(x, y))
          {
            RibbonPanel ribbonPanel = (RibbonPanel) null;
            foreach (RibbonPanel panel in (List<RibbonPanel>) this.Ribbon.ActiveTab.Panels)
            {
              if (panel.Bounds.Contains(x, y))
              {
                ribbonPanel = panel;
                break;
              }
            }
            if (ribbonPanel != null)
            {
              RibbonItem ribbonItem1 = (RibbonItem) null;
              foreach (RibbonItem ribbonItem2 in (List<RibbonItem>) ribbonPanel.Items)
              {
                if (ribbonItem2.Bounds.Contains(x, y))
                {
                  ribbonItem1 = ribbonItem2;
                  break;
                }
              }
              if (ribbonItem1 != null && ribbonItem1 is IContainsSelectableRibbonItems)
              {
                RibbonItem ribbonItem3 = (RibbonItem) null;
                foreach (RibbonItem ribbonItem4 in (ribbonItem1 as IContainsSelectableRibbonItems).GetItems())
                {
                  if (ribbonItem4.Bounds.Contains(x, y))
                  {
                    ribbonItem3 = ribbonItem4;
                    break;
                  }
                }
                if (ribbonItem3 != null)
                  this.SelectedElement = (IRibbonElement) ribbonItem3;
                else
                  this.SelectedElement = (IRibbonElement) ribbonItem1;
              }
              else if (ribbonItem1 != null)
                this.SelectedElement = (IRibbonElement) ribbonItem1;
              else
                this.SelectedElement = (IRibbonElement) ribbonPanel;
            }
            else
              this.SelectedElement = (IRibbonElement) this.Ribbon.ActiveTab;
          }
          else if (this.Ribbon.QuickAccessToolbar.SuperBounds.Contains(x, y))
          {
            bool flag = false;
            foreach (RibbonItem ribbonItem in (List<RibbonItem>) this.Ribbon.QuickAccessToolbar.Items)
            {
              if (ribbonItem.Bounds.Contains(x, y))
              {
                flag = true;
                this.SelectedElement = (IRibbonElement) ribbonItem;
                break;
              }
            }
            if (flag)
              return;
            this.SelectedElement = (IRibbonElement) this.Ribbon.QuickAccessToolbar;
          }
          else if (this.Ribbon.OrbBounds.Contains(x, y))
          {
            this.Ribbon.OrbMouseDown();
          }
          else
          {
            this.SelectRibbon();
            this.Ribbon.ForceOrbMenu = false;
            if (!this.Ribbon.OrbDropDown.Visible)
              return;
            this.Ribbon.OrbDropDown.Close();
          }
        }
      }
    }

    protected override void OnPaintAdornments(PaintEventArgs pe)
    {
      base.OnPaintAdornments(pe);
      using (Pen pen = new Pen(Color.Black))
      {
        pen.DashStyle = DashStyle.Dot;
        if (!(this.GetService(typeof (ISelectionService)) is ISelectionService service2))
          return;
        foreach (IComponent selectedComponent in (IEnumerable) service2.GetSelectedComponents())
        {
          switch (selectedComponent)
          {
            case RibbonContext _:
              if (selectedComponent is RibbonContext ribbonContext4)
              {
                Rectangle rect = ribbonContext4.ContextualTabsCount > 0 ? ribbonContext4.HeaderBounds : ribbonContext4.Bounds;
                rect.Inflate(-1, -1);
                pe.Graphics.DrawRectangle(pen, rect);
                continue;
              }
              continue;
            case RibbonTab _:
              if (selectedComponent is RibbonTab ribbonTab4)
              {
                Rectangle bounds = ribbonTab4.Bounds;
                bounds.Inflate(-1, -1);
                pe.Graphics.DrawRectangle(pen, bounds);
                continue;
              }
              continue;
            case RibbonPanel _:
              if (selectedComponent is RibbonPanel ribbonPanel4)
              {
                Rectangle bounds = ribbonPanel4.Bounds;
                bounds.Inflate(-1, -1);
                pe.Graphics.DrawRectangle(pen, bounds);
                continue;
              }
              continue;
            case RibbonItem _:
              if (selectedComponent is RibbonItem ribbonItem4 && !this.Ribbon.OrbDropDown.AllItems.Contains(ribbonItem4))
              {
                Rectangle bounds = ribbonItem4.Bounds;
                bounds.Inflate(1, 1);
                pe.Graphics.DrawRectangle(pen, bounds);
                continue;
              }
              continue;
            default:
              continue;
          }
        }
      }
    }

    public BehaviorService GetBehaviorService() => this.BehaviorService;

    public override void Initialize(IComponent component)
    {
      base.Initialize(component);
      IComponentChangeService service = this.GetService(typeof (IComponentChangeService)) as IComponentChangeService;
      this.GetService(typeof (IDesignerEventService));
      if (service != null)
        service.ComponentRemoved += new ComponentEventHandler(this.changeService_ComponentRemoved);
      this._orbAdorner = new Adorner();
      this._tabAdorner = new Adorner();
      if (this.BehaviorService == null)
        return;
      this.BehaviorService.Adorners.AddRange(new Adorner[2]
      {
        this._orbAdorner,
        this._tabAdorner
      });
      if (this.Ribbon.QuickAccessToolbar.Visible)
      {
        this._quickAccessAdorner = new Adorner();
        this.BehaviorService.Adorners.Add(this._quickAccessAdorner);
        this._quickAccessAdorner.Glyphs.Add((Glyph) new RibbonQuickAccessToolbarGlyph(this.BehaviorService, this, this.Ribbon));
      }
      else
        this._quickAccessAdorner = (Adorner) null;
      this._tabAdorner.Glyphs.Add((Glyph) new RibbonTabGlyph(this.BehaviorService, this, this.Ribbon));
    }

    public void changeService_ComponentRemoved(object sender, ComponentEventArgs e)
    {
      RibbonTab component1 = e.Component as RibbonTab;
      RibbonContext component2 = e.Component as RibbonContext;
      RibbonPanel component3 = e.Component as RibbonPanel;
      RibbonItem component4 = e.Component as RibbonItem;
      IDesignerHost service = this.GetService(typeof (IDesignerHost)) as IDesignerHost;
      this.RemoveRecursive(e.Component as IContainsRibbonComponents, service);
      if (component1 != null && this.Ribbon != null)
        this.Ribbon.Tabs.Remove(component1);
      else if (component2 != null)
        this.Ribbon.Contexts.Remove(component2);
      else if (component3 != null)
        component3.OwnerTab.Panels.Remove(component3);
      else if (component4 != null)
      {
        if (component4.Canvas is RibbonOrbDropDown)
          this.Ribbon.OrbDropDown.HandleDesignerItemRemoved(component4);
        else if (component4.OwnerItem is RibbonItemGroup ownerItem6)
          ownerItem6.Items.Remove(component4);
        else if (component4.OwnerPanel != null)
          component4.OwnerPanel.Items.Remove(component4);
        else if (this.Ribbon != null && this.Ribbon.QuickAccessToolbar.Items.Contains(component4))
          this.Ribbon.QuickAccessToolbar.Items.Remove(component4);
      }
      this.SelectedElement = (IRibbonElement) null;
      this.Ribbon?.OnRegionsChanged();
    }

    public void RemoveRecursive(IContainsRibbonComponents item, IDesignerHost service)
    {
      if (item == null || service == null)
        return;
      foreach (Component allChildComponent in item.GetAllChildComponents())
      {
        if (allChildComponent is IContainsRibbonComponents ribbonComponents2)
          this.RemoveRecursive(ribbonComponents2, service);
        service.DestroyComponent((IComponent) allChildComponent);
      }
    }
  }
}
