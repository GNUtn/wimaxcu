// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.NoPropertiesGroupBox
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.UI.CustomControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class NoPropertiesGroupBox : UserControl, INetworkPropertiesGroupBox
  {
    private IContainer components;
    private Label NoProperitesGroupBox_Label;
    private CustomLabelSeparator NoPropertiesGroupBox_ButtonBarSeperator;

    public NoPropertiesGroupBox()
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (NoPropertiesGroupBox));
      this.NoProperitesGroupBox_Label = new Label();
      this.NoPropertiesGroupBox_ButtonBarSeperator = new CustomLabelSeparator();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.NoProperitesGroupBox_Label, "NoProperitesGroupBox_Label");
      this.NoProperitesGroupBox_Label.Name = "NoProperitesGroupBox_Label";
      this.NoPropertiesGroupBox_ButtonBarSeperator.BackColor = Color.White;
      componentResourceManager.ApplyResources((object) this.NoPropertiesGroupBox_ButtonBarSeperator, "NoPropertiesGroupBox_ButtonBarSeperator");
      this.NoPropertiesGroupBox_ButtonBarSeperator.Name = "NoPropertiesGroupBox_ButtonBarSeperator";
      this.NoPropertiesGroupBox_ButtonBarSeperator.TabStop = false;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.NoPropertiesGroupBox_ButtonBarSeperator);
      this.Controls.Add((Control) this.NoProperitesGroupBox_Label);
      this.Name = "NoPropertiesGroupBox";
      this.ResumeLayout(false);
    }

    private void CustomInitializeComponents()
    {
      this.AccessibleName = "NoProperitesGroupBox";
      this.NoProperitesGroupBox_Label.AccessibleName = "NoProperitesGroupBox_Label";
      this.NoPropertiesGroupBox_ButtonBarSeperator.AccessibleName = "NoPropertiesGroupBox_ButtonBarSeperator";
      this.NoProperitesGroupBox_Label.Text = NetworkPropertiesDlgStringHelper.GetString("NoProperitesGroupBox_Label");
      this.NoPropertiesGroupBox_ButtonBarSeperator.Text = DashboardStringHelper.GetString("Empty");
      this.NoProperitesGroupBox_Label.ForeColor = Color.Black;
    }

    public void Initialize()
    {
    }

    public bool PrerequistesMet()
    {
      return true;
    }

    public void SetUpdateSaveBtnDelgate(UpdateSaveBtnDelegate func)
    {
    }

    public bool ChangesWereMade()
    {
      return false;
    }

    public bool SaveChanges()
    {
      return false;
    }

    public bool AddToLayoutPanel()
    {
      return false;
    }
  }
}
