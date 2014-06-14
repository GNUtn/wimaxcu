// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.AboutPanel
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class AboutPanel : UserControl
  {
    private Container components;
    private Label AboutPanel_IntelCopyrightLbl;
    private Label AboutPanel_HeaderLbl;
    private CustomLabelSeparator AboutPanel_ButtonBarSeperator;
    private CustomButtonPushHorizBox AboutPanel_CloseBtnBox;
    private CustomButtonPush AboutPanel_CloseBtn;
    private Panel AboutPanel_CopyrightPanel;
    private Panel AboutPanel_SeparatorAndButtonPanel;
    private DataGridView AboutPanel_ComponentVersionGridView;
    private PictureBox AboutPanel_AppLogo;
    private Label AboutPanel_DevicescapeCopyrightLbl;
    private string _swPackageVersion;
    private LinkLabel AboutPanel_CheckForUpgradeLinkLabel;
    private string _wmfComplianceVersion;

    public AboutPanel()
    {
      this.InitializeComponent();
      this.CustomInitializeComponents();
      this.AboutPanel_AppLogo.Image = (Image) ScalingUtils.ScaleBitmap(this.AboutPanel_AppLogo.Image);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AboutPanel));
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      this.AboutPanel_IntelCopyrightLbl = new Label();
      this.AboutPanel_HeaderLbl = new Label();
      this.AboutPanel_CopyrightPanel = new Panel();
      this.AboutPanel_DevicescapeCopyrightLbl = new Label();
      this.AboutPanel_ButtonBarSeperator = new CustomLabelSeparator();
      this.AboutPanel_CloseBtnBox = new CustomButtonPushHorizBox();
      this.AboutPanel_CloseBtn = new CustomButtonPush();
      this.AboutPanel_SeparatorAndButtonPanel = new Panel();
      this.AboutPanel_ComponentVersionGridView = new DataGridView();
      this.AboutPanel_AppLogo = new PictureBox();
      this.AboutPanel_CheckForUpgradeLinkLabel = new LinkLabel();
      this.AboutPanel_CopyrightPanel.SuspendLayout();
      this.AboutPanel_CloseBtnBox.SuspendLayout();
      this.AboutPanel_SeparatorAndButtonPanel.SuspendLayout();
      this.AboutPanel_ComponentVersionGridView.BeginInit();
      this.AboutPanel_AppLogo.BeginInit();
      this.SuspendLayout();
      this.AboutPanel_IntelCopyrightLbl.BackColor = Color.White;
      componentResourceManager.ApplyResources((object) this.AboutPanel_IntelCopyrightLbl, "AboutPanel_IntelCopyrightLbl");
      this.AboutPanel_IntelCopyrightLbl.Name = "AboutPanel_IntelCopyrightLbl";
      this.AboutPanel_HeaderLbl.BackColor = Color.White;
      componentResourceManager.ApplyResources((object) this.AboutPanel_HeaderLbl, "AboutPanel_HeaderLbl");
      this.AboutPanel_HeaderLbl.Name = "AboutPanel_HeaderLbl";
      this.AboutPanel_CopyrightPanel.Controls.Add((Control) this.AboutPanel_DevicescapeCopyrightLbl);
      this.AboutPanel_CopyrightPanel.Controls.Add((Control) this.AboutPanel_IntelCopyrightLbl);
      componentResourceManager.ApplyResources((object) this.AboutPanel_CopyrightPanel, "AboutPanel_CopyrightPanel");
      this.AboutPanel_CopyrightPanel.Name = "AboutPanel_CopyrightPanel";
      this.AboutPanel_DevicescapeCopyrightLbl.BackColor = Color.White;
      componentResourceManager.ApplyResources((object) this.AboutPanel_DevicescapeCopyrightLbl, "AboutPanel_DevicescapeCopyrightLbl");
      this.AboutPanel_DevicescapeCopyrightLbl.Name = "AboutPanel_DevicescapeCopyrightLbl";
      this.AboutPanel_ButtonBarSeperator.BackColor = Color.White;
      componentResourceManager.ApplyResources((object) this.AboutPanel_ButtonBarSeperator, "AboutPanel_ButtonBarSeperator");
      this.AboutPanel_ButtonBarSeperator.Name = "AboutPanel_ButtonBarSeperator";
      this.AboutPanel_ButtonBarSeperator.TabStop = false;
      this.AboutPanel_CloseBtnBox.Controls.Add((Control) this.AboutPanel_CloseBtn);
      componentResourceManager.ApplyResources((object) this.AboutPanel_CloseBtnBox, "AboutPanel_CloseBtnBox");
      this.AboutPanel_CloseBtnBox.HorizontalJustification = HorizontalJustificationEnum.Right;
      this.AboutPanel_CloseBtnBox.Name = "AboutPanel_CloseBtnBox";
      this.AboutPanel_CloseBtn.BackColor = Color.White;
      this.AboutPanel_CloseBtn.BtnColor = PushButtonColorEnum.BlueGrey;
      this.AboutPanel_CloseBtn.BtnDoubleEndCaps = false;
      this.AboutPanel_CloseBtn.BtnEnabled = true;
      componentResourceManager.ApplyResources((object) this.AboutPanel_CloseBtn, "AboutPanel_CloseBtn");
      this.AboutPanel_CloseBtn.Name = "AboutPanel_CloseBtn";
      this.AboutPanel_SeparatorAndButtonPanel.Controls.Add((Control) this.AboutPanel_CloseBtnBox);
      this.AboutPanel_SeparatorAndButtonPanel.Controls.Add((Control) this.AboutPanel_ButtonBarSeperator);
      componentResourceManager.ApplyResources((object) this.AboutPanel_SeparatorAndButtonPanel, "AboutPanel_SeparatorAndButtonPanel");
      this.AboutPanel_SeparatorAndButtonPanel.Name = "AboutPanel_SeparatorAndButtonPanel";
      this.AboutPanel_ComponentVersionGridView.AllowUserToAddRows = false;
      this.AboutPanel_ComponentVersionGridView.AllowUserToDeleteRows = false;
      this.AboutPanel_ComponentVersionGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.AboutPanel_ComponentVersionGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
      this.AboutPanel_ComponentVersionGridView.BackgroundColor = Color.WhiteSmoke;
      this.AboutPanel_ComponentVersionGridView.BorderStyle = BorderStyle.None;
      this.AboutPanel_ComponentVersionGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle1.BackColor = Color.FromArgb(37, 101, 166);
      gridViewCellStyle1.Font = new Font("Tahoma", 9f);
      gridViewCellStyle1.ForeColor = Color.White;
      gridViewCellStyle1.SelectionBackColor = Color.FromArgb(37, 101, 166);
      gridViewCellStyle1.SelectionForeColor = Color.White;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.AboutPanel_ComponentVersionGridView.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.AboutPanel_ComponentVersionGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = Color.WhiteSmoke;
      gridViewCellStyle2.Font = new Font("Tahoma", 9f);
      gridViewCellStyle2.ForeColor = Color.Black;
      gridViewCellStyle2.SelectionBackColor = Color.FromArgb(81, 149, 217);
      gridViewCellStyle2.SelectionForeColor = Color.Black;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.AboutPanel_ComponentVersionGridView.DefaultCellStyle = gridViewCellStyle2;
      this.AboutPanel_ComponentVersionGridView.GridColor = Color.FromArgb(204, 204, 204);
      componentResourceManager.ApplyResources((object) this.AboutPanel_ComponentVersionGridView, "AboutPanel_ComponentVersionGridView");
      this.AboutPanel_ComponentVersionGridView.MultiSelect = false;
      this.AboutPanel_ComponentVersionGridView.Name = "AboutPanel_ComponentVersionGridView";
      this.AboutPanel_ComponentVersionGridView.ReadOnly = true;
      this.AboutPanel_ComponentVersionGridView.RowHeadersVisible = false;
      this.AboutPanel_ComponentVersionGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      this.AboutPanel_ComponentVersionGridView.RowTemplate.Height = 24;
      this.AboutPanel_ComponentVersionGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.AboutPanel_ComponentVersionGridView.ShowEditingIcon = false;
      this.AboutPanel_ComponentVersionGridView.TabStop = false;
      this.AboutPanel_AppLogo.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.AboutPanel_AppLogo, "AboutPanel_AppLogo");
      this.AboutPanel_AppLogo.Name = "AboutPanel_AppLogo";
      this.AboutPanel_AppLogo.TabStop = false;
      componentResourceManager.ApplyResources((object) this.AboutPanel_CheckForUpgradeLinkLabel, "AboutPanel_CheckForUpgradeLinkLabel");
      this.AboutPanel_CheckForUpgradeLinkLabel.Name = "AboutPanel_CheckForUpgradeLinkLabel";
      this.AboutPanel_CheckForUpgradeLinkLabel.TabStop = true;
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.AboutPanel_CheckForUpgradeLinkLabel);
      this.Controls.Add((Control) this.AboutPanel_AppLogo);
      this.Controls.Add((Control) this.AboutPanel_ComponentVersionGridView);
      this.Controls.Add((Control) this.AboutPanel_SeparatorAndButtonPanel);
      this.Controls.Add((Control) this.AboutPanel_CopyrightPanel);
      this.Controls.Add((Control) this.AboutPanel_HeaderLbl);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "AboutPanel";
      this.AboutPanel_CopyrightPanel.ResumeLayout(false);
      this.AboutPanel_CloseBtnBox.ResumeLayout(false);
      this.AboutPanel_SeparatorAndButtonPanel.ResumeLayout(false);
      this.AboutPanel_ComponentVersionGridView.EndInit();
      this.AboutPanel_AppLogo.EndInit();
      this.ResumeLayout(false);
    }

    public void InitPanel()
    {
      string maxProductVersion = this.GetWiMAXProductVersion();
      this.AboutPanel_HeaderLbl.Text = string.Format(AboutDlgStringHelper.GetString("AboutPanel_HeaderLbl"), (object) maxProductVersion);
      this.SetIntelCopyrightLabel();
      this.FillComponentAndVersionDataGrid(maxProductVersion);
      this.ActiveControl = (Control) this.AboutPanel_CloseBtn;
      this.AboutPanel_CloseBtn.Focus();
    }

    public void CleanUp()
    {
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      ControlPaint.DrawBorder(e.Graphics, new Rectangle(this.AboutPanel_ComponentVersionGridView.Location.X - 1, this.AboutPanel_ComponentVersionGridView.Location.Y - 1, this.AboutPanel_ComponentVersionGridView.Width + 2, this.AboutPanel_ComponentVersionGridView.Height + 2), Color.FromArgb(204, 204, 204), ButtonBorderStyle.Solid);
      base.OnPaint(e);
    }

    protected override void OnVisibleChanged(EventArgs e)
    {
      this.SetupColumns();
    }

    private void OnCloseBtnPressed(object sender, EventArgs e)
    {
      ((Form) this.Parent).Close();
    }

    private void OnComponentVersionGridViewSelectionChanged(object sender, EventArgs e)
    {
      this.AboutPanel_ComponentVersionGridView.ClearSelection();
    }

    private void OnCheckForUpgradeLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      OnlineHelp.LaunchHelp("/about.htm#check_upgrade");
    }

    private void CustomInitializeComponents()
    {
      this.AccessibleName = "AboutPanel";
      this.AboutPanel_AppLogo.AccessibleName = "AboutPanel_AppLogo";
      this.AboutPanel_ButtonBarSeperator.AccessibleName = "AboutPanel_ButtonBarSeperator";
      this.AboutPanel_CloseBtn.AccessibleName = "AboutPanel_CloseBtn";
      this.AboutPanel_CloseBtnBox.AccessibleName = "AboutPanel_CloseBtnBox";
      this.AboutPanel_ComponentVersionGridView.AccessibleName = "AboutPanel_ComponentVersionGridView";
      this.AboutPanel_CopyrightPanel.AccessibleName = "AboutPanel_CopyrightPanel";
      this.AboutPanel_DevicescapeCopyrightLbl.AccessibleName = "AboutPanel_DevicescapeCopyrightLbl";
      this.AboutPanel_HeaderLbl.AccessibleName = "AboutPanel_HeaderLbl";
      this.AboutPanel_IntelCopyrightLbl.AccessibleName = "AboutPanel_IntelCopyrightLbl";
      this.AboutPanel_SeparatorAndButtonPanel.AccessibleName = "AboutPanel_SeparatorAndButtonPanel";
      this.AboutPanel_CheckForUpgradeLinkLabel.AccessibleName = "AboutPanel_CheckForUpgradeLinkLabel";
      this.AboutPanel_CloseBtn.BtnText = AboutDlgStringHelper.GetString("AboutPanel_CloseBtn");
      this.AboutPanel_DevicescapeCopyrightLbl.Text = AboutDlgStringHelper.GetString("AboutPanel_DevicescapeCopyrightLbl");
      this.AboutPanel_ButtonBarSeperator.Text = DashboardStringHelper.GetString("Empty");
      this.AboutPanel_CheckForUpgradeLinkLabel.Text = AboutDlgStringHelper.GetString("AboutPanel_CheckForUpgradeLinkLabel");
      this.AboutPanel_ComponentVersionGridView.ClearSelection();
      this.AboutPanel_CloseBtn.Pressed += new CustomButtonPush.PressedDelegate(this.OnCloseBtnPressed);
      this.AboutPanel_ComponentVersionGridView.SelectionChanged += new EventHandler(this.OnComponentVersionGridViewSelectionChanged);
      this.AboutPanel_CheckForUpgradeLinkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(this.OnCheckForUpgradeLinkLabelClicked);
      SizeHelper.ResizeCustomControls(this.Controls);
    }

    public void SquirrelInfo()
    {
      this.SquirrelSWPackageVersion();
      this.SquirrelWMFComplianceVersion();
      this.SquirrelWmxApiExVersion();
    }

    private string GetWiMAXProductVersion()
    {
      string altProductVersion = LocalMachineSettings.GetAltProductVersion();
      if (!string.IsNullOrEmpty(altProductVersion))
        return altProductVersion;
      StringBuilder stringBuilder = new StringBuilder();
      string productVersion = LocalMachineSettings.GetProductVersion();
      if (!string.IsNullOrEmpty(productVersion))
      {
        foreach (string str in Regex.Split(Regex.Replace(productVersion, "\\d\\d\\d$", ""), "\\."))
        {
          if (stringBuilder.Length > 0)
            stringBuilder.Append(".");
          stringBuilder.Append(Convert.ToInt32(str).ToString());
        }
      }
      return ((object) stringBuilder).ToString();
    }

    private void SetIntelCopyrightLabel()
    {
      this.AboutPanel_IntelCopyrightLbl.Text = string.Format(AboutDlgStringHelper.GetString("AboutPanel_IntelCopyrightLbl"), (object) DateTime.Now.Year.ToString());
    }

    private void FillComponentAndVersionDataGrid(string wimaxProductVersion)
    {
      List<AboutPanel.ComponentVersion> list = new List<AboutPanel.ComponentVersion>();
      this.SquirrelInfo();
      string version1 = this._wmfComplianceVersion;
      if (string.IsNullOrEmpty(version1))
        version1 = AboutDlgStringHelper.GetString("AboutPanel_ComponentVersionGridView_Unknown");
      string version2 = this._swPackageVersion;
      if (string.IsNullOrEmpty(version2))
        version2 = AboutDlgStringHelper.GetString("AboutPanel_ComponentVersionGridView_Unknown");
      if (string.IsNullOrEmpty(wimaxProductVersion))
        wimaxProductVersion = AboutDlgStringHelper.GetString("AboutPanel_ComponentVersionGridView_Unknown");
      string version3 = LocalMachineSettings.GetProductVersion();
      if (string.IsNullOrEmpty(version3))
        version3 = AboutDlgStringHelper.GetString("AboutPanel_ComponentVersionGridView_Unknown");
      Assembly executingAssembly = Assembly.GetExecutingAssembly();
      AboutPanel.ComponentVersion componentVersion1 = this.GetComponentVersion(AboutDlgStringHelper.GetString("AboutPanel_ComponentVersionGridView_ProductGrouping"), (string) null, (string) null);
      list.Add(componentVersion1);
      AboutPanel.ComponentVersion componentVersion2 = this.GetComponentVersion((string) null, AboutDlgStringHelper.GetString("AboutPanel_ComponentVersionGridView_WiMAXProductVersion"), wimaxProductVersion);
      list.Add(componentVersion2);
      AboutPanel.ComponentVersion componentVersion3 = this.GetComponentVersion(AboutDlgStringHelper.GetString("AboutPanel_ComponentVersionGridView_ComponentsGrouping"), (string) null, (string) null);
      list.Add(componentVersion3);
      AboutPanel.ComponentVersion componentVersion4 = this.GetComponentVersion((string) null, AboutDlgStringHelper.GetString("AboutPanel_ComponentVersionGridView_SoftwarePackage"), version2);
      list.Add(componentVersion4);
      AboutPanel.ComponentVersion componentVersion5 = this.GetComponentVersion((string) null, AboutDlgStringHelper.GetString("AboutPanel_ComponentVersionGridView_Install"), version3);
      list.Add(componentVersion5);
      AboutPanel.ComponentVersion componentVersion6 = this.GetComponentVersion((string) null, AboutDlgStringHelper.GetString("AboutPanel_ComponentVersionGridView_ConnectionUtility"), ((object) executingAssembly.GetName().Version).ToString());
      list.Add(componentVersion6);
      AboutPanel.ComponentVersion componentVersion7 = this.GetComponentVersion((string) null, AboutDlgStringHelper.GetString("AboutPanel_ComponentVersionGridView_WMFCompliance"), version1);
      list.Add(componentVersion7);
      this.AboutPanel_ComponentVersionGridView.DataSource = (object) list;
      this.SetupColumns();
    }

    private void SetupColumns()
    {
      if (this.AboutPanel_ComponentVersionGridView.Columns.Count != 3)
        return;
      this.AboutPanel_ComponentVersionGridView.Columns["Grouping"].HeaderText = "";
      this.AboutPanel_ComponentVersionGridView.Columns["Name"].HeaderText = AboutDlgStringHelper.GetString("AboutPanel_ComponentVersionGridView_NameColumnHeader");
      this.AboutPanel_ComponentVersionGridView.Columns["Version"].HeaderText = AboutDlgStringHelper.GetString("AboutPanel_ComponentVersionGridView_VersionColumnHeader");
      this.AboutPanel_ComponentVersionGridView.Columns["Grouping"].DisplayIndex = 0;
      this.AboutPanel_ComponentVersionGridView.Columns["Name"].DisplayIndex = 1;
      this.AboutPanel_ComponentVersionGridView.Columns["Version"].DisplayIndex = 2;
    }

    private void SquirrelSWPackageVersion()
    {
      if (!string.IsNullOrEmpty(this._swPackageVersion))
        return;
      this._swPackageVersion = AdapterHandler.TheAdapter.SWVersion;
    }

    private void SquirrelWMFComplianceVersion()
    {
      if (!string.IsNullOrEmpty(this._wmfComplianceVersion))
        return;
      MiscHandler.Singleton.GetWMFComplianceVersion(ref this._wmfComplianceVersion);
    }

    private void SquirrelWmxApiExVersion()
    {
      uint version = 0U;
      MiscHandler.Singleton.GetWmxApiExVersion(ref version);
    }

    private AboutPanel.ComponentVersion GetComponentVersion(string grouping, string name, string version)
    {
      return new AboutPanel.ComponentVersion()
      {
        Grouping = grouping,
        Name = name,
        Version = version
      };
    }

    internal class ComponentVersion
    {
      private string _grouping;
      private string _name;
      private string _version;

      public string Grouping
      {
        get
        {
          return this._grouping;
        }
        set
        {
          this._grouping = value;
        }
      }

      public string Name
      {
        get
        {
          return this._name;
        }
        set
        {
          this._name = value;
        }
      }

      public string Version
      {
        get
        {
          return this._version;
        }
        set
        {
          this._version = value;
        }
      }
    }
  }
}
