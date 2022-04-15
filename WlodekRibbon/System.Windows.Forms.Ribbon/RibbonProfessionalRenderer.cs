// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonProfessionalRenderer
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms.RibbonHelpers;
using System.Windows.Forms.VisualStyles;

namespace System.Windows.Forms
{
  public class RibbonProfessionalRenderer : RibbonRenderer
  {
    private readonly Size arrowSize = new Size(5, 3);
    private readonly Ribbon _ownerRibbon;

    public RibbonProfessionalRenderer(Ribbon ownerRibbon) => this._ownerRibbon = ownerRibbon;

    public Theme Theme => this._ownerRibbon != null ? this._ownerRibbon.Theme : Theme.Standard;

    public RibbonProfesionalRendererColorTable ColorTable => this.Theme.RendererColorTable;

    public Color GetTextColor(bool enabled, Color alternative) => enabled ? alternative : this.ColorTable.ArrowDisabled;

    public Color LightenColor(Color color, float correctionFactor)
    {
      float r = (float) color.R;
      float g = (float) color.G;
      float b = (float) color.B;
      if (0.0 < (double) correctionFactor && (double) correctionFactor < 1.0)
      {
        r += ((float) byte.MaxValue - r) * correctionFactor;
        g += ((float) byte.MaxValue - g) * correctionFactor;
        b += ((float) byte.MaxValue - b) * correctionFactor;
      }
      return Color.FromArgb((int) color.A, (int) r, (int) g, (int) b);
    }

    public Color DarkenColor(Color color, float correctionFactor)
    {
      float r = (float) color.R;
      float g = (float) color.G;
      float b = (float) color.B;
      if (0.0 < (double) correctionFactor && (double) correctionFactor < 1.0)
      {
        r -= r * correctionFactor;
        g -= g * correctionFactor;
        b -= b * correctionFactor;
      }
      return Color.FromArgb((int) color.A, (int) r, (int) g, (int) b);
    }

    public static GraphicsPath RoundRectangle(Rectangle r, int radius) => RibbonProfessionalRenderer.RoundRectangle(r, radius, RibbonProfessionalRenderer.Corners.All);

    public static GraphicsPath RoundRectangle(
      Rectangle r,
      int radius,
      RibbonProfessionalRenderer.Corners corners)
    {
      GraphicsPath graphicsPath = new GraphicsPath();
      int num1 = radius * 2;
      int num2 = (corners & RibbonProfessionalRenderer.Corners.NorthWest) == RibbonProfessionalRenderer.Corners.NorthWest ? num1 : 0;
      int num3 = (corners & RibbonProfessionalRenderer.Corners.NorthEast) == RibbonProfessionalRenderer.Corners.NorthEast ? num1 : 0;
      int num4 = (corners & RibbonProfessionalRenderer.Corners.SouthEast) == RibbonProfessionalRenderer.Corners.SouthEast ? num1 : 0;
      int num5 = (corners & RibbonProfessionalRenderer.Corners.SouthWest) == RibbonProfessionalRenderer.Corners.SouthWest ? num1 : 0;
      graphicsPath.AddLine(r.Left + num2, r.Top, r.Right - num3, r.Top);
      if (num3 > 0)
        graphicsPath.AddArc(Rectangle.FromLTRB(r.Right - num3, r.Top, r.Right, r.Top + num3), -90f, 90f);
      graphicsPath.AddLine(r.Right, r.Top + num3, r.Right, r.Bottom - num4);
      if (num4 > 0)
        graphicsPath.AddArc(Rectangle.FromLTRB(r.Right - num4, r.Bottom - num4, r.Right, r.Bottom), 0.0f, 90f);
      graphicsPath.AddLine(r.Right - num4, r.Bottom, r.Left + num5, r.Bottom);
      if (num5 > 0)
        graphicsPath.AddArc(Rectangle.FromLTRB(r.Left, r.Bottom - num5, r.Left + num5, r.Bottom), 90f, 90f);
      graphicsPath.AddLine(r.Left, r.Bottom - num5, r.Left, r.Top + num2);
      if (num2 > 0)
        graphicsPath.AddArc(Rectangle.FromLTRB(r.Left, r.Top, r.Left + num2, r.Top + num2), 180f, 90f);
      graphicsPath.CloseFigure();
      return graphicsPath;
    }

    public static GraphicsPath FlatRectangle(Rectangle r)
    {
      GraphicsPath graphicsPath = new GraphicsPath();
      graphicsPath.AddLine(r.Left, r.Top, r.Right, r.Top);
      graphicsPath.AddLine(r.Right, r.Top, r.Right, r.Bottom);
      graphicsPath.AddLine(r.Right, r.Bottom, r.Left, r.Bottom);
      graphicsPath.CloseFigure();
      return graphicsPath;
    }

    private void GradientRect(Graphics g, Rectangle r, Color northColor, Color southColor)
    {
      using (Brush brush = (Brush) new LinearGradientBrush(new Point(r.X, r.Y - 1), new Point(r.Left, r.Bottom), northColor, southColor))
        g.FillRectangle(brush, r);
    }

    public void DrawPressedShadow(Graphics g, Rectangle r)
    {
      Rectangle rectangle = Rectangle.FromLTRB(r.Left, r.Top, r.Right, r.Top + 4);
      using (GraphicsPath path = RibbonProfessionalRenderer.RoundRectangle(rectangle, 3, RibbonProfessionalRenderer.Corners.North))
      {
        using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, Color.FromArgb(50, Color.Black), Color.FromArgb(0, Color.Black), 90f))
        {
          linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
          g.FillPath((Brush) linearGradientBrush, path);
        }
      }
    }

    public void DrawArrow(Graphics g, Rectangle b, Color c, RibbonArrowDirection d)
    {
      GraphicsPath path = new GraphicsPath();
      Rectangle rectangle = b;
      if (b.Width % 2 != 0 && d == RibbonArrowDirection.Up)
        rectangle = new Rectangle(new Point(b.Left - 1, b.Top - 1), new Size(b.Width + 1, b.Height + 1));
      switch (d)
      {
        case RibbonArrowDirection.Up:
          path.AddLine(rectangle.Left, rectangle.Bottom, rectangle.Right, rectangle.Bottom);
          path.AddLine(rectangle.Right, rectangle.Bottom, rectangle.Left + rectangle.Width / 2, rectangle.Top);
          break;
        case RibbonArrowDirection.Down:
          path.AddLine(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Top);
          path.AddLine(rectangle.Right, rectangle.Top, rectangle.Left + rectangle.Width / 2, rectangle.Bottom);
          break;
        case RibbonArrowDirection.Left:
          path.AddLine(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Top + rectangle.Height / 2);
          path.AddLine(rectangle.Right, rectangle.Top + rectangle.Height / 2, rectangle.Left, rectangle.Bottom);
          break;
        default:
          path.AddLine(rectangle.Right, rectangle.Top, rectangle.Left, rectangle.Top + rectangle.Height / 2);
          path.AddLine(rectangle.Left, rectangle.Top + rectangle.Height / 2, rectangle.Right, rectangle.Bottom);
          break;
      }
      path.CloseFigure();
      using (SolidBrush solidBrush = new SolidBrush(c))
      {
        SmoothingMode smoothingMode = g.SmoothingMode;
        g.SmoothingMode = SmoothingMode.None;
        g.FillPath((Brush) solidBrush, path);
        g.SmoothingMode = smoothingMode;
      }
      path.Dispose();
    }

    public void DrawArrowShaded(Graphics g, Rectangle b, RibbonArrowDirection d, bool enabled)
    {
      Size size = this.arrowSize;
      if (d == RibbonArrowDirection.Left || d == RibbonArrowDirection.Right)
        size = new Size(this.arrowSize.Height, this.arrowSize.Width);
      Rectangle b1 = new Rectangle(new Point(b.Left + (b.Width - size.Width) / 2, b.Top + (b.Height - size.Height) / 2), size);
      Rectangle b2 = b1;
      b2.Offset(0, 1);
      Color c1 = this.ColorTable.ArrowLight;
      Color c2 = this.ColorTable.Arrow;
      if (!enabled)
      {
        c1 = Color.Transparent;
        c2 = this.ColorTable.ArrowDisabled;
      }
      this.DrawArrow(g, b2, c1, d);
      this.DrawArrow(g, b1, c2, d);
    }

    public Rectangle CenterOn(Rectangle container, Rectangle r) => new Rectangle(container.Left + (container.Width - r.Width) / 2, container.Top + (container.Height - r.Height) / 2, r.Width, r.Height);

    public void DrawGripDot(Graphics g, Point location)
    {
      Rectangle rect1 = new Rectangle(location.X - 1, location.Y + 1, 2, 2);
      Rectangle rect2 = new Rectangle(location, new Size(2, 2));
      using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.DropDownGripLight))
        g.FillRectangle((Brush) solidBrush, rect1);
      using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.DropDownGripDark))
        g.FillRectangle((Brush) solidBrush, rect2);
    }

    public GraphicsPath CreateCompleteTabPath_2007(RibbonTab t)
    {
      GraphicsPath graphicsPath1 = new GraphicsPath();
      int num = 6;
      Rectangle rectangle;
      if (t.Invisible)
      {
        GraphicsPath graphicsPath2 = graphicsPath1;
        int left = t.TabBounds.Left;
        int bottom1 = t.TabBounds.Bottom;
        int x2 = t.TabContentBounds.Right - num;
        rectangle = t.TabBounds;
        int bottom2 = rectangle.Bottom;
        graphicsPath2.AddLine(left, bottom1, x2, bottom2);
      }
      else
      {
        GraphicsPath graphicsPath3 = graphicsPath1;
        int left1 = t.TabBounds.Left - num;
        Rectangle tabBounds1 = t.TabBounds;
        int top1 = tabBounds1.Bottom - num;
        tabBounds1 = t.TabBounds;
        int left2 = tabBounds1.Left;
        tabBounds1 = t.TabBounds;
        int bottom3 = tabBounds1.Bottom;
        Rectangle rect1 = Rectangle.FromLTRB(left1, top1, left2, bottom3);
        graphicsPath3.AddArc(rect1, 90f, -90f);
        graphicsPath1.AddLine(t.TabBounds.Left, t.TabBounds.Bottom - num, t.TabBounds.Left, t.TabBounds.Top + num);
        GraphicsPath graphicsPath4 = graphicsPath1;
        int left3 = t.TabBounds.Left;
        Rectangle tabBounds2 = t.TabBounds;
        int top2 = tabBounds2.Top;
        tabBounds2 = t.TabBounds;
        int right1 = tabBounds2.Left + num;
        tabBounds2 = t.TabBounds;
        int bottom4 = tabBounds2.Top + num;
        Rectangle rect2 = Rectangle.FromLTRB(left3, top2, right1, bottom4);
        graphicsPath4.AddArc(rect2, 180f, 90f);
        GraphicsPath graphicsPath5 = graphicsPath1;
        int x1_1 = t.TabBounds.Left + num;
        Rectangle tabBounds3 = t.TabBounds;
        int top3 = tabBounds3.Top;
        tabBounds3 = t.TabBounds;
        int x2_1 = tabBounds3.Right - num;
        tabBounds3 = t.TabBounds;
        int top4 = tabBounds3.Top;
        graphicsPath5.AddLine(x1_1, top3, x2_1, top4);
        GraphicsPath graphicsPath6 = graphicsPath1;
        tabBounds3 = t.TabBounds;
        int left4 = tabBounds3.Right - num;
        Rectangle tabBounds4 = t.TabBounds;
        int top5 = tabBounds4.Top;
        tabBounds4 = t.TabBounds;
        int right2 = tabBounds4.Right;
        tabBounds4 = t.TabBounds;
        int bottom5 = tabBounds4.Top + num;
        Rectangle rect3 = Rectangle.FromLTRB(left4, top5, right2, bottom5);
        graphicsPath6.AddArc(rect3, -90f, 90f);
        graphicsPath1.AddLine(t.TabBounds.Right, t.TabBounds.Top + num, t.TabBounds.Right, t.TabBounds.Bottom - num);
        GraphicsPath graphicsPath7 = graphicsPath1;
        int right3 = t.TabBounds.Right;
        Rectangle tabBounds5 = t.TabBounds;
        int top6 = tabBounds5.Bottom - num;
        tabBounds5 = t.TabBounds;
        int right4 = tabBounds5.Right + num;
        tabBounds5 = t.TabBounds;
        int bottom6 = tabBounds5.Bottom;
        Rectangle rect4 = Rectangle.FromLTRB(right3, top6, right4, bottom6);
        graphicsPath7.AddArc(rect4, -180f, -90f);
        GraphicsPath graphicsPath8 = graphicsPath1;
        int x1_2 = t.TabBounds.Right + num;
        rectangle = t.TabBounds;
        int bottom7 = rectangle.Bottom;
        rectangle = t.TabContentBounds;
        int x2_2 = rectangle.Right - num;
        rectangle = t.TabBounds;
        int bottom8 = rectangle.Bottom;
        graphicsPath8.AddLine(x1_2, bottom7, x2_2, bottom8);
      }
      GraphicsPath graphicsPath9 = graphicsPath1;
      rectangle = t.TabContentBounds;
      int left5 = rectangle.Right - num;
      rectangle = t.TabBounds;
      int bottom9 = rectangle.Bottom;
      rectangle = t.TabContentBounds;
      int right5 = rectangle.Right;
      rectangle = t.TabBounds;
      int bottom10 = rectangle.Bottom + num;
      Rectangle rect5 = Rectangle.FromLTRB(left5, bottom9, right5, bottom10);
      graphicsPath9.AddArc(rect5, -90f, 90f);
      GraphicsPath graphicsPath10 = graphicsPath1;
      rectangle = t.TabContentBounds;
      int right6 = rectangle.Right;
      rectangle = t.TabContentBounds;
      int y1_1 = rectangle.Top + num;
      rectangle = t.TabContentBounds;
      int right7 = rectangle.Right;
      rectangle = t.TabContentBounds;
      int y2_1 = rectangle.Bottom - num;
      graphicsPath10.AddLine(right6, y1_1, right7, y2_1);
      GraphicsPath graphicsPath11 = graphicsPath1;
      rectangle = t.TabContentBounds;
      int left6 = rectangle.Right - num;
      rectangle = t.TabContentBounds;
      int top7 = rectangle.Bottom - num;
      rectangle = t.TabContentBounds;
      int right8 = rectangle.Right;
      rectangle = t.TabContentBounds;
      int bottom11 = rectangle.Bottom;
      Rectangle rect6 = Rectangle.FromLTRB(left6, top7, right8, bottom11);
      graphicsPath11.AddArc(rect6, 0.0f, 90f);
      GraphicsPath graphicsPath12 = graphicsPath1;
      rectangle = t.TabContentBounds;
      int x1_3 = rectangle.Right - num;
      rectangle = t.TabContentBounds;
      int bottom12 = rectangle.Bottom;
      rectangle = t.TabContentBounds;
      int x2_3 = rectangle.Left + num;
      rectangle = t.TabContentBounds;
      int bottom13 = rectangle.Bottom;
      graphicsPath12.AddLine(x1_3, bottom12, x2_3, bottom13);
      GraphicsPath graphicsPath13 = graphicsPath1;
      rectangle = t.TabContentBounds;
      int left7 = rectangle.Left;
      rectangle = t.TabContentBounds;
      int top8 = rectangle.Bottom - num;
      rectangle = t.TabContentBounds;
      int right9 = rectangle.Left + num;
      rectangle = t.TabContentBounds;
      int bottom14 = rectangle.Bottom;
      Rectangle rect7 = Rectangle.FromLTRB(left7, top8, right9, bottom14);
      graphicsPath13.AddArc(rect7, 90f, 90f);
      GraphicsPath graphicsPath14 = graphicsPath1;
      rectangle = t.TabContentBounds;
      int left8 = rectangle.Left;
      rectangle = t.TabContentBounds;
      int y1_2 = rectangle.Bottom - num;
      rectangle = t.TabContentBounds;
      int left9 = rectangle.Left;
      rectangle = t.TabBounds;
      int y2_2 = rectangle.Bottom + num;
      graphicsPath14.AddLine(left8, y1_2, left9, y2_2);
      GraphicsPath graphicsPath15 = graphicsPath1;
      rectangle = t.TabContentBounds;
      int left10 = rectangle.Left;
      rectangle = t.TabBounds;
      int bottom15 = rectangle.Bottom;
      rectangle = t.TabContentBounds;
      int right10 = rectangle.Left + num;
      rectangle = t.TabBounds;
      int bottom16 = rectangle.Bottom + num;
      Rectangle rect8 = Rectangle.FromLTRB(left10, bottom15, right10, bottom16);
      graphicsPath15.AddArc(rect8, 180f, 90f);
      GraphicsPath graphicsPath16 = graphicsPath1;
      rectangle = t.TabContentBounds;
      int x1_4 = rectangle.Left + num;
      rectangle = t.TabContentBounds;
      int top9 = rectangle.Top;
      rectangle = t.TabBounds;
      int x2_4 = rectangle.Left - num;
      rectangle = t.TabBounds;
      int bottom17 = rectangle.Bottom;
      graphicsPath16.AddLine(x1_4, top9, x2_4, bottom17);
      graphicsPath1.CloseFigure();
      return graphicsPath1;
    }

    public GraphicsPath CreateCompleteTopTabPath_2010(RibbonTab t)
    {
      GraphicsPath graphicsPath1 = new GraphicsPath();
      int num = 6;
      GraphicsPath graphicsPath2 = graphicsPath1;
      Rectangle rectangle1 = t.TabContentBounds;
      int left1 = rectangle1.Left;
      rectangle1 = t.TabContentBounds;
      int top1 = rectangle1.Top;
      rectangle1 = t.TabBounds;
      int x2_1 = rectangle1.Left - num;
      rectangle1 = t.TabBounds;
      int bottom1 = rectangle1.Bottom;
      graphicsPath2.AddLine(left1, top1, x2_1, bottom1);
      if (t.Invisible)
      {
        GraphicsPath graphicsPath3 = graphicsPath1;
        Rectangle rectangle2 = t.TabBounds;
        int left2 = rectangle2.Left;
        rectangle2 = t.TabBounds;
        int bottom2 = rectangle2.Bottom;
        rectangle2 = t.TabContentBounds;
        int x2_2 = rectangle2.Right - num;
        rectangle2 = t.TabBounds;
        int bottom3 = rectangle2.Bottom;
        graphicsPath3.AddLine(left2, bottom2, x2_2, bottom3);
      }
      else
      {
        GraphicsPath graphicsPath4 = graphicsPath1;
        Rectangle tabBounds1 = t.TabBounds;
        int left3 = tabBounds1.Left - num;
        tabBounds1 = t.TabBounds;
        int top2 = tabBounds1.Bottom - num;
        tabBounds1 = t.TabBounds;
        int left4 = tabBounds1.Left;
        tabBounds1 = t.TabBounds;
        int bottom4 = tabBounds1.Bottom;
        Rectangle rect1 = Rectangle.FromLTRB(left3, top2, left4, bottom4);
        graphicsPath4.AddArc(rect1, 90f, -90f);
        GraphicsPath graphicsPath5 = graphicsPath1;
        int left5 = t.TabBounds.Left;
        int y1_1 = t.TabBounds.Bottom - num;
        Rectangle tabBounds2 = t.TabBounds;
        int left6 = tabBounds2.Left;
        tabBounds2 = t.TabBounds;
        int y2_1 = tabBounds2.Top + num;
        graphicsPath5.AddLine(left5, y1_1, left6, y2_1);
        GraphicsPath graphicsPath6 = graphicsPath1;
        Rectangle tabBounds3 = t.TabBounds;
        int left7 = tabBounds3.Left;
        tabBounds3 = t.TabBounds;
        int top3 = tabBounds3.Top;
        tabBounds3 = t.TabBounds;
        int right1 = tabBounds3.Left + num;
        tabBounds3 = t.TabBounds;
        int bottom5 = tabBounds3.Top + num;
        Rectangle rect2 = Rectangle.FromLTRB(left7, top3, right1, bottom5);
        graphicsPath6.AddArc(rect2, 180f, 90f);
        GraphicsPath graphicsPath7 = graphicsPath1;
        Rectangle tabBounds4 = t.TabBounds;
        int x1_1 = tabBounds4.Left + num;
        tabBounds4 = t.TabBounds;
        int top4 = tabBounds4.Top;
        tabBounds4 = t.TabBounds;
        int x2_3 = tabBounds4.Right - num;
        tabBounds4 = t.TabBounds;
        int top5 = tabBounds4.Top;
        graphicsPath7.AddLine(x1_1, top4, x2_3, top5);
        GraphicsPath graphicsPath8 = graphicsPath1;
        Rectangle tabBounds5 = t.TabBounds;
        int left8 = tabBounds5.Right - num;
        tabBounds5 = t.TabBounds;
        int top6 = tabBounds5.Top;
        tabBounds5 = t.TabBounds;
        int right2 = tabBounds5.Right;
        tabBounds5 = t.TabBounds;
        int bottom6 = tabBounds5.Top + num;
        Rectangle rect3 = Rectangle.FromLTRB(left8, top6, right2, bottom6);
        graphicsPath8.AddArc(rect3, -90f, 90f);
        GraphicsPath graphicsPath9 = graphicsPath1;
        Rectangle tabBounds6 = t.TabBounds;
        int right3 = tabBounds6.Right;
        tabBounds6 = t.TabBounds;
        int y1_2 = tabBounds6.Top + num;
        tabBounds6 = t.TabBounds;
        int right4 = tabBounds6.Right;
        tabBounds6 = t.TabBounds;
        int y2_2 = tabBounds6.Bottom - num;
        graphicsPath9.AddLine(right3, y1_2, right4, y2_2);
        GraphicsPath graphicsPath10 = graphicsPath1;
        Rectangle tabBounds7 = t.TabBounds;
        int right5 = tabBounds7.Right;
        tabBounds7 = t.TabBounds;
        int top7 = tabBounds7.Bottom - num;
        tabBounds7 = t.TabBounds;
        int right6 = tabBounds7.Right + num;
        tabBounds7 = t.TabBounds;
        int bottom7 = tabBounds7.Bottom;
        Rectangle rect4 = Rectangle.FromLTRB(right5, top7, right6, bottom7);
        graphicsPath10.AddArc(rect4, -180f, -90f);
        GraphicsPath graphicsPath11 = graphicsPath1;
        Rectangle rectangle3 = t.TabBounds;
        int x1_2 = rectangle3.Right + num;
        rectangle3 = t.TabBounds;
        int bottom8 = rectangle3.Bottom;
        rectangle3 = t.TabContentBounds;
        int right7 = rectangle3.Right;
        rectangle3 = t.TabBounds;
        int bottom9 = rectangle3.Bottom;
        graphicsPath11.AddLine(x1_2, bottom8, right7, bottom9);
      }
      return graphicsPath1;
    }

    public GraphicsPath CreateCompleteTabPath_2013(RibbonTab t)
    {
      GraphicsPath graphicsPath1 = new GraphicsPath();
      GraphicsPath graphicsPath2 = graphicsPath1;
      Rectangle rectangle1 = t.TabContentBounds;
      int left1 = rectangle1.Left;
      rectangle1 = t.TabContentBounds;
      int top1 = rectangle1.Top;
      rectangle1 = t.TabBounds;
      int left2 = rectangle1.Left;
      rectangle1 = t.TabBounds;
      int bottom1 = rectangle1.Bottom;
      graphicsPath2.AddLine(left1, top1, left2, bottom1);
      if (t.Invisible)
      {
        graphicsPath1.AddLine(t.TabBounds.Left, t.TabBounds.Bottom, t.TabContentBounds.Right, t.TabBounds.Bottom);
      }
      else
      {
        graphicsPath1.AddLine(t.TabBounds.Left, t.TabBounds.Bottom, t.TabBounds.Left, t.TabBounds.Top);
        GraphicsPath graphicsPath3 = graphicsPath1;
        Rectangle rectangle2 = t.TabBounds;
        int left3 = rectangle2.Left;
        rectangle2 = t.TabBounds;
        int top2 = rectangle2.Top;
        rectangle2 = t.TabBounds;
        int right1 = rectangle2.Right;
        rectangle2 = t.TabBounds;
        int top3 = rectangle2.Top;
        graphicsPath3.AddLine(left3, top2, right1, top3);
        GraphicsPath graphicsPath4 = graphicsPath1;
        rectangle2 = t.TabBounds;
        int right2 = rectangle2.Right;
        rectangle2 = t.TabBounds;
        int top4 = rectangle2.Top;
        rectangle2 = t.TabBounds;
        int right3 = rectangle2.Right;
        rectangle2 = t.TabBounds;
        int bottom2 = rectangle2.Bottom;
        graphicsPath4.AddLine(right2, top4, right3, bottom2);
        GraphicsPath graphicsPath5 = graphicsPath1;
        rectangle2 = t.TabBounds;
        int right4 = rectangle2.Right;
        rectangle2 = t.TabBounds;
        int bottom3 = rectangle2.Bottom;
        rectangle2 = t.TabContentBounds;
        int right5 = rectangle2.Right;
        rectangle2 = t.TabBounds;
        int bottom4 = rectangle2.Bottom;
        graphicsPath5.AddLine(right4, bottom3, right5, bottom4);
      }
      return graphicsPath1;
    }

    public GraphicsPath CreateTabPath_2010(RibbonTab t)
    {
      GraphicsPath graphicsPath = new GraphicsPath();
      int num1 = 6;
      int num2 = 1;
      Rectangle tabBounds1 = t.TabBounds;
      int left1 = tabBounds1.Left;
      tabBounds1 = t.TabBounds;
      int bottom1 = tabBounds1.Bottom;
      tabBounds1 = t.TabBounds;
      int left2 = tabBounds1.Left;
      tabBounds1 = t.TabBounds;
      int y2 = tabBounds1.Top + num1;
      graphicsPath.AddLine(left1, bottom1, left2, y2);
      Rectangle tabBounds2 = t.TabBounds;
      int left3 = tabBounds2.Left;
      tabBounds2 = t.TabBounds;
      int top1 = tabBounds2.Top;
      int width1 = num1;
      int height1 = num1;
      graphicsPath.AddArc(new Rectangle(left3, top1, width1, height1), 180f, 90f);
      Rectangle tabBounds3 = t.TabBounds;
      int x1_1 = tabBounds3.Left + num1;
      tabBounds3 = t.TabBounds;
      int top2 = tabBounds3.Top;
      tabBounds3 = t.TabBounds;
      int x2_1 = tabBounds3.Right - num1 - num2;
      tabBounds3 = t.TabBounds;
      int top3 = tabBounds3.Top;
      graphicsPath.AddLine(x1_1, top2, x2_1, top3);
      Rectangle tabBounds4 = t.TabBounds;
      int x = tabBounds4.Right - num1 - num2;
      tabBounds4 = t.TabBounds;
      int top4 = tabBounds4.Top;
      int width2 = num1;
      int height2 = num1;
      graphicsPath.AddArc(new Rectangle(x, top4, width2, height2), -90f, 90f);
      Rectangle tabBounds5 = t.TabBounds;
      int x1_2 = tabBounds5.Right - num2;
      tabBounds5 = t.TabBounds;
      int y1 = tabBounds5.Top + num1;
      tabBounds5 = t.TabBounds;
      int x2_2 = tabBounds5.Right - num2;
      tabBounds5 = t.TabBounds;
      int bottom2 = tabBounds5.Bottom;
      graphicsPath.AddLine(x1_2, y1, x2_2, bottom2);
      return graphicsPath;
    }

    public GraphicsPath CreateTabPath_2013(RibbonTab t)
    {
      GraphicsPath graphicsPath = new GraphicsPath();
      int num = 1;
      Rectangle tabBounds1 = t.TabBounds;
      int left1 = tabBounds1.Left;
      tabBounds1 = t.TabBounds;
      int bottom1 = tabBounds1.Bottom;
      tabBounds1 = t.TabBounds;
      int left2 = tabBounds1.Left;
      tabBounds1 = t.TabBounds;
      int top1 = tabBounds1.Top;
      graphicsPath.AddLine(left1, bottom1, left2, top1);
      Rectangle tabBounds2 = t.TabBounds;
      int left3 = tabBounds2.Left;
      tabBounds2 = t.TabBounds;
      int top2 = tabBounds2.Top;
      tabBounds2 = t.TabBounds;
      int x2_1 = tabBounds2.Right - num;
      tabBounds2 = t.TabBounds;
      int top3 = tabBounds2.Top;
      graphicsPath.AddLine(left3, top2, x2_1, top3);
      Rectangle tabBounds3 = t.TabBounds;
      int x1 = tabBounds3.Right - num;
      tabBounds3 = t.TabBounds;
      int top4 = tabBounds3.Top;
      tabBounds3 = t.TabBounds;
      int x2_2 = tabBounds3.Right - num;
      tabBounds3 = t.TabBounds;
      int bottom2 = tabBounds3.Bottom;
      graphicsPath.AddLine(x1, top4, x2_2, bottom2);
      return graphicsPath;
    }

    public void DrawCompleteTab(RibbonTabRenderEventArgs e)
    {
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
      {
        using (GraphicsPath path = RibbonProfessionalRenderer.RoundRectangle(e.Tab.TabContentBounds, 4))
        {
          Color color1 = this.ColorTable.TabContentNorth;
          Color color2 = this.ColorTable.TabContentSouth;
          if (e.Tab.Contextual)
          {
            color1 = this.ColorTable.DropDownBg;
            color2 = color1;
          }
          int num = e.Tab.TabContentBounds.Height / 2;
          using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(0, e.Tab.TabContentBounds.Top + num), new Point(0, e.Tab.TabContentBounds.Bottom - 10), color1, color2))
          {
            linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
            SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = SmoothingMode.None;
            e.Graphics.FillPath((Brush) linearGradientBrush, path);
            e.Graphics.SmoothingMode = smoothingMode;
          }
        }
        if (!e.Tab.Invisible)
        {
          Rectangle tabContentBounds = e.Tab.TabContentBounds;
          int left = tabContentBounds.Left;
          tabContentBounds = e.Tab.TabContentBounds;
          int top = tabContentBounds.Top + 1;
          int right = e.Tab.TabContentBounds.Right;
          int bottom = e.Tab.TabContentBounds.Top + 18;
          using (GraphicsPath path = RibbonProfessionalRenderer.RoundRectangle(Rectangle.FromLTRB(left, top, right, bottom), 6, RibbonProfessionalRenderer.Corners.North))
          {
            using (Brush brush = (Brush) new SolidBrush(Color.FromArgb(30, Color.White)))
            {
              SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
              e.Graphics.SmoothingMode = SmoothingMode.None;
              e.Graphics.FillPath(brush, path);
              e.Graphics.SmoothingMode = smoothingMode;
            }
          }
        }
        using (GraphicsPath completeTabPath2007 = this.CreateCompleteTabPath_2007(e.Tab))
        {
          using (Pen pen = new Pen(this.ColorTable.TabBorder))
          {
            SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawPath(pen, completeTabPath2007);
            e.Graphics.SmoothingMode = smoothingMode;
          }
        }
      }
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
      {
        using (GraphicsPath path = RibbonProfessionalRenderer.FlatRectangle(e.Tab.TabContentBounds))
        {
          Color tabContentNorth = this.ColorTable.TabContentNorth;
          Color tabContentSouth = this.ColorTable.TabContentSouth;
          Rectangle tabContentBounds = e.Tab.TabContentBounds;
          Point point1 = new Point(0, tabContentBounds.Top);
          tabContentBounds = e.Tab.TabContentBounds;
          Point point2 = new Point(0, tabContentBounds.Bottom);
          Color color1 = tabContentNorth;
          Color color2 = tabContentSouth;
          using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(point1, point2, color1, color2))
          {
            SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = SmoothingMode.None;
            e.Graphics.FillPath((Brush) linearGradientBrush, path);
            e.Graphics.SmoothingMode = smoothingMode;
          }
        }
        using (GraphicsPath completeTopTabPath2010 = this.CreateCompleteTopTabPath_2010(e.Tab))
        {
          using (Pen pen = new Pen(this.ColorTable.TabBorder))
          {
            SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawPath(pen, completeTopTabPath2010);
            e.Graphics.SmoothingMode = smoothingMode;
          }
        }
        using (GraphicsPath path = new GraphicsPath())
        {
          GraphicsPath graphicsPath = path;
          int right = e.Tab.TabContentBounds.Right;
          int bottom1 = e.Tab.TabContentBounds.Bottom;
          Rectangle tabContentBounds = e.Tab.TabContentBounds;
          int left = tabContentBounds.Left;
          tabContentBounds = e.Tab.TabContentBounds;
          int bottom2 = tabContentBounds.Bottom;
          graphicsPath.AddLine(right, bottom1, left, bottom2);
          using (Pen pen = new Pen(this.ColorTable.TabBorder))
          {
            SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = SmoothingMode.None;
            e.Graphics.DrawPath(pen, path);
            e.Graphics.SmoothingMode = smoothingMode;
          }
        }
      }
      if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
        return;
      using (GraphicsPath path = RibbonProfessionalRenderer.FlatRectangle(e.Tab.TabContentBounds))
      {
        using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.TabCompleteBackground_2013))
        {
          SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
          e.Graphics.SmoothingMode = SmoothingMode.None;
          e.Graphics.FillPath((Brush) solidBrush, path);
          e.Graphics.SmoothingMode = smoothingMode;
        }
      }
      using (GraphicsPath completeTabPath2013 = this.CreateCompleteTabPath_2013(e.Tab))
      {
        using (Pen pen = new Pen(this.ColorTable.TabBorder_2013))
        {
          SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
          e.Graphics.SmoothingMode = SmoothingMode.None;
          e.Graphics.DrawPath(pen, completeTabPath2013);
          e.Graphics.SmoothingMode = smoothingMode;
        }
      }
    }

    public void DrawTabActiveSelected(RibbonTabRenderEventArgs e)
    {
      if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2007)
        return;
      using (GraphicsPath tabPath2010 = this.CreateTabPath_2010(e.Tab))
      {
        Pen pen = new Pen(Color.FromArgb(150, Color.Gold))
        {
          Width = 2f
        };
        e.Graphics.DrawPath(pen, tabPath2010);
        pen.Dispose();
      }
    }

    public void DrawTabNormal(RibbonTabRenderEventArgs e)
    {
      if (e.Tab.Invisible)
        return;
      RectangleF clipBounds = e.Graphics.ClipBounds;
      Rectangle tabBounds = e.Tab.TabBounds;
      int left1 = tabBounds.Left;
      tabBounds = e.Tab.TabBounds;
      int top1 = tabBounds.Top;
      tabBounds = e.Tab.TabBounds;
      int right1 = tabBounds.Right;
      tabBounds = e.Tab.TabBounds;
      int bottom1 = tabBounds.Bottom;
      Rectangle rect = Rectangle.FromLTRB(left1, top1, right1, bottom1);
      tabBounds = e.Tab.TabBounds;
      int left2 = tabBounds.Left - 1;
      tabBounds = e.Tab.TabBounds;
      int top2 = tabBounds.Top - 1;
      tabBounds = e.Tab.TabBounds;
      int right2 = tabBounds.Right;
      tabBounds = e.Tab.TabBounds;
      int bottom2 = tabBounds.Bottom;
      Rectangle rectangle = Rectangle.FromLTRB(left2, top2, right2, bottom2);
      e.Graphics.SetClip(rect);
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
      {
        using (Brush brush = (Brush) new SolidBrush(this.ColorTable.RibbonBackground))
          e.Graphics.FillRectangle(brush, rectangle);
        if (e.Tab.Contextual)
        {
          using (GraphicsPath path = RibbonProfessionalRenderer.FlatRectangle(e.Tab.Bounds))
          {
            Color color1 = Color.FromArgb(40, e.Tab.Context.GlowColor);
            Color color = Color.FromArgb(20, e.Tab.Context.GlowColor);
            Color color2 = Color.FromArgb(0, e.Tab.Context.GlowColor);
            using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, color1, color2, 90f))
            {
              ColorBlend colorBlend = new ColorBlend(3)
              {
                Colors = new Color[3]
                {
                  color1,
                  color,
                  color2
                },
                Positions = new float[3]{ 0.0f, 0.3f, 1f }
              };
              linearGradientBrush.InterpolationColors = colorBlend;
              SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
              e.Graphics.SmoothingMode = SmoothingMode.None;
              e.Graphics.FillPath((Brush) linearGradientBrush, path);
              e.Graphics.SmoothingMode = smoothingMode;
            }
          }
        }
      }
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
      {
        if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass)
        {
          WinApi.FillForGlass(e.Graphics, rectangle);
        }
        else
        {
          using (Brush brush = (Brush) new SolidBrush(this.ColorTable.RibbonBackground))
            e.Graphics.FillRectangle(brush, rectangle);
        }
        if (e.Tab.Contextual)
        {
          using (GraphicsPath path = RibbonProfessionalRenderer.FlatRectangle(e.Tab.Bounds))
          {
            Color color1 = Color.FromArgb(40, e.Tab.Context.GlowColor);
            Color color = Color.FromArgb(20, e.Tab.Context.GlowColor);
            Color color2 = Color.FromArgb(0, e.Tab.Context.GlowColor);
            using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, color1, color2, 90f))
            {
              ColorBlend colorBlend = new ColorBlend(3)
              {
                Colors = new Color[3]
                {
                  color1,
                  color,
                  color2
                },
                Positions = new float[3]{ 0.0f, 0.3f, 1f }
              };
              linearGradientBrush.InterpolationColors = colorBlend;
              SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
              e.Graphics.SmoothingMode = SmoothingMode.None;
              e.Graphics.FillPath((Brush) linearGradientBrush, path);
              e.Graphics.SmoothingMode = smoothingMode;
            }
          }
        }
      }
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2013)
      {
        if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass)
        {
          WinApi.FillForGlass(e.Graphics, rectangle);
        }
        else
        {
          using (Brush brush = (Brush) new SolidBrush(this.ColorTable.TabNormalBackground_2013))
            e.Graphics.FillRectangle(brush, rectangle);
        }
        if (e.Tab.Contextual)
        {
          using (GraphicsPath path = RibbonProfessionalRenderer.FlatRectangle(e.Tab.Bounds))
          {
            Color color1 = Color.FromArgb(40, e.Tab.Context.GlowColor);
            Color color = Color.FromArgb(20, e.Tab.Context.GlowColor);
            Color color2 = Color.FromArgb(0, e.Tab.Context.GlowColor);
            using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, color1, color2, 90f))
            {
              ColorBlend colorBlend = new ColorBlend(3)
              {
                Colors = new Color[3]
                {
                  color1,
                  color,
                  color2
                },
                Positions = new float[3]{ 0.0f, 0.3f, 1f }
              };
              linearGradientBrush.InterpolationColors = colorBlend;
              SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
              e.Graphics.SmoothingMode = SmoothingMode.None;
              e.Graphics.FillPath((Brush) linearGradientBrush, path);
              e.Graphics.SmoothingMode = smoothingMode;
            }
          }
        }
      }
      e.Graphics.SetClip(clipBounds);
    }

    public void DrawTabSelected(RibbonTabRenderEventArgs e)
    {
      if (e.Tab.Invisible)
        return;
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
      {
        Rectangle tabBounds = e.Tab.TabBounds;
        int left1 = tabBounds.Left;
        tabBounds = e.Tab.TabBounds;
        int top1 = tabBounds.Top;
        tabBounds = e.Tab.TabBounds;
        int right1 = tabBounds.Right - 1;
        tabBounds = e.Tab.TabBounds;
        int bottom1 = tabBounds.Bottom;
        Rectangle r1 = Rectangle.FromLTRB(left1, top1, right1, bottom1);
        Rectangle rectangle = Rectangle.FromLTRB(r1.Left + 1, r1.Top + 1, r1.Right - 1, r1.Bottom);
        int left2 = rectangle.Left + 1;
        int top2 = rectangle.Top + 1;
        int right2 = rectangle.Right - 1;
        int top3 = rectangle.Top;
        tabBounds = e.Tab.TabBounds;
        int num = tabBounds.Height / 2;
        int bottom2 = top3 + num;
        Rectangle r2 = Rectangle.FromLTRB(left2, top2, right2, bottom2);
        GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(r1, 3, RibbonProfessionalRenderer.Corners.North);
        GraphicsPath path2 = RibbonProfessionalRenderer.RoundRectangle(rectangle, 3, RibbonProfessionalRenderer.Corners.North);
        GraphicsPath path3 = RibbonProfessionalRenderer.RoundRectangle(r2, 3, RibbonProfessionalRenderer.Corners.North);
        using (Pen pen = new Pen(this.ColorTable.TabBorder))
          e.Graphics.DrawPath(pen, path1);
        using (Pen pen = new Pen(Color.FromArgb(200, Color.White)))
          e.Graphics.DrawPath(pen, path2);
        using (GraphicsPath path4 = new GraphicsPath())
        {
          path4.AddRectangle(rectangle);
          path4.CloseFigure();
          PathGradientBrush pathGradientBrush = new PathGradientBrush(path4)
          {
            CenterPoint = new PointF(Convert.ToSingle(rectangle.Left + rectangle.Width / 2), Convert.ToSingle(rectangle.Top - 5)),
            CenterColor = Color.Transparent,
            SurroundColors = new Color[1]
            {
              this.ColorTable.TabSelectedGlow
            }
          };
          pathGradientBrush.Blend = new Blend(3)
          {
            Factors = new float[3]{ 0.0f, 0.9f, 0.0f },
            Positions = new float[3]{ 0.0f, 0.8f, 1f }
          };
          e.Graphics.FillPath((Brush) pathGradientBrush, path4);
          pathGradientBrush.Dispose();
        }
        using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(100, Color.White)))
          e.Graphics.FillPath((Brush) solidBrush, path3);
        path1.Dispose();
        path2.Dispose();
        path3.Dispose();
      }
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
      {
        Rectangle tabBounds = e.Tab.TabBounds;
        int left3 = tabBounds.Left;
        tabBounds = e.Tab.TabBounds;
        int top4 = tabBounds.Top;
        tabBounds = e.Tab.TabBounds;
        int right3 = tabBounds.Right - 1;
        tabBounds = e.Tab.TabBounds;
        int bottom3 = tabBounds.Bottom;
        Rectangle r3 = Rectangle.FromLTRB(left3, top4, right3, bottom3);
        Rectangle rectangle = Rectangle.FromLTRB(r3.Left + 1, r3.Top + 1, r3.Right - 1, r3.Bottom);
        int left4 = rectangle.Left + 1;
        int top5 = rectangle.Top + 1;
        int right4 = rectangle.Right - 1;
        int top6 = rectangle.Top;
        tabBounds = e.Tab.TabBounds;
        int height = tabBounds.Height;
        int bottom4 = top6 + height;
        Rectangle r4 = Rectangle.FromLTRB(left4, top5, right4, bottom4);
        RibbonProfessionalRenderer.RoundRectangle(r3, 3, RibbonProfessionalRenderer.Corners.North);
        GraphicsPath path5 = RibbonProfessionalRenderer.RoundRectangle(rectangle, 3, RibbonProfessionalRenderer.Corners.North);
        RibbonProfessionalRenderer.RoundRectangle(r4, 3, RibbonProfessionalRenderer.Corners.North);
        if (e.Tab.Contextual)
        {
          using (GraphicsPath path6 = RibbonProfessionalRenderer.RoundRectangle(r3, 6, RibbonProfessionalRenderer.Corners.North))
          {
            Color color1 = Color.FromArgb(200, e.Tab.Context.GlowColor);
            Color color = Color.FromArgb(40, e.Tab.Context.GlowColor);
            Color color2 = Color.FromArgb(0, e.Tab.Context.GlowColor);
            using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(e.Tab.TabBounds, color1, color2, 90f))
            {
              ColorBlend colorBlend = new ColorBlend(3)
              {
                Colors = new Color[3]
                {
                  color1,
                  color,
                  color2
                },
                Positions = new float[3]{ 0.0f, 0.3f, 1f }
              };
              linearGradientBrush.InterpolationColors = colorBlend;
              e.Graphics.FillPath((Brush) linearGradientBrush, path6);
            }
          }
        }
        using (GraphicsPath tabPath2010 = this.CreateTabPath_2010(e.Tab))
        {
          using (Pen pen = new Pen(this.ColorTable.TabSelectedBorder))
          {
            SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawPath(pen, tabPath2010);
            e.Graphics.SmoothingMode = smoothingMode;
          }
        }
        using (GraphicsPath path7 = new GraphicsPath())
        {
          path7.AddRectangle(rectangle);
          path7.CloseFigure();
          LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, Color.FromArgb(50, Color.Gray), Color.FromArgb(80, Color.White), 90f);
          linearGradientBrush.Blend = new Blend(3)
          {
            Factors = new float[3]{ 0.0f, 0.6f, 1f },
            Positions = new float[3]{ 0.0f, 0.2f, 1f }
          };
          e.Graphics.FillPath((Brush) linearGradientBrush, path7);
          linearGradientBrush.Dispose();
        }
        using (Pen pen = new Pen(Color.FromArgb(200, Color.White)))
          e.Graphics.DrawPath(pen, path5);
      }
      if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
        return;
      Rectangle tabBounds1 = e.Tab.TabBounds;
      int left5 = tabBounds1.Left;
      tabBounds1 = e.Tab.TabBounds;
      int top7 = tabBounds1.Top;
      tabBounds1 = e.Tab.TabBounds;
      int right5 = tabBounds1.Right - 1;
      tabBounds1 = e.Tab.TabBounds;
      int bottom5 = tabBounds1.Bottom;
      Rectangle r5 = Rectangle.FromLTRB(left5, top7, right5, bottom5);
      Rectangle r6 = Rectangle.FromLTRB(r5.Left + 1, r5.Top + 1, r5.Right - 1, r5.Bottom);
      int left6 = r6.Left + 1;
      int top8 = r6.Top + 1;
      int right6 = r6.Right - 1;
      int top9 = r6.Top;
      tabBounds1 = e.Tab.TabBounds;
      int height1 = tabBounds1.Height;
      int bottom6 = top9 + height1;
      Rectangle r7 = Rectangle.FromLTRB(left6, top8, right6, bottom6);
      GraphicsPath path = RibbonProfessionalRenderer.FlatRectangle(r5);
      RibbonProfessionalRenderer.FlatRectangle(r6);
      RibbonProfessionalRenderer.FlatRectangle(r7);
      using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.ButtonSelected_2013))
        e.Graphics.FillPath((Brush) solidBrush, path);
      using (GraphicsPath tabPath2013 = this.CreateTabPath_2013(e.Tab))
      {
        using (Pen pen = new Pen(this.ColorTable.ButtonSelected_2013))
        {
          SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
          e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
          e.Graphics.DrawPath(pen, tabPath2013);
          e.Graphics.SmoothingMode = smoothingMode;
        }
      }
    }

    public void DrawTabPressed(RibbonTabRenderEventArgs e)
    {
    }

    public void DrawTabActive(RibbonTabRenderEventArgs e)
    {
      if (e.Tab.Invisible)
        return;
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
      {
        Rectangle r = new Rectangle(e.Tab.TabBounds.Left, e.Tab.TabBounds.Top, e.Tab.TabBounds.Width, 4);
        Rectangle tabBounds1 = e.Tab.TabBounds;
        tabBounds1.Offset(2, 1);
        Rectangle tabBounds2 = e.Tab.TabBounds;
        if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
        {
          using (GraphicsPath path = RibbonProfessionalRenderer.RoundRectangle(tabBounds1, 6, RibbonProfessionalRenderer.Corners.North))
          {
            using (PathGradientBrush pathGradientBrush = new PathGradientBrush(path))
            {
              pathGradientBrush.WrapMode = WrapMode.Clamp;
              ColorBlend colorBlend = new ColorBlend(3)
              {
                Colors = new Color[3]
                {
                  Color.Transparent,
                  Color.FromArgb(50, Color.Black),
                  Color.FromArgb(100, Color.Black)
                },
                Positions = new float[3]{ 0.0f, 0.1f, 1f }
              };
              pathGradientBrush.InterpolationColors = colorBlend;
              e.Graphics.FillPath((Brush) pathGradientBrush, path);
            }
          }
        }
        using (GraphicsPath path = RibbonProfessionalRenderer.RoundRectangle(tabBounds2, 6, RibbonProfessionalRenderer.Corners.North))
        {
          Color tabNorth = this.ColorTable.TabNorth;
          Color tabSouth = this.ColorTable.TabSouth;
          if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
          {
            using (Pen pen = new Pen(tabNorth, 1.6f))
              e.Graphics.DrawPath(pen, path);
          }
          using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(e.Tab.TabBounds, tabNorth, tabSouth, 90f))
            e.Graphics.FillPath((Brush) linearGradientBrush, path);
        }
        if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2007)
          return;
        using (GraphicsPath path = RibbonProfessionalRenderer.RoundRectangle(r, 6, RibbonProfessionalRenderer.Corners.North))
        {
          using (Brush brush = (Brush) new SolidBrush(Color.FromArgb(180, Color.White)))
            e.Graphics.FillPath(brush, path);
        }
      }
      else
      {
        if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
          return;
        Rectangle tabBounds = e.Tab.TabBounds;
        int left = tabBounds.Left;
        tabBounds = e.Tab.TabBounds;
        int top = tabBounds.Top;
        tabBounds = e.Tab.TabBounds;
        int width = tabBounds.Width;
        tabBounds = e.Tab.TabBounds;
        int height = tabBounds.Height + 1;
        using (GraphicsPath path = RibbonProfessionalRenderer.FlatRectangle(new Rectangle(left, top, width, height)))
        {
          using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.TabActiveBackbround_2013))
            e.Graphics.FillPath((Brush) solidBrush, path);
        }
      }
    }

    public void DrawTabMinimized(RibbonTabRenderEventArgs e)
    {
      if (e.Tab.Invisible)
        return;
      if (e.Tab.Selected)
      {
        if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
        {
          Rectangle tabBounds = e.Tab.TabBounds;
          int left1 = tabBounds.Left;
          tabBounds = e.Tab.TabBounds;
          int top1 = tabBounds.Top;
          tabBounds = e.Tab.TabBounds;
          int right1 = tabBounds.Right - 1;
          tabBounds = e.Tab.TabBounds;
          int bottom1 = tabBounds.Bottom;
          Rectangle r1 = Rectangle.FromLTRB(left1, top1, right1, bottom1);
          Rectangle rectangle = Rectangle.FromLTRB(r1.Left + 1, r1.Top + 1, r1.Right - 1, r1.Bottom);
          int left2 = rectangle.Left + 1;
          int top2 = rectangle.Top + 1;
          int right2 = rectangle.Right - 1;
          int top3 = rectangle.Top;
          tabBounds = e.Tab.TabBounds;
          int num = tabBounds.Height / 2;
          int bottom2 = top3 + num;
          Rectangle r2 = Rectangle.FromLTRB(left2, top2, right2, bottom2);
          GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(r1, 3, RibbonProfessionalRenderer.Corners.North);
          GraphicsPath path2 = RibbonProfessionalRenderer.RoundRectangle(rectangle, 3, RibbonProfessionalRenderer.Corners.North);
          GraphicsPath path3 = RibbonProfessionalRenderer.RoundRectangle(r2, 3, RibbonProfessionalRenderer.Corners.North);
          using (Pen pen = new Pen(this.ColorTable.TabBorder))
            e.Graphics.DrawPath(pen, path1);
          using (Pen pen = new Pen(Color.FromArgb(200, Color.White)))
            e.Graphics.DrawPath(pen, path2);
          using (GraphicsPath path4 = new GraphicsPath())
          {
            path4.AddRectangle(rectangle);
            path4.CloseFigure();
            PathGradientBrush pathGradientBrush = new PathGradientBrush(path4)
            {
              CenterPoint = new PointF(Convert.ToSingle(rectangle.Left + rectangle.Width / 2), Convert.ToSingle(rectangle.Top - 5)),
              CenterColor = Color.Transparent,
              SurroundColors = new Color[1]
              {
                this.ColorTable.TabSelectedGlow
              }
            };
            pathGradientBrush.Blend = new Blend(3)
            {
              Factors = new float[3]{ 0.0f, 0.9f, 0.0f },
              Positions = new float[3]{ 0.0f, 0.8f, 1f }
            };
            e.Graphics.FillPath((Brush) pathGradientBrush, path4);
            pathGradientBrush.Dispose();
          }
          using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(100, Color.White)))
            e.Graphics.FillPath((Brush) solidBrush, path3);
          path1.Dispose();
          path2.Dispose();
          path3.Dispose();
        }
        if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
        {
          Rectangle tabBounds = e.Tab.TabBounds;
          int left3 = tabBounds.Left;
          tabBounds = e.Tab.TabBounds;
          int top4 = tabBounds.Top;
          tabBounds = e.Tab.TabBounds;
          int right3 = tabBounds.Right - 1;
          tabBounds = e.Tab.TabBounds;
          int bottom3 = tabBounds.Bottom;
          Rectangle r3 = Rectangle.FromLTRB(left3, top4, right3, bottom3);
          Rectangle rectangle = Rectangle.FromLTRB(r3.Left + 1, r3.Top + 1, r3.Right - 1, r3.Bottom);
          int left4 = rectangle.Left + 1;
          int top5 = rectangle.Top + 1;
          int right4 = rectangle.Right - 1;
          int top6 = rectangle.Top;
          tabBounds = e.Tab.TabBounds;
          int height = tabBounds.Height;
          int bottom4 = top6 + height;
          Rectangle r4 = Rectangle.FromLTRB(left4, top5, right4, bottom4);
          RibbonProfessionalRenderer.RoundRectangle(r3, 3, RibbonProfessionalRenderer.Corners.North);
          GraphicsPath path5 = RibbonProfessionalRenderer.RoundRectangle(rectangle, 3, RibbonProfessionalRenderer.Corners.North);
          RibbonProfessionalRenderer.RoundRectangle(r4, 3, RibbonProfessionalRenderer.Corners.North);
          using (GraphicsPath tabPath2010 = this.CreateTabPath_2010(e.Tab))
          {
            using (Pen pen = new Pen(this.ColorTable.TabSelectedBorder))
            {
              SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
              e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
              e.Graphics.DrawPath(pen, tabPath2010);
              e.Graphics.SmoothingMode = smoothingMode;
            }
          }
          using (GraphicsPath path6 = new GraphicsPath())
          {
            path6.AddRectangle(rectangle);
            path6.CloseFigure();
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, Color.FromArgb(50, Color.Gray), Color.FromArgb(80, Color.White), 90f);
            linearGradientBrush.Blend = new Blend(3)
            {
              Factors = new float[3]{ 0.0f, 0.6f, 1f },
              Positions = new float[3]{ 0.0f, 0.2f, 1f }
            };
            e.Graphics.FillPath((Brush) linearGradientBrush, path6);
            linearGradientBrush.Dispose();
          }
          using (Pen pen = new Pen(Color.FromArgb(200, Color.White)))
            e.Graphics.DrawPath(pen, path5);
        }
        if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
          return;
        Rectangle tabBounds1 = e.Tab.TabBounds;
        int left5 = tabBounds1.Left;
        tabBounds1 = e.Tab.TabBounds;
        int top7 = tabBounds1.Top;
        tabBounds1 = e.Tab.TabBounds;
        int right5 = tabBounds1.Right - 1;
        tabBounds1 = e.Tab.TabBounds;
        int bottom5 = tabBounds1.Bottom;
        Rectangle r5 = Rectangle.FromLTRB(left5, top7, right5, bottom5);
        Rectangle r6 = Rectangle.FromLTRB(r5.Left + 1, r5.Top + 1, r5.Right - 1, r5.Bottom);
        int left6 = r6.Left + 1;
        int top8 = r6.Top + 1;
        int right6 = r6.Right - 1;
        int top9 = r6.Top;
        tabBounds1 = e.Tab.TabBounds;
        int height1 = tabBounds1.Height;
        int bottom6 = top9 + height1;
        Rectangle r7 = Rectangle.FromLTRB(left6, top8, right6, bottom6);
        GraphicsPath path = RibbonProfessionalRenderer.FlatRectangle(r5);
        RibbonProfessionalRenderer.FlatRectangle(r6);
        RibbonProfessionalRenderer.FlatRectangle(r7);
        using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.ButtonSelected_2013))
          e.Graphics.FillPath((Brush) solidBrush, path);
        using (GraphicsPath tabPath2013 = this.CreateTabPath_2013(e.Tab))
        {
          using (Pen pen = new Pen(this.ColorTable.ButtonSelected_2013))
          {
            SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawPath(pen, tabPath2013);
            e.Graphics.SmoothingMode = smoothingMode;
          }
        }
      }
      else
      {
        RectangleF clipBounds = e.Graphics.ClipBounds;
        Rectangle tabBounds = e.Tab.TabBounds;
        int left7 = tabBounds.Left;
        tabBounds = e.Tab.TabBounds;
        int top10 = tabBounds.Top;
        tabBounds = e.Tab.TabBounds;
        int right7 = tabBounds.Right;
        tabBounds = e.Tab.TabBounds;
        int bottom7 = tabBounds.Bottom;
        Rectangle rect = Rectangle.FromLTRB(left7, top10, right7, bottom7);
        tabBounds = e.Tab.TabBounds;
        int left8 = tabBounds.Left - 1;
        tabBounds = e.Tab.TabBounds;
        int top11 = tabBounds.Top - 1;
        tabBounds = e.Tab.TabBounds;
        int right8 = tabBounds.Right;
        tabBounds = e.Tab.TabBounds;
        int bottom8 = tabBounds.Bottom;
        Rectangle rectangle = Rectangle.FromLTRB(left8, top11, right8, bottom8);
        e.Graphics.SetClip(rect);
        if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
        {
          using (Brush brush = (Brush) new SolidBrush(this.ColorTable.RibbonBackground))
            e.Graphics.FillRectangle(brush, rectangle);
        }
        if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
        {
          if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass)
          {
            WinApi.FillForGlass(e.Graphics, rectangle);
          }
          else
          {
            using (Brush brush = (Brush) new SolidBrush(this.ColorTable.RibbonBackground))
              e.Graphics.FillRectangle(brush, rectangle);
          }
        }
        if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2013)
        {
          if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass)
          {
            WinApi.FillForGlass(e.Graphics, rectangle);
          }
          else
          {
            using (Brush brush = (Brush) new SolidBrush(this.ColorTable.RibbonBackground_2013))
              e.Graphics.FillRectangle(brush, rectangle);
          }
        }
        e.Graphics.SetClip(clipBounds);
      }
    }

    public void DrawPanelNormal(RibbonPanelRenderEventArgs e)
    {
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
      {
        Rectangle r1 = Rectangle.FromLTRB(e.Panel.Bounds.Left, e.Panel.Bounds.Top, e.Panel.Bounds.Right, e.Panel.Bounds.Bottom);
        Rectangle r2 = Rectangle.FromLTRB(e.Panel.Bounds.Left + 1, e.Panel.Bounds.Top + 1, e.Panel.Bounds.Right + 1, e.Panel.Bounds.Bottom);
        Rectangle r3 = Rectangle.FromLTRB(e.Panel.Bounds.Left + 1, e.Panel.ContentBounds.Bottom, e.Panel.Bounds.Right - 1, e.Panel.Bounds.Bottom - 1);
        GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(r1, 3);
        GraphicsPath path2 = RibbonProfessionalRenderer.RoundRectangle(r2, 3);
        GraphicsPath path3 = RibbonProfessionalRenderer.RoundRectangle(r3, 3, RibbonProfessionalRenderer.Corners.South);
        using (Pen pen = new Pen(this.ColorTable.PanelLightBorder))
          e.Graphics.DrawPath(pen, path2);
        using (Pen pen = new Pen(this.ColorTable.PanelDarkBorder))
          e.Graphics.DrawPath(pen, path1);
        using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.PanelTextBackground))
          e.Graphics.FillPath((Brush) solidBrush, path3);
        path3.Dispose();
        path1.Dispose();
        path2.Dispose();
      }
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
      {
        Rectangle rect = Rectangle.FromLTRB(e.Panel.Bounds.Left, e.Panel.Bounds.Top, e.Panel.Bounds.Right - 2, e.Panel.Bounds.Bottom);
        Rectangle rectangle1 = Rectangle.FromLTRB(e.Panel.Bounds.Left, e.Panel.Bounds.Top, e.Panel.Bounds.Right - 1, e.Panel.Bounds.Bottom);
        int left = e.Panel.Bounds.Left;
        Rectangle bounds = e.Panel.Bounds;
        int top = bounds.Top;
        bounds = e.Panel.Bounds;
        int right = bounds.Right;
        bounds = e.Panel.Bounds;
        int bottom = bounds.Bottom;
        Rectangle rectangle2 = Rectangle.FromLTRB(left, top, right, bottom);
        using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, Color.FromArgb(30, this.ColorTable.PanelLightBorder), this.ColorTable.PanelLightBorder, 90f))
        {
          using (Pen pen = new Pen((Brush) linearGradientBrush))
          {
            SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = SmoothingMode.None;
            e.Graphics.DrawLine(pen, rect.Left, rect.Top, rect.Left, rect.Bottom);
            e.Graphics.DrawLine(pen, rect.Right, rect.Top, rect.Right, rect.Bottom);
            e.Graphics.DrawLine(pen, rectangle2.Right, rectangle2.Top, rectangle2.Right, rectangle2.Bottom);
            e.Graphics.SmoothingMode = smoothingMode;
          }
        }
        using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(e.Panel.Bounds, Color.FromArgb(30, this.ColorTable.PanelDarkBorder), this.ColorTable.PanelDarkBorder, LinearGradientMode.Vertical))
        {
          linearGradientBrush.WrapMode = WrapMode.TileFlipX;
          using (Pen pen = new Pen((Brush) linearGradientBrush))
          {
            SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = SmoothingMode.None;
            e.Graphics.DrawLine(pen, rectangle1.Right, rectangle1.Top, rectangle1.Right, rectangle1.Bottom);
            e.Graphics.SmoothingMode = smoothingMode;
          }
        }
        using (Pen pen = new Pen(this.ColorTable.TabContentSouth))
        {
          SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
          e.Graphics.SmoothingMode = SmoothingMode.None;
          e.Graphics.DrawLine(pen, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
          e.Graphics.SmoothingMode = smoothingMode;
        }
        if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
        {
          using (GraphicsPath path = RibbonProfessionalRenderer.RoundRectangle(Rectangle.FromLTRB(e.Panel.Bounds.Left + 1, e.Panel.ContentBounds.Bottom, e.Panel.Bounds.Right - 1, e.Panel.Bounds.Bottom - 1), 3, RibbonProfessionalRenderer.Corners.South))
          {
            using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(200, this.LightenColor(this.ColorTable.PanelTextBackground, 0.2f))))
              e.Graphics.FillPath((Brush) solidBrush, path);
          }
        }
      }
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2013)
      {
        using (Pen pen1 = new Pen(this.ColorTable.PanelBorder_2013))
        {
          Graphics graphics = e.Graphics;
          Pen pen2 = pen1;
          Rectangle bounds = e.Panel.Bounds;
          int right1 = bounds.Right;
          bounds = e.Panel.Bounds;
          int top = bounds.Top;
          Point pt1 = new Point(right1, top);
          bounds = e.Panel.Bounds;
          int right2 = bounds.Right;
          bounds = e.Panel.Bounds;
          int bottom = bounds.Bottom;
          Point pt2 = new Point(right2, bottom);
          graphics.DrawLine(pen2, pt1, pt2);
        }
      }
      if (!e.Panel.ButtonMoreVisible)
        return;
      this.DrawButtonMoreGlyph(e.Graphics, e.Panel.ButtonMoreBounds, e.Panel.ButtonMoreEnabled && e.Panel.Enabled);
    }

    public void DrawPanelSelected(RibbonPanelRenderEventArgs e)
    {
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
      {
        Rectangle r1 = Rectangle.FromLTRB(e.Panel.Bounds.Left, e.Panel.Bounds.Top, e.Panel.Bounds.Right, e.Panel.Bounds.Bottom);
        Rectangle r2 = Rectangle.FromLTRB(e.Panel.Bounds.Left + 1, e.Panel.Bounds.Top + 1, e.Panel.Bounds.Right - 1, e.Panel.Bounds.Bottom - 1);
        Rectangle r3 = Rectangle.FromLTRB(e.Panel.Bounds.Left + 1, e.Panel.ContentBounds.Bottom, e.Panel.Bounds.Right - 1, e.Panel.Bounds.Bottom - 1);
        GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(r1, 3);
        GraphicsPath path2 = RibbonProfessionalRenderer.RoundRectangle(r2, 3);
        GraphicsPath path3 = RibbonProfessionalRenderer.RoundRectangle(r3, 3, RibbonProfessionalRenderer.Corners.South);
        using (Pen pen = new Pen(this.ColorTable.PanelLightBorder))
          e.Graphics.DrawPath(pen, path2);
        using (Pen pen = new Pen(this.ColorTable.PanelDarkBorder))
          e.Graphics.DrawPath(pen, path1);
        using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.PanelBackgroundSelected))
          e.Graphics.FillPath((Brush) solidBrush, path2);
        using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.PanelTextBackgroundSelected))
          e.Graphics.FillPath((Brush) solidBrush, path3);
        if (e.Panel.ButtonMoreVisible)
        {
          if (e.Panel.ButtonMorePressed)
            this.DrawButtonPressed(e.Graphics, e.Panel.ButtonMoreBounds, RibbonProfessionalRenderer.Corners.SouthEast, e.Ribbon);
          else if (e.Panel.ButtonMoreSelected)
            this.DrawButtonSelected(e.Graphics, e.Panel.ButtonMoreBounds, RibbonProfessionalRenderer.Corners.SouthEast, e.Ribbon);
          this.DrawButtonMoreGlyph(e.Graphics, e.Panel.ButtonMoreBounds, e.Panel.ButtonMoreEnabled && e.Panel.Enabled);
        }
        path3.Dispose();
        path1.Dispose();
        path2.Dispose();
      }
      if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2010 && e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2010_Extended)
        return;
      Rectangle rectangle1 = Rectangle.FromLTRB(e.Panel.Bounds.Left, e.Panel.Bounds.Top, e.Panel.Bounds.Right - 2, e.Panel.Bounds.Bottom);
      Rectangle rectangle2 = Rectangle.FromLTRB(e.Panel.Bounds.Left, e.Panel.Bounds.Top, e.Panel.Bounds.Right - 1, e.Panel.Bounds.Bottom);
      Rectangle rectangle3 = Rectangle.FromLTRB(e.Panel.Bounds.Left, e.Panel.Bounds.Top, e.Panel.Bounds.Right, e.Panel.Bounds.Bottom);
      Rectangle rect = new Rectangle();
      ref Rectangle local = ref rect;
      int left = e.Panel.Bounds.Left;
      Rectangle bounds1 = e.Panel.Bounds;
      int num1 = (int) (0.1 * (double) bounds1.Width);
      int x = left + num1;
      bounds1 = e.Panel.Bounds;
      int top = bounds1.Top;
      int width1 = e.Panel.Bounds.Width;
      Rectangle bounds2 = e.Panel.Bounds;
      int num2 = (int) (0.2 * (double) bounds2.Width);
      int width2 = width1 - num2;
      bounds2 = e.Panel.Bounds;
      int height = 2 * bounds2.Height - 1;
      local = new Rectangle(x, top, width2, height);
      using (GraphicsPath path = new GraphicsPath())
      {
        path.AddArc(rect, 180f, 180f);
        path.CloseFigure();
        PathGradientBrush pathGradientBrush = new PathGradientBrush(path)
        {
          CenterPoint = new PointF(Convert.ToSingle(rectangle1.Left + rectangle1.Width / 2), Convert.ToSingle(rectangle1.Bottom)),
          CenterColor = this.ColorTable.PanelBackgroundSelected,
          SurroundColors = new Color[1]{ Color.Transparent }
        };
        pathGradientBrush.SetSigmaBellShape(1f, 1f);
        SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
        e.Graphics.SmoothingMode = SmoothingMode.None;
        e.Graphics.FillPath((Brush) pathGradientBrush, path);
        e.Graphics.SmoothingMode = smoothingMode;
        pathGradientBrush.Dispose();
      }
      using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(e.Panel.Bounds, Color.FromArgb(90, Color.White), Color.FromArgb(220, Color.White), LinearGradientMode.Vertical))
      {
        Blend blend = new Blend()
        {
          Factors = new float[3]{ 0.0f, 1f, 1f },
          Positions = new float[3]{ 0.0f, 0.5f, 1f }
        };
        linearGradientBrush.Blend = blend;
        linearGradientBrush.WrapMode = WrapMode.TileFlipX;
        using (Pen pen = new Pen((Brush) linearGradientBrush))
        {
          SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
          e.Graphics.SmoothingMode = SmoothingMode.None;
          e.Graphics.DrawLine(pen, rectangle1.Right, rectangle1.Top, rectangle1.Right, rectangle1.Bottom);
          e.Graphics.SmoothingMode = smoothingMode;
        }
      }
      using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(e.Panel.Bounds, Color.FromArgb(30, this.ColorTable.PanelLightBorder), this.ColorTable.PanelLightBorder, LinearGradientMode.Vertical))
      {
        using (Pen pen = new Pen((Brush) linearGradientBrush))
        {
          SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
          e.Graphics.SmoothingMode = SmoothingMode.None;
          e.Graphics.DrawLine(pen, rectangle3.Right, rectangle3.Top, rectangle3.Right, rectangle3.Bottom);
          e.Graphics.SmoothingMode = smoothingMode;
        }
      }
      using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(e.Panel.Bounds, Color.FromArgb(30, this.ColorTable.PanelDarkBorder), this.ColorTable.PanelDarkBorder, LinearGradientMode.Vertical))
      {
        linearGradientBrush.WrapMode = WrapMode.TileFlipX;
        using (Pen pen = new Pen((Brush) linearGradientBrush))
        {
          SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
          e.Graphics.SmoothingMode = SmoothingMode.None;
          e.Graphics.DrawLine(pen, rectangle2.Right, rectangle2.Top, rectangle2.Right, rectangle2.Bottom);
          e.Graphics.SmoothingMode = smoothingMode;
        }
      }
      using (Pen pen = new Pen(Color.FromArgb(220, Color.White)))
      {
        SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
        e.Graphics.SmoothingMode = SmoothingMode.None;
        e.Graphics.DrawLine(pen, rectangle1.Left, rectangle1.Bottom, rectangle1.Right, rectangle1.Bottom);
        e.Graphics.SmoothingMode = smoothingMode;
      }
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
      {
        using (GraphicsPath path = RibbonProfessionalRenderer.RoundRectangle(Rectangle.FromLTRB(e.Panel.Bounds.Left + 1, e.Panel.ContentBounds.Bottom, e.Panel.Bounds.Right - 1, e.Panel.Bounds.Bottom - 1), 3, RibbonProfessionalRenderer.Corners.South))
        {
          using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.PanelTextBackground))
            e.Graphics.FillPath((Brush) solidBrush, path);
        }
      }
      if (!e.Panel.ButtonMoreVisible)
        return;
      if (e.Panel.ButtonMorePressed)
        this.DrawButtonPressed(e.Graphics, e.Panel.ButtonMoreBounds, RibbonProfessionalRenderer.Corners.SouthEast, e.Ribbon);
      else if (e.Panel.ButtonMoreSelected)
        this.DrawButtonSelected(e.Graphics, e.Panel.ButtonMoreBounds, RibbonProfessionalRenderer.Corners.SouthEast, e.Ribbon);
      this.DrawButtonMoreGlyph(e.Graphics, e.Panel.ButtonMoreBounds, e.Panel.ButtonMoreEnabled && e.Panel.Enabled);
    }

    public void DrawButtonMoreGlyph(Graphics g, Rectangle b, bool enabled)
    {
      if (this._ownerRibbon.OrbStyle == RibbonOrbStyle.Office_2007)
      {
        Color color = enabled ? this.ColorTable.Arrow : this.ColorTable.ArrowDisabled;
        Color arrowLight = this.ColorTable.ArrowLight;
        Rectangle rectangle1 = this.CenterOn(b, new Rectangle(Point.Empty, this._ownerRibbon.PanelMoreSize));
        Rectangle rectangle2 = rectangle1;
        rectangle2.Offset(1, 1);
        this.DrawButtonMoreGlyph(g, rectangle2.Location, arrowLight);
        this.DrawButtonMoreGlyph(g, rectangle1.Location, color);
      }
      if (this._ownerRibbon.OrbStyle == RibbonOrbStyle.Office_2010 || this._ownerRibbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
      {
        Color color = enabled ? Color.FromArgb(180, this.ColorTable.Arrow) : this.ColorTable.ArrowDisabled;
        Rectangle rectangle = this.CenterOn(b, new Rectangle(Point.Empty, this._ownerRibbon.PanelMoreSize));
        this.DrawButtonMoreGlyph(g, rectangle.Location, color);
      }
      if (this._ownerRibbon.OrbStyle != RibbonOrbStyle.Office_2013)
        return;
      Color color1 = enabled ? this.ColorTable.Arrow : this.ColorTable.ArrowDisabled;
      Color arrowLight1 = this.ColorTable.ArrowLight;
      Rectangle rectangle3 = this.CenterOn(b, new Rectangle(Point.Empty, this._ownerRibbon.PanelMoreSize));
      Rectangle rectangle4 = rectangle3;
      rectangle4.Offset(1, 1);
      this.DrawButtonMoreGlyph(g, rectangle4.Location, arrowLight1);
      this.DrawButtonMoreGlyph(g, rectangle3.Location, color1);
    }

    public void DrawButtonMoreGlyph(Graphics gr, Point p, Color color)
    {
      Point point1 = p;
      Point pt2 = new Point(p.X + this._ownerRibbon.PanelMoreSize.Width - 1, p.Y);
      Point pt1_1 = new Point(p.X, p.Y + this._ownerRibbon.PanelMoreSize.Height - 1);
      Point point2 = new Point(p.X + this._ownerRibbon.PanelMoreSize.Width, p.Y + this._ownerRibbon.PanelMoreSize.Height);
      Point point3 = new Point(point2.X, point2.Y - 3);
      Point point4 = new Point(point2.X - 3, point2.Y);
      Point pt1_2 = new Point(point2.X - 3, point2.Y - 3);
      GraphicsPath path1 = new GraphicsPath();
      path1.AddLine(pt1_1, point1);
      path1.AddLine(point1, pt2);
      GraphicsPath path2 = new GraphicsPath();
      path2.AddLine(pt1_2, point2);
      path2.AddLine(point2, point3);
      path2.AddLine(point3, point4);
      path2.AddLine(point4, point2);
      SmoothingMode smoothingMode = gr.SmoothingMode;
      gr.SmoothingMode = SmoothingMode.None;
      using (Pen pen = new Pen(color))
      {
        gr.DrawPath(pen, path1);
        gr.DrawPath(pen, path2);
      }
      gr.SmoothingMode = smoothingMode;
    }

    public void DrawPanelOverflowNormal(RibbonPanelRenderEventArgs e)
    {
      Rectangle bounds1 = e.Panel.Bounds;
      int left1 = bounds1.Left;
      bounds1 = e.Panel.Bounds;
      int top1 = bounds1.Top;
      bounds1 = e.Panel.Bounds;
      int right1 = bounds1.Right;
      bounds1 = e.Panel.Bounds;
      int bottom1 = bounds1.Bottom;
      Rectangle r1 = Rectangle.FromLTRB(left1, top1, right1, bottom1);
      Rectangle bounds2 = e.Panel.Bounds;
      int left2 = bounds2.Left + 1;
      bounds2 = e.Panel.Bounds;
      int top2 = bounds2.Top + 1;
      bounds2 = e.Panel.Bounds;
      int right2 = bounds2.Right - 1;
      bounds2 = e.Panel.Bounds;
      int bottom2 = bounds2.Bottom - 1;
      Rectangle r2 = Rectangle.FromLTRB(left2, top2, right2, bottom2);
      GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(r1, 3);
      GraphicsPath path2 = RibbonProfessionalRenderer.RoundRectangle(r2, 3);
      using (Pen pen = new Pen(this.ColorTable.PanelLightBorder))
        e.Graphics.DrawPath(pen, path2);
      using (Pen pen = new Pen(this.ColorTable.PanelDarkBorder))
        e.Graphics.DrawPath(pen, path1);
      this.DrawPanelOverflowImage(e);
      path1.Dispose();
      path2.Dispose();
    }

    [Obsolete("use DrawPanelOverflowSelected")]
    public void DrawPannelOveflowSelected(RibbonPanelRenderEventArgs e) => this.DrawPanelOverflowSelected(e);

    public void DrawPanelOverflowSelected(RibbonPanelRenderEventArgs e)
    {
      Rectangle bounds1 = e.Panel.Bounds;
      int left1 = bounds1.Left;
      bounds1 = e.Panel.Bounds;
      int top1 = bounds1.Top;
      bounds1 = e.Panel.Bounds;
      int right1 = bounds1.Right;
      bounds1 = e.Panel.Bounds;
      int bottom1 = bounds1.Bottom;
      Rectangle r = Rectangle.FromLTRB(left1, top1, right1, bottom1);
      Rectangle bounds2 = e.Panel.Bounds;
      int left2 = bounds2.Left + 1;
      bounds2 = e.Panel.Bounds;
      int top2 = bounds2.Top + 1;
      bounds2 = e.Panel.Bounds;
      int right2 = bounds2.Right - 1;
      bounds2 = e.Panel.Bounds;
      int bottom2 = bounds2.Bottom - 1;
      Rectangle rectangle = Rectangle.FromLTRB(left2, top2, right2, bottom2);
      GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(r, 3);
      GraphicsPath path2 = RibbonProfessionalRenderer.RoundRectangle(rectangle, 3);
      using (Pen pen = new Pen(this.ColorTable.PanelLightBorder))
        e.Graphics.DrawPath(pen, path2);
      using (Pen pen = new Pen(this.ColorTable.PanelDarkBorder))
        e.Graphics.DrawPath(pen, path1);
      using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, this.ColorTable.PanelOverflowBackgroundSelectedNorth, Color.Transparent, 90f))
        e.Graphics.FillPath((Brush) linearGradientBrush, path2);
      this.DrawPanelOverflowImage(e);
      path1.Dispose();
      path2.Dispose();
    }

    public void DrawPanelOverflowPressed(RibbonPanelRenderEventArgs e)
    {
      Rectangle bounds1 = e.Panel.Bounds;
      int left1 = bounds1.Left;
      bounds1 = e.Panel.Bounds;
      int top1 = bounds1.Top;
      bounds1 = e.Panel.Bounds;
      int right1 = bounds1.Right;
      bounds1 = e.Panel.Bounds;
      int bottom1 = bounds1.Bottom;
      Rectangle r = Rectangle.FromLTRB(left1, top1, right1, bottom1);
      Rectangle bounds2 = e.Panel.Bounds;
      int left2 = bounds2.Left + 1;
      bounds2 = e.Panel.Bounds;
      int top2 = bounds2.Top + 1;
      bounds2 = e.Panel.Bounds;
      int right2 = bounds2.Right - 1;
      bounds2 = e.Panel.Bounds;
      int bottom2 = bounds2.Bottom - 1;
      Rectangle rectangle1 = Rectangle.FromLTRB(left2, top2, right2, bottom2);
      bounds2 = e.Panel.Bounds;
      int left3 = bounds2.Left;
      bounds2 = e.Panel.Bounds;
      int top3 = bounds2.Top;
      bounds2 = e.Panel.Bounds;
      int right3 = bounds2.Right;
      bounds2 = e.Panel.Bounds;
      int bottom3 = bounds2.Top + 17;
      Rectangle rectangle2 = Rectangle.FromLTRB(left3, top3, right3, bottom3);
      GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(r, 3);
      GraphicsPath path2 = RibbonProfessionalRenderer.RoundRectangle(rectangle1, 3);
      using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle1, this.ColorTable.PanelOverflowBackgroundPressed, this.ColorTable.PanelOverflowBackgroundSelectedSouth, 90f))
      {
        linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
        e.Graphics.FillPath((Brush) linearGradientBrush, path1);
      }
      using (GraphicsPath path3 = RibbonProfessionalRenderer.RoundRectangle(rectangle2, 3, RibbonProfessionalRenderer.Corners.North))
      {
        using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle2, Color.FromArgb(150, Color.White), Color.FromArgb(50, Color.White), 90f))
        {
          linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
          e.Graphics.FillPath((Brush) linearGradientBrush, path3);
        }
      }
      using (Pen pen = new Pen(Color.FromArgb(40, Color.White)))
        e.Graphics.DrawPath(pen, path2);
      using (Pen pen = new Pen(this.ColorTable.PanelDarkBorder))
        e.Graphics.DrawPath(pen, path1);
      this.DrawPanelOverflowImage(e);
      this.DrawPressedShadow(e.Graphics, rectangle2);
      path1.Dispose();
      path2.Dispose();
    }

    public void DrawPanelOverflowImage(RibbonPanelRenderEventArgs e)
    {
      int num1 = 3;
      Size size1 = new Size(32, 32);
      Rectangle rectangle = new Rectangle();
      ref Rectangle local = ref rectangle;
      Rectangle bounds1 = e.Panel.Bounds;
      int left1 = bounds1.Left;
      bounds1 = e.Panel.Bounds;
      int num2 = (bounds1.Width - size1.Width) / 2;
      int x = left1 + num2;
      bounds1 = e.Panel.Bounds;
      int y = bounds1.Top + 5;
      Point location = new Point(x, y);
      Size size2 = size1;
      local = new Rectangle(location, size2);
      Rectangle r = Rectangle.FromLTRB(rectangle.Left, rectangle.Bottom - 10, rectangle.Right, rectangle.Bottom);
      Rectangle bounds2 = e.Panel.Bounds;
      int left2 = bounds2.Left + num1;
      int top = rectangle.Bottom + num1;
      bounds2 = e.Panel.Bounds;
      int right = bounds2.Right - num1;
      bounds2 = e.Panel.Bounds;
      int bottom = bounds2.Bottom - num1;
      Rectangle textLayout = Rectangle.FromLTRB(left2, top, right, bottom);
      using (GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(rectangle, 5))
      {
        using (GraphicsPath path2 = RibbonProfessionalRenderer.RoundRectangle(r, 5, RibbonProfessionalRenderer.Corners.South))
        {
          using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, this.ColorTable.TabContentNorth, this.ColorTable.TabContentSouth, 90f))
            e.Graphics.FillPath((Brush) linearGradientBrush, path1);
          if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
          {
            using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.PanelTextBackground))
              e.Graphics.FillPath((Brush) solidBrush, path2);
          }
          using (Pen pen = new Pen(this.ColorTable.PanelDarkBorder))
            e.Graphics.DrawPath(pen, path1);
          if (e.Panel.Image != null)
            e.Graphics.DrawImage(e.Panel.Image, rectangle.Left + (rectangle.Width - e.Panel.Image.Width) / 2, rectangle.Top + (rectangle.Height - r.Height - e.Panel.Image.Height) / 2, e.Panel.Image.Width, e.Panel.Image.Height);
          if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
          {
            using (StringFormat format = StringFormatFactory.CenterNearTrimChar())
            {
              using (SolidBrush solidBrush = new SolidBrush(this.GetTextColor(e.Panel.Enabled, this.ColorTable.Text)))
                e.Graphics.DrawString(e.Panel.Text, e.Ribbon.Font, (Brush) solidBrush, (RectangleF) textLayout, format);
            }
          }
          else if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2013)
          {
            using (StringFormat format = StringFormatFactory.CenterNearTrimChar())
            {
              using (SolidBrush solidBrush = new SolidBrush(this.GetTextColor(e.Panel.Enabled, this.ColorTable.RibbonItemText_2013)))
                e.Graphics.DrawString(e.Panel.Text, e.Ribbon.Font, (Brush) solidBrush, (RectangleF) textLayout, format);
            }
          }
          if (e.Panel.Text == null)
            return;
          Rectangle b1 = this.LargeButtonDropDownArrowBounds(e.Graphics, e.Panel.Owner.Font, e.Panel.Text, textLayout);
          if (b1.Right >= e.Panel.Bounds.Right)
            return;
          Rectangle b2 = b1;
          b2.Offset(0, 1);
          Color arrowLight = this.ColorTable.ArrowLight;
          Color arrow = this.ColorTable.Arrow;
          this.DrawArrow(e.Graphics, b2, arrowLight, RibbonArrowDirection.Down);
          this.DrawArrow(e.Graphics, b1, arrow, RibbonArrowDirection.Down);
        }
      }
    }

    private RibbonProfessionalRenderer.Corners ButtonCorners(
      RibbonButton button)
    {
      if (!(button.OwnerItem is RibbonItemGroup))
        return RibbonProfessionalRenderer.Corners.All;
      RibbonItemGroup ownerItem = button.OwnerItem as RibbonItemGroup;
      RibbonProfessionalRenderer.Corners corners = RibbonProfessionalRenderer.Corners.None;
      if (button == ownerItem.FirstItem)
        corners |= RibbonProfessionalRenderer.Corners.West;
      if (button == ownerItem.LastItem)
        corners |= RibbonProfessionalRenderer.Corners.East;
      return corners;
    }

    private RibbonProfessionalRenderer.Corners ButtonFaceRounding(
      RibbonButton button)
    {
      if (!(button.OwnerItem is RibbonItemGroup))
        return button.SizeMode == RibbonElementSizeMode.Large ? RibbonProfessionalRenderer.Corners.North : RibbonProfessionalRenderer.Corners.West;
      RibbonProfessionalRenderer.Corners corners = RibbonProfessionalRenderer.Corners.None;
      RibbonItemGroup ownerItem = button.OwnerItem as RibbonItemGroup;
      if (button == ownerItem.FirstItem)
        corners |= RibbonProfessionalRenderer.Corners.West;
      return corners;
    }

    private RibbonProfessionalRenderer.Corners ButtonDdRounding(
      RibbonButton button)
    {
      if (!(button.OwnerItem is RibbonItemGroup))
        return button.SizeMode == RibbonElementSizeMode.Large ? RibbonProfessionalRenderer.Corners.South : RibbonProfessionalRenderer.Corners.East;
      RibbonProfessionalRenderer.Corners corners = RibbonProfessionalRenderer.Corners.None;
      RibbonItemGroup ownerItem = button.OwnerItem as RibbonItemGroup;
      if (button == ownerItem.LastItem)
        corners |= RibbonProfessionalRenderer.Corners.East;
      return corners;
    }

    public void DrawOrbOptionButton(Graphics g, Rectangle bounds)
    {
      --bounds.Width;
      --bounds.Height;
      using (GraphicsPath path = RibbonProfessionalRenderer.RoundRectangle(bounds, 3))
      {
        using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.OrbOptionBackground))
          g.FillPath((Brush) solidBrush, path);
        this.GradientRect(g, Rectangle.FromLTRB(bounds.Left, bounds.Top + bounds.Height / 2, bounds.Right, bounds.Bottom - 2), this.ColorTable.OrbOptionShine, this.ColorTable.OrbOptionBackground);
        using (Pen pen = new Pen(this.ColorTable.OrbOptionBorder))
          g.DrawPath(pen, path);
      }
    }

    public void DrawButton(
      Graphics g,
      Rectangle bounds,
      RibbonProfessionalRenderer.Corners corners)
    {
      if (bounds.Height <= 0 || bounds.Width <= 0)
        return;
      Rectangle r1 = Rectangle.FromLTRB(bounds.Left, bounds.Top, bounds.Right - 1, bounds.Bottom - 1);
      Rectangle r2 = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, bounds.Right - 2, bounds.Bottom - 2);
      Rectangle rectangle = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, bounds.Right - 2, bounds.Top + Convert.ToInt32((double) bounds.Height * 0.36));
      int num = (int) corners;
      using (GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(r1, 3, (RibbonProfessionalRenderer.Corners) num))
      {
        using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.ButtonBgOut))
          g.FillPath((Brush) solidBrush, path1);
        using (GraphicsPath path2 = new GraphicsPath())
        {
          path2.AddEllipse(new Rectangle(bounds.Left, bounds.Top, bounds.Width, bounds.Height * 2));
          path2.CloseFigure();
          using (PathGradientBrush pathGradientBrush = new PathGradientBrush(path2))
          {
            pathGradientBrush.WrapMode = WrapMode.Clamp;
            pathGradientBrush.CenterPoint = new PointF(Convert.ToSingle(bounds.Left + bounds.Width / 2), Convert.ToSingle(bounds.Bottom));
            pathGradientBrush.CenterColor = this.ColorTable.ButtonBgCenter;
            pathGradientBrush.SurroundColors = new Color[1]
            {
              this.ColorTable.ButtonBgOut
            };
            Blend blend = new Blend(3)
            {
              Factors = new float[3]{ 0.0f, 0.8f, 0.0f },
              Positions = new float[3]{ 0.0f, 0.3f, 1f }
            };
            Region clip = g.Clip;
            Region region = new Region(path1);
            region.Intersect(clip);
            g.SetClip(region.GetBounds(g));
            g.FillPath((Brush) pathGradientBrush, path2);
            g.Clip = clip;
          }
        }
        using (Pen pen = new Pen(this.ColorTable.ButtonBorderOut))
          g.DrawPath(pen, path1);
        using (GraphicsPath path3 = RibbonProfessionalRenderer.RoundRectangle(r2, 3, corners))
        {
          using (Pen pen = new Pen(this.ColorTable.ButtonBorderIn))
            g.DrawPath(pen, path3);
        }
        using (GraphicsPath path4 = RibbonProfessionalRenderer.RoundRectangle(rectangle, 3, corners & RibbonProfessionalRenderer.Corners.NorthWest | corners & RibbonProfessionalRenderer.Corners.NorthEast))
        {
          if (rectangle.Width <= 0 || rectangle.Height <= 0)
            return;
          using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, this.ColorTable.ButtonGlossyNorth, this.ColorTable.ButtonGlossySouth, 90f))
          {
            linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
            g.FillPath((Brush) linearGradientBrush, path4);
          }
        }
      }
    }

    public Rectangle LargeButtonDropDownArrowBounds(
      Graphics g,
      Font font,
      string text,
      Rectangle textLayout)
    {
      Rectangle empty = Rectangle.Empty;
      bool flag = text.Contains(" ");
      StringFormat stringFormat = new StringFormat()
      {
        Alignment = StringAlignment.Center,
        LineAlignment = flag ? StringAlignment.Center : StringAlignment.Near,
        Trimming = StringTrimming.EllipsisCharacter
      };
      stringFormat.SetMeasurableCharacterRanges(new CharacterRange[1]
      {
        new CharacterRange(0, text.Length)
      });
      Region[] regionArray = g.MeasureCharacterRanges(text, font, (RectangleF) textLayout, stringFormat);
      Rectangle rectangle = Rectangle.Round(regionArray[regionArray.Length - 1].GetBounds(g));
      if (flag)
      {
        int x = rectangle.Right + 3;
        int y = rectangle.Top + (rectangle.Height - this.arrowSize.Height) / 2;
        Size arrowSize = this.arrowSize;
        int width = arrowSize.Width;
        arrowSize = this.arrowSize;
        int height = arrowSize.Height;
        return new Rectangle(x, y, width, height);
      }
      int x1 = textLayout.Left + (textLayout.Width - this.arrowSize.Width) / 2;
      int bottom = rectangle.Bottom;
      int num1 = textLayout.Bottom - rectangle.Bottom;
      Size arrowSize1 = this.arrowSize;
      int height1 = arrowSize1.Height;
      int num2 = (num1 - height1) / 2;
      int y1 = bottom + num2;
      arrowSize1 = this.arrowSize;
      int width1 = arrowSize1.Width;
      arrowSize1 = this.arrowSize;
      int height2 = arrowSize1.Height;
      return new Rectangle(x1, y1, width1, height2);
    }

    public void DrawButtonDropDownArrow(Graphics g, RibbonButton button, Rectangle textLayout)
    {
      Rectangle empty = Rectangle.Empty;
      Rectangle b = button.SizeMode == RibbonElementSizeMode.Large || button.SizeMode == RibbonElementSizeMode.Overflow ? this.LargeButtonDropDownArrowBounds(g, button.Owner.Font, button.Text, textLayout) : textLayout;
      this.DrawArrowShaded(g, b, button.DropDownArrowDirection, button.Enabled);
    }

    public void DrawButtonDisabled(
      Graphics g,
      Rectangle bounds,
      RibbonProfessionalRenderer.Corners corners)
    {
      if (bounds.Height <= 0 || bounds.Width <= 0)
        return;
      Rectangle r1 = Rectangle.FromLTRB(bounds.Left, bounds.Top, bounds.Right - 1, bounds.Bottom - 1);
      Rectangle r2 = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, bounds.Right - 2, bounds.Bottom - 2);
      Rectangle rectangle = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, bounds.Right - 2, bounds.Top + Convert.ToInt32((double) bounds.Height * 0.36));
      int num = (int) corners;
      using (GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(r1, 3, (RibbonProfessionalRenderer.Corners) num))
      {
        using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.ButtonDisabledBgOut))
          g.FillPath((Brush) solidBrush, path1);
        using (GraphicsPath path2 = new GraphicsPath())
        {
          path2.AddEllipse(new Rectangle(bounds.Left, bounds.Top, bounds.Width, bounds.Height * 2));
          path2.CloseFigure();
          using (PathGradientBrush pathGradientBrush = new PathGradientBrush(path2))
          {
            pathGradientBrush.WrapMode = WrapMode.Clamp;
            pathGradientBrush.CenterPoint = new PointF(Convert.ToSingle(bounds.Left + bounds.Width / 2), Convert.ToSingle(bounds.Bottom));
            pathGradientBrush.CenterColor = this.ColorTable.ButtonDisabledBgCenter;
            pathGradientBrush.SurroundColors = new Color[1]
            {
              this.ColorTable.ButtonDisabledBgOut
            };
            Blend blend = new Blend(3)
            {
              Factors = new float[3]{ 0.0f, 0.8f, 0.0f },
              Positions = new float[3]{ 0.0f, 0.3f, 1f }
            };
            Region clip = g.Clip;
            Region region = new Region(path1);
            region.Intersect(clip);
            g.SetClip(region.GetBounds(g));
            g.FillPath((Brush) pathGradientBrush, path2);
            g.Clip = clip;
          }
        }
        using (Pen pen = new Pen(this.ColorTable.ButtonDisabledBorderOut))
          g.DrawPath(pen, path1);
        using (GraphicsPath path3 = RibbonProfessionalRenderer.RoundRectangle(r2, 3, corners))
        {
          using (Pen pen = new Pen(this.ColorTable.ButtonDisabledBorderIn))
            g.DrawPath(pen, path3);
        }
        using (GraphicsPath path4 = RibbonProfessionalRenderer.RoundRectangle(rectangle, 3, corners & RibbonProfessionalRenderer.Corners.NorthWest | corners & RibbonProfessionalRenderer.Corners.NorthEast))
        {
          using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, this.ColorTable.ButtonDisabledGlossyNorth, this.ColorTable.ButtonDisabledGlossySouth, 90f))
          {
            linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
            g.FillPath((Brush) linearGradientBrush, path4);
          }
        }
      }
    }

    public void DrawButtonPressed(
      Graphics g,
      Rectangle bounds,
      RibbonProfessionalRenderer.Corners corners,
      Ribbon ribbon)
    {
      if (ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
      {
        Rectangle r1 = Rectangle.FromLTRB(bounds.Left, bounds.Top, bounds.Right - 1, bounds.Bottom - 1);
        using (GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(r1, 3, corners))
        {
          Rectangle r2 = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, bounds.Right - 2, bounds.Bottom - 2);
          Rectangle rectangle = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, bounds.Right - 2, bounds.Top + Convert.ToInt32((double) bounds.Height * 0.36));
          using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.ButtonPressedBgOut))
            g.FillPath((Brush) solidBrush, path1);
          using (Pen pen = new Pen(this.ColorTable.ButtonPressedBorderOut))
            g.DrawPath(pen, path1);
          using (GraphicsPath path2 = RibbonProfessionalRenderer.RoundRectangle(r2, 3, corners))
          {
            using (Pen pen = new Pen(this.ColorTable.ButtonPressedBorderIn))
              g.DrawPath(pen, path2);
          }
          using (GraphicsPath path3 = new GraphicsPath())
          {
            path3.AddEllipse(new Rectangle(bounds.Left, bounds.Top, bounds.Width, bounds.Height * 2));
            path3.CloseFigure();
            using (PathGradientBrush pathGradientBrush = new PathGradientBrush(path3))
            {
              pathGradientBrush.WrapMode = WrapMode.Clamp;
              pathGradientBrush.CenterPoint = new PointF(Convert.ToSingle(bounds.Left + bounds.Width / 2), Convert.ToSingle(bounds.Bottom));
              pathGradientBrush.CenterColor = this.ColorTable.ButtonPressedBgCenter;
              pathGradientBrush.SurroundColors = new Color[1]
              {
                this.ColorTable.ButtonPressedBgOut
              };
              Blend blend = new Blend(3)
              {
                Factors = new float[3]{ 0.0f, 0.8f, 0.0f },
                Positions = new float[3]{ 0.0f, 0.3f, 1f }
              };
              Region clip = g.Clip;
              Region region = new Region(path1);
              region.Intersect(clip);
              g.SetClip(region.GetBounds(g));
              g.FillPath((Brush) pathGradientBrush, path3);
              g.Clip = clip;
            }
          }
          using (GraphicsPath path4 = RibbonProfessionalRenderer.RoundRectangle(rectangle, 3, corners & RibbonProfessionalRenderer.Corners.NorthWest | corners & RibbonProfessionalRenderer.Corners.NorthEast))
          {
            using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, this.ColorTable.ButtonPressedGlossyNorth, this.ColorTable.ButtonPressedGlossySouth, 90f))
            {
              linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
              g.FillPath((Brush) linearGradientBrush, path4);
            }
          }
          this.DrawPressedShadow(g, r1);
        }
      }
      else
      {
        if (ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
          return;
        using (GraphicsPath path = RibbonProfessionalRenderer.FlatRectangle(bounds))
        {
          using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.ButtonPressed_2013))
            g.FillPath((Brush) solidBrush, path);
        }
      }
    }

    public void DrawButtonSelected(
      Graphics g,
      Rectangle bounds,
      RibbonProfessionalRenderer.Corners corners,
      Ribbon ribbon)
    {
      if (bounds.Height <= 0 || bounds.Width <= 0)
        return;
      if (ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
      {
        using (GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(Rectangle.FromLTRB(bounds.Left, bounds.Top, bounds.Right - 1, bounds.Bottom - 1), 3, corners))
        {
          Rectangle r = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, bounds.Right - 2, bounds.Bottom - 2);
          Rectangle rectangle = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, bounds.Right - 2, bounds.Top + Convert.ToInt32((double) bounds.Height * 0.36));
          using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.ButtonSelectedBgOut))
            g.FillPath((Brush) solidBrush, path1);
          using (Pen pen = new Pen(this.ColorTable.ButtonSelectedBorderOut))
            g.DrawPath(pen, path1);
          using (GraphicsPath path2 = RibbonProfessionalRenderer.RoundRectangle(r, 3, corners))
          {
            using (Pen pen = new Pen(this.ColorTable.ButtonSelectedBorderIn))
              g.DrawPath(pen, path2);
          }
          using (GraphicsPath path3 = new GraphicsPath())
          {
            path3.AddEllipse(new Rectangle(bounds.Left, bounds.Top, bounds.Width, bounds.Height * 2));
            path3.CloseFigure();
            using (PathGradientBrush pathGradientBrush = new PathGradientBrush(path3))
            {
              pathGradientBrush.WrapMode = WrapMode.Clamp;
              pathGradientBrush.CenterPoint = new PointF(Convert.ToSingle(bounds.Left + bounds.Width / 2), Convert.ToSingle(bounds.Bottom));
              pathGradientBrush.CenterColor = this.ColorTable.ButtonSelectedBgCenter;
              pathGradientBrush.SurroundColors = new Color[1]
              {
                this.ColorTable.ButtonSelectedBgOut
              };
              Blend blend = new Blend(3)
              {
                Factors = new float[3]{ 0.0f, 0.8f, 0.0f },
                Positions = new float[3]{ 0.0f, 0.3f, 1f }
              };
              Region clip = g.Clip;
              Region region = new Region(path1);
              region.Intersect(clip);
              g.SetClip(region.GetBounds(g));
              g.FillPath((Brush) pathGradientBrush, path3);
              g.Clip = clip;
            }
          }
          using (GraphicsPath path4 = RibbonProfessionalRenderer.RoundRectangle(rectangle, 3, corners & RibbonProfessionalRenderer.Corners.NorthWest | corners & RibbonProfessionalRenderer.Corners.NorthEast))
          {
            using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, this.ColorTable.ButtonSelectedGlossyNorth, this.ColorTable.ButtonSelectedGlossySouth, 90f))
            {
              linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
              g.FillPath((Brush) linearGradientBrush, path4);
            }
          }
        }
      }
      else
      {
        if (ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
          return;
        using (GraphicsPath path = RibbonProfessionalRenderer.FlatRectangle(bounds))
        {
          using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.ButtonSelected_2013))
            g.FillPath((Brush) solidBrush, path);
        }
      }
    }

    public void DrawButtonPressed(Graphics g, RibbonButton button, Ribbon ribbon) => this.DrawButtonPressed(g, button.Bounds, this.ButtonCorners(button), ribbon);

    public void DrawButtonChecked(Graphics g, RibbonButton button, Ribbon ribbon) => this.DrawButtonChecked(g, button.Bounds, this.ButtonCorners(button), ribbon);

    public void DrawButtonCheckedSelected(Graphics g, RibbonButton button, Ribbon ribbon) => this.DrawButtonCheckedSelected(g, button.Bounds, this.ButtonCorners(button), ribbon);

    public void DrawButtonChecked(
      Graphics g,
      Rectangle bounds,
      RibbonProfessionalRenderer.Corners corners,
      Ribbon ribbon)
    {
      if (bounds.Height <= 0 || bounds.Width <= 0)
        return;
      if (ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
      {
        Rectangle r1 = Rectangle.FromLTRB(bounds.Left, bounds.Top, bounds.Right - 1, bounds.Bottom - 1);
        Rectangle r2 = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, bounds.Right - 2, bounds.Bottom - 2);
        Rectangle rectangle = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, bounds.Right - 2, bounds.Top + Convert.ToInt32((double) bounds.Height * 0.36));
        int num = (int) corners;
        using (GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(r1, 3, (RibbonProfessionalRenderer.Corners) num))
        {
          using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.ButtonCheckedBgOut))
            g.FillPath((Brush) solidBrush, path1);
          using (GraphicsPath path2 = new GraphicsPath())
          {
            path2.AddEllipse(new Rectangle(bounds.Left, bounds.Top, bounds.Width, bounds.Height * 2));
            path2.CloseFigure();
            using (PathGradientBrush pathGradientBrush = new PathGradientBrush(path2))
            {
              pathGradientBrush.WrapMode = WrapMode.Clamp;
              pathGradientBrush.CenterPoint = new PointF(Convert.ToSingle(bounds.Left + bounds.Width / 2), Convert.ToSingle(bounds.Bottom));
              pathGradientBrush.CenterColor = this.ColorTable.ButtonCheckedBgCenter;
              pathGradientBrush.SurroundColors = new Color[1]
              {
                this.ColorTable.ButtonCheckedBgOut
              };
              Blend blend = new Blend(3)
              {
                Factors = new float[3]{ 0.0f, 0.8f, 0.0f },
                Positions = new float[3]{ 0.0f, 0.3f, 1f }
              };
              Region clip = g.Clip;
              Region region = new Region(path1);
              region.Intersect(clip);
              g.SetClip(region.GetBounds(g));
              g.FillPath((Brush) pathGradientBrush, path2);
              g.Clip = clip;
            }
          }
          using (Pen pen = new Pen(this.ColorTable.ButtonCheckedBorderOut))
            g.DrawPath(pen, path1);
          using (GraphicsPath path3 = RibbonProfessionalRenderer.RoundRectangle(r2, 3, corners))
          {
            using (Pen pen = new Pen(this.ColorTable.ButtonCheckedBorderIn))
              g.DrawPath(pen, path3);
          }
          using (GraphicsPath path4 = RibbonProfessionalRenderer.RoundRectangle(rectangle, 3, corners & RibbonProfessionalRenderer.Corners.NorthWest | corners & RibbonProfessionalRenderer.Corners.NorthEast))
          {
            using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, this.ColorTable.ButtonCheckedGlossyNorth, this.ColorTable.ButtonCheckedGlossySouth, 90f))
            {
              linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
              g.FillPath((Brush) linearGradientBrush, path4);
            }
          }
        }
      }
      if (ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
        return;
      using (GraphicsPath path = RibbonProfessionalRenderer.FlatRectangle(bounds))
      {
        using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.ButtonChecked_2013))
          g.FillPath((Brush) solidBrush, path);
      }
    }

    public void DrawButtonCheckedSelected(
      Graphics g,
      Rectangle bounds,
      RibbonProfessionalRenderer.Corners corners,
      Ribbon ribbon)
    {
      if (ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
      {
        using (GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(Rectangle.FromLTRB(bounds.Left, bounds.Top, bounds.Right - 1, bounds.Bottom - 1), 3, corners))
        {
          Rectangle r = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, bounds.Right - 2, bounds.Bottom - 2);
          Rectangle rectangle = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, bounds.Right - 2, bounds.Top + Convert.ToInt32((double) bounds.Height * 0.36));
          using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.ButtonCheckedSelectedBgOut))
            g.FillPath((Brush) solidBrush, path1);
          using (Pen pen = new Pen(this.ColorTable.ButtonCheckedSelectedBorderOut))
            g.DrawPath(pen, path1);
          using (GraphicsPath path2 = RibbonProfessionalRenderer.RoundRectangle(r, 3, corners))
          {
            using (Pen pen = new Pen(this.ColorTable.ButtonCheckedSelectedBorderIn))
              g.DrawPath(pen, path2);
          }
          using (GraphicsPath path3 = new GraphicsPath())
          {
            path3.AddEllipse(new Rectangle(bounds.Left, bounds.Top, bounds.Width, bounds.Height * 2));
            path3.CloseFigure();
            using (PathGradientBrush pathGradientBrush = new PathGradientBrush(path3))
            {
              pathGradientBrush.WrapMode = WrapMode.Clamp;
              pathGradientBrush.CenterPoint = new PointF(Convert.ToSingle(bounds.Left + bounds.Width / 2), Convert.ToSingle(bounds.Bottom));
              pathGradientBrush.CenterColor = this.ColorTable.ButtonCheckedSelectedBgCenter;
              pathGradientBrush.SurroundColors = new Color[1]
              {
                this.ColorTable.ButtonCheckedSelectedBgOut
              };
              Blend blend = new Blend(3)
              {
                Factors = new float[3]{ 0.0f, 0.8f, 0.0f },
                Positions = new float[3]{ 0.0f, 0.3f, 1f }
              };
              Region clip = g.Clip;
              Region region = new Region(path1);
              region.Intersect(clip);
              g.SetClip(region.GetBounds(g));
              g.FillPath((Brush) pathGradientBrush, path3);
              g.Clip = clip;
            }
          }
          using (GraphicsPath path4 = RibbonProfessionalRenderer.RoundRectangle(rectangle, 3, corners & RibbonProfessionalRenderer.Corners.NorthWest | corners & RibbonProfessionalRenderer.Corners.NorthEast))
          {
            using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, this.ColorTable.ButtonCheckedSelectedGlossyNorth, this.ColorTable.ButtonCheckedSelectedGlossySouth, 90f))
            {
              linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
              g.FillPath((Brush) linearGradientBrush, path4);
            }
          }
        }
      }
      if (ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
        return;
      using (GraphicsPath path = RibbonProfessionalRenderer.FlatRectangle(bounds))
      {
        using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.ButtonCheckedSelectedBgOut))
          g.FillPath((Brush) solidBrush, path);
      }
    }

    public void DrawButtonSelected(Graphics g, RibbonButton button, Ribbon ribbon) => this.DrawButtonSelected(g, button.Bounds, this.ButtonCorners(button), ribbon);

    public void DrawSplitButton(RibbonItemRenderEventArgs e, RibbonButton button)
    {
    }

    public void DrawSplitButtonPressed(RibbonItemRenderEventArgs e, RibbonButton button)
    {
    }

    public void DrawSplitButtonSelected(RibbonItemRenderEventArgs e, RibbonButton button)
    {
      Rectangle dropDownBounds = button.DropDownBounds;
      int left1 = dropDownBounds.Left;
      dropDownBounds = button.DropDownBounds;
      int top1 = dropDownBounds.Top;
      dropDownBounds = button.DropDownBounds;
      int right1 = dropDownBounds.Right - 1;
      dropDownBounds = button.DropDownBounds;
      int bottom1 = dropDownBounds.Bottom - 1;
      Rectangle r1 = Rectangle.FromLTRB(left1, top1, right1, bottom1);
      Rectangle r2 = Rectangle.FromLTRB(r1.Left + 1, r1.Top + 1, r1.Right - 1, r1.Bottom - 1);
      Rectangle buttonFaceBounds = button.ButtonFaceBounds;
      int left2 = buttonFaceBounds.Left;
      buttonFaceBounds = button.ButtonFaceBounds;
      int top2 = buttonFaceBounds.Top;
      buttonFaceBounds = button.ButtonFaceBounds;
      int right2 = buttonFaceBounds.Right - 1;
      buttonFaceBounds = button.ButtonFaceBounds;
      int bottom2 = buttonFaceBounds.Bottom - 1;
      Rectangle r3 = Rectangle.FromLTRB(left2, top2, right2, bottom2);
      Rectangle r4 = Rectangle.FromLTRB(r3.Left + 1, r3.Top + 1, r3.Right + (button.SizeMode == RibbonElementSizeMode.Large ? -1 : 0), r3.Bottom + (button.SizeMode == RibbonElementSizeMode.Large ? 0 : -1));
      RibbonProfessionalRenderer.Corners corners1 = this.ButtonFaceRounding(button);
      RibbonProfessionalRenderer.Corners corners2 = this.ButtonDdRounding(button);
      GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(r1, 3, corners2);
      GraphicsPath path2 = RibbonProfessionalRenderer.RoundRectangle(r2, 2, corners2);
      GraphicsPath graphicsPath = RibbonProfessionalRenderer.RoundRectangle(r3, 3, corners1);
      int num = (int) corners1;
      GraphicsPath path3 = RibbonProfessionalRenderer.RoundRectangle(r4, 2, (RibbonProfessionalRenderer.Corners) num);
      using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(150, Color.White)))
        e.Graphics.FillPath((Brush) solidBrush, path2);
      using (Pen pen = new Pen(!button.Pressed || button.SizeMode == RibbonElementSizeMode.DropDown ? this.ColorTable.ButtonSelectedBorderOut : this.ColorTable.ButtonPressedBorderOut))
        e.Graphics.DrawPath(pen, path1);
      using (Pen pen = new Pen(!button.Pressed || button.SizeMode == RibbonElementSizeMode.DropDown ? this.ColorTable.ButtonSelectedBorderIn : this.ColorTable.ButtonPressedBorderIn))
        e.Graphics.DrawPath(pen, path3);
      path1.Dispose();
      path2.Dispose();
      graphicsPath.Dispose();
      path3.Dispose();
    }

    public void DrawSplitButtonDropDownPressed(RibbonItemRenderEventArgs e, RibbonButton button)
    {
    }

    public void DrawSplitButtonDropDownSelected(RibbonItemRenderEventArgs e, RibbonButton button)
    {
      Rectangle dropDownBounds = button.DropDownBounds;
      int left1 = dropDownBounds.Left;
      dropDownBounds = button.DropDownBounds;
      int top1 = dropDownBounds.Top;
      dropDownBounds = button.DropDownBounds;
      int right1 = dropDownBounds.Right - 1;
      dropDownBounds = button.DropDownBounds;
      int bottom1 = dropDownBounds.Bottom - 1;
      Rectangle r1 = Rectangle.FromLTRB(left1, top1, right1, bottom1);
      Rectangle r2 = Rectangle.FromLTRB(r1.Left + 1, r1.Top + (button.SizeMode == RibbonElementSizeMode.Large ? 1 : 0), r1.Right - 1, r1.Bottom - 1);
      Rectangle buttonFaceBounds = button.ButtonFaceBounds;
      int left2 = buttonFaceBounds.Left;
      buttonFaceBounds = button.ButtonFaceBounds;
      int top2 = buttonFaceBounds.Top;
      buttonFaceBounds = button.ButtonFaceBounds;
      int right2 = buttonFaceBounds.Right - 1;
      int bottom2 = button.ButtonFaceBounds.Bottom - 1;
      Rectangle r3 = Rectangle.FromLTRB(left2, top2, right2, bottom2);
      Rectangle r4 = Rectangle.FromLTRB(r3.Left + 1, r3.Top + 1, r3.Right + (button.SizeMode == RibbonElementSizeMode.Large ? -1 : 0), r3.Bottom + (button.SizeMode == RibbonElementSizeMode.Large ? 0 : -1));
      RibbonProfessionalRenderer.Corners corners1 = this.ButtonFaceRounding(button);
      RibbonProfessionalRenderer.Corners corners2 = this.ButtonDdRounding(button);
      GraphicsPath graphicsPath1 = RibbonProfessionalRenderer.RoundRectangle(r1, 3, corners2);
      GraphicsPath graphicsPath2 = RibbonProfessionalRenderer.RoundRectangle(r2, 2, corners2);
      GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(r3, 3, corners1);
      int num = (int) corners1;
      GraphicsPath path2 = RibbonProfessionalRenderer.RoundRectangle(r4, 2, (RibbonProfessionalRenderer.Corners) num);
      using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(150, Color.White)))
        e.Graphics.FillPath((Brush) solidBrush, path2);
      using (Pen pen = new Pen(!button.Pressed || button.SizeMode == RibbonElementSizeMode.DropDown ? this.ColorTable.ButtonSelectedBorderIn : this.ColorTable.ButtonPressedBorderIn))
        e.Graphics.DrawPath(pen, path2);
      using (Pen pen = new Pen(!button.Pressed || button.SizeMode == RibbonElementSizeMode.DropDown ? this.ColorTable.ButtonSelectedBorderOut : this.ColorTable.ButtonPressedBorderOut))
        e.Graphics.DrawPath(pen, path1);
      graphicsPath1.Dispose();
      graphicsPath2.Dispose();
      path1.Dispose();
      path2.Dispose();
    }

    public void DrawItemGroup(RibbonItemRenderEventArgs e, RibbonItemGroup grp)
    {
      if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2007)
        return;
      Rectangle bounds = grp.Bounds;
      int left = bounds.Left;
      bounds = grp.Bounds;
      int top = bounds.Top;
      bounds = grp.Bounds;
      int right = bounds.Right - 1;
      bounds = grp.Bounds;
      int bottom = bounds.Bottom - 1;
      Rectangle r = Rectangle.FromLTRB(left, top, right, bottom);
      Rectangle rectangle1 = Rectangle.FromLTRB(r.Left + 1, r.Top + 1, r.Right - 1, r.Bottom - 1);
      Rectangle rectangle2 = Rectangle.FromLTRB(r.Left + 1, r.Top + r.Height / 2 + 1, r.Right - 1, r.Bottom - 1);
      GraphicsPath graphicsPath = RibbonProfessionalRenderer.RoundRectangle(r, 2);
      GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(rectangle1, 2);
      GraphicsPath path2 = RibbonProfessionalRenderer.RoundRectangle(rectangle2, 2);
      using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle1, this.ColorTable.ItemGroupBgNorth, this.ColorTable.ItemGroupBgSouth, 90f))
        e.Graphics.FillPath((Brush) linearGradientBrush, path1);
      using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle2, this.ColorTable.ItemGroupBgGlossy, Color.Transparent, 90f))
        e.Graphics.FillPath((Brush) linearGradientBrush, path2);
      graphicsPath.Dispose();
      path1.Dispose();
    }

    public void DrawItemGroupBorder(RibbonItemRenderEventArgs e, RibbonItemGroup grp)
    {
      if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2007 && !e.Ribbon.IsDesignMode())
        return;
      Rectangle bounds = grp.Bounds;
      int left = bounds.Left;
      bounds = grp.Bounds;
      int top1 = bounds.Top;
      bounds = grp.Bounds;
      int right1 = bounds.Right - 1;
      bounds = grp.Bounds;
      int bottom1 = bounds.Bottom - 1;
      Rectangle r1 = Rectangle.FromLTRB(left, top1, right1, bottom1);
      Rectangle r2 = Rectangle.FromLTRB(r1.Left + 1, r1.Top + 1, r1.Right - 1, r1.Bottom - 1);
      GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(r1, 2);
      GraphicsPath path2 = RibbonProfessionalRenderer.RoundRectangle(r2, 2);
      using (Pen pen1 = new Pen(this.ColorTable.ItemGroupSeparatorDark))
      {
        using (Pen pen2 = new Pen(this.ColorTable.ItemGroupSeparatorLight))
        {
          foreach (RibbonItem ribbonItem in (List<RibbonItem>) grp.Items)
          {
            if (ribbonItem != grp.LastItem)
            {
              Graphics graphics1 = e.Graphics;
              Pen pen3 = pen1;
              bounds = ribbonItem.Bounds;
              int right2 = bounds.Right;
              bounds = ribbonItem.Bounds;
              int top2 = bounds.Top;
              Point pt1_1 = new Point(right2, top2);
              bounds = ribbonItem.Bounds;
              int right3 = bounds.Right;
              bounds = ribbonItem.Bounds;
              int bottom2 = bounds.Bottom;
              Point pt2_1 = new Point(right3, bottom2);
              graphics1.DrawLine(pen3, pt1_1, pt2_1);
              Graphics graphics2 = e.Graphics;
              Pen pen4 = pen2;
              bounds = ribbonItem.Bounds;
              int x1 = bounds.Right + 1;
              bounds = ribbonItem.Bounds;
              int top3 = bounds.Top;
              Point pt1_2 = new Point(x1, top3);
              bounds = ribbonItem.Bounds;
              int x2 = bounds.Right + 1;
              bounds = ribbonItem.Bounds;
              int bottom3 = bounds.Bottom;
              Point pt2_2 = new Point(x2, bottom3);
              graphics2.DrawLine(pen4, pt1_2, pt2_2);
            }
            else
              break;
          }
        }
      }
      using (Pen pen = new Pen(this.ColorTable.ItemGroupOuterBorder))
        e.Graphics.DrawPath(pen, path1);
      using (Pen pen = new Pen(this.ColorTable.ItemGroupInnerBorder))
        e.Graphics.DrawPath(pen, path2);
      path1.Dispose();
      path2.Dispose();
    }

    public void DrawButtonList(Graphics g, RibbonButtonList list, Ribbon ribbon)
    {
      Rectangle bounds = list.Bounds;
      int left = bounds.Left;
      bounds = list.Bounds;
      int top = bounds.Top;
      bounds = list.Bounds;
      int right = bounds.Right - 1;
      bounds = list.Bounds;
      int bottom = bounds.Bottom;
      using (GraphicsPath path = RibbonProfessionalRenderer.RoundRectangle(Rectangle.FromLTRB(left, top, right, bottom), 3, RibbonProfessionalRenderer.Corners.East))
      {
        Color color = list.Selected ? this.ColorTable.ButtonListBgSelected : this.ColorTable.ButtonListBg;
        if (list.Canvas is RibbonDropDown)
          color = this.ColorTable.DropDownBg;
        using (SolidBrush solidBrush = new SolidBrush(color))
          g.FillPath((Brush) solidBrush, path);
        using (Pen pen = new Pen(this.ColorTable.ButtonListBorder))
          g.DrawPath(pen, path);
      }
      if (list.ScrollType == RibbonButtonList.ListScrollType.Scrollbar && ScrollBarRenderer.IsSupported)
      {
        ScrollBarRenderer.DrawUpperVerticalTrack(g, list.ScrollBarBounds, ScrollBarState.Normal);
        if (list.ThumbPressed)
        {
          ScrollBarRenderer.DrawVerticalThumb(g, list.ThumbBounds, ScrollBarState.Pressed);
          ScrollBarRenderer.DrawVerticalThumbGrip(g, list.ThumbBounds, ScrollBarState.Pressed);
        }
        else if (list.ThumbSelected)
        {
          ScrollBarRenderer.DrawVerticalThumb(g, list.ThumbBounds, ScrollBarState.Hot);
          ScrollBarRenderer.DrawVerticalThumbGrip(g, list.ThumbBounds, ScrollBarState.Hot);
        }
        else
        {
          ScrollBarRenderer.DrawVerticalThumb(g, list.ThumbBounds, ScrollBarState.Normal);
          ScrollBarRenderer.DrawVerticalThumbGrip(g, list.ThumbBounds, ScrollBarState.Normal);
        }
        if (list.ButtonUpPressed)
          ScrollBarRenderer.DrawArrowButton(g, list.ButtonUpBounds, ScrollBarArrowButtonState.UpPressed);
        else if (list.ButtonUpSelected)
          ScrollBarRenderer.DrawArrowButton(g, list.ButtonUpBounds, ScrollBarArrowButtonState.UpHot);
        else
          ScrollBarRenderer.DrawArrowButton(g, list.ButtonUpBounds, ScrollBarArrowButtonState.UpNormal);
        if (list.ButtonDownPressed)
          ScrollBarRenderer.DrawArrowButton(g, list.ButtonDownBounds, ScrollBarArrowButtonState.DownPressed);
        else if (list.ButtonDownSelected)
          ScrollBarRenderer.DrawArrowButton(g, list.ButtonDownBounds, ScrollBarArrowButtonState.DownHot);
        else
          ScrollBarRenderer.DrawArrowButton(g, list.ButtonDownBounds, ScrollBarArrowButtonState.DownNormal);
      }
      else
      {
        if (list.ScrollType == RibbonButtonList.ListScrollType.Scrollbar)
        {
          using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.ButtonGlossyNorth))
            g.FillRectangle((Brush) solidBrush, list.ScrollBarBounds);
        }
        if (!list.ButtonDownEnabled)
          this.DrawButtonDisabled(g, list.ButtonDownBounds, list.ButtonDropDownPresent ? RibbonProfessionalRenderer.Corners.None : RibbonProfessionalRenderer.Corners.SouthEast);
        else if (list.ButtonDownPressed)
          this.DrawButtonPressed(g, list.ButtonDownBounds, list.ButtonDropDownPresent ? RibbonProfessionalRenderer.Corners.None : RibbonProfessionalRenderer.Corners.SouthEast, ribbon);
        else if (list.ButtonDownSelected)
          this.DrawButtonSelected(g, list.ButtonDownBounds, list.ButtonDropDownPresent ? RibbonProfessionalRenderer.Corners.None : RibbonProfessionalRenderer.Corners.SouthEast, ribbon);
        else
          this.DrawButton(g, list.ButtonDownBounds, RibbonProfessionalRenderer.Corners.None);
        if (!list.ButtonUpEnabled)
          this.DrawButtonDisabled(g, list.ButtonUpBounds, RibbonProfessionalRenderer.Corners.NorthEast);
        else if (list.ButtonUpPressed)
          this.DrawButtonPressed(g, list.ButtonUpBounds, RibbonProfessionalRenderer.Corners.NorthEast, ribbon);
        else if (list.ButtonUpSelected)
          this.DrawButtonSelected(g, list.ButtonUpBounds, RibbonProfessionalRenderer.Corners.NorthEast, ribbon);
        else
          this.DrawButton(g, list.ButtonUpBounds, RibbonProfessionalRenderer.Corners.NorthEast);
        if (list.ButtonDropDownPresent)
        {
          if (list.ButtonDropDownPressed)
            this.DrawButtonPressed(g, list.ButtonDropDownBounds, RibbonProfessionalRenderer.Corners.SouthEast, ribbon);
          else if (list.ButtonDropDownSelected)
            this.DrawButtonSelected(g, list.ButtonDropDownBounds, RibbonProfessionalRenderer.Corners.SouthEast, ribbon);
          else
            this.DrawButton(g, list.ButtonDropDownBounds, RibbonProfessionalRenderer.Corners.SouthEast);
        }
        if (list.ScrollType == RibbonButtonList.ListScrollType.Scrollbar && list.ScrollBarEnabled)
        {
          if (list.ThumbPressed)
            this.DrawButtonPressed(g, list.ThumbBounds, RibbonProfessionalRenderer.Corners.All, ribbon);
          else if (list.ThumbSelected)
            this.DrawButtonSelected(g, list.ThumbBounds, RibbonProfessionalRenderer.Corners.All, ribbon);
          else
            this.DrawButton(g, list.ThumbBounds, RibbonProfessionalRenderer.Corners.All);
        }
        Color arrow = this.ColorTable.Arrow;
        Color arrowLight = this.ColorTable.ArrowLight;
        Color arrowDisabled = this.ColorTable.ArrowDisabled;
        Rectangle b1 = this.CenterOn(list.ButtonUpBounds, new Rectangle(Point.Empty, this.arrowSize));
        b1.Offset(0, 1);
        Rectangle b2 = this.CenterOn(list.ButtonDownBounds, new Rectangle(Point.Empty, this.arrowSize));
        b2.Offset(0, 1);
        Rectangle b3 = this.CenterOn(list.ButtonDropDownBounds, new Rectangle(Point.Empty, this.arrowSize));
        b3.Offset(0, 3);
        this.DrawArrow(g, b1, list.ButtonUpEnabled ? arrowLight : Color.Transparent, RibbonArrowDirection.Up);
        b1.Offset(0, -1);
        this.DrawArrow(g, b1, list.ButtonUpEnabled ? arrow : arrowDisabled, RibbonArrowDirection.Up);
        this.DrawArrow(g, b2, list.ButtonDownEnabled ? arrowLight : Color.Transparent, RibbonArrowDirection.Down);
        b2.Offset(0, -1);
        this.DrawArrow(g, b2, list.ButtonDownEnabled ? arrow : arrowDisabled, RibbonArrowDirection.Down);
        if (!list.ButtonDropDownPresent)
          return;
        using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.Arrow))
        {
          SmoothingMode smoothingMode = g.SmoothingMode;
          g.SmoothingMode = SmoothingMode.None;
          g.FillRectangle((Brush) solidBrush, new Rectangle(new Point(b3.Left - 1, b3.Top - 4), new Size(this.arrowSize.Width + 2, 1)));
          g.SmoothingMode = smoothingMode;
        }
        this.DrawArrow(g, b3, arrowLight, RibbonArrowDirection.Down);
        b3.Offset(0, -1);
        this.DrawArrow(g, b3, arrow, RibbonArrowDirection.Down);
      }
    }

    public void DrawSeparator(Graphics g, RibbonSeparator separator, Ribbon ribbon)
    {
      if (ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || ribbon.OrbStyle == RibbonOrbStyle.Office_2013)
      {
        if (separator.SizeMode == RibbonElementSizeMode.DropDown)
        {
          if (!string.IsNullOrEmpty(separator.Text))
          {
            using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.SeparatorBg))
              g.FillRectangle((Brush) solidBrush, separator.Bounds);
            using (Pen pen1 = new Pen(this.ColorTable.SeparatorLine))
            {
              Graphics graphics = g;
              Pen pen2 = pen1;
              int left = separator.Bounds.Left;
              Rectangle bounds = separator.Bounds;
              int bottom1 = bounds.Bottom;
              Point pt1 = new Point(left, bottom1);
              bounds = separator.Bounds;
              int right = bounds.Right;
              bounds = separator.Bounds;
              int bottom2 = bounds.Bottom;
              Point pt2 = new Point(right, bottom2);
              graphics.DrawLine(pen2, pt1, pt2);
            }
          }
          else
          {
            using (Pen pen3 = new Pen(this.ColorTable.DropDownImageSeparator))
            {
              Graphics graphics = g;
              Pen pen4 = pen3;
              Point pt1 = new Point(separator.Bounds.Left + (separator.DropDownWidth == RibbonSeparatorDropDownWidth.Full ? 0 : 40), separator.Bounds.Top);
              Rectangle bounds = separator.Bounds;
              int right = bounds.Right;
              bounds = separator.Bounds;
              int top = bounds.Top;
              Point pt2 = new Point(right, top);
              graphics.DrawLine(pen4, pt1, pt2);
            }
          }
        }
        else if (separator.OwnerPanel == null)
        {
          using (Pen pen = new Pen(this.ColorTable.QATSeparatorDark))
            g.DrawLine(pen, new Point(separator.Bounds.Left + 1, separator.Bounds.Top + 5), new Point(separator.Bounds.Left + 1, separator.Bounds.Bottom - 1));
          using (Pen pen = new Pen(this.ColorTable.QATSeparatorLight))
            g.DrawLine(pen, new Point(separator.Bounds.Left + 2, separator.Bounds.Top + 5), new Point(separator.Bounds.Left + 2, separator.Bounds.Bottom - 1));
        }
        else
        {
          using (Pen pen = new Pen(this.ColorTable.SeparatorDark))
            g.DrawLine(pen, new Point(separator.Bounds.Left + 1, separator.Bounds.Top), new Point(separator.Bounds.Left + 1, separator.Bounds.Bottom));
          using (Pen pen = new Pen(this.ColorTable.SeparatorLight))
            g.DrawLine(pen, new Point(separator.Bounds.Left + 2, separator.Bounds.Top), new Point(separator.Bounds.Left + 2, separator.Bounds.Bottom));
        }
      }
      if (ribbon.OrbStyle != RibbonOrbStyle.Office_2010 && ribbon.OrbStyle != RibbonOrbStyle.Office_2010_Extended)
        return;
      if (separator.SizeMode == RibbonElementSizeMode.DropDown)
      {
        if (!string.IsNullOrEmpty(separator.Text))
        {
          using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.SeparatorBg))
            g.FillRectangle((Brush) solidBrush, separator.Bounds);
          using (Pen pen5 = new Pen(this.ColorTable.SeparatorLine))
          {
            Graphics graphics = g;
            Pen pen6 = pen5;
            int left = separator.Bounds.Left;
            Rectangle bounds = separator.Bounds;
            int bottom3 = bounds.Bottom;
            Point pt1 = new Point(left, bottom3);
            bounds = separator.Bounds;
            int right = bounds.Right;
            bounds = separator.Bounds;
            int bottom4 = bounds.Bottom;
            Point pt2 = new Point(right, bottom4);
            graphics.DrawLine(pen6, pt1, pt2);
          }
        }
        else
        {
          using (Pen pen7 = new Pen(this.ColorTable.DropDownImageSeparator))
          {
            if (separator.DropDownWidth == RibbonSeparatorDropDownWidth.Partial)
              pen7.DashStyle = DashStyle.Dash;
            Graphics graphics = g;
            Pen pen8 = pen7;
            Point pt1 = new Point(separator.Bounds.Left + (separator.DropDownWidth == RibbonSeparatorDropDownWidth.Full ? 0 : 40), separator.Bounds.Top);
            Rectangle bounds = separator.Bounds;
            int right = bounds.Right;
            bounds = separator.Bounds;
            int top = bounds.Top;
            Point pt2 = new Point(right, top);
            graphics.DrawLine(pen8, pt1, pt2);
          }
        }
      }
      else if (separator.OwnerPanel == null)
      {
        using (Pen pen = new Pen(this.ColorTable.QATSeparatorDark))
        {
          SmoothingMode smoothingMode = g.SmoothingMode;
          g.SmoothingMode = SmoothingMode.None;
          g.DrawLine(pen, new Point(separator.Bounds.Left + 1, separator.Bounds.Top + 5), new Point(separator.Bounds.Left + 1, separator.Bounds.Bottom - 1));
          g.SmoothingMode = smoothingMode;
        }
        using (Pen pen = new Pen(this.ColorTable.QATSeparatorLight))
        {
          SmoothingMode smoothingMode = g.SmoothingMode;
          g.SmoothingMode = SmoothingMode.None;
          g.DrawLine(pen, new Point(separator.Bounds.Left + 2, separator.Bounds.Top + 5), new Point(separator.Bounds.Left + 2, separator.Bounds.Bottom - 1));
          g.SmoothingMode = smoothingMode;
        }
      }
      else
      {
        Point point1_1 = new Point(separator.Bounds.Left, separator.Bounds.Top);
        Rectangle bounds1 = separator.Bounds;
        int left1 = bounds1.Left;
        bounds1 = separator.Bounds;
        int bottom5 = bounds1.Bottom;
        Point point2_1 = new Point(left1, bottom5);
        Color color1_1 = Color.FromArgb(50, this.ColorTable.SeparatorDark);
        Color separatorDark = this.ColorTable.SeparatorDark;
        using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(point1_1, point2_1, color1_1, separatorDark))
        {
          linearGradientBrush.SetSigmaBellShape(0.5f);
          using (Pen pen9 = new Pen((Brush) linearGradientBrush))
          {
            SmoothingMode smoothingMode = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.None;
            Graphics graphics = g;
            Pen pen10 = pen9;
            bounds1 = separator.Bounds;
            int x1 = bounds1.Left + 2;
            bounds1 = separator.Bounds;
            int y1 = bounds1.Top + 3;
            bounds1 = separator.Bounds;
            int x2 = bounds1.Left + 2;
            bounds1 = separator.Bounds;
            int y2 = bounds1.Bottom - 7;
            graphics.DrawLine(pen10, x1, y1, x2, y2);
            g.SmoothingMode = smoothingMode;
          }
        }
        Point point1_2 = new Point(separator.Bounds.Left, separator.Bounds.Top);
        Rectangle bounds2 = separator.Bounds;
        int left2 = bounds2.Left;
        bounds2 = separator.Bounds;
        int bottom6 = bounds2.Bottom;
        Point point2_2 = new Point(left2, bottom6);
        Color color1_2 = Color.FromArgb(50, this.ColorTable.SeparatorLight);
        Color separatorLight = this.ColorTable.SeparatorLight;
        using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(point1_2, point2_2, color1_2, separatorLight))
        {
          linearGradientBrush.SetSigmaBellShape(0.5f);
          using (Pen pen11 = new Pen((Brush) linearGradientBrush))
          {
            SmoothingMode smoothingMode = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.None;
            Graphics graphics1 = g;
            Pen pen12 = pen11;
            bounds2 = separator.Bounds;
            int x1_1 = bounds2.Left + 1;
            bounds2 = separator.Bounds;
            int y1_1 = bounds2.Top + 3;
            bounds2 = separator.Bounds;
            int x2_1 = bounds2.Left + 1;
            bounds2 = separator.Bounds;
            int y2_1 = bounds2.Bottom - 7;
            graphics1.DrawLine(pen12, x1_1, y1_1, x2_1, y2_1);
            Graphics graphics2 = g;
            Pen pen13 = pen11;
            bounds2 = separator.Bounds;
            int x1_2 = bounds2.Left + 3;
            bounds2 = separator.Bounds;
            int y1_2 = bounds2.Top + 3;
            bounds2 = separator.Bounds;
            int x2_2 = bounds2.Left + 3;
            bounds2 = separator.Bounds;
            int y2_2 = bounds2.Bottom - 7;
            graphics2.DrawLine(pen13, x1_2, y1_2, x2_2, y2_2);
            g.SmoothingMode = smoothingMode;
          }
        }
      }
    }

    public void DrawTextBoxDisabled(Graphics g, Rectangle bounds)
    {
      using (SolidBrush solidBrush = new SolidBrush(SystemColors.Control))
        g.FillRectangle((Brush) solidBrush, bounds);
      using (Pen pen = new Pen(this.ColorTable.TextBoxBorder))
        g.DrawRectangle(pen, bounds);
    }

    public void DrawTextBoxUnselected(Graphics g, Rectangle bounds)
    {
      using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.TextBoxUnselectedBg))
        g.FillRectangle((Brush) solidBrush, bounds);
      using (Pen pen = new Pen(this.ColorTable.TextBoxBorder))
        g.DrawRectangle(pen, bounds);
    }

    public void DrawTextBoxSelected(Graphics g, Rectangle bounds)
    {
      using (RibbonProfessionalRenderer.RoundRectangle(bounds, 3))
      {
        using (SolidBrush solidBrush = new SolidBrush(SystemColors.Window))
          g.FillRectangle((Brush) solidBrush, bounds);
        using (Pen pen = new Pen(this.ColorTable.TextBoxBorder))
          g.DrawRectangle(pen, bounds);
      }
    }

    [Obsolete("use DrawComboBoxDropDown")]
    public void DrawComboxDropDown(Graphics g, RibbonComboBox b, Ribbon ribbon) => this.DrawComboBoxDropDown(g, b, ribbon);

    public void DrawComboBoxDropDown(Graphics g, RibbonComboBox b, Ribbon ribbon)
    {
      if (b.DropDownButtonPressed)
        this.DrawButtonPressed(g, b.DropDownButtonBounds, RibbonProfessionalRenderer.Corners.None, ribbon);
      else if (b.DropDownButtonSelected)
        this.DrawButtonSelected(g, b.DropDownButtonBounds, RibbonProfessionalRenderer.Corners.None, ribbon);
      else if (b.Selected)
        this.DrawButton(g, b.DropDownButtonBounds, RibbonProfessionalRenderer.Corners.None);
      this.DrawArrowShaded(g, b.DropDownButtonBounds, RibbonArrowDirection.Down, true);
    }

    public void DrawUpDownButtons(Graphics g, RibbonUpDown b, Ribbon ribbon)
    {
      if (b.UpButtonPressed)
        this.DrawButtonPressed(g, b.UpButtonBounds, RibbonProfessionalRenderer.Corners.None, ribbon);
      else if (b.UpButtonSelected)
        this.DrawButtonSelected(g, b.UpButtonBounds, RibbonProfessionalRenderer.Corners.None, ribbon);
      else
        this.DrawButton(g, b.UpButtonBounds, RibbonProfessionalRenderer.Corners.None);
      if (b.DownButtonPressed)
        this.DrawButtonPressed(g, b.DownButtonBounds, RibbonProfessionalRenderer.Corners.None, ribbon);
      else if (b.DownButtonSelected)
        this.DrawButtonSelected(g, b.DownButtonBounds, RibbonProfessionalRenderer.Corners.None, ribbon);
      else
        this.DrawButton(g, b.DownButtonBounds, RibbonProfessionalRenderer.Corners.None);
      this.DrawArrowShaded(g, b.UpButtonBounds, RibbonArrowDirection.Up, true);
      this.DrawArrowShaded(g, b.DownButtonBounds, RibbonArrowDirection.Down, true);
    }

    public void DrawCaptionBarBackground(Rectangle r, Graphics g)
    {
      SmoothingMode smoothingMode = g.SmoothingMode;
      Rectangle rectangle1 = new Rectangle(r.Left, r.Top, r.Width, 4);
      Rectangle rectangle2 = new Rectangle(r.Left, rectangle1.Bottom, r.Width, 4);
      Rectangle rectangle3 = new Rectangle(r.Left, rectangle2.Bottom, r.Width, r.Height - 8);
      Rectangle rectangle4 = new Rectangle(r.Left, rectangle3.Bottom, r.Width, 1);
      Rectangle[] rectangleArray = new Rectangle[4]
      {
        rectangle1,
        rectangle2,
        rectangle3,
        rectangle4
      };
      Color[,] colorArray = new Color[4, 2]
      {
        {
          this.ColorTable.Caption1,
          this.ColorTable.Caption2
        },
        {
          this.ColorTable.Caption3,
          this.ColorTable.Caption4
        },
        {
          this.ColorTable.Caption5,
          this.ColorTable.Caption6
        },
        {
          this.ColorTable.Caption7,
          this.ColorTable.Caption7
        }
      };
      g.SmoothingMode = SmoothingMode.None;
      for (int index = 0; index < rectangleArray.Length; ++index)
      {
        Rectangle rect = rectangleArray[index];
        rect.Height += 2;
        --rect.Y;
        using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, colorArray[index, 0], colorArray[index, 1], 90f))
          g.FillRectangle((Brush) linearGradientBrush, rectangleArray[index]);
      }
      g.SmoothingMode = smoothingMode;
    }

    private void DrawCaptionBarText(Rectangle captionBar, RibbonRenderEventArgs e)
    {
      Form form = e.Ribbon.FindForm();
      if (form == null)
        return;
      Font font = new Font(SystemFonts.CaptionFont, FontStyle.Regular);
      if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass)
      {
        if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
          WinApi.DrawTextOnGlass(e.Graphics, form.Text, font, captionBar, 10);
        else
          WinApi.DrawTextOnGlass(e.Graphics, form.Text, SystemFonts.CaptionFont, captionBar, 10);
      }
      else
      {
        if (e.Ribbon.ActualBorderMode != RibbonWindowMode.NonClientAreaCustomDrawn)
          return;
        using (StringFormat format = StringFormatFactory.CenterNoWrapTrimEllipsis())
        {
          using (Brush brush = (Brush) new SolidBrush(this.ColorTable.FormBorder))
            e.Graphics.DrawString(form.Text, font, brush, (RectangleF) captionBar, format);
        }
      }
    }

    private GraphicsPath CreateQuickAccessPath(
      Point a,
      Point b,
      Point c,
      Point d,
      Point e,
      Rectangle bounds,
      int offsetx,
      int offsety,
      Ribbon ribbon)
    {
      a.Offset(offsetx, offsety);
      b.Offset(offsetx, offsety);
      c.Offset(offsetx, offsety);
      d.Offset(offsetx, offsety);
      e.Offset(offsetx, offsety);
      GraphicsPath graphicsPath = new GraphicsPath();
      if (ribbon.RightToLeft == RightToLeft.No)
      {
        graphicsPath.AddLine(a, b);
        graphicsPath.AddArc(new Rectangle(b.X - bounds.Height / 2, b.Y, bounds.Height, bounds.Height), -90f, 180f);
        graphicsPath.AddLine(d, c);
        if (ribbon.OrbVisible)
          graphicsPath.AddCurve(new Point[3]{ c, e, a });
        else
          graphicsPath.AddArc(new Rectangle(a.X - bounds.Height / 2, a.Y, bounds.Height, bounds.Height), 90f, 180f);
      }
      else
      {
        graphicsPath.AddLine(d, c);
        graphicsPath.AddArc(new Rectangle(a.X - bounds.Height / 2, a.Y, bounds.Height, bounds.Height), 90f, 180f);
        graphicsPath.AddLine(a, b);
        if (ribbon.OrbVisible)
          graphicsPath.AddCurve(new Point[3]{ b, e, d });
        else
          graphicsPath.AddArc(new Rectangle(b.X - bounds.Height / 2, b.Y, bounds.Height, bounds.Height), -90f, 180f);
      }
      return graphicsPath;
    }

    public void DrawOrb(Graphics g, Rectangle r, Image image, bool selected, bool pressed)
    {
      Rectangle rect1 = r;
      rect1.Inflate(-1, -1);
      Rectangle rect2 = r;
      rect2.Offset(1, 1);
      rect2.Inflate(2, 2);
      Color color1;
      Color color2;
      Color color3;
      Color color4;
      if (pressed)
      {
        color1 = this.ColorTable.OrbPressedBackgroundDark;
        color2 = this.ColorTable.OrbPressedBackgroundMedium;
        color3 = this.ColorTable.OrbPressedBackgroundLight;
        color4 = this.ColorTable.OrbPressedLight;
      }
      else if (selected)
      {
        color1 = this.ColorTable.OrbSelectedBackgroundDark;
        color2 = this.ColorTable.OrbSelectedBackgroundDark;
        color3 = this.ColorTable.OrbSelectedBackgroundLight;
        color4 = this.ColorTable.OrbSelectedLight;
      }
      else
      {
        color1 = this.ColorTable.OrbBackgroundDark;
        color2 = this.ColorTable.OrbBackgroundMedium;
        color3 = this.ColorTable.OrbBackgroundLight;
        color4 = this.ColorTable.OrbLight;
      }
      using (GraphicsPath path = new GraphicsPath())
      {
        path.AddEllipse(rect2);
        using (PathGradientBrush pathGradientBrush = new PathGradientBrush(path))
        {
          pathGradientBrush.WrapMode = WrapMode.Clamp;
          pathGradientBrush.CenterPoint = new PointF((float) (rect2.Left + rect2.Width / 2), (float) (rect2.Top + rect2.Height / 2));
          pathGradientBrush.CenterColor = Color.FromArgb(180, Color.Black);
          pathGradientBrush.SurroundColors = new Color[1]
          {
            Color.Transparent
          };
          Blend blend = new Blend(3)
          {
            Factors = new float[3]{ 0.0f, 1f, 1f },
            Positions = new float[3]{ 0.0f, 0.2f, 1f }
          };
          pathGradientBrush.Blend = blend;
          g.FillPath((Brush) pathGradientBrush, path);
        }
      }
      using (Pen pen = new Pen(color1, 1f))
        g.DrawEllipse(pen, r);
      using (GraphicsPath path = new GraphicsPath())
      {
        path.AddEllipse(r);
        using (PathGradientBrush pathGradientBrush = new PathGradientBrush(path))
        {
          pathGradientBrush.WrapMode = WrapMode.Clamp;
          pathGradientBrush.CenterPoint = new PointF(Convert.ToSingle(r.Left + r.Width / 2), Convert.ToSingle(r.Bottom));
          pathGradientBrush.CenterColor = color3;
          pathGradientBrush.SurroundColors = new Color[1]
          {
            color2
          };
          Blend blend = new Blend(3)
          {
            Factors = new float[3]{ 0.0f, 0.8f, 1f },
            Positions = new float[3]{ 0.0f, 0.5f, 1f }
          };
          pathGradientBrush.Blend = blend;
          g.FillPath((Brush) pathGradientBrush, path);
        }
      }
      Rectangle rect3 = new Rectangle(0, 0, r.Width / 2, r.Height / 2);
      rect3.X = r.X + (r.Width - rect3.Width) / 2;
      rect3.Y = r.Y + r.Height / 2;
      using (GraphicsPath path = new GraphicsPath())
      {
        path.AddEllipse(rect3);
        using (PathGradientBrush pathGradientBrush = new PathGradientBrush(path))
        {
          pathGradientBrush.WrapMode = WrapMode.Clamp;
          pathGradientBrush.CenterPoint = new PointF(Convert.ToSingle(r.Left + r.Width / 2), Convert.ToSingle(r.Bottom));
          pathGradientBrush.CenterColor = Color.White;
          pathGradientBrush.SurroundColors = new Color[1]
          {
            Color.Transparent
          };
          g.FillPath((Brush) pathGradientBrush, path);
        }
      }
      using (GraphicsPath path = new GraphicsPath())
      {
        int num1 = 160;
        int num2 = 180 + (180 - num1) / 2;
        path.AddArc(rect1, (float) num2, (float) num1);
        Point point1 = Point.Round(path.PathData.Points[0]);
        Point point2 = Point.Round(path.PathData.Points[path.PathData.Points.Length - 1]);
        Point point3 = new Point(rect1.Left + rect1.Width / 2, point2.Y - 3);
        path.AddCurve(new Point[3]{ point2, point3, point1 });
        using (PathGradientBrush pathGradientBrush = new PathGradientBrush(path))
        {
          pathGradientBrush.WrapMode = WrapMode.Clamp;
          pathGradientBrush.CenterPoint = (PointF) point3;
          pathGradientBrush.CenterColor = Color.Transparent;
          pathGradientBrush.SurroundColors = new Color[1]
          {
            color4
          };
          Blend blend = new Blend(3)
          {
            Factors = new float[3]{ 0.3f, 0.8f, 1f },
            Positions = new float[3]{ 0.0f, 0.5f, 1f }
          };
          pathGradientBrush.Blend = blend;
          g.FillPath((Brush) pathGradientBrush, path);
        }
        using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(r.Left, r.Top), new Point(r.Left, point1.Y), Color.White, Color.Transparent))
        {
          Blend blend = new Blend(4)
          {
            Factors = new float[4]{ 0.0f, 0.4f, 0.8f, 1f },
            Positions = new float[4]{ 0.0f, 0.3f, 0.4f, 1f }
          };
          linearGradientBrush.Blend = blend;
          g.FillPath((Brush) linearGradientBrush, path);
        }
      }
      using (GraphicsPath path = new GraphicsPath())
      {
        int num3 = 160;
        int num4 = 180 + (180 - num3) / 2;
        path.AddArc(rect1, (float) num4, (float) num3);
        using (Pen pen = new Pen(Color.White))
          g.DrawPath(pen, path);
      }
      using (GraphicsPath path = new GraphicsPath())
      {
        int num5 = 160;
        int num6 = (180 - num5) / 2;
        path.AddArc(rect1, (float) num6, (float) num5);
        Point point = Point.Round(path.PathData.Points[0]);
        Rectangle rect4 = rect1;
        rect4.Inflate(-1, -1);
        int num7 = 160;
        int num8 = (180 - num7) / 2;
        path.AddArc(rect4, (float) num8, (float) num7);
        using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(rect1.Left, rect1.Bottom), new Point(rect1.Left, point.Y - 1), color4, Color.FromArgb(50, color4)))
          g.FillPath((Brush) linearGradientBrush, path);
      }
      if (image == null)
        return;
      Rectangle rect5 = new Rectangle(Point.Empty, image.Size);
      rect5.X = r.X + (r.Width - rect5.Width) / 2;
      rect5.Y = r.Y + (r.Height - rect5.Height) / 2;
      g.DrawImage(image, rect5);
    }

    public void DrawOrbNormal(RibbonRenderEventArgs e)
    {
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
      {
        using (GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(e.ClipRectangle, 2, RibbonProfessionalRenderer.Corners.North))
        {
          e.Graphics.FillPath((Brush) new SolidBrush(this.ColorTable.OrbButtonBackground), path1);
          using (Pen pen = new Pen(this.ColorTable.OrbButtonBorderDark))
            e.Graphics.DrawPath(pen, path1);
          Rectangle clipRectangle1 = e.ClipRectangle;
          int left1 = clipRectangle1.Left + 1;
          clipRectangle1 = e.ClipRectangle;
          int top1 = clipRectangle1.Top + 1;
          clipRectangle1 = e.ClipRectangle;
          int right1 = clipRectangle1.Right - 1;
          clipRectangle1 = e.ClipRectangle;
          int bottom1 = clipRectangle1.Bottom;
          using (GraphicsPath path2 = RibbonProfessionalRenderer.RoundRectangle(Rectangle.FromLTRB(left1, top1, right1, bottom1), 2, RibbonProfessionalRenderer.Corners.North))
          {
            using (Pen pen = new Pen(this.ColorTable.OrbButtonMedium))
              e.Graphics.DrawPath(pen, path2);
          }
          Rectangle clipRectangle2 = e.ClipRectangle;
          int num = clipRectangle2.Height / 2;
          clipRectangle2 = e.ClipRectangle;
          int left2 = clipRectangle2.Left + 1;
          clipRectangle2 = e.ClipRectangle;
          int top2 = clipRectangle2.Top + num;
          clipRectangle2 = e.ClipRectangle;
          int right2 = clipRectangle2.Right - 2;
          clipRectangle2 = e.ClipRectangle;
          int bottom2 = clipRectangle2.Bottom - 1;
          Rectangle rect = Rectangle.FromLTRB(left2, top2, right2, bottom2);
          Color orbButtonDark = this.ColorTable.OrbButtonDark;
          Color orbButtonLight = this.ColorTable.OrbButtonLight;
          clipRectangle2 = e.ClipRectangle;
          Point point1 = new Point(0, clipRectangle2.Top + num);
          clipRectangle2 = e.ClipRectangle;
          Point point2 = new Point(0, clipRectangle2.Bottom);
          Color color1 = orbButtonDark;
          Color color2 = orbButtonLight;
          using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(point1, point2, color1, color2))
          {
            linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
            e.Graphics.FillRectangle((Brush) linearGradientBrush, rect);
          }
        }
      }
      else
      {
        if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
          return;
        using (GraphicsPath path = RibbonProfessionalRenderer.FlatRectangle(e.ClipRectangle))
        {
          SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
          e.Graphics.SmoothingMode = SmoothingMode.None;
          e.Graphics.FillPath((Brush) new SolidBrush(this.ColorTable.OrbButton_2013), path);
          e.Graphics.SmoothingMode = smoothingMode;
        }
      }
    }

    public void DrawOrbSelected(RibbonRenderEventArgs e)
    {
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
      {
        using (GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(e.ClipRectangle, 2, RibbonProfessionalRenderer.Corners.North))
        {
          e.Graphics.FillPath((Brush) new SolidBrush(this.ColorTable.ButtonPressedGlossySouth), path1);
          using (Pen pen = new Pen(this.ColorTable.ButtonPressedBorderOut))
            e.Graphics.DrawPath(pen, path1);
          Rectangle clipRectangle1 = e.ClipRectangle;
          int left1 = clipRectangle1.Left + 1;
          clipRectangle1 = e.ClipRectangle;
          int top1 = clipRectangle1.Top + 1;
          clipRectangle1 = e.ClipRectangle;
          int right1 = clipRectangle1.Right - 1;
          clipRectangle1 = e.ClipRectangle;
          int bottom1 = clipRectangle1.Bottom;
          using (GraphicsPath path2 = RibbonProfessionalRenderer.RoundRectangle(Rectangle.FromLTRB(left1, top1, right1, bottom1), 2, RibbonProfessionalRenderer.Corners.North))
          {
            using (Pen pen = new Pen(this.ColorTable.ButtonPressedBorderIn))
              e.Graphics.DrawPath(pen, path2);
          }
          Color selectedGlossyNorth = this.ColorTable.ButtonSelectedGlossyNorth;
          Color selectedGlossySouth = this.ColorTable.ButtonSelectedGlossySouth;
          int num = e.ClipRectangle.Height / 2;
          Rectangle clipRectangle2 = e.ClipRectangle;
          int left2 = clipRectangle2.Left + 1;
          clipRectangle2 = e.ClipRectangle;
          int top2 = clipRectangle2.Top + num;
          clipRectangle2 = e.ClipRectangle;
          int right2 = clipRectangle2.Right - 2;
          clipRectangle2 = e.ClipRectangle;
          int bottom2 = clipRectangle2.Bottom - 1;
          Rectangle rect = Rectangle.FromLTRB(left2, top2, right2, bottom2);
          clipRectangle2 = e.ClipRectangle;
          Point point1 = new Point(0, clipRectangle2.Top + num);
          clipRectangle2 = e.ClipRectangle;
          Point point2 = new Point(0, clipRectangle2.Bottom);
          Color color1 = selectedGlossyNorth;
          Color color2 = selectedGlossySouth;
          using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(point1, point2, color1, color2))
          {
            linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
            e.Graphics.FillRectangle((Brush) linearGradientBrush, rect);
          }
        }
      }
      else
      {
        if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
          return;
        using (GraphicsPath path = RibbonProfessionalRenderer.FlatRectangle(e.ClipRectangle))
        {
          SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
          e.Graphics.SmoothingMode = SmoothingMode.None;
          e.Graphics.FillPath((Brush) new SolidBrush(this.ColorTable.OrbButtonSelected_2013), path);
          e.Graphics.SmoothingMode = smoothingMode;
        }
      }
    }

    public void DrawOrbPressed(RibbonRenderEventArgs e)
    {
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
      {
        using (GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(e.ClipRectangle, 2, RibbonProfessionalRenderer.Corners.North))
        {
          e.Graphics.FillPath((Brush) new SolidBrush(this.ColorTable.ButtonPressedGlossySouth), path1);
          using (Pen pen = new Pen(this.ColorTable.ButtonPressedBorderOut))
            e.Graphics.DrawPath(pen, path1);
          Rectangle clipRectangle1 = e.ClipRectangle;
          int left1 = clipRectangle1.Left + 1;
          clipRectangle1 = e.ClipRectangle;
          int top1 = clipRectangle1.Top + 1;
          clipRectangle1 = e.ClipRectangle;
          int right1 = clipRectangle1.Right - 1;
          clipRectangle1 = e.ClipRectangle;
          int bottom1 = clipRectangle1.Bottom;
          using (GraphicsPath path2 = RibbonProfessionalRenderer.RoundRectangle(Rectangle.FromLTRB(left1, top1, right1, bottom1), 2, RibbonProfessionalRenderer.Corners.North))
          {
            using (Pen pen = new Pen(this.ColorTable.ButtonPressedBorderIn))
              e.Graphics.DrawPath(pen, path2);
          }
          Color pressedGlossyNorth = this.ColorTable.ButtonPressedGlossyNorth;
          Color pressedGlossySouth = this.ColorTable.ButtonPressedGlossySouth;
          int num = e.ClipRectangle.Height / 2;
          Rectangle clipRectangle2 = e.ClipRectangle;
          int left2 = clipRectangle2.Left + 1;
          clipRectangle2 = e.ClipRectangle;
          int top2 = clipRectangle2.Top + num;
          clipRectangle2 = e.ClipRectangle;
          int right2 = clipRectangle2.Right - 2;
          clipRectangle2 = e.ClipRectangle;
          int bottom2 = clipRectangle2.Bottom - 1;
          Rectangle rect = Rectangle.FromLTRB(left2, top2, right2, bottom2);
          clipRectangle2 = e.ClipRectangle;
          Point point1 = new Point(0, clipRectangle2.Top + num);
          clipRectangle2 = e.ClipRectangle;
          Point point2 = new Point(0, clipRectangle2.Bottom);
          Color color1 = pressedGlossyNorth;
          Color color2 = pressedGlossySouth;
          using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(point1, point2, color1, color2))
          {
            linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
            e.Graphics.FillRectangle((Brush) linearGradientBrush, rect);
          }
        }
      }
      else
      {
        if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
          return;
        using (GraphicsPath path = RibbonProfessionalRenderer.FlatRectangle(e.ClipRectangle))
        {
          SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
          e.Graphics.SmoothingMode = SmoothingMode.None;
          e.Graphics.FillPath((Brush) new SolidBrush(this.ColorTable.OrbButtonPressed_2013), path);
          e.Graphics.SmoothingMode = smoothingMode;
        }
      }
    }

    public override void OnRenderRibbonCaptionBar(RibbonRenderEventArgs e)
    {
      if (!e.Ribbon.CaptionBarVisible)
        return;
      Rectangle rectangle = new Rectangle(0, 0, e.Ribbon.Width, e.Ribbon.CaptionBarSize);
      if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass)
      {
        RibbonDesigner current = RibbonDesigner.Current;
      }
      this.DrawCaptionBarText(e.Ribbon.CaptionTextBounds, e);
    }

    public override void OnRenderOrbDropDownBackground(RibbonOrbDropDownEventArgs e)
    {
      int width1 = e.RibbonOrbDropDown.Width;
      int height = e.RibbonOrbDropDown.Height;
      Rectangle contentBounds = e.RibbonOrbDropDown.ContentBounds;
      Rectangle contentButtonsBounds = e.RibbonOrbDropDown.ContentButtonsBounds;
      Rectangle r1 = new Rectangle(0, 0, width1 - 1, height - 1);
      Rectangle r2 = new Rectangle(1, 1, width1 - 3, height - 3);
      Rectangle r3 = new Rectangle(1, 1, width1 - 3, contentBounds.Top / 2);
      Rectangle r4 = new Rectangle(1, r3.Bottom, r3.Width, contentBounds.Top / 2);
      Rectangle r5 = Rectangle.FromLTRB(1, (height - contentBounds.Bottom) / 2 + contentBounds.Bottom, width1 - 1, height - 1);
      Color dropDownDarkBorder = this.ColorTable.OrbDropDownDarkBorder;
      Color dropDownLightBorder = this.ColorTable.OrbDropDownLightBorder;
      Color orbDropDownBack = this.ColorTable.OrbDropDownBack;
      Color orbDropDownNorthA = this.ColorTable.OrbDropDownNorthA;
      Color orbDropDownNorthB = this.ColorTable.OrbDropDownNorthB;
      Color orbDropDownNorthC = this.ColorTable.OrbDropDownNorthC;
      Color orbDropDownNorthD = this.ColorTable.OrbDropDownNorthD;
      Color orbDropDownSouthC = this.ColorTable.OrbDropDownSouthC;
      Color orbDropDownSouthD = this.ColorTable.OrbDropDownSouthD;
      Color dropDownContentbg = this.ColorTable.OrbDropDownContentbg;
      Color downContentbglight = this.ColorTable.OrbDropDownContentbglight;
      Color downSeparatorlight = this.ColorTable.OrbDropDownSeparatorlight;
      Color downSeparatordark = this.ColorTable.OrbDropDownSeparatordark;
      GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(r2, 6);
      GraphicsPath path2 = RibbonProfessionalRenderer.RoundRectangle(r1, 6);
      e.Graphics.SmoothingMode = SmoothingMode.None;
      using (Brush brush = (Brush) new SolidBrush(Color.FromArgb(142, 142, 142)))
        e.Graphics.FillRectangle(brush, new Rectangle(width1 - 10, height - 10, 10, 10));
      using (Brush brush = (Brush) new SolidBrush(orbDropDownBack))
        e.Graphics.FillPath(brush, path2);
      this.GradientRect(e.Graphics, r3, orbDropDownNorthA, orbDropDownNorthB);
      this.GradientRect(e.Graphics, r4, orbDropDownNorthC, orbDropDownNorthD);
      this.GradientRect(e.Graphics, r5, orbDropDownSouthC, orbDropDownSouthD);
      using (Pen pen = new Pen(dropDownDarkBorder))
        e.Graphics.DrawPath(pen, path2);
      SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
      e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
      using (Pen pen = new Pen(dropDownLightBorder))
        e.Graphics.DrawPath(pen, path1);
      e.Graphics.SmoothingMode = smoothingMode;
      path1.Dispose();
      path2.Dispose();
      Rectangle rect1 = contentBounds;
      rect1.Inflate(0, 0);
      Rectangle rect2 = contentBounds;
      rect2.Inflate(1, 1);
      using (SolidBrush solidBrush = new SolidBrush(dropDownContentbg))
        e.Graphics.FillRectangle((Brush) solidBrush, contentBounds);
      if (e.RibbonOrbDropDown.ContentRecentItemsCaptionBounds.Height > 0)
      {
        Rectangle itemsCaptionBounds = e.RibbonOrbDropDown.ContentRecentItemsCaptionBounds;
        int int32 = Convert.ToInt32(e.RibbonOrbDropDown.RecentItemsCaptionLineSpacing / 2);
        using (Pen pen = new Pen(downSeparatorlight))
          e.Graphics.DrawLine(pen, new Point(contentBounds.Left, itemsCaptionBounds.Bottom - int32), new Point(contentBounds.Right, itemsCaptionBounds.Bottom - int32));
        using (Pen pen = new Pen(downSeparatordark))
          e.Graphics.DrawLine(pen, new Point(contentBounds.Left, itemsCaptionBounds.Bottom - int32 - 1), new Point(contentBounds.Right, itemsCaptionBounds.Bottom - int32 - 1));
        ref Rectangle local1 = ref itemsCaptionBounds;
        int x = local1.X;
        Padding itemMargin = e.Ribbon.ItemMargin;
        int left1 = itemMargin.Left;
        local1.X = x + left1;
        ref Rectangle local2 = ref itemsCaptionBounds;
        int width2 = local2.Width;
        itemMargin = e.Ribbon.ItemMargin;
        int left2 = itemMargin.Left;
        itemMargin = e.Ribbon.ItemMargin;
        int right = itemMargin.Right;
        int num = left2 + right;
        local2.Width = width2 - num;
        itemsCaptionBounds.Height -= e.RibbonOrbDropDown.RecentItemsCaptionLineSpacing;
        StringFormat format = new StringFormat()
        {
          LineAlignment = StringAlignment.Center
        };
        format.Alignment = e.Ribbon.RightToLeft != RightToLeft.Yes ? StringAlignment.Near : StringAlignment.Far;
        e.Graphics.DrawString(e.RibbonOrbDropDown.RecentItemsCaption, new Font(e.Ribbon.RibbonTabFont.FontFamily, e.Ribbon.RibbonTabFont.Size, FontStyle.Bold), Brushes.DarkBlue, (RectangleF) itemsCaptionBounds, format);
      }
      using (SolidBrush solidBrush = new SolidBrush(downContentbglight))
        e.Graphics.FillRectangle((Brush) solidBrush, contentButtonsBounds);
      using (Pen pen = new Pen(downSeparatorlight))
        e.Graphics.DrawLine(pen, contentButtonsBounds.Right, contentButtonsBounds.Top, contentButtonsBounds.Right, contentButtonsBounds.Bottom);
      using (Pen pen = new Pen(downSeparatordark))
        e.Graphics.DrawLine(pen, contentButtonsBounds.Right - 1, contentButtonsBounds.Top, contentButtonsBounds.Right - 1, contentButtonsBounds.Bottom);
      using (Pen pen = new Pen(dropDownLightBorder))
        e.Graphics.DrawRectangle(pen, rect2);
      using (Pen pen = new Pen(dropDownDarkBorder))
        e.Graphics.DrawRectangle(pen, rect1);
      if (!e.Ribbon.OrbVisible || !e.Ribbon.CaptionBarVisible || e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2007)
        return;
      Rectangle screen = e.Ribbon.RectangleToScreen(e.Ribbon.OrbBounds);
      Rectangle client = e.RibbonOrbDropDown.RectangleToClient(screen);
      this.DrawOrb(e.Graphics, client, e.Ribbon.OrbImage, e.Ribbon.OrbSelected, e.Ribbon.OrbPressed);
    }

    public override void OnRenderRibbonQuickAccessToolbarBackground(RibbonRenderEventArgs e)
    {
      Rectangle bounds = e.Ribbon.QuickAccessToolbar.Bounds;
      Padding padding = e.Ribbon.QuickAccessToolbar.Padding;
      Padding margin = e.Ribbon.QuickAccessToolbar.Margin;
      Point a = new Point(bounds.Left - (e.Ribbon.OrbVisible ? margin.Left : 0), bounds.Top);
      Point point1 = new Point(bounds.Right + padding.Right, bounds.Top);
      Point c = new Point(bounds.Left, bounds.Bottom);
      Point point2 = new Point(point1.X, c.Y);
      Point e1 = new Point(c.X - 2, a.Y + bounds.Height / 2 - 1);
      bool flag = e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass && RibbonDesigner.Current == null;
      if (e.Ribbon.RightToLeft == RightToLeft.Yes)
      {
        a = new Point(bounds.Left + padding.Left, bounds.Top);
        point1 = new Point(bounds.Right + (e.Ribbon.OrbVisible ? margin.Right : 0), bounds.Top);
        c = new Point(a.X, bounds.Bottom);
        point2 = new Point(bounds.Right, bounds.Bottom);
        e1 = new Point(point2.X + 2, point1.Y + bounds.Height / 2 - 1);
      }
      using (GraphicsPath quickAccessPath = this.CreateQuickAccessPath(a, point1, c, point2, e1, bounds, 0, 0, e.Ribbon))
      {
        if (!flag)
        {
          using (Pen pen = new Pen(this.ColorTable.QuickAccessBorderLight, 3f))
            e.Graphics.DrawPath(pen, quickAccessPath);
        }
        using (Pen pen = new Pen(this.ColorTable.QuickAccessBorderDark, 1f))
        {
          if (flag)
            pen.Color = Color.FromArgb(150, 150, 150);
          e.Graphics.DrawPath(pen, quickAccessPath);
        }
        if (e.Ribbon.RightToLeft == RightToLeft.Yes)
        {
          point1 = a;
          point2 = c;
        }
        if (!flag)
        {
          using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(point1, point2, Color.FromArgb(150, this.ColorTable.QuickAccessUpper), Color.FromArgb(150, this.ColorTable.QuickAccessLower)))
            e.Graphics.FillPath((Brush) linearGradientBrush, quickAccessPath);
        }
        else
        {
          using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(point1, point2, Color.FromArgb(66, RibbonProfesionalRendererColorTable.ToGray(this.ColorTable.QuickAccessUpper)), Color.FromArgb(66, RibbonProfesionalRendererColorTable.ToGray(this.ColorTable.QuickAccessLower))))
            e.Graphics.FillPath((Brush) linearGradientBrush, quickAccessPath);
        }
      }
    }

    private string FormatText(string text, string altKey, bool altPressed) => altPressed && !string.IsNullOrEmpty(altKey) && text.Contains(altKey) ? new Regex(Regex.Escape(altKey), RegexOptions.IgnoreCase).Replace(text.Replace("&", ""), "&" + altKey, 1).Replace("&&", "&") : text;

    public override void OnRenderRibbonOrb(RibbonRenderEventArgs e)
    {
      if (!e.Ribbon.OrbVisible)
        return;
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
      {
        if (!e.Ribbon.CaptionBarVisible)
          return;
        this.DrawOrb(e.Graphics, e.Ribbon.OrbBounds, e.Ribbon.OrbImage, e.Ribbon.OrbSelected, e.Ribbon.OrbPressed);
      }
      else
      {
        if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2010 && e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2010_Extended && e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
          return;
        RibbonRenderEventArgs e1 = new RibbonRenderEventArgs(e.Ribbon, e.Graphics, e.Ribbon.OrbBounds);
        if (e.Ribbon.OrbPressed)
          this.DrawOrbPressed(e1);
        else if (e.Ribbon.OrbSelected)
          this.DrawOrbSelected(e1);
        else
          this.DrawOrbNormal(e1);
        if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
        {
          if (e.Ribbon.OrbText != string.Empty)
          {
            using (StringFormat format = StringFormatFactory.CenterNoWrapTrimEllipsis())
            {
              using (Brush brush = (Brush) new SolidBrush(this.ColorTable.OrbButtonText))
                e.Graphics.DrawString(this.FormatText(e.Ribbon.OrbText, e.Ribbon.AltKey, e.Ribbon.AltPressed), e.Ribbon.RibbonTabFont, brush, (RectangleF) e.Ribbon.OrbBounds, format);
            }
          }
        }
        else if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2013 && e.Ribbon.OrbText != string.Empty)
        {
          using (StringFormat format = StringFormatFactory.CenterNoWrapTrimEllipsis())
          {
            using (Brush brush = (Brush) new SolidBrush(this.ColorTable.OrbButtonText_2013))
              e.Graphics.DrawString(this.FormatText(e.Ribbon.OrbText, e.Ribbon.AltKey, e.Ribbon.AltPressed), e.Ribbon.RibbonTabFont, brush, (RectangleF) e.Ribbon.OrbBounds, format);
          }
        }
        if (e.Ribbon.OrbImage == null)
          return;
        Rectangle rect = new Rectangle(Point.Empty, e.Ribbon.OrbImage.Size);
        ref Rectangle local = ref rect;
        Rectangle orbBounds = e.Ribbon.OrbBounds;
        int x = orbBounds.X;
        orbBounds = e.Ribbon.OrbBounds;
        int num1 = (orbBounds.Width - rect.Width) / 2;
        int num2 = x + num1;
        local.X = num2;
        rect.Y = e.Ribbon.OrbBounds.Y + (e.Ribbon.OrbBounds.Height - rect.Height) / 2;
        e.Graphics.DrawImage(e.Ribbon.OrbImage, rect);
      }
    }

    public override void OnRenderRibbonBackground(RibbonRenderEventArgs e)
    {
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
      {
        e.Graphics.Clear(this.ColorTable.RibbonBackground);
        if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass && !e.Ribbon.IsDesignMode())
          WinApi.FillForGlass(e.Graphics, new Rectangle(0, 0, e.Ribbon.Width, e.Ribbon.CaptionBarSize + 1));
      }
      Padding tabsMargin;
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
      {
        e.Graphics.Clear(this.ColorTable.RibbonBackground);
        if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass)
        {
          Graphics graphics = e.Graphics;
          int width = e.Ribbon.Width;
          int captionBarSize = e.Ribbon.CaptionBarSize;
          tabsMargin = e.Ribbon.TabsMargin;
          int top = tabsMargin.Top;
          int height = captionBarSize + top;
          Rectangle r = new Rectangle(0, 0, width, height);
          WinApi.FillForGlass(graphics, r);
        }
      }
      if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
        return;
      e.Graphics.Clear(this.ColorTable.RibbonBackground_2013);
      if (e.Ribbon.ActualBorderMode != RibbonWindowMode.NonClientAreaGlass)
        return;
      Graphics graphics1 = e.Graphics;
      int width1 = e.Ribbon.Width;
      int captionBarSize1 = e.Ribbon.CaptionBarSize;
      tabsMargin = e.Ribbon.TabsMargin;
      int top1 = tabsMargin.Top;
      int height1 = captionBarSize1 + top1;
      Rectangle r1 = new Rectangle(0, 0, width1, height1);
      WinApi.FillForGlass(graphics1, r1);
    }

    public override void OnRenderRibbonTab(RibbonTabRenderEventArgs e)
    {
      if (e.Ribbon.Minimized && !e.Ribbon.Expanded)
        this.DrawTabMinimized(e);
      else if (e.Tab.Active)
      {
        this.DrawTabNormal(e);
        this.DrawTabActive(e);
        this.DrawCompleteTab(e);
        if (!e.Tab.Selected || e.Tab.Invisible)
          return;
        this.DrawTabActiveSelected(e);
      }
      else
      {
        if (e.Tab.Pressed)
          return;
        if (e.Tab.Selected)
        {
          this.DrawTabNormal(e);
          this.DrawTabSelected(e);
        }
        else
          this.DrawTabNormal(e);
      }
    }

    public override void OnRenderRibbonContext(RibbonContextRenderEventArgs e) => this.DrawContextNormal(e);

    private void DrawContextNormal(RibbonContextRenderEventArgs e)
    {
      RectangleF clipBounds = e.Graphics.ClipBounds;
      Rectangle bounds = e.Context.Bounds;
      int left = bounds.Left;
      bounds = e.Context.Bounds;
      int top = bounds.Top;
      bounds = e.Context.Bounds;
      int right = bounds.Right;
      bounds = e.Context.Bounds;
      int bottom = bounds.Bottom;
      Rectangle rect1 = Rectangle.FromLTRB(left, top, right, bottom);
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
        Rectangle.FromLTRB(e.Context.Bounds.Left, e.Context.Bounds.Top + 13, e.Context.Bounds.Right, e.Context.Bounds.Bottom);
      else
        Rectangle.FromLTRB(e.Context.Bounds.Left, e.Context.Bounds.Top, e.Context.Bounds.Right, e.Context.Bounds.Bottom);
      Rectangle rect2 = e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2010_Extended ? Rectangle.FromLTRB(e.Context.HeaderBounds.Left, e.Context.HeaderBounds.Top, e.Context.HeaderBounds.Right, e.Context.HeaderBounds.Bottom) : Rectangle.FromLTRB(e.Context.HeaderBounds.Left, e.Context.HeaderBounds.Top + 13, e.Context.HeaderBounds.Right, e.Context.HeaderBounds.Bottom);
      Rectangle rect3 = e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2010_Extended ? Rectangle.FromLTRB(e.Context.Bounds.Left, e.Context.Bounds.Top, e.Context.Bounds.Right, e.Context.Bounds.Top + 5) : Rectangle.FromLTRB(e.Context.Bounds.Left, e.Context.Bounds.Top + 13, e.Context.Bounds.Right, e.Context.Bounds.Top + 5);
      e.Graphics.SetClip(rect1);
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007)
      {
        Color color1 = Color.FromArgb(200, this.DarkenColor(e.Context.GlowColor, 0.3f));
        Color color = Color.FromArgb(120, this.DarkenColor(e.Context.GlowColor, 0.2f));
        Color color2 = Color.FromArgb(40, this.DarkenColor(e.Context.GlowColor, 0.0f));
        using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect2, color1, color2, 90f))
        {
          ColorBlend colorBlend = new ColorBlend(3)
          {
            Colors = new Color[3]{ color1, color, color2 },
            Positions = new float[3]{ 0.0f, 0.3f, 1f }
          };
          linearGradientBrush.InterpolationColors = colorBlend;
          SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
          e.Graphics.SmoothingMode = SmoothingMode.None;
          e.Graphics.FillRectangle((Brush) linearGradientBrush, rect2);
          e.Graphics.SmoothingMode = smoothingMode;
        }
        using (Brush brush = (Brush) new SolidBrush(e.Context.GlowColor))
        {
          SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
          e.Graphics.SmoothingMode = SmoothingMode.None;
          e.Graphics.FillRectangle(brush, rect3);
          e.Graphics.SmoothingMode = smoothingMode;
        }
      }
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
      {
        Color color1;
        Color color;
        Color color2;
        if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010)
        {
          color1 = Color.FromArgb(200, this.DarkenColor(e.Context.GlowColor, 0.3f));
          color = Color.FromArgb(120, this.DarkenColor(e.Context.GlowColor, 0.2f));
          color2 = Color.FromArgb(40, this.DarkenColor(e.Context.GlowColor, 0.0f));
        }
        else
        {
          color1 = Color.FromArgb(200, this.DarkenColor(e.Context.GlowColor, 0.1f));
          color = color1;
          color2 = color1;
        }
        using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect2, color1, color2, 90f))
        {
          ColorBlend colorBlend = new ColorBlend(3)
          {
            Colors = new Color[3]{ color1, color, color2 },
            Positions = new float[3]{ 0.0f, 0.3f, 1f }
          };
          linearGradientBrush.InterpolationColors = colorBlend;
          SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
          e.Graphics.SmoothingMode = SmoothingMode.None;
          e.Graphics.FillRectangle((Brush) linearGradientBrush, rect2);
          e.Graphics.SmoothingMode = smoothingMode;
        }
        using (Brush brush = (Brush) new SolidBrush(e.Context.GlowColor))
        {
          SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
          e.Graphics.SmoothingMode = SmoothingMode.None;
          e.Graphics.FillRectangle(brush, rect3);
          e.Graphics.SmoothingMode = smoothingMode;
        }
      }
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2013)
      {
        Color color1 = Color.FromArgb(200, this.DarkenColor(e.Context.GlowColor, 0.3f));
        Color color = Color.FromArgb(120, this.DarkenColor(e.Context.GlowColor, 0.2f));
        Color color2 = Color.FromArgb(40, this.DarkenColor(e.Context.GlowColor, 0.0f));
        using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect2, color1, color2, 90f))
        {
          ColorBlend colorBlend = new ColorBlend(3)
          {
            Colors = new Color[3]{ color1, color, color2 },
            Positions = new float[3]{ 0.0f, 0.3f, 1f }
          };
          linearGradientBrush.InterpolationColors = colorBlend;
          SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
          e.Graphics.SmoothingMode = SmoothingMode.None;
          e.Graphics.FillRectangle((Brush) linearGradientBrush, rect2);
          e.Graphics.SmoothingMode = smoothingMode;
        }
        using (Brush brush = (Brush) new SolidBrush(e.Context.GlowColor))
        {
          SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
          e.Graphics.SmoothingMode = SmoothingMode.None;
          e.Graphics.FillRectangle(brush, rect3);
          e.Graphics.SmoothingMode = smoothingMode;
        }
      }
      e.Graphics.SetClip(clipBounds);
    }

    public override void OnRenderRibbonContextText(RibbonContextRenderEventArgs e)
    {
      StringFormat format = StringFormatFactory.CenterNoWrapTrimEllipsis();
      format.LineAlignment = StringAlignment.Near;
      Rectangle layoutRect1;
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
      {
        Rectangle bounds = e.Context.Bounds;
        int left = bounds.Left + e.Ribbon.TabTextMargin.Left;
        bounds = e.Context.Bounds;
        int top = bounds.Top + e.Ribbon.TabTextMargin.Top + 9;
        bounds = e.Context.Bounds;
        int right = bounds.Right - e.Ribbon.TabTextMargin.Right;
        bounds = e.Context.Bounds;
        int bottom = bounds.Bottom - e.Ribbon.TabTextMargin.Bottom;
        layoutRect1 = Rectangle.FromLTRB(left, top, right, bottom);
      }
      else
      {
        Rectangle bounds = e.Context.Bounds;
        int left = bounds.Left + e.Ribbon.TabTextMargin.Left;
        bounds = e.Context.Bounds;
        int top = bounds.Top + e.Ribbon.TabTextMargin.Top + 3;
        bounds = e.Context.Bounds;
        int right = bounds.Right - e.Ribbon.TabTextMargin.Right;
        bounds = e.Context.Bounds;
        int bottom = bounds.Bottom - e.Ribbon.TabTextMargin.Bottom;
        layoutRect1 = Rectangle.FromLTRB(left, top, right, bottom);
      }
      Rectangle layoutRect2 = layoutRect1;
      layoutRect2.Offset(0, 1);
      string text = e.Context.Text;
      if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2007 && e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2010 && e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2010_Extended && e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
        return;
      if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2010_Extended)
      {
        using (Brush brush = (Brush) new SolidBrush(this.GetTextColor(true, this.DarkenColor(e.Context.GlowColor, 0.5f))))
        {
          if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass)
          {
            GraphicsPath path = new GraphicsPath();
            float emSize = (float) ((double) e.Graphics.DpiY * (double) e.Ribbon.RibbonTabFont.Size / 72.0);
            path.AddString(text, e.Ribbon.RibbonTabFont.FontFamily, 1, emSize, layoutRect2, format);
            SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.FillPath(brush, path);
            e.Graphics.SmoothingMode = smoothingMode;
          }
          else
          {
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            Font font = new Font(e.Ribbon.RibbonTabFont, FontStyle.Bold);
            e.Graphics.DrawString(text, font, brush, (RectangleF) layoutRect2, format);
          }
        }
      }
      using (Brush brush = (Brush) new SolidBrush(this.GetTextColor(true, Color.White)))
      {
        if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass)
        {
          GraphicsPath path = new GraphicsPath();
          float emSize = e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2010_Extended ? (float) ((double) e.Graphics.DpiY * (double) e.Ribbon.RibbonTabFont.Size / 72.0) : (float) ((double) e.Graphics.DpiY * (double) e.Ribbon.RibbonTabFont.Size / 96.0);
          path.AddString(text, e.Ribbon.RibbonTabFont.FontFamily, 1, emSize, layoutRect1, format);
          SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
          e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
          e.Graphics.FillPath(brush, path);
          e.Graphics.SmoothingMode = smoothingMode;
        }
        else
        {
          e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
          Font font = new Font(e.Ribbon.RibbonTabFont, FontStyle.Bold);
          e.Graphics.DrawString(text, font, brush, (RectangleF) layoutRect1, format);
        }
      }
    }

    public override void OnRenderRibbonTabText(RibbonTabRenderEventArgs e)
    {
      StringFormat format = StringFormatFactory.CenterNoWrapTrimEllipsis();
      format.HotkeyPrefix = !e.Ribbon.AltPressed ? HotkeyPrefix.Hide : HotkeyPrefix.Show;
      int left = e.Tab.TabBounds.Left + e.Ribbon.TabTextMargin.Left;
      Rectangle tabBounds = e.Tab.TabBounds;
      int top = tabBounds.Top + e.Ribbon.TabTextMargin.Top;
      tabBounds = e.Tab.TabBounds;
      int right = tabBounds.Right - e.Ribbon.TabTextMargin.Right;
      tabBounds = e.Tab.TabBounds;
      int bottom = tabBounds.Bottom - e.Ribbon.TabTextMargin.Bottom;
      Rectangle layoutRect = Rectangle.FromLTRB(left, top, right, bottom);
      string s = this.FormatText(e.Tab.Text, e.Tab.AltKey, e.Ribbon.AltPressed);
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
      {
        using (Brush brush = (Brush) new SolidBrush(this.GetTextColor(e.Tab.Enabled, e.Tab.Active ? this.ColorTable.TabActiveText : this.ColorTable.TabText)))
        {
          if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass)
          {
            GraphicsPath path = new GraphicsPath();
            float emSize = (float) ((double) e.Graphics.DpiY * (double) e.Ribbon.RibbonTabFont.Size / 72.0);
            path.AddString(s, e.Ribbon.RibbonTabFont.FontFamily, 0, emSize, layoutRect, format);
            SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.FillPath(brush, path);
            e.Graphics.SmoothingMode = smoothingMode;
          }
          else
          {
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.DrawString(s, e.Ribbon.RibbonTabFont, brush, (RectangleF) layoutRect, format);
          }
        }
      }
      else
      {
        if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
          return;
        using (Brush brush = (Brush) new SolidBrush(this.GetTextColor(e.Tab.Enabled, e.Tab.Active || e.Tab.Selected ? this.ColorTable.TabText_2013 : this.ColorTable.TabTextSelected_2013)))
        {
          if (e.Ribbon.ActualBorderMode == RibbonWindowMode.NonClientAreaGlass)
          {
            GraphicsPath path = new GraphicsPath();
            float emSize = (float) ((double) e.Graphics.DpiY * (double) e.Ribbon.RibbonTabFont.Size / 72.0);
            path.AddString(s, e.Ribbon.RibbonTabFont.FontFamily, 0, emSize, layoutRect, format);
            SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.FillPath(brush, path);
            e.Graphics.SmoothingMode = smoothingMode;
          }
          else
          {
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.DrawString(s, e.Ribbon.RibbonTabFont, brush, (RectangleF) layoutRect, format);
          }
        }
      }
    }

    public override void OnRenderRibbonPanelBackground(RibbonPanelRenderEventArgs e)
    {
      if (e.Panel.OverflowMode && !(e.Canvas is RibbonPanelPopup))
      {
        if (e.Panel.Pressed)
          this.DrawPanelOverflowPressed(e);
        else if (e.Panel.Selected)
          this.DrawPanelOverflowSelected(e);
        else
          this.DrawPanelOverflowNormal(e);
      }
      else if (e.Panel.Selected && (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended))
        this.DrawPanelSelected(e);
      else
        this.DrawPanelNormal(e);
    }

    public override void OnRenderRibbonPanelText(RibbonPanelRenderEventArgs e)
    {
      if (e.Panel.OverflowMode && !(e.Canvas is RibbonPanelPopup))
        return;
      int left = e.Panel.Bounds.Left + 1;
      Rectangle rectangle1 = e.Panel.ContentBounds;
      int bottom1 = rectangle1.Bottom;
      rectangle1 = e.Panel.Bounds;
      int right = rectangle1.Right - 1;
      rectangle1 = e.Panel.Bounds;
      int bottom2 = rectangle1.Bottom - 1;
      Rectangle rectangle2 = Rectangle.FromLTRB(left, bottom1, right, bottom2);
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
      {
        using (StringFormat format = StringFormatFactory.Center())
        {
          using (Brush brush = (Brush) new SolidBrush(this.GetTextColor(e.Panel.Enabled, this.ColorTable.PanelText)))
            e.Graphics.DrawString(e.Panel.Text, e.Ribbon.Font, brush, (RectangleF) rectangle2, format);
        }
      }
      else
      {
        if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
          return;
        using (StringFormat format = StringFormatFactory.Center())
        {
          using (Brush brush = (Brush) new SolidBrush(this.GetTextColor(e.Panel.Enabled, this.ColorTable.PanelText_2013)))
            e.Graphics.DrawString(e.Panel.Text, e.Ribbon.Font, brush, (RectangleF) rectangle2, format);
        }
      }
    }

    public override void OnRenderRibbonItem(RibbonItemRenderEventArgs e)
    {
      if (e.Item is RibbonButton)
      {
        RibbonButton button = e.Item as RibbonButton;
        if (button.Enabled)
        {
          if (button.Style == RibbonButtonStyle.Normal)
          {
            if (button.SizeMode == RibbonElementSizeMode.DropDown)
            {
              if (button.Selected)
                this.DrawButtonSelected(e.Graphics, button, e.Ribbon);
            }
            else if (button.Pressed)
              this.DrawButtonPressed(e.Graphics, button, e.Ribbon);
            else if (button.Selected && button.Checked)
              this.DrawButtonCheckedSelected(e.Graphics, button, e.Ribbon);
            else if (button.Selected && !button.Checked)
              this.DrawButtonSelected(e.Graphics, button, e.Ribbon);
            else if (button.Checked)
              this.DrawButtonChecked(e.Graphics, button, e.Ribbon);
            else if (button is RibbonOrbOptionButton)
              this.DrawOrbOptionButton(e.Graphics, button.Bounds);
          }
          else
          {
            if (button.Style == RibbonButtonStyle.DropDownListItem)
            {
              using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.DropDownBg))
              {
                SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillRectangle((Brush) solidBrush, button.Bounds);
                e.Graphics.SmoothingMode = smoothingMode;
              }
            }
            if (button.DropDownPressed && button.SizeMode != RibbonElementSizeMode.DropDown)
            {
              this.DrawButtonPressed(e.Graphics, button, e.Ribbon);
              this.DrawSplitButtonDropDownSelected(e, button);
            }
            else if (button.Pressed && button.SizeMode != RibbonElementSizeMode.DropDown)
            {
              this.DrawButtonPressed(e.Graphics, button, e.Ribbon);
              this.DrawSplitButtonSelected(e, button);
            }
            else if (button.DropDownSelected)
            {
              this.DrawButtonSelected(e.Graphics, button, e.Ribbon);
              this.DrawSplitButtonDropDownSelected(e, button);
            }
            else if (button.Selected)
            {
              this.DrawButtonSelected(e.Graphics, button, e.Ribbon);
              this.DrawSplitButtonSelected(e, button);
            }
            else if (button.Checked)
              this.DrawButtonChecked(e.Graphics, button, e.Ribbon);
            else
              this.DrawSplitButton(e, button);
          }
        }
        if (button.Style == RibbonButtonStyle.Normal || button.Style == RibbonButtonStyle.DropDown && button.SizeMode == RibbonElementSizeMode.Large)
          return;
        if (button.Style == RibbonButtonStyle.DropDown)
          this.DrawButtonDropDownArrow(e.Graphics, button, button.OnGetDropDownBounds(button.SizeMode, button.Bounds));
        else
          this.DrawButtonDropDownArrow(e.Graphics, button, button.DropDownBounds);
      }
      else if (e.Item is RibbonItemGroup)
        this.DrawItemGroup(e, e.Item as RibbonItemGroup);
      else if (e.Item is RibbonButtonList)
        this.DrawButtonList(e.Graphics, e.Item as RibbonButtonList, e.Ribbon);
      else if (e.Item is RibbonSeparator)
      {
        if (!e.Item.Visible)
          return;
        this.DrawSeparator(e.Graphics, e.Item as RibbonSeparator, e.Ribbon);
      }
      else if (e.Item is RibbonUpDown)
      {
        RibbonUpDown b = e.Item as RibbonUpDown;
        if (b.Enabled)
        {
          if (b != null && (b.Selected || b.Editing))
            this.DrawTextBoxSelected(e.Graphics, b.TextBoxBounds);
          else
            this.DrawTextBoxUnselected(e.Graphics, b.TextBoxBounds);
        }
        else
          this.DrawTextBoxDisabled(e.Graphics, b.TextBoxBounds);
        this.DrawUpDownButtons(e.Graphics, b, e.Ribbon);
      }
      else if (e.Item is RibbonComboBox)
      {
        RibbonComboBox b = e.Item as RibbonComboBox;
        if (b.Enabled)
        {
          if (b != null && (b.Selected || b.DropDownVisible || b.Editing))
            this.DrawTextBoxSelected(e.Graphics, b.TextBoxBounds);
          else
            this.DrawTextBoxUnselected(e.Graphics, b.TextBoxBounds);
        }
        else
          this.DrawTextBoxDisabled(e.Graphics, b.TextBoxBounds);
        this.DrawComboBoxDropDown(e.Graphics, b, e.Ribbon);
      }
      else
      {
        if (!(e.Item is RibbonTextBox))
          return;
        RibbonTextBox ribbonTextBox = e.Item as RibbonTextBox;
        if (ribbonTextBox.Enabled)
        {
          if (ribbonTextBox != null && (ribbonTextBox.Selected || ribbonTextBox.Editing))
            this.DrawTextBoxSelected(e.Graphics, ribbonTextBox.TextBoxBounds);
          else
            this.DrawTextBoxUnselected(e.Graphics, ribbonTextBox.TextBoxBounds);
        }
        else
          this.DrawTextBoxDisabled(e.Graphics, ribbonTextBox.TextBoxBounds);
      }
    }

    public override void OnRenderRibbonItemBorder(RibbonItemRenderEventArgs e)
    {
      if (!(e.Item is RibbonItemGroup))
        return;
      this.DrawItemGroupBorder(e, e.Item as RibbonItemGroup);
    }

    public override void OnRenderRibbonItemText(RibbonTextEventArgs e)
    {
      Color color = e.Color;
      StringFormat format = e.Format;
      Font prototype = e.Ribbon.Font;
      bool flag = false;
      if (e.Item is RibbonButton)
      {
        RibbonButton button = e.Item as RibbonButton;
        if (button is RibbonCaptionButton)
        {
          if (WinApi.IsWindows)
            prototype = new Font("Marlett", prototype.Size);
          flag = true;
          color = this.ColorTable.Arrow;
        }
        if (button.Style == RibbonButtonStyle.DropDown && button.SizeMode == RibbonElementSizeMode.Large)
          this.DrawButtonDropDownArrow(e.Graphics, button, e.Bounds);
      }
      else if (e.Item is RibbonSeparator)
      {
        if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
          color = this.GetTextColor(e.Item.Enabled, this.ColorTable.Text);
        else if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2013)
          color = this.GetTextColor(e.Item.Enabled, this.ColorTable.RibbonItemText_2013);
      }
      if (flag || !e.Item.Enabled)
      {
        Rectangle bounds = e.Bounds;
        ++bounds.Y;
        using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.ArrowLight))
          e.Graphics.DrawString(e.Text, new Font(prototype, e.Style), (Brush) solidBrush, (RectangleF) bounds, format);
      }
      if (color.Equals((object) Color.Empty))
      {
        if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
          color = this.GetTextColor(e.Item.Enabled, this.ColorTable.Text);
        else if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2013)
          color = this.GetTextColor(e.Item.Enabled, this.ColorTable.RibbonItemText_2013);
      }
      using (SolidBrush solidBrush = new SolidBrush(color))
        e.Graphics.DrawString(e.Text, new Font(prototype, e.Style), (Brush) solidBrush, (RectangleF) e.Bounds, format);
    }

    public override void OnRenderRibbonItemImage(RibbonItemBoundsEventArgs e)
    {
      Image image = e.Item.ShowFlashImage ? e.Item.FlashImage : e.Item.Image;
      if (e.Item is RibbonButton)
      {
        if (e.Item.SizeMode != RibbonElementSizeMode.Large && e.Item.SizeMode != RibbonElementSizeMode.Overflow)
          image = e.Item.ShowFlashImage ? (e.Item as RibbonButton).FlashSmallImage : (e.Item as RibbonButton).SmallImage;
        if (e.Item.SizeMode == RibbonElementSizeMode.DropDown && e.Item.Checked)
        {
          using (Pen pen = new Pen(this.ColorTable.DropDownCheckedButtonGlyphBorder))
          {
            using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.DropDownCheckedButtonGlyphBg))
            {
              Rectangle bounds1 = e.Bounds;
              int left = bounds1.Left - 2;
              bounds1 = e.Bounds;
              int top1 = bounds1.Top - 2;
              bounds1 = e.Bounds;
              int right = bounds1.Right + 1;
              bounds1 = e.Bounds;
              int bottom = bounds1.Bottom + 1;
              using (GraphicsPath path = RibbonProfessionalRenderer.RoundRectangle(Rectangle.FromLTRB(left, top1, right, bottom), 3, RibbonProfessionalRenderer.Corners.All))
              {
                SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(pen, path);
                e.Graphics.FillPath((Brush) solidBrush, path);
                e.Graphics.SmoothingMode = smoothingMode;
              }
              if (image != null)
              {
                Rectangle rectangle = new Rectangle();
                ref Rectangle local = ref rectangle;
                Rectangle bounds2 = e.Bounds;
                int x = bounds2.Left + 1;
                bounds2 = e.Bounds;
                int top2 = bounds2.Top;
                bounds2 = e.Bounds;
                int width = bounds2.Width;
                bounds2 = e.Bounds;
                int height = bounds2.Height;
                local = new Rectangle(x, top2, width, height);
                ControlPaint.DrawMenuGlyph(e.Graphics, rectangle, MenuGlyph.Checkmark, pen.Color, Color.Transparent);
              }
            }
          }
        }
      }
      if (image == null)
        return;
      if (!e.Item.Enabled)
        image = RibbonRenderer.CreateDisabledImage(image);
      e.Graphics.DrawImage(image, e.Bounds);
    }

    public override void OnRenderPanelPopupBackground(RibbonCanvasEventArgs e)
    {
      if (!(e.RelatedObject is RibbonPanel relatedObject))
        return;
      Rectangle rectangle = e.Bounds;
      int left1 = rectangle.Left;
      rectangle = e.Bounds;
      int top1 = rectangle.Top;
      rectangle = e.Bounds;
      int right1 = rectangle.Right;
      rectangle = e.Bounds;
      int bottom1 = rectangle.Bottom;
      Rectangle r1 = Rectangle.FromLTRB(left1, top1, right1, bottom1);
      rectangle = e.Bounds;
      int left2 = rectangle.Left + 1;
      rectangle = e.Bounds;
      int top2 = rectangle.Top + 1;
      rectangle = e.Bounds;
      int right2 = rectangle.Right - 1;
      rectangle = e.Bounds;
      int bottom2 = rectangle.Bottom - 1;
      Rectangle r2 = Rectangle.FromLTRB(left2, top2, right2, bottom2);
      rectangle = e.Bounds;
      int left3 = rectangle.Left + 1;
      rectangle = relatedObject.ContentBounds;
      int bottom3 = rectangle.Bottom;
      rectangle = e.Bounds;
      int right3 = rectangle.Right - 1;
      rectangle = e.Bounds;
      int bottom4 = rectangle.Bottom - 1;
      Rectangle r3 = Rectangle.FromLTRB(left3, bottom3, right3, bottom4);
      GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(r1, 3);
      GraphicsPath path2 = RibbonProfessionalRenderer.RoundRectangle(r2, 3);
      GraphicsPath path3 = RibbonProfessionalRenderer.RoundRectangle(r3, 3, RibbonProfessionalRenderer.Corners.South);
      using (Pen pen = new Pen(this.ColorTable.PanelLightBorder))
        e.Graphics.DrawPath(pen, path2);
      using (Pen pen = new Pen(this.ColorTable.PanelDarkBorder))
        e.Graphics.DrawPath(pen, path1);
      using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.PanelBackgroundSelected))
        e.Graphics.FillPath((Brush) solidBrush, path2);
      if (this._ownerRibbon.OrbStyle == RibbonOrbStyle.Office_2007)
      {
        using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.PanelTextBackground))
          e.Graphics.FillPath((Brush) solidBrush, path3);
      }
      path3.Dispose();
      path1.Dispose();
      path2.Dispose();
    }

    public override void OnRenderDropDownBackground(RibbonCanvasEventArgs e)
    {
      Rectangle rect1 = new Rectangle();
      ref Rectangle local = ref rect1;
      Rectangle bounds = e.Bounds;
      int width = bounds.Width - 1;
      bounds = e.Bounds;
      int height = bounds.Height - 1;
      local = new Rectangle(0, 0, width, height);
      RibbonDropDown canvas = e.Canvas as RibbonDropDown;
      using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.DropDownBg))
      {
        e.Graphics.Clear(Color.Transparent);
        SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.FillRectangle((Brush) solidBrush, rect1);
        e.Graphics.SmoothingMode = smoothingMode;
      }
      using (Pen pen = new Pen(this.ColorTable.DropDownBorder))
      {
        if (canvas != null)
        {
          using (GraphicsPath path = RibbonProfessionalRenderer.RoundRectangle(new Rectangle(Point.Empty, new Size(canvas.Size.Width - 1, canvas.Size.Height - 1)), canvas.BorderRoundness))
          {
            SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawPath(pen, path);
            e.Graphics.SmoothingMode = smoothingMode;
          }
        }
        else
          e.Graphics.DrawRectangle(pen, rect1);
      }
      if (!canvas.ShowSizingGrip)
        return;
      Rectangle rect2 = Rectangle.FromLTRB(e.Bounds.Left + 1, e.Bounds.Bottom - canvas.SizingGripHeight, e.Bounds.Right - 1, e.Bounds.Bottom - 1);
      if (rect2.Height <= 0 || rect2.Width <= 0)
        return;
      using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect2, this.ColorTable.DropDownGripNorth, this.ColorTable.DropDownGripSouth, 90f))
        e.Graphics.FillRectangle((Brush) linearGradientBrush, rect2);
      using (Pen pen = new Pen(this.ColorTable.DropDownGripBorder))
        e.Graphics.DrawLine(pen, rect2.Location, new Point(rect2.Right - 1, rect2.Top));
      this.DrawGripDot(e.Graphics, new Point(rect2.Right - 7, rect2.Bottom - 3));
      this.DrawGripDot(e.Graphics, new Point(rect2.Right - 3, rect2.Bottom - 7));
      this.DrawGripDot(e.Graphics, new Point(rect2.Right - 3, rect2.Bottom - 3));
    }

    public override void OnRenderDropDownDropDownImageSeparator(
      RibbonItem item,
      RibbonCanvasEventArgs e)
    {
      if (!(e.Canvas is RibbonDropDown canvas) || !canvas.DrawIconsBar)
        return;
      Rectangle rect = new Rectangle();
      ref Rectangle local = ref rect;
      int left = item.Bounds.Left;
      Rectangle bounds = item.Bounds;
      int top = bounds.Top;
      bounds = item.Bounds;
      int height = bounds.Height;
      local = new Rectangle(left, top, 26, height);
      using (new Pen(this.ColorTable.DropDownImageBg))
      {
        using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.DropDownImageBg))
        {
          SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
          e.Graphics.SmoothingMode = SmoothingMode.None;
          e.Graphics.FillRectangle((Brush) solidBrush, rect);
          e.Graphics.SmoothingMode = smoothingMode;
        }
      }
      using (Pen pen = new Pen(this.ColorTable.DropDownImageSeparator))
      {
        SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
        e.Graphics.SmoothingMode = SmoothingMode.None;
        e.Graphics.DrawLine(pen, new Point(rect.Right, rect.Top), new Point(rect.Right, rect.Bottom - 1));
        e.Graphics.SmoothingMode = smoothingMode;
      }
    }

    public override void OnRenderTabScrollButtons(RibbonTabRenderEventArgs e)
    {
      if (e.Tab.ScrollLeftVisible)
      {
        if (e.Tab.ScrollLeftSelected)
          this.DrawButtonSelected(e.Graphics, e.Tab.ScrollLeftBounds, RibbonProfessionalRenderer.Corners.West, e.Ribbon);
        else
          this.DrawButton(e.Graphics, e.Tab.ScrollLeftBounds, RibbonProfessionalRenderer.Corners.West);
        this.DrawArrowShaded(e.Graphics, e.Tab.ScrollLeftBounds, RibbonArrowDirection.Right, true);
      }
      if (!e.Tab.ScrollRightVisible)
        return;
      if (e.Tab.ScrollRightSelected)
        this.DrawButtonSelected(e.Graphics, e.Tab.ScrollRightBounds, RibbonProfessionalRenderer.Corners.East, e.Ribbon);
      else
        this.DrawButton(e.Graphics, e.Tab.ScrollRightBounds, RibbonProfessionalRenderer.Corners.East);
      this.DrawArrowShaded(e.Graphics, e.Tab.ScrollRightBounds, RibbonArrowDirection.Left, true);
    }

    public override void OnRenderScrollbar(Graphics g, Control ctl, Ribbon ribbon)
    {
      RibbonDropDown ribbonDropDown = (RibbonDropDown) ctl;
      if (ScrollBarRenderer.IsSupported)
      {
        ScrollBarRenderer.DrawUpperVerticalTrack(g, ribbonDropDown.ScrollBarBounds, ScrollBarState.Normal);
        if (ribbonDropDown.ThumbPressed)
        {
          ScrollBarRenderer.DrawVerticalThumb(g, ribbonDropDown.ThumbBounds, ScrollBarState.Pressed);
          ScrollBarRenderer.DrawVerticalThumbGrip(g, ribbonDropDown.ThumbBounds, ScrollBarState.Pressed);
        }
        else if (ribbonDropDown.ThumbSelected)
        {
          ScrollBarRenderer.DrawVerticalThumb(g, ribbonDropDown.ThumbBounds, ScrollBarState.Hot);
          ScrollBarRenderer.DrawVerticalThumbGrip(g, ribbonDropDown.ThumbBounds, ScrollBarState.Hot);
        }
        else
        {
          ScrollBarRenderer.DrawVerticalThumb(g, ribbonDropDown.ThumbBounds, ScrollBarState.Normal);
          ScrollBarRenderer.DrawVerticalThumbGrip(g, ribbonDropDown.ThumbBounds, ScrollBarState.Normal);
        }
        if (ribbonDropDown.ButtonUpPressed)
          ScrollBarRenderer.DrawArrowButton(g, ribbonDropDown.ButtonUpBounds, ScrollBarArrowButtonState.UpPressed);
        else if (ribbonDropDown.ButtonUpSelected)
          ScrollBarRenderer.DrawArrowButton(g, ribbonDropDown.ButtonUpBounds, ScrollBarArrowButtonState.UpHot);
        else
          ScrollBarRenderer.DrawArrowButton(g, ribbonDropDown.ButtonUpBounds, ScrollBarArrowButtonState.UpNormal);
        if (ribbonDropDown.ButtonDownPressed)
          ScrollBarRenderer.DrawArrowButton(g, ribbonDropDown.ButtonDownBounds, ScrollBarArrowButtonState.DownPressed);
        else if (ribbonDropDown.ButtonDownSelected)
          ScrollBarRenderer.DrawArrowButton(g, ribbonDropDown.ButtonDownBounds, ScrollBarArrowButtonState.DownHot);
        else
          ScrollBarRenderer.DrawArrowButton(g, ribbonDropDown.ButtonDownBounds, ScrollBarArrowButtonState.DownNormal);
      }
      else
      {
        using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.ButtonGlossyNorth))
          g.FillRectangle((Brush) solidBrush, ribbonDropDown.ScrollBarBounds);
        if (!ribbonDropDown.ButtonDownEnabled)
          this.DrawButtonDisabled(g, ribbonDropDown.ButtonDownBounds, RibbonProfessionalRenderer.Corners.SouthEast);
        else if (ribbonDropDown.ButtonDownPressed)
          this.DrawButtonPressed(g, ribbonDropDown.ButtonDownBounds, RibbonProfessionalRenderer.Corners.SouthEast, ribbon);
        else if (ribbonDropDown.ButtonDownSelected)
          this.DrawButtonSelected(g, ribbonDropDown.ButtonDownBounds, RibbonProfessionalRenderer.Corners.SouthEast, ribbon);
        else
          this.DrawButton(g, ribbonDropDown.ButtonDownBounds, RibbonProfessionalRenderer.Corners.None);
        if (!ribbonDropDown.ButtonUpEnabled)
          this.DrawButtonDisabled(g, ribbonDropDown.ButtonUpBounds, RibbonProfessionalRenderer.Corners.NorthEast);
        else if (ribbonDropDown.ButtonUpPressed)
          this.DrawButtonPressed(g, ribbonDropDown.ButtonUpBounds, RibbonProfessionalRenderer.Corners.NorthEast, ribbon);
        else if (ribbonDropDown.ButtonUpSelected)
          this.DrawButtonSelected(g, ribbonDropDown.ButtonUpBounds, RibbonProfessionalRenderer.Corners.NorthEast, ribbon);
        else
          this.DrawButton(g, ribbonDropDown.ButtonUpBounds, RibbonProfessionalRenderer.Corners.NorthEast);
        if (ribbonDropDown.ScrollBarEnabled)
        {
          if (ribbonDropDown.ThumbPressed)
            this.DrawButtonPressed(g, ribbonDropDown.ThumbBounds, RibbonProfessionalRenderer.Corners.All, ribbon);
          else if (ribbonDropDown.ThumbSelected)
            this.DrawButtonSelected(g, ribbonDropDown.ThumbBounds, RibbonProfessionalRenderer.Corners.All, ribbon);
          else
            this.DrawButton(g, ribbonDropDown.ThumbBounds, RibbonProfessionalRenderer.Corners.All);
        }
        Color arrow = this.ColorTable.Arrow;
        Color arrowLight = this.ColorTable.ArrowLight;
        Color arrowDisabled = this.ColorTable.ArrowDisabled;
        Rectangle b1 = this.CenterOn(ribbonDropDown.ButtonUpBounds, new Rectangle(Point.Empty, this.arrowSize));
        b1.Offset(0, 1);
        Rectangle b2 = this.CenterOn(ribbonDropDown.ButtonDownBounds, new Rectangle(Point.Empty, this.arrowSize));
        b2.Offset(0, 1);
        this.DrawArrow(g, b1, ribbonDropDown.ButtonUpEnabled ? arrowLight : Color.Transparent, RibbonArrowDirection.Up);
        b1.Offset(0, -1);
        this.DrawArrow(g, b1, ribbonDropDown.ButtonUpEnabled ? arrow : arrowDisabled, RibbonArrowDirection.Up);
        this.DrawArrow(g, b2, ribbonDropDown.ButtonDownEnabled ? arrowLight : Color.Transparent, RibbonArrowDirection.Down);
        b2.Offset(0, -1);
        this.DrawArrow(g, b2, ribbonDropDown.ButtonDownEnabled ? arrow : arrowDisabled, RibbonArrowDirection.Down);
      }
    }

    public override void OnRenderToolTipBackground(RibbonToolTipRenderEventArgs e)
    {
      Rectangle clipRectangle1 = e.ClipRectangle;
      int left1 = clipRectangle1.Left;
      clipRectangle1 = e.ClipRectangle;
      int top1 = clipRectangle1.Top;
      clipRectangle1 = e.ClipRectangle;
      int right1 = clipRectangle1.Right - 1;
      clipRectangle1 = e.ClipRectangle;
      int bottom1 = clipRectangle1.Bottom - 1;
      Rectangle r1 = Rectangle.FromLTRB(left1, top1, right1, bottom1);
      Rectangle clipRectangle2 = e.ClipRectangle;
      int left2 = clipRectangle2.Left + 1;
      clipRectangle2 = e.ClipRectangle;
      int top2 = clipRectangle2.Top + 1;
      clipRectangle2 = e.ClipRectangle;
      int right2 = clipRectangle2.Right - 2;
      clipRectangle2 = e.ClipRectangle;
      int bottom2 = clipRectangle2.Bottom - 1;
      Rectangle r2 = Rectangle.FromLTRB(left2, top2, right2, bottom2);
      GraphicsPath path1 = RibbonProfessionalRenderer.RoundRectangle(r1, 3);
      GraphicsPath path2 = RibbonProfessionalRenderer.RoundRectangle(r2, 3);
      Rectangle clipRectangle3 = e.ClipRectangle;
      clipRectangle3.Offset(2, 1);
      using (GraphicsPath path3 = RibbonProfessionalRenderer.RoundRectangle(clipRectangle3, 3, RibbonProfessionalRenderer.Corners.All))
      {
        using (PathGradientBrush pathGradientBrush = new PathGradientBrush(path3))
        {
          pathGradientBrush.WrapMode = WrapMode.Clamp;
          ColorBlend colorBlend = new ColorBlend(3)
          {
            Colors = new Color[3]
            {
              Color.Transparent,
              Color.FromArgb(50, Color.Black),
              Color.FromArgb(100, Color.Black)
            },
            Positions = new float[3]{ 0.0f, 0.1f, 1f }
          };
          pathGradientBrush.InterpolationColors = colorBlend;
          e.Graphics.FillPath((Brush) pathGradientBrush, path3);
        }
      }
      using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(e.ClipRectangle, this.ColorTable.ToolTipContentNorth, this.ColorTable.ToolTipContentSouth, 90f))
        e.Graphics.FillPath((Brush) linearGradientBrush, path1);
      using (Pen pen = new Pen(this.ColorTable.ToolTipLightBorder))
        e.Graphics.DrawPath(pen, path2);
      using (Pen pen = new Pen(this.ColorTable.ToolTipDarkBorder))
        e.Graphics.DrawPath(pen, path1);
      path1.Dispose();
      path2.Dispose();
    }

    public override void OnRenderToolTipText(RibbonToolTipRenderEventArgs e)
    {
      if (e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2007 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010 || e.Ribbon.OrbStyle == RibbonOrbStyle.Office_2010_Extended)
      {
        using (Brush brush = (Brush) new SolidBrush(this.ColorTable.ToolTipText))
        {
          e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
          e.Graphics.DrawString(e.Text, e.Font, brush, (RectangleF) e.ClipRectangle, e.Format);
        }
      }
      else
      {
        if (e.Ribbon.OrbStyle != RibbonOrbStyle.Office_2013)
          return;
        using (Brush brush = (Brush) new SolidBrush(this.ColorTable.ToolTipText_2013))
        {
          e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
          e.Graphics.DrawString(e.Text, e.Font, brush, (RectangleF) e.ClipRectangle, e.Format);
        }
      }
    }

    public override void OnRenderToolTipImage(RibbonToolTipRenderEventArgs e) => e.Graphics.DrawImage(e.TipImage, e.ClipRectangle);

    public enum Corners
    {
      None = 0,
      NorthWest = 2,
      NorthEast = 4,
      North = 6,
      SouthEast = 8,
      East = 12, // 0x0000000C
      SouthWest = 16, // 0x00000010
      West = 18, // 0x00000012
      South = 24, // 0x00000018
      All = 30, // 0x0000001E
    }
  }
}
