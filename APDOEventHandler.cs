// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.APDOEventHandler
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.BizTier;
using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.SDKInterop;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class APDOEventHandler : UserControl
  {
    private CustomMessageBox _packageInstallCMB = new CustomMessageBox((string) null);
    private ClickableCustomMessageBox _fumoPromptCMB = new ClickableCustomMessageBox((string) null, (string) null, (LinkLabelLinkClickedEventHandler) null);
    private bool _callSetPackageUpdateState = true;
    private IContainer components;
    private static int _errorMessageCount;
    private System.Windows.Forms.Timer _packageInstallCMBTimer;
    private int _numOfSecondsBeforeInstallationBegins;

    public APDOEventHandler()
    {
      this.InitializeComponent();
      this.RegisterForEvents();
    }

    protected override void Dispose(bool disposing)
    {
      Eventing.DeRegisterAllUIEvents((object) this);
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.Name = "APDOEventHandler";
      this.ResumeLayout(false);
    }

    public void OnAPDO(object sender, object[] eventArgs)
    {
      if (eventArgs == null || eventArgs.Length == 0)
        return;
      switch ((APDOEventType) eventArgs[0])
      {
        case APDOEventType.ProvisioningOperationCompleted:
          APDOHandler.ProvisioningInProgress = false;
          break;
        case APDOEventType.ProvisioningOperationFailed:
          APDOHandler.ProvisioningInProgress = false;
          break;
        case APDOEventType.ProvisioningOperationFailedBadAuthentication:
          APDOHandler.ProvisioningInProgress = false;
          break;
        case APDOEventType.ProvisioningOperationFailedInvalidProvisioning:
          APDOHandler.ProvisioningInProgress = false;
          break;
        case APDOEventType.ProvisioningOperationFailedNetworkDisconnect:
          APDOHandler.ProvisioningInProgress = false;
          break;
        case APDOEventType.ProvisioningOperationStarted:
          APDOHandler.ProvisioningInProgress = true;
          break;
        case APDOEventType.ProvisioningOperationTriggerContact:
          if (eventArgs.Length < 1)
            break;
          this.LaunchBrowserToSubscriptionPortal((ushort) eventArgs[1]);
          break;
        case APDOEventType.PackageUpdateCompleted:
          this.FUMODownloadNotInProgress();
          break;
        case APDOEventType.PackageUpdateFailed:
          this.FUMODownloadNotInProgress();
          this.ShowErrorMessage(ErrorStringsHelper.GetString("General_PackageUpdateFailed"), ErrorHelper.TranslateErrorCodeToMessage(53249));
          break;
        case APDOEventType.PackageUpdateFailedBadAuthentication:
          this.FUMODownloadNotInProgress();
          this.ShowErrorMessage(ErrorStringsHelper.GetString("General_PackageUpdateFailed"), ErrorHelper.TranslateErrorCodeToMessage(53251));
          break;
        case APDOEventType.PackageUpdateFailedInvalidPackage:
          this.FUMODownloadNotInProgress();
          this.ShowErrorMessage(ErrorStringsHelper.GetString("General_PackageUpdateFailed"), ErrorHelper.TranslateErrorCodeToMessage(53253));
          break;
        case APDOEventType.PackageUpdateFailedNetworkDisconnected:
          this.FUMODownloadNotInProgress();
          if (this._fumoPromptCMB != null && this._fumoPromptCMB.Visible)
          {
            this._callSetPackageUpdateState = false;
            this._fumoPromptCMB.Close();
          }
          this.ShowErrorMessage(ErrorStringsHelper.GetString("General_PackageUpdateFailed"), ErrorHelper.TranslateErrorCodeToMessage(53250));
          break;
        case APDOEventType.PackageUpdateReceived:
        case APDOEventType.PackageUpdateReceivedFullStack:
        case APDOEventType.PackageUpdateReceivedLowerStack:
        case APDOEventType.PackageUpdateReceivedOmaDmClient:
          if (APDOHandler.FUMODownloadState != FumoDownloadStateEnum.Idle)
            break;
          this.FUMODownloadNotInProgress();
          int num = (int) this.PromptUser(APDOEventHandler.PromptType.PackageDownload);
          break;
        case APDOEventType.PackageUpdateStarted:
          this.FUMODownloadNotInProgress();
          this.PreInstallPackage();
          break;
        case APDOEventType.PackageDownloadProgress:
          if ((int) eventArgs[1] < 100)
          {
            this.FUMODownloadInProgress();
            break;
          }
          else
          {
            this.FUMODownloadNotInProgress();
            break;
          }
        case APDOEventType.PackageDownloadStarted:
          this.FUMODownloadInProgress();
          break;
        case APDOEventType.PackageInstallStarted:
          this.FUMODownloadNotInProgress();
          break;
      }
    }

    public void OnSomethingChanged(object sender, object[] eventArgs)
    {
      if (MediaHandler.TheMedia.WiMAXIsReady && MediaHandler.IntelCUIsInControl && (AdapterHandler.TheAdapter.RadioIsOn() && NetworkHandler.ConnectedNetworks.Count != 0))
        return;
      if (this._fumoPromptCMB != null && this._fumoPromptCMB.Visible)
      {
        this._callSetPackageUpdateState = false;
        this._fumoPromptCMB.Close();
      }
      if (!FUMOProgressDialog.Singleton.Visible)
        return;
      FUMOProgressDialog.Singleton.Close();
    }

    private void OnPackageDownloadHelpLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      OnlineHelp.LaunchHelp("/tasktray.htm#updates");
    }

    private void RegisterForEvents()
    {
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnAPDO), (object) this, "WiMAXSP.OnAPDO");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnSomethingChanged), (object) this, "WiMAXUI.OnStateChange");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnSomethingChanged), (object) this, "WiMAXSP.OnDisconnected");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnSomethingChanged), (object) this, "WiMAXUI.OnAdapterListChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnSomethingChanged), (object) this, "WiMAXUI.OnMediaStatusChanged");
      Eventing.RegisterForUIEvent(new Eventing.EventDelegate(this.OnSomethingChanged), (object) this, "WiMAXUI.OnIntelCUControlChanged");
    }

    private void FUMODownloadNotInProgress()
    {
      FumoDownloadStateEnum fumoDownloadState = APDOHandler.FUMODownloadState;
      APDOHandler.FUMODownloadState = FumoDownloadStateEnum.Idle;
      if (FUMOProgressDialog.Singleton.Visible)
        FUMOProgressDialog.Singleton.Close();
      if (fumoDownloadState == APDOHandler.FUMODownloadState)
        return;
      AppFramework.Dashboard.TheConnectionPanel.UpdateUI();
    }

    private void FUMODownloadInProgress()
    {
      FumoDownloadStateEnum fumoDownloadState = APDOHandler.FUMODownloadState;
      APDOHandler.FUMODownloadState = FumoDownloadStateEnum.Downloading;
      if (fumoDownloadState == APDOHandler.FUMODownloadState)
        return;
      AppFramework.Dashboard.TheConnectionPanel.UpdateUI();
    }

    private DialogResult ShowPromptDialog(string promptText, string clickableText, LinkLabelLinkClickedEventHandler linkClickedEventHandler, CustomMessageBoxStyle promptStyle)
    {
      if (this._fumoPromptCMB != null && this._fumoPromptCMB.Visible)
        return DialogResult.Ignore;
      this._fumoPromptCMB = new ClickableCustomMessageBox(promptText, clickableText, linkClickedEventHandler, promptStyle);
      this._fumoPromptCMB.AccessibleName = "FUMODownloadMB";
      this._fumoPromptCMB.LocationOfMessageBox = CustomMessageBoxLocation.AlwaysInTaskTrayBottom;
      return this._fumoPromptCMB.CustomShowDialog((IWin32Window) AppFramework.Dashboard, true);
    }

    private void ShowErrorMessage(string operationThatFailed, string reason)
    {
      ++APDOEventHandler._errorMessageCount;
      if (APDOEventHandler._errorMessageCount > 1)
      {
        --APDOEventHandler._errorMessageCount;
      }
      else
      {
        ErrorHelper.ShowErrorDialogOnlyIfPrimaryCUAndSDKReady((Control) AppFramework.Dashboard, operationThatFailed, reason, (string) null, "PackageUpdateFailed");
        --APDOEventHandler._errorMessageCount;
      }
    }

    private void LaunchBrowserToSubscriptionPortal(ushort contactType)
    {
      new SecurityPermission(SecurityPermissionFlag.AllFlags).Demand();
      string subscriptionPortalUrl = APDOHandler.Singleton.GetSubscriptionPortalURL(contactType);
      if (!string.IsNullOrEmpty(subscriptionPortalUrl))
        UIHelper.LaunchDefaultBrowser(subscriptionPortalUrl);
      else
        UIHelper.LaunchDefaultBrowser(DashboardStringHelper.GetString("DefaultURL"));
    }

    private DialogResult PromptUser(APDOEventHandler.PromptType promptType)
    {
      string promptText = string.Empty;
      string clickableText = string.Empty;
      LinkLabelLinkClickedEventHandler linkClickedEventHandler = (LinkLabelLinkClickedEventHandler) null;
      if (promptType == APDOEventHandler.PromptType.PackageDownload)
      {
        clickableText = DashboardStringHelper.GetString("CapitalClickHere_Clickable");
        promptText = string.Format(DashboardStringHelper.GetString("APDO_PromptUserPackageDownload"), (object) clickableText);
        linkClickedEventHandler = new LinkLabelLinkClickedEventHandler(this.OnPackageDownloadHelpLinkClicked);
      }
      else if (promptType == APDOEventHandler.PromptType.PackageInstall)
        promptText = DashboardStringHelper.GetString("APDO_PromptUserPackageInstall");
      this._callSetPackageUpdateState = true;
      DialogResult dialogResult = this.ShowPromptDialog(promptText, clickableText, linkClickedEventHandler, CustomMessageBoxStyle.YesRemindMeLater);
      int num;
      switch (dialogResult)
      {
        case DialogResult.Ignore:
          return dialogResult;
        case DialogResult.Yes:
          num = 1;
          break;
        default:
          num = 0;
          break;
      }
      bool userApprovedAction = num != 0;
      if (this._callSetPackageUpdateState && (promptType == APDOEventHandler.PromptType.PackageDownload || promptType == APDOEventHandler.PromptType.PackageInstall))
      {
        int errorCode = APDOHandler.Singleton.SetPackageUpdateState(userApprovedAction);
        if (errorCode != 0)
        {
          ErrorHelper.ShowErrorDialog((Control) AppFramework.Dashboard, ErrorStringsHelper.GetString("General_SetPackageUpdateStateFailed"), ErrorHelper.TranslateErrorCodeToMessage(errorCode), (string) null, "SetPackageUpdateStateFailed");
          dialogResult = DialogResult.Abort;
        }
        else if (userApprovedAction && promptType == APDOEventHandler.PromptType.PackageDownload)
          Eventing.GenerateUIEvent("WiMAXSP.OnAPDO", (object) this, new object[1]
          {
            (object) APDOEventType.PackageDownloadStarted
          });
      }
      return dialogResult;
    }

    private void PreInstallPackage()
    {
      WIMAX_API_PACKAGE_INFO packageInfo = new WIMAX_API_PACKAGE_INFO();
      if (CurrentUserSettings.ShowApdoFumoSimulator())
      {
        packageInfo.mandatoryUpdate = true;
        packageInfo.warnUser = true;
        packageInfo.filePath = Environment.SystemDirectory;
        packageInfo.fileName = "mspaint.exe";
        packageInfo.forceReboot = false;
      }
      else
      {
        int packageInformation = APDOHandler.Singleton.GetPackageInformation(ref packageInfo);
        if (packageInformation != 0)
        {
          ErrorHelper.ShowErrorDialog((Control) AppFramework.Dashboard, ErrorStringsHelper.GetString("General_GetPackageInformationFailed"), ErrorHelper.TranslateErrorCodeToMessage(packageInformation), (string) null, "GetPackageInformationFailed");
          return;
        }
      }
      if (!packageInfo.mandatoryUpdate)
      {
        if (this.PromptUser(APDOEventHandler.PromptType.PackageInstall) != DialogResult.Yes)
          return;
      }
      else if (packageInfo.warnUser && !this._packageInstallCMB.Visible)
      {
        this._numOfSecondsBeforeInstallationBegins = 20;
        if (this._packageInstallCMBTimer == null)
        {
          this._packageInstallCMBTimer = new System.Windows.Forms.Timer();
          this._packageInstallCMBTimer.Tick += new EventHandler(this.OnPackageInstallPopupTimer);
          this._packageInstallCMBTimer.Interval = TimerSettings.APDOEventHandler_PackageInstallCMBTimer_Interval;
        }
        this._packageInstallCMBTimer.Start();
        this._packageInstallCMB = new CustomMessageBox(this.GetPackageInstallCMBText(), CustomMessageBoxStyle.Ok);
        this._packageInstallCMB.AccessibleName = "FUMOInstallMB";
        this._packageInstallCMB.LocationOfMessageBox = CustomMessageBoxLocation.AlwaysInTaskTrayBottom;
        int num = (int) this._packageInstallCMB.CustomShowDialog((IWin32Window) AppFramework.Dashboard, true);
        if (this._packageInstallCMBTimer != null)
          this._packageInstallCMBTimer.Stop();
      }
      this.InstallPackage(packageInfo);
    }

    private void OnPackageInstallPopupTimer(object sender, EventArgs e)
    {
      --this._numOfSecondsBeforeInstallationBegins;
      if (this._numOfSecondsBeforeInstallationBegins > 0)
      {
        this._packageInstallCMB.Message = this.GetPackageInstallCMBText();
      }
      else
      {
        this._packageInstallCMBTimer.Stop();
        this._packageInstallCMB.Close();
      }
    }

    private string GetPackageInstallCMBText()
    {
      return string.Format(DashboardStringHelper.GetString("APDO_NotifyUserPackageInstall"), (object) this._numOfSecondsBeforeInstallationBegins);
    }

    private void InstallPackage(WIMAX_API_PACKAGE_INFO packageInfo)
    {
      new SecurityPermission(SecurityPermissionFlag.AllFlags).Demand();
      string path = string.Empty;
      if (!string.IsNullOrEmpty(packageInfo.filePath))
        path = path + packageInfo.filePath + "\\";
      if (!string.IsNullOrEmpty(packageInfo.fileName))
        path = path + packageInfo.fileName;
      if (!string.IsNullOrEmpty(path) && File.Exists(path))
      {
        Eventing.GenerateUIEvent("WiMAXSP.OnAPDO", (object) this, new object[1]
        {
          (object) APDOEventType.PackageInstallStarted
        });
        ThreadPool.QueueUserWorkItem(new WaitCallback(APDOEventHandler.DoAsyncInstallPackage), (object) path);
      }
      else
        ErrorHelper.ShowErrorDialog((Control) AppFramework.Dashboard, ErrorStringsHelper.GetString("General_PackageInstallationFailed"), string.Format(ErrorStringsHelper.GetString("APDO_PACKAGE_INSTALLATION_FILE_DOES_NOT_EXIST"), (object) path), (string) null, "PackageInstallationFailedFileDoesNotExist");
    }

    private static void DoAsyncInstallPackage(object obj)
    {
      string fileName = Convert.ToString(obj);
      try
      {
        Process.Start(new ProcessStartInfo(fileName)
        {
          WindowStyle = ProcessWindowStyle.Minimized
        });
      }
      catch (Win32Exception ex)
      {
        ErrorHelper.ShowErrorDialog((Control) AppFramework.Dashboard, ErrorStringsHelper.GetString("General_PackageInstallationFailed_NoCredentialsGiven"), "", (string) null, "PackageInstallationFailedNoCredentialsGiven");
      }
    }

    private enum PromptType
    {
      PackageDownload,
      PackageInstall,
    }
  }
}
