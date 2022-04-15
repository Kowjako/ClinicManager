// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.RibbonRenderer
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Drawing;
using System.Drawing.Imaging;

namespace System.Windows.Forms
{
  public class RibbonRenderer
  {
    private static ColorMatrix _disabledImageColorMatrix;

    private static ColorMatrix DisabledImageColorMatrix
    {
      get
      {
        if (RibbonRenderer._disabledImageColorMatrix == null)
        {
          float[][] matrix2 = new float[5][]
          {
            new float[5]{ 0.2125f, 0.2125f, 0.2125f, 0.0f, 0.0f },
            new float[5]{ 0.2577f, 0.2577f, 0.2577f, 0.0f, 0.0f },
            new float[5]{ 0.0361f, 0.0361f, 0.0361f, 0.0f, 0.0f },
            null,
            null
          };
          float[] numArray = new float[5]
          {
            0.0f,
            0.0f,
            0.0f,
            1f,
            0.0f
          };
          matrix2[3] = numArray;
          matrix2[4] = new float[5]
          {
            0.38f,
            0.38f,
            0.38f,
            0.0f,
            1f
          };
          RibbonRenderer._disabledImageColorMatrix = RibbonRenderer.MultiplyColorMatrix(new float[5][]
          {
            new float[5]{ 1f, 0.0f, 0.0f, 0.0f, 0.0f },
            new float[5]{ 0.0f, 1f, 0.0f, 0.0f, 0.0f },
            new float[5]{ 0.0f, 0.0f, 1f, 0.0f, 0.0f },
            new float[5]{ 0.0f, 0.0f, 0.0f, 0.7f, 0.0f },
            new float[5]
          }, matrix2);
        }
        return RibbonRenderer._disabledImageColorMatrix;
      }
    }

    internal static ColorMatrix MultiplyColorMatrix(float[][] matrix1, float[][] matrix2)
    {
      int length = 5;
      float[][] newColorMatrix = new float[length][];
      for (int index = 0; index < length; ++index)
        newColorMatrix[index] = new float[length];
      float[] numArray1 = new float[length];
      for (int index1 = 0; index1 < length; ++index1)
      {
        for (int index2 = 0; index2 < length; ++index2)
          numArray1[index2] = matrix1[index2][index1];
        for (int index3 = 0; index3 < length; ++index3)
        {
          float[] numArray2 = matrix2[index3];
          float num = 0.0f;
          for (int index4 = 0; index4 < length; ++index4)
            num += numArray2[index4] * numArray1[index4];
          newColorMatrix[index3][index1] = num;
        }
      }
      return new ColorMatrix(newColorMatrix);
    }

    public static Image CreateDisabledImage(Image normalImage)
    {
      ImageAttributes imageAttr = new ImageAttributes();
      imageAttr.ClearColorKey();
      imageAttr.SetColorMatrix(RibbonRenderer.DisabledImageColorMatrix);
      Size size = normalImage.Size;
      Bitmap bitmap = new Bitmap(size.Width, size.Height);
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      graphics.DrawImage(normalImage, new Rectangle(0, 0, size.Width, size.Height), 0, 0, size.Width, size.Height, GraphicsUnit.Pixel, imageAttr);
      graphics.Dispose();
      return (Image) bitmap;
    }

    public virtual void OnRenderOrbDropDownBackground(RibbonOrbDropDownEventArgs e)
    {
    }

    public virtual void OnRenderRibbonCaptionBar(RibbonRenderEventArgs e)
    {
    }

    public virtual void OnRenderRibbonOrb(RibbonRenderEventArgs e)
    {
    }

    public virtual void OnRenderRibbonQuickAccessToolbarBackground(RibbonRenderEventArgs e)
    {
    }

    public virtual void OnRenderRibbonBackground(RibbonRenderEventArgs e)
    {
    }

    public virtual void OnRenderRibbonTab(RibbonTabRenderEventArgs e)
    {
    }

    public virtual void OnRenderRibbonContext(RibbonContextRenderEventArgs e)
    {
    }

    public virtual void OnRenderRibbonItem(RibbonItemRenderEventArgs e)
    {
    }

    public virtual void OnRenderRibbonTabContentBackground(RibbonTabRenderEventArgs e)
    {
    }

    public virtual void OnRenderRibbonPanelBackground(RibbonPanelRenderEventArgs e)
    {
    }

    public virtual void OnRenderRibbonTabText(RibbonTabRenderEventArgs e)
    {
    }

    public virtual void OnRenderRibbonContextText(RibbonContextRenderEventArgs e)
    {
    }

    public virtual void OnRenderRibbonItemText(RibbonTextEventArgs e)
    {
    }

    public virtual void OnRenderRibbonItemBorder(RibbonItemRenderEventArgs e)
    {
    }

    public virtual void OnRenderRibbonItemImage(RibbonItemBoundsEventArgs e)
    {
    }

    public virtual void OnRenderRibbonPanelText(RibbonPanelRenderEventArgs e)
    {
    }

    public virtual void OnRenderDropDownBackground(RibbonCanvasEventArgs e)
    {
    }

    public virtual void OnRenderDropDownDropDownImageSeparator(
      RibbonItem item,
      RibbonCanvasEventArgs e)
    {
    }

    public virtual void OnRenderPanelPopupBackground(RibbonCanvasEventArgs e)
    {
    }

    public virtual void OnRenderTabScrollButtons(RibbonTabRenderEventArgs e)
    {
    }

    public virtual void OnRenderScrollbar(Graphics g, Control item, Ribbon ribbon)
    {
    }

    public virtual void OnRenderToolTipBackground(RibbonToolTipRenderEventArgs e)
    {
    }

    public virtual void OnRenderToolTipText(RibbonToolTipRenderEventArgs e)
    {
    }

    public virtual void OnRenderToolTipImage(RibbonToolTipRenderEventArgs e)
    {
    }
  }
}
