// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonTabGlyph
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms.Design.Behavior;

namespace System.Windows.Forms
{
  public class RibbonTabGlyph : Glyph
  {
    private readonly BehaviorService _behaviorService;
    private readonly Ribbon _ribbon;
    private RibbonDesigner _componentDesigner;
    private Rectangle _bounds;

    public RibbonTabGlyph(BehaviorService behaviorService, RibbonDesigner designer, Ribbon ribbon)
      : base((System.Windows.Forms.Design.Behavior.Behavior) new RibbonTabGlyphBehavior(designer, ribbon))
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
        this._bounds = new Rectangle(5, this._ribbon.OrbBounds.Bottom + 5, 60, 16);
        if (this._ribbon.Tabs.Count > 0)
        {
          RibbonTab tab = this._ribbon.Tabs[this._ribbon.Tabs.Count - 1];
          this._bounds = this._ribbon.LayoutHelper.CalcNewPosition(tab.Bounds, this._bounds, LayoutHelper.RTLLayoutPosition.Far, 5);
          this._bounds.Y = tab.Bounds.Top + 2;
        }
        foreach (RibbonContext context in (List<RibbonContext>) this._ribbon.Contexts)
        {
          if (context.ContextualTabsCount == 0)
            this._bounds = this._ribbon.LayoutHelper.CalcNewPosition(context.Bounds, this._bounds, LayoutHelper.RTLLayoutPosition.Far, 5);
        }
        this._bounds.Offset(adornerWindow);
        return this._bounds;
      }
    }

    public override Cursor GetHitTest(Point p) => this.Bounds.Contains(p) ? Cursors.Hand : (Cursor) null;

    public override void Paint(PaintEventArgs pe)
    {
      SmoothingMode smoothingMode = pe.Graphics.SmoothingMode;
      pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
      using (GraphicsPath path = RibbonProfessionalRenderer.RoundRectangle(this.Bounds, 2))
      {
        using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(50, Color.Blue)))
          pe.Graphics.FillPath((Brush) solidBrush, path);
      }
      StringFormat format = StringFormatFactory.Center();
      pe.Graphics.DrawString("Add Tab", SystemFonts.DefaultFont, Brushes.White, (RectangleF) this.Bounds, format);
      pe.Graphics.SmoothingMode = smoothingMode;
    }
  }
}
