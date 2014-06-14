// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.Resources.Strings.CustomMessageBoxStrings
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
  [CompilerGenerated]
  [DebuggerNonUserCode]
  internal class CustomMessageBoxStrings
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) CustomMessageBoxStrings.resourceMan, (object) null))
          CustomMessageBoxStrings.resourceMan = new ResourceManager("Intel.Mobile.WiMAXCU.UI.Dashboard.Resources.Strings.CustomMessageBoxStrings", typeof (CustomMessageBoxStrings).Assembly);
        return CustomMessageBoxStrings.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return CustomMessageBoxStrings.resourceCulture;
      }
      set
      {
        CustomMessageBoxStrings.resourceCulture = value;
      }
    }

    internal static string Cancel
    {
      get
      {
        return CustomMessageBoxStrings.ResourceManager.GetString("Cancel", CustomMessageBoxStrings.resourceCulture);
      }
    }

    internal static string DontShowThisMessageAgain
    {
      get
      {
        return CustomMessageBoxStrings.ResourceManager.GetString("DontShowThisMessageAgain", CustomMessageBoxStrings.resourceCulture);
      }
    }

    internal static string No
    {
      get
      {
        return CustomMessageBoxStrings.ResourceManager.GetString("No", CustomMessageBoxStrings.resourceCulture);
      }
    }

    internal static string Ok
    {
      get
      {
        return CustomMessageBoxStrings.ResourceManager.GetString("Ok", CustomMessageBoxStrings.resourceCulture);
      }
    }

    internal static string RemindMeLater
    {
      get
      {
        return CustomMessageBoxStrings.ResourceManager.GetString("RemindMeLater", CustomMessageBoxStrings.resourceCulture);
      }
    }

    internal static string Yes
    {
      get
      {
        return CustomMessageBoxStrings.ResourceManager.GetString("Yes", CustomMessageBoxStrings.resourceCulture);
      }
    }

    internal CustomMessageBoxStrings()
    {
    }
  }
}
