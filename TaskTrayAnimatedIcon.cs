// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.TaskTrayAnimatedIcon
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  internal class TaskTrayAnimatedIcon : AnimatedScanOrConnectImage
  {
    private NotifyIcon _icon;

    public TaskTrayAnimatedIcon(NotifyIcon icon)
    {
      this._icon = icon;
    }

    public override void AssignImage(Icon ico)
    {
      if (this._icon == null || !ApplicationState.Singleton.BlockedForScan && !ApplicationState.Singleton.BlockedForConnect)
        return;
      this._icon.Icon = ico;
    }

    public override void AssignImage(Bitmap newImage)
    {
    }
  }
}
