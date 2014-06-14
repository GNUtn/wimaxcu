// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.ContactInfo
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  [XmlType(TypeName = "ContactInfo")]
  [Serializable]
  public class ContactInfo
  {
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [XmlElement(DataType = "string", ElementName = "Header", IsNullable = false)]
    public string __Header;
    [XmlElement(DataType = "string", ElementName = "URL", IsNullable = false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public string __URL;

    [XmlIgnore]
    public string Header
    {
      get
      {
        return this.__Header;
      }
      set
      {
        this.__Header = value;
      }
    }

    [XmlIgnore]
    public string URL
    {
      get
      {
        return this.__URL;
      }
      set
      {
        this.__URL = value;
      }
    }
  }
}
