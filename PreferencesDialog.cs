// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.PreferencesDialog
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
  public class PreferencesDialog : CustomForm
  {
    private static PreferencesDialog _instance = new PreferencesDialog();
    private IContainer components;
    private static PreferencesPanel _preferencesPanel;

    public static PreferencesDialog Singleton
    {
      get
      {
        return PreferencesDialog._instance;
      }
    }

    static PreferencesDialog()
    {
    }

    public PreferencesDialog()
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (PreferencesDialog));
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Inherit;
      this.ForeColor = Color.Black;
      this.FormType = FormTypeEnum.Dialog;
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.Name = "PreferencesDialog";
      this.ShowInTaskbar = false;
      this.ResumeLayout(false);
    }

    protected override void OnVisibleChanged(EventArgs e)
    {
      if (this.Visible)
        PreferencesDialog._preferencesPanel.InitPanel();
      else
        PreferencesDialog._preferencesPanel.CleanUp();
      base.OnVisibleChanged(e);
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.F1)
      {
        PreferencesDialog._preferencesPanel.LaunchHelp();
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
      this.AccessibleName = "PreferencesDialog";
      this.KeyDown += new KeyEventHandler(this.OnKeyDown);
      this.BackColor = CustomForm.FormBackColor;
      if (PreferencesDialog._preferencesPanel == null)
      {
        PreferencesDialog._preferencesPanel = new PreferencesPanel(this);
        PreferencesDialog._preferencesPanel.Location = new Point(ImageHelper.Unscaled.FrameLeftPixel.Width, ImageHelper.Unscaled.FrameTopPixel.Height);
        this.Controls.Add((Control) PreferencesDialog._preferencesPanel);
      }
      this.Size = new Size(PreferencesDialog._preferencesPanel.Width + ImageHelper.Unscaled.FrameLeftPixel.Width + ImageHelper.Unscaled.FrameRightPixel.Width, PreferencesDialog._preferencesPanel.Height + ImageHelper.Unscaled.FrameTopPixel.Height + ImageHelper.Unscaled.FrameBottomPixel.Height);
    }
  }
}
