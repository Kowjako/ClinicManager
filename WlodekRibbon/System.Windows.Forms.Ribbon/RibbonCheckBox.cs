// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonCheckBox
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace System.Windows.Forms
{
  public class RibbonCheckBox : RibbonItem
  {
    private const int spacing = 3;
    private Rectangle _labelBounds;
    private Rectangle _checkboxBounds;
    private int _labelWidth;
    private int _checkboxSize;
    private RibbonCheckBox.CheckBoxOrientationEnum _checkBoxOrientation;
    private RibbonCheckBox.CheckBoxStyle _style;
    private bool checkedGlyphSize;

    public event EventHandler CheckBoxCheckChanged;

    public event CancelEventHandler CheckBoxCheckChanging;

    public RibbonCheckBox() => this._checkboxSize = 16;

    [DefaultValue(RibbonCheckBox.CheckBoxStyle.CheckBox)]
    [Category("Appearance")]
    public RibbonCheckBox.CheckBoxStyle Style
    {
      get => this._style;
      set
      {
        this._style = value;
        this.NotifyOwnerRegionsChanged();
      }
    }

    [DefaultValue(RibbonCheckBox.CheckBoxOrientationEnum.Left)]
    [Category("Appearance")]
    public RibbonCheckBox.CheckBoxOrientationEnum CheckBoxOrientation
    {
      get => this._checkBoxOrientation;
      set
      {
        this._checkBoxOrientation = value;
        this.NotifyOwnerRegionsChanged();
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual Rectangle LabelBounds => this._labelBounds;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool LabelVisible { get; private set; } = true;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual Rectangle CheckBoxBounds => this._checkboxBounds;

    [DefaultValue(0)]
    [Category("Appearance")]
    public int LabelWidth
    {
      get => this._labelWidth;
      set
      {
        this._labelWidth = value;
        this.NotifyOwnerRegionsChanged();
      }
    }

    [Description("Click on text changes the checked state.")]
    [Category("Behavior")]
    [DefaultValue(true)]
    public bool TextClickable { get; set; } = true;

    protected virtual int MeasureHeight() => this._checkboxSize + this.Owner.ItemMargin.Vertical;

    public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
    {
      if (this.Owner == null)
        return;
      this.Owner.Renderer.OnRenderRibbonItem(new RibbonItemRenderEventArgs(this.Owner, e.Graphics, this.Bounds, (RibbonItem) this));
      if (this.Style == RibbonCheckBox.CheckBoxStyle.CheckBox)
      {
        CheckBoxState state = this.Checked ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal;
        if (this.Selected)
          ++state;
        if (this.CheckBoxOrientation == RibbonCheckBox.CheckBoxOrientationEnum.Left)
          CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(this._checkboxBounds.Left, this._checkboxBounds.Top), state);
        else
          CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(this._checkboxBounds.Left + 3, this._checkboxBounds.Top), state);
      }
      else
      {
        RadioButtonState state = this.Checked ? RadioButtonState.CheckedNormal : RadioButtonState.UncheckedNormal;
        if (this.Selected)
          ++state;
        if (this.CheckBoxOrientation == RibbonCheckBox.CheckBoxOrientationEnum.Left)
          RadioButtonRenderer.DrawRadioButton(e.Graphics, new Point(this._checkboxBounds.Left, this._checkboxBounds.Top), state);
        else
          RadioButtonRenderer.DrawRadioButton(e.Graphics, new Point(this._checkboxBounds.Left + 3, this._checkboxBounds.Top), state);
      }
      if (!this.LabelVisible)
        return;
      StringFormat format = new StringFormat();
      format.Alignment = this._checkBoxOrientation != RibbonCheckBox.CheckBoxOrientationEnum.Left ? StringAlignment.Far : StringAlignment.Near;
      format.LineAlignment = StringAlignment.Far;
      format.Trimming = StringTrimming.None;
      format.FormatFlags |= StringFormatFlags.NoWrap;
      this.Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(this.Owner, e.Graphics, this._labelBounds, (RibbonItem) this, this.LabelBounds, this.Text, format));
    }

    public override void SetBounds(Rectangle bounds)
    {
      base.SetBounds(bounds);
      if (this.CheckBoxOrientation == RibbonCheckBox.CheckBoxOrientationEnum.Left)
      {
        int left1 = bounds.Left;
        Padding itemMargin = this.Owner.ItemMargin;
        int left2 = itemMargin.Left;
        int x = left1 + left2;
        int top1 = bounds.Top;
        itemMargin = this.Owner.ItemMargin;
        int top2 = itemMargin.Top;
        int y = top1 + top2 + (bounds.Height - this._checkboxSize) / 2;
        int checkboxSize1 = this._checkboxSize;
        int checkboxSize2 = this._checkboxSize;
        this._checkboxBounds = new Rectangle(x, y, checkboxSize1, checkboxSize2);
        int left3 = this._checkboxBounds.Right + (this.SizeMode == RibbonElementSizeMode.DropDown ? this.Owner.ItemImageToTextSpacing : 0);
        int top3 = bounds.Top;
        itemMargin = this.Owner.ItemMargin;
        int top4 = itemMargin.Top;
        int top5 = top3 + top4;
        int right1 = bounds.Right;
        itemMargin = this.Owner.ItemMargin;
        int right2 = itemMargin.Right;
        int right3 = right1 - right2;
        int bottom1 = bounds.Bottom;
        itemMargin = this.Owner.ItemMargin;
        int bottom2 = itemMargin.Bottom;
        int bottom3 = bottom1 - bottom2;
        this._labelBounds = Rectangle.FromLTRB(left3, top5, right3, bottom3);
      }
      else
      {
        int right4 = bounds.Right;
        Padding itemMargin1 = this.Owner.ItemMargin;
        int right5 = itemMargin1.Right;
        int x = right4 - right5 - this._checkboxSize;
        int top6 = bounds.Top;
        itemMargin1 = this.Owner.ItemMargin;
        int top7 = itemMargin1.Top;
        int y = top6 + top7 + (bounds.Height - this._checkboxSize) / 2;
        int checkboxSize3 = this._checkboxSize;
        int checkboxSize4 = this._checkboxSize;
        this._checkboxBounds = new Rectangle(x, y, checkboxSize3, checkboxSize4);
        int left4 = bounds.Left;
        Padding itemMargin2 = this.Owner.ItemMargin;
        int left5 = itemMargin2.Left;
        int left6 = left4 + left5;
        int top8 = bounds.Top;
        itemMargin2 = this.Owner.ItemMargin;
        int top9 = itemMargin2.Top;
        int top10 = top8 + top9;
        int left7 = this._checkboxBounds.Left;
        int bottom4 = bounds.Bottom;
        itemMargin2 = this.Owner.ItemMargin;
        int bottom5 = itemMargin2.Bottom;
        int bottom6 = bottom4 - bottom5;
        this._labelBounds = Rectangle.FromLTRB(left6, top10, left7, bottom6);
      }
      if (this.SizeMode == RibbonElementSizeMode.Large)
        this.LabelVisible = true;
      else if (this.SizeMode == RibbonElementSizeMode.Medium)
      {
        this.LabelVisible = true;
        this._labelBounds = Rectangle.Empty;
      }
      else
      {
        if (this.SizeMode != RibbonElementSizeMode.Compact)
          return;
        this._labelBounds = Rectangle.Empty;
        this.LabelVisible = false;
      }
    }

    public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
    {
      if (!this.checkedGlyphSize)
      {
        try
        {
          this._checkboxSize = this.Style != RibbonCheckBox.CheckBoxStyle.CheckBox ? CheckBoxRenderer.GetGlyphSize(e.Graphics, this.Checked ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal).Height + 3 : CheckBoxRenderer.GetGlyphSize(e.Graphics, this.Checked ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal).Height + 3;
        }
        catch
        {
        }
        this.checkedGlyphSize = true;
      }
      if (!this.Visible && !this.Owner.IsDesignMode())
      {
        this.SetLastMeasuredSize(new Size(0, 0));
        return this.LastMeasuredSize;
      }
      Size empty = Size.Empty;
      int horizontal = this.Owner.ItemMargin.Horizontal;
      int num1 = this.Image != null ? this.Image.Width + 3 : 0;
      int num2 = string.IsNullOrEmpty(this.Text) ? 0 : (this._labelWidth > 0 ? this._labelWidth : e.Graphics.MeasureString(this.Text, this.Owner.Font).ToSize().Width);
      int width = horizontal + this._checkboxSize;
      switch (e.SizeMode)
      {
        case RibbonElementSizeMode.Medium:
          width += num1;
          break;
        case RibbonElementSizeMode.Large:
          width += num1 + num2;
          break;
        case RibbonElementSizeMode.DropDown:
          width += num1 + num2 + this.Owner.ItemImageToTextSpacing;
          break;
      }
      this.SetLastMeasuredSize(new Size(width, this.MeasureHeight()));
      return this.LastMeasuredSize;
    }

    public override void OnMouseEnter(MouseEventArgs e)
    {
      if (!this.Enabled)
        return;
      base.OnMouseEnter(e);
    }

    public override void OnMouseLeave(MouseEventArgs e)
    {
      if (!this.Enabled)
        return;
      base.OnMouseLeave(e);
      this.Canvas.Cursor = Cursors.Default;
    }

    public override void OnMouseDown(MouseEventArgs e)
    {
      if (!this.Enabled)
        return;
      base.OnMouseDown(e);
      if (!(this.TextClickable ? this.Bounds : this.CheckBoxBounds).Contains(e.X, e.Y))
        return;
      CancelEventArgs e1 = new CancelEventArgs();
      this.OnCheckChanging(e1);
      if (e1.Cancel)
        return;
      this.Checked = !this.Checked;
      this.OnCheckChanged((EventArgs) e);
    }

    public override void OnMouseMove(MouseEventArgs e)
    {
      if (!this.Enabled)
        return;
      base.OnMouseMove(e);
      if ((this.TextClickable ? this.Bounds : this.CheckBoxBounds).Contains(e.X, e.Y))
      {
        this.Canvas.Cursor = Cursors.Hand;
        if (this.Selected)
          return;
        this.SetSelected(true);
      }
      else
      {
        this.Canvas.Cursor = Cursors.Default;
        if (!this.Selected)
          return;
        this.SetSelected(false);
      }
    }

    public void OnCheckChanged(EventArgs e)
    {
      if (!this.Enabled)
        return;
      this.NotifyOwnerRegionsChanged();
      if (this.CheckBoxCheckChanged == null)
        return;
      this.CheckBoxCheckChanged((object) this, e);
    }

    public void OnCheckChanging(CancelEventArgs e)
    {
      if (!this.Enabled || this.CheckBoxCheckChanging == null)
        return;
      this.CheckBoxCheckChanging((object) this, e);
    }

    public enum CheckBoxOrientationEnum
    {
      Left,
      Right,
    }

    public enum CheckBoxStyle
    {
      CheckBox,
      RadioButton,
    }
  }
}
