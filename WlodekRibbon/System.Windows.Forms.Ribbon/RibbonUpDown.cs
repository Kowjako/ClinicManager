// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonUpDown
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
  public class RibbonUpDown : RibbonTextBox
  {
    private const int spacing = 3;
    private readonly int _UpDownSize = 16;

    public event MouseEventHandler UpButtonClicked;

    public event MouseEventHandler DownButtonClicked;

    public RibbonUpDown()
    {
      this._textboxWidth = 50;
      this._UpDownSize = 16;
    }

    public override int MeasureHeight() => 16 + this.Owner.ItemMargin.Vertical;

    public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
    {
      if (this.Owner == null)
        return;
      this.Owner.Renderer.OnRenderRibbonItem(new RibbonItemRenderEventArgs(this.Owner, e.Graphics, this.Bounds, (RibbonItem) this));
      if (this.ImageVisible)
        this.Owner.Renderer.OnRenderRibbonItemImage(new RibbonItemBoundsEventArgs(this.Owner, e.Graphics, e.Clip, (RibbonItem) this, this._imageBounds));
      using (StringFormat format = StringFormatFactory.NearCenterNoWrap(StringTrimming.None))
      {
        format.Alignment = StringAlignment.Near;
        format.LineAlignment = StringAlignment.Center;
        format.Trimming = StringTrimming.None;
        format.FormatFlags |= StringFormatFlags.NoWrap;
        this.Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(this.Owner, e.Graphics, this.Bounds, (RibbonItem) this, this.TextBoxTextBounds, this.TextBoxText, format));
        if (!this.LabelVisible)
          return;
        format.Alignment = (StringAlignment) this.TextAlignment;
        this.Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(this.Owner, e.Graphics, this.Bounds, (RibbonItem) this, this.LabelBounds, this.Text, format));
      }
    }

    public override void SetBounds(Rectangle bounds)
    {
      base.SetBounds(bounds);
      this._textBoxBounds = Rectangle.FromLTRB(bounds.Right - this.TextBoxWidth - this._UpDownSize, bounds.Top, bounds.Right - this._UpDownSize, bounds.Bottom);
      if (this.Image != null)
        this._imageBounds = new Rectangle(bounds.Left + this.Owner.ItemMargin.Left, bounds.Top + this.Owner.ItemMargin.Top, this.Image.Width, this.Image.Height);
      else
        this._imageBounds = new Rectangle(bounds.Location, Size.Empty);
      this._labelBounds = Rectangle.FromLTRB(this._imageBounds.Right + (this._imageBounds.Width > 0 ? 3 : 0), bounds.Top, this._textBoxBounds.Left - 3, bounds.Bottom - this.Owner.ItemMargin.Bottom);
      this.UpButtonBounds = new Rectangle(bounds.Right - this._UpDownSize, bounds.Top, this._UpDownSize, bounds.Height / 2);
      int x = this.UpButtonBounds.X;
      Rectangle upButtonBounds = this.UpButtonBounds;
      int y = upButtonBounds.Bottom + 1;
      upButtonBounds = this.UpButtonBounds;
      int width = upButtonBounds.Width;
      int height = bounds.Height - this.UpButtonBounds.Height;
      this.DownButtonBounds = new Rectangle(x, y, width, height);
      if (this.SizeMode == RibbonElementSizeMode.Large)
      {
        this._imageVisible = true;
        this._labelVisible = true;
      }
      else if (this.SizeMode == RibbonElementSizeMode.Medium)
      {
        this._imageVisible = true;
        this._labelVisible = false;
        this._labelBounds = Rectangle.Empty;
      }
      else
      {
        if (this.SizeMode != RibbonElementSizeMode.Compact)
          return;
        this._imageBounds = Rectangle.Empty;
        this._imageVisible = false;
        this._labelBounds = Rectangle.Empty;
        this._labelVisible = false;
      }
    }

    public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
    {
      if (!this.Visible && !this.Owner.IsDesignMode())
      {
        this.SetLastMeasuredSize(new Size(0, 0));
        return this.LastMeasuredSize;
      }
      Size empty = Size.Empty;
      int num1 = 0;
      int num2 = this.Image != null ? this.Image.Width + 3 : 0;
      int num3 = string.IsNullOrEmpty(this.Text) ? 0 : (this._labelWidth > 0 ? this._labelWidth : e.Graphics.MeasureString(this.Text, this.Owner.Font).ToSize().Width + 3);
      int textBoxWidth = this.TextBoxWidth;
      int width = num1 + (this.TextBoxWidth + this._UpDownSize);
      switch (e.SizeMode)
      {
        case RibbonElementSizeMode.Medium:
          width += num2;
          break;
        case RibbonElementSizeMode.Large:
          width += num2 + num3;
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
      if (!this.TextBoxBounds.Contains(e.Location))
        return;
      this.Canvas.Cursor = Cursors.IBeam;
    }

    public override void OnMouseLeave(MouseEventArgs e)
    {
      if (!this.Enabled)
        return;
      base.OnMouseLeave(e);
      this.UpButtonPressed = false;
      this.DownButtonPressed = false;
      this.UpButtonSelected = false;
      this.DownButtonSelected = false;
      this.Canvas.Cursor = Cursors.Default;
    }

    public override void OnMouseUp(MouseEventArgs e)
    {
      if (!this.Enabled)
        return;
      base.OnMouseUp(e);
      bool flag = false;
      if (this.UpButtonPressed || this.DownButtonPressed)
        flag = true;
      this.UpButtonPressed = false;
      this.DownButtonPressed = false;
      if (!flag)
        return;
      this.RedrawItem();
    }

    public override void OnMouseDown(MouseEventArgs e)
    {
      if (!this.Enabled)
        return;
      Rectangle rectangle = this.UpButtonBounds;
      if (rectangle.Contains(e.Location))
      {
        this.UpButtonPressed = true;
        this.DownButtonPressed = false;
        this.DownButtonSelected = false;
        if (this.UpButtonClicked == null)
          return;
        this.UpButtonClicked((object) this, e);
      }
      else
      {
        rectangle = this.DownButtonBounds;
        if (rectangle.Contains(e.Location))
        {
          this.DownButtonPressed = true;
          this.UpButtonPressed = false;
          this.UpButtonSelected = false;
          if (this.DownButtonClicked == null)
            return;
          this.DownButtonClicked((object) this, e);
        }
        else
        {
          rectangle = this.TextBoxBounds;
          if (!rectangle.Contains(e.X, e.Y) || !this.AllowTextEdit)
            return;
          this.StartEdit();
        }
      }
    }

    public override void OnMouseMove(MouseEventArgs e)
    {
      if (!this.Enabled)
        return;
      base.OnMouseMove(e);
      bool flag = false;
      Rectangle rectangle = this.UpButtonBounds;
      if (rectangle.Contains(e.Location))
      {
        this.Owner.Cursor = Cursors.Default;
        flag = !this.UpButtonSelected || this.DownButtonSelected || this.DownButtonPressed;
        this.UpButtonSelected = true;
        this.DownButtonSelected = false;
        this.DownButtonPressed = false;
      }
      else
      {
        rectangle = this.DownButtonBounds;
        if (rectangle.Contains(e.Location))
        {
          this.Owner.Cursor = Cursors.Default;
          flag = !this.DownButtonSelected || this.UpButtonSelected || this.UpButtonPressed;
          this.DownButtonSelected = true;
          this.UpButtonSelected = false;
          this.UpButtonPressed = false;
        }
        else
        {
          rectangle = this.TextBoxBounds;
          if (rectangle.Contains(e.X, e.Y))
          {
            this.Owner.Cursor = Cursors.IBeam;
            flag = this.DownButtonSelected || this.DownButtonPressed || this.UpButtonSelected || this.UpButtonPressed;
            this.UpButtonSelected = false;
            this.UpButtonPressed = false;
            this.DownButtonSelected = false;
            this.DownButtonPressed = false;
          }
          else
            this.Owner.Cursor = Cursors.Default;
        }
      }
      if (!flag)
        return;
      this.RedrawItem();
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool UpButtonPressed { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool DownButtonPressed { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool UpButtonSelected { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool DownButtonSelected { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle UpButtonBounds { get; private set; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle DownButtonBounds { get; private set; }
  }
}
