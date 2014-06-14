// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.AdapterTabPanel
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
using System.Threading;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class AdapterTabPanel : UserControl
  {
    private Container components;
    private CustomLabelSeparator AdapterTabPanel_SupportedAdaptersLabelSeparator;
    private Label AdapterTabPanel_OverviewLbl;
    private CustomLabelRoundedCorners AdapterTabPanel_ModelValueLbl;
    private Label AdapterTabPanel_ModelLbl;
    private CustomLabelRoundedCorners AdapterTabPanel_MACAddressValueLbl;
    private CustomLabelRoundedCorners AdapterTabPanel_ManufacturerValueLbl;
    private Label AdapterTabPanel_ManufacturerLbl;
    private Label AdapterTabPanel_MACAddressLbl;
    private Panel AdapterTabPanel_AdapterDetailsPanel;
    private CustomLabelSeparator AdapterTabPanel_DeviceManagementSeparator;
    private Label AdapterTabPanel_ResetLbl;
    private CustomButtonPush AdapterTabPanel_ResetPushBtn;
    private bool _timeoutOccurred;
    private string _vendorName;
    private string _hwName;
    private string _macAddress;
    private static int _iResult;
    private AdvancedPanel _parentPanel;
    private System.Windows.Forms.Timer _timeoutTimer;
    private CustomMessageBox cmb1;

    public AdvancedPanel ParentPanel
    {
      get
      {
        return this._parentPanel;
      }
      set
      {
        this._parentPanel = value;
      }
    }

    public AdapterTabPanel()
    {
      this.InitializeComponent();
      this.CustomInitializeComponents();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AdapterTabPanel));
      this.AdapterTabPanel_SupportedAdaptersLabelSeparator = new CustomLabelSeparator();
      this.AdapterTabPanel_OverviewLbl = new Label();
      this.AdapterTabPanel_ModelValueLbl = new CustomLabelRoundedCorners();
      this.AdapterTabPanel_ModelLbl = new Label();
      this.AdapterTabPanel_MACAddressValueLbl = new CustomLabelRoundedCorners();
      this.AdapterTabPanel_ManufacturerValueLbl = new CustomLabelRoundedCorners();
      this.AdapterTabPanel_ManufacturerLbl = new Label();
      this.AdapterTabPanel_MACAddressLbl = new Label();
      this.AdapterTabPanel_AdapterDetailsPanel = new Panel();
      this.AdapterTabPanel_DeviceManagementSeparator = new CustomLabelSeparator();
      this.AdapterTabPanel_ResetLbl = new Label();
      this.AdapterTabPanel_ResetPushBtn = new CustomButtonPush();
      this.AdapterTabPanel_AdapterDetailsPanel.SuspendLayout();
      this.SuspendLayout();
      this.AdapterTabPanel_SupportedAdaptersLabelSeparator.BackColor = Color.White;
      componentResourceManager.ApplyResources((object) this.AdapterTabPanel_SupportedAdaptersLabelSeparator, "AdapterTabPanel_SupportedAdaptersLabelSeparator");
      this.AdapterTabPanel_SupportedAdaptersLabelSeparator.Name = "AdapterTabPanel_SupportedAdaptersLabelSeparator";
      this.AdapterTabPanel_SupportedAdaptersLabelSeparator.TabStop = false;
      componentResourceManager.ApplyResources((object) this.AdapterTabPanel_OverviewLbl, "AdapterTabPanel_OverviewLbl");
      this.AdapterTabPanel_OverviewLbl.Name = "AdapterTabPanel_OverviewLbl";
      this.AdapterTabPanel_ModelValueLbl.BackColor = Color.Transparent;
      this.AdapterTabPanel_ModelValueLbl.BackgroundColor = Color.FromArgb(210, 234, 251);
      this.AdapterTabPanel_ModelValueLbl.ControlType = ControlTypeEnum.TextBox;
      componentResourceManager.ApplyResources((object) this.AdapterTabPanel_ModelValueLbl, "AdapterTabPanel_ModelValueLbl");
      this.AdapterTabPanel_ModelValueLbl.Icon = (Bitmap) null;
      this.AdapterTabPanel_ModelValueLbl.Name = "AdapterTabPanel_ModelValueLbl";
      this.AdapterTabPanel_ModelValueLbl.TabStop = false;
      this.AdapterTabPanel_ModelValueLbl.UniqueID = -1;
      componentResourceManager.ApplyResources((object) this.AdapterTabPanel_ModelLbl, "AdapterTabPanel_ModelLbl");
      this.AdapterTabPanel_ModelLbl.Name = "AdapterTabPanel_ModelLbl";
      this.AdapterTabPanel_MACAddressValueLbl.BackColor = Color.Transparent;
      this.AdapterTabPanel_MACAddressValueLbl.BackgroundColor = Color.FromArgb(210, 234, 251);
      this.AdapterTabPanel_MACAddressValueLbl.ControlType = ControlTypeEnum.TextBox;
      componentResourceManager.ApplyResources((object) this.AdapterTabPanel_MACAddressValueLbl, "AdapterTabPanel_MACAddressValueLbl");
      this.AdapterTabPanel_MACAddressValueLbl.Icon = (Bitmap) null;
      this.AdapterTabPanel_MACAddressValueLbl.Name = "AdapterTabPanel_MACAddressValueLbl";
      this.AdapterTabPanel_MACAddressValueLbl.TabStop = false;
      this.AdapterTabPanel_MACAddressValueLbl.UniqueID = -1;
      this.AdapterTabPanel_ManufacturerValueLbl.BackColor = Color.Transparent;
      this.AdapterTabPanel_ManufacturerValueLbl.BackgroundColor = Color.FromArgb(210, 234, 251);
      this.AdapterTabPanel_ManufacturerValueLbl.ControlType = ControlTypeEnum.TextBox;
      componentResourceManager.ApplyResources((object) this.AdapterTabPanel_ManufacturerValueLbl, "AdapterTabPanel_ManufacturerValueLbl");
      this.AdapterTabPanel_ManufacturerValueLbl.Icon = (Bitmap) null;
      this.AdapterTabPanel_ManufacturerValueLbl.Name = "AdapterTabPanel_ManufacturerValueLbl";
      this.AdapterTabPanel_ManufacturerValueLbl.TabStop = false;
      this.AdapterTabPanel_ManufacturerValueLbl.UniqueID = -1;
      componentResourceManager.ApplyResources((object) this.AdapterTabPanel_ManufacturerLbl, "AdapterTabPanel_ManufacturerLbl");
      this.AdapterTabPanel_ManufacturerLbl.Name = "AdapterTabPanel_ManufacturerLbl";
      componentResourceManager.ApplyResources((object) this.AdapterTabPanel_MACAddressLbl, "AdapterTabPanel_MACAddressLbl");
      this.AdapterTabPanel_MACAddressLbl.Name = "AdapterTabPanel_MACAddressLbl";
      this.AdapterTabPanel_AdapterDetailsPanel.BackColor = Color.White;
      this.AdapterTabPanel_AdapterDetailsPanel.Controls.Add((Control) this.AdapterTabPanel_ModelValueLbl);
      this.AdapterTabPanel_AdapterDetailsPanel.Controls.Add((Control) this.AdapterTabPanel_MACAddressLbl);
      this.AdapterTabPanel_AdapterDetailsPanel.Controls.Add((Control) this.AdapterTabPanel_ManufacturerLbl);
      this.AdapterTabPanel_AdapterDetailsPanel.Controls.Add((Control) this.AdapterTabPanel_ManufacturerValueLbl);
      this.AdapterTabPanel_AdapterDetailsPanel.Controls.Add((Control) this.AdapterTabPanel_ModelLbl);
      this.AdapterTabPanel_AdapterDetailsPanel.Controls.Add((Control) this.AdapterTabPanel_MACAddressValueLbl);
      componentResourceManager.ApplyResources((object) this.AdapterTabPanel_AdapterDetailsPanel, "AdapterTabPanel_AdapterDetailsPanel");
      this.AdapterTabPanel_AdapterDetailsPanel.Name = "AdapterTabPanel_AdapterDetailsPanel";
      this.AdapterTabPanel_DeviceManagementSeparator.BackColor = Color.White;
      componentResourceManager.ApplyResources((object) this.AdapterTabPanel_DeviceManagementSeparator, "AdapterTabPanel_DeviceManagementSeparator");
      this.AdapterTabPanel_DeviceManagementSeparator.Name = "AdapterTabPanel_DeviceManagementSeparator";
      this.AdapterTabPanel_DeviceManagementSeparator.TabStop = false;
      componentResourceManager.ApplyResources((object) this.AdapterTabPanel_ResetLbl, "AdapterTabPanel_ResetLbl");
      this.AdapterTabPanel_ResetLbl.Name = "AdapterTabPanel_ResetLbl";
      this.AdapterTabPanel_ResetPushBtn.BackColor = Color.White;
      this.AdapterTabPanel_ResetPushBtn.BtnColor = PushButtonColorEnum.BlueGrey;
      this.AdapterTabPanel_ResetPushBtn.BtnDoubleEndCaps = false;
      this.AdapterTabPanel_ResetPushBtn.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.AdapterTabPanel_ResetPushBtn, "AdapterTabPanel_ResetPushBtn");
      this.AdapterTabPanel_ResetPushBtn.Name = "AdapterTabPanel_ResetPushBtn";
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.AdapterTabPanel_DeviceManagementSeparator);
      this.Controls.Add((Control) this.AdapterTabPanel_ResetLbl);
      this.Controls.Add((Control) this.AdapterTabPanel_ResetPushBtn);
      this.Controls.Add((Control) this.AdapterTabPanel_AdapterDetailsPanel);
      this.Controls.Add((Control) this.AdapterTabPanel_OverviewLbl);
      this.Controls.Add((Control) this.AdapterTabPanel_SupportedAdaptersLabelSeparator);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "AdapterTabPanel";
      this.AdapterTabPanel_AdapterDetailsPanel.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public void InitPanel()
    {
      this.UpdateButtonState();
      this.UpdateUI();
      this.RegisterForEvents();
    }

    public void CleanUp()
    {
      this.UnregisterForEvents();
    }

    public void UpdateButtonState()
    {
      if (this._parentPanel.Blocked)
        this.Cursor = Cursors.WaitCursor;
      else
        this.Cursor = Cursors.Default;
      if (!MediaHandler.IntelCUIsInControl)
      {
        if (this.cmb1 != null && this.cmb1.Visible)
          this.cmb1.Close();
        this.AdapterTabPanel_ResetPushBtn.BtnEnabled = false;
      }
      else if (this._parentPanel.Blocked)
        this.AdapterTabPanel_ResetPushBtn.BtnEnabled = false;
      else
        this.AdapterTabPanel_ResetPushBtn.BtnEnabled = true;
    }

    private void OnAdapterListChanged(object sender, object[] eventArgs)
    {
      this.UpdateUI();
    }

    private void OnStateChanged(object sender, object[] eventArgs)
    {
      this.UpdateButtonState();
    }

    private void OnIntelCUControlChanged(object sender, object[] eventArgs)
    {
      this.UpdateButtonState();
    }

    private void OnResetWiMAXDeviceComplete(object sender, object[] eventArgs)
    {
      if (this._parentPanel == null || !this._parentPanel.Visible || this._timeoutOccurred)
        return;
      this.Unblock();
      this.UpdateButtonState();
      if (AdapterTabPanel._iResult != 0)
      {
        ErrorHelper.ShowErrorDialog((Control) this, ErrorStringsHelper.GetString("General_ResetWiMAXDeviceFailed"), ErrorHelper.TranslateErrorCodeToMessage(AdapterTabPanel._iResult), (string) null, "ResetWiMAXDeviceFailed");
      }
      else
      {
        CustomMessageBox customMessageBox = new CustomMessageBox(AdvancedDlgStringHelper.GetString("AdapterTabPanel_ResetWiMAXDeviceSucceded"), CustomMessageBoxStyle.Ok);
        customMessageBox.AccessibleName = "ResetWiMAXDeviceSucceededMB";
        int num = (int) customMessageBox.CustomShowDialog((IWin32Window) this, false);
      }
    }

    private void OnTimeoutTimerTick(object sender, EventArgs e)
    {
      if (this._parentPanel == null || !this._parentPanel.Visible)
        return;
      this.Unblock();
      this.UpdateButtonState();
      this._timeoutOccurred = true;
      ErrorHelper.ShowErrorDialog((Control) this, ErrorStringsHelper.GetString("General_ResetWiMAXDeviceFailed"), "", (string) null, "ResetWiMAXDeviceFailed");
    }

    private void OnDeviceResetPushBtnPressed(object sender, EventArgs e)
    {
      if (NetworkHandler.ConnectedNetworks.Count > 0)
      {
        if (this.cmb1 == null)
        {
          this.cmb1 = new CustomMessageBox(AdvancedDlgStringHelper.GetString("AdapterTabPanel_ConfirmOperationBecauseConnected"), CustomMessageBoxStyle.YesNo);
          this.cmb1.AccessibleName = "ConfirmResetDeviceMB";
        }
        if (!this.cmb1.Visible && this.cmb1.CustomShowDialog((IWin32Window) this._parentPanel, false) != DialogResult.Yes)
          return;
      }
      if (!this.PrerequisitesMet())
        return;
      Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user pressed the 'Reset WiMAX Adapter' button.");
      this.Block();
      if (this._timeoutTimer == null)
      {
        this._timeoutTimer = new System.Windows.Forms.Timer();
        this._timeoutTimer.Interval = TimerSettings.AdaptersTabPanel_TimeoutTimer_Interval;
        this._timeoutTimer.Tick += new EventHandler(this.OnTimeoutTimerTick);
        this._timeoutTimer.Start();
      }
      else
        this._timeoutTimer.Start();
      this._timeoutOccurred = false;
      AdapterTabPanel._iResult = 0;
      ThreadPool.QueueUserWorkItem(new WaitCallback(this.DoAsyncResetWiMAXDevice));
    }

    private void CustomInitializeComponents()
    {
      this.AccessibleName = "AdapterTabPanel";
      this.AdapterTabPanel_AdapterDetailsPanel.AccessibleName = "AdapterTabPanel_AdapterDetailsPanel";
      this.AdapterTabPanel_DeviceManagementSeparator.AccessibleName = "AdapterTabPanel_DeviceManagementSeparator";
      this.AdapterTabPanel_MACAddressLbl.AccessibleName = "AdapterTabPanel_MACAddressLbl";
      this.AdapterTabPanel_MACAddressValueLbl.AccessibleName = "AdapterTabPanel_MACAddressValueLbl";
      this.AdapterTabPanel_ManufacturerLbl.AccessibleName = "AdapterTabPanel_ManufacturerLbl";
      this.AdapterTabPanel_ManufacturerValueLbl.AccessibleName = "AdapterTabPanel_ManufacturerValueLbl";
      this.AdapterTabPanel_ModelLbl.AccessibleName = "AdapterTabPanel_ModelLbl";
      this.AdapterTabPanel_ModelValueLbl.AccessibleName = "AdapterTabPanel_ModelValueLbl";
      this.AdapterTabPanel_OverviewLbl.AccessibleName = "AdapterTabPanel_OverviewLbl";
      this.AdapterTabPanel_ResetLbl.AccessibleName = "AdapterTabPanel_ResetLbl";
      this.AdapterTabPanel_ResetPushBtn.AccessibleName = "AdapterTabPanel_ResetPushBtn";
      this.AdapterTabPanel_SupportedAdaptersLabelSeparator.AccessibleName = "AdapterTabPanel_SupportedAdaptersLabelSeparator";
      this.AdapterTabPanel_SupportedAdaptersLabelSeparator.Text = AdvancedDlgStringHelper.GetString("AdapterTabPanel_SupportedAdaptersLabelSeparator");
      this.AdapterTabPanel_OverviewLbl.Text = AdvancedDlgStringHelper.GetString("AdapterTabPanel_OverviewLbl");
      this.AdapterTabPanel_ManufacturerLbl.Text = AdvancedDlgStringHelper.GetString("AdapterTabPanel_ManufacturerLbl");
      this.AdapterTabPanel_ModelLbl.Text = AdvancedDlgStringHelper.GetString("AdapterTabPanel_ModelLbl");
      this.AdapterTabPanel_MACAddressLbl.Text = AdvancedDlgStringHelper.GetString("AdapterTabPanel_MACAddressLbl");
      this.AdapterTabPanel_DeviceManagementSeparator.Text = AdvancedDlgStringHelper.GetString("AdapterTabPanel_DeviceManagementSeparator");
      this.AdapterTabPanel_ResetLbl.Text = AdvancedDlgStringHelper.GetString("AdapterTabPanel_ResetLbl");
      this.AdapterTabPanel_ResetPushBtn.BtnText = AdvancedDlgStringHelper.GetString("AdapterTabPanel_ResetPushBtn");
      this.AdapterTabPanel_ResetPushBtn.Pressed += new CustomButtonPush.PressedDelegate(this.OnDeviceResetPushBtnPressed);
      SizeHelper.ResizeCustomControls(this.Controls);
    }

    private void RegisterForEvents()
    {
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnAdapterListChanged), (object) this, "WiMAXUI.OnAdapterListChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnStateChanged), (object) this, "WiMAXUI.OnStateChange");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnIntelCUControlChanged), (object) this, "WiMAXUI.OnIntelCUControlChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnResetWiMAXDeviceComplete), (object) this, "WiMAXSP.OnResetWiMAXDeviceComplete");
    }

    private void UnregisterForEvents()
    {
      Eventing.DeRegisterAllUIEvents((object) this);
    }

    private bool PrerequisitesMet()
    {
      return true;
    }

    private void Block()
    {
      this._parentPanel.Block();
    }

    private void Unblock()
    {
      if (this._timeoutTimer != null)
        this._timeoutTimer.Stop();
      this._parentPanel.Unblock();
    }

    private void UpdateUI()
    {
      this.UpdateForAdapter();
    }

    private void UpdateForAdapter()
    {
      this.AdapterTabPanel_ManufacturerValueLbl.Text = AdvancedDlgStringHelper.GetString("AdapterTabPanel_InformationNotAvailable");
      this.AdapterTabPanel_ModelValueLbl.Text = AdvancedDlgStringHelper.GetString("AdapterTabPanel_InformationNotAvailable");
      this.AdapterTabPanel_MACAddressValueLbl.Text = AdvancedDlgStringHelper.GetString("AdapterTabPanel_InformationNotAvailable");
      if (!string.IsNullOrEmpty(AdapterHandler.TheAdapter.VendorName))
      {
        this._vendorName = AdapterHandler.TheAdapter.VendorName;
        this.AdapterTabPanel_ManufacturerValueLbl.Text = AdapterHandler.TheAdapter.VendorName;
      }
      else if (!string.IsNullOrEmpty(this._vendorName))
        this.AdapterTabPanel_ManufacturerValueLbl.Text = this._vendorName;
      if (!string.IsNullOrEmpty(AdapterHandler.TheAdapter.HWName))
      {
        this._hwName = AdapterHandler.TheAdapter.HWName;
        this.AdapterTabPanel_ModelValueLbl.Text = AdapterHandler.TheAdapter.HWName;
      }
      else if (!string.IsNullOrEmpty(this._hwName))
        this.AdapterTabPanel_ModelValueLbl.Text = this._hwName;
      if (!string.IsNullOrEmpty(AdapterHandler.TheAdapter.MACAddress))
      {
        this._macAddress = AdapterHandler.TheAdapter.MACAddress;
        this.AdapterTabPanel_MACAddressValueLbl.Text = AdapterHandler.TheAdapter.MACAddress;
      }
      else
      {
        if (string.IsNullOrEmpty(this._macAddress))
          return;
        this.AdapterTabPanel_MACAddressValueLbl.Text = this._macAddress;
      }
    }

    private void DoAsyncResetWiMAXDevice(object obj)
    {
      AdapterTabPanel._iResult = MiscHandler.Singleton.ResetWiMAXDevice();
      Eventing.GenerateUIEvent("WiMAXSP.OnResetWiMAXDeviceComplete", (object) this, new object[0]);
    }
  }
}
