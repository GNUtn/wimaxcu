// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.CustomMessageBox
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.SDKInterop;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class CustomMessageBox : CustomForm
  {
    protected string _message = string.Empty;
    private CustomMessageBoxLocation _customMessageBoxLocation = CustomMessageBoxLocation.CenterOfDashboard;
    protected CustomMessageBoxPanel _customMessageBoxPanel;
    protected CustomMessageBoxStyle _style;
    protected DontShowThisMessageAgainOptions _dontShowThisMessageAgainOption;
    protected bool _userGaveResponse;
    private IContainer components;

    public string Message
    {
      get
      {
        return this._message;
      }
      set
      {
        this._message = value;
        this._customMessageBoxPanel.UpdateTextControl();
      }
    }

    public CustomMessageBoxStyle Style
    {
      get
      {
        return this._style;
      }
    }

    public DontShowThisMessageAgainOptions DontShowThisMessageAgainOption
    {
      get
      {
        return this._dontShowThisMessageAgainOption;
      }
    }

    public bool UserGaveResponse
    {
      get
      {
        return this._userGaveResponse;
      }
      set
      {
        this._userGaveResponse = value;
      }
    }

    public CustomMessageBoxLocation LocationOfMessageBox
    {
      get
      {
        return this._customMessageBoxLocation;
      }
      set
      {
        this._customMessageBoxLocation = value;
      }
    }

    public CustomMessageBox(string message)
      : this(message, true)
    {
    }

    protected CustomMessageBox(string message, bool scaleControls)
    {
      this.Text = DashboardStringHelper.GetString("ShortenedApplicationCaption");
      this._message = message;
      this.InitializeComponent();
      int num = scaleControls ? 1 : 0;
    }

    public CustomMessageBox(string message, CustomMessageBoxStyle style)
      : this(message, style, true)
    {
    }

    protected CustomMessageBox(string message, CustomMessageBoxStyle style, bool scaleControls)
    {
      this.Text = DashboardStringHelper.GetString("ShortenedApplicationCaption");
      this._message = message;
      this._style = style;
      this.InitializeComponent();
      int num = scaleControls ? 1 : 0;
    }

    public CustomMessageBox(string message, CustomMessageBoxStyle style, DontShowThisMessageAgainOptions dontShowThisMessageAgainOption)
      : this(message, style, dontShowThisMessageAgainOption, true)
    {
    }

    protected CustomMessageBox(string message, CustomMessageBoxStyle style, DontShowThisMessageAgainOptions dontShowThisMessageAgainOption, bool scaleControls)
    {
      this.Text = DashboardStringHelper.GetString("ShortenedApplicationCaption");
      this._message = message;
      this._style = style;
      this._dontShowThisMessageAgainOption = dontShowThisMessageAgainOption;
      this.InitializeComponent();
      int num = scaleControls ? 1 : 0;
    }

    public CustomMessageBox(string title, string message, CustomMessageBoxStyle style)
      : this(title, message, style, true)
    {
    }

    protected CustomMessageBox(string title, string message, CustomMessageBoxStyle style, bool scaleControls)
    {
      this.Text = title;
      this._message = message;
      this._style = style;
      this.InitializeComponent();
      int num = scaleControls ? 1 : 0;
    }

    public void CustomShow(IWin32Window parent, bool showPopupOnlyIfPrimaryCUAndSDKReady)
    {
      if (showPopupOnlyIfPrimaryCUAndSDKReady && (!MediaHandler.TheMedia.WiMAXIsReady || !MediaHandler.IntelCUIsInControl))
        return;
      if (this.SetupControls())
      {
        if (this._customMessageBoxLocation == CustomMessageBoxLocation.CenterOfDashboardOrInTaskTrayOnTop || this._customMessageBoxLocation == CustomMessageBoxLocation.AlwaysInTaskTrayOnTop)
          UIHelper.ShowAsTopMostForm((Form) this);
        else
          UIHelper.ShowAsBottomMostForm((Form) this);
      }
      else if (parent == null)
        ((Control) this).Show();
      else
        this.Show(parent);
    }

    public DialogResult CustomShowDialog(IWin32Window parent, bool showPopupOnlyIfPrimaryCUAndSDKReady)
    {
      DialogResult dialogResult1 = DialogResult.OK;
      if (showPopupOnlyIfPrimaryCUAndSDKReady && (!MediaHandler.TheMedia.WiMAXIsReady || !MediaHandler.IntelCUIsInControl))
        return dialogResult1;
      bool flag = this.SetupControls();
      try
      {
        if (this._style == CustomMessageBoxStyle.YesNo || this._style == CustomMessageBoxStyle.YesNoCancel)
        {
          SystemSounds.Exclamation.Play();
        }
        else
        {
          if (this._style != CustomMessageBoxStyle.Ok)
          {
            if (this._style != CustomMessageBoxStyle.OkCancel)
              goto label_9;
          }
          SystemSounds.Asterisk.Play();
        }
      }
      catch (Exception ex)
      {
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Warning, (object) this, Logging.GetMessageForException(ex));
      }
label_9:
      DialogResult dialogResult2;
      if (flag)
      {
        UIHelper.ShowAsTopMostForm((Form) this);
        while (this.Visible)
        {
          Application.DoEvents();
          Thread.Sleep(100);
        }
        dialogResult2 = this.DialogResult;
      }
      else
        dialogResult2 = parent != null ? this.ShowDialog(parent) : this.ShowDialog();
      return dialogResult2;
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      if (!this._userGaveResponse)
      {
        if (this._style == CustomMessageBoxStyle.YesNo)
          this.DialogResult = DialogResult.No;
        else if (this._style == CustomMessageBoxStyle.YesRemindMeLater)
          this.DialogResult = DialogResult.No;
        else if (this._style == CustomMessageBoxStyle.YesNoCancel || this._style == CustomMessageBoxStyle.OkCancel)
          this.DialogResult = DialogResult.Cancel;
        else
          this.DialogResult = DialogResult.OK;
      }
      base.OnClosing(e);
    }

    protected override void OnCreateControl()
    {
      this._customMessageBoxPanel.AccessibleName = this.AccessibleName + "_Panel";
      base.OnCreateControl();
    }

    protected virtual void CustomInitializeComponents()
    {
      this.BackColor = CustomForm.FormBackColor;
      if (this._customMessageBoxPanel != null)
        this.Controls.Remove((Control) this._customMessageBoxPanel);
      this._customMessageBoxPanel = new CustomMessageBoxPanel(this);
      this._customMessageBoxPanel.Location = new Point(ImageHelper.Unscaled.FrameLeftPixel.Width, ImageHelper.Unscaled.FrameTopPixel.Height);
      this.Controls.Add((Control) this._customMessageBoxPanel);
      this.Size = new Size(this._customMessageBoxPanel.Width + ImageHelper.Unscaled.FrameLeftPixel.Width + ImageHelper.Unscaled.FrameRightPixel.Width, this._customMessageBoxPanel.Height + ImageHelper.Unscaled.FrameTopPixel.Height + ImageHelper.Unscaled.FrameBottomPixel.Height);
    }

    protected override void OnHandleCreated(EventArgs e)
    {
      base.OnHandleCreated(e);
      this.ScaleMe();
    }

    private bool SetupControls()
    {
      this.CustomInitializeComponents();
      if (this._customMessageBoxLocation == CustomMessageBoxLocation.AlwaysInTaskTrayBottom || this._customMessageBoxLocation == CustomMessageBoxLocation.AlwaysInTaskTrayOnTop || this._customMessageBoxLocation == CustomMessageBoxLocation.CenterOfDashboardOrInTaskTrayBottom && AppFramework.TaskTray.ShowPopupInTaskTray() || this._customMessageBoxLocation == CustomMessageBoxLocation.CenterOfDashboardOrInTaskTrayOnTop && AppFramework.TaskTray.ShowPopupInTaskTray())
      {
        if (this._style == CustomMessageBoxStyle.Ok)
          this.FormType = FormTypeEnum.TaskTrayWithCloseBtn;
        else
          this.FormType = FormTypeEnum.TaskTrayWithoutCloseBtn;
        this.StartPosition = FormStartPosition.Manual;
        this.Location = AppFramework.TaskTray.GetTaskTrayPopupLocation(DPIUtils.ScaleSize(this.Size));
        return true;
      }
      else
      {
        if (AppFramework.Dashboard != null && AppFramework.Dashboard.WindowState == FormWindowState.Minimized)
          AppFramework.Dashboard.WindowState = FormWindowState.Normal;
        AppFramework.Dashboard.BringToFront();
        this.FormType = FormTypeEnum.Dialog;
        if (AppFramework.Dashboard != null && AppFramework.Dashboard.Visible)
          this.StartPosition = FormStartPosition.CenterParent;
        else
          this.StartPosition = FormStartPosition.CenterScreen;
        return false;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (CustomMessageBox));
      this.SuspendLayout();
      this.AutoScaleMode = AutoScaleMode.Inherit;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.ForeColor = Color.Black;
      this.FormType = FormTypeEnum.Dialog;
      this.Name = "CustomMessageBox";
      this.ShowInTaskbar = false;
      this.ResumeLayout(false);
    }
  }
}
