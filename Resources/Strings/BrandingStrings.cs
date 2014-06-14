// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.Resources.Strings.BrandingStrings
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard.Resources.Strings
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class BrandingStrings
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) BrandingStrings.resourceMan, (object) null))
          BrandingStrings.resourceMan = new ResourceManager("Intel.Mobile.WiMAXCU.UI.Dashboard.Resources.Strings.BrandingStrings", typeof (BrandingStrings).Assembly);
        return BrandingStrings.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return BrandingStrings.resourceCulture;
      }
      set
      {
        BrandingStrings.resourceCulture = value;
      }
    }

    internal static string Branding_ImageIntelURL
    {
      get
      {
        return BrandingStrings.ResourceManager.GetString("Branding_ImageIntelURL", BrandingStrings.resourceCulture);
      }
    }

    internal static string HTTPPrefix
    {
      get
      {
        return BrandingStrings.ResourceManager.GetString("HTTPPrefix", BrandingStrings.resourceCulture);
      }
    }

    internal BrandingStrings()
    {
    }
  }
}
