// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.Ribbon
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Security.Permissions;
using System.Windows.Forms.RibbonHelpers;

namespace System.Windows.Forms
{
  [Designer(typeof (RibbonDesigner))]
  public class Ribbon : Control, IMessageFilter
  {
    public const string Version = "5.0";
    private const int DefaultTabSpacing = 6;
    private const int DefaultPanelSpacing = 3;
    public static int CaptionBarHeight = 24;
    private int _contextspace;
    private bool? _isopeninvisualstudiodesigner;
    internal bool ForceOrbMenu;
    private Size _lastSizeMeasured;
    private Padding _tabsMargin;
    internal bool _minimized = true;
    internal bool _expanded;
    internal bool _expanding;
    private int _expandedHeight;
    private RibbonRenderer _renderer;
    private bool _useAlwaysStandardTheme;
    private Theme _theme;
    private Padding _panelMargin;
    private RibbonTab _activeTab;
    private RibbonTab _lastSelectedTab;
    private bool _updatingSuspended;
    private bool _orbSelected;
    private bool _orbPressed;
    private bool _orbVisible;
    private Image _orbImage;
    private string _orbText;
    private Size _orbTextSize = Size.Empty;
    private RibbonWindowMode _borderMode;
    private GlobalHook _mouseHook;
    private GlobalHook _keyboardHook;
    private Font _RibbonItemFont = new Font("Trebuchet MS", 9f);
    private Font _RibbonTabFont = new Font("Trebuchet MS", 9f);
    private bool _CaptionBarVisible;
    private bool _enabled;
    internal RibbonItem ActiveTextBox;
    internal bool AltPressed;

    public event EventHandler OrbClicked;

    public event EventHandler OrbDoubleClick;

    public event EventHandler ActiveTabChanged;

    public event EventHandler ActualBorderModeChanged;

    public event EventHandler CaptionButtonsVisibleChanged;

    public event EventHandler ExpandedChanged;

    public Ribbon()
    {
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.SetStyle(ControlStyles.Selectable, false);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      this.Dock = DockStyle.Top;
      this.Tabs = new RibbonTabCollection(this);
      this.Contexts = new RibbonContextCollection(this);
      this.OrbsPadding = new Padding(8, 5, 8, 3);
      this.TabsPadding = new Padding(8, 5, 8, 3);
      this._tabsMargin = new Padding(12, 26, 20, 0);
      this.TabTextMargin = new Padding(4, 2, 4, 2);
      this.TabContentMargin = new Padding(1, 0, 1, 2);
      this.PanelPadding = new Padding(3);
      this._panelMargin = new Padding(3, 2, 3, 15);
      this.PanelMoreMargin = new Padding(0, 0, 1, 1);
      this.PanelSpacing = 3;
      this.ItemPadding = new Padding(1, 0, 1, 0);
      this.ItemMargin = new Padding(4, 2, 4, 2);
      this.ItemImageToTextSpacing = 3;
      this.TabSpacing = 6;
      this.DropDownMargin = new Padding(2);
      this._renderer = (RibbonRenderer) new RibbonProfessionalRenderer(this);
      this._orbVisible = true;
      this.OrbDropDown = new RibbonOrbDropDown(this);
      this.QuickAccessToolbar = new RibbonQuickAccessToolbar(this);
      this.MinimizeButton = new RibbonCaptionButton(RibbonCaptionButton.CaptionButton.Minimize);
      this.MaximizeRestoreButton = new RibbonCaptionButton(RibbonCaptionButton.CaptionButton.Maximize);
      this.CloseButton = new RibbonCaptionButton(RibbonCaptionButton.CaptionButton.Close);
      this.LayoutHelper = new LayoutHelper(this);
      this.MinimizeButton.SetOwner(this);
      this.MaximizeRestoreButton.SetOwner(this);
      this.CloseButton.SetOwner(this);
      this._CaptionBarVisible = true;
      this.Font = SystemFonts.CaptionFont;
      this.BorderMode = RibbonWindowMode.NonClientAreaGlass;
      this._minimized = false;
      this._expanded = true;
      this._enabled = true;
      RibbonPopupManager.PopupRegistered += new EventHandler(this.OnPopupRegistered);
      RibbonPopupManager.PopupUnRegistered += new EventHandler(this.OnPopupUnregistered);
      Control parent = (Control) null;
      this.ParentChanged += (EventHandler) ((o1, e1) =>
      {
        if (parent != null)
        {
          parent.KeyUp -= new KeyEventHandler(this.Ribbon_KeyUp);
          parent.KeyDown -= new KeyEventHandler(this.parent_KeyDown);
        }
        parent = this.Parent;
        Application.AddMessageFilter((IMessageFilter) this);
        if (parent is Form)
        {
          Form form = parent as Form;
          form.KeyPreview = true;
          form.FormClosing += (FormClosingEventHandler) ((o, e) => Application.RemoveMessageFilter((IMessageFilter) this));
        }
        if (parent == null)
          return;
        parent.KeyDown += new KeyEventHandler(this.parent_KeyDown);
        parent.KeyUp += new KeyEventHandler(this.Ribbon_KeyUp);
      });
    }

    public bool PreFilterMessage(ref Message m)
    {
      if (m.Msg == 261)
      {
        this.AltPressed = false;
        this.Invalidate();
      }
      return false;
    }

    private void parent_KeyDown(object sender, KeyEventArgs e)
    {
      this.AltPressed = e.Alt;
      this.Invalidate();
    }

    private bool IsTargetedAltKey(string key, string altKey) => !string.IsNullOrEmpty(key) && string.Equals(key, altKey, StringComparison.InvariantCultureIgnoreCase);

    private void ParseItem(RibbonItem item)
    {
      switch (item)
      {
        case RibbonButton _:
          (item as RibbonButton).PerformClick();
          break;
        case RibbonCheckBox _:
          (item as RibbonCheckBox).Checked = !(item as RibbonCheckBox).Checked;
          break;
        case RibbonTextBox _:
          (item as RibbonTextBox).SetSelected(true);
          break;
      }
    }

    public void Ribbon_KeyUp(object sender, KeyEventArgs e)
    {
      string altKey = new KeysConverter().ConvertToString((object) e.KeyValue);
      if (!e.Alt || e.KeyValue <= 0)
        return;
      Ribbon ribbon = this;
      if (ribbon.OrbPressed)
      {
        foreach (RibbonItem menuItem in (List<RibbonItem>) ribbon.OrbDropDown.MenuItems)
        {
          if (this.IsTargetedAltKey(menuItem.AltKey, altKey))
          {
            this.ParseItem(menuItem);
            return;
          }
        }
      }
      if (ribbon.ActiveTab != null)
      {
        foreach (RibbonPanel panel in (List<RibbonPanel>) ribbon.ActiveTab.Panels)
        {
          foreach (RibbonItem ribbonItem in panel.GetItems())
          {
            if (this.IsTargetedAltKey(ribbonItem.AltKey, altKey))
            {
              this.ParseItem(ribbonItem);
              return;
            }
          }
        }
      }
      if (this.IsTargetedAltKey(ribbon.AltKey, altKey))
      {
        ribbon.ShowOrbDropDown();
      }
      else
      {
        foreach (RibbonTab tab in (List<RibbonTab>) ribbon.Tabs)
        {
          if (this.IsTargetedAltKey(tab.AltKey, altKey))
          {
            ribbon.ActiveTab = tab;
            break;
          }
        }
      }
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
            foreach (Component tab in (List<RibbonTab>) this.Tabs)
              tab.Dispose();
          }
          catch (InvalidOperationException ex)
          {
            if (!this.IsOpenInVisualStudioDesigner())
              throw;
          }
          this.OrbDropDown.Dispose();
          this.QuickAccessToolbar.Dispose();
          this.MinimizeButton.Dispose();
          this.MaximizeRestoreButton.Dispose();
          if (this._RibbonItemFont != null)
            this._RibbonItemFont.Dispose();
          if (this._RibbonTabFont != null)
            this._RibbonTabFont.Dispose();
          this.CloseButton.Dispose();
          RibbonPopupManager.PopupRegistered -= new EventHandler(this.OnPopupRegistered);
          RibbonPopupManager.PopupUnRegistered -= new EventHandler(this.OnPopupUnregistered);
        }
      }
      this.DisposeHooks();
      base.Dispose(disposing);
    }

    private void DisposeHooks()
    {
      if (this._mouseHook != null)
      {
        this._mouseHook.MouseWheel -= new MouseEventHandler(this._mouseHook_MouseWheel);
        this._mouseHook.MouseDown -= new MouseEventHandler(this._mouseHook_MouseDown);
        this._mouseHook.Dispose();
        this._mouseHook = (GlobalHook) null;
      }
      if (this._keyboardHook == null)
        return;
      this._keyboardHook.KeyDown -= new KeyEventHandler(this._keyboardHook_KeyDown);
      this._keyboardHook.Dispose();
      this._keyboardHook = (GlobalHook) null;
    }

    [RefreshProperties(RefreshProperties.All)]
    [DefaultValue(0)]
    [Category("Behavior")]
    public int ContextSpace
    {
      get => this._contextspace;
      set
      {
        this._contextspace = value;
        this.OrbStyle = this.OrbStyle;
      }
    }

    [DefaultValue(null)]
    [Category("Behavior")]
    public string AltKey { get; set; }

    [DefaultValue(true)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Expanded
    {
      get => this._expanded;
      set
      {
        this._expanded = value;
        if (this.IsDesignMode() || !this.Minimized)
          return;
        this._expanding = true;
        if (this._expanded)
          this.Height = this._expandedHeight;
        else
          this.Height = this.MinimizedHeight;
        this.OnExpandedChanged(EventArgs.Empty);
        if (this._expanded)
          this.SetUpHooks();
        else if (!this._expanded && RibbonPopupManager.PopupCount == 0)
          this.DisposeHooks();
        this.Invalidate();
        this._expanding = false;
      }
    }

    [DefaultValue(true)]
    [Category("Behavior")]
    [Description("Sets if the Ribbon should be enabled")]
    public new bool Enabled
    {
      get => this._enabled;
      set
      {
        this._enabled = value;
        this.Invalidate();
        this.UpdateRegions();
      }
    }

    [Browsable(false)]
    [Description("Gets the height of the ribbon when collapsed")]
    public int MinimizedHeight
    {
      get
      {
        Rectangle rectangle;
        int num;
        if (this.Tabs.Count <= 0)
        {
          num = 0;
        }
        else
        {
          rectangle = this.Tabs[0].Bounds;
          num = rectangle.Bottom;
        }
        int val2 = num;
        rectangle = this.OrbBounds;
        return Math.Max(rectangle.Bottom, val2) + 1;
      }
    }

    public new Size Size
    {
      get => base.Size;
      set
      {
        base.Size = value;
        this.Height = value.Height;
        if (this.Minimized && (this._expanding || !this.Expanded))
          return;
        this._expandedHeight = this.Height;
      }
    }

    internal Rectangle CaptionTextBounds
    {
      get
      {
        if (this.RightToLeft == RightToLeft.No)
        {
          int left1 = 0;
          int right1 = this.Width - 100;
          int right2 = right1;
          int left2 = left1;
          if (this.OrbVisible)
            left1 = this.OrbBounds.Right;
          Rectangle bounds;
          if (this.QuickAccessToolbar.Visible)
          {
            bounds = this.QuickAccessToolbar.Bounds;
            left1 = bounds.Right + 20;
          }
          if (this.QuickAccessToolbar.Visible && this.QuickAccessToolbar.DropDownButtonVisible)
          {
            bounds = this.QuickAccessToolbar.DropDownButton.Bounds;
            left1 = bounds.Right;
          }
          foreach (RibbonContext context in (List<RibbonContext>) this.Contexts)
          {
            if (context.Visible)
            {
              int val1_1 = right2;
              bounds = context.Bounds;
              int left3 = bounds.Left;
              right2 = Math.Min(val1_1, left3);
              int val1_2 = left2;
              bounds = context.Bounds;
              int right3 = bounds.Right;
              left2 = Math.Max(val1_2, right3);
            }
          }
          return right2 - left1 <= right1 - left2 ? Rectangle.FromLTRB(left2, 0, right1, this.CaptionBarSize) : Rectangle.FromLTRB(left1, 0, right2, this.CaptionBarSize);
        }
        int right4 = this.ClientRectangle.Right;
        int left4 = 100;
        int right5 = right4;
        int left5 = left4;
        if (this.OrbVisible)
          right4 = this.OrbBounds.Left;
        Rectangle bounds1;
        if (this.QuickAccessToolbar.Visible)
        {
          bounds1 = this.QuickAccessToolbar.Bounds;
          right4 = bounds1.Left - 20;
        }
        if (this.QuickAccessToolbar.Visible && this.QuickAccessToolbar.DropDownButtonVisible)
        {
          bounds1 = this.QuickAccessToolbar.DropDownButton.Bounds;
          right4 = bounds1.Left;
        }
        foreach (RibbonContext context in (List<RibbonContext>) this.Contexts)
        {
          if (context.Visible)
          {
            int val1_3 = right5;
            bounds1 = context.Bounds;
            int left6 = bounds1.Left;
            right5 = Math.Min(val1_3, left6);
            int val1_4 = left5;
            bounds1 = context.Bounds;
            int right6 = bounds1.Right;
            left5 = Math.Max(val1_4, right6);
          }
        }
        return right5 - left4 <= right4 - left5 ? Rectangle.FromLTRB(left5, 0, right4, this.CaptionBarSize) : Rectangle.FromLTRB(left4, 0, right5, this.CaptionBarSize);
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool CaptionButtonsVisible { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RibbonCaptionButton CloseButton { get; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RibbonCaptionButton MaximizeRestoreButton { get; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RibbonCaptionButton MinimizeButton { get; }

    [Browsable(false)]
    public RibbonFormHelper FormHelper => this.Parent is IRibbonForm parent ? parent.Helper : (RibbonFormHelper) null;

    [Browsable(false)]
    public LayoutHelper LayoutHelper { get; }

    [Browsable(false)]
    public RibbonWindowMode ActualBorderMode { get; private set; }

    [DefaultValue(RibbonWindowMode.NonClientAreaGlass)]
    [Category("Appearance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Description("Specifies how the Ribbon is placed on the window border and the non-client area")]
    public RibbonWindowMode BorderMode
    {
      get => this._borderMode;
      set
      {
        this._borderMode = value;
        RibbonWindowMode borderMode = value;
        if (value == RibbonWindowMode.NonClientAreaGlass && !WinApi.IsGlassEnabled)
          borderMode = RibbonWindowMode.NonClientAreaCustomDrawn;
        if (this.FormHelper == null || value == RibbonWindowMode.NonClientAreaCustomDrawn && Environment.OSVersion.Platform != PlatformID.Win32NT)
          borderMode = RibbonWindowMode.InsideWindow;
        this.SetActualBorderMode(borderMode);
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Category("Orb")]
    [Browsable(true)]
    public RibbonOrbDropDown OrbDropDown { get; }

    [DefaultValue(15)]
    [Category("Appearance")]
    [Description("Gets or sets the height of the Panel Caption area")]
    public int PanelCaptionHeight
    {
      get => this._panelMargin.Bottom;
      set
      {
        this._panelMargin.Bottom = value;
        this.UpdateRegions();
        this.Invalidate();
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public RibbonQuickAccessToolbar QuickAccessToolbar { get; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Theme Theme => this._theme != null ? this._theme : Theme.Standard;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Category("Orb")]
    [DefaultValue(RibbonOrbStyle.Office_2007)]
    public RibbonOrbStyle OrbStyle
    {
      get => this.Theme.Style;
      set
      {
        int num = value != this.Theme.Style ? 1 : 0;
        this.EnsureCustomThemeCreated(value, this.ThemeColor);
        this.Theme.Style = value;
        switch (value)
        {
          case RibbonOrbStyle.Office_2007:
            this.TabsPadding = new Padding(8, 4, 8, 4);
            this.OrbsPadding = new Padding(8, 4, 8, 4);
            this._tabsMargin = !this.CaptionBarVisible ? new Padding(12, 2 + this.ContextSpace, 20, 0) : new Padding(12, Ribbon.CaptionBarHeight + 2 + this.ContextSpace, 20, 0);
            this.TabContentMargin = new Padding(1, 0, 2, 2);
            this.TabContentPadding = new Padding(0);
            this.TabSpacing = 6;
            this.PanelSpacing = 4;
            this.PanelPadding = new Padding(3);
            this._panelMargin = new Padding(3, 2, 3, 15);
            this.PanelMoreSize = new Size(6, 6);
            this.PanelMoreMargin = new Padding(0, 0, 1, 1);
            this.ItemMargin = new Padding(4, 2, 4, 2);
            this.ItemPadding = new Padding(1, 0, 1, 0);
            this.ItemImageToTextSpacing = 4;
            break;
          case RibbonOrbStyle.Office_2010:
          case RibbonOrbStyle.Office_2010_Extended:
            this.TabsPadding = new Padding(10, 3, 7, 2);
            this.OrbsPadding = new Padding(17, 4, 15, 4);
            this.TabsMargin = !this.CaptionBarVisible ? new Padding(6, 2 + this.ContextSpace, 20, 0) : new Padding(6, Ribbon.CaptionBarHeight + 2 + this.ContextSpace, 20, 0);
            this.TabContentMargin = new Padding(0, 0, 0, 2);
            this.TabContentPadding = new Padding(0);
            this.TabSpacing = 3;
            this.PanelSpacing = 0;
            this.PanelPadding = new Padding(0, 1, 1, 1);
            this._panelMargin = new Padding(2, 2, 2, 15);
            this.PanelMoreSize = new Size(6, 6);
            this.PanelMoreMargin = new Padding(0, 0, 2, 0);
            this.ItemMargin = new Padding(3, 2, 0, 2);
            this.ItemPadding = new Padding(1, 0, 1, 0);
            this.ItemImageToTextSpacing = 11;
            break;
          case RibbonOrbStyle.Office_2013:
            this.TabsPadding = new Padding(8, 4, 8, 1);
            this.OrbsPadding = new Padding(15, 3, 15, 3);
            this._tabsMargin = !this.CaptionBarVisible ? new Padding(5, 2 + this.ContextSpace, 20, 0) : new Padding(5, Ribbon.CaptionBarHeight + 2 + this.ContextSpace, 20, 0);
            this.TabContentMargin = new Padding(0, 0, 0, 2);
            this.TabContentPadding = new Padding(0);
            this.TabSpacing = 4;
            this.PanelSpacing = 0;
            this.PanelPadding = new Padding(3);
            this._panelMargin = new Padding(3, 2, 3, 15);
            this.PanelMoreSize = new Size(6, 6);
            this.PanelMoreMargin = new Padding(0, 0, 1, 0);
            this.ItemMargin = new Padding(2, 2, 0, 2);
            this.ItemPadding = new Padding(1, 0, 1, 0);
            this.ItemImageToTextSpacing = 11;
            break;
        }
        this.UpdateRegions();
        this.Invalidate();
        if (num == 0)
          return;
        EventHandler orbStyleChanged = this.OrbStyleChanged;
        if (orbStyleChanged == null)
          return;
        orbStyleChanged((object) this, EventArgs.Empty);
      }
    }

    public event EventHandler OrbStyleChanged;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Category("Appearance")]
    [DefaultValue(RibbonTheme.Normal)]
    public RibbonTheme ThemeColor
    {
      get => this.Theme.RibbonTheme;
      set
      {
        this.EnsureCustomThemeCreated(this.OrbStyle, value);
        this.Theme.RibbonTheme = value;
        this.OnRegionsChanged();
        this.Invalidate();
      }
    }

    [DefaultValue(false)]
    [Category("Appearance")]
    [Description("If this value is set, you can still link a Ribbon fixed to the Standard Theme.")]
    public bool UseAlwaysStandardTheme
    {
      get => this._useAlwaysStandardTheme;
      set
      {
        this._useAlwaysStandardTheme = value;
        if (!value)
          return;
        this._theme = (Theme) null;
      }
    }

    [DefaultValue(null)]
    [Category("Orb")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string OrbText
    {
      get => this._orbText;
      set
      {
        this._orbText = value;
        this.RecalculateOrbTextSize();
        this.OnRegionsChanged();
        this.Invalidate();
      }
    }

    [DefaultValue(null)]
    [Category("Orb")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public Image OrbImage
    {
      get => this._orbImage;
      set
      {
        this._orbImage = value;
        this.OnRegionsChanged();
        this.Invalidate(this.OrbBounds);
      }
    }

    [DefaultValue(true)]
    [Category("Orb")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public bool OrbVisible
    {
      get => this._orbVisible;
      set
      {
        this._orbVisible = value;
        this.OnRegionsChanged();
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool OrbSelected
    {
      get => this._orbSelected;
      set
      {
        this._orbSelected = value;
        this.Invalidate(this.OrbBounds);
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool OrbPressed
    {
      get => this._orbPressed;
      set
      {
        this._orbPressed = value;
        this.Invalidate(this.OrbBounds);
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int CaptionBarSize => Ribbon.CaptionBarHeight;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle OrbBounds
    {
      get
      {
        if (this.OrbStyle == RibbonOrbStyle.Office_2007)
        {
          if (this.OrbVisible && this.RightToLeft == RightToLeft.No && this.CaptionBarVisible)
            return new Rectangle(4, 4, 36, 36);
          if (this.OrbVisible && this.RightToLeft == RightToLeft.Yes && this.CaptionBarVisible)
            return new Rectangle(this.Width - 36 - 4, 4, 36, 36);
          return this.RightToLeft == RightToLeft.No ? new Rectangle(4, 4, 0, 0) : new Rectangle(this.Width - 4, 4, 0, 0);
        }
        if (this.OrbStyle == RibbonOrbStyle.Office_2010 || this.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
        {
          Size orbTextSize = this._orbTextSize;
          if (this.OrbImage != null)
          {
            orbTextSize.Width = Math.Max(orbTextSize.Width, this.OrbImage.Size.Width);
            orbTextSize.Height = Math.Max(orbTextSize.Height, this.OrbImage.Size.Height);
          }
          if (this.OrbVisible && this.RightToLeft == RightToLeft.No)
          {
            int top = this.TabsMargin.Top;
            int width1 = orbTextSize.Width;
            Padding orbsPadding = this.OrbsPadding;
            int left = orbsPadding.Left;
            int num1 = width1 + left;
            orbsPadding = this.OrbsPadding;
            int right = orbsPadding.Right;
            int width2 = num1 + right;
            orbsPadding = this.OrbsPadding;
            int num2 = orbsPadding.Top + orbTextSize.Height;
            orbsPadding = this.OrbsPadding;
            int bottom = orbsPadding.Bottom;
            int height = num2 + bottom;
            return new Rectangle(1, top, width2, height);
          }
          if (this.OrbVisible && this.RightToLeft == RightToLeft.Yes && this.CaptionBarVisible)
          {
            int num3 = this.Width - orbTextSize.Width;
            Padding padding = this.OrbsPadding;
            int left1 = padding.Left;
            int num4 = num3 - left1;
            padding = this.OrbsPadding;
            int right1 = padding.Right;
            int x = num4 - right1 - 1;
            padding = this.TabsMargin;
            int top = padding.Top;
            int width3 = orbTextSize.Width;
            padding = this.OrbsPadding;
            int left2 = padding.Left;
            int num5 = width3 + left2;
            padding = this.OrbsPadding;
            int right2 = padding.Right;
            int width4 = num5 + right2;
            padding = this.OrbsPadding;
            int num6 = padding.Top + orbTextSize.Height;
            padding = this.OrbsPadding;
            int bottom = padding.Bottom;
            int height = num6 + bottom;
            return new Rectangle(x, top, width4, height);
          }
          return this.RightToLeft == RightToLeft.No ? new Rectangle(4, 4, 0, 0) : new Rectangle(this.Width - 4, 4, 0, 0);
        }
        Size orbTextSize1 = this._orbTextSize;
        if (this.OrbImage != null)
        {
          orbTextSize1.Width = Math.Max(orbTextSize1.Width, this.OrbImage.Size.Width);
          orbTextSize1.Height = Math.Max(orbTextSize1.Height, this.OrbImage.Size.Height);
        }
        if (this.OrbVisible && this.RightToLeft == RightToLeft.No)
        {
          int top = this.TabsMargin.Top;
          int width5 = orbTextSize1.Width;
          Padding orbsPadding = this.OrbsPadding;
          int left = orbsPadding.Left;
          int num7 = width5 + left;
          orbsPadding = this.OrbsPadding;
          int right = orbsPadding.Right;
          int width6 = num7 + right;
          orbsPadding = this.OrbsPadding;
          int num8 = orbsPadding.Top + orbTextSize1.Height;
          orbsPadding = this.OrbsPadding;
          int bottom = orbsPadding.Bottom;
          int height = num8 + bottom + 1;
          return new Rectangle(0, top, width6, height);
        }
        if (this.OrbVisible && this.RightToLeft == RightToLeft.Yes && this.CaptionBarVisible)
        {
          int num9 = this.Width - orbTextSize1.Width;
          Padding padding = this.OrbsPadding;
          int left3 = padding.Left;
          int num10 = num9 - left3;
          padding = this.OrbsPadding;
          int right3 = padding.Right;
          int x = num10 - right3 - 4;
          padding = this.TabsMargin;
          int top = padding.Top;
          int width7 = orbTextSize1.Width;
          padding = this.OrbsPadding;
          int left4 = padding.Left;
          int num11 = width7 + left4;
          padding = this.OrbsPadding;
          int right4 = padding.Right;
          int width8 = num11 + right4;
          padding = this.OrbsPadding;
          int num12 = padding.Top + orbTextSize1.Height;
          padding = this.OrbsPadding;
          int bottom = padding.Bottom;
          int height = num12 + bottom;
          return new Rectangle(x, top, width8, height);
        }
        return this.RightToLeft == RightToLeft.No ? new Rectangle(4, 4, 0, 0) : new Rectangle(this.Width - 4, 4, 0, 0);
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RibbonTab NextTab
    {
      get
      {
        if (this.ActiveTab == null || this.Tabs.Count == 0)
          return this.Tabs.Count == 0 ? (RibbonTab) null : this.Tabs[0];
        int num = this.Tabs.IndexOf(this.ActiveTab);
        return num == this.Tabs.Count - 1 ? this.ActiveTab : this.Tabs[num + 1];
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RibbonTab PreviousTab
    {
      get
      {
        if (this.ActiveTab == null || this.Tabs.Count == 0)
          return this.Tabs.Count == 0 ? (RibbonTab) null : this.Tabs[0];
        int num = this.Tabs.IndexOf(this.ActiveTab);
        return num == 0 ? this.ActiveTab : this.Tabs[num - 1];
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Padding TabTextMargin { get; set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Padding DropDownMargin { get; set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Padding ItemPadding { get; set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int ItemImageToTextSpacing { get; set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Padding ItemMargin { get; set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RibbonTab ActiveTab
    {
      get => this._activeTab;
      set
      {
        RibbonTab ribbonTab = this._activeTab;
        foreach (RibbonTab tab in (List<RibbonTab>) this.Tabs)
        {
          if (tab != value)
            tab.SetActive(false);
          else
            ribbonTab = tab;
        }
        ribbonTab.SetActive(true);
        this._activeTab = value;
        this.RemoveHelperControls();
        value.UpdatePanelsRegions();
        this.Invalidate();
        this.RenewSensor();
        this.OnActiveTabChanged(EventArgs.Empty);
      }
    }

    [DefaultValue(3)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int PanelSpacing { get; set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Size PanelMoreSize { get; set; } = new Size(7, 7);

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Padding PanelPadding { get; set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Padding PanelMargin
    {
      get => this._panelMargin;
      set => this._panelMargin = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Padding PanelMoreMargin { get; set; }

    [Browsable(false)]
    [DefaultValue(6)]
    public int TabSpacing { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public RibbonTabCollection Tabs { get; }

    [Category("Appearance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public bool Minimized
    {
      get => this._minimized;
      set
      {
        this._minimized = value;
        if (this.IsDesignMode())
          return;
        if (this._minimized)
          this.Height = this.MinimizedHeight;
        else
          this.Height = this._expandedHeight;
        this.Expanded = !this.Minimized;
        this.UpdateRegions();
        this.Invalidate();
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public RibbonContextCollection Contexts { get; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RibbonRenderer Renderer
    {
      get => this._renderer;
      set
      {
        this._renderer = value ?? throw new ArgumentNullException(nameof (Renderer), "Null renderer!");
        this.Invalidate();
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Padding TabContentMargin { get; set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Padding TabContentPadding { get; set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Padding TabsMargin
    {
      get => this._tabsMargin;
      set
      {
        this._tabsMargin = value;
        this.UpdateRegions();
        this.Invalidate();
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Padding TabsPadding { get; set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Padding OrbsPadding { get; set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Size MaximumSize
    {
      get => new Size(0, 200);
      set
      {
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Size MinimumSize
    {
      get => new Size(0, 27);
      set
      {
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [DefaultValue(DockStyle.Top)]
    public override DockStyle Dock
    {
      get => base.Dock;
      set => base.Dock = value;
    }

    [Browsable(false)]
    public RibbonMouseSensor Sensor { get; private set; }

    [DefaultValue(RightToLeft.No)]
    public override RightToLeft RightToLeft
    {
      get => base.RightToLeft;
      set
      {
        base.RightToLeft = value;
        this.OnRegionsChanged();
      }
    }

    [Category("Appearance")]
    [DefaultValue(true)]
    public bool CaptionBarVisible
    {
      get => this._CaptionBarVisible;
      set
      {
        this._CaptionBarVisible = value;
        this.OrbStyle = this.OrbStyle;
      }
    }

    public override void Refresh()
    {
      try
      {
        if (this.IsDisposed)
          return;
        if (this.InvokeRequired)
          this.Invoke((Delegate) new Ribbon.HandlerCallbackMethode(((Control) this).Refresh));
        else
          base.Refresh();
      }
      catch (Exception ex)
      {
      }
    }

    private string cr => "Professional Ribbon\n\n2009 Jos?Manuel Menéndez Poo\nwww.menendezpoo.com";

    [DefaultValue(null)]
    [Category("Appearance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public Font RibbonTabFont
    {
      get => this._RibbonTabFont;
      set
      {
        this._RibbonTabFont = value;
        this.RecalculateOrbTextSize();
      }
    }

    [Category("Appearance")]
    [Description("Specifies if a Tab is invisible in case it is the only one and the text is set to string.Empty.")]
    [DefaultValue(true)]
    public bool HideSingleTabIfTextEmpty { get; set; } = true;

    private void _mouseHook_MouseDown(object sender, MouseEventArgs e)
    {
      bool flag = false;
      if (!this.RectangleToScreen(this.OrbBounds).Contains(e.Location))
        flag = RibbonPopupManager.FeedHookClick(e);
      if (this.RectangleToScreen(this.Bounds).Contains(e.Location))
        flag = true;
      if (!this.Minimized || flag)
        return;
      this.Expanded = false;
    }

    private void _mouseHook_MouseWheel(object sender, MouseEventArgs e)
    {
      if (RibbonPopupManager.FeedMouseWheel(e) || !this.RectangleToScreen(new Rectangle(Point.Empty, this.Size)).Contains(e.Location))
        return;
      this.OnMouseWheel(e);
    }

    internal virtual void OnOrbClicked(EventArgs e)
    {
      if (this.OrbPressed)
        RibbonPopupManager.Dismiss(RibbonPopupManager.DismissReason.ItemClicked);
      else
        this.ShowOrbDropDown();
      if (this.OrbClicked == null)
        return;
      this.OrbClicked((object) this, e);
    }

    internal virtual void OnOrbDoubleClicked(EventArgs e)
    {
      if (this.OrbDoubleClick == null)
        return;
      this.OrbDoubleClick((object) this, e);
    }

    private void SetUpHooks()
    {
      if (RibbonDesigner.Current != null)
        return;
      if (this._mouseHook == null)
      {
        this._mouseHook = new GlobalHook(GlobalHook.HookTypes.Mouse);
        this._mouseHook.MouseWheel += new MouseEventHandler(this._mouseHook_MouseWheel);
        this._mouseHook.MouseDown += new MouseEventHandler(this._mouseHook_MouseDown);
      }
      if (this._keyboardHook != null)
        return;
      this._keyboardHook = new GlobalHook(GlobalHook.HookTypes.Keyboard);
      this._keyboardHook.KeyDown += new KeyEventHandler(this._keyboardHook_KeyDown);
    }

    private void _keyboardHook_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Escape)
        return;
      RibbonPopupManager.Dismiss(RibbonPopupManager.DismissReason.EscapePressed);
    }

    public void ShowOrbDropDown()
    {
      this.OrbPressed = true;
      if (this.RightToLeft != RightToLeft.No)
        return;
      if (this.OrbStyle == RibbonOrbStyle.Office_2007)
        this.OrbDropDown.Show(this.PointToScreen(new Point(this.OrbBounds.X - 4, this.OrbBounds.Bottom - this.OrbDropDown.ContentMargin.Top + 2)));
      else if (this.OrbStyle == RibbonOrbStyle.Office_2010 || this.OrbStyle == RibbonOrbStyle.Office_2010_Extended || this.OrbStyle == RibbonOrbStyle.Office_2013)
        this.OrbDropDown.Show(this.PointToScreen(new Point(this.OrbBounds.X - 4, this.OrbBounds.Bottom)));
      else if (this.OrbStyle == RibbonOrbStyle.Office_2007)
      {
        this.OrbDropDown.Show(this.PointToScreen(new Point(this.OrbBounds.Right + 4 - this.OrbDropDown.Width, this.OrbBounds.Bottom - this.OrbDropDown.ContentMargin.Top + 2)));
      }
      else
      {
        if (this.OrbStyle != RibbonOrbStyle.Office_2010 && this.OrbStyle != RibbonOrbStyle.Office_2010_Extended && this.OrbStyle != RibbonOrbStyle.Office_2013)
          return;
        this.OrbDropDown.Show(this.PointToScreen(new Point(this.OrbBounds.Right + 4 - this.OrbDropDown.Width, this.OrbBounds.Bottom)));
      }
    }

    public void ShowOrbDropDown(Point pt)
    {
      this.OrbPressed = true;
      this.OrbDropDown.Show(this.PointToScreen(pt));
    }

    private void RenewSensor()
    {
      if (this.ActiveTab == null)
        return;
      if (this.Sensor != null)
        this.Sensor.Dispose();
      this.Sensor = new RibbonMouseSensor((Control) this, this, this.ActiveTab);
      if (!this.CaptionButtonsVisible)
        return;
      this.Sensor.Items.AddRange((IEnumerable<RibbonItem>) new RibbonItem[3]
      {
        (RibbonItem) this.CloseButton,
        (RibbonItem) this.MaximizeRestoreButton,
        (RibbonItem) this.MinimizeButton
      });
    }

    private void SetActualBorderMode(RibbonWindowMode borderMode)
    {
      int num = this.ActualBorderMode != borderMode ? 1 : 0;
      this.ActualBorderMode = borderMode;
      if (num != 0)
        this.OnActualBorderModeChanged(EventArgs.Empty);
      this.SetCaptionButtonsVisible(borderMode == RibbonWindowMode.NonClientAreaCustomDrawn);
    }

    private void SetCaptionButtonsVisible(bool visible)
    {
      int num = this.CaptionButtonsVisible != visible ? 1 : 0;
      this.CaptionButtonsVisible = visible;
      if (num == 0)
        return;
      this.OnCaptionButtonsVisibleChanged(EventArgs.Empty);
    }

    public void SuspendUpdating() => this._updatingSuspended = true;

    public void ResumeUpdating() => this.ResumeUpdating(true);

    public void ResumeUpdating(bool update)
    {
      this._updatingSuspended = false;
      if (!update)
        return;
      this.OnRegionsChanged();
    }

    private void RemoveHelperControls()
    {
      RibbonPopupManager.Dismiss(RibbonPopupManager.DismissReason.AppClicked);
      while (this.Controls.Count > 0)
      {
        Control control = this.Controls[0];
        control.Visible = false;
        this.Controls.Remove(control);
      }
    }

    internal bool TabHitTest(int x, int y)
    {
      foreach (RibbonTab tab in (List<RibbonTab>) this.Tabs)
      {
        if (tab.TabBounds.Contains(x, y))
        {
          this.ActiveTab = tab;
          this.Expanded = true;
          return true;
        }
      }
      return false;
    }

    internal bool ContextHitTest(int x, int y)
    {
      foreach (RibbonContext context in (List<RibbonContext>) this.Contexts)
      {
        if (context.Bounds.Contains(x, y))
          return true;
      }
      return false;
    }

    internal void UpdateRegions() => this.UpdateRegions((Graphics) null);

    internal void UpdateRegions(Graphics g)
    {
      bool flag = false;
      if (this.IsDisposed || this._updatingSuspended)
        return;
      if (g == null)
      {
        g = this.CreateGraphics();
        flag = true;
      }
      this.UpdateRegionsTabsConsiderRTL(g);
      if (this.RightToLeft == RightToLeft.No)
      {
        this.QuickAccessToolbar.MeasureSize((object) this, new RibbonElementMeasureSizeEventArgs(g, RibbonElementSizeMode.Compact));
        if (this.OrbStyle == RibbonOrbStyle.Office_2007)
          this.QuickAccessToolbar.SetBounds(new Rectangle(new Point(this.OrbBounds.Right + this.QuickAccessToolbar.Margin.Left, this.OrbBounds.Top - 2), this.QuickAccessToolbar.LastMeasuredSize));
        else if (this.OrbStyle == RibbonOrbStyle.Office_2010 || this.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
          this.QuickAccessToolbar.SetBounds(new Rectangle(new Point(this.QuickAccessToolbar.Margin.Left, 0), this.QuickAccessToolbar.LastMeasuredSize));
        else if (this.OrbStyle == RibbonOrbStyle.Office_2013)
          this.QuickAccessToolbar.SetBounds(new Rectangle(new Point(this.QuickAccessToolbar.Margin.Left, 0), this.QuickAccessToolbar.LastMeasuredSize));
        if (this.CaptionButtonsVisible)
        {
          Size size = new Size(20, 20);
          int y = 2;
          this.CloseButton.SetBounds(new Rectangle(new Point(this.ClientRectangle.Right - size.Width - y, y), size));
          RibbonCaptionButton maximizeRestoreButton = this.MaximizeRestoreButton;
          Rectangle bounds1 = this.CloseButton.Bounds;
          Rectangle bounds2 = new Rectangle(new Point(bounds1.Left - size.Width, y), size);
          maximizeRestoreButton.SetBounds(bounds2);
          RibbonCaptionButton minimizeButton = this.MinimizeButton;
          bounds1 = this.MaximizeRestoreButton.Bounds;
          Rectangle bounds3 = new Rectangle(new Point(bounds1.Left - size.Width, y), size);
          minimizeButton.SetBounds(bounds3);
        }
      }
      else
      {
        this.QuickAccessToolbar.MeasureSize((object) this, new RibbonElementMeasureSizeEventArgs(g, RibbonElementSizeMode.Compact));
        if (this.OrbStyle == RibbonOrbStyle.Office_2007)
          this.QuickAccessToolbar.SetBounds(new Rectangle(new Point(this.OrbBounds.Left - this.QuickAccessToolbar.Margin.Right - this.QuickAccessToolbar.LastMeasuredSize.Width, this.OrbBounds.Top - 2), this.QuickAccessToolbar.LastMeasuredSize));
        else if (this.OrbStyle == RibbonOrbStyle.Office_2010 || this.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
          this.QuickAccessToolbar.SetBounds(new Rectangle(new Point(this.ClientRectangle.Right - this.QuickAccessToolbar.Margin.Right - this.QuickAccessToolbar.LastMeasuredSize.Width, 0), this.QuickAccessToolbar.LastMeasuredSize));
        else if (this.OrbStyle == RibbonOrbStyle.Office_2013)
          this.QuickAccessToolbar.SetBounds(new Rectangle(new Point(this.ClientRectangle.Right - this.QuickAccessToolbar.Margin.Right - this.QuickAccessToolbar.LastMeasuredSize.Width, 0), this.QuickAccessToolbar.LastMeasuredSize));
        if (this.CaptionButtonsVisible)
        {
          Size size = new Size(20, 20);
          int y = 2;
          this.CloseButton.SetBounds(new Rectangle(new Point(this.ClientRectangle.Left, y), size));
          this.MaximizeRestoreButton.SetBounds(new Rectangle(new Point(this.CloseButton.Bounds.Right, y), size));
          this.MinimizeButton.SetBounds(new Rectangle(new Point(this.MaximizeRestoreButton.Bounds.Right, y), size));
        }
      }
      if (flag)
        g.Dispose();
      this._lastSizeMeasured = this.Size;
      this.RenewSensor();
    }

    private void UpdateRegionsTabsConsiderRTL(Graphics g)
    {
      int val2_1 = 0;
      Point point = new Point();
      ref Point local1 = ref point;
      Padding padding1;
      int x1;
      if (this.RightToLeft != RightToLeft.No)
      {
        int left1 = this.OrbBounds.Left;
        padding1 = this.TabsMargin;
        int left2 = padding1.Left;
        x1 = left1 - left2 + 4;
      }
      else
      {
        int width = this.OrbBounds.Width;
        padding1 = this.TabsMargin;
        int left = padding1.Left;
        x1 = width + left;
      }
      local1 = new Point(x1, 0);
      int val2_2 = 0;
      int num1 = 0;
      foreach (RibbonTab tab in (List<RibbonTab>) this.Tabs)
      {
        if (tab.Visible || this.IsDesignMode())
        {
          Size size1 = tab.MeasureSize((object) this, new RibbonElementMeasureSizeEventArgs(g, RibbonElementSizeMode.None));
          if (tab.Contextual && tab.Context.ContextualTabsCount == 1)
          {
            Size size2 = tab.Context.MeasureSize((object) this, new RibbonElementMeasureSizeEventArgs(g, RibbonElementSizeMode.None));
            size1.Width = Math.Max(size1.Width, size2.Width);
          }
          int num2;
          if (tab.Invisible && !this.OrbVisible)
          {
            padding1 = this.TabsMargin;
            num2 = padding1.Top - size1.Height - 8 + (this.OrbStyle == RibbonOrbStyle.Office_2013 ? 2 : 0);
          }
          else
          {
            padding1 = this.TabsMargin;
            num2 = padding1.Top;
          }
          num1 = num2;
          Rectangle rectangle = new Rectangle();
          ref Rectangle local2 = ref rectangle;
          int y = num1;
          padding1 = this.TabsPadding;
          int num3 = padding1.Left + size1.Width;
          padding1 = this.TabsPadding;
          int right1 = padding1.Right;
          int width1 = num3 + right1;
          padding1 = this.TabsPadding;
          int num4 = padding1.Top + size1.Height;
          padding1 = this.TabsPadding;
          int bottom1 = padding1.Bottom;
          int height1 = num4 + bottom1;
          local2 = new Rectangle(0, y, width1, height1);
          rectangle = this.LayoutHelper.CalcNewPosition(point, rectangle, LayoutHelper.RTLLayoutPosition.Far, this.TabSpacing);
          tab.SetTabBounds(rectangle);
          point = this.LayoutHelper.CalcNewPosition(rectangle, point, LayoutHelper.RTLLayoutPosition.Far, 0);
          val2_2 = Math.Max(rectangle.Width, val2_2);
          val2_1 = Math.Max(rectangle.Bottom, val2_1);
          RibbonTab ribbonTab = tab;
          padding1 = this.TabContentMargin;
          int left = padding1.Left;
          int num5 = val2_1;
          padding1 = this.TabContentMargin;
          int top1 = padding1.Top;
          int top2 = num5 + top1;
          Size clientSize = this.ClientSize;
          int width2 = clientSize.Width;
          padding1 = this.TabContentMargin;
          int right2 = padding1.Right;
          int right3 = width2 - right2;
          clientSize = this.ClientSize;
          int height2 = clientSize.Height;
          padding1 = this.TabContentMargin;
          int bottom2 = padding1.Bottom;
          int bottom3 = height2 - bottom2;
          Rectangle tabContentBounds = Rectangle.FromLTRB(left, top2, right3, bottom3);
          ribbonTab.SetTabContentBounds(tabContentBounds);
          if (tab.Active)
            tab.UpdatePanelsRegions();
        }
        else
        {
          tab.SetTabBounds(Rectangle.Empty);
          tab.SetTabContentBounds(Rectangle.Empty);
          if (tab.Contextual)
          {
            tab.Context.SetBounds(Rectangle.Empty);
            tab.Context.SetHeaderBounds(Rectangle.Empty);
          }
        }
      }
      foreach (RibbonContext context in (List<RibbonContext>) this.Contexts)
      {
        if (context.ContextualTabsCount == 0 && this.IsDesignMode())
        {
          Size size = context.MeasureSize((object) this, new RibbonElementMeasureSizeEventArgs(g, RibbonElementSizeMode.None));
          Padding padding2;
          int num6;
          if (!context.Visible && !this.OrbVisible)
          {
            padding2 = this.TabsMargin;
            num6 = padding2.Top - size.Height - 8 + (this.OrbStyle == RibbonOrbStyle.Office_2013 ? 2 : 0);
          }
          else
          {
            padding2 = this.TabsMargin;
            num6 = padding2.Top;
          }
          num1 = num6;
          Rectangle rectangle1 = new Rectangle();
          ref Rectangle local3 = ref rectangle1;
          int y = num1 - Ribbon.CaptionBarHeight;
          padding2 = this.TabsPadding;
          int num7 = padding2.Left + size.Width;
          padding2 = this.TabsPadding;
          int right = padding2.Right;
          int width = num7 + right;
          padding2 = this.TabsPadding;
          int num8 = padding2.Top + size.Height;
          padding2 = this.TabsPadding;
          int bottom = padding2.Bottom;
          int height = num8 + bottom + Ribbon.CaptionBarHeight;
          local3 = new Rectangle(0, y, width, height);
          Rectangle rectangle2 = new Rectangle(rectangle1.Left, rectangle1.Top, rectangle1.Width, Ribbon.CaptionBarHeight);
          rectangle1 = this.LayoutHelper.CalcNewPosition(point, rectangle1, LayoutHelper.RTLLayoutPosition.Far, this.TabSpacing);
          rectangle2 = this.LayoutHelper.CalcNewPosition(point, rectangle2, LayoutHelper.RTLLayoutPosition.Far, this.TabSpacing);
          context.SetBounds(rectangle1);
          context.SetHeaderBounds(rectangle2);
          point = this.LayoutHelper.CalcNewPosition(rectangle1, point, LayoutHelper.RTLLayoutPosition.Far, 0);
          val2_2 = Math.Max(rectangle1.Width, val2_2);
          val2_1 = Math.Max(rectangle1.Bottom, val2_1);
        }
      }
label_53:
      Rectangle rectangle3;
      int num9;
      if (this.RightToLeft != RightToLeft.No)
      {
        int x2 = point.X;
        rectangle3 = this.ClientRectangle;
        int left = rectangle3.Left;
        num9 = x2 < left ? 1 : 0;
      }
      else
      {
        int x3 = point.X;
        rectangle3 = this.ClientRectangle;
        int right = rectangle3.Right;
        num9 = x3 > right ? 1 : 0;
      }
      if (num9 != 0 && val2_2 > 0)
      {
        ref Point local4 = ref point;
        Padding padding3;
        int x4;
        if (this.RightToLeft != RightToLeft.No)
        {
          rectangle3 = this.OrbBounds;
          int left3 = rectangle3.Left;
          padding3 = this.TabsMargin;
          int left4 = padding3.Left;
          x4 = left3 - left4 + 4;
        }
        else
        {
          rectangle3 = this.OrbBounds;
          int width = rectangle3.Width;
          padding3 = this.TabsMargin;
          int left = padding3.Left;
          x4 = width + left;
        }
        local4 = new Point(x4, 0);
        --val2_2;
        foreach (RibbonTab tab in (List<RibbonTab>) this.Tabs)
        {
          if (tab.Visible)
          {
            Size size3 = tab.MeasureSize((object) this, new RibbonElementMeasureSizeEventArgs(g, RibbonElementSizeMode.None));
            if (size3.Width >= val2_2)
              size3.Width = val2_2;
            if (tab.Contextual && tab.Context.ContextualTabsCount == 1)
            {
              Size size4 = tab.Context.MeasureSize((object) this, new RibbonElementMeasureSizeEventArgs(g, RibbonElementSizeMode.None));
              size3.Width = Math.Max(size3.Width, size4.Width);
            }
            int num10;
            if (tab.Invisible && !this.OrbVisible)
            {
              padding3 = this.TabsMargin;
              num10 = padding3.Top - size3.Height - 8 + (this.OrbStyle == RibbonOrbStyle.Office_2013 ? 2 : 0);
            }
            else
            {
              padding3 = this.TabsMargin;
              num10 = padding3.Top;
            }
            num1 = num10;
            Rectangle rectangle4 = new Rectangle();
            ref Rectangle local5 = ref rectangle4;
            int y = num1;
            padding3 = this.TabsPadding;
            int num11 = padding3.Left + size3.Width;
            padding3 = this.TabsPadding;
            int right = padding3.Right;
            int width = num11 + right;
            padding3 = this.TabsPadding;
            int num12 = padding3.Top + size3.Height;
            padding3 = this.TabsPadding;
            int bottom = padding3.Bottom;
            int height = num12 + bottom;
            local5 = new Rectangle(0, y, width, height);
            rectangle4 = this.LayoutHelper.CalcNewPosition(point, rectangle4, LayoutHelper.RTLLayoutPosition.Far, this.TabSpacing);
            tab.SetTabBounds(rectangle4);
            point = this.LayoutHelper.CalcNewPosition(rectangle4, point, LayoutHelper.RTLLayoutPosition.Far, 0);
          }
        }
        using (List<RibbonContext>.Enumerator enumerator = this.Contexts.GetEnumerator())
        {
          while (enumerator.MoveNext())
          {
            RibbonContext current = enumerator.Current;
            if (current.ContextualTabsCount == 0 && this.IsDesignMode())
            {
              Size size = current.MeasureSize((object) this, new RibbonElementMeasureSizeEventArgs(g, RibbonElementSizeMode.None));
              if (size.Width >= val2_2)
                size.Width = val2_2;
              Padding padding4;
              int num13;
              if (!current.Visible && !this.OrbVisible)
              {
                padding4 = this.TabsMargin;
                num13 = padding4.Top - size.Height - 8 + (this.OrbStyle == RibbonOrbStyle.Office_2013 ? 2 : 0);
              }
              else
              {
                padding4 = this.TabsMargin;
                num13 = padding4.Top;
              }
              num1 = num13;
              Rectangle rectangle5 = new Rectangle();
              ref Rectangle local6 = ref rectangle5;
              int y = num1 - Ribbon.CaptionBarHeight;
              padding4 = this.TabsPadding;
              int num14 = padding4.Left + size.Width;
              padding4 = this.TabsPadding;
              int right = padding4.Right;
              int width = num14 + right;
              padding4 = this.TabsPadding;
              int num15 = padding4.Top + size.Height;
              padding4 = this.TabsPadding;
              int bottom = padding4.Bottom;
              int height = num15 + bottom + Ribbon.CaptionBarHeight;
              local6 = new Rectangle(0, y, width, height);
              Rectangle rectangle6 = new Rectangle(rectangle5.Left, rectangle5.Top, rectangle5.Width, Ribbon.CaptionBarHeight);
              rectangle5 = this.LayoutHelper.CalcNewPosition(point, rectangle5, LayoutHelper.RTLLayoutPosition.Far, this.TabSpacing);
              rectangle6 = this.LayoutHelper.CalcNewPosition(point, rectangle6, LayoutHelper.RTLLayoutPosition.Far, this.TabSpacing);
              current.SetBounds(rectangle5);
              current.SetHeaderBounds(rectangle6);
              point = this.LayoutHelper.CalcNewPosition(rectangle5, point, LayoutHelper.RTLLayoutPosition.Far, 0);
            }
          }
          goto label_53;
        }
      }
      else
      {
        foreach (RibbonContext context in (List<RibbonContext>) this.Contexts)
        {
          if (context.ContextualTabsCount > 0)
          {
            foreach (RibbonTab contextualTab in context.ContextualTabs)
            {
              Rectangle bounds1 = context.ContextualTabs[context.ContextualTabs.Count - 1].Bounds;
              Rectangle bounds2 = context.ContextualTabs[0].Bounds;
              int num16 = Math.Max(bounds1.Right, bounds2.Right);
              int num17 = Math.Min(bounds1.Left, bounds2.Left);
              Rectangle bounds3 = new Rectangle();
              ref Rectangle local7 = ref bounds3;
              int x5 = num17;
              int y = num1 - Ribbon.CaptionBarHeight;
              int width = num16 - num17;
              Padding tabsPadding = this.TabsPadding;
              int num18 = tabsPadding.Top + bounds1.Height;
              tabsPadding = this.TabsPadding;
              int bottom = tabsPadding.Bottom;
              int height = num18 + bottom + Ribbon.CaptionBarHeight;
              local7 = new Rectangle(x5, y, width, height);
              Rectangle bounds4 = new Rectangle(bounds3.Left, bounds3.Top, bounds3.Width, Ribbon.CaptionBarHeight);
              contextualTab.Context.SetBounds(bounds3);
              contextualTab.Context.SetHeaderBounds(bounds4);
            }
          }
        }
      }
    }

    internal void OnRegionsChanged()
    {
      if (this._updatingSuspended)
        return;
      if (this.Tabs.Count == 1 && this.ActiveTab != this.Tabs[0])
        this.ActiveTab = this.Tabs[0];
      this._lastSizeMeasured = Size.Empty;
      this.Refresh();
    }

    internal void RedrawTab(RibbonTab tab)
    {
      using (Graphics graphics = this.CreateGraphics())
      {
        Rectangle rect = Rectangle.FromLTRB(tab.TabBounds.Left, tab.TabBounds.Top, tab.TabBounds.Right, tab.TabBounds.Bottom);
        graphics.SetClip(rect);
        SmoothingMode smoothingMode = graphics.SmoothingMode;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
        tab.OnPaint((object) this, new RibbonElementPaintEventArgs(tab.TabBounds, graphics, RibbonElementSizeMode.None));
        graphics.SmoothingMode = smoothingMode;
        graphics.TextRenderingHint = TextRenderingHint.SystemDefault;
      }
    }

    private void SetSelectedTab(RibbonTab tab)
    {
      if (tab == this._lastSelectedTab)
        return;
      if (this._lastSelectedTab != null)
      {
        this._lastSelectedTab.SetSelected(false);
        this.RedrawTab(this._lastSelectedTab);
      }
      if (tab != null)
      {
        tab.SetSelected(true);
        this.RedrawTab(tab);
      }
      this._lastSelectedTab = tab;
    }

    internal void SuspendSensor()
    {
      if (this.Sensor == null)
        return;
      this.Sensor.Suspend();
    }

    internal void ResumeSensor() => this.Sensor.Resume();

    public void RedrawArea(Rectangle area) => this.Sensor.Control.Invalidate(area);

    public void ActivateNextTab()
    {
      RibbonTab nextTab = this.NextTab;
      if (nextTab == null)
        return;
      this.ActiveTab = nextTab;
    }

    public void ActivatePreviousTab()
    {
      RibbonTab previousTab = this.PreviousTab;
      if (previousTab == null)
        return;
      this.ActiveTab = previousTab;
    }

    internal void OrbMouseDown() => this.OnOrbClicked(EventArgs.Empty);

    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    protected override void WndProc(ref Message m)
    {
      bool flag1 = false;
      if (WinApi.IsWindows && (this.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass || this.ActualBorderMode == RibbonWindowMode.NonClientAreaCustomDrawn) && m.Msg == 132)
      {
        Form form = this.FindForm();
        Rectangle rectangle;
        Rectangle r;
        if (this.RightToLeft == RightToLeft.No)
        {
          int right;
          if (!this.QuickAccessToolbar.Visible)
          {
            rectangle = this.OrbBounds;
            right = rectangle.Right;
          }
          else
          {
            rectangle = this.QuickAccessToolbar.Bounds;
            right = rectangle.Right;
          }
          int left = right;
          if (this.QuickAccessToolbar.Visible && this.QuickAccessToolbar.DropDownButtonVisible)
          {
            rectangle = this.QuickAccessToolbar.DropDownButton.Bounds;
            left = rectangle.Right;
          }
          r = Rectangle.FromLTRB(left, 0, this.Width, this.CaptionBarSize);
        }
        else
        {
          int left;
          if (!this.QuickAccessToolbar.Visible)
          {
            rectangle = this.OrbBounds;
            left = rectangle.Left;
          }
          else
          {
            rectangle = this.QuickAccessToolbar.Bounds;
            left = rectangle.Left;
          }
          int right = left;
          if (this.QuickAccessToolbar.Visible && this.QuickAccessToolbar.DropDownButtonVisible)
          {
            rectangle = this.QuickAccessToolbar.DropDownButton.Bounds;
            right = rectangle.Left;
          }
          r = Rectangle.FromLTRB(0, 0, right, this.CaptionBarSize);
        }
        Point point = new Point((int) WinApi.LoWord((int) m.LParam), (int) WinApi.HiWord((int) m.LParam));
        Point client = this.PointToClient(point);
        bool flag2 = false;
        if (this.CaptionButtonsVisible)
        {
          rectangle = this.CloseButton.Bounds;
          int num;
          if (!rectangle.Contains(client))
          {
            rectangle = this.MinimizeButton.Bounds;
            if (!rectangle.Contains(client))
            {
              rectangle = this.MaximizeRestoreButton.Bounds;
              num = rectangle.Contains(client) ? 1 : 0;
              goto label_19;
            }
          }
          num = 1;
label_19:
          flag2 = num != 0;
        }
        rectangle = this.RectangleToScreen(r);
        if (rectangle.Contains(point) && !flag2)
        {
          Point screen = this.PointToScreen(point);
          WinApi.SendMessage(form.Handle, 132, m.WParam, WinApi.MakeLParam(screen.X, screen.Y));
          m.Result = new IntPtr(-1);
          flag1 = true;
          this.CloseButton.SetSelected(false);
          this.MinimizeButton.SetSelected(false);
          this.MaximizeRestoreButton.SetSelected(false);
          this.OrbSelected = false;
          this.QuickAccessToolbar.DropDownButton.SetSelected(false);
        }
      }
      if (flag1)
        return;
      base.WndProc(ref m);
    }

    private void PaintOn(Graphics g, Rectangle clip)
    {
      try
      {
        if (WinApi.IsWindows && Environment.OSVersion.Platform == PlatformID.Win32NT)
        {
          g.SmoothingMode = SmoothingMode.AntiAlias;
          g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        }
        this.Renderer.OnRenderRibbonBackground(new RibbonRenderEventArgs(this, g, clip));
        this.Renderer.OnRenderRibbonCaptionBar(new RibbonRenderEventArgs(this, g, clip));
        if (this.CaptionButtonsVisible)
        {
          this.MinimizeButton.OnPaint((object) this, new RibbonElementPaintEventArgs(clip, g, RibbonElementSizeMode.Medium));
          this.MaximizeRestoreButton.OnPaint((object) this, new RibbonElementPaintEventArgs(clip, g, RibbonElementSizeMode.Medium));
          this.CloseButton.OnPaint((object) this, new RibbonElementPaintEventArgs(clip, g, RibbonElementSizeMode.Medium));
        }
        this.Renderer.OnRenderRibbonOrb(new RibbonRenderEventArgs(this, g, clip));
        this.QuickAccessToolbar.OnPaint((object) this, new RibbonElementPaintEventArgs(clip, g, RibbonElementSizeMode.Compact));
        foreach (RibbonContext context in (List<RibbonContext>) this.Contexts)
        {
          if (context.Visible || this.IsDesignMode())
            context.OnPaint((object) this, new RibbonElementPaintEventArgs(context.Bounds, g, RibbonElementSizeMode.None, (Control) this));
        }
        foreach (RibbonTab tab in (List<RibbonTab>) this.Tabs)
        {
          if (tab.Visible || this.IsDesignMode())
            tab.OnPaint((object) this, new RibbonElementPaintEventArgs(tab.TabBounds, g, RibbonElementSizeMode.None, (Control) this));
        }
        if (!this.OrbVisible || this._expanded || string.IsNullOrEmpty(this.OrbText))
          return;
        if (this.OrbStyle == RibbonOrbStyle.Office_2010 || this.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
        {
          Pen pen1 = new Pen(this.Theme.RendererColorTable.TabBorder);
          Graphics graphics = g;
          Pen pen2 = pen1;
          Rectangle rectangle = this.OrbBounds;
          int left = rectangle.Left;
          rectangle = this.OrbBounds;
          int bottom1 = rectangle.Bottom;
          rectangle = this.Bounds;
          int right = rectangle.Right;
          rectangle = this.OrbBounds;
          int bottom2 = rectangle.Bottom;
          graphics.DrawLine(pen2, left, bottom1, right, bottom2);
        }
        else
        {
          int orbStyle = (int) this.OrbStyle;
        }
      }
      catch
      {
      }
    }

    private void PaintDoubleBuffered(Graphics wndGraphics, Rectangle clip)
    {
      using (Bitmap bitmap = new Bitmap(this.Width, this.Height))
      {
        using (Graphics g = Graphics.FromImage((Image) bitmap))
        {
          g.Clear(Color.Black);
          this.PaintOn(g, clip);
          g.Flush();
          WinApi.BitBlt(wndGraphics.GetHdc(), clip.X, clip.Y, clip.Width, clip.Height, g.GetHdc(), clip.X, clip.Y, 13369376U);
        }
      }
    }

    internal bool IsDesignMode() => this.Site != null && this.Site.DesignMode;

    private void EnsureCustomThemeCreated(RibbonOrbStyle orbStyle, RibbonTheme theme)
    {
      if (this._theme != null || Theme.StandardThemeIsGlobal || this.UseAlwaysStandardTheme)
        return;
      this._theme = new Theme(orbStyle, theme);
    }

    private void RecalculateOrbTextSize()
    {
      if (string.IsNullOrEmpty(this.OrbText))
      {
        this._orbTextSize = Size.Empty;
      }
      else
      {
        try
        {
          using (Graphics graphics = this.CreateGraphics())
            this._orbTextSize = Size.Ceiling(graphics.MeasureString(this.OrbText, this.RibbonTabFont));
        }
        catch
        {
        }
      }
    }

    protected virtual void OnActiveTabChanged(EventArgs e)
    {
      if (this.ActiveTabChanged == null)
        return;
      this.ActiveTabChanged((object) this, e);
    }

    protected virtual void OnActualBorderModeChanged(EventArgs e)
    {
      if (this.ActualBorderModeChanged == null)
        return;
      this.ActualBorderModeChanged((object) this, e);
    }

    protected virtual void OnCaptionButtonsVisibleChanged(EventArgs e)
    {
      if (this.CaptionButtonsVisibleChanged == null)
        return;
      this.CaptionButtonsVisibleChanged((object) this, e);
    }

    protected virtual void OnExpandedChanged(EventArgs e)
    {
      if (this.ExpandedChanged == null)
        return;
      this.ExpandedChanged((object) this, e);
    }

    protected override void OnMouseDoubleClick(MouseEventArgs e)
    {
      base.OnMouseDoubleClick(e);
      if (this.OrbBounds.Contains(e.Location))
        this.OnOrbDoubleClicked(EventArgs.Empty);
      if (this.Tabs.Count == 1 && this.Tabs[0].Invisible)
        return;
      foreach (RibbonTab tab in (List<RibbonTab>) this.Tabs)
      {
        if (tab.Bounds.Contains(e.Location))
        {
          this.Minimized = !this.Minimized;
          break;
        }
      }
    }

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (this._updatingSuspended)
        return;
      if (this.Size != this._lastSizeMeasured)
        this.UpdateRegions(e.Graphics);
      this.PaintOn(e.Graphics, e.ClipRectangle);
    }

    protected override void OnClick(EventArgs e) => base.OnClick(e);

    protected override void OnMouseEnter(EventArgs e) => base.OnMouseEnter(e);

    protected override void OnMouseLeave(EventArgs e)
    {
      base.OnMouseLeave(e);
      this.SetSelectedTab((RibbonTab) null);
      if (!this.Expanded)
      {
        foreach (RibbonTab tab in (List<RibbonTab>) this.Tabs)
          tab.SetSelected(false);
      }
      this.Invalidate();
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      if (this.ActiveTab == null)
        return;
      bool flag = false;
      Rectangle rectangle = this.ActiveTab.TabContentBounds;
      if (!rectangle.Contains(e.X, e.Y))
      {
        if (this.OrbVisible)
        {
          rectangle = this.OrbBounds;
          if (rectangle.Contains(e.Location) && !this.OrbSelected)
          {
            this.OrbSelected = true;
            this.Invalidate(this.OrbBounds);
            goto label_15;
          }
        }
        if (this.QuickAccessToolbar.Visible)
        {
          rectangle = this.QuickAccessToolbar.Bounds;
          if (rectangle.Contains(e.Location))
            goto label_15;
        }
        foreach (RibbonTab tab in (List<RibbonTab>) this.Tabs)
        {
          rectangle = tab.TabBounds;
          if (rectangle.Contains(e.X, e.Y))
          {
            this.SetSelectedTab(tab);
            flag = true;
            tab.OnMouseMove(e);
          }
        }
      }
label_15:
      if (!flag)
        this.SetSelectedTab((RibbonTab) null);
      if (!this.OrbSelected)
        return;
      rectangle = this.OrbBounds;
      if (rectangle.Contains(e.Location))
        return;
      this.OrbSelected = false;
      this.Invalidate(this.OrbBounds);
    }

    protected override void OnMouseUp(MouseEventArgs e) => base.OnMouseUp(e);

    protected override void OnMouseDown(MouseEventArgs e)
    {
      if (this.ActiveTextBox != null)
        (this.ActiveTextBox as RibbonTextBox).EndEdit();
      base.OnMouseDown(e);
      if (this.OrbBounds.Contains(e.Location))
        this.OrbMouseDown();
      else
        this.TabHitTest(e.X, e.Y);
    }

    protected override void OnMouseWheel(MouseEventArgs e) => base.OnMouseWheel(e);

    internal void OnRibbonHostMouseMove(MouseEventArgs e) => this.OnMouseMove(e);

    protected override void OnSizeChanged(EventArgs e)
    {
      this.UpdateRegions();
      this.RemoveHelperControls();
      base.OnSizeChanged(e);
    }

    protected override void OnParentChanged(EventArgs e)
    {
      base.OnParentChanged(e);
      if (this.Site == null || !this.Site.DesignMode)
      {
        this.BorderMode = this.BorderMode;
        if (this.Parent is IRibbonForm)
          this.FormHelper.Ribbon = this;
      }
      if (this.Parent == null)
        return;
      Control parent = this.Parent;
      while (parent.Parent != null)
        parent = parent.Parent;
      if (!(parent is Form form))
        return;
      form.Deactivate += new EventHandler(this.parentForm_Deactivate);
    }

    private void parentForm_Deactivate(object sender, EventArgs e)
    {
      if (Form.ActiveForm != null)
        return;
      RibbonPopupManager.Dismiss(RibbonPopupManager.DismissReason.AppFocusChanged);
    }

    private void OnPopupRegistered(object sender, EventArgs args)
    {
      if (RibbonPopupManager.PopupCount != 1)
        return;
      this.SetUpHooks();
    }

    private void OnPopupUnregistered(object sender, EventArgs args)
    {
      if (RibbonPopupManager.PopupCount != 0 || this.Minimized && (!this.Minimized || this.Expanded))
        return;
      this.DisposeHooks();
    }

    protected override void OnVisibleChanged(EventArgs e)
    {
      base.OnVisibleChanged(e);
      if (!this.Visible)
        return;
      this.UpdateRegions();
      this.Invalidate();
    }

    private delegate void HandlerCallbackMethode();
  }
}
