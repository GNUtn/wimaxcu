// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.NetworkPropertiesPanel
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using Intel.Mobile.WiMAXCU.UI.DisplayWiMAX;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class NetworkPropertiesPanel : UserControl
  {
    private IContainer components;
    private Label NetworkPropertiesPanel_HeaderLbl;
    private CustomHelpButtonLabelPair NetworkPropertiesPanel_HelpButtonLabelPair;
    private FlowLayoutPanel NetworkPropertiesPanel_LayoutPanel;
    private CustomButtonPushHorizBox NetworkPropertiesPanel_SaveCancelBtnBox;
    private CustomButtonPush NetworkPropertiesPanel_SaveBtn;
    private CustomButtonPush NetworkPropertiesPanel_CancelBtn;
    private UnidentifiedNetworkGroupBox NetworkPropertiesPanel_UnidentifiedNetworkGroupBox;
    private CredentialsGroupBox NetworkPropertiesPanel_CredentialsGroupBox;
    private NoPropertiesGroupBox NetworkPropertiesPanel_NoPropertiesGroupBox;

    public NetworkPropertiesPanel()
    {
      this.InitializeComponent();
      this.CustomInitializeComponents();
    }

    public void InitPanel()
    {
      if (NetworkPropertiesDialog.Singleton.Network != null)
        this.NetworkPropertiesPanel_HeaderLbl.Text = string.Format(NetworkPropertiesDlgStringHelper.GetString("NetworkPropertiesPanel_HeaderLbl"), (object) WiMAXDisplayService.Singleton.GetNetworkNameDisplayText(NetworkPropertiesDialog.Singleton.Network.WmxNetwork, false));
      else
        this.NetworkPropertiesPanel_HeaderLbl.Text = string.Format(NetworkPropertiesDlgStringHelper.GetString("NetworkPropertiesPanel_HeaderLbl"), (object) MiscUtilities.ParseProfileName(NetworkPropertiesDialog.Singleton.Profile.profileName));
      this.NetworkPropertiesPanel_SaveBtn.BtnEnabled = false;
      this.UpdateLayoutPanel();
      foreach (INetworkPropertiesGroupBox propertiesGroupBox in (ArrangedElementCollection) this.NetworkPropertiesPanel_LayoutPanel.Controls)
        propertiesGroupBox.Initialize();
      if (this.NetworkPropertiesPanel_LayoutPanel.Controls.Contains((Control) this.NetworkPropertiesPanel_CredentialsGroupBox))
      {
        this.ActiveControl = (Control) this.NetworkPropertiesPanel_CredentialsGroupBox;
        this.NetworkPropertiesPanel_CredentialsGroupBox.Focus();
      }
      else if (this.NetworkPropertiesPanel_LayoutPanel.Controls.Contains((Control) this.NetworkPropertiesPanel_UnidentifiedNetworkGroupBox))
      {
        this.ActiveControl = (Control) this.NetworkPropertiesPanel_UnidentifiedNetworkGroupBox;
        this.NetworkPropertiesPanel_UnidentifiedNetworkGroupBox.Focus();
      }
      else
      {
        this.ActiveControl = (Control) this.NetworkPropertiesPanel_NoPropertiesGroupBox;
        this.NetworkPropertiesPanel_NoPropertiesGroupBox.Focus();
      }
    }

    public void CleanUp()
    {
    }

    public void LaunchHelp()
    {
      OnlineHelp.LaunchHelp("/overview.htm");
    }

    private void OnSaveBtnPressed(object sender, EventArgs e)
    {
      if (!this.SaveChanges())
        return;
      NetworkPropertiesDialog.Singleton.Close();
    }

    private void OnCancelBtnPressed(object sender, EventArgs e)
    {
      NetworkPropertiesDialog.Singleton.Close();
    }

    private void OnHelpButtonPressed(object sender, MouseEventArgs e)
    {
      if (MouseHelper.IgnoreMouseClick(e, (Control) sender, ((Control) sender).Enabled))
        return;
      this.LaunchHelp();
    }

    private void CustomInitializeComponents()
    {
      this.AccessibleName = "NetworkPropertiesPanel";
      this.NetworkPropertiesPanel_CancelBtn.AccessibleName = "NetworkPropertiesPanel_CancelBtn";
      this.NetworkPropertiesPanel_HeaderLbl.AccessibleName = "NetworkPropertiesPanel_HeaderLbl";
      this.NetworkPropertiesPanel_HelpButtonLabelPair.AccessibleName = "NetworkPropertiesPanel_HelpButtonLabelPair";
      this.NetworkPropertiesPanel_LayoutPanel.AccessibleName = "NetworkPropertiesPanel_LayoutPanel";
      this.NetworkPropertiesPanel_SaveBtn.AccessibleName = "NetworkPropertiesPanel_SaveBtn";
      this.NetworkPropertiesPanel_SaveCancelBtnBox.AccessibleName = "NetworkPropertiesPanel_SaveCancelBtnBox";
      this.NetworkPropertiesPanel_CredentialsGroupBox.AccessibleName = "NetworkPropertiesPanel_CredentialsGroupBox";
      this.NetworkPropertiesPanel_UnidentifiedNetworkGroupBox.AccessibleName = "NetworkPropertiesPanel_UnidentifiedNetworkGroupBox";
      this.NetworkPropertiesPanel_CancelBtn.BtnText = NetworkPropertiesDlgStringHelper.GetString("NetworkPropertiesPanel_CancelBtn");
      this.NetworkPropertiesPanel_SaveBtn.BtnText = NetworkPropertiesDlgStringHelper.GetString("NetworkPropertiesPanel_SaveBtn");
      this.NetworkPropertiesPanel_SaveBtn.Pressed += new CustomButtonPush.PressedDelegate(this.OnSaveBtnPressed);
      this.NetworkPropertiesPanel_CancelBtn.Pressed += new CustomButtonPush.PressedDelegate(this.OnCancelBtnPressed);
      this.NetworkPropertiesPanel_HelpButtonLabelPair.HelpBtnPressed += new CustomHelpButtonLabelPair.HelpBtnPressedDelegate(this.OnHelpButtonPressed);
      SizeHelper.ResizeCustomControls(this.Controls);
      foreach (INetworkPropertiesGroupBox propertiesGroupBox in (ArrangedElementCollection) this.NetworkPropertiesPanel_LayoutPanel.Controls)
        propertiesGroupBox.SetUpdateSaveBtnDelgate(new UpdateSaveBtnDelegate(this.UpdateSaveBtn));
    }

    private void UpdateSaveBtn()
    {
      this.NetworkPropertiesPanel_SaveBtn.BtnEnabled = true;
    }

    private void UpdateLayoutPanel()
    {
      int num = 0;
      this.NetworkPropertiesPanel_LayoutPanel.Controls.Clear();
      if (this.NetworkPropertiesPanel_UnidentifiedNetworkGroupBox.AddToLayoutPanel())
      {
        this.NetworkPropertiesPanel_LayoutPanel.Controls.Add((Control) this.NetworkPropertiesPanel_UnidentifiedNetworkGroupBox);
        num = num + this.NetworkPropertiesPanel_UnidentifiedNetworkGroupBox.Height + (this.NetworkPropertiesPanel_UnidentifiedNetworkGroupBox.Margin.Top + this.NetworkPropertiesPanel_UnidentifiedNetworkGroupBox.Margin.Bottom);
      }
      if (this.NetworkPropertiesPanel_CredentialsGroupBox.AddToLayoutPanel())
      {
        this.NetworkPropertiesPanel_LayoutPanel.Controls.Add((Control) this.NetworkPropertiesPanel_CredentialsGroupBox);
        num = num + this.NetworkPropertiesPanel_CredentialsGroupBox.Height + (this.NetworkPropertiesPanel_CredentialsGroupBox.Margin.Top + this.NetworkPropertiesPanel_CredentialsGroupBox.Margin.Bottom);
      }
      if (this.NetworkPropertiesPanel_LayoutPanel.Controls.Count == 0)
      {
        this.NetworkPropertiesPanel_LayoutPanel.Controls.Add((Control) this.NetworkPropertiesPanel_NoPropertiesGroupBox);
        num = num + this.NetworkPropertiesPanel_NoPropertiesGroupBox.Height + (this.NetworkPropertiesPanel_NoPropertiesGroupBox.Margin.Top + this.NetworkPropertiesPanel_NoPropertiesGroupBox.Margin.Bottom);
      }
      this.NetworkPropertiesPanel_LayoutPanel.Height = num;
      this.NetworkPropertiesPanel_SaveCancelBtnBox.Location = new Point(this.NetworkPropertiesPanel_SaveCancelBtnBox.Location.X, this.NetworkPropertiesPanel_LayoutPanel.Location.Y + this.NetworkPropertiesPanel_LayoutPanel.Height);
      this.Size = new Size(this.Width, this.NetworkPropertiesPanel_SaveCancelBtnBox.Location.Y + this.NetworkPropertiesPanel_SaveCancelBtnBox.Height + 5);
      NetworkPropertiesDialog.Singleton.SetSizeToFitPanel();
    }

    private bool SaveChanges()
    {
      if (!this.PrerequistesMet())
        return false;
      this.Cursor = Cursors.WaitCursor;
      foreach (INetworkPropertiesGroupBox propertiesGroupBox in (ArrangedElementCollection) this.NetworkPropertiesPanel_LayoutPanel.Controls)
      {
        if (!propertiesGroupBox.SaveChanges())
        {
          this.Cursor = Cursors.Default;
          ErrorHelper.ShowErrorDialog((Control) this, ErrorStringsHelper.GetString("General_SaveChangesFailed"), "", (string) null, "NetworkPropertiesSaveChangesFailed");
          return false;
        }
      }
      this.Cursor = Cursors.Default;
      return true;
    }

    private bool PrerequistesMet()
    {
      foreach (INetworkPropertiesGroupBox propertiesGroupBox in (ArrangedElementCollection) this.NetworkPropertiesPanel_LayoutPanel.Controls)
      {
        if (!propertiesGroupBox.PrerequistesMet())
          return false;
      }
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (NetworkPropertiesPanel));
      this.NetworkPropertiesPanel_HeaderLbl = new Label();
      this.NetworkPropertiesPanel_HelpButtonLabelPair = new CustomHelpButtonLabelPair();
      this.NetworkPropertiesPanel_LayoutPanel = new FlowLayoutPanel();
      this.NetworkPropertiesPanel_NoPropertiesGroupBox = new NoPropertiesGroupBox();
      this.NetworkPropertiesPanel_UnidentifiedNetworkGroupBox = new UnidentifiedNetworkGroupBox();
      this.NetworkPropertiesPanel_CredentialsGroupBox = new CredentialsGroupBox();
      this.NetworkPropertiesPanel_SaveCancelBtnBox = new CustomButtonPushHorizBox();
      this.NetworkPropertiesPanel_SaveBtn = new CustomButtonPush();
      this.NetworkPropertiesPanel_CancelBtn = new CustomButtonPush();
      this.NetworkPropertiesPanel_LayoutPanel.SuspendLayout();
      this.NetworkPropertiesPanel_SaveCancelBtnBox.SuspendLayout();
      this.SuspendLayout();
      this.NetworkPropertiesPanel_HeaderLbl.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.NetworkPropertiesPanel_HeaderLbl, "NetworkPropertiesPanel_HeaderLbl");
      this.NetworkPropertiesPanel_HeaderLbl.Name = "NetworkPropertiesPanel_HeaderLbl";
      this.NetworkPropertiesPanel_HelpButtonLabelPair.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.NetworkPropertiesPanel_HelpButtonLabelPair, "NetworkPropertiesPanel_HelpButtonLabelPair");
      this.NetworkPropertiesPanel_HelpButtonLabelPair.Name = "NetworkPropertiesPanel_HelpButtonLabelPair";
      this.NetworkPropertiesPanel_LayoutPanel.Controls.Add((Control) this.NetworkPropertiesPanel_NoPropertiesGroupBox);
      this.NetworkPropertiesPanel_LayoutPanel.Controls.Add((Control) this.NetworkPropertiesPanel_UnidentifiedNetworkGroupBox);
      this.NetworkPropertiesPanel_LayoutPanel.Controls.Add((Control) this.NetworkPropertiesPanel_CredentialsGroupBox);
      componentResourceManager.ApplyResources((object) this.NetworkPropertiesPanel_LayoutPanel, "NetworkPropertiesPanel_LayoutPanel");
      this.NetworkPropertiesPanel_LayoutPanel.Name = "NetworkPropertiesPanel_LayoutPanel";
      componentResourceManager.ApplyResources((object) this.NetworkPropertiesPanel_NoPropertiesGroupBox, "NetworkPropertiesPanel_NoPropertiesGroupBox");
      this.NetworkPropertiesPanel_NoPropertiesGroupBox.BackColor = Color.White;
      this.NetworkPropertiesPanel_NoPropertiesGroupBox.Name = "NetworkPropertiesPanel_NoPropertiesGroupBox";
      componentResourceManager.ApplyResources((object) this.NetworkPropertiesPanel_UnidentifiedNetworkGroupBox, "NetworkPropertiesPanel_UnidentifiedNetworkGroupBox");
      this.NetworkPropertiesPanel_UnidentifiedNetworkGroupBox.BackColor = Color.White;
      this.NetworkPropertiesPanel_UnidentifiedNetworkGroupBox.Name = "NetworkPropertiesPanel_UnidentifiedNetworkGroupBox";
      componentResourceManager.ApplyResources((object) this.NetworkPropertiesPanel_CredentialsGroupBox, "NetworkPropertiesPanel_CredentialsGroupBox");
      this.NetworkPropertiesPanel_CredentialsGroupBox.BackColor = Color.White;
      this.NetworkPropertiesPanel_CredentialsGroupBox.Name = "NetworkPropertiesPanel_CredentialsGroupBox";
      this.NetworkPropertiesPanel_SaveCancelBtnBox.Controls.Add((Control) this.NetworkPropertiesPanel_SaveBtn);
      this.NetworkPropertiesPanel_SaveCancelBtnBox.Controls.Add((Control) this.NetworkPropertiesPanel_CancelBtn);
      componentResourceManager.ApplyResources((object) this.NetworkPropertiesPanel_SaveCancelBtnBox, "NetworkPropertiesPanel_SaveCancelBtnBox");
      this.NetworkPropertiesPanel_SaveCancelBtnBox.HorizontalJustification = HorizontalJustificationEnum.Right;
      this.NetworkPropertiesPanel_SaveCancelBtnBox.Name = "NetworkPropertiesPanel_SaveCancelBtnBox";
      this.NetworkPropertiesPanel_SaveBtn.BackColor = Color.White;
      this.NetworkPropertiesPanel_SaveBtn.BtnColor = PushButtonColorEnum.BlueGrey;
      this.NetworkPropertiesPanel_SaveBtn.BtnDoubleEndCaps = false;
      this.NetworkPropertiesPanel_SaveBtn.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.NetworkPropertiesPanel_SaveBtn, "NetworkPropertiesPanel_SaveBtn");
      this.NetworkPropertiesPanel_SaveBtn.Name = "NetworkPropertiesPanel_SaveBtn";
      this.NetworkPropertiesPanel_CancelBtn.BackColor = Color.White;
      this.NetworkPropertiesPanel_CancelBtn.BtnColor = PushButtonColorEnum.BlueGrey;
      this.NetworkPropertiesPanel_CancelBtn.BtnDoubleEndCaps = false;
      this.NetworkPropertiesPanel_CancelBtn.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.NetworkPropertiesPanel_CancelBtn, "NetworkPropertiesPanel_CancelBtn");
      this.NetworkPropertiesPanel_CancelBtn.Name = "NetworkPropertiesPanel_CancelBtn";
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.NetworkPropertiesPanel_SaveCancelBtnBox);
      this.Controls.Add((Control) this.NetworkPropertiesPanel_LayoutPanel);
      this.Controls.Add((Control) this.NetworkPropertiesPanel_HeaderLbl);
      this.Controls.Add((Control) this.NetworkPropertiesPanel_HelpButtonLabelPair);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "NetworkPropertiesPanel";
      this.NetworkPropertiesPanel_LayoutPanel.ResumeLayout(false);
      this.NetworkPropertiesPanel_SaveCancelBtnBox.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
