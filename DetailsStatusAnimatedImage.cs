// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.DetailsStatusAnimatedImage
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  internal class DetailsStatusAnimatedImage : AnimatedScanOrConnectImage
  {
    private PictureBox _image;

    public DetailsStatusAnimatedImage(PictureBox image)
    {
      this._image = image;
    }

    public override void AssignImage(Icon ico)
    {
    }

    public override void AssignImage(Bitmap newImage)
    {
      if (this._image == null || !ApplicationState.Singleton.BlockedForScan && !ApplicationState.Singleton.BlockedForConnect)
        return;
      this._image.Image = (Image) newImage;
    }
  }
}
