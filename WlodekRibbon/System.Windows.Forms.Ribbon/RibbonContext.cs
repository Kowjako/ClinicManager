// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonContext
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
  [ToolboxItem(false)]
  [DesignTimeVisible(false)]
  public class RibbonContext : Component, IRibbonElement
  {
    private string _text;
    private Color _glowColor;
    private bool _visible;

    public event EventHandler OwnerChanged;

    [Category("Appearance")]
    public string Text
    {
      get => this._text;
      set
      {
        this._text = value;
        if (this.Owner == null)
          return;
        this.Owner.OnRegionsChanged();
      }
    }

    [Category("Appearance")]
    public Color GlowColor
    {
      get => this._glowColor;
      set
      {
        this._glowColor = value;
        if (this.Owner == null)
          return;
        this.Owner.OnRegionsChanged();
      }
    }

    [Category("Behavior")]
    [DefaultValue(false)]
    public bool Visible
    {
      get => (this.Owner == null || this.Owner.IsDesignMode() || this.Owner.Visible) && this._visible;
      set
      {
        this._visible = value;
        if (this.Owner != null)
        {
          if (this._visible)
          {
            if (this.ContextualTabsCount > 0)
              this.Owner.ActiveTab = this.ContextualTabs[0];
          }
          else
            this.Owner.ActiveTab = this.Owner.Tabs[0];
        }
        if (this.Owner == null)
          return;
        this.Owner.OnRegionsChanged();
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle Bounds { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle HeaderBounds { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public List<RibbonTab> ContextualTabs
    {
      get
      {
        List<RibbonTab> ribbonTabList = new List<RibbonTab>();
        foreach (RibbonTab tab in (List<RibbonTab>) this.Owner.Tabs)
        {
          if (tab.Context == this)
            ribbonTabList.Add(tab);
        }
        return ribbonTabList;
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int ContextualTabsCount
    {
      get
      {
        int num = 0;
        foreach (RibbonTab tab in (List<RibbonTab>) this.Owner.Tabs)
        {
          if (tab.Context == this)
            ++num;
        }
        return num;
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Ribbon Owner { get; private set; }

    public void SetBounds(Rectangle bounds) => this.Bounds = bounds;

    public void SetHeaderBounds(Rectangle bounds) => this.HeaderBounds = bounds;

    internal void SetOwner(Ribbon owner) => this.Owner = owner;

    internal virtual void ClearOwner()
    {
      this.Owner = (Ribbon) null;
      this.OnOwnerChanged(EventArgs.Empty);
    }

    public Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e) => !this.Visible && !this.Owner.IsDesignMode() ? new Size(0, 0) : Size.Ceiling(e.Graphics.MeasureString(string.IsNullOrEmpty(this.Text) ? "   " : this.Text, this.Owner.Font));

    public void OnPaint(object sender, RibbonElementPaintEventArgs e)
    {
      if (this.Owner == null || this.ContextualTabsCount <= 0 && !this.Owner.IsDesignMode())
        return;
      this.Owner.Renderer.OnRenderRibbonContext(new RibbonContextRenderEventArgs(this.Owner, e.Graphics, e.Clip, this));
      this.Owner.Renderer.OnRenderRibbonContextText(new RibbonContextRenderEventArgs(this.Owner, e.Graphics, e.Clip, this));
    }

    public void OnOwnerChanged(EventArgs e)
    {
      if (this.OwnerChanged == null)
        return;
      this.OwnerChanged((object) this, e);
    }
  }
}
