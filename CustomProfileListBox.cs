// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.CustomProfileListBox
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.SDKInterop;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using Intel.Mobile.WiMAXCU.UI.DisplayWiMAX;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class CustomProfileListBox : ListBox
  {
    private ToolTip _tooltip = new ToolTip();
    private int _tooltip_DisplayedForIndex = -1;
    private const int STARTX = 0;
    private const int STARTY = 3;
    private const int SINGLE_LINE_HEIGHT = 36;
    private const int HEADER_HEIGHT = 24;
    private bool _hasFocus;
    private ProfileSelectedDelegate _profileSelectedCallback;
    private ProperitesDelegate _properitesCallback;
    private SetAsDefaultDelegate _setAsDefaultCallback;
    private EnableProperitesDelegate _enableProperitesCallback;
    private EnableSetAsDefaultDelegate _enableSetAsDefaultCallback;

    public ProfileSelectedDelegate ProfileSelectedCallback
    {
      get
      {
        return this._profileSelectedCallback;
      }
      set
      {
        this._profileSelectedCallback = value;
      }
    }

    public ProperitesDelegate ProperitesCallback
    {
      get
      {
        return this._properitesCallback;
      }
      set
      {
        this._properitesCallback = value;
      }
    }

    public SetAsDefaultDelegate SetAsDefaultCallback
    {
      get
      {
        return this._setAsDefaultCallback;
      }
      set
      {
        this._setAsDefaultCallback = value;
      }
    }

    public EnableProperitesDelegate EnableProperitesCallback
    {
      get
      {
        return this._enableProperitesCallback;
      }
      set
      {
        this._enableProperitesCallback = value;
      }
    }

    public EnableSetAsDefaultDelegate EnableSetAsDefaultCallback
    {
      get
      {
        return this._enableSetAsDefaultCallback;
      }
      set
      {
        this._enableSetAsDefaultCallback = value;
      }
    }

    public CustomProfileListBox()
    {
      this.DrawMode = DrawMode.OwnerDrawVariable;
      this.BorderStyle = BorderStyle.None;
      this.DrawItem += new DrawItemEventHandler(this.DrawItemHandler);
      this.MeasureItem += new MeasureItemEventHandler(this.MeasureItemHandler);
      this.SelectedIndexChanged += new EventHandler(this.OnSelectedIndexChanged);
      this.MouseDown += new MouseEventHandler(this.OnMouseDown);
      this.MouseMove += new MouseEventHandler(this.OnMouseMove);
      this.Leave += new EventHandler(this.OnLostFocus);
      this.Enter += new EventHandler(this.OnGotFocus);
      this.DoubleClick += new EventHandler(this.OnItemDoubleClicked);
      this.SelectionMode = SelectionMode.One;
      this._tooltip.ShowAlways = true;
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
      if (this._setAsDefaultCallback == null)
        return;
      this._setAsDefaultCallback();
    }

    private void OnSelectedIndexChanged(object sender, EventArgs e)
    {
      this.Invalidate();
      if (this._profileSelectedCallback == null)
        return;
      this._profileSelectedCallback();
    }

    private void ContextMenu_SetAsPreferred_Click(object sender, EventArgs e)
    {
      if (this._setAsDefaultCallback == null)
        return;
      this._setAsDefaultCallback();
    }

    private void ContextMenu_Properites_Click(object sender, EventArgs e)
    {
      if (this._properitesCallback == null)
        return;
      this._properitesCallback();
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
      string str = string.Empty;
      if (this.Items.Count <= 0)
        return;
      int iItem = this.IndexFromPoint(e.X, e.Y);
      if (iItem == -1)
        return;
      int num1 = this.ItemViewportY(iItem);
      List<NDIAvailNetworkListboxColumn> list = this.SetupColumns((ProfileDisplayItem) this.Items[iItem]);
      int num2 = 0;
      int num3 = 3;
      for (int index1 = 0; index1 < list.Count; ++index1)
      {
        NDIAvailNetworkListboxColumn networkListboxColumn = list[index1];
        int[] iconXpositions = this.GetIconXPositions(networkListboxColumn.Items, networkListboxColumn.ColWidth);
        for (int index2 = 0; index2 < networkListboxColumn.Items.Count; ++index2)
        {
          if (networkListboxColumn.Items[index2] is NDIAvailNetworkListboxColumnIcon)
          {
            NDIAvailNetworkListboxColumnIcon listboxColumnIcon = (NDIAvailNetworkListboxColumnIcon) networkListboxColumn.Items[index2];
            if (new Rectangle(new Point(num2 + iconXpositions[index2], num3 + num1), new Size(listboxColumnIcon.Icon.Width, listboxColumnIcon.Icon.Height)).Contains(new Point(e.X, e.Y)) && listboxColumnIcon.Visible)
            {
              str = listboxColumnIcon.IconTooltip;
              break;
            }
          }
        }
        num2 += networkListboxColumn.ColWidth;
      }
      if (this._tooltip.GetToolTip((Control) this).CompareTo(str) != 0 || iItem != this._tooltip_DisplayedForIndex)
      {
        if (string.IsNullOrEmpty(str))
          this._tooltip.RemoveAll();
        else
          this._tooltip.SetToolTip((Control) this, str);
      }
      this._tooltip_DisplayedForIndex = iItem;
    }

    private bool IgnoreMouseEvent(int x, int y)
    {
      return this.Items.Count <= 0 || this.IndexFromPoint(x, y) == -1 || y > this.ItemViewportY(this.Items.Count);
    }

    private void DrawItemHandler(object sender, DrawItemEventArgs e)
    {
      if (this.Items == null || this.Items.Count <= 0 || (e == null || e.Index < 0))
        return;
      int num1 = e.Bounds.Y + 4;
      int num2 = 0;
      ProfileDisplayItem pdi = (ProfileDisplayItem) this.Items[e.Index];
      int itemHeight = this.GetItemHeight();
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
          using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(81, 149, 217)))
            e.Graphics.FillRectangle((Brush) solidBrush, e.Bounds.X + 1, e.Bounds.Y + num3 + num2, this.Width - 2, itemHeight - (num3 + 1) - num2);
          if (this._hasFocus)
            ControlPaint.DrawFocusRectangle(e.Graphics, new Rectangle(e.Bounds.X + 1, e.Bounds.Y + num3 + num2, this.Width - 2, itemHeight - (num3 + 1) - num2));
        }
      }
      if (e.Index > 0)
      {
        using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(204, 204, 204)))
          e.Graphics.FillRectangle((Brush) solidBrush, e.Bounds.X, e.Bounds.Y + num2, this.Width, 1);
      }
      List<NDIAvailNetworkListboxColumn> list = this.SetupColumns(pdi);
      int xPos = 0;
      int yPos = num1 + 3;
      foreach (NDIAvailNetworkListboxColumn column in list)
      {
        this.DrawColumn(column, xPos, yPos, e);
        xPos += column.ColWidth;
      }
    }

    private List<NDIAvailNetworkListboxColumn> SetupColumns(ProfileDisplayItem pdi)
    {
      List<NDIAvailNetworkListboxColumn> list = new List<NDIAvailNetworkListboxColumn>();
      List<ListBoxHeaderData> listboxHeaderData = ProfileListBox.GetListboxHeaderData();
      list.Add(new NDIAvailNetworkListboxColumn()
      {
        ColWidth = listboxHeaderData[0].Width,
        Items = {
          (NDIAvailNetworkListboxColumnItem) new NDIAvailNetworkListboxColumnIcon()
          {
            Icon = WiMAXDisplayService.Singleton.GetPreferredIcon(),
            IconTooltip = WiMAXDisplayService.Singleton.GetPreferredIconTooltip(),
            Visible = pdi.Preferred
          },
          (NDIAvailNetworkListboxColumnItem) new NDIAvailNetworkListboxColumnIcon()
          {
            Icon = WiMAXDisplayService.Singleton.GetHomeIcon(),
            IconTooltip = WiMAXDisplayService.Singleton.GetHomeIconTooltip(),
            Visible = WiMAXDisplayService.IsHomeNetwork(pdi.TheProfile.profileId)
          }
        }
      });
      list.Add(new NDIAvailNetworkListboxColumn()
      {
        ColWidth = listboxHeaderData[1].Width,
        Items = {
          (NDIAvailNetworkListboxColumnItem) new NDIAvailNetworkListboxColumnText()
          {
            Text = MiscUtilities.ParseProfileName(pdi.TheProfile.profileName)
          }
        }
      });
      return list;
    }

    private void DrawColumn(NDIAvailNetworkListboxColumn column, int xPos, int yPos, DrawItemEventArgs e)
    {
      int[] iconXpositions = this.GetIconXPositions(column.Items, column.ColWidth);
      for (int index = 0; index < column.Items.Count; ++index)
      {
        if (column.Items[index] is NDIAvailNetworkListboxColumnIcon)
          this.DrawIcon((NDIAvailNetworkListboxColumnIcon) column.Items[index], xPos + iconXpositions[index], yPos, e);
        else if (column.Items[index] is NDIAvailNetworkListboxColumnText)
          this.DrawText((NDIAvailNetworkListboxColumnText) column.Items[index], xPos, yPos, column.ColWidth, e);
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

    private void DrawText(NDIAvailNetworkListboxColumnText textItem, int xPos, int yPos, int colWidth, DrawItemEventArgs e)
    {
      string text = textItem.Text;
      Color color = Color.Black;
      if (!this.Enabled)
        color = SystemColors.GrayText;
      if (text == null)
        return;
      string s = text.Trim();
      using (SolidBrush solidBrush = new SolidBrush(color))
        e.Graphics.DrawString(s, this.Font, (Brush) solidBrush, (float) xPos, (float) yPos);
    }

    private void MeasureItemHandler(object sender, MeasureItemEventArgs e)
    {
      e.ItemHeight = this.GetItemHeight();
    }

    private int ItemViewportY(int iItem)
    {
      int num = 0;
      using (this.CreateGraphics())
      {
        for (int topIndex = this.TopIndex; topIndex < iItem; ++topIndex)
          num += this.GetItemHeight();
      }
      return num;
    }

    private int GetItemHeight()
    {
      return DPIUtils.ScaleY(36);
    }

    public void SetDataSource(List<ProfileDisplayItem> profileList)
    {
      this.SelectedIndexChanged -= new EventHandler(this.OnSelectedIndexChanged);
      this.Items.Clear();
      for (int index = 0; index < profileList.Count; ++index)
        this.Items.Add((object) profileList[index]);
      if (this.Items.Count > 0)
        this.SelectedIndex = 0;
      this.Invalidate();
      this.SelectedIndexChanged += new EventHandler(this.OnSelectedIndexChanged);
    }

    private void ShowContextMenu(Point p)
    {
      ContextMenu contextMenu = new ContextMenu();
      MenuItem menuItem = new MenuItem();
      menuItem.Text = ManageNetworksDlgStringHelper.GetString("ManageNetworksPanel_SetAsPreferredBtn");
      menuItem.Click += new EventHandler(this.ContextMenu_SetAsPreferred_Click);
      menuItem.Enabled = this._enableSetAsDefaultCallback();
      contextMenu.MenuItems.Add(menuItem);
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
