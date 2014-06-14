// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.ConnectionBrandingPanel
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class ConnectionBrandingPanel : UserControl
  {
    private ToolTip _leftBrandingImageTooltip = new ToolTip();
    private ToolTip _centerBrandingImageTooltip = new ToolTip();
    private ToolTip _rightBrandingImageTooltip = new ToolTip();
    private string _httpPrefix = BrandingStringHelper.GetString("HTTPPrefix");
    private Container components;
    private Bitmap _leftBrandingImageBitmap;
    private string _leftBrandingImageURL;
    private Bitmap _centerBrandingImageBitmap;
    private string _centerBrandingImageURL;
    private Bitmap _rightBrandingImageBitmap;
    private string _rightBrandingImageURL;

    public ConnectionBrandingPanel()
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ConnectionBrandingPanel));
      this.SuspendLayout();
      this.BackColor = Color.White;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "ConnectionBrandingPanel";
      this.ResumeLayout(false);
    }

    public void InitPanel()
    {
      this.SetLeftBrandingImage();
      this.SetCenterBrandingImage();
      this.SetRightBrandingImage();
    }

    private void OnBrandingImageMouseEnter(object sender, EventArgs e)
    {
      this.Cursor = Cursors.Hand;
    }

    private void OnBrandingImageMouseLeave(object sender, EventArgs e)
    {
      this.Cursor = Cursors.Default;
    }

    private void OnLeftBrandingImageMouseDown(object sender, MouseEventArgs e)
    {
      UIHelper.LaunchDefaultBrowser(this._leftBrandingImageURL.Trim());
    }

    private void OnCenterBrandingImageMouseDown(object sender, MouseEventArgs e)
    {
      UIHelper.LaunchDefaultBrowser(this._centerBrandingImageURL.Trim());
    }

    private void OnRightBrandingImageMouseDown(object sender, MouseEventArgs e)
    {
      UIHelper.LaunchDefaultBrowser(this._rightBrandingImageURL.Trim());
    }

    private void CustomInitializeComponents()
    {
      this._leftBrandingImageTooltip.ShowAlways = true;
      this._centerBrandingImageTooltip.ShowAlways = true;
      this._rightBrandingImageTooltip.ShowAlways = true;
    }

    private void SetLeftBrandingImage()
    {
      this.GetLeftBrandingInfo();
      if (this._leftBrandingImageBitmap == null)
        return;
      TransparentPictureBox transparentPictureBox = new TransparentPictureBox();
      transparentPictureBox.TheBitmap = this._leftBrandingImageBitmap;
      transparentPictureBox.Size = new Size(transparentPictureBox.TheBitmap.Width, transparentPictureBox.TheBitmap.Height);
      transparentPictureBox.Location = new Point(0, (this.Size.Height - transparentPictureBox.TheBitmap.Height) / 2);
      transparentPictureBox.Name = "LeftBrandingImageBitmap";
      transparentPictureBox.AccessibleName = "LeftBrandingImageBitmap";
      transparentPictureBox.TabStop = false;
      this.Controls.Add((Control) transparentPictureBox);
      if (this._leftBrandingImageURL == null)
        return;
      transparentPictureBox.MouseEnter += new EventHandler(this.OnBrandingImageMouseEnter);
      transparentPictureBox.MouseLeave += new EventHandler(this.OnBrandingImageMouseLeave);
      transparentPictureBox.MouseDown += new MouseEventHandler(this.OnLeftBrandingImageMouseDown);
      this._leftBrandingImageTooltip.SetToolTip((Control) transparentPictureBox, this._leftBrandingImageURL.Trim());
    }

    private void GetLeftBrandingInfo()
    {
      this._leftBrandingImageBitmap = (Bitmap) null;
      this._leftBrandingImageURL = (string) null;
      OEM oemInfo = OEMHelper.GetOEMInfo();
      if (oemInfo == null)
        return;
      string filename = oemInfo.Branding.LeftImage.filename;
      string url = oemInfo.Branding.LeftImage.url;
      if (filename == null || filename.Length <= 0 || !File.Exists(filename))
        return;
      this._leftBrandingImageBitmap = ScalingUtils.ScaleBitmap(new Bitmap(filename));
      if (url == null || url.Length <= 0 || !url.Trim().ToLower(Application.CurrentCulture).StartsWith(this._httpPrefix))
        return;
      this._leftBrandingImageURL = url;
    }

    private void SetCenterBrandingImage()
    {
      this.GetCenterBrandingInfo();
      if (this._centerBrandingImageBitmap == null)
        return;
      TransparentPictureBox transparentPictureBox = new TransparentPictureBox();
      transparentPictureBox.TheBitmap = this._centerBrandingImageBitmap;
      transparentPictureBox.Size = new Size(transparentPictureBox.TheBitmap.Width, transparentPictureBox.TheBitmap.Height);
      transparentPictureBox.Location = new Point((this.Size.Width - transparentPictureBox.TheBitmap.Width) / 2, (this.Size.Height - transparentPictureBox.TheBitmap.Height) / 2);
      transparentPictureBox.Name = "CenterBrandingImageBitmap";
      transparentPictureBox.AccessibleName = "CenterBrandingImageBitmap";
      transparentPictureBox.TabStop = false;
      this.Controls.Add((Control) transparentPictureBox);
      if (this._centerBrandingImageURL == null)
        return;
      transparentPictureBox.MouseEnter += new EventHandler(this.OnBrandingImageMouseEnter);
      transparentPictureBox.MouseLeave += new EventHandler(this.OnBrandingImageMouseLeave);
      transparentPictureBox.MouseDown += new MouseEventHandler(this.OnCenterBrandingImageMouseDown);
      this._centerBrandingImageTooltip.SetToolTip((Control) transparentPictureBox, this._centerBrandingImageURL.Trim());
    }

    private void GetCenterBrandingInfo()
    {
      this._centerBrandingImageBitmap = (Bitmap) null;
      this._centerBrandingImageURL = (string) null;
      OEM oemInfo = OEMHelper.GetOEMInfo();
      if (oemInfo == null)
        return;
      string filename = oemInfo.Branding.CenterImage.filename;
      string url = oemInfo.Branding.CenterImage.url;
      if (filename == null || filename.Length <= 0 || !File.Exists(filename))
        return;
      this._centerBrandingImageBitmap = ScalingUtils.ScaleBitmap(new Bitmap(filename));
      if (url == null || url.Length <= 0 || !url.Trim().ToLower(Application.CurrentCulture).StartsWith(this._httpPrefix))
        return;
      this._centerBrandingImageURL = url;
    }

    private void SetRightBrandingImage()
    {
      this.GetRightBrandingInfo();
      if (this._rightBrandingImageBitmap == null)
        return;
      TransparentPictureBox transparentPictureBox = new TransparentPictureBox();
      transparentPictureBox.TheBitmap = new Bitmap((Image) this._rightBrandingImageBitmap);
      transparentPictureBox.Size = new Size(transparentPictureBox.TheBitmap.Width, DPIUtils.UnscaleY(transparentPictureBox.TheBitmap.Height));
      transparentPictureBox.Location = new Point(this.Size.Width - transparentPictureBox.TheBitmap.Width, (this.Size.Height - DPIUtils.UnscaleY(transparentPictureBox.TheBitmap.Height)) / 2);
      transparentPictureBox.Name = "RightBrandingImageBitmap";
      transparentPictureBox.AccessibleName = "RightBrandingImageBitmap";
      transparentPictureBox.TabStop = false;
      this.Controls.Add((Control) transparentPictureBox);
      if (this._rightBrandingImageURL == null)
        return;
      transparentPictureBox.MouseEnter += new EventHandler(this.OnBrandingImageMouseEnter);
      transparentPictureBox.MouseLeave += new EventHandler(this.OnBrandingImageMouseLeave);
      transparentPictureBox.MouseDown += new MouseEventHandler(this.OnRightBrandingImageMouseDown);
      this._rightBrandingImageTooltip.SetToolTip((Control) transparentPictureBox, this._rightBrandingImageURL.Trim());
    }

    private void GetRightBrandingInfo()
    {
      this._rightBrandingImageBitmap = ImageHelper.IntelLogo;
      this._rightBrandingImageURL = (string) null;
      string @string = BrandingStringHelper.GetString("Branding_ImageIntelURL");
      if (@string == null || @string.Length <= 0 || !@string.Trim().ToLower(Application.CurrentCulture).StartsWith(this._httpPrefix))
        return;
      this._rightBrandingImageURL = @string;
    }
  }
}
