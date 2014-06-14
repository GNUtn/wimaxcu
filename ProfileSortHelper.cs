// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.ProfileSortHelper
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.UI.DisplayWiMAX;
using System.Collections;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  internal static class ProfileSortHelper
  {
    internal static int SortBasedOnType(ProfileDisplayItem xPDI, ProfileDisplayItem yPDI, ProfileSortEnum typeOfSort)
    {
      if (xPDI == null || yPDI == null)
        return Comparer.Default.Compare((object) xPDI, (object) yPDI);
      switch (typeOfSort)
      {
        case ProfileSortEnum.PreferredAscending:
          if (yPDI.Preferred != xPDI.Preferred)
            return Comparer.Default.Compare((object) (bool) (yPDI.Preferred ? 1 : 0), (object) (bool) (xPDI.Preferred ? 1 : 0));
          if (WiMAXDisplayService.IsHomeNetwork(yPDI.TheProfile.profileId) != WiMAXDisplayService.IsHomeNetwork(xPDI.TheProfile.profileId))
            return Comparer.Default.Compare((object) (bool) (WiMAXDisplayService.IsHomeNetwork(yPDI.TheProfile.profileId) ? 1 : 0), (object) (bool) (WiMAXDisplayService.IsHomeNetwork(xPDI.TheProfile.profileId) ? 1 : 0));
          else
            return xPDI.TheProfile.profileName.CompareTo(yPDI.TheProfile.profileName);
        case ProfileSortEnum.PreferredDescending:
          if (xPDI.Preferred != yPDI.Preferred)
            return Comparer.Default.Compare((object) (bool) (xPDI.Preferred ? 1 : 0), (object) (bool) (yPDI.Preferred ? 1 : 0));
          if (WiMAXDisplayService.IsHomeNetwork(xPDI.TheProfile.profileId) != WiMAXDisplayService.IsHomeNetwork(yPDI.TheProfile.profileId))
            return Comparer.Default.Compare((object) (bool) (WiMAXDisplayService.IsHomeNetwork(xPDI.TheProfile.profileId) ? 1 : 0), (object) (bool) (WiMAXDisplayService.IsHomeNetwork(yPDI.TheProfile.profileId) ? 1 : 0));
          else
            return xPDI.TheProfile.profileName.CompareTo(yPDI.TheProfile.profileName);
        case ProfileSortEnum.NameAscending:
          return xPDI.TheProfile.profileName.CompareTo(yPDI.TheProfile.profileName);
        case ProfileSortEnum.NameDescending:
          return yPDI.TheProfile.profileName.CompareTo(xPDI.TheProfile.profileName);
        default:
          return ProfileSortHelper.SortBasedOnType(xPDI, yPDI, ProfileSortEnum.PreferredAscending);
      }
    }
  }
}
