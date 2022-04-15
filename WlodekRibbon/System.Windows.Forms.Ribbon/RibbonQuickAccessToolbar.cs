// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonQuickAccessToolbar
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
  public class RibbonQuickAccessToolbar : 
    RibbonItem,
    IContainsSelectableRibbonItems,
    IContainsRibbonComponents
  {
    private readonly RibbonQuickAccessToolbarItemCollection _items;
    private bool _dropDownButtonVisible;
    private RibbonMouseSensor _sensor;
    private RibbonButton _dropDownButton;

    internal RibbonQuickAccessToolbar(Ribbon ownerRibbon)
    {
      if (ownerRibbon == null)
        throw new ArgumentNullException(nameof (ownerRibbon));
      this.SetOwner(ownerRibbon);
      this._dropDownButton = new RibbonButton();
      this._dropDownButton.SetOwner(ownerRibbon);
      this._dropDownButton.SmallImage = this.CreateDropDownButtonImage();
      this._dropDownButton.Style = RibbonButtonStyle.DropDown;
      this.Margin = new Padding(9);
      this.Padding = new Padding(3, 0, 0, 0);
      this._items = new RibbonQuickAccessToolbarItemCollection(this);
      this._sensor = new RibbonMouseSensor((Control) ownerRibbon, ownerRibbon, (IEnumerable<RibbonItem>) this.Items);
      this._dropDownButtonVisible = true;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (RibbonDesigner.Current == null)
        {
          try
          {
            foreach (Component component in (List<RibbonItem>) this._items)
              component.Dispose();
          }
          catch (InvalidOperationException ex)
          {
            if (!this.IsOpenInVisualStudioDesigner())
              throw;
          }
          this._dropDownButton.Dispose();
          this._sensor.Dispose();
        }
      }
      base.Dispose(disposing);
    }

    private Image CreateDropDownButtonImage()
    {
      Bitmap bitmap = new Bitmap(7, 7);
      RibbonProfessionalRenderer renderer = this.Owner.Renderer as RibbonProfessionalRenderer;
      Color c1 = Color.Navy;
      Color c2 = Color.White;
      if (renderer != null)
      {
        c1 = renderer.ColorTable.Arrow;
        c2 = renderer.ColorTable.ArrowLight;
      }
      using (Graphics g = Graphics.FromImage((Image) bitmap))
      {
        this.DrawDropDownButtonArrow(g, c2, 0, 1);
        this.DrawDropDownButtonArrow(g, c1, 0, 0);
      }
      return (Image) bitmap;
    }

    private void DrawDropDownButtonArrow(Graphics g, Color c, int x, int y)
    {
      using (Pen pen = new Pen(c))
      {
        using (SolidBrush solidBrush = new SolidBrush(c))
        {
          g.DrawLine(pen, x, y, x + 4, y);
          g.FillPolygon((Brush) solidBrush, new Point[3]
          {
            new Point(x, y + 3),
            new Point(x + 5, y + 3),
            new Point(x + 2, y + 6)
          });
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override string Name
    {
      get => base.Name;
      set => base.Name = value;
    }

    [Description("Shows or hides the dropdown button of the toolbar")]
    [Category("Drop Down")]
    [DefaultValue(true)]
    public bool DropDownButtonVisible
    {
      get => this._dropDownButtonVisible;
      set
      {
        this._dropDownButtonVisible = value;
        this.Owner.OnRegionsChanged();
      }
    }

    [Browsable(false)]
    internal Rectangle SuperBounds
    {
      get
      {
        Rectangle bounds = this.Bounds;
        int left = bounds.Left - this.Padding.Horizontal;
        bounds = this.Bounds;
        int top = bounds.Top;
        bounds = this.DropDownButton.Bounds;
        int right = bounds.Right;
        bounds = this.Bounds;
        int bottom = bounds.Bottom;
        return Rectangle.FromLTRB(left, top, right, bottom);
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RibbonButton DropDownButton => this._dropDownButton;

    [Description("The drop down items of the dropdown button of the toolbar")]
    [Category("Drop Down")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public RibbonItemCollection DropDownButtonItems => this.DropDownButton.DropDownItems;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Padding Padding { get; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Padding Margin { get; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool MenuButtonVisible { get; set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RibbonMouseSensor Sensor => this._sensor;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public RibbonQuickAccessToolbarItemCollection Items
    {
      get
      {
        if (this.DropDownButtonVisible)
        {
          if (!this._items.Contains((RibbonItem) this.DropDownButton))
            this._items.Add((RibbonItem) this.DropDownButton);
        }
        else if (this._items.Contains((RibbonItem) this.DropDownButton))
          this._items.Remove((RibbonItem) this.DropDownButton);
        return this._items;
      }
    }

    public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
    {
      if (!this.Visible || !this.Owner.CaptionBarVisible)
        return;
      if (this.Owner.OrbStyle == RibbonOrbStyle.Office_2007)
        this.Owner.Renderer.OnRenderRibbonQuickAccessToolbarBackground(new RibbonRenderEventArgs(this.Owner, e.Graphics, e.Clip));
      foreach (RibbonItem ribbonItem in (List<RibbonItem>) this.Items)
      {
        if (ribbonItem.Visible)
          ribbonItem.OnPaint((object) this, new RibbonElementPaintEventArgs(ribbonItem.Bounds, e.Graphics, RibbonElementSizeMode.Compact));
      }
    }

    public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
    {
      if (!this.Visible || !this.Owner.CaptionBarVisible)
      {
        this.SetLastMeasuredSize(new Size(0, 0));
        return this.LastMeasuredSize;
      }
      int horizontal = this.Padding.Horizontal;
      int num = 16;
      foreach (RibbonItem ribbonItem in (List<RibbonItem>) this.Items)
      {
        if (!ribbonItem.Equals((object) this.DropDownButton))
        {
          ribbonItem.SetSizeMode(RibbonElementSizeMode.Compact);
          Size size = ribbonItem.MeasureSize((object) this, new RibbonElementMeasureSizeEventArgs(e.Graphics, RibbonElementSizeMode.Compact));
          horizontal += size.Width + 1;
          num = Math.Max(num, size.Height);
        }
      }
      int width = horizontal - 1;
      if (this.Site != null && this.Site.DesignMode)
        width += 16;
      Size size1 = new Size(width, num);
      this.SetLastMeasuredSize(size1);
      return size1;
    }

    public override void SetBounds(Rectangle bounds)
    {
      base.SetBounds(bounds);
      if (this.Owner.RightToLeft == RightToLeft.No)
      {
        int x = bounds.Left + this.Padding.Left;
        foreach (RibbonItem ribbonItem in (List<RibbonItem>) this.Items)
        {
          ribbonItem.SetBounds(new Rectangle(new Point(x, bounds.Top), ribbonItem.LastMeasuredSize));
          x = ribbonItem.Bounds.Right + 1;
        }
        if (!this.DropDownButtonVisible)
          return;
        this.DropDownButton.SetBounds(new Rectangle(bounds.Right + bounds.Height / 2 + 2, bounds.Top, 12, bounds.Height));
      }
      else
      {
        int x = bounds.Left + this.Padding.Left;
        for (int index = this.Items.Count - 1; index >= 0; --index)
        {
          this.Items[index].SetBounds(new Rectangle(new Point(x, bounds.Top), this.Items[index].LastMeasuredSize));
          x = this.Items[index].Bounds.Right + 1;
        }
        if (!this.DropDownButtonVisible)
          return;
        this.DropDownButton.SetBounds(new Rectangle(bounds.Left - bounds.Height / 2 - 14, bounds.Top, 12, bounds.Height));
      }
    }

    public IEnumerable<Component> GetAllChildComponents() => (IEnumerable<Component>) this.Items.ToArray();

    public IEnumerable<RibbonItem> GetItems() => (IEnumerable<RibbonItem>) this.Items;

    public Rectangle GetContentBounds() => this.Bounds;
  }
}
