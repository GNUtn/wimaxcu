// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.AdvancedDlgStringHelper
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using System.Reflection;
using System.Resources;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public static class AdvancedDlgStringHelper
  {
    private static ResourceManager m_rm = new ResourceManager("Intel.Mobile.WiMAXCU.UI.Dashboard.Resources.Strings.AdvancedDialogStrings", Assembly.GetExecutingAssembly());

    static AdvancedDlgStringHelper()
    {
    }

    public static string GetString(string str)
    {
      return AdvancedDlgStringHelper.m_rm.GetString(str);
    }
  }
}
