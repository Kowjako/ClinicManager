// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonElementWithItemCollectionDesigner
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.ComponentModel;
using System.ComponentModel.Design;

namespace System.Windows.Forms
{
  internal abstract class RibbonElementWithItemCollectionDesigner : ComponentDesigner
  {
    public abstract Ribbon Ribbon { get; }

    public abstract RibbonItemCollection Collection { get; }

    protected virtual DesignerVerbCollection OnGetVerbs() => new DesignerVerbCollection(new DesignerVerb[12]
    {
      new DesignerVerb("Add Button", new EventHandler(this.AddButton)),
      new DesignerVerb("Add ButtonList", new EventHandler(this.AddButtonList)),
      new DesignerVerb("Add ItemGroup", new EventHandler(this.AddItemGroup)),
      new DesignerVerb("Add Separator", new EventHandler(this.AddSeparator)),
      new DesignerVerb("Add TextBox", new EventHandler(this.AddTextBox)),
      new DesignerVerb("Add ComboBox", new EventHandler(this.AddComboBox)),
      new DesignerVerb("Add ColorChooser", new EventHandler(this.AddColorChooser)),
      new DesignerVerb("Add DescriptionMenuItem", new EventHandler(this.AddDescriptionMenuItem)),
      new DesignerVerb("Add CheckBox", new EventHandler(this.AddCheckBox)),
      new DesignerVerb("Add UpDown", new EventHandler(this.AddUpDown)),
      new DesignerVerb("Add Label", new EventHandler(this.AddLabel)),
      new DesignerVerb("Add Host", new EventHandler(this.AddHost))
    });

    public override DesignerVerbCollection Verbs => this.OnGetVerbs();

    private void CreateItem(Type t) => this.CreateItem(this.Ribbon, this.Collection, t);

    protected virtual void CreateItem(Ribbon ribbon, RibbonItemCollection collection, Type t)
    {
      if (!(this.GetService(typeof (IDesignerHost)) is IDesignerHost service) || collection == null || ribbon == null)
        return;
      DesignerTransaction transaction = service.CreateTransaction("AddRibbonItem_" + this.Component.Site.Name);
      MemberDescriptor property = (MemberDescriptor) TypeDescriptor.GetProperties((object) this.Component)["Items"];
      this.RaiseComponentChanging(property);
      RibbonItem component = service.CreateComponent(t) as RibbonItem;
      switch (component)
      {
        case RibbonSeparator _:
        case null:
          collection.Add(component);
          ribbon.OnRegionsChanged();
          this.RaiseComponentChanged(property, (object) null, (object) null);
          transaction.Commit();
          break;
        default:
          component.Text = component.Site.Name;
          goto case null;
      }
    }

    protected virtual void AddButton(object sender, EventArgs e) => this.CreateItem(typeof (RibbonButton));

    protected virtual void AddButtonList(object sender, EventArgs e) => this.CreateItem(typeof (RibbonButtonList));

    protected virtual void AddItemGroup(object sender, EventArgs e) => this.CreateItem(typeof (RibbonItemGroup));

    protected virtual void AddSeparator(object sender, EventArgs e) => this.CreateItem(typeof (RibbonSeparator));

    protected virtual void AddTextBox(object sender, EventArgs e) => this.CreateItem(typeof (RibbonTextBox));

    protected virtual void AddComboBox(object sender, EventArgs e) => this.CreateItem(typeof (RibbonComboBox));

    protected virtual void AddColorChooser(object sender, EventArgs e) => this.CreateItem(typeof (RibbonColorChooser));

    protected virtual void AddDescriptionMenuItem(object sender, EventArgs e) => this.CreateItem(typeof (RibbonDescriptionMenuItem));

    protected virtual void AddCheckBox(object sender, EventArgs e) => this.CreateItem(typeof (RibbonCheckBox));

    protected virtual void AddUpDown(object sender, EventArgs e) => this.CreateItem(typeof (RibbonUpDown));

    protected virtual void AddLabel(object sender, EventArgs e) => this.CreateItem(typeof (RibbonLabel));

    protected virtual void AddHost(object sender, EventArgs e) => this.CreateItem(typeof (RibbonHost));
  }
}
