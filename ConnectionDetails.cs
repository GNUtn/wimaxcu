// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.ConnectionDetails
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
  public class ConnectionDetails : UserControl
  {
    private ToolTip _signalIconTooltip = new ToolTip();
    private Size unscaledNetworkDetailsBottomPanelSize = Size.Empty;
    private Size unscaledNetworkDetailsTopPanelSize = Size.Empty;
    private TransparentPictureBox SignalIcon;
    private TransparentPictureBox ConnectedIcon;
    private Panel NetworkDetailsPanel;
    private Panel NetworkDetailsTopPanel;
    private Label TopPanel_ConnectedToLbl;
    private Label TopPanel_NetworkNameLbl;
    private Panel NetworkDetailsBottomPanel;
    private LinkLabel BottomPanel_LinkLabel;
    private IContainer components;

    public ConnectionDetails()
    {
      this.InitializeComponent();
      this.CustomInitializeComponents();
      this.unscaledNetworkDetailsBottomPanelSize = this.NetworkDetailsBottomPanel.Size;
      this.unscaledNetworkDetailsTopPanelSize = this.NetworkDetailsTopPanel.Size;
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ConnectionDetails));
      this.ConnectedIcon = new TransparentPictureBox();
      this.SignalIcon = new TransparentPictureBox();
      this.NetworkDetailsPanel = new Panel();
      this.NetworkDetailsBottomPanel = new Panel();
      this.BottomPanel_LinkLabel = new LinkLabel();
      this.NetworkDetailsTopPanel = new Panel();
      this.TopPanel_NetworkNameLbl = new Label();
      this.TopPanel_ConnectedToLbl = new Label();
      this.NetworkDetailsPanel.SuspendLayout();
      this.NetworkDetailsBottomPanel.SuspendLayout();
      this.NetworkDetailsTopPanel.SuspendLayout();
      this.SuspendLayout();
      this.ConnectedIcon.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.ConnectedIcon, "ConnectedIcon");
      this.ConnectedIcon.ImageFilename = "Resources.Placeholder.icon_connected_wired.png";
      this.ConnectedIcon.Name = "ConnectedIcon";
      this.ConnectedIcon.TabStop = false;
      this.ConnectedIcon.TheBitmap = (Bitmap) null;
      this.SignalIcon.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.SignalIcon, "SignalIcon");
      this.SignalIcon.ImageFilename = "Resources.Buttons.btn_help.png";
      this.SignalIcon.Name = "SignalIcon";
      this.SignalIcon.TabStop = false;
      this.SignalIcon.TheBitmap = (Bitmap) null;
      componentResourceManager.ApplyResources((object) this.NetworkDetailsPanel, "NetworkDetailsPanel");
      this.NetworkDetailsPanel.Controls.Add((Control) this.NetworkDetailsBottomPanel);
      this.NetworkDetailsPanel.Controls.Add((Control) this.NetworkDetailsTopPanel);
      this.NetworkDetailsPanel.Name = "NetworkDetailsPanel";
      this.NetworkDetailsBottomPanel.Controls.Add((Control) this.BottomPanel_LinkLabel);
      componentResourceManager.ApplyResources((object) this.NetworkDetailsBottomPanel, "NetworkDetailsBottomPanel");
      this.NetworkDetailsBottomPanel.Name = "NetworkDetailsBottomPanel";
      componentResourceManager.ApplyResources((object) this.BottomPanel_LinkLabel, "BottomPanel_LinkLabel");
      this.BottomPanel_LinkLabel.Name = "BottomPanel_LinkLabel";
      this.BottomPanel_LinkLabel.TabStop = true;
      componentResourceManager.ApplyResources((object) this.NetworkDetailsTopPanel, "NetworkDetailsTopPanel");
      this.NetworkDetailsTopPanel.Controls.Add((Control) this.TopPanel_NetworkNameLbl);
      this.NetworkDetailsTopPanel.Controls.Add((Control) this.TopPanel_ConnectedToLbl);
      this.NetworkDetailsTopPanel.Name = "NetworkDetailsTopPanel";
      componentResourceManager.ApplyResources((object) this.TopPanel_NetworkNameLbl, "TopPanel_NetworkNameLbl");
      this.TopPanel_NetworkNameLbl.Name = "TopPanel_NetworkNameLbl";
      componentResourceManager.ApplyResources((object) this.TopPanel_ConnectedToLbl, "TopPanel_ConnectedToLbl");
      this.TopPanel_ConnectedToLbl.ForeColor = Color.FromArgb(42, 125, 193);
      this.TopPanel_ConnectedToLbl.Name = "TopPanel_ConnectedToLbl";
      this.TopPanel_ConnectedToLbl.TabStop = true;
      this.TopPanel_ConnectedToLbl.UseCompatibleTextRendering = true;
      this.Controls.Add((Control) this.NetworkDetailsPanel);
      this.Controls.Add((Control) this.SignalIcon);
      this.Controls.Add((Control) this.ConnectedIcon);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "ConnectionDetails";
      this.NetworkDetailsPanel.ResumeLayout(false);
      this.NetworkDetailsBottomPanel.ResumeLayout(false);
      this.NetworkDetailsTopPanel.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    public void UpdateUI()
    {
      if (NetworkHandler.ConnectedNetworks == null || NetworkHandler.ConnectedNetworks.Count <= 0)
        return;
      NetworkDisplayItem networkDisplayItem = NetworkHandler.ConnectedNetworks[0];
      this.SetConnectedIcon(networkDisplayItem.LargeTopologyIcon);
      this.SetNetworkNameLabel(networkDisplayItem.NetworkName);
      this.SetLinkLabel();
      this.SetSignalIcon(networkDisplayItem.LargeSignalIcon, networkDisplayItem.WmxNetwork.SignalBars);
      this.RelayoutControls();
    }

    private void WiMAXUpdatesAreBeingDownloadedClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      AppFramework.Dashboard.ShowFUMOProgressDialog();
    }

    private void CustomInitializeComponents()
    {
      this.AccessibleName = "ConnectionDetails";
      this.TopPanel_ConnectedToLbl.AccessibleName = "ConnectionDetailsPanel_ConnectionDetails_NetworkCountLinkLabel";
      this.TopPanel_NetworkNameLbl.AccessibleName = "ConnectionDetailsPanel_ConnectionDetails_NetworkNameLabel";
      this.SignalIcon.AccessibleName = "ConnectionDetailsPanel_ConnectionDetails_SignalStrengthIcon";
      this.ConnectedIcon.AccessibleName = "ConnectionDetailsPanel_ConnectionDetails_ConnectedIcon";
      this.BottomPanel_LinkLabel.AccessibleName = "ConnectionDetailsPanel_ConnectionDetails_BottomPanel_LinkLabel";
      this.TopPanel_ConnectedToLbl.Text = DashboardStringHelper.GetString("ConnectedToColon");
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.BackColor = Color.Transparent;
      this.TopPanel_ConnectedToLbl.BackColor = Color.Transparent;
      this.TopPanel_NetworkNameLbl.BackColor = Color.Transparent;
      this.BottomPanel_LinkLabel.BackColor = Color.Transparent;
      this.NetworkDetailsPanel.Controls.Clear();
      this.NetworkDetailsPanel.Controls.Add((Control) this.NetworkDetailsTopPanel);
      this.BottomPanel_LinkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(this.WiMAXUpdatesAreBeingDownloadedClicked);
      this._signalIconTooltip.ShowAlways = true;
    }

    private void SetConnectedIcon(Bitmap newConnectedIcon)
    {
      if (ImageHelper.ImagesAreSame((Image) newConnectedIcon, (Image) this.ConnectedIcon.TheBitmap))
        return;
      this.ConnectedIcon.TheBitmap = newConnectedIcon;
      this.ConnectedIcon.Invalidate();
    }

    private void SetNetworkNameLabel(string newNetworkName)
    {
      if (newNetworkName.CompareTo(this.TopPanel_NetworkNameLbl.Text) == 0)
        return;
      this.TopPanel_NetworkNameLbl.Text = newNetworkName;
    }

    private void SetLinkLabel()
    {
      if (APDOHandler.FUMODownloadState != FumoDownloadStateEnum.Idle)
      {
        string @string = DashboardStringHelper.GetString("CapitalClickHere_Clickable");
        this.BottomPanel_LinkLabel.Text = string.Format(DashboardStringHelper.GetString("WiMAXUpdatesAreBeingDownloaded"), (object) @string);
        if (this.BottomPanel_LinkLabel.Links.Count > 0)
          this.BottomPanel_LinkLabel.Links.Clear();
        this.BottomPanel_LinkLabel.Links.Add(this.BottomPanel_LinkLabel.Text.IndexOf(@string), @string.Length);
        this.TabStop = true;
      }
      else
      {
        if (this.BottomPanel_LinkLabel.Links.Count > 0)
          this.BottomPanel_LinkLabel.Links.Clear();
        this.BottomPanel_LinkLabel.Text = (string) null;
        this.TabStop = false;
      }
    }

    private void SetSignalIcon(Bitmap signalIcon, SIGNAL_BARS signalBars)
    {
      Bitmap theBitmap = this.SignalIcon.TheBitmap;
      bool visible = this.SignalIcon.Visible;
      if (signalIcon == null)
        this.SignalIcon.Visible = false;
      else
        this.SignalIcon.Visible = true;
      this._signalIconTooltip.SetToolTip((Control) this.SignalIcon, WiMAXDisplayService.Singleton.GetSignalDisplayText(signalBars));
      if (ImageHelper.ImagesAreSame((Image) theBitmap, (Image) signalIcon) && visible == this.SignalIcon.Visible)
        return;
      this.SignalIcon.TheBitmap = signalIcon;
      this.Invalidate(new Rectangle(this.SignalIcon.Location, this.SignalIcon.Size));
    }

    private void RelayoutControls()
    {
      if (this.NetworkDetailsPanel.Controls.Contains((Control) this.NetworkDetailsBottomPanel) && string.IsNullOrEmpty(this.BottomPanel_LinkLabel.Text))
        this.NetworkDetailsPanel.Controls.Remove((Control) this.NetworkDetailsBottomPanel);
      else if (!this.NetworkDetailsPanel.Controls.Contains((Control) this.NetworkDetailsBottomPanel) && !string.IsNullOrEmpty(this.BottomPanel_LinkLabel.Text))
      {
        if (this.NetworkDetailsBottomPanel.Size == this.unscaledNetworkDetailsBottomPanelSize)
        {
          ScalingUtils.ScaleControlSize((Control) this.NetworkDetailsBottomPanel);
          this.BottomPanel_LinkLabel.Location = new Point(0, 0);
          this.BottomPanel_LinkLabel.Size = this.NetworkDetailsBottomPanel.Size;
        }
        this.NetworkDetailsPanel.Controls.Add((Control) this.NetworkDetailsBottomPanel);
      }
      Point point1 = new Point(0, 5);
      Point point2 = new Point(0, 0);
      int num = point1.Y + this.NetworkDetailsTopPanel.Height;
      if (this.NetworkDetailsPanel.Controls.Contains((Control) this.NetworkDetailsBottomPanel))
      {
        point2 = new Point(0, point1.Y + this.NetworkDetailsTopPanel.Height + 10);
        num = point2.Y + this.NetworkDetailsBottomPanel.Height;
      }
      this.NetworkDetailsPanel.Height = num;
      this.NetworkDetailsPanel.Location = new Point(this.NetworkDetailsPanel.Location.X, (this.Height - this.NetworkDetailsPanel.Height) / 2);
      this.NetworkDetailsTopPanel.Location = point1;
      this.NetworkDetailsBottomPanel.Location = point2;
      this.SignalIcon.Location = new Point(this.SignalIcon.Location.X, (this.Height - this.SignalIcon.Height) / 2 + 5);
      this.ConnectedIcon.Location = new Point(this.ConnectedIcon.Location.X, (this.Height - this.ConnectedIcon.Height) / 2 + 3);
    }
  }
}
