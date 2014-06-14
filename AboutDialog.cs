// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.AboutDialog
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
  public class AboutDialog : CustomForm
  {
    private static AboutDialog _instance = new AboutDialog();
    private static AboutPanel _aboutPanel;
    private IContainer components;

    public static AboutDialog Singleton
    {
      get
      {
        return AboutDialog._instance;
      }
    }

    static AboutDialog()
    {
    }

    public AboutDialog()
    {
      this.InitializeComponent();
      this.CustomInitializeComponents();
      ScalingUtils.ScaleControlHierarchy((Control) this);
    }

    public void ReinitDialog()
    {
      AboutDialog._aboutPanel.SquirrelInfo();
    }

    protected override void OnVisibleChanged(EventArgs e)
    {
      if (this.Visible)
        AboutDialog._aboutPanel.InitPanel();
      else
        AboutDialog._aboutPanel.CleanUp();
      base.OnVisibleChanged(e);
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Escape)
        return;
      this.Close();
    }

    private void CustomInitializeComponents()
    {
      this.AccessibleName = "AboutDialog";
      this.KeyDown += new KeyEventHandler(this.OnKeyDown);
      this.BackColor = CustomForm.FormBackColor;
      if (AboutDialog._aboutPanel == null)
      {
        AboutDialog._aboutPanel = new AboutPanel();
        AboutDialog._aboutPanel.Location = new Point(ImageHelper.Unscaled.FrameLeftPixel.Width, ImageHelper.Unscaled.FrameTopPixel.Height);
        this.Controls.Add((Control) AboutDialog._aboutPanel);
      }
      this.SetSize();
    }

    public void SetSize()
    {
      this.Size = new Size(AboutDialog._aboutPanel.Width + ImageHelper.Unscaled.FrameLeftPixel.Width + ImageHelper.Unscaled.FrameRightPixel.Width, AboutDialog._aboutPanel.Height + ImageHelper.Unscaled.FrameTopPixel.Height + ImageHelper.Unscaled.FrameBottomPixel.Height);
      this.Invalidate();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AboutDialog));
      this.SuspendLayout();
      this.AutoScaleMode = AutoScaleMode.Inherit;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.ForeColor = Color.Black;
      this.FormType = FormTypeEnum.Dialog;
      this.KeyPreview = true;
      this.Name = "AboutDialog";
      this.ShowInTaskbar = false;
      this.ResumeLayout(false);
    }
  }
}
