// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.ErrorHelper
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.SDKInterop;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using System;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public static class ErrorHelper
  {
    public static string TranslateErrorCodeToMessage(int errorCode)
    {
      switch (errorCode)
      {
        case 49154:
          return ErrorStringsHelper.GetString("BizTier_INVALID_RADIO_STATE");
        case 49155:
          return ErrorStringsHelper.GetString("BizTier_INVALID_NETWORK");
        case 49156:
          return ErrorStringsHelper.GetString("BizTier_ONLY_ONE_CONNECTED_NETWORK_SUPPORTED");
        case 49157:
          return ErrorStringsHelper.GetString("BizTier_NETWORK_NOT_CONNECTED");
        case 53249:
          return ErrorStringsHelper.GetString("APDO_GENERIC_FAILURE");
        case 53250:
          return ErrorStringsHelper.GetString("APDO_NETWORK_DISCONNECTED");
        case 53251:
          return ErrorStringsHelper.GetString("APDO_BAD_AUTHENTICATION");
        case 53252:
          return ErrorStringsHelper.GetString("APDO_INVALID_PROVISIONING");
        case 53253:
          return ErrorStringsHelper.GetString("APDO_INVALID_PACKAGE");
        case 57345:
          return ErrorStringsHelper.GetString("UI_PROVISIONING_OPERATION_IN_PROGRESS");
        case 40961:
          return ErrorStringsHelper.GetString("SDK_ALREADY_CONNECTED");
        case 40962:
          return ErrorStringsHelper.GetString("SDK_BUFFER_SIZE_TOO_SMALL");
        case 40963:
          return ErrorStringsHelper.GetString("SDK_CONNECTION_IN_PROGRESS");
        case 40964:
          return ErrorStringsHelper.GetString("SDK_DEVICE_MISSING");
        case 40965:
          return ErrorStringsHelper.GetString("SDK_FAILED");
        case 40966:
          return ErrorStringsHelper.GetString("SDK_FIRST_COMMON_ERROR");
        case 40967:
          return ErrorStringsHelper.GetString("SDK_INVALID_DEVICE");
        case 40968:
          return ErrorStringsHelper.GetString("SDK_INVALID_PARAMETER");
        case 40969:
          return ErrorStringsHelper.GetString("SDK_INVALID_PROFILE");
        case 40970:
          return ErrorStringsHelper.GetString("SDK_LAST_COMMON_ERROR");
        case 40971:
          return ErrorStringsHelper.GetString("SDK_LINK_NOT_CONNECTED");
        case 40972:
          return ErrorStringsHelper.GetString("SDK_NETWORK_PROHIBITED");
        case 40973:
          return ErrorStringsHelper.GetString("SDK_PERMISSON_DENIED");
        case 40974:
          return ErrorStringsHelper.GetString("SDK_ROAMING_NOT_ALLOWED");
        case 40975:
          return ErrorStringsHelper.GetString("SDK_INTEL_NO_RF");
        case 40976:
          return ErrorStringsHelper.GetString("SDK_Fail_to_connect_3_Way_Handshake");
        case 40977:
          return ErrorStringsHelper.GetString("SDK_Fail_to_connect_datapath");
        case 40978:
          return ErrorStringsHelper.GetString("SDK_Fail_to_connect_EAP_AUTH_Device");
        case 40979:
          return ErrorStringsHelper.GetString("SDK_Fail_to_connect_EAP_AUTH_user");
        case 40980:
          return ErrorStringsHelper.GetString("SDK_Fail_to_connect_Ranging");
        case 40981:
          return ErrorStringsHelper.GetString("SDK_Fail_to_connect_REG");
        case 40982:
          return ErrorStringsHelper.GetString("SDK_Fail_to_connect_SBC");
        case 40983:
          return ErrorStringsHelper.GetString("SDK_Fail_to_connect_to_NW");
        case 40984:
          return ErrorStringsHelper.GetString("SDK_UNKNOWN_ERROR_CODE");
        case 45057:
          return string.Format(ErrorStringsHelper.GetString("SP_UNHANDLED_EXCEPTION"), (object) ErrorHelper.GetStringForException(MediaHandler.LastUnhandledException));
        default:
          return string.Format(ErrorStringsHelper.GetString("ERROR_CODE"), (object) errorCode);
      }
    }

    private static string GetStringForException(Exception ex)
    {
      if (ex == null)
        return "";
      if (ex.InnerException != null)
        return ErrorHelper.GetStringForException(ex.InnerException);
      else
        return (string) (object) ex.GetType() + (object) "\r\n" + ex.Message;
    }

    public static void ShowErrorDialog(Control parent, string errorMsg, string errorDetails, string helpTopic, string accessibleName)
    {
      if (parent.InvokeRequired)
        return;
      ErrorDialog errorDlg = new ErrorDialog(errorMsg, errorDetails, helpTopic, accessibleName);
      ErrorHelper.ShowErrorDialog(parent, errorDlg, errorMsg, true);
    }

    public static void ShowErrorDialog(Control parent, string errorMsg, Exception ex, string helpTopic, string accessibleName)
    {
      if (parent.InvokeRequired)
        return;
      ErrorDialog errorDlg = new ErrorDialog(errorMsg, ex, helpTopic, accessibleName);
      ErrorHelper.ShowErrorDialog(parent, errorDlg, errorMsg, true);
    }

    public static void ShowErrorDialogOnlyIfPrimaryCUAndSDKReady(Control parent, string errorMsg, string errorDetails, string helpTopic, string accessibleName)
    {
      if (parent.InvokeRequired)
        return;
      ErrorDialog errorDlg = new ErrorDialog(errorMsg, errorDetails, helpTopic, accessibleName);
      ErrorHelper.ShowErrorDialog(parent, errorDlg, errorMsg, false);
    }

    public static void ShowErrorDialogOnlyIfPrimaryCUAndSDKReady(Control parent, string errorMsg, Exception ex, string helpTopic, string accessibleName)
    {
      if (parent.InvokeRequired)
        return;
      ErrorDialog errorDlg = new ErrorDialog(errorMsg, ex, helpTopic, accessibleName);
      ErrorHelper.ShowErrorDialog(parent, errorDlg, errorMsg, false);
    }

    private static void ShowErrorDialog(Control parent, ErrorDialog errorDlg, string errorMsg, bool alwaysShowErrorMsg)
    {
      if (!alwaysShowErrorMsg && (!MediaHandler.IntelCUIsInControl || !MediaHandler.TheMedia.WiMAXIsReady))
        return;
      if (!alwaysShowErrorMsg)
      {
        if (!AdapterHandler.TheAdapter.RadioIsOn())
        {
          if (errorMsg != ErrorStringsHelper.GetString("General_RadioOnFailed"))
          {
            if (errorMsg != ErrorStringsHelper.GetString("General_RadioOffFailed"))
              return;
          }
        }
      }
      try
      {
        if (File.Exists("C:\\Windows\\Media\\Windows XP Critical Stop.wav"))
          new SoundPlayer("C:\\Windows\\Media\\Windows XP Critical Stop.wav").Play();
        else if (File.Exists("C:\\Windows\\Media\\Windows Critical Stop.wav"))
          new SoundPlayer("C:\\Windows\\Media\\Windows Critical Stop.wav").Play();
      }
      catch (Exception ex)
      {
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Warning, typeof (ErrorDialog), Logging.GetMessageForException(ex));
      }
      if (AppFramework.TaskTray.ShowPopupInTaskTray())
      {
        errorDlg.FormType = FormTypeEnum.TaskTrayWithCloseBtn;
        errorDlg.StartPosition = FormStartPosition.Manual;
        errorDlg.Location = AppFramework.TaskTray.GetTaskTrayPopupLocation(DPIUtils.ScaleSize(errorDlg.Size));
        UIHelper.ShowAsTopMostForm((Form) errorDlg);
      }
      else
      {
        if (AppFramework.Dashboard != null && AppFramework.Dashboard.WindowState == FormWindowState.Minimized)
          AppFramework.Dashboard.WindowState = FormWindowState.Normal;
        AppFramework.Dashboard.BringToFront();
        errorDlg.FormType = FormTypeEnum.Dialog;
        if (AppFramework.Dashboard != null && AppFramework.Dashboard.Visible)
          errorDlg.StartPosition = FormStartPosition.CenterParent;
        else
          errorDlg.StartPosition = FormStartPosition.CenterScreen;
        int num = (int) errorDlg.ShowDialog((IWin32Window) parent);
      }
    }
  }
}
