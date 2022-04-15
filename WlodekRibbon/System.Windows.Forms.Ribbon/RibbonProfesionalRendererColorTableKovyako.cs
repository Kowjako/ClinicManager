using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Windows.Forms
{
    public class RibbonProfesionalRendererColorTableKovyako : RibbonProfesionalRendererColorTable
    {
        public RibbonProfesionalRendererColorTableKovyako()
        {
            this.ThemeName = "KOWJAKO";
            this.ThemeAuthor = "Włodzimierz Kowjako";
            this.ThemeAuthorWebsite = "";
            this.ThemeAuthorEmail = "";
            this.ThemeDateCreated = "15 Apr 2022";
            this.OrbDropDownDarkBorder = this.FromHex("#9BAFCA");
            this.OrbDropDownLightBorder = this.FromHex("#FFFFFF");
            this.OrbDropDownBack = this.FromHex("#BFD3EB");
            this.OrbDropDownNorthA = this.FromHex("#D7E5F7");
            this.OrbDropDownNorthB = this.FromHex("#D4E1F3");
            this.OrbDropDownNorthC = this.FromHex("#C6D8EE");
            this.OrbDropDownNorthD = this.FromHex("#B7CAE6");
            this.OrbDropDownSouthC = this.FromHex("#B0C9EA");
            this.OrbDropDownSouthD = this.FromHex("#CFE0F5");
            this.OrbDropDownContentbg = this.FromHex("#E9EAEE");
            this.OrbDropDownContentbglight = this.FromHex("#FAFAFA");
            this.OrbDropDownSeparatorlight = this.FromHex("#F5F5F5");
            this.OrbDropDownSeparatordark = this.FromHex("#C5C5C5");
            this.Caption1 = this.FromHex("#E3EBF6");
            this.Caption2 = this.FromHex("#DAE9FD");
            this.Caption3 = this.FromHex("#D5E5FA");
            this.Caption4 = this.FromHex("#D9E7F9");
            this.Caption5 = this.FromHex("#CADEF7");
            this.Caption6 = this.FromHex("#E4EFFD");
            this.Caption7 = this.FromHex("#B0CFF7");
            this.QuickAccessBorderDark = this.FromHex("#B6CAE2");
            this.QuickAccessBorderLight = this.FromHex("#F2F6FB");
            this.QuickAccessUpper = this.FromHex("#E0EBF9");
            this.QuickAccessLower = this.FromHex("#C9D9EE");
            this.OrbOptionBorder = this.FromHex("#7793B9");
            this.OrbOptionBackground = this.FromHex("#E8F1FC");
            this.OrbOptionShine = this.FromHex("#D2E1F4");
            this.Arrow = this.FromHex("#797C80");
            this.ArrowLight = Color.FromArgb(200, this.FromHex("#FFFFFF"));
            this.ArrowDisabled = this.FromHex("#B7B7B7");
            this.Text = this.FromHex("#000000");

            //Ribbon header
            this.RibbonBackground = this.FromHex("#FFFFFF");


            //Ribbon border color
            this.TabBorder = this.FromHex("#A0A0A0");
            this.TabSelectedBorder = this.FromHex("#B266FF");
            this.TabNorth = this.FromHex("#FFFFFF");
            this.TabSouth = this.FromHex("#FFFFFF");
            this.TabGlow = this.FromHex("#FFFFFF");

            //Ribbon not selected tab foreground
            this.TabText = this.FromHex("#000000");
            this.TabActiveText = this.FromHex("#15428B");

            //Ribbon button gradient
            this.TabContentNorth = this.FromHex("#FFFFFF");
            this.TabContentSouth = this.FromHex("#FFFFFF");
            this.TabSelectedGlow = this.FromHex("#E1D2A5");

            //Separator gradient
            this.PanelDarkBorder = this.FromHex("#000000");
            this.PanelLightBorder = Color.FromArgb((int)sbyte.MaxValue, this.FromHex("#FFFFFF"));
            this.PanelTextBackground = this.FromHex("#000000");
            this.PanelTextBackgroundSelected = this.FromHex("#FFFFFF");

            //Panel caption text below
            this.PanelText = this.FromHex("#000000");
            this.PanelBackgroundSelected = Color.FromArgb(110, this.FromHex("#FFFFFF"));
            this.PanelOverflowBackground = this.FromHex("#B9D1F0");
            this.PanelOverflowBackgroundPressed = this.FromHex("#7699C8");
            this.PanelOverflowBackgroundSelectedNorth = Color.FromArgb(100, this.FromHex("#FFFFFF"));
            this.PanelOverflowBackgroundSelectedSouth = Color.FromArgb(102, this.FromHex("#B8D7FD"));


            this.ButtonBgOut = this.FromHex("#C1D5F1");
            this.ButtonBgCenter = this.FromHex("#CFE0F7");

            this.ButtonBorderOut = this.FromHex("#0000CC");
            this.ButtonBorderIn = this.FromHex("#0000CC");
            this.ButtonGlossyNorth = this.FromHex("#0000CC");
            this.ButtonGlossySouth = this.FromHex("#CBDEF6");
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
            this.ButtonCheckedBgOut = this.FromHex("#FFD86B");
            this.ButtonCheckedBgCenter = this.FromHex("#FFF480");
            this.ButtonCheckedBorderOut = this.FromHex("#C2963D");
            this.ButtonCheckedBorderIn = Color.FromArgb(0, this.FromHex("#F9C65A"));
            this.ButtonCheckedGlossyNorth = this.FromHex("#FFE575");
            this.ButtonCheckedGlossySouth = Color.FromArgb(0, this.FromHex("#FFDA6D"));
            this.ButtonCheckedSelectedBgOut = this.FromHex("#F9AA45");
            this.ButtonCheckedSelectedBgCenter = this.FromHex("#FDEA9D");
            this.ButtonCheckedSelectedBorderOut = this.FromHex("#8E8165");
            this.ButtonCheckedSelectedBorderIn = this.FromHex("#F9C65A");
            this.ButtonCheckedSelectedGlossyNorth = this.FromHex("#F8DBB7");
            this.ButtonCheckedSelectedGlossySouth = this.FromHex("#FED18E");
            this.ItemGroupOuterBorder = this.FromHex("#9EBAE1");
            this.ItemGroupInnerBorder = Color.FromArgb(51, this.FromHex("#FFFFFF"));
            this.ItemGroupSeparatorLight = Color.FromArgb(64, this.FromHex("#FFFFFF"));
            this.ItemGroupSeparatorDark = Color.FromArgb(38, this.FromHex("#9EBAE1"));
            this.ItemGroupBgNorth = this.FromHex("#CADCF0");
            this.ItemGroupBgSouth = this.FromHex("#D0E1F7");
            this.ItemGroupBgGlossy = this.FromHex("#BCD0E9");
            this.ButtonListBorder = this.FromHex("#B9D0ED");
            this.ButtonListBg = this.FromHex("#D4E6F8");
            this.ButtonListBgSelected = this.FromHex("#ECF3FB");
            this.DropDownBg = this.FromHex("#FFFFFF");
            this.DropDownImageBg = this.FromHex("#FFFFFF");
            this.DropDownImageSeparator = this.FromHex("#E2E4E7");
            this.DropDownBorder = this.FromHex("#A7ABB0");
            this.DropDownGripNorth = this.FromHex("#FFFFFF");
            this.DropDownGripSouth = this.FromHex("#DFE9EF");
            this.DropDownGripBorder = this.FromHex("#DDE7EE");
            this.DropDownGripDark = this.FromHex("#5574A7");
            this.DropDownGripLight = this.FromHex("#FFFFFF");
            this.DropDownCheckedButtonGlyphBg = this.FromHex("#FCF1C2");
            this.DropDownCheckedButtonGlyphBorder = this.FromHex("#F29536");
            this.SeparatorLight = Color.FromArgb(140, this.FromHex("#FFFFFF"));
            this.SeparatorDark = this.FromHex("#91A6C2");
            this.QATSeparatorLight = Color.FromArgb(95, this.FromHex("#FFFFFF"));
            this.QATSeparatorDark = this.FromHex("#999B9E");
            this.SeparatorBg = this.FromHex("#DAE6EE");
            this.SeparatorLine = this.FromHex("#C5C5C5");
            this.TextBoxUnselectedBg = this.FromHex("#EAF2FB");
            this.TextBoxBorder = this.FromHex("#ABC1DE");
            this.ToolTipContentNorth = this.FromHex("#FAFCFE");
            this.ToolTipContentSouth = this.FromHex("#CEDCF1");
            this.ToolTipDarkBorder = this.FromHex("#A9A9A9");
            this.ToolTipLightBorder = Color.FromArgb(102, this.FromHex("#FFFFFF"));
            this.ToolStripItemTextPressed = this.FromHex("#444444");
            this.ToolStripItemTextSelected = this.FromHex("#444444");
            this.ToolStripItemText = this.FromHex("#444444");
            this.clrVerBG_Shadow = this.FromHex("#FFFFFF");
            this.ButtonChecked_2013 = this.FromHex("#FFFFFF");
            this.ButtonPressed_2013 = this.FromHex("#92C0E0");
            this.ButtonSelected_2013 = this.FromHex("#CDE6F7");

            this.OrbButton_2013 = this.FromHex("#0072C6");
            this.OrbButtonSelected_2013 = this.FromHex("#2A8AD4");
            this.OrbButtonPressed_2013 = this.FromHex("#2A8AD4");
            this.TabText_2013 = this.FromHex("#0072C6");
            this.TabTextSelected_2013 = this.FromHex("#444444");
            this.PanelBorder_2013 = this.FromHex("#15428B");


            this.RibbonBackground_2013 = this.FromHex("#FFFFFF");
            this.TabCompleteBackground_2013 = this.FromHex("#FFFFFF");
            this.TabNormalBackground_2013 = this.FromHex("#FFFFFF");
            this.TabActiveBackbround_2013 = this.FromHex("#FFFFFF");
            this.TabBorder_2013 = this.FromHex("#FFFFFF");




            this.TabCompleteBorder_2013 = this.FromHex("#D4D4D4");
            this.TabActiveBorder_2013 = this.FromHex("#D4D4D4");
            this.OrbButtonText_2013 = this.FromHex("#FFFFFF");
            this.PanelText_2013 = this.FromHex("#666666");
            this.RibbonItemText_2013 = this.FromHex("#444444");
            this.ToolTipText_2013 = this.FromHex("#262626");
            this.ToolStripItemTextPressed_2013 = this.FromHex("#444444");
            this.ToolStripItemTextSelected_2013 = this.FromHex("#444444");
            this.ToolStripItemText_2013 = this.FromHex("#444444");
        }
    }
}
