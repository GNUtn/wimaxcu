// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.WindowDragHelper
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.Common;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class WindowDragHelper
  {
    public WindowDragHelper()
    {
      this.RegisterForEvents();
    }

    public void CleanUp()
    {
      this.UnregisterForEvents();
    }

    public void OnWindowDragEnd(object sender, object[] eventArgs)
    {
      AppFramework.Dashboard.SetDashboardMode();
    }

    private void RegisterForEvents()
    {
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnWindowDragEnd), (object) this, "WiMAXUI.OnWindowDragEnd");
    }

    private void UnregisterForEvents()
    {
      Eventing.DeRegisterAllUIEvents((object) this);
    }
  }
}
