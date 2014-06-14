// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.Timers
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.UI.Dashboard.Properties;
using System;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class Timers
  {
    private ClickableCustomMessageBox _computerIsEnabledForWiMAXCMB = new ClickableCustomMessageBox((string) null, (string) null, (LinkLabelLinkClickedEventHandler) null);
    private Timer _pollForSignalChangesTimer;
    private Timer _pollForIPAddressTimer;
    private Timer _computerIsEnabledForWiMAXPopupTimer;
    private DateTime _ipAddressPolingStartTime;
    private Timer _resetTrayIconVisibilityTimer;

    public Timers()
    {
      this.CreateTimers();
      this.RegisterForEvents();
    }

    private void OnPollForSignalChangesTick(object sender, EventArgs e)
    {
      NetworkHandler.Singleton.CheckForNetworkPropertyChanges();
    }

    private void OnPollForIPAddressTick(object sender, EventArgs e)
    {
      if (DateTime.Now > new DateTime(this._ipAddressPolingStartTime.Ticks + new TimeSpan(10000L * (long) TimerSettings.NetworksCache_IpAddressGiveUpTimer_DueTime).Ticks + new TimeSpan(5000L).Ticks) || NetworkHandler.ConnectedNetworks.Count == 0 || MiscUtilities.IsValidIPAddress(NetworkHandler.ConnectedNetworks[0].WmxNetwork.Connection.IPv4Address))
        this._pollForIPAddressTimer.Stop();
      NetworkHandler.Singleton.CheckForNetworkPropertyChanges();
    }

    private void OnComputerIsEnabledForWiMAXPopupTick(object sender, EventArgs e)
    {
      this._computerIsEnabledForWiMAXPopupTimer.Stop();
      if (this._computerIsEnabledForWiMAXCMB.Visible || !CurrentUserSettings.GetShowComputerIsEnabledForWiMAXPopup())
        return;
      string @string = DashboardStringHelper.GetString("CapitalClickHere_Clickable");
      this._computerIsEnabledForWiMAXCMB = new ClickableCustomMessageBox(string.Format(TaskTrayStringHelper.GetString("TaskTray_Prompt_ComputerIsEnabledForWiMAX"), (object) @string), @string, new LinkLabelLinkClickedEventHandler(this.OnComputerIsEnabledForWiMAXClicked), CustomMessageBoxStyle.Ok, DontShowThisMessageAgainOptions.ComputerIsEnabledForWiMAXPopup);
      this._computerIsEnabledForWiMAXCMB.AccessibleName = "ComputerIsEnabledForWiMAXMB";
      this._computerIsEnabledForWiMAXCMB.LocationOfMessageBox = CustomMessageBoxLocation.AlwaysInTaskTrayBottom;
      this._computerIsEnabledForWiMAXCMB.CustomShow((IWin32Window) null, true);
    }

    private void OnComputerIsEnabledForWiMAXClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      OnlineHelp.LaunchHelp("/overview.htm");
    }

    public void OnPostInitApplication(object sender, object[] eventArgs)
    {
      if (NetworkHandler.ConnectedNetworks.Count <= 0 || MiscUtilities.IsValidIPAddress(NetworkHandler.ConnectedNetworks[0].WmxNetwork.Connection.IPv4Address))
        return;
      this.StartPollingForIPAddress();
    }

    public void OnConnected(object sender, object[] eventArgs)
    {
      if (NetworkHandler.ConnectedNetworks.Count <= 0 || MiscUtilities.IsValidIPAddress(NetworkHandler.ConnectedNetworks[0].WmxNetwork.Connection.IPv4Address))
        return;
      this.StartPollingForIPAddress();
    }

    private void StartPollingForIPAddress()
    {
      this._ipAddressPolingStartTime = DateTime.Now;
      if (this._pollForIPAddressTimer == null)
        return;
      this._pollForIPAddressTimer.Start();
    }

    private void CreateTimers()
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      Settings settings = new Settings();
      if (this._pollForSignalChangesTimer == null)
      {
        this._pollForSignalChangesTimer = new Timer();
        this._pollForSignalChangesTimer.Tick += new EventHandler(this.OnPollForSignalChangesTick);
        this._pollForSignalChangesTimer.Interval = TimerSettings.Timers_PollForSignalChangesTimer_Interval;
      }
      this._pollForSignalChangesTimer.Start();
      if (this._pollForIPAddressTimer == null)
      {
        this._pollForIPAddressTimer = new Timer();
        this._pollForIPAddressTimer.Tick += new EventHandler(this.OnPollForIPAddressTick);
        this._pollForIPAddressTimer.Interval = TimerSettings.Timers_PollForIPAddressTimer_Interval;
      }
      if (CurrentUserSettings.GetShowComputerIsEnabledForWiMAXPopup())
      {
        if (this._computerIsEnabledForWiMAXPopupTimer == null)
        {
          this._computerIsEnabledForWiMAXPopupTimer = new Timer();
          this._computerIsEnabledForWiMAXPopupTimer.Tick += new EventHandler(this.OnComputerIsEnabledForWiMAXPopupTick);
          this._computerIsEnabledForWiMAXPopupTimer.Interval = TimerSettings.Timers_ComputerIsEnabledForWiMAXPopupTimer_Interval;
        }
        this._computerIsEnabledForWiMAXPopupTimer.Start();
      }
      if (this._resetTrayIconVisibilityTimer != null)
        return;
      this._resetTrayIconVisibilityTimer = new Timer();
      this._resetTrayIconVisibilityTimer.Tick += new EventHandler(this.OnResetTrayIconVisibilityTimerTick);
      this._resetTrayIconVisibilityTimer.Interval = TimerSettings.Timers_ResetTrayIconVisibilityTimer_Interval;
      this._resetTrayIconVisibilityTimer.Start();
    }

    private void OnResetTrayIconVisibilityTimerTick(object sender, EventArgs e)
    {
      this._resetTrayIconVisibilityTimer.Stop();
      AppFramework.Dashboard.ResetTrayIconVisibility();
    }

    private void RegisterForEvents()
    {
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnPostInitApplication), (object) this, "WiMAXUI.OnPostInitApplication");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnConnected), (object) this, "WiMAXSP.OnConnected");
    }
  }
}
