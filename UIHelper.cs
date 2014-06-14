// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.UIHelper
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.Common;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class UIHelper
  {
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static bool ShowWindow(IntPtr hWnd, UIHelper.SW nCmdShow);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static bool SetWindowPos(int hWnd, UIHelper.HWND hWndInsertAfter, int X, int Y, int cx, int cy, UIHelper.SWP uFlags);

    public static void ShowAsTopMostForm(Form frm)
    {
      int left = frm.Left;
      int top = frm.Top;
      int width = frm.Width;
      int height = frm.Height;
      UIHelper.SetWindowPos(frm.Handle.ToInt32(), UIHelper.HWND.HWND_TOPMOST, left, top, width, height, (UIHelper.SWP) 19);
      UIHelper.ShowWindow(frm.Handle, UIHelper.SW.SW_SHOWNOACTIVATE);
    }

    public static void ShowAsBottomMostForm(Form frm)
    {
      int left = frm.Left;
      int top = frm.Top;
      int width = frm.Width;
      int height = frm.Height;
      UIHelper.SetWindowPos(frm.Handle.ToInt32(), UIHelper.HWND.HWND_BOTTOM, left, top, width, height, (UIHelper.SWP) 19);
      UIHelper.ShowWindow(frm.Handle, UIHelper.SW.SW_SHOWNOACTIVATE);
    }

    public static void LaunchDefaultBrowser(string url)
    {
      ThreadPool.QueueUserWorkItem(new WaitCallback(UIHelper.DoAsyncLaunchBrowser), (object) url);
    }

    private static void DoAsyncLaunchBrowser(object obj)
    {
      Process.Start(MiscUtilities.AddHttpPrefix(Convert.ToString(obj)));
    }

    public enum HWND
    {
      HWND_MESSAGE = -3,
      HWND_NOTOPMOST = -2,
      HWND_TOPMOST = -1,
      HWND_TOP = 0,
      HWND_BOTTOM = 1,
      HWND_BROADCAST = 65535,
    }

    public enum SW : uint
    {
      SW_HIDE = 0U,
      SW_NORMAL = 1U,
      SW_SHOWNORMAL = 1U,
      SW_SHOWMINIMIZED = 2U,
      SW_MAXIMIZE = 3U,
      SW_SHOWMAXIMIZED = 3U,
      SW_SHOWNOACTIVATE = 4U,
      SW_SHOW = 5U,
      SW_MINIMIZE = 6U,
      SW_SHOWMINNOACTIVE = 7U,
      SW_SHOWNA = 8U,
      SW_RESTORE = 9U,
      SW_SHOWDEFAULT = 10U,
      SW_FORCEMINIMIZE = 11U,
      SW_MAX = 11U,
    }

    public enum SWP : uint
    {
      SWP_NOSIZE = 1U,
      SWP_NOMOVE = 2U,
      SWP_NOZORDER = 4U,
      SWP_NOREDRAW = 8U,
      SWP_NOACTIVATE = 16U,
      SWP_DRAWFRAME = 32U,
      SWP_FRAMECHANGED = 32U,
      SWP_SHOWWINDOW = 64U,
      SWP_HIDEWINDOW = 128U,
      SWP_NOCOPYBITS = 256U,
      SWP_NOOWNERZORDER = 512U,
      SWP_NOREPOSITION = 512U,
      SWP_NOSENDCHANGING = 1024U,
      SWP_DEFERERASE = 8192U,
      SWP_ASYNCWINDOWPOS = 16384U,
    }
  }
}
