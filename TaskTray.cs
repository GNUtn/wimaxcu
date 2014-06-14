// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.TaskTray
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.SDKInterop;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using Intel.Mobile.WiMAXCU.UI.DisplayWiMAX;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class TaskTray : Control
  {
    private bool _bShowAvailableNetworks = true;
    private NotifyIcon _taskTrayIcon;
    private TaskTrayContextMenu _taskTrayContextMenu;
    private Icon _icon_off;
    private Icon _icon_not_available;
    private Icon _icon_available;
    private Icon _icon_application;
    private Icon _icon_problem;
    private Icon _icon_signal_0;
    private Icon _icon_signal_1;
    private Icon _icon_signal_2;
    private Icon _icon_signal_3;
    private bool _bLastRadioState;
    private bool _systemSuspended;
    private TaskTrayAnimatedIcon _taskTrayAnimatedIcon;

    public NotifyIcon TaskTrayNotifyIcon
    {
      get
      {
        return this._taskTrayIcon;
      }
    }

    public TaskTray()
    {
      new SecurityPermission(SecurityPermissionFlag.AllFlags).Demand();
      this.CreateHandle();
      this._icon_off = ImageHelper.TrayWiMAXOff;
      this._icon_not_available = ImageHelper.TrayWiMAXNotAvailable;
      this._icon_available = ImageHelper.TrayWiMAXAvailable;
      this._icon_application = ImageHelper.TrayWiMAXAppIco;
      this._icon_problem = ImageHelper.TrayWiMAXProblem;
      this._icon_signal_0 = ImageHelper.TrayWiMAXSignal0;
      this._icon_signal_1 = ImageHelper.TrayWiMAXSignal1;
      this._icon_signal_2 = ImageHelper.TrayWiMAXSignal2;
      this._icon_signal_3 = ImageHelper.TrayWiMAXSignal3;
      this._taskTrayIcon = new NotifyIcon();
      this._taskTrayAnimatedIcon = new TaskTrayAnimatedIcon(this._taskTrayIcon);
      ContextMenu contextMenu = new ContextMenu();
      this._taskTrayContextMenu = new TaskTrayContextMenu(contextMenu);
      contextMenu.Popup += new EventHandler(this.ContextMenuPopup);
      this._taskTrayIcon.ContextMenu = contextMenu;
      this._taskTrayIcon.MouseDoubleClick += new MouseEventHandler(this.OnTaskTrayIconDoubleClick);
      SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(this.OnPowerModeChanged);
    }

    protected override void Dispose(bool disposing)
    {
      this._taskTrayIcon.Visible = false;
      this._taskTrayIcon.Dispose();
      this._taskTrayIcon = (NotifyIcon) null;
      Eventing.DeRegisterAllUIEvents((object) this);
      base.Dispose(disposing);
    }

    public void InitTaskTray()
    {
      this.RegisterForEvents();
      if (AllSettings.Singleton.LaunchInTaskTray)
      {
        AppFramework.Dashboard.SetTrayIconVisiblity();
        ThreadPool.QueueUserWorkItem(new WaitCallback(this.DoInitApplication));
      }
      else
        this.UpdateTaskTray((object) null);
    }

    public void UpdateUI()
    {
      this._taskTrayContextMenu.ClearContextMenu();
      this.UpdateTaskTray((object) null);
    }

    public bool ShowPopupInTaskTray()
    {
      return AppFramework.Dashboard == null || !AppFramework.Dashboard.Visible;
    }

    public void ShowTaskTrayNotification(string message, TaskTrayPopupClickOptions clickOption, bool allowPopupToBeSuperceded, bool popupShouldBeVisibleForExtraLongTime, bool showPopupEvenIfDashboardIsVisible)
    {
      if (this._systemSuspended || !MediaHandler.IntelCUIsInControl || (!MediaHandler.TheMedia.WiMAXIsReady || !CurrentUserSettings.GetShowTaskTrayNotifications()) || !showPopupEvenIfDashboardIsVisible && !this.ShowPopupInTaskTray() && AppFramework.Dashboard.WindowState != FormWindowState.Minimized)
        return;
      TaskTrayPopupDialog.Singleton.ShowPopup(message, clickOption, allowPopupToBeSuperceded, popupShouldBeVisibleForExtraLongTime);
    }

    public Point GetTaskTrayPopupLocation(Size sizePopup)
    {
      int num1 = 6;
      int num2 = 3;
      int width = Screen.PrimaryScreen.Bounds.Width;
      int height = Screen.PrimaryScreen.Bounds.Height;
      TaskBarHelper.TASKBAREDGE taskBarEdge;
      int taskBarHeight;
      bool autoHide;
      TaskBarHelper.GetTaskBarInfo(out taskBarEdge, out taskBarHeight, out autoHide);
      if (autoHide)
        taskBarHeight = 0;
      switch (taskBarEdge)
      {
        case TaskBarHelper.TASKBAREDGE.Left:
          return new Point(taskBarHeight + num1, height - sizePopup.Height - num2);
        case TaskBarHelper.TASKBAREDGE.Top:
          return new Point(width - sizePopup.Width - num1, taskBarHeight + num2);
        case TaskBarHelper.TASKBAREDGE.Right:
          return new Point(width - taskBarHeight - sizePopup.Width - num1, height - sizePopup.Height - num2);
        case TaskBarHelper.TASKBAREDGE.Bottom:
          return new Point(width - sizePopup.Width - num1, height - sizePopup.Height - taskBarHeight - num2);
        default:
          return new Point(width - sizePopup.Width - num1, height - sizePopup.Height - taskBarHeight - num2);
      }
    }

    public void CloseMainWindow()
    {
      Application.Exit();
    }

    private void OnTaskTrayIconDoubleClick(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      AppFramework.Dashboard.ShowMainWindow();
    }

    private void ContextMenuPopup(object sender, EventArgs e)
    {
      this._taskTrayContextMenu.UpdateContextMenu();
    }

    private void OnPowerModeChanged(object sender, PowerModeChangedEventArgs e)
    {
      if (e.Mode == PowerModes.Suspend)
        this._systemSuspended = true;
      else
        this._systemSuspended = false;
    }

    private void OnMediaStatusChanged(object sender, object[] eventArgs)
    {
      this._taskTrayContextMenu.ClearContextMenu();
      this.UpdateTaskTray((object) null);
    }

    private void OnNetworkListChanged(object sender, object[] eventArgs)
    {
      this.UpdateTaskTray((object) null);
    }

    private void OnOngoingScanNetworkListChanged(object sender, object[] eventArgs)
    {
      this._taskTrayContextMenu.AddConnectSubMenuItems(true);
    }

    private void OnIntelCUControlChanged(object sender, object[] eventArgs)
    {
      this._taskTrayContextMenu.ClearContextMenu();
      this.UpdateTaskTray((object) null);
    }

    public void OnStateChange(object sender, object[] eventArgs)
    {
      this._taskTrayContextMenu.ClearContextMenu();
      if (eventArgs == null || eventArgs.Length == 0)
        this.UpdateTaskTray((object) null);
      else
        this.UpdateTaskTray(eventArgs[0]);
    }

    private void OnAdapterListChanged(object sender, object[] eventArgs)
    {
      this._taskTrayContextMenu.ClearContextMenu();
      this.UpdateTaskTray((object) null);
    }

    private void OnDisconnected(object sender, object[] eventArgs)
    {
      if (eventArgs == null || eventArgs.Length < 1)
        return;
      NetworkDisplayItem ndi = eventArgs[0] as NetworkDisplayItem;
      if (ndi == null)
      {
        ndi = new NetworkDisplayItem();
        ndi.WmxNetwork = eventArgs[0] as WiMAXNetwork;
        ndi.WmxNetwork.Connection.Status = CONNECTION_STATUS.DISCONNECTED;
        WiMAXDisplayService.Singleton.FillNetworkDisplayItem(ref ndi, IPAddressStateEnum.Invalid);
      }
      this.ShowTaskTrayNotification(WiMAXDisplayService.Singleton.GetDisconnectedBalloonText(ndi.WmxNetwork), TaskTrayPopupClickOptions.LaunchDashboard, true, false, true);
    }

    private void OnDisconnectedBecauseOfRealmMismatch(object sender, object[] eventArgs)
    {
      if (eventArgs == null || eventArgs.Length < 2)
        return;
      WIMAX_API_SECURITY_COMPOUND securityCompound = (WIMAX_API_SECURITY_COMPOUND) eventArgs[0];
      this.ShowTaskTrayNotification(string.Format(TaskTrayStringHelper.GetString("TaskTray_Prompt_FormattedClickMessage"), (object) WiMAXDisplayService.Singleton.GetDisconnectedBecauseOfRealmMismatchBalloonText(eventArgs[1] as WiMAXNetwork, securityCompound.NSPRealm)), TaskTrayPopupClickOptions.LaunchDisconnectedRealmMismatchHelp, true, true, true);
    }

    private void OnDisconnectedBecauseOfNWRejection(object sender, object[] eventArgs)
    {
      if (eventArgs == null || eventArgs.Length < 1)
        return;
      this.ShowTaskTrayNotification(string.Format(TaskTrayStringHelper.GetString("TaskTray_Prompt_FormattedClickMessage"), (object) WiMAXDisplayService.Singleton.GetDisconnectedBecauseOfNWRejectionBalloonText(eventArgs[0] as WiMAXNetwork)), TaskTrayPopupClickOptions.LaunchDisconnectedNWRejectionHelp, true, true, true);
    }

    private void OnDisconnectedBecauseOfNWRejectionReauthentication(object sender, object[] eventArgs)
    {
      if (eventArgs == null || eventArgs.Length < 1)
        return;
      WiMAXNetwork wmxNetwork = (WiMAXNetwork) null;
      if (eventArgs[0] is WiMAXNetwork)
        wmxNetwork = eventArgs[0] as WiMAXNetwork;
      else if (eventArgs[0] is NetworkDisplayItem)
        wmxNetwork = ((NetworkDisplayItem) eventArgs[0]).WmxNetwork;
      this.ShowTaskTrayNotification(string.Format(TaskTrayStringHelper.GetString("TaskTray_Prompt_FormattedClickMessage"), (object) WiMAXDisplayService.Singleton.GetDisconnectedBecauseOfNWRejectionReauthenticationBalloonText(wmxNetwork)), TaskTrayPopupClickOptions.LaunchDisconnectedNWRejectionReauthenticationHelp, true, true, true);
    }

    private void OnNetworkNotification(object sender, object[] eventArgs)
    {
      if (eventArgs == null || eventArgs.Length < 1)
        return;
      this.ShowTaskTrayNotification((string) eventArgs[0], TaskTrayPopupClickOptions.LaunchDashboard, false, true, true);
    }

    private void OnIPAddressStateChanged(object sender, object[] eventArgs)
    {
      this.UpdateTooltip((object) null);
      if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.IPAddressState != IPAddressStateEnum.Valid || NetworkHandler.ConnectedNetworks.Count <= 0)
        return;
      int numSecondsConnected = 0;
      NetworkHandler.Singleton.GetConnectionTime(ref numSecondsConnected);
      if (AppFramework.Dashboard.SubscriptionAndFirewallPopupShown || CurrentUserSettings.GetShowSubscribeForServiceAndFirewallPopup() || (numSecondsConnected > TimerSettings.NetworksCache_IpAddressGiveUpTimer_DueTime / 1000 || SPEventsHandler.Singleton.FastReconnect))
        return;
      this.ShowTaskTrayNotification(WiMAXDisplayService.Singleton.GetConnectedBalloonText(NetworkHandler.ConnectedNetworks[0].WmxNetwork, false), TaskTrayPopupClickOptions.LaunchDashboard, true, false, true);
    }

    private void UpdateTaskTray(object objItem)
    {
      this.UpdateTooltip(objItem);
      this.UpdateIcon();
      this.ShowAvailableNetworksNotification();
    }

    public void UpdateTooltip(object objItem)
    {
      string str1 = (string) null;
      string profileDisplayName = DashboardAndTaskTray.GetPreferredProfileDisplayName();
      if (!AppHandler.InitApplicationCalled)
        str1 = TaskTrayStringHelper.GetString("TaskTray_Tooltip_InitializingApplication");
      else if (!MediaHandler.IntelCUIsInControl)
        str1 = TaskTrayStringHelper.GetString("TaskTray_Tooltip_NotPrimaryCU");
      else if (!MediaHandler.TheMedia.WiMAXIsReady)
        str1 = !MediaHandler.ResumingFromSleep ? TaskTrayStringHelper.GetString("TaskTray_Tooltip_AnErrorOccurred") : TaskTrayStringHelper.GetString("TaskTray_Tooltip_WaitingForWiMAX");
      else if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForRadioSwitch)
      {
        if (objItem != null)
          str1 = (RadioOperationEnum) objItem != RadioOperationEnum.On ? TaskTrayStringHelper.GetString("TaskTray_Tooltip_TurningWiMAXRadioOff") : TaskTrayStringHelper.GetString("TaskTray_Tooltip_TurningWiMAXRadioOn");
      }
      else if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForDisconnect)
      {
        if (objItem == null)
        {
          str1 = TaskTrayStringHelper.GetString("TaskTray_Tooltip_DisconnectingFromNetworkEllipse");
        }
        else
        {
          string str2 = string.Empty;
          if (objItem is WiMAXNetwork)
            str1 = string.Format(TaskTrayStringHelper.GetString("TaskTray_Tooltip_DisconnectingFromXEllipse"), (object) WiMAXDisplayService.Singleton.GetNetworkNameDisplayText((WiMAXNetwork) objItem));
          else if (objItem is NetworkDisplayItem)
            str1 = string.Format(TaskTrayStringHelper.GetString("TaskTray_Tooltip_DisconnectingFromXEllipse"), (object) ((NetworkDisplayItem) objItem).NetworkName);
        }
      }
      else if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForConnect)
        str1 = NetworkHandler.ConnectedNetworks.Count <= 0 ? (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.WmxNetworkBeingConnected == null ? (string.IsNullOrEmpty(profileDisplayName) ? TaskTrayStringHelper.GetString("TaskTray_Tooltip_ConnectingToNetworkEllipse") : string.Format(TaskTrayStringHelper.GetString("TaskTray_Tooltip_ConnectingToXEllipse"), (object) profileDisplayName)) : string.Format(TaskTrayStringHelper.GetString("TaskTray_Tooltip_ConnectingToXEllipse"), (object) WiMAXDisplayService.Singleton.GetNetworkNameDisplayText(Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.WmxNetworkBeingConnected))) : string.Format(TaskTrayStringHelper.GetString("TaskTray_Tooltip_ReconnectingToXEllipse"), (object) WiMAXDisplayService.Singleton.GetNetworkNameDisplayText(NetworkHandler.ConnectedNetworks[0].WmxNetwork));
      else if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForScan)
        str1 = string.IsNullOrEmpty(profileDisplayName) || Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForManualWideScan ? string.Format(TaskTrayStringHelper.GetString("TaskTray_Tooltip_SearchingForNetworksPercentCompleteEllipse"), (object) NetworkListStatusBar.ScanPercentComplete) : string.Format(TaskTrayStringHelper.GetString("TaskTray_Tooltip_SearchingForXEllipse"), (object) profileDisplayName);
      else if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForStopScan)
        str1 = TaskTrayStringHelper.GetString("TaskTray_Tooltip_StoppingTheSearch");
      else if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForStopConnect)
        str1 = TaskTrayStringHelper.GetString("TaskTray_Tooltip_StoppingTheConnect");
      else if (this.AreAllRadiosOff())
        str1 = AdapterHandler.TheAdapter.HardwareRadioOn ? TaskTrayStringHelper.GetString("TaskTray_Tooltip_AllRadiosOff") : TaskTrayStringHelper.GetString("TaskTray_Tooltip_HWRadioOff");
      else if (NetworkHandler.ConnectedNetworks.Count == 0)
      {
        NetworkDisplayItem preferredProfile = NetworkHandler.Singleton.GetNetworkForPreferredProfile();
        bool flag = ProfileHandler.Singleton.IsPreferredProfileSet();
        str1 = !flag || preferredProfile != null || ScanModeHandler.ScanMode != ScanModeEnum.BackgroundScanningEnabled ? (!flag || preferredProfile == null || NetworkHandler.AvailableNetworks.Count != 1 ? (NetworkHandler.AvailableNetworks.Count != 0 ? (NetworkHandler.AvailableNetworks.Count != 1 ? string.Format(TaskTrayStringHelper.GetString("TaskTray_Tooltip_XAvailableNetworks"), (object) NetworkHandler.AvailableNetworks.Count) : string.Format(TaskTrayStringHelper.GetString("TaskTray_Tooltip_XIsAvailable"), (object) NetworkHandler.AvailableNetworks[0].NetworkName)) : TaskTrayStringHelper.GetString("TaskTray_Tooltip_NoNetworksAvailable")) : string.Format(TaskTrayStringHelper.GetString("TaskTray_Tooltip_XIsAvailable"), (object) profileDisplayName)) : string.Format(TaskTrayStringHelper.GetString("TaskTray_Tooltip_PreferredProfileNotAvailable"), (object) profileDisplayName);
      }
      else if (NetworkHandler.ConnectedNetworks.Count == 1)
      {
        NetworkDisplayItem networkDisplayItem = NetworkHandler.ConnectedNetworks[0];
        str1 = Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.IPAddressState != IPAddressStateEnum.Acquiring ? (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.IPAddressState != IPAddressStateEnum.Invalid ? networkDisplayItem.ConnectedTaskTrayTooltip : networkDisplayItem.InvalidIPAddressTaskTrayTooltip) : networkDisplayItem.AcquiringIPAddressTaskTrayTooltip;
      }
      else if (NetworkHandler.ConnectedNetworks.Count > 1)
        str1 = string.Format(TaskTrayStringHelper.GetString("TaskTray_Tooltip_ConnectedToXNetworks"), (object) NetworkHandler.ConnectedNetworks.Count);
      if (string.IsNullOrEmpty(str1))
        str1 = TaskTrayStringHelper.GetString("TaskTray_Tooltip_WiMAXCU");
      try
      {
        if (str1.Length >= 128)
          str1 = str1.Substring(0, (int) sbyte.MaxValue);
        System.Type type = typeof (NotifyIcon);
        BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
        type.GetField("text", bindingAttr).SetValue((object) this._taskTrayIcon, (object) str1);
        if (!(bool) type.GetField("added", bindingAttr).GetValue((object) this._taskTrayIcon))
          return;
        object[] parameters = new object[1]
        {
          (object) true
        };
        type.GetMethod("UpdateIcon", bindingAttr).Invoke((object) this._taskTrayIcon, parameters);
      }
      catch (Exception ex)
      {
        this._taskTrayIcon.Text = TaskTrayStringHelper.GetString("TaskTray_Tooltip_WiMAXCU");
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Warning, (object) this, Logging.GetMessageForException(ex));
      }
    }

    private void UpdateIcon()
    {
      Icon icon = (Icon) null;
      if (!AppHandler.InitApplicationCalled)
        icon = this._icon_application;
      else if (!MediaHandler.IntelCUIsInControl)
        icon = this._icon_problem;
      else if (!MediaHandler.TheMedia.WiMAXIsReady)
      {
        icon = !MediaHandler.ResumingFromSleep ? this._icon_problem : this._icon_application;
      }
      else
      {
        if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForConnect || Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForScan)
          return;
        if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForDisconnect || Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForRadioSwitch || (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForStopScan || Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForStopConnect))
          icon = this._icon_application;
        else if (this.AreAllRadiosOff())
          icon = this._icon_off;
        else if (NetworkHandler.ConnectedNetworks.Count == 0)
          icon = NetworkHandler.AvailableNetworks.Count != 0 ? this._icon_available : this._icon_not_available;
        else if (NetworkHandler.ConnectedNetworks.Count == 1)
        {
          NetworkDisplayItem networkDisplayItem = NetworkHandler.ConnectedNetworks[0];
          icon = networkDisplayItem.WmxNetwork.SignalBars == SIGNAL_BARS.Excellent || networkDisplayItem.WmxNetwork.SignalBars == SIGNAL_BARS.VeryGood ? this._icon_signal_3 : (networkDisplayItem.WmxNetwork.SignalBars != SIGNAL_BARS.Good ? (networkDisplayItem.WmxNetwork.SignalBars == SIGNAL_BARS.Fair || networkDisplayItem.WmxNetwork.SignalBars == SIGNAL_BARS.Poor ? this._icon_signal_1 : this._icon_signal_0) : this._icon_signal_2);
        }
        else if (NetworkHandler.ConnectedNetworks.Count > 1)
          icon = this._icon_application;
      }
      if (icon == null)
        icon = this._icon_application;
      this._taskTrayIcon.Icon = icon;
    }

    private void ShowAvailableNetworksNotification()
    {
      if (AdapterHandler.TheAdapter.RadioIsOn() && !this._bLastRadioState)
        this._bShowAvailableNetworks = true;
      this._bLastRadioState = AdapterHandler.TheAdapter.RadioIsOn();
      if (!this._bShowAvailableNetworks || !AdapterHandler.TheAdapter.RadioIsOn() || (NetworkHandler.ConnectedNetworks.Count != 0 || NetworkHandler.AvailableNetworks.Count <= 0) || ConnectModeHandler.ConnectMode != ConnectModeEnum.Manual)
        return;
      if (ProfileHandler.Singleton.IsPreferredProfileSet())
        this.ShowTaskTrayNotification(string.Format(TaskTrayStringHelper.GetString("TaskTray_Prompt_PreferredProfileAvailable"), (object) DashboardAndTaskTray.GetPreferredProfileDisplayName()), TaskTrayPopupClickOptions.LaunchDashboard, true, false, false);
      else
        this.ShowTaskTrayNotification(TaskTrayStringHelper.GetString("TaskTray_Prompt_AvailableNetworks"), TaskTrayPopupClickOptions.LaunchDashboard, true, false, false);
      this._bShowAvailableNetworks = false;
    }

    private bool AreAllRadiosOff()
    {
      return !AdapterHandler.TheAdapter.RadioIsOn();
    }

    private void RegisterForEvents()
    {
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnMediaStatusChanged), (object) this, "WiMAXUI.OnMediaStatusChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnNetworkListChanged), (object) this, "WiMAXUI.OnNetworkListChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnStateChange), (object) this, "WiMAXUI.OnStateChange");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnIPAddressStateChanged), (object) this, "WiMAXSP.OnIPAddressStateChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnDisconnected), (object) this, "WiMAXSP.OnDisconnected");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnIntelCUControlChanged), (object) this, "WiMAXUI.OnIntelCUControlChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnAdapterListChanged), (object) this, "WiMAXUI.OnAdapterListChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnOngoingScanNetworkListChanged), (object) this, "WiMAXUI.OnOngoingScanNetworkListChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnDisconnectedBecauseOfRealmMismatch), (object) this, "WiMAXSP.OnDisconnectedBecauseOfRealmMismatch");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnNetworkNotification), (object) this, "WiMAXSP.OnNetworkNotification");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnDisconnectedBecauseOfNWRejection), (object) this, "WiMAXSP.OnDisconnectedBecauseOfNWRejection");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnDisconnectedBecauseOfNWRejectionReauthentication), (object) this, "WiMAXSP.OnDisconnectedBecauseOfNWRejectionReauthentication");
    }

    private void DoInitApplication(object obj)
    {
      Thread.Sleep(750);
      AppHandler.InitApplication();
      Eventing.GenerateUIEvent("WiMAXUI.OnPostInitApplication", (object) this, new object[0]);
    }
  }
}
