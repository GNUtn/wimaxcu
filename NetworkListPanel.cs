// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.NetworkListPanel
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.SDKInterop;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class NetworkListPanel : UserControl
  {
    protected bool _drawDivider = true;
    private int _normalNetworkListBoxHeight;
    private int _normalNetworkListMessageHeight;
    private bool _statusBarVisible;
    private IContainer components;
    protected NetworkListMessage NetworkListMessage;
    protected CustomButtonPushHorizBox ButtonBoxConnect;
    protected CustomButtonPush ConnectPushButton;
    protected NetworkListBox NetworkListBox;
    protected CustomButtonPush SearchForNetworksPushButton;
    private NetworkListStatusBar NetworkListStatusBar;
    private Label AvailableWiMAXNeworksLabel;

    public NetworkListBox TheNetworkListBox
    {
      get
      {
        return this.NetworkListBox;
      }
    }

    public NetworkListStatusBar TheStatusBar
    {
      get
      {
        return this.NetworkListStatusBar;
      }
    }

    public NetworkListPanel()
    {
      this.InitializeComponent();
      this.CustomInitializeComponents();
      this.RegisterForEvents();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (this._drawDivider)
      {
        int x = this.NetworkListBox.Location.X;
        e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
        e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
        Bitmap ncDividerPixel = ImageHelper.NcDividerPixel;
        Point[] destPoints = new Point[3]
        {
          new Point(x, 0),
          new Point(this.NetworkListBox.Width + x, 0),
          new Point(x, ncDividerPixel.Height)
        };
        e.Graphics.DrawImage((Image) ncDividerPixel, destPoints);
      }
      base.OnPaint(e);
    }

    private void OnSearchForNetworksBtnPressed(object sender, EventArgs e)
    {
      if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForManualWideScan)
      {
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user pressed the 'Stop Search' button.");
        int errorCode = NetworkHandler.Singleton.StopScan();
        if (errorCode == 0)
          return;
        ErrorHelper.ShowErrorDialog((Control) AppFramework.Dashboard, ErrorStringsHelper.GetString("General_StopSearchFailed"), ErrorHelper.TranslateErrorCodeToMessage(errorCode), (string) null, "StopSearchFailed");
      }
      else
      {
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user pressed the 'Search for Networks' button.");
        int errorCode = NetworkHandler.Singleton.StartWideScan();
        if (errorCode == 0)
          return;
        ErrorHelper.ShowErrorDialog((Control) AppFramework.Dashboard, ErrorStringsHelper.GetString("General_ScanFailed"), ErrorHelper.TranslateErrorCodeToMessage(errorCode), (string) null, "SearchFailed");
      }
    }

    private bool SetNetworkListMessage()
    {
      this.NetworkListMessage.SetMessageText("", (string) null, (LinkLabelLinkClickedEventHandler) null);
      return false;
    }

    private void UpdateSearchForNetworksPushButtonState()
    {
      bool btnEnabled = this.SearchForNetworksPushButton.BtnEnabled;
      string btnText = this.SearchForNetworksPushButton.BtnText;
      this.SearchForNetworksPushButton.BtnEnabled = Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.ShouldControlBeEnabled(DashboardControlEnum.NetworkListPanel_SearchForNetworksBtn);
      if (!MediaHandler.TheMedia.WiMAXIsReady || !MediaHandler.IntelCUIsInControl || (!AdapterHandler.TheAdapter.RadioIsOn() || NetworkHandler.ConnectedNetworks.Count > 0))
        this.SearchForNetworksPushButton.BtnEnabled = false;
      this.SearchForNetworksPushButton.BtnText = Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForStopScan || Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForManualWideScan ? DashboardStringHelper.GetString("StopSearching") : DashboardStringHelper.GetString("SearchForNetworks");
      if (btnEnabled == this.SearchForNetworksPushButton.BtnEnabled && !(btnText != this.SearchForNetworksPushButton.BtnText))
        return;
      this.SearchForNetworksPushButton.ResizeMe();
      this.SearchForNetworksPushButton.Invalidate();
    }

    private bool ShouldConnectButtonBeEnabled()
    {
      return Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.ShouldControlBeEnabled(DashboardControlEnum.NetworkListPanel_ConnectBtn);
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
        this.ConnectSelectedNetwork();
      }
    }

    public virtual void UpdateUI(bool recreateNetworksListbox)
    {
      this.DoUpdateUI(recreateNetworksListbox);
    }

    public virtual bool ShowStatusBar()
    {
      return Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForScan;
    }

    public void ViewDetailsForSelectedNetwork()
    {
      if (this.NetworkListBox.GetSelectedNDI() == null)
        return;
      AppFramework.Dashboard.ShowNetworkDetailsDialog();
    }

    public void EditPropertiesForSelectedNetwork()
    {
      NetworkDisplayItem selectedNdi = this.NetworkListBox.GetSelectedNDI();
      if (selectedNdi == null)
        return;
      AppFramework.Dashboard.ShowNetworkProperitesDialog(selectedNdi);
    }

    public void HandleStateChange()
    {
      this.UpdateUI(false);
    }

    public void UnregisterForEvents()
    {
      Eventing.DeRegisterAllUIEvents((object) this);
      this.NetworkListStatusBar.Cleanup();
    }

    public void ConnectSelectedNetwork()
    {
      NetworkDisplayItem selectedNdi = this.NetworkListBox.GetSelectedNDI();
      if (selectedNdi == null)
        return;
      DashboardAndTaskTray.ConnectToNetwork(selectedNdi);
    }

    public void OnAvailableNetworkListSelectionChanged(object sender, object[] eventArgs)
    {
      this.UpdateButtonState();
    }

    private void OnNetworkListChanged(object sender, object[] eventArgs)
    {
      this.UpdateUI(true);
    }

    private void OnOngoingScanNetworkListChanged(object sender, object[] eventArgs)
    {
      this.UpdateUI(true);
    }

    public void OnStateChange(object sender, object[] eventArgs)
    {
      this.HandleStateChange();
    }

    private void CustomInitializeComponents()
    {
      this.AccessibleName = "NetworkListPanel";
      this.SearchForNetworksPushButton.AccessibleName = "NetworkListPanel_SearchForNetworksPushButton";
      this.ConnectPushButton.AccessibleName = "NetworkListPanel_ConnectPushButton";
      this.NetworkListMessage.AccessibleName = "NetworkListPanel_NetworkListMessage";
      this.NetworkListBox.AccessibleName = "NetworkListPanel_NetworkListBox";
      this.NetworkListStatusBar.AccessibleName = "NetworkListPanel_NetworkListStatusBar";
      this.ButtonBoxConnect.AccessibleName = "NetworkListPanel_ButtonBoxCollapseConnect";
      this.AvailableWiMAXNeworksLabel.AccessibleName = "NetworkListPanel_AvailableWiMAXNeworksLabel";
      this.AvailableWiMAXNeworksLabel.Text = DashboardStringHelper.GetString("AvailableWiMAXNeworks");
      this.SearchForNetworksPushButton.BtnText = DashboardStringHelper.GetString("SearchForNetworks");
      this.SearchForNetworksPushButton.Pressed += new CustomButtonPush.PressedDelegate(this.OnSearchForNetworksBtnPressed);
      this.ConnectPushButton.BtnText = DashboardStringHelper.GetString("Connect");
      this.ConnectPushButton.Pressed += new CustomButtonPush.PressedDelegate(this.OnConnectBtnPressed);
      this.NetworkListStatusBar.InitPanel();
    }

    private void RegisterForEvents()
    {
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnNetworkListChanged), (object) this, "WiMAXUI.OnNetworkListChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnAvailableNetworkListSelectionChanged), (object) this, "WiMAXUI.OnAvailableNetworkListSelectionChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnOngoingScanNetworkListChanged), (object) this, "WiMAXUI.OnOngoingScanNetworkListChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnStateChange), (object) this, "WiMAXUI.OnStateChange");
    }

    private void UpdateButtonState()
    {
      this.UpdateSearchForNetworksPushButtonState();
      this.UpdateConnectPushButtonState();
      if (!this.ConnectPushButton.BtnEnabled)
        this.ButtonBoxConnect.TabStop = false;
      else
        this.ButtonBoxConnect.TabStop = true;
    }

    private void UpdateConnectPushButtonState()
    {
      bool btnEnabled = this.ConnectPushButton.BtnEnabled;
      string btnText = this.ConnectPushButton.BtnText;
      this.ConnectPushButton.BtnEnabled = this.ShouldConnectButtonBeEnabled();
      if (!MediaHandler.TheMedia.WiMAXIsReady || !MediaHandler.IntelCUIsInControl || (!AdapterHandler.TheAdapter.RadioIsOn() || this.NetworkListBox.GetSelectedNDI() == null) || NetworkHandler.ConnectedNetworks.Count > 0)
        this.ConnectPushButton.BtnEnabled = false;
      if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForConnect || Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForStopConnect)
      {
        this.ConnectPushButton.BtnText = DashboardStringHelper.GetString("StopConnecting");
        this.ConnectPushButton.BtnColor = PushButtonColorEnum.BlueGrey;
      }
      else
      {
        this.ConnectPushButton.BtnText = DashboardStringHelper.GetString("Connect");
        this.ConnectPushButton.BtnColor = PushButtonColorEnum.GreenGrey;
      }
      if (btnEnabled == this.ConnectPushButton.BtnEnabled && !(btnText != this.ConnectPushButton.BtnText))
        return;
      this.ConnectPushButton.ResizeMe();
      this.ButtonBoxConnect.ResizeMe();
      this.ConnectPushButton.Invalidate();
    }

    private void MakeRoomForStatusBar(int statusBarHeight)
    {
      if (this._normalNetworkListMessageHeight == 0)
        this._normalNetworkListMessageHeight = this.NetworkListMessage.Height;
      if (this._normalNetworkListBoxHeight == 0)
        this._normalNetworkListBoxHeight = this.NetworkListBox.Height;
      if (statusBarHeight == 0)
      {
        this.NetworkListBox.Height = DPIUtils.ScaleY(this._normalNetworkListBoxHeight);
        this.NetworkListMessage.Height = DPIUtils.ScaleY(this._normalNetworkListMessageHeight);
      }
      else
      {
        NetworkListBox networkListBox = this.NetworkListBox;
        int num1 = networkListBox.Height - statusBarHeight;
        networkListBox.Height = num1;
        NetworkListMessage networkListMessage = this.NetworkListMessage;
        int num2 = networkListMessage.Height - statusBarHeight;
        networkListMessage.Height = num2;
      }
      this.Invalidate(true);
    }

    protected void DoUpdateUI(bool recreateNetworksListbox)
    {
      bool flag = this.SetNetworkListMessage();
      if (this.ShowStatusBar())
      {
        if (!this._statusBarVisible)
        {
          this.NetworkListStatusBar.ResetProgressBar();
          this.MakeRoomForStatusBar(this.NetworkListStatusBar.Height + 2);
          this.NetworkListStatusBar.Visible = true;
          this._statusBarVisible = true;
        }
        this.NetworkListStatusBar.BringToFront();
        this.NetworkListStatusBar.Invalidate();
      }
      else
      {
        this.MakeRoomForStatusBar(0);
        this.NetworkListStatusBar.Visible = false;
        this.NetworkListStatusBar.SendToBack();
        this._statusBarVisible = false;
      }
      if (flag)
      {
        this.NetworkListBox.SendToBack();
        this.NetworkListBox.TabStop = false;
        this.NetworkListMessage.TabStop = false;
        this.NetworkListMessage.BringToFront();
      }
      else
      {
        this.NetworkListBox.BringToFront();
        this.NetworkListBox.TabStop = true;
        this.NetworkListMessage.TabStop = false;
        this.NetworkListMessage.SendToBack();
      }
      this.NetworkListBox.UpdateUI(NetworkHandler.AvailableNetworks, recreateNetworksListbox);
      this.UpdateButtonState();
    }

    protected override void Dispose(bool disposing)
    {
      Eventing.DeRegisterAllUIEvents((object) this);
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (NetworkListPanel));
      this.ButtonBoxConnect = new CustomButtonPushHorizBox();
      this.ConnectPushButton = new CustomButtonPush();
      this.SearchForNetworksPushButton = new CustomButtonPush();
      this.AvailableWiMAXNeworksLabel = new Label();
      this.NetworkListStatusBar = new NetworkListStatusBar();
      this.NetworkListMessage = new NetworkListMessage();
      this.NetworkListBox = new NetworkListBox();
      this.ButtonBoxConnect.SuspendLayout();
      this.SuspendLayout();
      this.ButtonBoxConnect.Controls.Add((Control) this.ConnectPushButton);
      componentResourceManager.ApplyResources((object) this.ButtonBoxConnect, "ButtonBoxConnect");
      this.ButtonBoxConnect.HorizontalJustification = HorizontalJustificationEnum.Right;
      this.ButtonBoxConnect.Name = "ButtonBoxConnect";
      this.ConnectPushButton.BackColor = Color.Transparent;
      this.ConnectPushButton.BtnColor = PushButtonColorEnum.GreenGrey;
      this.ConnectPushButton.BtnDoubleEndCaps = true;
      this.ConnectPushButton.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.ConnectPushButton, "ConnectPushButton");
      this.ConnectPushButton.Name = "ConnectPushButton";
      this.SearchForNetworksPushButton.BackColor = Color.Transparent;
      this.SearchForNetworksPushButton.BtnColor = PushButtonColorEnum.BlueGrey;
      this.SearchForNetworksPushButton.BtnDoubleEndCaps = false;
      this.SearchForNetworksPushButton.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.SearchForNetworksPushButton, "SearchForNetworksPushButton");
      this.SearchForNetworksPushButton.Name = "SearchForNetworksPushButton";
      componentResourceManager.ApplyResources((object) this.AvailableWiMAXNeworksLabel, "AvailableWiMAXNeworksLabel");
      this.AvailableWiMAXNeworksLabel.Name = "AvailableWiMAXNeworksLabel";
      componentResourceManager.ApplyResources((object) this.NetworkListStatusBar, "NetworkListStatusBar");
      this.NetworkListStatusBar.BackColor = Color.WhiteSmoke;
      this.NetworkListStatusBar.Name = "NetworkListStatusBar";
      this.NetworkListStatusBar.TabStop = false;
      componentResourceManager.ApplyResources((object) this.NetworkListMessage, "NetworkListMessage");
      this.NetworkListMessage.BackColor = Color.WhiteSmoke;
      this.NetworkListMessage.ForeColor = Color.Black;
      this.NetworkListMessage.Name = "NetworkListMessage";
      this.NetworkListMessage.TabStop = false;
      componentResourceManager.ApplyResources((object) this.NetworkListBox, "NetworkListBox");
      this.NetworkListBox.BackColor = Color.White;
      this.NetworkListBox.Name = "NetworkListBox";
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.AvailableWiMAXNeworksLabel);
      this.Controls.Add((Control) this.NetworkListStatusBar);
      this.Controls.Add((Control) this.ButtonBoxConnect);
      this.Controls.Add((Control) this.SearchForNetworksPushButton);
      this.Controls.Add((Control) this.NetworkListMessage);
      this.Controls.Add((Control) this.NetworkListBox);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "NetworkListPanel";
      this.ButtonBoxConnect.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
