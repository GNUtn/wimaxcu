// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.ClickableCustomMessageBox
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.UI.CustomControls;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  internal class ClickableCustomMessageBox : CustomMessageBox
  {
    private string _firstLinkText = string.Empty;
    private string _secondLinkText = string.Empty;
    private LinkLabelLinkClickedEventHandler _linkHandler;

    public string FirstLinkText
    {
      get
      {
        return this._firstLinkText;
      }
    }

    public string SecondLinkText
    {
      get
      {
        return this._secondLinkText;
      }
    }

    public LinkLabelLinkClickedEventHandler LinkHandler
    {
      get
      {
        return this._linkHandler;
      }
    }

    public ClickableCustomMessageBox(string message, string firstLinkText, LinkLabelLinkClickedEventHandler LinkHandler)
      : base(message, false)
    {
      this._firstLinkText = firstLinkText;
      if (string.IsNullOrEmpty(this._firstLinkText))
        this._firstLinkText = string.Empty;
      this._linkHandler = LinkHandler;
    }

    public ClickableCustomMessageBox(string message, string firstLinkText, LinkLabelLinkClickedEventHandler LinkHandler, CustomMessageBoxStyle style)
      : base(message, style, false)
    {
      this._firstLinkText = firstLinkText;
      if (string.IsNullOrEmpty(this._firstLinkText))
        this._firstLinkText = string.Empty;
      this._linkHandler = LinkHandler;
    }

    public ClickableCustomMessageBox(string message, string firstLinkText, LinkLabelLinkClickedEventHandler LinkHandler, CustomMessageBoxStyle style, DontShowThisMessageAgainOptions dontShowThisMessageAgainOption)
      : base(message, style, dontShowThisMessageAgainOption, false)
    {
      this._firstLinkText = firstLinkText;
      if (string.IsNullOrEmpty(this._firstLinkText))
        this._firstLinkText = string.Empty;
      this._linkHandler = LinkHandler;
    }

    public ClickableCustomMessageBox(string title, string message, string firstLinkText, LinkLabelLinkClickedEventHandler LinkHandler, CustomMessageBoxStyle style)
      : base(title, message, style, false)
    {
      this._firstLinkText = firstLinkText;
      if (string.IsNullOrEmpty(this._firstLinkText))
        this._firstLinkText = string.Empty;
      this._linkHandler = LinkHandler;
    }

    public ClickableCustomMessageBox(string message, string firstLinkText, string secondLinkText, LinkLabelLinkClickedEventHandler LinkHandler)
      : base(message, false)
    {
      this._firstLinkText = firstLinkText;
      if (string.IsNullOrEmpty(this._firstLinkText))
        this._firstLinkText = string.Empty;
      this._secondLinkText = secondLinkText;
      if (string.IsNullOrEmpty(this._secondLinkText))
        this._secondLinkText = string.Empty;
      this._linkHandler = LinkHandler;
    }

    public ClickableCustomMessageBox(string message, string firstLinkText, string secondLinkText, LinkLabelLinkClickedEventHandler LinkHandler, CustomMessageBoxStyle style, int toAvoidMethodSignatureClash)
      : base(message, style, false)
    {
      this._firstLinkText = firstLinkText;
      if (string.IsNullOrEmpty(this._firstLinkText))
        this._firstLinkText = string.Empty;
      this._secondLinkText = secondLinkText;
      if (string.IsNullOrEmpty(this._secondLinkText))
        this._secondLinkText = string.Empty;
      this._linkHandler = LinkHandler;
    }

    public ClickableCustomMessageBox(string message, string firstLinkText, string secondLinkText, LinkLabelLinkClickedEventHandler LinkHandler, CustomMessageBoxStyle style, DontShowThisMessageAgainOptions dontShowThisMessageAgainOption)
      : base(message, style, dontShowThisMessageAgainOption, false)
    {
      this._firstLinkText = firstLinkText;
      if (string.IsNullOrEmpty(this._firstLinkText))
        this._firstLinkText = string.Empty;
      this._secondLinkText = secondLinkText;
      if (string.IsNullOrEmpty(this._secondLinkText))
        this._secondLinkText = string.Empty;
      this._linkHandler = LinkHandler;
    }

    public ClickableCustomMessageBox(string title, string message, string firstLinkText, string secondLinkText, LinkLabelLinkClickedEventHandler LinkHandler, CustomMessageBoxStyle style)
      : base(title, message, style, false)
    {
      this._firstLinkText = firstLinkText;
      if (string.IsNullOrEmpty(this._firstLinkText))
        this._firstLinkText = string.Empty;
      this._secondLinkText = secondLinkText;
      if (string.IsNullOrEmpty(this._secondLinkText))
        this._secondLinkText = string.Empty;
      this._linkHandler = LinkHandler;
    }

    protected override void CustomInitializeComponents()
    {
      this.BackColor = CustomForm.FormBackColor;
      if (this._customMessageBoxPanel != null)
        this.Controls.Remove((Control) this._customMessageBoxPanel);
      this._customMessageBoxPanel = (CustomMessageBoxPanel) new ClickableCustomMessageBoxPanel(this);
      this._customMessageBoxPanel.Location = new Point(ImageHelper.Unscaled.FrameLeftPixel.Width, ImageHelper.Unscaled.FrameTopPixel.Height);
      this.Controls.Add((Control) this._customMessageBoxPanel);
      this.Size = new Size(this._customMessageBoxPanel.Width + ImageHelper.Unscaled.FrameLeftPixel.Width + ImageHelper.Unscaled.FrameRightPixel.Width, this._customMessageBoxPanel.Height + ImageHelper.Unscaled.FrameTopPixel.Height + ImageHelper.Unscaled.FrameBottomPixel.Height);
    }
  }
}
