// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonTextBox
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
  public class RibbonTextBox : RibbonItem
  {
    private const int spacing = 3;
    internal TextBox _actualTextBox;
    internal bool _removingTxt;
    internal bool _labelVisible;
    internal bool _imageVisible;
    internal Rectangle _labelBounds;
    internal Rectangle _imageBounds;
    internal int _textboxWidth;
    internal int _labelWidth;
    internal Rectangle _textBoxBounds;
    internal string _textBoxText;
    internal bool _AllowTextEdit = true;
    internal bool _disableTextboxCursor;
    private char _passwordChar;

    public event EventHandler TextBoxTextChanged;

    public event KeyPressEventHandler TextBoxKeyPress;

    public event KeyEventHandler TextBoxKeyDown;

    public event KeyEventHandler TextBoxKeyUp;

    public event EventHandler TextBoxValidating;

    public event EventHandler TextBoxValidated;

    public RibbonTextBox()
    {
      this._textboxWidth = 100;
      this._textBoxText = "";
    }

    [Description("Allow Test Edit")]
    [Category("Behavior")]
    [DefaultValue(true)]
    public bool AllowTextEdit
    {
      get => this._AllowTextEdit;
      set
      {
        this._AllowTextEdit = value;
        if (this.Canvas == null)
          return;
        this.Canvas.Cursor = this.AllowTextEdit ? Cursors.IBeam : Cursors.Default;
      }
    }

    [DefaultValue('\0')]
    [Category("Behavior")]
    [Localizable(true)]
    [RefreshProperties(RefreshProperties.Repaint)]
    public char PasswordChar
    {
      get => this._passwordChar;
      set
      {
        this._passwordChar = value;
        if (this._actualTextBox == null)
          return;
        this._actualTextBox.PasswordChar = value;
      }
    }

    [Category("Appearance")]
    [Description("Text on the textbox")]
    public string TextBoxText
    {
      get => this._textBoxText;
      set
      {
        this._textBoxText = value;
        if (this._actualTextBox != null)
          this._actualTextBox.Text = this._textBoxText;
        this.OnTextChanged(EventArgs.Empty);
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual Rectangle TextBoxTextBounds => this.TextBoxBounds;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle ImageBounds => this._imageBounds;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual Rectangle LabelBounds => this._labelBounds;

    [Category("Appearance")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ImageVisible => this._imageVisible;

    [Category("Appearance")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool LabelVisible => this._labelVisible;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual Rectangle TextBoxBounds => this._textBoxBounds;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Editing => this._actualTextBox != null;

    [Category("Appearance")]
    [DefaultValue(100)]
    public int TextBoxWidth
    {
      get => this._textboxWidth;
      set
      {
        this._textboxWidth = value;
        this.NotifyOwnerRegionsChanged();
      }
    }

    [Category("Appearance")]
    [DefaultValue(0)]
    public int LabelWidth
    {
      get => this._labelWidth;
      set
      {
        this._labelWidth = value;
        this.NotifyOwnerRegionsChanged();
      }
    }

    public void StartEdit()
    {
      this.PlaceActualTextBox();
      this._actualTextBox.SelectAll();
      this._actualTextBox.Focus();
    }

    public void EndEdit() => this.RemoveActualTextBox();

    protected void PlaceActualTextBox()
    {
      this._actualTextBox = new TextBox();
      this.InitTextBox(this._actualTextBox);
      this._actualTextBox.TextChanged += new EventHandler(this._actualTextbox_TextChanged);
      this._actualTextBox.KeyDown += new KeyEventHandler(this._actualTextbox_KeyDown);
      this._actualTextBox.KeyUp += new KeyEventHandler(this._actualTextbox_KeyUp);
      this._actualTextBox.KeyPress += new KeyPressEventHandler(this._actualTextbox_KeyPress);
      this._actualTextBox.LostFocus += new EventHandler(this._actualTextbox_LostFocus);
      this._actualTextBox.VisibleChanged += new EventHandler(this._actualTextBox_VisibleChanged);
      this._actualTextBox.Validating += new CancelEventHandler(this._actualTextbox_Validating);
      this._actualTextBox.Validated += new EventHandler(this._actualTextbox_Validated);
      this._actualTextBox.PasswordChar = this.PasswordChar;
      this._actualTextBox.Visible = true;
      this.Canvas.Controls.Add((Control) this._actualTextBox);
      this.Owner.ActiveTextBox = (RibbonItem) this;
    }

    public void _actualTextBox_VisibleChanged(object sender, EventArgs e)
    {
      if ((sender as TextBox).Visible || this._removingTxt)
        return;
      this.RemoveActualTextBox();
    }

    protected void RemoveActualTextBox()
    {
      if (this._actualTextBox == null || this._removingTxt)
        return;
      this._removingTxt = true;
      this.TextBoxText = this._actualTextBox.Text;
      this._actualTextBox.Visible = false;
      if (this._actualTextBox.Parent != null)
        this._actualTextBox.Parent.Controls.Remove((Control) this._actualTextBox);
      this._actualTextBox.Dispose();
      this._actualTextBox = (TextBox) null;
      this.RedrawItem();
      this._removingTxt = false;
      this.Owner.ActiveTextBox = (RibbonItem) null;
    }

    protected virtual void InitTextBox(TextBox t)
    {
      t.Text = this.TextBoxText;
      t.BorderStyle = BorderStyle.None;
      t.Width = this.TextBoxBounds.Width - 2;
      TextBox textBox = t;
      Rectangle rectangle = this.TextBoxBounds;
      int x = rectangle.Left + 2;
      rectangle = this.Bounds;
      int top = rectangle.Top;
      rectangle = this.Bounds;
      int num = (rectangle.Height - t.Height) / 2;
      int y = top + num;
      Point point = new Point(x, y);
      textBox.Location = point;
    }

    public void _actualTextbox_LostFocus(object sender, EventArgs e) => this.RemoveActualTextBox();

    public void _actualTextbox_KeyDown(object sender, KeyEventArgs e)
    {
      if (this.TextBoxKeyDown != null)
        this.TextBoxKeyDown((object) this, e);
      if (e.KeyCode != Keys.Return && e.KeyCode != Keys.Return && e.KeyCode != Keys.Escape)
        return;
      this.RemoveActualTextBox();
    }

    public void _actualTextbox_KeyUp(object sender, KeyEventArgs e)
    {
      if (this.TextBoxKeyUp != null)
        this.TextBoxKeyUp((object) this, e);
      if (e.KeyCode != Keys.Return && e.KeyCode != Keys.Return && e.KeyCode != Keys.Escape)
        return;
      this.RemoveActualTextBox();
    }

    public void _actualTextbox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!this.Enabled || this.TextBoxKeyPress == null)
        return;
      this.TextBoxKeyPress((object) this, e);
    }

    public void _actualTextbox_Validating(object sender, CancelEventArgs e)
    {
      if (!this.Enabled || this.TextBoxValidating == null)
        return;
      this.TextBoxValidating((object) this, (EventArgs) e);
    }

    public void _actualTextbox_Validated(object sender, EventArgs e)
    {
      if (!this.Enabled || this.TextBoxValidated == null)
        return;
      this.TextBoxValidated((object) this, e);
    }

    public void _actualTextbox_TextChanged(object sender, EventArgs e) => this.TextBoxText = (sender as TextBox).Text;

    public virtual int MeasureHeight() => 16 + this.Owner.ItemMargin.Vertical;

    public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
    {
      if (this.Owner == null)
        return;
      this.Owner.Renderer.OnRenderRibbonItem(new RibbonItemRenderEventArgs(this.Owner, e.Graphics, this.Bounds, (RibbonItem) this));
      if (this.ImageVisible)
        this.Owner.Renderer.OnRenderRibbonItemImage(new RibbonItemBoundsEventArgs(this.Owner, e.Graphics, e.Clip, (RibbonItem) this, this._imageBounds));
      using (StringFormat format = StringFormatFactory.NearCenterNoWrap(StringTrimming.None))
      {
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
      this._textBoxBounds = Rectangle.FromLTRB(bounds.Right - this.TextBoxWidth, bounds.Top, bounds.Right, bounds.Bottom);
      Padding itemMargin;
      if (this.Image != null)
      {
        int x = bounds.Left + this.Owner.ItemMargin.Left;
        int top1 = bounds.Top;
        itemMargin = this.Owner.ItemMargin;
        int top2 = itemMargin.Top;
        int y = top1 + top2;
        int width = this.Image.Width;
        int height = this.Image.Height;
        this._imageBounds = new Rectangle(x, y, width, height);
      }
      else
        this._imageBounds = new Rectangle(bounds.Location, Size.Empty);
      int left = this._imageBounds.Right + (this._imageBounds.Width > 0 ? 3 : 0);
      int top = bounds.Top;
      int right = this._textBoxBounds.Left - 3;
      int bottom1 = bounds.Bottom;
      itemMargin = this.Owner.ItemMargin;
      int bottom2 = itemMargin.Bottom;
      int bottom3 = bottom1 - bottom2;
      this._labelBounds = Rectangle.FromLTRB(left, top, right, bottom3);
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
      int width = num1 + this.TextBoxWidth;
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
      this.Canvas.Cursor = this.AllowTextEdit ? Cursors.IBeam : Cursors.Default;
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
      if (!this.TextBoxBounds.Contains(e.X, e.Y) || !this._AllowTextEdit)
        return;
      this.StartEdit();
    }

    public override void OnMouseMove(MouseEventArgs e)
    {
      if (!this.Enabled)
        return;
      base.OnMouseMove(e);
      if (this._disableTextboxCursor)
        return;
      if (this.TextBoxBounds.Contains(e.X, e.Y) && this.AllowTextEdit)
        this.Owner.Cursor = Cursors.IBeam;
      else
        this.Owner.Cursor = Cursors.Default;
    }

    public void OnTextChanged(EventArgs e)
    {
      if (!this.Enabled)
        return;
      this.NotifyOwnerRegionsChanged();
      if (this.TextBoxTextChanged == null)
        return;
      this.TextBoxTextChanged((object) this, e);
    }
  }
}
