// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.TaskBarHelper
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using System;
using System.Runtime.InteropServices;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class TaskBarHelper
  {
    private static int GETSTATE = 4;
    private static int GETTASKBARPOS = 5;

    static TaskBarHelper()
    {
    }

    [DllImport("SHELL32", CallingConvention = CallingConvention.StdCall)]
    private static uint SHAppBarMessage(int dwMessage, ref TaskBarHelper.TASKBARDATA pData);

    public static void GetTaskBarInfo(out TaskBarHelper.TASKBAREDGE taskBarEdge, out int taskBarHeight, out bool autoHide)
    {
      TaskBarHelper.TASKBARDATA pData = new TaskBarHelper.TASKBARDATA();
      int num1 = (int) TaskBarHelper.SHAppBarMessage(TaskBarHelper.GETTASKBARPOS, ref pData);
      taskBarEdge = (TaskBarHelper.TASKBAREDGE) pData.uEdge;
      taskBarHeight = 0;
      switch (pData.uEdge)
      {
        case 0:
          taskBarHeight = pData.rc.right - pData.rc.left;
          break;
        case 1:
          taskBarHeight = pData.rc.bottom;
          break;
        case 2:
          taskBarHeight = pData.rc.right - pData.rc.left;
          break;
        case 3:
          taskBarHeight = pData.rc.bottom - pData.rc.top;
          break;
      }
      pData = new TaskBarHelper.TASKBARDATA();
      uint num2 = TaskBarHelper.SHAppBarMessage(TaskBarHelper.GETSTATE, ref pData);
      autoHide = false;
      if ((int) num2 != 1 && (int) num2 != 3)
        return;
      autoHide = true;
    }

    private struct RECT
    {
      public int left;
      public int top;
      public int right;
      public int bottom;
    }

    private struct TASKBARDATA
    {
      public int cbSize;
      public IntPtr hWnd;
      public int uCallbackMessage;
      public int uEdge;
      public TaskBarHelper.RECT rc;
      public IntPtr lParam;
    }

    public enum TASKBAREDGE
    {
      Left,
      Top,
      Right,
      Bottom,
    }

    private enum TASKBARSTATE
    {
      Manual,
      AutoHide,
      AlwaysOnTop,
      AutoHideAndOnTop,
    }
  }
}
