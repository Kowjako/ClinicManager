// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonTab
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

namespace System.Windows.Forms
{
  [DesignTimeVisible(false)]
  [Designer(typeof (RibbonTabDesigner))]
  public class RibbonTab : Component, IRibbonElement, IRibbonToolTip, IContainsRibbonComponents
  {
    private bool? _isopeninvisualstudiodesigner;
    private bool _enabled;
    private bool _pressed;
    private bool _selected;
    private bool _active;
    private string _text;
    private RibbonContext _context;
    private int _offset;
    private bool _visible = true;
    private readonly RibbonToolTip _TT;
    private string _Name = string.Empty;

    public event MouseEventHandler MouseEnter;

    public event MouseEventHandler MouseLeave;

    public event MouseEventHandler MouseMove;

    public RibbonTab()
    {
      this.Panels = new RibbonPanelCollection(this);
      this._enabled = true;
      RibbonToolTip ribbonToolTip = new RibbonToolTip((IRibbonElement) this);
      ribbonToolTip.InitialDelay = 100;
      ribbonToolTip.AutomaticDelay = 800;
      ribbonToolTip.AutoPopDelay = 8000;
      ribbonToolTip.UseAnimation = true;
      ribbonToolTip.Active = false;
      this._TT = ribbonToolTip;
      this._TT.Popup += new PopupEventHandler(this._TT_Popup);
    }

    public RibbonTab(string text)
      : this()
    {
      this._text = text;
    }

    [Obsolete("Use 'public RibbonTab(string text)' instead!")]
    public RibbonTab(Ribbon owner, string text)
      : this(text)
    {
    }

    protected bool IsOpenInVisualStudioDesigner()
    {
      if (!this._isopeninvisualstudiodesigner.HasValue)
      {
        this._isopeninvisualstudiodesigner = new bool?(LicenseManager.UsageMode == LicenseUsageMode.Designtime || this.DesignMode);
        if (!this._isopeninvisualstudiodesigner.Value)
        {
          try
          {
            using (Process currentProcess = Process.GetCurrentProcess())
              this._isopeninvisualstudiodesigner = new bool?(currentProcess.ProcessName.ToLowerInvariant().Contains("devenv"));
          }
          catch
          {
          }
        }
      }
      return this._isopeninvisualstudiodesigner.Value;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && RibbonDesigner.Current == null)
      {
        this._TT.Popup -= new PopupEventHandler(this._TT_Popup);
        this._TT.Dispose();
        try
        {
          foreach (Component panel in (List<RibbonPanel>) this.Panels)
            panel.Dispose();
        }
        catch (InvalidOperationException ex)
        {
          if (!this.IsOpenInVisualStudioDesigner())
            throw;
        }
      }
      base.Dispose(disposing);
    }

    public event EventHandler ScrollRightVisibleChanged;

    public event EventHandler ScrollRightPressedChanged;

    public event EventHandler ScrollRightBoundsChanged;

    public event EventHandler ScrollRightSelectedChanged;

    public event EventHandler ScrollLeftVisibleChanged;

    public event EventHandler ScrollLeftPressedChanged;

    public event EventHandler ScrollLeftSelectedChanged;

    public event EventHandler ScrollLeftBoundsChanged;

    public event EventHandler TabBoundsChanged;

    public event EventHandler TabContentBoundsChanged;

    public event EventHandler OwnerChanged;

    public event EventHandler PressedChanged;

    public event EventHandler ActiveChanged;

    public event EventHandler TextChanged;

    public event EventHandler ContextChanged;

    public virtual event RibbonElementPopupEventHandler ToolTipPopUp;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual string Name
    {
      get
      {
        if (this.Site != null)
          this._Name = this.Site.Name;
        return this._Name;
      }
      set => this._Name = value;
    }

    [DefaultValue(true)]
    [Category("Behavior")]
    [Description("Sets if the tab should be enabled")]
    public bool Enabled
    {
      get
      {
        if (this.Owner == null)
          return this._enabled;
        return this._enabled && this.Owner.Enabled;
      }
      set
      {
        this._enabled = value;
        this.Owner.Invalidate();
        foreach (RibbonPanel panel in (List<RibbonPanel>) this.Panels)
          panel.Enabled = value;
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public bool ScrollRightVisible { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public bool ScrollRightSelected { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public bool ScrollRightPressed { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Rectangle ScrollRightBounds { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Browsable(false)]
    public bool ScrollLeftVisible { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Rectangle ScrollLeftBounds { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public bool ScrollLeftSelected { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public bool ScrollLeftPressed { get; private set; }

    [Browsable(false)]
    public Rectangle Bounds => this.TabBounds;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public RibbonPanelCollection Panels { get; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle TabBounds { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle TabContentBounds { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Ribbon Owner { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual bool Pressed => this._pressed;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual bool Selected => this._selected;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual bool Active => this._active;

    [Description("An Object field for associating custom data for this control")]
    [DefaultValue(null)]
    [Category("Data")]
    [TypeConverter(typeof (StringConverter))]
    public object Tag { get; set; }

    [DefaultValue(null)]
    [Category("Data")]
    [Description("A string field for associating custom data for this control")]
    public string Value { get; set; }

    [Category("Behavior")]
    [DefaultValue(null)]
    public string AltKey { get; set; }

    [Localizable(true)]
    [Category("Appearance")]
    public string Text
    {
      get => this._text;
      set
      {
        this._text = value;
        this.OnTextChanged(EventArgs.Empty);
        if (this.Owner == null)
          return;
        this.Owner.OnRegionsChanged();
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual bool Contextual => this._context != null;

    [DefaultValue(null)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public RibbonContext Context
    {
      get => this._context;
      set
      {
        this._context = value;
        this.OnContextChanged(EventArgs.Empty);
        if (this.Owner == null)
          return;
        this.Owner.OnRegionsChanged();
        this.Owner.UpdateRegions();
      }
    }

    [Category("Behavior")]
    [Localizable(true)]
    [DefaultValue(true)]
    public bool Visible
    {
      get
      {
        if (this.Owner != null && !this.Owner.IsDesignMode() && !this.Owner.Visible)
          return false;
        return !this.Contextual ? this._visible : this.Context.Visible;
      }
      set
      {
        this._visible = value;
        if (this.Owner == null)
          return;
        this.Owner.UpdateRegions();
        if (this.Active)
          this.EnsureAnyTabVisible();
        else
          this.Owner.Invalidate();
      }
    }

    [DefaultValue("")]
    public string ToolTipTitle
    {
      get => this._TT.ToolTipTitle;
      set => this._TT.ToolTipTitle = value;
    }

    [DefaultValue(ToolTipIcon.None)]
    public ToolTipIcon ToolTipIcon
    {
      get => this._TT.ToolTipIcon;
      set => this._TT.ToolTipIcon = value;
    }

    [DefaultValue(null)]
    [Localizable(true)]
    public string ToolTip { get; set; }

    [DefaultValue(null)]
    [Localizable(true)]
    public Image ToolTipImage
    {
      get => this._TT.ToolTipImage;
      set => this._TT.ToolTipImage = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    internal bool Invisible => this.Owner != null && this.Owner.HideSingleTabIfTextEmpty && this.Owner.Tabs.Count == 1 && string.IsNullOrEmpty(this.Text);

    public void OnPaint(object sender, RibbonElementPaintEventArgs e)
    {
      if (this.Owner == null)
        return;
      this.Owner.Renderer.OnRenderRibbonTab(new RibbonTabRenderEventArgs(this.Owner, e.Graphics, e.Clip, this));
      this.Owner.Renderer.OnRenderRibbonTabText(new RibbonTabRenderEventArgs(this.Owner, e.Graphics, e.Clip, this));
      if (this.Active && (!this.Owner.Minimized || this.Owner.Minimized && this.Owner.Expanded))
      {
        int num = 0;
        foreach (RibbonPanel panel in (List<RibbonPanel>) this.Panels)
        {
          if (panel.Visible)
          {
            panel.Index = num;
            panel.IsFirstPanel = num == 0;
            panel.OnPaint((object) this, new RibbonElementPaintEventArgs(e.Clip, e.Graphics, panel.SizeMode, e.Control));
            ++num;
          }
        }
        foreach (RibbonPanel panel in (List<RibbonPanel>) this.Panels)
        {
          if (panel.Visible)
          {
            panel.IsLastPanel = panel.Index == num - 1;
            break;
          }
        }
      }
      this.Owner.Renderer.OnRenderTabScrollButtons(new RibbonTabRenderEventArgs(this.Owner, e.Graphics, e.Clip, this));
    }

    public void SetBounds(Rectangle bounds) => throw new NotSupportedException();

    public void SetContext(RibbonContext context)
    {
      if (!context.Equals((object) context))
        this.OnContextChanged(EventArgs.Empty);
      this._context = context;
    }

    public Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e) => !this.Visible && !this.Owner.IsDesignMode() ? new Size(0, 0) : Size.Ceiling(e.Graphics.MeasureString(string.IsNullOrEmpty(this.Text) ? " " : this.Text, this.Owner.Font));

    internal void SetOwner(Ribbon owner)
    {
      this.Owner = owner;
      this.Panels.SetOwner(owner);
      this.OnOwnerChanged(EventArgs.Empty);
    }

    internal virtual void ClearOwner()
    {
      this.Owner = (Ribbon) null;
      this.OnOwnerChanged(EventArgs.Empty);
    }

    internal void SetPressed(bool pressed)
    {
      this._pressed = pressed;
      this.OnPressedChanged(EventArgs.Empty);
    }

    internal void SetSelected(bool selected)
    {
      this._selected = selected;
      if (selected)
        this.OnMouseEnter(new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0));
      else
        this.OnMouseLeave(new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0));
    }

    public void OnContextChanged(EventArgs e)
    {
      if (this.ContextChanged == null)
        return;
      this.ContextChanged((object) this, e);
    }

    public void OnTextChanged(EventArgs e)
    {
      if (this.TextChanged == null)
        return;
      this.TextChanged((object) this, e);
    }

    public void OnActiveChanged(EventArgs e)
    {
      if (this.ActiveChanged == null)
        return;
      this.ActiveChanged((object) this, e);
    }

    public void OnPressedChanged(EventArgs e)
    {
      if (this.PressedChanged == null)
        return;
      this.PressedChanged((object) this, e);
    }

    public void OnOwnerChanged(EventArgs e)
    {
      if (this.OwnerChanged == null)
        return;
      this.OwnerChanged((object) this, e);
    }

    public void OnTabContentBoundsChanged(EventArgs e)
    {
      if (this.TabContentBoundsChanged == null)
        return;
      this.TabContentBoundsChanged((object) this, e);
    }

    public void OnTabBoundsChanged(EventArgs e)
    {
      if (this.TabBoundsChanged == null)
        return;
      this.TabBoundsChanged((object) this, e);
    }

    public void OnScrollRightVisibleChanged(EventArgs e)
    {
      if (this.ScrollRightVisibleChanged == null)
        return;
      this.ScrollRightVisibleChanged((object) this, e);
    }

    public void OnScrollRightPressedChanged(EventArgs e)
    {
      if (this.ScrollRightPressedChanged == null)
        return;
      this.ScrollRightPressedChanged((object) this, e);
    }

    public void OnScrollRightBoundsChanged(EventArgs e)
    {
      if (this.ScrollRightBoundsChanged == null)
        return;
      this.ScrollRightBoundsChanged((object) this, e);
    }

    public void OnScrollRightSelectedChanged(EventArgs e)
    {
      if (this.ScrollRightSelectedChanged == null)
        return;
      this.ScrollRightSelectedChanged((object) this, e);
    }

    public void OnScrollLeftVisibleChanged(EventArgs e)
    {
      if (this.ScrollLeftVisibleChanged == null)
        return;
      this.ScrollLeftVisibleChanged((object) this, e);
    }

    public void OnScrollLeftPressedChanged(EventArgs e)
    {
      if (this.ScrollLeftPressedChanged == null)
        return;
      this.ScrollLeftPressedChanged((object) this, e);
    }

    public void OnScrollLeftBoundsChanged(EventArgs e)
    {
      if (this.ScrollLeftBoundsChanged == null)
        return;
      this.ScrollLeftBoundsChanged((object) this, e);
    }

    public void OnScrollLeftSelectedChanged(EventArgs e)
    {
      if (this.ScrollLeftSelectedChanged == null)
        return;
      this.ScrollLeftSelectedChanged((object) this, e);
    }

    internal void SetActive(bool active)
    {
      int num = this._active != active ? 1 : 0;
      this._active = active;
      if (num == 0)
        return;
      this.OnActiveChanged(EventArgs.Empty);
    }

    internal void SetTabBounds(Rectangle tabBounds)
    {
      int num = this.TabBounds != tabBounds ? 1 : 0;
      this.TabBounds = tabBounds;
      this.OnTabBoundsChanged(EventArgs.Empty);
    }

    internal void SetTabContentBounds(Rectangle tabContentBounds)
    {
      int num = this.TabContentBounds != tabContentBounds ? 1 : 0;
      this.TabContentBounds = tabContentBounds;
      this.OnTabContentBoundsChanged(EventArgs.Empty);
    }

    private RibbonPanel GetLargerPanel(RibbonElementSizeMode size)
    {
      RibbonPanel ribbonPanel = (RibbonPanel) null;
      foreach (RibbonPanel panel in (List<RibbonPanel>) this.Panels)
      {
        if (panel.SizeMode == size)
        {
          if (ribbonPanel == null)
            ribbonPanel = panel;
          if (panel.Bounds.Width > ribbonPanel.Bounds.Width)
            ribbonPanel = panel;
        }
      }
      return ribbonPanel;
    }

    private RibbonPanel GetLargerPanel() => this.GetLargerPanel(RibbonElementSizeMode.Large) ?? this.GetLargerPanel(RibbonElementSizeMode.Medium) ?? this.GetLargerPanel(RibbonElementSizeMode.Compact) ?? this.GetLargerPanel(RibbonElementSizeMode.Overflow) ?? (RibbonPanel) null;

    private bool AllPanelsOverflow()
    {
      foreach (RibbonPanel panel in (List<RibbonPanel>) this.Panels)
      {
        if (panel.SizeMode != RibbonElementSizeMode.Overflow)
          return false;
      }
      return true;
    }

    internal void UpdatePanelsRegions()
    {
      if (this.Panels.Count == 0 || this.Owner == null || this.Owner.IsDisposed)
        return;
      if (!this.Owner.IsDesignMode())
        this._offset = 0;
      Rectangle tabContentBounds = this.TabContentBounds;
      int x = tabContentBounds.Left + this.Owner.PanelPadding.Left + this._offset;
      tabContentBounds = this.TabContentBounds;
      int num1 = tabContentBounds.Right - this.Owner.PanelPadding.Right;
      tabContentBounds = this.TabContentBounds;
      int top1 = tabContentBounds.Top;
      Padding panelPadding = this.Owner.PanelPadding;
      int top2 = panelPadding.Top;
      int y = top1 + top2;
      int num2 = 0;
      using (Graphics graphics = this.Owner.CreateGraphics())
      {
        foreach (RibbonPanel panel in (List<RibbonPanel>) this.Panels)
        {
          if (panel.Visible && this.Owner.RightToLeft == RightToLeft.No)
          {
            RibbonElementSizeMode sizeMode = panel.FlowsTo == RibbonPanelFlowDirection.Right ? RibbonElementSizeMode.Medium : RibbonElementSizeMode.Large;
            RibbonPanel ribbonPanel = panel;
            tabContentBounds = this.TabContentBounds;
            int height = tabContentBounds.Height;
            panelPadding = this.Owner.PanelPadding;
            int vertical = panelPadding.Vertical;
            Rectangle bounds1 = new Rectangle(0, 0, 1, height - vertical);
            ribbonPanel.SetBounds(bounds1);
            Size size = panel.MeasureSize((object) this, new RibbonElementMeasureSizeEventArgs(graphics, sizeMode));
            Rectangle bounds2 = new Rectangle(x, y, size.Width, size.Height);
            panel.SetBounds(bounds2);
            panel.SetSizeMode(sizeMode);
            x = bounds2.Right + this.Owner.PanelSpacing;
            ++num2;
          }
          else if (panel.Visible && this.Owner.RightToLeft == RightToLeft.Yes)
          {
            RibbonElementSizeMode sizeMode = panel.FlowsTo == RibbonPanelFlowDirection.Right ? RibbonElementSizeMode.Medium : RibbonElementSizeMode.Large;
            RibbonPanel ribbonPanel = panel;
            tabContentBounds = this.TabContentBounds;
            int height = tabContentBounds.Height;
            panelPadding = this.Owner.PanelPadding;
            int vertical = panelPadding.Vertical;
            Rectangle bounds3 = new Rectangle(0, 0, 1, height - vertical);
            ribbonPanel.SetBounds(bounds3);
            Size size = panel.MeasureSize((object) this, new RibbonElementMeasureSizeEventArgs(graphics, sizeMode));
            Rectangle bounds4 = new Rectangle(num1 - (size.Width + this.Owner.PanelSpacing), y, size.Width, size.Height);
            panel.SetBounds(bounds4);
            panel.SetSizeMode(sizeMode);
            num1 = bounds4.Left - 1 - this.Owner.PanelSpacing;
            ++num2;
          }
          else
            panel.SetBounds(Rectangle.Empty);
        }
        if (!this.Owner.IsDesignMode() && num2 > 0)
        {
label_25:
          int num3 = x;
          Rectangle rectangle = this.TabContentBounds;
          int right = rectangle.Right;
          if (num3 > right && !this.AllPanelsOverflow())
          {
            RibbonPanel largerPanel = this.GetLargerPanel();
            if (largerPanel.SizeMode == RibbonElementSizeMode.Large)
              largerPanel.SetSizeMode(RibbonElementSizeMode.Medium);
            else if (largerPanel.SizeMode == RibbonElementSizeMode.Medium)
              largerPanel.SetSizeMode(RibbonElementSizeMode.Compact);
            else if (largerPanel.SizeMode == RibbonElementSizeMode.Compact)
              largerPanel.SetSizeMode(RibbonElementSizeMode.Overflow);
            Size size1 = largerPanel.MeasureSize((object) this, new RibbonElementMeasureSizeEventArgs(graphics, largerPanel.SizeMode));
            RibbonPanel ribbonPanel = largerPanel;
            rectangle = largerPanel.Bounds;
            Rectangle bounds = new Rectangle(rectangle.Location, new Size(size1.Width + this.Owner.PanelMargin.Horizontal, size1.Height));
            ribbonPanel.SetBounds(bounds);
            rectangle = this.TabContentBounds;
            x = rectangle.Left + this.Owner.PanelPadding.Left;
            using (List<RibbonPanel>.Enumerator enumerator = this.Panels.GetEnumerator())
            {
              while (enumerator.MoveNext())
              {
                RibbonPanel current = enumerator.Current;
                rectangle = current.Bounds;
                Size size2 = rectangle.Size;
                current.SetBounds(new Rectangle(new Point(x, y), size2));
                int num4 = x;
                rectangle = current.Bounds;
                int num5 = rectangle.Width + this.Owner.PanelSpacing;
                x = num4 + num5;
              }
              goto label_25;
            }
          }
        }
        foreach (RibbonPanel panel in (List<RibbonPanel>) this.Panels)
          panel.UpdateItemsRegions(graphics, panel.SizeMode);
      }
      this.UpdateScrollBounds();
    }

    private void UpdateScrollBounds()
    {
      int num1 = 13;
      bool scrollRightVisible = this.ScrollRightVisible;
      int num2 = this.ScrollLeftVisible ? 1 : 0;
      Rectangle scrollRightBounds = this.ScrollRightBounds;
      Rectangle scrollLeftBounds = this.ScrollLeftBounds;
      if (this.Panels.Count == 0)
        return;
      Rectangle rectangle = this.Panels[this.Panels.Count - 1].Bounds;
      int right1 = rectangle.Right;
      rectangle = this.TabContentBounds;
      int right2 = rectangle.Right;
      this.ScrollRightVisible = right1 > right2;
      if (this.ScrollRightVisible != scrollRightVisible)
        this.OnScrollRightVisibleChanged(EventArgs.Empty);
      this.ScrollLeftVisible = this._offset < 0;
      if (this.ScrollRightVisible != scrollRightVisible)
        this.OnScrollLeftVisibleChanged(EventArgs.Empty);
      if (!this.ScrollLeftVisible && !this.ScrollRightVisible)
        return;
      rectangle = this.Owner.ClientRectangle;
      int left = rectangle.Right - num1;
      rectangle = this.TabContentBounds;
      int top1 = rectangle.Top;
      rectangle = this.Owner.ClientRectangle;
      int right3 = rectangle.Right;
      rectangle = this.TabContentBounds;
      int bottom1 = rectangle.Bottom;
      this.ScrollRightBounds = Rectangle.FromLTRB(left, top1, right3, bottom1);
      rectangle = this.TabContentBounds;
      int top2 = rectangle.Top;
      int right4 = num1;
      rectangle = this.TabContentBounds;
      int bottom2 = rectangle.Bottom;
      this.ScrollLeftBounds = Rectangle.FromLTRB(0, top2, right4, bottom2);
      if (this.ScrollRightBounds != scrollRightBounds)
        this.OnScrollRightBoundsChanged(EventArgs.Empty);
      if (!(this.ScrollLeftBounds != scrollLeftBounds))
        return;
      this.OnScrollLeftBoundsChanged(EventArgs.Empty);
    }

    public override string ToString() => string.Format("Tab: {0}", (object) this.Text);

    public virtual void OnMouseEnter(MouseEventArgs e)
    {
      if (this.MouseEnter == null)
        return;
      this.MouseEnter((object) this, e);
    }

    public virtual void OnMouseLeave(MouseEventArgs e)
    {
      this._TT.Active = false;
      if (this.MouseLeave == null)
        return;
      this.MouseLeave((object) this, e);
    }

    public virtual void OnMouseMove(MouseEventArgs e)
    {
      if (this.MouseMove != null)
        this.MouseMove((object) this, e);
      if (this._TT.Active || string.IsNullOrEmpty(this.ToolTip))
        return;
      if (this.ToolTip != this._TT.GetToolTip((Control) this.Owner))
        this._TT.SetToolTip((Control) this.Owner, this.ToolTip);
      this._TT.Active = true;
    }

    internal void SetScrollLeftPressed(bool pressed)
    {
      this.ScrollLeftPressed = pressed;
      if (pressed)
        this.ScrollLeft();
      this.OnScrollLeftPressedChanged(EventArgs.Empty);
    }

    internal void SetScrollLeftSelected(bool selected)
    {
      this.ScrollLeftSelected = selected;
      this.OnScrollLeftSelectedChanged(EventArgs.Empty);
    }

    internal void SetScrollRightPressed(bool pressed)
    {
      this.ScrollRightPressed = pressed;
      if (pressed)
        this.ScrollRight();
      this.OnScrollRightPressedChanged(EventArgs.Empty);
    }

    internal void SetScrollRightSelected(bool selected)
    {
      this.ScrollRightSelected = selected;
      this.OnScrollRightSelectedChanged(EventArgs.Empty);
    }

    public void ScrollLeft() => this.ScrollOffset(50);

    public void ScrollRight() => this.ScrollOffset(-50);

    public void ScrollOffset(int amount)
    {
      this._offset += amount;
      foreach (RibbonPanel panel in (List<RibbonPanel>) this.Panels)
      {
        RibbonPanel ribbonPanel = panel;
        Rectangle bounds1 = panel.Bounds;
        int x = bounds1.Left + amount;
        bounds1 = panel.Bounds;
        int top = bounds1.Top;
        bounds1 = panel.Bounds;
        int width = bounds1.Width;
        bounds1 = panel.Bounds;
        int height = bounds1.Height;
        Rectangle bounds2 = new Rectangle(x, top, width, height);
        ribbonPanel.SetBounds(bounds2);
      }
      if (this.Site != null && this.Site.DesignMode)
        this.UpdatePanelsRegions();
      this.UpdateScrollBounds();
      this.Owner.Invalidate();
    }

    private void _TT_Popup(object sender, PopupEventArgs e)
    {
      if (this.ToolTipPopUp == null)
        return;
      this.ToolTipPopUp(sender, new RibbonElementPopupEventArgs((IRibbonElement) this, e));
      if (!(this.ToolTip != this._TT.GetToolTip((Control) this.Owner)))
        return;
      this._TT.SetToolTip((Control) this.Owner, this.ToolTip);
    }

    private void EnsureAnyTabVisible()
    {
      int num = this.Owner.Tabs.IndexOf(this);
      for (int index = num; index < this.Owner.Tabs.Count; ++index)
      {
        if (this != this.Owner.Tabs[index] && this.Owner.Tabs[index]._visible)
        {
          this.Owner.ActiveTab = this.Owner.Tabs[index];
          return;
        }
      }
      for (int index = 0; index < num; ++index)
      {
        if (this != this.Owner.Tabs[index] && this.Owner.Tabs[index]._visible)
        {
          this.Owner.ActiveTab = this.Owner.Tabs[index];
          return;
        }
      }
      this.Owner.Invalidate();
    }

    public IEnumerable<Component> GetAllChildComponents() => (IEnumerable<Component>) this.Panels.ToArray();
  }
}
