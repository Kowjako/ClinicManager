// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonComboBox
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
  [Designer(typeof (RibbonComboBoxDesigner))]
  public class RibbonComboBox : RibbonTextBox, IContainsRibbonComponents, IDropDownRibbonItem
  {
    private RibbonItem _selectedItem;
    private readonly Set<RibbonItem> _assignedHandlers = new Set<RibbonItem>();

    public event EventHandler DropDownShowing;

    public event RibbonComboBox.RibbonItemEventHandler DropDownItemClicked;

    public RibbonComboBox()
    {
      this.DropDownItems = new RibbonItemCollection();
      this.DropDownItems.SetOwnerItem((RibbonItem) this);
      this.DropDownVisible = false;
      this.AllowTextEdit = true;
      this.DrawIconsBar = true;
      this.DropDownMaxHeight = 0;
      this._disableTextboxCursor = true;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.RemoveHandlers();
      base.Dispose(disposing);
    }

    [DefaultValue(0)]
    [Category("Behavior")]
    [Description("Gets or sets the maximum height for the dropdown window.  0 = Autosize.  If the size is smaller than the contents then scrollbars will be shown.")]
    public int DropDownMaxHeight { get; set; }

    [Browsable(false)]
    [DefaultValue(false)]
    [Description("Indicates if the dropdown window is currently visible")]
    public bool DropDownVisible { get; private set; }

    [DefaultValue(false)]
    [Category("Drop Down")]
    [Description("Makes the DropDown resizable with a grip on the corner")]
    public bool DropDownResizable { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public override Rectangle TextBoxTextBounds
    {
      get
      {
        Rectangle textBoxTextBounds = base.TextBoxTextBounds;
        textBoxTextBounds.Width -= this.DropDownButtonBounds.Width;
        return textBoxTextBounds;
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Category("Drop Down")]
    public RibbonItemCollection DropDownItems { get; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public RibbonItem SelectedItem
    {
      get
      {
        if (this._selectedItem == null)
        {
          foreach (RibbonItem dropDownItem in (List<RibbonItem>) this.DropDownItems)
          {
            if (dropDownItem.Text == this.TextBoxText)
            {
              this._selectedItem = dropDownItem;
              return dropDownItem;
            }
          }
          return (RibbonItem) null;
        }
        if (this.DropDownItems.Contains(this._selectedItem))
          return this._selectedItem;
        this._selectedItem = (RibbonItem) null;
        return (RibbonItem) null;
      }
      set
      {
        if (value == null)
        {
          this._selectedItem = (RibbonItem) null;
          this.TextBoxText = string.Empty;
        }
        else
        {
          if (!(value.GetType().BaseType == typeof (RibbonItem)))
            return;
          if (this.DropDownItems.Contains(value))
          {
            this._selectedItem = value;
            this.TextBoxText = this._selectedItem.Text;
          }
          else
          {
            this._selectedItem = value;
            this.TextBoxText = this._selectedItem.Text;
          }
        }
      }
    }

    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public int SelectedIndex
    {
      get => this._selectedItem != null ? this.DropDownItems.IndexOf(this._selectedItem) : -1;
      set
      {
        if (value == -1)
        {
          this.SelectedItem = (RibbonItem) null;
        }
        else
        {
          if (this.DropDownItems.Count <= 0 || value < 0 || value >= this.DropDownItems.Count)
            throw new ArgumentOutOfRangeException(nameof (SelectedIndex));
          this.SelectedItem = this.DropDownItems[value];
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
          if (string.Compare(dropDownItem.Value, value, false) == 0 && this._selectedItem != dropDownItem)
          {
            this._selectedItem = dropDownItem;
            this.TextBoxText = this._selectedItem.Text;
            RibbonItemEventArgs e = new RibbonItemEventArgs(dropDownItem);
            this.OnDropDownItemClicked(ref e);
          }
        }
      }
    }

    internal RibbonDropDown DropDown { get; private set; }

    public void OnDropDownShowing(EventArgs e)
    {
      if (this.DropDownShowing == null)
        return;
      this.DropDownShowing((object) this, e);
    }

    protected virtual void CreateDropDown() => this.DropDown = new RibbonDropDown((RibbonItem) this, (IEnumerable<RibbonItem>) this.DropDownItems, this.Owner);

    [Category("Drop Down")]
    [DisplayName("DrawDropDownIconsBar")]
    [DefaultValue(true)]
    public bool DrawIconsBar { get; set; }

    public virtual void ShowDropDown()
    {
      if (this.DropDownVisible)
        return;
      this.AssignHandlers();
      this.OnDropDownShowing(EventArgs.Empty);
      foreach (RibbonItem dropDownItem in (List<RibbonItem>) this.DropDownItems)
        dropDownItem.SetSelected(dropDownItem == this.SelectedItem);
      this.CreateDropDown();
      this.DropDown.DropDownMaxHeight = this.DropDownMaxHeight;
      this.DropDown.ShowSizingGrip = this.DropDownResizable;
      this.DropDown.DrawIconsBar = this.DrawIconsBar;
      this.DropDown.Closed += new EventHandler(this.DropDown_Closed);
      this.DropDown.Show(this.OnGetDropDownMenuLocation());
      this.DropDownVisible = true;
    }

    private void DropDown_Closed(object sender, EventArgs e)
    {
      this.DropDownVisible = false;
      this.DropDownButtonPressed = false;
      this.DropDownButtonSelected = false;
      this.SetSelected(false);
      this.RedrawItem();
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
      foreach (RibbonItem assignedHandler in this._assignedHandlers)
        assignedHandler.Click -= new EventHandler(this.DropDownItem_Click);
      this._assignedHandlers.Clear();
    }

    private void DropDownItem_Click(object sender, EventArgs e)
    {
      this._selectedItem = sender as RibbonItem;
      this.TextBoxText = (sender as RibbonItem).Text;
      RibbonItemEventArgs e1 = new RibbonItemEventArgs(sender as RibbonItem);
      this.OnDropDownItemClicked(ref e1);
    }

    protected override bool ClosesDropDownAt(Point p) => false;

    protected override void InitTextBox(TextBox t)
    {
      base.InitTextBox(t);
      t.Width -= this.DropDownButtonBounds.Width;
    }

    public override void SetBounds(Rectangle bounds)
    {
      base.SetBounds(bounds);
      this.DropDownButtonBounds = Rectangle.FromLTRB(bounds.Right - 15, bounds.Top, bounds.Right + 1, bounds.Bottom + 1);
    }

    public virtual void OnDropDownItemClicked(ref RibbonItemEventArgs e)
    {
      if (this.DropDownItemClicked == null)
        return;
      this.DropDownItemClicked((object) this, e);
    }

    public override void OnMouseMove(MouseEventArgs e)
    {
      if (!this.Enabled)
        return;
      base.OnMouseMove(e);
      bool flag = false;
      Rectangle rectangle = this.DropDownButtonBounds;
      if (rectangle.Contains(e.X, e.Y))
      {
        this.Owner.Cursor = Cursors.Default;
        flag = !this.DropDownButtonSelected;
        this.DropDownButtonSelected = true;
      }
      else
      {
        rectangle = this.TextBoxBounds;
        if (rectangle.Contains(e.X, e.Y))
        {
          this.Owner.Cursor = this.AllowTextEdit ? Cursors.IBeam : Cursors.Default;
          flag = this.DropDownButtonSelected;
          this.DropDownButtonSelected = false;
        }
        else
          this.Owner.Cursor = Cursors.Default;
      }
      if (!flag)
        return;
      this.RedrawItem();
    }

    public override void OnMouseDown(MouseEventArgs e)
    {
      if (!this.Enabled)
        return;
      Rectangle rectangle = this.DropDownButtonBounds;
      if (!rectangle.Contains(e.X, e.Y))
      {
        rectangle = this.TextBoxBounds;
        if (rectangle.Contains(e.X, e.Y) == this.AllowTextEdit)
        {
          rectangle = this.TextBoxBounds;
          if (!rectangle.Contains(e.X, e.Y) || !this.AllowTextEdit)
            return;
          this.StartEdit();
          return;
        }
      }
      this.DropDownButtonPressed = true;
      this.ShowDropDown();
    }

    public override void OnMouseUp(MouseEventArgs e)
    {
      if (!this.Enabled)
        return;
      base.OnMouseUp(e);
    }

    public override void OnMouseLeave(MouseEventArgs e)
    {
      if (!this.Enabled)
        return;
      base.OnMouseLeave(e);
      this.DropDownButtonSelected = false;
    }

    internal virtual Point OnGetDropDownMenuLocation()
    {
      Point empty = Point.Empty;
      Point screen;
      if (this.Canvas is RibbonDropDown)
      {
        Control canvas = this.Canvas;
        Rectangle rectangle = this.TextBoxBounds;
        int left = rectangle.Left;
        rectangle = this.Bounds;
        int bottom = rectangle.Bottom;
        Point p = new Point(left, bottom);
        screen = canvas.PointToScreen(p);
      }
      else
      {
        Ribbon owner = this.Owner;
        Rectangle rectangle = this.TextBoxBounds;
        int left = rectangle.Left;
        rectangle = this.Bounds;
        int bottom = rectangle.Bottom;
        Point p = new Point(left, bottom);
        screen = owner.PointToScreen(p);
      }
      return screen;
    }

    public IEnumerable<Component> GetAllChildComponents() => (IEnumerable<Component>) this.DropDownItems.ToArray();

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle DropDownButtonBounds { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool DropDownButtonVisible => this.DropDownVisible;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool DropDownButtonSelected { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool DropDownButtonPressed { get; private set; }

    internal override void SetOwner(Ribbon owner)
    {
      base.SetOwner(owner);
      this.DropDownItems.SetOwner(owner);
    }

    internal override void SetOwnerPanel(RibbonPanel ownerPanel)
    {
      base.SetOwnerPanel(ownerPanel);
      this.DropDownItems.SetOwnerPanel(ownerPanel);
    }

    internal override void SetOwnerTab(RibbonTab ownerTab)
    {
      base.SetOwnerTab(ownerTab);
      this.DropDownItems.SetOwnerTab(this.OwnerTab);
    }

    internal override void SetOwnerItem(RibbonItem ownerItem) => base.SetOwnerItem(ownerItem);

    internal override void ClearOwner()
    {
      List<RibbonItem> ribbonItemList = new List<RibbonItem>((IEnumerable<RibbonItem>) this.DropDownItems);
      base.ClearOwner();
      foreach (RibbonItem ribbonItem in ribbonItemList)
        ribbonItem.ClearOwner();
    }

    public delegate void RibbonItemEventHandler(object sender, RibbonItemEventArgs e);
  }
}
