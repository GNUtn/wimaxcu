// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.NetworkDetailsDialog
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
  public class NetworkDetailsDialog : CustomForm
  {
    private static NetworkDetailsDialog _instance = new NetworkDetailsDialog();
    private IContainer components;
    private static NetworkDetailsPanel _networkDetailsPanel;

    public static NetworkDetailsDialog Singleton
    {
      get
      {
        return NetworkDetailsDialog._instance;
      }
    }

    static NetworkDetailsDialog()
    {
    }

    public NetworkDetailsDialog()
    {
      this.InitializeComponent();
      this.CustomInitializeComponents();
      ScalingUtils.ScaleControlHierarchy((Control) this);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (NetworkDetailsDialog));
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Inherit;
      this.ForeColor = Color.Black;
      this.FormType = FormTypeEnum.Dialog;
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DetailsDialog";
      this.ShowInTaskbar = false;
      this.SizeGripStyle = SizeGripStyle.Hide;
      this.ResumeLayout(false);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    protected override void OnVisibleChanged(EventArgs e)
    {
      if (this.Visible)
        NetworkDetailsDialog._networkDetailsPanel.InitPanel();
      else
        NetworkDetailsDialog._networkDetailsPanel.CleanUp();
      base.OnVisibleChanged(e);
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.F1)
      {
        NetworkDetailsDialog._networkDetailsPanel.LaunchHelp();
      }
      else
      {
        if (e.KeyCode != Keys.Escape)
          return;
        this.Close();
      }
    }

    private void CustomInitializeComponents()
    {
      this.AccessibleName = "DetailsDialog";
      this.KeyDown += new KeyEventHandler(this.OnKeyDown);
      this.BackColor = CustomForm.FormBackColor;
      if (NetworkDetailsDialog._networkDetailsPanel == null)
      {
        NetworkDetailsDialog._networkDetailsPanel = new NetworkDetailsPanel();
        NetworkDetailsDialog._networkDetailsPanel.Location = new Point(ImageHelper.Unscaled.FrameLeftPixel.Width, ImageHelper.Unscaled.FrameTopPixel.Height);
        this.Controls.Add((Control) NetworkDetailsDialog._networkDetailsPanel);
      }
      this.Size = new Size(NetworkDetailsDialog._networkDetailsPanel.Width + ImageHelper.Unscaled.FrameLeftPixel.Width + ImageHelper.Unscaled.FrameRightPixel.Width, NetworkDetailsDialog._networkDetailsPanel.Height + ImageHelper.Unscaled.FrameTopPixel.Height + ImageHelper.Unscaled.FrameBottomPixel.Height);
    }
  }
}
