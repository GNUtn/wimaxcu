// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.DashboardAndTaskTray
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.SDKInterop;
using Intel.Mobile.WiMAXCU.UI.DisplayWiMAX;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  internal class DashboardAndTaskTray
  {
    private static ClickableCustomMessageBox _turningWiMAXOnWillBreakYourWiFiConnectionCMB = new ClickableCustomMessageBox((string) null, (string) null, (LinkLabelLinkClickedEventHandler) null);
    private static CustomMessageBox _wimaxOffCMB = new CustomMessageBox((string) null);
    private static CustomMessageBox _turningWiFiOnWillBreakYourWiMAXConnectionCMB = new CustomMessageBox((string) null);
    private static CustomMessageBox _disconnectCMB = new CustomMessageBox((string) null);
    private static CustomMessageBox _connectToUnknownNetworkCMB = new CustomMessageBox((string) null);
    private static CustomMessageBox _activeRoutesCMB = new CustomMessageBox((string) null);

    static DashboardAndTaskTray()
    {
    }

    public static bool TurnRadioOn()
    {
      if (!MediaHandler.TheMedia.WiMAXIsReady || !MediaHandler.IntelCUIsInControl || (!AdapterHandler.TheAdapter.HardwareRadioOn || AdapterHandler.TheAdapter.SoftwareRadioOn) || (!DashboardAndTaskTray.IsOkToTurnWiMAXRadioOnActiveRoutesCheck() || !DashboardAndTaskTray.IsOkToTurnWiMAXRadioOnCoExCheck()))
        return false;
      int errorCode = AdapterHandler.Singleton.SetRadioState(true);
      switch (errorCode)
      {
        case 40975:
          ErrorHelper.ShowErrorDialog((Control) AppFramework.Dashboard, string.Format(ErrorStringsHelper.GetString("General_WiFiStillHasRadio"), (object) ErrorStringsHelper.GetString("General_RadioOnFailed")), ErrorHelper.TranslateErrorCodeToMessage(errorCode), (string) null, "RadioOnFailedWiFiStillHasRadio");
          return false;
        case 0:
          return true;
        default:
          ErrorHelper.ShowErrorDialog((Control) AppFramework.Dashboard, ErrorStringsHelper.GetString("General_RadioOnFailed"), ErrorHelper.TranslateErrorCodeToMessage(errorCode), (string) null, "RadioOnFailed");
          return false;
      }
    }

    public static bool TurnRadioOff()
    {
      if (!MediaHandler.TheMedia.WiMAXIsReady || !MediaHandler.IntelCUIsInControl || (!AdapterHandler.TheAdapter.HardwareRadioOn || !AdapterHandler.TheAdapter.SoftwareRadioOn) || !DashboardAndTaskTray.IsOkToTurnWiMAXRadioOff())
        return false;
      int errorCode = AdapterHandler.Singleton.SetRadioState(false);
      if (errorCode == 0)
        return true;
      ErrorHelper.ShowErrorDialog((Control) AppFramework.Dashboard, ErrorStringsHelper.GetString("General_RadioOffFailed"), ErrorHelper.TranslateErrorCodeToMessage(errorCode), (string) null, "RadioOffFailed");
      return false;
    }

    public static bool TurnWiFiRadioOn()
    {
      bool bSWRadioState = false;
      bool bHwRadioState = false;
      if (!AdapterHandler.TheAdapter.HardwareRadioOn || WiFiHandler.Singleton.GetRadioState(ref bSWRadioState, ref bHwRadioState) != 0 || (bSWRadioState || !DashboardAndTaskTray.IsOkToTurnWiFiRadioOn()))
        return false;
      int errorCode = WiFiHandler.Singleton.SetRadioState(true);
      if (errorCode == 0)
        return true;
      ErrorHelper.ShowErrorDialog((Control) AppFramework.Dashboard, ErrorStringsHelper.GetString("General_WiFiRadioOnFailed"), ErrorHelper.TranslateErrorCodeToMessage(errorCode), (string) null, "WiFiRadioOnFailed");
      return false;
    }

    public static bool TurnWiFiRadioOff()
    {
      bool bSWRadioState = false;
      bool bHwRadioState = false;
      if (!AdapterHandler.TheAdapter.HardwareRadioOn || WiFiHandler.Singleton.GetRadioState(ref bSWRadioState, ref bHwRadioState) != 0 || !bSWRadioState)
        return false;
      int errorCode = WiFiHandler.Singleton.SetRadioState(false);
      if (errorCode == 0)
        return true;
      ErrorHelper.ShowErrorDialog((Control) AppFramework.Dashboard, ErrorStringsHelper.GetString("General_WiFiRadioOffFailed"), ErrorHelper.TranslateErrorCodeToMessage(errorCode), (string) null, "WiFiRadioOffFailed");
      return false;
    }

    public static void ConnectToNetwork(NetworkDisplayItem ndiToConnect)
    {
      if (!MediaHandler.TheMedia.WiMAXIsReady || !MediaHandler.IntelCUIsInControl || (!AdapterHandler.TheAdapter.RadioIsOn() || NetworkHandler.ConnectedNetworks.Count > 0) || (ndiToConnect == null || !DashboardAndTaskTray.IsOkToConnectUnidentifiedNetworkCheck(ndiToConnect) || !DashboardAndTaskTray.IsOkToConnectActiveRoutesCheck(ndiToConnect)))
        return;
      int errorCode = NetworkHandler.Singleton.ConnectNetwork(ndiToConnect.WmxNetwork);
      if (errorCode == 0)
        return;
      string errorMsg;
      string accessibleName;
      if (ScanModeHandler.ScanMode == ScanModeEnum.BackgroundScanningDisabled)
      {
        errorMsg = string.Format(ErrorStringsHelper.GetString("General_ConnectFailedInManualScanMode"), (object) ErrorStringsHelper.GetString("General_ConnectFailed"));
        accessibleName = "ConnectFailedInManualScanMode";
      }
      else
      {
        errorMsg = string.Format(ErrorStringsHelper.GetString("General_ErrorMessageWithClickHelp"), (object) ErrorStringsHelper.GetString("General_ConnectFailed"));
        accessibleName = "ConnectFailed";
      }
      ErrorHelper.ShowErrorDialog((Control) AppFramework.Dashboard, errorMsg, ErrorHelper.TranslateErrorCodeToMessage(errorCode), "/errors.htm#noconnect", accessibleName);
    }

    public static void DisconnectFromNetwork(NetworkDisplayItem ndiToDisconnect)
    {
      if (!MediaHandler.TheMedia.WiMAXIsReady || !MediaHandler.IntelCUIsInControl || (!AdapterHandler.TheAdapter.RadioIsOn() || NetworkHandler.ConnectedNetworks.Count == 0) || (ndiToDisconnect == null || !DashboardAndTaskTray.IsOkToDisconnect()))
        return;
      int errorCode = NetworkHandler.Singleton.DisconnectNetwork(ndiToDisconnect.WmxNetwork);
      if (errorCode == 0)
        return;
      ErrorHelper.ShowErrorDialog((Control) AppFramework.Dashboard, ErrorStringsHelper.GetString("General_DisconnectFailed"), ErrorHelper.TranslateErrorCodeToMessage(errorCode), (string) null, "DisconnectFailed");
    }

    private static void OnActiveRoutesPopupClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      OnlineHelp.LaunchHelp("/tasktray.htm#ethernet");
    }

    private static void OnWiFiAndDeviceConnectionWillBeBrokenPopupClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      OnlineHelp.LaunchHelp("/tasktray.htm#wimax3");
    }

    private static void OnDeviceConnectionWillBeBrokenPopupClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      OnlineHelp.LaunchHelp("/tasktray.htm#wimax2");
    }

    private static void OnWiFiConnectionWillBeBrokenPopupClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      OnlineHelp.LaunchHelp("/tasktray.htm#wimax1");
    }

    private static bool IsOkToTurnWiMAXRadioOnActiveRoutesCheck()
    {
      if (DashboardAndTaskTray._activeRoutesCMB.Visible)
        return false;
      bool bSWRadioState = true;
      bool bHwRadioState = true;
      if (WiFiHandler.Singleton.GetRadioState(ref bSWRadioState, ref bHwRadioState) != 0)
        bSWRadioState = true;
      if (ConnectModeHandler.ConnectMode == ConnectModeEnum.Automatic && !DashboardAndTaskTray._activeRoutesCMB.Visible && (MiscUtilities.ActiveRouteExists() && CurrentUserSettings.GetShowActiveRoutesPopup()) && !bSWRadioState)
      {
        string @string = DashboardStringHelper.GetString("CapitalClickHere_Clickable");
        DashboardAndTaskTray._activeRoutesCMB = (CustomMessageBox) new ClickableCustomMessageBox(string.Format(DashboardStringHelper.GetString("ActiveRoutesPopup_WiMAXOn"), (object) @string), @string, new LinkLabelLinkClickedEventHandler(DashboardAndTaskTray.OnActiveRoutesPopupClicked), CustomMessageBoxStyle.YesNo, DontShowThisMessageAgainOptions.ActiveRoutesPopup);
        DashboardAndTaskTray._activeRoutesCMB.AccessibleName = "ActiveRoutesWarningMB";
        DashboardAndTaskTray._activeRoutesCMB.LocationOfMessageBox = CustomMessageBoxLocation.CenterOfDashboardOrInTaskTrayOnTop;
        if (DashboardAndTaskTray._activeRoutesCMB.CustomShowDialog((IWin32Window) AppFramework.Dashboard, true) != DialogResult.Yes)
          return false;
      }
      return true;
    }

    private static bool IsOkToTurnWiMAXRadioOnCoExCheck()
    {
      if (DashboardAndTaskTray._turningWiMAXOnWillBreakYourWiFiConnectionCMB.Visible)
        return false;
      if (CurrentUserSettings.GetShowCoExPopups() && WiFiHandler.Singleton.IsWiFiAvailable() && WiFiHandler.Singleton.IsWiFiReady())
      {
        WiFiCoEx_ConnectionState eConnectionState = WiFiCoEx_ConnectionState.WIFI_NOT_CONNECTED;
        if (WiFiHandler.Singleton.GetConnectionState(ref eConnectionState) == 0 && eConnectionState != WiFiCoEx_ConnectionState.WIFI_NOT_CONNECTED)
        {
          string @string = DashboardStringHelper.GetString("CapitalClickHere_Clickable");
          LinkLabelLinkClickedEventHandler clickedEventHandler = new LinkLabelLinkClickedEventHandler(DashboardAndTaskTray.OnWiFiConnectionWillBeBrokenPopupClicked);
          string message;
          LinkLabelLinkClickedEventHandler LinkHandler;
          if (WiFiCoEx_ConnectionState.WIFI_STA_CP_CONNECTED == eConnectionState || WiFiCoEx_ConnectionState.WIFI_STA_HN_CONNECTED == eConnectionState)
          {
            message = string.Format(DashboardStringHelper.GetString("Prompt_WiFiAndDeviceConnectionWillBeBroken_Ver2"), (object) @string);
            LinkHandler = new LinkLabelLinkClickedEventHandler(DashboardAndTaskTray.OnWiFiAndDeviceConnectionWillBeBrokenPopupClicked);
          }
          else if (WiFiCoEx_ConnectionState.WIFI_CP_CONNECTED == eConnectionState || WiFiCoEx_ConnectionState.WIFI_HN_CONNECTED == eConnectionState)
          {
            message = string.Format(DashboardStringHelper.GetString("Prompt_WiFiDeviceConnectionWillBeBroken_Ver2"), (object) @string);
            LinkHandler = new LinkLabelLinkClickedEventHandler(DashboardAndTaskTray.OnDeviceConnectionWillBeBrokenPopupClicked);
          }
          else
          {
            message = string.Format(DashboardStringHelper.GetString("Prompt_WiFiConnectionWillBeBroken_Ver2"), (object) @string);
            LinkHandler = new LinkLabelLinkClickedEventHandler(DashboardAndTaskTray.OnWiFiConnectionWillBeBrokenPopupClicked);
          }
          DashboardAndTaskTray._turningWiMAXOnWillBreakYourWiFiConnectionCMB = new ClickableCustomMessageBox(message, @string, LinkHandler, CustomMessageBoxStyle.YesNo, DontShowThisMessageAgainOptions.TurningRadioOnWillBreakYourConnectionPopup);
          DashboardAndTaskTray._turningWiMAXOnWillBreakYourWiFiConnectionCMB.AccessibleName = "TurningWiMAXOnWillBreakYourWiFiConnectionMB";
          DashboardAndTaskTray._turningWiMAXOnWillBreakYourWiFiConnectionCMB.LocationOfMessageBox = CustomMessageBoxLocation.CenterOfDashboardOrInTaskTrayOnTop;
          if (DashboardAndTaskTray._turningWiMAXOnWillBreakYourWiFiConnectionCMB.CustomShowDialog((IWin32Window) AppFramework.Dashboard, true) != DialogResult.Yes)
            return false;
        }
      }
      return true;
    }

    private static bool IsOkToTurnWiMAXRadioOff()
    {
      if (DashboardAndTaskTray._wimaxOffCMB.Visible)
        return false;
      if (APDOHandler.FUMODownloadState == FumoDownloadStateEnum.Downloading)
      {
        DashboardAndTaskTray._wimaxOffCMB = new CustomMessageBox(DashboardStringHelper.GetString("Prompt_ConfirmRadioOffDuringFUMODownload"), CustomMessageBoxStyle.YesNo);
        DashboardAndTaskTray._wimaxOffCMB.AccessibleName = "ConfirmRadioOffDuringFUMODownloadMB";
        DashboardAndTaskTray._wimaxOffCMB.LocationOfMessageBox = CustomMessageBoxLocation.CenterOfDashboardOrInTaskTrayOnTop;
        if (DashboardAndTaskTray._wimaxOffCMB.CustomShowDialog((IWin32Window) AppFramework.Dashboard, true) != DialogResult.Yes)
          return false;
      }
      return true;
    }

    private static bool IsOkToTurnWiFiRadioOn()
    {
      if (DashboardAndTaskTray._turningWiFiOnWillBreakYourWiMAXConnectionCMB.Visible)
        return false;
      if (NetworkHandler.ConnectedNetworks.Count > 0 && CurrentUserSettings.GetShowCoExPopups() && (WiFiHandler.Singleton.IsWiFiAvailable() && WiFiHandler.Singleton.IsWiFiReady()))
      {
        DashboardAndTaskTray._turningWiFiOnWillBreakYourWiMAXConnectionCMB = new CustomMessageBox(DashboardStringHelper.GetString("Prompt_WiMAXConnectionWillBeBroken"), CustomMessageBoxStyle.YesNo, DontShowThisMessageAgainOptions.TurningRadioOnWillBreakYourConnectionPopup);
        DashboardAndTaskTray._turningWiFiOnWillBreakYourWiMAXConnectionCMB.AccessibleName = "TurningWiFiOnWillBreakYourWiMAXConnectionMB";
        DashboardAndTaskTray._turningWiFiOnWillBreakYourWiMAXConnectionCMB.LocationOfMessageBox = CustomMessageBoxLocation.CenterOfDashboardOrInTaskTrayOnTop;
        if (DashboardAndTaskTray._turningWiFiOnWillBreakYourWiMAXConnectionCMB.CustomShowDialog((IWin32Window) AppFramework.Dashboard, true) != DialogResult.Yes)
          return false;
      }
      return true;
    }

    private static bool IsOkToDisconnect()
    {
      if (DashboardAndTaskTray._disconnectCMB.Visible)
        return false;
      if (APDOHandler.FUMODownloadState == FumoDownloadStateEnum.Downloading)
      {
        DashboardAndTaskTray._disconnectCMB = new CustomMessageBox(string.Format(DashboardStringHelper.GetString("Prompt_ConfirmDisconnectDuringFUMODownload"), (object) NetworkHandler.ConnectedNetworks[0].NetworkName), CustomMessageBoxStyle.YesNo);
        DashboardAndTaskTray._disconnectCMB.AccessibleName = "ConfirmDisconnectDuringFUMODownloadMB";
        DashboardAndTaskTray._disconnectCMB.LocationOfMessageBox = CustomMessageBoxLocation.CenterOfDashboardOrInTaskTrayOnTop;
        if (DashboardAndTaskTray._disconnectCMB.CustomShowDialog((IWin32Window) AppFramework.Dashboard, true) != DialogResult.Yes)
          return false;
      }
      return true;
    }

    private static bool IsOkToConnectUnidentifiedNetworkCheck(NetworkDisplayItem ndiToConnect)
    {
      if (DashboardAndTaskTray._connectToUnknownNetworkCMB.Visible)
        return false;
      if (ndiToConnect.NetworkName == WiMAXDisplayService.Singleton.GetUnknownNetworkName() || ndiToConnect.NetworkName == WiMAXDisplayService.Singleton.GetUnidentifiedNetworkName(ndiToConnect.WmxNetwork.NSPName))
      {
        DashboardAndTaskTray._connectToUnknownNetworkCMB = new CustomMessageBox(DashboardStringHelper.GetString("Prompt_ConnectToUnknownNetworkWarning"), CustomMessageBoxStyle.YesNo);
        DashboardAndTaskTray._connectToUnknownNetworkCMB.AccessibleName = "ConfirmConnectToUnknownNetworkMB";
        DashboardAndTaskTray._connectToUnknownNetworkCMB.LocationOfMessageBox = CustomMessageBoxLocation.CenterOfDashboardOrInTaskTrayOnTop;
        if (DashboardAndTaskTray._connectToUnknownNetworkCMB.CustomShowDialog((IWin32Window) AppFramework.Dashboard, true) != DialogResult.Yes)
          return false;
      }
      return true;
    }

    private static bool IsOkToConnectActiveRoutesCheck(NetworkDisplayItem ndiToConnect)
    {
      if (DashboardAndTaskTray._activeRoutesCMB.Visible)
        return false;
      if (!DashboardAndTaskTray._activeRoutesCMB.Visible && MiscUtilities.ActiveRouteExists() && CurrentUserSettings.GetShowActiveRoutesPopup())
      {
        string @string = DashboardStringHelper.GetString("CapitalClickHere_Clickable");
        DashboardAndTaskTray._activeRoutesCMB = (CustomMessageBox) new ClickableCustomMessageBox(string.Format(DashboardStringHelper.GetString("ActiveRoutesPopup_Connect"), (object) ndiToConnect.NetworkName, (object) @string), @string, new LinkLabelLinkClickedEventHandler(DashboardAndTaskTray.OnActiveRoutesPopupClicked), CustomMessageBoxStyle.YesNo, DontShowThisMessageAgainOptions.ActiveRoutesPopup);
        DashboardAndTaskTray._activeRoutesCMB.AccessibleName = "ActiveRoutesWarningMB";
        DashboardAndTaskTray._activeRoutesCMB.LocationOfMessageBox = CustomMessageBoxLocation.CenterOfDashboardOrInTaskTrayOnTop;
        if (DashboardAndTaskTray._activeRoutesCMB.CustomShowDialog((IWin32Window) AppFramework.Dashboard, true) != DialogResult.Yes)
          return false;
      }
      return true;
    }

    public static string GetPreferredProfileDisplayName()
    {
      try
      {
        foreach (ProfileDisplayItem profileDisplayItem in new List<ProfileDisplayItem>((IEnumerable<ProfileDisplayItem>) ProfileHandler.Singleton.Profiles))
        {
          if (profileDisplayItem != null && profileDisplayItem.Preferred)
          {
            foreach (NetworkDisplayItem networkDisplayItem in new List<NetworkDisplayItem>((IEnumerable<NetworkDisplayItem>) NetworkHandler.AvailableNetworks))
            {
              if (networkDisplayItem != null && networkDisplayItem.WmxNetwork != null && (networkDisplayItem.WmxNetwork.Profile != null && (int) profileDisplayItem.TheProfile.profileId != 0) && (int) networkDisplayItem.WmxNetwork.Profile.TheProfile.profileId == (int) profileDisplayItem.TheProfile.profileId)
                return WiMAXDisplayService.Singleton.GetNetworkNameDisplayText(networkDisplayItem.WmxNetwork);
            }
            return MiscUtilities.ParseProfileName(profileDisplayItem.TheProfile.profileName);
          }
        }
      }
      catch (Exception ex)
      {
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Warning, typeof (DashboardAndTaskTray), Logging.GetMessageForException(ex));
      }
      return "";
    }

    public static void CloseMessageBoxesIfNeeded()
    {
      if (MediaHandler.TheMedia.WiMAXIsReady && MediaHandler.IntelCUIsInControl)
        return;
      if (DashboardAndTaskTray._turningWiMAXOnWillBreakYourWiFiConnectionCMB != null && DashboardAndTaskTray._turningWiMAXOnWillBreakYourWiFiConnectionCMB.Visible)
        DashboardAndTaskTray._turningWiMAXOnWillBreakYourWiFiConnectionCMB.Close();
      if (DashboardAndTaskTray._wimaxOffCMB != null && DashboardAndTaskTray._wimaxOffCMB.Visible)
        DashboardAndTaskTray._wimaxOffCMB.Close();
      if (DashboardAndTaskTray._turningWiFiOnWillBreakYourWiMAXConnectionCMB != null && DashboardAndTaskTray._turningWiFiOnWillBreakYourWiMAXConnectionCMB.Visible)
        DashboardAndTaskTray._turningWiFiOnWillBreakYourWiMAXConnectionCMB.Close();
      if (DashboardAndTaskTray._disconnectCMB != null && DashboardAndTaskTray._disconnectCMB.Visible)
        DashboardAndTaskTray._disconnectCMB.Close();
      if (DashboardAndTaskTray._connectToUnknownNetworkCMB == null || !DashboardAndTaskTray._connectToUnknownNetworkCMB.Visible)
        return;
      DashboardAndTaskTray._connectToUnknownNetworkCMB.Close();
    }
  }
}
