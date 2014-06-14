// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.CustomNetworkListBox
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.SDKInterop;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class CustomNetworkListBox : ListBox
  {
    private ToolTip _tooltip = new ToolTip();
    private string _tooltip_NewText = string.Empty;
    private int _tooltip_DisplayedForIndex = -1;
    private const int STARTX = 0;
    private const int STARTY = 3;
    private const int SINGLE_LINE_HEIGHT = 36;
    private const int HEADER_HEIGHT = 24;
    private bool _hasFocus;
    private NetworkDisplayItem _currSelectedNDI;
    private NetworkDisplayItem _tooltip_NDI;
    private int _tooltip_yOffset;
    private bool _paintHeadersInListbox;
    private bool _currentlyConnected;

    public CustomNetworkListBox()
    {
      this.DrawMode = DrawMode.OwnerDrawVariable;
      this.BorderStyle = BorderStyle.None;
      this.MouseDown += new MouseEventHandler(this.OnMouseDown);
      this.DoubleClick += new EventHandler(this.OnItemDoubleClicked);
      this.MouseMove += new MouseEventHandler(this.OnMouseMove);
      this.Leave += new EventHandler(this.OnLostFocus);
      this.Enter += new EventHandler(this.OnGotFocus);
      this.SelectedIndexChanged += new EventHandler(this.OnSelectedIndexChanged);
      this.DrawItem += new DrawItemEventHandler(this.DrawItemHandler);
      this.MeasureItem += new MeasureItemEventHandler(this.MeasureItemHandler);
      this._tooltip.ShowAlways = true;
    }

    public void CopyPrivateFields(CustomNetworkListBox orig)
    {
      if (orig == null)
        return;
      this._currentlyConnected = orig._currentlyConnected;
      this._currSelectedNDI = orig._currSelectedNDI;
      this._hasFocus = orig._hasFocus;
      this._paintHeadersInListbox = orig._paintHeadersInListbox;
      this._tooltip = orig._tooltip;
      this._tooltip_DisplayedForIndex = orig._tooltip_DisplayedForIndex;
      this._tooltip_NDI = orig._tooltip_NDI;
      this._tooltip_NewText = orig._tooltip_NewText;
      this._tooltip_yOffset = orig._tooltip_yOffset;
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      if (this.IgnoreMouseEvent(e.X, e.Y))
        return;
      base.OnMouseDown(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      if (this.IgnoreMouseEvent(e.X, e.Y))
        return;
      base.OnMouseUp(e);
    }

    protected override void OnClick(EventArgs e)
    {
      Point point = this.PointToClient(Cursor.Position);
      if (this.IgnoreMouseEvent(point.X, point.Y))
        return;
      base.OnClick(e);
    }

    protected override void OnDoubleClick(EventArgs e)
    {
      Point point = this.PointToClient(Cursor.Position);
      if (this.IgnoreMouseEvent(point.X, point.Y))
        return;
      base.OnDoubleClick(e);
    }

    private void OnItemDoubleClicked(object sender, EventArgs e)
    {
      Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user double clicked on a network in the network list.");
      AppFramework.Dashboard.TheNetworkListPanel.ConnectSelectedNetwork();
    }

    private void ContextMenu_Connect_Click(object sender, EventArgs e)
    {
      Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user selected the 'Connect' context menu item in the network list.");
      AppFramework.Dashboard.TheNetworkListPanel.ConnectSelectedNetwork();
    }

    private void ContextMenu_ViewDetails_Click(object sender, EventArgs e)
    {
      Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user selected the 'View Details' context menu item in the network list.");
      AppFramework.Dashboard.TheNetworkListPanel.ViewDetailsForSelectedNetwork();
    }

    private void ContextMenu_EditProperties_Click(object sender, EventArgs e)
    {
      Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user selected the 'Edit Properites' context menu item in the network list.");
      AppFramework.Dashboard.TheNetworkListPanel.EditPropertiesForSelectedNetwork();
    }

    private void OnSelectedIndexChanged(object sender, EventArgs e)
    {
      this.HandleSelectedIndexChanged();
    }

    private void OnGotFocus(object sender, EventArgs e)
    {
      this._hasFocus = true;
      this.Invalidate();
    }

    private void OnLostFocus(object sender, EventArgs e)
    {
      this._hasFocus = false;
      this.Invalidate();
    }

    private void OnMouseDown(object sender, MouseEventArgs e)
    {
      if (this.Items.Count <= 0 || e.Button != MouseButtons.Right)
        return;
      int num1 = this.IndexFromPoint(e.X, e.Y);
      if (num1 == -1)
        return;
      int num2 = 0;
      for (int topIndex = this.TopIndex; topIndex < this.Items.Count; ++topIndex)
        num2 += base.GetItemHeight(topIndex);
      if (e.Y > num2)
        return;
      this.SelectedIndex = num1;
      this.ShowContextMenu(new Point(e.X, e.Y));
    }

    private void OnMouseMove(object sender, MouseEventArgs e)
    {
      this._tooltip_NewText = string.Empty;
      if (this.Items.Count <= 0)
        return;
      int index = this.IndexFromPoint(e.X, e.Y);
      if (index == -1)
        return;
      this._tooltip_yOffset = this.ItemViewportY(index);
      if (this._paintHeadersInListbox && (this.IsFirstConnectedNetwork(index) || this.IsFirstAvailableNetwork(index)))
        this._tooltip_yOffset += DPIUtils.ScaleY(24);
      this._tooltip_NDI = (NetworkDisplayItem) this.Items[index];
      lock (this._tooltip_NDI.AvailNetworkListboxColumns.SyncRoot)
      {
        int local_1 = 0;
        int local_2 = 3;
        for (int local_3 = 0; local_3 < this._tooltip_NDI.AvailNetworkListboxColumns.Count; ++local_3)
        {
          NDIAvailNetworkListboxColumn local_4 = this._tooltip_NDI.AvailNetworkListboxColumns[local_3];
          int[] local_5 = this.GetIconXPositions(local_4.Items, local_4.ColWidth);
          for (int local_6 = 0; local_6 < local_4.Items.Count; ++local_6)
          {
            if (local_4.Items[local_6] is NDIAvailNetworkListboxColumnIcon)
            {
              NDIAvailNetworkListboxColumnIcon local_7 = (NDIAvailNetworkListboxColumnIcon) local_4.Items[local_6];
              if (new Rectangle(new Point(local_1 + local_5[local_6], local_2 + this._tooltip_yOffset), new Size(local_7.Icon.Width, local_7.Icon.Height)).Contains(new Point(e.X, e.Y)) && local_7.Visible)
              {
                this._tooltip_NewText = local_7.IconTooltip;
                break;
              }
            }
          }
          local_1 += local_4.ColWidth;
        }
      }
      if (this._tooltip.GetToolTip((Control) this).CompareTo(this._tooltip_NewText) != 0 || index != this._tooltip_DisplayedForIndex)
      {
        if (string.IsNullOrEmpty(this._tooltip_NewText))
          this._tooltip.RemoveAll();
        else
          this._tooltip.SetToolTip((Control) this, this._tooltip_NewText);
      }
      this._tooltip_DisplayedForIndex = index;
    }

    private bool IgnoreMouseEvent(int x, int y)
    {
      if (this.Items.Count <= 0)
        return true;
      int num = this.IndexFromPoint(x, y);
      return num == -1 || y > this.ItemViewportY(this.Items.Count) || this._paintHeadersInListbox && (this.IsFirstConnectedNetwork(num) || this.IsFirstAvailableNetwork(num)) && y <= this.ItemViewportY(num) + DPIUtils.ScaleY(24);
    }

    private void DrawItemHandler(object sender, DrawItemEventArgs e)
    {
      if (this.Items == null || this.Items.Count <= 0 || (e == null || e.Index < 0))
        return;
      int num1 = e.Bounds.Y + 4;
      int num2 = 0;
      if (this._paintHeadersInListbox)
      {
        if (this.IsFirstConnectedNetwork(e.Index))
        {
          using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(230, 230, 230)))
            e.Graphics.FillRectangle((Brush) solidBrush, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, DPIUtils.ScaleY(24));
          string str = string.Empty;
          string s = this.GetConnectedNetworksCount() != 1 ? string.Format(DashboardStringHelper.GetString("ConnectedNetworksX"), (object) this.GetConnectedNetworksCount()) : DashboardStringHelper.GetString("ConnectedNetwork");
          using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(47, 137, 221)))
          {
            using (Font font = new Font(this.Font.FontFamily, (float) Convert.ToInt32(DashboardStringHelper.GetString("NetworkListBox_HeaderFontSize")), FontStyle.Bold))
              e.Graphics.DrawString(s, font, (Brush) solidBrush, 0.0f, (float) num1);
          }
          num1 += DPIUtils.ScaleY(24);
          num2 += DPIUtils.ScaleY(24);
          using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(204, 204, 204)))
          {
            if (e.Index > 0)
              e.Graphics.FillRectangle((Brush) solidBrush, e.Bounds.X, e.Bounds.Y, this.Width, 1);
          }
        }
        if (this.IsFirstAvailableNetwork(e.Index))
        {
          using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(230, 230, 230)))
            e.Graphics.FillRectangle((Brush) solidBrush, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, DPIUtils.ScaleY(24));
          using (Font font = new Font(this.Font.FontFamily, (float) Convert.ToInt32(DashboardStringHelper.GetString("NetworkListBox_HeaderFontSize")), FontStyle.Bold))
          {
            using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(47, 137, 221)))
              e.Graphics.DrawString(string.Format(DashboardStringHelper.GetString("NetworksAvailableToConnectX"), (object) this.GetAvailableNetworksCount()), font, (Brush) solidBrush, 0.0f, (float) num1);
          }
          num1 += DPIUtils.ScaleY(24);
          num2 += DPIUtils.ScaleY(24);
          using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(204, 204, 204)))
          {
            if (e.Index > 0)
              e.Graphics.FillRectangle((Brush) solidBrush, e.Bounds.X, e.Bounds.Y, this.Width, 1);
          }
        }
      }
      NetworkDisplayItem ndi = (NetworkDisplayItem) this.Items[e.Index];
      int itemHeight = this.GetItemHeight(e.Graphics, e.Index, ndi);
      using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(223, 234, 241)))
      {
        if (ndi.WmxNetwork.Connection != null)
        {
          if (ndi.WmxNetwork.Connection.Status == CONNECTION_STATUS.CONNECTED)
            e.Graphics.FillRectangle((Brush) solidBrush, e.Bounds.X, e.Bounds.Y + num2, this.Width, itemHeight - num2);
        }
      }
      if (this.SelectedIndex == e.Index)
      {
        if (e.Index != 0)
        {
          using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(81, 149, 217)))
            e.Graphics.FillRectangle((Brush) solidBrush, e.Bounds.X + 1, e.Bounds.Y + 2 + num2, this.Width - 2, itemHeight - 3 - num2);
          if (this._hasFocus)
            ControlPaint.DrawFocusRectangle(e.Graphics, new Rectangle(e.Bounds.X + 1, e.Bounds.Y + 2 + num2, this.Width - 2, itemHeight - 3 - num2));
        }
        else
        {
          int num3 = 1;
          if (this._paintHeadersInListbox)
            num3 = 2;
          using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(81, 149, 217)))
            e.Graphics.FillRectangle((Brush) solidBrush, e.Bounds.X + 1, e.Bounds.Y + num3 + num2, this.Width - 2, itemHeight - (num3 + 1) - num2);
          if (this._hasFocus)
            ControlPaint.DrawFocusRectangle(e.Graphics, new Rectangle(e.Bounds.X + 1, e.Bounds.Y + num3 + num2, this.Width - 2, itemHeight - (num3 + 1) - num2));
        }
      }
      if (this._paintHeadersInListbox || e.Index > 0)
      {
        using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(204, 204, 204)))
          e.Graphics.FillRectangle((Brush) solidBrush, e.Bounds.X, e.Bounds.Y + num2, this.Width, 1);
      }
      int xPos = 0;
      int yPos = num1 + 3;
      lock (ndi.AvailNetworkListboxColumns.SyncRoot)
      {
        for (int local_19 = 0; local_19 < ndi.AvailNetworkListboxColumns.Count; ++local_19)
        {
          NDIAvailNetworkListboxColumn local_20 = ndi.AvailNetworkListboxColumns[local_19];
          this.DrawColumn(ndi, local_20, xPos, yPos, e);
          xPos += local_20.ColWidth;
        }
      }
    }

    private void DrawColumn(NetworkDisplayItem ndi, NDIAvailNetworkListboxColumn column, int xPos, int yPos, DrawItemEventArgs e)
    {
      int[] iconXpositions = this.GetIconXPositions(column.Items, column.ColWidth);
      for (int index = 0; index < column.Items.Count; ++index)
      {
        if (column.Items[index] is NDIAvailNetworkListboxColumnIcon)
          this.DrawIcon((NDIAvailNetworkListboxColumnIcon) column.Items[index], xPos + iconXpositions[index], yPos, e);
        else if (column.Items[index] is NDIAvailNetworkListboxColumnText)
          this.DrawText(ndi, (NDIAvailNetworkListboxColumnText) column.Items[index], xPos, yPos, column.ColWidth, e);
      }
    }

    private int[] GetIconXPositions(List<NDIAvailNetworkListboxColumnItem> items, int colWidth)
    {
      int num1 = 8;
      int[] numArray = new int[items.Count];
      int num2 = 0;
      for (int index = 0; index < items.Count; ++index)
      {
        if (!(items[index] is NDIAvailNetworkListboxColumnIcon))
          return new int[0];
        numArray[index] = num2;
        num2 += ((NDIAvailNetworkListboxColumnIcon) items[index]).Icon.Width;
      }
      int num3 = num2 + (items.Count - 1) * num1;
      int num4 = (colWidth - num3) / 2;
      for (int index = 0; index < items.Count; ++index)
      {
        numArray[index] += num4;
        if (index > 0)
          numArray[index] += num1;
      }
      return numArray;
    }

    private void DrawIcon(NDIAvailNetworkListboxColumnIcon iconItem, int xPos, int yPos, DrawItemEventArgs e)
    {
      if (!iconItem.Visible)
        return;
      Point[] destPoints = new Point[3]
      {
        new Point(xPos, yPos),
        new Point(xPos + iconItem.Icon.Width, yPos),
        new Point(xPos, yPos + iconItem.Icon.Height)
      };
      e.Graphics.DrawImage((Image) iconItem.Icon, destPoints);
    }

    private void DrawText(NetworkDisplayItem ndi, NDIAvailNetworkListboxColumnText textItem, int xPos, int yPos, int colWidth, DrawItemEventArgs e)
    {
      string text = textItem.Text;
      Color color = Color.Black;
      if (!this.Enabled)
        color = SystemColors.GrayText;
      if (text == null)
        return;
      string str = text.Trim();
      bool disposeFont = false;
      Font fontForNetwork = this.GetFontForNetwork(ndi, ref disposeFont);
      if (fontForNetwork == null)
        return;
      SizeF sizeF = e.Graphics.MeasureString(str, fontForNetwork);
      if (SizeHelper.MeasureDisplayStringWidth(e.Graphics, str, fontForNetwork) > colWidth)
      {
        int num = 0;
        for (int length = str.Length - 1; length >= 0; --length)
        {
          if (textItem.ValidLineBreakChars.Contains(str[length]) && (double) e.Graphics.MeasureString(str.Substring(0, length), fontForNetwork).Width < (double) colWidth)
          {
            num = length + 1;
            break;
          }
        }
        if ((double) num <= (double) str.Length * 0.3333)
          num = str.Length / 2;
        using (SolidBrush solidBrush = new SolidBrush(color))
        {
          e.Graphics.DrawString(str.Substring(0, num), fontForNetwork, (Brush) solidBrush, (float) xPos, (float) yPos);
          e.Graphics.DrawString(str.Substring(num), fontForNetwork, (Brush) solidBrush, (float) xPos, (float) ((double) yPos + (double) sizeF.Height + 3.0));
        }
      }
      else
      {
        using (SolidBrush solidBrush = new SolidBrush(color))
          e.Graphics.DrawString(str, fontForNetwork, (Brush) solidBrush, (float) xPos, (float) yPos);
      }
      if (!disposeFont)
        return;
      fontForNetwork.Dispose();
    }

    private void MeasureItemHandler(object sender, MeasureItemEventArgs e)
    {
      NetworkDisplayItem ndi = (NetworkDisplayItem) this.Items[e.Index];
      e.ItemHeight = this.GetItemHeight(e.Graphics, e.Index, ndi);
    }

    private int ItemViewportY(int iItem)
    {
      int num = 0;
      using (Graphics graphics = this.CreateGraphics())
      {
        for (int topIndex = this.TopIndex; topIndex < iItem; ++topIndex)
          num += this.GetItemHeight(graphics, topIndex, (NetworkDisplayItem) this.Items[topIndex]);
      }
      return num;
    }

    private bool IsFirstConnectedNetwork(int index)
    {
      if (this.Items.Count > 0)
      {
        for (int index1 = 0; index1 < this.Items.Count; ++index1)
        {
          NetworkDisplayItem networkDisplayItem = (NetworkDisplayItem) this.Items[index1];
          if (networkDisplayItem.WmxNetwork.Connection != null && networkDisplayItem.WmxNetwork.Connection.Status == CONNECTION_STATUS.CONNECTED)
          {
            if (index == index1)
              return true;
            else
              break;
          }
        }
      }
      return false;
    }

    private bool IsFirstAvailableNetwork(int index)
    {
      if (this.Items.Count > 0)
      {
        for (int index1 = 0; index1 < this.Items.Count; ++index1)
        {
          NetworkDisplayItem networkDisplayItem = (NetworkDisplayItem) this.Items[index1];
          if (networkDisplayItem.WmxNetwork.Connection == null || networkDisplayItem.WmxNetwork.Connection.Status != CONNECTION_STATUS.CONNECTED)
          {
            if (index == index1)
              return true;
            else
              break;
          }
        }
      }
      return false;
    }

    private int GetAvailableNetworksCount()
    {
      int num = 0;
      if (this.Items.Count > 0)
      {
        for (int index = 0; index < this.Items.Count; ++index)
        {
          NetworkDisplayItem networkDisplayItem = (NetworkDisplayItem) this.Items[index];
          if (networkDisplayItem.WmxNetwork.Connection == null || networkDisplayItem.WmxNetwork.Connection.Status != CONNECTION_STATUS.CONNECTED)
            ++num;
        }
      }
      return num;
    }

    private int GetConnectedNetworksCount()
    {
      int num = 0;
      if (this.Items.Count > 0)
      {
        for (int index = 0; index < this.Items.Count; ++index)
        {
          NetworkDisplayItem networkDisplayItem = (NetworkDisplayItem) this.Items[index];
          if (networkDisplayItem.WmxNetwork.Connection != null && networkDisplayItem.WmxNetwork.Connection.Status == CONNECTION_STATUS.CONNECTED)
            ++num;
        }
      }
      return num;
    }

    private int GetItemHeight(Graphics g, int index, NetworkDisplayItem ndi)
    {
      int num = DPIUtils.ScaleY(36);
      lock (ndi.AvailNetworkListboxColumns.SyncRoot)
      {
        for (int local_2 = 0; local_2 < ndi.AvailNetworkListboxColumns.Count; ++local_2)
        {
          for (int local_3 = 0; local_3 < ndi.AvailNetworkListboxColumns[local_2].Items.Count; ++local_3)
          {
            NDIAvailNetworkListboxColumn local_1_1 = ndi.AvailNetworkListboxColumns[local_2];
            if (local_1_1.Items[local_3] is NDIAvailNetworkListboxColumnText)
            {
              bool local_4 = false;
              Font local_5 = this.GetFontForNetwork(ndi, ref local_4);
              NDIAvailNetworkListboxColumnText local_6 = (NDIAvailNetworkListboxColumnText) local_1_1.Items[local_3];
              SizeF local_7 = g.MeasureString(local_6.Text, local_5);
              if (SizeHelper.MeasureDisplayStringWidth(g, local_6.Text, local_5) > local_1_1.ColWidth)
              {
                num = (int) ((double) DPIUtils.ScaleY(36) + (double) local_7.Height + 3.0);
                break;
              }
              else if (local_4)
                local_5.Dispose();
            }
          }
        }
      }
      if (index > 0)
        ++num;
      if (this._paintHeadersInListbox && (this.IsFirstConnectedNetwork(index) || this.IsFirstAvailableNetwork(index)))
        num += DPIUtils.ScaleY(24);
      return num;
    }

    private Font GetFontForNetwork(NetworkDisplayItem ndi, ref bool disposeFont)
    {
      disposeFont = false;
      if (!(ndi.NetworkName.Trim().ToLower() == "clear"))
        return this.Font;
      disposeFont = true;
      return new Font(this.Font.FontFamily, 11f, FontStyle.Bold);
    }

    public void SetDataSource(List<NetworkDisplayItem> ndiList)
    {
      this.SelectedIndexChanged -= new EventHandler(this.OnSelectedIndexChanged);
      this.Items.Clear();
      bool flag = false;
      for (int index = 0; index < ndiList.Count; ++index)
      {
        this.Items.Add((object) ndiList[index]);
        if (NetworkHandler.IsSameNetwork(this._currSelectedNDI, ndiList[index]))
        {
          this.SelectedIndex = index;
          flag = true;
        }
      }
      if (this.Items.Count > 0 && !flag)
        this.SelectedIndex = 0;
      this.HandleSelectedIndexChanged();
      this.SelectedIndexChanged += new EventHandler(this.OnSelectedIndexChanged);
    }

    private void HandleSelectedIndexChanged()
    {
      this.Invalidate();
      this._currSelectedNDI = this.Items.Count <= 0 || this.SelectedItem == null ? (NetworkDisplayItem) null : (NetworkDisplayItem) ((NetworkDisplayItem) this.SelectedItem).Clone();
      Eventing.GenerateUIEvent("WiMAXUI.OnAvailableNetworkListSelectionChanged", (object) this, new object[1]
      {
        this.SelectedItem
      });
    }

    private void ShowContextMenu(Point p)
    {
      ContextMenu contextMenu = new ContextMenu();
      NetworkDisplayItem networkDisplayItem = (NetworkDisplayItem) this.Items[this.SelectedIndex];
      MenuItem menuItem1 = new MenuItem();
      menuItem1.Text = DashboardStringHelper.GetString("Connect");
      menuItem1.Click += new EventHandler(this.ContextMenu_Connect_Click);
      if (!AdapterHandler.TheAdapter.RadioIsOn() || this.Items.Count == 0 || (this.SelectedItem == null || !MediaHandler.TheMedia.WiMAXIsReady) || (!MediaHandler.IntelCUIsInControl || NetworkHandler.ConnectedNetworks.Count > 0))
        menuItem1.Enabled = false;
      contextMenu.MenuItems.Add(menuItem1);
      MenuItem menuItem2 = new MenuItem();
      menuItem2.Text = DashboardStringHelper.GetString("ViewDetailsEllipse");
      menuItem2.Click += new EventHandler(this.ContextMenu_ViewDetails_Click);
      if (!AdapterHandler.TheAdapter.RadioIsOn() || this.Items.Count == 0 || (this.SelectedItem == null || !MediaHandler.TheMedia.WiMAXIsReady) || !MediaHandler.IntelCUIsInControl)
        menuItem2.Enabled = false;
      contextMenu.MenuItems.Add(menuItem2);
      try
      {
        contextMenu.Show((Control) this, p);
      }
      catch (Exception ex)
      {
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Warning, (object) this, Logging.GetMessageForException(ex));
      }
    }
  }
}
