// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.TaskTrayContextMenu
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.SDKInterop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class TaskTrayContextMenu
  {
    private static string _vistaMobilityCenterEXE = Environment.GetEnvironmentVariable("SystemRoot") + "\\system32\\mblctr.exe";
    private ContextMenu _contextMenu;
    private MenuItem _connectToSubMenu;

    static TaskTrayContextMenu()
    {
    }

    public TaskTrayContextMenu(ContextMenu contextMenu)
    {
      this._contextMenu = contextMenu;
    }

    public void ClearContextMenu()
    {
      this._contextMenu.MenuItems.Clear();
    }

    public void UpdateContextMenu()
    {
      bool flag = true;
      if (!MediaHandler.TheMedia.WiMAXIsReady || !MediaHandler.IntelCUIsInControl || AdvancedDialog.Singleton.Blocked)
        flag = false;
      this._contextMenu.MenuItems.Clear();
      this.AddOpenMenuItem(ref this._contextMenu);
      if (flag && Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.ShouldControlBeEnabled(DashboardControlEnum.TaskTrayMenu_RadioOnOff))
        this.AddRadioMenuItems(ref this._contextMenu, true);
      else
        this.AddRadioMenuItems(ref this._contextMenu, false);
      if (flag && Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.ShouldControlBeEnabled(DashboardControlEnum.TaskTrayMenu_Connect))
        this.AddConnectMenuItem(ref this._contextMenu, true);
      else
        this.AddConnectMenuItem(ref this._contextMenu, false);
      if (flag && Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.ShouldControlBeEnabled(DashboardControlEnum.TaskTrayMenu_Disconnect))
        this.AddDisconnectMenuItem(ref this._contextMenu, true);
      else
        this.AddDisconnectMenuItem(ref this._contextMenu, false);
      this.AddExitMenuItem(ref this._contextMenu);
    }

    private void Connect_Click(object sender, EventArgs e)
    {
      Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user selected the 'Connect' task tray menu item.");
      DashboardAndTaskTray.ConnectToNetwork((NetworkDisplayItem) ((TaskTrayContextMenu.MenuItemWithData) sender).AssociatedData);
    }

    private void Disconnect_Click(object sender, EventArgs e)
    {
      Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user selected the 'Disconnect' task tray menu item.");
      DashboardAndTaskTray.DisconnectFromNetwork((NetworkDisplayItem) ((TaskTrayContextMenu.MenuItemWithData) sender).AssociatedData);
    }

    private void TurnWiMAXRadioOff_Click(object sender, EventArgs e)
    {
      Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user selected the 'WiMAX Off' task tray menu item.");
      DashboardAndTaskTray.TurnRadioOff();
    }

    private void TurnWiMAXRadioOn_Click(object sender, EventArgs e)
    {
      Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user selected the 'WiMAX On' task tray menu item.");
      DashboardAndTaskTray.TurnRadioOn();
    }

    private void TurnWiFiRadioOff_Click(object sender, EventArgs e)
    {
      Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user selected the 'WiFi Off' task tray menu item.");
      DashboardAndTaskTray.TurnWiFiRadioOff();
    }

    private void TurnWiFiRadioOn_Click(object sender, EventArgs e)
    {
      Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user selected the 'WiFi On' task tray menu item.");
      DashboardAndTaskTray.TurnWiFiRadioOn();
    }

    private void TurnAllRadiosOff_Click(object sender, EventArgs e)
    {
      Logging.LogEvent(TraceModule.SDK, TraceLevel.Info, (object) this, "--> The user selected the 'WiMAX and WiFi Off' task tray menu item.");
      DashboardAndTaskTray.TurnWiFiRadioOff();
      DashboardAndTaskTray.TurnRadioOff();
    }

    private void TurnWiFiOnOff_Click(object sender, EventArgs e)
    {
      Process.Start(new ProcessStartInfo(TaskTrayContextMenu._vistaMobilityCenterEXE)
      {
        WindowStyle = ProcessWindowStyle.Normal,
        Arguments = " /open"
      });
    }

    private void Open_Click(object sender, EventArgs e)
    {
      AppFramework.Dashboard.ShowMainWindow();
    }

    private void Exit_Click(object sender, EventArgs e)
    {
      AppFramework.TaskTray.CloseMainWindow();
    }

    private void AddConnectMenuItem(ref ContextMenu contextMenu, bool enableMenuItems)
    {
      if (this._connectToSubMenu == null)
      {
        this._connectToSubMenu = new MenuItem();
        this._connectToSubMenu.Text = TaskTrayStringHelper.GetString("TaskTray_Menu_ConnectTo");
      }
      this._connectToSubMenu.Enabled = MediaHandler.TheMedia.WiMAXIsReady && MediaHandler.IntelCUIsInControl && (AdapterHandler.TheAdapter.RadioIsOn() && !Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForRadioSwitch) && !AdvancedDialog.Singleton.Blocked;
      this.AddConnectSubMenuItems(enableMenuItems);
      if (!Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForDisconnect && (NetworkHandler.ConnectedNetworks.Count == 0 || !MediaHandler.TheMedia.WiMAXIsReady || (!MediaHandler.IntelCUIsInControl || !AdapterHandler.TheAdapter.RadioIsOn())))
        contextMenu.MenuItems.Add(this._connectToSubMenu);
      else
        contextMenu.MenuItems.Remove(this._connectToSubMenu);
    }

    public void AddConnectSubMenuItems(bool enableMenuItems)
    {
      int num = 0;
      if (this._connectToSubMenu == null)
        return;
      this._connectToSubMenu.MenuItems.Clear();
      try
      {
        foreach (NetworkDisplayItem networkDisplayItem in new List<NetworkDisplayItem>((IEnumerable<NetworkDisplayItem>) NetworkHandler.AvailableNetworks))
        {
          if (networkDisplayItem.WmxNetwork.Connection == null || networkDisplayItem.WmxNetwork.Connection.Status != CONNECTION_STATUS.CONNECTED)
          {
            TaskTrayContextMenu.MenuItemWithData menuItemWithData = new TaskTrayContextMenu.MenuItemWithData();
            menuItemWithData.Text = networkDisplayItem.NetworkName;
            menuItemWithData.AssociatedData = (object) networkDisplayItem;
            menuItemWithData.Click += new EventHandler(this.Connect_Click);
            menuItemWithData.Enabled = enableMenuItems;
            this._connectToSubMenu.MenuItems.Add((MenuItem) menuItemWithData);
            ++num;
          }
        }
      }
      catch (Exception ex)
      {
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Warning, (object) this, Logging.GetMessageForException(ex));
      }
      if (num != 0)
        return;
      string profileDisplayName = DashboardAndTaskTray.GetPreferredProfileDisplayName();
      TaskTrayContextMenu.MenuItemWithData menuItemWithData1 = new TaskTrayContextMenu.MenuItemWithData();
      if (string.IsNullOrEmpty(profileDisplayName) || Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForManualWideScan || ScanModeHandler.ScanMode == ScanModeEnum.BackgroundScanningDisabled)
      {
        if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForScan)
          menuItemWithData1.Text = TaskTrayStringHelper.GetString("TaskTray_Menu_SearchingForWiMAXNetworks");
        else
          menuItemWithData1.Text = TaskTrayStringHelper.GetString("TaskTray_Menu_NoAvailableNetworks");
      }
      else if (Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForScan)
        menuItemWithData1.Text = string.Format(TaskTrayStringHelper.GetString("TaskTray_Menu_SearchingForX"), (object) profileDisplayName);
      else
        menuItemWithData1.Text = string.Format(TaskTrayStringHelper.GetString("TaskTray_Menu_XIsNotAvailable"), (object) profileDisplayName);
      menuItemWithData1.Enabled = false;
      this._connectToSubMenu.MenuItems.Add((MenuItem) menuItemWithData1);
    }

    private void AddDisconnectMenuItem(ref ContextMenu contextMenu, bool enableMenuItems)
    {
      if (!AdapterHandler.TheAdapter.RadioIsOn())
        enableMenuItems = false;
      if (!Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.BlockedForDisconnect && (NetworkHandler.ConnectedNetworks.Count <= 0 || !MediaHandler.TheMedia.WiMAXIsReady || (!MediaHandler.IntelCUIsInControl || !AdapterHandler.TheAdapter.RadioIsOn())))
        return;
      TaskTrayContextMenu.MenuItemWithData menuItemWithData = new TaskTrayContextMenu.MenuItemWithData();
      menuItemWithData.Text = TaskTrayStringHelper.GetString("TaskTray_Menu_Disconnect");
      if (NetworkHandler.ConnectedNetworks.Count > 0)
        menuItemWithData.AssociatedData = (object) NetworkHandler.ConnectedNetworks[0];
      menuItemWithData.Click += new EventHandler(this.Disconnect_Click);
      menuItemWithData.Enabled = enableMenuItems;
      contextMenu.MenuItems.Add((MenuItem) menuItemWithData);
    }

    private void AddRadioMenuItems(ref ContextMenu contextMenu, bool enableMenuItems)
    {
      if (!AdapterHandler.TheAdapter.HardwareRadioOn)
        enableMenuItems = false;
      if (!AppFramework.Dashboard.TheConnectionPanel.WiFiMenuVisible)
      {
        this.AddRadioMenuItemsForWiMAXOnly(ref contextMenu, enableMenuItems);
      }
      else
      {
        bool bWiMAXRadioState = false;
        bool bSWRadioState = false;
        bool bHwRadioState = false;
        if (MediaHandler.TheMedia.WiMAXIsReady && MediaHandler.IntelCUIsInControl && AdapterHandler.TheAdapter.SoftwareRadioOn)
          bWiMAXRadioState = true;
        if (WiFiHandler.Singleton.GetRadioState(ref bSWRadioState, ref bHwRadioState) != 0)
          bSWRadioState = false;
        if (AppFramework.Dashboard.TheConnectionPanel.WifiBeingControlledByComboCard)
          this.AddRadioMenuItemsForWiFiAndWiMAX(ref contextMenu, enableMenuItems, bSWRadioState, bWiMAXRadioState);
        else
          this.AddRadioMenuItemsForDualMode(ref contextMenu, enableMenuItems, bSWRadioState, bWiMAXRadioState);
      }
      this.AddSeparator(ref contextMenu);
    }

    private void AddRadioMenuItemsForWiMAXOnly(ref ContextMenu contextMenu, bool enableMenuItems)
    {
      TaskTrayContextMenu.MenuItemWithData menuItemWithData1 = new TaskTrayContextMenu.MenuItemWithData();
      menuItemWithData1.AssociatedData = (object) MediaHandler.TheMedia;
      menuItemWithData1.Enabled = enableMenuItems;
      menuItemWithData1.RadioCheck = true;
      menuItemWithData1.Text = TaskTrayStringHelper.GetString("TaskTray_Menu_WiMAXRadioOn");
      if (MediaHandler.TheMedia.WiMAXIsReady && MediaHandler.IntelCUIsInControl && AdapterHandler.TheAdapter.SoftwareRadioOn)
        menuItemWithData1.Checked = true;
      else
        menuItemWithData1.Checked = false;
      if (!menuItemWithData1.Checked)
        menuItemWithData1.Click += new EventHandler(this.TurnWiMAXRadioOn_Click);
      contextMenu.MenuItems.Add((MenuItem) menuItemWithData1);
      TaskTrayContextMenu.MenuItemWithData menuItemWithData2 = new TaskTrayContextMenu.MenuItemWithData();
      menuItemWithData2.AssociatedData = (object) MediaHandler.TheMedia;
      menuItemWithData2.Enabled = enableMenuItems;
      menuItemWithData2.RadioCheck = true;
      menuItemWithData2.Text = TaskTrayStringHelper.GetString("TaskTray_Menu_WiMAXRadioOff");
      menuItemWithData2.Checked = !menuItemWithData1.Checked;
      if (!menuItemWithData2.Checked)
        menuItemWithData2.Click += new EventHandler(this.TurnWiMAXRadioOff_Click);
      contextMenu.MenuItems.Add((MenuItem) menuItemWithData2);
    }

    private void AddRadioMenuItemsForWiFiAndWiMAX(ref ContextMenu contextMenu, bool enableMenuItems, bool bWiFiSwRadioState, bool bWiMAXRadioState)
    {
      TaskTrayContextMenu.MenuItemWithData menuItemWithData1 = new TaskTrayContextMenu.MenuItemWithData();
      menuItemWithData1.AssociatedData = (object) MediaHandler.TheMedia;
      menuItemWithData1.Enabled = enableMenuItems;
      menuItemWithData1.RadioCheck = true;
      menuItemWithData1.Text = TaskTrayStringHelper.GetString("TaskTray_Menu_WiMAXRadioOn");
      menuItemWithData1.Checked = bWiMAXRadioState;
      if (!menuItemWithData1.Checked)
        menuItemWithData1.Click += new EventHandler(this.TurnWiMAXRadioOn_Click);
      contextMenu.MenuItems.Add((MenuItem) menuItemWithData1);
      bool flag1 = true;
      if (!Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.ShouldWiFiOnOffBeEnabled(true) || AdvancedDialog.Singleton.Blocked)
        flag1 = false;
      TaskTrayContextMenu.MenuItemWithData menuItemWithData2 = new TaskTrayContextMenu.MenuItemWithData();
      menuItemWithData2.AssociatedData = (object) MediaHandler.TheMedia;
      menuItemWithData2.RadioCheck = true;
      menuItemWithData2.Text = TaskTrayStringHelper.GetString("TaskTray_Menu_WiFiRadioOn");
      menuItemWithData2.Checked = bWiFiSwRadioState;
      menuItemWithData2.Enabled = flag1;
      if (!menuItemWithData2.Checked)
        menuItemWithData2.Click += new EventHandler(this.TurnWiFiRadioOn_Click);
      contextMenu.MenuItems.Add((MenuItem) menuItemWithData2);
      bool flag2 = true;
      if (!Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.ShouldWiFiOnOffBeEnabled(false) || AdvancedDialog.Singleton.Blocked)
        flag2 = false;
      TaskTrayContextMenu.MenuItemWithData menuItemWithData3 = new TaskTrayContextMenu.MenuItemWithData();
      menuItemWithData3.AssociatedData = (object) MediaHandler.TheMedia;
      menuItemWithData3.RadioCheck = true;
      menuItemWithData3.Text = TaskTrayStringHelper.GetString("TaskTray_Menu_AllRadiosOff");
      menuItemWithData3.Enabled = flag2;
      if (!bWiMAXRadioState && !bWiFiSwRadioState)
        menuItemWithData3.Checked = true;
      else
        menuItemWithData3.Click += new EventHandler(this.TurnAllRadiosOff_Click);
      contextMenu.MenuItems.Add((MenuItem) menuItemWithData3);
    }

    private void AddRadioMenuItemsForDualMode(ref ContextMenu contextMenu, bool enableMenuItems, bool bWiFiSwRadioState, bool bWiMAXRadioState)
    {
      TaskTrayContextMenu.MenuItemWithData menuItemWithData1 = new TaskTrayContextMenu.MenuItemWithData();
      menuItemWithData1.AssociatedData = (object) MediaHandler.TheMedia;
      menuItemWithData1.Enabled = enableMenuItems;
      menuItemWithData1.RadioCheck = true;
      menuItemWithData1.Text = TaskTrayStringHelper.GetString("TaskTray_Menu_WiMAXRadioOn");
      menuItemWithData1.Checked = bWiMAXRadioState;
      if (!menuItemWithData1.Checked)
        menuItemWithData1.Click += new EventHandler(this.TurnWiMAXRadioOn_Click);
      contextMenu.MenuItems.Add((MenuItem) menuItemWithData1);
      TaskTrayContextMenu.MenuItemWithData menuItemWithData2 = new TaskTrayContextMenu.MenuItemWithData();
      menuItemWithData2.AssociatedData = (object) MediaHandler.TheMedia;
      menuItemWithData2.Enabled = enableMenuItems;
      menuItemWithData2.RadioCheck = true;
      menuItemWithData2.Text = TaskTrayStringHelper.GetString("TaskTray_Menu_WiMAXRadioOff");
      menuItemWithData2.Checked = !bWiMAXRadioState;
      if (!menuItemWithData2.Checked)
        menuItemWithData2.Click += new EventHandler(this.TurnWiMAXRadioOff_Click);
      contextMenu.MenuItems.Add((MenuItem) menuItemWithData2);
      this.AddSeparator(ref contextMenu);
      bool flag1 = true;
      if (!Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.ShouldWiFiOnOffBeEnabled(true) || AdvancedDialog.Singleton.Blocked)
        flag1 = false;
      TaskTrayContextMenu.MenuItemWithData menuItemWithData3 = new TaskTrayContextMenu.MenuItemWithData();
      menuItemWithData3.AssociatedData = (object) MediaHandler.TheMedia;
      menuItemWithData3.RadioCheck = true;
      menuItemWithData3.Text = TaskTrayStringHelper.GetString("TaskTray_Menu_WiFiRadioOn");
      menuItemWithData3.Checked = bWiFiSwRadioState;
      menuItemWithData3.Enabled = flag1;
      if (!menuItemWithData3.Checked)
        menuItemWithData3.Click += new EventHandler(this.TurnWiFiRadioOn_Click);
      contextMenu.MenuItems.Add((MenuItem) menuItemWithData3);
      bool flag2 = true;
      if (!Intel.Mobile.WiMAXCU.BizTier.ApplicationState.Singleton.ShouldWiFiOnOffBeEnabled(true) || AdvancedDialog.Singleton.Blocked)
        flag2 = false;
      TaskTrayContextMenu.MenuItemWithData menuItemWithData4 = new TaskTrayContextMenu.MenuItemWithData();
      menuItemWithData4.AssociatedData = (object) MediaHandler.TheMedia;
      menuItemWithData4.Enabled = flag2;
      menuItemWithData4.RadioCheck = true;
      menuItemWithData4.Text = TaskTrayStringHelper.GetString("TaskTray_Menu_WiFiRadioOff");
      menuItemWithData4.Checked = !bWiFiSwRadioState;
      if (!menuItemWithData4.Checked)
        menuItemWithData4.Click += new EventHandler(this.TurnWiFiRadioOff_Click);
      contextMenu.MenuItems.Add((MenuItem) menuItemWithData4);
    }

    private void AddOpenMenuItem(ref ContextMenu contextMenu)
    {
      TaskTrayContextMenu.MenuItemWithData menuItemWithData = new TaskTrayContextMenu.MenuItemWithData();
      menuItemWithData.Text = TaskTrayStringHelper.GetString("TaskTray_Menu_OpenWiMAXUtility");
      menuItemWithData.DefaultItem = true;
      menuItemWithData.Click += new EventHandler(this.Open_Click);
      contextMenu.MenuItems.Add((MenuItem) menuItemWithData);
      this.AddSeparator(ref contextMenu);
    }

    private void AddExitMenuItem(ref ContextMenu contextMenu)
    {
      if (!CurrentUserSettings.ShowExitMenuItem())
        return;
      this.AddSeparator(ref contextMenu);
      TaskTrayContextMenu.MenuItemWithData menuItemWithData1 = new TaskTrayContextMenu.MenuItemWithData();
      TaskTrayContextMenu.MenuItemWithData menuItemWithData2 = menuItemWithData1;
      string str = menuItemWithData2.Text + TaskTrayStringHelper.GetString("TaskTray_Menu_Exit");
      menuItemWithData2.Text = str;
      menuItemWithData1.Click += new EventHandler(this.Exit_Click);
      contextMenu.MenuItems.Add((MenuItem) menuItemWithData1);
    }

    private void AddSeparator(ref ContextMenu contextMenu)
    {
      MenuItem menuItem = new MenuItem("-");
      contextMenu.MenuItems.Add(menuItem);
    }

    internal class MenuItemWithData : MenuItem
    {
      private object _associatedData;

      public object AssociatedData
      {
        get
        {
          return this._associatedData;
        }
        set
        {
          this._associatedData = value;
        }
      }
    }
  }
}
