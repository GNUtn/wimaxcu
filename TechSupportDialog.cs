// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.TechSupportDialog
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
  public class TechSupportDialog : CustomForm
  {
    private static TechSupportDialog _instance = new TechSupportDialog();
    private IContainer components;
    private static TechSupportPanel _techSupportPanel;

    public static TechSupportDialog Singleton
    {
      get
      {
        return TechSupportDialog._instance;
      }
    }

    static TechSupportDialog()
    {
    }

    public TechSupportDialog()
    {
      this.InitializeComponent();
      this.CustomInitializeComponents();
      ScalingUtils.ScaleControlHierarchy((Control) this);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TechSupportDialog));
      this.SuspendLayout();
      this.AutoScaleMode = AutoScaleMode.Inherit;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.ForeColor = Color.Black;
      this.FormType = FormTypeEnum.Dialog;
      this.KeyPreview = true;
      this.Name = "TechSupportDialog";
      this.ShowInTaskbar = false;
      this.ResumeLayout(false);
    }

    public void ReinitDialog()
    {
      TechSupportDialog._techSupportPanel.SquirrelInfo();
    }

    protected override void OnVisibleChanged(EventArgs e)
    {
      if (this.Visible)
        TechSupportDialog._techSupportPanel.InitPanel();
      else
        TechSupportDialog._techSupportPanel.CleanUp();
      base.OnVisibleChanged(e);
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.F1)
      {
        TechSupportDialog._techSupportPanel.LaunchHelp();
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
      this.AccessibleName = "TechSupportDialog";
      this.KeyDown += new KeyEventHandler(this.OnKeyDown);
      this.BackColor = CustomForm.FormBackColor;
      if (TechSupportDialog._techSupportPanel == null)
      {
        TechSupportDialog._techSupportPanel = new TechSupportPanel();
        TechSupportDialog._techSupportPanel.Location = new Point(ImageHelper.Unscaled.FrameLeftPixel.Width, ImageHelper.Unscaled.FrameTopPixel.Height);
        this.Controls.Add((Control) TechSupportDialog._techSupportPanel);
      }
      this.Size = new Size(TechSupportDialog._techSupportPanel.Width + ImageHelper.Unscaled.FrameLeftPixel.Width + ImageHelper.Unscaled.FrameRightPixel.Width, TechSupportDialog._techSupportPanel.Height + ImageHelper.Unscaled.FrameTopPixel.Height + ImageHelper.Unscaled.FrameBottomPixel.Height);
    }
  }
}
