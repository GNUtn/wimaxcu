// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.ConnectionPanel
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
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class ConnectionPanel : UserControl
  {
    private StringBuilder _statusMsg = new StringBuilder();
    private StringBuilder _longOperationStatusMsg = new StringBuilder();
    private bool _wifiBeingControlledByComboCard = true;
    private IContainer components;
    private ConnectionDetails ConnectionDetails;
    private CustomButtonPush DisconnectPushButton;
    private ConnectionSubDetails ConnectionSubDetails;
    private ConnectionSubDetailUptime ConnectionSubDetailUptime;
    private ConnectionDetailsNone ConnectionDetailsNone;
    private ConnectionDetailsStatus ConnectionDetailsStatus;
    private CustomButtonPushHorizBox BtnBoxDetailsDisconnect;
    private Label RadioLbl;
    private CustomRadioButtonOnOff RadioOnOffRadioButtonGrp;
    private CustomButtonPushHorizBox BtnBoxOptionsWiFiHelp;
    private ConnectionBrandingPanel ConnectionBrandingPanel;
    private CustomButtonPushHorizBox BtnBoxConnect;
    private CustomButtonPush ConnectPushButton;
    private CustomButtonPushHorizBox BtnBoxSearch;
    private CustomButtonPush SearchPushButton;
    private CustomButtonPush DetailsPushButton;
    private CustomMenuButton OptionsMenuButton;
    private CustomMenuButton WiFiMenuButton;
    private CustomMenuButton HelpMenuButton;
    private static MenuItem _preferencesMenuItem;
    private static MenuItem _advancedMenuItem;
    private static MenuItem _manageNetworksMenuItem;
    private static MenuItem _wifiOnMenuItem;
    private static MenuItem _wifiOffMenuItem;
    private static MenuItem _helpMenuItem;
    private static MenuItem _techSupportMenuItem;
    private static MenuItem _aboutMenuItem;
    private Timer _addWiFiMenuTimer;

    public bool WifiBeingControlledByComboCard
    {
      get
      {
        return this._wifiBeingControlledByComboCard;
      }
    }

    public bool WiFiMenuVisible
    {
      get
      {
        return this.BtnBoxOptionsWiFiHelp.Controls.Contains((Control) this.WiFiMenuButton);
      }
    }

    public ConnectionPanel()
    {
      this.InitializeComponent();
      this.CustomInitializeComponents();
      this.RegisterForEvents();
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ConnectionPanel));
      this.BtnBoxDetailsDisconnect = new CustomButtonPushHorizBox();
      this.DetailsPushButton = new CustomButtonPush();
      this.DisconnectPushButton = new CustomButtonPush();
      this.RadioLbl = new Label();
      this.RadioOnOffRadioButtonGrp = new CustomRadioButtonOnOff();
      this.OptionsMenuButton = new CustomMenuButton();
      this.BtnBoxOptionsWiFiHelp = new CustomButtonPushHorizBox();
      this.WiFiMenuButton = new CustomMenuButton();
      this.HelpMenuButton = new CustomMenuButton();
      this.BtnBoxConnect = new CustomButtonPushHorizBox();
      this.ConnectPushButton = new CustomButtonPush();
      this.BtnBoxSearch = new CustomButtonPushHorizBox();
      this.SearchPushButton = new CustomButtonPush();
      this.ConnectionBrandingPanel = new ConnectionBrandingPanel();
      this.ConnectionDetailsStatus = new ConnectionDetailsStatus();
      this.ConnectionSubDetailUptime = new ConnectionSubDetailUptime();
      this.ConnectionDetails = new ConnectionDetails();
      this.ConnectionSubDetails = new ConnectionSubDetails();
      this.ConnectionDetailsNone = new ConnectionDetailsNone();
      this.BtnBoxDetailsDisconnect.SuspendLayout();
      this.BtnBoxOptionsWiFiHelp.SuspendLayout();
      this.BtnBoxConnect.SuspendLayout();
      this.BtnBoxSearch.SuspendLayout();
      this.SuspendLayout();
      this.BtnBoxDetailsDisconnect.BackColor = Color.Transparent;
      this.BtnBoxDetailsDisconnect.Controls.Add((Control) this.DetailsPushButton);
      this.BtnBoxDetailsDisconnect.Controls.Add((Control) this.DisconnectPushButton);
      componentResourceManager.ApplyResources((object) this.BtnBoxDetailsDisconnect, "BtnBoxDetailsDisconnect");
      this.BtnBoxDetailsDisconnect.HorizontalJustification = HorizontalJustificationEnum.Right;
      this.BtnBoxDetailsDisconnect.Name = "BtnBoxDetailsDisconnect";
      this.DetailsPushButton.BackColor = Color.Transparent;
      this.DetailsPushButton.BtnColor = PushButtonColorEnum.BlueGrey;
      this.DetailsPushButton.BtnDoubleEndCaps = false;
      this.DetailsPushButton.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.DetailsPushButton, "DetailsPushButton");
      this.DetailsPushButton.Name = "DetailsPushButton";
      this.DisconnectPushButton.BackColor = Color.Transparent;
      this.DisconnectPushButton.BtnColor = PushButtonColorEnum.RedGrey;
      this.DisconnectPushButton.BtnDoubleEndCaps = true;
      this.DisconnectPushButton.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.DisconnectPushButton, "DisconnectPushButton");
      this.DisconnectPushButton.Name = "DisconnectPushButton";
      componentResourceManager.ApplyResources((object) this.RadioLbl, "RadioLbl");
      this.RadioLbl.Name = "RadioLbl";
      this.RadioOnOffRadioButtonGrp.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.RadioOnOffRadioButtonGrp, "RadioOnOffRadioButtonGrp");
      this.RadioOnOffRadioButtonGrp.Name = "RadioOnOffRadioButtonGrp";
      this.RadioOnOffRadioButtonGrp.SelectionChanged = (CustomRadioButtonGroup.SelectionChangedDelegate) null;
      this.RadioOnOffRadioButtonGrp.State = OnOffRadioButtonState.Off;
      this.OptionsMenuButton.BackColor = Color.Transparent;
      this.OptionsMenuButton.ButtonBitmapDisabled = (Bitmap) componentResourceManager.GetObject("OptionsMenuButton.ButtonBitmapDisabled");
      this.OptionsMenuButton.ButtonBitmapNormal = (Bitmap) componentResourceManager.GetObject("OptionsMenuButton.ButtonBitmapNormal");
      this.OptionsMenuButton.ButtonBitmapPressed = (Bitmap) componentResourceManager.GetObject("OptionsMenuButton.ButtonBitmapPressed");
      this.OptionsMenuButton.ButtonBitmapRollover = (Bitmap) componentResourceManager.GetObject("OptionsMenuButton.ButtonBitmapRollover");
      componentResourceManager.ApplyResources((object) this.OptionsMenuButton, "OptionsMenuButton");
      this.OptionsMenuButton.Name = "OptionsMenuButton";
      this.OptionsMenuButton.TheContextMenu = (ContextMenu) null;
      this.BtnBoxOptionsWiFiHelp.BackColor = Color.Transparent;
      this.BtnBoxOptionsWiFiHelp.Controls.Add((Control) this.OptionsMenuButton);
      this.BtnBoxOptionsWiFiHelp.Controls.Add((Control) this.WiFiMenuButton);
      this.BtnBoxOptionsWiFiHelp.Controls.Add((Control) this.HelpMenuButton);
      componentResourceManager.ApplyResources((object) this.BtnBoxOptionsWiFiHelp, "BtnBoxOptionsWiFiHelp");
      this.BtnBoxOptionsWiFiHelp.HorizontalJustification = HorizontalJustificationEnum.Right;
      this.BtnBoxOptionsWiFiHelp.Name = "BtnBoxOptionsWiFiHelp";
      this.WiFiMenuButton.BackColor = Color.Transparent;
      this.WiFiMenuButton.ButtonBitmapDisabled = (Bitmap) componentResourceManager.GetObject("WiFiMenuButton.ButtonBitmapDisabled");
      this.WiFiMenuButton.ButtonBitmapNormal = (Bitmap) componentResourceManager.GetObject("WiFiMenuButton.ButtonBitmapNormal");
      this.WiFiMenuButton.ButtonBitmapPressed = (Bitmap) componentResourceManager.GetObject("WiFiMenuButton.ButtonBitmapPressed");
      this.WiFiMenuButton.ButtonBitmapRollover = (Bitmap) componentResourceManager.GetObject("WiFiMenuButton.ButtonBitmapRollover");
      componentResourceManager.ApplyResources((object) this.WiFiMenuButton, "WiFiMenuButton");
      this.WiFiMenuButton.Name = "WiFiMenuButton";
      this.WiFiMenuButton.TheContextMenu = (ContextMenu) null;
      this.HelpMenuButton.BackColor = Color.Transparent;
      this.HelpMenuButton.ButtonBitmapDisabled = (Bitmap) componentResourceManager.GetObject("HelpMenuButton.ButtonBitmapDisabled");
      this.HelpMenuButton.ButtonBitmapNormal = (Bitmap) componentResourceManager.GetObject("HelpMenuButton.ButtonBitmapNormal");
      this.HelpMenuButton.ButtonBitmapPressed = (Bitmap) componentResourceManager.GetObject("HelpMenuButton.ButtonBitmapPressed");
      this.HelpMenuButton.ButtonBitmapRollover = (Bitmap) componentResourceManager.GetObject("HelpMenuButton.ButtonBitmapRollover");
      componentResourceManager.ApplyResources((object) this.HelpMenuButton, "HelpMenuButton");
      this.HelpMenuButton.Name = "HelpMenuButton";
      this.HelpMenuButton.TheContextMenu = (ContextMenu) null;
      this.BtnBoxConnect.BackColor = Color.Transparent;
      this.BtnBoxConnect.Controls.Add((Control) this.ConnectPushButton);
      componentResourceManager.ApplyResources((object) this.BtnBoxConnect, "BtnBoxConnect");
      this.BtnBoxConnect.HorizontalJustification = HorizontalJustificationEnum.Right;
      this.BtnBoxConnect.Name = "BtnBoxConnect";
      this.ConnectPushButton.BackColor = Color.Transparent;
      this.ConnectPushButton.BtnColor = PushButtonColorEnum.GreenGrey;
      this.ConnectPushButton.BtnDoubleEndCaps = true;
      this.ConnectPushButton.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.ConnectPushButton, "ConnectPushButton");
      this.ConnectPushButton.Name = "ConnectPushButton";
      this.BtnBoxSearch.BackColor = Color.Transparent;
      this.BtnBoxSearch.Controls.Add((Control) this.SearchPushButton);
      componentResourceManager.ApplyResources((object) this.BtnBoxSearch, "BtnBoxSearch");
      this.BtnBoxSearch.HorizontalJustification = HorizontalJustificationEnum.Right;
      this.BtnBoxSearch.Name = "BtnBoxSearch";
      this.SearchPushButton.BackColor = Color.Transparent;
      this.SearchPushButton.BtnColor = PushButtonColorEnum.BlueGrey;
      this.SearchPushButton.BtnDoubleEndCaps = false;
      this.SearchPushButton.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.SearchPushButton, "SearchPushButton");
      this.SearchPushButton.Name = "SearchPushButton";
      this.ConnectionBrandingPanel.BackColor = Color.White;
      componentResourceManager.ApplyResources((object) this.ConnectionBrandingPanel, "ConnectionBrandingPanel");
      this.ConnectionBrandingPanel.Name = "ConnectionBrandingPanel";
      this.ConnectionBrandingPanel.TabStop = false;
      componentResourceManager.ApplyResources((object) this.ConnectionDetailsStatus, "ConnectionDetailsStatus");
      this.ConnectionDetailsStatus.BackColor = Color.Transparent;
      this.ConnectionDetailsStatus.LongOperationStatusMessageToShow = (string) null;
      this.ConnectionDetailsStatus.Name = "ConnectionDetailsStatus";
      this.ConnectionDetailsStatus.StatusImageToShow = StatusImageEnum.None;
      this.ConnectionDetailsStatus.StatusMessageToShow = (string) null;
      this.ConnectionDetailsStatus.TabStop = false;
      componentResourceManager.ApplyResources((object) this.ConnectionSubDetailUptime, "ConnectionSubDetailUptime");
      this.ConnectionSubDetailUptime.BackColor = Color.Transparent;
      this.ConnectionSubDetailUptime.Name = "ConnectionSubDetailUptime";
      this.ConnectionSubDetailUptime.TabStop = false;
      componentResourceManager.ApplyResources((object) this.ConnectionDetails, "ConnectionDetails");
      this.ConnectionDetails.BackColor = Color.Transparent;
      this.ConnectionDetails.Name = "ConnectionDetails";
      this.ConnectionDetails.TabStop = false;
      this.ConnectionSubDetails.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.ConnectionSubDetails, "ConnectionSubDetails");
      this.ConnectionSubDetails.Name = "ConnectionSubDetails";
      this.ConnectionSubDetails.TabStop = false;
      componentResourceManager.ApplyResources((object) this.ConnectionDetailsNone, "ConnectionDetailsNone");
      this.ConnectionDetailsNone.BackColor = Color.Transparent;
      this.ConnectionDetailsNone.Name = "ConnectionDetailsNone";
      this.ConnectionDetailsNone.TabStop = false;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.BtnBoxOptionsWiFiHelp);
      this.Controls.Add((Control) this.ConnectionBrandingPanel);
      this.Controls.Add((Control) this.RadioOnOffRadioButtonGrp);
      this.Controls.Add((Control) this.RadioLbl);
      this.Controls.Add((Control) this.ConnectionSubDetailUptime);
      this.Controls.Add((Control) this.ConnectionSubDetails);
      this.Controls.Add((Control) this.ConnectionDetails);
      this.Controls.Add((Control) this.ConnectionDetailsStatus);
      this.Controls.Add((Control) this.ConnectionDetailsNone);
      this.Controls.Add((Control) this.BtnBoxDetailsDisconnect);
      this.Controls.Add((Control) this.BtnBoxSearch);
      this.Controls.Add((Control) this.BtnBoxConnect);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "ConnectionPanel";
      this.BtnBoxDetailsDisconnect.ResumeLayout(false);
      this.BtnBoxOptionsWiFiHelp.ResumeLayout(false);
      this.BtnBoxConnect.ResumeLayout(false);
      this.BtnBoxSearch.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
      e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
      Bitmap bitmap = !MediaHandler.TheMedia.WiMAXIsReady || !MediaHandler.IntelCUIsInControl || (!AdapterHandler.TheAdapter.RadioIsOn() || NetworkHandler.ConnectedNetworks.Count <= 0) || Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForAny ? ImageHelper.ChromeNoSeparatorBackground : ImageHelper.ChromeBackground;
      Point[] destPoints = new Point[3]
      {
        new Point(0, 0),
        new Point(bitmap.Width, 0),
        new Point(0, bitmap.Height)
      };
      e.Graphics.DrawImage((Image) bitmap, destPoints);
      base.OnPaint(e);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (this.components != null)
          this.components.Dispose();
        Eventing.DeRegisterAllUIEvents((object) this);
      }
      base.Dispose(disposing);
    }

    private void OnRadioOnOffRadioButtonGrpSelectionChanged(object sender, SelectionArgs e)
    {
      if (this.RadioOnOffRadioButtonGrp.State == OnOffRadioButtonState.On)
      {
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user pressed the 'WiMAX On' button.");
        this.RadioOnOffRadioButtonGrp.SelectionChanged -= new CustomRadioButtonGroup.SelectionChangedDelegate(this.OnRadioOnOffRadioButtonGrpSelectionChanged);
        this.RadioOnOffRadioButtonGrp.State = OnOffRadioButtonState.Off;
        this.RadioOnOffRadioButtonGrp.Invalidate();
        this.RadioOnOffRadioButtonGrp.SelectionChanged += new CustomRadioButtonGroup.SelectionChangedDelegate(this.OnRadioOnOffRadioButtonGrpSelectionChanged);
        if (!DashboardAndTaskTray.TurnRadioOn())
          return;
        this.RadioOnOffRadioButtonGrp.SelectionChanged -= new CustomRadioButtonGroup.SelectionChangedDelegate(this.OnRadioOnOffRadioButtonGrpSelectionChanged);
        this.RadioOnOffRadioButtonGrp.State = OnOffRadioButtonState.On;
        this.RadioOnOffRadioButtonGrp.Invalidate();
        this.RadioOnOffRadioButtonGrp.SelectionChanged += new CustomRadioButtonGroup.SelectionChangedDelegate(this.OnRadioOnOffRadioButtonGrpSelectionChanged);
      }
      else
      {
        if (this.RadioOnOffRadioButtonGrp.State != OnOffRadioButtonState.Off)
          return;
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user pressed the 'WiMAX Off' button.");
        this.RadioOnOffRadioButtonGrp.SelectionChanged -= new CustomRadioButtonGroup.SelectionChangedDelegate(this.OnRadioOnOffRadioButtonGrpSelectionChanged);
        this.RadioOnOffRadioButtonGrp.State = OnOffRadioButtonState.On;
        this.RadioOnOffRadioButtonGrp.Invalidate();
        this.RadioOnOffRadioButtonGrp.SelectionChanged += new CustomRadioButtonGroup.SelectionChangedDelegate(this.OnRadioOnOffRadioButtonGrpSelectionChanged);
        if (!DashboardAndTaskTray.TurnRadioOff())
          return;
        this.RadioOnOffRadioButtonGrp.SelectionChanged -= new CustomRadioButtonGroup.SelectionChangedDelegate(this.OnRadioOnOffRadioButtonGrpSelectionChanged);
        this.RadioOnOffRadioButtonGrp.State = OnOffRadioButtonState.Off;
        this.RadioOnOffRadioButtonGrp.Invalidate();
        this.RadioOnOffRadioButtonGrp.SelectionChanged += new CustomRadioButtonGroup.SelectionChangedDelegate(this.OnRadioOnOffRadioButtonGrpSelectionChanged);
      }
    }

    private void OnDetailsBtnPressed(object sender, EventArgs e)
    {
      Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user pressed the 'Details' button.");
      if (NetworkHandler.ConnectedNetworks.Count <= 0)
        return;
      AppFramework.Dashboard.ShowNetworkDetailsDialog();
    }

    private void OnDisconnectBtnPressed(object sender, EventArgs e)
    {
      Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user pressed the 'Disconnect' button.");
      if (NetworkHandler.ConnectedNetworks.Count <= 0)
        return;
      DashboardAndTaskTray.DisconnectFromNetwork(NetworkHandler.ConnectedNetworks[0]);
    }

    private void OnConnectBtnPressed(object sender, EventArgs e)
    {
      if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForConnect)
      {
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user pressed the 'Stop Connect' button.");
        int errorCode = NetworkHandler.Singleton.StopConnect();
        if (errorCode == 0)
          return;
        ErrorHelper.ShowErrorDialog((Control) AppFramework.Dashboard, ErrorStringsHelper.GetString("General_StopConnectFailed"), ErrorHelper.TranslateErrorCodeToMessage(errorCode), (string) null, "StopConnectFailed");
      }
      else
      {
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user pressed the 'Connect' button.");
        if (NetworkHandler.AvailableNetworks.Count <= 0)
          return;
        DashboardAndTaskTray.ConnectToNetwork(NetworkHandler.AvailableNetworks[0]);
      }
    }

    private void OnSearchForNetworkBtnPressed(object sender, EventArgs e)
    {
      if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForManualPreferredScan)
      {
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user pressed the 'Stop Search' button.");
        int errorCode = NetworkHandler.Singleton.StopScan();
        if (errorCode == 0)
          return;
        ErrorHelper.ShowErrorDialog((Control) AppFramework.Dashboard, ErrorStringsHelper.GetString("General_StopSearchFailed"), ErrorHelper.TranslateErrorCodeToMessage(errorCode), (string) null, "StopSearchFailed");
      }
      else
      {
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user pressed the 'Search' button.");
        int errorCode = NetworkHandler.Singleton.StartPreferredScan();
        if (errorCode == 0)
          return;
        ErrorHelper.ShowErrorDialog((Control) AppFramework.Dashboard, ErrorStringsHelper.GetString("General_ScanFailed"), ErrorHelper.TranslateErrorCodeToMessage(errorCode), (string) null, "SearchFailed");
      }
    }

    private void OnPreferencesSelected(object sender, EventArgs e)
    {
      Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user selected the 'Preferences' menu item from the Options menu.");
      AppFramework.Dashboard.ShowPreferencesDialog();
    }

    private void OnAdvancedSelected(object sender, EventArgs e)
    {
      Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user selected the 'Advanced' menu item from the Options menu.");
      AppFramework.Dashboard.ShowAdvancedDialog();
    }

    private void OnManageNetworksSelected(object sender, EventArgs e)
    {
      Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user selected the 'Manage Networks' menu item from the Options menu.");
      AppFramework.Dashboard.ShowManageNetworksDialog();
    }

    private void OnWiFiOnSelected(object sender, EventArgs e)
    {
      bool bSWRadioState = false;
      bool bHwRadioState = false;
      if (!ConnectionPanel._wifiOnMenuItem.Enabled || WiFiHandler.Singleton.GetRadioState(ref bSWRadioState, ref bHwRadioState) != 0 || bSWRadioState)
        return;
      Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user selected the 'On' menu item from WiFi menu.");
      DashboardAndTaskTray.TurnWiFiRadioOn();
    }

    private void OnWiFiOffSelected(object sender, EventArgs e)
    {
      bool bSWRadioState = false;
      bool bHwRadioState = false;
      if (!ConnectionPanel._wifiOffMenuItem.Enabled || WiFiHandler.Singleton.GetRadioState(ref bSWRadioState, ref bHwRadioState) != 0 || !bSWRadioState)
        return;
      Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user selected the 'Off' menu item from WiFi menu.");
      DashboardAndTaskTray.TurnWiFiRadioOff();
    }

    private void OnHelpSelected(object sender, EventArgs e)
    {
      Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user selected the 'Help' menu item from the Help menu.");
      this.LaunchHelp();
    }

    private void OnTechSupportSelected(object sender, EventArgs e)
    {
      Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user selected the 'Support' menu item from the Help menu.");
      AppFramework.Dashboard.ShowTechSupportDialog();
    }

    private void OnAboutSelected(object sender, EventArgs e)
    {
      Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user selected the 'About' menu item from the Help menu.");
      AppFramework.Dashboard.ShowAboutDialog();
    }

    private void OnApdoFumoSimulatorSelected(object sender, EventArgs e)
    {
      Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user selected the 'APDO/FUMO Simulator' menu item from the Options menu.");
      ((Control) new ApdoFumoSimulator()).Show();
    }

    private void WiFiMenuPopup(object sender, EventArgs e)
    {
      if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.ShouldWiFiOnOffBeEnabled(true))
      {
        ConnectionPanel._wifiOffMenuItem.Enabled = true;
        ConnectionPanel._wifiOnMenuItem.Enabled = true;
      }
      else
      {
        ConnectionPanel._wifiOffMenuItem.Enabled = false;
        ConnectionPanel._wifiOnMenuItem.Enabled = false;
      }
      bool bSWRadioState = false;
      bool bHwRadioState = false;
      if (WiFiHandler.Singleton.GetRadioState(ref bSWRadioState, ref bHwRadioState) == 0 && bSWRadioState && ConnectionPanel._wifiOnMenuItem.Enabled)
      {
        ConnectionPanel._wifiOnMenuItem.Checked = true;
        ConnectionPanel._wifiOffMenuItem.Checked = false;
      }
      else
      {
        ConnectionPanel._wifiOffMenuItem.Checked = true;
        ConnectionPanel._wifiOnMenuItem.Checked = false;
      }
    }

    public void LaunchHelp()
    {
      if (!AppHandler.InitApplicationCalled)
        OnlineHelp.LaunchHelp("/status.htm#initializing");
      else if (!MediaHandler.IntelCUIsInControl)
        OnlineHelp.LaunchHelp("/nostart.htm#enable");
      else if (!MediaHandler.TheMedia.WiMAXIsReady)
      {
        if (MediaHandler.ResumingFromSleep)
          OnlineHelp.LaunchHelp("/status.htm#initializing_resume");
        else
          OnlineHelp.LaunchHelp("/nostart.htm#notready");
      }
      else if (!AdapterHandler.TheAdapter.HardwareRadioOn)
        OnlineHelp.LaunchHelp("/status.htm#hw_radio_off");
      else if (!AdapterHandler.TheAdapter.SoftwareRadioOn)
        OnlineHelp.LaunchHelp("/status.htm#wimax_off");
      else if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForScan)
      {
        if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForManualWideScan || !ProfileHandler.Singleton.IsPreferredProfileSet())
          OnlineHelp.LaunchHelp("/status.htm#not_connected");
        else
          OnlineHelp.LaunchHelp("/status.htm#searching_abc");
      }
      else if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForConnect)
        OnlineHelp.LaunchHelp("/status.htm#connecting");
      else if (NetworkHandler.ConnectedNetworks.Count > 0)
      {
        if (APDOHandler.FUMODownloadState != FumoDownloadStateEnum.Idle)
          OnlineHelp.LaunchHelp("/status.htm#downloading");
        else if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.IPAddressState == IPAddressStateEnum.Acquiring)
          OnlineHelp.LaunchHelp("/status.htm#acquiring");
        else if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.IPAddressState == IPAddressStateEnum.Invalid && (string.IsNullOrEmpty(NetworkHandler.ConnectedNetworks[0].WmxNetwork.Connection.IPv4Address) || NetworkHandler.ConnectedNetworks[0].WmxNetwork.Connection.IPv4Address == "0.0.0.0"))
          OnlineHelp.LaunchHelp("/status.htm#no_con");
        else if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.IPAddressState == IPAddressStateEnum.Invalid)
          OnlineHelp.LaunchHelp("/status.htm#limited_con");
        else
          OnlineHelp.LaunchHelp("/status.htm#connected");
      }
      else if (NetworkHandler.AvailableNetworks.Count >= 1 && ProfileHandler.Singleton.IsPreferredProfileSet() && ScanModeHandler.ScanMode == ScanModeEnum.BackgroundScanningEnabled)
        OnlineHelp.LaunchHelp("/status.htm#available");
      else if (NetworkHandler.AvailableNetworks.Count == 0 && ProfileHandler.Singleton.IsPreferredProfileSet())
        OnlineHelp.LaunchHelp("/status.htm#not_available");
      else if (NetworkHandler.AvailableNetworks.Count >= 1)
        OnlineHelp.LaunchHelp("/status.htm#select");
      else if (NetworkHandler.AvailableNetworks.Count == 0)
        OnlineHelp.LaunchHelp("/search.htm#exhaustive");
      else
        OnlineHelp.LaunchHelp("/overview.htm");
    }

    public void UpdateUI()
    {
      if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForScan && AppFramework.Dashboard.Expanded)
      {
        this._statusMsg = new StringBuilder();
        this._longOperationStatusMsg = new StringBuilder();
      }
      this.UpdatePanelState();
      this.UpdateButtonState();
    }

    public void HandleStateChange(object[] eventArgs)
    {
      this._statusMsg = new StringBuilder();
      this._longOperationStatusMsg = new StringBuilder();
      if (AdapterHandler.TheAdapter.HardwareRadioOn && Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForAny)
      {
        if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForRadioSwitch)
        {
          if (eventArgs != null && eventArgs.Length > 0)
          {
            if ((RadioOperationEnum) eventArgs[0] == RadioOperationEnum.On)
              this.AppendMsg(this._statusMsg, DashboardStringHelper.GetString("Dashboard_TurningWiMAXOn"));
            else
              this.AppendMsg(this._statusMsg, DashboardStringHelper.GetString("Dashboard_TurningWiMAXOff"));
          }
          else if (!AdapterHandler.TheAdapter.RadioIsOn())
            this.AppendMsg(this._statusMsg, DashboardStringHelper.GetString("Dashboard_TurningWiMAXOn"));
          else
            this.AppendMsg(this._statusMsg, DashboardStringHelper.GetString("Dashboard_TurningWiMAXOff"));
        }
        else if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForConnect)
        {
          string profileDisplayName = DashboardAndTaskTray.GetPreferredProfileDisplayName();
          if (NetworkHandler.ConnectedNetworks.Count > 0)
            this.AppendMsg(this._statusMsg, string.Format(DashboardStringHelper.GetString("Dashboard_ReconnectingToX"), (object) WiMAXDisplayService.Singleton.GetNetworkNameDisplayText(NetworkHandler.ConnectedNetworks[0].WmxNetwork)));
          else if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.WmxNetworkBeingConnected != null)
          {
            string networkNameDisplayText = WiMAXDisplayService.Singleton.GetNetworkNameDisplayText(Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.WmxNetworkBeingConnected);
            this.AppendMsg(this._statusMsg, string.Format(DashboardStringHelper.GetString("Dashboard_ConnectingToX"), (object) networkNameDisplayText));
            this.AppendMsg(this._longOperationStatusMsg, string.Format(DashboardStringHelper.GetString("Dashboard_ConnectingToXLongOperation"), (object) networkNameDisplayText));
          }
          else if (!string.IsNullOrEmpty(profileDisplayName))
          {
            this.AppendMsg(this._statusMsg, string.Format(DashboardStringHelper.GetString("Dashboard_ConnectingToX"), (object) profileDisplayName));
            this.AppendMsg(this._longOperationStatusMsg, string.Format(DashboardStringHelper.GetString("Dashboard_ConnectingToXLongOperation"), (object) profileDisplayName));
          }
          else
          {
            this.AppendMsg(this._statusMsg, DashboardStringHelper.GetString("Dashboard_ConnectingToNetwork"));
            this.AppendMsg(this._longOperationStatusMsg, DashboardStringHelper.GetString("Dashboard_ConnectingToNetworkLongOperation"));
          }
        }
        else if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForDisconnect)
        {
          if (eventArgs != null && eventArgs.Length > 0)
            this.AppendMsg(this._statusMsg, string.Format(DashboardStringHelper.GetString("Dashboard_DisconnectingFromX"), (object) WiMAXDisplayService.Singleton.GetNetworkNameDisplayText((WiMAXNetwork) eventArgs[0])));
          else
            this.AppendMsg(this._statusMsg, DashboardStringHelper.GetString("Dashboard_DisconnectingFromNetwork"));
        }
        else if (!AppFramework.Dashboard.Expanded && Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForScan)
        {
          string profileDisplayName = DashboardAndTaskTray.GetPreferredProfileDisplayName();
          if (string.IsNullOrEmpty(profileDisplayName))
            this.AppendMsg(this._statusMsg, DashboardStringHelper.GetString("Dashboard_SearchingForNetworks"));
          else
            this.AppendMsg(this._statusMsg, string.Format(DashboardStringHelper.GetString("Dashboard_SearchingForX"), (object) profileDisplayName));
        }
        else if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForStopConnect)
          this.AppendMsg(this._statusMsg, DashboardStringHelper.GetString("Dashboard_StoppingConnect"));
        else if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForStopScan)
          this.AppendMsg(this._statusMsg, DashboardStringHelper.GetString("Dashboard_StoppingSearch"));
      }
      this.UpdateUI();
    }

    private void OnNetworkListChanged(object sender, object[] eventArgs)
    {
      this.UpdateUI();
    }

    private void OnOngoingScanNetworkListChanged(object sender, object[] eventArgs)
    {
      this.UpdateUI();
    }

    public void OnStateChange(object sender, object[] eventArgs)
    {
      this.HandleStateChange(eventArgs);
    }

    private void CustomInitializeComponents()
    {
      this.AccessibleName = "ConnectionPanel";
      this.SearchPushButton.AccessibleName = "ConnectionPanel_SearchPushButton";
      this.BtnBoxSearch.AccessibleName = "ConnectionPanel_BtnBoxSearch";
      this.ConnectPushButton.AccessibleName = "ConnectionPanel_ConnectPushButton";
      this.BtnBoxConnect.AccessibleName = "ConnectionPanel_BtnBoxConnect";
      this.ConnectionBrandingPanel.AccessibleName = "ConnectionPanel_ConnectionBrandingPanel";
      this.BtnBoxOptionsWiFiHelp.AccessibleName = "ConnectionPanel_BtnBoxOptionsHelp";
      this.OptionsMenuButton.AccessibleName = "ConnectionPanel_OptionsMenuButton";
      this.WiFiMenuButton.AccessibleName = "ConnectionPanel_WiFiMenuButton";
      this.HelpMenuButton.AccessibleName = "ConnectionPanel_HelpMenuButton";
      this.RadioOnOffRadioButtonGrp.AccessibleName = "ConnectionPanel_RadioOnOffRadioButtonGrp";
      this.RadioLbl.AccessibleName = "ConnectionPanel_RadioLbl";
      this.BtnBoxDetailsDisconnect.AccessibleName = "ConnectionPanel_BtnBoxDetailsDisconnect";
      this.ConnectionDetailsStatus.AccessibleName = "ConnectionPanel_ConnectionDetailsStatus";
      this.ConnectionDetailsNone.AccessibleName = "ConnectionPanel_ConnectionDetailsNone";
      this.ConnectionSubDetailUptime.AccessibleName = "ConnectionPanel_ConnectionSubDetailUptime";
      this.ConnectionSubDetails.AccessibleName = "ConnectionPanel_ConnectionSubDetails";
      this.DetailsPushButton.AccessibleName = "ConnectionPanel_DetailsPushButton";
      this.DisconnectPushButton.AccessibleName = "ConnectionPanel_DisconnectPushButton";
      this.ConnectionDetails.AccessibleName = "ConnectionPanel_ConnectionDetails";
      this.OptionsMenuButton.ForeColor = Color.FromArgb(42, 125, 193);
      this.OptionsMenuButton.Text = DashboardStringHelper.GetString("Options");
      this.SetContextMenuForOptionsButton();
      this.WiFiMenuButton.ForeColor = Color.FromArgb(42, 125, 193);
      this.WiFiMenuButton.Text = DashboardStringHelper.GetString("WiFi");
      this.SetContextMenuForWiFiButton();
      this.HelpMenuButton.ForeColor = Color.FromArgb(42, 125, 193);
      this.HelpMenuButton.Text = DashboardStringHelper.GetString("Help");
      this.SetContextMenuForHelpButton();
      this.DetailsPushButton.BtnText = DashboardStringHelper.GetString("Details");
      this.DetailsPushButton.Pressed += new CustomButtonPush.PressedDelegate(this.OnDetailsBtnPressed);
      this.DisconnectPushButton.BtnText = DashboardStringHelper.GetString("Disconnect");
      this.DisconnectPushButton.Pressed += new CustomButtonPush.PressedDelegate(this.OnDisconnectBtnPressed);
      this.ConnectPushButton.BtnText = DashboardStringHelper.GetString("Connect");
      this.ConnectPushButton.Pressed += new CustomButtonPush.PressedDelegate(this.OnConnectBtnPressed);
      this.SearchPushButton.BtnText = DashboardStringHelper.GetString("Search");
      this.SearchPushButton.Pressed += new CustomButtonPush.PressedDelegate(this.OnSearchForNetworkBtnPressed);
      this.RadioLbl.Text = DashboardStringHelper.GetString("WiMAXRadioColon");
      this.RadioOnOffRadioButtonGrp.State = this.GetDesiredRadioButtonState();
      this.RadioOnOffRadioButtonGrp.SelectionChanged += new CustomRadioButtonGroup.SelectionChangedDelegate(this.OnRadioOnOffRadioButtonGrpSelectionChanged);
      this.RadioLbl.Top = this.BtnBoxConnect.Top;
      this.RadioOnOffRadioButtonGrp.Top = this.BtnBoxConnect.Top;
      if (this.RadioOnOffRadioButtonGrp.Orientation == RadioButtonOrientation.Vertical)
      {
        CustomRadioButtonOnOff radioButtonOnOff = this.RadioOnOffRadioButtonGrp;
        int num = radioButtonOnOff.Top - 3;
        radioButtonOnOff.Top = num;
      }
      else if (this.RadioLbl.Text.Length >= 7)
        this.RadioOnOffRadioButtonGrp.Location = new Point(this.RadioOnOffRadioButtonGrp.Location.X, this.RadioOnOffRadioButtonGrp.Location.Y + (this.RadioLbl.Height - this.RadioOnOffRadioButtonGrp.Height) / 2 + 4);
      if (!WiFiHandler.Singleton.IsWiFiReady())
      {
        Logging.LogEvent(TraceModule.Dashboard, TraceLevel.Verbose, (object) this, "--- WiFi is NOT READY at startup -> Removing the WiFi menu and setting timer.");
        this.BtnBoxOptionsWiFiHelp.Controls.Remove((Control) this.WiFiMenuButton);
        this._addWiFiMenuTimer = new Timer();
        this._addWiFiMenuTimer.Interval = 2500;
        this._addWiFiMenuTimer.Tick += new EventHandler(this.OnAddWiFiMenuTimerTick);
        this._addWiFiMenuTimer.Start();
      }
      else if (WiFiHandler.Singleton.IsWiFiAvailable())
      {
        Logging.LogEvent(TraceModule.Dashboard, TraceLevel.Verbose, (object) this, "--- WiFi is READY at startup -> Combo card detected.");
      }
      else
      {
        Logging.LogEvent(TraceModule.Dashboard, TraceLevel.Verbose, (object) this, "--- WiFi is READY at startup -> WiFi is NOT on Combo Card.");
        this._wifiBeingControlledByComboCard = false;
        if (!LocalMachineSettings.IsDualModeWarningEnabled())
        {
          this.BtnBoxOptionsWiFiHelp.Controls.Remove((Control) this.WiFiMenuButton);
          Logging.LogEvent(TraceModule.Dashboard, TraceLevel.Verbose, (object) this, "--- WiFi Dual Mode NOT enabled -> Removing the WiFi menu permanently.");
        }
      }
      this.ConnectionBrandingPanel.InitPanel();
    }

    private void OnAddWiFiMenuTimerTick(object sender, EventArgs e)
    {
      if (!WiFiHandler.Singleton.IsWiFiReady())
        return;
      this._addWiFiMenuTimer.Stop();
      if (WiFiHandler.Singleton.IsWiFiAvailable())
      {
        Logging.LogEvent(TraceModule.Dashboard, TraceLevel.Verbose, (object) this, "--- WiFi is now READY -> Adding WiFi menu for combo card.");
        this.BtnBoxOptionsWiFiHelp.Controls.Clear();
        this.BtnBoxOptionsWiFiHelp.Controls.Add((Control) this.OptionsMenuButton);
        this.BtnBoxOptionsWiFiHelp.Controls.Add((Control) this.WiFiMenuButton);
        this.BtnBoxOptionsWiFiHelp.Controls.Add((Control) this.HelpMenuButton);
        this.BtnBoxOptionsWiFiHelp.ResizeMe();
      }
      else
      {
        Logging.LogEvent(TraceModule.Dashboard, TraceLevel.Verbose, (object) this, "--- WiFi is now READY -> WiFi is NOT on Combo Card.");
        this._wifiBeingControlledByComboCard = false;
        if (!LocalMachineSettings.IsDualModeWarningEnabled())
          return;
        Logging.LogEvent(TraceModule.Dashboard, TraceLevel.Verbose, (object) this, "--- WiFi Dual Mode is enabled -> Adding WiFi menu.");
        this.BtnBoxOptionsWiFiHelp.Controls.Clear();
        this.BtnBoxOptionsWiFiHelp.Controls.Add((Control) this.OptionsMenuButton);
        this.BtnBoxOptionsWiFiHelp.Controls.Add((Control) this.WiFiMenuButton);
        this.BtnBoxOptionsWiFiHelp.Controls.Add((Control) this.HelpMenuButton);
        this.BtnBoxOptionsWiFiHelp.ResizeMe();
      }
    }

    private void SetContextMenuForOptionsButton()
    {
      ContextMenu contextMenu = new ContextMenu();
      if (ConnectionPanel._preferencesMenuItem == null)
      {
        ConnectionPanel._preferencesMenuItem = new MenuItem();
        ConnectionPanel._preferencesMenuItem.Text = DashboardStringHelper.GetString("PreferencesEllipse");
        ConnectionPanel._preferencesMenuItem.Click += new EventHandler(this.OnPreferencesSelected);
      }
      contextMenu.MenuItems.Add(ConnectionPanel._preferencesMenuItem);
      if (ConnectionPanel._manageNetworksMenuItem == null)
      {
        ConnectionPanel._manageNetworksMenuItem = new MenuItem();
        ConnectionPanel._manageNetworksMenuItem.Text = DashboardStringHelper.GetString("ManageNetworksEllipse");
        ConnectionPanel._manageNetworksMenuItem.Click += new EventHandler(this.OnManageNetworksSelected);
      }
      contextMenu.MenuItems.Add(ConnectionPanel._manageNetworksMenuItem);
      if (ConnectionPanel._advancedMenuItem == null)
      {
        ConnectionPanel._advancedMenuItem = new MenuItem();
        ConnectionPanel._advancedMenuItem.Text = DashboardStringHelper.GetString("AdvancedEllipse");
        ConnectionPanel._advancedMenuItem.Click += new EventHandler(this.OnAdvancedSelected);
      }
      contextMenu.MenuItems.Add(ConnectionPanel._advancedMenuItem);
      if (CurrentUserSettings.ShowApdoFumoSimulator())
      {
        this.AddSeparator(ref contextMenu);
        MenuItem menuItem = new MenuItem();
        menuItem.Text = "APDO/FUMO Simulator...";
        menuItem.Click += new EventHandler(this.OnApdoFumoSimulatorSelected);
        contextMenu.MenuItems.Add(menuItem);
      }
      this.OptionsMenuButton.TheContextMenu = contextMenu;
    }

    private void SetContextMenuForWiFiButton()
    {
      ContextMenu contextMenu = new ContextMenu();
      if (ConnectionPanel._wifiOnMenuItem == null)
      {
        ConnectionPanel._wifiOnMenuItem = new MenuItem();
        ConnectionPanel._wifiOnMenuItem.Text = DashboardStringHelper.GetString("WiFiOn");
        ConnectionPanel._wifiOnMenuItem.Click += new EventHandler(this.OnWiFiOnSelected);
        ConnectionPanel._wifiOnMenuItem.RadioCheck = true;
      }
      contextMenu.MenuItems.Add(ConnectionPanel._wifiOnMenuItem);
      if (ConnectionPanel._wifiOffMenuItem == null)
      {
        ConnectionPanel._wifiOffMenuItem = new MenuItem();
        ConnectionPanel._wifiOffMenuItem.Text = DashboardStringHelper.GetString("WiFiOff");
        ConnectionPanel._wifiOffMenuItem.Click += new EventHandler(this.OnWiFiOffSelected);
        ConnectionPanel._wifiOffMenuItem.RadioCheck = true;
      }
      contextMenu.MenuItems.Add(ConnectionPanel._wifiOffMenuItem);
      contextMenu.Popup += new EventHandler(this.WiFiMenuPopup);
      this.WiFiMenuButton.TheContextMenu = contextMenu;
    }

    private void SetContextMenuForHelpButton()
    {
      ContextMenu contextMenu = new ContextMenu();
      if (ConnectionPanel._helpMenuItem == null)
      {
        ConnectionPanel._helpMenuItem = new MenuItem();
        ConnectionPanel._helpMenuItem.Shortcut = Shortcut.F1;
        ConnectionPanel._helpMenuItem.Text = DashboardStringHelper.GetString("Help");
        ConnectionPanel._helpMenuItem.Click += new EventHandler(this.OnHelpSelected);
      }
      contextMenu.MenuItems.Add(ConnectionPanel._helpMenuItem);
      if (ConnectionPanel._techSupportMenuItem == null)
      {
        ConnectionPanel._techSupportMenuItem = new MenuItem();
        ConnectionPanel._techSupportMenuItem.Text = DashboardStringHelper.GetString("TechSupportEllipse");
        ConnectionPanel._techSupportMenuItem.Click += new EventHandler(this.OnTechSupportSelected);
      }
      contextMenu.MenuItems.Add(ConnectionPanel._techSupportMenuItem);
      this.AddSeparator(ref contextMenu);
      if (ConnectionPanel._aboutMenuItem == null)
      {
        ConnectionPanel._aboutMenuItem = new MenuItem();
        ConnectionPanel._aboutMenuItem.Text = DashboardStringHelper.GetString("AboutEllipse");
        ConnectionPanel._aboutMenuItem.Click += new EventHandler(this.OnAboutSelected);
      }
      contextMenu.MenuItems.Add(ConnectionPanel._aboutMenuItem);
      this.HelpMenuButton.TheContextMenu = contextMenu;
    }

    private void AddSeparator(ref ContextMenu contextMenu)
    {
      MenuItem menuItem = new MenuItem("-");
      contextMenu.MenuItems.Add(menuItem);
    }

    private OnOffRadioButtonState GetDesiredRadioButtonState()
    {
      return MediaHandler.IntelCUIsInControl && MediaHandler.TheMedia.WiMAXIsReady && AdapterHandler.TheAdapter.SoftwareRadioOn ? OnOffRadioButtonState.On : OnOffRadioButtonState.Off;
    }

    private void RegisterForEvents()
    {
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnNetworkListChanged), (object) this, "WiMAXUI.OnNetworkListChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnOngoingScanNetworkListChanged), (object) this, "WiMAXUI.OnOngoingScanNetworkListChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnStateChange), (object) this, "WiMAXUI.OnStateChange");
    }

    private void UpdatePanelState()
    {
      bool visible1 = this.ConnectionBrandingPanel.Visible;
      bool visible2 = this.ConnectionDetails.Visible;
      bool visible3 = this.ConnectionSubDetails.Visible;
      bool visible4 = this.ConnectionSubDetailUptime.Visible;
      bool visible5 = this.ConnectionDetailsNone.Visible;
      bool visible6 = this.ConnectionDetailsStatus.Visible;
      bool visible7 = this.BtnBoxDetailsDisconnect.Visible;
      if (!MediaHandler.TheMedia.WiMAXIsReady || !MediaHandler.IntelCUIsInControl)
      {
        this.ConnectionDetailsNone.UpdateUI();
        this.ShowConnectionDetailsNone();
      }
      else if (this._statusMsg.Length > 0)
      {
        this.ConnectionDetailsStatus.StatusMessageToShow = ((object) this._statusMsg).ToString();
        this.ConnectionDetailsStatus.LongOperationStatusMessageToShow = ((object) this._longOperationStatusMsg).ToString();
        this.ConnectionDetailsStatus.StatusImageToShow = !Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForScan ? (!Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForConnect ? (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForDisconnect || Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForRadioSwitch || (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForStopScan || Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForStopConnect) ? StatusImageEnum.Application : StatusImageEnum.None) : StatusImageEnum.Connecting) : StatusImageEnum.Searching;
        this.ShowConnectionDetailsStatus();
      }
      else if (!AdapterHandler.TheAdapter.RadioIsOn() || NetworkHandler.ConnectedNetworks == null || NetworkHandler.ConnectedNetworks.Count == 0)
      {
        this.ConnectionDetailsNone.UpdateUI();
        this.ShowConnectionDetailsNone();
      }
      else
      {
        this.ConnectionDetails.UpdateUI();
        this.ConnectionSubDetails.UpdateUI();
        this.ConnectionSubDetailUptime.UpdateUI();
        this.ShowConnectionDetails();
      }
      if (visible1 == this.ConnectionBrandingPanel.Visible && visible2 == this.ConnectionDetails.Visible && (visible3 == this.ConnectionSubDetails.Visible && visible4 == this.ConnectionSubDetailUptime.Visible) && (visible5 == this.ConnectionDetailsNone.Visible && visible6 == this.ConnectionDetailsStatus.Visible && visible7 == this.BtnBoxDetailsDisconnect.Visible))
        return;
      this.Invalidate();
    }

    private void ShowConnectionDetailsNone()
    {
      this.ConnectionBrandingPanel.Visible = true;
      this.ConnectionDetails.Visible = false;
      this.ConnectionSubDetails.Visible = false;
      this.ConnectionSubDetailUptime.Visible = false;
      this.ConnectionDetailsNone.Visible = true;
      this.ConnectionDetailsStatus.Visible = false;
      this.BtnBoxDetailsDisconnect.Visible = false;
    }

    private void ShowConnectionDetailsStatus()
    {
      this.ConnectionBrandingPanel.Visible = true;
      this.ConnectionDetails.Visible = false;
      this.ConnectionSubDetails.Visible = false;
      this.ConnectionSubDetailUptime.Visible = false;
      this.ConnectionDetailsNone.Visible = false;
      this.ConnectionDetailsStatus.Visible = true;
      this.BtnBoxDetailsDisconnect.Visible = true;
    }

    private void ShowConnectionDetails()
    {
      this.ConnectionBrandingPanel.Visible = true;
      this.ConnectionDetails.Visible = true;
      this.ConnectionSubDetails.Visible = true;
      this.ConnectionSubDetailUptime.Visible = true;
      this.ConnectionDetailsNone.Visible = false;
      this.ConnectionDetailsStatus.Visible = false;
      this.BtnBoxDetailsDisconnect.Visible = true;
    }

    private void UpdateButtonState()
    {
      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = false;
      bool flag4 = Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.ShouldControlBeEnabled(DashboardControlEnum.ConnectionPanel_DetailsBtn);
      bool flag5 = Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.ShouldControlBeEnabled(DashboardControlEnum.ConnectionPanel_DisconnectBtn);
      bool flag6 = Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.ShouldControlBeEnabled(DashboardControlEnum.ConnectionPanel_ConnectBtn);
      bool flag7 = Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.ShouldControlBeEnabled(DashboardControlEnum.ConnectionPanel_SearchBtn);
      bool flag8 = Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.ShouldControlBeEnabled(DashboardControlEnum.ConnectionPanel_RadioOnOffRBG);
      if (!MediaHandler.TheMedia.WiMAXIsReady || !MediaHandler.IntelCUIsInControl || !AdapterHandler.TheAdapter.HardwareRadioOn)
        flag8 = false;
      else if (AdapterHandler.TheAdapter.RadioIsOn())
      {
        if (NetworkHandler.ConnectedNetworks != null && NetworkHandler.ConnectedNetworks.Count > 0 || Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForDisconnect)
          flag1 = true;
        else if (!AppFramework.Dashboard.Expanded)
        {
          if (NetworkHandler.Singleton.GetNetworkForPreferredProfile() != null && !Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForAny || (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForConnect || Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForStopConnect))
            flag3 = true;
          else if (!Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForAny || Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForManualPreferredScan || Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForStopScan)
            flag2 = true;
        }
      }
      string str = Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForStopScan || Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForManualPreferredScan ? DashboardStringHelper.GetString("StopSearching") : DashboardStringHelper.GetString("Search");
      string @string;
      PushButtonColorEnum pushButtonColorEnum;
      if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForConnect || Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForStopConnect)
      {
        @string = DashboardStringHelper.GetString("StopConnecting");
        pushButtonColorEnum = PushButtonColorEnum.BlueGrey;
      }
      else
      {
        @string = DashboardStringHelper.GetString("Connect");
        pushButtonColorEnum = PushButtonColorEnum.GreenGrey;
      }
      OnOffRadioButtonState radioButtonState = this.GetDesiredRadioButtonState();
      if (flag1)
      {
        this.BtnBoxDetailsDisconnect.Visible = true;
        this.BtnBoxDetailsDisconnect.BringToFront();
      }
      else
      {
        this.BtnBoxDetailsDisconnect.Visible = false;
        this.BtnBoxDetailsDisconnect.SendToBack();
      }
      if (flag3)
      {
        this.BtnBoxConnect.Visible = true;
        this.BtnBoxConnect.BringToFront();
      }
      else
      {
        this.BtnBoxConnect.Visible = false;
        this.BtnBoxConnect.SendToBack();
      }
      if (flag2)
      {
        this.BtnBoxSearch.Visible = true;
        this.BtnBoxSearch.BringToFront();
      }
      else
      {
        this.BtnBoxSearch.Visible = false;
        this.BtnBoxSearch.SendToBack();
      }
      if (this.DisconnectPushButton.BtnEnabled != flag5)
      {
        this.DisconnectPushButton.BtnEnabled = flag5;
        this.DisconnectPushButton.Invalidate();
      }
      if (this.DetailsPushButton.BtnEnabled != flag4)
      {
        this.DetailsPushButton.BtnEnabled = flag4;
        this.DetailsPushButton.Invalidate();
      }
      if (this.SearchPushButton.BtnEnabled != flag7)
      {
        this.SearchPushButton.BtnEnabled = flag7;
        this.SearchPushButton.Invalidate();
      }
      if (this.ConnectPushButton.BtnEnabled != flag6)
      {
        this.ConnectPushButton.BtnEnabled = flag6;
        this.ConnectPushButton.Invalidate();
      }
      if (this.RadioOnOffRadioButtonGrp.Enabled != flag8 || radioButtonState != this.RadioOnOffRadioButtonGrp.State)
      {
        this.RadioOnOffRadioButtonGrp.Enabled = flag8;
        this.RadioOnOffRadioButtonGrp.SelectionChanged -= new CustomRadioButtonGroup.SelectionChangedDelegate(this.OnRadioOnOffRadioButtonGrpSelectionChanged);
        this.RadioOnOffRadioButtonGrp.State = radioButtonState;
        this.RadioOnOffRadioButtonGrp.Invalidate();
        this.RadioOnOffRadioButtonGrp.SelectionChanged += new CustomRadioButtonGroup.SelectionChangedDelegate(this.OnRadioOnOffRadioButtonGrpSelectionChanged);
      }
      if (str != this.SearchPushButton.BtnText)
      {
        this.SearchPushButton.BtnText = str;
        this.BtnBoxSearch.ResizeMe();
        this.SearchPushButton.Invalidate();
      }
      if (!(@string != this.ConnectPushButton.BtnText))
        return;
      this.ConnectPushButton.BtnText = @string;
      this.ConnectPushButton.BtnColor = pushButtonColorEnum;
      this.BtnBoxConnect.ResizeMe();
      this.ConnectPushButton.Invalidate();
    }

    private void AppendMsg(StringBuilder sb, string msg)
    {
      if (sb.Length > 0)
        sb.Append("\r\n");
      sb.Append(msg);
    }
  }
}
