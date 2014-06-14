// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.FUMOProgressDialog
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
  public class FUMOProgressDialog : CustomForm
  {
    private static FUMOProgressDialog _instance = new FUMOProgressDialog();
    private IContainer components;
    private static FUMOProgressPanel _fumoProgressPanel;

    public static FUMOProgressDialog Singleton
    {
      get
      {
        return FUMOProgressDialog._instance;
      }
    }

    static FUMOProgressDialog()
    {
    }

    public FUMOProgressDialog()
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
      this.SuspendLayout();
      this.AutoScaleMode = AutoScaleMode.None;
      this.ClientSize = new Size(450, 300);
      this.ForeColor = Color.Black;
      this.FormType = FormTypeEnum.Dialog;
      this.KeyPreview = true;
      this.Name = "FUMOProgressDialog";
      this.ShowInTaskbar = false;
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    protected override void OnVisibleChanged(EventArgs e)
    {
      if (this.Visible)
        FUMOProgressDialog._fumoProgressPanel.InitPanel();
      else
        FUMOProgressDialog._fumoProgressPanel.CleanUp();
      base.OnVisibleChanged(e);
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      this.Visible = false;
      Application.DoEvents();
      base.OnClosing(e);
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.F1)
      {
        FUMOProgressDialog._fumoProgressPanel.LaunchHelp();
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
      this.AccessibleName = "FUMOProgressDialog";
      this.KeyDown += new KeyEventHandler(this.OnKeyDown);
      this.BackColor = CustomForm.FormBackColor;
      if (FUMOProgressDialog._fumoProgressPanel == null)
      {
        FUMOProgressDialog._fumoProgressPanel = new FUMOProgressPanel();
        FUMOProgressDialog._fumoProgressPanel.Location = new Point(ImageHelper.Unscaled.FrameLeftPixel.Width, ImageHelper.Unscaled.FrameTopPixel.Height);
        this.Controls.Add((Control) FUMOProgressDialog._fumoProgressPanel);
      }
      this.Size = new Size(FUMOProgressDialog._fumoProgressPanel.Width + ImageHelper.Unscaled.FrameLeftPixel.Width + ImageHelper.Unscaled.FrameRightPixel.Width, FUMOProgressDialog._fumoProgressPanel.Height + ImageHelper.Unscaled.FrameTopPixel.Height + ImageHelper.Unscaled.FrameBottomPixel.Height);
    }
  }
}
