// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.TaskbarTabPanel
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
  public class TaskbarTabPanel : UserControl
  {
    private PreferencesPanel _parentPanel;
    private IContainer components;
    private CustomCheckBox TaskbarTabPanel_ShowTasktrayNotificationsChkBox;
    private Label TaskbarTabPanel_HowToLaunchCULabel;
    private CustomLabelSeparator TaskbarTabPanel_TaskbarSettingsLabelSeparator;
    private CustomCheckBox TaskbarTabPanel_ShowSystemTrayIconChkBox;

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

    public TaskbarTabPanel()
    {
      this.InitializeComponent();
      this.CustomInitializeComponents();
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
      return CurrentUserSettings.GetShowTrayIconSetting() != this.TaskbarTabPanel_ShowSystemTrayIconChkBox.Checked || CurrentUserSettings.GetShowTaskTrayNotifications() != this.TaskbarTabPanel_ShowTasktrayNotificationsChkBox.Checked;
    }

    private void CustomInitializeComponents()
    {
      this.AccessibleName = "TaskbarTabPanel";
      this.TaskbarTabPanel_HowToLaunchCULabel.AccessibleName = "TaskbarTabPanel_HowToLaunchCULabel";
      this.TaskbarTabPanel_ShowSystemTrayIconChkBox.AccessibleName = "TaskbarTabPanel_ShowSystemTrayIconChkBox";
      this.TaskbarTabPanel_ShowTasktrayNotificationsChkBox.AccessibleName = "TaskbarTabPanel_ShowTasktrayNotificationsChkBox";
      this.TaskbarTabPanel_TaskbarSettingsLabelSeparator.AccessibleName = "TaskbarTabPanel_TaskbarSettingsLabelSeparator";
      this.TaskbarTabPanel_TaskbarSettingsLabelSeparator.Text = PreferencesDlgStringHelper.GetString("TaskbarTabPanel_TaskbarSettingsLabelSeparator");
      this.TaskbarTabPanel_ShowSystemTrayIconChkBox.Text = PreferencesDlgStringHelper.GetString("TaskbarTabPanel_ShowSystemTrayIconChkBox");
      this.TaskbarTabPanel_HowToLaunchCULabel.Text = PreferencesDlgStringHelper.GetString("TaskbarTabPanel_HowToLaunchCULabel");
      this.TaskbarTabPanel_ShowTasktrayNotificationsChkBox.Text = PreferencesDlgStringHelper.GetString("TaskbarTabPanel_ShowTasktrayNotificationsChkBox");
      this.TaskbarTabPanel_ShowSystemTrayIconChkBox.CheckedChanged += new CustomCheckBox.CheckChangedDelegate(this.OnCheckboxChecked);
      this.TaskbarTabPanel_ShowTasktrayNotificationsChkBox.CheckedChanged += new CustomCheckBox.CheckChangedDelegate(this.OnCheckboxChecked);
      SizeHelper.ResizeCustomControls(this.Controls);
    }

    private void InitCheckBoxValues()
    {
      this.TaskbarTabPanel_ShowSystemTrayIconChkBox.Checked = CurrentUserSettings.GetShowTrayIconSetting();
      this.TaskbarTabPanel_ShowTasktrayNotificationsChkBox.Checked = CurrentUserSettings.GetShowTaskTrayNotifications();
    }

    private bool SaveCheckBoxChanges()
    {
      if (CurrentUserSettings.GetShowTrayIconSetting() != this.TaskbarTabPanel_ShowSystemTrayIconChkBox.Checked)
      {
        CurrentUserSettings.SetShowTrayIconSetting(this.TaskbarTabPanel_ShowSystemTrayIconChkBox.Checked);
        if (AppFramework.Dashboard.TheTaskTray != null)
          AppFramework.Dashboard.TheTaskTray.TaskTrayNotifyIcon.Visible = this.TaskbarTabPanel_ShowSystemTrayIconChkBox.Checked;
      }
      if (CurrentUserSettings.GetShowTaskTrayNotifications() != this.TaskbarTabPanel_ShowTasktrayNotificationsChkBox.Checked)
        CurrentUserSettings.SetShowTaskTrayNotifications(this.TaskbarTabPanel_ShowTasktrayNotificationsChkBox.Checked);
      return true;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TaskbarTabPanel));
      this.TaskbarTabPanel_ShowTasktrayNotificationsChkBox = new CustomCheckBox();
      this.TaskbarTabPanel_HowToLaunchCULabel = new Label();
      this.TaskbarTabPanel_TaskbarSettingsLabelSeparator = new CustomLabelSeparator();
      this.TaskbarTabPanel_ShowSystemTrayIconChkBox = new CustomCheckBox();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.TaskbarTabPanel_ShowTasktrayNotificationsChkBox, "TaskbarTabPanel_ShowTasktrayNotificationsChkBox");
      this.TaskbarTabPanel_ShowTasktrayNotificationsChkBox.BackColor = Color.Transparent;
      this.TaskbarTabPanel_ShowTasktrayNotificationsChkBox.ButtonBitmapDisabled = (Bitmap) componentResourceManager.GetObject("TaskbarTabPanel_ShowTasktrayNotificationsChkBox.ButtonBitmapDisabled");
      this.TaskbarTabPanel_ShowTasktrayNotificationsChkBox.ButtonBitmapNormal = (Bitmap) componentResourceManager.GetObject("TaskbarTabPanel_ShowTasktrayNotificationsChkBox.ButtonBitmapNormal");
      this.TaskbarTabPanel_ShowTasktrayNotificationsChkBox.ButtonBitmapPressed = (Bitmap) componentResourceManager.GetObject("TaskbarTabPanel_ShowTasktrayNotificationsChkBox.ButtonBitmapPressed");
      this.TaskbarTabPanel_ShowTasktrayNotificationsChkBox.ButtonBitmapRollover = (Bitmap) componentResourceManager.GetObject("TaskbarTabPanel_ShowTasktrayNotificationsChkBox.ButtonBitmapRollover");
      this.TaskbarTabPanel_ShowTasktrayNotificationsChkBox.Checked = false;
      this.TaskbarTabPanel_ShowTasktrayNotificationsChkBox.Name = "TaskbarTabPanel_ShowTasktrayNotificationsChkBox";
      this.TaskbarTabPanel_HowToLaunchCULabel.BackColor = Color.White;
      this.TaskbarTabPanel_HowToLaunchCULabel.ForeColor = Color.Black;
      componentResourceManager.ApplyResources((object) this.TaskbarTabPanel_HowToLaunchCULabel, "TaskbarTabPanel_HowToLaunchCULabel");
      this.TaskbarTabPanel_HowToLaunchCULabel.Name = "TaskbarTabPanel_HowToLaunchCULabel";
      this.TaskbarTabPanel_TaskbarSettingsLabelSeparator.BackColor = Color.White;
      componentResourceManager.ApplyResources((object) this.TaskbarTabPanel_TaskbarSettingsLabelSeparator, "TaskbarTabPanel_TaskbarSettingsLabelSeparator");
      this.TaskbarTabPanel_TaskbarSettingsLabelSeparator.Name = "TaskbarTabPanel_TaskbarSettingsLabelSeparator";
      this.TaskbarTabPanel_TaskbarSettingsLabelSeparator.TabStop = false;
      componentResourceManager.ApplyResources((object) this.TaskbarTabPanel_ShowSystemTrayIconChkBox, "TaskbarTabPanel_ShowSystemTrayIconChkBox");
      this.TaskbarTabPanel_ShowSystemTrayIconChkBox.BackColor = Color.Transparent;
      this.TaskbarTabPanel_ShowSystemTrayIconChkBox.ButtonBitmapDisabled = (Bitmap) componentResourceManager.GetObject("TaskbarTabPanel_ShowSystemTrayIconChkBox.ButtonBitmapDisabled");
      this.TaskbarTabPanel_ShowSystemTrayIconChkBox.ButtonBitmapNormal = (Bitmap) componentResourceManager.GetObject("TaskbarTabPanel_ShowSystemTrayIconChkBox.ButtonBitmapNormal");
      this.TaskbarTabPanel_ShowSystemTrayIconChkBox.ButtonBitmapPressed = (Bitmap) componentResourceManager.GetObject("TaskbarTabPanel_ShowSystemTrayIconChkBox.ButtonBitmapPressed");
      this.TaskbarTabPanel_ShowSystemTrayIconChkBox.ButtonBitmapRollover = (Bitmap) componentResourceManager.GetObject("TaskbarTabPanel_ShowSystemTrayIconChkBox.ButtonBitmapRollover");
      this.TaskbarTabPanel_ShowSystemTrayIconChkBox.Checked = false;
      this.TaskbarTabPanel_ShowSystemTrayIconChkBox.Name = "TaskbarTabPanel_ShowSystemTrayIconChkBox";
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.TaskbarTabPanel_ShowTasktrayNotificationsChkBox);
      this.Controls.Add((Control) this.TaskbarTabPanel_HowToLaunchCULabel);
      this.Controls.Add((Control) this.TaskbarTabPanel_TaskbarSettingsLabelSeparator);
      this.Controls.Add((Control) this.TaskbarTabPanel_ShowSystemTrayIconChkBox);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "TaskbarTabPanel";
      this.ResumeLayout(false);
    }
  }
}
