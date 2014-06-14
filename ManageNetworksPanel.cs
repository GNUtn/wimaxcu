// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.ManageNetworksPanel
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.SDKInterop;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class ManageNetworksPanel : UserControl
  {
    private bool _waitingForDisconnectFlag;
    private IContainer components;
    private Label ManageNetworksPanel_HeaderLbl;
    private CustomHelpButtonLabelPair ManageNetworksPanel_HelpButtonLabelPair;
    private CustomButtonPushHorizBox ManageNetworksPanel_CloseBtnBox;
    private CustomButtonPush ManageNetworksPanel_CloseBtn;
    private CustomButtonPushHorizBox ManageNetworksPanel_SetAsPreferredPropertiesBtnBox;
    private CustomButtonPush ManageNetworksPanel_PropertiesBtn;
    private CustomLabelSeparator ManageNetworksPanel_ButtonBarSeperator;
    private ProfileListBox ManageNetworksPanel_ProfileListBox;
    private CustomButtonPush ManageNetworksPanel_SetAsPreferredBtn;

    public ManageNetworksPanel()
    {
      this.InitializeComponent();
      this.CustomInitializeComponents();
    }

    public void InitPanel()
    {
      this.UpdateUI();
      this._waitingForDisconnectFlag = false;
      this.RegisterForEvents();
      this.ActiveControl = (Control) this.ManageNetworksPanel_ProfileListBox;
      this.ManageNetworksPanel_ProfileListBox.Focus();
    }

    public void CleanUp()
    {
      this.UnregisterForEvents();
    }

    public void LaunchHelp()
    {
      OnlineHelp.LaunchHelp("/manage.htm");
    }

    public void UpdateButtonState()
    {
      this.ManageNetworksPanel_PropertiesBtn.BtnEnabled = this.EnableProperites();
      this.ManageNetworksPanel_SetAsPreferredBtn.BtnEnabled = this.EnableSetAsDefault();
      if ((!this.ManageNetworksPanel_PropertiesBtn.Visible || !this.ManageNetworksPanel_PropertiesBtn.BtnEnabled) && (!this.ManageNetworksPanel_SetAsPreferredBtn.Visible || !this.ManageNetworksPanel_SetAsPreferredBtn.BtnEnabled))
        this.ManageNetworksPanel_SetAsPreferredPropertiesBtnBox.TabStop = false;
      else
        this.ManageNetworksPanel_SetAsPreferredPropertiesBtnBox.TabStop = true;
    }

    public void ProperitesClicked()
    {
      if (this.ManageNetworksPanel_ProfileListBox.SelectedPDI == null)
        return;
      AppFramework.Dashboard.ShowNetworkProperitesDialog(this.ManageNetworksPanel_ProfileListBox.SelectedPDI);
    }

    public void SetAsDefaultClicked()
    {
      if (!this.ManageNetworksPanel_SetAsPreferredBtn.BtnEnabled)
        return;
      if (NetworkHandler.ConnectedNetworks.Count > 0)
      {
        CustomMessageBox customMessageBox = new CustomMessageBox(ManageNetworksDlgStringHelper.GetString("ManageNetworksPanel_CanNotSetAsDefaultWhileConnected"), CustomMessageBoxStyle.YesNo);
        customMessageBox.AccessibleName = "CanNotChangePreferredProfileWhileConnectedMB";
        customMessageBox.LocationOfMessageBox = CustomMessageBoxLocation.CenterOfDashboard;
        if (customMessageBox.CustomShowDialog((IWin32Window) AppFramework.Dashboard, true) != DialogResult.Yes)
          return;
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user pressed the 'Set As Preferred' button.");
        if (NetworkHandler.ConnectedNetworks.Count > 0)
        {
          this._waitingForDisconnectFlag = true;
          NetworkHandler.Singleton.DisconnectNetwork(NetworkHandler.ConnectedNetworks[0].WmxNetwork);
        }
        else
        {
          Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user pressed the 'Set As Preferred' button.");
          this.DoSetPreferredProfile();
        }
      }
      else
        this.DoSetPreferredProfile();
    }

    public bool EnableProperites()
    {
      if (this.ManageNetworksPanel_ProfileListBox.SelectedPDI != null && MediaHandler.IntelCUIsInControl && MediaHandler.TheMedia.WiMAXIsReady)
        return true;
      else
        return this.ManageNetworksPanel_PropertiesBtn.BtnEnabled = false;
    }

    public bool EnableSetAsDefault()
    {
      return this.ManageNetworksPanel_ProfileListBox.SelectedPDI != null && !this.ManageNetworksPanel_ProfileListBox.SelectedPDI.Preferred && (MediaHandler.IntelCUIsInControl && MediaHandler.TheMedia.WiMAXIsReady) && (!Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForConnect && !Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForDisconnect && (!Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForRadioSwitch && !Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForStopConnect)) && (!Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForStopScan && !Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForManualPreferredScan && !Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForManualWideScan);
    }

    private void OnMediaStatusChanged(object sender, object[] eventArgs)
    {
      this.UpdateButtonState();
    }

    private void OnIntelCUControlChanged(object sender, object[] eventArgs)
    {
      this.UpdateButtonState();
    }

    private void OnProfileListChanged(object sender, object[] eventArgs)
    {
      this.UpdateUI();
    }

    private void OnDisconnected(object sender, object[] eventArgs)
    {
      if (!this.Visible || !this._waitingForDisconnectFlag)
        return;
      this._waitingForDisconnectFlag = false;
      this.DoSetPreferredProfile();
    }

    private void OnStateChanged(object sender, object[] eventArgs)
    {
      this.UpdateButtonState();
    }

    public void OnError(object sender, object[] eventArgs)
    {
      if (!this._waitingForDisconnectFlag || !this.Visible || (eventArgs == null || eventArgs.Length < 2))
        return;
      int num = (int) eventArgs[0];
      if ((OperationThatFailed) eventArgs[1] != OperationThatFailed.Disconnect)
        return;
      this._waitingForDisconnectFlag = false;
      ErrorHelper.ShowErrorDialog((Control) AppFramework.Dashboard, ErrorStringsHelper.GetString("General_SetPreferredProfileFailed"), "", (string) null, "SetPreferredProfileFailed");
    }

    private void OnHelpButtonPressed(object sender, MouseEventArgs e)
    {
      if (MouseHelper.IgnoreMouseClick(e, (Control) sender, ((Control) sender).Enabled))
        return;
      this.LaunchHelp();
    }

    private void OnCloseBtnPressed(object sender, EventArgs e)
    {
      ManageNetworksDialog.Singleton.Close();
    }

    private void OnProperitesBtnPressed(object sender, EventArgs e)
    {
      this.ProperitesClicked();
    }

    private void OnSetAsPreferredBtnPressed(object sender, EventArgs e)
    {
      this.SetAsDefaultClicked();
    }

    private void CustomInitializeComponents()
    {
      this.ManageNetworksPanel_HelpButtonLabelPair.HelpBtnPressed += new CustomHelpButtonLabelPair.HelpBtnPressedDelegate(this.OnHelpButtonPressed);
      this.ManageNetworksPanel_CloseBtn.Pressed += new CustomButtonPush.PressedDelegate(this.OnCloseBtnPressed);
      this.ManageNetworksPanel_SetAsPreferredBtn.Pressed += new CustomButtonPush.PressedDelegate(this.OnSetAsPreferredBtnPressed);
      this.ManageNetworksPanel_PropertiesBtn.Pressed += new CustomButtonPush.PressedDelegate(this.OnProperitesBtnPressed);
      this.AccessibleName = "ManageNetworksPanel";
      this.ManageNetworksPanel_CloseBtn.AccessibleName = "ManageNetworksPanel_CloseBtn";
      this.ManageNetworksPanel_CloseBtnBox.AccessibleName = "ManageNetworksPanel_CloseBtnBox";
      this.ManageNetworksPanel_HelpButtonLabelPair.AccessibleName = "ManageNetworksPanel_HelpButtonLabelPair";
      this.ManageNetworksPanel_ProfileListBox.AccessibleName = "ManageNetworksPanel_ProfileListBox";
      this.ManageNetworksPanel_PropertiesBtn.AccessibleName = "ManageNetworksPanel_PropertiesBtn";
      this.ManageNetworksPanel_SetAsPreferredPropertiesBtnBox.AccessibleName = "ManageNetworksPanel_SetAsPreferredPropertiesBtnBox";
      this.ManageNetworksPanel_HeaderLbl.AccessibleName = "ManageNetworksPanel_HeaderLbl";
      this.ManageNetworksPanel_ButtonBarSeperator.AccessibleName = "ManageNetworksPanel_ButtonBarSeperator";
      this.ManageNetworksPanel_SetAsPreferredBtn.AccessibleName = "ManageNetworksPanel_SetAsPreferredBtn";
      this.ManageNetworksPanel_HeaderLbl.Text = ManageNetworksDlgStringHelper.GetString("ManageNetworksPanel_HeaderLbl");
      this.ManageNetworksPanel_CloseBtn.BtnText = ManageNetworksDlgStringHelper.GetString("ManageNetworksPanel_CloseBtn");
      this.ManageNetworksPanel_PropertiesBtn.BtnText = ManageNetworksDlgStringHelper.GetString("ManageNetworksPanel_PropertiesBtn");
      this.ManageNetworksPanel_SetAsPreferredBtn.BtnText = ManageNetworksDlgStringHelper.GetString("ManageNetworksPanel_SetAsPreferredBtn");
      this.ManageNetworksPanel_ButtonBarSeperator.Text = DashboardStringHelper.GetString("Empty");
      this.ManageNetworksPanel_ProfileListBox.ProfileSelectedCallback = new ProfileSelectedDelegate(this.UpdateButtonState);
      this.ManageNetworksPanel_ProfileListBox.ProperitesCallback = new ProperitesDelegate(this.ProperitesClicked);
      this.ManageNetworksPanel_ProfileListBox.SetAsDefaultCallback = new SetAsDefaultDelegate(this.SetAsDefaultClicked);
      this.ManageNetworksPanel_ProfileListBox.EnableProperitesCallback = new EnableProperitesDelegate(this.EnableProperites);
      this.ManageNetworksPanel_ProfileListBox.EnableSetAsDefaultCallback = new EnableSetAsDefaultDelegate(this.EnableSetAsDefault);
      this.ManageNetworksPanel_SetAsPreferredPropertiesBtnBox.Controls.Remove((Control) this.ManageNetworksPanel_PropertiesBtn);
      this.ManageNetworksPanel_PropertiesBtn.BtnEnabled = false;
      this.ManageNetworksPanel_PropertiesBtn.Visible = false;
      SizeHelper.ResizeCustomControls(this.Controls);
    }

    private void UpdateUI()
    {
      this.ManageNetworksPanel_ProfileListBox.UpdateUI(new List<ProfileDisplayItem>((IEnumerable<ProfileDisplayItem>) ProfileHandler.Singleton.Profiles));
      this.UpdateButtonState();
    }

    private void RegisterForEvents()
    {
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnMediaStatusChanged), (object) this, "WiMAXUI.OnMediaStatusChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnIntelCUControlChanged), (object) this, "WiMAXUI.OnIntelCUControlChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnProfileListChanged), (object) this, "WiMAXUI.OnProfileListChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnDisconnected), (object) this, "WiMAXSP.OnDisconnected");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnStateChanged), (object) this, "WiMAXUI.OnStateChange");
    }

    private void UnregisterForEvents()
    {
      Eventing.DeRegisterAllUIEvents((object) this);
    }

    private void DoSetPreferredProfile()
    {
      if (this.ManageNetworksPanel_ProfileListBox.SelectedPDI == null)
        return;
      this.Cursor = Cursors.WaitCursor;
      if (ProfileHandler.Singleton.SetPreferredProfiles(new List<WIMAX_API_PROFILE_INFO>()
      {
        this.ManageNetworksPanel_ProfileListBox.SelectedPDI.TheProfile
      }) != 0)
      {
        this.Cursor = Cursors.Default;
        ErrorHelper.ShowErrorDialog((Control) AppFramework.Dashboard, ErrorStringsHelper.GetString("General_SetPreferredProfileFailed"), "", (string) null, "SetPreferredProfileFailed");
      }
      else
      {
        ProfileHandler.Singleton.RefreshData();
        if (AdapterHandler.TheAdapter.RadioIsOn())
          NetworkHandler.Singleton.StartPreferredScan();
      }
      this.Cursor = Cursors.Default;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ManageNetworksPanel));
      this.ManageNetworksPanel_HeaderLbl = new Label();
      this.ManageNetworksPanel_HelpButtonLabelPair = new CustomHelpButtonLabelPair();
      this.ManageNetworksPanel_CloseBtnBox = new CustomButtonPushHorizBox();
      this.ManageNetworksPanel_CloseBtn = new CustomButtonPush();
      this.ManageNetworksPanel_SetAsPreferredBtn = new CustomButtonPush();
      this.ManageNetworksPanel_SetAsPreferredPropertiesBtnBox = new CustomButtonPushHorizBox();
      this.ManageNetworksPanel_PropertiesBtn = new CustomButtonPush();
      this.ManageNetworksPanel_ButtonBarSeperator = new CustomLabelSeparator();
      this.ManageNetworksPanel_ProfileListBox = new ProfileListBox();
      this.ManageNetworksPanel_CloseBtnBox.SuspendLayout();
      this.ManageNetworksPanel_SetAsPreferredPropertiesBtnBox.SuspendLayout();
      this.SuspendLayout();
      this.ManageNetworksPanel_HeaderLbl.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.ManageNetworksPanel_HeaderLbl, "ManageNetworksPanel_HeaderLbl");
      this.ManageNetworksPanel_HeaderLbl.Name = "ManageNetworksPanel_HeaderLbl";
      this.ManageNetworksPanel_HelpButtonLabelPair.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.ManageNetworksPanel_HelpButtonLabelPair, "ManageNetworksPanel_HelpButtonLabelPair");
      this.ManageNetworksPanel_HelpButtonLabelPair.Name = "ManageNetworksPanel_HelpButtonLabelPair";
      this.ManageNetworksPanel_CloseBtnBox.Controls.Add((Control) this.ManageNetworksPanel_CloseBtn);
      componentResourceManager.ApplyResources((object) this.ManageNetworksPanel_CloseBtnBox, "ManageNetworksPanel_CloseBtnBox");
      this.ManageNetworksPanel_CloseBtnBox.HorizontalJustification = HorizontalJustificationEnum.Right;
      this.ManageNetworksPanel_CloseBtnBox.Name = "ManageNetworksPanel_CloseBtnBox";
      this.ManageNetworksPanel_CloseBtn.BackColor = Color.White;
      this.ManageNetworksPanel_CloseBtn.BtnColor = PushButtonColorEnum.BlueGrey;
      this.ManageNetworksPanel_CloseBtn.BtnDoubleEndCaps = false;
      this.ManageNetworksPanel_CloseBtn.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.ManageNetworksPanel_CloseBtn, "ManageNetworksPanel_CloseBtn");
      this.ManageNetworksPanel_CloseBtn.Name = "ManageNetworksPanel_CloseBtn";
      this.ManageNetworksPanel_SetAsPreferredBtn.BackColor = Color.White;
      this.ManageNetworksPanel_SetAsPreferredBtn.BtnColor = PushButtonColorEnum.BlueGrey;
      this.ManageNetworksPanel_SetAsPreferredBtn.BtnDoubleEndCaps = false;
      this.ManageNetworksPanel_SetAsPreferredBtn.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.ManageNetworksPanel_SetAsPreferredBtn, "ManageNetworksPanel_SetAsPreferredBtn");
      this.ManageNetworksPanel_SetAsPreferredBtn.Name = "ManageNetworksPanel_SetAsPreferredBtn";
      this.ManageNetworksPanel_SetAsPreferredPropertiesBtnBox.Controls.Add((Control) this.ManageNetworksPanel_SetAsPreferredBtn);
      this.ManageNetworksPanel_SetAsPreferredPropertiesBtnBox.Controls.Add((Control) this.ManageNetworksPanel_PropertiesBtn);
      componentResourceManager.ApplyResources((object) this.ManageNetworksPanel_SetAsPreferredPropertiesBtnBox, "ManageNetworksPanel_SetAsPreferredPropertiesBtnBox");
      this.ManageNetworksPanel_SetAsPreferredPropertiesBtnBox.HorizontalJustification = HorizontalJustificationEnum.Right;
      this.ManageNetworksPanel_SetAsPreferredPropertiesBtnBox.Name = "ManageNetworksPanel_SetAsPreferredPropertiesBtnBox";
      this.ManageNetworksPanel_PropertiesBtn.BackColor = Color.White;
      this.ManageNetworksPanel_PropertiesBtn.BtnColor = PushButtonColorEnum.BlueGrey;
      this.ManageNetworksPanel_PropertiesBtn.BtnDoubleEndCaps = false;
      this.ManageNetworksPanel_PropertiesBtn.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.ManageNetworksPanel_PropertiesBtn, "ManageNetworksPanel_PropertiesBtn");
      this.ManageNetworksPanel_PropertiesBtn.Name = "ManageNetworksPanel_PropertiesBtn";
      this.ManageNetworksPanel_ButtonBarSeperator.BackColor = Color.White;
      componentResourceManager.ApplyResources((object) this.ManageNetworksPanel_ButtonBarSeperator, "ManageNetworksPanel_ButtonBarSeperator");
      this.ManageNetworksPanel_ButtonBarSeperator.Name = "ManageNetworksPanel_ButtonBarSeperator";
      this.ManageNetworksPanel_ButtonBarSeperator.TabStop = false;
      componentResourceManager.ApplyResources((object) this.ManageNetworksPanel_ProfileListBox, "ManageNetworksPanel_ProfileListBox");
      this.ManageNetworksPanel_ProfileListBox.BackColor = Color.White;
      this.ManageNetworksPanel_ProfileListBox.EnableProperitesCallback = (EnableProperitesDelegate) null;
      this.ManageNetworksPanel_ProfileListBox.EnableSetAsDefaultCallback = (EnableSetAsDefaultDelegate) null;
      this.ManageNetworksPanel_ProfileListBox.Name = "ManageNetworksPanel_ProfileListBox";
      this.ManageNetworksPanel_ProfileListBox.ProfileSelectedCallback = (ProfileSelectedDelegate) null;
      this.ManageNetworksPanel_ProfileListBox.ProperitesCallback = (ProperitesDelegate) null;
      this.ManageNetworksPanel_ProfileListBox.SetAsDefaultCallback = (SetAsDefaultDelegate) null;
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.ManageNetworksPanel_ProfileListBox);
      this.Controls.Add((Control) this.ManageNetworksPanel_SetAsPreferredPropertiesBtnBox);
      this.Controls.Add((Control) this.ManageNetworksPanel_CloseBtnBox);
      this.Controls.Add((Control) this.ManageNetworksPanel_HeaderLbl);
      this.Controls.Add((Control) this.ManageNetworksPanel_HelpButtonLabelPair);
      this.Controls.Add((Control) this.ManageNetworksPanel_ButtonBarSeperator);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "ManageNetworksPanel";
      this.ManageNetworksPanel_CloseBtnBox.ResumeLayout(false);
      this.ManageNetworksPanel_SetAsPreferredPropertiesBtnBox.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
