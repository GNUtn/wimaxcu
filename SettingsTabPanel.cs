// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.SettingsTabPanel
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.SDKInterop;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using Intel.Mobile.WiMAXCU.UI.DisplayWiMAX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class SettingsTabPanel : UserControl
  {
    private IContainer components;
    private Label SettingsTabPanel_NetworkSettingsInstructionsLbl;
    private CustomLabelSeparator SettingsTabPanel_NetworkSettingsSeparator;
    private CustomComboBox SettingsTabPanel_NetworkSettingsComboBox;
    private CustomButtonPushHorizBox SettingsTabPanel_NetworkSettingsRestoreBtnBox;
    private CustomButtonPush SettingsTabPanel_NetworkSettingsRestoreBtn;
    private GroupBox SettingsTabPanel_NetworkSettingsGroupBox;
    private CustomRadioButtonGroup SettingsTabPanel_NetworkSettingsRadioButtonGroup;
    private Label SettingsTabPanel_NetworkSettingsWarningLbl;
    private AdvancedPanel _parentPanel;
    private static int _iResult;
    private CustomMessageBox _confirmOperationMessageBox;
    private List<ProfileDisplayItem> _profiles;
    private SettingsTabPanel.RestoreNetworkSettingsEnum _selectedRadioButton;
    private WIMAX_API_PROFILE_INFO _selectedComboBoxProfile;
    private System.Windows.Forms.Timer _timeoutTimer;
    private bool _timeoutOccurred;

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

    public SettingsTabPanel()
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (SettingsTabPanel));
      this.SettingsTabPanel_NetworkSettingsInstructionsLbl = new Label();
      this.SettingsTabPanel_NetworkSettingsSeparator = new CustomLabelSeparator();
      this.SettingsTabPanel_NetworkSettingsComboBox = new CustomComboBox();
      this.SettingsTabPanel_NetworkSettingsRestoreBtnBox = new CustomButtonPushHorizBox();
      this.SettingsTabPanel_NetworkSettingsRestoreBtn = new CustomButtonPush();
      this.SettingsTabPanel_NetworkSettingsGroupBox = new GroupBox();
      this.SettingsTabPanel_NetworkSettingsRadioButtonGroup = new CustomRadioButtonGroup();
      this.SettingsTabPanel_NetworkSettingsWarningLbl = new Label();
      this.SettingsTabPanel_NetworkSettingsRestoreBtnBox.SuspendLayout();
      this.SettingsTabPanel_NetworkSettingsGroupBox.SuspendLayout();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.SettingsTabPanel_NetworkSettingsInstructionsLbl, "SettingsTabPanel_NetworkSettingsInstructionsLbl");
      this.SettingsTabPanel_NetworkSettingsInstructionsLbl.Name = "SettingsTabPanel_NetworkSettingsInstructionsLbl";
      this.SettingsTabPanel_NetworkSettingsSeparator.BackColor = Color.White;
      componentResourceManager.ApplyResources((object) this.SettingsTabPanel_NetworkSettingsSeparator, "SettingsTabPanel_NetworkSettingsSeparator");
      this.SettingsTabPanel_NetworkSettingsSeparator.Name = "SettingsTabPanel_NetworkSettingsSeparator";
      this.SettingsTabPanel_NetworkSettingsSeparator.TabStop = false;
      this.SettingsTabPanel_NetworkSettingsComboBox.DrawMode = DrawMode.OwnerDrawFixed;
      this.SettingsTabPanel_NetworkSettingsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      this.SettingsTabPanel_NetworkSettingsComboBox.FormattingEnabled = true;
      componentResourceManager.ApplyResources((object) this.SettingsTabPanel_NetworkSettingsComboBox, "SettingsTabPanel_NetworkSettingsComboBox");
      this.SettingsTabPanel_NetworkSettingsComboBox.Name = "SettingsTabPanel_NetworkSettingsComboBox";
      this.SettingsTabPanel_NetworkSettingsComboBox.Text = (string) null;
      this.SettingsTabPanel_NetworkSettingsRestoreBtnBox.Controls.Add((Control) this.SettingsTabPanel_NetworkSettingsRestoreBtn);
      componentResourceManager.ApplyResources((object) this.SettingsTabPanel_NetworkSettingsRestoreBtnBox, "SettingsTabPanel_NetworkSettingsRestoreBtnBox");
      this.SettingsTabPanel_NetworkSettingsRestoreBtnBox.HorizontalJustification = HorizontalJustificationEnum.Right;
      this.SettingsTabPanel_NetworkSettingsRestoreBtnBox.Name = "SettingsTabPanel_NetworkSettingsRestoreBtnBox";
      this.SettingsTabPanel_NetworkSettingsRestoreBtn.BackColor = Color.White;
      this.SettingsTabPanel_NetworkSettingsRestoreBtn.BtnColor = PushButtonColorEnum.BlueGrey;
      this.SettingsTabPanel_NetworkSettingsRestoreBtn.BtnDoubleEndCaps = false;
      this.SettingsTabPanel_NetworkSettingsRestoreBtn.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.SettingsTabPanel_NetworkSettingsRestoreBtn, "SettingsTabPanel_NetworkSettingsRestoreBtn");
      this.SettingsTabPanel_NetworkSettingsRestoreBtn.Name = "SettingsTabPanel_NetworkSettingsRestoreBtn";
      this.SettingsTabPanel_NetworkSettingsGroupBox.Controls.Add((Control) this.SettingsTabPanel_NetworkSettingsComboBox);
      this.SettingsTabPanel_NetworkSettingsGroupBox.Controls.Add((Control) this.SettingsTabPanel_NetworkSettingsRadioButtonGroup);
      componentResourceManager.ApplyResources((object) this.SettingsTabPanel_NetworkSettingsGroupBox, "SettingsTabPanel_NetworkSettingsGroupBox");
      this.SettingsTabPanel_NetworkSettingsGroupBox.Name = "SettingsTabPanel_NetworkSettingsGroupBox";
      this.SettingsTabPanel_NetworkSettingsGroupBox.TabStop = false;
      this.SettingsTabPanel_NetworkSettingsRadioButtonGroup.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.SettingsTabPanel_NetworkSettingsRadioButtonGroup, "SettingsTabPanel_NetworkSettingsRadioButtonGroup");
      this.SettingsTabPanel_NetworkSettingsRadioButtonGroup.Name = "SettingsTabPanel_NetworkSettingsRadioButtonGroup";
      this.SettingsTabPanel_NetworkSettingsRadioButtonGroup.SelectedIndex = 0;
      componentResourceManager.ApplyResources((object) this.SettingsTabPanel_NetworkSettingsWarningLbl, "SettingsTabPanel_NetworkSettingsWarningLbl");
      this.SettingsTabPanel_NetworkSettingsWarningLbl.ForeColor = Color.Red;
      this.SettingsTabPanel_NetworkSettingsWarningLbl.Name = "SettingsTabPanel_NetworkSettingsWarningLbl";
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.SettingsTabPanel_NetworkSettingsRestoreBtnBox);
      this.Controls.Add((Control) this.SettingsTabPanel_NetworkSettingsWarningLbl);
      this.Controls.Add((Control) this.SettingsTabPanel_NetworkSettingsGroupBox);
      this.Controls.Add((Control) this.SettingsTabPanel_NetworkSettingsInstructionsLbl);
      this.Controls.Add((Control) this.SettingsTabPanel_NetworkSettingsSeparator);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "SettingsTabPanel";
      this.SettingsTabPanel_NetworkSettingsRestoreBtnBox.ResumeLayout(false);
      this.SettingsTabPanel_NetworkSettingsGroupBox.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public void InitPanel()
    {
      this.SettingsTabPanel_NetworkSettingsRadioButtonGroup.SelectedIndex = 1;
      this.PopulateComboBox();
      this.UpdateUI(true);
      this.RegisterForEvents();
    }

    public void CleanUp()
    {
      this.UnregisterForEvents();
    }

    public void UpdateUI(bool initDialog)
    {
      if (!MediaHandler.TheMedia.WiMAXIsReady || !MediaHandler.IntelCUIsInControl)
      {
        if (this._confirmOperationMessageBox != null && this._confirmOperationMessageBox.Visible)
          this._confirmOperationMessageBox.Close();
        this.SettingsTabPanel_NetworkSettingsRadioButtonGroup.Enabled = false;
        this.SettingsTabPanel_NetworkSettingsComboBox.Enabled = false;
        this.SettingsTabPanel_NetworkSettingsRestoreBtn.BtnEnabled = false;
        this.Cursor = Cursors.Default;
      }
      else if (this._parentPanel.Blocked)
      {
        this.SettingsTabPanel_NetworkSettingsRadioButtonGroup.Enabled = false;
        this.SettingsTabPanel_NetworkSettingsComboBox.Enabled = false;
        this.SettingsTabPanel_NetworkSettingsRestoreBtn.BtnEnabled = false;
        if (!this._parentPanel.Blocked)
          return;
        this.Cursor = Cursors.WaitCursor;
      }
      else
      {
        this.SettingsTabPanel_NetworkSettingsRadioButtonGroup.Enabled = true;
        if (this.SettingsTabPanel_NetworkSettingsRadioButtonGroup.SelectedIndex == 0)
          this.SettingsTabPanel_NetworkSettingsComboBox.Enabled = false;
        else
          this.SettingsTabPanel_NetworkSettingsComboBox.Enabled = true;
        this.SettingsTabPanel_NetworkSettingsRestoreBtn.BtnEnabled = this.SettingsTabPanel_NetworkSettingsRadioButtonGroup.SelectedIndex != 1 || !string.IsNullOrEmpty((string) this.SettingsTabPanel_NetworkSettingsComboBox.SelectedItem);
        this.Cursor = Cursors.Default;
      }
    }

    private void OnTimeoutTimerTick(object sender, EventArgs e)
    {
      if (this._parentPanel == null || !this._parentPanel.Visible)
        return;
      this.Unblock();
      this.UpdateUI(false);
      this._timeoutOccurred = true;
      ErrorHelper.ShowErrorDialog((Control) this, ErrorStringsHelper.GetString("General_RestoreNetworkSettingsFailed"), ErrorHelper.TranslateErrorCodeToMessage(57345), (string) null, "RestoreNetworkSettingsFailed");
    }

    private void OnNetworkSettingsRestoreBtnPressed(object sender, EventArgs e)
    {
      if (NetworkHandler.ConnectedNetworks.Count > 0)
      {
        if (this._confirmOperationMessageBox == null)
        {
          this._confirmOperationMessageBox = new CustomMessageBox(AdvancedDlgStringHelper.GetString("SettingsTabPanel_ConfirmOperationPopup"), CustomMessageBoxStyle.YesNo);
          this._confirmOperationMessageBox.AccessibleName = "SettingsTabPanelConfirmOperationMB";
        }
        if (!this._confirmOperationMessageBox.Visible && this._confirmOperationMessageBox.CustomShowDialog((IWin32Window) this._parentPanel, false) != DialogResult.Yes)
          return;
      }
      if (!this.PrerequisitesMet())
        return;
      this._selectedRadioButton = (SettingsTabPanel.RestoreNetworkSettingsEnum) this.SettingsTabPanel_NetworkSettingsRadioButtonGroup.SelectedIndex;
      if (this._selectedRadioButton == SettingsTabPanel.RestoreNetworkSettingsEnum.Single)
      {
        this._selectedComboBoxProfile = this._profiles[this.SettingsTabPanel_NetworkSettingsComboBox.SelectedIndex].TheProfile;
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user pressed the 'Restore Settings' button (for the " + this.SettingsTabPanel_NetworkSettingsComboBox.SelectedItem + " network).");
      }
      else
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user pressed the 'Restore Settings' button (for all networks).");
      this._parentPanel.Block();
      if (this._timeoutTimer == null)
      {
        this._timeoutTimer = new System.Windows.Forms.Timer();
        this._timeoutTimer.Interval = TimerSettings.SettingsTabPanel_TimeoutTimer_Interval;
        this._timeoutTimer.Tick += new EventHandler(this.OnTimeoutTimerTick);
        this._timeoutTimer.Start();
      }
      else
        this._timeoutTimer.Start();
      this._timeoutOccurred = false;
      SettingsTabPanel._iResult = 0;
      ThreadPool.QueueUserWorkItem(new WaitCallback(this.DoAsyncRestoreNetworkSettings));
    }

    private void OnNetworkSettingsRadioButtonGroupSelected(object sender, SelectionArgs e)
    {
      this.UpdateUI(false);
    }

    private void CustomInitializeComponents()
    {
      this.SettingsTabPanel_NetworkSettingsInstructionsLbl.AccessibleName = "SettingsTabPanel_NetworkSettingsInstructionsLbl";
      this.SettingsTabPanel_NetworkSettingsRadioButtonGroup.AccessibleName = "SettingsTabPanel_NetworkSettingsRadioButtonGroup";
      this.SettingsTabPanel_NetworkSettingsRestoreBtn.AccessibleName = "SettingsTabPanel_NetworkSettingsRestoreBtn";
      this.SettingsTabPanel_NetworkSettingsSeparator.AccessibleName = "SettingsTabPanel_NetworkSettingsSeparator";
      this.SettingsTabPanel_NetworkSettingsWarningLbl.AccessibleName = "SettingsTabPanel_NetworkSettingsWarningLbl";
      this.SettingsTabPanel_NetworkSettingsComboBox.AccessibleName = "SettingsTabPanel_NetworkSettingsComboBox";
      this.SettingsTabPanel_NetworkSettingsInstructionsLbl.Text = AdvancedDlgStringHelper.GetString("SettingsTabPanel_NetworkSettingsInstructionsLbl");
      this.SettingsTabPanel_NetworkSettingsRadioButtonGroup.Labels = new string[2]
      {
        AdvancedDlgStringHelper.GetString("SettingsTabPanel_AllNetworksRadioBtn"),
        AdvancedDlgStringHelper.GetString("SettingsTabPanel_ThisNetworkOnlyRadioBtn")
      };
      this.SettingsTabPanel_NetworkSettingsRestoreBtn.BtnText = AdvancedDlgStringHelper.GetString("SettingsTabPanel_NetworkSettingsRestoreBtn");
      this.SettingsTabPanel_NetworkSettingsSeparator.Text = AdvancedDlgStringHelper.GetString("SettingsTabPanel_NetworkSettingsSeparator");
      this.SettingsTabPanel_NetworkSettingsWarningLbl.Text = AdvancedDlgStringHelper.GetString("SettingsTabPanel_NetworkSettingsWarningLbl");
      this.SettingsTabPanel_NetworkSettingsComboBox.IntegralHeight = false;
      this.SettingsTabPanel_NetworkSettingsComboBox.MaxDropDownItems = 7;
      this.SettingsTabPanel_NetworkSettingsRestoreBtn.Pressed += new CustomButtonPush.PressedDelegate(this.OnNetworkSettingsRestoreBtnPressed);
      this.SettingsTabPanel_NetworkSettingsRadioButtonGroup.SelectionChanged += new CustomRadioButtonGroup.SelectionChangedDelegate(this.OnNetworkSettingsRadioButtonGroupSelected);
      SizeHelper.ResizeCustomControls(this.Controls);
    }

    private void RegisterForEvents()
    {
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnRestoreNetworkSettingsComplete), (object) this, "WiMAXSP.OnRestoreNetworkSettingsComplete");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnStateChange), (object) this, "WiMAXUI.OnStateChange");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnMediaStatusChanged), (object) this, "WiMAXUI.OnMediaStatusChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnIntelCUControlChanged), (object) this, "WiMAXUI.OnIntelCUControlChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnProfileListChanged), (object) this, "WiMAXUI.OnProfileListChanged");
    }

    private void UnregisterForEvents()
    {
      Eventing.DeRegisterAllUIEvents((object) this);
    }

    private void PopulateComboBox()
    {
      this.SettingsTabPanel_NetworkSettingsComboBox.Items.Clear();
      this._profiles = new List<ProfileDisplayItem>((IEnumerable<ProfileDisplayItem>) ProfileHandler.Singleton.Profiles);
      this._profiles.Sort(new Comparison<ProfileDisplayItem>(SettingsTabPanel.CompareProfile));
      for (int index = 0; index < this._profiles.Count; ++index)
      {
        this.SettingsTabPanel_NetworkSettingsComboBox.Items.Add((object) MiscUtilities.ParseProfileName(this._profiles[index].TheProfile.profileName));
        if (this._profiles[index].Preferred)
          this.SettingsTabPanel_NetworkSettingsComboBox.SelectedIndex = index;
        else if (WiMAXDisplayService.IsHomeNetwork(this._profiles[index].TheProfile.profileId) && this.SettingsTabPanel_NetworkSettingsComboBox.SelectedIndex < 0)
          this.SettingsTabPanel_NetworkSettingsComboBox.SelectedIndex = index;
      }
      if (this.SettingsTabPanel_NetworkSettingsComboBox.SelectedIndex < 0 && this.SettingsTabPanel_NetworkSettingsComboBox.Items.Count > 0)
        this.SettingsTabPanel_NetworkSettingsComboBox.SelectedIndex = 0;
      this.UpdateUI(false);
    }

    private static int CompareProfile(ProfileDisplayItem x, ProfileDisplayItem y)
    {
      return x.TheProfile.profileName.CompareTo(y.TheProfile.profileName);
    }

    private bool PrerequisitesMet()
    {
      if (!MediaHandler.TheMedia.WiMAXIsReady || !APDOHandler.ProvisioningInProgress)
        return true;
      ErrorHelper.ShowErrorDialog((Control) this, ErrorStringsHelper.GetString("General_RestoreNetworkSettingsFailed"), ErrorHelper.TranslateErrorCodeToMessage(57345), (string) null, "RestoreNetworkSettingsFailed");
      return false;
    }

    private void Unblock()
    {
      if (this._timeoutTimer != null)
        this._timeoutTimer.Stop();
      this._parentPanel.Unblock();
    }

    public void OnRestoreNetworkSettingsComplete(object sender, object[] eventArgs)
    {
      if (this._parentPanel == null || !this._parentPanel.Visible || this._timeoutOccurred)
        return;
      this.Unblock();
      this.UpdateUI(false);
      if (SettingsTabPanel._iResult != 0)
      {
        ErrorHelper.ShowErrorDialog((Control) this, ErrorStringsHelper.GetString("General_RestoreNetworkSettingsFailed"), ErrorHelper.TranslateErrorCodeToMessage(SettingsTabPanel._iResult), (string) null, "RestoreNetworkSettingsFailed");
      }
      else
      {
        CustomMessageBox customMessageBox = new CustomMessageBox(this._selectedRadioButton != SettingsTabPanel.RestoreNetworkSettingsEnum.All ? string.Format(AdvancedDlgStringHelper.GetString("SettingsTabPanel_RestoreSelectedNetworkSettingsSucceededPopup"), (object) MiscUtilities.ParseProfileName(this._selectedComboBoxProfile.profileName)) : AdvancedDlgStringHelper.GetString("SettingsTabPanel_RestoreAllNetworkSettingsSucceededPopup"), CustomMessageBoxStyle.Ok);
        customMessageBox.AccessibleName = "RestoreNetworkSettingsSucceededMB";
        int num = (int) customMessageBox.CustomShowDialog((IWin32Window) this, false);
      }
    }

    public void OnStateChange(object sender, object[] eventArgs)
    {
      this.UpdateUI(false);
    }

    private void OnMediaStatusChanged(object sender, object[] eventArgs)
    {
      this.UpdateUI(false);
    }

    private void OnIntelCUControlChanged(object sender, object[] eventArgs)
    {
      this.UpdateUI(false);
    }

    private void OnProfileListChanged(object sender, object[] eventArgs)
    {
      this.PopulateComboBox();
    }

    private void DoAsyncRestoreNetworkSettings(object obj)
    {
      if (this._selectedRadioButton == SettingsTabPanel.RestoreNetworkSettingsEnum.All)
      {
        SettingsTabPanel._iResult = MiscHandler.Singleton.RestoreAllNetworkSettings();
        if (SettingsTabPanel._iResult == 0)
          CurrentUserSettings.RemoveWiMAXSettings();
      }
      else
      {
        bool isPreferredProfile = false;
        foreach (ProfileDisplayItem profileDisplayItem in ProfileHandler.Singleton.Profiles)
        {
          if ((int) profileDisplayItem.TheProfile.profileId == (int) this._selectedComboBoxProfile.profileId && profileDisplayItem.Preferred)
            isPreferredProfile = true;
        }
        SettingsTabPanel._iResult = MiscHandler.Singleton.RestoreSingleNetworkSettings(this._selectedComboBoxProfile);
        if (SettingsTabPanel._iResult == 0)
          CurrentUserSettings.RemoveWiMAXSettingsForNetwork(this._selectedComboBoxProfile, isPreferredProfile);
      }
      if (SettingsTabPanel._iResult == 0)
        MediaHandler.Singleton.RefreshData();
      Eventing.GenerateUIEvent("WiMAXSP.OnRestoreNetworkSettingsComplete", (object) this, new object[0]);
    }

    private enum RestoreNetworkSettingsEnum
    {
      All,
      Single,
    }
  }
}
