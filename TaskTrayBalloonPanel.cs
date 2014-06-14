// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.TaskTrayBalloonPanel
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.UI.CustomControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class TaskTrayBalloonPanel : UserControl
  {
    private const int padding = 6;
    private IContainer components;
    private TextPanel MessageTextPanel;
    private string _message;

    public TaskTrayBalloonPanel(string message)
    {
      this._message = message;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TaskTrayBalloonPanel));
      this.MessageTextPanel = new TextPanel();
      this.SuspendLayout();
      this.MessageTextPanel.Alignment = StringAlignment.Near;
      this.MessageTextPanel.BackColor = Color.White;
      componentResourceManager.ApplyResources((object) this.MessageTextPanel, "MessageTextPanel");
      this.MessageTextPanel.Name = "MessageTextPanel";
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.MessageTextPanel);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "TaskTrayBalloonPanel";
      this.ResumeLayout(false);
    }

    private void OnClientAreaClick(object sender, EventArgs e)
    {
      TaskTrayPopupDialog.Singleton.HidePopup();
      switch (TaskTrayPopupDialog.Singleton.TaskTrayPopupClickOption)
      {
        case TaskTrayPopupClickOptions.LaunchDashboard:
          AppFramework.Dashboard.ShowMainWindow();
          break;
        case TaskTrayPopupClickOptions.LaunchDisconnectedRealmMismatchHelp:
          AppFramework.Dashboard.LaunchHelp("/tasktray.htm#realmmismatch");
          break;
        case TaskTrayPopupClickOptions.LaunchDisconnectedNWRejectionHelp:
          AppFramework.Dashboard.LaunchHelp("/tasktray.htm#rejection");
          break;
        case TaskTrayPopupClickOptions.LaunchDisconnectedNWRejectionReauthenticationHelp:
          AppFramework.Dashboard.LaunchHelp("/tasktray.htm#reauthenticate");
          break;
        case TaskTrayPopupClickOptions.LaunchIPAddressHelp:
          AppFramework.Dashboard.LaunchHelp("/tasktray.htm#ipaddress");
          break;
      }
    }

    private void OnMouseEnter(object sender, EventArgs e)
    {
      this.Cursor = Cursors.Hand;
    }

    private void OnMouseLeave(object sender, EventArgs e)
    {
      this.Cursor = Cursors.Default;
    }

    private void CustomInitializeComponents()
    {
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.Click += new EventHandler(this.OnClientAreaClick);
      this.MouseEnter += new EventHandler(this.OnMouseEnter);
      this.MouseLeave += new EventHandler(this.OnMouseLeave);
      this.MessageTextPanel.Click += new EventHandler(this.OnClientAreaClick);
      this.MessageTextPanel.MouseEnter += new EventHandler(this.OnMouseEnter);
      this.MessageTextPanel.MouseLeave += new EventHandler(this.OnMouseLeave);
      this.MessageTextPanel.Text = this._message;
      SizeHelper.ResizeCustomControls(this.Controls);
      this.Height = this.MessageTextPanel.Height + 30;
    }
  }
}
