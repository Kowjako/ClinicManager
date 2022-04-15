// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonProfesionalRendererColorTable
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms.RibbonHelpers;
using System.Xml;

namespace System.Windows.Forms
{
  public class RibbonProfesionalRendererColorTable
  {
    public Color FormBorder = RibbonProfesionalRendererColorTable.FromHexStr("#3B5A82");
    public Color OrbDropDownDarkBorder = Color.FromArgb(155, 175, 202);
    public Color OrbDropDownLightBorder = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    public Color OrbDropDownBack = Color.FromArgb(191, 211, 235);
    public Color OrbDropDownNorthA = Color.FromArgb(215, 229, 247);
    public Color OrbDropDownNorthB = Color.FromArgb(212, 225, 243);
    public Color OrbDropDownNorthC = Color.FromArgb(198, 216, 238);
    public Color OrbDropDownNorthD = Color.FromArgb(183, 202, 230);
    public Color OrbDropDownSouthC = Color.FromArgb(176, 201, 234);
    public Color OrbDropDownSouthD = Color.FromArgb(207, 224, 245);
    public Color OrbDropDownContentbg = Color.FromArgb(233, 234, 238);
    public Color OrbDropDownContentbglight = Color.FromArgb(250, 250, 250);
    public Color OrbDropDownSeparatorlight = Color.FromArgb(245, 245, 245);
    public Color OrbDropDownSeparatordark = Color.FromArgb(197, 197, 197);
    public Color Caption1 = RibbonProfesionalRendererColorTable.FromHexStr("#E3EBF6");
    public Color Caption2 = RibbonProfesionalRendererColorTable.FromHexStr("#DAE9FD");
    public Color Caption3 = RibbonProfesionalRendererColorTable.FromHexStr("#D5E5FA");
    public Color Caption4 = RibbonProfesionalRendererColorTable.FromHexStr("#D9E7F9");
    public Color Caption5 = RibbonProfesionalRendererColorTable.FromHexStr("#CADEF7");
    public Color Caption6 = RibbonProfesionalRendererColorTable.FromHexStr("#E4EFFD");
    public Color Caption7 = RibbonProfesionalRendererColorTable.FromHexStr("#B0CFF7");
    public Color QuickAccessBorderDark = RibbonProfesionalRendererColorTable.FromHexStr("#B6CAE2");
    public Color QuickAccessBorderLight = RibbonProfesionalRendererColorTable.FromHexStr("#F2F6FB");
    public Color QuickAccessUpper = RibbonProfesionalRendererColorTable.FromHexStr("#E0EBF9");
    public Color QuickAccessLower = RibbonProfesionalRendererColorTable.FromHexStr("#C9D9EE");
    public Color OrbOptionBorder = RibbonProfesionalRendererColorTable.FromHexStr("#7793B9");
    public Color OrbOptionBackground = RibbonProfesionalRendererColorTable.FromHexStr("#E8F1FC");
    public Color OrbOptionShine = RibbonProfesionalRendererColorTable.FromHexStr("#D2E1F4");
    public Color Arrow = RibbonProfesionalRendererColorTable.FromHexStr("#678CBD");
    public Color ArrowLight = Color.FromArgb(200, Color.White);
    public Color ArrowDisabled = RibbonProfesionalRendererColorTable.FromHexStr("#B7B7B7");
    public Color Text = RibbonProfesionalRendererColorTable.FromHexStr("#15428B");
    public Color OrbBackgroundDark = RibbonProfesionalRendererColorTable.FromHexStr("#7C8CA4");
    public Color OrbBackgroundMedium = RibbonProfesionalRendererColorTable.FromHexStr("#99ABC6");
    public Color OrbBackgroundLight = Color.White;
    public Color OrbLight = Color.White;
    public Color OrbSelectedBackgroundDark = RibbonProfesionalRendererColorTable.FromHexStr("#DFAA1A");
    public Color OrbSelectedBackgroundMedium = RibbonProfesionalRendererColorTable.FromHexStr("#F9D12E");
    public Color OrbSelectedBackgroundLight = RibbonProfesionalRendererColorTable.FromHexStr("#FFEF36");
    public Color OrbSelectedLight = RibbonProfesionalRendererColorTable.FromHexStr("#FFF52B");
    public Color OrbPressedBackgroundDark = RibbonProfesionalRendererColorTable.FromHexStr("#CE8410");
    public Color OrbPressedBackgroundMedium = RibbonProfesionalRendererColorTable.FromHexStr("#CE8410");
    public Color OrbPressedBackgroundLight = RibbonProfesionalRendererColorTable.FromHexStr("#F57603");
    public Color OrbPressedLight = RibbonProfesionalRendererColorTable.FromHexStr("#F08500");
    public Color OrbBorderAero = RibbonProfesionalRendererColorTable.FromHexStr("#99A1AD");
    public Color OrbButtonText = Color.White;
    public Color OrbButtonBackground = Color.FromArgb(60, 120, 187);
    public Color OrbButtonDark = Color.FromArgb(25, 65, 135);
    public Color OrbButtonMedium = Color.FromArgb(56, 135, 191);
    public Color OrbButtonLight = Color.FromArgb(64, 154, 207);
    public Color OrbButtonPressedCenter = Color.FromArgb(25, 64, 136);
    public Color OrbButtonPressedNorth = Color.FromArgb(71, 132, 194);
    public Color OrbButtonPressedSouth = Color.FromArgb(56, 135, 191);
    public Color OrbButtonGlossyNorth = Color.FromArgb(71, 132, 194);
    public Color OrbButtonGlossySouth = Color.FromArgb(46, 104, 178);
    public Color OrbButtonBorderDark = Color.FromArgb(68, 135, 213);
    public Color OrbButtonBorderLight = Color.FromArgb(160, 204, 243);
    public Color RibbonBackground = RibbonProfesionalRendererColorTable.FromHexStr("#BED0E8");
    public Color TabBorder = RibbonProfesionalRendererColorTable.FromHexStr("#9FB2C7");
    public Color TabSelectedBorder = RibbonProfesionalRendererColorTable.FromHexStr("#B1B5BA");
    public Color TabNorth = RibbonProfesionalRendererColorTable.FromHexStr("#EBF3FE");
    public Color TabSouth = RibbonProfesionalRendererColorTable.FromHexStr("#E1EAF6");
    public Color TabGlow = RibbonProfesionalRendererColorTable.FromHexStr("#D1FBFF");
    public Color TabText = RibbonProfesionalRendererColorTable.FromHexStr("#15428B");
    public Color TabActiveText = RibbonProfesionalRendererColorTable.FromHexStr("#15428B");
    public Color TabContentNorth = RibbonProfesionalRendererColorTable.FromHexStr("#C8D9ED");
    public Color TabContentSouth = RibbonProfesionalRendererColorTable.FromHexStr("#E7F2FF");
    public Color TabSelectedGlow = RibbonProfesionalRendererColorTable.FromHexStr("#E1D2A5");
    public Color PanelDarkBorder = Color.FromArgb(51, RibbonProfesionalRendererColorTable.FromHexStr("#15428B"));
    public Color PanelLightBorder = Color.FromArgb(102, Color.White);
    public Color PanelTextBackground = RibbonProfesionalRendererColorTable.FromHexStr("#C2D9F0");
    public Color PanelTextBackgroundSelected = RibbonProfesionalRendererColorTable.FromHexStr("#C2D9F0");
    public Color PanelText = RibbonProfesionalRendererColorTable.FromHexStr("#15428B");
    public Color PanelBackgroundSelected = Color.FromArgb(102, RibbonProfesionalRendererColorTable.FromHexStr("#E8FFFD"));
    public Color PanelOverflowBackground = RibbonProfesionalRendererColorTable.FromHexStr("#B9D1F0");
    public Color PanelOverflowBackgroundPressed = RibbonProfesionalRendererColorTable.FromHexStr("#7699C8");
    public Color PanelOverflowBackgroundSelectedNorth = Color.FromArgb(100, Color.White);
    public Color PanelOverflowBackgroundSelectedSouth = Color.FromArgb(102, RibbonProfesionalRendererColorTable.FromHexStr("#B8D7FD"));
    public Color ButtonBgOut = RibbonProfesionalRendererColorTable.FromHexStr("#C1D5F1");
    public Color ButtonBgCenter = RibbonProfesionalRendererColorTable.FromHexStr("#CFE0F7");
    public Color ButtonBorderOut = RibbonProfesionalRendererColorTable.FromHexStr("#B9D0ED");
    public Color ButtonBorderIn = RibbonProfesionalRendererColorTable.FromHexStr("#E3EDFB");
    public Color ButtonGlossyNorth = RibbonProfesionalRendererColorTable.FromHexStr("#DEEBFE");
    public Color ButtonGlossySouth = RibbonProfesionalRendererColorTable.FromHexStr("#CBDEF6");
    public Color ButtonDisabledBgOut = RibbonProfesionalRendererColorTable.FromHexStr("#E0E4E8");
    public Color ButtonDisabledBgCenter = RibbonProfesionalRendererColorTable.FromHexStr("#E8EBEF");
    public Color ButtonDisabledBorderOut = RibbonProfesionalRendererColorTable.FromHexStr("#C5D1DE");
    public Color ButtonDisabledBorderIn = RibbonProfesionalRendererColorTable.FromHexStr("#F1F3F5");
    public Color ButtonDisabledGlossyNorth = RibbonProfesionalRendererColorTable.FromHexStr("#F0F3F6");
    public Color ButtonDisabledGlossySouth = RibbonProfesionalRendererColorTable.FromHexStr("#EAEDF1");
    public Color ButtonSelectedBgOut = RibbonProfesionalRendererColorTable.FromHexStr("#FFD646");
    public Color ButtonSelectedBgCenter = RibbonProfesionalRendererColorTable.FromHexStr("#FFEAAC");
    public Color ButtonSelectedBorderOut = RibbonProfesionalRendererColorTable.FromHexStr("#C2A978");
    public Color ButtonSelectedBorderIn = RibbonProfesionalRendererColorTable.FromHexStr("#FFF2C7");
    public Color ButtonSelectedGlossyNorth = RibbonProfesionalRendererColorTable.FromHexStr("#FFFDDB");
    public Color ButtonSelectedGlossySouth = RibbonProfesionalRendererColorTable.FromHexStr("#FFE793");
    public Color ButtonPressedBgOut = RibbonProfesionalRendererColorTable.FromHexStr("#F88F2C");
    public Color ButtonPressedBgCenter = RibbonProfesionalRendererColorTable.FromHexStr("#FDF1B0");
    public Color ButtonPressedBorderOut = RibbonProfesionalRendererColorTable.FromHexStr("#8E8165");
    public Color ButtonPressedBorderIn = RibbonProfesionalRendererColorTable.FromHexStr("#F9C65A");
    public Color ButtonPressedGlossyNorth = RibbonProfesionalRendererColorTable.FromHexStr("#FDD5A8");
    public Color ButtonPressedGlossySouth = RibbonProfesionalRendererColorTable.FromHexStr("#FBB062");
    public Color ButtonCheckedBgOut = RibbonProfesionalRendererColorTable.FromHexStr("#F9AA45");
    public Color ButtonCheckedBgCenter = RibbonProfesionalRendererColorTable.FromHexStr("#FDEA9D");
    public Color ButtonCheckedBorderOut = RibbonProfesionalRendererColorTable.FromHexStr("#8E8165");
    public Color ButtonCheckedBorderIn = RibbonProfesionalRendererColorTable.FromHexStr("#F9C65A");
    public Color ButtonCheckedGlossyNorth = RibbonProfesionalRendererColorTable.FromHexStr("#F8DBB7");
    public Color ButtonCheckedGlossySouth = RibbonProfesionalRendererColorTable.FromHexStr("#FED18E");
    public Color ButtonCheckedSelectedBgOut = RibbonProfesionalRendererColorTable.FromHexStr("#F9AA45");
    public Color ButtonCheckedSelectedBgCenter = RibbonProfesionalRendererColorTable.FromHexStr("#FDEA9D");
    public Color ButtonCheckedSelectedBorderOut = RibbonProfesionalRendererColorTable.FromHexStr("#8E8165");
    public Color ButtonCheckedSelectedBorderIn = RibbonProfesionalRendererColorTable.FromHexStr("#F9C65A");
    public Color ButtonCheckedSelectedGlossyNorth = RibbonProfesionalRendererColorTable.FromHexStr("#F8DBB7");
    public Color ButtonCheckedSelectedGlossySouth = RibbonProfesionalRendererColorTable.FromHexStr("#FED18E");
    public Color ItemGroupOuterBorder = RibbonProfesionalRendererColorTable.FromHexStr("#9EBAE1");
    public Color ItemGroupInnerBorder = Color.FromArgb(51, Color.White);
    public Color ItemGroupSeparatorLight = Color.FromArgb(64, Color.White);
    public Color ItemGroupSeparatorDark = Color.FromArgb(38, RibbonProfesionalRendererColorTable.FromHexStr("#9EBAE1"));
    public Color ItemGroupBgNorth = RibbonProfesionalRendererColorTable.FromHexStr("#CADCF0");
    public Color ItemGroupBgSouth = RibbonProfesionalRendererColorTable.FromHexStr("#D0E1F7");
    public Color ItemGroupBgGlossy = RibbonProfesionalRendererColorTable.FromHexStr("#BCD0E9");
    public Color ButtonListBorder = RibbonProfesionalRendererColorTable.FromHexStr("#B9D0ED");
    public Color ButtonListBg = RibbonProfesionalRendererColorTable.FromHexStr("#D4E6F8");
    public Color ButtonListBgSelected = RibbonProfesionalRendererColorTable.FromHexStr("#ECF3FB");
    public Color DropDownBg = RibbonProfesionalRendererColorTable.FromHexStr("#FAFAFA");
    public Color DropDownImageBg = RibbonProfesionalRendererColorTable.FromHexStr("#E9EEEE");
    public Color DropDownImageSeparator = RibbonProfesionalRendererColorTable.FromHexStr("#C5C5C5");
    public Color DropDownBorder = RibbonProfesionalRendererColorTable.FromHexStr("#868686");
    public Color DropDownGripNorth = RibbonProfesionalRendererColorTable.FromHexStr("#FFFFFF");
    public Color DropDownGripSouth = RibbonProfesionalRendererColorTable.FromHexStr("#DFE9EF");
    public Color DropDownGripBorder = RibbonProfesionalRendererColorTable.FromHexStr("#DDE7EE");
    public Color DropDownGripDark = RibbonProfesionalRendererColorTable.FromHexStr("#5574A7");
    public Color DropDownGripLight = RibbonProfesionalRendererColorTable.FromHexStr("#FFFFFF");
    public Color DropDownCheckedButtonGlyphBg = RibbonProfesionalRendererColorTable.FromHexStr("#FCF1C2");
    public Color DropDownCheckedButtonGlyphBorder = RibbonProfesionalRendererColorTable.FromHexStr("#F29536");
    public Color SeparatorLight = RibbonProfesionalRendererColorTable.FromHexStr("#FAFBFD");
    public Color SeparatorDark = RibbonProfesionalRendererColorTable.FromHexStr("#96B4DA");
    public Color QATSeparatorLight = RibbonProfesionalRendererColorTable.FromHexStr("#FAFBFD");
    public Color QATSeparatorDark = RibbonProfesionalRendererColorTable.FromHexStr("#96B4DA");
    public Color SeparatorBg = RibbonProfesionalRendererColorTable.FromHexStr("#DAE6EE");
    public Color SeparatorLine = RibbonProfesionalRendererColorTable.FromHexStr("#C5C5C5");
    public Color TextBoxUnselectedBg = RibbonProfesionalRendererColorTable.FromHexStr("#EAF2FB");
    public Color TextBoxBorder = RibbonProfesionalRendererColorTable.FromHexStr("#ABC1DE");
    public Color ToolTipContentNorth = Color.FromArgb(250, 252, 254);
    public Color ToolTipContentSouth = Color.FromArgb(206, 220, 241);
    public Color ToolTipDarkBorder = Color.DarkGray;
    public Color ToolTipLightBorder = Color.FromArgb(102, Color.White);
    public Color ToolTipText = WinApi.IsVista ? SystemColors.InactiveCaptionText : RibbonProfesionalRendererColorTable.FromHexStr("#15428B");
    public Color ToolStripItemTextPressed = RibbonProfesionalRendererColorTable.FromHexStr("#444444");
    public Color ToolStripItemTextSelected = RibbonProfesionalRendererColorTable.FromHexStr("#444444");
    public Color ToolStripItemText = RibbonProfesionalRendererColorTable.FromHexStr("#444444");
    public Color clrVerBG_Shadow = Color.FromArgb((int) byte.MaxValue, 181, 190, 206);
    public Color ButtonChecked_2013 = RibbonProfesionalRendererColorTable.FromHexStr("#CDE6F7");
    public Color ButtonPressed_2013 = RibbonProfesionalRendererColorTable.FromHexStr("#92C0E0");
    public Color ButtonSelected_2013 = RibbonProfesionalRendererColorTable.FromHexStr("#CDE6F7");
    public Color OrbButton_2013 = RibbonProfesionalRendererColorTable.FromHexStr("#0072C6");
    public Color OrbButtonSelected_2013 = RibbonProfesionalRendererColorTable.FromHexStr("#2A8AD4");
    public Color OrbButtonPressed_2013 = RibbonProfesionalRendererColorTable.FromHexStr("#2A8AD4");
    public Color TabText_2013 = RibbonProfesionalRendererColorTable.FromHexStr("#0072C6");
    public Color TabTextSelected_2013 = RibbonProfesionalRendererColorTable.FromHexStr("#444444");
    public Color PanelBorder_2013 = RibbonProfesionalRendererColorTable.FromHexStr("#15428B");
    public Color RibbonBackground_2013 = RibbonProfesionalRendererColorTable.FromHexStr("#FFFFFF");
    public Color TabCompleteBackground_2013 = RibbonProfesionalRendererColorTable.FromHexStr("#FFFFFF");
    public Color TabNormalBackground_2013 = RibbonProfesionalRendererColorTable.FromHexStr("#FFFFFF");
    public Color TabActiveBackbround_2013 = RibbonProfesionalRendererColorTable.FromHexStr("#FFFFFF");
    public Color TabBorder_2013 = RibbonProfesionalRendererColorTable.FromHexStr("#D4D4D4");
    public Color TabCompleteBorder_2013 = RibbonProfesionalRendererColorTable.FromHexStr("#D4D4D4");
    public Color TabActiveBorder_2013 = RibbonProfesionalRendererColorTable.FromHexStr("#D4D4D4");
    public Color OrbButtonText_2013 = RibbonProfesionalRendererColorTable.FromHexStr("#FFFFFF");
    public Color PanelText_2013 = RibbonProfesionalRendererColorTable.FromHexStr("#666666");
    public Color RibbonItemText_2013 = RibbonProfesionalRendererColorTable.FromHexStr("#444444");
    public Color ToolTipText_2013 = RibbonProfesionalRendererColorTable.FromHexStr("#262626");
    public Color ToolStripItemTextPressed_2013 = RibbonProfesionalRendererColorTable.FromHexStr("#444444");
    public Color ToolStripItemTextSelected_2013 = RibbonProfesionalRendererColorTable.FromHexStr("#444444");
    public Color ToolStripItemText_2013 = RibbonProfesionalRendererColorTable.FromHexStr("#444444");

    public string ThemeName { get; set; }

    public string ThemeAuthor { get; set; }

    public string ThemeAuthorEmail { get; set; }

    public string ThemeAuthorWebsite { get; set; }

    public string ThemeDateCreated { get; set; }

    private static Color FromHexStr(string hex)
    {
      if (hex.StartsWith("#"))
        hex = hex.Substring(1);
      switch (hex.Length)
      {
        case 6:
          return Color.FromArgb(int.Parse(hex.Substring(0, 2), NumberStyles.HexNumber), int.Parse(hex.Substring(2, 2), NumberStyles.HexNumber), int.Parse(hex.Substring(4, 2), NumberStyles.HexNumber));
        case 8:
          return Color.FromArgb(int.Parse(hex.Substring(0, 2), NumberStyles.HexNumber), int.Parse(hex.Substring(2, 2), NumberStyles.HexNumber), int.Parse(hex.Substring(4, 2), NumberStyles.HexNumber), int.Parse(hex.Substring(6, 2), NumberStyles.HexNumber));
        default:
          throw new ArgumentException("Color not valid");
      }
    }

    public Color FromHex(string hex) => RibbonProfesionalRendererColorTable.FromHexStr(hex);

    internal static Color ToGray(Color c)
    {
      int num = ((int) c.R + (int) c.G + (int) c.B) / 3;
      return Color.FromArgb(num, num, num);
    }

    public void SetColor(RibbonColorPart ribbonColorPart, int red, int green, int blue) => this.SetColor(ribbonColorPart, Color.FromArgb(red, green, blue));

    public void SetColor(RibbonColorPart ribbonColorPart, string hexColor) => this.SetColor(ribbonColorPart, this.FromHex(hexColor));

    public void SetColor(RibbonColorPart ribbonColorPart, Color color)
    {
      switch (ribbonColorPart)
      {
        case RibbonColorPart.OrbDropDownDarkBorder:
          this.OrbDropDownDarkBorder = color;
          break;
        case RibbonColorPart.OrbDropDownLightBorder:
          this.OrbDropDownLightBorder = color;
          break;
        case RibbonColorPart.OrbDropDownBack:
          this.OrbDropDownBack = color;
          break;
        case RibbonColorPart.OrbDropDownNorthA:
          this.OrbDropDownNorthA = color;
          break;
        case RibbonColorPart.OrbDropDownNorthB:
          this.OrbDropDownNorthB = color;
          break;
        case RibbonColorPart.OrbDropDownNorthC:
          this.OrbDropDownNorthC = color;
          break;
        case RibbonColorPart.OrbDropDownNorthD:
          this.OrbDropDownNorthD = color;
          break;
        case RibbonColorPart.OrbDropDownSouthC:
          this.OrbDropDownSouthC = color;
          break;
        case RibbonColorPart.OrbDropDownSouthD:
          this.OrbDropDownSouthD = color;
          break;
        case RibbonColorPart.OrbDropDownContentbg:
          this.OrbDropDownContentbg = color;
          break;
        case RibbonColorPart.OrbDropDownContentbglight:
          this.OrbDropDownContentbglight = color;
          break;
        case RibbonColorPart.OrbDropDownSeparatorlight:
          this.OrbDropDownSeparatorlight = color;
          break;
        case RibbonColorPart.OrbDropDownSeparatordark:
          this.OrbDropDownSeparatordark = color;
          break;
        case RibbonColorPart.Caption1:
          this.Caption1 = color;
          break;
        case RibbonColorPart.Caption2:
          this.Caption2 = color;
          break;
        case RibbonColorPart.Caption3:
          this.Caption3 = color;
          break;
        case RibbonColorPart.Caption4:
          this.Caption4 = color;
          break;
        case RibbonColorPart.Caption5:
          this.Caption5 = color;
          break;
        case RibbonColorPart.Caption6:
          this.Caption6 = color;
          break;
        case RibbonColorPart.Caption7:
          this.Caption7 = color;
          break;
        case RibbonColorPart.QuickAccessBorderDark:
          this.QuickAccessBorderDark = color;
          break;
        case RibbonColorPart.QuickAccessBorderLight:
          this.QuickAccessBorderLight = color;
          break;
        case RibbonColorPart.QuickAccessUpper:
          this.QuickAccessUpper = color;
          break;
        case RibbonColorPart.QuickAccessLower:
          this.QuickAccessLower = color;
          break;
        case RibbonColorPart.OrbOptionBorder:
          this.OrbOptionBorder = color;
          break;
        case RibbonColorPart.OrbOptionBackground:
          this.OrbOptionBackground = color;
          break;
        case RibbonColorPart.OrbOptionShine:
          this.OrbOptionShine = color;
          break;
        case RibbonColorPart.Arrow:
          this.Arrow = color;
          break;
        case RibbonColorPart.ArrowLight:
          this.ArrowLight = color;
          break;
        case RibbonColorPart.ArrowDisabled:
          this.ArrowDisabled = color;
          break;
        case RibbonColorPart.Text:
          this.Text = color;
          break;
        case RibbonColorPart.RibbonBackground:
          this.RibbonBackground = color;
          break;
        case RibbonColorPart.TabBorder:
          this.TabBorder = color;
          break;
        case RibbonColorPart.TabNorth:
          this.TabNorth = color;
          break;
        case RibbonColorPart.TabSouth:
          this.TabSouth = color;
          break;
        case RibbonColorPart.TabGlow:
          this.TabGlow = color;
          break;
        case RibbonColorPart.TabText:
          this.TabText = color;
          break;
        case RibbonColorPart.TabActiveText:
          this.TabActiveText = color;
          break;
        case RibbonColorPart.TabContentNorth:
          this.TabContentNorth = color;
          break;
        case RibbonColorPart.TabContentSouth:
          this.TabContentSouth = color;
          break;
        case RibbonColorPart.TabSelectedGlow:
          this.TabSelectedGlow = color;
          break;
        case RibbonColorPart.PanelDarkBorder:
          this.PanelDarkBorder = color;
          break;
        case RibbonColorPart.PanelLightBorder:
          this.PanelLightBorder = color;
          break;
        case RibbonColorPart.PanelTextBackground:
          this.PanelTextBackground = color;
          break;
        case RibbonColorPart.PanelTextBackgroundSelected:
          this.PanelTextBackgroundSelected = color;
          break;
        case RibbonColorPart.PanelText:
          this.PanelText = color;
          break;
        case RibbonColorPart.PanelBackgroundSelected:
          this.PanelBackgroundSelected = color;
          break;
        case RibbonColorPart.PanelOverflowBackground:
          this.PanelOverflowBackground = color;
          break;
        case RibbonColorPart.PanelOverflowBackgroundPressed:
          this.PanelOverflowBackgroundPressed = color;
          break;
        case RibbonColorPart.PanelOverflowBackgroundSelectedNorth:
          this.PanelOverflowBackgroundSelectedNorth = color;
          break;
        case RibbonColorPart.PanelOverflowBackgroundSelectedSouth:
          this.PanelOverflowBackgroundSelectedSouth = color;
          break;
        case RibbonColorPart.ButtonBgOut:
          this.ButtonBgOut = color;
          break;
        case RibbonColorPart.ButtonBgCenter:
          this.ButtonBgCenter = color;
          break;
        case RibbonColorPart.ButtonBorderOut:
          this.ButtonBorderOut = color;
          break;
        case RibbonColorPart.ButtonBorderIn:
          this.ButtonBorderIn = color;
          break;
        case RibbonColorPart.ButtonGlossyNorth:
          this.ButtonGlossyNorth = color;
          break;
        case RibbonColorPart.ButtonGlossySouth:
          this.ButtonGlossySouth = color;
          break;
        case RibbonColorPart.ButtonDisabledBgOut:
          this.ButtonDisabledBgOut = color;
          break;
        case RibbonColorPart.ButtonDisabledBgCenter:
          this.ButtonDisabledBgCenter = color;
          break;
        case RibbonColorPart.ButtonDisabledBorderOut:
          this.ButtonDisabledBorderOut = color;
          break;
        case RibbonColorPart.ButtonDisabledBorderIn:
          this.ButtonDisabledBorderIn = color;
          break;
        case RibbonColorPart.ButtonDisabledGlossyNorth:
          this.ButtonDisabledGlossyNorth = color;
          break;
        case RibbonColorPart.ButtonDisabledGlossySouth:
          this.ButtonDisabledGlossySouth = color;
          break;
        case RibbonColorPart.ButtonSelectedBgOut:
          this.ButtonSelectedBgOut = color;
          break;
        case RibbonColorPart.ButtonSelectedBgCenter:
          this.ButtonSelectedBgCenter = color;
          break;
        case RibbonColorPart.ButtonSelectedBorderOut:
          this.ButtonSelectedBorderOut = color;
          break;
        case RibbonColorPart.ButtonSelectedBorderIn:
          this.ButtonSelectedBorderIn = color;
          break;
        case RibbonColorPart.ButtonSelectedGlossyNorth:
          this.ButtonSelectedGlossyNorth = color;
          break;
        case RibbonColorPart.ButtonSelectedGlossySouth:
          this.ButtonSelectedGlossySouth = color;
          break;
        case RibbonColorPart.ButtonPressedBgOut:
          this.ButtonPressedBgOut = color;
          break;
        case RibbonColorPart.ButtonPressedBgCenter:
          this.ButtonPressedBgCenter = color;
          break;
        case RibbonColorPart.ButtonPressedBorderOut:
          this.ButtonPressedBorderOut = color;
          break;
        case RibbonColorPart.ButtonPressedBorderIn:
          this.ButtonPressedBorderIn = color;
          break;
        case RibbonColorPart.ButtonPressedGlossyNorth:
          this.ButtonPressedGlossyNorth = color;
          break;
        case RibbonColorPart.ButtonPressedGlossySouth:
          this.ButtonPressedGlossySouth = color;
          break;
        case RibbonColorPart.ButtonCheckedBgOut:
          this.ButtonCheckedBgOut = color;
          break;
        case RibbonColorPart.ButtonCheckedBgCenter:
          this.ButtonCheckedBgCenter = color;
          break;
        case RibbonColorPart.ButtonCheckedBorderOut:
          this.ButtonCheckedBorderOut = color;
          break;
        case RibbonColorPart.ButtonCheckedBorderIn:
          this.ButtonCheckedBorderIn = color;
          break;
        case RibbonColorPart.ButtonCheckedGlossyNorth:
          this.ButtonCheckedGlossyNorth = color;
          break;
        case RibbonColorPart.ButtonCheckedGlossySouth:
          this.ButtonCheckedGlossySouth = color;
          break;
        case RibbonColorPart.ButtonCheckedSelectedBgOut:
          this.ButtonCheckedSelectedBgOut = color;
          break;
        case RibbonColorPart.ButtonCheckedSelectedBgCenter:
          this.ButtonCheckedSelectedBgCenter = color;
          break;
        case RibbonColorPart.ButtonCheckedSelectedBorderOut:
          this.ButtonCheckedSelectedBorderOut = color;
          break;
        case RibbonColorPart.ButtonCheckedSelectedBorderIn:
          this.ButtonCheckedSelectedBorderIn = color;
          break;
        case RibbonColorPart.ButtonCheckedSelectedGlossyNorth:
          this.ButtonCheckedSelectedGlossyNorth = color;
          break;
        case RibbonColorPart.ButtonCheckedSelectedGlossySouth:
          this.ButtonCheckedSelectedGlossySouth = color;
          break;
        case RibbonColorPart.ItemGroupOuterBorder:
          this.ItemGroupOuterBorder = color;
          break;
        case RibbonColorPart.ItemGroupInnerBorder:
          this.ItemGroupInnerBorder = color;
          break;
        case RibbonColorPart.ItemGroupSeparatorLight:
          this.ItemGroupSeparatorLight = color;
          break;
        case RibbonColorPart.ItemGroupSeparatorDark:
          this.ItemGroupSeparatorDark = color;
          break;
        case RibbonColorPart.ItemGroupBgNorth:
          this.ItemGroupBgNorth = color;
          break;
        case RibbonColorPart.ItemGroupBgSouth:
          this.ItemGroupBgSouth = color;
          break;
        case RibbonColorPart.ItemGroupBgGlossy:
          this.ItemGroupBgGlossy = color;
          break;
        case RibbonColorPart.ButtonListBorder:
          this.ButtonListBorder = color;
          break;
        case RibbonColorPart.ButtonListBg:
          this.ButtonListBg = color;
          break;
        case RibbonColorPart.ButtonListBgSelected:
          this.ButtonListBgSelected = color;
          break;
        case RibbonColorPart.DropDownBg:
          this.DropDownBg = color;
          break;
        case RibbonColorPart.DropDownImageBg:
          this.DropDownImageBg = color;
          break;
        case RibbonColorPart.DropDownImageSeparator:
          this.DropDownImageSeparator = color;
          break;
        case RibbonColorPart.DropDownBorder:
          this.DropDownBorder = color;
          break;
        case RibbonColorPart.DropDownGripNorth:
          this.DropDownGripNorth = color;
          break;
        case RibbonColorPart.DropDownGripSouth:
          this.DropDownGripSouth = color;
          break;
        case RibbonColorPart.DropDownGripBorder:
          this.DropDownGripBorder = color;
          break;
        case RibbonColorPart.DropDownGripDark:
          this.DropDownGripDark = color;
          break;
        case RibbonColorPart.DropDownGripLight:
          this.DropDownGripLight = color;
          break;
        case RibbonColorPart.DropDownCheckedButtonGlyphBg:
          this.DropDownCheckedButtonGlyphBg = color;
          break;
        case RibbonColorPart.DropDownCheckedButtonGlyphBorder:
          this.DropDownCheckedButtonGlyphBorder = color;
          break;
        case RibbonColorPart.SeparatorLight:
          this.SeparatorLight = color;
          break;
        case RibbonColorPart.SeparatorDark:
          this.SeparatorDark = color;
          break;
        case RibbonColorPart.QATSeparatorLight:
          this.QATSeparatorLight = color;
          break;
        case RibbonColorPart.QATSeparatorDark:
          this.QATSeparatorDark = color;
          break;
        case RibbonColorPart.SeparatorBg:
          this.SeparatorBg = color;
          break;
        case RibbonColorPart.SeparatorLine:
          this.SeparatorLine = color;
          break;
        case RibbonColorPart.TextBoxUnselectedBg:
          this.TextBoxUnselectedBg = color;
          break;
        case RibbonColorPart.TextBoxBorder:
          this.TextBoxBorder = color;
          break;
        case RibbonColorPart.ToolTipContentNorth:
          this.ToolTipContentNorth = color;
          break;
        case RibbonColorPart.ToolTipContentSouth:
          this.ToolTipContentSouth = color;
          break;
        case RibbonColorPart.ToolTipDarkBorder:
          this.ToolTipDarkBorder = color;
          break;
        case RibbonColorPart.ToolTipLightBorder:
          this.ToolTipLightBorder = color;
          break;
        case RibbonColorPart.ToolStripItemTextPressed:
          this.ToolStripItemTextPressed = color;
          break;
        case RibbonColorPart.ToolStripItemTextSelected:
          this.ToolStripItemTextSelected = color;
          break;
        case RibbonColorPart.ToolStripItemText:
          this.ToolStripItemText = color;
          break;
        case RibbonColorPart.ButtonChecked_2013:
          this.ButtonChecked_2013 = color;
          break;
        case RibbonColorPart.ButtonPressed_2013:
          this.ButtonPressed_2013 = color;
          break;
        case RibbonColorPart.ButtonSelected_2013:
          this.ButtonSelected_2013 = color;
          break;
        case RibbonColorPart.OrbButton_2013:
          this.OrbButton_2013 = color;
          break;
        case RibbonColorPart.OrbButtonSelected_2013:
          this.OrbButtonSelected_2013 = color;
          break;
        case RibbonColorPart.OrbButtonPressed_2013:
          this.OrbButtonPressed_2013 = color;
          break;
        case RibbonColorPart.TabText_2013:
          this.TabText_2013 = color;
          break;
        case RibbonColorPart.TabTextSelected_2013:
          this.TabTextSelected_2013 = color;
          break;
        case RibbonColorPart.PanelBorder_2013:
          this.PanelBorder_2013 = color;
          break;
        case RibbonColorPart.RibbonBackground_2013:
          this.RibbonBackground_2013 = color;
          break;
        case RibbonColorPart.TabCompleteBackground_2013:
          this.TabCompleteBackground_2013 = color;
          break;
        case RibbonColorPart.TabNormalBackground_2013:
          this.TabNormalBackground_2013 = color;
          break;
        case RibbonColorPart.TabActiveBackbround_2013:
          this.TabActiveBackbround_2013 = color;
          break;
        case RibbonColorPart.TabBorder_2013:
          this.TabBorder_2013 = color;
          break;
        case RibbonColorPart.TabCompleteBorder_2013:
          this.TabCompleteBorder_2013 = color;
          break;
        case RibbonColorPart.TabActiveBorder_2013:
          this.TabActiveBorder_2013 = color;
          break;
        case RibbonColorPart.OrbButtonText_2013:
          this.OrbButtonText_2013 = color;
          break;
        case RibbonColorPart.PanelText_2013:
          this.PanelText_2013 = color;
          break;
        case RibbonColorPart.RibbonItemText_2013:
          this.RibbonItemText_2013 = color;
          break;
        case RibbonColorPart.ToolTipText_2013:
          this.ToolTipText_2013 = color;
          break;
        case RibbonColorPart.ToolStripItemTextPressed_2013:
          this.ToolStripItemTextPressed_2013 = color;
          break;
        case RibbonColorPart.ToolStripItemTextSelected_2013:
          this.ToolStripItemTextSelected_2013 = color;
          break;
        case RibbonColorPart.ToolStripItemText_2013:
          this.ToolStripItemText_2013 = color;
          break;
      }
    }

    public string GetColorHexStr(RibbonColorPart ribbonColorPart)
    {
      Color color = this.GetColor(ribbonColorPart);
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.AppendFormat("#");
      stringBuilder.Append(BitConverter.ToString(new byte[1]
      {
        color.R
      }));
      stringBuilder.Append(BitConverter.ToString(new byte[1]
      {
        color.G
      }));
      stringBuilder.Append(BitConverter.ToString(new byte[1]
      {
        color.B
      }));
      return stringBuilder.ToString();
    }

    public string GetFullColorHexStr(RibbonColorPart ribbonColorPart)
    {
      Color color = this.GetColor(ribbonColorPart);
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.AppendFormat("#");
      stringBuilder.Append(BitConverter.ToString(new byte[1]
      {
        color.A
      }));
      stringBuilder.Append(BitConverter.ToString(new byte[1]
      {
        color.R
      }));
      stringBuilder.Append(BitConverter.ToString(new byte[1]
      {
        color.G
      }));
      stringBuilder.Append(BitConverter.ToString(new byte[1]
      {
        color.B
      }));
      return stringBuilder.ToString();
    }

    public Color GetColor(RibbonColorPart ribbonColorPart)
    {
      switch (ribbonColorPart)
      {
        case RibbonColorPart.OrbDropDownDarkBorder:
          return this.OrbDropDownDarkBorder;
        case RibbonColorPart.OrbDropDownLightBorder:
          return this.OrbDropDownLightBorder;
        case RibbonColorPart.OrbDropDownBack:
          return this.OrbDropDownBack;
        case RibbonColorPart.OrbDropDownNorthA:
          return this.OrbDropDownNorthA;
        case RibbonColorPart.OrbDropDownNorthB:
          return this.OrbDropDownNorthB;
        case RibbonColorPart.OrbDropDownNorthC:
          return this.OrbDropDownNorthC;
        case RibbonColorPart.OrbDropDownNorthD:
          return this.OrbDropDownNorthD;
        case RibbonColorPart.OrbDropDownSouthC:
          return this.OrbDropDownSouthC;
        case RibbonColorPart.OrbDropDownSouthD:
          return this.OrbDropDownSouthD;
        case RibbonColorPart.OrbDropDownContentbg:
          return this.OrbDropDownContentbg;
        case RibbonColorPart.OrbDropDownContentbglight:
          return this.OrbDropDownContentbglight;
        case RibbonColorPart.OrbDropDownSeparatorlight:
          return this.OrbDropDownSeparatorlight;
        case RibbonColorPart.OrbDropDownSeparatordark:
          return this.OrbDropDownSeparatordark;
        case RibbonColorPart.Caption1:
          return this.Caption1;
        case RibbonColorPart.Caption2:
          return this.Caption2;
        case RibbonColorPart.Caption3:
          return this.Caption3;
        case RibbonColorPart.Caption4:
          return this.Caption4;
        case RibbonColorPart.Caption5:
          return this.Caption5;
        case RibbonColorPart.Caption6:
          return this.Caption6;
        case RibbonColorPart.Caption7:
          return this.Caption7;
        case RibbonColorPart.QuickAccessBorderDark:
          return this.QuickAccessBorderDark;
        case RibbonColorPart.QuickAccessBorderLight:
          return this.QuickAccessBorderLight;
        case RibbonColorPart.QuickAccessUpper:
          return this.QuickAccessUpper;
        case RibbonColorPart.QuickAccessLower:
          return this.QuickAccessLower;
        case RibbonColorPart.OrbOptionBorder:
          return this.OrbOptionBorder;
        case RibbonColorPart.OrbOptionBackground:
          return this.OrbOptionBackground;
        case RibbonColorPart.OrbOptionShine:
          return this.OrbOptionShine;
        case RibbonColorPart.Arrow:
          return this.Arrow;
        case RibbonColorPart.ArrowLight:
          return this.ArrowLight;
        case RibbonColorPart.ArrowDisabled:
          return this.ArrowDisabled;
        case RibbonColorPart.Text:
          return this.Text;
        case RibbonColorPart.RibbonBackground:
          return this.RibbonBackground;
        case RibbonColorPart.TabBorder:
          return this.TabBorder;
        case RibbonColorPart.TabSelectedBorder:
          return this.TabSelectedBorder;
        case RibbonColorPart.TabNorth:
          return this.TabNorth;
        case RibbonColorPart.TabSouth:
          return this.TabSouth;
        case RibbonColorPart.TabGlow:
          return this.TabGlow;
        case RibbonColorPart.TabText:
          return this.TabText;
        case RibbonColorPart.TabActiveText:
          return this.TabActiveText;
        case RibbonColorPart.TabContentNorth:
          return this.TabContentNorth;
        case RibbonColorPart.TabContentSouth:
          return this.TabContentSouth;
        case RibbonColorPart.TabSelectedGlow:
          return this.TabSelectedGlow;
        case RibbonColorPart.PanelDarkBorder:
          return this.PanelDarkBorder;
        case RibbonColorPart.PanelLightBorder:
          return this.PanelLightBorder;
        case RibbonColorPart.PanelTextBackground:
          return this.PanelTextBackground;
        case RibbonColorPart.PanelTextBackgroundSelected:
          return this.PanelTextBackgroundSelected;
        case RibbonColorPart.PanelText:
          return this.PanelText;
        case RibbonColorPart.PanelBackgroundSelected:
          return this.PanelBackgroundSelected;
        case RibbonColorPart.PanelOverflowBackground:
          return this.PanelOverflowBackground;
        case RibbonColorPart.PanelOverflowBackgroundPressed:
          return this.PanelOverflowBackgroundPressed;
        case RibbonColorPart.PanelOverflowBackgroundSelectedNorth:
          return this.PanelOverflowBackgroundSelectedNorth;
        case RibbonColorPart.PanelOverflowBackgroundSelectedSouth:
          return this.PanelOverflowBackgroundSelectedSouth;
        case RibbonColorPart.ButtonBgOut:
          return this.ButtonBgOut;
        case RibbonColorPart.ButtonBgCenter:
          return this.ButtonBgCenter;
        case RibbonColorPart.ButtonBorderOut:
          return this.ButtonBorderOut;
        case RibbonColorPart.ButtonBorderIn:
          return this.ButtonBorderIn;
        case RibbonColorPart.ButtonGlossyNorth:
          return this.ButtonGlossyNorth;
        case RibbonColorPart.ButtonGlossySouth:
          return this.ButtonGlossySouth;
        case RibbonColorPart.ButtonDisabledBgOut:
          return this.ButtonDisabledBgOut;
        case RibbonColorPart.ButtonDisabledBgCenter:
          return this.ButtonDisabledBgCenter;
        case RibbonColorPart.ButtonDisabledBorderOut:
          return this.ButtonDisabledBorderOut;
        case RibbonColorPart.ButtonDisabledBorderIn:
          return this.ButtonDisabledBorderIn;
        case RibbonColorPart.ButtonDisabledGlossyNorth:
          return this.ButtonDisabledGlossyNorth;
        case RibbonColorPart.ButtonDisabledGlossySouth:
          return this.ButtonDisabledGlossySouth;
        case RibbonColorPart.ButtonSelectedBgOut:
          return this.ButtonSelectedBgOut;
        case RibbonColorPart.ButtonSelectedBgCenter:
          return this.ButtonSelectedBgCenter;
        case RibbonColorPart.ButtonSelectedBorderOut:
          return this.ButtonSelectedBorderOut;
        case RibbonColorPart.ButtonSelectedBorderIn:
          return this.ButtonSelectedBorderIn;
        case RibbonColorPart.ButtonSelectedGlossyNorth:
          return this.ButtonSelectedGlossyNorth;
        case RibbonColorPart.ButtonSelectedGlossySouth:
          return this.ButtonSelectedGlossySouth;
        case RibbonColorPart.ButtonPressedBgOut:
          return this.ButtonPressedBgOut;
        case RibbonColorPart.ButtonPressedBgCenter:
          return this.ButtonPressedBgCenter;
        case RibbonColorPart.ButtonPressedBorderOut:
          return this.ButtonPressedBorderOut;
        case RibbonColorPart.ButtonPressedBorderIn:
          return this.ButtonPressedBorderIn;
        case RibbonColorPart.ButtonPressedGlossyNorth:
          return this.ButtonPressedGlossyNorth;
        case RibbonColorPart.ButtonPressedGlossySouth:
          return this.ButtonPressedGlossySouth;
        case RibbonColorPart.ButtonCheckedBgOut:
          return this.ButtonCheckedBgOut;
        case RibbonColorPart.ButtonCheckedBgCenter:
          return this.ButtonCheckedBgCenter;
        case RibbonColorPart.ButtonCheckedBorderOut:
          return this.ButtonCheckedBorderOut;
        case RibbonColorPart.ButtonCheckedBorderIn:
          return this.ButtonCheckedBorderIn;
        case RibbonColorPart.ButtonCheckedGlossyNorth:
          return this.ButtonCheckedGlossyNorth;
        case RibbonColorPart.ButtonCheckedGlossySouth:
          return this.ButtonCheckedGlossySouth;
        case RibbonColorPart.ButtonCheckedSelectedBgOut:
          return this.ButtonCheckedSelectedBgOut;
        case RibbonColorPart.ButtonCheckedSelectedBgCenter:
          return this.ButtonCheckedSelectedBgCenter;
        case RibbonColorPart.ButtonCheckedSelectedBorderOut:
          return this.ButtonCheckedSelectedBorderOut;
        case RibbonColorPart.ButtonCheckedSelectedBorderIn:
          return this.ButtonCheckedSelectedBorderIn;
        case RibbonColorPart.ButtonCheckedSelectedGlossyNorth:
          return this.ButtonCheckedSelectedGlossyNorth;
        case RibbonColorPart.ButtonCheckedSelectedGlossySouth:
          return this.ButtonCheckedSelectedGlossySouth;
        case RibbonColorPart.ItemGroupOuterBorder:
          return this.ItemGroupOuterBorder;
        case RibbonColorPart.ItemGroupInnerBorder:
          return this.ItemGroupInnerBorder;
        case RibbonColorPart.ItemGroupSeparatorLight:
          return this.ItemGroupSeparatorLight;
        case RibbonColorPart.ItemGroupSeparatorDark:
          return this.ItemGroupSeparatorDark;
        case RibbonColorPart.ItemGroupBgNorth:
          return this.ItemGroupBgNorth;
        case RibbonColorPart.ItemGroupBgSouth:
          return this.ItemGroupBgSouth;
        case RibbonColorPart.ItemGroupBgGlossy:
          return this.ItemGroupBgGlossy;
        case RibbonColorPart.ButtonListBorder:
          return this.ButtonListBorder;
        case RibbonColorPart.ButtonListBg:
          return this.ButtonListBg;
        case RibbonColorPart.ButtonListBgSelected:
          return this.ButtonListBgSelected;
        case RibbonColorPart.DropDownBg:
          return this.DropDownBg;
        case RibbonColorPart.DropDownImageBg:
          return this.DropDownImageBg;
        case RibbonColorPart.DropDownImageSeparator:
          return this.DropDownImageSeparator;
        case RibbonColorPart.DropDownBorder:
          return this.DropDownBorder;
        case RibbonColorPart.DropDownGripNorth:
          return this.DropDownGripNorth;
        case RibbonColorPart.DropDownGripSouth:
          return this.DropDownGripSouth;
        case RibbonColorPart.DropDownGripBorder:
          return this.DropDownGripBorder;
        case RibbonColorPart.DropDownGripDark:
          return this.DropDownGripDark;
        case RibbonColorPart.DropDownGripLight:
          return this.DropDownGripLight;
        case RibbonColorPart.DropDownCheckedButtonGlyphBg:
          return this.DropDownCheckedButtonGlyphBg;
        case RibbonColorPart.DropDownCheckedButtonGlyphBorder:
          return this.DropDownCheckedButtonGlyphBorder;
        case RibbonColorPart.SeparatorLight:
          return this.SeparatorLight;
        case RibbonColorPart.SeparatorDark:
          return this.SeparatorDark;
        case RibbonColorPart.QATSeparatorLight:
          return this.QATSeparatorLight;
        case RibbonColorPart.QATSeparatorDark:
          return this.QATSeparatorDark;
        case RibbonColorPart.SeparatorBg:
          return this.SeparatorBg;
        case RibbonColorPart.SeparatorLine:
          return this.SeparatorLine;
        case RibbonColorPart.TextBoxUnselectedBg:
          return this.TextBoxUnselectedBg;
        case RibbonColorPart.TextBoxBorder:
          return this.TextBoxBorder;
        case RibbonColorPart.ToolTipContentNorth:
          return this.ToolTipContentNorth;
        case RibbonColorPart.ToolTipContentSouth:
          return this.ToolTipContentSouth;
        case RibbonColorPart.ToolTipDarkBorder:
          return this.ToolTipDarkBorder;
        case RibbonColorPart.ToolTipLightBorder:
          return this.ToolTipLightBorder;
        case RibbonColorPart.ToolStripItemTextPressed:
          return this.ToolStripItemTextPressed;
        case RibbonColorPart.ToolStripItemTextSelected:
          return this.ToolStripItemTextSelected;
        case RibbonColorPart.ToolStripItemText:
          return this.ToolStripItemText;
        case RibbonColorPart.ButtonPressed_2013:
          return this.ButtonPressed_2013;
        case RibbonColorPart.ButtonSelected_2013:
          return this.ButtonSelected_2013;
        case RibbonColorPart.OrbButton_2013:
          return this.OrbButton_2013;
        case RibbonColorPart.OrbButtonSelected_2013:
          return this.OrbButtonSelected_2013;
        case RibbonColorPart.OrbButtonPressed_2013:
          return this.OrbButtonPressed_2013;
        case RibbonColorPart.TabText_2013:
          return this.TabText_2013;
        case RibbonColorPart.TabTextSelected_2013:
          return this.TabTextSelected_2013;
        case RibbonColorPart.PanelBorder_2013:
          return this.PanelBorder_2013;
        case RibbonColorPart.RibbonBackground_2013:
          return this.RibbonBackground_2013;
        case RibbonColorPart.TabCompleteBackground_2013:
          return this.TabCompleteBackground_2013;
        case RibbonColorPart.TabNormalBackground_2013:
          return this.TabNormalBackground_2013;
        case RibbonColorPart.TabActiveBackbround_2013:
          return this.TabActiveBackbround_2013;
        case RibbonColorPart.TabBorder_2013:
          return this.TabBorder_2013;
        case RibbonColorPart.TabCompleteBorder_2013:
          return this.TabCompleteBorder_2013;
        case RibbonColorPart.TabActiveBorder_2013:
          return this.TabActiveBorder_2013;
        case RibbonColorPart.OrbButtonText_2013:
          return this.OrbButtonText_2013;
        case RibbonColorPart.PanelText_2013:
          return this.PanelText_2013;
        case RibbonColorPart.RibbonItemText_2013:
          return this.RibbonItemText_2013;
        case RibbonColorPart.ToolTipText_2013:
          return this.ToolTipText_2013;
        case RibbonColorPart.ToolStripItemTextPressed_2013:
          return this.ToolStripItemTextPressed_2013;
        case RibbonColorPart.ToolStripItemTextSelected_2013:
          return this.ToolStripItemTextSelected_2013;
        case RibbonColorPart.ToolStripItemText_2013:
          return this.ToolStripItemText_2013;
        default:
          return Color.White;
      }
    }

    public string WriteThemeIniFile()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.AppendLine("[Properties]");
      stringBuilder.AppendLine("ThemeName = " + this.ThemeName);
      stringBuilder.AppendLine("Author = " + this.ThemeAuthor);
      stringBuilder.AppendLine("AuthorEmail = " + this.ThemeAuthorEmail);
      stringBuilder.AppendLine("AuthorWebsite = " + this.ThemeAuthorWebsite);
      stringBuilder.AppendLine("DateCreated = " + this.ThemeDateCreated);
      stringBuilder.AppendLine();
      stringBuilder.AppendLine("[ColorTable]");
      int length = Enum.GetNames(typeof (RibbonColorPart)).Length;
      for (int index = 0; index < length; ++index)
        stringBuilder.AppendLine(((RibbonColorPart) index).ToString() + " = " + this.GetFullColorHexStr((RibbonColorPart) index));
      return stringBuilder.ToString();
    }

    public void ReadThemeIniFile(string iniFileContent)
    {
      string[] strArray1;
      if (iniFileContent.Contains("\r\n"))
        strArray1 = iniFileContent.Split(new string[1]
        {
          "\r\n"
        }, StringSplitOptions.None);
      else
        strArray1 = iniFileContent.Contains("\n") ? iniFileContent.Split(new string[1]
        {
          "\n"
        }, StringSplitOptions.None) : throw new ArgumentException("Unrecognized end line delimeter.");
      Dictionary<string, RibbonColorPart> dictionary = new Dictionary<string, RibbonColorPart>();
      foreach (RibbonColorPart ribbonColorPart in Enum.GetValues(typeof (RibbonColorPart)))
        dictionary[ribbonColorPart.ToString().ToLower()] = ribbonColorPart;
      foreach (string str1 in strArray1)
      {
        string str2 = str1.Trim();
        if (str2.Length != 0)
        {
          string[] strArray2 = str2.Split('=');
          if (strArray2.Length == 2)
          {
            string lower = strArray2[0].Trim().ToLower();
            string hexColor = strArray2[1].Trim();
            if (lower == "author")
              this.ThemeAuthor = hexColor;
            else if (lower == "authorwebsite")
              this.ThemeAuthorWebsite = hexColor;
            else if (lower == "authoremail")
              this.ThemeAuthorEmail = hexColor;
            else if (lower == "datecreated")
              this.ThemeDateCreated = hexColor;
            else if (lower == "themename")
              this.ThemeName = hexColor;
            else if (dictionary.ContainsKey(lower))
              this.SetColor(dictionary[lower], hexColor);
          }
        }
      }
    }

    public string WriteThemeXmlFile()
    {
      StringWriter stringWriter;
      using (XmlTextWriter xmlTextWriter = new XmlTextWriter((TextWriter) (stringWriter = new StringWriter())))
      {
        xmlTextWriter.WriteStartDocument();
        xmlTextWriter.WriteWhitespace("\r\n");
        xmlTextWriter.WriteStartElement("RibbonColorTheme");
        xmlTextWriter.WriteWhitespace("\r\n\t");
        xmlTextWriter.WriteStartElement("Properties");
        xmlTextWriter.WriteWhitespace("\r\n\t\t");
        xmlTextWriter.WriteElementString("ThemeName", this.ThemeName);
        xmlTextWriter.WriteWhitespace("\r\n\t\t");
        xmlTextWriter.WriteElementString("Author", this.ThemeAuthor);
        xmlTextWriter.WriteWhitespace("\r\n\t\t");
        xmlTextWriter.WriteElementString("AuthorEmail", this.ThemeAuthorEmail);
        xmlTextWriter.WriteWhitespace("\r\n\t\t");
        xmlTextWriter.WriteElementString("AuthorWebsite", this.ThemeAuthorWebsite);
        xmlTextWriter.WriteWhitespace("\r\n\t\t");
        xmlTextWriter.WriteElementString("DateCreated", this.ThemeDateCreated);
        xmlTextWriter.WriteWhitespace("\r\n\t");
        xmlTextWriter.WriteEndElement();
        xmlTextWriter.WriteWhitespace("\r\n\t");
        xmlTextWriter.WriteStartElement("ColorTable");
        int length = Enum.GetNames(typeof (RibbonColorPart)).Length;
        for (int index = 0; index < length; ++index)
        {
          xmlTextWriter.WriteWhitespace("\r\n\t\t");
          xmlTextWriter.WriteElementString(((RibbonColorPart) index).ToString(), this.GetFullColorHexStr((RibbonColorPart) index));
        }
        xmlTextWriter.WriteWhitespace("\r\n\t");
        xmlTextWriter.WriteEndElement();
        xmlTextWriter.WriteWhitespace("\r\n");
        xmlTextWriter.WriteEndElement();
        xmlTextWriter.WriteWhitespace("\r\n");
        xmlTextWriter.WriteEndDocument();
        return stringWriter.ToString();
      }
    }

    public void ReadThemeXmlFile(string xmlFileContent)
    {
      Dictionary<string, RibbonColorPart> dictionary = new Dictionary<string, RibbonColorPart>();
      foreach (RibbonColorPart ribbonColorPart in Enum.GetValues(typeof (RibbonColorPart)))
        dictionary[ribbonColorPart.ToString().ToLower()] = ribbonColorPart;
      using (XmlTextReader xmlTextReader = new XmlTextReader((TextReader) new StringReader(xmlFileContent)))
      {
        while (xmlTextReader.Read())
        {
          switch (xmlTextReader.Name)
          {
            case "ThemeName":
              this.ThemeName = xmlTextReader.ReadString();
              continue;
            case "Author":
              this.ThemeAuthor = xmlTextReader.ReadString();
              continue;
            case "AuthorEmail":
              this.ThemeAuthorEmail = xmlTextReader.ReadString();
              continue;
            case "AuthorWebsite":
              this.ThemeAuthorWebsite = xmlTextReader.ReadString();
              continue;
            case "DateCreated":
              this.ThemeDateCreated = xmlTextReader.ReadString();
              continue;
            default:
              if (dictionary.ContainsKey(xmlTextReader.Name.ToLower()))
              {
                this.SetColor(dictionary[xmlTextReader.Name.ToLower()], xmlTextReader.ReadString());
                continue;
              }
              continue;
          }
        }
      }
    }
  }
}
