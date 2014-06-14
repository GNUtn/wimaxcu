// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.ErrorPanel
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class ErrorPanel : UserControl
  {
    private TextBox ErrorPanel_DetailsTxtBox;
    private Label ErrorPanel_DetailsTxtBoxLbl;
    private CustomButtonPushHorizBox ErrorPanel_OkBtnBox;
    private CustomButtonPush ErrorPanel_OkBtn;
    private PictureBox ErrorPanel_ProblemImage;
    private CustomLabelSeparator ErrorPanel_TopButtonBarSeperator;
    private CustomLabelSeparator ErrorPanel_BottomButtonBarSeperator;
    private Container components;
    private ErrorDialog _parentDialog;
    private string _helpTopic;
    private Point _origProblemImageLocation;
    private CustomHelpButtonLabelPair ErrorPanel_HelpButtonLabelPair;
    private Point _origErrorMsgLblLocation;
    private TextPanel _textPanel;

    public ErrorPanel(ErrorDialog parentDialog, string errorMessage, string details, string helpTopic)
    {
      this._parentDialog = parentDialog;
      this._helpTopic = helpTopic;
      if (this._textPanel == null)
      {
        this._textPanel = new TextPanel();
        this._textPanel.Location = new Point(74, 30);
        this._textPanel.Size = new Size(261, 72);
        this._textPanel.TabStop = false;
        this.Controls.Add((Control) this._textPanel);
      }
      this.InitializeComponent();
      this._origProblemImageLocation = this.ErrorPanel_ProblemImage.Location;
      this._origErrorMsgLblLocation = this._textPanel.Location;
      this.CustomInitializeComponents(errorMessage, details);
      this.ErrorPanel_ProblemImage.Image = (Image) ScalingUtils.ScaleBitmap(this.ErrorPanel_ProblemImage.Image);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ErrorPanel));
      this.ErrorPanel_DetailsTxtBox = new TextBox();
      this.ErrorPanel_DetailsTxtBoxLbl = new Label();
      this.ErrorPanel_OkBtnBox = new CustomButtonPushHorizBox();
      this.ErrorPanel_OkBtn = new CustomButtonPush();
      this.ErrorPanel_ProblemImage = new PictureBox();
      this.ErrorPanel_TopButtonBarSeperator = new CustomLabelSeparator();
      this.ErrorPanel_BottomButtonBarSeperator = new CustomLabelSeparator();
      this.ErrorPanel_HelpButtonLabelPair = new CustomHelpButtonLabelPair();
      this.ErrorPanel_OkBtnBox.SuspendLayout();
      this.ErrorPanel_ProblemImage.BeginInit();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.ErrorPanel_DetailsTxtBox, "ErrorPanel_DetailsTxtBox");
      this.ErrorPanel_DetailsTxtBox.Name = "ErrorPanel_DetailsTxtBox";
      this.ErrorPanel_DetailsTxtBox.ReadOnly = true;
      this.ErrorPanel_DetailsTxtBox.TabStop = false;
      componentResourceManager.ApplyResources((object) this.ErrorPanel_DetailsTxtBoxLbl, "ErrorPanel_DetailsTxtBoxLbl");
      this.ErrorPanel_DetailsTxtBoxLbl.Name = "ErrorPanel_DetailsTxtBoxLbl";
      this.ErrorPanel_OkBtnBox.Controls.Add((Control) this.ErrorPanel_OkBtn);
      componentResourceManager.ApplyResources((object) this.ErrorPanel_OkBtnBox, "ErrorPanel_OkBtnBox");
      this.ErrorPanel_OkBtnBox.HorizontalJustification = HorizontalJustificationEnum.Right;
      this.ErrorPanel_OkBtnBox.Name = "ErrorPanel_OkBtnBox";
      this.ErrorPanel_OkBtn.BackColor = Color.White;
      this.ErrorPanel_OkBtn.BtnColor = PushButtonColorEnum.BlueGrey;
      this.ErrorPanel_OkBtn.BtnDoubleEndCaps = false;
      this.ErrorPanel_OkBtn.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.ErrorPanel_OkBtn, "ErrorPanel_OkBtn");
      this.ErrorPanel_OkBtn.Name = "ErrorPanel_OkBtn";
      this.ErrorPanel_ProblemImage.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.ErrorPanel_ProblemImage, "ErrorPanel_ProblemImage");
      this.ErrorPanel_ProblemImage.Name = "ErrorPanel_ProblemImage";
      this.ErrorPanel_ProblemImage.TabStop = false;
      this.ErrorPanel_TopButtonBarSeperator.BackColor = Color.White;
      componentResourceManager.ApplyResources((object) this.ErrorPanel_TopButtonBarSeperator, "ErrorPanel_TopButtonBarSeperator");
      this.ErrorPanel_TopButtonBarSeperator.Name = "ErrorPanel_TopButtonBarSeperator";
      this.ErrorPanel_TopButtonBarSeperator.TabStop = false;
      this.ErrorPanel_BottomButtonBarSeperator.BackColor = Color.White;
      componentResourceManager.ApplyResources((object) this.ErrorPanel_BottomButtonBarSeperator, "ErrorPanel_BottomButtonBarSeperator");
      this.ErrorPanel_BottomButtonBarSeperator.Name = "ErrorPanel_BottomButtonBarSeperator";
      this.ErrorPanel_BottomButtonBarSeperator.TabStop = false;
      this.ErrorPanel_HelpButtonLabelPair.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.ErrorPanel_HelpButtonLabelPair, "ErrorPanel_HelpButtonLabelPair");
      this.ErrorPanel_HelpButtonLabelPair.Name = "ErrorPanel_HelpButtonLabelPair";
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.ErrorPanel_HelpButtonLabelPair);
      this.Controls.Add((Control) this.ErrorPanel_BottomButtonBarSeperator);
      this.Controls.Add((Control) this.ErrorPanel_TopButtonBarSeperator);
      this.Controls.Add((Control) this.ErrorPanel_ProblemImage);
      this.Controls.Add((Control) this.ErrorPanel_OkBtnBox);
      this.Controls.Add((Control) this.ErrorPanel_DetailsTxtBoxLbl);
      this.Controls.Add((Control) this.ErrorPanel_DetailsTxtBox);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "ErrorPanel";
      this.ErrorPanel_OkBtnBox.ResumeLayout(false);
      this.ErrorPanel_ProblemImage.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public void InitPanel()
    {
      this.UpdatePanel();
      this.ActiveControl = (Control) this.ErrorPanel_OkBtn;
      this.ErrorPanel_OkBtn.Focus();
    }

    public void LaunchHelp()
    {
      if (this.ErrorPanel_HelpButtonLabelPair == null || string.IsNullOrEmpty(this._helpTopic))
        return;
      OnlineHelp.LaunchHelp(this._helpTopic);
    }

    private void OnOkBtnPressed(object sender, EventArgs e)
    {
      this._parentDialog.Close();
    }

    private void OnHelpButtonPressed(object sender, MouseEventArgs e)
    {
      if (MouseHelper.IgnoreMouseClick(e, (Control) sender, ((Control) sender).Enabled))
        return;
      this.LaunchHelp();
    }

    private void CustomInitializeComponents(string errorMessage, string details)
    {
      this.ErrorPanel_DetailsTxtBoxLbl.Text = ErrorDlgStringHelper.GetString("ErrorPanel_DetailsTxtBoxLbl");
      this.ErrorPanel_OkBtn.BtnText = ErrorDlgStringHelper.GetString("ErrorPanel_OkBtn");
      this.ErrorPanel_BottomButtonBarSeperator.Text = string.Empty;
      this.ErrorPanel_TopButtonBarSeperator.Text = string.Empty;
      this.ErrorPanel_OkBtn.Pressed += new CustomButtonPush.PressedDelegate(this.OnOkBtnPressed);
      this.ErrorPanel_HelpButtonLabelPair.HelpBtnPressed += new CustomHelpButtonLabelPair.HelpBtnPressedDelegate(this.OnHelpButtonPressed);
      if (string.IsNullOrEmpty(this._helpTopic))
      {
        this.ErrorPanel_HelpButtonLabelPair.Visible = false;
        this._textPanel.Location = new Point(this._origErrorMsgLblLocation.X, this._origErrorMsgLblLocation.Y - 6);
        this.ErrorPanel_ProblemImage.Location = new Point(this._origProblemImageLocation.X, this._origProblemImageLocation.Y - 6);
      }
      else
      {
        this.ErrorPanel_HelpButtonLabelPair.Visible = true;
        this._textPanel.Location = this._origErrorMsgLblLocation;
        this.ErrorPanel_ProblemImage.Location = this._origProblemImageLocation;
      }
      this._textPanel.Text = errorMessage;
      this.ErrorPanel_DetailsTxtBox.Text = details;
      SizeHelper.ResizeCustomControls(this.Controls);
    }

    private void UpdatePanel()
    {
      SizeHelper.ResizeCustomControls(this.Controls);
      int num;
      if (this.ErrorPanel_ProblemImage.Height < this._textPanel.Height)
      {
        this.ErrorPanel_ProblemImage.Location = new Point(this.ErrorPanel_ProblemImage.Location.X, this._textPanel.Location.Y + (this._textPanel.Height - this.ErrorPanel_ProblemImage.Height) / 2);
        num = this._textPanel.Location.Y + this._textPanel.Height;
      }
      else
      {
        this._textPanel.Location = new Point(this._textPanel.Location.X, this.ErrorPanel_ProblemImage.Location.Y + (this.ErrorPanel_ProblemImage.Height - this._textPanel.Height) / 2);
        num = this.ErrorPanel_ProblemImage.Location.Y + this.ErrorPanel_ProblemImage.Height;
      }
      if (CurrentUserSettings.ShowErrorDetails())
      {
        this.ErrorPanel_TopButtonBarSeperator.Visible = false;
        this.ErrorPanel_DetailsTxtBox.Visible = true;
        this.ErrorPanel_DetailsTxtBoxLbl.Visible = true;
        this.ErrorPanel_OkBtnBox.Location = new Point(this.ErrorPanel_OkBtnBox.Location.X, this.ErrorPanel_BottomButtonBarSeperator.Location.Y + this.ErrorPanel_BottomButtonBarSeperator.Height + 5);
      }
      else
      {
        this.ErrorPanel_TopButtonBarSeperator.Visible = true;
        this.ErrorPanel_DetailsTxtBox.Visible = false;
        this.ErrorPanel_DetailsTxtBoxLbl.Visible = false;
        this.ErrorPanel_TopButtonBarSeperator.Location = new Point(this.ErrorPanel_TopButtonBarSeperator.Location.X, num + 15);
        this.ErrorPanel_OkBtnBox.Location = new Point(this.ErrorPanel_OkBtnBox.Location.X, this.ErrorPanel_TopButtonBarSeperator.Location.Y + this.ErrorPanel_TopButtonBarSeperator.Height + 2);
      }
      this.Height = this.ErrorPanel_OkBtnBox.Location.Y + this.ErrorPanel_OkBtnBox.Height + 2;
      this._parentDialog.ResizeMe();
    }
  }
}
