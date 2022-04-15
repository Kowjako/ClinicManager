// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonItem
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;

namespace System.Windows.Forms
{
  [DesignTimeVisible(false)]
  public abstract class RibbonItem : Component, IRibbonElement, IRibbonToolTip
  {
    private bool? _isopeninvisualstudiodesigner;
    private string _text;
    private Image _image;
    private bool _checked;
    private bool _selected;
    private bool _pressed;
    private bool _enabled;
    private object _tag;
    private string _value;
    private string _altKey;
    private RibbonElementSizeMode _maxSize;
    private RibbonElementSizeMode _minSize;
    private Control _canvas;
    private bool _visible;
    private RibbonItem.RibbonItemTextAlignment _textAlignment;
    private bool _flashEnabled;
    private int _flashIntervall = 1000;
    private Image _flashImage;
    private readonly Timer _flashTimer = new Timer();
    protected bool _showFlashImage;
    private readonly RibbonToolTip _TT;
    private static RibbonToolTip _lastActiveToolTip;
    private string _tooltip;
    private string _checkedGroup;
    private string _name = string.Empty;

    public virtual event EventHandler DoubleClick;

    public virtual event EventHandler Click;

    public virtual event MouseEventHandler MouseUp;

    public virtual event MouseEventHandler MouseMove;

    public virtual event MouseEventHandler MouseDown;

    public virtual event MouseEventHandler MouseEnter;

    public virtual event MouseEventHandler MouseLeave;

    public virtual event EventHandler CanvasChanged;

    public virtual event EventHandler OwnerChanged;

    public virtual event RibbonElementPopupEventHandler ToolTipPopUp;

    public RibbonItem()
    {
      this._enabled = true;
      this._visible = true;
      this.Click += new EventHandler(this.RibbonItem_Click);
      this._flashTimer.Tick += new EventHandler(this._flashTimer_Tick);
      RibbonToolTip ribbonToolTip = new RibbonToolTip((IRibbonElement) this);
      ribbonToolTip.InitialDelay = 100;
      ribbonToolTip.AutomaticDelay = 800;
      ribbonToolTip.AutoPopDelay = 8000;
      ribbonToolTip.UseAnimation = true;
      ribbonToolTip.Active = false;
      this._TT = ribbonToolTip;
      this._TT.Popup += new PopupEventHandler(this._TT_Popup);
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
        this._flashTimer.Enabled = false;
        this._TT.Popup -= new PopupEventHandler(this._TT_Popup);
        this._TT.Dispose();
      }
      base.Dispose(disposing);
    }

    private void RibbonItem_Click(object sender, EventArgs e)
    {
      if (!(this.Canvas is RibbonDropDown canvas) || canvas.SelectionService == null)
        return;
      canvas.SelectionService.SetSelectedComponents((ICollection) new Component[1]
      {
        (Component) this
      }, SelectionTypes.Click);
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual string Name
    {
      get
      {
        if (this.Site != null)
          this._name = this.Site.Name;
        return this._name;
      }
      set
      {
        if (!(this._name != value))
          return;
        this._name = value;
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual Rectangle ContentBounds
    {
      get
      {
        if (this.Owner == null)
          return Rectangle.Empty;
        int left1 = this.Bounds.Left;
        Padding itemMargin = this.Owner.ItemMargin;
        int left2 = itemMargin.Left;
        int left3 = left1 + left2;
        int top1 = this.Bounds.Top;
        itemMargin = this.Owner.ItemMargin;
        int top2 = itemMargin.Top;
        int top3 = top1 + top2;
        int right1 = this.Bounds.Right;
        itemMargin = this.Owner.ItemMargin;
        int right2 = itemMargin.Right;
        int right3 = right1 - right2;
        int bottom1 = this.Bounds.Bottom;
        itemMargin = this.Owner.ItemMargin;
        int bottom2 = itemMargin.Bottom;
        int bottom3 = bottom1 - bottom2;
        return Rectangle.FromLTRB(left3, top3, right3, bottom3);
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Control Canvas => this._canvas != null && !this._canvas.IsDisposed ? this._canvas : (Control) this.Owner;

    [DefaultValue(false)]
    [Category("Flash")]
    public bool FlashEnabled
    {
      get => this._flashEnabled;
      set
      {
        if (this._flashEnabled == value)
          return;
        this._flashEnabled = value;
        if (this._flashEnabled)
        {
          this._showFlashImage = false;
          this._flashTimer.Interval = this._flashIntervall;
          this._flashTimer.Enabled = true;
        }
        else
        {
          this._flashTimer.Enabled = false;
          this._showFlashImage = false;
          this.NotifyOwnerRegionsChanged();
        }
      }
    }

    [DefaultValue(1000)]
    [Category("Flash")]
    public int FlashIntervall
    {
      get => this._flashIntervall;
      set
      {
        if (this._flashIntervall == value)
          return;
        this._flashIntervall = value;
      }
    }

    [DefaultValue(null)]
    [Category("Flash")]
    public Image FlashImage
    {
      get => this._flashImage;
      set
      {
        if (this._flashImage == value)
          return;
        this._flashImage = value;
      }
    }

    [DefaultValue(false)]
    [Browsable(false)]
    public bool ShowFlashImage
    {
      get => this._showFlashImage;
      set
      {
        if (this._showFlashImage == value)
          return;
        this._showFlashImage = value;
      }
    }

    [DefaultValue(null)]
    [Category("Appearance")]
    [Localizable(true)]
    public virtual string Text
    {
      get => this._text;
      set
      {
        if (!(this._text != value))
          return;
        this._text = value;
        this.NotifyOwnerRegionsChanged();
      }
    }

    [DefaultValue(null)]
    [Category("Appearance")]
    public virtual Image Image
    {
      get => this._image;
      set
      {
        this._image = value;
        this.NotifyOwnerRegionsChanged();
      }
    }

    [DefaultValue(true)]
    [Category("Behavior")]
    public virtual bool Visible
    {
      get => (!this._visible || this.Owner == null || this.Owner.IsDesignMode() || (this.OwnerItem == null || this.OwnerItem.Visible) && (this.OwnerPanel == null || this.OwnerPanel.Visible)) && this._visible;
      set
      {
        if (this._visible == value)
          return;
        this._visible = value;
        this.NotifyOwnerRegionsChanged();
      }
    }

    [DefaultValue(false)]
    [Category("Appearance")]
    [Description("Indicates whether the component is in the checked state.")]
    public virtual bool Checked
    {
      get => this._checked;
      set
      {
        if (this._checked == value)
          return;
        this._checked = value;
        if (value)
        {
          if (this.Canvas is RibbonDropDown)
          {
            foreach (RibbonItem ribbonItem in ((RibbonDropDown) this.Canvas).Items)
            {
              if (ribbonItem.CheckedGroup == this._checkedGroup && ribbonItem.Checked && ribbonItem != this)
              {
                ribbonItem.Checked = false;
                ribbonItem.RedrawItem();
              }
            }
          }
          else if (this.OwnerPanel != null && this._checkedGroup != null)
          {
            foreach (RibbonItem ribbonItem in (List<RibbonItem>) this.OwnerPanel.Items)
            {
              if (ribbonItem.CheckedGroup == this._checkedGroup && ribbonItem.Checked && ribbonItem != this)
              {
                ribbonItem.Checked = false;
                ribbonItem.RedrawItem();
              }
            }
          }
        }
        this.NotifyOwnerRegionsChanged();
      }
    }

    [DefaultValue(null)]
    [Category("Behavior")]
    [Description("Determins the other Ribbon Items that belong to this checked group.  When one button is checked the other items in this group will be unchecked automatically.  This only applies to Items that are within the same Parent")]
    public virtual string CheckedGroup
    {
      get => this._checkedGroup;
      set
      {
        if (!(this._checkedGroup != value))
          return;
        this._checkedGroup = value;
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RibbonElementSizeMode SizeMode { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual bool Selected => this._selected;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual bool Pressed => this._pressed;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Ribbon Owner { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle Bounds { get; private set; }

    [DefaultValue(true)]
    [Category("Behavior")]
    public virtual bool Enabled
    {
      get
      {
        if (this.Owner == null)
          return this._enabled;
        return this._enabled && this.Owner.Enabled;
      }
      set
      {
        if (this._enabled == value)
          return;
        this._enabled = value;
        if (this is IContainsSelectableRibbonItems selectableRibbonItems)
        {
          foreach (RibbonItem ribbonItem in selectableRibbonItems.GetItems())
            ribbonItem.Enabled = value;
        }
        this.NotifyOwnerRegionsChanged();
      }
    }

    [DefaultValue("")]
    public string ToolTipTitle
    {
      get => this._TT.ToolTipTitle;
      set
      {
        if (!(this._TT.ToolTipTitle != value))
          return;
        this._TT.ToolTipTitle = value;
      }
    }

    [DefaultValue(ToolTipIcon.None)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolTipIcon ToolTipIcon
    {
      get => this._TT.ToolTipIcon;
      set
      {
        if (this._TT.ToolTipIcon == value)
          return;
        this._TT.ToolTipIcon = value;
      }
    }

    [DefaultValue(null)]
    [Localizable(true)]
    public string ToolTip
    {
      get => this._tooltip;
      set
      {
        if (!(this._tooltip != value))
          return;
        this._tooltip = value;
      }
    }

    [DefaultValue(null)]
    [Localizable(true)]
    public Image ToolTipImage
    {
      get => this._TT.ToolTipImage;
      set
      {
        if (this._TT.ToolTipImage == value)
          return;
        this._TT.ToolTipImage = value;
      }
    }

    [Description("An Object field for associating custom data for this control")]
    [DefaultValue(null)]
    [Category("Data")]
    [TypeConverter(typeof (StringConverter))]
    public object Tag
    {
      get => this._tag;
      set
      {
        if (this._tag == value)
          return;
        this._tag = value;
      }
    }

    [DefaultValue(null)]
    [Category("Data")]
    [Description("A string field for associating custom data for this control")]
    public string Value
    {
      get => this._value;
      set
      {
        if (!(this._value != value))
          return;
        this._value = value;
      }
    }

    [DefaultValue(null)]
    [Category("Behavior")]
    public string AltKey
    {
      get => this._altKey;
      set
      {
        if (!(this._altKey != value))
          return;
        this._altKey = value;
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RibbonTab OwnerTab { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RibbonPanel OwnerPanel { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RibbonItem OwnerItem { get; private set; }

    [DefaultValue(RibbonElementSizeMode.None)]
    [Category("Appearance")]
    [Description("Sets the maximum size mode of the element.")]
    public RibbonElementSizeMode MaxSizeMode
    {
      get => this._maxSize;
      set
      {
        if (this._maxSize == value)
          return;
        this._maxSize = value;
        this.NotifyOwnerRegionsChanged();
      }
    }

    [DefaultValue(RibbonElementSizeMode.None)]
    [Category("Appearance")]
    [Description("Sets the minimum size mode of the element.")]
    public RibbonElementSizeMode MinSizeMode
    {
      get => this._minSize;
      set
      {
        if (this._minSize == value)
          return;
        this._minSize = value;
        this.NotifyOwnerRegionsChanged();
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Size LastMeasuredSize { get; private set; }

    [DefaultValue(RibbonItem.RibbonItemTextAlignment.Left)]
    [Category("Appearance")]
    public RibbonItem.RibbonItemTextAlignment TextAlignment
    {
      get => this._textAlignment;
      set
      {
        if (this._textAlignment == value)
          return;
        this._textAlignment = value;
        this.NotifyOwnerRegionsChanged();
      }
    }

    private void _flashTimer_Tick(object sender, EventArgs e)
    {
      this._showFlashImage = !this._showFlashImage;
      this.NotifyOwnerRegionsChanged();
    }

    protected virtual bool ClosesDropDownAt(Point p) => true;

    protected void NotifyOwnerRegionsChanged()
    {
      if (this.Owner == null)
        return;
      if (this.Owner == this.Canvas)
      {
        this.Owner.OnRegionsChanged();
      }
      else
      {
        if (this.Canvas == null)
          return;
        if (this.Canvas is RibbonOrbDropDown)
          (this.Canvas as RibbonOrbDropDown).OnRegionsChanged();
        else
          this.Canvas.Invalidate(this.Bounds);
      }
    }

    internal virtual void SetOwnerItem(RibbonItem item) => this.OwnerItem = item;

    internal virtual void SetOwner(Ribbon owner)
    {
      this.Owner = owner;
      this.OnOwnerChanged(EventArgs.Empty);
    }

    internal virtual void SetOwnerPanel(RibbonPanel ownerPanel) => this.OwnerPanel = ownerPanel;

    internal virtual void SetSelected(bool selected)
    {
      if (!this.Enabled)
        return;
      this._selected = selected;
    }

    internal virtual void SetPressed(bool pressed) => this._pressed = pressed;

    internal virtual void SetOwnerTab(RibbonTab ownerTab) => this.OwnerTab = ownerTab;

    internal virtual void ClearOwner()
    {
      this.OwnerItem = (RibbonItem) null;
      this.OwnerPanel = (RibbonPanel) null;
      this.OwnerTab = (RibbonTab) null;
      this.Owner = (Ribbon) null;
      this.OnOwnerChanged(EventArgs.Empty);
    }

    protected RibbonElementSizeMode GetNearestSize(
      RibbonElementSizeMode sizeMode)
    {
      int num1 = (int) sizeMode;
      int maxSizeMode = (int) this.MaxSizeMode;
      int minSizeMode = (int) this.MinSizeMode;
      int num2 = (int) sizeMode;
      if (maxSizeMode > 0 && num1 > maxSizeMode)
        num2 = maxSizeMode;
      if (minSizeMode > 0 && num1 < minSizeMode)
        num2 = minSizeMode;
      return (RibbonElementSizeMode) num2;
    }

    protected void SetLastMeasuredSize(Size size) => this.LastMeasuredSize = size;

    internal virtual void SetSizeMode(RibbonElementSizeMode sizeMode) => this.SizeMode = this.GetNearestSize(sizeMode);

    public virtual void OnCanvasChanged(EventArgs e)
    {
      if (this.CanvasChanged == null)
        return;
      this.CanvasChanged((object) this, e);
    }

    public virtual void OnOwnerChanged(EventArgs e)
    {
      if (this.OwnerChanged == null)
        return;
      this.OwnerChanged((object) this, e);
    }

    public virtual void OnMouseEnter(MouseEventArgs e)
    {
      if (!this.Enabled || this.MouseEnter == null)
        return;
      this.MouseEnter((object) this, e);
    }

    public virtual void OnMouseDown(MouseEventArgs e)
    {
      if (!this.Enabled)
        return;
      if (this.MouseDown != null)
        this.MouseDown((object) this, e);
      this.SetPressed(true);
    }

    public virtual void OnMouseLeave(MouseEventArgs e)
    {
      if (!this.Enabled)
        return;
      this.DeactivateToolTip(this._TT);
      if (this.MouseLeave == null)
        return;
      this.MouseLeave((object) this, e);
    }

    public virtual void OnMouseUp(MouseEventArgs e)
    {
      if (!this.Enabled)
        return;
      if (this.MouseUp != null)
        this.MouseUp((object) this, e);
      if (!this.Pressed)
        return;
      this.SetPressed(false);
      this.RedrawItem();
    }

    public virtual void OnMouseMove(MouseEventArgs e)
    {
      if (!this.Enabled)
        return;
      if (this.MouseMove != null)
        this.MouseMove((object) this, e);
      if (!this.Selected)
      {
        this.SetSelected(true);
        this.Owner.Invalidate(this.Bounds);
      }
      if (this._TT.Active || string.IsNullOrEmpty(this.ToolTip))
        return;
      this.DeactivateToolTip(RibbonItem._lastActiveToolTip);
      if (this.ToolTip != this._TT.GetToolTip(this.Canvas))
        this._TT.SetToolTip(this.Canvas, this.ToolTip);
      this._TT.Active = true;
      RibbonItem._lastActiveToolTip = (RibbonToolTip) null;
      RibbonItem._lastActiveToolTip = this._TT;
    }

    public virtual void OnClick(EventArgs e)
    {
      if (!this.Enabled)
        return;
      if (this.ClosesDropDownAt(this.Canvas.PointToClient(Cursor.Position)))
      {
        this.DeactivateToolTip(this._TT);
        RibbonPopupManager.Dismiss(RibbonPopupManager.DismissReason.ItemClicked);
      }
      this.SetSelected(false);
      if (this.Click == null)
        return;
      this.Click((object) this, e);
    }

    public virtual void OnDoubleClick(EventArgs e)
    {
      if (!this.Enabled || this.DoubleClick == null)
        return;
      this.DoubleClick((object) this, e);
    }

    public virtual void RedrawItem()
    {
      if (this.Canvas == null)
        return;
      this.Canvas.Invalidate(Rectangle.Inflate(this.Bounds, 1, 1));
    }

    internal void SetCanvas(Control canvas)
    {
      this._canvas = canvas;
      this.SetCanvas(this as IContainsSelectableRibbonItems, canvas);
      this.OnCanvasChanged(EventArgs.Empty);
    }

    private void SetCanvas(IContainsSelectableRibbonItems parent, Control canvas)
    {
      if (parent == null)
        return;
      foreach (RibbonItem ribbonItem in parent.GetItems())
        ribbonItem.SetCanvas(canvas);
    }

    private void _TT_Popup(object sender, PopupEventArgs e)
    {
      if (this.ToolTipPopUp == null)
        return;
      this.ToolTipPopUp(sender, new RibbonElementPopupEventArgs((IRibbonElement) this, e));
      if (!(this.ToolTip != this._TT.GetToolTip(this.Canvas)))
        return;
      this._TT.SetToolTip(this.Canvas, this.ToolTip);
    }

    private void DeactivateToolTip(RibbonToolTip toolTip)
    {
      if (toolTip == null)
        return;
      toolTip.Active = false;
      toolTip.RemoveAll();
    }

    public abstract void OnPaint(object sender, RibbonElementPaintEventArgs e);

    public virtual void SetBounds(Rectangle bounds) => this.Bounds = bounds;

    public abstract Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e);

    public enum RibbonItemTextAlignment
    {
      Left,
      Center,
      Right,
    }
  }
}
