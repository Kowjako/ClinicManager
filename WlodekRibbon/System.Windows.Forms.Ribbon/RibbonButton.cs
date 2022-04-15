// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonButton
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Text.RegularExpressions;

namespace System.Windows.Forms
{
  [Designer(typeof (RibbonButtonDesigner))]
  public class RibbonButton : RibbonItem, IContainsRibbonComponents
  {
    private const int arrowWidth = 5;
    private RibbonButtonStyle _style;
    private Image _smallImage;
    private Image _flashSmallImage;
    private Size _dropDownArrowSize;
    private Padding _dropDownMargin;
    private Point _lastMousePos;
    private RibbonArrowDirection _dropDownArrowDirection;
    private RibbonItem _selectedItem;
    private readonly Set<RibbonItem> _assignedHandlers;
    private Size _minimumSize;
    private Size _maximumSize;

    public event EventHandler DropDownShowing;

    public event RibbonButton.RibbonItemEventHandler DropDownItemClicked;

    public virtual void OnDropDownItemClicked(ref RibbonItemEventArgs e)
    {
      if (this.DropDownItemClicked == null)
        return;
      this.DropDownItemClicked((object) this, e);
    }

    public RibbonButton()
    {
      this._style = RibbonButtonStyle.Normal;
      this._dropDownArrowDirection = RibbonArrowDirection.Down;
      this._assignedHandlers = new Set<RibbonItem>();
      this.DropDownItems = new RibbonItemCollection();
      this.DropDownItems.SetOwnerItem((RibbonItem) this);
      this._dropDownArrowSize = new Size(5, 3);
      this._dropDownMargin = new Padding(6);
      this.Image = this.CreateImage(32);
      this.SmallImage = this.CreateImage(16);
      this.DrawDropDownIconsBar = true;
    }

    public RibbonButton(string text)
      : this()
    {
      this.Text = text;
    }

    public RibbonButton(Image smallImage)
      : this()
    {
      this.SmallImage = smallImage;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && RibbonDesigner.Current == null)
        this.RemoveHandlers();
      base.Dispose(disposing);
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RibbonItem SelectedItem
    {
      get
      {
        if (this._selectedItem == null)
          return (RibbonItem) null;
        if (this.DropDownItems.Contains(this._selectedItem))
          return this._selectedItem;
        this._selectedItem = (RibbonItem) null;
        return (RibbonItem) null;
      }
      set
      {
        if (!(value.GetType().BaseType == typeof (RibbonItem)))
          return;
        if (this.DropDownItems.Contains(value))
        {
          this._selectedItem = value;
        }
        else
        {
          this.DropDownItems.Add(value);
          this._selectedItem = value;
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string SelectedValue
    {
      get => this._selectedItem == null ? (string) null : this._selectedItem.Value;
      set
      {
        foreach (RibbonItem dropDownItem in (List<RibbonItem>) this.DropDownItems)
        {
          if (dropDownItem.Value == value)
            this._selectedItem = dropDownItem;
        }
      }
    }

    internal RibbonDropDown DropDown { get; private set; }

    [Category("Drop Down")]
    [DefaultValue(true)]
    [Description("Gets or sets if the icon bar on a drop down should be drawn")]
    public bool DrawDropDownIconsBar { get; set; }

    [DefaultValue(false)]
    [Category("Behavior")]
    [Description("Toggles the Checked property of the button when clicked")]
    public bool CheckOnClick { get; set; }

    [Category("Drop Down")]
    [DefaultValue(false)]
    [Description("Makes the DropDown resizable with a grip on the corner")]
    public bool DropDownResizable { get; set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle ImageBounds { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle TextBounds { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool DropDownVisible { get; private set; }

    [Browsable(false)]
    [DefaultValue(typeof (Size), "5, 3")]
    public Size DropDownArrowSize
    {
      get => this._dropDownArrowSize;
      set
      {
        this._dropDownArrowSize = value;
        this.NotifyOwnerRegionsChanged();
      }
    }

    [Category("Drop Down")]
    [DefaultValue(RibbonArrowDirection.Down)]
    public RibbonArrowDirection DropDownArrowDirection
    {
      get => this._dropDownArrowDirection;
      set
      {
        this._dropDownArrowDirection = value;
        this.NotifyOwnerRegionsChanged();
      }
    }

    [DefaultValue(RibbonButtonStyle.Normal)]
    [Category("Appearance")]
    [Description("Indicates the visual style of the button.")]
    public RibbonButtonStyle Style
    {
      get => this._style;
      set
      {
        this._style = value;
        if (this.Canvas is RibbonPopup || this.OwnerItem != null && this.OwnerItem.Canvas is RibbonPopup)
          this.DropDownArrowDirection = RibbonArrowDirection.Left;
        this.NotifyOwnerRegionsChanged();
      }
    }

    [Category("Drop Down")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public RibbonItemCollection DropDownItems { get; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Rectangle ButtonFaceBounds { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Rectangle DropDownBounds { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool DropDownSelected { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool DropDownPressed { get; private set; }

    [DefaultValue(null)]
    [Category("Appearance")]
    [Description("sets the image of the button when in large size mode.")]
    public virtual Image LargeImage
    {
      get => base.Image;
      set => base.Image = value;
    }

    [Browsable(false)]
    [Category("Appearance")]
    public override Image Image
    {
      get => base.Image;
      set => base.Image = value;
    }

    [DefaultValue(null)]
    [Category("Appearance")]
    [Description("sets the image of the button when in compact, medium or dropdown size modes.")]
    public virtual Image SmallImage
    {
      get => this._smallImage;
      set
      {
        if (this._smallImage == value)
          return;
        this._smallImage = value;
        this.NotifyOwnerRegionsChanged();
      }
    }

    [Category("Flash")]
    [DefaultValue(null)]
    public virtual Image FlashSmallImage
    {
      get => this._flashSmallImage;
      set
      {
        if (this._flashSmallImage == value)
          return;
        this._flashSmallImage = value;
      }
    }

    [DefaultValue(typeof (Size), "0, 0")]
    [Category("Appearance")]
    [Description("Sets the minimum size for this Item.  Only applies when in Large Size Mode.")]
    public Size MinimumSize
    {
      get => this._minimumSize;
      set
      {
        this._minimumSize = value;
        this.NotifyOwnerRegionsChanged();
      }
    }

    [DefaultValue(typeof (Size), "0, 0")]
    [Category("Appearance")]
    [Description("Sets the maximum size for this Item.  Only applies when in Large Size Mode.")]
    public Size MaximumSize
    {
      get => this._maximumSize;
      set
      {
        this._maximumSize = value;
        this.NotifyOwnerRegionsChanged();
      }
    }

    protected void SetDropDownMargin(Padding p) => this._dropDownMargin = p;

    public void PerformClick() => this.OnClick(EventArgs.Empty);

    private Image CreateImage(int size) => (Image) new Bitmap(size, size);

    protected virtual void CreateDropDown() => this.DropDown = new RibbonDropDown((RibbonItem) this, (IEnumerable<RibbonItem>) this.DropDownItems, this.Owner);

    internal override void SetPressed(bool pressed) => base.SetPressed(pressed);

    internal override void SetOwner(Ribbon owner)
    {
      base.SetOwner(owner);
      if (this.DropDownItems == null)
        return;
      this.DropDownItems.SetOwner(owner);
    }

    internal override void SetOwnerPanel(RibbonPanel ownerPanel)
    {
      base.SetOwnerPanel(ownerPanel);
      if (this.DropDownItems == null)
        return;
      this.DropDownItems.SetOwnerPanel(ownerPanel);
    }

    internal override void SetOwnerTab(RibbonTab ownerTab)
    {
      base.SetOwnerTab(ownerTab);
      if (this.DropDownItems == null)
        return;
      this.DropDownItems.SetOwnerTab(ownerTab);
    }

    internal override void SetOwnerItem(RibbonItem ownerItem) => base.SetOwnerItem(ownerItem);

    internal override void ClearOwner()
    {
      List<RibbonItem> ribbonItemList = this.DropDownItems == null ? (List<RibbonItem>) null : new List<RibbonItem>((IEnumerable<RibbonItem>) this.DropDownItems);
      base.ClearOwner();
      if (ribbonItemList == null)
        return;
      foreach (RibbonItem ribbonItem in ribbonItemList)
        ribbonItem.ClearOwner();
    }

    public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
    {
      if (this.Owner == null)
        return;
      this.OnPaintBackground(e);
      this.OnPaintImage(e);
      this.OnPaintText(e);
    }

    protected virtual void OnPaintText(RibbonElementPaintEventArgs e)
    {
      if (this.SizeMode == RibbonElementSizeMode.Compact)
        return;
      StringFormat format = StringFormatFactory.NearCenter();
      format.HotkeyPrefix = this.Owner.AltPressed || this.Owner.OrbDropDown.MenuItems.Contains((RibbonItem) this) ? HotkeyPrefix.Show : HotkeyPrefix.Hide;
      if (this.SizeMode == RibbonElementSizeMode.Large)
      {
        format.Alignment = StringAlignment.Center;
        format.LineAlignment = StringAlignment.Near;
      }
      if (this.Style == RibbonButtonStyle.DropDownListItem)
      {
        format.LineAlignment = StringAlignment.Near;
        this.Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(this.Owner, e.Graphics, e.Clip, (RibbonItem) this, this.Bounds, this.Text, format));
      }
      else
      {
        string text = this.Text;
        if (!string.IsNullOrEmpty(this.AltKey) && this.Text.Contains(this.AltKey))
          text = new Regex(Regex.Escape(this.AltKey), RegexOptions.IgnoreCase).Replace(this.Text.Replace("&", ""), "&" + this.AltKey, 1).Replace("&&", "&");
        this.Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(this.Owner, e.Graphics, e.Clip, (RibbonItem) this, this.TextBounds, text, format));
      }
    }

    private void OnPaintImage(RibbonElementPaintEventArgs e)
    {
      RibbonElementSizeMode nearestSize = this.GetNearestSize(e.Mode);
      if (this._showFlashImage)
      {
        if ((nearestSize != RibbonElementSizeMode.Large || this.FlashImage == null) && this.FlashSmallImage == null)
          return;
        this.Owner.Renderer.OnRenderRibbonItemImage(new RibbonItemBoundsEventArgs(this.Owner, e.Graphics, e.Clip, (RibbonItem) this, this.OnGetImageBounds(nearestSize, this.Bounds)));
      }
      else
      {
        if ((nearestSize != RibbonElementSizeMode.Large || this.Image == null) && this.SmallImage == null)
          return;
        this.Owner.Renderer.OnRenderRibbonItemImage(new RibbonItemBoundsEventArgs(this.Owner, e.Graphics, e.Clip, (RibbonItem) this, this.OnGetImageBounds(nearestSize, this.Bounds)));
      }
    }

    private void OnPaintBackground(RibbonElementPaintEventArgs e) => this.Owner.Renderer.OnRenderRibbonItem(new RibbonItemRenderEventArgs(this.Owner, e.Graphics, e.Clip, (RibbonItem) this));

    public override void SetBounds(Rectangle bounds)
    {
      base.SetBounds(bounds);
      RibbonElementSizeMode nearestSize = this.GetNearestSize(this.SizeMode);
      this.ImageBounds = this.OnGetImageBounds(nearestSize, bounds);
      this.TextBounds = this.OnGetTextBounds(nearestSize, bounds);
      if (this.Style != RibbonButtonStyle.SplitDropDown)
        return;
      this.DropDownBounds = this.OnGetDropDownBounds(nearestSize, bounds);
      this.ButtonFaceBounds = this.OnGetButtonFaceBounds(nearestSize, bounds);
    }

    internal virtual Rectangle OnGetImageBounds(
      RibbonElementSizeMode sMode,
      Rectangle bounds)
    {
      if (sMode == RibbonElementSizeMode.Large)
      {
        if (this.Image == null)
          return new Rectangle(this.ContentBounds.Location, new Size(32, 32));
        int left = this.Bounds.Left;
        Rectangle bounds1 = this.Bounds;
        int num = (bounds1.Width - this.Image.Width) / 2;
        int x = left + num;
        bounds1 = this.Bounds;
        int y = bounds1.Top + this.Owner.ItemMargin.Top;
        int width = this.Image.Width;
        int height = this.Image.Height;
        return new Rectangle(x, y, width, height);
      }
      if (this.SmallImage == null || this.SmallImage.PixelFormat == PixelFormat.Undefined)
        return new Rectangle(this.ContentBounds.Location, new Size(0, 0));
      int x1 = this.Bounds.Left + this.Owner.ItemMargin.Left;
      Rectangle bounds2 = this.Bounds;
      int top = bounds2.Top;
      bounds2 = this.Bounds;
      int num1 = (bounds2.Height - this.SmallImage.Height) / 2;
      int y1 = top + num1;
      int width1 = this.SmallImage.Width;
      int height1 = this.SmallImage.Height;
      return new Rectangle(x1 - 3, y1, width1, height1);
    }

    internal virtual Rectangle OnGetTextBounds(
      RibbonElementSizeMode sMode,
      Rectangle bounds)
    {
      int width = this.ImageBounds.Width;
      int height = this.ImageBounds.Height;
      if (sMode == RibbonElementSizeMode.Large)
      {
        int left = this.Bounds.Left + this.Owner.ItemMargin.Left;
        int top = this.Bounds.Top + this.Owner.ItemMargin.Top + height;
        Rectangle bounds1 = this.Bounds;
        int right1 = bounds1.Right;
        Padding itemMargin = this.Owner.ItemMargin;
        int right2 = itemMargin.Right;
        int right3 = right1 - right2;
        bounds1 = this.Bounds;
        int bottom1 = bounds1.Bottom;
        itemMargin = this.Owner.ItemMargin;
        int bottom2 = itemMargin.Bottom;
        int bottom3 = bottom1 - bottom2;
        return Rectangle.FromLTRB(left, top, right3, bottom3);
      }
      int num1 = this.Style == RibbonButtonStyle.Normal || this.Style == RibbonButtonStyle.DropDownListItem ? 0 : this._dropDownMargin.Horizontal;
      int num2 = sMode == RibbonElementSizeMode.DropDown ? this.Owner.ItemImageToTextSpacing : 0;
      int num3 = this.Bounds.Left + width + this.Owner.ItemMargin.Horizontal;
      Padding itemMargin1 = this.Owner.ItemMargin;
      int left1 = itemMargin1.Left;
      int left2 = num3 + left1 + num2;
      int top1 = this.Bounds.Top;
      itemMargin1 = this.Owner.ItemMargin;
      int top2 = itemMargin1.Top;
      int top3 = top1 + top2;
      int right = this.Bounds.Right - num1;
      int bottom4 = this.Bounds.Bottom;
      itemMargin1 = this.Owner.ItemMargin;
      int bottom5 = itemMargin1.Bottom;
      int bottom6 = bottom4 - bottom5;
      return Rectangle.FromLTRB(left2, top3, right, bottom6);
    }

    internal virtual Rectangle OnGetDropDownBounds(
      RibbonElementSizeMode sMode,
      Rectangle bounds)
    {
      Rectangle rectangle = Rectangle.FromLTRB(bounds.Right - this._dropDownMargin.Horizontal - 2, bounds.Top, bounds.Right, bounds.Bottom);
      switch (sMode)
      {
        case RibbonElementSizeMode.Overflow:
        case RibbonElementSizeMode.Large:
          return Rectangle.FromLTRB(bounds.Left, bounds.Top + this.Image.Height + this.Owner.ItemMargin.Vertical, bounds.Right, bounds.Bottom);
        case RibbonElementSizeMode.Compact:
        case RibbonElementSizeMode.Medium:
        case RibbonElementSizeMode.DropDown:
          return rectangle;
        default:
          return Rectangle.Empty;
      }
    }

    internal virtual Rectangle OnGetButtonFaceBounds(
      RibbonElementSizeMode sMode,
      Rectangle bounds)
    {
      Rectangle.FromLTRB(bounds.Right - this._dropDownMargin.Horizontal - 2, bounds.Top, bounds.Right, bounds.Bottom);
      switch (sMode)
      {
        case RibbonElementSizeMode.Overflow:
        case RibbonElementSizeMode.Large:
          return Rectangle.FromLTRB(bounds.Left, bounds.Top, bounds.Right, this.DropDownBounds.Top);
        case RibbonElementSizeMode.Compact:
        case RibbonElementSizeMode.Medium:
        case RibbonElementSizeMode.DropDown:
          return Rectangle.FromLTRB(bounds.Left, bounds.Top, this.DropDownBounds.Left, bounds.Bottom);
        default:
          return Rectangle.Empty;
      }
    }

    public static Size MeasureStringLargeSize(Graphics g, string text, Font font)
    {
      if (string.IsNullOrEmpty(text))
        return Size.Empty;
      Size size1 = g.MeasureString(text, font).ToSize();
      string[] strArray = text.Split(' ');
      string empty = string.Empty;
      int width1 = size1.Width;
      for (int index = 0; index < strArray.Length; ++index)
      {
        if (strArray[index].Length > empty.Length)
          empty = strArray[index];
      }
      if (strArray.Length <= 1)
        return g.MeasureString(text, font).ToSize();
      int val1 = size1.Width / 2;
      SizeF sizeF = g.MeasureString(empty, font);
      int width2 = sizeF.ToSize().Width;
      int width3 = Math.Max(val1, width2) + 1;
      sizeF = g.MeasureString(text, font, width3);
      Size size2 = sizeF.ToSize();
      return new Size(size2.Width, size2.Height);
    }

    public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
    {
      if (!this.Visible && !this.Owner.IsDesignMode())
      {
        this.SetLastMeasuredSize(new Size(0, 0));
        return this.LastMeasuredSize;
      }
      RibbonElementSizeMode nearestSize = this.GetNearestSize(e.SizeMode);
      int horizontal = this.Owner.ItemMargin.Horizontal;
      int vertical = this.Owner.ItemMargin.Vertical;
      int val2 = this.OwnerPanel == null ? 0 : this.OwnerPanel.ContentBounds.Height - this.Owner.ItemPadding.Vertical;
      Size size1 = this.SmallImage != null ? this.SmallImage.Size : Size.Empty;
      Size size2 = this.Image != null ? this.Image.Size : Size.Empty;
      Size empty = Size.Empty;
      int width1;
      int height1;
      switch (nearestSize)
      {
        case RibbonElementSizeMode.Overflow:
        case RibbonElementSizeMode.Large:
          Size size3 = RibbonButton.MeasureStringLargeSize(e.Graphics, this.Text, this.Owner.Font);
          if (!string.IsNullOrEmpty(this.Text))
          {
            width1 = horizontal + Math.Max(size3.Width + 1, size2.Width);
            height1 = Math.Max(0, val2);
            break;
          }
          width1 = horizontal + size2.Width;
          height1 = vertical + size2.Height;
          break;
        case RibbonElementSizeMode.Compact:
          width1 = horizontal + size1.Width;
          height1 = vertical + size1.Height;
          break;
        case RibbonElementSizeMode.Medium:
          Size size4 = Size.Ceiling(e.Graphics.MeasureString(this.Text, this.Owner.Font));
          if (!string.IsNullOrEmpty(this.Text))
            horizontal += size4.Width + 1;
          width1 = horizontal + (size1.Width + this.Owner.ItemMargin.Horizontal);
          height1 = vertical + Math.Max(size4.Height, size1.Height);
          break;
        case RibbonElementSizeMode.DropDown:
          Size size5 = Size.Ceiling(e.Graphics.MeasureString(this.Text, this.Owner.Font));
          if (!string.IsNullOrEmpty(this.Text))
            horizontal += size5.Width + 1;
          width1 = horizontal + (size1.Width + this.Owner.ItemMargin.Horizontal + this.Owner.ItemImageToTextSpacing);
          height1 = vertical + Math.Max(size5.Height, size1.Height);
          break;
        default:
          throw new ArgumentException("SizeMode not supported: " + (object) e.SizeMode);
      }
      switch (this.Style)
      {
        case RibbonButtonStyle.DropDown:
        case RibbonButtonStyle.SplitDropDown:
          width1 += 5 + this._dropDownMargin.Horizontal;
          break;
      }
      if (nearestSize == RibbonElementSizeMode.Large)
      {
        Size size6;
        if (this.MinimumSize.Height > 0 && height1 < this.MinimumSize.Height)
        {
          size6 = this.MinimumSize;
          height1 = size6.Height;
        }
        size6 = this.MinimumSize;
        if (size6.Width > 0)
        {
          int num = width1;
          size6 = this.MinimumSize;
          int width2 = size6.Width;
          if (num < width2)
          {
            size6 = this.MinimumSize;
            width1 = size6.Width;
          }
        }
        size6 = this.MaximumSize;
        if (size6.Height > 0)
        {
          int num = height1;
          size6 = this.MaximumSize;
          int height2 = size6.Height;
          if (num > height2)
          {
            size6 = this.MaximumSize;
            height1 = size6.Height;
          }
        }
        size6 = this.MaximumSize;
        if (size6.Width > 0)
        {
          int num = width1;
          size6 = this.MaximumSize;
          int width3 = size6.Width;
          if (num > width3)
          {
            size6 = this.MaximumSize;
            width1 = size6.Width;
          }
        }
      }
      this.SetLastMeasuredSize(new Size(width1, height1));
      return this.LastMeasuredSize;
    }

    internal void SetDropDownPressed(bool pressed) => throw new NotSupportedException();

    internal void SetDropDownSelected(bool selected) => throw new NotSupportedException();

    public void ShowDropDown()
    {
      if (this.Style == RibbonButtonStyle.Normal)
      {
        if (this.DropDown == null)
          return;
        RibbonPopupManager.DismissChildren((RibbonPopup) this.DropDown, RibbonPopupManager.DismissReason.NewPopup);
      }
      else
      {
        if (this.Style == RibbonButtonStyle.DropDown)
          this.SetPressed(true);
        else
          this.DropDownPressed = true;
        this.OnDropDownShowing(EventArgs.Empty);
        if (this.DropDownItems.Count == 0)
        {
          if (this.DropDown == null)
            return;
          RibbonPopupManager.DismissChildren((RibbonPopup) this.DropDown, RibbonPopupManager.DismissReason.NewPopup);
        }
        else
        {
          this.AssignHandlers();
          this.CreateDropDown();
          this.DropDown.MouseEnter += new EventHandler(this.DropDown_MouseEnter);
          this.DropDown.Closed += new EventHandler(this.DropDown_Closed);
          this.DropDown.ShowSizingGrip = this.DropDownResizable;
          this.DropDown.DrawIconsBar = this.DrawDropDownIconsBar;
          Control canvas = this.Canvas;
          Point downMenuLocation = this.OnGetDropDownMenuLocation();
          Size dropDownMenuSize = this.OnGetDropDownMenuSize();
          if (!dropDownMenuSize.IsEmpty)
            this.DropDown.MinimumSize = dropDownMenuSize;
          this.SetDropDownVisible(true);
          this.DropDown.SelectionService = this.GetService(typeof (ISelectionService)) as ISelectionService;
          this.DropDown.Show(downMenuLocation);
        }
      }
    }

    private void DropDownItem_Click(object sender, EventArgs e)
    {
      this._selectedItem = sender as RibbonItem;
      RibbonItemEventArgs e1 = new RibbonItemEventArgs(sender as RibbonItem);
      this.OnDropDownItemClicked(ref e1);
    }

    private void AssignHandlers()
    {
      foreach (RibbonItem dropDownItem in (List<RibbonItem>) this.DropDownItems)
      {
        if (!this._assignedHandlers.Contains(dropDownItem))
        {
          dropDownItem.Click += new EventHandler(this.DropDownItem_Click);
          this._assignedHandlers.Add(dropDownItem);
        }
      }
    }

    private void RemoveHandlers()
    {
      if (this.DropDown != null)
      {
        this.DropDown.MouseEnter -= new EventHandler(this.DropDown_MouseEnter);
        this.DropDown.Closed -= new EventHandler(this.DropDown_Closed);
      }
      foreach (RibbonItem assignedHandler in this._assignedHandlers)
        assignedHandler.Click -= new EventHandler(this.DropDownItem_Click);
      this._assignedHandlers.Clear();
    }

    private void DropDown_MouseEnter(object sender, EventArgs e)
    {
      this.SetSelected(true);
      this.RedrawItem();
    }

    internal virtual Point OnGetDropDownMenuLocation()
    {
      Point empty = Point.Empty;
      Point screen;
      if (this.Canvas is RibbonDropDown)
      {
        Control canvas = this.Canvas;
        Rectangle bounds = this.Bounds;
        int right = bounds.Right;
        bounds = this.Bounds;
        int top = bounds.Top;
        Point p = new Point(right, top);
        screen = canvas.PointToScreen(p);
      }
      else
      {
        Control canvas = this.Canvas;
        Rectangle bounds = this.Bounds;
        int left = bounds.Left;
        bounds = this.Bounds;
        int bottom = bounds.Bottom;
        Point p = new Point(left, bottom);
        screen = canvas.PointToScreen(p);
      }
      return screen;
    }

    internal virtual Size OnGetDropDownMenuSize() => Size.Empty;

    private void DropDown_Closed(object sender, EventArgs e)
    {
      this.SetPressed(false);
      this.DropDownPressed = false;
      this.SetDropDownVisible(false);
      this.SetSelected(false);
      this.DropDownSelected = false;
      this.RedrawItem();
    }

    private void IgnoreDeactivation()
    {
      if (this.Canvas is RibbonPanelPopup)
        (this.Canvas as RibbonPanelPopup).IgnoreNextClickDeactivation();
      if (!(this.Canvas is RibbonDropDown))
        return;
      (this.Canvas as RibbonDropDown).IgnoreNextClickDeactivation();
    }

    public void CloseDropDown()
    {
      if (this.DropDown != null)
      {
        RibbonPopupManager.Dismiss((RibbonPopup) this.DropDown, RibbonPopupManager.DismissReason.NewPopup);
        this.RemoveHandlers();
        this.DropDown = (RibbonDropDown) null;
      }
      this.SetDropDownVisible(false);
    }

    public override string ToString() => string.Format("{1}: {0}", (object) this.Text, (object) this.GetType().Name);

    internal void SetDropDownVisible(bool visible) => this.DropDownVisible = visible;

    public void OnDropDownShowing(EventArgs e)
    {
      if (this.DropDownShowing == null)
        return;
      this.DropDownShowing((object) this, e);
    }

    public override void OnCanvasChanged(EventArgs e)
    {
      base.OnCanvasChanged(e);
      if (!(this.Canvas is RibbonDropDown))
        return;
      this.DropDownArrowDirection = RibbonArrowDirection.Left;
    }

    protected override bool ClosesDropDownAt(Point p)
    {
      if (this.Style == RibbonButtonStyle.DropDown)
        return false;
      return this.Style != RibbonButtonStyle.SplitDropDown || this.ButtonFaceBounds.Contains(p);
    }

    internal override void SetSizeMode(RibbonElementSizeMode sizeMode)
    {
      if (sizeMode == RibbonElementSizeMode.Overflow)
        base.SetSizeMode(RibbonElementSizeMode.Large);
      else
        base.SetSizeMode(sizeMode);
    }

    internal override void SetSelected(bool selected)
    {
      base.SetSelected(selected);
      this.SetPressed(false);
    }

    public override void OnMouseDown(MouseEventArgs e)
    {
      if (!this.Enabled)
        return;
      if ((this.DropDownSelected || this.Style == RibbonButtonStyle.DropDown) && this.DropDownItems.Count > 0)
      {
        if (!this.DropDownVisible)
        {
          this.DropDownPressed = true;
          this.ShowDropDown();
        }
        else
        {
          this.DropDownPressed = false;
          this.CloseDropDown();
        }
      }
      base.OnMouseDown(e);
    }

    public override void OnMouseUp(MouseEventArgs e) => base.OnMouseUp(e);

    public override void OnMouseMove(MouseEventArgs e)
    {
      if (!this.Enabled)
        return;
      if (this.Style == RibbonButtonStyle.SplitDropDown)
      {
        int num1 = this.DropDownSelected ? 1 : 0;
        this.DropDownSelected = this.DropDownBounds.Contains(e.X, e.Y);
        int num2 = this.DropDownSelected ? 1 : 0;
        if (num1 != num2)
          this.RedrawItem();
        int num3 = this.DropDownSelected ? 1 : 0;
      }
      this._lastMousePos = new Point(e.X, e.Y);
      base.OnMouseMove(e);
    }

    public override void OnMouseLeave(MouseEventArgs e)
    {
      base.OnMouseLeave(e);
      this.DropDownSelected = false;
    }

    public override void OnClick(EventArgs e)
    {
      if (this.Style != RibbonButtonStyle.Normal && this.Style != RibbonButtonStyle.DropDownListItem && !this.ButtonFaceBounds.Contains(this._lastMousePos))
        return;
      if (this.CheckOnClick)
        this.Checked = !this.Checked;
      base.OnClick(e);
    }

    public IEnumerable<RibbonItem> GetItems() => (IEnumerable<RibbonItem>) this.DropDownItems;

    public IEnumerable<Component> GetAllChildComponents() => (IEnumerable<Component>) this.DropDownItems.ToArray();

    public delegate void RibbonItemEventHandler(object sender, RibbonItemEventArgs e);
  }
}
