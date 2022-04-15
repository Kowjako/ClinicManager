// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonDropDown
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;

namespace System.Windows.Forms
{
  [ToolboxItem(false)]
  public class RibbonDropDown : RibbonPopup, IScrollableRibbonItem
  {
    private bool _showSizingGrip;
    private bool _ignoreNext;
    private bool _resizing;
    private Point _resizeOrigin;
    private Size _resizeSize;
    private Rectangle _thumbBounds;
    private Rectangle _fullContentBounds;
    private int _scrollValue;
    private bool _avoidNextThumbMeasure;
    private int _jumpDownSize;
    private int _jumpUpSize;
    private int _offset;
    private int _thumbOffset;

    private RibbonDropDown()
    {
      this.DoubleBuffered = true;
      this.DrawIconsBar = true;
    }

    internal RibbonDropDown(
      RibbonItem parentItem,
      IEnumerable<RibbonItem> items,
      Ribbon ownerRibbon)
      : this(parentItem, items, ownerRibbon, RibbonElementSizeMode.DropDown)
    {
    }

    internal RibbonDropDown(
      RibbonItem parentItem,
      IEnumerable<RibbonItem> items,
      Ribbon ownerRibbon,
      RibbonElementSizeMode measuringSize)
      : this()
    {
      this.Items = items;
      this.OwnerRibbon = ownerRibbon;
      this.SizingGripHeight = 12;
      this.ParentItem = parentItem;
      this.Sensor = new RibbonMouseSensor((Control) this, this.OwnerRibbon, items);
      this.MeasuringSize = measuringSize;
      this.ScrollBarSize = 16;
      if (this.Items != null)
      {
        foreach (RibbonItem ribbonItem in this.Items)
        {
          ribbonItem.SetSizeMode(RibbonElementSizeMode.DropDown);
          ribbonItem.SetCanvas((Control) this);
          if (ribbonItem is RibbonHost)
            ((RibbonHost) ribbonItem).ClientMouseMove += new MouseEventHandler(this.OnRibbonHostMouseMove);
        }
      }
      this.UpdateSize();
    }

    public int DropDownMaxHeight { get; set; }

    public int ScrollBarSize { get; set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Control Canvas => (Control) this;

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
    public double ScrolledPercent
    {
      get => (double) this._fullContentBounds.Height > (double) this.ContentBounds.Height ? ((double) this.ContentBounds.Top - (double) this._fullContentBounds.Top) / ((double) this._fullContentBounds.Height - (double) this.ContentBounds.Height) : 0.0;
      set
      {
        this._avoidNextThumbMeasure = true;
        this.ScrollTo(-Convert.ToInt32((double) (this._fullContentBounds.Height - this.ContentBounds.Height) * value));
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int ScrollMinimum => this.ButtonUpBounds.Bottom;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int ScrollMaximum
    {
      get
      {
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
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ButtonUpEnabled { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ButtonDownEnabled { get; private set; }

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
    public Rectangle ContentBounds { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ButtonUpPressed { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle ButtonUpBounds { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle ButtonDownBounds { get; private set; }

    public bool DrawIconsBar { get; set; }

    internal ISelectionService SelectionService { get; set; }

    public Rectangle SizingGripBounds { get; private set; }

    public RibbonElementSizeMode MeasuringSize { get; set; }

    public RibbonItem ParentItem { get; }

    public RibbonMouseSensor Sensor { get; }

    public Ribbon OwnerRibbon { get; }

    public IEnumerable<RibbonItem> Items { get; }

    public bool ShowSizingGrip
    {
      get => this._showSizingGrip;
      set
      {
        this._showSizingGrip = value;
        this.UpdateSize();
      }
    }

    [DefaultValue(12)]
    public int SizingGripHeight { get; set; }

    public void SetBounds()
    {
      this.SizingGripBounds = !this.ShowSizingGrip ? Rectangle.Empty : Rectangle.FromLTRB(this.ClientSize.Width - this.SizingGripHeight, this.ClientSize.Height - this.SizingGripHeight, this.ClientSize.Width, this.ClientSize.Height);
      Rectangle rectangle1;
      if (this.ScrollBarEnabled)
      {
        int scrollBarSize1 = this.ScrollBarSize;
        int scrollBarSize2 = this.ScrollBarSize;
        this._thumbBounds.Width = this.ScrollBarSize;
        Rectangle bounds = this.Bounds;
        int x = bounds.Right - scrollBarSize1 - 1;
        bounds = this.Bounds;
        int y1 = bounds.Top + this.OwnerRibbon.DropDownMargin.Top;
        int width1 = scrollBarSize1;
        int height1 = scrollBarSize2;
        this.ButtonUpBounds = new Rectangle(x, y1, width1, height1);
        rectangle1 = this.ButtonUpBounds;
        int left1 = rectangle1.Left;
        rectangle1 = this.Bounds;
        int num = rectangle1.Height - scrollBarSize2;
        rectangle1 = this.SizingGripBounds;
        int height2 = rectangle1.Height;
        int y2 = num - height2 - this.OwnerRibbon.DropDownMargin.Bottom - 1;
        int width2 = scrollBarSize1;
        int height3 = scrollBarSize2;
        this.ButtonDownBounds = new Rectangle(left1, y2, width2, height3);
        ref Rectangle local = ref this._thumbBounds;
        rectangle1 = this.ButtonUpBounds;
        int left2 = rectangle1.Left;
        local.X = left2;
        this.ButtonUpEnabled = this._offset < 0;
        if (!this.ButtonUpEnabled)
          this._offset = 0;
        this.ButtonDownEnabled = false;
      }
      int num1 = this.ScrollBarEnabled ? this.ScrollBarSize : 0;
      int width3 = this.ClientSize.Width;
      Padding dropDownMargin1 = this.OwnerRibbon.DropDownMargin;
      int horizontal = dropDownMargin1.Horizontal;
      int width4 = Math.Max(0, width3 - horizontal - num1);
      dropDownMargin1 = this.OwnerRibbon.DropDownMargin;
      int left3 = dropDownMargin1.Left;
      dropDownMargin1 = this.OwnerRibbon.DropDownMargin;
      int top1 = dropDownMargin1.Top;
      rectangle1 = this.Bounds;
      int right = rectangle1.Right - num1 - this.OwnerRibbon.DropDownMargin.Right;
      rectangle1 = this.Bounds;
      int bottom1 = rectangle1.Bottom;
      Padding dropDownMargin2 = this.OwnerRibbon.DropDownMargin;
      int bottom2 = dropDownMargin2.Bottom;
      int num2 = bottom1 - bottom2;
      rectangle1 = this.SizingGripBounds;
      int height4 = rectangle1.Height;
      int bottom3 = num2 - height4;
      this.ContentBounds = Rectangle.FromLTRB(left3, top1, right, bottom3);
      dropDownMargin2 = this.OwnerRibbon.DropDownMargin;
      int num3 = dropDownMargin2.Top + this._offset;
      int left4 = this.OwnerRibbon.DropDownMargin.Left;
      int bottom4 = num3;
      int top2 = num3;
      foreach (RibbonItem ribbonItem in this.Items)
        ribbonItem.SetBounds(Rectangle.Empty);
      foreach (RibbonItem ribbonItem in this.Items)
      {
        int y = bottom4;
        ribbonItem.SetBounds(new Rectangle(left4, y, width4, ribbonItem.LastMeasuredSize.Height));
        bottom4 = y + ribbonItem.LastMeasuredSize.Height;
        Rectangle bounds = ribbonItem.Bounds;
        this._jumpDownSize = bounds.Height;
        bounds = ribbonItem.Bounds;
        this._jumpUpSize = bounds.Height;
      }
      this._fullContentBounds = Rectangle.FromLTRB(this.ContentBounds.Left, top2, this.ContentBounds.Right, bottom4);
      int height5 = this.Bounds.Height;
      Rectangle rectangle2 = this.ContentBounds;
      if (rectangle2.Height < this._fullContentBounds.Height)
      {
        int height6 = this._fullContentBounds.Height;
        rectangle2 = this.ContentBounds;
        int height7 = rectangle2.Height;
        double num4;
        if (height6 <= height7)
        {
          num4 = 0.0;
        }
        else
        {
          rectangle2 = this.ContentBounds;
          num4 = (double) rectangle2.Height / (double) this._fullContentBounds.Height;
        }
        rectangle2 = this.ButtonDownBounds;
        int top3 = rectangle2.Top;
        rectangle2 = this.ButtonUpBounds;
        int bottom5 = rectangle2.Bottom;
        double num5 = (double) (top3 - bottom5);
        double num6 = num5;
        double num7 = Math.Ceiling(num4 * num6);
        if (num7 < 30.0)
          num7 = num5 < 30.0 ? num5 : 30.0;
        this.ButtonUpEnabled = this._offset < 0;
        this.ButtonDownEnabled = this.ScrollMaximum > -this._offset;
        this._thumbBounds.Height = Convert.ToInt32(num7);
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

    public void ScrollDown()
    {
      if (!this.ScrollBarEnabled)
        return;
      this.ScrollOffset(-(this._jumpDownSize + 1));
    }

    public void ScrollUp()
    {
      if (!this.ScrollBarEnabled)
        return;
      this.ScrollOffset(this._jumpUpSize + 1);
    }

    private void ScrollOffset(int amount) => this.ScrollTo(this._offset + amount);

    private void ScrollTo(int offset)
    {
      if (!this.ScrollBarEnabled)
        return;
      int num = this.ContentBounds.Height - this._fullContentBounds.Height;
      if (offset < num)
        offset = num;
      this._offset = offset;
      this.SetBounds();
      this.Invalidate();
    }

    public void IgnoreNextClickDeactivation() => this._ignoreNext = true;

    private void UpdateSize()
    {
      int num1 = this.OwnerRibbon.DropDownMargin.Vertical;
      int num2 = 0;
      int num3 = 0;
      using (Graphics graphics = this.CreateGraphics())
      {
        foreach (RibbonItem ribbonItem in this.Items)
        {
          Size size = ribbonItem.MeasureSize((object) this, new RibbonElementMeasureSizeEventArgs(graphics, this.MeasuringSize));
          num1 += size.Height;
          num2 = Math.Max(num2, size.Width + this.OwnerRibbon.DropDownMargin.Horizontal);
          if (ribbonItem is IScrollableRibbonItem)
            num3 += size.Height;
        }
      }
      Rectangle workingArea;
      if (this.DropDownMaxHeight <= 0 || this.DropDownMaxHeight >= num1 || this._resizing)
      {
        int num4 = num1 + (this.ShowSizingGrip ? this.SizingGripHeight + 2 : 0) + 1;
        workingArea = Screen.PrimaryScreen.WorkingArea;
        int height = workingArea.Height;
        if (num4 <= height)
          goto label_18;
      }
      if (this.DropDownMaxHeight > 0)
      {
        num1 = this.DropDownMaxHeight;
      }
      else
      {
        workingArea = Screen.PrimaryScreen.WorkingArea;
        num1 = workingArea.Height - ((this.ShowSizingGrip ? this.SizingGripHeight + 2 : 0) + 1);
      }
      num2 += this.ScrollBarSize;
      this._thumbBounds.Width = this.ScrollBarSize;
      this.ScrollBarEnabled = true;
label_18:
      if (!this._resizing)
        this.Size = new Size(num2, num1 + (this.ShowSizingGrip ? this.SizingGripHeight + 2 : 0));
      if (this.WrappedDropDown != null)
        this.WrappedDropDown.Size = this.Size;
      this.SetBounds();
    }

    private void IgnoreDeactivation()
    {
      if (this.Canvas is RibbonPanelPopup)
        (this.Canvas as RibbonPanelPopup).IgnoreNextClickDeactivation();
      if (!(this.Canvas is RibbonDropDown))
        return;
      (this.Canvas as RibbonDropDown).IgnoreNextClickDeactivation();
    }

    protected override void OnOpening(CancelEventArgs e)
    {
      base.OnOpening(e);
      this.SetBounds();
    }

    protected override void OnShowed(EventArgs e)
    {
      base.OnShowed(e);
      if (!(this.ParentItem is RibbonButton))
        return;
      foreach (RibbonItem ribbonItem in this.Items)
        ribbonItem.SetSelected(false);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      if (this.Cursor == Cursors.SizeNWSE)
      {
        this._resizeOrigin = new Point(e.X, e.Y);
        this._resizeSize = this.Size;
        this._resizing = true;
      }
      if (this.ButtonDownSelected || this.ButtonUpSelected)
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
      if (this.ThumbSelected)
      {
        this.ThumbPressed = true;
        this._thumbOffset = e.Y - this._thumbBounds.Y;
      }
      if (!this.ScrollBarBounds.Contains(e.Location) || e.Y < this.ButtonUpBounds.Bottom || e.Y > this.ButtonDownBounds.Y || this.ThumbBounds.Contains(e.Location) || this.ButtonDownBounds.Contains(e.Location) || this.ButtonUpBounds.Contains(e.Location))
        return;
      if (e.Y < this.ThumbBounds.Y)
        this.ScrollOffset(this.Bounds.Height);
      else
        this.ScrollOffset(-this.Bounds.Height);
    }

    protected override void OnMouseClick(MouseEventArgs e) => base.OnMouseClick(e);

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      if (this.ShowSizingGrip && this.SizingGripBounds.Contains(e.X, e.Y))
        this.Cursor = Cursors.SizeNWSE;
      else if (this.Cursor == Cursors.SizeNWSE)
        this.Cursor = Cursors.Default;
      Rectangle rectangle;
      if (this._resizing)
      {
        int num1 = e.X - this._resizeOrigin.X;
        int num2 = e.Y - this._resizeOrigin.Y;
        int width = this._resizeSize.Width + num1;
        int height1 = this._resizeSize.Height + num2;
        if (width != this.Width || height1 != this.Height)
        {
          this.Size = new Size(width, height1);
          if (this.WrappedDropDown != null)
            this.WrappedDropDown.Size = this.Size;
          int num3 = this.Bounds.Height - this.OwnerRibbon.DropDownMargin.Vertical;
          rectangle = this.SizingGripBounds;
          int height2 = rectangle.Height;
          int num4 = num3 - height2;
          if (num4 < this._fullContentBounds.Height)
          {
            this.ScrollBarEnabled = true;
            if (-this._offset + num4 > this._fullContentBounds.Height)
              this._offset = num4 - this._fullContentBounds.Height;
          }
          else
            this.ScrollBarEnabled = false;
          this.SetBounds();
          this.Invalidate();
        }
      }
      if (this.ButtonDownPressed && this.ButtonDownSelected && this.ButtonDownEnabled)
        this.ScrollOffset(-1);
      if (this.ButtonUpPressed && this.ButtonUpSelected && this.ButtonUpEnabled)
        this.ScrollOffset(1);
      int num5 = this.ButtonUpSelected ? 1 : 0;
      bool buttonDownSelected = this.ButtonDownSelected;
      bool thumbSelected = this.ThumbSelected;
      rectangle = this.ButtonUpBounds;
      this.ButtonUpSelected = rectangle.Contains(e.Location);
      rectangle = this.ButtonDownBounds;
      this.ButtonDownSelected = rectangle.Contains(e.Location);
      this.ThumbSelected = this._thumbBounds.Contains(e.Location) && this.ScrollBarEnabled;
      int num6 = this.ButtonUpSelected ? 1 : 0;
      if (num5 != num6 || buttonDownSelected != this.ButtonDownSelected || thumbSelected != this.ThumbSelected)
        this.Invalidate();
      if (!this.ThumbPressed)
        return;
      int num7 = e.Y - this._thumbOffset;
      if (num7 < this.ScrollMinimum)
        num7 = this.ScrollMinimum;
      else if (num7 > this.ScrollMaximum)
        num7 = this.ScrollMaximum;
      this.ScrollValue = num7;
      this.Invalidate();
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);
      this.ButtonDownPressed = false;
      this.ButtonUpPressed = false;
      this.ThumbPressed = false;
      if (this._resizing)
        this._resizing = false;
      else if (this._ignoreNext)
      {
        this._ignoreNext = false;
      }
      else
      {
        if (RibbonDesigner.Current == null)
          return;
        this.Close();
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      this.OwnerRibbon.Renderer.OnRenderDropDownBackground(new RibbonCanvasEventArgs(this.OwnerRibbon, e.Graphics, new Rectangle(Point.Empty, this.ClientSize), (Control) this, (object) this.ParentItem));
      RectangleF clipBounds = e.Graphics.ClipBounds;
      RectangleF rect = clipBounds;
      rect.Y = (float) this.OwnerRibbon.DropDownMargin.Top;
      ref RectangleF local = ref rect;
      Rectangle rectangle = this.Bounds;
      int bottom = rectangle.Bottom;
      rectangle = this.SizingGripBounds;
      int height = rectangle.Height;
      double num = (double) (bottom - height - this.OwnerRibbon.DropDownMargin.Vertical);
      local.Height = (float) num;
      e.Graphics.SetClip(rect);
      foreach (RibbonItem ribbonItem in this.Items)
      {
        if (ribbonItem is RibbonButton && !(ribbonItem is RibbonDescriptionMenuItem) || ribbonItem is RibbonSeparator && ((RibbonSeparator) ribbonItem).DropDownWidth == RibbonSeparatorDropDownWidth.Partial)
          this.OwnerRibbon.Renderer.OnRenderDropDownDropDownImageSeparator(ribbonItem, new RibbonCanvasEventArgs(this.OwnerRibbon, e.Graphics, new Rectangle(Point.Empty, this.ClientSize), (Control) this, (object) this.ParentItem));
        if (ribbonItem.Bounds.IntersectsWith(this.ContentBounds))
          ribbonItem.OnPaint((object) this, new RibbonElementPaintEventArgs(ribbonItem.Bounds, e.Graphics, RibbonElementSizeMode.DropDown));
      }
      if (this.ScrollBarEnabled)
        this.OwnerRibbon.Renderer.OnRenderScrollbar(e.Graphics, (Control) this, this.OwnerRibbon);
      e.Graphics.SetClip(clipBounds);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      base.OnMouseLeave(e);
      foreach (RibbonItem ribbonItem in this.Items)
        ribbonItem.SetSelected(false);
    }

    private void OnRibbonHostMouseMove(object sender, MouseEventArgs e) => this.OnMouseMove(e);
  }
}
