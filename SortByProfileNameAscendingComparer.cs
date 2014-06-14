// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.SortByProfileNameAscendingComparer
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.Common;
using System.Collections.Generic;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  internal class SortByProfileNameAscendingComparer : IComparer<ProfileDisplayItem>
  {
    int IComparer<ProfileDisplayItem>.Compare(ProfileDisplayItem xPDI, ProfileDisplayItem yPDI)
    {
      return ProfileSortHelper.SortBasedOnType(xPDI, yPDI, ProfileSortEnum.NameAscending);
    }
  }
}
