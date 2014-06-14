// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.ApplicationTabPanel
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class ApplicationTabPanel : UserControl
  {
    private IContainer components;
    private CustomCheckBox ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox;
    private CustomCheckBox ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox;
    private CustomCheckBox ApplicationTabPanel_ShowCoExPopupsChkBox;
    private CustomLabelSeparator ApplicationTabPanel_ApplicationSettingsLabelSeparator;
    private CustomCheckBox ApplicationTabPanel_ShowActiveRoutesPopupChkBox;
    private CustomCheckBox ApplicationTabPanel_ShowDualModeWarningPopupChkBox;
    private PreferencesPanel _parentPanel;

    public PreferencesPanel ParentPanel
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

    public ApplicationTabPanel()
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ApplicationTabPanel));
      this.ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox = new CustomCheckBox();
      this.ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox = new CustomCheckBox();
      this.ApplicationTabPanel_ShowCoExPopupsChkBox = new CustomCheckBox();
      this.ApplicationTabPanel_ApplicationSettingsLabelSeparator = new CustomLabelSeparator();
      this.ApplicationTabPanel_ShowActiveRoutesPopupChkBox = new CustomCheckBox();
      this.ApplicationTabPanel_ShowDualModeWarningPopupChkBox = new CustomCheckBox();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox, "ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox");
      this.ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox.BackColor = Color.Transparent;
      this.ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox.ButtonBitmapDisabled = (Bitmap) componentResourceManager.GetObject("ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox.ButtonBitmapDisabled");
      this.ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox.ButtonBitmapNormal = (Bitmap) componentResourceManager.GetObject("ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox.ButtonBitmapNormal");
      this.ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox.ButtonBitmapPressed = (Bitmap) componentResourceManager.GetObject("ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox.ButtonBitmapPressed");
      this.ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox.ButtonBitmapRollover = (Bitmap) componentResourceManager.GetObject("ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox.ButtonBitmapRollover");
      this.ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox.Checked = false;
      this.ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox.Name = "ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox";
      componentResourceManager.ApplyResources((object) this.ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox, "ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox");
      this.ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox.BackColor = Color.Transparent;
      this.ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox.ButtonBitmapDisabled = (Bitmap) componentResourceManager.GetObject("ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox.ButtonBitmapDisabled");
      this.ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox.ButtonBitmapNormal = (Bitmap) componentResourceManager.GetObject("ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox.ButtonBitmapNormal");
      this.ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox.ButtonBitmapPressed = (Bitmap) componentResourceManager.GetObject("ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox.ButtonBitmapPressed");
      this.ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox.ButtonBitmapRollover = (Bitmap) componentResourceManager.GetObject("ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox.ButtonBitmapRollover");
      this.ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox.Checked = false;
      this.ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox.Name = "ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox";
      componentResourceManager.ApplyResources((object) this.ApplicationTabPanel_ShowCoExPopupsChkBox, "ApplicationTabPanel_ShowCoExPopupsChkBox");
      this.ApplicationTabPanel_ShowCoExPopupsChkBox.BackColor = Color.Transparent;
      this.ApplicationTabPanel_ShowCoExPopupsChkBox.ButtonBitmapDisabled = (Bitmap) componentResourceManager.GetObject("ApplicationTabPanel_ShowCoExPopupsChkBox.ButtonBitmapDisabled");
      this.ApplicationTabPanel_ShowCoExPopupsChkBox.ButtonBitmapNormal = (Bitmap) componentResourceManager.GetObject("ApplicationTabPanel_ShowCoExPopupsChkBox.ButtonBitmapNormal");
      this.ApplicationTabPanel_ShowCoExPopupsChkBox.ButtonBitmapPressed = (Bitmap) componentResourceManager.GetObject("ApplicationTabPanel_ShowCoExPopupsChkBox.ButtonBitmapPressed");
      this.ApplicationTabPanel_ShowCoExPopupsChkBox.ButtonBitmapRollover = (Bitmap) componentResourceManager.GetObject("ApplicationTabPanel_ShowCoExPopupsChkBox.ButtonBitmapRollover");
      this.ApplicationTabPanel_ShowCoExPopupsChkBox.Checked = false;
      this.ApplicationTabPanel_ShowCoExPopupsChkBox.Name = "ApplicationTabPanel_ShowCoExPopupsChkBox";
      this.ApplicationTabPanel_ApplicationSettingsLabelSeparator.BackColor = Color.White;
      componentResourceManager.ApplyResources((object) this.ApplicationTabPanel_ApplicationSettingsLabelSeparator, "ApplicationTabPanel_ApplicationSettingsLabelSeparator");
      this.ApplicationTabPanel_ApplicationSettingsLabelSeparator.Name = "ApplicationTabPanel_ApplicationSettingsLabelSeparator";
      this.ApplicationTabPanel_ApplicationSettingsLabelSeparator.TabStop = false;
      componentResourceManager.ApplyResources((object) this.ApplicationTabPanel_ShowActiveRoutesPopupChkBox, "ApplicationTabPanel_ShowActiveRoutesPopupChkBox");
      this.ApplicationTabPanel_ShowActiveRoutesPopupChkBox.BackColor = Color.Transparent;
      this.ApplicationTabPanel_ShowActiveRoutesPopupChkBox.ButtonBitmapDisabled = (Bitmap) componentResourceManager.GetObject("ApplicationTabPanel_ShowActiveRoutesPopupChkBox.ButtonBitmapDisabled");
      this.ApplicationTabPanel_ShowActiveRoutesPopupChkBox.ButtonBitmapNormal = (Bitmap) componentResourceManager.GetObject("ApplicationTabPanel_ShowActiveRoutesPopupChkBox.ButtonBitmapNormal");
      this.ApplicationTabPanel_ShowActiveRoutesPopupChkBox.ButtonBitmapPressed = (Bitmap) componentResourceManager.GetObject("ApplicationTabPanel_ShowActiveRoutesPopupChkBox.ButtonBitmapPressed");
      this.ApplicationTabPanel_ShowActiveRoutesPopupChkBox.ButtonBitmapRollover = (Bitmap) componentResourceManager.GetObject("ApplicationTabPanel_ShowActiveRoutesPopupChkBox.ButtonBitmapRollover");
      this.ApplicationTabPanel_ShowActiveRoutesPopupChkBox.Checked = false;
      this.ApplicationTabPanel_ShowActiveRoutesPopupChkBox.Name = "ApplicationTabPanel_ShowActiveRoutesPopupChkBox";
      componentResourceManager.ApplyResources((object) this.ApplicationTabPanel_ShowDualModeWarningPopupChkBox, "ApplicationTabPanel_ShowDualModeWarningPopupChkBox");
      this.ApplicationTabPanel_ShowDualModeWarningPopupChkBox.BackColor = Color.Transparent;
      this.ApplicationTabPanel_ShowDualModeWarningPopupChkBox.ButtonBitmapDisabled = (Bitmap) componentResourceManager.GetObject("ApplicationTabPanel_ShowDualModeWarningPopupChkBox.ButtonBitmapDisabled");
      this.ApplicationTabPanel_ShowDualModeWarningPopupChkBox.ButtonBitmapNormal = (Bitmap) componentResourceManager.GetObject("ApplicationTabPanel_ShowDualModeWarningPopupChkBox.ButtonBitmapNormal");
      this.ApplicationTabPanel_ShowDualModeWarningPopupChkBox.ButtonBitmapPressed = (Bitmap) componentResourceManager.GetObject("ApplicationTabPanel_ShowDualModeWarningPopupChkBox.ButtonBitmapPressed");
      this.ApplicationTabPanel_ShowDualModeWarningPopupChkBox.ButtonBitmapRollover = (Bitmap) componentResourceManager.GetObject("ApplicationTabPanel_ShowDualModeWarningPopupChkBox.ButtonBitmapRollover");
      this.ApplicationTabPanel_ShowDualModeWarningPopupChkBox.Checked = false;
      this.ApplicationTabPanel_ShowDualModeWarningPopupChkBox.Name = "ApplicationTabPanel_ShowDualModeWarningPopupChkBox";
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.ApplicationTabPanel_ShowDualModeWarningPopupChkBox);
      this.Controls.Add((Control) this.ApplicationTabPanel_ShowActiveRoutesPopupChkBox);
      this.Controls.Add((Control) this.ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox);
      this.Controls.Add((Control) this.ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox);
      this.Controls.Add((Control) this.ApplicationTabPanel_ShowCoExPopupsChkBox);
      this.Controls.Add((Control) this.ApplicationTabPanel_ApplicationSettingsLabelSeparator);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "ApplicationTabPanel";
      this.ResumeLayout(false);
    }

    private void OnCheckboxChecked(object sender, bool isChecked)
    {
      this._parentPanel.UserMadeChange();
    }

    public void InitPanel()
    {
      this.InitCheckBoxValues();
    }

    public void CleanUp()
    {
    }

    public bool SaveChanges()
    {
      return !this.ChangesMade() || this.SaveCheckBoxChanges();
    }

    public bool ChangesMade()
    {
      return CurrentUserSettings.GetShowSubscribeForServiceAndFirewallPopup() != this.ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox.Checked || CurrentUserSettings.GetShowCoExPopups() != this.ApplicationTabPanel_ShowCoExPopupsChkBox.Checked || (CurrentUserSettings.GetShowComputerIsEnabledForWiMAXPopup() != this.ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox.Checked || CurrentUserSettings.GetShowActiveRoutesPopup() != this.ApplicationTabPanel_ShowActiveRoutesPopupChkBox.Checked) || CurrentUserSettings.GetShowDualModeWarningPopup() != this.ApplicationTabPanel_ShowDualModeWarningPopupChkBox.Checked;
    }

    private void CustomInitializeComponents()
    {
      this.AccessibleName = "ApplicationTabPanel";
      this.ApplicationTabPanel_ApplicationSettingsLabelSeparator.AccessibleName = "ApplicationTabPanel_ApplicationSettingsLabelSeparator";
      this.ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox.AccessibleName = "ApplicationTabPanel_ShowComputerIsEnabledForWiMAXNotificationChkBox";
      this.ApplicationTabPanel_ShowCoExPopupsChkBox.AccessibleName = "ApplicationTabPanel_ShowDisconnectWarningsChkBox";
      this.ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox.AccessibleName = "ApplicationTabPanel_ShowFirewallConfigurationWarningChkBox";
      this.ApplicationTabPanel_ShowActiveRoutesPopupChkBox.AccessibleName = "ApplicationTabPanel_ShowActiveRouteWarningChkBox";
      this.ApplicationTabPanel_ShowDualModeWarningPopupChkBox.AccessibleName = "ApplicationTabPanel_ShowDualModeWarningPopupChkBox";
      this.ApplicationTabPanel_ApplicationSettingsLabelSeparator.Text = PreferencesDlgStringHelper.GetString("ApplicationTabPanel_ApplicationSettingsLabelSeparator");
      this.ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox.Text = PreferencesDlgStringHelper.GetString("ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox");
      this.ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox.Text = PreferencesDlgStringHelper.GetString("ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox");
      this.ApplicationTabPanel_ShowCoExPopupsChkBox.Text = PreferencesDlgStringHelper.GetString("ApplicationTabPanel_ShowCoExPopupsChkBox");
      this.ApplicationTabPanel_ShowActiveRoutesPopupChkBox.Text = PreferencesDlgStringHelper.GetString("ApplicationTabPanel_ShowActiveRoutesPopupChkBox");
      this.ApplicationTabPanel_ShowDualModeWarningPopupChkBox.Text = PreferencesDlgStringHelper.GetString("ApplicationTabPanel_ShowDualModeWarningPopupChkBox");
      this.ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox.CheckedChanged += new CustomCheckBox.CheckChangedDelegate(this.OnCheckboxChecked);
      this.ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox.CheckedChanged += new CustomCheckBox.CheckChangedDelegate(this.OnCheckboxChecked);
      this.ApplicationTabPanel_ShowCoExPopupsChkBox.CheckedChanged += new CustomCheckBox.CheckChangedDelegate(this.OnCheckboxChecked);
      this.ApplicationTabPanel_ShowActiveRoutesPopupChkBox.CheckedChanged += new CustomCheckBox.CheckChangedDelegate(this.OnCheckboxChecked);
      this.ApplicationTabPanel_ShowDualModeWarningPopupChkBox.CheckedChanged += new CustomCheckBox.CheckChangedDelegate(this.OnCheckboxChecked);
      if (!LocalMachineSettings.IsDualModeWarningEnabled())
        this.ApplicationTabPanel_ShowDualModeWarningPopupChkBox.Visible = false;
      SizeHelper.ResizeCustomControls(this.Controls);
    }

    private void InitCheckBoxValues()
    {
      this.ApplicationTabPanel_ShowCoExPopupsChkBox.Checked = CurrentUserSettings.GetShowCoExPopups();
      this.ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox.Checked = CurrentUserSettings.GetShowSubscribeForServiceAndFirewallPopup();
      this.ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox.Checked = CurrentUserSettings.GetShowComputerIsEnabledForWiMAXPopup();
      this.ApplicationTabPanel_ShowActiveRoutesPopupChkBox.Checked = CurrentUserSettings.GetShowActiveRoutesPopup();
      if (!LocalMachineSettings.IsDualModeWarningEnabled())
        return;
      this.ApplicationTabPanel_ShowDualModeWarningPopupChkBox.Checked = CurrentUserSettings.GetShowDualModeWarningPopup();
    }

    private bool SaveCheckBoxChanges()
    {
      if (CurrentUserSettings.GetShowSubscribeForServiceAndFirewallPopup() != this.ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox.Checked)
        CurrentUserSettings.SetShowSubscribeForServiceAndFirewallPopup(this.ApplicationTabPanel_ShowSubscribeForServiceAndFirewallPopupChkBox.Checked);
      if (CurrentUserSettings.GetShowCoExPopups() != this.ApplicationTabPanel_ShowCoExPopupsChkBox.Checked)
        CurrentUserSettings.SetShowCoExPopups(this.ApplicationTabPanel_ShowCoExPopupsChkBox.Checked);
      if (CurrentUserSettings.GetShowComputerIsEnabledForWiMAXPopup() != this.ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox.Checked)
        CurrentUserSettings.SetShowComputerIsEnabledForWiMAXPopup(this.ApplicationTabPanel_ShowComputerIsEnabledForWiMAXPopupChkBox.Checked);
      if (CurrentUserSettings.GetShowActiveRoutesPopup() != this.ApplicationTabPanel_ShowActiveRoutesPopupChkBox.Checked)
        CurrentUserSettings.SetShowActiveRoutesPopup(this.ApplicationTabPanel_ShowActiveRoutesPopupChkBox.Checked);
      if (LocalMachineSettings.IsDualModeWarningEnabled() && CurrentUserSettings.GetShowDualModeWarningPopup() != this.ApplicationTabPanel_ShowDualModeWarningPopupChkBox.Checked)
        CurrentUserSettings.SetShowDualModeWarningPopup(this.ApplicationTabPanel_ShowDualModeWarningPopupChkBox.Checked);
      return true;
    }
  }
}
