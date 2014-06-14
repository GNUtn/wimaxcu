// Type: Intel.Mobile.WiMAXCU.UI.Dashboard.ConnectionSubDetailItem
// Assembly: WiMAXCU, Version=6.2.4357.25644, Culture=neutral, PublicKeyToken=null
// MVID: 3C622363-C72C-43B7-9311-DD8942A58F18
// Assembly location: E:\Extracted\program files\Intel\WiMAX\Bin\WiMAXCU.exe

using Intel.Mobile.WiMAXCU.Common;
using Intel.Mobile.WiMAXCU.UI.CustomControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Intel.Mobile.WiMAXCU.UI.Dashboard
{
  public class ConnectionSubDetailItem : UserControl
  {
    private string _headingText = string.Empty;
    private Color _headingForeColor = Color.Black;
    private string _bodyTextLine1 = string.Empty;
    private Color _bodyLine1ForeColor = Color.Black;
    private ToolTip _pictureBoxLine1Tooltip = new ToolTip();
    private string _bodyTextLine2 = string.Empty;
    private Color _bodyLine2ForeColor = Color.Black;
    private ToolTip _pictureBoxLine2Tooltip = new ToolTip();
    private const int minConnectionSubDetailItemWidth = 150;
    private Container components;
    private PictureBox _pictureBoxLine1;
    private Bitmap _bodyIconLine1;
    private string _bodyIconLine1Tooltip;
    private PictureBox _pictureBoxLine2;
    private Bitmap _bodyIconLine2;
    private string _bodyIconLine2Tooltip;

    public string HeadingText
    {
      get
      {
        return this._headingText;
      }
      set
      {
        this._headingText = value;
      }
    }

    public Color HeadingForeColor
    {
      get
      {
        return this._headingForeColor;
      }
      set
      {
        this._headingForeColor = value;
      }
    }

    public string BodyTextLine1
    {
      get
      {
        return this._bodyTextLine1;
      }
      set
      {
        this._bodyTextLine1 = value;
      }
    }

    public Color BodyLine1ForeColor
    {
      get
      {
        return this._bodyLine1ForeColor;
      }
      set
      {
        this._bodyLine1ForeColor = value;
      }
    }

    public Bitmap BodyIconLine1
    {
      get
      {
        return this._bodyIconLine1;
      }
      set
      {
        this._bodyIconLine1 = value;
      }
    }

    public string BodyIconLine1Tooltip
    {
      get
      {
        return this._bodyIconLine1Tooltip;
      }
      set
      {
        this._bodyIconLine1Tooltip = value;
      }
    }

    public string BodyTextLine2
    {
      get
      {
        return this._bodyTextLine2;
      }
      set
      {
        this._bodyTextLine2 = value;
      }
    }

    public Color BodyLine2ForeColor
    {
      get
      {
        return this._bodyLine2ForeColor;
      }
      set
      {
        this._bodyLine2ForeColor = value;
      }
    }

    public Bitmap BodyIconLine2
    {
      get
      {
        return this._bodyIconLine2;
      }
      set
      {
        this._bodyIconLine2 = value;
      }
    }

    public string BodyIconLine2Tooltip
    {
      get
      {
        return this._bodyIconLine2Tooltip;
      }
      set
      {
        this._bodyIconLine2Tooltip = value;
      }
    }

    public ConnectionSubDetailItem(string headingText, Color headingForeColor, string bodyTextLine1, Color bodyLine1ForeColor, Bitmap bodyIconLine1, string bodyIconLine1Tooltip, string bodyTextLine2, Color bodyLine2ForeColor, Bitmap bodyIconLine2, string bodyIconLine2Tooltip)
    {
      this.InitializeComponent();
      this.CustomInitializeComponents(headingText, headingForeColor, bodyTextLine1, bodyLine1ForeColor, bodyIconLine1, bodyIconLine1Tooltip, bodyTextLine2, bodyLine2ForeColor, bodyIconLine2, bodyIconLine2Tooltip);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ConnectionSubDetailItem));
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Name = "ConnectionSubDetailItem";
      this.ResumeLayout(false);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    public void ResizeMe()
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      int num5 = 0;
      if (this._headingText != null && this._headingText.Length > 0)
      {
        using (Graphics graphics = this.CreateGraphics())
        {
          using (Font font = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold))
            num1 = SizeHelper.MeasureDisplayStringWidth(graphics, this._headingText, font) + 8;
        }
      }
      if (this._bodyTextLine1 != null && this._bodyTextLine1.Length > 0)
      {
        using (Graphics graphics = this.CreateGraphics())
        {
          num2 = SizeHelper.MeasureDisplayStringWidth(graphics, this._bodyTextLine1, this.Font) + 8;
          if (num2 < SizeHelper.MeasureDisplayStringWidth(graphics, "777.777.777.777", this.Font) + 25)
            num2 = SizeHelper.MeasureDisplayStringWidth(graphics, "777.777.777.777", this.Font) + 25;
        }
      }
      if (this._bodyTextLine2 != null && this._bodyTextLine2.Length > 0)
      {
        using (Graphics graphics = this.CreateGraphics())
        {
          num3 = SizeHelper.MeasureDisplayStringWidth(graphics, this._bodyTextLine2, this.Font) + 8;
          if (num3 < SizeHelper.MeasureDisplayStringWidth(graphics, "777.777.777.777", this.Font) + 25)
            num3 = SizeHelper.MeasureDisplayStringWidth(graphics, "777.777.777.777", this.Font) + 25;
        }
      }
      if (this._bodyIconLine1 != null)
        num4 = this._bodyIconLine1.Width;
      if (this._bodyIconLine2 != null)
        num5 = this._bodyIconLine2.Width;
      this.Width = num4 + num2;
      if (num5 + num3 > this.Width)
        this.Width = num5 + num3;
      if (num1 > this.Width)
        this.Width = num1;
      int num6 = DPIUtils.ScaleX(150);
      if (this.Width < num6)
        this.Width = num6;
      this.Height = DPIUtils.ScaleY(40);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      int xPos = 0;
      int yPos = 0;
      SizeF sizeF = new SizeF();
      if (this._headingText != null && this._headingText.Length > 0)
      {
        using (Font font = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold))
          sizeF = e.Graphics.MeasureString(this._headingText, font);
      }
      if (string.IsNullOrEmpty(this._bodyTextLine1) && string.IsNullOrEmpty(this._bodyTextLine2))
        yPos = 12;
      else if (string.IsNullOrEmpty(this._bodyTextLine1) || string.IsNullOrEmpty(this._bodyTextLine2))
        yPos = 4;
      if ((double) sizeF.Height > 18.5)
        yPos -= 5;
      if (this._headingText != null && this._headingText.Length > 0)
      {
        using (SolidBrush solidBrush = new SolidBrush(this._headingForeColor))
        {
          using (Font font = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold))
            e.Graphics.DrawString(this._headingText, font, (Brush) solidBrush, (float) xPos, (float) yPos);
        }
        yPos += (int) sizeF.Height - 2;
      }
      this.DrawBodyIconAndText(this._bodyIconLine1, ref this._pictureBoxLine1, this._bodyTextLine1, this._bodyLine1ForeColor, xPos, ref yPos, e);
      this.DrawBodyIconAndText(this._bodyIconLine2, ref this._pictureBoxLine2, this._bodyTextLine2, this._bodyLine2ForeColor, xPos, ref yPos, e);
      base.OnPaint(e);
    }

    private void DrawBodyIconAndText(Bitmap icon, ref PictureBox pictureBox, string text, Color foreColor, int xPos, ref int yPos, PaintEventArgs e)
    {
      int num = 0;
      if (icon != null)
      {
        if (pictureBox == null)
        {
          pictureBox = new PictureBox();
          pictureBox.MouseEnter += new EventHandler(this.pictureBox_MouseEnter);
          pictureBox.MouseLeave += new EventHandler(this.pictureBox_MouseLeave);
          this.Controls.Add((Control) pictureBox);
        }
        if (!ImageHelper.ImagesAreSame(pictureBox.Image, (Image) icon))
        {
          pictureBox.Image = (Image) icon;
          pictureBox.Location = new Point(xPos, yPos);
          pictureBox.Size = new Size(icon.Width, icon.Height);
        }
        xPos += icon.Width;
        num = icon.Height;
      }
      if (text != null && text.Length > 0)
      {
        SizeF sizeF = e.Graphics.MeasureString(text, this.Font);
        using (SolidBrush solidBrush = new SolidBrush(foreColor))
          e.Graphics.DrawString(text, this.Font, (Brush) solidBrush, (float) xPos, (float) yPos);
        if ((double) sizeF.Height > (double) num)
          num = (int) sizeF.Height;
      }
      if (num <= 0)
        return;
      yPos += num - 5;
    }

    private void pictureBox_MouseEnter(object sender, EventArgs e)
    {
      if (this._pictureBoxLine1 != null && this._bodyIconLine1Tooltip != null && this._pictureBoxLine1Tooltip != null)
        this._pictureBoxLine1Tooltip.SetToolTip((Control) this._pictureBoxLine1, this._bodyIconLine1Tooltip);
      if (this._pictureBoxLine2 == null || this._bodyIconLine2Tooltip == null || this._pictureBoxLine2Tooltip == null)
        return;
      this._pictureBoxLine2Tooltip.SetToolTip((Control) this._pictureBoxLine2, this._bodyIconLine2Tooltip);
    }

    private void pictureBox_MouseLeave(object sender, EventArgs e)
    {
      if (this._pictureBoxLine1 != null && this._bodyIconLine1Tooltip != null && this._pictureBoxLine1Tooltip != null)
        this._pictureBoxLine1Tooltip.RemoveAll();
      if (this._pictureBoxLine2 == null || this._bodyIconLine2Tooltip == null || this._pictureBoxLine2Tooltip == null)
        return;
      this._pictureBoxLine2Tooltip.RemoveAll();
    }

    private void CustomInitializeComponents(string headingText, Color headingForeColor, string bodyTextLine1, Color bodyLine1ForeColor, Bitmap bodyIconLine1, string bodyIconLine1Tooltip, string bodyTextLine2, Color bodyLine2ForeColor, Bitmap bodyIconLine2, string bodyIconLine2Tooltip)
    {
      this._headingText = headingText;
      this._headingForeColor = headingForeColor;
      this._bodyTextLine1 = bodyTextLine1;
      this._bodyLine1ForeColor = bodyLine1ForeColor;
      this._bodyIconLine1 = bodyIconLine1;
      this._bodyIconLine1Tooltip = bodyIconLine1Tooltip;
      this._bodyTextLine2 = bodyTextLine2;
      this._bodyLine2ForeColor = bodyLine2ForeColor;
      this._bodyIconLine2 = bodyIconLine2;
      this._bodyIconLine2Tooltip = bodyIconLine2Tooltip;
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.BackColor = Color.Transparent;
      this._pictureBoxLine1Tooltip.ShowAlways = true;
      this._pictureBoxLine2Tooltip.ShowAlways = true;
    }
  }
}
