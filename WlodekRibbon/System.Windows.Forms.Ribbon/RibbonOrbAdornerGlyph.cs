// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonOrbAdornerGlyph
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Drawing;
using System.Windows.Forms.Design.Behavior;

namespace System.Windows.Forms
{
  public class RibbonOrbAdornerGlyph : Glyph
  {
    private readonly BehaviorService _behaviorService;
    private readonly Ribbon _ribbon;
    private RibbonDesigner _componentDesigner;

    public RibbonOrbAdornerGlyph(
      BehaviorService behaviorService,
      RibbonDesigner designer,
      Ribbon ribbon)
      : base((System.Windows.Forms.Design.Behavior.Behavior) new RibbonOrbAdornerGlyphBehavior())
    {
      this._behaviorService = behaviorService;
      this._componentDesigner = designer;
      this._ribbon = ribbon;
    }

    public bool MenuVisible { get; set; }

    public override Rectangle Bounds
    {
      get
      {
        Point adornerWindow = this._behaviorService.ControlToAdornerWindow((Control) this._ribbon);
        int x = adornerWindow.X + this._ribbon.OrbBounds.Left;
        int y = adornerWindow.Y + this._ribbon.OrbBounds.Top;
        Rectangle orbBounds = this._ribbon.OrbBounds;
        int height1 = orbBounds.Height;
        orbBounds = this._ribbon.OrbBounds;
        int height2 = orbBounds.Height;
        return new Rectangle(x, y, height1, height2);
      }
    }

    public override Cursor GetHitTest(Point p) => this.Bounds.Contains(p) ? Cursors.Hand : (Cursor) null;

    public override void Paint(PaintEventArgs pe)
    {
    }
  }
}
