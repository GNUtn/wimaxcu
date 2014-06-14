// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.NetworkListBox
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using Intel.Mobile.WiMAXCU.UI.DisplayWiMAX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class NetworkListBox : UserControl
  {
    private CustomListBoxHeader _listBoxHeader = new CustomListBoxHeader();
    private IContainer components;
    private CustomNetworkListBox _customListBox;
    private ListBoxHeaderData _currSortColumnData;

    public NetworkListBox()
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (NetworkListBox));
      this.SuspendLayout();
      this.BackColor = Color.White;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "NetworkListBox";
      this.ResumeLayout(false);
    }

    public void UpdateUI(List<NetworkDisplayItem> ndiList, bool recreateNetworksListbox)
    {
      if (!Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForConnect && !Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForDisconnect)
      {
        this.AddCustomListBox(recreateNetworksListbox);
        this.DoSort(ref ndiList);
        if (this._customListBox != null)
          this._customListBox.SetDataSource(ndiList);
      }
      this.Enabled = Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.ShouldControlBeEnabled(DashboardControlEnum.NetworkListPanel_NetworkListBox);
      this._listBoxHeader.Enabled = this.Enabled;
    }

    public int GetItemCount()
    {
      if (this._customListBox != null)
        return this._customListBox.Items.Count;
      else
        return 0;
    }

    public NetworkDisplayItem GetSelectedNDI()
    {
      if (this._customListBox != null && this._customListBox.Items.Count > 0 && this._customListBox.SelectedItem != null)
        return (NetworkDisplayItem) this._customListBox.SelectedItem;
      else
        return (NetworkDisplayItem) null;
    }

    public Size GetListBoxSize()
    {
      return this.Size;
    }

    public Point GetListBoxLocation()
    {
      return this.Location;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      using (Graphics graphics = this.CreateGraphics())
        ControlPaint.DrawBorder(graphics, new Rectangle(0, this._listBoxHeader.Height, this.Width, this.Height - this._listBoxHeader.Height), Color.FromArgb(204, 204, 204), ButtonBorderStyle.Solid);
      base.OnPaint(e);
    }

    protected override void OnSizeChanged(EventArgs e)
    {
      if (this._customListBox != null && this._listBoxHeader != null)
        this._customListBox.Size = new Size(this.Width - 2, this.Height - (this._listBoxHeader.Location.Y + this._listBoxHeader.Height) - 2);
      base.OnSizeChanged(e);
    }

    private void CustomInitializeComponents()
    {
      this.AccessibleName = "NetworkListBox";
      this._listBoxHeader.AccessibleName = "NetworkListPanel_NetworkListBox_ListBoxHeader";
      this._listBoxHeader.TabStop = false;
      this._listBoxHeader.Columns = WiMAXDisplayService.Singleton.GetAvailableNetworksListboxHeaderData();
      this._currSortColumnData = this._listBoxHeader.Columns[0];
      this._listBoxHeader.SortOrderChangedEvent += new CustomListBoxHeader.SortOrderChangedDelegate(this.ApplyNewSortOrder);
      this._listBoxHeader.Size = new Size(this.Width - 2, this._listBoxHeader.Height);
      this._listBoxHeader.Location = new Point(1, 0);
      this.Controls.Add((Control) this._listBoxHeader);
      this.AddCustomListBox(false);
    }

    private void DoSort(ref List<NetworkDisplayItem> ndiList)
    {
      if (this._currSortColumnData.SortAscending)
        ndiList.Sort((IComparer<NetworkDisplayItem>) this._currSortColumnData.AscendingSortComparer);
      else
        ndiList.Sort((IComparer<NetworkDisplayItem>) this._currSortColumnData.DescendingSortComparer);
    }

    private void ApplyNewSortOrder(ListBoxHeaderData sortColumnData)
    {
      this._currSortColumnData = sortColumnData;
      List<NetworkDisplayItem> ndiList = new List<NetworkDisplayItem>();
      if (this._customListBox == null)
        return;
      for (int index = 0; index < this._customListBox.Items.Count; ++index)
        ndiList.Add((NetworkDisplayItem) this._customListBox.Items[index]);
      this.DoSort(ref ndiList);
      this._customListBox.SetDataSource(ndiList);
    }

    private void AddCustomListBox(bool recreateNetworksListbox)
    {
      if (this._customListBox != null && !recreateNetworksListbox)
        return;
      this.SuspendLayout();
      CustomNetworkListBox customNetworkListBox = new CustomNetworkListBox();
      customNetworkListBox.AccessibleName = "NetworkListPanel_NetworkListBox_CustomListBox";
      customNetworkListBox.Size = new Size(this.Width - 2, this.Height - (this._listBoxHeader.Location.Y + this._listBoxHeader.Height) - 2);
      customNetworkListBox.Location = new Point(1, this._listBoxHeader.Location.Y + this._listBoxHeader.Height + 1);
      customNetworkListBox.BackColor = Color.WhiteSmoke;
      customNetworkListBox.Visible = false;
      this.Controls.Add((Control) customNetworkListBox);
      customNetworkListBox.SendToBack();
      customNetworkListBox.Visible = true;
      if (this._customListBox != null)
      {
        customNetworkListBox.CopyPrivateFields(this._customListBox);
        this._customListBox.SendToBack();
        this.Controls.Remove((Control) this._customListBox);
      }
      this._customListBox = customNetworkListBox;
      this.ResumeLayout(false);
    }
  }
}
