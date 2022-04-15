// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonPanelGlyphBehavior
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Windows.Forms.Design.Behavior;

namespace System.Windows.Forms
{
  public class RibbonPanelGlyphBehavior : System.Windows.Forms.Design.Behavior.Behavior
  {
    private RibbonTab _tab;
    private readonly RibbonTabDesigner _designer;

    public RibbonPanelGlyphBehavior(RibbonTabDesigner designer, RibbonTab tab)
    {
      this._designer = designer;
      this._tab = tab;
    }

    public override bool OnMouseUp(Glyph g, MouseButtons button)
    {
      this._designer.AddPanel((object) this, EventArgs.Empty);
      return base.OnMouseUp(g, button);
    }
  }
}
