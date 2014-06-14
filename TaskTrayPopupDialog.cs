// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.TaskTrayPopupDialog
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.SDKInterop;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class TaskTrayPopupDialog : CustomForm
  {
    protected TaskTrayPopupClickOptions _clickOption = TaskTrayPopupClickOptions.LaunchDashboard;
    protected bool _allowPopupToBeSuperceded = true;
    private static TaskTrayPopupDialog _instance = new TaskTrayPopupDialog();
    private IContainer components;
    private Timer FadePopupInTimer;
    private Timer FadePopupOutTimer;
    private Timer ClosePopupTimer;

    public static TaskTrayPopupDialog Singleton
    {
      get
      {
        return TaskTrayPopupDialog._instance;
      }
    }

    public TaskTrayPopupClickOptions TaskTrayPopupClickOption
    {
      get
      {
        return this._clickOption;
      }
    }

    static TaskTrayPopupDialog()
    {
      TaskTrayPopupDialog._instance.CreateHandle();
    }

    public TaskTrayPopupDialog()
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
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TaskTrayPopupDialog));
      this.FadePopupInTimer = new Timer(this.components);
      this.ClosePopupTimer = new Timer(this.components);
      this.FadePopupOutTimer = new Timer(this.components);
      this.SuspendLayout();
      this.FadePopupInTimer.Enabled = false;
      this.FadePopupInTimer.Interval = 7;
      this.FadePopupOutTimer.Enabled = false;
      this.FadePopupOutTimer.Interval = 7;
      this.ClosePopupTimer.Enabled = false;
      this.ClosePopupTimer.Interval = 5500;
      this.AutoScaleMode = AutoScaleMode.Inherit;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.ForeColor = Color.Black;
      this.FormType = FormTypeEnum.TaskTrayWithCloseBtn;
      this.Name = "TaskTrayPopupDialog";
      this.ShowInTaskbar = false;
      this.ResumeLayout(false);
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      FormClosingEventArgs closingEventArgs = e as FormClosingEventArgs;
      if (closingEventArgs == null || CloseReason.UserClosing == closingEventArgs.CloseReason)
      {
        e.Cancel = true;
        this.HidePopup();
      }
      base.OnClosing(e);
    }

    public void ShowPopup(string message, TaskTrayPopupClickOptions clickOption, bool allowPopupToBeSuperceded, bool popupShouldBeVisibleForExtraLongTime)
    {
      if (this.InvokeRequired || this.IsDisposed || !this.IsHandleCreated)
        return;
      if (this.Visible)
      {
        if (!this._allowPopupToBeSuperceded)
          return;
        this.HidePopup();
      }
      this._clickOption = clickOption;
      this._allowPopupToBeSuperceded = allowPopupToBeSuperceded;
      if (this.ClosePopupTimer != null)
        this.ClosePopupTimer.Interval = !popupShouldBeVisibleForExtraLongTime ? TimerSettings.TaskTrayPopupDialog_ClosePopupTimer_NormalInterval : TimerSettings.TaskTrayPopupDialog_ClosePopupTimer_LongInterval;
      this.Controls.Clear();
      TaskTrayBalloonPanel trayBalloonPanel = new TaskTrayBalloonPanel(message);
      trayBalloonPanel.Location = new Point(ImageHelper.Unscaled.FrameLeftPixel.Width, ImageHelper.Unscaled.FrameTopPixel.Height);
      this.Controls.Add((Control) trayBalloonPanel);
      this.Size = new Size(trayBalloonPanel.Width + ImageHelper.Unscaled.FrameLeftPixel.Width + ImageHelper.Unscaled.FrameRightPixel.Width, trayBalloonPanel.Height + ImageHelper.Unscaled.FrameTopPixel.Height + ImageHelper.Unscaled.FrameBottomPixel.Height);
      this.Location = AppFramework.TaskTray.GetTaskTrayPopupLocation(DPIUtils.ScaleSize(this.Size));
      this.ScaleMe();
      try
      {
        this.Opacity = 0.0;
      }
      catch (Exception ex)
      {
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Warning, (object) this, Logging.GetMessageForException(ex));
        this.HidePopup();
        return;
      }
      UIHelper.ShowAsTopMostForm((Form) this);
      try
      {
        if (File.Exists("C:\\Windows\\Media\\Windows XP Balloon.wav"))
          new SoundPlayer("C:\\Windows\\Media\\Windows XP Balloon.wav").Play();
        else if (File.Exists("C:\\Windows\\Media\\Windows Balloon.wav"))
          new SoundPlayer("C:\\Windows\\Media\\Windows Balloon.wav").Play();
      }
      catch (Exception ex)
      {
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Warning, (object) this, Logging.GetMessageForException(ex));
      }
      this.FadePopupInTimer.Start();
    }

    public void HidePopup()
    {
      this.FadePopupInTimer.Stop();
      this.FadePopupOutTimer.Stop();
      this.ClosePopupTimer.Stop();
      this.Hide();
    }

    private void OnMouseLeave(object sender, EventArgs e)
    {
      this.FadePopupOutTimer.Start();
    }

    private void OnClosePopupTimerTick(object sender, EventArgs e)
    {
      this.ClosePopupTimer.Stop();
      this.FadePopupOutTimer.Start();
    }

    private void OnFadePopupInTimerTick(object sender, EventArgs e)
    {
      try
      {
        TaskTrayPopupDialog taskTrayPopupDialog = this;
        double num = taskTrayPopupDialog.Opacity + 0.02;
        taskTrayPopupDialog.Opacity = num;
        if (this.Opacity < 1.0)
          return;
        this.FadePopupInTimer.Stop();
        this.ClosePopupTimer.Start();
      }
      catch (Exception ex)
      {
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Warning, (object) this, Logging.GetMessageForException(ex));
        this.HidePopup();
      }
    }

    private void OnFadePopupOutTimerTick(object sender, EventArgs e)
    {
      try
      {
        this.MouseLeave -= new EventHandler(this.OnMouseLeave);
        if (this.ClientRectangle.Contains(this.PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y))))
        {
          this.FadePopupOutTimer.Stop();
          this.Opacity = 1.0;
          this.MouseLeave += new EventHandler(this.OnMouseLeave);
        }
        else
        {
          TaskTrayPopupDialog taskTrayPopupDialog = this;
          double num = taskTrayPopupDialog.Opacity - 0.02;
          taskTrayPopupDialog.Opacity = num;
          if (this.Opacity > 0.0)
            return;
          this.FadePopupOutTimer.Stop();
          this.HidePopup();
        }
      }
      catch (Exception ex)
      {
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Warning, (object) this, Logging.GetMessageForException(ex));
        this.HidePopup();
      }
    }

    private void CustomInitializeComponents()
    {
      this.UseIconAndTitleGraphic = false;
      this.Text = DashboardStringHelper.GetString("ShortenedApplicationCaption");
      this.BackColor = CustomForm.FormBackColor;
      this.ClosePopupTimer.Tick += new EventHandler(this.OnClosePopupTimerTick);
      this.ClosePopupTimer.Interval = TimerSettings.TaskTrayPopupDialog_ClosePopupTimer_NormalInterval;
      this.FadePopupInTimer.Tick += new EventHandler(this.OnFadePopupInTimerTick);
      this.FadePopupInTimer.Interval = TimerSettings.TaskTrayPopupDialog_FadePopupInTimer_Interval;
      this.FadePopupOutTimer.Tick += new EventHandler(this.OnFadePopupOutTimerTick);
      this.FadePopupOutTimer.Interval = TimerSettings.TaskTrayPopupDialog_FadePopupOutTimer_Interval;
    }
  }
}
