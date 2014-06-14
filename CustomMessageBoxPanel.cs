// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.CustomMessageBoxPanel
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
  public class CustomMessageBoxPanel : UserControl
  {
    private IContainer components;
    protected CustomButtonPushHorizBox BtnBox;
    protected CustomButtonPush Btn1;
    protected CustomButtonPush Btn2;
    protected CustomButtonPush Btn3;
    protected CustomCheckBox DontShowThisMessageAgainChkBox;
    protected CustomMessageBox _parentDialog;
    private TextPanel _txtPanel;

    public CustomMessageBoxPanel(CustomMessageBox parentDialog)
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (CustomMessageBoxPanel));
      this.BtnBox = new CustomButtonPushHorizBox();
      this.Btn1 = new CustomButtonPush();
      this.Btn2 = new CustomButtonPush();
      this.Btn3 = new CustomButtonPush();
      this.DontShowThisMessageAgainChkBox = new CustomCheckBox();
      this.BtnBox.SuspendLayout();
      this.SuspendLayout();
      this.BtnBox.Controls.Add((Control) this.Btn1);
      this.BtnBox.Controls.Add((Control) this.Btn2);
      this.BtnBox.Controls.Add((Control) this.Btn3);
      componentResourceManager.ApplyResources((object) this.BtnBox, "BtnBox");
      this.BtnBox.HorizontalJustification = HorizontalJustificationEnum.Right;
      this.BtnBox.Name = "BtnBox";
      this.Btn1.BackColor = Color.Transparent;
      this.Btn1.BtnColor = PushButtonColorEnum.BlueGrey;
      this.Btn1.BtnDoubleEndCaps = false;
      this.Btn1.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.Btn1, "Btn1");
      this.Btn1.Name = "Btn1";
      this.Btn2.BackColor = Color.Transparent;
      this.Btn2.BtnColor = PushButtonColorEnum.BlueGrey;
      this.Btn2.BtnDoubleEndCaps = false;
      this.Btn2.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.Btn2, "Btn2");
      this.Btn2.Name = "Btn2";
      this.Btn3.BackColor = Color.Transparent;
      this.Btn3.BtnColor = PushButtonColorEnum.BlueGrey;
      this.Btn3.BtnDoubleEndCaps = false;
      this.Btn3.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.Btn3, "Btn3");
      this.Btn3.Name = "Btn3";
      this.DontShowThisMessageAgainChkBox.BackColor = Color.Transparent;
      this.DontShowThisMessageAgainChkBox.ButtonBitmapDisabled = (Bitmap) componentResourceManager.GetObject("DontShowThisMessageAgainChkBox.ButtonBitmapDisabled");
      this.DontShowThisMessageAgainChkBox.ButtonBitmapNormal = (Bitmap) componentResourceManager.GetObject("DontShowThisMessageAgainChkBox.ButtonBitmapNormal");
      this.DontShowThisMessageAgainChkBox.ButtonBitmapPressed = (Bitmap) componentResourceManager.GetObject("DontShowThisMessageAgainChkBox.ButtonBitmapPressed");
      this.DontShowThisMessageAgainChkBox.ButtonBitmapRollover = (Bitmap) componentResourceManager.GetObject("DontShowThisMessageAgainChkBox.ButtonBitmapRollover");
      this.DontShowThisMessageAgainChkBox.Checked = false;
      componentResourceManager.ApplyResources((object) this.DontShowThisMessageAgainChkBox, "DontShowThisMessageAgainChkBox");
      this.DontShowThisMessageAgainChkBox.Name = "DontShowThisMessageAgainChkBox";
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.BtnBox);
      this.Controls.Add((Control) this.DontShowThisMessageAgainChkBox);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "CustomMessageBoxPanel";
      this.BtnBox.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    protected override void OnCreateControl()
    {
      this.DontShowThisMessageAgainChkBox.AccessibleName = this._parentDialog.AccessibleName + "_DontShowCheckBox";
      this.BtnBox.AccessibleName = this._parentDialog.AccessibleName + "_BtnBox";
      this.Btn1.AccessibleName = this._parentDialog.AccessibleName + "_PushBtn1";
      this.Btn2.AccessibleName = this._parentDialog.AccessibleName + "_PushBtn2";
      this.Btn3.AccessibleName = this._parentDialog.AccessibleName + "_PushBtn3";
      base.OnCreateControl();
    }

    private void OnOkButtonPressed(object sender, EventArgs e)
    {
      this.HandleDontShowThisMessageAgainChkBox();
      this._parentDialog.DialogResult = DialogResult.OK;
      this._parentDialog.UserGaveResponse = true;
      this._parentDialog.Close();
    }

    private void OnCancelButtonPressed(object sender, EventArgs e)
    {
      this.HandleDontShowThisMessageAgainChkBox();
      this._parentDialog.DialogResult = DialogResult.Cancel;
      this._parentDialog.UserGaveResponse = true;
      this._parentDialog.Close();
    }

    private void OnYesButtonPressed(object sender, EventArgs e)
    {
      this.HandleDontShowThisMessageAgainChkBox();
      this._parentDialog.DialogResult = DialogResult.Yes;
      this._parentDialog.UserGaveResponse = true;
      this._parentDialog.Close();
    }

    private void OnRemindMeLaterButtonPressed(object sender, EventArgs e)
    {
      this.HandleDontShowThisMessageAgainChkBox();
      this._parentDialog.DialogResult = DialogResult.No;
      this._parentDialog.UserGaveResponse = true;
      this._parentDialog.Close();
    }

    private void OnNoButtonPressed(object sender, EventArgs e)
    {
      this.HandleDontShowThisMessageAgainChkBox();
      this._parentDialog.DialogResult = DialogResult.No;
      this._parentDialog.UserGaveResponse = true;
      this._parentDialog.Close();
    }

    protected void CustomInitializeComponents()
    {
      int num1 = 15;
      int num2 = 15;
      int num3 = 25;
      int num4 = 25;
      this._parentDialog.UserGaveResponse = false;
      this.DontShowThisMessageAgainChkBox.Text = CustomMessageBoxStringHelper.GetString("DontShowThisMessageAgain");
      if (this._parentDialog.DontShowThisMessageAgainOption == DontShowThisMessageAgainOptions.None)
      {
        this.DontShowThisMessageAgainChkBox.Visible = false;
        this.DontShowThisMessageAgainChkBox.TabStop = false;
      }
      else
      {
        this.DontShowThisMessageAgainChkBox.Visible = true;
        this.DontShowThisMessageAgainChkBox.TabStop = true;
      }
      this.CustomButtonInitialize();
      SizeHelper.ResizeCustomControls(this.Controls);
      PictureBox pictureBox = new PictureBox();
      pictureBox.Size = new Size(0, 0);
      int iconPadding = 0;
      if (this._parentDialog.Style == CustomMessageBoxStyle.YesNo || this._parentDialog.Style == CustomMessageBoxStyle.YesNoCancel || this._parentDialog.Style == CustomMessageBoxStyle.YesRemindMeLater)
      {
        pictureBox = new PictureBox();
        pictureBox.AccessibleName = this._parentDialog.AccessibleName + "_Icon";
        pictureBox.Image = (Image) ImageHelper.WiMAXQuestionLargeIcon;
        pictureBox.Location = new Point(num1, num2);
        pictureBox.Size = new Size(48, 48);
        iconPadding = 20;
        this.Controls.Add((Control) pictureBox);
      }
      Control textControlToAdd = this.GetTextControlToAdd(num1, num2, pictureBox.Width, iconPadding);
      textControlToAdd.AccessibleName = this._parentDialog.AccessibleName + "_Text";
      this.Controls.Add(textControlToAdd);
      textControlToAdd.Location = new Point(num1 + pictureBox.Width + iconPadding, num2);
      this.DontShowThisMessageAgainChkBox.Location = new Point(textControlToAdd.Location.X, this.DontShowThisMessageAgainChkBox.Location.Y);
      this.BtnBox.Location = new Point(textControlToAdd.Location.X, this.BtnBox.Location.Y);
      this.Height = textControlToAdd.Height + this.BtnBox.Height + num3 + num2;
      if (this.DontShowThisMessageAgainChkBox.Visible)
      {
        CustomMessageBoxPanel customMessageBoxPanel = this;
        int num5 = customMessageBoxPanel.Height + (num4 + this.DontShowThisMessageAgainChkBox.Height);
        customMessageBoxPanel.Height = num5;
      }
      this.Width = textControlToAdd.Location.X + textControlToAdd.Width + num1;
      if (this.Width < this.DontShowThisMessageAgainChkBox.Location.X + this.DontShowThisMessageAgainChkBox.Width + num1)
        this.Width = this.DontShowThisMessageAgainChkBox.Location.X + this.DontShowThisMessageAgainChkBox.Width + num1;
      if (this.Width < this.BtnBox.Location.X + this.BtnBox.Width + num1)
        this.Width = this.BtnBox.Location.X + this.BtnBox.Width + num1;
      if (this.DontShowThisMessageAgainChkBox.Visible)
        this.DontShowThisMessageAgainChkBox.Location = new Point(textControlToAdd.Location.X, textControlToAdd.Location.Y + textControlToAdd.Height + num4);
      this.BtnBox.Location = new Point(this.Width - num1 - this.BtnBox.Width, this.Height - this.BtnBox.Height);
    }

    protected virtual Control GetTextControlToAdd(int xPos, int yPos, int iconWidth, int iconPadding)
    {
      if (this._txtPanel == null)
      {
        this._txtPanel = new TextPanel();
        this._txtPanel.Location = new Point(xPos + iconWidth + iconPadding, yPos);
        this._txtPanel.Width = this.Width - iconWidth - iconPadding;
        this._txtPanel.Font = this.Font;
        this._txtPanel.Text = this._parentDialog.Message;
        this._txtPanel.TabStop = false;
      }
      return (Control) this._txtPanel;
    }

    public virtual void UpdateTextControl()
    {
      this._txtPanel.Text = this._parentDialog.Message;
      this._txtPanel.Invalidate();
    }

    protected void CustomButtonInitialize()
    {
      switch (this._parentDialog.Style)
      {
        case CustomMessageBoxStyle.Ok:
          this.Btn1.BtnText = CustomMessageBoxStringHelper.GetString("Ok");
          this.Btn1.Pressed += new CustomButtonPush.PressedDelegate(this.OnOkButtonPressed);
          this.BtnBox.Controls.Remove((Control) this.Btn2);
          this.BtnBox.Controls.Remove((Control) this.Btn3);
          this.ActiveControl = (Control) this.Btn1;
          break;
        case CustomMessageBoxStyle.OkCancel:
          this.Btn1.BtnText = CustomMessageBoxStringHelper.GetString("Ok");
          this.Btn1.Pressed += new CustomButtonPush.PressedDelegate(this.OnOkButtonPressed);
          this.Btn2.BtnText = CustomMessageBoxStringHelper.GetString("Cancel");
          this.Btn2.Pressed += new CustomButtonPush.PressedDelegate(this.OnCancelButtonPressed);
          this.BtnBox.Controls.Remove((Control) this.Btn3);
          this.ActiveControl = (Control) this.Btn1;
          break;
        case CustomMessageBoxStyle.YesNo:
          this.Btn1.BtnText = CustomMessageBoxStringHelper.GetString("Yes");
          this.Btn1.Pressed += new CustomButtonPush.PressedDelegate(this.OnYesButtonPressed);
          this.Btn2.BtnText = CustomMessageBoxStringHelper.GetString("No");
          this.Btn2.Pressed += new CustomButtonPush.PressedDelegate(this.OnRemindMeLaterButtonPressed);
          this.BtnBox.Controls.Remove((Control) this.Btn3);
          this.ActiveControl = (Control) this.Btn2;
          break;
        case CustomMessageBoxStyle.YesRemindMeLater:
          this.Btn1.BtnText = CustomMessageBoxStringHelper.GetString("Yes");
          this.Btn1.Pressed += new CustomButtonPush.PressedDelegate(this.OnYesButtonPressed);
          this.Btn2.BtnText = CustomMessageBoxStringHelper.GetString("RemindMeLater");
          this.Btn2.Pressed += new CustomButtonPush.PressedDelegate(this.OnNoButtonPressed);
          this.BtnBox.Controls.Remove((Control) this.Btn3);
          this.ActiveControl = (Control) this.Btn2;
          break;
        case CustomMessageBoxStyle.YesNoCancel:
          this.Btn1.BtnText = CustomMessageBoxStringHelper.GetString("Yes");
          this.Btn1.Pressed += new CustomButtonPush.PressedDelegate(this.OnYesButtonPressed);
          this.Btn2.BtnText = CustomMessageBoxStringHelper.GetString("No");
          this.Btn2.Pressed += new CustomButtonPush.PressedDelegate(this.OnNoButtonPressed);
          this.Btn3.BtnText = CustomMessageBoxStringHelper.GetString("Cancel");
          this.Btn3.Pressed += new CustomButtonPush.PressedDelegate(this.OnCancelButtonPressed);
          this.ActiveControl = (Control) this.Btn3;
          break;
      }
    }

    private void HandleDontShowThisMessageAgainChkBox()
    {
      if (this._parentDialog.DontShowThisMessageAgainOption == DontShowThisMessageAgainOptions.None || !this.DontShowThisMessageAgainChkBox.Checked)
        return;
      switch (this._parentDialog.DontShowThisMessageAgainOption)
      {
        case DontShowThisMessageAgainOptions.ActiveRoutesPopup:
          CurrentUserSettings.SetShowActiveRoutesPopup(false);
          break;
        case DontShowThisMessageAgainOptions.SubscribeForServiceAndFirewallPopup:
          CurrentUserSettings.SetShowSubscribeForServiceAndFirewallPopup(false);
          break;
        case DontShowThisMessageAgainOptions.TurningRadioOnWillBreakYourConnectionPopup:
          CurrentUserSettings.SetShowCoExPopups(false);
          break;
        case DontShowThisMessageAgainOptions.ComputerIsEnabledForWiMAXPopup:
          CurrentUserSettings.SetShowComputerIsEnabledForWiMAXPopup(false);
          break;
        case DontShowThisMessageAgainOptions.DualModeWarningForWiFi:
        case DontShowThisMessageAgainOptions.DualModeWarningForWiMAX:
          CurrentUserSettings.SetShowDualModeWarningPopup(false);
          break;
      }
    }
  }
}
