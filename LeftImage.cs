// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.LeftImage
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  [XmlType(TypeName = "LeftImage")]
  [Serializable]
  public class LeftImage
  {
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [XmlElement(DataType = "string", ElementName = "Filename", IsNullable = false)]
    public string __filename;
    [XmlElement(DataType = "string", ElementName = "URL", IsNullable = false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public string __url;

    [XmlIgnore]
    public string filename
    {
      get
      {
        return this.__filename;
      }
      set
      {
        this.__filename = value;
      }
    }

    [XmlIgnore]
    public string url
    {
      get
      {
        return this.__url;
      }
      set
      {
        this.__url = value;
      }
    }
  }
}
