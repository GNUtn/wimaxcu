// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.NetworkListMessage
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class NetworkListMessage : UserControl
  {
    private IContainer components;
    private LinkLabel MessageLinkLbl;

    public NetworkListMessage()
    {
      this.InitializeComponent();
      this.CustomInitializeComponents();
    }

    public void SetMessageText(string message, string textToMakeClickable, LinkLabelLinkClickedEventHandler handler)
    {
      this.TabStop = false;
      if (this.MessageLinkLbl.Links.Count > 0)
        this.MessageLinkLbl.Links.Clear();
      this.MessageLinkLbl.Text = message;
      if (string.IsNullOrEmpty(textToMakeClickable))
        return;
      this.MessageLinkLbl.LinkClicked -= handler;
      this.MessageLinkLbl.LinkClicked += handler;
      this.MessageLinkLbl.Links.Add(this.MessageLinkLbl.Text.IndexOf(textToMakeClickable), textToMakeClickable.Length);
      this.TabStop = true;
    }

    private void CustomInitializeComponents()
    {
      this.AccessibleName = "NetworkListMessage";
      this.MessageLinkLbl.AccessibleName = "NetworkListPanel_NetworkListMessage_MessageLinkLbl";
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (NetworkListMessage));
      this.MessageLinkLbl = new LinkLabel();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.MessageLinkLbl, "MessageLinkLbl");
      this.MessageLinkLbl.Name = "MessageLinkLbl";
      this.MessageLinkLbl.TabStop = true;
      this.BackColor = Color.WhiteSmoke;
      this.Controls.Add((Control) this.MessageLinkLbl);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "NetworkListMessage";
      this.ResumeLayout(false);
    }
  }
}
