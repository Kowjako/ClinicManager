// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonCaptionButton
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Drawing;
using System.Windows.Forms.RibbonHelpers;

namespace System.Windows.Forms
{
  public class RibbonCaptionButton : RibbonButton
  {
    public const string WindowsIconsFont = "Marlett";

    public static string GetCharFor(RibbonCaptionButton.CaptionButton type)
    {
      if (WinApi.IsWindows)
      {
        switch (type)
        {
          case RibbonCaptionButton.CaptionButton.Minimize:
            return "0";
          case RibbonCaptionButton.CaptionButton.Maximize:
            return "1";
          case RibbonCaptionButton.CaptionButton.Restore:
            return "2";
          case RibbonCaptionButton.CaptionButton.Close:
            return "r";
          default:
            return "?";
        }
      }
      else
      {
        switch (type)
        {
          case RibbonCaptionButton.CaptionButton.Minimize:
            return "_";
          case RibbonCaptionButton.CaptionButton.Maximize:
            return "+";
          case RibbonCaptionButton.CaptionButton.Restore:
            return "^";
          case RibbonCaptionButton.CaptionButton.Close:
            return "X";
          default:
            return "?";
        }
      }
    }

    public RibbonCaptionButton(RibbonCaptionButton.CaptionButton buttonType) => this.SetCaptionButtonType(buttonType);

    public RibbonCaptionButton.CaptionButton CaptionButtonType { get; private set; }

    public override void OnClick(EventArgs e)
    {
      base.OnClick(e);
      Form form = this.Owner.FindForm();
      if (form == null)
        return;
      switch (this.CaptionButtonType)
      {
        case RibbonCaptionButton.CaptionButton.Minimize:
          form.WindowState = FormWindowState.Minimized;
          break;
        case RibbonCaptionButton.CaptionButton.Maximize:
          if (form.WindowState == FormWindowState.Normal)
          {
            form.WindowState = FormWindowState.Maximized;
            form.Refresh();
            break;
          }
          form.WindowState = FormWindowState.Normal;
          form.Refresh();
          break;
        case RibbonCaptionButton.CaptionButton.Restore:
          form.WindowState = FormWindowState.Normal;
          break;
        case RibbonCaptionButton.CaptionButton.Close:
          form.Close();
          break;
      }
    }

    internal void SetCaptionButtonType(RibbonCaptionButton.CaptionButton buttonType)
    {
      this.Text = RibbonCaptionButton.GetCharFor(buttonType);
      this.CaptionButtonType = buttonType;
    }

    internal override Rectangle OnGetTextBounds(
      RibbonElementSizeMode sMode,
      Rectangle bounds)
    {
      Rectangle rectangle = bounds;
      rectangle.X = bounds.Left + 3;
      return rectangle;
    }

    public enum CaptionButton
    {
      Minimize,
      Maximize,
      Restore,
      Close,
    }
  }
}
