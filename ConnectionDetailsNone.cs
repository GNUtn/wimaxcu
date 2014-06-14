// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.ConnectionDetailsNone
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using Intel.Mobile.WiMAXCU.UI.DisplayWiMAX;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class ConnectionDetailsNone : UserControl
  {
    private LinkLabel LinkLabelTop;
    private PictureBox NotConnectedLargeIcon;
    private Container components;
    private Point _origIconLocation;
    private Point _origLinkLabelLocation;
    private LinkLabel LinkLabelBottom;
    private bool _doCustomPaint;

    public ConnectionDetailsNone()
    {
      this.InitializeComponent();
      this.CustomInitializeComponents();
      this.RegisterForEvents();
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ConnectionDetailsNone));
      this.LinkLabelTop = new LinkLabel();
      this.NotConnectedLargeIcon = new PictureBox();
      this.LinkLabelBottom = new LinkLabel();
      this.NotConnectedLargeIcon.BeginInit();
      this.SuspendLayout();
      this.LinkLabelTop.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.LinkLabelTop, "LinkLabelTop");
      this.LinkLabelTop.ForeColor = Color.Black;
      this.LinkLabelTop.Name = "LinkLabelTop";
      this.LinkLabelTop.TabStop = true;
      this.NotConnectedLargeIcon.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.NotConnectedLargeIcon, "NotConnectedLargeIcon");
      this.NotConnectedLargeIcon.Name = "NotConnectedLargeIcon";
      this.NotConnectedLargeIcon.TabStop = false;
      this.LinkLabelBottom.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.LinkLabelBottom, "LinkLabelBottom");
      this.LinkLabelBottom.ForeColor = Color.Black;
      this.LinkLabelBottom.Name = "LinkLabelBottom";
      this.LinkLabelBottom.TabStop = true;
      this.BackColor = Color.Transparent;
      this.Controls.Add((Control) this.LinkLabelBottom);
      this.Controls.Add((Control) this.NotConnectedLargeIcon);
      this.Controls.Add((Control) this.LinkLabelTop);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "ConnectionDetailsNone";
      this.NotConnectedLargeIcon.EndInit();
      this.ResumeLayout(false);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (this.components != null)
          this.components.Dispose();
        Eventing.DeRegisterAllUIEvents((object) this);
      }
      base.Dispose(disposing);
    }

    public void OnAvailableNetworkListSelectionChanged(object sender, object[] eventArgs)
    {
      this.UpdateUI();
      this.Invalidate();
    }

    private void OnNetworkListChanged(object sender, object[] eventArgs)
    {
      this.UpdateUI();
      if (!this._doCustomPaint)
        return;
      this.Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (!this._doCustomPaint)
        return;
      NetworkDisplayItem networkDisplayItem = !AppFramework.Dashboard.Expanded ? NetworkHandler.Singleton.GetNetworkForPreferredProfile() : this.GetSelectedNDI();
      if (networkDisplayItem == null || this.LinkLabelTop == null)
        return;
      string text = this.LinkLabelTop.Text;
      int num1 = SizeHelper.MeasureDisplayStringWidth(e.Graphics, text, this.LinkLabelTop.Font) + 12;
      double num2 = (double) e.Graphics.MeasureString(text, this.LinkLabelTop.Font).Height;
      int num3 = 1;
      if (num1 > this.LinkLabelTop.Width)
      {
        num3 = num1 / this.LinkLabelTop.Width;
        if (num1 % this.LinkLabelTop.Width > 0)
          ++num3;
      }
      int x = this.LinkLabelTop.Location.X;
      int y = 0;
      if (num3 == 1)
        y = 18;
      else if (num3 == 2)
        y = 36;
      int num4 = DPIUtils.ScaleY(y);
      using (SolidBrush solidBrush = new SolidBrush(this.LinkLabelTop.ForeColor))
      {
        string @string = DashboardStringHelper.GetString("SignalColon");
        e.Graphics.DrawString(@string, this.LinkLabelTop.Font, (Brush) solidBrush, (float) x, (float) num4);
        x += SizeHelper.MeasureDisplayStringWidth(e.Graphics, @string, this.LinkLabelTop.Font) + 3;
      }
      Bitmap smallSignalIcon = WiMAXDisplayService.Singleton.GetSmallSignalIcon(networkDisplayItem.WmxNetwork.SignalBars);
      Point[] destPoints = new Point[3]
      {
        new Point(x, num4 + 1),
        new Point(x + smallSignalIcon.Width, num4 + 1),
        new Point(x, num4 + smallSignalIcon.Height + 1)
      };
      e.Graphics.DrawImage((Image) smallSignalIcon, destPoints);
      int num5 = x + (smallSignalIcon.Width + 4);
      using (SolidBrush solidBrush = new SolidBrush(this.LinkLabelTop.ForeColor))
      {
        string s = string.Format(DashboardStringHelper.GetString("SignalValue"), (object) WiMAXDisplayService.Singleton.GetSignalDisplayText(networkDisplayItem.WmxNetwork.SignalBars));
        e.Graphics.DrawString(s, this.LinkLabelTop.Font, (Brush) solidBrush, (float) num5, (float) num4);
      }
    }

    public void UpdateUI()
    {
      this._doCustomPaint = false;
      if (this.LinkLabelTop.Links.Count > 0)
        this.LinkLabelTop.Links.Clear();
      if (this.LinkLabelBottom.Links.Count > 0)
        this.LinkLabelBottom.Links.Clear();
      this.TabStop = false;
      this.LinkLabelTop.TabStop = false;
      this.LinkLabelBottom.TabStop = false;
      this.GetSelectedNDI();
      string profileDisplayName = DashboardAndTaskTray.GetPreferredProfileDisplayName();
      NetworkDisplayItem preferredProfile = NetworkHandler.Singleton.GetNetworkForPreferredProfile();
      if (!AppHandler.InitApplicationCalled)
      {
        this.LinkLabelTop.Text = DashboardStringHelper.GetString("Dashboard_InitializingApplication");
        this.LinkLabelBottom.Text = "";
        this.NotConnectedLargeIcon.Image = (Image) ImageHelper.WiMAXApplicationLargeIcon;
      }
      else if (!MediaHandler.IntelCUIsInControl)
      {
        this.LinkLabelTop.Text = DashboardStringHelper.GetString("Dashboard_NotPrimaryCU");
        this.LinkLabelBottom.Text = "";
        this.NotConnectedLargeIcon.Image = (Image) ImageHelper.WiMAXProblemLargeIcon;
      }
      else if (!MediaHandler.TheMedia.WiMAXIsReady)
      {
        if (MediaHandler.ResumingFromSleep)
        {
          this.LinkLabelTop.Text = DashboardStringHelper.GetString("Dashboard_WaitingForWiMAX");
          this.LinkLabelBottom.Text = "";
          this.NotConnectedLargeIcon.Image = (Image) ImageHelper.WiMAXApplicationLargeIcon;
        }
        else
        {
          this.LinkLabelTop.Text = DashboardStringHelper.GetString("Dashboard_WiMAXNotReady");
          this.LinkLabelBottom.Text = "";
          this.NotConnectedLargeIcon.Image = (Image) ImageHelper.WiMAXProblemLargeIcon;
        }
      }
      else if (!AdapterHandler.TheAdapter.HardwareRadioOn)
      {
        this.LinkLabelTop.Text = DashboardStringHelper.GetString("Dashboard_HardwareRadioOff");
        this.LinkLabelBottom.Text = "";
        this.NotConnectedLargeIcon.Image = (Image) ImageHelper.WiMAXOffLargeIcon;
      }
      else if (!AdapterHandler.TheAdapter.SoftwareRadioOn)
      {
        this.LinkLabelTop.Text = DashboardStringHelper.GetString("Dashboard_SoftwareRadioOff");
        this.LinkLabelBottom.Text = "";
        this.NotConnectedLargeIcon.Image = (Image) ImageHelper.WiMAXOffLargeIcon;
      }
      else if (!AppFramework.Dashboard.Expanded)
      {
        if (preferredProfile == null)
        {
          this.LinkLabelTop.Text = string.Format(DashboardStringHelper.GetString("DashboardCollapsed_PreferredProfileNotAvailable"), (object) profileDisplayName);
          this.LinkLabelBottom.Text = "";
          this.NotConnectedLargeIcon.Image = (Image) ImageHelper.WiMAXNotAvailableLargeIcon;
        }
        else
        {
          this._doCustomPaint = true;
          this.LinkLabelTop.Text = string.Format(DashboardStringHelper.GetString("DashboardCollapsed_PreferredProfileAvailable_Top"), (object) profileDisplayName);
          this.LinkLabelBottom.Text = string.Format(DashboardStringHelper.GetString("DashboardCollapsed_PreferredProfileAvailable_Bottom"), (object) profileDisplayName);
          this.NotConnectedLargeIcon.Image = (Image) ImageHelper.WiMAXAvailableLargeIcon;
        }
      }
      else
      {
        this.NotConnectedLargeIcon.Image = NetworkHandler.AvailableNetworks.Count != 0 ? (Image) ImageHelper.WiMAXAvailableLargeIcon : (Image) ImageHelper.WiMAXNotAvailableLargeIcon;
        this.LinkLabelBottom.Text = "";
        if (ApplicationState.Singleton.BlockedForScan)
        {
          if (NetworkHandler.AvailableNetworks.Count == 0)
          {
            if (string.IsNullOrEmpty(profileDisplayName) || ApplicationState.Singleton.BlockedForManualWideScan)
              this.LinkLabelTop.Text = DashboardStringHelper.GetString("Dashboard_BlockedForScan_NoNetworksAvail");
            else
              this.LinkLabelTop.Text = string.Format(DashboardStringHelper.GetString("Dashboard_BlockedForScan_PreferredProfileNotAvail"), (object) profileDisplayName);
          }
          else
            this.LinkLabelTop.Text = DashboardStringHelper.GetString("Dashboard_BlockedForScan_NetworksAvail");
        }
        else if (string.IsNullOrEmpty(profileDisplayName))
        {
          if (NetworkHandler.AvailableNetworks.Count > 0)
            this.LinkLabelTop.Text = DashboardStringHelper.GetString("DashboardExpanded_NoPreferredProfile_NetworksAvail");
          else
            this.LinkLabelTop.Text = DashboardStringHelper.GetString("DashboardExpanded_NoPreferredProfile_NoNetworksAvail");
        }
        else if (NetworkHandler.AvailableNetworks.Count == 0)
          this.LinkLabelTop.Text = string.Format(DashboardStringHelper.GetString("DashboardExpanded_PreferredProfileNotAvailable"), (object) profileDisplayName);
        else
          this.LinkLabelTop.Text = string.Format(DashboardStringHelper.GetString("DashboardExpanded_PreferredProfileAvailable"), (object) profileDisplayName);
      }
      if (string.IsNullOrEmpty(this.LinkLabelBottom.Text))
      {
        this.LinkLabelTop.Height = DPIUtils.ScaleY(91);
        this.LinkLabelTop.TextAlign = ContentAlignment.MiddleLeft;
        this.LinkLabelBottom.SendToBack();
      }
      else
      {
        this.LinkLabelTop.Height = DPIUtils.ScaleY(45);
        this.LinkLabelTop.TextAlign = ContentAlignment.TopLeft;
        this.LinkLabelBottom.SendToBack();
      }
      this.NotConnectedLargeIcon.Size = new Size(this.NotConnectedLargeIcon.Image.Width, this.NotConnectedLargeIcon.Image.Height);
    }

    private void CustomInitializeComponents()
    {
      this.AccessibleName = "ConnectionDetailsNone";
      this.NotConnectedLargeIcon.AccessibleName = "ConnectionDetailsPanel_ConnectionDetailsNone_NotConnectedLargeIcon";
      this.LinkLabelBottom.AccessibleName = "ConnectionPanel_ConnectionDetailsNone_LinkLabelBottom";
      this.LinkLabelTop.AccessibleName = "ConnectionPanel_ConnectionDetailsNone_LinkLabelTop";
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.BackColor = Color.Transparent;
      this.LinkLabelTop.BackColor = Color.Transparent;
      this._origIconLocation = this.NotConnectedLargeIcon.Location;
      this._origLinkLabelLocation = this.LinkLabelTop.Location;
    }

    private void RegisterForEvents()
    {
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnAvailableNetworkListSelectionChanged), (object) this, "WiMAXUI.OnAvailableNetworkListSelectionChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnNetworkListChanged), (object) this, "WiMAXUI.OnNetworkListChanged");
    }

    private NetworkDisplayItem GetSelectedNDI()
    {
      NetworkDisplayItem networkDisplayItem = (NetworkDisplayItem) null;
      if (AppFramework.Dashboard != null && AppFramework.Dashboard.TheNetworkListPanel != null && AppFramework.Dashboard.TheNetworkListPanel.TheNetworkListBox != null)
        networkDisplayItem = AppFramework.Dashboard.TheNetworkListPanel.TheNetworkListBox.GetSelectedNDI();
      else if (NetworkHandler.AvailableNetworks.Count > 0)
        networkDisplayItem = NetworkHandler.AvailableNetworks[0];
      return networkDisplayItem;
    }

    private enum IconPosition
    {
      Left,
      Right,
    }
  }
}
