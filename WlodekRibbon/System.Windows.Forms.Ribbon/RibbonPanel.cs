// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonPanel
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
  [Designer(typeof (RibbonPanelDesigner))]
  public class RibbonPanel : 
    Component,
    IRibbonElement,
    IContainsSelectableRibbonItems,
    IContainsRibbonComponents
  {
    private bool? _isopeninvisualstudiodesigner;
    private bool _enabled;
    private Image _image;
    private string _text;
    private bool _selected;
    private RibbonPanelFlowDirection _flowsTo;
    private bool _buttonMoreVisible;
    private bool _buttonMoreEnabled;
    internal Rectangle overflowBoundsBuffer;
    private bool _visible = true;
    private string _Name = string.Empty;

    public event MouseEventHandler MouseEnter;

    public event MouseEventHandler MouseLeave;

    public event MouseEventHandler MouseMove;

    public event PaintEventHandler Paint;

    public event EventHandler Resize;

    public event EventHandler ButtonMoreClick;

    public virtual event EventHandler Click;

    public virtual event EventHandler DoubleClick;

    public virtual event MouseEventHandler MouseDown;

    public virtual event MouseEventHandler MouseUp;

    public RibbonPanel()
    {
      this.Items = new RibbonItemCollection();
      this.Items.SetOwnerPanel(this);
      this.SizeMode = RibbonElementSizeMode.None;
      this._flowsTo = RibbonPanelFlowDirection.Bottom;
      this._buttonMoreEnabled = true;
      this._buttonMoreVisible = true;
      this._enabled = true;
    }

    public RibbonPanel(string text)
      : this(text, RibbonPanelFlowDirection.Bottom)
    {
    }

    public RibbonPanel(string text, RibbonPanelFlowDirection flowsTo)
      : this(text, flowsTo, (IEnumerable<RibbonItem>) new RibbonItem[0])
    {
    }

    public RibbonPanel(
      string text,
      RibbonPanelFlowDirection flowsTo,
      IEnumerable<RibbonItem> items)
      : this()
    {
      this._text = text;
      this._flowsTo = flowsTo;
      this.Items.AddRange(items);
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
    [Description("Sets if the panel should be enabled")]
    public bool Enabled
    {
      get
      {
        if (this.OwnerTab == null)
          return this._enabled;
        return this._enabled && this.OwnerTab.Enabled;
      }
      set
      {
        this._enabled = value;
        this.Owner.Invalidate();
        foreach (RibbonItem ribbonItem in (List<RibbonItem>) this.Items)
          ribbonItem.Enabled = value;
      }
    }

    [DefaultValue(true)]
    [Category("Behavior")]
    [Description("Sets if the panel should be Visible")]
    public virtual bool Visible
    {
      get => (this.Owner == null || this.Owner.IsDesignMode() || this.OwnerTab == null || this.OwnerTab.Visible) && this._visible;
      set
      {
        this._visible = value;
        if (this.Owner == null)
          return;
        this.Owner.PerformLayout();
        this.Owner.Invalidate();
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Collapsed => this.SizeMode == RibbonElementSizeMode.Overflow;

    [Description("Sets the visibility of the \"More...\" button")]
    [Category("Appearance")]
    [DefaultValue(true)]
    public bool ButtonMoreVisible
    {
      get => this._buttonMoreVisible;
      set
      {
        this._buttonMoreVisible = value;
        if (this.Owner == null)
          return;
        this.Owner.OnRegionsChanged();
      }
    }

    [Description("Enables/Disables the \"More...\" button")]
    [Category("Appearance")]
    [DefaultValue(true)]
    public bool ButtonMoreEnabled
    {
      get => this._buttonMoreEnabled;
      set
      {
        this._buttonMoreEnabled = value;
        if (this.Owner == null)
          return;
        this.Owner.OnRegionsChanged();
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ButtonMoreSelected { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ButtonMorePressed { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle ButtonMoreBounds { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Pressed { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    internal Control PopUp { get; set; }

    [Browsable(false)]
    public RibbonElementSizeMode SizeMode { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public RibbonItemCollection Items { get; }

    [Category("Appearance")]
    [Localizable(true)]
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

    [DefaultValue(null)]
    [Category("Appearance")]
    public Image Image
    {
      get => this._image;
      set
      {
        this._image = value;
        if (this.Owner == null)
          return;
        this.Owner.OnRegionsChanged();
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool OverflowMode => this.SizeMode == RibbonElementSizeMode.Overflow;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Ribbon Owner { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle Bounds { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual bool Selected
    {
      get => this._selected;
      set => this._selected = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual bool IsFirstPanel { get; set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual bool IsLastPanel { get; set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual int Index { get; set; } = -1;

    [Description("An Object field for associating custom data for this control")]
    [DefaultValue(null)]
    [Category("Data")]
    [TypeConverter(typeof (StringConverter))]
    public object Tag { get; set; }

    [Browsable(false)]
    public Rectangle ContentBounds { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RibbonTab OwnerTab { get; private set; }

    [DefaultValue(RibbonPanelFlowDirection.Bottom)]
    [Category("Layout")]
    public RibbonPanelFlowDirection FlowsTo
    {
      get => this._flowsTo;
      set
      {
        this._flowsTo = value;
        if (this.Owner == null)
          return;
        this.Owner.OnRegionsChanged();
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    internal bool PopupShowed { get; set; }

    public Size SwitchToSize(Control ctl, Graphics g, RibbonElementSizeMode size)
    {
      Size size1 = this.MeasureSize((object) this, new RibbonElementMeasureSizeEventArgs(g, size));
      this.SetBounds(new Rectangle(0, 0, size1.Width, size1.Height));
      this.UpdateItemsRegions(g, size);
      return size1;
    }

    public virtual void OnPaint(object sender, RibbonElementPaintEventArgs e)
    {
      if (this.Paint != null)
        this.Paint((object) this, new PaintEventArgs(e.Graphics, e.Clip));
      if (this.PopupShowed && e.Control == this.Owner)
      {
        RibbonPanel panel = new RibbonPanel(this.Text)
        {
          Image = this.Image
        };
        panel.SetOwner(this.Owner);
        panel.SetSizeMode(RibbonElementSizeMode.Overflow);
        panel.SetBounds(this.overflowBoundsBuffer);
        panel.SetPressed(true);
        this.Owner.Renderer.OnRenderRibbonPanelBackground(new RibbonPanelRenderEventArgs(this.Owner, e.Graphics, e.Clip, panel, e.Control));
        this.Owner.Renderer.OnRenderRibbonPanelText(new RibbonPanelRenderEventArgs(this.Owner, e.Graphics, e.Clip, panel, e.Control));
      }
      else
      {
        this.Owner.Renderer.OnRenderRibbonPanelBackground(new RibbonPanelRenderEventArgs(this.Owner, e.Graphics, e.Clip, this, e.Control));
        this.Owner.Renderer.OnRenderRibbonPanelText(new RibbonPanelRenderEventArgs(this.Owner, e.Graphics, e.Clip, this, e.Control));
      }
      if (e.Mode == RibbonElementSizeMode.Overflow && (e.Control == null || e.Control != this.PopUp))
        return;
      foreach (RibbonItem ribbonItem in (List<RibbonItem>) this.Items)
      {
        if (ribbonItem.Visible || this.Owner.IsDesignMode())
          ribbonItem.OnPaint((object) this, new RibbonElementPaintEventArgs(ribbonItem.Bounds, e.Graphics, ribbonItem.SizeMode));
      }
    }

    public void SetBounds(Rectangle bounds)
    {
      int num = this.Bounds != bounds ? 1 : 0;
      this.Bounds = bounds;
      this.OnResize(EventArgs.Empty);
      Padding padding;
      if (this.Owner != null)
      {
        int x = bounds.X;
        padding = this.Owner.PanelMargin;
        int left1 = padding.Left;
        int left2 = x + left1;
        int y = bounds.Y;
        padding = this.Owner.PanelMargin;
        int top1 = padding.Top;
        int top2 = y + top1;
        int right1 = bounds.Right;
        padding = this.Owner.PanelMargin;
        int right2 = padding.Right;
        int right3 = right1 - right2;
        int bottom1 = bounds.Bottom;
        padding = this.Owner.PanelMargin;
        int bottom2 = padding.Bottom;
        int bottom3 = bottom1 - bottom2;
        this.ContentBounds = Rectangle.FromLTRB(left2, top2, right3, bottom3);
      }
      if (this.ButtonMoreVisible)
      {
        int right4 = bounds.Right;
        padding = this.Owner.PanelMoreMargin;
        int right5 = padding.Right;
        int left = right4 - right5 - 15;
        int bottom4 = bounds.Bottom;
        padding = this.Owner.PanelMoreMargin;
        int bottom5 = padding.Bottom;
        int top = bottom4 - bottom5 - 14;
        int right6 = bounds.Right;
        padding = this.Owner.PanelMoreMargin;
        int right7 = padding.Right;
        int right8 = right6 - right7;
        int bottom6 = bounds.Bottom;
        padding = this.Owner.PanelMoreMargin;
        int bottom7 = padding.Bottom;
        int bottom8 = bottom6 - bottom7;
        this.SetMoreBounds(Rectangle.FromLTRB(left, top, right8, bottom8));
      }
      else
        this.SetMoreBounds(Rectangle.Empty);
    }

    public Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
    {
      Size empty1 = Size.Empty;
      Size empty2 = Size.Empty;
      if (!this.Visible && !this.Owner.IsDesignMode())
        return new Size(0, 0);
      int height1 = this.OwnerTab.TabContentBounds.Height;
      Padding padding = this.Owner.PanelPadding;
      int vertical = padding.Vertical;
      int height2 = height1 - vertical;
      ref Size local = ref empty2;
      int width1 = e.Graphics.MeasureString(this.Text, this.Owner.Font).ToSize().Width;
      padding = this.Owner.PanelMargin;
      int horizontal1 = padding.Horizontal;
      int num = width1 + horizontal1 + 1;
      local.Width = num;
      if (this.ButtonMoreVisible)
        empty2.Width += this.ButtonMoreBounds.Width + 3;
      if (e.SizeMode == RibbonElementSizeMode.Overflow)
      {
        int width2 = RibbonButton.MeasureStringLargeSize(e.Graphics, this.Text, this.Owner.Font).Width;
        padding = this.Owner.PanelMargin;
        int horizontal2 = padding.Horizontal;
        return new Size(width2 + horizontal2, height2);
      }
      Size size;
      switch (this.FlowsTo)
      {
        case RibbonPanelFlowDirection.Bottom:
          size = this.MeasureSizeFlowsToBottom(sender, e);
          break;
        case RibbonPanelFlowDirection.Right:
          size = this.MeasureSizeFlowsToRight(sender, e);
          break;
        case RibbonPanelFlowDirection.Left:
          size = this.MeasureSizeFlowsToBottom(sender, e);
          break;
        default:
          size = Size.Empty;
          break;
      }
      return new Size(Math.Max(size.Width, empty2.Width), height2);
    }

    internal void SetOwner(Ribbon owner)
    {
      this.Owner = owner;
      this.Items.SetOwner(owner);
    }

    internal virtual void ClearOwner()
    {
      this.OwnerTab = (RibbonTab) null;
      this.Owner = (Ribbon) null;
    }

    internal void SetSelected(bool selected) => this._selected = selected;

    protected virtual void OnResize(EventArgs e)
    {
      if (this.Resize == null)
        return;
      this.Resize((object) this, e);
    }

    private void ShowOverflowPopup()
    {
      Rectangle bounds = this.Bounds;
      RibbonPanelPopup ribbonPanelPopup = new RibbonPanelPopup(this);
      Point screen = this.Owner.PointToScreen(new Point(bounds.Left, bounds.Bottom));
      this.PopupShowed = true;
      Point screenLocation = screen;
      ribbonPanelPopup.Show(screenLocation);
    }

    private Size MeasureSizeFlowsToRight(object sender, RibbonElementMeasureSizeEventArgs e)
    {
      int horizontal = this.Owner.PanelMargin.Horizontal;
      int val1_1 = 0;
      int val1_2 = 0;
      int num = 0;
      foreach (RibbonItem ribbonItem in (List<RibbonItem>) this.Items)
      {
        if (ribbonItem.Visible || this.Owner.IsDesignMode())
        {
          Size size = ribbonItem.MeasureSize((object) this, e);
          horizontal += size.Width + this.Owner.ItemPadding.Horizontal + 1;
          val1_1 = Math.Max(val1_1, size.Width);
          val1_2 = Math.Max(val1_2, size.Height);
        }
      }
      switch (e.SizeMode)
      {
        case RibbonElementSizeMode.Compact:
          num = horizontal / 3;
          break;
        case RibbonElementSizeMode.Medium:
          num = horizontal / 2;
          break;
        case RibbonElementSizeMode.Large:
          num = horizontal / 1;
          break;
      }
      int val2 = num + this.Owner.PanelMargin.Horizontal;
      return new Size(Math.Max(val1_1, val2) + this.Owner.PanelMargin.Horizontal, 0);
    }

    private Size MeasureSizeFlowsToBottom(object sender, RibbonElementMeasureSizeEventArgs e)
    {
      Padding padding1 = this.Owner.PanelMargin;
      int left = padding1.Left;
      padding1 = this.Owner.ItemPadding;
      int horizontal1 = padding1.Horizontal;
      int x = left + horizontal1;
      int y = this.ContentBounds.Top + this.Owner.ItemPadding.Vertical;
      int height = this.OwnerTab.TabContentBounds.Height;
      int vertical1 = this.Owner.TabContentMargin.Vertical;
      int vertical2 = this.Owner.PanelPadding.Vertical;
      int vertical3 = this.Owner.PanelMargin.Vertical;
      int val1_1 = 0;
      int val1_2 = 0;
      foreach (RibbonItem ribbonItem in (List<RibbonItem>) this.Items)
      {
        if (ribbonItem.Visible || this.Owner.IsDesignMode() || ribbonItem.GetType() == typeof (RibbonSeparator))
        {
          Size size = ribbonItem.MeasureSize((object) this, new RibbonElementMeasureSizeEventArgs(e.Graphics, e.SizeMode));
          int num1 = y + size.Height;
          Rectangle contentBounds = this.ContentBounds;
          int bottom1 = contentBounds.Bottom;
          Padding itemPadding;
          if (num1 > bottom1)
          {
            contentBounds = this.ContentBounds;
            int top = contentBounds.Top;
            itemPadding = this.Owner.ItemPadding;
            int vertical4 = itemPadding.Vertical;
            y = top + vertical4;
            int num2 = val1_1;
            itemPadding = this.Owner.ItemPadding;
            int horizontal2 = itemPadding.Horizontal;
            x = num2 + horizontal2;
          }
          Rectangle rectangle = new Rectangle(x, y, size.Width, size.Height);
          int right = rectangle.Right;
          int bottom2 = rectangle.Bottom;
          int bottom3 = rectangle.Bottom;
          itemPadding = this.Owner.ItemPadding;
          int vertical5 = itemPadding.Vertical;
          y = bottom3 + vertical5 + 1;
          val1_1 = Math.Max(val1_1, right);
          val1_2 = Math.Max(val1_2, bottom2);
        }
      }
      int num3 = val1_1;
      Padding padding2 = this.Owner.ItemPadding;
      int right1 = padding2.Right;
      int num4 = num3 + right1;
      padding2 = this.Owner.PanelMargin;
      int right2 = padding2.Right;
      return new Size(num4 + right2 + 1, 0);
    }

    internal void SetSizeMode(RibbonElementSizeMode sizeMode)
    {
      this.SizeMode = sizeMode;
      foreach (RibbonItem ribbonItem in (List<RibbonItem>) this.Items)
        ribbonItem.SetSizeMode(sizeMode);
    }

    internal void SetContentBounds(Rectangle contentBounds) => this.ContentBounds = contentBounds;

    internal void SetOwnerTab(RibbonTab ownerTab)
    {
      this.OwnerTab = ownerTab;
      this.Items.SetOwnerTab(this.OwnerTab);
    }

    internal void UpdateItemsRegions(Graphics g, RibbonElementSizeMode mode)
    {
      switch (this.FlowsTo)
      {
        case RibbonPanelFlowDirection.Bottom:
          this.UpdateRegionsFlowsToBottom(g, mode);
          break;
        case RibbonPanelFlowDirection.Right:
          this.UpdateRegionsFlowsToRight(g, mode);
          break;
        case RibbonPanelFlowDirection.Left:
          this.UpdateRegionsFlowsToLeft(g, mode);
          break;
      }
      this.CenterItems();
    }

    private void UpdateRegionsFlowsToBottom(Graphics g, RibbonElementSizeMode mode)
    {
      int x = this.ContentBounds.Left + this.Owner.ItemPadding.Horizontal;
      int y = this.ContentBounds.Top + this.Owner.ItemPadding.Vertical;
      int val2 = x;
      List<RibbonItem> ribbonItemList = new List<RibbonItem>();
      foreach (RibbonItem ribbonItem in (List<RibbonItem>) this.Items)
      {
        Size size = ribbonItem.Visible || this.Owner.IsDesignMode() ? ribbonItem.LastMeasuredSize : new Size(0, 0);
        int num = y + size.Height;
        Rectangle rectangle = this.ContentBounds;
        int bottom1 = rectangle.Bottom;
        if (num > bottom1)
        {
          rectangle = this.ContentBounds;
          y = rectangle.Top + this.Owner.ItemPadding.Vertical;
          x = val2 + this.Owner.ItemPadding.Horizontal;
          this.Items.CenterItemsVerticallyInto((IEnumerable<RibbonItem>) ribbonItemList, this.ContentBounds);
          ribbonItemList.Clear();
        }
        ribbonItem.SetBounds(new Rectangle(x, y, size.Width, size.Height));
        rectangle = ribbonItem.Bounds;
        val2 = Math.Max(rectangle.Right, val2);
        rectangle = ribbonItem.Bounds;
        int bottom2 = rectangle.Bottom;
        rectangle = ribbonItem.Bounds;
        y = rectangle.Bottom + this.Owner.ItemPadding.Vertical + 1;
        ribbonItemList.Add(ribbonItem);
      }
      this.Items.CenterItemsVerticallyInto((IEnumerable<RibbonItem>) ribbonItemList, this.ContentBounds);
    }

    private void UpdateRegionsFlowsToLeft(Graphics g, RibbonElementSizeMode mode)
    {
      int x = this.ContentBounds.Left + this.Owner.ItemPadding.Horizontal;
      int y = this.ContentBounds.Top + this.Owner.ItemPadding.Vertical;
      int val2 = x;
      List<RibbonItem> ribbonItemList = new List<RibbonItem>();
      for (int index = this.Items.Count - 1; index >= 0; --index)
      {
        RibbonItem ribbonItem = this.Items[index];
        Size size = !ribbonItem.Visible ? new Size(0, 0) : ribbonItem.LastMeasuredSize;
        int num = y + size.Height;
        Rectangle rectangle = this.ContentBounds;
        int bottom1 = rectangle.Bottom;
        if (num > bottom1)
        {
          rectangle = this.ContentBounds;
          y = rectangle.Top + this.Owner.ItemPadding.Vertical;
          x = val2 + this.Owner.ItemPadding.Horizontal;
          this.Items.CenterItemsVerticallyInto((IEnumerable<RibbonItem>) ribbonItemList, this.ContentBounds);
          ribbonItemList.Clear();
        }
        ribbonItem.SetBounds(new Rectangle(x, y, size.Width, size.Height));
        rectangle = ribbonItem.Bounds;
        val2 = Math.Max(rectangle.Right, val2);
        rectangle = ribbonItem.Bounds;
        int bottom2 = rectangle.Bottom;
        rectangle = ribbonItem.Bounds;
        y = rectangle.Bottom + this.Owner.ItemPadding.Vertical + 1;
        ribbonItemList.Add(ribbonItem);
      }
      this.Items.CenterItemsVerticallyInto((IEnumerable<RibbonItem>) ribbonItemList, this.Items.GetItemsBounds());
    }

    private void UpdateRegionsFlowsToRight(Graphics g, RibbonElementSizeMode mode)
    {
      int x = this.ContentBounds.Left;
      int y = this.ContentBounds.Top;
      int num1 = mode == RibbonElementSizeMode.Medium ? 7 : 0;
      int num2 = 0;
      RibbonItem[] array = this.Items.ToArray();
      Size lastMeasuredSize;
      for (int index1 = array.Length - 1; index1 >= 0; --index1)
      {
        for (int index2 = 1; index2 <= index1; ++index2)
        {
          lastMeasuredSize = array[index2 - 1].LastMeasuredSize;
          int width1 = lastMeasuredSize.Width;
          lastMeasuredSize = array[index2].LastMeasuredSize;
          int width2 = lastMeasuredSize.Width;
          if (width1 < width2)
          {
            RibbonItem ribbonItem = array[index2 - 1];
            array[index2 - 1] = array[index2];
            array[index2] = ribbonItem;
          }
        }
      }
      List<RibbonItem> ribbonItemList = new List<RibbonItem>((IEnumerable<RibbonItem>) array);
      while (ribbonItemList.Count > 0)
      {
        RibbonItem ribbonItem = ribbonItemList[0];
        ribbonItemList.Remove(ribbonItem);
        int num3 = x;
        lastMeasuredSize = ribbonItem.LastMeasuredSize;
        int width3 = lastMeasuredSize.Width;
        int num4 = num3 + width3;
        Rectangle rectangle = this.ContentBounds;
        int right = rectangle.Right;
        Padding itemPadding;
        if (num4 > right)
        {
          rectangle = this.ContentBounds;
          x = rectangle.Left;
          int num5 = num2;
          itemPadding = this.Owner.ItemPadding;
          int vertical = itemPadding.Vertical;
          y = num5 + vertical + 1 + num1;
        }
        ribbonItem.SetBounds(new Rectangle(new Point(x, y), ribbonItem.LastMeasuredSize));
        int num6 = x;
        rectangle = ribbonItem.Bounds;
        int width4 = rectangle.Width;
        itemPadding = this.Owner.ItemPadding;
        int horizontal1 = itemPadding.Horizontal;
        int num7 = width4 + horizontal1;
        x = num6 + num7;
        int val1_1 = num2;
        rectangle = ribbonItem.Bounds;
        int bottom1 = rectangle.Bottom;
        num2 = Math.Max(val1_1, bottom1);
        rectangle = this.ContentBounds;
        int num8 = rectangle.Right - x;
        for (int index = 0; index < ribbonItemList.Count; ++index)
        {
          lastMeasuredSize = ribbonItemList[index].LastMeasuredSize;
          if (lastMeasuredSize.Width < num8)
          {
            ribbonItemList[index].SetBounds(new Rectangle(new Point(x, y), ribbonItemList[index].LastMeasuredSize));
            int num9 = x;
            rectangle = ribbonItemList[index].Bounds;
            int width5 = rectangle.Width;
            itemPadding = this.Owner.ItemPadding;
            int horizontal2 = itemPadding.Horizontal;
            int num10 = width5 + horizontal2;
            x = num9 + num10;
            int val1_2 = num2;
            rectangle = ribbonItemList[index].Bounds;
            int bottom2 = rectangle.Bottom;
            num2 = Math.Max(val1_2, bottom2);
            rectangle = this.ContentBounds;
            num8 = rectangle.Right - x;
            ribbonItemList.RemoveAt(index);
            index = 0;
          }
        }
      }
    }

    private void CenterItems() => this.Items.CenterItemsInto(this.ContentBounds);

    public override string ToString() => string.Format("Panel: {0} ({1})", (object) this.Text, (object) this.SizeMode);

    public void SetPressed(bool pressed) => this.Pressed = pressed;

    internal void SetMorePressed(bool pressed) => this.ButtonMorePressed = pressed;

    internal void SetMoreSelected(bool selected) => this.ButtonMoreSelected = selected;

    internal void SetMoreBounds(Rectangle bounds) => this.ButtonMoreBounds = bounds;

    protected void OnButtonMoreClick(EventArgs e)
    {
      if (this.ButtonMoreClick == null)
        return;
      this.ButtonMoreClick((object) this, e);
    }

    public IEnumerable<RibbonItem> GetItems() => (IEnumerable<RibbonItem>) this.Items;

    public Rectangle GetContentBounds() => this.ContentBounds;

    public virtual void OnMouseEnter(MouseEventArgs e)
    {
      if (!this.Enabled || this.MouseEnter == null)
        return;
      this.MouseEnter((object) this, e);
    }

    public virtual void OnMouseLeave(MouseEventArgs e)
    {
      if (!this.Enabled || this.MouseLeave == null)
        return;
      this.MouseLeave((object) this, e);
    }

    public virtual void OnMouseMove(MouseEventArgs e)
    {
      if (!this.Enabled)
        return;
      if (this.MouseMove != null)
        this.MouseMove((object) this, e);
      bool flag;
      if (this.ButtonMoreEnabled && this.ButtonMoreVisible && this.ButtonMoreBounds.Contains(e.X, e.Y) && !this.Collapsed)
      {
        this.SetMoreSelected(true);
        flag = true;
      }
      else
      {
        flag = this.ButtonMoreSelected;
        this.SetMoreSelected(false);
      }
      if (!flag)
        return;
      this.Owner.Invalidate(this.Bounds);
    }

    public virtual void OnClick(EventArgs e)
    {
      if (!this.Enabled)
        return;
      if (this.Click != null)
        this.Click((object) this, e);
      if (!this.Collapsed || this.PopUp != null)
        return;
      this.ShowOverflowPopup();
    }

    public virtual void OnDoubleClick(EventArgs e)
    {
      if (!this.Enabled || this.DoubleClick == null)
        return;
      this.DoubleClick((object) this, e);
    }

    public virtual void OnMouseDown(MouseEventArgs e)
    {
      if (!this.Enabled)
        return;
      if (this.MouseDown != null)
        this.MouseDown((object) this, e);
      this.SetPressed(true);
      bool flag;
      if (this.ButtonMoreEnabled && this.ButtonMoreVisible && this.ButtonMoreBounds.Contains(e.X, e.Y) && !this.Collapsed)
      {
        this.SetMorePressed(true);
        flag = true;
      }
      else
      {
        flag = this.ButtonMoreSelected;
        this.SetMorePressed(false);
      }
      if (!flag)
        return;
      this.Owner.Invalidate(this.Bounds);
    }

    public virtual void OnMouseUp(MouseEventArgs e)
    {
      if (!this.Enabled)
        return;
      if (this.MouseUp != null)
        this.MouseUp((object) this, e);
      if (this.ButtonMoreEnabled && this.ButtonMoreVisible && this.ButtonMorePressed && !this.Collapsed)
        this.OnButtonMoreClick(EventArgs.Empty);
      this.SetPressed(false);
      this.SetMorePressed(false);
    }

    public IEnumerable<Component> GetAllChildComponents() => (IEnumerable<Component>) this.Items.ToArray();
  }
}
