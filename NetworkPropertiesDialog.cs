// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.NetworkPropertiesDialog
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.SDKInterop;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class NetworkPropertiesDialog : CustomForm, IScalable
  {
    private static NetworkPropertiesDialog _instance = new NetworkPropertiesDialog();
    private static NetworkPropertiesPanel _networkPropertiesPanel;
    private WIMAX_API_PROFILE_INFO _profile;
    private NetworkDisplayItem _network;
    private bool hasBeenScaled;
    private IContainer components;

    public static NetworkPropertiesDialog Singleton
    {
      get
      {
        return NetworkPropertiesDialog._instance;
      }
    }

    public NetworkDisplayItem Network
    {
      get
      {
        return this._network;
      }
      set
      {
        this._network = value;
      }
    }

    public WIMAX_API_PROFILE_INFO Profile
    {
      get
      {
        return this._profile;
      }
      set
      {
        this._profile = value;
      }
    }

    static NetworkPropertiesDialog()
    {
    }

    public NetworkPropertiesDialog()
    {
      this.InitializeComponent();
      this.CustomInitializeComponents();
      ScalingUtils.ScaleControlHierarchy((Control) this);
    }

    public void SetSizeToFitPanel()
    {
      if (!this.hasBeenScaled)
        this.Size = new Size(NetworkPropertiesDialog._networkPropertiesPanel.Width + ImageHelper.Unscaled.FrameLeftPixel.Width + ImageHelper.Unscaled.FrameRightPixel.Width, NetworkPropertiesDialog._networkPropertiesPanel.Height + ImageHelper.Unscaled.FrameTopPixel.Height + ImageHelper.Unscaled.FrameBottomPixel.Height);
      else
        this.Size = new Size(NetworkPropertiesDialog._networkPropertiesPanel.Width + ImageHelper.FrameLeftPixel.Width + ImageHelper.FrameRightPixel.Width, NetworkPropertiesDialog._networkPropertiesPanel.Height + ImageHelper.FrameTopPixel.Height + ImageHelper.FrameBottomPixel.Height);
    }

    protected override void OnVisibleChanged(EventArgs e)
    {
      if (this.Visible)
        NetworkPropertiesDialog._networkPropertiesPanel.InitPanel();
      else
        NetworkPropertiesDialog._networkPropertiesPanel.CleanUp();
      base.OnVisibleChanged(e);
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.F1)
      {
        NetworkPropertiesDialog._networkPropertiesPanel.LaunchHelp();
      }
      else
      {
        if (e.KeyCode != Keys.Escape)
          return;
        this.Close();
      }
    }

    private void CustomInitializeComponents()
    {
      this.AccessibleName = "NetworkPropertiesDialog";
      this.KeyDown += new KeyEventHandler(this.OnKeyDown);
      this.BackColor = CustomForm.FormBackColor;
      if (NetworkPropertiesDialog._networkPropertiesPanel == null)
      {
        NetworkPropertiesDialog._networkPropertiesPanel = new NetworkPropertiesPanel();
        NetworkPropertiesDialog._networkPropertiesPanel.Location = new Point(ImageHelper.Unscaled.FrameLeftPixel.Width, ImageHelper.Unscaled.FrameTopPixel.Height);
        this.Controls.Add((Control) NetworkPropertiesDialog._networkPropertiesPanel);
      }
      this.SetSizeToFitPanel();
    }

    public void DoPrescalingWork()
    {
    }

    public void DoPostScalingWork()
    {
      this.hasBeenScaled = true;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (NetworkPropertiesDialog));
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.None;
      this.FormType = FormTypeEnum.Dialog;
      this.KeyPreview = true;
      this.Name = "NetworkPropertiesDialog";
      this.ShowInTaskbar = false;
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
