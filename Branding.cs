// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.Branding
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  [XmlType(TypeName = "Branding")]
  [Serializable]
  public class Branding
  {
    [XmlElement(ElementName = "LeftImage", IsNullable = false, Type = typeof (LeftImage))]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public LeftImage __LeftImage;
    [XmlElement(ElementName = "CenterImage", IsNullable = false, Type = typeof (CenterImage))]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public CenterImage __CenterImage;

    [XmlIgnore]
    public LeftImage LeftImage
    {
      get
      {
        if (this.__LeftImage == null)
          this.__LeftImage = new LeftImage();
        return this.__LeftImage;
      }
      set
      {
        this.__LeftImage = value;
      }
    }

    [XmlIgnore]
    public CenterImage CenterImage
    {
      get
      {
        if (this.__CenterImage == null)
          this.__CenterImage = new CenterImage();
        return this.__CenterImage;
      }
      set
      {
        this.__CenterImage = value;
      }
    }
  }
}
