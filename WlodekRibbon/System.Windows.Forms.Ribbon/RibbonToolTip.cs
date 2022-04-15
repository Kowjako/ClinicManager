// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonToolTip
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace System.Windows.Forms
{
  public class RibbonToolTip : ToolTip
  {
    private const int DEFAULT_WIDTH = 200;
    private readonly IRibbonElement _RibbonElement;
    private static Color _BorderColor = Color.Red;
    private readonly Font _Font = new Font("Segoe UI", 8f);
    private readonly Padding TipPadding = new Padding(5, 5, 5, 5);
    private Rectangle _ImageRectangle;
    private Rectangle _TitleRectangle;
    private Rectangle _TextRectangle;
    private Rectangle _ToolTipRectangle;
    private Size _Size = new Size(200, 60);
    private int _ImageWidth = 15;
    private bool _AutoSize = true;

    public new event PopupEventHandler Popup;

    private Ribbon Owner => this._RibbonElement.Owner;

    [Category("Custom Settings")]
    [Description("Gets or sets a value indicating whether the ToolTip is drawn by the operating system or by code that you provide. If true, the properties 'ToolTipIcon' and 'ToolTipTitle' will set to their default values and the image will display in ToolTip otherwise only text will display.")]
    public new bool OwnerDraw
    {
      get => base.OwnerDraw;
      set
      {
        if (value)
        {
          this.ToolTipIcon = ToolTipIcon.None;
          this.ToolTipTitle = string.Empty;
        }
        base.OwnerDraw = value;
      }
    }

    [Category("Custom Settings")]
    [Description("Gets or sets a value that defines the type of icon to be displayed alongside the ToolTip text. Cannot set if the property 'OwnerDraw' is true.")]
    public new ToolTipIcon ToolTipIcon
    {
      get => base.ToolTipIcon;
      set => base.ToolTipIcon = value;
    }

    [Category("Custom Settings")]
    [Description("Gets or sets a title for the ToolTip window. Cannot set if the property 'OwnerDraw' is true.")]
    public new string ToolTipTitle
    {
      get => base.ToolTipTitle;
      set => base.ToolTipTitle = value;
    }

    [Category("Custom Settings")]
    [Description("Gets or sets an Image for the ToolTip window. Cannot set if the property 'OwnerDraw' is true.")]
    public Image ToolTipImage { get; set; }

    [Category("Custom Settings")]
    [Description("Gets or sets the background color for the ToolTip.")]
    public new Color BackColor
    {
      get => base.BackColor;
      set => base.BackColor = value;
    }

    [Category("Custom Settings")]
    [Description("Gets or sets the foreground color for the ToolTip.")]
    public new Color ForeColor
    {
      get => base.ForeColor;
      set => base.ForeColor = value;
    }

    [Category("Custom Settings")]
    [Description("Gets or sets a value that indicates whether the ToolTip resizes based on its text. true if the ToolTip automatically resizes based on its text; otherwise, false. The default is true.")]
    public bool AutoSize
    {
      get => this._AutoSize;
      set
      {
        this._AutoSize = value;
        int num = this._AutoSize ? 1 : 0;
      }
    }

    [Category("Custom Settings")]
    [Description("Gets or sets the size of the ToolTip. Valid only if the Property 'AutoSize' is false.")]
    public Size Size
    {
      get => this._Size;
      set
      {
        if (this._AutoSize)
          return;
        this._Size = value;
        this._ToolTipRectangle.Size = this._Size;
      }
    }

    [Category("Custom Settings")]
    [Description("Gets or sets the border color for the ToolTip.")]
    public Color BorderColor
    {
      get => RibbonToolTip._BorderColor;
      set => RibbonToolTip._BorderColor = value;
    }

    public RibbonToolTip(IRibbonElement ribbonElement)
    {
      try
      {
        this._RibbonElement = ribbonElement;
        this.OwnerDraw = true;
        this.AutoSize = false;
        base.Popup += new PopupEventHandler(this.ToolTip_Popup);
        this.Draw += new DrawToolTipEventHandler(this.ToolTip_Draw);
      }
      catch (Exception ex)
      {
        Trace.TraceError("Exception in RibbonToolTip.RibbonToolTip() " + (object) ex);
        throw;
      }
    }

    protected override void Dispose(bool disposing)
    {
      try
      {
        try
        {
          if (!disposing)
            return;
          if (this._Font != null)
            this._Font.Dispose();
          base.Popup -= new PopupEventHandler(this.ToolTip_Popup);
          this.Draw -= new DrawToolTipEventHandler(this.ToolTip_Draw);
        }
        finally
        {
          base.Dispose(disposing);
        }
      }
      catch (Exception ex)
      {
        Trace.TraceError("Exception in CustomizedToolTip.Dispose (bool) " + (object) ex);
        throw;
      }
    }

    private void ToolTip_Draw(object sender, DrawToolTipEventArgs e)
    {
      try
      {
        e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
        string toolTip = this.GetToolTip(e.AssociatedControl);
        RibbonToolTipRenderEventArgs e1 = new RibbonToolTipRenderEventArgs(this.Owner, e.Graphics, e.Bounds, toolTip)
        {
          Color = Color.Black,
          Font = this._Font
        };
        this.Owner.Renderer.OnRenderToolTipBackground(e1);
        StringFormat stringFormat = new StringFormat()
        {
          Trimming = StringTrimming.None
        };
        e1.Format = stringFormat;
        if (this._ImageRectangle.Width > 0 && this._ImageRectangle.Height > 0)
          e.Graphics.DrawImage(this.ToolTipImage, this._ImageRectangle);
        if (this._TextRectangle.Width > 0 && this._TextRectangle.Height > 0)
        {
          stringFormat.Alignment = StringAlignment.Near;
          stringFormat.LineAlignment = StringAlignment.Near;
          e1.ClipRectangle = this._TextRectangle;
          e1.Text = toolTip;
          this.Owner.Renderer.OnRenderToolTipText(e1);
        }
        if (this._TitleRectangle.Width <= 0 || this._TitleRectangle.Height <= 0)
          return;
        Font font = new Font(this._Font, FontStyle.Bold);
        e1.ClipRectangle = this._TitleRectangle;
        e1.Text = this.ToolTipTitle;
        e1.Font = font;
        this.Owner.Renderer.OnRenderToolTipText(e1);
        font.Dispose();
      }
      catch (Exception ex)
      {
        Trace.TraceError("Exception in RibbonToolTip_Draw (object, DrawToolTipEventArgs) " + (object) ex);
        throw;
      }
    }

    private void ToolTip_Popup(object sender, PopupEventArgs e)
    {
      if (this.Popup != null)
      {
        this.Popup(sender, e);
        if (e.Cancel)
          return;
      }
      try
      {
        if (!this.OwnerDraw)
          return;
        if (!this._AutoSize)
        {
          Graphics graphics = e.AssociatedControl.CreateGraphics();
          Padding tipPadding = this.TipPadding;
          int num1 = tipPadding.Left;
          tipPadding = this.TipPadding;
          int num2 = tipPadding.Top;
          SizeF sizeF;
          Size size1;
          if (!string.IsNullOrEmpty(base.ToolTipTitle))
          {
            Font font = new Font(this._Font, FontStyle.Bold);
            sizeF = graphics.MeasureString(base.ToolTipTitle, font, 200);
            size1 = sizeF.ToSize();
            size1.Width = Math.Max(size1.Width + 5, 200);
            this._TitleRectangle = new Rectangle(num1, num2, size1.Width, size1.Height);
            num2 = this._TitleRectangle.Bottom + 5;
            font.Dispose();
          }
          if (this.ToolTipImage != null)
          {
            this._ImageRectangle = new Rectangle(num1, num2, this.ToolTipImage.Width + 2, this.ToolTipImage.Height + 2);
            num1 = this._ImageRectangle.Right + 10;
          }
          else if (!string.IsNullOrEmpty(base.ToolTipTitle))
            num1 += 15;
          sizeF = graphics.MeasureString(this.GetToolTip(e.AssociatedControl), this._Font, 200);
          size1 = sizeF.ToSize();
          this._TextRectangle = Rectangle.FromLTRB(num1, num2, size1.Width + num1 + 4, num2 + size1.Height);
          int right1 = this._TextRectangle.Right;
          Size size2 = new Size();
          ref Size local = ref size2;
          int num3 = Math.Max(this._TextRectangle.Right, this._TitleRectangle.Right);
          tipPadding = this.TipPadding;
          int right2 = tipPadding.Right;
          int width = num3 + right2;
          int num4 = Math.Max(this._TextRectangle.Bottom, this._ImageRectangle.Bottom);
          tipPadding = this.TipPadding;
          int bottom = tipPadding.Bottom;
          int height = num4 + bottom;
          local = new Size(width, height);
          e.ToolTipSize = size2;
        }
        else
        {
          Size toolTipSize = e.ToolTipSize;
          if (e.AssociatedControl.Tag is Image)
          {
            this._ImageWidth = toolTipSize.Height;
            toolTipSize.Width += this._ImageWidth + this.TipPadding.Left;
          }
          else
            toolTipSize.Width += this.TipPadding.Left;
          e.ToolTipSize = toolTipSize;
        }
      }
      catch (Exception ex)
      {
        Trace.TraceError("Exception in RibbonToolTip_Popup (object, PopupEventArgs) " + (object) ex);
        throw;
      }
    }
  }
}
