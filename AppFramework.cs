// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.AppFramework
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.SDKInterop;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public sealed class AppFramework : ApplicationContext
  {
    private const string REGISTRY_WIMAX_SUBKEY = "SOFTWARE\\Intel\\WiMAX";
    private const string REGISTRY_INSTALLDIR_VALUE = "InstallDir";
    private static AppFramework s_AppFramework;
    private Dashboard _objDashboard;
    private TaskTray _objTaskTray;

    public static Dashboard Dashboard
    {
      get
      {
        if (AppFramework.s_AppFramework == null)
          return (Dashboard) null;
        else
          return AppFramework.s_AppFramework._objDashboard;
      }
    }

    public static TaskTray TaskTray
    {
      get
      {
        if (AppFramework.s_AppFramework == null)
          return (TaskTray) null;
        else
          return AppFramework.s_AppFramework._objTaskTray;
      }
    }

    private AppFramework()
    {
      this._objDashboard = (Dashboard) null;
      this._objTaskTray = (TaskTray) null;
    }

    [STAThread]
    private static void Main(string[] args)
    {
      Logging.LogEvent(TraceModule.App, TraceLevel.Info, typeof (AppFramework), "<<<=================================================================>>>");
      Logging.LogEvent(TraceModule.App, TraceLevel.Info, typeof (AppFramework), "CU Version: " + ((object) Assembly.GetExecutingAssembly().GetName().Version).ToString());
      if (args.Length != 0)
      {
        foreach (string str in args)
        {
          string strA = str.Trim().Replace("/", "");
          if (string.Compare(strA, "tasktray", true) == 0)
          {
            Logging.LogEvent(TraceModule.App, TraceLevel.Info, typeof (AppFramework), "/tasktray command line argument detected.");
            AllSettings.Singleton.LaunchInTaskTray = true;
            AllSettings.Singleton.ShowSplashScreen = false;
          }
          else if (string.Compare(strA, "nosplash", true) == 0)
          {
            Logging.LogEvent(TraceModule.App, TraceLevel.Info, typeof (AppFramework), "/nosplash command line argument detected.");
            AllSettings.Singleton.ShowSplashScreen = false;
          }
        }
      }
      if (!AppFrameworkHelper.IsAlreadyRunning())
      {
        Logging.LogEvent(TraceModule.App, TraceLevel.Info, typeof (AppFramework), "Creating application for the first time.");
        Application.EnableVisualStyles();
        Application.DoEvents();
        AppFramework.s_AppFramework = new AppFramework();
        if (AllSettings.Singleton.ShowSplashScreen)
          SplashScreen.ShowSplashScreen();
        Logging.LogEvent(TraceModule.App, TraceLevel.Info, typeof (AppFramework), "Creating Dashboard.");
        AppFramework.s_AppFramework._objDashboard = new Dashboard();
        Eventing.DashboardControl = (Control) AppFramework.s_AppFramework._objDashboard;
        AppFramework.s_AppFramework.MainForm = (Form) AppFramework.s_AppFramework._objDashboard;
        SystemMenu.AddAboutMenuItem(AppFramework.s_AppFramework._objDashboard);
        Logging.LogEvent(TraceModule.App, TraceLevel.Info, typeof (AppFramework), "Creating TaskTray.");
        AppFramework.s_AppFramework._objTaskTray = new TaskTray();
        AppFramework.s_AppFramework._objDashboard.TheTaskTray = AppFramework.s_AppFramework._objTaskTray;
        AppFramework.s_AppFramework._objTaskTray.InitTaskTray();
        TaskTrayPopupDialog singleton = TaskTrayPopupDialog.Singleton;
        string name1 = CurrentUserSettings.CurrentCulture();
        if (!string.IsNullOrEmpty(name1))
          Thread.CurrentThread.CurrentCulture = new CultureInfo(name1);
        string name2 = CurrentUserSettings.CurrentUICulture();
        if (!string.IsNullOrEmpty(name2))
          Thread.CurrentThread.CurrentUICulture = new CultureInfo(name2);
        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(AppFramework.OnUnhandledException);
        Application.ThreadException += new ThreadExceptionEventHandler(AppFramework.OnThreadException);
        CustomMessageBox outOfMemoryDlg = new CustomMessageBox(ErrorStringsHelper.GetString("OutOfMemory"), CustomMessageBoxStyle.Ok);
        outOfMemoryDlg.AccessibleName = "OutOfMemoryMB";
        try
        {
          if (AllSettings.Singleton.LaunchInTaskTray)
            Application.Run();
          else
            Application.Run((ApplicationContext) AppFramework.s_AppFramework);
        }
        catch (Win32Exception ex)
        {
          if (ex.NativeErrorCode == 14)
            AppFramework.ShowOutOfMemoryDialog(outOfMemoryDlg);
          else
            throw;
        }
        catch (OutOfMemoryException ex)
        {
          AppFramework.ShowOutOfMemoryDialog(outOfMemoryDlg);
        }
        AppFramework.DisposeOfTaskTray();
        AppFrameworkHelper.Cleanup();
        AppHandler.CleanupApplication();
        Application.DoEvents();
        Environment.Exit(0);
      }
      else
      {
        Logging.LogEvent(TraceModule.App, TraceLevel.Info, typeof (AppFramework), "Restoring running instance.");
        AppFrameworkHelper.RestoreRunningInstance();
      }
    }

    private static void DisposeOfTaskTray()
    {
      if (AppFramework.s_AppFramework._objTaskTray == null)
        return;
      AppFramework.s_AppFramework._objTaskTray.Dispose();
      AppFramework.s_AppFramework._objTaskTray = (TaskTray) null;
    }

    private static void ShowOutOfMemoryDialog(CustomMessageBox outOfMemoryDlg)
    {
      if (AppFramework.Dashboard != null && AppFramework.Dashboard.Visible)
        AppFramework.Dashboard.Visible = false;
      AppFramework.DisposeOfTaskTray();
      int num = (int) outOfMemoryDlg.CustomShowDialog((IWin32Window) null, true);
    }

    private static void OnThreadException(object sender, ThreadExceptionEventArgs args)
    {
      Exception exception = args.Exception;
      AppFramework.WriteToEventLog(exception);
      if (!CurrentUserSettings.ShowErrorDetails())
        return;
      ErrorHelper.ShowErrorDialog((Control) AppFramework.Dashboard, ErrorStringsHelper.GetString("General_UnhandledException"), exception, (string) null, "UnhandledException");
    }

    private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs args)
    {
      Exception ex = (Exception) args.ExceptionObject;
      AppFramework.WriteToEventLog(ex);
      if (!CurrentUserSettings.ShowErrorDetails())
        return;
      ErrorHelper.ShowErrorDialog((Control) AppFramework.Dashboard, ErrorStringsHelper.GetString("General_UnhandledException"), ex, (string) null, "UnhandledException");
    }

    public static void WriteToEventLog(Exception ex)
    {
      try
      {
        if (ex == null)
          return;
        Logging.LogEvent(TraceModule.App, TraceLevel.Error, typeof (AppFramework), "CU_EXCEPTION: The following unhandled exception was encountered...");
        Logging.LogEvent(TraceModule.App, TraceLevel.Error, typeof (AppFramework), Logging.GetMessageForException(ex));
        if (ex.InnerException != null)
          Logging.LogEvent(TraceModule.App, TraceLevel.Error, typeof (AppFramework), ex.InnerException.StackTrace);
        else
          Logging.LogEvent(TraceModule.App, TraceLevel.Error, typeof (AppFramework), ex.StackTrace);
        string message = ex.Message + "\r\n\r\n" + ex.GetType().ToString() + "\r\n" + ex.StackTrace;
        if (ex.InnerException != null)
        {
          message = ex.InnerException.Message + "\r\n\r\n" + ex.InnerException.GetType().ToString() + "\r\n" + ex.InnerException.StackTrace;
          if (ex.InnerException.InnerException != null)
            message = ex.InnerException.InnerException.Message + "\r\n\r\n" + ex.InnerException.InnerException.GetType().ToString() + "\r\n" + ex.InnerException.InnerException.StackTrace;
        }
        EventLog.WriteEntry(DashboardStringHelper.GetString("ApplicationCaption"), message, EventLogEntryType.Error);
      }
      catch
      {
      }
    }

    private static string GetWiMAXCUFilename()
    {
      RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Intel\\WiMAX", false);
      if (registryKey == null || registryKey.GetValue("InstallDir") == null)
        return (string) null;
      string path = Convert.ToString(registryKey.GetValue("InstallDir")) + "bin\\wimaxcu.exe";
      if (!File.Exists(path))
        return (string) null;
      else
        return path;
    }
  }
}
