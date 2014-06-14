// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.AppFrameworkHelper
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public static class AppFrameworkHelper
  {
    private const int WM_GETTEXTLENGTH = 14;
    private const int WM_GETTEXT = 13;
    private const int LB_GETTEXT = 393;
    private const int LB_GETTEXTLEN = 394;
    private static Mutex _mutex;
    private static int _uniqueMsgId;
    private static string _strOurWindowCaption;

    [DllImport("User32.dll", CharSet = CharSet.Auto)]
    private static int RegisterWindowMessage(string lpString);

    [DllImport("User32.dll")]
    private static int SendMessage(IntPtr hwnd, int msg, int wparam, int lparam);

    [DllImport("User32.dll")]
    private static int SendMessage(IntPtr hwnd, int msg, int wparam, StringBuilder sb);

    [DllImport("User32.dll")]
    private static int PostMessage(IntPtr hwnd, int msg, int wparam, int lparam);

    [DllImport("User32.dll")]
    private static int EnumWindows(AppFrameworkHelper.CallBack x, int y);

    [DllImport("User32.dll", CharSet = CharSet.Auto)]
    private static int GetWindowText(int hWnd, StringBuilder lpString, int iMaxCount);

    public static string GetWindowText(IntPtr handle)
    {
      string str = (string) null;
      if (handle != IntPtr.Zero)
      {
        int num = AppFrameworkHelper.SendMessage(handle, 14, 0, 0);
        if (num > 0)
        {
          StringBuilder sb = new StringBuilder(num + 1);
          if (AppFrameworkHelper.SendMessage(handle, 13, sb.Capacity, sb) > 0)
            str = ((object) sb).ToString();
        }
      }
      return str;
    }

    public static string GetListBoxItemText(IntPtr handle, int index)
    {
      string str = (string) null;
      if (handle != IntPtr.Zero)
      {
        int num = AppFrameworkHelper.SendMessage(handle, 394, index, 0);
        if (num > 0)
        {
          StringBuilder sb = new StringBuilder(num + 1);
          if (AppFrameworkHelper.SendMessage(handle, 393, index, sb) > 0)
            str = ((object) sb).ToString();
        }
      }
      return str;
    }

    public static bool IsAlreadyRunning()
    {
      bool createdNew;
      AppFrameworkHelper._mutex = new Mutex(true, "Local\\{57AA56FF-B82F-4386-B9D1-5C91ACD6A37F}", out createdNew);
      GC.KeepAlive((object) AppFrameworkHelper._mutex);
      return !createdNew;
    }

    public static void Cleanup()
    {
      AppFrameworkHelper._mutex.ReleaseMutex();
    }

    public static void RestoreRunningInstance()
    {
      AppFrameworkHelper._uniqueMsgId = AppFrameworkHelper.RegisterWindowMessage(DashboardStringHelper.GetString("ApplicationCaption"));
      AppFrameworkHelper._strOurWindowCaption = DashboardStringHelper.GetString("ApplicationCaption");
      string.Format("- Inside RestoreRunningInstance: Enumerating Windows with title = {0}", (object) AppFrameworkHelper._strOurWindowCaption);
      AppFrameworkHelper.EnumWindows(new AppFrameworkHelper.CallBack(AppFrameworkHelper.EnumWindowsCallBack), 0);
    }

    public static bool EnumWindowsCallBack(int hWnd, int lParam)
    {
      StringBuilder lpString = new StringBuilder(512);
      if (AppFrameworkHelper.GetWindowText(hWnd, lpString, 512) > 0 && AppFrameworkHelper._strOurWindowCaption.Equals(((object) lpString).ToString()))
        AppFrameworkHelper.PostMessage(new IntPtr(hWnd), AppFrameworkHelper._uniqueMsgId, 0, 0);
      return true;
    }

    public delegate bool CallBack(int hwnd, int lParam);
  }
}
