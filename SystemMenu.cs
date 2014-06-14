// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.SystemMenu
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using System;
using System.Runtime.InteropServices;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class SystemMenu
  {
    private const int MF_SEPARATOR = 2048;
    private const int MF_BYPOSITION = 1024;
    private const int MF_STRING = 0;
    public const int AboutMenuID = 1001;

    [DllImport("user32.dll")]
    private static IntPtr GetSystemMenu(IntPtr hWnd, [MarshalAs(UnmanagedType.Bool)] bool bRevert);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static bool InsertMenu(IntPtr hMenu, int wPosition, int wFlags, IntPtr wIDNewItem, string lpNewItem);

    public static void AddAboutMenuItem(Dashboard dashboard)
    {
      IntPtr systemMenu = SystemMenu.GetSystemMenu(dashboard.Handle, false);
      SystemMenu.InsertMenu(systemMenu, 5, 3072, (IntPtr) 0, string.Empty);
      string lpNewItem = string.Format(DashboardStringHelper.GetString("SysMenuAbout"), (object) DashboardStringHelper.GetString("ShortenedApplicationCaption"));
      SystemMenu.InsertMenu(systemMenu, 6, 1024, (IntPtr) 1001, lpNewItem);
    }
  }
}
