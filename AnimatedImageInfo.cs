// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.AnimatedImageInfo
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using System.Collections.Generic;
using System.Drawing;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  internal class AnimatedImageInfo
  {
    private List<Icon> _iconList;
    private List<Bitmap> _bitmapList;
    private int _currentIconIndex;
    private int _currentBitmapIndex;

    public List<Icon> Icons
    {
      get
      {
        return this._iconList;
      }
      set
      {
        this._iconList = value;
      }
    }

    public List<Bitmap> Bitmaps
    {
      get
      {
        return this._bitmapList;
      }
      set
      {
        this._bitmapList = value;
      }
    }

    public int CurrentIconIndex
    {
      get
      {
        return this._currentIconIndex;
      }
      set
      {
        this._currentIconIndex = value;
      }
    }

    public int CurrentBitmapIndex
    {
      get
      {
        return this._currentBitmapIndex;
      }
      set
      {
        this._currentBitmapIndex = value;
      }
    }
  }
}
