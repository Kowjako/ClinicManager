// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.Theme
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

namespace System.Windows.Forms
{
  public class Theme
  {
    private static Theme _Default;
    private RibbonTheme _Theme;

    public static Theme Standard
    {
      get
      {
        if (Theme._Default == null)
          Theme._Default = new Theme();
        return Theme._Default;
      }
    }

    public static bool StandardThemeIsGlobal { get; set; } = true;

    public Theme()
    {
    }

    public Theme(RibbonOrbStyle style) => this.Style = style;

    public Theme(RibbonOrbStyle style, RibbonTheme theme)
      : this(style)
    {
      this.RibbonTheme = theme;
    }

    public Theme(RibbonOrbStyle style, RibbonProfesionalRendererColorTable colorTable)
      : this(style)
    {
      this.RendererColorTable = colorTable;
    }

    public RibbonProfesionalRendererColorTable RendererColorTable { get; set; } = new RibbonProfesionalRendererColorTable();

    public RibbonOrbStyle Style { get; set; }

    public RibbonTheme RibbonTheme
        {
            get => this._Theme;
            set
            {
                this._Theme = value;
                if (this._Theme == RibbonTheme.Blue || this._Theme == RibbonTheme.Normal)
                    this.RendererColorTable = new RibbonProfesionalRendererColorTable();
                else if (this._Theme == RibbonTheme.Black)
                    this.RendererColorTable = (RibbonProfesionalRendererColorTable)new RibbonProfesionalRendererColorTableBlack();
                else if (this._Theme == RibbonTheme.Blue_2010)
                    this.RendererColorTable = (RibbonProfesionalRendererColorTable)new RibbonProfesionalRendererColorTableBlue2010();
                else if (this._Theme == RibbonTheme.Green)
                    this.RendererColorTable = (RibbonProfesionalRendererColorTable)new RibbonProfesionalRendererColorTableGreen();
                else if (this._Theme == RibbonTheme.Purple)
                    this.RendererColorTable = (RibbonProfesionalRendererColorTable)new RibbonProfesionalRendererColorTablePurple();
                else if (this._Theme == RibbonTheme.JellyBelly)
                {
                    this.RendererColorTable = (RibbonProfesionalRendererColorTable)new RibbonProfesionalRendererColorTableJellyBelly();
                }
                else if (this._Theme == RibbonTheme.KovyakoTheme)
                {
                    this.RendererColorTable = (RibbonProfesionalRendererColorTable)new RibbonProfesionalRendererColorTableKovyako();
                }
                else
                {
                    if (this._Theme != RibbonTheme.Halloween)
                        return;
                    this.RendererColorTable = (RibbonProfesionalRendererColorTable)new RibbonProfesionalRendererColorTableHalloween();
                }
            }
        }

    [Obsolete("Either create a theme for your Ribbon or use 'Standard' instance!")]
    public static RibbonProfesionalRendererColorTable ColorTable
    {
      get => Theme.Standard.RendererColorTable;
      set => Theme.Standard.RendererColorTable = value;
    }

    [Obsolete("Either create a theme for your Ribbon or use 'Standard' instance!")]
    public static RibbonOrbStyle ThemeStyle
    {
      get => Theme.Standard.Style;
      set => Theme.Standard.Style = value;
    }

    [Obsolete("Either create a theme for your Ribbon or use 'Standard' instance!")]
    public RibbonTheme ThemeColor
    {
      get => Theme.Standard.RibbonTheme;
      set => Theme.Standard.RibbonTheme = value;
    }
  }
}
