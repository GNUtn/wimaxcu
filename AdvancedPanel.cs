// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.AdvancedPanel
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
  public class AdvancedPanel : UserControl
  {
    private Container components;
    private AdvancedDialog _parentDialog;
    private CustomHelpButtonLabelPair AdvancedPanel_HelpButtonLabelPair;
    private CustomButtonPushHorizBox AdvancedPanel_CloseBtnBox;
    private CustomButtonPush AdvancedPanel_CloseBtn;
    private CustomTabControl AdvancedPanel_TabControl;
    private TabPage AdvancedPanel_SettingsTabPage;
    private Label AdvancedPanel_HeaderLbl;
    private AdapterTabPanel AdvandedPanel_AdapterTabPanel;
    private SettingsTabPanel AdvandedPanel_SettingsTabPanel;
    private TabPage AdvancedPanel_AdapterTabPage;
    private bool _blocked;

    public bool Blocked
    {
      get
      {
        return this._blocked;
      }
      set
      {
        this._blocked = value;
      }
    }

    public AdvancedPanel(AdvancedDialog parentDialog)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AdvancedPanel));
      this.AdvancedPanel_HelpButtonLabelPair = new CustomHelpButtonLabelPair();
      this.AdvancedPanel_CloseBtnBox = new CustomButtonPushHorizBox();
      this.AdvancedPanel_CloseBtn = new CustomButtonPush();
      this.AdvancedPanel_TabControl = new CustomTabControl();
      this.AdvancedPanel_AdapterTabPage = new TabPage();
      this.AdvandedPanel_AdapterTabPanel = new AdapterTabPanel();
      this.AdvancedPanel_SettingsTabPage = new TabPage();
      this.AdvandedPanel_SettingsTabPanel = new SettingsTabPanel();
      this.AdvancedPanel_HeaderLbl = new Label();
      this.AdvancedPanel_CloseBtnBox.SuspendLayout();
      this.AdvancedPanel_AdapterTabPage.SuspendLayout();
      this.AdvancedPanel_SettingsTabPage.SuspendLayout();
      this.SuspendLayout();
      this.AdvancedPanel_HelpButtonLabelPair.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.AdvancedPanel_HelpButtonLabelPair, "AdvancedPanel_HelpButtonLabelPair");
      this.AdvancedPanel_HelpButtonLabelPair.Name = "AdvancedPanel_HelpButtonLabelPair";
      this.AdvancedPanel_CloseBtnBox.Controls.Add((Control) this.AdvancedPanel_CloseBtn);
      componentResourceManager.ApplyResources((object) this.AdvancedPanel_CloseBtnBox, "AdvancedPanel_CloseBtnBox");
      this.AdvancedPanel_CloseBtnBox.HorizontalJustification = HorizontalJustificationEnum.Right;
      this.AdvancedPanel_CloseBtnBox.Name = "AdvancedPanel_CloseBtnBox";
      this.AdvancedPanel_CloseBtn.BackColor = Color.White;
      this.AdvancedPanel_CloseBtn.BtnColor = PushButtonColorEnum.BlueGrey;
      this.AdvancedPanel_CloseBtn.BtnDoubleEndCaps = false;
      this.AdvancedPanel_CloseBtn.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.AdvancedPanel_CloseBtn, "AdvancedPanel_CloseBtn");
      this.AdvancedPanel_CloseBtn.Name = "AdvancedPanel_CloseBtn";
      componentResourceManager.ApplyResources((object) this.AdvancedPanel_TabControl, "AdvancedPanel_TabControl");
      this.AdvancedPanel_TabControl.Name = "AdvancedPanel_TabControl";
      this.AdvancedPanel_TabControl.SelectedIndex = 0;
      this.AdvancedPanel_AdapterTabPage.BackColor = Color.White;
      this.AdvancedPanel_AdapterTabPage.Controls.Add((Control) this.AdvandedPanel_AdapterTabPanel);
      componentResourceManager.ApplyResources((object) this.AdvancedPanel_AdapterTabPage, "AdvancedPanel_AdapterTabPage");
      this.AdvancedPanel_AdapterTabPage.Name = "AdvancedPanel_AdapterTabPage";
      this.AdvancedPanel_AdapterTabPage.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.AdvandedPanel_AdapterTabPanel, "AdvandedPanel_AdapterTabPanel");
      this.AdvandedPanel_AdapterTabPanel.BackColor = Color.White;
      this.AdvandedPanel_AdapterTabPanel.Name = "AdvandedPanel_AdapterTabPanel";
      this.AdvandedPanel_AdapterTabPanel.ParentPanel = (AdvancedPanel) null;
      this.AdvancedPanel_SettingsTabPage.BackColor = Color.White;
      this.AdvancedPanel_SettingsTabPage.Controls.Add((Control) this.AdvandedPanel_SettingsTabPanel);
      componentResourceManager.ApplyResources((object) this.AdvancedPanel_SettingsTabPage, "AdvancedPanel_SettingsTabPage");
      this.AdvancedPanel_SettingsTabPage.Name = "AdvancedPanel_SettingsTabPage";
      this.AdvancedPanel_SettingsTabPage.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.AdvandedPanel_SettingsTabPanel, "AdvandedPanel_SettingsTabPanel");
      this.AdvandedPanel_SettingsTabPanel.BackColor = Color.White;
      this.AdvandedPanel_SettingsTabPanel.Name = "AdvandedPanel_SettingsTabPanel";
      this.AdvandedPanel_SettingsTabPanel.ParentPanel = (AdvancedPanel) null;
      this.AdvancedPanel_HeaderLbl.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.AdvancedPanel_HeaderLbl, "AdvancedPanel_HeaderLbl");
      this.AdvancedPanel_HeaderLbl.Name = "AdvancedPanel_HeaderLbl";
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.AdvancedPanel_HeaderLbl);
      this.Controls.Add((Control) this.AdvancedPanel_TabControl);
      this.Controls.Add((Control) this.AdvancedPanel_HelpButtonLabelPair);
      this.Controls.Add((Control) this.AdvancedPanel_CloseBtnBox);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "AdvancedPanel";
      this.AdvancedPanel_CloseBtnBox.ResumeLayout(false);
      this.AdvancedPanel_AdapterTabPage.ResumeLayout(false);
      this.AdvancedPanel_SettingsTabPage.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public void InitPanel()
    {
      this.AdvandedPanel_AdapterTabPanel.InitPanel();
      this.AdvandedPanel_SettingsTabPanel.InitPanel();
      this.AdvancedPanel_TabControl.SelectedTab = this.AdvancedPanel_AdapterTabPage;
      this.ActiveControl = (Control) this.AdvancedPanel_TabControl;
      this.AdvancedPanel_TabControl.Focus();
    }

    public void CleanUp()
    {
      this.AdvandedPanel_AdapterTabPanel.CleanUp();
      this.AdvandedPanel_SettingsTabPanel.CleanUp();
    }

    public void LaunchHelp()
    {
      if (this.AdvancedPanel_TabControl.SelectedTab == this.AdvancedPanel_AdapterTabPage)
        OnlineHelp.LaunchHelp("/advanced.htm#adapter");
      else if (this.AdvancedPanel_TabControl.SelectedTab == this.AdvancedPanel_SettingsTabPage)
        OnlineHelp.LaunchHelp("/advanced.htm#settings");
      else
        OnlineHelp.LaunchHelp((string) null);
    }

    public void Block()
    {
      this._blocked = true;
      this.AdvandedPanel_AdapterTabPanel.UpdateButtonState();
      this.AdvandedPanel_SettingsTabPanel.UpdateUI(false);
      this.AdvancedPanel_CloseBtn.BtnEnabled = false;
    }

    public void Unblock()
    {
      this._blocked = false;
      this.AdvandedPanel_AdapterTabPanel.UpdateButtonState();
      this.AdvandedPanel_SettingsTabPanel.UpdateUI(false);
      this.AdvancedPanel_CloseBtn.BtnEnabled = true;
    }

    private void OnCloseBtnPressed(object sender, EventArgs e)
    {
      AdvancedDialog.Singleton.Close();
    }

    private void OnHelpButtonPressed(object sender, MouseEventArgs e)
    {
      if (MouseHelper.IgnoreMouseClick(e, (Control) sender, ((Control) sender).Enabled))
        return;
      this.LaunchHelp();
    }

    private void CustomInitializeComponents()
    {
      this.AccessibleName = "AdvancedPanel";
      this.AdvancedPanel_AdapterTabPage.AccessibleName = "AdvancedPanel_AdapterTabPage";
      this.AdvancedPanel_CloseBtn.AccessibleName = "AdvancedPanel_CloseBtn";
      this.AdvancedPanel_CloseBtnBox.AccessibleName = "AdvancedPanel_CloseBtnBox";
      this.AdvancedPanel_HeaderLbl.AccessibleName = "AdvancedPanel_HeaderLbl";
      this.AdvancedPanel_HelpButtonLabelPair.AccessibleName = "AdvancedPanel_HelpButtonLabelPair";
      this.AdvancedPanel_TabControl.AccessibleName = "AdvancedPanel_TabControl";
      this.AdvancedPanel_SettingsTabPage.AccessibleName = "AdvancedPanel_SettingsTabPage";
      this.AdvandedPanel_AdapterTabPanel.AccessibleName = "AdvandedPanel_AdapterTabPanel";
      this.AdvandedPanel_SettingsTabPanel.AccessibleName = "AdvandedPanel_SettingsTabPanel";
      this.AdvancedPanel_CloseBtn.BtnText = AdvancedDlgStringHelper.GetString("AdvancedPanel_CloseBtn");
      this.AdvancedPanel_AdapterTabPage.Text = AdvancedDlgStringHelper.GetString("AdvancedPanel_AdapterTabPage");
      this.AdvancedPanel_SettingsTabPage.Text = AdvancedDlgStringHelper.GetString("AdvancedPanel_SettingsTabPage");
      this.AdvancedPanel_HeaderLbl.Text = AdvancedDlgStringHelper.GetString("AdvancedPanel_HeaderLbl");
      this.AdvancedPanel_TabControl.AddTabPage(this.AdvancedPanel_AdapterTabPage);
      this.AdvancedPanel_TabControl.AddTabPage(this.AdvancedPanel_SettingsTabPage);
      this.AdvancedPanel_CloseBtn.Pressed += new CustomButtonPush.PressedDelegate(this.OnCloseBtnPressed);
      this.AdvancedPanel_HelpButtonLabelPair.HelpBtnPressed += new CustomHelpButtonLabelPair.HelpBtnPressedDelegate(this.OnHelpButtonPressed);
      SizeHelper.ResizeCustomControls(this.Controls);
      this.AdvandedPanel_AdapterTabPanel.ParentPanel = this;
      this.AdvandedPanel_SettingsTabPanel.ParentPanel = this;
    }
  }
}
