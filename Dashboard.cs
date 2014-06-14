// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.Dashboard
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.SDKInterop;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using Intel.Mobile.WiMAXCU.UI.DisplayWiMAX;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class Dashboard : CustomForm
  {
    private static int _errorMessageCount = 0;
    private static int _uniqueMsgId = Dashboard.RegisterWindowMessage(DashboardStringHelper.GetString("ApplicationCaption"));
    private static uint MSGFLT_ADD = 1U;
    private static int NOTIFY_FOR_THIS_SESSION = 0;
    private ConnectionPanel _connectionPanel = new ConnectionPanel();
    private NetworkListPanel _networkListPanel = new NetworkListPanel();
    private PreferencesDialog _preferencesDlg = PreferencesDialog.Singleton;
    private AdvancedDialog _advancedDlg = AdvancedDialog.Singleton;
    private ManageNetworksDialog _manageNetworksDlg = ManageNetworksDialog.Singleton;
    private TechSupportDialog _techSupportDlg = TechSupportDialog.Singleton;
    private AboutDialog _aboutDlg = AboutDialog.Singleton;
    private NetworkDetailsDialog _networkDetailsDlg = NetworkDetailsDialog.Singleton;
    private NetworkPropertiesDialog _networkProperitesDlg = NetworkPropertiesDialog.Singleton;
    private FUMOProgressDialog _fumoProgressDialog = FUMOProgressDialog.Singleton;
    private ClickableCustomMessageBox _connectedCMB = new ClickableCustomMessageBox((string) null, (string) null, (LinkLabelLinkClickedEventHandler) null);
    private ClickableCustomMessageBox _dualModeWarningCMB = new ClickableCustomMessageBox((string) null, (string) null, (LinkLabelLinkClickedEventHandler) null);
    private DashboardMode _preferredDashboardMode = DashboardMode.Collapsed;
    private IContainer components;
    private TaskTray _taskTray;
    private APDOEventHandler TheApdoEventHandler;
    private WindowDragHelper _windowDragHelper;
    private Timers _timers;
    private bool _subscriptionAndFirewallPopupShown;
    private System.Windows.Forms.Timer _waitingForWiMAXAfterResumeTimer;

    public TaskTray TheTaskTray
    {
      get
      {
        return this._taskTray;
      }
      set
      {
        this._taskTray = value;
      }
    }

    public NetworkListPanel TheNetworkListPanel
    {
      get
      {
        return this._networkListPanel;
      }
    }

    public ConnectionPanel TheConnectionPanel
    {
      get
      {
        return this._connectionPanel;
      }
    }

    public DashboardMode PreferredDashboardMode
    {
      get
      {
        return this._preferredDashboardMode;
      }
      set
      {
        this._preferredDashboardMode = value;
        this.SetDashboardMode();
      }
    }

    public bool SubscriptionAndFirewallPopupShown
    {
      get
      {
        return this._subscriptionAndFirewallPopupShown;
      }
      set
      {
        this._subscriptionAndFirewallPopupShown = value;
      }
    }

    static Dashboard()
    {
    }

    public Dashboard()
    {
      this.CreateHandle();
      this.InitializeComponent();
      this.CustomInitializeComponents();
      ScalingUtils.ScaleControlHierarchy((Control) this);
      this.RegisterForEvents();
      this._timers = new Timers();
      this._waitingForWiMAXAfterResumeTimer = new System.Windows.Forms.Timer();
      this._waitingForWiMAXAfterResumeTimer.Tick += new EventHandler(this.OnWaitingForWiMAXAfterResumeTick);
      this._waitingForWiMAXAfterResumeTimer.Interval = TimerSettings.Dashboard_WaitingForWiMAXAfterResumeTimer_Interval;
    }

    [DllImport("User32.dll", CharSet = CharSet.Auto)]
    private static int RegisterWindowMessage(string lpString);

    [DllImport("User32.dll", SetLastError = true)]
    private static int ChangeWindowMessageFilter(int iMessage, uint dwFlag);

    [DllImport("wtsapi32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static bool WTSRegisterSessionNotification(IntPtr hWnd, [MarshalAs(UnmanagedType.U4)] int dwFlags);

    [DllImport("WtsApi32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static bool WTSUnRegisterSessionNotification(IntPtr hWnd);

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Dashboard));
      this.TheApdoEventHandler = new APDOEventHandler();
      this.SuspendLayout();
      this.TheApdoEventHandler.BackColor = Color.DarkRed;
      componentResourceManager.ApplyResources((object) this.TheApdoEventHandler, "TheApdoEventHandler");
      this.TheApdoEventHandler.Name = "TheApdoEventHandler";
      this.AutoScaleMode = AutoScaleMode.None;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Controls.Add((Control) this.TheApdoEventHandler);
      this.ForeColor = Color.Black;
      this.FormType = FormTypeEnum.MainApplication;
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.Name = "Dashboard";
      this.WindowState = FormWindowState.Minimized;
      this.ResumeLayout(false);
    }

    protected override void Dispose(bool disposing)
    {
      new SecurityPermission(SecurityPermissionFlag.AllFlags).Demand();
      if (disposing)
      {
        Eventing.DeRegisterAllUIEvents((object) this);
        if (this._windowDragHelper != null)
          this._windowDragHelper.CleanUp();
        if (this.components != null)
          this.components.Dispose();
      }
      base.Dispose(disposing);
    }

    protected override void OnHandleDestroyed(EventArgs e)
    {
      Dashboard.WTSUnRegisterSessionNotification(this.Handle);
      base.OnHandleDestroyed(e);
    }

    internal void ResetTrayIconVisibility()
    {
      try
      {
        if (AppFramework.Dashboard == null || AppFramework.Dashboard.TheTaskTray == null || AppFramework.Dashboard.TheTaskTray.TaskTrayNotifyIcon == null)
          return;
        AppFramework.Dashboard.TheTaskTray.TaskTrayNotifyIcon.Visible = false;
        if (!CurrentUserSettings.GetShowTrayIconSetting())
          return;
        AppFramework.Dashboard.TheTaskTray.TaskTrayNotifyIcon.Visible = true;
        AppFramework.Dashboard.TheTaskTray.UpdateUI();
      }
      catch (Exception ex)
      {
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Warning, (object) this, Logging.GetMessageForException(ex));
      }
    }

    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    protected override void WndProc(ref Message m)
    {
      if (m.Msg == Dashboard._uniqueMsgId)
      {
        AppFramework.Dashboard.ResetTrayIconVisibility();
        this.ShowMainWindow();
      }
      else if (m.Msg == 562)
        Eventing.GenerateUIEvent("WiMAXUI.OnWindowDragEnd", (object) this, new object[0]);
      else if (m.Msg == 274)
      {
        if (m.WParam.ToInt32() == 1001)
          AppFramework.Dashboard.ShowAboutDialog();
      }
      else if (m.Msg == 689)
      {
        switch (m.WParam.ToInt32())
        {
          case 1:
          case 3:
          case 5:
            ConnectModeHandler.UserSessionIsActive = true;
            break;
          case 2:
          case 4:
          case 6:
            ConnectModeHandler.UserSessionIsActive = false;
            break;
        }
      }
      else if (m.Msg == 536)
      {
        if (m.WParam.ToInt32() == 7)
        {
          if (this._waitingForWiMAXAfterResumeTimer != null)
          {
            MediaHandler.ResumingFromSleep = true;
            this._waitingForWiMAXAfterResumeTimer.Start();
          }
        }
        else if (m.WParam.ToInt32() == 4 && this._waitingForWiMAXAfterResumeTimer != null)
          this._waitingForWiMAXAfterResumeTimer.Stop();
      }
      base.WndProc(ref m);
    }

    private void OnWaitingForWiMAXAfterResumeTick(object sender, EventArgs e)
    {
      this._waitingForWiMAXAfterResumeTimer.Stop();
      MediaHandler.ResumingFromSleep = false;
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.F1)
      {
        this._connectionPanel.LaunchHelp();
      }
      else
      {
        if (e.KeyCode != Keys.F5)
          return;
        this.Cursor = Cursors.WaitCursor;
        this.UpdateDisplay();
        this.Cursor = Cursors.Default;
      }
    }

    private void OnSizeChanged(object sender, EventArgs e)
    {
      if (this.WindowState != FormWindowState.Minimized)
        return;
      this.ShowInTaskbar = true;
    }

    private void OnLoad(object sender, EventArgs e)
    {
      if (AllSettings.Singleton.ShowSplashScreen)
      {
        TimeSpan sleepTime = SplashScreen.GetSleepTime();
        if (sleepTime.Ticks > 0L)
          Thread.Sleep(sleepTime.Seconds * 1000 + sleepTime.Milliseconds);
        SplashScreen.CloseForm();
        Application.DoEvents();
        Thread.Sleep(750);
      }
      this.StartPosition = FormStartPosition.Manual;
      this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - (ImageHelper.FrameLeftPixel.Width + this._connectionPanel.Width + ImageHelper.FrameRightPixel.Width)) / 2, 50);
      this.DoCollapse();
    }

    private void OnShown(object sender, EventArgs e)
    {
      if (AllSettings.Singleton.LaunchInTaskTray)
        return;
      AppHandler.ForceBringToFront(this.Handle);
      this.SetTrayIconVisiblity();
      ThreadPool.QueueUserWorkItem(new WaitCallback(this.DoInitApplication));
    }

    private void OnClosing(object sender, CancelEventArgs e)
    {
      FormClosingEventArgs closingEventArgs = e as FormClosingEventArgs;
      if (closingEventArgs != null && CloseReason.UserClosing != closingEventArgs.CloseReason)
      {
        Application.Exit();
      }
      else
      {
        if (AppFramework.Dashboard.TheTaskTray == null)
          return;
        e.Cancel = true;
        this.Hide();
      }
    }

    private void OnSubscribeForServiceAndFirewallPopupClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if ((WhichLinkClicked) e.Link.LinkData == WhichLinkClicked.FirstLink)
      {
        new SecurityPermission(SecurityPermissionFlag.AllFlags).Demand();
        UIHelper.LaunchDefaultBrowser(DashboardStringHelper.GetString("DefaultURL"));
      }
      else
        this.LaunchHelp("/firewall.htm");
    }

    private void OnDualModeWarningForWiFiClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.LaunchHelp("/tasktray.htm#wimax_off");
    }

    private void OnDualModeWarningForWiMAXClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.LaunchHelp("/tasktray.htm#wifi_off");
    }

    private void OnRestoreNetworkSettingsComplete(object sender, object[] eventArgs)
    {
      AppFramework.Dashboard.TheTaskTray.TaskTrayNotifyIcon.Visible = true;
      AppFramework.Dashboard.SetDashboardMode();
      AppFramework.Dashboard.TheConnectionPanel.UpdateUI();
      AppFramework.Dashboard.TheNetworkListPanel.UpdateUI(false);
      if (AppFramework.Dashboard.TheTaskTray != null)
        AppFramework.Dashboard.TheTaskTray.UpdateUI();
      Application.DoEvents();
    }

    private void OnResetWiMAXDeviceComplete(object sender, object[] eventArgs)
    {
      AppFramework.Dashboard.SetDashboardMode();
      AppFramework.Dashboard.TheConnectionPanel.UpdateUI();
      AppFramework.Dashboard.TheNetworkListPanel.UpdateUI(false);
      if (AppFramework.Dashboard.TheTaskTray != null)
        AppFramework.Dashboard.TheTaskTray.UpdateUI();
      Application.DoEvents();
    }

    private void OnShowDualModeWarningForWiFi(object sender, object[] eventArgs)
    {
      if (this._dualModeWarningCMB.Visible || !LocalMachineSettings.IsDualModeWarningEnabled() || !CurrentUserSettings.GetShowDualModeWarningPopup())
        return;
      string @string = DashboardStringHelper.GetString("LowerCaseClickHere_Clickable");
      this._dualModeWarningCMB = new ClickableCustomMessageBox(string.Format(DashboardStringHelper.GetString("DualModeWarningForWiFi"), (object) @string), @string, new LinkLabelLinkClickedEventHandler(this.OnDualModeWarningForWiFiClicked), CustomMessageBoxStyle.Ok, DontShowThisMessageAgainOptions.DualModeWarningForWiFi);
      this._dualModeWarningCMB.AccessibleName = "DualModeWarningMB";
      this._dualModeWarningCMB.LocationOfMessageBox = CustomMessageBoxLocation.CenterOfDashboardOrInTaskTrayOnTop;
      int num = (int) this._dualModeWarningCMB.CustomShowDialog((IWin32Window) AppFramework.Dashboard, true);
    }

    private void OnShowDualModeWarningForWiMAX(object sender, object[] eventArgs)
    {
      if (this._dualModeWarningCMB.Visible || !LocalMachineSettings.IsDualModeWarningEnabled() || !CurrentUserSettings.GetShowDualModeWarningPopup())
        return;
      string @string = DashboardStringHelper.GetString("LowerCaseClickHere_Clickable");
      this._dualModeWarningCMB = new ClickableCustomMessageBox(string.Format(DashboardStringHelper.GetString("DualModeWarningForWiMAX"), (object) @string), @string, new LinkLabelLinkClickedEventHandler(this.OnDualModeWarningForWiMAXClicked), CustomMessageBoxStyle.Ok, DontShowThisMessageAgainOptions.DualModeWarningForWiMAX);
      this._dualModeWarningCMB.AccessibleName = "DualModeWarningMB";
      this._dualModeWarningCMB.LocationOfMessageBox = CustomMessageBoxLocation.CenterOfDashboardOrInTaskTrayOnTop;
      int num = (int) this._dualModeWarningCMB.CustomShowDialog((IWin32Window) AppFramework.Dashboard, true);
    }

    public void OnStateChange(object sender, object[] eventArgs)
    {
      AppFramework.Dashboard.SetDashboardMode();
      if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForRadioSwitch)
        this.Cursor = Cursors.WaitCursor;
      else
        this.Cursor = Cursors.Default;
    }

    public void OnError(object sender, object[] eventArgs)
    {
      if (eventArgs == null || eventArgs.Length < 2)
        return;
      this.ShowErrorMessage((int) eventArgs[0], (OperationThatFailed) eventArgs[1]);
      AppFramework.Dashboard.TheConnectionPanel.UpdateUI();
      AppFramework.Dashboard.TheNetworkListPanel.UpdateUI(false);
      if (AppFramework.Dashboard.TheTaskTray == null)
        return;
      AppFramework.Dashboard.TheTaskTray.UpdateUI();
    }

    public void OnMediaStatusChanged(object sender, object[] eventArgs)
    {
      if (MediaHandler.TheMedia.WiMAXIsReady)
        this._aboutDlg.ReinitDialog();
      DashboardAndTaskTray.CloseMessageBoxesIfNeeded();
      if (MediaHandler.TheMedia.WiMAXIsReady)
        AppFramework.Dashboard.ResetTrayIconVisibility();
      this._connectionPanel.UpdateUI();
      this._networkListPanel.UpdateUI(false);
    }

    public void OnIntelCUControlChanged(object sender, object[] eventArgs)
    {
      DashboardAndTaskTray.CloseMessageBoxesIfNeeded();
      this._connectionPanel.UpdateUI();
    }

    public void OnUpdateDashboardMode(object sender, object[] eventArgs)
    {
      AppFramework.Dashboard.SetDashboardMode();
    }

    public void OnPostInitApplication(object sender, object[] eventArgs)
    {
      this._aboutDlg.ReinitDialog();
      this._techSupportDlg.ReinitDialog();
      if (AppFramework.TaskTray != null)
        AppFramework.TaskTray.UpdateUI();
      AppFramework.Dashboard.SetDashboardMode();
    }

    private void OnIPAddressStateChanged(object sender, object[] eventArgs)
    {
      this.TheConnectionPanel.UpdateUI();
      this._subscriptionAndFirewallPopupShown = false;
      if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.IPAddressState == IPAddressStateEnum.Invalid)
      {
        if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForDisconnect || Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForRadioSwitch)
          return;
        AppFramework.TaskTray.ShowTaskTrayNotification(DashboardStringHelper.GetString("BalloonMsg_WiMAXHasLimitedOrNoConnectivity"), TaskTrayPopupClickOptions.LaunchIPAddressHelp, true, false, true);
      }
      else
      {
        if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.IPAddressState != IPAddressStateEnum.Valid || NetworkHandler.ConnectedNetworks.Count <= 0 || SPEventsHandler.Singleton.FastReconnect)
          return;
        int numSecondsConnected = 0;
        NetworkHandler.Singleton.GetConnectionTime(ref numSecondsConnected);
        if (this._connectedCMB.Visible || !CurrentUserSettings.GetShowSubscribeForServiceAndFirewallPopup() || numSecondsConnected >= 20)
          return;
        this._subscriptionAndFirewallPopupShown = true;
        string connectedBalloonText = WiMAXDisplayService.Singleton.GetConnectedBalloonText(NetworkHandler.ConnectedNetworks[0].WmxNetwork, true);
        string string1 = DashboardStringHelper.GetString("OpenWebBrowserClickHere_Clickable");
        if (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToLower() == "ko")
        {
          this._connectedCMB = new ClickableCustomMessageBox(string.Format(DashboardStringHelper.GetString("SubscribeForServiceAndFirewallPopup"), (object) connectedBalloonText, (object) NetworkHandler.ConnectedNetworks[0].NetworkName, (object) string1), string1, (string) null, new LinkLabelLinkClickedEventHandler(this.OnSubscribeForServiceAndFirewallPopupClicked), CustomMessageBoxStyle.Ok, DontShowThisMessageAgainOptions.SubscribeForServiceAndFirewallPopup);
        }
        else
        {
          string string2 = DashboardStringHelper.GetString("CapitalClickHere_Clickable");
          this._connectedCMB = new ClickableCustomMessageBox(string.Format(DashboardStringHelper.GetString("SubscribeForServiceAndFirewallPopup"), (object) connectedBalloonText, (object) NetworkHandler.ConnectedNetworks[0].NetworkName, (object) string1, (object) string2), string1, string2, new LinkLabelLinkClickedEventHandler(this.OnSubscribeForServiceAndFirewallPopupClicked), CustomMessageBoxStyle.Ok, DontShowThisMessageAgainOptions.SubscribeForServiceAndFirewallPopup);
        }
        this._connectedCMB.AccessibleName = "SubscribeForServiceAndFirewallWarningMB";
        this._connectedCMB.LocationOfMessageBox = CustomMessageBoxLocation.CenterOfDashboardOrInTaskTrayOnTop;
        int num = (int) this._connectedCMB.CustomShowDialog((IWin32Window) AppFramework.Dashboard, true);
      }
    }

    public void OnConnected(object sender, object[] eventArgs)
    {
      this.PreferredDashboardMode = DashboardMode.Collapsed;
    }

    public void OnAdapterListChanged(object sender, object[] eventArgs)
    {
      AppFramework.Dashboard.SetDashboardMode();
      this._connectionPanel.UpdateUI();
      this._networkListPanel.UpdateUI(true);
    }

    public void OnChangePreferredDashboardMode(object sender, object[] eventArgs)
    {
      if (this.PreferredDashboardMode == DashboardMode.Collapsed)
      {
        this.PreferredDashboardMode = DashboardMode.Expanded;
      }
      else
      {
        if (ScanModeHandler.ScanMode == ScanModeEnum.BackgroundScanningDisabled)
        {
          Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "Enabling background scanning because the user hid the network list.");
          ScanModeHandler.ScanMode = ScanModeEnum.BackgroundScanningEnabled;
        }
        this.PreferredDashboardMode = DashboardMode.Collapsed;
      }
    }

    public void ShowPreferencesDialog()
    {
      int num = (int) this._preferencesDlg.ShowDialog((IWin32Window) AppFramework.Dashboard);
    }

    public void ShowAdvancedDialog()
    {
      int num = (int) this._advancedDlg.ShowDialog((IWin32Window) AppFramework.Dashboard);
    }

    public void ShowManageNetworksDialog()
    {
      int num = (int) this._manageNetworksDlg.ShowDialog((IWin32Window) AppFramework.Dashboard);
    }

    public void ShowTechSupportDialog()
    {
      int num = (int) this._techSupportDlg.ShowDialog((IWin32Window) AppFramework.Dashboard);
    }

    public void ShowAboutDialog()
    {
      int num = (int) this._aboutDlg.ShowDialog((IWin32Window) AppFramework.Dashboard);
    }

    public void ShowNetworkDetailsDialog()
    {
      int num = (int) this._networkDetailsDlg.ShowDialog((IWin32Window) AppFramework.Dashboard);
    }

    public void ShowNetworkProperitesDialog(NetworkDisplayItem ndi)
    {
      this._networkProperitesDlg.Network = ndi;
      this._networkProperitesDlg.Profile = ndi.WmxNetwork.Profile.TheProfile;
      int num = (int) this._networkProperitesDlg.ShowDialog((IWin32Window) AppFramework.Dashboard);
    }

    public void ShowNetworkProperitesDialog(ProfileDisplayItem pdi)
    {
      this._networkProperitesDlg.Network = (NetworkDisplayItem) null;
      this._networkProperitesDlg.Profile = pdi.TheProfile;
      int num = (int) this._networkProperitesDlg.ShowDialog((IWin32Window) AppFramework.Dashboard);
    }

    public void ShowFUMOProgressDialog()
    {
      int num = (int) this._fumoProgressDialog.ShowDialog((IWin32Window) AppFramework.Dashboard);
    }

    public void ShowMainWindow()
    {
      AppFramework.Dashboard.Visible = true;
      AppFramework.Dashboard.WindowState = FormWindowState.Normal;
      AppFramework.Dashboard.Activate();
      AppFramework.Dashboard.SetDashboardMode();
      AppFramework.Dashboard.TheConnectionPanel.UpdateUI();
      AppFramework.Dashboard.TheNetworkListPanel.UpdateUI(false);
      if (AppFramework.Dashboard.TheTaskTray == null)
        return;
      AppFramework.Dashboard.TheTaskTray.UpdateUI();
    }

    public void LaunchHelp(string strHelpTopic)
    {
      OnlineHelp.LaunchHelp(strHelpTopic);
    }

    public void SetTrayIconVisiblity()
    {
      if (this.TheTaskTray == null || this.TheTaskTray.TaskTrayNotifyIcon == null)
        return;
      if (CurrentUserSettings.GetShowTrayIconSetting())
      {
        this.TheTaskTray.TaskTrayNotifyIcon.Visible = true;
        this.TheTaskTray.UpdateUI();
      }
      else
        this.TheTaskTray.TaskTrayNotifyIcon.Visible = false;
    }

    public void SetDashboardMode()
    {
      if (ProfileHandler.Singleton.IsPreferredProfileSet())
      {
        if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.ShouldControlBeEnabled(DashboardControlEnum.Window_ShowHideNetworkListLinkLabel))
          this.ShowHideState = ShowHideStateEnum.Enabled;
        else
          this.ShowHideState = ShowHideStateEnum.Disabled;
      }
      else
        this.ShowHideState = ShowHideStateEnum.Hidden;
      if (!MediaHandler.TheMedia.WiMAXIsReady || !MediaHandler.IntelCUIsInControl || (!AdapterHandler.TheAdapter.RadioIsOn() || NetworkHandler.ConnectedNetworks.Count > 0))
      {
        this.ShowHideState = ShowHideStateEnum.Hidden;
        this.DoCollapse();
      }
      else if (ProfileHandler.Singleton.IsPreferredProfileSet() && this._preferredDashboardMode == DashboardMode.Collapsed)
        this.DoCollapse();
      else
        this.DoExpand();
    }

    public void UpdateDisplay()
    {
      this._networkListPanel.UpdateUI(false);
      this._connectionPanel.UpdateUI();
    }

    public IContainer GetComponents()
    {
      return this.components;
    }

    private void CustomInitializeComponents()
    {
      new SecurityPermission(SecurityPermissionFlag.AllFlags).Demand();
      this.AccessibleName = "Dashboard";
      this._connectionPanel.AccessibleName = "ConnectionPanel";
      this._networkListPanel.AccessibleName = "NetworkListPanel";
      try
      {
        Dashboard.ChangeWindowMessageFilter(Dashboard._uniqueMsgId, Dashboard.MSGFLT_ADD);
      }
      catch (Exception ex)
      {
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Warning, (object) this, Logging.GetMessageForException(ex));
      }
      this._windowDragHelper = new WindowDragHelper();
      this.KeyDown += new KeyEventHandler(this.OnKeyDown);
      this.Closing += new CancelEventHandler(this.OnClosing);
      this.SizeChanged += new EventHandler(this.OnSizeChanged);
      this.Load += new EventHandler(this.OnLoad);
      this.Shown += new EventHandler(this.OnShown);
      this.TheApdoEventHandler.SendToBack();
      this.TheApdoEventHandler.Visible = false;
      this.AddPanels();
      this.Text = DashboardStringHelper.GetString("ApplicationCaption");
      this.BackColor = CustomForm.FormBackColor;
      this.FormBorderStyle = FormBorderStyle.None;
      SizeHelper.ResizeCustomControls(this.Controls);
      this.UpdateDisplay();
      if (Dashboard.WTSRegisterSessionNotification(this.Handle, Dashboard.NOTIFY_FOR_THIS_SESSION))
        return;
      Marshal.ThrowExceptionForHR(Marshal.GetLastWin32Error());
    }

    private void RegisterForEvents()
    {
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnStateChange), (object) this, "WiMAXUI.OnStateChange");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnError), (object) this, "WiMAXUI.OnError");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnMediaStatusChanged), (object) this, "WiMAXUI.OnMediaStatusChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnUpdateDashboardMode), (object) this, "WiMAXUI.OnUpdateDashboardMode");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnIntelCUControlChanged), (object) this, "WiMAXUI.OnIntelCUControlChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnPostInitApplication), (object) this, "WiMAXUI.OnPostInitApplication");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnIPAddressStateChanged), (object) this, "WiMAXSP.OnIPAddressStateChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnRestoreNetworkSettingsComplete), (object) this, "WiMAXSP.OnRestoreNetworkSettingsComplete");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnConnected), (object) this, "WiMAXSP.OnConnected");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnAdapterListChanged), (object) this, "WiMAXUI.OnAdapterListChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnChangePreferredDashboardMode), (object) this, "WiMAXUI.OnChangePreferredDashboardMode");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnResetWiMAXDeviceComplete), (object) this, "WiMAXSP.OnResetWiMAXDeviceComplete");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnShowDualModeWarningForWiFi), (object) this, "WiMAXSP.OnShowDualModeWarningForWiFi");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnShowDualModeWarningForWiMAX), (object) this, "WiMAXSP.OnShowDualModeWarningForWiMAX");
    }

    private void AddPanels()
    {
      this._connectionPanel.Location = new Point(ImageHelper.Unscaled.FrameLeftPixel.Width, ImageHelper.Unscaled.FrameTopPixel.Height);
      this.Controls.Add((Control) this._connectionPanel);
      this._networkListPanel.Location = new Point(ImageHelper.Unscaled.FrameLeftPixel.Width, this._connectionPanel.Location.Y + this._connectionPanel.Height);
      this.Controls.Add((Control) this._networkListPanel);
    }

    private void ShowErrorMessage(int errorCode, OperationThatFailed operationThatFailed)
    {
      if (Dashboard._errorMessageCount > 0)
        return;
      string helpTopic = (string) null;
      string errorMsg = ErrorStringsHelper.GetString("General_UnknownOperation");
      string errorDetails = ErrorHelper.TranslateErrorCodeToMessage(errorCode);
      string accessibleName = "";
      switch (operationThatFailed)
      {
        case OperationThatFailed.Connect:
          if (ConnectModeHandler.ConnectMode == ConnectModeEnum.Automatic)
            return;
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
          helpTopic = "/errors.htm#noconnect";
          break;
        case OperationThatFailed.StopConnect:
          errorMsg = ErrorStringsHelper.GetString("General_StopConnectFailed");
          accessibleName = "General_StopConnectFailed";
          break;
        case OperationThatFailed.Disconnect:
          errorMsg = ErrorStringsHelper.GetString("General_DisconnectFailed");
          accessibleName = "General_DisconnectFailed";
          break;
        case OperationThatFailed.RadioOn:
          errorMsg = ErrorStringsHelper.GetString("General_RadioOnFailed");
          accessibleName = "General_RadioOnFailed";
          break;
        case OperationThatFailed.RadioOff:
          errorMsg = ErrorStringsHelper.GetString("General_RadioOffFailed");
          accessibleName = "General_RadioOffFailed";
          break;
        case OperationThatFailed.Scan:
          errorMsg = ErrorStringsHelper.GetString("General_ScanFailed");
          accessibleName = "General_SearchFailed";
          break;
        case OperationThatFailed.StopScan:
          errorMsg = ErrorStringsHelper.GetString("General_StopSearchFailed");
          accessibleName = "General_StopSearchFailed";
          break;
      }
      if (errorCode == 40975)
      {
        errorMsg = string.Format(ErrorStringsHelper.GetString("General_WiFiStillHasRadio"), (object) errorMsg);
        accessibleName = "RadioOnFailedWiFiStillHasRadio";
      }
      ++Dashboard._errorMessageCount;
      ErrorHelper.ShowErrorDialogOnlyIfPrimaryCUAndSDKReady((Control) AppFramework.Dashboard, errorMsg, errorDetails, helpTopic, accessibleName);
      --Dashboard._errorMessageCount;
    }

    private void DoExpand()
    {
      int num1 = ImageHelper.FrameLeftPixel.Width + ImageHelper.FrameRightPixel.Width;
      int num2 = ImageHelper.FrameTopPixel.Height + ImageHelper.BtnContractedCorner.Height;
      int width = num1 + this._connectionPanel.Width;
      int height = num2 + (this._connectionPanel.Height + this._networkListPanel.Height);
      this._networkListPanel.Visible = true;
      this._networkListPanel.Focus();
      this.Size = new Size(width, height);
      this.Expanded = true;
      this.TheConnectionPanel.UpdateUI();
    }

    private void DoCollapse()
    {
      int num1 = ImageHelper.FrameLeftPixel.Width + ImageHelper.FrameRightPixel.Width;
      int num2 = ImageHelper.FrameTopPixel.Height + ImageHelper.BtnContractedCorner.Height;
      int width = num1 + this._connectionPanel.Width;
      int height = num2 + this._connectionPanel.Height;
      this._networkListPanel.Visible = false;
      this._connectionPanel.Focus();
      this.Size = new Size(width, height);
      this.Expanded = false;
      this.TheConnectionPanel.UpdateUI();
    }

    private void DoInitApplication(object obj)
    {
      Eventing.GenerateUIEvent("WiMAXUI.OnUpdateDashboardMode", (object) this, new object[0]);
      Thread.Sleep(750);
      AppHandler.InitApplication();
      Eventing.GenerateUIEvent("WiMAXUI.OnPostInitApplication", (object) this, new object[0]);
    }
  }
}
