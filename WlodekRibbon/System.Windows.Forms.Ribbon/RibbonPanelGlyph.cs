// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonPanelGlyph
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms.Design.Behavior;

namespace System.Windows.Forms
{
  public class RibbonPanelGlyph : Glyph
  {
    private readonly BehaviorService _behaviorService;
    private readonly RibbonTab _tab;
    private RibbonTabDesigner _componentDesigner;
    private readonly Size size;

    public RibbonPanelGlyph(
      BehaviorService behaviorService,
      RibbonTabDesigner designer,
      RibbonTab tab)
      : base((System.Windows.Forms.Design.Behavior.Behavior) new RibbonPanelGlyphBehavior(designer, tab))
    {
      this._behaviorService = behaviorService;
      this._componentDesigner = designer;
      this._tab = tab;
      this.size = new Size(60, 16);
    }

    public override Rectangle Bounds
    {
      get
      {
        if (!this._tab.Active || !this._tab.Owner.Tabs.Contains(this._tab))
          return Rectangle.Empty;
        Point adornerWindow = this._behaviorService.ControlToAdornerWindow((Control) this._tab.Owner);
        Point point = new Point(0,0);
        ref Point local1 = ref point;
        Rectangle rectangle = this._tab.TabBounds;
        int y1 = rectangle.Bottom + 5;
        local1 = new Point(5, y1);
        Size size;
        if (this._tab.Panels.Count > 0)
        {
          RibbonPanel panel = this._tab.Panels[this._tab.Panels.Count - 1];
          if (this._tab.Owner.RightToLeft == RightToLeft.No)
          {
            ref Point local2 = ref point;
            rectangle = panel.Bounds;
            int num = rectangle.Right + 5;
            local2.X = num;
          }
          else
          {
            ref Point local3 = ref point;
            rectangle = panel.Bounds;
            int num1 = rectangle.Left - 5;
            size = this.size;
            int width = size.Width;
            int num2 = num1 - width;
            local3.X = num2;
          }
        }
        int x = adornerWindow.X + point.X;
        int y2 = adornerWindow.Y + point.Y;
        size = this.size;
        int width1 = size.Width;
        size = this.size;
        int height = size.Height;
        return new Rectangle(x, y2, width1, height);
      }
    }

    public override Cursor GetHitTest(Point p) => this.Bounds.Contains(p) ? Cursors.Hand : (Cursor) null;

    public override void Paint(PaintEventArgs pe)
    {
      SmoothingMode smoothingMode = pe.Graphics.SmoothingMode;
      pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
      using (GraphicsPath path = RibbonProfessionalRenderer.RoundRectangle(this.Bounds, 9))
      {
        using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(50, Color.Blue)))
          pe.Graphics.FillPath((Brush) solidBrush, path);
      }
      StringFormat format = StringFormatFactory.Center();
      pe.Graphics.DrawString("Add Panel", SystemFonts.DefaultFont, Brushes.White, (RectangleF) this.Bounds, format);
      pe.Graphics.SmoothingMode = smoothingMode;
    }
  }
}
