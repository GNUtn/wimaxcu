// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.StatusBarAnimatedImage
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.Common;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  internal class StatusBarAnimatedImage : AnimatedScanOrConnectImage
  {
    private PictureBox _image;

    public StatusBarAnimatedImage(PictureBox image)
    {
      this._image = image;
    }

    public override void AssignImage(Icon ico)
    {
      if (this._image == null)
        return;
      this._image.Image = (Image) ScalingUtils.ScaleBitmap(ico.ToBitmap());
    }

    public override void AssignImage(Bitmap newImage)
    {
    }
  }
}
