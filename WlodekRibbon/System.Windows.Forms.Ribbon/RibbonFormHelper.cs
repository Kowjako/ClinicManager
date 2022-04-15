// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonFormHelper
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms.RibbonHelpers;

namespace System.Windows.Forms
{
  public class RibbonFormHelper
  {
    private FormWindowState _lastState;
    private bool _frameExtended;
    private Ribbon _ribbon;
    private Size _storeSize;

    public RibbonFormHelper(Form f)
    {
      this.Form = f;
      this.Form.Load += new EventHandler(this.Form_Load);
      this.Form.ResizeEnd += new EventHandler(this._form_ResizeEnd);
      this.Form.MinimumSizeChanged += new EventHandler(this._form_ResizeEnd);
      this.Form.MaximumSizeChanged += new EventHandler(this._form_ResizeEnd);
      this.Form.Layout += new LayoutEventHandler(this._form_Layout);
      this.Form.TextChanged += new EventHandler(this._form_TextChanged);
    }

    private void _form_TextChanged(object sender, EventArgs e)
    {
      this.UpdateRibbonConditions();
      this.Form.Refresh();
      this.Form.Update();
    }

    private void _form_Layout(object sender, LayoutEventArgs e)
    {
      if (this._lastState == this.Form.WindowState)
        return;
      if (this._storeSize.IsEmpty)
        this._storeSize = this.Form.Size;
      if (WinApi.IsGlassEnabled)
        this.Form.Invalidate();
      else
        this.Form.Refresh();
      this._lastState = this.Form.WindowState;
    }

    private void _form_ResizeEnd(object sender, EventArgs e)
    {
      this.UpdateRibbonConditions();
      this.Form.Refresh();
    }

    public Ribbon Ribbon
    {
      get => this._ribbon;
      set
      {
        if (this._ribbon != null)
          this._ribbon.OrbStyleChanged -= new EventHandler(this.RibbonOrbStyleChanged);
        this._ribbon = value;
        if (this._ribbon != null)
          this._ribbon.OrbStyleChanged += new EventHandler(this.RibbonOrbStyleChanged);
        this.UpdateRibbonConditions();
      }
    }

    public int CaptionHeight { get; set; }

    public Form Form { get; }

    public Padding Margins { get; private set; }

    private bool MarginsChecked { get; set; }

    private bool DesignMode => this.Form != null && this.Form.Site != null && this.Form.Site.DesignMode;

    private void UpdateRibbonConditions()
    {
      if (this.Ribbon == null || this.Ribbon.Dock == DockStyle.Top)
        return;
      this.Ribbon.Dock = DockStyle.Top;
    }

    public void Form_Paint(object sender, PaintEventArgs e)
    {
      if (this.DesignMode)
        return;
      if (WinApi.IsGlassEnabled)
      {
        WinApi.FillForGlass(e.Graphics, new Rectangle(0, 0, this.Form.Width, this.Form.Height));
        using (Brush brush1 = (Brush) new SolidBrush(this.Form.BackColor))
        {
          int num1;
          int num2;
          Padding margins;
          if (WinApi.IsWin10)
          {
            num1 = 0;
            num2 = this.Form.Width;
          }
          else
          {
            margins = this.Margins;
            num1 = margins.Left;
            int width = this.Form.Width;
            margins = this.Margins;
            int right = margins.Right;
            num2 = width - right;
          }
          Graphics graphics = e.Graphics;
          Brush brush2 = brush1;
          int left = num1;
          margins = this.Margins;
          int top = margins.Top;
          int right1 = num2;
          int height = this.Form.Height;
          margins = this.Margins;
          int bottom1 = margins.Bottom;
          int bottom2 = height - bottom1;
          Rectangle rect = Rectangle.FromLTRB(left, top, right1, bottom2);
          graphics.FillRectangle(brush2, rect);
        }
      }
      else
        this.PaintTitleBar(e);
    }

    private void PaintTitleBar(PaintEventArgs e)
    {
      int radius1 = 4;
      int radius2 = radius1;
      Rectangle r1 = new Rectangle(Point.Empty, this.Form.Size);
      Rectangle r2 = new Rectangle(Point.Empty, new Size(r1.Width - 1, r1.Height - 1));
      using (GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(r1, radius1))
      {
        using (GraphicsPath path2 = RibbonProfessionalRenderer.RoundRectangle(r2, radius2))
        {
          if (this.Ribbon == null || this.Ribbon.ActualBorderMode != RibbonWindowMode.NonClientAreaCustomDrawn || !(this.Ribbon.Renderer is RibbonProfessionalRenderer renderer3))
            return;
          e.Graphics.Clear(renderer3.ColorTable.RibbonBackground);
          using (SolidBrush solidBrush = new SolidBrush(renderer3.ColorTable.Caption1))
            e.Graphics.FillRectangle((Brush) solidBrush, new Rectangle(0, 0, this.Form.Width, this.Ribbon.CaptionBarSize));
          renderer3.DrawCaptionBarBackground(new Rectangle(0, this.Margins.Bottom - 1, this.Form.Width, this.Ribbon.CaptionBarSize), e.Graphics);
          using (Region region = new Region(path1))
          {
            this.Form.Region = region;
            SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(renderer3.ColorTable.FormBorder, 1f))
              e.Graphics.DrawPath(pen, path2);
            e.Graphics.SmoothingMode = smoothingMode;
          }
        }
      }
    }

    private void RibbonOrbStyleChanged(object sender, EventArgs e)
    {
      if (!this._frameExtended)
        return;
      this._frameExtended = false;
      this.Form_Load(sender, e);
    }

    protected virtual void Form_Load(object sender, EventArgs e)
    {
      if (this.DesignMode)
        return;
      if (this.Ribbon == null)
        throw new ArgumentNullException("Ribbon", "Ribbon Control was not placed to RibbonForm");
            WinApi.MARGINS marInset = new WinApi.MARGINS(0, 0, 0, 0);
      if (this.Ribbon.CaptionBarVisible)
      {
        ref WinApi.MARGINS local = ref marInset;
        int left = this.Margins.Left;
        int right = this.Margins.Right;
        Padding padding = this.Margins;
        int num1 = padding.Bottom + this.Ribbon.ContextSpace;
        int num2;
        if (this.Ribbon.OrbStyle != RibbonOrbStyle.Office_2007)
        {
          int captionBarHeight = Ribbon.CaptionBarHeight;
          padding = this.Ribbon.TabsMargin;
          int top = padding.Top;
          num2 = captionBarHeight + top;
        }
        else
          num2 = Ribbon.CaptionBarHeight;
        int Top = num1 + num2;
        padding = this.Margins;
        int bottom = padding.Bottom;
        local = new WinApi.MARGINS(left, right, Top, bottom);
      }
      else
      {
        ref WinApi.MARGINS local = ref marInset;
        int left = this.Margins.Left;
        int right = this.Margins.Right;
        Padding padding = this.Margins;
        int num3 = padding.Bottom + this.Ribbon.ContextSpace;
        int num4;
        if (this.Ribbon.OrbStyle != RibbonOrbStyle.Office_2007)
        {
          padding = this.Ribbon.TabsMargin;
          num4 = padding.Top;
        }
        else
          num4 = 0;
        int Top = num3 + num4;
        padding = this.Margins;
        int bottom = padding.Bottom;
        local = new WinApi.MARGINS(left, right, Top, bottom);
      }
      if (WinApi.IsWin10)
      {
        marInset.cxLeftWidth = 0;
        marInset.cxRightWidth = 0;
        marInset.cyBottomHeight = 0;
      }
      if (!WinApi.IsVista || this._frameExtended)
        return;
      WinApi.DwmExtendFrameIntoClientArea(this.Form.Handle, ref marInset);
      this._frameExtended = true;
    }

    public virtual void ReapplyGlass()
    {
      this._frameExtended = false;
      this.Form_Load((object) this, EventArgs.Empty);
    }

    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    public virtual bool WndProc(ref Message m)
    {
      if (this.DesignMode || this.Ribbon == null)
        return false;
      bool flag = false;
      IntPtr result;
      if (WinApi.IsVista && WinApi.DwmDefWindowProc(m.HWnd, m.Msg, m.WParam, m.LParam, out result) == 1)
      {
        m.Result = result;
        flag = true;
      }
      if (!flag)
      {
        if (m.Msg == 131 && (int) m.WParam == 1)
        {
          WinApi.NCCALCSIZE_PARAMS structure = (WinApi.NCCALCSIZE_PARAMS) Marshal.PtrToStructure(m.LParam, typeof (WinApi.NCCALCSIZE_PARAMS));
          if (!this.MarginsChecked)
          {
            this.SetMargins(new Padding(structure.rect2.Left - structure.rect1.Left, structure.rect2.Top - structure.rect1.Top, structure.rect1.Right - structure.rect2.Right, structure.rect1.Bottom - structure.rect2.Bottom));
            this.MarginsChecked = true;
          }
          if (WinApi.IsWin10)
          {
            structure.rect0.Left += this.Margins.Left;
            structure.rect0.Right -= this.Margins.Right;
            structure.rect0.Bottom -= this.Margins.Bottom;
          }
          if (Screen.AllScreens.Length > 1 && WinApi.IsGlassEnabled)
            --structure.rect0.Bottom;
          Marshal.StructureToPtr<WinApi.NCCALCSIZE_PARAMS>(structure, m.LParam, false);
          m.Result = IntPtr.Zero;
          flag = true;
        }
        else if (m.Msg == 134 && this.Ribbon != null && this.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaCustomDrawn)
        {
          this.Ribbon.Invalidate();
          flag = true;
          if (m.WParam == IntPtr.Zero)
            m.Result = (IntPtr) 1;
        }
        else if ((m.Msg == 6 || m.Msg == 15) && WinApi.IsVista)
        {
          m.Result = (IntPtr) 1;
          flag = false;
        }
        else if (m.Msg == 132 && (int) m.Result == 0)
        {
          m.Result = new IntPtr(Convert.ToInt32((object) this.NonClientHitTest(new Point((int) WinApi.LoWord((int) m.LParam), (int) WinApi.HiWord((int) m.LParam)))));
          flag = true;
        }
        else if (m.Msg == 165)
        {
          int xLparam = WinApi.Get_X_LParam((int) m.LParam);
          int yLparam = WinApi.Get_Y_LParam((int) m.LParam);
          switch (WinApi.LoWord((int) m.WParam))
          {
            case 2:
            case 3:
              WinApi.ShowSystemMenu(this.Form, xLparam, yLparam);
              flag = true;
              break;
          }
        }
        else if (m.Msg == 274)
        {
          if (((IntPtr.Size == 4 ? m.WParam.ToInt32() : (int) (uint) m.WParam.ToInt64()) & 65520) == 61728)
            this.Form.Size = this._storeSize;
          else if (this.Form.WindowState == FormWindowState.Normal)
            this._storeSize = this.Form.Size;
        }
        else if ((m.Msg == 70 || m.Msg == 71) && this.Ribbon != null)
          this.Ribbon.Invalidate();
      }
      return flag;
    }

    public virtual RibbonFormHelper.NonClientHitTestResult NonClientHitTest(
      Point hitPoint)
    {
      int num1 = 0;
      int num2 = 0;
      Padding margins;
      if (WinApi.IsWin10)
      {
        margins = this.Margins;
        num1 = -margins.Left;
        margins = this.Margins;
        num2 = -margins.Right;
      }
      Form form1 = this.Form;
      int x1 = num1;
      margins = this.Margins;
      int left1 = margins.Left;
      margins = this.Margins;
      int left2 = margins.Left;
      Rectangle r1 = new Rectangle(x1, 0, left1, left2);
      if (form1.RectangleToScreen(r1).Contains(hitPoint))
        return RibbonFormHelper.NonClientHitTestResult.TopLeft;
      Form form2 = this.Form;
      int num3 = num2 + this.Form.Width;
      margins = this.Margins;
      int right1 = margins.Right;
      int x2 = num3 - right1;
      margins = this.Margins;
      int right2 = margins.Right;
      margins = this.Margins;
      int right3 = margins.Right;
      Rectangle r2 = new Rectangle(x2, 0, right2, right3);
      if (form2.RectangleToScreen(r2).Contains(hitPoint))
        return RibbonFormHelper.NonClientHitTestResult.TopRight;
      Form form3 = this.Form;
      int x3 = num1;
      int height1 = this.Form.Height;
      margins = this.Margins;
      int bottom1 = margins.Bottom;
      int y1 = height1 - bottom1;
      margins = this.Margins;
      int left3 = margins.Left;
      margins = this.Margins;
      int bottom2 = margins.Bottom;
      Rectangle r3 = new Rectangle(x3, y1, left3, bottom2);
      if (form3.RectangleToScreen(r3).Contains(hitPoint))
        return RibbonFormHelper.NonClientHitTestResult.BottomLeft;
      Form form4 = this.Form;
      int num4 = num2 + this.Form.Width;
      margins = this.Margins;
      int right4 = margins.Right;
      int x4 = num4 - right4;
      int height2 = this.Form.Height;
      margins = this.Margins;
      int bottom3 = margins.Bottom;
      int y2 = height2 - bottom3;
      margins = this.Margins;
      int right5 = margins.Right;
      margins = this.Margins;
      int bottom4 = margins.Bottom;
      Rectangle r4 = new Rectangle(x4, y2, right5, bottom4);
      if (form4.RectangleToScreen(r4).Contains(hitPoint))
        return RibbonFormHelper.NonClientHitTestResult.BottomRight;
      Form form5 = this.Form;
      int width1 = this.Form.Width;
      margins = this.Margins;
      int left4 = margins.Left;
      Rectangle r5 = new Rectangle(0, 0, width1, left4);
      if (form5.RectangleToScreen(r5).Contains(hitPoint))
        return RibbonFormHelper.NonClientHitTestResult.Top;
      Form form6 = this.Form;
      margins = this.Margins;
      int left5 = margins.Left;
      int width2 = this.Form.Width;
      margins = this.Margins;
      int top = margins.Top;
      margins = this.Margins;
      int left6 = margins.Left;
      int height3 = top - left6;
      Rectangle r6 = new Rectangle(0, left5, width2, height3);
      if (form6.RectangleToScreen(r6).Contains(hitPoint))
        return RibbonFormHelper.NonClientHitTestResult.Caption;
      Form form7 = this.Form;
      int x5 = num1;
      margins = this.Margins;
      int left7 = margins.Left;
      int height4 = this.Form.Height;
      Rectangle r7 = new Rectangle(x5, 0, left7, height4);
      if (form7.RectangleToScreen(r7).Contains(hitPoint))
        return RibbonFormHelper.NonClientHitTestResult.Left;
      Form form8 = this.Form;
      int num5 = num2 + this.Form.Width;
      margins = this.Margins;
      int right6 = margins.Right;
      int x6 = num5 - right6;
      margins = this.Margins;
      int right7 = margins.Right;
      int height5 = this.Form.Height;
      Rectangle r8 = new Rectangle(x6, 0, right7, height5);
      if (form8.RectangleToScreen(r8).Contains(hitPoint))
        return RibbonFormHelper.NonClientHitTestResult.Right;
      Form form9 = this.Form;
      int height6 = this.Form.Height;
      margins = this.Margins;
      int bottom5 = margins.Bottom;
      int y3 = height6 - bottom5;
      int width3 = this.Form.Width;
      margins = this.Margins;
      int bottom6 = margins.Bottom;
      Rectangle r9 = new Rectangle(0, y3, width3, bottom6);
      return form9.RectangleToScreen(r9).Contains(hitPoint) ? RibbonFormHelper.NonClientHitTestResult.Bottom : RibbonFormHelper.NonClientHitTestResult.Client;
    }

    private void SetMargins(Padding p)
    {
      this.Margins = p;
      Padding padding = p;
      padding.Top = p.Bottom - 1;
      if (this.DesignMode)
        return;
      if (WinApi.IsWin10)
      {
        padding.Left = 0;
        padding.Right = 0;
        padding.Bottom = 0;
      }
      this.Form.Padding = padding;
    }

    public enum NonClientHitTestResult
    {
      Nowhere = 0,
      Client = 1,
      Caption = 2,
      GrowBox = 4,
      MinimizeButton = 8,
      MaximizeButton = 9,
      Left = 10, // 0x0000000A
      Right = 11, // 0x0000000B
      Top = 12, // 0x0000000C
      TopLeft = 13, // 0x0000000D
      TopRight = 14, // 0x0000000E
      Bottom = 15, // 0x0000000F
      BottomLeft = 16, // 0x00000010
      BottomRight = 17, // 0x00000011
    }
  }
}
