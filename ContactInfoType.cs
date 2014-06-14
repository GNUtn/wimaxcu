// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.ContactInfoType
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  internal class ContactInfoType
  {
    private string _companyName;
    private string _supportURL;

    public string CompanyName
    {
      get
      {
        return this._companyName;
      }
      set
      {
        this._companyName = value;
      }
    }

    public string SupportURL
    {
      get
      {
        return this._supportURL;
      }
      set
      {
        this._supportURL = value;
      }
    }
  }
}
