// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.INetworkPropertiesGroupBox
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public interface INetworkPropertiesGroupBox
  {
    void Initialize();

    bool PrerequistesMet();

    void SetUpdateSaveBtnDelgate(UpdateSaveBtnDelegate func);

    bool ChangesWereMade();

    bool SaveChanges();

    bool AddToLayoutPanel();
  }
}
