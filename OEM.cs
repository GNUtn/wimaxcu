// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.OEM
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  [XmlRoot(ElementName = "OEM", IsNullable = false)]
  [Serializable]
  public class OEM
  {
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [XmlElement(ElementName = "ContactInfo", IsNullable = false, Type = typeof (ContactInfo))]
    public ContactInfo __ContactInfo;
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [XmlElement(ElementName = "Branding", IsNullable = false, Type = typeof (Branding))]
    public Branding __Branding;

    [XmlIgnore]
    public ContactInfo ContactInfo
    {
      get
      {
        if (this.__ContactInfo == null)
          this.__ContactInfo = new ContactInfo();
        return this.__ContactInfo;
      }
      set
      {
        this.__ContactInfo = value;
      }
    }

    [XmlIgnore]
    public Branding Branding
    {
      get
      {
        if (this.__Branding == null)
          this.__Branding = new Branding();
        return this.__Branding;
      }
      set
      {
        this.__Branding = value;
      }
    }
  }
}
