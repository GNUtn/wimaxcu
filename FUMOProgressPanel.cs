// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.FUMOProgressPanel
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
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class FUMOProgressPanel : UserControl
  {
    private IContainer components;
    private CustomProgressBar FUMOProgressPanel_ProgressBar;
    private CustomHelpButtonLabelPair FUMOProgressPanel_HelpButtonLabelPair;
    private Label FUMOProgressPanel_HeaderLbl;
    private CustomButtonPushHorizBox FUMOProgressPanel_CloseBtnBox;
    private CustomButtonPush FUMOProgressPanel_CloseBtn;
    private CustomLabelSeparator FUMOProgressPanel_ButtonBarSeperator;
    private Label FUMOProgressPanel_InstructionsLbl;
    private Label FUMOProgressPanel_DownloadProgressLbl;
    private CustomButtonPushHorizBox FUMOProgressPanel_StopDownloadBtnBox;
    private CustomButtonPush FUMOProgressPanel_StopDownloadBtn;
    private Label FUMOProgressPanel_DownloadBeingStoppedLbl;
    private int _percentComplete;

    public FUMOProgressPanel()
    {
      this.InitializeComponent();
      this.CustomInitializeComponents();
      this.RegisterForEvents();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FUMOProgressPanel));
      this.FUMOProgressPanel_ProgressBar = new CustomProgressBar();
      this.FUMOProgressPanel_HelpButtonLabelPair = new CustomHelpButtonLabelPair();
      this.FUMOProgressPanel_HeaderLbl = new Label();
      this.FUMOProgressPanel_CloseBtnBox = new CustomButtonPushHorizBox();
      this.FUMOProgressPanel_CloseBtn = new CustomButtonPush();
      this.FUMOProgressPanel_ButtonBarSeperator = new CustomLabelSeparator();
      this.FUMOProgressPanel_InstructionsLbl = new Label();
      this.FUMOProgressPanel_DownloadProgressLbl = new Label();
      this.FUMOProgressPanel_StopDownloadBtnBox = new CustomButtonPushHorizBox();
      this.FUMOProgressPanel_StopDownloadBtn = new CustomButtonPush();
      this.FUMOProgressPanel_DownloadBeingStoppedLbl = new Label();
      this.FUMOProgressPanel_CloseBtnBox.SuspendLayout();
      this.FUMOProgressPanel_StopDownloadBtnBox.SuspendLayout();
      this.SuspendLayout();
      this.FUMOProgressPanel_ProgressBar.BackColor = Color.FromArgb(204, 204, 204);
      componentResourceManager.ApplyResources((object) this.FUMOProgressPanel_ProgressBar, "FUMOProgressPanel_ProgressBar");
      this.FUMOProgressPanel_ProgressBar.ForeColor = Color.FromArgb(32, 87, 143);
      this.FUMOProgressPanel_ProgressBar.Name = "FUMOProgressPanel_ProgressBar";
      this.FUMOProgressPanel_ProgressBar.TabStop = false;
      this.FUMOProgressPanel_ProgressBar.Value = 0;
      this.FUMOProgressPanel_HelpButtonLabelPair.AccessibleRole = AccessibleRole.None;
      this.FUMOProgressPanel_HelpButtonLabelPair.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.FUMOProgressPanel_HelpButtonLabelPair, "FUMOProgressPanel_HelpButtonLabelPair");
      this.FUMOProgressPanel_HelpButtonLabelPair.Name = "FUMOProgressPanel_HelpButtonLabelPair";
      this.FUMOProgressPanel_HeaderLbl.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.FUMOProgressPanel_HeaderLbl, "FUMOProgressPanel_HeaderLbl");
      this.FUMOProgressPanel_HeaderLbl.Name = "FUMOProgressPanel_HeaderLbl";
      this.FUMOProgressPanel_CloseBtnBox.Controls.Add((Control) this.FUMOProgressPanel_CloseBtn);
      componentResourceManager.ApplyResources((object) this.FUMOProgressPanel_CloseBtnBox, "FUMOProgressPanel_CloseBtnBox");
      this.FUMOProgressPanel_CloseBtnBox.HorizontalJustification = HorizontalJustificationEnum.Right;
      this.FUMOProgressPanel_CloseBtnBox.Name = "FUMOProgressPanel_CloseBtnBox";
      this.FUMOProgressPanel_CloseBtn.BackColor = Color.White;
      this.FUMOProgressPanel_CloseBtn.BtnColor = PushButtonColorEnum.BlueGrey;
      this.FUMOProgressPanel_CloseBtn.BtnDoubleEndCaps = false;
      this.FUMOProgressPanel_CloseBtn.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.FUMOProgressPanel_CloseBtn, "FUMOProgressPanel_CloseBtn");
      this.FUMOProgressPanel_CloseBtn.Name = "FUMOProgressPanel_CloseBtn";
      this.FUMOProgressPanel_ButtonBarSeperator.BackColor = Color.White;
      componentResourceManager.ApplyResources((object) this.FUMOProgressPanel_ButtonBarSeperator, "FUMOProgressPanel_ButtonBarSeperator");
      this.FUMOProgressPanel_ButtonBarSeperator.Name = "FUMOProgressPanel_ButtonBarSeperator";
      this.FUMOProgressPanel_ButtonBarSeperator.TabStop = false;
      this.FUMOProgressPanel_InstructionsLbl.AccessibleRole = AccessibleRole.None;
      componentResourceManager.ApplyResources((object) this.FUMOProgressPanel_InstructionsLbl, "FUMOProgressPanel_InstructionsLbl");
      this.FUMOProgressPanel_InstructionsLbl.Name = "FUMOProgressPanel_InstructionsLbl";
      componentResourceManager.ApplyResources((object) this.FUMOProgressPanel_DownloadProgressLbl, "FUMOProgressPanel_DownloadProgressLbl");
      this.FUMOProgressPanel_DownloadProgressLbl.Name = "FUMOProgressPanel_DownloadProgressLbl";
      this.FUMOProgressPanel_StopDownloadBtnBox.Controls.Add((Control) this.FUMOProgressPanel_StopDownloadBtn);
      componentResourceManager.ApplyResources((object) this.FUMOProgressPanel_StopDownloadBtnBox, "FUMOProgressPanel_StopDownloadBtnBox");
      this.FUMOProgressPanel_StopDownloadBtnBox.HorizontalJustification = HorizontalJustificationEnum.Right;
      this.FUMOProgressPanel_StopDownloadBtnBox.Name = "FUMOProgressPanel_StopDownloadBtnBox";
      this.FUMOProgressPanel_StopDownloadBtn.BackColor = Color.White;
      this.FUMOProgressPanel_StopDownloadBtn.BtnColor = PushButtonColorEnum.BlueGrey;
      this.FUMOProgressPanel_StopDownloadBtn.BtnDoubleEndCaps = false;
      this.FUMOProgressPanel_StopDownloadBtn.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.FUMOProgressPanel_StopDownloadBtn, "FUMOProgressPanel_StopDownloadBtn");
      this.FUMOProgressPanel_StopDownloadBtn.Name = "FUMOProgressPanel_StopDownloadBtn";
      componentResourceManager.ApplyResources((object) this.FUMOProgressPanel_DownloadBeingStoppedLbl, "FUMOProgressPanel_DownloadBeingStoppedLbl");
      this.FUMOProgressPanel_DownloadBeingStoppedLbl.Name = "FUMOProgressPanel_DownloadBeingStoppedLbl";
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.FUMOProgressPanel_StopDownloadBtnBox);
      this.Controls.Add((Control) this.FUMOProgressPanel_DownloadProgressLbl);
      this.Controls.Add((Control) this.FUMOProgressPanel_InstructionsLbl);
      this.Controls.Add((Control) this.FUMOProgressPanel_CloseBtnBox);
      this.Controls.Add((Control) this.FUMOProgressPanel_ButtonBarSeperator);
      this.Controls.Add((Control) this.FUMOProgressPanel_HelpButtonLabelPair);
      this.Controls.Add((Control) this.FUMOProgressPanel_HeaderLbl);
      this.Controls.Add((Control) this.FUMOProgressPanel_ProgressBar);
      this.Controls.Add((Control) this.FUMOProgressPanel_DownloadBeingStoppedLbl);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "FUMOProgressPanel";
      this.FUMOProgressPanel_CloseBtnBox.ResumeLayout(false);
      this.FUMOProgressPanel_StopDownloadBtnBox.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public void InitPanel()
    {
      this.UpdateUI();
      this.ActiveControl = (Control) this.FUMOProgressPanel_CloseBtn;
      this.FUMOProgressPanel_CloseBtn.Focus();
    }

    public void CleanUp()
    {
    }

    public void LaunchHelp()
    {
      OnlineHelp.LaunchHelp("/wimaxupdates.htm");
    }

    private void OnStopDownloadBtnPressed(object sender, EventArgs e)
    {
      Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user pressed the 'Stop Download' button.");
      if (APDOHandler.Singleton.StopPackageUpdate() != 0)
        ErrorHelper.ShowErrorDialog((Control) this, ErrorStringsHelper.GetString("General_StopDownloadFailed"), "", (string) null, "StopDownloadFailed");
      else
        this.UpdateUI();
    }

    private void OnCloseBtnPressed(object sender, EventArgs e)
    {
      FUMOProgressDialog.Singleton.Close();
    }

    private void OnHelpButtonPressed(object sender, MouseEventArgs e)
    {
      if (MouseHelper.IgnoreMouseClick(e, (Control) sender, ((Control) sender).Enabled))
        return;
      this.LaunchHelp();
    }

    public void OnAPDO(object sender, object[] eventArgs)
    {
      if (eventArgs == null || eventArgs.Length == 0)
        return;
      switch ((APDOEventType) eventArgs[0])
      {
        case APDOEventType.PackageUpdateReceived:
        case APDOEventType.PackageUpdateReceivedFullStack:
        case APDOEventType.PackageUpdateReceivedLowerStack:
        case APDOEventType.PackageUpdateReceivedOmaDmClient:
          this._percentComplete = 0;
          this.UpdateUI();
          break;
        case APDOEventType.PackageDownloadProgress:
          this._percentComplete = (int) eventArgs[1];
          this.UpdateUI();
          break;
      }
    }

    private void CustomInitializeComponents()
    {
      this.AccessibleName = "FUMOProgressPanel";
      this.FUMOProgressPanel_HeaderLbl.AccessibleName = "FUMOProgressPanel_HeaderLbl";
      this.FUMOProgressPanel_CloseBtn.AccessibleName = "FUMOProgressPanel_CloseBtn";
      this.FUMOProgressPanel_ButtonBarSeperator.AccessibleName = "FUMOProgressPanel_ButtonBarSeperator";
      this.FUMOProgressPanel_CloseBtnBox.AccessibleName = "FUMOProgressPanel_CloseBtnBox";
      this.FUMOProgressPanel_HelpButtonLabelPair.AccessibleName = "FUMOProgressPanel_HelpButtonLabelPair";
      this.FUMOProgressPanel_DownloadProgressLbl.AccessibleName = "FUMOProgressPanel_DownloadProgressLbl";
      this.FUMOProgressPanel_InstructionsLbl.AccessibleName = "FUMOProgressPanel_InstructionsLbl";
      this.FUMOProgressPanel_StopDownloadBtn.AccessibleName = "FUMOProgressPanel_StopDownloadBtn";
      this.FUMOProgressPanel_StopDownloadBtnBox.AccessibleName = "FUMOProgressPanel_StopDownloadBtnBox";
      this.FUMOProgressPanel_ProgressBar.AccessibleName = "FUMOProgressPanel_ProgressBar";
      this.FUMOProgressPanel_DownloadBeingStoppedLbl.AccessibleName = "FUMOProgressPanel_DownloadBeingStoppedLbl";
      this.FUMOProgressPanel_HeaderLbl.Text = FUMOProgressDlgStringHelper.GetString("FUMOProgressPanel_HeaderLbl");
      this.FUMOProgressPanel_CloseBtn.BtnText = FUMOProgressDlgStringHelper.GetString("FUMOProgressPanel_CloseBtn");
      this.FUMOProgressPanel_DownloadProgressLbl.Text = FUMOProgressDlgStringHelper.GetString("FUMOProgressPanel_DownloadProgressLbl");
      this.FUMOProgressPanel_InstructionsLbl.Text = FUMOProgressDlgStringHelper.GetString("FUMOProgressPanel_InstructionsLbl");
      this.FUMOProgressPanel_StopDownloadBtn.BtnText = FUMOProgressDlgStringHelper.GetString("FUMOProgressPanel_StopDownloadBtn");
      this.FUMOProgressPanel_DownloadBeingStoppedLbl.Text = FUMOProgressDlgStringHelper.GetString("FUMOProgressPanel_DownloadBeingStoppedLbl");
      this.FUMOProgressPanel_ButtonBarSeperator.Text = DashboardStringHelper.GetString("Empty");
      this.FUMOProgressPanel_CloseBtn.Pressed += new CustomButtonPush.PressedDelegate(this.OnCloseBtnPressed);
      this.FUMOProgressPanel_StopDownloadBtn.Pressed += new CustomButtonPush.PressedDelegate(this.OnStopDownloadBtnPressed);
      this.FUMOProgressPanel_HelpButtonLabelPair.HelpBtnPressed += new CustomHelpButtonLabelPair.HelpBtnPressedDelegate(this.OnHelpButtonPressed);
      SizeHelper.ResizeCustomControls(this.Controls);
    }

    private void RegisterForEvents()
    {
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnAPDO), (object) this, "WiMAXSP.OnAPDO");
    }

    private void UnregisterForEvents()
    {
      Eventing.DeRegisterAllUIEvents((object) this);
    }

    private void UpdateUI()
    {
      if (APDOHandler.FUMODownloadState == FumoDownloadStateEnum.StoppingDownload)
      {
        this.FUMOProgressPanel_DownloadBeingStoppedLbl.Visible = true;
        this.FUMOProgressPanel_InstructionsLbl.Visible = false;
        this.FUMOProgressPanel_ProgressBar.Visible = false;
        this.FUMOProgressPanel_StopDownloadBtn.Visible = false;
        this.FUMOProgressPanel_StopDownloadBtnBox.Visible = false;
      }
      else
      {
        this.FUMOProgressPanel_DownloadBeingStoppedLbl.Visible = false;
        this.FUMOProgressPanel_InstructionsLbl.Visible = true;
        this.FUMOProgressPanel_ProgressBar.Visible = true;
        this.FUMOProgressPanel_StopDownloadBtn.Visible = true;
        this.FUMOProgressPanel_StopDownloadBtnBox.Visible = true;
        this.FUMOProgressPanel_ProgressBar.Value = this._percentComplete;
      }
    }
  }
}
