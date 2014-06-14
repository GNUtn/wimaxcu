// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.TechSupportPanel
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.SDKInterop;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class TechSupportPanel : UserControl
  {
    private List<ProfileDisplayItem> _profileList = new List<ProfileDisplayItem>();
    private Hashtable _profileContactInfoHash = new Hashtable();
    private List<ProfilesConnectedTo> _profilesConnectedToList;
    private IContainer components;
    private Label TechSupportPanel_HeaderLbl;
    private CustomButtonPushHorizBox TechSupportPanel_CloseBtnBox;
    private CustomButtonPush TechSupportPanel_CloseBtn;
    private CustomLabelSeparator TechSupportPanel_ButtonBarSeperator;
    private DataGridView TechSupportPanel_GridView;
    private CustomButtonPush TechSupportPanel_ShowOtherOperatorsBtn;
    private DataGridViewTextBoxColumn CompanyColumn;
    private DataGridViewLinkColumn SupportWebsiteColumn;
    private CustomHelpButtonLabelPair TechSupportPanel_HelpButtonLabelPair;

    public TechSupportPanel()
    {
      this.InitializeComponent();
      this.CustomInitializeComponents();
      this.RegisterForEvents();
    }

    public void InitPanel()
    {
      this.SquirrelInfo();
      this._profilesConnectedToList = new List<ProfilesConnectedTo>();
      ProfilesThatUserHasConnectedTo.GetProfiles(ref this._profilesConnectedToList);
      bool flag = false;
      foreach (ProfileDisplayItem profileDisplayItem in this._profileList)
      {
        if (profileDisplayItem.Preferred)
          flag = true;
      }
      if (this._profilesConnectedToList.Count != 0 || flag)
      {
        this.FillDataGridLimited();
        this.TechSupportPanel_ShowOtherOperatorsBtn.BtnText = TechSupportDlgStringHelper.GetString("TechSupportPanel_ShowOtherOperatorsBtn");
        if (this._profileList.Count == 0 && !MediaHandler.TheMedia.WiMAXIsReady)
          this.TechSupportPanel_ShowOtherOperatorsBtn.Visible = false;
        else
          this.TechSupportPanel_ShowOtherOperatorsBtn.Visible = true;
      }
      else
      {
        this.FillDataGridAll();
        this.TechSupportPanel_ShowOtherOperatorsBtn.BtnText = TechSupportDlgStringHelper.GetString("TechSupportPanel_HideOtherOperatorsBtn");
        this.TechSupportPanel_ShowOtherOperatorsBtn.Visible = false;
      }
      this.ActiveControl = (Control) this.TechSupportPanel_CloseBtn;
      this.TechSupportPanel_CloseBtn.Focus();
    }

    public void CleanUp()
    {
    }

    public void SquirrelInfo()
    {
      try
      {
        if (!MediaHandler.TheMedia.WiMAXIsReady || this._profileList != null && this._profileList.Count != 0 && this._profileList.Count == ProfileHandler.Singleton.Profiles.Count)
          return;
        this._profileList = new List<ProfileDisplayItem>((IEnumerable<ProfileDisplayItem>) ProfileHandler.Singleton.Profiles);
        this._profileContactInfoHash.Clear();
        foreach (ProfileDisplayItem profileDisplayItem in this._profileList)
        {
          string nspName = MiscUtilities.ParseProfileName(profileDisplayItem.TheProfile.profileName);
          List<WIMAX_API_CONTACT_INFO> customerSupportInfoList = new List<WIMAX_API_CONTACT_INFO>();
          if (NetworkHandler.Singleton.GetCustomerSupportInfoForNSPName(nspName, ref customerSupportInfoList) == 0 && customerSupportInfoList.Count > 0 && !this._profileContactInfoHash.ContainsKey((object) nspName))
            this._profileContactInfoHash.Add((object) nspName, (object) MiscUtilities.AddHttpPrefix(customerSupportInfoList[0].URI));
        }
      }
      catch (Exception ex)
      {
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Warning, (object) this, Logging.GetMessageForException(ex));
      }
    }

    public void LaunchHelp()
    {
      OnlineHelp.LaunchHelp("/support.htm");
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      ControlPaint.DrawBorder(e.Graphics, new Rectangle(this.TechSupportPanel_GridView.Location.X - 1, this.TechSupportPanel_GridView.Location.Y - 1, this.TechSupportPanel_GridView.Width + 2, this.TechSupportPanel_GridView.Height + 2), Color.FromArgb(204, 204, 204), ButtonBorderStyle.Solid);
      base.OnPaint(e);
    }

    private void OnCloseBtnPressed(object sender, EventArgs e)
    {
      ((Form) this.Parent).Close();
    }

    private void OnShowOtherOperatorsBtnPressed(object sender, EventArgs e)
    {
      if (this.TechSupportPanel_ShowOtherOperatorsBtn.BtnText == TechSupportDlgStringHelper.GetString("TechSupportPanel_ShowOtherOperatorsBtn"))
      {
        this.TechSupportPanel_ShowOtherOperatorsBtn.BtnText = TechSupportDlgStringHelper.GetString("TechSupportPanel_HideOtherOperatorsBtn");
        this.FillDataGridAll();
      }
      else
      {
        this.TechSupportPanel_ShowOtherOperatorsBtn.BtnText = TechSupportDlgStringHelper.GetString("TechSupportPanel_ShowOtherOperatorsBtn");
        this.FillDataGridLimited();
      }
    }

    private void OnCellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex < 0 || e.RowIndex < 0 || !(this.TechSupportPanel_GridView.Columns[e.ColumnIndex].DataPropertyName == "SupportURL"))
        return;
      List<ContactInfoType> list = this.TechSupportPanel_GridView.DataSource as List<ContactInfoType>;
      string @string = TechSupportDlgStringHelper.GetString("TechSupportPanel_InformationNotAvailable");
      if (!(list[e.RowIndex].SupportURL != @string))
        return;
      UIHelper.LaunchDefaultBrowser(list[e.RowIndex].SupportURL);
    }

    private void OnGridViewSelectionChanged(object sender, EventArgs e)
    {
      this.TechSupportPanel_GridView.ClearSelection();
    }

    private void OnHelpButtonPressed(object sender, MouseEventArgs e)
    {
      if (MouseHelper.IgnoreMouseClick(e, (Control) sender, ((Control) sender).Enabled))
        return;
      this.LaunchHelp();
    }

    public void OnRestoreNetworkSettingsComplete(object sender, object[] eventArgs)
    {
      this._profileList = (List<ProfileDisplayItem>) null;
      this.SquirrelInfo();
    }

    public void OnProfileListChanged(object sender, object[] eventArgs)
    {
      this._profileList = (List<ProfileDisplayItem>) null;
      this.SquirrelInfo();
    }

    private void CustomInitializeComponents()
    {
      this.AccessibleName = "TechSupportPanel";
      this.TechSupportPanel_HeaderLbl.AccessibleName = "TechSupportPanel_HeaderLbl";
      this.TechSupportPanel_CloseBtn.AccessibleName = "TechSupportPanel_CloseBtn";
      this.TechSupportPanel_ShowOtherOperatorsBtn.AccessibleName = "TechSupportPanel_ShowAllBtn";
      this.TechSupportPanel_ButtonBarSeperator.AccessibleName = "TechSupportPanel_ButtonBarSeperator";
      this.TechSupportPanel_GridView.AccessibleName = "TechSupportPanel_GridView";
      this.TechSupportPanel_CloseBtnBox.AccessibleName = "TechSupportPanel_CloseBtnBox";
      this.TechSupportPanel_HelpButtonLabelPair.AccessibleName = "TechSupportPanel_HelpButtonLabelPair";
      this.TechSupportPanel_HeaderLbl.Text = TechSupportDlgStringHelper.GetString("TechSupportPanel_HeaderLbl");
      this.TechSupportPanel_CloseBtn.BtnText = TechSupportDlgStringHelper.GetString("TechSupportPanel_CloseBtn");
      this.TechSupportPanel_ShowOtherOperatorsBtn.BtnText = TechSupportDlgStringHelper.GetString("TechSupportPanel_ShowOtherOperatorsBtn");
      this.TechSupportPanel_GridView.Columns["CompanyColumn"].HeaderText = TechSupportDlgStringHelper.GetString("TechSupportPanel_CompanyHeader");
      this.TechSupportPanel_GridView.Columns["SupportWebsiteColumn"].HeaderText = TechSupportDlgStringHelper.GetString("TechSupportPanel_SupportWebsiteHeader");
      this.TechSupportPanel_ButtonBarSeperator.Text = DashboardStringHelper.GetString("Empty");
      this.TechSupportPanel_GridView.ClearSelection();
      this.TechSupportPanel_CloseBtn.Pressed += new CustomButtonPush.PressedDelegate(this.OnCloseBtnPressed);
      this.TechSupportPanel_ShowOtherOperatorsBtn.Pressed += new CustomButtonPush.PressedDelegate(this.OnShowOtherOperatorsBtnPressed);
      this.TechSupportPanel_GridView.SelectionChanged += new EventHandler(this.OnGridViewSelectionChanged);
      this.TechSupportPanel_HelpButtonLabelPair.HelpBtnPressed += new CustomHelpButtonLabelPair.HelpBtnPressedDelegate(this.OnHelpButtonPressed);
      SizeHelper.ResizeCustomControls(this.Controls);
    }

    private void FillDataGridLimited()
    {
      List<ContactInfoType> contactInfoList = new List<ContactInfoType>();
      this.AddCurrentlyConnectedNWContactInfo(contactInfoList, false);
      this.AddPreferredNetworkContactInfo(contactInfoList, false);
      this.AddPreviouslyConnectedNetworksContactInfo(contactInfoList, false);
      contactInfoList.Sort(new Comparison<ContactInfoType>(TechSupportPanel.CompareContactInfo));
      this.AddOEMContactInfo(contactInfoList);
      this.AddIntelContactInfo(contactInfoList);
      this.TechSupportPanel_GridView.DataSource = (object) contactInfoList;
      this.FormatInformationNotAvailableCells();
    }

    private void FillDataGridAll()
    {
      int num = 0;
      List<ContactInfoType> contactInfoList = new List<ContactInfoType>();
      if (num + this.AddCurrentlyConnectedNWContactInfo(contactInfoList, true) + this.AddPreferredNetworkContactInfo(contactInfoList, true) + this.AddAllKnownProfilesContactInfo(contactInfoList) == 0)
        this.AddPreviouslyConnectedNetworksContactInfo(contactInfoList, true);
      contactInfoList.Sort(new Comparison<ContactInfoType>(TechSupportPanel.CompareContactInfo));
      this.AddOEMContactInfo(contactInfoList);
      this.AddIntelContactInfo(contactInfoList);
      this.TechSupportPanel_GridView.DataSource = (object) contactInfoList;
      this.FormatInformationNotAvailableCells();
    }

    private void AddIntelContactInfo(List<ContactInfoType> contactInfoList)
    {
      this.AddItemToList(contactInfoList, new ContactInfoType()
      {
        CompanyName = TechSupportDlgStringHelper.GetString("TechSupportPanel_IntelCompanyName"),
        SupportURL = MiscUtilities.AddHttpPrefix(TechSupportDlgStringHelper.GetString("TechSupportPanel_IntelSupportURL"))
      });
    }

    private int AddCurrentlyConnectedNWContactInfo(List<ContactInfoType> contactInfoList, bool includeOperatorsWithNoSupportURL)
    {
      int num = 0;
      if (NetworkHandler.ConnectedNetworks.Count > 0 && !string.IsNullOrEmpty(NetworkHandler.ConnectedNetworks[0].WmxNetwork.CustomerSupportURL) && !string.IsNullOrEmpty(NetworkHandler.ConnectedNetworks[0].WmxNetwork.NSPName))
      {
        this.AddItemToList(contactInfoList, new ContactInfoType()
        {
          CompanyName = NetworkHandler.ConnectedNetworks[0].WmxNetwork.NSPName,
          SupportURL = MiscUtilities.AddHttpPrefix(NetworkHandler.ConnectedNetworks[0].WmxNetwork.CustomerSupportURL)
        }, includeOperatorsWithNoSupportURL);
        ++num;
      }
      return num;
    }

    private int AddPreviouslyConnectedNetworksContactInfo(List<ContactInfoType> contactInfoList, bool includeOperatorsWithNoSupportURL)
    {
      int num = 0;
      foreach (ProfilesConnectedTo profilesConnectedTo in this._profilesConnectedToList)
      {
        ContactInfoType newContactInfo = new ContactInfoType();
        newContactInfo.CompanyName = profilesConnectedTo.NSPName;
        foreach (ProfileDisplayItem profileDisplayItem in ProfileHandler.Singleton.Profiles)
        {
          if ((int) profilesConnectedTo.ProfileID == (int) profileDisplayItem.TheProfile.profileId)
          {
            newContactInfo.CompanyName = MiscUtilities.ParseProfileName(profileDisplayItem.TheProfile.profileName);
            break;
          }
        }
        newContactInfo.SupportURL = this.GetSupportURL(newContactInfo.CompanyName, profilesConnectedTo.CustomerSupportURL);
        this.AddItemToList(contactInfoList, newContactInfo, includeOperatorsWithNoSupportURL);
        ++num;
      }
      return num;
    }

    private int AddPreferredNetworkContactInfo(List<ContactInfoType> contactInfoList, bool includeOperatorsWithNoSupportURL)
    {
      int num = 0;
      foreach (ProfileDisplayItem profileDisplayItem in this._profileList)
      {
        if (profileDisplayItem.Preferred)
        {
          ContactInfoType newContactInfo = new ContactInfoType();
          newContactInfo.CompanyName = MiscUtilities.ParseProfileName(profileDisplayItem.TheProfile.profileName);
          string customerSupportURL = "";
          if (this._profileContactInfoHash.ContainsKey((object) newContactInfo.CompanyName))
            customerSupportURL = (string) this._profileContactInfoHash[(object) newContactInfo.CompanyName];
          newContactInfo.SupportURL = this.GetSupportURL(newContactInfo.CompanyName, customerSupportURL);
          this.AddItemToList(contactInfoList, newContactInfo, includeOperatorsWithNoSupportURL);
          ++num;
        }
      }
      return num;
    }

    private int AddAllKnownProfilesContactInfo(List<ContactInfoType> contactInfoList)
    {
      int num = 0;
      foreach (ProfileDisplayItem profileDisplayItem in this._profileList)
      {
        ContactInfoType newContactInfo = new ContactInfoType();
        newContactInfo.CompanyName = MiscUtilities.ParseProfileName(profileDisplayItem.TheProfile.profileName);
        string customerSupportURL = "";
        if (this._profileContactInfoHash.ContainsKey((object) newContactInfo.CompanyName))
          customerSupportURL = (string) this._profileContactInfoHash[(object) newContactInfo.CompanyName];
        newContactInfo.SupportURL = this.GetSupportURL(newContactInfo.CompanyName, customerSupportURL);
        this.AddItemToList(contactInfoList, newContactInfo);
        ++num;
      }
      return num;
    }

    private void AddOEMContactInfo(List<ContactInfoType> contactInfoList)
    {
      OEM oemInfo = OEMHelper.GetOEMInfo();
      if (oemInfo == null || string.IsNullOrEmpty(oemInfo.ContactInfo.Header) || string.IsNullOrEmpty(oemInfo.ContactInfo.URL))
        return;
      this.AddItemToList(contactInfoList, new ContactInfoType()
      {
        CompanyName = oemInfo.ContactInfo.Header,
        SupportURL = MiscUtilities.AddHttpPrefix(oemInfo.ContactInfo.URL)
      });
    }

    private string GetSupportURL(string nspName, string customerSupportURL)
    {
      if (!MediaHandler.TheMedia.WiMAXIsReady)
        return MiscUtilities.AddHttpPrefix(customerSupportURL);
      List<WIMAX_API_CONTACT_INFO> customerSupportInfoList = new List<WIMAX_API_CONTACT_INFO>();
      if (NetworkHandler.Singleton.GetCustomerSupportInfoForNSPName(nspName, ref customerSupportInfoList) == 0 && customerSupportInfoList.Count > 0)
        return MiscUtilities.AddHttpPrefix(customerSupportInfoList[0].URI);
      else
        return MiscUtilities.AddHttpPrefix(customerSupportURL);
    }

    private void AddItemToList(List<ContactInfoType> contactInfoList, ContactInfoType newContactInfo)
    {
      this.AddItemToList(contactInfoList, newContactInfo, true);
    }

    private void AddItemToList(List<ContactInfoType> contactInfoList, ContactInfoType newContactInfo, bool includeOperatorsWithNoSupportURL)
    {
      if (newContactInfo == null || string.IsNullOrEmpty(newContactInfo.CompanyName))
        return;
      bool flag = false;
      foreach (ContactInfoType contactInfoType in contactInfoList)
      {
        if (contactInfoType.CompanyName == newContactInfo.CompanyName && contactInfoType.SupportURL == newContactInfo.SupportURL)
        {
          flag = true;
          break;
        }
      }
      if (flag)
        return;
      if (string.IsNullOrEmpty(newContactInfo.SupportURL))
      {
        if (!includeOperatorsWithNoSupportURL)
          return;
        contactInfoList.Add(new ContactInfoType()
        {
          CompanyName = newContactInfo.CompanyName,
          SupportURL = TechSupportDlgStringHelper.GetString("TechSupportPanel_InformationNotAvailable")
        });
      }
      else
        contactInfoList.Add(newContactInfo);
    }

    private void FormatInformationNotAvailableCells()
    {
      string @string = TechSupportDlgStringHelper.GetString("TechSupportPanel_InformationNotAvailable");
      for (int index = 0; index < this.TechSupportPanel_GridView.Rows.Count; ++index)
      {
        if (this.TechSupportPanel_GridView.Rows[index].Cells[1] is DataGridViewLinkCell && (string) this.TechSupportPanel_GridView.Rows[index].Cells[1].Value == @string)
        {
          ((DataGridViewLinkCell) this.TechSupportPanel_GridView.Rows[index].Cells[1]).LinkBehavior = LinkBehavior.NeverUnderline;
          ((DataGridViewLinkCell) this.TechSupportPanel_GridView.Rows[index].Cells[1]).LinkColor = Color.Black;
          ((DataGridViewLinkCell) this.TechSupportPanel_GridView.Rows[index].Cells[1]).ActiveLinkColor = Color.Black;
          ((DataGridViewLinkCell) this.TechSupportPanel_GridView.Rows[index].Cells[1]).VisitedLinkColor = Color.Black;
          ((DataGridViewLinkCell) this.TechSupportPanel_GridView.Rows[index].Cells[1]).LinkVisited = false;
        }
      }
    }

    private static int CompareContactInfo(ContactInfoType x, ContactInfoType y)
    {
      return x.CompanyName.CompareTo(y.CompanyName);
    }

    private void RegisterForEvents()
    {
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnRestoreNetworkSettingsComplete), (object) this, "WiMAXSP.OnRestoreNetworkSettingsComplete");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnProfileListChanged), (object) this, "WiMAXUI.OnProfileListChanged");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TechSupportPanel));
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      this.TechSupportPanel_HeaderLbl = new Label();
      this.TechSupportPanel_CloseBtnBox = new CustomButtonPushHorizBox();
      this.TechSupportPanel_CloseBtn = new CustomButtonPush();
      this.TechSupportPanel_ButtonBarSeperator = new CustomLabelSeparator();
      this.TechSupportPanel_GridView = new DataGridView();
      this.CompanyColumn = new DataGridViewTextBoxColumn();
      this.SupportWebsiteColumn = new DataGridViewLinkColumn();
      this.TechSupportPanel_ShowOtherOperatorsBtn = new CustomButtonPush();
      this.TechSupportPanel_HelpButtonLabelPair = new CustomHelpButtonLabelPair();
      this.TechSupportPanel_CloseBtnBox.SuspendLayout();
      this.TechSupportPanel_GridView.BeginInit();
      this.SuspendLayout();
      this.TechSupportPanel_HeaderLbl.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.TechSupportPanel_HeaderLbl, "TechSupportPanel_HeaderLbl");
      this.TechSupportPanel_HeaderLbl.Name = "TechSupportPanel_HeaderLbl";
      this.TechSupportPanel_CloseBtnBox.Controls.Add((Control) this.TechSupportPanel_CloseBtn);
      componentResourceManager.ApplyResources((object) this.TechSupportPanel_CloseBtnBox, "TechSupportPanel_CloseBtnBox");
      this.TechSupportPanel_CloseBtnBox.HorizontalJustification = HorizontalJustificationEnum.Right;
      this.TechSupportPanel_CloseBtnBox.Name = "TechSupportPanel_CloseBtnBox";
      this.TechSupportPanel_CloseBtn.BackColor = Color.White;
      this.TechSupportPanel_CloseBtn.BtnColor = PushButtonColorEnum.BlueGrey;
      this.TechSupportPanel_CloseBtn.BtnDoubleEndCaps = false;
      this.TechSupportPanel_CloseBtn.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.TechSupportPanel_CloseBtn, "TechSupportPanel_CloseBtn");
      this.TechSupportPanel_CloseBtn.Name = "TechSupportPanel_CloseBtn";
      this.TechSupportPanel_ButtonBarSeperator.BackColor = Color.White;
      componentResourceManager.ApplyResources((object) this.TechSupportPanel_ButtonBarSeperator, "TechSupportPanel_ButtonBarSeperator");
      this.TechSupportPanel_ButtonBarSeperator.Name = "TechSupportPanel_ButtonBarSeperator";
      this.TechSupportPanel_ButtonBarSeperator.TabStop = false;
      this.TechSupportPanel_GridView.AllowUserToAddRows = false;
      this.TechSupportPanel_GridView.AllowUserToDeleteRows = false;
      this.TechSupportPanel_GridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.TechSupportPanel_GridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
      this.TechSupportPanel_GridView.BackgroundColor = Color.WhiteSmoke;
      this.TechSupportPanel_GridView.BorderStyle = BorderStyle.None;
      this.TechSupportPanel_GridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle1.BackColor = Color.FromArgb(37, 101, 166);
      gridViewCellStyle1.Font = new Font("Tahoma", 9f);
      gridViewCellStyle1.ForeColor = Color.White;
      gridViewCellStyle1.SelectionBackColor = Color.FromArgb(37, 101, 166);
      gridViewCellStyle1.SelectionForeColor = Color.White;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.TechSupportPanel_GridView.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.TechSupportPanel_GridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.TechSupportPanel_GridView.Columns.AddRange((DataGridViewColumn) this.CompanyColumn, (DataGridViewColumn) this.SupportWebsiteColumn);
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = Color.WhiteSmoke;
      gridViewCellStyle2.Font = new Font("Tahoma", 9f);
      gridViewCellStyle2.ForeColor = Color.Black;
      gridViewCellStyle2.SelectionBackColor = Color.FromArgb(81, 149, 217);
      gridViewCellStyle2.SelectionForeColor = Color.Black;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.TechSupportPanel_GridView.DefaultCellStyle = gridViewCellStyle2;
      this.TechSupportPanel_GridView.GridColor = Color.FromArgb(204, 204, 204);
      componentResourceManager.ApplyResources((object) this.TechSupportPanel_GridView, "TechSupportPanel_GridView");
      this.TechSupportPanel_GridView.MultiSelect = false;
      this.TechSupportPanel_GridView.Name = "TechSupportPanel_GridView";
      this.TechSupportPanel_GridView.ReadOnly = true;
      this.TechSupportPanel_GridView.RowHeadersVisible = false;
      this.TechSupportPanel_GridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      this.TechSupportPanel_GridView.RowTemplate.Height = 24;
      this.TechSupportPanel_GridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.TechSupportPanel_GridView.ShowEditingIcon = false;
      this.TechSupportPanel_GridView.CellContentClick += new DataGridViewCellEventHandler(this.OnCellContentClick);
      this.CompanyColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.CompanyColumn.DataPropertyName = "CompanyName";
      componentResourceManager.ApplyResources((object) this.CompanyColumn, "CompanyColumn");
      this.CompanyColumn.Name = "CompanyColumn";
      this.CompanyColumn.ReadOnly = true;
      this.CompanyColumn.Resizable = DataGridViewTriState.True;
      this.SupportWebsiteColumn.DataPropertyName = "SupportURL";
      componentResourceManager.ApplyResources((object) this.SupportWebsiteColumn, "SupportWebsiteColumn");
      this.SupportWebsiteColumn.Name = "SupportWebsiteColumn";
      this.SupportWebsiteColumn.ReadOnly = true;
      this.TechSupportPanel_ShowOtherOperatorsBtn.BackColor = Color.White;
      this.TechSupportPanel_ShowOtherOperatorsBtn.BtnColor = PushButtonColorEnum.BlueGrey;
      this.TechSupportPanel_ShowOtherOperatorsBtn.BtnDoubleEndCaps = false;
      this.TechSupportPanel_ShowOtherOperatorsBtn.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.TechSupportPanel_ShowOtherOperatorsBtn, "TechSupportPanel_ShowOtherOperatorsBtn");
      this.TechSupportPanel_ShowOtherOperatorsBtn.Name = "TechSupportPanel_ShowOtherOperatorsBtn";
      this.TechSupportPanel_HelpButtonLabelPair.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.TechSupportPanel_HelpButtonLabelPair, "TechSupportPanel_HelpButtonLabelPair");
      this.TechSupportPanel_HelpButtonLabelPair.Name = "TechSupportPanel_HelpButtonLabelPair";
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.TechSupportPanel_HelpButtonLabelPair);
      this.Controls.Add((Control) this.TechSupportPanel_ShowOtherOperatorsBtn);
      this.Controls.Add((Control) this.TechSupportPanel_GridView);
      this.Controls.Add((Control) this.TechSupportPanel_CloseBtnBox);
      this.Controls.Add((Control) this.TechSupportPanel_ButtonBarSeperator);
      this.Controls.Add((Control) this.TechSupportPanel_HeaderLbl);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "TechSupportPanel";
      this.TechSupportPanel_CloseBtnBox.ResumeLayout(false);
      this.TechSupportPanel_GridView.EndInit();
      this.ResumeLayout(false);
    }
  }
}
