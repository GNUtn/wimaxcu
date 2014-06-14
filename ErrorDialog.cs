// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.ErrorDialog
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
  public class ErrorDialog : CustomForm
  {
    private Container components;
    private ErrorPanel _errorPanel;

    public ErrorDialog(string errorMessage, string details, string helpTopic, string accessibleName)
    {
      this.InitializeComponent();
      this.CustomInitializeComponents(errorMessage, details, helpTopic, accessibleName);
      ScalingUtils.ScaleControlHierarchy((Control) this);
    }

    public ErrorDialog(string errorMessage, Exception ex, string helpTopic, string accessibleName)
    {
      string details = ex.Message + "\r\n\r\n" + ex.GetType().ToString() + "\r\n" + ex.StackTrace;
      if (ex.InnerException != null)
      {
        details = ex.InnerException.Message + "\r\n\r\n" + ex.InnerException.GetType().ToString() + "\r\n" + ex.InnerException.StackTrace;
        if (ex.InnerException.InnerException != null)
          details = ex.InnerException.InnerException.Message + "\r\n\r\n" + ex.InnerException.InnerException.GetType().ToString() + "\r\n" + ex.InnerException.InnerException.StackTrace;
      }
      this.InitializeComponent();
      this.CustomInitializeComponents(errorMessage, details, helpTopic, accessibleName);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ErrorDialog));
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Inherit;
      this.ForeColor = Color.Black;
      this.FormType = FormTypeEnum.Dialog;
      this.KeyPreview = true;
      this.Name = "ErrorDialog";
      this.ShowInTaskbar = false;
      this.ResumeLayout(false);
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.F1)
      {
        this._errorPanel.LaunchHelp();
      }
      else
      {
        if (e.KeyCode != Keys.Escape)
          return;
        this.Close();
      }
    }

    public void ResizeMe()
    {
      this._errorPanel.Location = new Point(ImageHelper.Unscaled.FrameLeftPixel.Width, ImageHelper.Unscaled.FrameTopPixel.Height);
      this.Size = new Size(this._errorPanel.Width + ImageHelper.Unscaled.FrameLeftPixel.Width + ImageHelper.Unscaled.FrameRightPixel.Width, this._errorPanel.Height + ImageHelper.Unscaled.FrameTopPixel.Height + ImageHelper.Unscaled.FrameBottomPixel.Height);
    }

    private void CustomInitializeComponents(string errorMessage, string details, string helpTopic, string accessibleName)
    {
      this.AccessibleName = accessibleName + "ErrorDialog";
      this.Text = DashboardStringHelper.GetString("ShortenedApplicationCaption");
      this.KeyDown += new KeyEventHandler(this.OnKeyDown);
      this.BackColor = CustomForm.FormBackColor;
      this._errorPanel = new ErrorPanel(this, errorMessage, details, helpTopic);
      this._errorPanel.Location = new Point(ImageHelper.Unscaled.FrameLeftPixel.Width, ImageHelper.Unscaled.FrameTopPixel.Height);
      this.Controls.Add((Control) this._errorPanel);
      this._errorPanel.InitPanel();
    }
  }
}
