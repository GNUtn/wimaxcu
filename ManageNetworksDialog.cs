// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.ManageNetworksDialog
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
  public class ManageNetworksDialog : CustomForm
  {
    private static ManageNetworksDialog _instance = new ManageNetworksDialog();
    private IContainer components;
    private static ManageNetworksPanel _manageNetworksPanel;

    public static ManageNetworksDialog Singleton
    {
      get
      {
        return ManageNetworksDialog._instance;
      }
    }

    static ManageNetworksDialog()
    {
    }

    public ManageNetworksDialog()
    {
      this.InitializeComponent();
      this.CustomInitializeComponents();
      ScalingUtils.ScaleControlHierarchy((Control) this);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ManageNetworksDialog));
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
        ManageNetworksDialog._manageNetworksPanel.InitPanel();
      else
        ManageNetworksDialog._manageNetworksPanel.CleanUp();
      base.OnVisibleChanged(e);
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.F1)
      {
        ManageNetworksDialog._manageNetworksPanel.LaunchHelp();
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
      this.AccessibleName = "ManageNetworksDialog";
      this.KeyDown += new KeyEventHandler(this.OnKeyDown);
      this.BackColor = CustomForm.FormBackColor;
      if (ManageNetworksDialog._manageNetworksPanel == null)
      {
        ManageNetworksDialog._manageNetworksPanel = new ManageNetworksPanel();
        ManageNetworksDialog._manageNetworksPanel.Location = new Point(ImageHelper.Unscaled.FrameLeftPixel.Width, ImageHelper.Unscaled.FrameTopPixel.Height);
        this.Controls.Add((Control) ManageNetworksDialog._manageNetworksPanel);
      }
      this.Size = new Size(ManageNetworksDialog._manageNetworksPanel.Width + ImageHelper.Unscaled.FrameLeftPixel.Width + ImageHelper.Unscaled.FrameRightPixel.Width, ManageNetworksDialog._manageNetworksPanel.Height + ImageHelper.Unscaled.FrameTopPixel.Height + ImageHelper.Unscaled.FrameBottomPixel.Height);
    }
  }
}
