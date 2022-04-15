// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonButtonList
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace System.Windows.Forms
{
  [Designer(typeof (RibbonButtonListDesigner))]
  public sealed class RibbonButtonList : 
    RibbonItem,
    IContainsSelectableRibbonItems,
    IScrollableRibbonItem,
    IContainsRibbonComponents
  {
    private int _itemsInLargeMode;
    private int _itemsInMediumMode;
    private Size _ItemsInDropwDownMode;
    private Rectangle _contentBounds;
    private int _controlButtonsWidth;
    private RibbonElementSizeMode _buttonsSizeMode;
    private int _jumpDownSize;
    private int _jumpUpSize;
    private int _offset;
    private RibbonDropDown _dropDown;
    private bool _dropDownVisible;
    private Rectangle _thumbBounds;
    private int _scrollValue;
    private Rectangle fullContentBounds;
    private int _thumbOffset;
    private bool _avoidNextThumbMeasure;
    private RibbonItem _selectedItem;

    public event RibbonButtonList.RibbonItemEventHandler ButtonItemClicked;

    public event RibbonButtonList.RibbonItemEventHandler DropDownItemClicked;

    public RibbonButtonList()
    {
      this.Buttons = new RibbonButtonCollection(this);
      this.DropDownItems = new RibbonItemCollection();
      this.DropDownItems.SetOwnerItem((RibbonItem) this);
      this._controlButtonsWidth = 16;
      this._itemsInLargeMode = 7;
      this._itemsInMediumMode = 3;
      this._ItemsInDropwDownMode = new Size(7, 5);
      this._buttonsSizeMode = RibbonElementSizeMode.Large;
      this.ScrollType = RibbonButtonList.ListScrollType.UpDownButtons;
    }

    public RibbonButtonList(IEnumerable<RibbonButton> buttons)
      : this(buttons, (IEnumerable<RibbonItem>) null)
    {
    }

    public RibbonButtonList(
      IEnumerable<RibbonButton> buttons,
      IEnumerable<RibbonItem> dropDownItems)
      : this()
    {
      if (buttons != null)
      {
        this.Buttons.AddRange((IEnumerable<RibbonItem>) new List<RibbonButton>(buttons).ToArray());
        foreach (RibbonItem button in buttons)
          button.Click += new EventHandler(this.item_Click);
      }
      if (dropDownItems == null)
        return;
      this.DropDownItems.AddRange(dropDownItems);
      foreach (RibbonItem dropDownItem in dropDownItems)
        dropDownItem.Click += new EventHandler(this.item_Click);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        foreach (RibbonItem button in (List<RibbonItem>) this.Buttons)
          button.Click -= new EventHandler(this.item_Click);
        foreach (RibbonItem dropDownItem in (List<RibbonItem>) this.DropDownItems)
          dropDownItem.Click -= new EventHandler(this.item_Click);
      }
      base.Dispose(disposing);
    }

    [Category("Layout")]
    [Description("If activated, buttons will flow to bottom inside the list")]
    public bool FlowToBottom { get; set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle ScrollBarBounds
    {
      get
      {
        Rectangle rectangle = this.ButtonUpBounds;
        int left = rectangle.Left;
        rectangle = this.ButtonUpBounds;
        int top = rectangle.Top;
        rectangle = this.ButtonDownBounds;
        int right = rectangle.Right;
        rectangle = this.ButtonDownBounds;
        int bottom = rectangle.Bottom;
        return Rectangle.FromLTRB(left, top, right, bottom);
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ScrollBarEnabled { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RibbonButtonList.ListScrollType ScrollType { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public double ScrolledPercent
    {
      get
      {
        Rectangle contentBounds = this.ContentBounds;
        double num1 = (double) contentBounds.Top - (double) this.fullContentBounds.Top;
        double height1 = (double) this.fullContentBounds.Height;
        contentBounds = this.ContentBounds;
        double height2 = (double) contentBounds.Height;
        double num2 = height1 - height2;
        return num1 / num2;
      }
      set
      {
        this._avoidNextThumbMeasure = true;
        this.ScrollTo(-Convert.ToInt32((double) (this.fullContentBounds.Height - this.ContentBounds.Height) * value));
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int ScrollMinimum => this.ScrollType == RibbonButtonList.ListScrollType.Scrollbar ? this.ButtonUpBounds.Bottom : 0;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int ScrollMaximum
    {
      get
      {
        if (this.ScrollType != RibbonButtonList.ListScrollType.Scrollbar)
          return 0;
        Rectangle rectangle = this.ButtonDownBounds;
        int top = rectangle.Top;
        rectangle = this.ThumbBounds;
        int height = rectangle.Height;
        return top - height;
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int ScrollValue
    {
      get => this._scrollValue;
      set
      {
        if (value > this.ScrollMaximum || value < this.ScrollMinimum)
          throw new ArgumentOutOfRangeException(nameof (ScrollValue), "Scroll value must exist between ScrollMinimum and Scroll Maximum");
        this._thumbBounds.Y = value;
        this.ScrolledPercent = (double) (value - this.ScrollMinimum) / (double) (this.ScrollMaximum - this.ScrollMinimum);
        this._scrollValue = value;
      }
    }

    private void RedrawScroll()
    {
      if (this.Canvas == null)
        return;
      this.Canvas.Invalidate(Rectangle.FromLTRB(this.ButtonDownBounds.X, this.ButtonUpBounds.Y, this.ButtonDownBounds.Right, this.ButtonDownBounds.Bottom));
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ThumbSelected { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ThumbPressed { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle ThumbBounds => this._thumbBounds;

    [Browsable(false)]
    public bool ButtonDropDownPresent => this.ButtonDropDownBounds.Height > 0;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public RibbonItemCollection DropDownItems { get; }

    [Category("Appearance")]
    public RibbonElementSizeMode ButtonsSizeMode
    {
      get => this._buttonsSizeMode;
      set
      {
        this._buttonsSizeMode = value;
        if (this.Owner == null)
          return;
        this.Owner.OnRegionsChanged();
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ButtonUpEnabled { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ButtonDownEnabled { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ButtonDropDownSelected { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ButtonDropDownPressed { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ButtonDownSelected { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ButtonDownPressed { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ButtonUpSelected { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ButtonUpPressed { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Rectangle ContentBounds => this._contentBounds;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle ButtonUpBounds { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle ButtonDownBounds { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle ButtonDropDownBounds { get; private set; }

    [DefaultValue(16)]
    [Browsable(false)]
    public int ControlButtonsWidth
    {
      get => this._controlButtonsWidth;
      set
      {
        this._controlButtonsWidth = value;
        if (this.Owner == null)
          return;
        this.Owner.OnRegionsChanged();
      }
    }

    [DefaultValue(7)]
    [Category("Appearance")]
    public int ItemsWideInLargeMode
    {
      get => this._itemsInLargeMode;
      set
      {
        this._itemsInLargeMode = value;
        if (this.Owner == null)
          return;
        this.Owner.OnRegionsChanged();
      }
    }

    [DefaultValue(3)]
    [Category("Appearance")]
    public int ItemsWideInMediumMode
    {
      get => this._itemsInMediumMode;
      set
      {
        this._itemsInMediumMode = value;
        if (this.Owner == null)
          return;
        this.Owner.OnRegionsChanged();
      }
    }

    [Category("Appearance")]
    public Size ItemsSizeInDropwDownMode
    {
      get => this._ItemsInDropwDownMode;
      set
      {
        this._ItemsInDropwDownMode = value;
        if (this.Owner == null)
          return;
        this.Owner.OnRegionsChanged();
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public RibbonButtonCollection Buttons { get; }

    private void IgnoreDeactivation()
    {
      if (this.Canvas is RibbonPanelPopup)
        (this.Canvas as RibbonPanelPopup).IgnoreNextClickDeactivation();
      if (!(this.Canvas is RibbonDropDown))
        return;
      (this.Canvas as RibbonDropDown).IgnoreNextClickDeactivation();
    }

    private void RedrawControlButtons()
    {
      if (this.Canvas == null)
        return;
      if (this.ScrollType == RibbonButtonList.ListScrollType.Scrollbar)
        this.Canvas.Invalidate(this.ScrollBarBounds);
      else
        this.Canvas.Invalidate(Rectangle.FromLTRB(this.ButtonUpBounds.Left, this.ButtonUpBounds.Top, this.ButtonDropDownBounds.Right, this.ButtonDropDownBounds.Bottom));
    }

    private void ScrollOffset(int amount) => this.ScrollTo(this._offset + amount);

    private void ScrollTo(int offset)
    {
      int num = this.ContentBounds.Height - this.fullContentBounds.Height;
      if (offset < num)
        offset = num;
      this._offset = offset;
      this.SetBounds(this.Bounds);
      this.RedrawItem();
    }

    public void ScrollDown() => this.ScrollOffset(-(this._jumpDownSize + 1));

    public void ScrollUp() => this.ScrollOffset(this._jumpDownSize + 1);

    public void ShowDropDown()
    {
      if (this.DropDownItems.Count == 0)
      {
        this.SetPressed(false);
      }
      else
      {
        this.IgnoreDeactivation();
        this._dropDown = new RibbonDropDown((RibbonItem) this, (IEnumerable<RibbonItem>) this.DropDownItems, this.Owner)
        {
          ShowSizingGrip = true
        };
        Point screen = this.Canvas.PointToScreen(new Point(this.Bounds.Left, this.Bounds.Top));
        this.SetDropDownVisible(true);
        this._dropDown.Show(screen);
      }
    }

    private void dropDown_FormClosed(object sender, FormClosedEventArgs e) => this.SetDropDownVisible(false);

    public void CloseDropDown()
    {
      RibbonDropDown dropDown = this._dropDown;
      this.SetDropDownVisible(false);
    }

    internal void SetDropDownVisible(bool visible) => this._dropDownVisible = visible;

    public override void OnCanvasChanged(EventArgs e)
    {
      base.OnCanvasChanged(e);
      if (this.Canvas is RibbonDropDown)
        this.ScrollType = RibbonButtonList.ListScrollType.Scrollbar;
      else
        this.ScrollType = RibbonButtonList.ListScrollType.UpDownButtons;
    }

    protected override bool ClosesDropDownAt(Point p)
    {
      if (this.ButtonDropDownBounds.Contains(p) || this.ButtonDownBounds.Contains(p) || this.ButtonUpBounds.Contains(p))
        return false;
      return this.ScrollType != RibbonButtonList.ListScrollType.Scrollbar || !this.ScrollBarBounds.Contains(p);
    }

    internal override void SetOwner(Ribbon owner)
    {
      base.SetOwner(owner);
      this.Buttons.SetOwner(owner);
      this.DropDownItems.SetOwner(owner);
    }

    internal override void SetOwnerPanel(RibbonPanel ownerPanel)
    {
      base.SetOwnerPanel(ownerPanel);
      this.Buttons.SetOwnerPanel(ownerPanel);
      this.DropDownItems.SetOwnerPanel(ownerPanel);
    }

    internal override void SetOwnerTab(RibbonTab ownerTab)
    {
      base.SetOwnerTab(ownerTab);
      this.Buttons.SetOwnerTab(ownerTab);
      this.DropDownItems.SetOwnerTab(this.OwnerTab);
    }

    internal override void SetOwnerItem(RibbonItem ownerItem) => base.SetOwnerItem(ownerItem);

    internal override void ClearOwner()
    {
      List<RibbonItem> ribbonItemList = new List<RibbonItem>(this.Buttons.Count + this.DropDownItems.Count);
      ribbonItemList.AddRange((IEnumerable<RibbonItem>) this.Buttons);
      ribbonItemList.AddRange((IEnumerable<RibbonItem>) this.DropDownItems);
      base.ClearOwner();
      foreach (RibbonItem ribbonItem in ribbonItemList)
        ribbonItem.ClearOwner();
    }

    public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
    {
      this.Owner.Renderer.OnRenderRibbonItem(new RibbonItemRenderEventArgs(this.Owner, e.Graphics, e.Clip, (RibbonItem) this));
      if (e.Mode == RibbonElementSizeMode.Compact)
        return;
      Region clip = e.Graphics.Clip;
      Region region = new Region(clip.GetBounds(e.Graphics));
      region.Intersect(this.ContentBounds);
      e.Graphics.SetClip(region.GetBounds(e.Graphics));
      foreach (RibbonButton button in (List<RibbonItem>) this.Buttons)
      {
        if (!button.Bounds.IsEmpty)
          button.OnPaint((object) this, new RibbonElementPaintEventArgs(button.Bounds, e.Graphics, this.ButtonsSizeMode));
      }
      e.Graphics.SetClip(clip.GetBounds(e.Graphics));
    }

    public override void SetBounds(Rectangle bounds)
    {
      base.SetBounds(bounds);
      Rectangle rectangle1;
      if (this.ScrollType != RibbonButtonList.ListScrollType.Scrollbar)
      {
        int num1 = 3;
        int num2 = bounds.Height / num1;
        int controlButtonsWidth = this._controlButtonsWidth;
        this.ButtonUpBounds = Rectangle.FromLTRB(bounds.Right - controlButtonsWidth, bounds.Top, bounds.Right, bounds.Top + num2);
        int left1 = this.ButtonUpBounds.Left;
        int bottom1 = this.ButtonUpBounds.Bottom;
        int right1 = bounds.Right;
        rectangle1 = this.ButtonUpBounds;
        int bottom2 = rectangle1.Bottom + num2;
        this.ButtonDownBounds = Rectangle.FromLTRB(left1, bottom1, right1, bottom2);
        if (num1 == 2)
        {
          this.ButtonDropDownBounds = Rectangle.Empty;
        }
        else
        {
          rectangle1 = this.ButtonDownBounds;
          int left2 = rectangle1.Left;
          rectangle1 = this.ButtonDownBounds;
          int bottom3 = rectangle1.Bottom;
          int right2 = bounds.Right;
          int bottom4 = bounds.Bottom + 1;
          this.ButtonDropDownBounds = Rectangle.FromLTRB(left2, bottom3, right2, bottom4);
        }
        this._thumbBounds.Location = Point.Empty;
      }
      else
      {
        int width1 = this.ThumbBounds.Width;
        int width2 = this.ThumbBounds.Width;
        this.ButtonUpBounds = Rectangle.FromLTRB(bounds.Right - width1, bounds.Top + 1, bounds.Right, bounds.Top + width2 + 1);
        this.ButtonDownBounds = Rectangle.FromLTRB(this.ButtonUpBounds.Left, bounds.Bottom - width2, bounds.Right, bounds.Bottom);
        this.ButtonDropDownBounds = Rectangle.Empty;
        this._thumbBounds.X = this.ButtonUpBounds.Left;
      }
      int left3 = bounds.Left + 1;
      int top1 = bounds.Top + 1;
      rectangle1 = this.ButtonUpBounds;
      int right3 = rectangle1.Left - 1;
      int bottom5 = bounds.Bottom - 1;
      this._contentBounds = Rectangle.FromLTRB(left3, top1, right3, bottom5);
      this.ButtonUpEnabled = this._offset < 0;
      if (!this.ButtonUpEnabled)
        this._offset = 0;
      this.ButtonDownEnabled = false;
      rectangle1 = this.ContentBounds;
      int num3 = rectangle1.Left + 1;
      rectangle1 = this.ContentBounds;
      int num4 = rectangle1.Top + 1 + this._offset;
      int num5 = num4;
      int num6 = num4;
      foreach (RibbonItem button in (List<RibbonItem>) this.Buttons)
        button.SetBounds(Rectangle.Empty);
      Rectangle rectangle2;
      for (int index = 0; index < this.Buttons.Count && this.Buttons[index] is RibbonButton button1; ++index)
      {
        int num7 = num3;
        Size lastMeasuredSize = button1.LastMeasuredSize;
        int width3 = lastMeasuredSize.Width;
        int num8 = num7 + width3;
        rectangle2 = this.ContentBounds;
        int right4 = rectangle2.Right;
        if (num8 > right4)
        {
          rectangle2 = this.ContentBounds;
          num3 = rectangle2.Left + 1;
          num4 = num5 + 1;
        }
        RibbonButton ribbonButton = button1;
        int x = num3;
        int y = num4;
        lastMeasuredSize = button1.LastMeasuredSize;
        int width4 = lastMeasuredSize.Width;
        lastMeasuredSize = button1.LastMeasuredSize;
        int height = lastMeasuredSize.Height;
        Rectangle bounds1 = new Rectangle(x, y, width4, height);
        ribbonButton.SetBounds(bounds1);
        rectangle2 = button1.Bounds;
        num3 = rectangle2.Right + 1;
        int val1 = num5;
        rectangle2 = button1.Bounds;
        int bottom6 = rectangle2.Bottom;
        num5 = Math.Max(val1, bottom6);
        rectangle2 = button1.Bounds;
        int bottom7 = rectangle2.Bottom;
        rectangle2 = this.ContentBounds;
        int bottom8 = rectangle2.Bottom;
        if (bottom7 > bottom8)
          this.ButtonDownEnabled = true;
        rectangle2 = button1.Bounds;
        this._jumpDownSize = rectangle2.Height;
        rectangle2 = button1.Bounds;
        this._jumpUpSize = rectangle2.Height;
      }
      int num9 = num5 + 1;
      double num10 = (double) (num9 - num6);
      rectangle2 = this.ContentBounds;
      double height1 = (double) rectangle2.Height;
      if (num10 > height1 && num10 != 0.0)
      {
        double num11 = height1 / num10;
        rectangle2 = this.ButtonDownBounds;
        int top2 = rectangle2.Top;
        rectangle2 = this.ButtonUpBounds;
        int bottom9 = rectangle2.Bottom;
        double num12 = (double) (top2 - bottom9);
        double num13 = num12;
        double num14 = Math.Ceiling(num11 * num13);
        if (num14 < 30.0)
          num14 = num12 < 30.0 ? num12 : 30.0;
        this._thumbBounds.Height = Convert.ToInt32(num14);
        rectangle2 = this.ContentBounds;
        int left4 = rectangle2.Left;
        int top3 = num6;
        rectangle2 = this.ContentBounds;
        int right5 = rectangle2.Right;
        int bottom10 = num9;
        this.fullContentBounds = Rectangle.FromLTRB(left4, top3, right5, bottom10);
        this.ScrollBarEnabled = true;
        this.UpdateThumbPos();
      }
      else
        this.ScrollBarEnabled = false;
    }

    private void UpdateThumbPos()
    {
      if (this._avoidNextThumbMeasure)
      {
        this._avoidNextThumbMeasure = false;
      }
      else
      {
        this._thumbBounds.Y = double.IsInfinity(this.ScrolledPercent) ? this.ScrollMinimum : this.ScrollMinimum + Convert.ToInt32(Math.Ceiling((double) (this.ScrollMaximum - this.ScrollMinimum) * this.ScrolledPercent));
        if (this._thumbBounds.Y <= this.ScrollMaximum)
          return;
        this._thumbBounds.Y = this.ScrollMaximum;
      }
    }

    public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
    {
      if (!this.Visible && !this.Owner.IsDesignMode())
      {
        this.SetLastMeasuredSize(new Size(0, 0));
        return this.LastMeasuredSize;
      }
      int num1 = 0;
      switch (e.SizeMode)
      {
        case RibbonElementSizeMode.Compact:
          num1 = 0;
          break;
        case RibbonElementSizeMode.Medium:
          num1 = this.ItemsWideInMediumMode;
          break;
        case RibbonElementSizeMode.Large:
          num1 = this.ItemsWideInLargeMode;
          break;
        case RibbonElementSizeMode.DropDown:
          num1 = this.ItemsSizeInDropwDownMode.Width;
          break;
      }
      int val2 = this.OwnerPanel.ContentBounds.Height - this.Owner.ItemPadding.Vertical - 4;
      int num2 = 0;
      int num3 = 1;
      int num4 = 0;
      int num5 = 0;
      bool flag = true;
      foreach (RibbonButton button in (List<RibbonItem>) this.Buttons)
      {
        Size size = button.MeasureSize((object) this, new RibbonElementMeasureSizeEventArgs(e.Graphics, this.ButtonsSizeMode));
        if (flag)
          num3 += size.Width + 1;
        num4 = button.LastMeasuredSize.Height;
        num5 += num4;
        if (++num2 == num1)
          flag = false;
      }
      if (e.SizeMode == RibbonElementSizeMode.DropDown)
        val2 = num4 * this.ItemsSizeInDropwDownMode.Height;
      this._thumbBounds = !ScrollBarRenderer.IsSupported ? new Rectangle(Point.Empty, new Size(16, 16)) : new Rectangle(Point.Empty, ScrollBarRenderer.GetSizeBoxSize(e.Graphics, ScrollBarState.Normal));
      this.SetLastMeasuredSize(new Size(Math.Max(0, num3 + this.ControlButtonsWidth), Math.Max(0, val2)));
      return this.LastMeasuredSize;
    }

    internal override void SetSizeMode(RibbonElementSizeMode sizeMode)
    {
      base.SetSizeMode(sizeMode);
      foreach (RibbonItem button in (List<RibbonItem>) this.Buttons)
        button.SetSizeMode(this.ButtonsSizeMode);
    }

    public override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      if (this.ButtonDownPressed && this.ButtonDownSelected && this.ButtonDownEnabled)
        this.ScrollOffset(-1);
      if (this.ButtonUpPressed && this.ButtonUpSelected && this.ButtonUpEnabled)
        this.ScrollOffset(1);
      int num1 = this.ButtonUpSelected ? 1 : 0;
      bool buttonDownSelected = this.ButtonDownSelected;
      bool dropDownSelected = this.ButtonDropDownSelected;
      bool thumbSelected = this.ThumbSelected;
      this.ButtonUpSelected = this.ButtonUpBounds.Contains(e.Location);
      this.ButtonDownSelected = this.ButtonDownBounds.Contains(e.Location);
      this.ButtonDropDownSelected = this.ButtonDropDownBounds.Contains(e.Location);
      this.ThumbSelected = this._thumbBounds.Contains(e.Location) && this.ScrollType == RibbonButtonList.ListScrollType.Scrollbar && this.ScrollBarEnabled;
      int num2 = this.ButtonUpSelected ? 1 : 0;
      if (num1 != num2 || buttonDownSelected != this.ButtonDownSelected || dropDownSelected != this.ButtonDropDownSelected || thumbSelected != this.ThumbSelected)
        this.RedrawControlButtons();
      if (!this.ThumbPressed)
        return;
      int num3 = e.Y - this._thumbOffset;
      if (num3 < this.ScrollMinimum)
        num3 = this.ScrollMinimum;
      else if (num3 > this.ScrollMaximum)
        num3 = this.ScrollMaximum;
      this.ScrollValue = num3;
      this.RedrawScroll();
    }

    public override void OnMouseLeave(MouseEventArgs e)
    {
      base.OnMouseLeave(e);
      int num = this.ButtonUpSelected || this.ButtonDownSelected ? 1 : (this.ButtonDropDownSelected ? 1 : 0);
      this.ButtonUpSelected = false;
      this.ButtonDownSelected = false;
      this.ButtonDropDownSelected = false;
      if (num == 0)
        return;
      this.RedrawControlButtons();
    }

    public override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      if (this.ButtonDownSelected || this.ButtonUpSelected || this.ButtonDropDownSelected)
        this.IgnoreDeactivation();
      if (this.ButtonDownSelected && this.ButtonDownEnabled)
      {
        this.ButtonDownPressed = true;
        this.ScrollDown();
      }
      if (this.ButtonUpSelected && this.ButtonUpEnabled)
      {
        this.ButtonUpPressed = true;
        this.ScrollUp();
      }
      if (this.ButtonDropDownSelected)
      {
        this.ButtonDropDownPressed = true;
        this.ShowDropDown();
      }
      if (this.ThumbSelected)
      {
        this.ThumbPressed = true;
        this._thumbOffset = e.Y - this._thumbBounds.Y;
      }
      if (this.ScrollType != RibbonButtonList.ListScrollType.Scrollbar || !this.ScrollBarBounds.Contains(e.Location))
        return;
      int y1 = e.Y;
      Rectangle rectangle = this.ButtonUpBounds;
      int bottom = rectangle.Bottom;
      if (y1 < bottom)
        return;
      int y2 = e.Y;
      rectangle = this.ButtonDownBounds;
      int y3 = rectangle.Y;
      if (y2 > y3)
        return;
      rectangle = this.ThumbBounds;
      if (rectangle.Contains(e.Location))
        return;
      rectangle = this.ButtonDownBounds;
      if (rectangle.Contains(e.Location))
        return;
      rectangle = this.ButtonUpBounds;
      if (rectangle.Contains(e.Location))
        return;
      int y4 = e.Y;
      rectangle = this.ThumbBounds;
      int y5 = rectangle.Y;
      if (y4 < y5)
      {
        rectangle = this.ContentBounds;
        this.ScrollOffset(rectangle.Height);
      }
      else
      {
        rectangle = this.ContentBounds;
        this.ScrollOffset(-rectangle.Height);
      }
    }

    public override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);
      this.ButtonDownPressed = false;
      this.ButtonUpPressed = false;
      this.ButtonDropDownPressed = false;
      this.ThumbPressed = false;
    }

    public override void OnClick(EventArgs e)
    {
      if (this.Canvas is RibbonPopup)
        return;
      base.OnClick(e);
    }

    public void OnDropDownItemClicked(ref RibbonItemEventArgs e)
    {
      if (this.DropDownItemClicked == null)
        return;
      this.DropDownItemClicked((object) e.Item, e);
    }

    public void OnButtonItemClicked(ref RibbonItemEventArgs e)
    {
      if (this.ButtonItemClicked == null)
        return;
      this.ButtonItemClicked((object) e.Item, e);
    }

    internal void item_Click(object sender, EventArgs e)
    {
      this._selectedItem = sender as RibbonItem;
      RibbonItemEventArgs e1 = new RibbonItemEventArgs(this._selectedItem);
      if (this.DropDownItems.Contains(this._selectedItem))
        this.OnDropDownItemClicked(ref e1);
      else
        this.OnButtonItemClicked(ref e1);
    }

    public IEnumerable<RibbonItem> GetItems() => (IEnumerable<RibbonItem>) this.Buttons;

    public Rectangle GetContentBounds() => this.ContentBounds;

    public IEnumerable<Component> GetAllChildComponents()
    {
      List<Component> componentList = new List<Component>((IEnumerable<Component>) this.Buttons.ToArray());
      componentList.AddRange((IEnumerable<Component>) this.DropDownItems.ToArray());
      return (IEnumerable<Component>) componentList;
    }

    public enum ListScrollType
    {
      UpDownButtons,
      Scrollbar,
    }

    public delegate void RibbonItemEventHandler(object sender, RibbonItemEventArgs e);
  }
}
