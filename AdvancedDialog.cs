// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.AdvancedDialog
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
  public class AdvancedDialog : CustomForm
  {
    private static AdvancedDialog _instance = new AdvancedDialog();
    private IContainer components;
    private static AdvancedPanel _advancedPanel;

    public static AdvancedDialog Singleton
    {
      get
      {
        return AdvancedDialog._instance;
      }
    }

    public bool Blocked
    {
      get
      {
        return AdvancedDialog._advancedPanel.Blocked;
      }
    }

    static AdvancedDialog()
    {
    }

    public AdvancedDialog()
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AdvancedDialog));
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Inherit;
      this.ForeColor = Color.Black;
      this.FormType = FormTypeEnum.Dialog;
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.Name = "AdvancedDialog";
      this.ShowInTaskbar = false;
      this.ResumeLayout(false);
    }

    protected override void OnVisibleChanged(EventArgs e)
    {
      if (this.Visible)
        AdvancedDialog._advancedPanel.InitPanel();
      else
        AdvancedDialog._advancedPanel.CleanUp();
      base.OnVisibleChanged(e);
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      FormClosingEventArgs closingEventArgs = e as FormClosingEventArgs;
      if ((closingEventArgs == null || CloseReason.UserClosing == closingEventArgs.CloseReason) && AdvancedDialog._advancedPanel.Blocked)
        e.Cancel = true;
      base.OnClosing(e);
    }

    public void ResizeMe(Control childPanel)
    {
      this.Size = new Size(childPanel.Width + ImageHelper.Unscaled.FrameLeftPixel.Width + ImageHelper.Unscaled.FrameRightPixel.Width, childPanel.Height + ImageHelper.Unscaled.FrameTopPixel.Height + ImageHelper.Unscaled.FrameBottomPixel.Height);
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.F1)
      {
        AdvancedDialog._advancedPanel.LaunchHelp();
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
      this.AccessibleName = "AdvancedDialog";
      this.KeyDown += new KeyEventHandler(this.OnKeyDown);
      this.BackColor = CustomForm.FormBackColor;
      if (AdvancedDialog._advancedPanel == null)
      {
        AdvancedDialog._advancedPanel = new AdvancedPanel(this);
        AdvancedDialog._advancedPanel.Location = new Point(ImageHelper.Unscaled.FrameLeftPixel.Width, ImageHelper.Unscaled.FrameTopPixel.Height);
        this.Controls.Add((Control) AdvancedDialog._advancedPanel);
      }
      this.Size = new Size(AdvancedDialog._advancedPanel.Width + ImageHelper.Unscaled.FrameLeftPixel.Width + ImageHelper.Unscaled.FrameRightPixel.Width, AdvancedDialog._advancedPanel.Height + ImageHelper.Unscaled.FrameTopPixel.Height + ImageHelper.Unscaled.FrameBottomPixel.Height);
    }
  }
}
