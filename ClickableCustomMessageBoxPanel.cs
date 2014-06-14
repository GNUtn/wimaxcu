// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.ClickableCustomMessageBoxPanel
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  internal class ClickableCustomMessageBoxPanel : CustomMessageBoxPanel
  {
    private LinkLabel _linkLabel;

    public ClickableCustomMessageBoxPanel(ClickableCustomMessageBox parentDialog)
      : base((CustomMessageBox) parentDialog)
    {
    }

    protected override Control GetTextControlToAdd(int xPos, int yPos, int iconWidth, int iconPadding)
    {
      if (this._linkLabel == null)
      {
        this._linkLabel = new LinkLabel();
        this._linkLabel.Location = new Point(xPos + iconWidth + iconPadding, yPos);
        this._linkLabel.AutoSize = true;
        this._linkLabel.Font = this.Font;
        this._linkLabel.TabStop = true;
        this._linkLabel.TabIndex = 0;
        this._linkLabel.Text = this.InsertNewLines(this._parentDialog.Message, ((ClickableCustomMessageBox) this._parentDialog).FirstLinkText, ((ClickableCustomMessageBox) this._parentDialog).SecondLinkText);
        this._linkLabel.AutoSize = false;
        this._linkLabel.Size = SizeHelper.GetRequiredSizeForText((Control) this._linkLabel);
        this._linkLabel.LinkClicked -= ((ClickableCustomMessageBox) this._parentDialog).LinkHandler;
        this._linkLabel.LinkClicked += ((ClickableCustomMessageBox) this._parentDialog).LinkHandler;
        if (this._linkLabel.Links.Count > 0)
          this._linkLabel.Links.Clear();
        if (!string.IsNullOrEmpty(((ClickableCustomMessageBox) this._parentDialog).FirstLinkText))
        {
          string firstLinkText = ((ClickableCustomMessageBox) this._parentDialog).FirstLinkText;
          if (this._linkLabel.Text.IndexOf(firstLinkText) >= 0)
            this._linkLabel.Links.Add(this._linkLabel.Text.IndexOf(firstLinkText), firstLinkText.Length, (object) WhichLinkClicked.FirstLink);
        }
        if (!string.IsNullOrEmpty(((ClickableCustomMessageBox) this._parentDialog).SecondLinkText))
        {
          string firstLinkText = ((ClickableCustomMessageBox) this._parentDialog).FirstLinkText;
          string secondLinkText = ((ClickableCustomMessageBox) this._parentDialog).SecondLinkText;
          if (this._linkLabel.Text.IndexOf(secondLinkText, this._linkLabel.Text.IndexOf(firstLinkText) + firstLinkText.Length) >= 0)
            this._linkLabel.Links.Add(this._linkLabel.Text.IndexOf(secondLinkText, this._linkLabel.Text.IndexOf(firstLinkText) + firstLinkText.Length), secondLinkText.Length, (object) WhichLinkClicked.SecondLink);
        }
      }
      return (Control) this._linkLabel;
    }

    public override void UpdateTextControl()
    {
    }

    private string InsertNewLines(string str, string link1Text, string link2Text)
    {
      string str1 = "[~]";
      string str2 = "{~}";
      string str3 = "=#=";
      if (string.IsNullOrEmpty(str) || MiscUtilities.CurrentUICultureIsAsian())
        return str;
      string input1 = Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(str, "\r\n(\r\n)+", str3), "\r\n\\s+(\r\n)+", str3), str3 + "\\s+", str3), "\\s+" + str3, str3);
      string input2 = !MiscUtilities.CurrentUICultureIsAsian() ? Regex.Replace(input1, "\r\n", " ") : Regex.Replace(input1, "\r\n", "");
      if (!string.IsNullOrEmpty(link1Text))
        input2 = input2.Replace(link1Text, str1);
      if (!string.IsNullOrEmpty(link2Text))
        input2 = input2.Replace(link2Text, str2);
      string[] strArray = Regex.Split(input2, str3);
      StringBuilder stringBuilder = new StringBuilder();
      foreach (string line in strArray)
      {
        if (stringBuilder.Length > 0)
          stringBuilder.Append("\r\n\r\n");
        stringBuilder.Append(this.BreakLine(line, link1Text.Length, str1, link2Text.Length, str2));
      }
      stringBuilder.Replace(str1, link1Text);
      stringBuilder.Replace(str2, link2Text);
      return ((object) stringBuilder).ToString();
    }

    private string BreakLine(string line, int link1Length, string link1Placeholder, int link2Length, string link2Placeholder)
    {
      if (MiscUtilities.CurrentUICultureIsAsian())
        return this.BreakLineAsian(line, link1Length, link1Placeholder, link2Length, link2Placeholder);
      else
        return this.BreakLineNonAsian(line, link1Length, link1Placeholder, link2Length, link2Placeholder);
    }

    private string BreakLineAsian(string line, int link1Length, string link1Placeholder, int link2Length, string link2Placeholder)
    {
      string str = line;
      if (!string.IsNullOrEmpty(line))
      {
        StringBuilder stringBuilder = new StringBuilder();
        int num = 0;
        for (int index = 0; index < line.Length; ++index)
        {
          if (num > 35 && !this.CharInPlaceholder(line[index], link1Placeholder) && !this.CharInPlaceholder(line[index], link2Placeholder))
          {
            stringBuilder.Append("\r\n");
            num = 0;
          }
          stringBuilder.Append(line[index]);
          ++num;
        }
        str = ((object) stringBuilder).ToString();
      }
      return str;
    }

    private string BreakLineNonAsian(string line, int link1Length, string link1Placeholder, int link2Length, string link2Placeholder)
    {
      int num1 = 40;
      if (string.IsNullOrEmpty(line))
        return line;
      StringBuilder stringBuilder = new StringBuilder();
      int num2 = 0;
      bool flag = false;
      for (int index = 0; index < line.Length; ++index)
      {
        if (Regex.IsMatch(line[index].ToString(), "\\s") && flag)
        {
          num2 = 0;
          flag = false;
          stringBuilder.Append("\r\n");
        }
        else
        {
          if (index >= 1 && (int) line[index] == (int) link1Placeholder[link1Placeholder.Length - 1] && (int) line[index - 1] == (int) link1Placeholder[link1Placeholder.Length - 2])
            num2 += link1Length - 3;
          else if (index >= 1 && (int) line[index] == (int) link2Placeholder[link2Placeholder.Length - 1] && (int) line[index - 1] == (int) link2Placeholder[link2Placeholder.Length - 2])
            num2 += link2Length - 3;
          else
            ++num2;
          stringBuilder.Append(line[index]);
        }
        if (num2 > num1)
          flag = true;
      }
      return Regex.Replace(((object) stringBuilder).ToString(), "^\\s+", "", RegexOptions.Multiline);
    }

    private bool CharInPlaceholder(char theChar, string placeHolder)
    {
      if (!string.IsNullOrEmpty(placeHolder))
      {
        foreach (int num in placeHolder)
        {
          if (num == (int) theChar)
            return true;
        }
      }
      return false;
    }
  }
}
