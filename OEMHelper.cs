// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.OEMHelper
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.SDKInterop;
using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  internal class OEMHelper
  {
    private static OEM _oemInfo;
    private static bool _triedToReadOemInfo;

    public static OEM GetOEMInfo()
    {
      if (!OEMHelper._triedToReadOemInfo)
      {
        OEMHelper.DoRead(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Intel\\WiMAXCU\\OEM.xml");
        OEMHelper._triedToReadOemInfo = true;
      }
      return OEMHelper._oemInfo;
    }

    private static void DoRead(string filename)
    {
      OEMHelper._oemInfo = (OEM) null;
      if (!File.Exists(filename))
        return;
      try
      {
        FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
        OEMHelper._oemInfo = (OEM) new XmlSerializer(typeof (OEM)).Deserialize((Stream) fileStream);
        fileStream.Close();
      }
      catch (Exception ex)
      {
        OEMHelper._oemInfo = (OEM) null;
        Logging.LogEvent(TraceModule.SDK, TraceLevel.Warning, typeof (OEMHelper), Logging.GetMessageForException(ex));
      }
    }
  }
}
