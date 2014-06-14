// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.OnlineHelp
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class OnlineHelp
  {
    private const string HELP_FILENAME = "wimaxhlp.chm";
    public static Form _fakeForm;

    private static string GetHelpFilename()
    {
      string path1 = Application.StartupPath + "\\" + Thread.CurrentThread.CurrentUICulture.Name + "\\wimaxhlp.chm";
      if (File.Exists(path1))
        return path1;
      if (Thread.CurrentThread.CurrentUICulture.Parent != null)
      {
        string path2 = Application.StartupPath + "\\" + Thread.CurrentThread.CurrentUICulture.Parent.Name + "\\wimaxhlp.chm";
        if (File.Exists(path2))
          return path2;
      }
      return Application.StartupPath + "\\wimaxhlp.chm";
    }

    public static void LaunchHelp(string helpTopic)
    {
      string helpFilename = OnlineHelp.GetHelpFilename();
      if (string.IsNullOrEmpty(helpFilename) || !File.Exists(helpFilename))
      {
        ErrorHelper.ShowErrorDialog((Control) AppFramework.Dashboard, string.Format(DashboardStringHelper.GetString("HelpFileNotFound"), (object) helpFilename), "", (string) null, "HelpFileNotFound");
      }
      else
      {
        if (OnlineHelp._fakeForm == null)
        {
          OnlineHelp._fakeForm = new Form();
          OnlineHelp._fakeForm.CreateControl();
        }
        Help.ShowHelp((Control) OnlineHelp._fakeForm, helpFilename, HelpNavigator.TableOfContents, (object) null);
        if (string.IsNullOrEmpty(helpTopic))
          return;
        Help.ShowHelp((Control) OnlineHelp._fakeForm, helpFilename, HelpNavigator.Topic, (object) helpTopic);
      }
    }
  }
}
