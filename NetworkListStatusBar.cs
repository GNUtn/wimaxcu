// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.NetworkListStatusBar
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.Common;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class NetworkListStatusBar : UserControl
  {
    private string _textToDisplay = "";
    private bool _showProgressIndication = true;
    private IContainer components;
    private PictureBox StatusBar_Image;
    private StatusBarAnimatedImage _statusBarAnimatedImage;
    private static int _scanPercentComplete;

    public static int ScanPercentComplete
    {
      get
      {
        return NetworkListStatusBar._scanPercentComplete;
      }
      set
      {
        NetworkListStatusBar._scanPercentComplete = value;
      }
    }

    public NetworkListStatusBar()
    {
      this.InitializeComponent();
      this.AccessibleName = "NetworkListStatusBar";
      this.StatusBar_Image.AccessibleName = "NetworkListPanel_NetworkListStatusBar_StatusBarImage";
      this._statusBarAnimatedImage = new StatusBarAnimatedImage(this.StatusBar_Image);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (NetworkListStatusBar));
      this.StatusBar_Image = new PictureBox();
      this.StatusBar_Image.BeginInit();
      this.SuspendLayout();
      this.StatusBar_Image.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.StatusBar_Image, "StatusBar_Image");
      this.StatusBar_Image.Name = "StatusBar_Image";
      this.StatusBar_Image.TabStop = false;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Inherit;
      this.BackColor = Color.WhiteSmoke;
      this.Controls.Add((Control) this.StatusBar_Image);
      this.Name = "StatusBar";
      this.StatusBar_Image.EndInit();
      this.ResumeLayout(false);
    }

    public void InitPanel()
    {
      this._showProgressIndication = true;
      NetworkListStatusBar._scanPercentComplete = 0;
      this._textToDisplay = "";
      this.Invalidate();
      this.RegisterForEvents();
    }

    public void ResetProgressBar()
    {
      NetworkListStatusBar._scanPercentComplete = 0;
      this.GetSearchText();
      this.Invalidate();
    }

    public void Cleanup()
    {
      this.UnregisterForEvents();
    }

    protected override void OnLoad(EventArgs e)
    {
      this.UpdateUI(new object[1]
      {
        (object) Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.WmxNetworkBeingConnected
      });
      base.OnLoad(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      ControlPaint.DrawBorder(e.Graphics, new Rectangle(0, 0, this.Width, this.Height), Color.FromArgb(204, 204, 204), ButtonBorderStyle.Solid);
      if (this._showProgressIndication)
      {
        float num = (float) this.Width * ((float) NetworkListStatusBar._scanPercentComplete / 100f);
        if ((double) num > (double) this.Width)
          num = (float) this.Width;
        float width = num - 4f;
        using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(81, 149, 217)))
          e.Graphics.FillRectangle((Brush) solidBrush, 2f, 2f, width, (float) (this.Height - 4));
      }
      if (!string.IsNullOrEmpty(this._textToDisplay))
      {
        int num1 = this.StatusBar_Image.Location.X + this.StatusBar_Image.Width + 3;
        if (!this.StatusBar_Image.Visible)
          num1 = this.StatusBar_Image.Location.X;
        int num2 = (int) e.Graphics.MeasureString(this._textToDisplay, this.Font).Height;
        using (SolidBrush solidBrush = new SolidBrush(Color.Black))
          e.Graphics.DrawString(this._textToDisplay, this.Font, (Brush) solidBrush, (float) num1, (float) ((this.Height - num2) / 2));
      }
      base.OnPaint(e);
    }

    public void OnStateChange(object sender, object[] eventArgs)
    {
      this.UpdateUI(eventArgs);
    }

    public void OnScanProgress(object sender, object[] eventArgs)
    {
      if (eventArgs.Length <= 0 || !Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForScan)
        return;
      NetworkListStatusBar._scanPercentComplete = Convert.ToInt32(eventArgs[0]);
      this.GetSearchText();
      this.Invalidate();
    }

    private void RegisterForEvents()
    {
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnStateChange), (object) this, "WiMAXUI.OnStateChange");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnScanProgress), (object) this, "WiMAXUI.OnScanProgress");
    }

    private void UnregisterForEvents()
    {
      Eventing.DeRegisterAllUIEvents((object) this);
    }

    private void UpdateUI(object[] eventArgs)
    {
      if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForScan)
      {
        this._showProgressIndication = true;
        this.GetSearchText();
        this.StatusBar_Image.Visible = true;
      }
      else
      {
        this._showProgressIndication = false;
        this._textToDisplay = "";
        this.StatusBar_Image.Visible = false;
      }
      this.Invalidate();
    }

    private void GetSearchText()
    {
      string profileDisplayName = DashboardAndTaskTray.GetPreferredProfileDisplayName();
      if (!string.IsNullOrEmpty(profileDisplayName) && !Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForManualWideScan)
      {
        this._textToDisplay = string.Format(DashboardStringHelper.GetString("Dashboard_SearchingForX"), (object) profileDisplayName);
      }
      else
      {
        if (AppFramework.TaskTray != null)
          AppFramework.TaskTray.UpdateTooltip((object) null);
        this._textToDisplay = string.Format(DashboardStringHelper.GetString("SearchingForNetworksPercentCompleteEllipse"), (object) NetworkListStatusBar._scanPercentComplete);
      }
    }
  }
}
