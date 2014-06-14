// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.ConnectionDetailsStatus
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
  public class ConnectionDetailsStatus : UserControl
  {
    private Label StatusLbl;
    private PictureBox StatusImage;
    private Container components;
    private string _statusMessageToShow;
    private string _longOperationStatusMessageToShow;
    private bool _showLongOperationStatusMessage;
    private StatusImageEnum _statusImageToShow;
    private DetailsStatusAnimatedImage _detailsStatusAnimatedImage;
    private Timer _longOperationTimer;

    public string StatusMessageToShow
    {
      get
      {
        return this._statusMessageToShow;
      }
      set
      {
        this._statusMessageToShow = value;
        this.UpdateMessageText();
      }
    }

    public string LongOperationStatusMessageToShow
    {
      get
      {
        return this._longOperationStatusMessageToShow;
      }
      set
      {
        this._longOperationStatusMessageToShow = value;
        this.UpdateMessageText();
      }
    }

    public StatusImageEnum StatusImageToShow
    {
      get
      {
        return this._statusImageToShow;
      }
      set
      {
        if (value == this._statusImageToShow)
          return;
        this._statusImageToShow = value;
        this.UpdateStatusImage();
      }
    }

    public ConnectionDetailsStatus()
    {
      this.InitializeComponent();
      this._detailsStatusAnimatedImage = new DetailsStatusAnimatedImage(this.StatusImage);
      this.CustomInitializeComponents();
      this.RegisterForEvents();
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ConnectionDetailsStatus));
      this.StatusLbl = new Label();
      this.StatusImage = new PictureBox();
      this.StatusImage.BeginInit();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.StatusLbl, "StatusLbl");
      this.StatusLbl.Name = "StatusLbl";
      this.StatusImage.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.StatusImage, "StatusImage");
      this.StatusImage.Name = "StatusImage";
      this.StatusImage.TabStop = false;
      this.Controls.Add((Control) this.StatusImage);
      this.Controls.Add((Control) this.StatusLbl);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "ConnectionDetailsStatus";
      this.StatusImage.EndInit();
      this.ResumeLayout(false);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void OnLongOperationTimerTick(object sender, EventArgs e)
    {
      this._longOperationTimer.Stop();
      this._showLongOperationStatusMessage = true;
      this.UpdateMessageText();
    }

    public void OnStateChange(object sender, object[] eventArgs)
    {
      this._showLongOperationStatusMessage = false;
      if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForConnect)
        this._longOperationTimer.Start();
      else
        this._longOperationTimer.Stop();
    }

    private void CustomInitializeComponents()
    {
      this.AccessibleName = "ConnectionDetailsStatus";
      this.StatusLbl.AccessibleName = "ConnectionDetailsPanel_ConnectionDetailsStatus_StatusLbl";
      this.StatusImage.AccessibleName = "ConnectionPanel_ConnectionDetailsStatus_StatusImage";
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.BackColor = Color.Transparent;
      this.StatusLbl.BackColor = Color.Transparent;
      this._longOperationTimer = new Timer();
      this._longOperationTimer.Interval = TimerSettings.ConnectionDetailsStatus_LongOperationTimer_Interval;
      this._longOperationTimer.Tick += new EventHandler(this.OnLongOperationTimerTick);
    }

    private void UpdateStatusImage()
    {
      switch (this._statusImageToShow)
      {
        case StatusImageEnum.Connecting:
        case StatusImageEnum.Searching:
          if (this._statusImageToShow == StatusImageEnum.None)
          {
            this.StatusImage.Visible = false;
            this.StatusLbl.BringToFront();
            this.StatusLbl.Location = new Point(this.StatusImage.Location.X, this.StatusLbl.Location.Y);
            break;
          }
          else
          {
            this.StatusImage.Visible = true;
            this.StatusLbl.Location = new Point(this.StatusImage.Location.X + this.StatusImage.Size.Width + 10, this.StatusLbl.Location.Y);
            break;
          }
        case StatusImageEnum.Application:
          this.StatusImage.Image = (Image) ImageHelper.WiMAXApplicationLargeIcon;
          goto case StatusImageEnum.Connecting;
        default:
          this.StatusImage.Image = (Image) null;
          goto case StatusImageEnum.Connecting;
      }
    }

    private void RegisterForEvents()
    {
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnStateChange), (object) this, "WiMAXUI.OnStateChange");
    }

    private void UpdateMessageText()
    {
      if (this._showLongOperationStatusMessage && !string.IsNullOrEmpty(this._longOperationStatusMessageToShow))
        this.StatusLbl.Text = this._longOperationStatusMessageToShow;
      else
        this.StatusLbl.Text = this._statusMessageToShow;
    }
  }
}
