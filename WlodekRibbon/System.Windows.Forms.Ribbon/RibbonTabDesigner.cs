// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonTabDesigner
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms.Design.Behavior;

namespace System.Windows.Forms
{
  public class RibbonTabDesigner : ComponentDesigner
  {
    private Adorner _panelAdorner;

    public override DesignerVerbCollection Verbs => new DesignerVerbCollection(new DesignerVerb[1]
    {
      new DesignerVerb("Add Panel", new EventHandler(this.AddPanel))
    });

    public RibbonTab Tab => this.Component as RibbonTab;

    public void AddPanel(object sender, EventArgs e)
    {
      if (!(this.GetService(typeof (IDesignerHost)) is IDesignerHost service) || this.Tab == null)
        return;
      DesignerTransaction transaction = service.CreateTransaction(nameof (AddPanel) + this.Component.Site.Name);
      MemberDescriptor property = (MemberDescriptor) TypeDescriptor.GetProperties((object) this.Component)["Panels"];
      this.RaiseComponentChanging(property);
      if (service.CreateComponent(typeof (RibbonPanel)) is RibbonPanel component)
      {
        component.Text = component.Site.Name;
        component.Index = this.Tab.Panels.Count;
        if (component.Index == 0)
        {
          component.IsFirstPanel = true;
        }
        else
        {
          foreach (RibbonPanel panel in (List<RibbonPanel>) this.Tab.Panels)
            panel.IsLastPanel = false;
          component.IsLastPanel = true;
        }
        this.Tab.Panels.Add(component);
        this.Tab.Owner.OnRegionsChanged();
      }
      this.RaiseComponentChanged(property, (object) null, (object) null);
      transaction.Commit();
    }

    public override void Initialize(IComponent component)
    {
      base.Initialize(component);
      this._panelAdorner = new Adorner();
      if (RibbonDesigner.Current == null)
        return;
      BehaviorService behaviorService = RibbonDesigner.Current.GetBehaviorService();
      if (behaviorService == null)
        return;
      behaviorService.Adorners.AddRange(new Adorner[1]
      {
        this._panelAdorner
      });
      this._panelAdorner.Glyphs.Add((Glyph) new RibbonPanelGlyph(behaviorService, this, this.Tab));
    }
  }
}
