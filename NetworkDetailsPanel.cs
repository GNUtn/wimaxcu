// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.NetworkDetailsPanel
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using Intel.Mobile.WiMAXCU.UI.Dashboard.Properties;
using Intel.Mobile.WiMAXCU.UI.DisplayWiMAX;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class NetworkDetailsPanel : UserControl
  {
    private Settings _settings = new Settings();
    private NetworkDisplayItem _ndi = new NetworkDisplayItem();
    private IContainer components;
    private Label NetworkDetailsPanel_HeaderLbl;
    private CustomHelpButtonLabelPair NetworkDetailsPanel_HelpButtonLabelPair;
    private Panel NetworkDetailsPanel_MainPanel;
    private TreeView NetworkDetailsPanel_Tree;
    private CustomButtonPushHorizBox NetworkDetailsPanel_CloseBtnBox;
    private CustomButtonPush NetworkPanel_CloseBtn;
    private Panel ConnectedAdvancedPanel;
    private Label ConnectedAdvancedPanel_ChannelFreqLbl;
    private CustomLabelRoundedCorners ConnectedAdvancedPanel_ChannelFreqValueLbl;
    private CustomLabelRoundedCorners ConnectedAdvancedPanel_TransmitPowerValueLbl;
    private Label ConnectedAdvancedPanel_TransmitPowerLbl;
    private Panel GeneralPanel;
    private Label GeneralPanel_NetworkNameLbl;
    private CustomLabelRoundedCorners GeneralPanel_NetworkNameValueLbl;
    private Label GeneralPanel_SupportLbl;
    private CustomLabelRoundedCorners GeneralPanel_SupportValueLbl;
    private Panel StatisticsPanel;
    private Label StatisticsPanel_BytesSentLbl;
    private CustomLabelRoundedCorners StatisticsPanel_BytesSentValueLbl;
    private Label StatisticsPanel_BytesReceivedLbl;
    private Label StatisticsPanel_PacketsSentLbl;
    private CustomLabelRoundedCorners StatisticsPanel_PacketsReceivedValueLbl;
    private CustomLabelRoundedCorners StatisticsPanel_BytesReceivedValueLbl;
    private Label StatisticsPanel_PacketsReceivedLbl;
    private CustomLabelRoundedCorners StatisticsPanel_PacketsSentValueLbl;
    private Panel SecurityPanel;
    private Label SecurityPanel_ActualDomainNameLbl;
    private CustomLabelRoundedCorners SecurityPanel_ActualDomainNameValueLbl;
    private Label SecurityPanel_EncryptedLbl;
    private CustomLabelRoundedCorners SecurityPanel_EncryptedValueLbl;
    private Panel ConnectedPanel;
    private Label ConnectedPanel_IPAddressLbl;
    private Label ConnectedPanel_DurationLbl;
    private CustomLabelRoundedCorners ConnectedPanel_IPAddressValueLbl;
    private CustomLabelRoundedCorners ConnectedPanel_DurationValueLbl;
    private Panel NetworkDetailsPanel_TreePanel;
    private Label GeneralPanel_PreferredLbl;
    private CustomLabelRoundedCorners GeneralPanel_PreferredValueLbl;
    private Label SecurityPanel_NetworkAuthenticatedLbl;
    private CustomLabelRoundedCorners SecurityPanel_NetworkAuthenticatedValueLbl;
    private Panel AdvancedPanel;
    private Label AdvancedPanel_RSSILbl;
    private Label AdvancedPanel_CINRLbl;
    private CustomLabelRoundedCorners AdvancedPanel_RSSIValueLbl;
    private CustomLabelRoundedCorners AdvancedPanel_CINRValueLbl;
    private Label AdvancedPanel_NetworkIdLbl;
    private CustomLabelRoundedCorners AdvancedPanel_NetworkIdValueLbl;
    private Label GeneralPanel_SignalLbl;
    private CustomLabelRoundedCorners GeneralPanel_SignalValueLbl;
    private Label ConnectedAdvancedPanel_BaseStationLbl;
    private CustomLabelRoundedCorners ConnectedAdvancedPanel_BaseStationValueLbl;
    private bool _networkDetailsDlgOpen;
    private Timer _updateTimeTimer;
    private Timer _updateNetworkStatsTimer;

    public NetworkDetailsPanel()
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (NetworkDetailsPanel));
      this.NetworkDetailsPanel_HeaderLbl = new Label();
      this.NetworkDetailsPanel_HelpButtonLabelPair = new CustomHelpButtonLabelPair();
      this.NetworkDetailsPanel_MainPanel = new Panel();
      this.NetworkDetailsPanel_TreePanel = new Panel();
      this.NetworkDetailsPanel_Tree = new TreeView();
      this.ConnectedAdvancedPanel = new Panel();
      this.ConnectedAdvancedPanel_BaseStationLbl = new Label();
      this.ConnectedAdvancedPanel_BaseStationValueLbl = new CustomLabelRoundedCorners();
      this.ConnectedAdvancedPanel_ChannelFreqLbl = new Label();
      this.ConnectedAdvancedPanel_ChannelFreqValueLbl = new CustomLabelRoundedCorners();
      this.ConnectedAdvancedPanel_TransmitPowerValueLbl = new CustomLabelRoundedCorners();
      this.ConnectedAdvancedPanel_TransmitPowerLbl = new Label();
      this.SecurityPanel = new Panel();
      this.SecurityPanel_NetworkAuthenticatedLbl = new Label();
      this.SecurityPanel_NetworkAuthenticatedValueLbl = new CustomLabelRoundedCorners();
      this.SecurityPanel_ActualDomainNameLbl = new Label();
      this.SecurityPanel_ActualDomainNameValueLbl = new CustomLabelRoundedCorners();
      this.SecurityPanel_EncryptedLbl = new Label();
      this.SecurityPanel_EncryptedValueLbl = new CustomLabelRoundedCorners();
      this.ConnectedPanel = new Panel();
      this.ConnectedPanel_IPAddressLbl = new Label();
      this.ConnectedPanel_DurationLbl = new Label();
      this.ConnectedPanel_IPAddressValueLbl = new CustomLabelRoundedCorners();
      this.ConnectedPanel_DurationValueLbl = new CustomLabelRoundedCorners();
      this.GeneralPanel = new Panel();
      this.GeneralPanel_SignalLbl = new Label();
      this.GeneralPanel_SignalValueLbl = new CustomLabelRoundedCorners();
      this.GeneralPanel_PreferredLbl = new Label();
      this.GeneralPanel_PreferredValueLbl = new CustomLabelRoundedCorners();
      this.GeneralPanel_NetworkNameLbl = new Label();
      this.GeneralPanel_NetworkNameValueLbl = new CustomLabelRoundedCorners();
      this.GeneralPanel_SupportValueLbl = new CustomLabelRoundedCorners();
      this.GeneralPanel_SupportLbl = new Label();
      this.StatisticsPanel = new Panel();
      this.StatisticsPanel_BytesSentLbl = new Label();
      this.StatisticsPanel_BytesSentValueLbl = new CustomLabelRoundedCorners();
      this.StatisticsPanel_BytesReceivedLbl = new Label();
      this.StatisticsPanel_PacketsSentLbl = new Label();
      this.StatisticsPanel_PacketsReceivedValueLbl = new CustomLabelRoundedCorners();
      this.StatisticsPanel_BytesReceivedValueLbl = new CustomLabelRoundedCorners();
      this.StatisticsPanel_PacketsReceivedLbl = new Label();
      this.StatisticsPanel_PacketsSentValueLbl = new CustomLabelRoundedCorners();
      this.AdvancedPanel = new Panel();
      this.AdvancedPanel_NetworkIdLbl = new Label();
      this.AdvancedPanel_NetworkIdValueLbl = new CustomLabelRoundedCorners();
      this.AdvancedPanel_RSSILbl = new Label();
      this.AdvancedPanel_CINRLbl = new Label();
      this.AdvancedPanel_RSSIValueLbl = new CustomLabelRoundedCorners();
      this.AdvancedPanel_CINRValueLbl = new CustomLabelRoundedCorners();
      this.NetworkDetailsPanel_CloseBtnBox = new CustomButtonPushHorizBox();
      this.NetworkPanel_CloseBtn = new CustomButtonPush();
      this.NetworkDetailsPanel_MainPanel.SuspendLayout();
      this.NetworkDetailsPanel_TreePanel.SuspendLayout();
      this.ConnectedAdvancedPanel.SuspendLayout();
      this.SecurityPanel.SuspendLayout();
      this.ConnectedPanel.SuspendLayout();
      this.GeneralPanel.SuspendLayout();
      this.StatisticsPanel.SuspendLayout();
      this.AdvancedPanel.SuspendLayout();
      this.NetworkDetailsPanel_CloseBtnBox.SuspendLayout();
      this.SuspendLayout();
      this.NetworkDetailsPanel_HeaderLbl.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.NetworkDetailsPanel_HeaderLbl, "NetworkDetailsPanel_HeaderLbl");
      this.NetworkDetailsPanel_HeaderLbl.Name = "NetworkDetailsPanel_HeaderLbl";
      this.NetworkDetailsPanel_HelpButtonLabelPair.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.NetworkDetailsPanel_HelpButtonLabelPair, "NetworkDetailsPanel_HelpButtonLabelPair");
      this.NetworkDetailsPanel_HelpButtonLabelPair.Name = "NetworkDetailsPanel_HelpButtonLabelPair";
      this.NetworkDetailsPanel_MainPanel.BackColor = Color.FromArgb(204, 204, 204);
      this.NetworkDetailsPanel_MainPanel.Controls.Add((Control) this.NetworkDetailsPanel_TreePanel);
      this.NetworkDetailsPanel_MainPanel.Controls.Add((Control) this.AdvancedPanel);
      this.NetworkDetailsPanel_MainPanel.Controls.Add((Control) this.ConnectedAdvancedPanel);
      this.NetworkDetailsPanel_MainPanel.Controls.Add((Control) this.SecurityPanel);
      this.NetworkDetailsPanel_MainPanel.Controls.Add((Control) this.ConnectedPanel);
      this.NetworkDetailsPanel_MainPanel.Controls.Add((Control) this.GeneralPanel);
      this.NetworkDetailsPanel_MainPanel.Controls.Add((Control) this.StatisticsPanel);
      componentResourceManager.ApplyResources((object) this.NetworkDetailsPanel_MainPanel, "NetworkDetailsPanel_MainPanel");
      this.NetworkDetailsPanel_MainPanel.Name = "NetworkDetailsPanel_MainPanel";
      this.NetworkDetailsPanel_TreePanel.BackColor = Color.White;
      this.NetworkDetailsPanel_TreePanel.Controls.Add((Control) this.NetworkDetailsPanel_Tree);
      componentResourceManager.ApplyResources((object) this.NetworkDetailsPanel_TreePanel, "NetworkDetailsPanel_TreePanel");
      this.NetworkDetailsPanel_TreePanel.Name = "NetworkDetailsPanel_TreePanel";
      this.NetworkDetailsPanel_Tree.BackColor = Color.White;
      this.NetworkDetailsPanel_Tree.BorderStyle = BorderStyle.None;
      this.NetworkDetailsPanel_Tree.ForeColor = Color.Black;
      componentResourceManager.ApplyResources((object) this.NetworkDetailsPanel_Tree, "NetworkDetailsPanel_Tree");
      this.NetworkDetailsPanel_Tree.Name = "NetworkDetailsPanel_Tree";
      this.NetworkDetailsPanel_Tree.Nodes.AddRange(new TreeNode[3]
      {
        (TreeNode) componentResourceManager.GetObject("NetworkDetailsPanel_Tree.Nodes"),
        (TreeNode) componentResourceManager.GetObject("NetworkDetailsPanel_Tree.Nodes1"),
        (TreeNode) componentResourceManager.GetObject("NetworkDetailsPanel_Tree.Nodes2")
      });
      this.NetworkDetailsPanel_Tree.AfterSelect += new TreeViewEventHandler(this.OnTreeSelectionChanged);
      this.ConnectedAdvancedPanel.BackColor = Color.WhiteSmoke;
      this.ConnectedAdvancedPanel.Controls.Add((Control) this.ConnectedAdvancedPanel_BaseStationLbl);
      this.ConnectedAdvancedPanel.Controls.Add((Control) this.ConnectedAdvancedPanel_BaseStationValueLbl);
      this.ConnectedAdvancedPanel.Controls.Add((Control) this.ConnectedAdvancedPanel_ChannelFreqLbl);
      this.ConnectedAdvancedPanel.Controls.Add((Control) this.ConnectedAdvancedPanel_ChannelFreqValueLbl);
      this.ConnectedAdvancedPanel.Controls.Add((Control) this.ConnectedAdvancedPanel_TransmitPowerValueLbl);
      this.ConnectedAdvancedPanel.Controls.Add((Control) this.ConnectedAdvancedPanel_TransmitPowerLbl);
      componentResourceManager.ApplyResources((object) this.ConnectedAdvancedPanel, "ConnectedAdvancedPanel");
      this.ConnectedAdvancedPanel.Name = "ConnectedAdvancedPanel";
      componentResourceManager.ApplyResources((object) this.ConnectedAdvancedPanel_BaseStationLbl, "ConnectedAdvancedPanel_BaseStationLbl");
      this.ConnectedAdvancedPanel_BaseStationLbl.Name = "ConnectedAdvancedPanel_BaseStationLbl";
      this.ConnectedAdvancedPanel_BaseStationValueLbl.BackColor = Color.Transparent;
      this.ConnectedAdvancedPanel_BaseStationValueLbl.BackgroundColor = Color.FromArgb(210, 234, 251);
      this.ConnectedAdvancedPanel_BaseStationValueLbl.ControlType = ControlTypeEnum.TextBox;
      componentResourceManager.ApplyResources((object) this.ConnectedAdvancedPanel_BaseStationValueLbl, "ConnectedAdvancedPanel_BaseStationValueLbl");
      this.ConnectedAdvancedPanel_BaseStationValueLbl.Icon = (Bitmap) null;
      this.ConnectedAdvancedPanel_BaseStationValueLbl.Name = "ConnectedAdvancedPanel_BaseStationValueLbl";
      this.ConnectedAdvancedPanel_BaseStationValueLbl.TabStop = false;
      this.ConnectedAdvancedPanel_BaseStationValueLbl.UniqueID = -1;
      componentResourceManager.ApplyResources((object) this.ConnectedAdvancedPanel_ChannelFreqLbl, "ConnectedAdvancedPanel_ChannelFreqLbl");
      this.ConnectedAdvancedPanel_ChannelFreqLbl.Name = "ConnectedAdvancedPanel_ChannelFreqLbl";
      this.ConnectedAdvancedPanel_ChannelFreqValueLbl.BackColor = Color.Transparent;
      this.ConnectedAdvancedPanel_ChannelFreqValueLbl.BackgroundColor = Color.FromArgb(210, 234, 251);
      this.ConnectedAdvancedPanel_ChannelFreqValueLbl.ControlType = ControlTypeEnum.TextBox;
      componentResourceManager.ApplyResources((object) this.ConnectedAdvancedPanel_ChannelFreqValueLbl, "ConnectedAdvancedPanel_ChannelFreqValueLbl");
      this.ConnectedAdvancedPanel_ChannelFreqValueLbl.Icon = (Bitmap) null;
      this.ConnectedAdvancedPanel_ChannelFreqValueLbl.Name = "ConnectedAdvancedPanel_ChannelFreqValueLbl";
      this.ConnectedAdvancedPanel_ChannelFreqValueLbl.TabStop = false;
      this.ConnectedAdvancedPanel_ChannelFreqValueLbl.UniqueID = -1;
      this.ConnectedAdvancedPanel_TransmitPowerValueLbl.AccessibleRole = AccessibleRole.None;
      this.ConnectedAdvancedPanel_TransmitPowerValueLbl.BackColor = Color.Transparent;
      this.ConnectedAdvancedPanel_TransmitPowerValueLbl.BackgroundColor = Color.FromArgb(210, 234, 251);
      this.ConnectedAdvancedPanel_TransmitPowerValueLbl.ControlType = ControlTypeEnum.TextBox;
      componentResourceManager.ApplyResources((object) this.ConnectedAdvancedPanel_TransmitPowerValueLbl, "ConnectedAdvancedPanel_TransmitPowerValueLbl");
      this.ConnectedAdvancedPanel_TransmitPowerValueLbl.Icon = (Bitmap) null;
      this.ConnectedAdvancedPanel_TransmitPowerValueLbl.Name = "ConnectedAdvancedPanel_TransmitPowerValueLbl";
      this.ConnectedAdvancedPanel_TransmitPowerValueLbl.TabStop = false;
      this.ConnectedAdvancedPanel_TransmitPowerValueLbl.UniqueID = -1;
      componentResourceManager.ApplyResources((object) this.ConnectedAdvancedPanel_TransmitPowerLbl, "ConnectedAdvancedPanel_TransmitPowerLbl");
      this.ConnectedAdvancedPanel_TransmitPowerLbl.Name = "ConnectedAdvancedPanel_TransmitPowerLbl";
      this.SecurityPanel.BackColor = Color.WhiteSmoke;
      this.SecurityPanel.Controls.Add((Control) this.SecurityPanel_NetworkAuthenticatedLbl);
      this.SecurityPanel.Controls.Add((Control) this.SecurityPanel_NetworkAuthenticatedValueLbl);
      this.SecurityPanel.Controls.Add((Control) this.SecurityPanel_ActualDomainNameLbl);
      this.SecurityPanel.Controls.Add((Control) this.SecurityPanel_ActualDomainNameValueLbl);
      this.SecurityPanel.Controls.Add((Control) this.SecurityPanel_EncryptedLbl);
      this.SecurityPanel.Controls.Add((Control) this.SecurityPanel_EncryptedValueLbl);
      componentResourceManager.ApplyResources((object) this.SecurityPanel, "SecurityPanel");
      this.SecurityPanel.Name = "SecurityPanel";
      this.SecurityPanel_NetworkAuthenticatedLbl.AccessibleRole = AccessibleRole.TitleBar;
      componentResourceManager.ApplyResources((object) this.SecurityPanel_NetworkAuthenticatedLbl, "SecurityPanel_NetworkAuthenticatedLbl");
      this.SecurityPanel_NetworkAuthenticatedLbl.Name = "SecurityPanel_NetworkAuthenticatedLbl";
      this.SecurityPanel_NetworkAuthenticatedValueLbl.BackColor = Color.Transparent;
      this.SecurityPanel_NetworkAuthenticatedValueLbl.BackgroundColor = Color.FromArgb(210, 234, 251);
      this.SecurityPanel_NetworkAuthenticatedValueLbl.ControlType = ControlTypeEnum.TextBox;
      componentResourceManager.ApplyResources((object) this.SecurityPanel_NetworkAuthenticatedValueLbl, "SecurityPanel_NetworkAuthenticatedValueLbl");
      this.SecurityPanel_NetworkAuthenticatedValueLbl.Icon = (Bitmap) null;
      this.SecurityPanel_NetworkAuthenticatedValueLbl.Name = "SecurityPanel_NetworkAuthenticatedValueLbl";
      this.SecurityPanel_NetworkAuthenticatedValueLbl.TabStop = false;
      this.SecurityPanel_NetworkAuthenticatedValueLbl.UniqueID = -1;
      componentResourceManager.ApplyResources((object) this.SecurityPanel_ActualDomainNameLbl, "SecurityPanel_ActualDomainNameLbl");
      this.SecurityPanel_ActualDomainNameLbl.Name = "SecurityPanel_ActualDomainNameLbl";
      this.SecurityPanel_ActualDomainNameValueLbl.BackColor = Color.Transparent;
      this.SecurityPanel_ActualDomainNameValueLbl.BackgroundColor = Color.FromArgb(210, 234, 251);
      this.SecurityPanel_ActualDomainNameValueLbl.ControlType = ControlTypeEnum.TextBox;
      componentResourceManager.ApplyResources((object) this.SecurityPanel_ActualDomainNameValueLbl, "SecurityPanel_ActualDomainNameValueLbl");
      this.SecurityPanel_ActualDomainNameValueLbl.Icon = (Bitmap) null;
      this.SecurityPanel_ActualDomainNameValueLbl.Name = "SecurityPanel_ActualDomainNameValueLbl";
      this.SecurityPanel_ActualDomainNameValueLbl.TabStop = false;
      this.SecurityPanel_ActualDomainNameValueLbl.UniqueID = -1;
      this.SecurityPanel_EncryptedLbl.AccessibleRole = AccessibleRole.None;
      componentResourceManager.ApplyResources((object) this.SecurityPanel_EncryptedLbl, "SecurityPanel_EncryptedLbl");
      this.SecurityPanel_EncryptedLbl.Name = "SecurityPanel_EncryptedLbl";
      this.SecurityPanel_EncryptedValueLbl.BackColor = Color.Transparent;
      this.SecurityPanel_EncryptedValueLbl.BackgroundColor = Color.FromArgb(210, 234, 251);
      this.SecurityPanel_EncryptedValueLbl.ControlType = ControlTypeEnum.TextBox;
      componentResourceManager.ApplyResources((object) this.SecurityPanel_EncryptedValueLbl, "SecurityPanel_EncryptedValueLbl");
      this.SecurityPanel_EncryptedValueLbl.Icon = (Bitmap) null;
      this.SecurityPanel_EncryptedValueLbl.Name = "SecurityPanel_EncryptedValueLbl";
      this.SecurityPanel_EncryptedValueLbl.TabStop = false;
      this.SecurityPanel_EncryptedValueLbl.UniqueID = -1;
      this.ConnectedPanel.BackColor = Color.WhiteSmoke;
      this.ConnectedPanel.Controls.Add((Control) this.ConnectedPanel_IPAddressLbl);
      this.ConnectedPanel.Controls.Add((Control) this.ConnectedPanel_DurationLbl);
      this.ConnectedPanel.Controls.Add((Control) this.ConnectedPanel_IPAddressValueLbl);
      this.ConnectedPanel.Controls.Add((Control) this.ConnectedPanel_DurationValueLbl);
      componentResourceManager.ApplyResources((object) this.ConnectedPanel, "ConnectedPanel");
      this.ConnectedPanel.Name = "ConnectedPanel";
      this.ConnectedPanel_IPAddressLbl.AccessibleRole = AccessibleRole.None;
      componentResourceManager.ApplyResources((object) this.ConnectedPanel_IPAddressLbl, "ConnectedPanel_IPAddressLbl");
      this.ConnectedPanel_IPAddressLbl.Name = "ConnectedPanel_IPAddressLbl";
      componentResourceManager.ApplyResources((object) this.ConnectedPanel_DurationLbl, "ConnectedPanel_DurationLbl");
      this.ConnectedPanel_DurationLbl.Name = "ConnectedPanel_DurationLbl";
      this.ConnectedPanel_IPAddressValueLbl.BackColor = Color.Transparent;
      this.ConnectedPanel_IPAddressValueLbl.BackgroundColor = Color.FromArgb(210, 234, 251);
      this.ConnectedPanel_IPAddressValueLbl.ControlType = ControlTypeEnum.TextBox;
      componentResourceManager.ApplyResources((object) this.ConnectedPanel_IPAddressValueLbl, "ConnectedPanel_IPAddressValueLbl");
      this.ConnectedPanel_IPAddressValueLbl.Icon = (Bitmap) null;
      this.ConnectedPanel_IPAddressValueLbl.Name = "ConnectedPanel_IPAddressValueLbl";
      this.ConnectedPanel_IPAddressValueLbl.TabStop = false;
      this.ConnectedPanel_IPAddressValueLbl.UniqueID = -1;
      this.ConnectedPanel_DurationValueLbl.BackColor = Color.Transparent;
      this.ConnectedPanel_DurationValueLbl.BackgroundColor = Color.FromArgb(210, 234, 251);
      this.ConnectedPanel_DurationValueLbl.ControlType = ControlTypeEnum.TextBox;
      componentResourceManager.ApplyResources((object) this.ConnectedPanel_DurationValueLbl, "ConnectedPanel_DurationValueLbl");
      this.ConnectedPanel_DurationValueLbl.Icon = (Bitmap) null;
      this.ConnectedPanel_DurationValueLbl.Name = "ConnectedPanel_DurationValueLbl";
      this.ConnectedPanel_DurationValueLbl.TabStop = false;
      this.ConnectedPanel_DurationValueLbl.UniqueID = -1;
      this.GeneralPanel.BackColor = Color.WhiteSmoke;
      this.GeneralPanel.Controls.Add((Control) this.GeneralPanel_SignalLbl);
      this.GeneralPanel.Controls.Add((Control) this.GeneralPanel_SignalValueLbl);
      this.GeneralPanel.Controls.Add((Control) this.GeneralPanel_PreferredLbl);
      this.GeneralPanel.Controls.Add((Control) this.GeneralPanel_PreferredValueLbl);
      this.GeneralPanel.Controls.Add((Control) this.GeneralPanel_NetworkNameLbl);
      this.GeneralPanel.Controls.Add((Control) this.GeneralPanel_NetworkNameValueLbl);
      this.GeneralPanel.Controls.Add((Control) this.GeneralPanel_SupportValueLbl);
      this.GeneralPanel.Controls.Add((Control) this.GeneralPanel_SupportLbl);
      componentResourceManager.ApplyResources((object) this.GeneralPanel, "GeneralPanel");
      this.GeneralPanel.Name = "GeneralPanel";
      componentResourceManager.ApplyResources((object) this.GeneralPanel_SignalLbl, "GeneralPanel_SignalLbl");
      this.GeneralPanel_SignalLbl.Name = "GeneralPanel_SignalLbl";
      this.GeneralPanel_SignalValueLbl.BackColor = Color.Transparent;
      this.GeneralPanel_SignalValueLbl.BackgroundColor = Color.FromArgb(210, 234, 251);
      this.GeneralPanel_SignalValueLbl.ControlType = ControlTypeEnum.TextBox;
      componentResourceManager.ApplyResources((object) this.GeneralPanel_SignalValueLbl, "GeneralPanel_SignalValueLbl");
      this.GeneralPanel_SignalValueLbl.Icon = (Bitmap) null;
      this.GeneralPanel_SignalValueLbl.Name = "GeneralPanel_SignalValueLbl";
      this.GeneralPanel_SignalValueLbl.TabStop = false;
      this.GeneralPanel_SignalValueLbl.UniqueID = -1;
      componentResourceManager.ApplyResources((object) this.GeneralPanel_PreferredLbl, "GeneralPanel_PreferredLbl");
      this.GeneralPanel_PreferredLbl.Name = "GeneralPanel_PreferredLbl";
      this.GeneralPanel_PreferredValueLbl.BackColor = Color.Transparent;
      this.GeneralPanel_PreferredValueLbl.BackgroundColor = Color.FromArgb(210, 234, 251);
      this.GeneralPanel_PreferredValueLbl.ControlType = ControlTypeEnum.TextBox;
      componentResourceManager.ApplyResources((object) this.GeneralPanel_PreferredValueLbl, "GeneralPanel_PreferredValueLbl");
      this.GeneralPanel_PreferredValueLbl.Icon = (Bitmap) null;
      this.GeneralPanel_PreferredValueLbl.Name = "GeneralPanel_PreferredValueLbl";
      this.GeneralPanel_PreferredValueLbl.TabStop = false;
      this.GeneralPanel_PreferredValueLbl.UniqueID = -1;
      componentResourceManager.ApplyResources((object) this.GeneralPanel_NetworkNameLbl, "GeneralPanel_NetworkNameLbl");
      this.GeneralPanel_NetworkNameLbl.Name = "GeneralPanel_NetworkNameLbl";
      this.GeneralPanel_NetworkNameValueLbl.BackColor = Color.Transparent;
      this.GeneralPanel_NetworkNameValueLbl.BackgroundColor = Color.FromArgb(210, 234, 251);
      this.GeneralPanel_NetworkNameValueLbl.ControlType = ControlTypeEnum.TextBox;
      componentResourceManager.ApplyResources((object) this.GeneralPanel_NetworkNameValueLbl, "GeneralPanel_NetworkNameValueLbl");
      this.GeneralPanel_NetworkNameValueLbl.Icon = (Bitmap) null;
      this.GeneralPanel_NetworkNameValueLbl.Name = "GeneralPanel_NetworkNameValueLbl";
      this.GeneralPanel_NetworkNameValueLbl.TabStop = false;
      this.GeneralPanel_NetworkNameValueLbl.UniqueID = -1;
      this.GeneralPanel_SupportValueLbl.BackColor = Color.Transparent;
      this.GeneralPanel_SupportValueLbl.BackgroundColor = Color.FromArgb(210, 234, 251);
      this.GeneralPanel_SupportValueLbl.ControlType = ControlTypeEnum.LinkLabel;
      componentResourceManager.ApplyResources((object) this.GeneralPanel_SupportValueLbl, "GeneralPanel_SupportValueLbl");
      this.GeneralPanel_SupportValueLbl.Icon = (Bitmap) null;
      this.GeneralPanel_SupportValueLbl.Name = "GeneralPanel_SupportValueLbl";
      this.GeneralPanel_SupportValueLbl.TabStop = false;
      this.GeneralPanel_SupportValueLbl.UniqueID = -1;
      this.GeneralPanel_SupportLbl.AccessibleRole = AccessibleRole.None;
      componentResourceManager.ApplyResources((object) this.GeneralPanel_SupportLbl, "GeneralPanel_SupportLbl");
      this.GeneralPanel_SupportLbl.Name = "GeneralPanel_SupportLbl";
      this.StatisticsPanel.BackColor = Color.WhiteSmoke;
      this.StatisticsPanel.Controls.Add((Control) this.StatisticsPanel_BytesSentLbl);
      this.StatisticsPanel.Controls.Add((Control) this.StatisticsPanel_BytesSentValueLbl);
      this.StatisticsPanel.Controls.Add((Control) this.StatisticsPanel_BytesReceivedLbl);
      this.StatisticsPanel.Controls.Add((Control) this.StatisticsPanel_PacketsSentLbl);
      this.StatisticsPanel.Controls.Add((Control) this.StatisticsPanel_PacketsReceivedValueLbl);
      this.StatisticsPanel.Controls.Add((Control) this.StatisticsPanel_BytesReceivedValueLbl);
      this.StatisticsPanel.Controls.Add((Control) this.StatisticsPanel_PacketsReceivedLbl);
      this.StatisticsPanel.Controls.Add((Control) this.StatisticsPanel_PacketsSentValueLbl);
      componentResourceManager.ApplyResources((object) this.StatisticsPanel, "StatisticsPanel");
      this.StatisticsPanel.Name = "StatisticsPanel";
      componentResourceManager.ApplyResources((object) this.StatisticsPanel_BytesSentLbl, "StatisticsPanel_BytesSentLbl");
      this.StatisticsPanel_BytesSentLbl.Name = "StatisticsPanel_BytesSentLbl";
      this.StatisticsPanel_BytesSentValueLbl.BackColor = Color.Transparent;
      this.StatisticsPanel_BytesSentValueLbl.BackgroundColor = Color.FromArgb(210, 234, 251);
      this.StatisticsPanel_BytesSentValueLbl.ControlType = ControlTypeEnum.TextBox;
      componentResourceManager.ApplyResources((object) this.StatisticsPanel_BytesSentValueLbl, "StatisticsPanel_BytesSentValueLbl");
      this.StatisticsPanel_BytesSentValueLbl.Icon = (Bitmap) null;
      this.StatisticsPanel_BytesSentValueLbl.Name = "StatisticsPanel_BytesSentValueLbl";
      this.StatisticsPanel_BytesSentValueLbl.TabStop = false;
      this.StatisticsPanel_BytesSentValueLbl.UniqueID = -1;
      this.StatisticsPanel_BytesReceivedLbl.AccessibleRole = AccessibleRole.None;
      componentResourceManager.ApplyResources((object) this.StatisticsPanel_BytesReceivedLbl, "StatisticsPanel_BytesReceivedLbl");
      this.StatisticsPanel_BytesReceivedLbl.Name = "StatisticsPanel_BytesReceivedLbl";
      componentResourceManager.ApplyResources((object) this.StatisticsPanel_PacketsSentLbl, "StatisticsPanel_PacketsSentLbl");
      this.StatisticsPanel_PacketsSentLbl.Name = "StatisticsPanel_PacketsSentLbl";
      this.StatisticsPanel_PacketsReceivedValueLbl.AccessibleRole = AccessibleRole.None;
      this.StatisticsPanel_PacketsReceivedValueLbl.BackColor = Color.Transparent;
      this.StatisticsPanel_PacketsReceivedValueLbl.BackgroundColor = Color.FromArgb(210, 234, 251);
      this.StatisticsPanel_PacketsReceivedValueLbl.ControlType = ControlTypeEnum.TextBox;
      componentResourceManager.ApplyResources((object) this.StatisticsPanel_PacketsReceivedValueLbl, "StatisticsPanel_PacketsReceivedValueLbl");
      this.StatisticsPanel_PacketsReceivedValueLbl.Icon = (Bitmap) null;
      this.StatisticsPanel_PacketsReceivedValueLbl.Name = "StatisticsPanel_PacketsReceivedValueLbl";
      this.StatisticsPanel_PacketsReceivedValueLbl.TabStop = false;
      this.StatisticsPanel_PacketsReceivedValueLbl.UniqueID = -1;
      this.StatisticsPanel_BytesReceivedValueLbl.BackColor = Color.Transparent;
      this.StatisticsPanel_BytesReceivedValueLbl.BackgroundColor = Color.FromArgb(210, 234, 251);
      this.StatisticsPanel_BytesReceivedValueLbl.ControlType = ControlTypeEnum.TextBox;
      componentResourceManager.ApplyResources((object) this.StatisticsPanel_BytesReceivedValueLbl, "StatisticsPanel_BytesReceivedValueLbl");
      this.StatisticsPanel_BytesReceivedValueLbl.Icon = (Bitmap) null;
      this.StatisticsPanel_BytesReceivedValueLbl.Name = "StatisticsPanel_BytesReceivedValueLbl";
      this.StatisticsPanel_BytesReceivedValueLbl.TabStop = false;
      this.StatisticsPanel_BytesReceivedValueLbl.UniqueID = -1;
      componentResourceManager.ApplyResources((object) this.StatisticsPanel_PacketsReceivedLbl, "StatisticsPanel_PacketsReceivedLbl");
      this.StatisticsPanel_PacketsReceivedLbl.Name = "StatisticsPanel_PacketsReceivedLbl";
      this.StatisticsPanel_PacketsSentValueLbl.BackColor = Color.Transparent;
      this.StatisticsPanel_PacketsSentValueLbl.BackgroundColor = Color.FromArgb(210, 234, 251);
      this.StatisticsPanel_PacketsSentValueLbl.ControlType = ControlTypeEnum.TextBox;
      componentResourceManager.ApplyResources((object) this.StatisticsPanel_PacketsSentValueLbl, "StatisticsPanel_PacketsSentValueLbl");
      this.StatisticsPanel_PacketsSentValueLbl.Icon = (Bitmap) null;
      this.StatisticsPanel_PacketsSentValueLbl.Name = "StatisticsPanel_PacketsSentValueLbl";
      this.StatisticsPanel_PacketsSentValueLbl.TabStop = false;
      this.StatisticsPanel_PacketsSentValueLbl.UniqueID = -1;
      this.AdvancedPanel.BackColor = Color.WhiteSmoke;
      this.AdvancedPanel.Controls.Add((Control) this.AdvancedPanel_NetworkIdLbl);
      this.AdvancedPanel.Controls.Add((Control) this.AdvancedPanel_NetworkIdValueLbl);
      this.AdvancedPanel.Controls.Add((Control) this.AdvancedPanel_RSSILbl);
      this.AdvancedPanel.Controls.Add((Control) this.AdvancedPanel_CINRLbl);
      this.AdvancedPanel.Controls.Add((Control) this.AdvancedPanel_RSSIValueLbl);
      this.AdvancedPanel.Controls.Add((Control) this.AdvancedPanel_CINRValueLbl);
      componentResourceManager.ApplyResources((object) this.AdvancedPanel, "AdvancedPanel");
      this.AdvancedPanel.Name = "AdvancedPanel";
      componentResourceManager.ApplyResources((object) this.AdvancedPanel_NetworkIdLbl, "AdvancedPanel_NetworkIdLbl");
      this.AdvancedPanel_NetworkIdLbl.Name = "AdvancedPanel_NetworkIdLbl";
      this.AdvancedPanel_NetworkIdValueLbl.BackColor = Color.Transparent;
      this.AdvancedPanel_NetworkIdValueLbl.BackgroundColor = Color.FromArgb(210, 234, 251);
      this.AdvancedPanel_NetworkIdValueLbl.ControlType = ControlTypeEnum.TextBox;
      componentResourceManager.ApplyResources((object) this.AdvancedPanel_NetworkIdValueLbl, "AdvancedPanel_NetworkIdValueLbl");
      this.AdvancedPanel_NetworkIdValueLbl.Icon = (Bitmap) null;
      this.AdvancedPanel_NetworkIdValueLbl.Name = "AdvancedPanel_NetworkIdValueLbl";
      this.AdvancedPanel_NetworkIdValueLbl.TabStop = false;
      this.AdvancedPanel_NetworkIdValueLbl.UniqueID = -1;
      this.AdvancedPanel_RSSILbl.AccessibleRole = AccessibleRole.None;
      componentResourceManager.ApplyResources((object) this.AdvancedPanel_RSSILbl, "AdvancedPanel_RSSILbl");
      this.AdvancedPanel_RSSILbl.Name = "AdvancedPanel_RSSILbl";
      componentResourceManager.ApplyResources((object) this.AdvancedPanel_CINRLbl, "AdvancedPanel_CINRLbl");
      this.AdvancedPanel_CINRLbl.Name = "AdvancedPanel_CINRLbl";
      this.AdvancedPanel_RSSIValueLbl.BackColor = Color.Transparent;
      this.AdvancedPanel_RSSIValueLbl.BackgroundColor = Color.FromArgb(210, 234, 251);
      this.AdvancedPanel_RSSIValueLbl.ControlType = ControlTypeEnum.TextBox;
      componentResourceManager.ApplyResources((object) this.AdvancedPanel_RSSIValueLbl, "AdvancedPanel_RSSIValueLbl");
      this.AdvancedPanel_RSSIValueLbl.Icon = (Bitmap) null;
      this.AdvancedPanel_RSSIValueLbl.Name = "AdvancedPanel_RSSIValueLbl";
      this.AdvancedPanel_RSSIValueLbl.TabStop = false;
      this.AdvancedPanel_RSSIValueLbl.UniqueID = -1;
      this.AdvancedPanel_CINRValueLbl.BackColor = Color.Transparent;
      this.AdvancedPanel_CINRValueLbl.BackgroundColor = Color.FromArgb(210, 234, 251);
      this.AdvancedPanel_CINRValueLbl.ControlType = ControlTypeEnum.TextBox;
      componentResourceManager.ApplyResources((object) this.AdvancedPanel_CINRValueLbl, "AdvancedPanel_CINRValueLbl");
      this.AdvancedPanel_CINRValueLbl.Icon = (Bitmap) null;
      this.AdvancedPanel_CINRValueLbl.Name = "AdvancedPanel_CINRValueLbl";
      this.AdvancedPanel_CINRValueLbl.TabStop = false;
      this.AdvancedPanel_CINRValueLbl.UniqueID = -1;
      this.NetworkDetailsPanel_CloseBtnBox.Controls.Add((Control) this.NetworkPanel_CloseBtn);
      componentResourceManager.ApplyResources((object) this.NetworkDetailsPanel_CloseBtnBox, "NetworkDetailsPanel_CloseBtnBox");
      this.NetworkDetailsPanel_CloseBtnBox.HorizontalJustification = HorizontalJustificationEnum.Right;
      this.NetworkDetailsPanel_CloseBtnBox.Name = "NetworkDetailsPanel_CloseBtnBox";
      this.NetworkPanel_CloseBtn.BackColor = Color.White;
      this.NetworkPanel_CloseBtn.BtnColor = PushButtonColorEnum.BlueGrey;
      this.NetworkPanel_CloseBtn.BtnDoubleEndCaps = false;
      this.NetworkPanel_CloseBtn.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.NetworkPanel_CloseBtn, "NetworkPanel_CloseBtn");
      this.NetworkPanel_CloseBtn.Name = "NetworkPanel_CloseBtn";
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.NetworkDetailsPanel_CloseBtnBox);
      this.Controls.Add((Control) this.NetworkDetailsPanel_MainPanel);
      this.Controls.Add((Control) this.NetworkDetailsPanel_HeaderLbl);
      this.Controls.Add((Control) this.NetworkDetailsPanel_HelpButtonLabelPair);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "NetworkDetailsPanel";
      this.NetworkDetailsPanel_MainPanel.ResumeLayout(false);
      this.NetworkDetailsPanel_TreePanel.ResumeLayout(false);
      this.ConnectedAdvancedPanel.ResumeLayout(false);
      this.SecurityPanel.ResumeLayout(false);
      this.ConnectedPanel.ResumeLayout(false);
      this.GeneralPanel.ResumeLayout(false);
      this.StatisticsPanel.ResumeLayout(false);
      this.AdvancedPanel.ResumeLayout(false);
      this.NetworkDetailsPanel_CloseBtnBox.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public void InitPanel()
    {
      this.UpdateUI();
      this.IntializeTree();
      this._networkDetailsDlgOpen = true;
      this.RegisterForEvents();
      this.ActiveControl = (Control) this.NetworkDetailsPanel_Tree;
      this.NetworkDetailsPanel_Tree.Focus();
    }

    public void CleanUp()
    {
      this._networkDetailsDlgOpen = false;
      this.StopTimers();
      this.UnregisterForEvents();
    }

    public void LaunchHelp()
    {
      OnlineHelp.LaunchHelp("/details.htm");
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      using (Graphics graphics = this.CreateGraphics())
        ControlPaint.DrawBorder(graphics, new Rectangle(this.NetworkDetailsPanel_MainPanel.Location.X - 1, this.NetworkDetailsPanel_MainPanel.Location.Y - 1, this.NetworkDetailsPanel_MainPanel.Width + 2, this.NetworkDetailsPanel_MainPanel.Height + 2), Color.FromArgb(204, 204, 204), ButtonBorderStyle.Solid);
      base.OnPaint(e);
    }

    private void StartTimers()
    {
      if (this._updateTimeTimer == null)
      {
        this._updateTimeTimer = new Timer();
        this._updateTimeTimer.Interval = TimerSettings.NetworkDetailsPanel_UpdateTimeTimer_Interval;
        this._updateTimeTimer.Tick += new EventHandler(this.OnUpdateTimeTick);
        this._updateTimeTimer.Start();
      }
      if (this._updateNetworkStatsTimer != null)
        return;
      this._updateNetworkStatsTimer = new Timer();
      this._updateNetworkStatsTimer.Interval = TimerSettings.NetworkDetailsPanel_UpdateNetworkStatsTimer_Interval;
      this._updateNetworkStatsTimer.Tick += new EventHandler(this.OnUpdateNetworkStatsTick);
      this._updateNetworkStatsTimer.Start();
    }

    private void StopTimers()
    {
      if (this._updateTimeTimer != null)
      {
        this._updateTimeTimer.Enabled = false;
        this._updateTimeTimer.Stop();
        this._updateTimeTimer = (Timer) null;
      }
      if (this._updateNetworkStatsTimer == null)
        return;
      this._updateNetworkStatsTimer.Enabled = false;
      this._updateNetworkStatsTimer.Stop();
      this._updateNetworkStatsTimer = (Timer) null;
    }

    private void OnUpdateTimeTick(object sender, EventArgs e)
    {
      this.UpdateDurationValue();
    }

    private void OnUpdateNetworkStatsTick(object sender, EventArgs e)
    {
      this.RefreshConnectedInfo();
    }

    private void OnSomethingChanged(object sender, object[] eventArgs)
    {
      if (!this._networkDetailsDlgOpen)
        return;
      this.UpdateUI();
    }

    private void OnHelpButtonPressed(object sender, MouseEventArgs e)
    {
      if (MouseHelper.IgnoreMouseClick(e, (Control) sender, ((Control) sender).Enabled))
        return;
      this.LaunchHelp();
    }

    private void OnCloseBtnPressed(object sender, EventArgs e)
    {
      NetworkDetailsDialog.Singleton.Close();
    }

    private void OnTreeSelectionChanged(object sender, TreeViewEventArgs e)
    {
      this.ShowPanel(e.Node);
    }

    private void CustomInitializeComponents()
    {
      this.NetworkPanel_CloseBtn.Pressed += new CustomButtonPush.PressedDelegate(this.OnCloseBtnPressed);
      this.NetworkDetailsPanel_HelpButtonLabelPair.HelpBtnPressed += new CustomHelpButtonLabelPair.HelpBtnPressedDelegate(this.OnHelpButtonPressed);
      this.AccessibleName = "NetworkDetailsPanel";
      this.GeneralPanel_NetworkNameLbl.AccessibleName = "NetworkDetailsPanel_GeneralPanel_NetworkNameLbl";
      this.AdvancedPanel_NetworkIdLbl.AccessibleName = "NetworkDetailsPanel_GeneralPanel_BaseStationIdLbl";
      this.GeneralPanel_PreferredLbl.AccessibleName = "NetworkDetailsPanel_GeneralPanel_PreferredLbl";
      this.GeneralPanel_SupportLbl.AccessibleName = "NetworkDetailsPanel_GeneralPanel_SupportLbl";
      this.ConnectedPanel_DurationLbl.AccessibleName = "NetworkDetailsPanel_ConnectedPanel_DurationLbl";
      this.ConnectedPanel_IPAddressLbl.AccessibleName = "NetworkDetailsPanel_ConnectedPanel_IPAddressLbl";
      this.GeneralPanel_SignalLbl.AccessibleName = "NetworkDetailsPanel_ConnectedPanel_SignalLbl";
      this.SecurityPanel_ActualDomainNameLbl.AccessibleName = "NetworkDetailsPanel_SecurityPanel_ActualDomainNameLbl";
      this.SecurityPanel_EncryptedLbl.AccessibleName = "NetworkDetailsPanel_SecurityPanel_EncryptedLbl";
      this.SecurityPanel_NetworkAuthenticatedLbl.AccessibleName = "NetworkDetailsPanel_SecurityPanel_NetworkAuthenticatedLbl";
      this.StatisticsPanel_BytesReceivedLbl.AccessibleName = "NetworkDetailsPanel_StatisticsPanel_BytesReceivedLbl";
      this.StatisticsPanel_BytesSentLbl.AccessibleName = "NetworkDetailsPanel_StatisticsPanel_BytesSentLbl";
      this.StatisticsPanel_PacketsReceivedLbl.AccessibleName = "NetworkDetailsPanel_StatisticsPanel_PacketsReceivedLbl";
      this.StatisticsPanel_PacketsSentLbl.AccessibleName = "NetworkDetailsPanel_StatisticsPanel_PacketsSentLbl";
      this.AdvancedPanel_CINRLbl.AccessibleName = "NetworkDetailsPanel_AdvancedPanel_CINRLbl";
      this.AdvancedPanel_RSSILbl.AccessibleName = "NetworkDetailsPanel_AdvancedPanel_RSSILbl";
      this.ConnectedAdvancedPanel_ChannelFreqLbl.AccessibleName = "NetworkDetailsPanel_AdvancedPanel_ChannelFreqLbl";
      this.ConnectedAdvancedPanel_TransmitPowerLbl.AccessibleName = "NetworkDetailsPanel_AdvancedPanel_TransmitPowerLbl";
      this.ConnectedAdvancedPanel_BaseStationLbl.AccessibleName = "NetworkDetailsPanel_AdvancedPanel_BaseStationLbl";
      this.GeneralPanel_NetworkNameValueLbl.AccessibleName = "NetworkDetailsPanel_GeneralPanel_NetworkNameValueLbl";
      this.AdvancedPanel_NetworkIdValueLbl.AccessibleName = "NetworkDetailsPanel_GeneralPanel_BaseStationIdValueLbl";
      this.GeneralPanel_PreferredValueLbl.AccessibleName = "NetworkDetailsPanel_GeneralPanel_PreferredValueLbl";
      this.GeneralPanel_SupportValueLbl.AccessibleName = "NetworkDetailsPanel_GeneralPanel_SupportValueLbl";
      this.ConnectedPanel_DurationValueLbl.AccessibleName = "NetworkDetailsPanel_ConnectedPanel_DurationValueLbl";
      this.ConnectedPanel_IPAddressValueLbl.AccessibleName = "NetworkDetailsPanel_ConnectedPanel_IPAddressValueLbl";
      this.GeneralPanel_SignalValueLbl.AccessibleName = "NetworkDetailsPanel_ConnectedPanel_SignalValueLbl";
      this.SecurityPanel_ActualDomainNameValueLbl.AccessibleName = "NetworkDetailsPanel_SecurityPanel_ActualDomainNameValueLbl";
      this.SecurityPanel_EncryptedValueLbl.AccessibleName = "NetworkDetailsPanel_SecurityPanel_EncryptedValueLbl";
      this.SecurityPanel_NetworkAuthenticatedValueLbl.AccessibleName = "NetworkDetailsPanel_SecurityPanel_NetworkAuthenticatedValueLbl";
      this.StatisticsPanel_BytesReceivedValueLbl.AccessibleName = "NetworkDetailsPanel_StatisticsPanel_BytesReceivedValueLbl";
      this.StatisticsPanel_BytesSentValueLbl.AccessibleName = "NetworkDetailsPanel_StatisticsPanel_BytesSentValueLbl";
      this.StatisticsPanel_PacketsReceivedValueLbl.AccessibleName = "NetworkDetailsPanel_StatisticsPanel_PacketsReceivedValueLbl";
      this.StatisticsPanel_PacketsSentValueLbl.AccessibleName = "NetworkDetailsPanel_StatisticsPanel_PacketsSentValueLbl";
      this.AdvancedPanel_CINRValueLbl.AccessibleName = "NetworkDetailsPanel_AdvancedPanel_CINRValueLbl";
      this.AdvancedPanel_RSSIValueLbl.AccessibleName = "NetworkDetailsPanel_AdvancedPanel_RSSIValueLbl";
      this.ConnectedAdvancedPanel_ChannelFreqValueLbl.AccessibleName = "NetworkDetailsPanel_AdvancedPanel_ChannelFreqValueLbl";
      this.ConnectedAdvancedPanel_TransmitPowerValueLbl.AccessibleName = "NetworkDetailsPanel_AdvancedPanel_TransmitPowerValueLbl";
      this.ConnectedAdvancedPanel_BaseStationValueLbl.AccessibleName = "NetworkDetailsPanel_AdvancedPanel_BaseStationValueLbl";
      this.NetworkPanel_CloseBtn.AccessibleName = "NetworkDetailsPanel_CloseBtn";
      this.NetworkDetailsPanel_CloseBtnBox.AccessibleName = "NetworkDetailsPanel_CloseBtnBox";
      this.NetworkDetailsPanel_HelpButtonLabelPair.AccessibleName = "NetworkDetailsPanel_HelpButtonLabelPair";
      this.NetworkDetailsPanel_HeaderLbl.AccessibleName = "NetworkDetailsPanel_HeaderLbl";
      this.GeneralPanel.AccessibleName = "NetworkDetailsPanel_GeneralPanel";
      this.AdvancedPanel.AccessibleName = "NetworkDetailsPanel_SignalPanel";
      this.ConnectedPanel.AccessibleName = "NetworkDetailsPanel_ConnectedPanel";
      this.SecurityPanel.AccessibleName = "NetworkDetailsPanel_SecurityPanel";
      this.StatisticsPanel.AccessibleName = "NetworkDetailsPanel_StatisticsPanel";
      this.ConnectedAdvancedPanel.AccessibleName = "NetworkDetailsPanel_AdvancedPanel";
      this.NetworkDetailsPanel_Tree.AccessibleName = "NetworkDetailsPanel_Tree";
      this.GeneralPanel_NetworkNameLbl.Text = NetworkDetailsDlgStringHelper.GetString("GeneralPanel_NetworkNameLbl");
      this.AdvancedPanel_NetworkIdLbl.Text = NetworkDetailsDlgStringHelper.GetString("GeneralPanel_BaseStationIdLbl");
      this.GeneralPanel_PreferredLbl.Text = NetworkDetailsDlgStringHelper.GetString("GeneralPanel_PreferredLbl");
      this.GeneralPanel_SupportLbl.Text = NetworkDetailsDlgStringHelper.GetString("GeneralPanel_SupportLbl");
      this.ConnectedPanel_DurationLbl.Text = NetworkDetailsDlgStringHelper.GetString("ConnectedPanel_DurationLbl");
      this.ConnectedPanel_IPAddressLbl.Text = NetworkDetailsDlgStringHelper.GetString("ConnectedPanel_IPAddressLbl");
      this.GeneralPanel_SignalLbl.Text = NetworkDetailsDlgStringHelper.GetString("ConnectedPanel_SignalLbl");
      this.SecurityPanel_ActualDomainNameLbl.Text = NetworkDetailsDlgStringHelper.GetString("SecurityPanel_ActualDomainNameLbl");
      this.SecurityPanel_NetworkAuthenticatedLbl.Text = NetworkDetailsDlgStringHelper.GetString("SecurityPanel_NetworkAuthenticatedLbl");
      this.SecurityPanel_EncryptedLbl.Text = NetworkDetailsDlgStringHelper.GetString("SecurityPanel_EncryptedLbl");
      this.StatisticsPanel_BytesReceivedLbl.Text = NetworkDetailsDlgStringHelper.GetString("StatisticsPanel_BytesReceivedLbl");
      this.StatisticsPanel_BytesSentLbl.Text = NetworkDetailsDlgStringHelper.GetString("StatisticsPanel_BytesSentLbl");
      this.StatisticsPanel_PacketsReceivedLbl.Text = NetworkDetailsDlgStringHelper.GetString("StatisticsPanel_PacketsReceivedLbl");
      this.StatisticsPanel_PacketsSentLbl.Text = NetworkDetailsDlgStringHelper.GetString("StatisticsPanel_PacketsSentLbl");
      this.AdvancedPanel_CINRLbl.Text = NetworkDetailsDlgStringHelper.GetString("AdvancedPanel_CINRLbl");
      this.AdvancedPanel_RSSILbl.Text = NetworkDetailsDlgStringHelper.GetString("AdvancedPanel_RSSILbl");
      this.ConnectedAdvancedPanel_ChannelFreqLbl.Text = NetworkDetailsDlgStringHelper.GetString("AdvancedPanel_ChannelFreqLbl");
      this.ConnectedAdvancedPanel_TransmitPowerLbl.Text = NetworkDetailsDlgStringHelper.GetString("AdvancedPanel_TransmitPowerLbl");
      this.ConnectedAdvancedPanel_BaseStationLbl.Text = NetworkDetailsDlgStringHelper.GetString("AdvancedPanel_BaseStationLbl");
      this.NetworkPanel_CloseBtn.BtnText = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_CloseBtn");
      IEnumerator enumerator1 = this.NetworkDetailsPanel_Tree.Nodes.GetEnumerator();
      while (enumerator1.MoveNext())
      {
        switch ((string) ((TreeNode) enumerator1.Current).Tag)
        {
          case "Node1":
            ((TreeNode) enumerator1.Current).Text = NetworkDetailsDlgStringHelper.GetString("Tree_GeneralNode");
            continue;
          case "Node2":
            ((TreeNode) enumerator1.Current).Text = NetworkDetailsDlgStringHelper.GetString("Tree_AdvancedNode");
            continue;
          case "Node3":
            ((TreeNode) enumerator1.Current).Text = NetworkDetailsDlgStringHelper.GetString("Tree_ConnectedNode");
            IEnumerator enumerator2 = ((TreeNode) enumerator1.Current).Nodes.GetEnumerator();
            while (enumerator2.MoveNext())
            {
              switch ((string) ((TreeNode) enumerator2.Current).Tag)
              {
                case "Node4":
                  ((TreeNode) enumerator2.Current).Text = NetworkDetailsDlgStringHelper.GetString("Tree_SecurityNode");
                  continue;
                case "Node5":
                  ((TreeNode) enumerator2.Current).Text = NetworkDetailsDlgStringHelper.GetString("Tree_StatisticsNode");
                  continue;
                case "Node6":
                  ((TreeNode) enumerator2.Current).Text = NetworkDetailsDlgStringHelper.GetString("Tree_AdvancedNode");
                  continue;
                default:
                  continue;
              }
            }
            continue;
          default:
            continue;
        }
      }
      SizeHelper.ResizeCustomControls(this.Controls);
    }

    private void RegisterForEvents()
    {
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnSomethingChanged), (object) this, "WiMAXUI.OnMediaStatusChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnSomethingChanged), (object) this, "WiMAXUI.OnAdapterListChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnSomethingChanged), (object) this, "WiMAXUI.OnIntelCUControlChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnSomethingChanged), (object) this, "WiMAXSP.OnIPAddressStateChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnSomethingChanged), (object) this, "WiMAXUI.OnAvailableNetworkListSelectionChanged");
    }

    private void UnregisterForEvents()
    {
      Eventing.DeRegisterAllUIEvents((object) this);
    }

    private void IntializeTree()
    {
      if (NetworkHandler.ConnectedNetworks.Count == 0)
      {
        this.NetworkDetailsPanel_Tree.CollapseAll();
        TreeNode[] treeNodeArray = this.NetworkDetailsPanel_Tree.Nodes.Find("Tree_GeneralNode", true);
        if (treeNodeArray.Length == 1)
        {
          this.ShowPanel(treeNodeArray[0]);
          this.NetworkDetailsPanel_Tree.SelectedNode = treeNodeArray[0];
        }
      }
      else
      {
        this.NetworkDetailsPanel_Tree.ExpandAll();
        TreeNode[] treeNodeArray = this.NetworkDetailsPanel_Tree.Nodes.Find("Tree_ConnectedNode", true);
        if (treeNodeArray.Length == 1)
        {
          this.ShowPanel(treeNodeArray[0]);
          this.NetworkDetailsPanel_Tree.SelectedNode = treeNodeArray[0];
        }
      }
      this.ActiveControl = (Control) this.NetworkDetailsPanel_Tree;
    }

    private void ShowPanel(TreeNode selectedNode)
    {
      this.GeneralPanel.Visible = false;
      this.AdvancedPanel.Visible = false;
      this.ConnectedPanel.Visible = false;
      this.SecurityPanel.Visible = false;
      this.StatisticsPanel.Visible = false;
      this.ConnectedAdvancedPanel.Visible = false;
      if (selectedNode.Tag.ToString() == "Node1")
        this.GeneralPanel.Visible = true;
      else if (selectedNode.Tag.ToString() == "Node2")
        this.AdvancedPanel.Visible = true;
      else if (selectedNode.Tag.ToString() == "Node3")
        this.ConnectedPanel.Visible = true;
      else if (selectedNode.Tag.ToString() == "Node4")
        this.SecurityPanel.Visible = true;
      else if (selectedNode.Tag.ToString() == "Node5")
      {
        this.StatisticsPanel.Visible = true;
      }
      else
      {
        if (!(selectedNode.Tag.ToString() == "Node6"))
          return;
        this.ConnectedAdvancedPanel.Visible = true;
      }
    }

    private void UpdateUI()
    {
      try
      {
        this._ndi = (NetworkDisplayItem) null;
        for (int index = 0; index < NetworkHandler.AvailableNetworks.Count; ++index)
        {
          if (NetworkHandler.IsSameNetwork(NetworkHandler.AvailableNetworks[index], AppFramework.Dashboard.TheNetworkListPanel.TheNetworkListBox.GetSelectedNDI()))
          {
            this._ndi = NetworkHandler.AvailableNetworks[index];
            break;
          }
        }
      }
      catch
      {
        this._ndi = NetworkHandler.ConnectedNetworks.Count != 0 ? NetworkHandler.ConnectedNetworks[0] : AppFramework.Dashboard.TheNetworkListPanel.TheNetworkListBox.GetSelectedNDI();
      }
      if (this._ndi == null)
      {
        this.UpdateForInformationNotAvailable();
      }
      else
      {
        this.NetworkDetailsPanel_HeaderLbl.Text = string.Format(NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_HeaderLbl"), (object) this._ndi.NetworkName);
        if (!MediaHandler.IntelCUIsInControl || !MediaHandler.TheMedia.WiMAXIsReady)
        {
          this.StopTimers();
          this.UpdateForInformationNotAvailable();
        }
        else if (!AdapterHandler.TheAdapter.RadioIsOn() || NetworkHandler.ConnectedNetworks.Count == 0)
        {
          this.StopTimers();
          this.UpdateForNonConnectedNetwork();
        }
        else
        {
          this.UpdateForConnectedNetwork();
          this.StartTimers();
        }
      }
    }

    private void UpdateForInformationNotAvailable()
    {
      this.GeneralPanel_NetworkNameValueLbl.Icon = (Bitmap) null;
      this.GeneralPanel_NetworkNameValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
      this.AdvancedPanel_NetworkIdValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
      this.GeneralPanel_PreferredValueLbl.Icon = (Bitmap) null;
      this.GeneralPanel_PreferredValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
      this.GeneralPanel_SupportValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
      this.GeneralPanel_SupportValueLbl.ControlType = ControlTypeEnum.TextBox;
      this.ConnectedPanel_DurationValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
      this.ConnectedPanel_IPAddressValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
      this.ConnectedPanel_IPAddressValueLbl.ForeColor = Color.Black;
      this.GeneralPanel_SignalValueLbl.Icon = (Bitmap) null;
      this.GeneralPanel_SignalValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
      this.SecurityPanel_ActualDomainNameValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
      this.SecurityPanel_EncryptedValueLbl.Icon = (Bitmap) null;
      this.SecurityPanel_EncryptedValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
      this.SecurityPanel_NetworkAuthenticatedValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
      this.SecurityPanel_NetworkAuthenticatedValueLbl.Icon = (Bitmap) null;
      this.StatisticsPanel_BytesReceivedValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
      this.StatisticsPanel_BytesSentValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
      this.StatisticsPanel_PacketsReceivedValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
      this.StatisticsPanel_PacketsSentValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
      this.AdvancedPanel_CINRValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
      this.AdvancedPanel_RSSIValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
      this.ConnectedAdvancedPanel_ChannelFreqValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
      this.ConnectedAdvancedPanel_TransmitPowerValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
      this.ConnectedAdvancedPanel_BaseStationValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
    }

    private void UpdateForNonConnectedNetwork()
    {
      this.GeneralPanel_NetworkNameValueLbl.Icon = WiMAXDisplayService.Singleton.GetHomeNetworkIcon(this._ndi.WmxNetwork);
      this.GeneralPanel_NetworkNameValueLbl.Text = WiMAXDisplayService.Singleton.GetNetworkNameDisplayText(this._ndi.WmxNetwork);
      this.AdvancedPanel_NetworkIdValueLbl.Text = this._ndi.WmxNetwork.NSPId.ToString("x");
      this.GeneralPanel_PreferredValueLbl.Icon = WiMAXDisplayService.Singleton.GetPreferredIcon(this._ndi.WmxNetwork);
      this.GeneralPanel_PreferredValueLbl.Text = WiMAXDisplayService.Singleton.GetPreferredText(this._ndi.WmxNetwork);
      this.GeneralPanel_SupportValueLbl.Text = WiMAXDisplayService.Singleton.GetCustomerSupportURLText(this._ndi.WmxNetwork.CustomerSupportURL, TechSupportDlgStringHelper.GetString("TechSupportPanel_InformationNotAvailable"));
      this.GeneralPanel_SupportValueLbl.ControlType = !(this.GeneralPanel_SupportValueLbl.Text == TechSupportDlgStringHelper.GetString("TechSupportPanel_InformationNotAvailable")) ? ControlTypeEnum.LinkLabel : ControlTypeEnum.TextBox;
      this.GeneralPanel_SignalValueLbl.Icon = WiMAXDisplayService.Singleton.GetSmallSignalIcon(this._ndi.WmxNetwork.SignalBars);
      this.GeneralPanel_SignalValueLbl.Text = string.Format(NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_SignalFormat"), (object) WiMAXDisplayService.Singleton.GetSignalDisplayText(this._ndi.WmxNetwork.SignalBars));
      this.AdvancedPanel_CINRValueLbl.Text = WiMAXDisplayService.Singleton.GetCINRDisplayText(this._ndi.WmxNetwork.CINR);
      this.AdvancedPanel_RSSIValueLbl.Text = WiMAXDisplayService.Singleton.GetRSSIDisplayText(this._ndi.WmxNetwork.RSSI);
      this.ConnectedPanel_DurationValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_NotConnected");
      this.ConnectedPanel_IPAddressValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_NotConnected");
      this.ConnectedPanel_IPAddressValueLbl.ForeColor = Color.Black;
      this.SecurityPanel_ActualDomainNameValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_NotConnected");
      this.SecurityPanel_EncryptedValueLbl.Icon = (Bitmap) null;
      this.SecurityPanel_EncryptedValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_NotConnected");
      this.SecurityPanel_NetworkAuthenticatedValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_NotConnected");
      this.SecurityPanel_NetworkAuthenticatedValueLbl.Icon = (Bitmap) null;
      this.StatisticsPanel_BytesReceivedValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_NotConnected");
      this.StatisticsPanel_BytesSentValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_NotConnected");
      this.StatisticsPanel_PacketsReceivedValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_NotConnected");
      this.StatisticsPanel_PacketsSentValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_NotConnected");
      this.ConnectedAdvancedPanel_ChannelFreqValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_NotConnected");
      this.ConnectedAdvancedPanel_TransmitPowerValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_NotConnected");
      this.ConnectedAdvancedPanel_BaseStationValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_NotConnected");
    }

    private void UpdateForConnectedNetwork()
    {
      IPAddressStateEnum ipAddressState = Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.IPAddressState;
      this.GeneralPanel_NetworkNameValueLbl.Icon = WiMAXDisplayService.Singleton.GetHomeNetworkIcon(this._ndi.WmxNetwork);
      this.GeneralPanel_NetworkNameValueLbl.Text = WiMAXDisplayService.Singleton.GetNetworkNameDisplayText(this._ndi.WmxNetwork);
      this.AdvancedPanel_NetworkIdValueLbl.Text = this._ndi.WmxNetwork.NSPId.ToString("x");
      this.GeneralPanel_PreferredValueLbl.Icon = WiMAXDisplayService.Singleton.GetPreferredIcon(this._ndi.WmxNetwork);
      this.GeneralPanel_PreferredValueLbl.Text = WiMAXDisplayService.Singleton.GetPreferredText(this._ndi.WmxNetwork);
      this.GeneralPanel_SupportValueLbl.Text = WiMAXDisplayService.Singleton.GetCustomerSupportURLText(this._ndi.WmxNetwork.CustomerSupportURL, TechSupportDlgStringHelper.GetString("TechSupportPanel_InformationNotAvailable"));
      this.GeneralPanel_SupportValueLbl.ControlType = !(this.GeneralPanel_SupportValueLbl.Text == TechSupportDlgStringHelper.GetString("TechSupportPanel_InformationNotAvailable")) ? ControlTypeEnum.LinkLabel : ControlTypeEnum.TextBox;
      this.GeneralPanel_SignalValueLbl.Icon = WiMAXDisplayService.Singleton.GetSmallSignalIcon(this._ndi.WmxNetwork.SignalBars);
      this.GeneralPanel_SignalValueLbl.Text = string.Format(NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_SignalFormat"), (object) WiMAXDisplayService.Singleton.GetSignalDisplayText(this._ndi.WmxNetwork.SignalBars));
      this.AdvancedPanel_CINRValueLbl.Text = WiMAXDisplayService.Singleton.GetCINRDisplayText(this._ndi.WmxNetwork.CINR);
      this.AdvancedPanel_RSSIValueLbl.Text = WiMAXDisplayService.Singleton.GetRSSIDisplayText(this._ndi.WmxNetwork.RSSI);
      this.ConnectedPanel_IPAddressValueLbl.Text = WiMAXDisplayService.Singleton.GetIPAddressDisplayText(this._ndi.WmxNetwork.Connection.IPv4Address, ipAddressState);
      if (ipAddressState == IPAddressStateEnum.Invalid)
        this.ConnectedPanel_IPAddressValueLbl.ForeColor = Color.Red;
      else
        this.ConnectedPanel_IPAddressValueLbl.ForeColor = Color.Black;
      if (this._ndi.WmxNetwork.Connection.SecurityInfoValid)
      {
        this.SecurityPanel_ActualDomainNameValueLbl.Text = this._ndi.WmxNetwork.Connection.ActualRealm;
        this.SecurityPanel_EncryptedValueLbl.Icon = WiMAXDisplayService.Singleton.GetEncryptedIcon(this._ndi.WmxNetwork);
        this.SecurityPanel_EncryptedValueLbl.Text = WiMAXDisplayService.Singleton.GetEncryptedText(this._ndi.WmxNetwork);
        this.SecurityPanel_NetworkAuthenticatedValueLbl.Text = WiMAXDisplayService.Singleton.GetNetworkAuthenticatedText(this._ndi.WmxNetwork);
        this.SecurityPanel_NetworkAuthenticatedValueLbl.Icon = WiMAXDisplayService.Singleton.GetNetworkAuthenticatedIcon(this._ndi.WmxNetwork);
      }
      else
      {
        this.SecurityPanel_ActualDomainNameValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
        this.SecurityPanel_EncryptedValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
        this.SecurityPanel_EncryptedValueLbl.Icon = (Bitmap) null;
        this.SecurityPanel_NetworkAuthenticatedValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
        this.SecurityPanel_NetworkAuthenticatedValueLbl.Icon = (Bitmap) null;
      }
      this.RefreshConnectedInfo();
      this.UpdateDurationValue();
    }

    private void UpdateDurationValue()
    {
      if (!MediaHandler.TheMedia.WiMAXIsReady || !MediaHandler.IntelCUIsInControl || (!AdapterHandler.TheAdapter.RadioIsOn() || NetworkHandler.ConnectedNetworks.Count <= 0))
        return;
      this.ConnectedPanel_DurationValueLbl.Text = ConnectionSubDetailUptime.ConnectedTime;
    }

    private void RefreshConnectedInfo()
    {
      if (NetworkHandler.ConnectedNetworks.Count <= 0)
        return;
      NetworkDisplayItem ndi = (NetworkDisplayItem) null;
      NetworkHandler.Singleton.GetConnectedNetwork(ref ndi);
      if (ndi != null && ndi.WmxNetwork.Connection.StatisticsInfoValid)
      {
        this.StatisticsPanel_BytesReceivedValueLbl.Text = WiMAXDisplayService.Singleton.GetBytesDisplayText(ndi.WmxNetwork.Connection.BytesReceived);
        this.StatisticsPanel_BytesSentValueLbl.Text = WiMAXDisplayService.Singleton.GetBytesDisplayText(ndi.WmxNetwork.Connection.BytesSent);
        this.StatisticsPanel_PacketsReceivedValueLbl.Text = WiMAXDisplayService.Singleton.GetPacketsDisplayText(ndi.WmxNetwork.Connection.PacketsReceived);
        this.StatisticsPanel_PacketsSentValueLbl.Text = WiMAXDisplayService.Singleton.GetPacketsDisplayText(ndi.WmxNetwork.Connection.PacketsSent);
      }
      else
      {
        this.StatisticsPanel_BytesReceivedValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
        this.StatisticsPanel_BytesSentValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
        this.StatisticsPanel_PacketsReceivedValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
        this.StatisticsPanel_PacketsSentValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
      }
      if (ndi != null && ndi.WmxNetwork.Connection.LinkStatusInfoValid)
      {
        this.ConnectedAdvancedPanel_ChannelFreqValueLbl.Text = WiMAXDisplayService.Singleton.GetFrequencyDisplayText(ndi.WmxNetwork.Connection.Frequency);
        this.ConnectedAdvancedPanel_TransmitPowerValueLbl.Text = WiMAXDisplayService.Singleton.GetTransmitPowerDisplayText(ndi.WmxNetwork.Connection.Power);
        this.ConnectedAdvancedPanel_BaseStationValueLbl.Text = ndi.WmxNetwork.Connection.BaseStationId;
      }
      else
      {
        this.ConnectedAdvancedPanel_ChannelFreqValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
        this.ConnectedAdvancedPanel_TransmitPowerValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
        this.ConnectedAdvancedPanel_BaseStationValueLbl.Text = NetworkDetailsDlgStringHelper.GetString("NetworkDetailsPanel_InformationNotAvailable");
      }
    }
  }
}
