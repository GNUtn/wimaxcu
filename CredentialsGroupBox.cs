// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.CredentialsGroupBox
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
  public class CredentialsGroupBox : UserControl, INetworkPropertiesGroupBox
  {
    private IContainer components;
    private GroupBox CredentialsGroupBox_GroupBox;
    private Label CredentialsGroupBox_PasswordLbl;
    private TextBox CredentialsGroupBox_PasswordTxtBox;
    private TextBox CredentialsGroupBox_UsernameTxtBox;
    private Label CredentialsGroupBox_UsernameLbl;
    private CustomRadioButtonGroup CredentialsGroupBox_RadioButtonGroup;
    private UpdateSaveBtnDelegate _updateSaveBtnDelegate;

    public CredentialsGroupBox()
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (CredentialsGroupBox));
      this.CredentialsGroupBox_GroupBox = new GroupBox();
      this.CredentialsGroupBox_RadioButtonGroup = new CustomRadioButtonGroup();
      this.CredentialsGroupBox_PasswordLbl = new Label();
      this.CredentialsGroupBox_PasswordTxtBox = new TextBox();
      this.CredentialsGroupBox_UsernameTxtBox = new TextBox();
      this.CredentialsGroupBox_UsernameLbl = new Label();
      this.CredentialsGroupBox_GroupBox.SuspendLayout();
      this.SuspendLayout();
      this.CredentialsGroupBox_GroupBox.Controls.Add((Control) this.CredentialsGroupBox_RadioButtonGroup);
      this.CredentialsGroupBox_GroupBox.Controls.Add((Control) this.CredentialsGroupBox_PasswordLbl);
      this.CredentialsGroupBox_GroupBox.Controls.Add((Control) this.CredentialsGroupBox_PasswordTxtBox);
      this.CredentialsGroupBox_GroupBox.Controls.Add((Control) this.CredentialsGroupBox_UsernameTxtBox);
      this.CredentialsGroupBox_GroupBox.Controls.Add((Control) this.CredentialsGroupBox_UsernameLbl);
      componentResourceManager.ApplyResources((object) this.CredentialsGroupBox_GroupBox, "CredentialsGroupBox_GroupBox");
      this.CredentialsGroupBox_GroupBox.Name = "CredentialsGroupBox_GroupBox";
      this.CredentialsGroupBox_GroupBox.TabStop = false;
      this.CredentialsGroupBox_RadioButtonGroup.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.CredentialsGroupBox_RadioButtonGroup, "CredentialsGroupBox_RadioButtonGroup");
      this.CredentialsGroupBox_RadioButtonGroup.Name = "CredentialsGroupBox_RadioButtonGroup";
      this.CredentialsGroupBox_RadioButtonGroup.SelectedIndex = 0;
      componentResourceManager.ApplyResources((object) this.CredentialsGroupBox_PasswordLbl, "CredentialsGroupBox_PasswordLbl");
      this.CredentialsGroupBox_PasswordLbl.Name = "CredentialsGroupBox_PasswordLbl";
      componentResourceManager.ApplyResources((object) this.CredentialsGroupBox_PasswordTxtBox, "CredentialsGroupBox_PasswordTxtBox");
      this.CredentialsGroupBox_PasswordTxtBox.Name = "CredentialsGroupBox_PasswordTxtBox";
      this.CredentialsGroupBox_PasswordTxtBox.UseSystemPasswordChar = true;
      componentResourceManager.ApplyResources((object) this.CredentialsGroupBox_UsernameTxtBox, "CredentialsGroupBox_UsernameTxtBox");
      this.CredentialsGroupBox_UsernameTxtBox.Name = "CredentialsGroupBox_UsernameTxtBox";
      componentResourceManager.ApplyResources((object) this.CredentialsGroupBox_UsernameLbl, "CredentialsGroupBox_UsernameLbl");
      this.CredentialsGroupBox_UsernameLbl.Name = "CredentialsGroupBox_UsernameLbl";
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.CredentialsGroupBox_GroupBox);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "CredentialsGroupBox";
      this.CredentialsGroupBox_GroupBox.ResumeLayout(false);
      this.CredentialsGroupBox_GroupBox.PerformLayout();
      this.ResumeLayout(false);
    }

    private void OnRadioButtonGroupSelectionChanged(object sender, SelectionArgs e)
    {
      if (this._updateSaveBtnDelegate != null)
        this._updateSaveBtnDelegate();
      this.UpdateUI();
    }

    private void OnUsernameChanged(object sender, EventArgs e)
    {
      if (this._updateSaveBtnDelegate == null)
        return;
      this._updateSaveBtnDelegate();
    }

    private void OnPasswordChanged(object sender, EventArgs e)
    {
      if (this._updateSaveBtnDelegate == null)
        return;
      this._updateSaveBtnDelegate();
    }

    private void CustomInitializeComponents()
    {
      this.AccessibleName = "CredentialsGroupBox";
      this.CredentialsGroupBox_RadioButtonGroup.AccessibleName = "CredentialsGroupBox_RadioButtonGroup";
      this.CredentialsGroupBox_GroupBox.AccessibleName = "CredentialsGroupBox_GroupBox";
      this.CredentialsGroupBox_PasswordLbl.AccessibleName = "CredentialsGroupBox_PasswordLbl";
      this.CredentialsGroupBox_PasswordTxtBox.AccessibleName = "CredentialsGroupBox_PasswordTxtBox";
      this.CredentialsGroupBox_UsernameLbl.AccessibleName = "CredentialsGroupBox_UsernameLbl";
      this.CredentialsGroupBox_UsernameTxtBox.AccessibleName = "CredentialsGroupBox_UsernameTxtBox";
      this.CredentialsGroupBox_RadioButtonGroup.Labels = new string[2]
      {
        NetworkPropertiesDlgStringHelper.GetString("CredentialsGroupBox_RadioButtonGroup_Prompt"),
        NetworkPropertiesDlgStringHelper.GetString("CredentialsGroupBox_RadioButtonGroup_Remember")
      };
      this.CredentialsGroupBox_GroupBox.Text = NetworkPropertiesDlgStringHelper.GetString("CredentialsGroupBox_GroupBox");
      this.CredentialsGroupBox_PasswordLbl.Text = NetworkPropertiesDlgStringHelper.GetString("CredentialsGroupBox_PasswordLbl");
      this.CredentialsGroupBox_UsernameLbl.Text = NetworkPropertiesDlgStringHelper.GetString("CredentialsGroupBox_UsernameLbl");
      this.CredentialsGroupBox_GroupBox.ForeColor = Color.Black;
      this.CredentialsGroupBox_RadioButtonGroup.ForeColor = Color.Black;
      this.CredentialsGroupBox_PasswordLbl.ForeColor = Color.Black;
      this.CredentialsGroupBox_PasswordTxtBox.ForeColor = Color.Black;
      this.CredentialsGroupBox_UsernameLbl.ForeColor = Color.Black;
      this.CredentialsGroupBox_UsernameTxtBox.ForeColor = Color.Black;
      this.CredentialsGroupBox_RadioButtonGroup.SelectionChanged += new CustomRadioButtonGroup.SelectionChangedDelegate(this.OnRadioButtonGroupSelectionChanged);
      this.CredentialsGroupBox_UsernameTxtBox.TextChanged += new EventHandler(this.OnUsernameChanged);
      this.CredentialsGroupBox_PasswordTxtBox.TextChanged += new EventHandler(this.OnPasswordChanged);
    }

    private void UpdateUI()
    {
      if (this.CredentialsGroupBox_RadioButtonGroup.SelectedIndex == 1)
      {
        this.CredentialsGroupBox_UsernameTxtBox.Enabled = true;
        this.CredentialsGroupBox_PasswordTxtBox.Enabled = true;
      }
      else
      {
        this.CredentialsGroupBox_UsernameTxtBox.Enabled = false;
        this.CredentialsGroupBox_PasswordTxtBox.Enabled = false;
      }
    }

    public void Initialize()
    {
      this.CredentialsGroupBox_UsernameTxtBox.Text = "";
      this.CredentialsGroupBox_PasswordTxtBox.Text = "";
      this.CredentialsGroupBox_RadioButtonGroup.SelectedIndex = 0;
      if (this.CredentialsGroupBox_RadioButtonGroup.SelectedIndex == 0)
      {
        this.ActiveControl = (Control) this.CredentialsGroupBox_RadioButtonGroup;
        this.CredentialsGroupBox_RadioButtonGroup.Focus();
      }
      else
      {
        this.ActiveControl = (Control) this.CredentialsGroupBox_UsernameTxtBox;
        this.CredentialsGroupBox_UsernameTxtBox.Focus();
      }
      this.UpdateUI();
    }

    public bool PrerequistesMet()
    {
      return true;
    }

    public void SetUpdateSaveBtnDelgate(UpdateSaveBtnDelegate func)
    {
      this._updateSaveBtnDelegate = func;
    }

    public bool ChangesWereMade()
    {
      return false;
    }

    public bool SaveChanges()
    {
      return !this.ChangesWereMade() ? true : true;
    }

    public bool AddToLayoutPanel()
    {
      return false;
    }
  }
}
