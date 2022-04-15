// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonQuickAccessToolbarGlyph
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms.Design.Behavior;

namespace System.Windows.Forms
{
  public class RibbonQuickAccessToolbarGlyph : Glyph
  {
    private readonly BehaviorService _behaviorService;
    private readonly Ribbon _ribbon;
    private RibbonDesigner _componentDesigner;

    public RibbonQuickAccessToolbarGlyph(
      BehaviorService behaviorService,
      RibbonDesigner designer,
      Ribbon ribbon)
      : base((System.Windows.Forms.Design.Behavior.Behavior) new RibbonQuickAccessGlyphBehavior(designer, ribbon))
    {
      this._behaviorService = behaviorService;
      this._componentDesigner = designer;
      this._ribbon = ribbon;
    }

    public override Rectangle Bounds
    {
      get
      {
        Point adornerWindow = this._behaviorService.ControlToAdornerWindow((Control) this._ribbon);
        if (!this._ribbon.CaptionBarVisible || !this._ribbon.QuickAccessToolbar.Visible)
          return Rectangle.Empty;
        if (this._ribbon.RightToLeft == RightToLeft.No)
          return new Rectangle(adornerWindow.X + this._ribbon.QuickAccessToolbar.Bounds.Right + this._ribbon.QuickAccessToolbar.Bounds.Height / 2 + 4 + this._ribbon.QuickAccessToolbar.DropDownButton.Bounds.Width, adornerWindow.Y + this._ribbon.QuickAccessToolbar.Bounds.Top, this._ribbon.QuickAccessToolbar.Bounds.Height, this._ribbon.QuickAccessToolbar.Bounds.Height);
        Rectangle bounds = this._ribbon.QuickAccessToolbar.Bounds;
        int left = bounds.Left;
        bounds = this._ribbon.QuickAccessToolbar.Bounds;
        int num1 = bounds.Height / 2;
        int num2 = left - num1 - 4;
        bounds = this._ribbon.QuickAccessToolbar.DropDownButton.Bounds;
        int width = bounds.Width;
        int x = num2 - width;
        int y1 = adornerWindow.Y;
        bounds = this._ribbon.QuickAccessToolbar.Bounds;
        int top = bounds.Top;
        int y2 = y1 + top;
        bounds = this._ribbon.QuickAccessToolbar.Bounds;
        int height1 = bounds.Height;
        bounds = this._ribbon.QuickAccessToolbar.Bounds;
        int height2 = bounds.Height;
        return new Rectangle(x, y2, height1, height2);
      }
    }

    public override Cursor GetHitTest(Point p) => this.Bounds.Contains(p) ? Cursors.Hand : (Cursor) null;

    public override void Paint(PaintEventArgs pe)
    {
      if (!this._ribbon.CaptionBarVisible || !this._ribbon.QuickAccessToolbar.Visible)
        return;
      SmoothingMode smoothingMode = pe.Graphics.SmoothingMode;
      pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
      using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(50, Color.Blue)))
        pe.Graphics.FillEllipse((Brush) solidBrush, this.Bounds);
      StringFormat format = StringFormatFactory.Center();
      pe.Graphics.DrawString("+", SystemFonts.DefaultFont, Brushes.White, (RectangleF) this.Bounds, format);
      pe.Graphics.SmoothingMode = smoothingMode;
    }
  }
}
