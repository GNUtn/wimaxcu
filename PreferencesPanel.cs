// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.PreferencesPanel
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.UI.CustomControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class PreferencesPanel : UserControl
  {
    private Container components;
    private PreferencesDialog _parentDialog;
    private CustomButtonPushHorizBox PreferencesPanel_SaveCancelBtnBox;
    private CustomButtonPush PreferencesPanel_SaveBtn;
    private CustomButtonPush PreferencesPanel_CancelBtn;
    private CustomTabControl PreferencesPanel_TabControl;
    private Label PreferencesPanel_HeaderLbl;
    private TabPage PreferencesPanel_ApplicationTabPage;
    private ApplicationTabPanel PreferencesPanel_ApplicationTabPanel;
    private TabPage PreferencesPanel_TaskbarTabPage;
    private TaskbarTabPanel PreferencesPanel_TaskbarTabPanel;
    private CustomHelpButtonLabelPair PreferencesPanel_HelpButtonLabelPair;

    public PreferencesPanel(PreferencesDialog parentDialog)
    {
      this._parentDialog = parentDialog;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (PreferencesPanel));
      this.PreferencesPanel_TabControl = new CustomTabControl();
      this.PreferencesPanel_ApplicationTabPage = new TabPage();
      this.PreferencesPanel_ApplicationTabPanel = new ApplicationTabPanel();
      this.PreferencesPanel_TaskbarTabPage = new TabPage();
      this.PreferencesPanel_TaskbarTabPanel = new TaskbarTabPanel();
      this.PreferencesPanel_HelpButtonLabelPair = new CustomHelpButtonLabelPair();
      this.PreferencesPanel_SaveCancelBtnBox = new CustomButtonPushHorizBox();
      this.PreferencesPanel_SaveBtn = new CustomButtonPush();
      this.PreferencesPanel_CancelBtn = new CustomButtonPush();
      this.PreferencesPanel_HeaderLbl = new Label();
      this.PreferencesPanel_ApplicationTabPage.SuspendLayout();
      this.PreferencesPanel_TaskbarTabPage.SuspendLayout();
      this.PreferencesPanel_SaveCancelBtnBox.SuspendLayout();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.PreferencesPanel_TabControl, "PreferencesPanel_TabControl");
      this.PreferencesPanel_TabControl.Name = "PreferencesPanel_TabControl";
      this.PreferencesPanel_TabControl.SelectedIndex = 0;
      this.PreferencesPanel_ApplicationTabPage.BackColor = Color.White;
      this.PreferencesPanel_ApplicationTabPage.Controls.Add((Control) this.PreferencesPanel_ApplicationTabPanel);
      componentResourceManager.ApplyResources((object) this.PreferencesPanel_ApplicationTabPage, "PreferencesPanel_ApplicationTabPage");
      this.PreferencesPanel_ApplicationTabPage.Name = "PreferencesPanel_ApplicationTabPage";
      this.PreferencesPanel_ApplicationTabPage.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.PreferencesPanel_ApplicationTabPanel, "PreferencesPanel_ApplicationTabPanel");
      this.PreferencesPanel_ApplicationTabPanel.BackColor = Color.White;
      this.PreferencesPanel_ApplicationTabPanel.Name = "PreferencesPanel_ApplicationTabPanel";
      this.PreferencesPanel_ApplicationTabPanel.ParentPanel = (PreferencesPanel) null;
      this.PreferencesPanel_TaskbarTabPage.BackColor = Color.White;
      this.PreferencesPanel_TaskbarTabPage.Controls.Add((Control) this.PreferencesPanel_TaskbarTabPanel);
      componentResourceManager.ApplyResources((object) this.PreferencesPanel_TaskbarTabPage, "PreferencesPanel_TaskbarTabPage");
      this.PreferencesPanel_TaskbarTabPage.Name = "PreferencesPanel_TaskbarTabPage";
      this.PreferencesPanel_TaskbarTabPage.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.PreferencesPanel_TaskbarTabPanel, "PreferencesPanel_TaskbarTabPanel");
      this.PreferencesPanel_TaskbarTabPanel.BackColor = Color.White;
      this.PreferencesPanel_TaskbarTabPanel.Name = "PreferencesPanel_TaskbarTabPanel";
      this.PreferencesPanel_TaskbarTabPanel.ParentPanel = (PreferencesPanel) null;
      this.PreferencesPanel_HelpButtonLabelPair.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.PreferencesPanel_HelpButtonLabelPair, "PreferencesPanel_HelpButtonLabelPair");
      this.PreferencesPanel_HelpButtonLabelPair.Name = "PreferencesPanel_HelpButtonLabelPair";
      this.PreferencesPanel_SaveCancelBtnBox.Controls.Add((Control) this.PreferencesPanel_SaveBtn);
      this.PreferencesPanel_SaveCancelBtnBox.Controls.Add((Control) this.PreferencesPanel_CancelBtn);
      componentResourceManager.ApplyResources((object) this.PreferencesPanel_SaveCancelBtnBox, "PreferencesPanel_SaveCancelBtnBox");
      this.PreferencesPanel_SaveCancelBtnBox.HorizontalJustification = HorizontalJustificationEnum.Right;
      this.PreferencesPanel_SaveCancelBtnBox.Name = "PreferencesPanel_SaveCancelBtnBox";
      this.PreferencesPanel_SaveBtn.BackColor = Color.White;
      this.PreferencesPanel_SaveBtn.BtnColor = PushButtonColorEnum.BlueGrey;
      this.PreferencesPanel_SaveBtn.BtnDoubleEndCaps = false;
      this.PreferencesPanel_SaveBtn.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.PreferencesPanel_SaveBtn, "PreferencesPanel_SaveBtn");
      this.PreferencesPanel_SaveBtn.Name = "PreferencesPanel_SaveBtn";
      this.PreferencesPanel_CancelBtn.BackColor = Color.White;
      this.PreferencesPanel_CancelBtn.BtnColor = PushButtonColorEnum.BlueGrey;
      this.PreferencesPanel_CancelBtn.BtnDoubleEndCaps = false;
      this.PreferencesPanel_CancelBtn.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.PreferencesPanel_CancelBtn, "PreferencesPanel_CancelBtn");
      this.PreferencesPanel_CancelBtn.Name = "PreferencesPanel_CancelBtn";
      this.PreferencesPanel_HeaderLbl.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.PreferencesPanel_HeaderLbl, "PreferencesPanel_HeaderLbl");
      this.PreferencesPanel_HeaderLbl.Name = "PreferencesPanel_HeaderLbl";
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.PreferencesPanel_HeaderLbl);
      this.Controls.Add((Control) this.PreferencesPanel_HelpButtonLabelPair);
      this.Controls.Add((Control) this.PreferencesPanel_TabControl);
      this.Controls.Add((Control) this.PreferencesPanel_SaveCancelBtnBox);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "PreferencesPanel";
      this.PreferencesPanel_ApplicationTabPage.ResumeLayout(false);
      this.PreferencesPanel_TaskbarTabPage.ResumeLayout(false);
      this.PreferencesPanel_SaveCancelBtnBox.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public void InitPanel()
    {
      this.PreferencesPanel_SaveBtn.BtnEnabled = false;
      this.PreferencesPanel_ApplicationTabPanel.InitPanel();
      this.PreferencesPanel_TaskbarTabPanel.InitPanel();
      this.PreferencesPanel_TabControl.SelectedTab = this.PreferencesPanel_ApplicationTabPage;
      this.ActiveControl = (Control) this.PreferencesPanel_TabControl;
      this.PreferencesPanel_TabControl.Focus();
    }

    public void CleanUp()
    {
      this.PreferencesPanel_ApplicationTabPanel.CleanUp();
      this.PreferencesPanel_TaskbarTabPanel.CleanUp();
    }

    public void LaunchHelp()
    {
      if (this.PreferencesPanel_TabControl.SelectedTab == this.PreferencesPanel_ApplicationTabPage)
        OnlineHelp.LaunchHelp("/prefernc.htm#application");
      else if (this.PreferencesPanel_TabControl.SelectedTab == this.PreferencesPanel_TaskbarTabPage)
        OnlineHelp.LaunchHelp("/prefernc.htm#taskbar");
      else
        OnlineHelp.LaunchHelp((string) null);
    }

    private void OnSaveBtnPressed(object sender, EventArgs e)
    {
      if (!this.SaveChanges())
        return;
      PreferencesDialog.Singleton.Close();
    }

    private void OnCancelBtnPressed(object sender, EventArgs e)
    {
      PreferencesDialog.Singleton.Close();
    }

    private void OnHelpButtonPressed(object sender, MouseEventArgs e)
    {
      if (MouseHelper.IgnoreMouseClick(e, (Control) sender, ((Control) sender).Enabled))
        return;
      this.LaunchHelp();
    }

    public void UserMadeChange()
    {
      this.PreferencesPanel_SaveBtn.BtnEnabled = true;
    }

    private void CustomInitializeComponents()
    {
      this.AccessibleName = "PreferencesPanel";
      this.PreferencesPanel_ApplicationTabPage.AccessibleName = "PreferencesPanel_ApplicationTabPage";
      this.PreferencesPanel_ApplicationTabPanel.AccessibleName = "PreferencesPanel_ApplicationTabPanel";
      this.PreferencesPanel_CancelBtn.AccessibleName = "PreferencesPanel_CancelBtn";
      this.PreferencesPanel_HeaderLbl.AccessibleName = "PreferencesPanel_HeaderLbl";
      this.PreferencesPanel_HelpButtonLabelPair.AccessibleName = "PreferencesPanel_HelpButtonLabelPair";
      this.PreferencesPanel_SaveBtn.AccessibleName = "PreferencesPanel_SaveBtn";
      this.PreferencesPanel_SaveCancelBtnBox.AccessibleName = "PreferencesPanel_SaveCancelBtnBox";
      this.PreferencesPanel_TabControl.AccessibleName = "PreferencesPanel_TabControl";
      this.PreferencesPanel_TaskbarTabPage.AccessibleName = "PreferencesPanel_TaskbarTabPage";
      this.PreferencesPanel_TaskbarTabPanel.AccessibleName = "PreferencesPanel_TaskbarTabPanel";
      this.PreferencesPanel_HeaderLbl.Text = PreferencesDlgStringHelper.GetString("PreferencesPanel_HeaderLbl");
      this.PreferencesPanel_CancelBtn.BtnText = PreferencesDlgStringHelper.GetString("PreferencesPanel_CancelBtn");
      this.PreferencesPanel_SaveBtn.BtnText = PreferencesDlgStringHelper.GetString("PreferencesPanel_SaveBtn");
      this.PreferencesPanel_ApplicationTabPage.Text = PreferencesDlgStringHelper.GetString("PreferencesPanel_ApplicationTabPage");
      this.PreferencesPanel_TaskbarTabPage.Text = PreferencesDlgStringHelper.GetString("PreferencesPanel_TaskbarTabPage");
      this.PreferencesPanel_TabControl.AddTabPage(this.PreferencesPanel_ApplicationTabPage);
      this.PreferencesPanel_TabControl.AddTabPage(this.PreferencesPanel_TaskbarTabPage);
      this.PreferencesPanel_SaveBtn.Pressed += new CustomButtonPush.PressedDelegate(this.OnSaveBtnPressed);
      this.PreferencesPanel_CancelBtn.Pressed += new CustomButtonPush.PressedDelegate(this.OnCancelBtnPressed);
      this.PreferencesPanel_HelpButtonLabelPair.HelpBtnPressed += new CustomHelpButtonLabelPair.HelpBtnPressedDelegate(this.OnHelpButtonPressed);
      SizeHelper.ResizeCustomControls(this.Controls);
      this.PreferencesPanel_ApplicationTabPanel.ParentPanel = this;
      this.PreferencesPanel_TaskbarTabPanel.ParentPanel = this;
    }

    private bool SaveChanges()
    {
      this.Cursor = Cursors.WaitCursor;
      if (!this.PreferencesPanel_ApplicationTabPanel.SaveChanges())
      {
        this.Cursor = Cursors.Default;
        return false;
      }
      else if (!this.PreferencesPanel_TaskbarTabPanel.SaveChanges())
      {
        this.Cursor = Cursors.Default;
        return false;
      }
      else
      {
        this.Cursor = Cursors.Default;
        return true;
      }
    }
  }
}
