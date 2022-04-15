// Decompiled with JetBrains decompiler
// Type: System.Windows.Forms.StringFormatFactory
// Assembly: System.Windows.Forms.Ribbon, Version=2.0.0.0, Culture=neutral, PublicKeyToken=928736e248aa81f9
// MVID: 3A8D9A15-4A89-4889-BF77-7DC4CDB17624
// Assembly location: C:\Users\123\.nuget\packages\ribbonwinforms\5.0.1.1\lib\net48\System.Windows.Forms.Ribbon.dll

using System.Drawing;

namespace System.Windows.Forms
{
  internal static class StringFormatFactory
  {
    public static StringFormat NearCenter() => new StringFormat()
    {
      Alignment = StringAlignment.Near,
      LineAlignment = StringAlignment.Center
    };

    public static StringFormat NearCenterNoWrap(StringTrimming trim)
    {
      StringFormat stringFormat = StringFormatFactory.NearCenter();
      stringFormat.Trimming = trim;
      stringFormat.FormatFlags |= StringFormatFlags.NoWrap;
      return stringFormat;
    }

    public static StringFormat CenterNearTrimChar() => new StringFormat()
    {
      Alignment = StringAlignment.Center,
      LineAlignment = StringAlignment.Near,
      Trimming = StringTrimming.Character
    };

    public static StringFormat Center() => new StringFormat()
    {
      Alignment = StringAlignment.Center,
      LineAlignment = StringAlignment.Center
    };

    public static StringFormat Center(StringTrimming trim)
    {
      StringFormat stringFormat = StringFormatFactory.Center();
      stringFormat.Trimming = trim;
      return stringFormat;
    }

    public static StringFormat CenterNoWrap(StringTrimming trim)
    {
      StringFormat stringFormat = StringFormatFactory.Center(trim);
      stringFormat.FormatFlags |= StringFormatFlags.NoWrap;
      return stringFormat;
    }

    public static StringFormat CenterNoWrapTrimEllipsis() => StringFormatFactory.CenterNoWrap(StringTrimming.EllipsisCharacter);
  }
}
