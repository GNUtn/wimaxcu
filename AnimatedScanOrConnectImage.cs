// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.AnimatedScanOrConnectImage
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.SDKInterop;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public abstract class AnimatedScanOrConnectImage
  {
    private Timer _timer;

    public AnimatedScanOrConnectImage()
    {
      this.RegisterForEvents();
    }

    public virtual void AssignImage(Icon ico)
    {
    }

    public virtual void AssignImage(Bitmap newImage)
    {
    }

    private void OnTimerTick(object data)
    {
      if (this._timer == null)
        return;
      try
      {
        AnimatedImageInfo animatedImageInfo = (AnimatedImageInfo) data;
        this.AssignImage(animatedImageInfo.Icons[animatedImageInfo.CurrentIconIndex]);
        this.AssignImage(animatedImageInfo.Bitmaps[animatedImageInfo.CurrentBitmapIndex]);
        ++animatedImageInfo.CurrentIconIndex;
        if (animatedImageInfo.CurrentIconIndex >= animatedImageInfo.Icons.Count)
          animatedImageInfo.CurrentIconIndex = 0;
        ++animatedImageInfo.CurrentBitmapIndex;
        if (animatedImageInfo.CurrentBitmapIndex < animatedImageInfo.Bitmaps.Count)
          return;
        animatedImageInfo.CurrentBitmapIndex = 0;
      }
      catch (Exception ex)
      {
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Warning, (object) this, Logging.GetMessageForException(ex));
      }
    }

    private void OnSomethingChanged(object sender, object[] eventArgs)
    {
      if (MediaHandler.TheMedia.WiMAXIsReady && MediaHandler.IntelCUIsInControl && AdapterHandler.TheAdapter.RadioIsOn() && (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForConnect || Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForScan || (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForStopScan || Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForStopConnect)))
        this.StartAnimation();
      else
        this.StopAnimation();
    }

    private void RegisterForEvents()
    {
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnSomethingChanged), (object) this, "WiMAXUI.OnStateChange");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnSomethingChanged), (object) this, "WiMAXUI.OnIntelCUControlChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnSomethingChanged), (object) this, "WiMAXUI.OnMediaStatusChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnSomethingChanged), (object) this, "WiMAXUI.OnAdapterListChanged");
    }

    private void StartAnimation()
    {
      try
      {
        this.StopAnimation();
        if (this._timer != null)
          return;
        int period = TimerSettings.AnimatedScanOrConnectImageDefault_Timer_Period;
        AnimatedImageInfo animatedImageInfo = new AnimatedImageInfo();
        if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForScan)
        {
          animatedImageInfo.Icons = ImageHelper.TraySearchingIcons;
          animatedImageInfo.Bitmaps = ImageHelper.SearchingLargeIcons;
          period = TimerSettings.AnimatedScanOrConnectImageScan_Timer_Period;
        }
        else if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForConnect)
        {
          animatedImageInfo.Icons = ImageHelper.TrayConnectingIcons;
          animatedImageInfo.Bitmaps = ImageHelper.ConnectingLargeIcons;
          period = TimerSettings.AnimatedScanOrConnectImageConnect_Timer_Period;
        }
        else if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForStopScan || Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForStopConnect)
        {
          List<Icon> list1 = new List<Icon>();
          list1.Add(ImageHelper.TrayWiMAXAppIco);
          List<Bitmap> list2 = new List<Bitmap>();
          list2.Add(ImageHelper.WiMAXApplicationLargeIcon);
          animatedImageInfo.Icons = list1;
          animatedImageInfo.Bitmaps = list2;
          period = TimerSettings.AnimatedScanOrConnectImageStopScan_Timer_Period;
        }
        this._timer = new Timer(new TimerCallback(this.OnTimerTick), (object) animatedImageInfo, TimerSettings.AnimatedScanOrConnectImage_Timer_DueTime, period);
      }
      catch (Exception ex)
      {
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Warning, (object) this, Logging.GetMessageForException(ex));
      }
    }

    private void StopAnimation()
    {
      try
      {
        if (this._timer != null)
        {
          this._timer.Change(-1, -1);
          this._timer.Dispose();
          this._timer = (Timer) null;
        }
        AppFramework.TaskTray.UpdateUI();
      }
      catch (Exception ex)
      {
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Warning, (object) this, Logging.GetMessageForException(ex));
      }
    }
  }
}
