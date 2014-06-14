// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.SplashScreen
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.SDKInterop;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class SplashScreen : Form
  {
    private static SplashScreen _splashScreen = (SplashScreen) null;
    private static Thread _splashThread = (Thread) null;
    private static long _minimumDisplayTime = new TimeSpan(0, 0, 0, 3, 500).Ticks;
    private double _opacityIncrement = 0.05;
    private double _opacityDecrement = 0.1;
    private IContainer components;
    private System.Windows.Forms.Timer OpacityTimer;
    private static DateTime _timeSplashScreenShown;

    static SplashScreen()
    {
    }

    public SplashScreen()
    {
      this.InitializeComponent();
      try
      {
        this.Opacity = 0.0;
      }
      catch (Exception ex)
      {
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Warning, (object) this, Logging.GetMessageForException(ex));
      }
      this.OpacityTimer.Interval = TimerSettings.SplashScreen_OpacityTimer_Interval;
      this.BackgroundImage = (Image) ScalingUtils.ScaleBitmap(this.BackgroundImage);
      this.ClientSize = this.BackgroundImage.Size;
      this.OpacityTimer.Start();
      this.OpacityTimer.Tick += new EventHandler(this.OnOpacityTick);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (SplashScreen));
      this.OpacityTimer = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      this.AutoScaleMode = AutoScaleMode.Inherit;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.ControlBox = false;
      this.FormBorderStyle = FormBorderStyle.None;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SplashScreen";
      this.ShowInTaskbar = false;
      this.SizeGripStyle = SizeGripStyle.Hide;
      this.ResumeLayout(false);
    }

    private void OnOpacityTick(object sender, EventArgs e)
    {
      try
      {
        if (this._opacityIncrement > 0.0)
        {
          if (this.Opacity >= 1.0)
            return;
          SplashScreen splashScreen = this;
          double num = splashScreen.Opacity + this._opacityIncrement;
          splashScreen.Opacity = num;
        }
        else if (this.Opacity > 0.0)
        {
          SplashScreen splashScreen = this;
          double num = splashScreen.Opacity + this._opacityIncrement;
          splashScreen.Opacity = num;
        }
        else
        {
          this.OpacityTimer.Stop();
          this.Close();
        }
      }
      catch (Exception ex)
      {
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Warning, (object) this, Logging.GetMessageForException(ex));
        this.Close();
      }
    }

    public static void ShowSplashScreen()
    {
      SplashScreen._timeSplashScreenShown = DateTime.Now;
      if (SplashScreen._splashScreen != null)
        return;
      SplashScreen._splashThread = new Thread(new ThreadStart(SplashScreen.ShowForm));
      SplashScreen._splashThread.IsBackground = true;
      SplashScreen._splashThread.SetApartmentState(ApartmentState.STA);
      SplashScreen._splashThread.Start();
    }

    public static TimeSpan GetSleepTime()
    {
      if (DateTime.Now.Ticks - SplashScreen._timeSplashScreenShown.Ticks < SplashScreen._minimumDisplayTime)
        return new TimeSpan(SplashScreen._minimumDisplayTime - (DateTime.Now.Ticks - SplashScreen._timeSplashScreenShown.Ticks));
      else
        return new TimeSpan(0L);
    }

    public static void CloseForm()
    {
      if (SplashScreen._splashScreen != null)
        SplashScreen._splashScreen._opacityIncrement = -SplashScreen._splashScreen._opacityDecrement;
      SplashScreen._splashThread = (Thread) null;
      SplashScreen._splashScreen = (SplashScreen) null;
    }

    private static void ShowForm()
    {
      SplashScreen._splashScreen = new SplashScreen();
      Application.Run((Form) SplashScreen._splashScreen);
    }
  }
}
