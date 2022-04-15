// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonElementPopupEventArgs
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Drawing;

namespace System.Windows.Forms
{
  public class RibbonElementPopupEventArgs : PopupEventArgs
  {
    private readonly PopupEventArgs _args;

    public RibbonElementPopupEventArgs(IRibbonElement item)
      : base((IWin32Window) item.Owner, (Control) item.Owner, false, new Size(-1, -1))
    {
      this.AssociatedRibbonElement = item;
    }

    public RibbonElementPopupEventArgs(IRibbonElement item, PopupEventArgs args)
      : base(args.AssociatedWindow, args.AssociatedControl, args.IsBalloon, args.ToolTipSize)
    {
      this.AssociatedRibbonElement = item;
      this._args = args;
    }

    public IRibbonElement AssociatedRibbonElement { get; }

    public new bool Cancel
    {
      get => this._args != null ? this._args.Cancel : base.Cancel;
      set
      {
        if (this._args != null)
          this._args.Cancel = value;
        base.Cancel = value;
      }
    }
  }
}
