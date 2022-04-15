// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonOrbDropDown
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace System.Windows.Forms
{
  public class RibbonOrbDropDown : RibbonPopup
  {
    private const bool DefaultAutoSizeContentButtons = true;
    private const int DefaultContentButtonsMinWidth = 150;
    private const int DefaultContentRecentItemsMinWidth = 150;
    internal RibbonOrbMenuItem LastPoppedMenuItem;
    private Rectangle designerSelectedBounds;
    private readonly int glyphGap = 3;
    private Padding _contentMargin;
    private DateTime OpenedTime;
    private string _recentItemsCaption;
    private int _contentButtonsWidth = 150;

    internal RibbonOrbDropDown(Ribbon ribbon)
    {
      this.DoubleBuffered = true;
      this.Ribbon = ribbon;
      this.MenuItems = new RibbonOrbMenuItemCollection();
      this.RecentItems = new RibbonOrbRecentItemCollection();
      this.OptionItems = new RibbonOrbOptionButtonCollection();
      this.MenuItems.SetOwner(this.Ribbon);
      this.RecentItems.SetOwner(this.Ribbon);
      this.OptionItems.SetOwner(this.Ribbon);
      this.OptionItemsPadding = 6;
      this.Size = new Size(527, 447);
      this.BorderRoundness = 8;
    }

    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
      if (this.Sensor == null || this.Sensor.Disposed)
        return;
      this.Sensor.Dispose();
    }

    internal List<RibbonItem> AllItems
    {
      get
      {
        List<RibbonItem> ribbonItemList = new List<RibbonItem>();
        ribbonItemList.AddRange((IEnumerable<RibbonItem>) this.MenuItems);
        ribbonItemList.AddRange((IEnumerable<RibbonItem>) this.RecentItems);
        ribbonItemList.AddRange((IEnumerable<RibbonItem>) this.OptionItems);
        return ribbonItemList;
      }
    }

    [Browsable(false)]
    public Padding ContentMargin
    {
      get
      {
        if (this._contentMargin.Size.IsEmpty)
          this._contentMargin = new Padding(6, 17, 6, 29);
        return this._contentMargin;
      }
    }

    [Browsable(false)]
    public Rectangle ContentBounds
    {
      get
      {
        Padding contentMargin = this.ContentMargin;
        int left = contentMargin.Left;
        contentMargin = this.ContentMargin;
        int top = contentMargin.Top;
        Rectangle clientRectangle = this.ClientRectangle;
        int right1 = clientRectangle.Right;
        contentMargin = this.ContentMargin;
        int right2 = contentMargin.Right;
        int right3 = right1 - right2;
        clientRectangle = this.ClientRectangle;
        int bottom1 = clientRectangle.Bottom;
        contentMargin = this.ContentMargin;
        int bottom2 = contentMargin.Bottom;
        int bottom3 = bottom1 - bottom2;
        return Rectangle.FromLTRB(left, top, right3, bottom3);
      }
    }

    [Browsable(false)]
    public Rectangle ContentButtonsBounds
    {
      get
      {
        Rectangle contentBounds = this.ContentBounds;
        contentBounds.Width = this._contentButtonsWidth;
        if (this.Ribbon.RightToLeft == RightToLeft.Yes)
          contentBounds.X = this.ContentBounds.Right - this._contentButtonsWidth;
        return contentBounds;
      }
    }

    [DefaultValue(150)]
    public int ContentButtonsMinWidth { get; set; } = 150;

    [Browsable(false)]
    public Rectangle ContentRecentItemsBounds
    {
      get
      {
        Rectangle contentBounds = this.ContentBounds;
        contentBounds.Width -= this._contentButtonsWidth;
        contentBounds.Height -= this.ContentRecentItemsCaptionBounds.Height;
        contentBounds.Y += this.ContentRecentItemsCaptionBounds.Height;
        if (this.Ribbon.RightToLeft == RightToLeft.No)
          contentBounds.X += this._contentButtonsWidth;
        return contentBounds;
      }
    }

    [Browsable(false)]
    public Rectangle ContentRecentItemsCaptionBounds
    {
      get
      {
        if (this.RecentItemsCaption == null)
          return Rectangle.Empty;
        SizeF sizeF;
        using (Graphics graphics = this.CreateGraphics())
          sizeF = graphics.MeasureString(this.RecentItemsCaption, this.Ribbon.RibbonTabFont);
        Rectangle contentBounds = this.ContentBounds;
        contentBounds.Width -= this._contentButtonsWidth;
        ref Rectangle local = ref contentBounds;
        int int32 = Convert.ToInt32(sizeF.Height);
        Padding itemMargin = this.Ribbon.ItemMargin;
        int top = itemMargin.Top;
        int num1 = int32 + top;
        itemMargin = this.Ribbon.ItemMargin;
        int bottom = itemMargin.Bottom;
        int num2 = num1 + bottom;
        local.Height = num2;
        contentBounds.Height += this.RecentItemsCaptionLineSpacing;
        if (this.Ribbon.RightToLeft == RightToLeft.No)
          contentBounds.X += this._contentButtonsWidth;
        return contentBounds;
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int RecentItemsCaptionLineSpacing { get; } = 8;

    [DefaultValue(150)]
    public int ContentRecentItemsMinWidth { get; set; } = 150;

    private bool RibbonInDesignMode => RibbonDesigner.Current != null;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public RibbonOrbMenuItemCollection MenuItems { get; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public RibbonOrbOptionButtonCollection OptionItems { get; }

    [DefaultValue(6)]
    [Description("Spacing between option buttons (those on the bottom)")]
    public int OptionItemsPadding { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public RibbonOrbRecentItemCollection RecentItems { get; }

    [DefaultValue(null)]
    public string RecentItemsCaption
    {
      get => this._recentItemsCaption;
      set
      {
        this._recentItemsCaption = value;
        this.Invalidate();
      }
    }

    [Browsable(false)]
    public Ribbon Ribbon { get; }

    [Browsable(false)]
    public RibbonMouseSensor Sensor { get; private set; }

    internal Rectangle ButtonsGlyphBounds
    {
      get
      {
        Size size = new Size(50, 18);
        Rectangle contentButtonsBounds = this.ContentButtonsBounds;
        Rectangle rectangle = new Rectangle(contentButtonsBounds.Left + (contentButtonsBounds.Width - size.Width * 2) / 2, contentButtonsBounds.Top + this.glyphGap, size.Width, size.Height);
        if (this.MenuItems.Count > 0)
          rectangle.Y = this.MenuItems[this.MenuItems.Count - 1].Bounds.Bottom + this.glyphGap;
        return rectangle;
      }
    }

    internal Rectangle ButtonsSeparatorGlyphBounds
    {
      get
      {
        Size size = new Size(18, 18);
        Rectangle buttonsGlyphBounds = this.ButtonsGlyphBounds;
        buttonsGlyphBounds.X = buttonsGlyphBounds.Right + this.glyphGap;
        return buttonsGlyphBounds;
      }
    }

    internal Rectangle RecentGlyphBounds
    {
      get
      {
        Size size = new Size(50, 18);
        Rectangle recentItemsBounds = this.ContentRecentItemsBounds;
        Rectangle rectangle = new Rectangle(recentItemsBounds.Left + this.glyphGap, recentItemsBounds.Top + this.glyphGap, size.Width, size.Height);
        if (this.RecentItems.Count > 0)
          rectangle.Y = this.RecentItems[this.RecentItems.Count - 1].Bounds.Bottom + this.glyphGap;
        return rectangle;
      }
    }

    internal Rectangle OptionGlyphBounds
    {
      get
      {
        Size size = new Size(50, 18);
        Rectangle contentBounds = this.ContentBounds;
        Rectangle rectangle = new Rectangle(contentBounds.Right - size.Width, contentBounds.Bottom + this.glyphGap, size.Width, size.Height);
        if (this.OptionItems.Count > 0)
          rectangle.X = this.OptionItems[this.OptionItems.Count - 1].Bounds.Left - size.Width - this.glyphGap;
        return rectangle;
      }
    }

    [DefaultValue(true)]
    public bool AutoSizeContentButtons { get; set; } = true;

    internal void HandleDesignerItemRemoved(RibbonItem item)
    {
      if (this.MenuItems.Contains(item))
        this.MenuItems.Remove(item);
      else if (this.RecentItems.Contains(item))
        this.RecentItems.Remove(item);
      else if (this.OptionItems.Contains(item))
        this.OptionItems.Remove(item);
      this.OnRegionsChanged();
    }

    private int SeparatorHeight(RibbonSeparator s) => !string.IsNullOrEmpty(s.Text) ? 20 : 3;

    private void UpdateRegions()
    {
      int height1 = 44;
      int height2 = 22;
      int num1 = 1;
      int num2 = 1;
      if (this.AutoSizeContentButtons)
      {
        int val1 = 0;
        using (Graphics graphics = this.CreateGraphics())
        {
          foreach (RibbonItem menuItem in (List<RibbonItem>) this.MenuItems)
          {
            int width = menuItem.MeasureSize((object) this, new RibbonElementMeasureSizeEventArgs(graphics, RibbonElementSizeMode.DropDown)).Width;
            if (width > val1)
              val1 = width;
          }
        }
        this._contentButtonsWidth = Math.Max(Math.Min(val1, this.ContentBounds.Width - this.ContentRecentItemsMinWidth), this.ContentButtonsMinWidth);
      }
      Rectangle contentBounds1 = this.ContentBounds;
      Rectangle contentButtonsBounds = this.ContentButtonsBounds;
      Rectangle recentItemsBounds = this.ContentRecentItemsBounds;
      foreach (RibbonItem allItem in this.AllItems)
      {
        allItem.SetSizeMode(RibbonElementSizeMode.DropDown);
        allItem.SetCanvas((Control) this);
      }
      int y1 = contentBounds1.Top + 1;
      foreach (RibbonItem menuItem in (List<RibbonItem>) this.MenuItems)
      {
        Rectangle bounds = new Rectangle(contentButtonsBounds.Left + num1, y1, contentButtonsBounds.Width - num1 * 2, height1);
        if (menuItem is RibbonSeparator)
          bounds.Height = this.SeparatorHeight(menuItem as RibbonSeparator);
        menuItem.SetBounds(bounds);
        y1 += bounds.Height;
      }
      int val1_1 = y1 - contentBounds1.Top + 1;
      int top = recentItemsBounds.Top;
      foreach (RibbonItem recentItem in (List<RibbonItem>) this.RecentItems)
      {
        Rectangle bounds = new Rectangle(recentItemsBounds.Left + num2, top, recentItemsBounds.Width - num2 * 2, height2);
        if (recentItem is RibbonSeparator)
          bounds.Height = this.SeparatorHeight(recentItem as RibbonSeparator);
        recentItem.SetBounds(bounds);
        top += bounds.Height;
      }
      int val2 = top - contentButtonsBounds.Top;
      int num3 = Math.Max(val1_1, val2);
      if (RibbonDesigner.Current != null)
        num3 += this.ButtonsGlyphBounds.Height + this.glyphGap * 2;
      int num4 = num3;
      Padding contentMargin = this.ContentMargin;
      int vertical = contentMargin.Vertical;
      this.Height = num4 + vertical;
      Rectangle contentBounds2 = this.ContentBounds;
      int width1 = this.ClientSize.Width;
      contentMargin = this.ContentMargin;
      int right = contentMargin.Right;
      int num5 = width1 - right;
      using (Graphics graphics = this.CreateGraphics())
      {
        foreach (RibbonItem optionItem in (List<RibbonItem>) this.OptionItems)
        {
          Size size = optionItem.MeasureSize((object) this, new RibbonElementMeasureSizeEventArgs(graphics, RibbonElementSizeMode.DropDown));
          int bottom = contentBounds2.Bottom;
          contentMargin = this.ContentMargin;
          int num6 = (contentMargin.Bottom - size.Height) / 2;
          int y2 = bottom + num6;
          optionItem.SetBounds(new Rectangle(new Point(num5 - size.Width, y2), size));
          num5 = optionItem.Bounds.Left - this.OptionItemsPadding;
        }
      }
    }

    private void UpdateSensor()
    {
      if (this.Sensor != null && !this.Sensor.Disposed)
        this.Sensor.Dispose();
      this.Sensor = new RibbonMouseSensor((Control) this, this.Ribbon, (IEnumerable<RibbonItem>) this.AllItems);
    }

    internal void OnRegionsChanged()
    {
      this.UpdateRegions();
      this.UpdateSensor();
      this.UpdateDesignerSelectedBounds();
      this.Invalidate();
    }

    internal void SelectOnDesigner(RibbonItem item)
    {
      if (RibbonDesigner.Current == null)
        return;
      RibbonDesigner.Current.SelectedElement = (IRibbonElement) item;
      this.UpdateDesignerSelectedBounds();
      this.Invalidate();
    }

    internal void UpdateDesignerSelectedBounds()
    {
      this.designerSelectedBounds = Rectangle.Empty;
      if (!this.RibbonInDesignMode || !(RibbonDesigner.Current.SelectedElement is RibbonItem selectedElement) || !this.AllItems.Contains(selectedElement))
        return;
      this.designerSelectedBounds = selectedElement.Bounds;
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      if (!this.RibbonInDesignMode)
        return;
      if (this.ContentBounds.Contains(e.Location))
      {
        if (this.ContentButtonsBounds.Contains(e.Location))
        {
          foreach (RibbonItem menuItem in (List<RibbonItem>) this.MenuItems)
          {
            if (menuItem.Bounds.Contains(e.Location))
            {
              this.SelectOnDesigner(menuItem);
              break;
            }
          }
        }
        else if (this.ContentRecentItemsBounds.Contains(e.Location))
        {
          foreach (RibbonItem recentItem in (List<RibbonItem>) this.RecentItems)
          {
            if (recentItem.Bounds.Contains(e.Location))
            {
              this.SelectOnDesigner(recentItem);
              break;
            }
          }
        }
      }
      if (this.ButtonsGlyphBounds.Contains(e.Location))
        RibbonDesigner.Current.CreateOrbMenuItem(typeof (RibbonOrbMenuItem));
      else if (this.ButtonsSeparatorGlyphBounds.Contains(e.Location))
        RibbonDesigner.Current.CreateOrbMenuItem(typeof (RibbonSeparator));
      else if (this.RecentGlyphBounds.Contains(e.Location))
        RibbonDesigner.Current.CreateOrbRecentItem(typeof (RibbonOrbRecentItem));
      else if (this.OptionGlyphBounds.Contains(e.Location))
      {
        RibbonDesigner.Current.CreateOrbOptionItem(typeof (RibbonOrbOptionButton));
      }
      else
      {
        foreach (RibbonItem optionItem in (List<RibbonItem>) this.OptionItems)
        {
          if (optionItem.Bounds.Contains(e.Location))
          {
            this.SelectOnDesigner(optionItem);
            break;
          }
        }
      }
    }

    protected override void OnOpening(CancelEventArgs e)
    {
      base.OnOpening(e);
      this.UpdateRegions();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      this.Ribbon.Renderer.OnRenderOrbDropDownBackground(new RibbonOrbDropDownEventArgs(this.Ribbon, this, e.Graphics, e.ClipRectangle));
      foreach (RibbonItem allItem in this.AllItems)
        allItem.OnPaint((object) this, new RibbonElementPaintEventArgs(e.ClipRectangle, e.Graphics, RibbonElementSizeMode.DropDown));
      if (!this.RibbonInDesignMode)
        return;
      using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(50, Color.Blue)))
      {
        e.Graphics.FillRectangle((Brush) solidBrush, this.ButtonsGlyphBounds);
        e.Graphics.FillRectangle((Brush) solidBrush, this.RecentGlyphBounds);
        e.Graphics.FillRectangle((Brush) solidBrush, this.OptionGlyphBounds);
        e.Graphics.FillRectangle((Brush) solidBrush, this.ButtonsSeparatorGlyphBounds);
      }
      using (StringFormat format = StringFormatFactory.Center(StringTrimming.None))
      {
        e.Graphics.DrawString("+", this.Font, Brushes.White, (RectangleF) this.ButtonsGlyphBounds, format);
        e.Graphics.DrawString("+", this.Font, Brushes.White, (RectangleF) this.RecentGlyphBounds, format);
        e.Graphics.DrawString("+", this.Font, Brushes.White, (RectangleF) this.OptionGlyphBounds, format);
        e.Graphics.DrawString("---", this.Font, Brushes.White, (RectangleF) this.ButtonsSeparatorGlyphBounds, format);
      }
      using (Pen pen = new Pen(Color.Black))
      {
        pen.DashStyle = DashStyle.Dot;
        e.Graphics.DrawRectangle(pen, this.designerSelectedBounds);
      }
    }

    protected override void OnClosed(EventArgs e)
    {
      this.Ribbon.OrbPressed = false;
      this.Ribbon.OrbSelected = false;
      this.LastPoppedMenuItem = (RibbonOrbMenuItem) null;
      foreach (RibbonItem allItem in this.AllItems)
      {
        allItem.SetSelected(false);
        allItem.SetPressed(false);
      }
      base.OnClosed(e);
    }

    protected override void OnShowed(EventArgs e)
    {
      base.OnShowed(e);
      this.OpenedTime = DateTime.Now;
      this.UpdateSensor();
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
      if (this.Ribbon.RectangleToScreen(this.Ribbon.OrbBounds).Contains(this.PointToScreen(e.Location)))
      {
        this.Ribbon.OnOrbClicked(EventArgs.Empty);
        if (DateTime.Compare(DateTime.Now, this.OpenedTime.AddMilliseconds((double) SystemInformation.DoubleClickTime)) < 0)
          this.Ribbon.OnOrbDoubleClicked(EventArgs.Empty);
      }
      base.OnMouseClick(e);
    }

    protected override void OnMouseDoubleClick(MouseEventArgs e)
    {
      base.OnMouseDoubleClick(e);
      if (!this.Ribbon.RectangleToScreen(this.Ribbon.OrbBounds).Contains(this.PointToScreen(e.Location)))
        return;
      this.Ribbon.OnOrbDoubleClicked(EventArgs.Empty);
    }

    private void _keyboardHook_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Down)
      {
        RibbonItem ribbonItem1 = (RibbonItem) null;
        RibbonItem ribbonItem2 = (RibbonItem) null;
        foreach (RibbonItem menuItem in (List<RibbonItem>) this.MenuItems)
        {
          if (menuItem.Selected)
          {
            ribbonItem2 = menuItem;
            break;
          }
        }
        if (ribbonItem2 != null)
        {
          ribbonItem1 = this.GetNextSelectableMenuItem(this.MenuItems.IndexOf(ribbonItem2) + 1);
        }
        else
        {
          foreach (RibbonItem recentItem in (List<RibbonItem>) this.RecentItems)
          {
            if (recentItem.Selected)
            {
              ribbonItem2 = recentItem;
              recentItem.SetSelected(false);
              recentItem.RedrawItem();
              break;
            }
          }
          if (ribbonItem2 != null)
          {
            ribbonItem1 = this.GetNextSelectableRecentItem(this.RecentItems.IndexOf(ribbonItem2) + 1);
          }
          else
          {
            foreach (RibbonItem optionItem in (List<RibbonItem>) this.OptionItems)
            {
              if (optionItem.Selected)
              {
                ribbonItem2 = optionItem;
                optionItem.SetSelected(false);
                optionItem.RedrawItem();
                break;
              }
            }
            if (ribbonItem2 != null)
              ribbonItem1 = this.GetNextSelectableOptionItem(this.OptionItems.IndexOf(ribbonItem2) + 1);
          }
        }
        if (ribbonItem2 == null)
        {
          RibbonItem selectableMenuItem = this.GetNextSelectableMenuItem(0);
          if (selectableMenuItem == null)
            return;
          selectableMenuItem.SetSelected(true);
          selectableMenuItem.RedrawItem();
        }
        else
        {
          ribbonItem2.SetSelected(false);
          ribbonItem2.RedrawItem();
          ribbonItem1.SetSelected(true);
          ribbonItem1.RedrawItem();
        }
      }
      else
      {
        int keyCode = (int) e.KeyCode;
      }
    }

    private RibbonItem GetNextSelectableMenuItem(int StartIndex)
    {
      for (int index = StartIndex; index < this.MenuItems.Count; ++index)
      {
        if (this.MenuItems[index] is RibbonButton menuItem1)
          return (RibbonItem) menuItem1;
      }
      return this.GetNextSelectableRecentItem(0) ?? this.GetNextSelectableOptionItem(0) ?? this.GetNextSelectableMenuItem(0);
    }

    private RibbonItem GetNextSelectableRecentItem(int StartIndex)
    {
      for (int index = StartIndex; index < this.RecentItems.Count; ++index)
      {
        if (this.RecentItems[index] is RibbonButton recentItem1)
          return (RibbonItem) recentItem1;
      }
      return this.GetNextSelectableOptionItem(0) ?? this.GetNextSelectableMenuItem(0) ?? this.GetNextSelectableRecentItem(0);
    }

    private RibbonItem GetNextSelectableOptionItem(int StartIndex)
    {
      for (int index = StartIndex; index < this.OptionItems.Count; ++index)
      {
        if (this.OptionItems[index] is RibbonButton optionItem1)
          return (RibbonItem) optionItem1;
      }
      return this.GetNextSelectableMenuItem(0) ?? this.GetNextSelectableRecentItem(0) ?? this.GetNextSelectableOptionItem(0);
    }
  }
}
