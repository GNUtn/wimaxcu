// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.ApdoFumoSimulator
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.SDKInterop;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class ApdoFumoSimulator : Form
  {
    private IContainer components;
    private Label label1;
    private Button Provisioning_LaunchBrowserBtn;
    private Button Provisioning_InitialProvisioningBtn;
    private Button Provisioning_OngoingProvisioningBtn;
    private Button Provisioning_FailedBtn;
    private Button Provisioning_CompletedBtn;
    private Button Provisioning_StartedBtn;
    private Label label2;
    private Button FUMO_FailedBtn;
    private Button FUMO_ProgressUpdate25Btn;
    private Button FUMO_ProgressUpdate75Btn;
    private Button FUMO_CompletedBtn;
    private Button FUMO_StartedBtn;
    private Button FUMO_ReceivedBtn;
    private Label label3;
    private Button Misc_RealmMismatch;
    private Button Misc_NWRejection;
    private Button Misc_Reauthentication;
    private Button Misc_EAPNotification;
    private TextBox Misc_EAPNotificationTextBox;
    private GroupBox groupBox1;
    private Label label4;

    public ApdoFumoSimulator()
    {
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.label1 = new Label();
      this.Provisioning_LaunchBrowserBtn = new Button();
      this.Provisioning_InitialProvisioningBtn = new Button();
      this.Provisioning_OngoingProvisioningBtn = new Button();
      this.Provisioning_FailedBtn = new Button();
      this.Provisioning_CompletedBtn = new Button();
      this.Provisioning_StartedBtn = new Button();
      this.label2 = new Label();
      this.FUMO_FailedBtn = new Button();
      this.FUMO_ProgressUpdate25Btn = new Button();
      this.FUMO_ProgressUpdate75Btn = new Button();
      this.FUMO_CompletedBtn = new Button();
      this.FUMO_StartedBtn = new Button();
      this.FUMO_ReceivedBtn = new Button();
      this.label3 = new Label();
      this.Misc_RealmMismatch = new Button();
      this.Misc_NWRejection = new Button();
      this.Misc_Reauthentication = new Button();
      this.Misc_EAPNotification = new Button();
      this.Misc_EAPNotificationTextBox = new TextBox();
      this.groupBox1 = new GroupBox();
      this.label4 = new Label();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(28, 13);
      this.label1.Name = "label1";
      this.label1.Size = new Size(67, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Provisioning:";
      this.Provisioning_LaunchBrowserBtn.BackColor = Color.FromArgb(192, (int) byte.MaxValue, 192);
      this.Provisioning_LaunchBrowserBtn.Location = new Point(67, 33);
      this.Provisioning_LaunchBrowserBtn.Name = "Provisioning_LaunchBrowserBtn";
      this.Provisioning_LaunchBrowserBtn.Size = new Size(193, 23);
      this.Provisioning_LaunchBrowserBtn.TabIndex = 1;
      this.Provisioning_LaunchBrowserBtn.Text = "Launch Default Browser";
      this.Provisioning_LaunchBrowserBtn.UseVisualStyleBackColor = false;
      this.Provisioning_LaunchBrowserBtn.Click += new EventHandler(this.Provisioning_LaunchBrowserBtn_Click);
      this.Provisioning_InitialProvisioningBtn.Location = new Point(67, 62);
      this.Provisioning_InitialProvisioningBtn.Name = "Provisioning_InitialProvisioningBtn";
      this.Provisioning_InitialProvisioningBtn.Size = new Size(193, 23);
      this.Provisioning_InitialProvisioningBtn.TabIndex = 2;
      this.Provisioning_InitialProvisioningBtn.Text = "Initial Provisioning";
      this.Provisioning_InitialProvisioningBtn.UseVisualStyleBackColor = true;
      this.Provisioning_InitialProvisioningBtn.Click += new EventHandler(this.Provisioning_InitialProvisioningBtn_Click);
      this.Provisioning_OngoingProvisioningBtn.Location = new Point(67, 91);
      this.Provisioning_OngoingProvisioningBtn.Name = "Provisioning_OngoingProvisioningBtn";
      this.Provisioning_OngoingProvisioningBtn.Size = new Size(193, 23);
      this.Provisioning_OngoingProvisioningBtn.TabIndex = 3;
      this.Provisioning_OngoingProvisioningBtn.Text = "Ongoing Provisioning";
      this.Provisioning_OngoingProvisioningBtn.UseVisualStyleBackColor = true;
      this.Provisioning_OngoingProvisioningBtn.Click += new EventHandler(this.Provisioning_OngoingProvisioningBtn_Click);
      this.Provisioning_FailedBtn.Location = new Point(67, 178);
      this.Provisioning_FailedBtn.Name = "Provisioning_FailedBtn";
      this.Provisioning_FailedBtn.Size = new Size(193, 23);
      this.Provisioning_FailedBtn.TabIndex = 4;
      this.Provisioning_FailedBtn.Text = "Failed";
      this.Provisioning_FailedBtn.UseVisualStyleBackColor = true;
      this.Provisioning_FailedBtn.Click += new EventHandler(this.Provisioning_FailedBtn_Click);
      this.Provisioning_CompletedBtn.Location = new Point(67, 149);
      this.Provisioning_CompletedBtn.Name = "Provisioning_CompletedBtn";
      this.Provisioning_CompletedBtn.Size = new Size(193, 23);
      this.Provisioning_CompletedBtn.TabIndex = 5;
      this.Provisioning_CompletedBtn.Text = "Completed";
      this.Provisioning_CompletedBtn.UseVisualStyleBackColor = true;
      this.Provisioning_CompletedBtn.Click += new EventHandler(this.Provisioning_CompletedBtn_Click);
      this.Provisioning_StartedBtn.Location = new Point(67, 120);
      this.Provisioning_StartedBtn.Name = "Provisioning_StartedBtn";
      this.Provisioning_StartedBtn.Size = new Size(193, 23);
      this.Provisioning_StartedBtn.TabIndex = 6;
      this.Provisioning_StartedBtn.Text = "Started";
      this.Provisioning_StartedBtn.UseVisualStyleBackColor = true;
      this.Provisioning_StartedBtn.Click += new EventHandler(this.Provisioning_StartedBtn_Click);
      this.label2.AutoSize = true;
      this.label2.Location = new Point(28, 217);
      this.label2.Name = "label2";
      this.label2.Size = new Size(130, 13);
      this.label2.TabIndex = 7;
      this.label2.Text = "FUMO (Software Update):";
      this.FUMO_FailedBtn.BackColor = Color.FromArgb(192, (int) byte.MaxValue, 192);
      this.FUMO_FailedBtn.Location = new Point(67, 384);
      this.FUMO_FailedBtn.Name = "FUMO_FailedBtn";
      this.FUMO_FailedBtn.Size = new Size(193, 23);
      this.FUMO_FailedBtn.TabIndex = 13;
      this.FUMO_FailedBtn.Text = "Failed";
      this.FUMO_FailedBtn.UseVisualStyleBackColor = false;
      this.FUMO_FailedBtn.Click += new EventHandler(this.FUMO_FailedBtn_Click);
      this.FUMO_ProgressUpdate25Btn.BackColor = Color.FromArgb(192, (int) byte.MaxValue, 192);
      this.FUMO_ProgressUpdate25Btn.Location = new Point(67, 268);
      this.FUMO_ProgressUpdate25Btn.Name = "FUMO_ProgressUpdate25Btn";
      this.FUMO_ProgressUpdate25Btn.Size = new Size(193, 23);
      this.FUMO_ProgressUpdate25Btn.TabIndex = 12;
      this.FUMO_ProgressUpdate25Btn.Text = "Progress Update (25%)";
      this.FUMO_ProgressUpdate25Btn.UseVisualStyleBackColor = false;
      this.FUMO_ProgressUpdate25Btn.Click += new EventHandler(this.FUMO_ProgressUpdate25Btn_Click);
      this.FUMO_ProgressUpdate75Btn.BackColor = Color.FromArgb(192, (int) byte.MaxValue, 192);
      this.FUMO_ProgressUpdate75Btn.Location = new Point(67, 297);
      this.FUMO_ProgressUpdate75Btn.Name = "FUMO_ProgressUpdate75Btn";
      this.FUMO_ProgressUpdate75Btn.Size = new Size(193, 23);
      this.FUMO_ProgressUpdate75Btn.TabIndex = 11;
      this.FUMO_ProgressUpdate75Btn.Text = "Progress Update (75%)";
      this.FUMO_ProgressUpdate75Btn.UseVisualStyleBackColor = false;
      this.FUMO_ProgressUpdate75Btn.Click += new EventHandler(this.FUMO_ProgressUpdate75Btn_Click);
      this.FUMO_CompletedBtn.Location = new Point(67, 355);
      this.FUMO_CompletedBtn.Name = "FUMO_CompletedBtn";
      this.FUMO_CompletedBtn.Size = new Size(193, 23);
      this.FUMO_CompletedBtn.TabIndex = 10;
      this.FUMO_CompletedBtn.Text = "Completed";
      this.FUMO_CompletedBtn.UseVisualStyleBackColor = true;
      this.FUMO_CompletedBtn.Click += new EventHandler(this.FUMO_CompletedBtn_Click);
      this.FUMO_StartedBtn.BackColor = Color.FromArgb(192, (int) byte.MaxValue, 192);
      this.FUMO_StartedBtn.Location = new Point(67, 326);
      this.FUMO_StartedBtn.Name = "FUMO_StartedBtn";
      this.FUMO_StartedBtn.Size = new Size(193, 23);
      this.FUMO_StartedBtn.TabIndex = 9;
      this.FUMO_StartedBtn.Text = "Started";
      this.FUMO_StartedBtn.UseVisualStyleBackColor = false;
      this.FUMO_StartedBtn.Click += new EventHandler(this.FUMO_StartedBtn_Click);
      this.FUMO_ReceivedBtn.BackColor = Color.FromArgb(192, (int) byte.MaxValue, 192);
      this.FUMO_ReceivedBtn.Location = new Point(67, 239);
      this.FUMO_ReceivedBtn.Name = "FUMO_ReceivedBtn";
      this.FUMO_ReceivedBtn.Size = new Size(193, 23);
      this.FUMO_ReceivedBtn.TabIndex = 8;
      this.FUMO_ReceivedBtn.Text = "Received";
      this.FUMO_ReceivedBtn.UseVisualStyleBackColor = false;
      this.FUMO_ReceivedBtn.Click += new EventHandler(this.FUMO_ReceivedBtn_Click);
      this.label3.AutoSize = true;
      this.label3.Location = new Point(348, 13);
      this.label3.Name = "label3";
      this.label3.Size = new Size(32, 13);
      this.label3.TabIndex = 14;
      this.label3.Text = "Misc:";
      this.Misc_RealmMismatch.BackColor = Color.FromArgb(192, (int) byte.MaxValue, 192);
      this.Misc_RealmMismatch.Location = new Point(351, 33);
      this.Misc_RealmMismatch.Name = "Misc_RealmMismatch";
      this.Misc_RealmMismatch.Size = new Size(193, 23);
      this.Misc_RealmMismatch.TabIndex = 15;
      this.Misc_RealmMismatch.Text = "Realm Mismatch";
      this.Misc_RealmMismatch.UseVisualStyleBackColor = false;
      this.Misc_RealmMismatch.Click += new EventHandler(this.Misc_RealmMismatch_Click);
      this.Misc_NWRejection.BackColor = Color.FromArgb(192, (int) byte.MaxValue, 192);
      this.Misc_NWRejection.Location = new Point(351, 62);
      this.Misc_NWRejection.Name = "Misc_NWRejection";
      this.Misc_NWRejection.Size = new Size(193, 23);
      this.Misc_NWRejection.TabIndex = 16;
      this.Misc_NWRejection.Text = "Network Rejection";
      this.Misc_NWRejection.UseVisualStyleBackColor = false;
      this.Misc_NWRejection.Click += new EventHandler(this.Misc_NWRejection_Click);
      this.Misc_Reauthentication.BackColor = Color.FromArgb(192, (int) byte.MaxValue, 192);
      this.Misc_Reauthentication.Location = new Point(351, 91);
      this.Misc_Reauthentication.Name = "Misc_Reauthentication";
      this.Misc_Reauthentication.Size = new Size(193, 23);
      this.Misc_Reauthentication.TabIndex = 17;
      this.Misc_Reauthentication.Text = "Reauthentication";
      this.Misc_Reauthentication.UseVisualStyleBackColor = false;
      this.Misc_Reauthentication.Click += new EventHandler(this.Misc_Reauthentication_Click);
      this.Misc_EAPNotification.BackColor = Color.FromArgb(192, (int) byte.MaxValue, 192);
      this.Misc_EAPNotification.Location = new Point(6, 149);
      this.Misc_EAPNotification.Name = "Misc_EAPNotification";
      this.Misc_EAPNotification.Size = new Size(193, 23);
      this.Misc_EAPNotification.TabIndex = 18;
      this.Misc_EAPNotification.Text = "Show Msg";
      this.Misc_EAPNotification.UseVisualStyleBackColor = false;
      this.Misc_EAPNotification.Click += new EventHandler(this.Misc_EAPNotification_Click);
      this.Misc_EAPNotificationTextBox.Location = new Point(7, 42);
      this.Misc_EAPNotificationTextBox.Multiline = true;
      this.Misc_EAPNotificationTextBox.Name = "Misc_EAPNotificationTextBox";
      this.Misc_EAPNotificationTextBox.ScrollBars = ScrollBars.Both;
      this.Misc_EAPNotificationTextBox.Size = new Size(193, 101);
      this.Misc_EAPNotificationTextBox.TabIndex = 19;
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Controls.Add((Control) this.Misc_EAPNotificationTextBox);
      this.groupBox1.Controls.Add((Control) this.Misc_EAPNotification);
      this.groupBox1.Location = new Point(351, 138);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(217, 182);
      this.groupBox1.TabIndex = 21;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "EAP Notification";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(7, 23);
      this.label4.Name = "label4";
      this.label4.Size = new Size(71, 13);
      this.label4.TabIndex = 20;
      this.label4.Text = "Test to show:";
      this.AutoScaleMode = AutoScaleMode.None;
      this.ClientSize = new Size(606, 413);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.Misc_Reauthentication);
      this.Controls.Add((Control) this.Misc_NWRejection);
      this.Controls.Add((Control) this.Misc_RealmMismatch);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.FUMO_FailedBtn);
      this.Controls.Add((Control) this.FUMO_ProgressUpdate25Btn);
      this.Controls.Add((Control) this.FUMO_ProgressUpdate75Btn);
      this.Controls.Add((Control) this.FUMO_CompletedBtn);
      this.Controls.Add((Control) this.FUMO_StartedBtn);
      this.Controls.Add((Control) this.FUMO_ReceivedBtn);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.Provisioning_StartedBtn);
      this.Controls.Add((Control) this.Provisioning_CompletedBtn);
      this.Controls.Add((Control) this.Provisioning_FailedBtn);
      this.Controls.Add((Control) this.Provisioning_OngoingProvisioningBtn);
      this.Controls.Add((Control) this.Provisioning_InitialProvisioningBtn);
      this.Controls.Add((Control) this.Provisioning_LaunchBrowserBtn);
      this.Controls.Add((Control) this.label1);
      this.Name = "ApdoFumoSimulator";
      this.Text = "APDO/FUMO Simulator";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void Provisioning_LaunchBrowserBtn_Click(object sender, EventArgs e)
    {
      APDOHandler.Singleton.ApdoFumoSimulatorTriggerProvisioning(WIMAX_API_PROV_OPERATION.WIMAX_API_PROV_OPERATION_CFG_UPDATE_TRIGGER_CONTACT);
    }

    private void Provisioning_InitialProvisioningBtn_Click(object sender, EventArgs e)
    {
      APDOHandler.Singleton.ApdoFumoSimulatorTriggerProvisioning(WIMAX_API_PROV_OPERATION.WIMAX_API_PROV_OPERATION_CFG_UPDATE_REQUEST_INITIAL_PROVISIONING);
    }

    private void Provisioning_OngoingProvisioningBtn_Click(object sender, EventArgs e)
    {
      APDOHandler.Singleton.ApdoFumoSimulatorTriggerProvisioning(WIMAX_API_PROV_OPERATION.WIMAX_API_PROV_OPERATION_CFG_UPDATE_REQUEST_ONGOING_PROVISIONING);
    }

    private void Provisioning_StartedBtn_Click(object sender, EventArgs e)
    {
      APDOHandler.Singleton.ApdoFumoSimulatorTriggerProvisioning(WIMAX_API_PROV_OPERATION.WIMAX_API_PROV_OPERATION_CFG_UPDATE_STARTED);
    }

    private void Provisioning_CompletedBtn_Click(object sender, EventArgs e)
    {
      APDOHandler.Singleton.ApdoFumoSimulatorTriggerProvisioning(WIMAX_API_PROV_OPERATION.WIMAX_API_PROV_OPERATION_CFG_UPDATE_COMPLETED);
    }

    private void Provisioning_FailedBtn_Click(object sender, EventArgs e)
    {
      APDOHandler.Singleton.ApdoFumoSimulatorTriggerProvisioning(WIMAX_API_PROV_OPERATION.WIMAX_API_PROV_OPERATION_CFG_UPDATE_FAILED);
    }

    private void FUMO_ReceivedBtn_Click(object sender, EventArgs e)
    {
      APDOHandler.Singleton.ApdoFumoSimulatorTriggerPackageUpdate(WIMAX_API_PACK_UPDATE.WIMAX_API_PACK_UPDATE_RECEIVED);
    }

    private void FUMO_ProgressUpdate25Btn_Click(object sender, EventArgs e)
    {
      APDOHandler.Singleton.ApdoFumoSimulatorTriggerPackageDownloadProgress(25U);
    }

    private void FUMO_ProgressUpdate75Btn_Click(object sender, EventArgs e)
    {
      APDOHandler.Singleton.ApdoFumoSimulatorTriggerPackageDownloadProgress(75U);
    }

    private void FUMO_StartedBtn_Click(object sender, EventArgs e)
    {
      APDOHandler.Singleton.ApdoFumoSimulatorTriggerPackageUpdate(WIMAX_API_PACK_UPDATE.WIMAX_API_PACK_UPDATE_STARTED);
    }

    private void FUMO_CompletedBtn_Click(object sender, EventArgs e)
    {
      APDOHandler.Singleton.ApdoFumoSimulatorTriggerPackageUpdate(WIMAX_API_PACK_UPDATE.WIMAX_API_PACK_UPDATE_COMPLETED);
    }

    private void FUMO_FailedBtn_Click(object sender, EventArgs e)
    {
      APDOHandler.Singleton.ApdoFumoSimulatorTriggerPackageUpdate(WIMAX_API_PACK_UPDATE.WIMAX_API_PACK_UPDATE_FAILED);
    }

    private void Misc_RealmMismatch_Click(object sender, EventArgs e)
    {
      object[] objArray = new object[0];
      WIMAX_API_SECURITY_COMPOUND securityCompound = new WIMAX_API_SECURITY_COMPOUND();
      securityCompound.NSPRealm = "garbled.intel.com";
      securityCompound.nwSecurityEnabled = true;
      securityCompound.realmStatus = WIMAX_API_REALM_VERIFICATION_STATUS.REALM_MATCH;
      securityCompound.serviceFlowsEncrypted = false;
      securityCompound.nspId = 0U;
      object[] eventArgs;
      if (NetworkHandler.ConnectedNetworks.Count >= 1)
        eventArgs = new object[2]
        {
          (object) securityCompound,
          (object) NetworkHandler.ConnectedNetworks[0].WmxNetwork
        };
      else if (NetworkHandler.AvailableNetworks.Count >= 1)
      {
        eventArgs = new object[2]
        {
          (object) securityCompound,
          (object) NetworkHandler.AvailableNetworks[0].WmxNetwork
        };
      }
      else
      {
        int num = (int) MessageBox.Show("No WiMAX network was found.");
        return;
      }
      Eventing.GenerateUIEvent("WiMAXSP.OnDisconnectedBecauseOfRealmMismatch", (object) this, eventArgs);
    }

    private void Misc_NWRejection_Click(object sender, EventArgs e)
    {
      object[] objArray = new object[0];
      object[] eventArgs;
      if (NetworkHandler.ConnectedNetworks.Count >= 1)
        eventArgs = new object[1]
        {
          (object) NetworkHandler.ConnectedNetworks[0].WmxNetwork
        };
      else if (NetworkHandler.AvailableNetworks.Count >= 1)
      {
        eventArgs = new object[1]
        {
          (object) NetworkHandler.AvailableNetworks[0].WmxNetwork
        };
      }
      else
      {
        int num = (int) MessageBox.Show("No WiMAX network was found.");
        return;
      }
      Eventing.GenerateUIEvent("WiMAXSP.OnDisconnectedBecauseOfNWRejection", (object) this, eventArgs);
    }

    private void Misc_Reauthentication_Click(object sender, EventArgs e)
    {
      object[] objArray = new object[0];
      object[] eventArgs;
      if (NetworkHandler.ConnectedNetworks.Count >= 1)
        eventArgs = new object[1]
        {
          (object) NetworkHandler.ConnectedNetworks[0].WmxNetwork
        };
      else if (NetworkHandler.AvailableNetworks.Count >= 1)
      {
        eventArgs = new object[1]
        {
          (object) NetworkHandler.AvailableNetworks[0].WmxNetwork
        };
      }
      else
      {
        int num = (int) MessageBox.Show("No WiMAX network was found.");
        return;
      }
      Eventing.GenerateUIEvent("WiMAXSP.OnDisconnectedBecauseOfNWRejectionReauthentication", (object) this, eventArgs);
    }

    private void Misc_EAPNotification_Click(object sender, EventArgs e)
    {
      Eventing.GenerateSPEvent("WiMAXSP.OnNetworkNotification", (object) this, new object[1]
      {
        (object) this.Misc_EAPNotificationTextBox.Text
      });
    }
  }
}
