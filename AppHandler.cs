// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.AppHandler
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using System;
using System.Runtime.InteropServices;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public sealed class AppHandler
  {
    private static AppHandler _instance = new AppHandler();
    private static bool _initApplicationCalled;

    public static AppHandler Singleton
    {
      get
      {
        return AppHandler._instance;
      }
    }

    public static bool InitApplicationCalled
    {
      get
      {
        return AppHandler._initApplicationCalled;
      }
    }

    static AppHandler()
    {
    }

    [DllImport("user32.dll")]
    private static IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static bool SetForegroundWindow(IntPtr hWnd);

    public static void InitApplication()
    {
      if (AppHandler._initApplicationCalled)
        return;
      SPEventsHandler.Singleton.RegisterForEvents();
      MediaHandler.Singleton.InitializeStack();
      AppHandler._initApplicationCalled = true;
    }

    public static void CleanupApplication()
    {
      if (AppHandler._instance == null)
        return;
      AppHandler._instance = (AppHandler) null;
    }

    public static void ForceBringToFront(IntPtr handle)
    {
      if (handle == AppHandler.GetForegroundWindow())
        return;
      AppHandler.SetForegroundWindow(handle);
    }
  }
}
