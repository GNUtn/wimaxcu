// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.UnidentifiedNetworkGroupBox
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using Intel.Mobile.WiMAXCU.Common;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class UnidentifiedNetworkGroupBox : UserControl, INetworkPropertiesGroupBox
  {
    private IContainer components;
    private Label UnidentifiedNetworkGroupBox_NetworkIdLbl;
    private GroupBox UnidentifiedNetworkGroupBox_GroupBox;
    private Label UnidentifiedNetworkGroupBox_InstructionsLbl;
    private Label UnidentifiedNetworkGroupBox_NetworkIdValueLbl;
    private TextBox UnidentifiedNetworkGroupBox_NetworkNameTxtBox;
    private Label UnidentifiedNetworkGroupBox_NetworkNameLbl;
    private UpdateSaveBtnDelegate _updateSaveBtnDelegate;
    private string _origNetworkNameValue;

    public UnidentifiedNetworkGroupBox()
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (UnidentifiedNetworkGroupBox));
      this.UnidentifiedNetworkGroupBox_NetworkIdLbl = new Label();
      this.UnidentifiedNetworkGroupBox_GroupBox = new GroupBox();
      this.UnidentifiedNetworkGroupBox_NetworkIdValueLbl = new Label();
      this.UnidentifiedNetworkGroupBox_NetworkNameTxtBox = new TextBox();
      this.UnidentifiedNetworkGroupBox_NetworkNameLbl = new Label();
      this.UnidentifiedNetworkGroupBox_InstructionsLbl = new Label();
      this.UnidentifiedNetworkGroupBox_GroupBox.SuspendLayout();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.UnidentifiedNetworkGroupBox_NetworkIdLbl, "UnidentifiedNetworkGroupBox_NetworkIdLbl");
      this.UnidentifiedNetworkGroupBox_NetworkIdLbl.Name = "UnidentifiedNetworkGroupBox_NetworkIdLbl";
      this.UnidentifiedNetworkGroupBox_GroupBox.Controls.Add((Control) this.UnidentifiedNetworkGroupBox_NetworkIdValueLbl);
      this.UnidentifiedNetworkGroupBox_GroupBox.Controls.Add((Control) this.UnidentifiedNetworkGroupBox_NetworkNameTxtBox);
      this.UnidentifiedNetworkGroupBox_GroupBox.Controls.Add((Control) this.UnidentifiedNetworkGroupBox_NetworkNameLbl);
      this.UnidentifiedNetworkGroupBox_GroupBox.Controls.Add((Control) this.UnidentifiedNetworkGroupBox_InstructionsLbl);
      this.UnidentifiedNetworkGroupBox_GroupBox.Controls.Add((Control) this.UnidentifiedNetworkGroupBox_NetworkIdLbl);
      componentResourceManager.ApplyResources((object) this.UnidentifiedNetworkGroupBox_GroupBox, "UnidentifiedNetworkGroupBox_GroupBox");
      this.UnidentifiedNetworkGroupBox_GroupBox.Name = "UnidentifiedNetworkGroupBox_GroupBox";
      this.UnidentifiedNetworkGroupBox_GroupBox.TabStop = false;
      componentResourceManager.ApplyResources((object) this.UnidentifiedNetworkGroupBox_NetworkIdValueLbl, "UnidentifiedNetworkGroupBox_NetworkIdValueLbl");
      this.UnidentifiedNetworkGroupBox_NetworkIdValueLbl.Name = "UnidentifiedNetworkGroupBox_NetworkIdValueLbl";
      componentResourceManager.ApplyResources((object) this.UnidentifiedNetworkGroupBox_NetworkNameTxtBox, "UnidentifiedNetworkGroupBox_NetworkNameTxtBox");
      this.UnidentifiedNetworkGroupBox_NetworkNameTxtBox.Name = "UnidentifiedNetworkGroupBox_NetworkNameTxtBox";
      componentResourceManager.ApplyResources((object) this.UnidentifiedNetworkGroupBox_NetworkNameLbl, "UnidentifiedNetworkGroupBox_NetworkNameLbl");
      this.UnidentifiedNetworkGroupBox_NetworkNameLbl.Name = "UnidentifiedNetworkGroupBox_NetworkNameLbl";
      this.UnidentifiedNetworkGroupBox_InstructionsLbl.BackColor = Color.White;
      componentResourceManager.ApplyResources((object) this.UnidentifiedNetworkGroupBox_InstructionsLbl, "UnidentifiedNetworkGroupBox_InstructionsLbl");
      this.UnidentifiedNetworkGroupBox_InstructionsLbl.Name = "UnidentifiedNetworkGroupBox_InstructionsLbl";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.UnidentifiedNetworkGroupBox_GroupBox);
      this.Name = "UnidentifiedNetworkGroupBox";
      this.UnidentifiedNetworkGroupBox_GroupBox.ResumeLayout(false);
      this.UnidentifiedNetworkGroupBox_GroupBox.PerformLayout();
      this.ResumeLayout(false);
    }

    private void OnNetworkNameChanged(object sender, EventArgs e)
    {
      if (this._updateSaveBtnDelegate == null)
        return;
      this._updateSaveBtnDelegate();
    }

    private void CustomInitializeComponents()
    {
      this.AccessibleName = "UnidentifiedNetworkGroupBox";
      this.UnidentifiedNetworkGroupBox_GroupBox.AccessibleName = "UnidentifiedNetworkGroupBox_GroupBox";
      this.UnidentifiedNetworkGroupBox_InstructionsLbl.AccessibleName = "UnidentifiedNetworkGroupBox_InstructionsLbl";
      this.UnidentifiedNetworkGroupBox_NetworkIdLbl.AccessibleName = "UnidentifiedNetworkGroupBox_NetworkIdLbl";
      this.UnidentifiedNetworkGroupBox_NetworkIdValueLbl.AccessibleName = "UnidentifiedNetworkGroupBox_NetworkIdValueLbl";
      this.UnidentifiedNetworkGroupBox_NetworkNameLbl.AccessibleName = "UnidentifiedNetworkGroupBox_NetworkNameLbl";
      this.UnidentifiedNetworkGroupBox_NetworkNameTxtBox.AccessibleName = "UnidentifiedNetworkGroupBox_NetworkNameTxtBox";
      this.UnidentifiedNetworkGroupBox_GroupBox.Text = NetworkPropertiesDlgStringHelper.GetString("UnidentifiedNetworkGroupBox_GroupBox");
      this.UnidentifiedNetworkGroupBox_InstructionsLbl.Text = NetworkPropertiesDlgStringHelper.GetString("UnidentifiedNetworkGroupBox_InstructionsLbl");
      this.UnidentifiedNetworkGroupBox_NetworkIdLbl.Text = NetworkPropertiesDlgStringHelper.GetString("UnidentifiedNetworkGroupBox_NetworkIdLbl");
      this.UnidentifiedNetworkGroupBox_NetworkNameLbl.Text = NetworkPropertiesDlgStringHelper.GetString("UnidentifiedNetworkGroupBox_NetworkNameLbl");
      this.UnidentifiedNetworkGroupBox_GroupBox.ForeColor = Color.Black;
      this.UnidentifiedNetworkGroupBox_InstructionsLbl.ForeColor = Color.Black;
      this.UnidentifiedNetworkGroupBox_NetworkIdLbl.ForeColor = Color.Black;
      this.UnidentifiedNetworkGroupBox_NetworkNameLbl.ForeColor = Color.Black;
      this.UnidentifiedNetworkGroupBox_NetworkIdValueLbl.ForeColor = Color.Black;
      this.UnidentifiedNetworkGroupBox_NetworkNameTxtBox.ForeColor = Color.Black;
      this.UnidentifiedNetworkGroupBox_NetworkNameTxtBox.TextChanged += new EventHandler(this.OnNetworkNameChanged);
    }

    public void Initialize()
    {
      this.UnidentifiedNetworkGroupBox_NetworkIdValueLbl.Text = NetworkPropertiesDialog.Singleton.Network.WmxNetwork.NSPId.ToString();
      this.UnidentifiedNetworkGroupBox_NetworkNameTxtBox.Text = UserSpecifiedNetworkNames.GetNetworkName(NetworkPropertiesDialog.Singleton.Network.WmxNetwork);
      this._origNetworkNameValue = this.UnidentifiedNetworkGroupBox_NetworkNameTxtBox.Text;
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
      return this._origNetworkNameValue != this.UnidentifiedNetworkGroupBox_NetworkNameTxtBox.Text;
    }

    public bool SaveChanges()
    {
      if (!this.ChangesWereMade())
        return true;
      UserSpecifiedNetworkNames.AddNetworkName(NetworkPropertiesDialog.Singleton.Network.WmxNetwork, this.UnidentifiedNetworkGroupBox_NetworkNameTxtBox.Text);
      NetworkHandler.Singleton.RefreshData(true);
      return true;
    }

    public bool AddToLayoutPanel()
    {
      return NetworkPropertiesDialog.Singleton.Network != null && (MiscUtilities.IsUnidentifiedNetwork(NetworkPropertiesDialog.Singleton.Network.WmxNetwork.NSPName) || MiscUtilities.IsUnknownNetwork(NetworkPropertiesDialog.Singleton.Network.WmxNetwork.NSPName)) && NetworkPropertiesDialog.Singleton.Network.WmxNetwork.NSPId > 0U;
    }
  }
}
