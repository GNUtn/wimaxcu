// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.ProfileListBox
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class ProfileListBox : UserControl
  {
    private CustomListBoxHeader _listBoxHeader = new CustomListBoxHeader();
    private IContainer components;
    private CustomProfileListBox _customListBox;
    private ListBoxHeaderData _currSortColumnData;

    public ProfileDisplayItem SelectedPDI
    {
      get
      {
        return this._customListBox.SelectedItem as ProfileDisplayItem;
      }
    }

    public ProperitesDelegate ProperitesCallback
    {
      get
      {
        return this._customListBox.ProperitesCallback;
      }
      set
      {
        this._customListBox.ProperitesCallback = value;
      }
    }

    public ProfileSelectedDelegate ProfileSelectedCallback
    {
      get
      {
        return this._customListBox.ProfileSelectedCallback;
      }
      set
      {
        this._customListBox.ProfileSelectedCallback = value;
      }
    }

    public SetAsDefaultDelegate SetAsDefaultCallback
    {
      get
      {
        return this._customListBox.SetAsDefaultCallback;
      }
      set
      {
        this._customListBox.SetAsDefaultCallback = value;
      }
    }

    public EnableProperitesDelegate EnableProperitesCallback
    {
      get
      {
        return this._customListBox.EnableProperitesCallback;
      }
      set
      {
        this._customListBox.EnableProperitesCallback = value;
      }
    }

    public EnableSetAsDefaultDelegate EnableSetAsDefaultCallback
    {
      get
      {
        return this._customListBox.EnableSetAsDefaultCallback;
      }
      set
      {
        this._customListBox.EnableSetAsDefaultCallback = value;
      }
    }

    public ProfileListBox()
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ProfileListBox));
      this.SuspendLayout();
      this.BackColor = Color.White;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "ProfileListBox";
      this.ResumeLayout(false);
    }

    public void UpdateUI(List<ProfileDisplayItem> profileList)
    {
      this.DoSort(ref profileList);
      if (this._customListBox == null)
        return;
      this._customListBox.SetDataSource(profileList);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      using (Graphics graphics = this.CreateGraphics())
        ControlPaint.DrawBorder(graphics, new Rectangle(0, this._listBoxHeader.Height, this.Width, this.Height - this._listBoxHeader.Height), Color.FromArgb(204, 204, 204), ButtonBorderStyle.Solid);
      base.OnPaint(e);
    }

    private void CustomInitializeComponents()
    {
      this.AccessibleName = "ProfileListBox";
      this._listBoxHeader.AccessibleName = "ProfileListBox_ListBoxHeader";
      this._listBoxHeader.TabStop = false;
      this._listBoxHeader.Columns = ProfileListBox.GetListboxHeaderData();
      this._currSortColumnData = this._listBoxHeader.Columns[0];
      this._listBoxHeader.SortOrderChangedEvent += new CustomListBoxHeader.SortOrderChangedDelegate(this.ApplyNewSortOrder);
      this._listBoxHeader.Size = new Size(this.Width - 2, this._listBoxHeader.Height);
      this._listBoxHeader.Location = new Point(1, 0);
      this.Controls.Add((Control) this._listBoxHeader);
      this.AddCustomListBox();
    }

    public static List<ListBoxHeaderData> GetListboxHeaderData()
    {
      return new List<ListBoxHeaderData>()
      {
        new ListBoxHeaderData()
        {
          Text = ManageNetworksDlgStringHelper.GetString("ManageNetworksPanel_Col1Header"),
          Width = DPIUtils.ScaleX(75),
          Selected = true,
          SortAscending = true,
          AscendingSortComparer = (object) new SortByPreferredProfileAscendingComparer(),
          DescendingSortComparer = (object) new SortByPreferredProfileDescendingComparer()
        },
        new ListBoxHeaderData()
        {
          Text = ManageNetworksDlgStringHelper.GetString("ManageNetworksPanel_Col2Header"),
          Width = DPIUtils.ScaleX(275),
          Selected = false,
          SortAscending = true,
          AscendingSortComparer = (object) new SortByProfileNameAscendingComparer(),
          DescendingSortComparer = (object) new SortByProfileNameDescendingComparer()
        }
      };
    }

    private void DoSort(ref List<ProfileDisplayItem> profileList)
    {
      if (this._currSortColumnData.SortAscending)
        profileList.Sort((IComparer<ProfileDisplayItem>) this._currSortColumnData.AscendingSortComparer);
      else
        profileList.Sort((IComparer<ProfileDisplayItem>) this._currSortColumnData.DescendingSortComparer);
    }

    private void ApplyNewSortOrder(ListBoxHeaderData sortColumnData)
    {
      this._currSortColumnData = sortColumnData;
      if (this._customListBox == null)
        return;
      List<ProfileDisplayItem> profileList = new List<ProfileDisplayItem>();
      for (int index = 0; index < this._customListBox.Items.Count; ++index)
        profileList.Add((ProfileDisplayItem) this._customListBox.Items[index]);
      this.DoSort(ref profileList);
      this._customListBox.SetDataSource(profileList);
    }

    public void AdjustCustomListBoxSize(CustomProfileListBox newCustomListBox)
    {
      if (this._customListBox == null)
        return;
      this._customListBox.Size = new Size(this.Width - 2, this.Height - (this._listBoxHeader.Location.Y + this._listBoxHeader.Height) - 2);
    }

    private void AddCustomListBox()
    {
      this.SuspendLayout();
      CustomProfileListBox customProfileListBox = new CustomProfileListBox();
      customProfileListBox.AccessibleName = "NetworkListPanel_ProfileListBox_CustomListBox";
      customProfileListBox.Size = new Size(this.Width - 2, this.Height - (this._listBoxHeader.Location.Y + this._listBoxHeader.Height) - 2);
      customProfileListBox.Location = new Point(1, this._listBoxHeader.Location.Y + this._listBoxHeader.Height + 1);
      customProfileListBox.BackColor = Color.WhiteSmoke;
      customProfileListBox.Visible = false;
      this.Controls.Add((Control) customProfileListBox);
      customProfileListBox.SendToBack();
      customProfileListBox.Visible = true;
      this._customListBox = customProfileListBox;
      this.ResumeLayout(false);
    }
  }
}
