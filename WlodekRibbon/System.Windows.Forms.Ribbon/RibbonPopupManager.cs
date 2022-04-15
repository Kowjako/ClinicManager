// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonPopupManager
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections.Generic;
using System.Windows.Forms.RibbonHelpers;

namespace System.Windows.Forms
{
  public static class RibbonPopupManager
  {
    private static readonly List<RibbonPopup> pops = new List<RibbonPopup>();

    public static event EventHandler PopupRegistered;

    public static event EventHandler PopupUnRegistered;

    internal static RibbonPopup LastPopup => RibbonPopupManager.pops.Count > 0 ? RibbonPopupManager.pops[RibbonPopupManager.pops.Count - 1] : (RibbonPopup) null;

    internal static int PopupCount => RibbonPopupManager.pops.Count;

    internal static void Register(RibbonPopup p)
    {
      if (RibbonPopupManager.pops.Contains(p))
        return;
      RibbonPopupManager.pops.Add(p);
      RibbonPopupManager.PopupRegistered((object) p, EventArgs.Empty);
    }

    internal static void Unregister(RibbonPopup p)
    {
      if (!RibbonPopupManager.pops.Contains(p))
        return;
      RibbonPopupManager.pops.Remove(p);
      RibbonPopupManager.PopupUnRegistered((object) p, EventArgs.Empty);
    }

    internal static bool FeedHookClick(MouseEventArgs e)
    {
      WinApi.POINT lpPoint;
      if (WinApi.GetCursorPos(out lpPoint))
      {
        foreach (RibbonPopup pop in RibbonPopupManager.pops)
        {
          if (pop.WrappedDropDown.Bounds.Contains(lpPoint.x, lpPoint.y))
            return true;
        }
      }
      RibbonPopupManager.Dismiss(RibbonPopupManager.DismissReason.AppClicked);
      return false;
    }

    internal static bool FeedMouseWheel(MouseEventArgs e)
    {
            RibbonDropDown lastPopup = null;
      if (RibbonPopupManager.LastPopup is RibbonDropDown)
      {
                lastPopup = LastPopup as RibbonDropDown;
        foreach (RibbonItem ribbonItem in lastPopup.Items)
        {
          if (lastPopup.RectangleToScreen(ribbonItem.Bounds).Contains(e.Location) && ribbonItem is IScrollableRibbonItem scrollableRibbonItem2)
          {
            if (e.Delta < 0)
              scrollableRibbonItem2.ScrollDown();
            else
              scrollableRibbonItem2.ScrollUp();
            return true;
          }
        }
      }
      if (lastPopup == null)
        return false;
      if (e.Delta < 0)
        lastPopup.ScrollDown();
      else
        lastPopup.ScrollUp();
      return true;
    }

    public static void DismissChildren(RibbonPopup parent, RibbonPopupManager.DismissReason reason)
    {
      int num = RibbonPopupManager.pops.IndexOf(parent);
      if (num < 0)
        return;
      RibbonPopupManager.Dismiss(num + 1, reason);
    }

    public static void Dismiss(RibbonPopupManager.DismissReason reason) => RibbonPopupManager.Dismiss(0, reason);

    public static void Dismiss(RibbonPopup startPopup, RibbonPopupManager.DismissReason reason)
    {
      int startPopup1 = RibbonPopupManager.pops.IndexOf(startPopup);
      if (startPopup1 < 0)
        return;
      RibbonPopupManager.Dismiss(startPopup1, reason);
    }

    private static void Dismiss(int startPopup, RibbonPopupManager.DismissReason reason)
    {
      for (int index = RibbonPopupManager.pops.Count - 1; index >= startPopup; --index)
        RibbonPopupManager.pops[index].Close();
    }

    public enum DismissReason
    {
      ItemClicked,
      AppClicked,
      NewPopup,
      AppFocusChanged,
      EscapePressed,
    }
  }
}
