// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.ConnectionSubDetailUptime
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using Intel.Mobile.WiMAXCU.Common;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class ConnectionSubDetailUptime : UserControl
  {
    private static TimeSpan _connectedTime = new TimeSpan();
    private static string _connectedTimeStr = "";
    private Label UptimeLabel;
    private IContainer components;
    private Timer _updateTimeConnectedTimer;

    public static string ConnectedTime
    {
      get
      {
        return ConnectionSubDetailUptime._connectedTimeStr;
      }
      set
      {
        ConnectionSubDetailUptime._connectedTimeStr = value;
      }
    }

    static ConnectionSubDetailUptime()
    {
    }

    public ConnectionSubDetailUptime()
    {
      this.InitializeComponent();
      this.CustomInitializeComponents();
      this.RegisterForEvents();
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.BackColor = Color.Transparent;
      this.StartOrStopTimer();
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ConnectionSubDetailUptime));
      this.UptimeLabel = new Label();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.UptimeLabel, "UptimeLabel");
      this.UptimeLabel.Name = "UptimeLabel";
      this.Controls.Add((Control) this.UptimeLabel);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "ConnectionSubDetailUptime";
      this.ResumeLayout(false);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (this.components != null)
          this.components.Dispose();
        Eventing.DeRegisterAllUIEvents((object) this);
        if (this._updateTimeConnectedTimer != null)
          this._updateTimeConnectedTimer.Stop();
      }
      base.Dispose(disposing);
    }

    protected override void OnVisibleChanged(EventArgs e)
    {
      if (this.Visible)
        this.ResetTimeConnected();
      base.OnVisibleChanged(e);
    }

    private void StartOrStopTimer()
    {
      if (this._updateTimeConnectedTimer == null)
      {
        this._updateTimeConnectedTimer = new Timer();
        this._updateTimeConnectedTimer.Tick += new EventHandler(this.OnUpdateTimeConnectedTick);
        this._updateTimeConnectedTimer.Interval = TimerSettings.ConnectionSubDetailUptime_UpdateTimeConnectedTimer_Interval;
      }
      if (MediaHandler.TheMedia.WiMAXIsReady && MediaHandler.IntelCUIsInControl && (AdapterHandler.TheAdapter.RadioIsOn() && NetworkHandler.ConnectedNetworks.Count > 0))
        this._updateTimeConnectedTimer.Start();
      else
        this._updateTimeConnectedTimer.Stop();
    }

    private void OnUpdateTimeConnectedTick(object sender, EventArgs e)
    {
      if (NetworkHandler.ConnectedNetworks.Count == 0)
        return;
      ConnectionSubDetailUptime._connectedTime = ConnectionSubDetailUptime._connectedTime.Add(new TimeSpan(0, 0, 1));
      if (this.Parent == null || !this.Parent.Visible)
        return;
      this.UpdateUI();
    }

    public void OnNetworkListChanged(object sender, object[] eventArgs)
    {
      this.ResetTimeConnected();
      this.StartOrStopTimer();
    }

    public void OnSomethingChanged(object sender, object[] eventArgs)
    {
      this.StartOrStopTimer();
    }

    public void UpdateUI()
    {
      if (ConnectionSubDetailUptime._connectedTime.Days == 0)
        ConnectionSubDetailUptime._connectedTimeStr = string.Format(DashboardStringHelper.GetString("UptimeFormat"), (object) ConnectionSubDetailUptime._connectedTime.Hours, (object) ConnectionSubDetailUptime._connectedTime.Minutes, (object) ConnectionSubDetailUptime._connectedTime.Seconds);
      else if (ConnectionSubDetailUptime._connectedTime.Days == 1)
        ConnectionSubDetailUptime._connectedTimeStr = string.Format(DashboardStringHelper.GetString("UptimeFormatOneDay"), (object) ConnectionSubDetailUptime._connectedTime.Hours, (object) ConnectionSubDetailUptime._connectedTime.Minutes, (object) ConnectionSubDetailUptime._connectedTime.Seconds);
      else
        ConnectionSubDetailUptime._connectedTimeStr = string.Format(DashboardStringHelper.GetString("UptimeFormatXDays"), (object) ConnectionSubDetailUptime._connectedTime.Days, (object) ConnectionSubDetailUptime._connectedTime.Hours, (object) ConnectionSubDetailUptime._connectedTime.Minutes, (object) ConnectionSubDetailUptime._connectedTime.Seconds);
      this.UptimeLabel.Text = ConnectionSubDetailUptime._connectedTimeStr;
    }

    private void CustomInitializeComponents()
    {
      this.AccessibleName = "ConnectionSubDetailUptime";
      this.UptimeLabel.AccessibleName = "ConnectionPanel_ConnectionSubDetailUptime_UptimeLabel";
    }

    private void RegisterForEvents()
    {
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnNetworkListChanged), (object) this, "WiMAXUI.OnNetworkListChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnSomethingChanged), (object) this, "WiMAXUI.OnMediaStatusChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnSomethingChanged), (object) this, "WiMAXUI.OnAdapterListChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnSomethingChanged), (object) this, "WiMAXUI.OnIntelCUControlChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnSomethingChanged), (object) this, "WiMAXUI.OnPostInitApplication");
    }

    private void ResetTimeConnected()
    {
      int numSecondsConnected = 0;
      NetworkHandler.Singleton.GetConnectionTime(ref numSecondsConnected);
      if (NetworkHandler.ConnectedNetworks.Count == 1)
        ConnectionSubDetailUptime._connectedTime = new TimeSpan(0, 0, numSecondsConnected);
      else
        ConnectionSubDetailUptime._connectedTime = new TimeSpan(0, 0, 0);
    }
  }
}
