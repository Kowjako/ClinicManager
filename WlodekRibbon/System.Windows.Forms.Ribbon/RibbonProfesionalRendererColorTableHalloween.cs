// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonProfesionalRendererColorTableHalloween
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Drawing;

namespace System.Windows.Forms
{
  public class RibbonProfesionalRendererColorTableHalloween : RibbonProfesionalRendererColorTable
  {
    public RibbonProfesionalRendererColorTableHalloween()
    {
      this.OrbDropDownDarkBorder = RibbonProfesionalRendererColorTable.ToGray(this.OrbDropDownDarkBorder);
      this.OrbDropDownLightBorder = RibbonProfesionalRendererColorTable.ToGray(this.OrbDropDownLightBorder);
      this.OrbDropDownBack = RibbonProfesionalRendererColorTable.ToGray(this.OrbDropDownBack);
      this.OrbDropDownNorthA = RibbonProfesionalRendererColorTable.ToGray(this.OrbDropDownNorthA);
      this.OrbDropDownNorthB = RibbonProfesionalRendererColorTable.ToGray(this.OrbDropDownNorthB);
      this.OrbDropDownNorthC = RibbonProfesionalRendererColorTable.ToGray(this.OrbDropDownNorthC);
      this.OrbDropDownNorthD = RibbonProfesionalRendererColorTable.ToGray(this.OrbDropDownNorthD);
      this.OrbDropDownSouthC = RibbonProfesionalRendererColorTable.ToGray(this.OrbDropDownSouthC);
      this.OrbDropDownSouthD = RibbonProfesionalRendererColorTable.ToGray(this.OrbDropDownSouthD);
      this.OrbDropDownContentbg = RibbonProfesionalRendererColorTable.ToGray(this.OrbDropDownContentbg);
      this.OrbDropDownContentbglight = RibbonProfesionalRendererColorTable.ToGray(this.OrbDropDownContentbglight);
      this.OrbDropDownSeparatorlight = RibbonProfesionalRendererColorTable.ToGray(this.OrbDropDownSeparatorlight);
      this.OrbDropDownSeparatordark = RibbonProfesionalRendererColorTable.ToGray(this.OrbDropDownSeparatordark);
      this.Caption1 = RibbonProfesionalRendererColorTable.ToGray(this.Caption1);
      this.Caption2 = RibbonProfesionalRendererColorTable.ToGray(this.Caption2);
      this.Caption3 = RibbonProfesionalRendererColorTable.ToGray(this.Caption3);
      this.Caption4 = RibbonProfesionalRendererColorTable.ToGray(this.Caption4);
      this.Caption5 = RibbonProfesionalRendererColorTable.ToGray(this.Caption5);
      this.Caption6 = RibbonProfesionalRendererColorTable.ToGray(this.Caption6);
      this.Caption7 = RibbonProfesionalRendererColorTable.ToGray(this.Caption7);
      this.QuickAccessBorderDark = RibbonProfesionalRendererColorTable.ToGray(this.QuickAccessBorderDark);
      this.QuickAccessBorderLight = RibbonProfesionalRendererColorTable.ToGray(this.QuickAccessBorderLight);
      this.QuickAccessUpper = RibbonProfesionalRendererColorTable.ToGray(this.QuickAccessUpper);
      this.QuickAccessLower = RibbonProfesionalRendererColorTable.ToGray(this.QuickAccessLower);
      this.OrbOptionBorder = RibbonProfesionalRendererColorTable.ToGray(this.OrbOptionBorder);
      this.OrbOptionBackground = RibbonProfesionalRendererColorTable.ToGray(this.OrbOptionBackground);
      this.OrbOptionShine = RibbonProfesionalRendererColorTable.ToGray(this.OrbOptionShine);
      this.Arrow = this.FromHex("#7C7C7C");
      this.ArrowLight = this.FromHex("#EAF2F9");
      this.ArrowDisabled = this.FromHex("#7C7C7C");
      this.Text = this.FromHex("#000000");
      this.RibbonBackground = this.FromHex("#535353");
      this.TabBorder = this.FromHex("#BEBEBE");
      this.TabSelectedBorder = this.FromHex("#BEBEBE");
      this.TabNorth = this.FromHex("#F1F2F2");
      this.TabSouth = this.FromHex("#D6D9DF");
      this.TabGlow = this.FromHex("#D1FBFF");
      this.TabSelectedGlow = this.FromHex("#E1D2A5");
      this.TabText = Color.White;
      this.TabActiveText = Color.Black;
      this.TabContentNorth = this.FromHex("#B6BCC6");
      this.TabContentSouth = this.FromHex("#E6F0F1");
      this.PanelDarkBorder = this.FromHex("#AEB0B4");
      this.PanelLightBorder = this.FromHex("#E7E9ED");
      this.PanelTextBackground = this.FromHex("#ABAEAE");
      this.PanelTextBackgroundSelected = this.FromHex("#949495");
      this.PanelText = Color.White;
      this.PanelBackgroundSelected = this.FromHex("#F3F5F5");
      this.PanelOverflowBackground = this.FromHex("#B9D1F0");
      this.PanelOverflowBackgroundPressed = this.FromHex("#AAAEB3");
      this.PanelOverflowBackgroundSelectedNorth = Color.FromArgb(100, Color.White);
      this.PanelOverflowBackgroundSelectedSouth = Color.FromArgb(102, this.FromHex("#EBEBEB"));
      this.ButtonBgOut = this.FromHex("#B4B9C2");
      this.ButtonBgCenter = this.FromHex("#CDD2D8");
      this.ButtonBorderOut = this.FromHex("#A9B1B8");
      this.ButtonBorderIn = this.FromHex("#DFE2E6");
      this.ButtonGlossyNorth = this.FromHex("#DBDFE4");
      this.ButtonGlossySouth = this.FromHex("#DFE2E8");
      this.ButtonDisabledBgOut = this.FromHex("#E0E4E8");
      this.ButtonDisabledBgCenter = this.FromHex("#E8EBEF");
      this.ButtonDisabledBorderOut = this.FromHex("#C5D1DE");
      this.ButtonDisabledBorderIn = this.FromHex("#F1F3F5");
      this.ButtonDisabledGlossyNorth = this.FromHex("#F0F3F6");
      this.ButtonDisabledGlossySouth = this.FromHex("#EAEDF1");
      this.ButtonSelectedBgOut = this.FromHex("#FFD646");
      this.ButtonSelectedBgCenter = this.FromHex("#FFEAAC");
      this.ButtonSelectedBorderOut = this.FromHex("#C2A978");
      this.ButtonSelectedBorderIn = this.FromHex("#FFF2C7");
      this.ButtonSelectedGlossyNorth = this.FromHex("#FFFDDB");
      this.ButtonSelectedGlossySouth = this.FromHex("#FFE793");
      this.ButtonPressedBgOut = this.FromHex("#F88F2C");
      this.ButtonPressedBgCenter = this.FromHex("#FDF1B0");
      this.ButtonPressedBorderOut = this.FromHex("#8E8165");
      this.ButtonPressedBorderIn = this.FromHex("#F9C65A");
      this.ButtonPressedGlossyNorth = this.FromHex("#FDD5A8");
      this.ButtonPressedGlossySouth = this.FromHex("#FBB062");
      this.ButtonCheckedBgOut = this.FromHex("#F9AA45");
      this.ButtonCheckedBgCenter = this.FromHex("#FDEA9D");
      this.ButtonCheckedBorderOut = this.FromHex("#8E8165");
      this.ButtonCheckedBorderIn = this.FromHex("#F9C65A");
      this.ButtonCheckedGlossyNorth = this.FromHex("#F8DBB7");
      this.ButtonCheckedGlossySouth = this.FromHex("#FED18E");
      this.ButtonCheckedSelectedBgOut = this.FromHex("#F9AA45");
      this.ButtonCheckedSelectedBgCenter = this.FromHex("#FDEA9D");
      this.ButtonCheckedSelectedBorderOut = this.FromHex("#8E8165");
      this.ButtonCheckedSelectedBorderIn = this.FromHex("#F9C65A");
      this.ButtonCheckedSelectedGlossyNorth = this.FromHex("#F8DBB7");
      this.ButtonCheckedSelectedGlossySouth = this.FromHex("#FED18E");
      this.ItemGroupOuterBorder = this.FromHex("#ADB7BB");
      this.ItemGroupInnerBorder = Color.FromArgb(51, Color.White);
      this.ItemGroupSeparatorLight = Color.FromArgb(64, Color.White);
      this.ItemGroupSeparatorDark = Color.FromArgb(38, this.FromHex("#ADB7BB"));
      this.ItemGroupBgNorth = this.FromHex("#D9E0E1");
      this.ItemGroupBgSouth = this.FromHex("#EDF0F1");
      this.ItemGroupBgGlossy = this.FromHex("#D2D9DB");
      this.ButtonListBorder = this.FromHex("#ACACAC");
      this.ButtonListBg = this.FromHex("#DAE2E2");
      this.ButtonListBgSelected = this.FromHex("#F7F7F7");
      this.DropDownBg = this.FromHex("#FAFAFA");
      this.DropDownImageBg = this.FromHex("#E9EEEE");
      this.DropDownImageSeparator = this.FromHex("#C5C5C5");
      this.DropDownBorder = this.FromHex("#868686");
      this.DropDownGripNorth = this.FromHex("#FFFFFF");
      this.DropDownGripSouth = this.FromHex("#DFE9EF");
      this.DropDownGripBorder = this.FromHex("#DDE7EE");
      this.DropDownGripDark = this.FromHex("#5574A7");
      this.DropDownGripLight = this.FromHex("#FFFFFF");
      this.DropDownCheckedButtonGlyphBg = this.FromHex("#FCF1C2");
      this.DropDownCheckedButtonGlyphBorder = this.FromHex("#F29536");
      this.SeparatorLight = this.FromHex("#E6E8EB");
      this.SeparatorDark = this.FromHex("#C5C5C5");
      this.QATSeparatorLight = this.FromHex("#E6E8EB");
      this.QATSeparatorDark = this.FromHex("#C5C5C5");
      this.SeparatorBg = this.FromHex("#EBEBEB");
      this.SeparatorLine = this.FromHex("#C5C5C5");
      this.TextBoxUnselectedBg = this.FromHex("#E8E8E8");
      this.TextBoxBorder = this.FromHex("#898989");
      this.ToolStripItemTextPressed = this.FromHex("#262626");
      this.ToolStripItemTextSelected = this.FromHex("#262626");
      this.ToolStripItemText = this.FromHex("#0072C6");
      this.clrVerBG_Shadow = Color.FromArgb((int) byte.MaxValue, 181, 190, 206);
      this.ButtonChecked_2013 = this.FromHex("#CDE6F7");
      this.ButtonPressed_2013 = this.FromHex("#92C0E0");
      this.ButtonSelected_2013 = this.FromHex("#CDE6F7");
      this.OrbButton_2013 = this.FromHex("#333333");
      this.OrbButtonSelected_2013 = this.FromHex("#2A8AD4");
      this.OrbButtonPressed_2013 = this.FromHex("#2A8AD4");
      this.TabText_2013 = this.FromHex("#0072C6");
      this.TabTextSelected_2013 = this.FromHex("#262626");
      this.PanelBorder_2013 = this.FromHex("#15428B");
      this.RibbonBackground_2013 = this.FromHex("#DEDEDE");
      this.TabCompleteBackground_2013 = this.FromHex("#F3F3F3");
      this.TabNormalBackground_2013 = this.FromHex("#DEDEDE");
      this.TabActiveBackbround_2013 = this.FromHex("#F3F3F3");
      this.TabBorder_2013 = this.FromHex("#ABABAB");
      this.TabCompleteBorder_2013 = this.FromHex("#ABABAB");
      this.TabActiveBorder_2013 = this.FromHex("#ABABAB");
      this.OrbButtonText_2013 = this.FromHex("#FFFFFF");
      this.PanelText_2013 = this.FromHex("#262626");
      this.RibbonItemText_2013 = this.FromHex("#262626");
      this.ToolTipText_2013 = this.FromHex("#262626");
      this.ToolStripItemTextPressed_2013 = this.FromHex("#262626");
      this.ToolStripItemTextSelected_2013 = this.FromHex("#262626");
      this.ToolStripItemText_2013 = this.FromHex("#0072C6");
    }
  }
}
