// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.ConnectionSubDetails
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class ConnectionSubDetails : UserControl
  {
    private Container components;
    private static NetworkDisplayItem _currentlyDisplayedNDI;

    public ConnectionSubDetails()
    {
      this.InitializeComponent();
      this.CustomInitializeComponents();
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ConnectionSubDetails));
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "ConnectionSubDetails";
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
      NetworkDisplayItem networkDisplayItem = (NetworkDisplayItem) null;
      if (NetworkHandler.ConnectedNetworks.Count > 0)
        networkDisplayItem = NetworkHandler.ConnectedNetworks[0];
      if (ConnectionSubDetails._currentlyDisplayedNDI != null && networkDisplayItem != null && (NetworkHandler.IsSameNetwork(networkDisplayItem, ConnectionSubDetails._currentlyDisplayedNDI) && networkDisplayItem.SubDetails.Count == this.Controls.Count))
      {
        for (int index = 0; index < networkDisplayItem.SubDetails.Count; ++index)
        {
          NDISubDetail ndiSubDetail = networkDisplayItem.SubDetails[index];
          ConnectionSubDetailItem connectionSubDetailItem = (ConnectionSubDetailItem) this.Controls[index];
          bool flag = false;
          if (connectionSubDetailItem.HeadingText != ndiSubDetail.HeadingText || connectionSubDetailItem.HeadingForeColor != ndiSubDetail.HeadingForeColor)
          {
            connectionSubDetailItem.HeadingText = ndiSubDetail.HeadingText;
            connectionSubDetailItem.HeadingForeColor = ndiSubDetail.HeadingForeColor;
            flag = true;
          }
          if (!ImageHelper.ImagesAreSame((Image) connectionSubDetailItem.BodyIconLine1, (Image) ndiSubDetail.BodyIconLine1) || !ImageHelper.ImagesAreSame((Image) connectionSubDetailItem.BodyIconLine2, (Image) ndiSubDetail.BodyIconLine2) || (connectionSubDetailItem.BodyIconLine1Tooltip != ndiSubDetail.BodyIconLine1Tooltip || connectionSubDetailItem.BodyIconLine2Tooltip != ndiSubDetail.BodyIconLine2Tooltip))
          {
            connectionSubDetailItem.BodyIconLine1 = ndiSubDetail.BodyIconLine1;
            connectionSubDetailItem.BodyIconLine2 = ndiSubDetail.BodyIconLine2;
            connectionSubDetailItem.BodyIconLine1Tooltip = ndiSubDetail.BodyIconLine1Tooltip;
            connectionSubDetailItem.BodyIconLine2Tooltip = ndiSubDetail.BodyIconLine2Tooltip;
            flag = true;
          }
          if (connectionSubDetailItem.BodyTextLine1 != ndiSubDetail.BodyTextLine1 || connectionSubDetailItem.BodyTextLine2 != ndiSubDetail.BodyTextLine2 || (connectionSubDetailItem.BodyLine1ForeColor != ndiSubDetail.BodyLine1ForeColor || connectionSubDetailItem.BodyLine2ForeColor != ndiSubDetail.BodyLine2ForeColor))
          {
            connectionSubDetailItem.BodyTextLine1 = ndiSubDetail.BodyTextLine1;
            connectionSubDetailItem.BodyTextLine2 = ndiSubDetail.BodyTextLine2;
            connectionSubDetailItem.BodyLine1ForeColor = ndiSubDetail.BodyLine1ForeColor;
            connectionSubDetailItem.BodyLine2ForeColor = ndiSubDetail.BodyLine2ForeColor;
            flag = true;
          }
          if (flag)
            this.Controls[index].Invalidate();
        }
      }
      else
      {
        if (networkDisplayItem == null)
          return;
        this.AddDynamicControls(networkDisplayItem);
        ConnectionSubDetails._currentlyDisplayedNDI = networkDisplayItem;
      }
    }

    private void CustomInitializeComponents()
    {
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.BackColor = Color.Transparent;
    }

    private void AddDynamicControls(NetworkDisplayItem connectedNDI)
    {
      int x = 14;
      int num1 = 0;
      int num2 = 2;
      this.Controls.Clear();
      for (int index = 0; index < connectedNDI.SubDetails.Count; ++index)
      {
        NDISubDetail ndiSubDetail = connectedNDI.SubDetails[index];
        ConnectionSubDetailItem connectionSubDetailItem = new ConnectionSubDetailItem(ndiSubDetail.HeadingText, ndiSubDetail.HeadingForeColor, ndiSubDetail.BodyTextLine1, ndiSubDetail.BodyLine1ForeColor, ndiSubDetail.BodyIconLine1, ndiSubDetail.BodyIconLine1Tooltip, ndiSubDetail.BodyTextLine2, ndiSubDetail.BodyLine2ForeColor, ndiSubDetail.BodyIconLine2, ndiSubDetail.BodyIconLine2Tooltip);
        connectionSubDetailItem.Location = new Point(x, 0);
        connectionSubDetailItem.Name = "ConnectionSubDetailItem" + index.ToString();
        connectionSubDetailItem.AccessibleName = "ConnectionPanel_ConnectionSubDetails_ConnectionSubDetailItem" + index.ToString();
        connectionSubDetailItem.TabStop = false;
        connectionSubDetailItem.ResizeMe();
        this.Controls.Add((Control) connectionSubDetailItem);
        x += connectionSubDetailItem.Width + num2;
        num1 += connectionSubDetailItem.Width + num2;
      }
      this.Width = num1 - num2;
      this.Invalidate();
    }
  }
}
