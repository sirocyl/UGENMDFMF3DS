// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.frmRemapButtons
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Ultimate_GEN_MD_Forwarder_Maker_for_3DS.Properties;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS
{
  public class frmRemapButtons : Form
  {
    private Mapping3DS startingMapping;
    public Mapping3DS finalMapping;
    private bool windowsClosing;
    private IContainer components;
    private CheckBox chkn3dsLayout;
    private PictureBox pic3dsDPadRight;
    private PictureBox pic3dsDPadLeft;
    private PictureBox pic3dsDPadDown;
    private PictureBox pic3dsDPadUp;
    private PictureBox pictureBox8;
    private PictureBox pic3dsButtonSelect;
    private PictureBox pic3dsButtonStart;
    private PictureBox pic3dsButtonL;
    private PictureBox pic3dsButtonZL;
    private PictureBox pic3dsButtonR;
    private PictureBox pic3dsButtonZR;
    private PictureBox pic3dsCStickRight;
    private PictureBox pic3dsCStickLeft;
    private PictureBox pic3dsCStickDown;
    private PictureBox pic3dsCStickUp;
    private PictureBox pic3dsCirclePadRight;
    private PictureBox pic3dsCirclePadLeft;
    private PictureBox pic3dsCirclePadDown;
    private PictureBox pic3dsCirclePadUp;
    private PictureBox pic3DS;
    private PictureBox pic3dsCStick;
    private PictureBox pic3dsButtonA;
    private PictureBox pic3dsCirclePad;
    private PictureBox pic3dsButtonB;
    private PictureBox pic3dsButtonY;
    private PictureBox pic3dsButtonX;
    private Button btnCancel;
    private Button btnApply;
    private CheckBox chkEnableAnalogToDigital;
    private Label lblShowCurrentFunction;

    public frmRemapButtons(Mapping3DS actual)
    {
      this.InitializeComponent();
      this.startingMapping = new Mapping3DS(actual);
      this.finalMapping = new Mapping3DS(actual);
      this.chkn3dsLayout.Checked = actual.UsingNew3DS;
      this.chkEnableAnalogToDigital.Checked = actual.AnalogToDigital;
    }

    private void chkn3dsLayout_CheckedChanged(object sender, EventArgs e)
    {
      if (this.chkn3dsLayout.Checked)
      {
        this.finalMapping.UsingNew3DS = true;
        this.pic3dsButtonZL.Visible = true;
        this.pic3dsButtonZR.Visible = true;
        this.pic3dsCStick.Visible = true;
        this.pic3dsCStickUp.Visible = true;
        this.pic3dsCStickDown.Visible = true;
        this.pic3dsCStickLeft.Visible = true;
        this.pic3dsCStickRight.Visible = true;
        this.pic3DS.Image = (Image) Resources.n3ds_layout;
        this.Text = "Editing buttons layout (New 3DS mode)";
      }
      else
      {
        this.finalMapping.UsingNew3DS = false;
        this.pic3dsButtonZL.Visible = false;
        this.pic3dsButtonZR.Visible = false;
        this.pic3dsCStick.Visible = false;
        this.pic3dsCStickUp.Visible = false;
        this.pic3dsCStickDown.Visible = false;
        this.pic3dsCStickLeft.Visible = false;
        this.pic3dsCStickRight.Visible = false;
        this.pic3DS.Image = (Image) Resources.o3ds_layout;
        this.Text = "Editing buttons layout (Old 3DS mode)";
      }
    }

    private void frmRemapButtons_Load(object sender, EventArgs e)
    {
    }

    private void frmRemapButtons_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (this.windowsClosing)
        return;
      switch (MessageBox.Show("Do you want to save your changes?", Application.ProductName, MessageBoxButtons.YesNoCancel))
      {
        case DialogResult.Yes:
          break;
        case DialogResult.No:
          this.finalMapping = this.startingMapping;
          break;
        default:
          e.Cancel = true;
          this.windowsClosing = false;
          break;
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.windowsClosing = true;
      this.finalMapping = this.startingMapping;
      this.Close();
    }

    private void btnApply_Click(object sender, EventArgs e)
    {
      this.windowsClosing = true;
      this.Close();
    }

    private void chkEnableAnalogToDigital_CheckedChanged(object sender, EventArgs e)
    {
      if (this.chkEnableAnalogToDigital.Checked)
      {
        this.finalMapping.AnalogToDigital = true;
        this.pic3dsCirclePad.Visible = false;
        this.pic3dsCirclePadUp.Visible = false;
        this.pic3dsCirclePadDown.Visible = false;
        this.pic3dsCirclePadLeft.Visible = false;
        this.pic3dsCirclePadRight.Visible = false;
      }
      else
      {
        this.finalMapping.AnalogToDigital = false;
        this.pic3dsCirclePad.Visible = true;
        this.pic3dsCirclePadUp.Visible = true;
        this.pic3dsCirclePadDown.Visible = true;
        this.pic3dsCirclePadLeft.Visible = true;
        this.pic3dsCirclePadRight.Visible = true;
      }
    }

    private void pic3dsCirclePadUp_Click(object sender, EventArgs e)
    {
      frmPickButton frmPickButton = new frmPickButton(this.finalMapping.CirclePadUp);
      int num = (int) frmPickButton.ShowDialog();
      this.finalMapping.CirclePadUp = frmPickButton.pickedFunction;
    }

    private void pic3dsCirclePadDown_Click(object sender, EventArgs e)
    {
      frmPickButton frmPickButton = new frmPickButton(this.finalMapping.CirclePadDown);
      int num = (int) frmPickButton.ShowDialog();
      this.finalMapping.CirclePadDown = frmPickButton.pickedFunction;
    }

    private void pic3dsCirclePadLeft_Click(object sender, EventArgs e)
    {
      frmPickButton frmPickButton = new frmPickButton(this.finalMapping.CirclePadLeft);
      int num = (int) frmPickButton.ShowDialog();
      this.finalMapping.CirclePadLeft = frmPickButton.pickedFunction;
    }

    private void pic3dsCirclePadRight_Click(object sender, EventArgs e)
    {
      frmPickButton frmPickButton = new frmPickButton(this.finalMapping.CirclePadRight);
      int num = (int) frmPickButton.ShowDialog();
      this.finalMapping.CirclePadRight = frmPickButton.pickedFunction;
    }

    private void pictureBox7_Click(object sender, EventArgs e)
    {
      frmPickButton frmPickButton = new frmPickButton(this.finalMapping.DPadUp);
      int num = (int) frmPickButton.ShowDialog();
      this.finalMapping.DPadUp = frmPickButton.pickedFunction;
    }

    private void pictureBox6_Click(object sender, EventArgs e)
    {
      frmPickButton frmPickButton = new frmPickButton(this.finalMapping.DPadDown);
      int num = (int) frmPickButton.ShowDialog();
      this.finalMapping.DPadDown = frmPickButton.pickedFunction;
    }

    private void pictureBox4_Click(object sender, EventArgs e)
    {
      frmPickButton frmPickButton = new frmPickButton(this.finalMapping.DPadLeft);
      int num = (int) frmPickButton.ShowDialog();
      this.finalMapping.DPadLeft = frmPickButton.pickedFunction;
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
      frmPickButton frmPickButton = new frmPickButton(this.finalMapping.DPadRight);
      int num = (int) frmPickButton.ShowDialog();
      this.finalMapping.DPadRight = frmPickButton.pickedFunction;
    }

    private void pic3dsCStickUp_Click(object sender, EventArgs e)
    {
      frmPickButton frmPickButton = new frmPickButton(this.finalMapping.CStickUp);
      int num = (int) frmPickButton.ShowDialog();
      this.finalMapping.CStickUp = frmPickButton.pickedFunction;
    }

    private void pic3dsCStickDown_Click(object sender, EventArgs e)
    {
      frmPickButton frmPickButton = new frmPickButton(this.finalMapping.CStickDown);
      int num = (int) frmPickButton.ShowDialog();
      this.finalMapping.CStickDown = frmPickButton.pickedFunction;
    }

    private void pic3dsCStickLeft_Click(object sender, EventArgs e)
    {
      frmPickButton frmPickButton = new frmPickButton(this.finalMapping.CStickLeft);
      int num = (int) frmPickButton.ShowDialog();
      this.finalMapping.CStickLeft = frmPickButton.pickedFunction;
    }

    private void pic3dsCStickRight_Click(object sender, EventArgs e)
    {
      frmPickButton frmPickButton = new frmPickButton(this.finalMapping.CStickRight);
      int num = (int) frmPickButton.ShowDialog();
      this.finalMapping.CStickRight = frmPickButton.pickedFunction;
    }

    private void pic3dsButtonX_Click(object sender, EventArgs e)
    {
      frmPickButton frmPickButton = new frmPickButton(this.finalMapping.ButtonX);
      int num = (int) frmPickButton.ShowDialog();
      this.finalMapping.ButtonX = frmPickButton.pickedFunction;
    }

    private void pic3dsButtonA_Click(object sender, EventArgs e)
    {
      frmPickButton frmPickButton = new frmPickButton(this.finalMapping.ButtonA);
      int num = (int) frmPickButton.ShowDialog();
      this.finalMapping.ButtonA = frmPickButton.pickedFunction;
    }

    private void pic3dsButtonB_Click(object sender, EventArgs e)
    {
      frmPickButton frmPickButton = new frmPickButton(this.finalMapping.ButtonB);
      int num = (int) frmPickButton.ShowDialog();
      this.finalMapping.ButtonB = frmPickButton.pickedFunction;
    }

    private void pic3dsButtonY_Click(object sender, EventArgs e)
    {
      frmPickButton frmPickButton = new frmPickButton(this.finalMapping.ButtonY);
      int num = (int) frmPickButton.ShowDialog();
      this.finalMapping.ButtonY = frmPickButton.pickedFunction;
    }

    private void pic3dsButtonStart_Click(object sender, EventArgs e)
    {
      frmPickButton frmPickButton = new frmPickButton(this.finalMapping.ButtonStart);
      int num = (int) frmPickButton.ShowDialog();
      this.finalMapping.ButtonStart = frmPickButton.pickedFunction;
    }

    private void pic3dsButtonSelect_Click(object sender, EventArgs e)
    {
      frmPickButton frmPickButton = new frmPickButton(this.finalMapping.ButtonSelect);
      int num = (int) frmPickButton.ShowDialog();
      this.finalMapping.ButtonSelect = frmPickButton.pickedFunction;
    }

    private void pic3dsButtonR_Click(object sender, EventArgs e)
    {
      frmPickButton frmPickButton = new frmPickButton(this.finalMapping.ButtonR);
      int num = (int) frmPickButton.ShowDialog();
      this.finalMapping.ButtonR = frmPickButton.pickedFunction;
    }

    private void pic3dsButtonL_Click(object sender, EventArgs e)
    {
      frmPickButton frmPickButton = new frmPickButton(this.finalMapping.ButtonL);
      int num = (int) frmPickButton.ShowDialog();
      this.finalMapping.ButtonL = frmPickButton.pickedFunction;
    }

    private void pic3dsButtonZL_Click(object sender, EventArgs e)
    {
      frmPickButton frmPickButton = new frmPickButton(this.finalMapping.ButtonZL);
      int num = (int) frmPickButton.ShowDialog();
      this.finalMapping.ButtonZL = frmPickButton.pickedFunction;
    }

    private void pic3dsButtonZR_Click(object sender, EventArgs e)
    {
      frmPickButton frmPickButton = new frmPickButton(this.finalMapping.ButtonZR);
      int num = (int) frmPickButton.ShowDialog();
      this.finalMapping.ButtonZR = frmPickButton.pickedFunction;
    }

    private void pic3dsCirclePadUp_MouseEnter(object sender, EventArgs e)
    {
      this.lblShowCurrentFunction.Text = "Current function: " + Mapping3DS.TranslateFunctionToHumanReadable(this.finalMapping.CirclePadUp);
    }

    private void pic3dsCirclePadDown_MouseEnter(object sender, EventArgs e)
    {
      this.lblShowCurrentFunction.Text = "Current function: " + Mapping3DS.TranslateFunctionToHumanReadable(this.finalMapping.CirclePadDown);
    }

    private void pic3dsCirclePadLeft_MouseEnter(object sender, EventArgs e)
    {
      this.lblShowCurrentFunction.Text = "Current function: " + Mapping3DS.TranslateFunctionToHumanReadable(this.finalMapping.CirclePadLeft);
    }

    private void pic3dsCirclePadRight_MouseEnter(object sender, EventArgs e)
    {
      this.lblShowCurrentFunction.Text = "Current function: " + Mapping3DS.TranslateFunctionToHumanReadable(this.finalMapping.CirclePadRight);
    }

    private void pic3dsDPadUp_MouseEnter(object sender, EventArgs e)
    {
      this.lblShowCurrentFunction.Text = "Current function: " + Mapping3DS.TranslateFunctionToHumanReadable(this.finalMapping.DPadUp);
    }

    private void pic3dsDPadDown_MouseEnter(object sender, EventArgs e)
    {
      this.lblShowCurrentFunction.Text = "Current function: " + Mapping3DS.TranslateFunctionToHumanReadable(this.finalMapping.DPadDown);
    }

    private void pic3dsDPadLeft_MouseEnter(object sender, EventArgs e)
    {
      this.lblShowCurrentFunction.Text = "Current function: " + Mapping3DS.TranslateFunctionToHumanReadable(this.finalMapping.DPadLeft);
    }

    private void pic3dsDPadRight_MouseEnter(object sender, EventArgs e)
    {
      this.lblShowCurrentFunction.Text = "Current function: " + Mapping3DS.TranslateFunctionToHumanReadable(this.finalMapping.DPadRight);
    }

    private void pic3dsCStickUp_MouseEnter(object sender, EventArgs e)
    {
      this.lblShowCurrentFunction.Text = "Current function: " + Mapping3DS.TranslateFunctionToHumanReadable(this.finalMapping.CStickUp);
    }

    private void pic3dsCStickDown_MouseEnter(object sender, EventArgs e)
    {
      this.lblShowCurrentFunction.Text = "Current function: " + Mapping3DS.TranslateFunctionToHumanReadable(this.finalMapping.CStickDown);
    }

    private void pic3dsCStickLeft_MouseEnter(object sender, EventArgs e)
    {
      this.lblShowCurrentFunction.Text = "Current function: " + Mapping3DS.TranslateFunctionToHumanReadable(this.finalMapping.CStickLeft);
    }

    private void pic3dsCStickRight_MouseEnter(object sender, EventArgs e)
    {
      this.lblShowCurrentFunction.Text = "Current function: " + Mapping3DS.TranslateFunctionToHumanReadable(this.finalMapping.CStickRight);
    }

    private void pic3dsButtonA_MouseEnter(object sender, EventArgs e)
    {
      this.lblShowCurrentFunction.Text = "Current function: " + Mapping3DS.TranslateFunctionToHumanReadable(this.finalMapping.ButtonA);
    }

    private void pic3dsButtonB_MouseEnter(object sender, EventArgs e)
    {
      this.lblShowCurrentFunction.Text = "Current function: " + Mapping3DS.TranslateFunctionToHumanReadable(this.finalMapping.ButtonB);
    }

    private void pic3dsButtonX_MouseEnter(object sender, EventArgs e)
    {
      this.lblShowCurrentFunction.Text = "Current function: " + Mapping3DS.TranslateFunctionToHumanReadable(this.finalMapping.ButtonX);
    }

    private void pic3dsButtonY_MouseEnter(object sender, EventArgs e)
    {
      this.lblShowCurrentFunction.Text = "Current function: " + Mapping3DS.TranslateFunctionToHumanReadable(this.finalMapping.ButtonY);
    }

    private void pic3dsButtonStart_MouseEnter(object sender, EventArgs e)
    {
      this.lblShowCurrentFunction.Text = "Current function: " + Mapping3DS.TranslateFunctionToHumanReadable(this.finalMapping.ButtonStart);
    }

    private void pic3dsButtonSelect_MouseEnter(object sender, EventArgs e)
    {
      this.lblShowCurrentFunction.Text = "Current function: " + Mapping3DS.TranslateFunctionToHumanReadable(this.finalMapping.ButtonSelect);
    }

    private void pic3dsButtonL_MouseEnter(object sender, EventArgs e)
    {
      this.lblShowCurrentFunction.Text = "Current function: " + Mapping3DS.TranslateFunctionToHumanReadable(this.finalMapping.ButtonL);
    }

    private void pic3dsButtonR_MouseEnter(object sender, EventArgs e)
    {
      this.lblShowCurrentFunction.Text = "Current function: " + Mapping3DS.TranslateFunctionToHumanReadable(this.finalMapping.ButtonR);
    }

    private void pic3dsButtonZL_MouseEnter(object sender, EventArgs e)
    {
      this.lblShowCurrentFunction.Text = "Current function: " + Mapping3DS.TranslateFunctionToHumanReadable(this.finalMapping.ButtonZL);
    }

    private void pic3dsButtonZR_MouseEnter(object sender, EventArgs e)
    {
      this.lblShowCurrentFunction.Text = "Current function: " + Mapping3DS.TranslateFunctionToHumanReadable(this.finalMapping.ButtonZR);
    }

    private void frmRemapButtons_MouseEnter(object sender, EventArgs e)
    {
      this.lblShowCurrentFunction.Text = "";
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmRemapButtons));
      this.chkn3dsLayout = new CheckBox();
      this.pic3dsDPadRight = new PictureBox();
      this.pic3dsDPadLeft = new PictureBox();
      this.pic3dsDPadDown = new PictureBox();
      this.pic3dsDPadUp = new PictureBox();
      this.pictureBox8 = new PictureBox();
      this.pic3dsButtonSelect = new PictureBox();
      this.pic3dsButtonStart = new PictureBox();
      this.pic3dsButtonL = new PictureBox();
      this.pic3dsButtonZL = new PictureBox();
      this.pic3dsButtonR = new PictureBox();
      this.pic3dsButtonZR = new PictureBox();
      this.pic3dsCStickRight = new PictureBox();
      this.pic3dsCStickLeft = new PictureBox();
      this.pic3dsCStickDown = new PictureBox();
      this.pic3dsCStickUp = new PictureBox();
      this.pic3dsCirclePadRight = new PictureBox();
      this.pic3dsCirclePadLeft = new PictureBox();
      this.pic3dsCirclePadDown = new PictureBox();
      this.pic3dsCirclePadUp = new PictureBox();
      this.pic3DS = new PictureBox();
      this.pic3dsCStick = new PictureBox();
      this.pic3dsButtonA = new PictureBox();
      this.pic3dsCirclePad = new PictureBox();
      this.pic3dsButtonB = new PictureBox();
      this.pic3dsButtonY = new PictureBox();
      this.pic3dsButtonX = new PictureBox();
      this.btnCancel = new Button();
      this.btnApply = new Button();
      this.chkEnableAnalogToDigital = new CheckBox();
      this.lblShowCurrentFunction = new Label();
      ((ISupportInitialize) this.pic3dsDPadRight).BeginInit();
      ((ISupportInitialize) this.pic3dsDPadLeft).BeginInit();
      ((ISupportInitialize) this.pic3dsDPadDown).BeginInit();
      ((ISupportInitialize) this.pic3dsDPadUp).BeginInit();
      ((ISupportInitialize) this.pictureBox8).BeginInit();
      ((ISupportInitialize) this.pic3dsButtonSelect).BeginInit();
      ((ISupportInitialize) this.pic3dsButtonStart).BeginInit();
      ((ISupportInitialize) this.pic3dsButtonL).BeginInit();
      ((ISupportInitialize) this.pic3dsButtonZL).BeginInit();
      ((ISupportInitialize) this.pic3dsButtonR).BeginInit();
      ((ISupportInitialize) this.pic3dsButtonZR).BeginInit();
      ((ISupportInitialize) this.pic3dsCStickRight).BeginInit();
      ((ISupportInitialize) this.pic3dsCStickLeft).BeginInit();
      ((ISupportInitialize) this.pic3dsCStickDown).BeginInit();
      ((ISupportInitialize) this.pic3dsCStickUp).BeginInit();
      ((ISupportInitialize) this.pic3dsCirclePadRight).BeginInit();
      ((ISupportInitialize) this.pic3dsCirclePadLeft).BeginInit();
      ((ISupportInitialize) this.pic3dsCirclePadDown).BeginInit();
      ((ISupportInitialize) this.pic3dsCirclePadUp).BeginInit();
      ((ISupportInitialize) this.pic3DS).BeginInit();
      ((ISupportInitialize) this.pic3dsCStick).BeginInit();
      ((ISupportInitialize) this.pic3dsButtonA).BeginInit();
      ((ISupportInitialize) this.pic3dsCirclePad).BeginInit();
      ((ISupportInitialize) this.pic3dsButtonB).BeginInit();
      ((ISupportInitialize) this.pic3dsButtonY).BeginInit();
      ((ISupportInitialize) this.pic3dsButtonX).BeginInit();
      this.SuspendLayout();
      this.chkn3dsLayout.AutoSize = true;
      this.chkn3dsLayout.Location = new Point(8, 10);
      this.chkn3dsLayout.Name = "chkn3dsLayout";
      this.chkn3dsLayout.Size = new Size(72, 17);
      this.chkn3dsLayout.TabIndex = 133;
      this.chkn3dsLayout.Text = "New 3DS";
      this.chkn3dsLayout.UseVisualStyleBackColor = true;
      this.chkn3dsLayout.CheckedChanged += new EventHandler(this.chkn3dsLayout_CheckedChanged);
      this.pic3dsDPadRight.Cursor = Cursors.Hand;
      this.pic3dsDPadRight.Image = (Image) Resources.button_right;
      this.pic3dsDPadRight.Location = new Point(293, 186);
      this.pic3dsDPadRight.Name = "pic3dsDPadRight";
      this.pic3dsDPadRight.Size = new Size(22, 22);
      this.pic3dsDPadRight.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pic3dsDPadRight.TabIndex = 132;
      this.pic3dsDPadRight.TabStop = false;
      this.pic3dsDPadRight.Click += new EventHandler(this.pictureBox1_Click);
      this.pic3dsDPadRight.MouseEnter += new EventHandler(this.pic3dsDPadRight_MouseEnter);
      this.pic3dsDPadLeft.Cursor = Cursors.Hand;
      this.pic3dsDPadLeft.Image = (Image) Resources.button_left;
      this.pic3dsDPadLeft.Location = new Point(216, 186);
      this.pic3dsDPadLeft.Name = "pic3dsDPadLeft";
      this.pic3dsDPadLeft.Size = new Size(22, 22);
      this.pic3dsDPadLeft.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pic3dsDPadLeft.TabIndex = 131;
      this.pic3dsDPadLeft.TabStop = false;
      this.pic3dsDPadLeft.Click += new EventHandler(this.pictureBox4_Click);
      this.pic3dsDPadLeft.MouseEnter += new EventHandler(this.pic3dsDPadLeft_MouseEnter);
      this.pic3dsDPadDown.Cursor = Cursors.Hand;
      this.pic3dsDPadDown.Image = (Image) Resources.button_down;
      this.pic3dsDPadDown.Location = new Point(254, 225);
      this.pic3dsDPadDown.Name = "pic3dsDPadDown";
      this.pic3dsDPadDown.Size = new Size(22, 22);
      this.pic3dsDPadDown.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pic3dsDPadDown.TabIndex = 130;
      this.pic3dsDPadDown.TabStop = false;
      this.pic3dsDPadDown.Click += new EventHandler(this.pictureBox6_Click);
      this.pic3dsDPadDown.MouseEnter += new EventHandler(this.pic3dsDPadDown_MouseEnter);
      this.pic3dsDPadUp.Cursor = Cursors.Hand;
      this.pic3dsDPadUp.Image = (Image) Resources.button_up;
      this.pic3dsDPadUp.Location = new Point((int) byte.MaxValue, 149);
      this.pic3dsDPadUp.Name = "pic3dsDPadUp";
      this.pic3dsDPadUp.Size = new Size(22, 22);
      this.pic3dsDPadUp.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pic3dsDPadUp.TabIndex = 129;
      this.pic3dsDPadUp.TabStop = false;
      this.pic3dsDPadUp.Click += new EventHandler(this.pictureBox7_Click);
      this.pic3dsDPadUp.MouseEnter += new EventHandler(this.pic3dsDPadUp_MouseEnter);
      this.pictureBox8.Image = (Image) Resources._3ds_button_d_pad;
      this.pictureBox8.Location = new Point(237, 170);
      this.pictureBox8.Name = "pictureBox8";
      this.pictureBox8.Size = new Size(57, 56);
      this.pictureBox8.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox8.TabIndex = 128;
      this.pictureBox8.TabStop = false;
      this.pic3dsButtonSelect.Cursor = Cursors.Hand;
      this.pic3dsButtonSelect.Image = (Image) Resources._3ds_button_select;
      this.pic3dsButtonSelect.Location = new Point(549, 217);
      this.pic3dsButtonSelect.Name = "pic3dsButtonSelect";
      this.pic3dsButtonSelect.Size = new Size(66, 19);
      this.pic3dsButtonSelect.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pic3dsButtonSelect.TabIndex = (int) sbyte.MaxValue;
      this.pic3dsButtonSelect.TabStop = false;
      this.pic3dsButtonSelect.Click += new EventHandler(this.pic3dsButtonSelect_Click);
      this.pic3dsButtonSelect.MouseEnter += new EventHandler(this.pic3dsButtonSelect_MouseEnter);
      this.pic3dsButtonStart.Cursor = Cursors.Hand;
      this.pic3dsButtonStart.Image = (Image) Resources._3ds_button_start;
      this.pic3dsButtonStart.Location = new Point(549, 192);
      this.pic3dsButtonStart.Name = "pic3dsButtonStart";
      this.pic3dsButtonStart.Size = new Size(66, 19);
      this.pic3dsButtonStart.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pic3dsButtonStart.TabIndex = 126;
      this.pic3dsButtonStart.TabStop = false;
      this.pic3dsButtonStart.Click += new EventHandler(this.pic3dsButtonStart_Click);
      this.pic3dsButtonStart.MouseEnter += new EventHandler(this.pic3dsButtonStart_MouseEnter);
      this.pic3dsButtonL.Cursor = Cursors.Hand;
      this.pic3dsButtonL.Image = (Image) Resources._3ds_button_L;
      this.pic3dsButtonL.Location = new Point(263, 12);
      this.pic3dsButtonL.Name = "pic3dsButtonL";
      this.pic3dsButtonL.Size = new Size(28, 27);
      this.pic3dsButtonL.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pic3dsButtonL.TabIndex = 125;
      this.pic3dsButtonL.TabStop = false;
      this.pic3dsButtonL.Click += new EventHandler(this.pic3dsButtonL_Click);
      this.pic3dsButtonL.MouseEnter += new EventHandler(this.pic3dsButtonL_MouseEnter);
      this.pic3dsButtonZL.Cursor = Cursors.Hand;
      this.pic3dsButtonZL.Image = (Image) Resources._3ds_button_ZL;
      this.pic3dsButtonZL.Location = new Point(297, 12);
      this.pic3dsButtonZL.Name = "pic3dsButtonZL";
      this.pic3dsButtonZL.Size = new Size(27, 27);
      this.pic3dsButtonZL.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pic3dsButtonZL.TabIndex = 124;
      this.pic3dsButtonZL.TabStop = false;
      this.pic3dsButtonZL.Visible = false;
      this.pic3dsButtonZL.Click += new EventHandler(this.pic3dsButtonZL_Click);
      this.pic3dsButtonZL.MouseEnter += new EventHandler(this.pic3dsButtonZL_MouseEnter);
      this.pic3dsButtonR.Cursor = Cursors.Hand;
      this.pic3dsButtonR.Image = (Image) Resources._3ds_button_R;
      this.pic3dsButtonR.Location = new Point(582, 10);
      this.pic3dsButtonR.Name = "pic3dsButtonR";
      this.pic3dsButtonR.Size = new Size(28, 27);
      this.pic3dsButtonR.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pic3dsButtonR.TabIndex = 123;
      this.pic3dsButtonR.TabStop = false;
      this.pic3dsButtonR.Click += new EventHandler(this.pic3dsButtonR_Click);
      this.pic3dsButtonR.MouseEnter += new EventHandler(this.pic3dsButtonR_MouseEnter);
      this.pic3dsButtonZR.Cursor = Cursors.Hand;
      this.pic3dsButtonZR.Image = (Image) Resources._3ds_button_ZR;
      this.pic3dsButtonZR.Location = new Point(549, 11);
      this.pic3dsButtonZR.Name = "pic3dsButtonZR";
      this.pic3dsButtonZR.Size = new Size(27, 27);
      this.pic3dsButtonZR.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pic3dsButtonZR.TabIndex = 122;
      this.pic3dsButtonZR.TabStop = false;
      this.pic3dsButtonZR.Visible = false;
      this.pic3dsButtonZR.Click += new EventHandler(this.pic3dsButtonZR_Click);
      this.pic3dsButtonZR.MouseEnter += new EventHandler(this.pic3dsButtonZR_MouseEnter);
      this.pic3dsCStickRight.Cursor = Cursors.Hand;
      this.pic3dsCStickRight.Image = (Image) Resources.button_right;
      this.pic3dsCStickRight.Location = new Point(595, 81);
      this.pic3dsCStickRight.Name = "pic3dsCStickRight";
      this.pic3dsCStickRight.Size = new Size(22, 22);
      this.pic3dsCStickRight.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pic3dsCStickRight.TabIndex = 121;
      this.pic3dsCStickRight.TabStop = false;
      this.pic3dsCStickRight.Visible = false;
      this.pic3dsCStickRight.Click += new EventHandler(this.pic3dsCStickRight_Click);
      this.pic3dsCStickRight.MouseEnter += new EventHandler(this.pic3dsCStickRight_MouseEnter);
      this.pic3dsCStickLeft.Cursor = Cursors.Hand;
      this.pic3dsCStickLeft.Image = (Image) Resources.button_left;
      this.pic3dsCStickLeft.Location = new Point(549, 81);
      this.pic3dsCStickLeft.Name = "pic3dsCStickLeft";
      this.pic3dsCStickLeft.Size = new Size(22, 22);
      this.pic3dsCStickLeft.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pic3dsCStickLeft.TabIndex = 120;
      this.pic3dsCStickLeft.TabStop = false;
      this.pic3dsCStickLeft.Visible = false;
      this.pic3dsCStickLeft.Click += new EventHandler(this.pic3dsCStickLeft_Click);
      this.pic3dsCStickLeft.MouseEnter += new EventHandler(this.pic3dsCStickLeft_MouseEnter);
      this.pic3dsCStickDown.Cursor = Cursors.Hand;
      this.pic3dsCStickDown.Image = (Image) Resources.button_down;
      this.pic3dsCStickDown.Location = new Point(572, 104);
      this.pic3dsCStickDown.Name = "pic3dsCStickDown";
      this.pic3dsCStickDown.Size = new Size(22, 22);
      this.pic3dsCStickDown.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pic3dsCStickDown.TabIndex = 119;
      this.pic3dsCStickDown.TabStop = false;
      this.pic3dsCStickDown.Visible = false;
      this.pic3dsCStickDown.Click += new EventHandler(this.pic3dsCStickDown_Click);
      this.pic3dsCStickDown.MouseEnter += new EventHandler(this.pic3dsCStickDown_MouseEnter);
      this.pic3dsCStickUp.Cursor = Cursors.Hand;
      this.pic3dsCStickUp.Image = (Image) Resources.button_up;
      this.pic3dsCStickUp.Location = new Point(572, 58);
      this.pic3dsCStickUp.Name = "pic3dsCStickUp";
      this.pic3dsCStickUp.Size = new Size(22, 22);
      this.pic3dsCStickUp.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pic3dsCStickUp.TabIndex = 118;
      this.pic3dsCStickUp.TabStop = false;
      this.pic3dsCStickUp.Visible = false;
      this.pic3dsCStickUp.Click += new EventHandler(this.pic3dsCStickUp_Click);
      this.pic3dsCStickUp.MouseEnter += new EventHandler(this.pic3dsCStickUp_MouseEnter);
      this.pic3dsCirclePadRight.Cursor = Cursors.Hand;
      this.pic3dsCirclePadRight.Image = (Image) Resources.button_right;
      this.pic3dsCirclePadRight.Location = new Point(290, 83);
      this.pic3dsCirclePadRight.Name = "pic3dsCirclePadRight";
      this.pic3dsCirclePadRight.Size = new Size(22, 22);
      this.pic3dsCirclePadRight.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pic3dsCirclePadRight.TabIndex = 117;
      this.pic3dsCirclePadRight.TabStop = false;
      this.pic3dsCirclePadRight.Visible = false;
      this.pic3dsCirclePadRight.Click += new EventHandler(this.pic3dsCirclePadRight_Click);
      this.pic3dsCirclePadRight.MouseEnter += new EventHandler(this.pic3dsCirclePadRight_MouseEnter);
      this.pic3dsCirclePadLeft.Cursor = Cursors.Hand;
      this.pic3dsCirclePadLeft.Image = (Image) Resources.button_left;
      this.pic3dsCirclePadLeft.Location = new Point(218, 83);
      this.pic3dsCirclePadLeft.Name = "pic3dsCirclePadLeft";
      this.pic3dsCirclePadLeft.Size = new Size(22, 22);
      this.pic3dsCirclePadLeft.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pic3dsCirclePadLeft.TabIndex = 116;
      this.pic3dsCirclePadLeft.TabStop = false;
      this.pic3dsCirclePadLeft.Visible = false;
      this.pic3dsCirclePadLeft.Click += new EventHandler(this.pic3dsCirclePadLeft_Click);
      this.pic3dsCirclePadLeft.MouseEnter += new EventHandler(this.pic3dsCirclePadLeft_MouseEnter);
      this.pic3dsCirclePadDown.Cursor = Cursors.Hand;
      this.pic3dsCirclePadDown.Image = (Image) Resources.button_down;
      this.pic3dsCirclePadDown.Location = new Point((int) byte.MaxValue, 118);
      this.pic3dsCirclePadDown.Name = "pic3dsCirclePadDown";
      this.pic3dsCirclePadDown.Size = new Size(22, 22);
      this.pic3dsCirclePadDown.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pic3dsCirclePadDown.TabIndex = 115;
      this.pic3dsCirclePadDown.TabStop = false;
      this.pic3dsCirclePadDown.Visible = false;
      this.pic3dsCirclePadDown.Click += new EventHandler(this.pic3dsCirclePadDown_Click);
      this.pic3dsCirclePadDown.MouseEnter += new EventHandler(this.pic3dsCirclePadDown_MouseEnter);
      this.pic3dsCirclePadUp.Cursor = Cursors.Hand;
      this.pic3dsCirclePadUp.Image = (Image) Resources.button_up;
      this.pic3dsCirclePadUp.Location = new Point((int) byte.MaxValue, 46);
      this.pic3dsCirclePadUp.Name = "pic3dsCirclePadUp";
      this.pic3dsCirclePadUp.Size = new Size(22, 22);
      this.pic3dsCirclePadUp.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pic3dsCirclePadUp.TabIndex = 114;
      this.pic3dsCirclePadUp.TabStop = false;
      this.pic3dsCirclePadUp.Visible = false;
      this.pic3dsCirclePadUp.Click += new EventHandler(this.pic3dsCirclePadUp_Click);
      this.pic3dsCirclePadUp.MouseEnter += new EventHandler(this.pic3dsCirclePadUp_MouseEnter);
      this.pic3DS.Image = (Image) Resources.o3ds_layout;
      this.pic3DS.Location = new Point(330, 12);
      this.pic3DS.Name = "pic3DS";
      this.pic3DS.Size = new Size(213, 224);
      this.pic3DS.TabIndex = 107;
      this.pic3DS.TabStop = false;
      this.pic3dsCStick.Image = (Image) Resources._3ds_button_c_stick;
      this.pic3dsCStick.Location = new Point(570, 79);
      this.pic3dsCStick.Name = "pic3dsCStick";
      this.pic3dsCStick.Size = new Size(26, 26);
      this.pic3dsCStick.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pic3dsCStick.TabIndex = 113;
      this.pic3dsCStick.TabStop = false;
      this.pic3dsCStick.Visible = false;
      this.pic3dsButtonA.Cursor = Cursors.Hand;
      this.pic3dsButtonA.Image = (Image) Resources._3ds_button_A;
      this.pic3dsButtonA.Location = new Point(672, 140);
      this.pic3dsButtonA.Name = "pic3dsButtonA";
      this.pic3dsButtonA.Size = new Size(28, 29);
      this.pic3dsButtonA.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pic3dsButtonA.TabIndex = 108;
      this.pic3dsButtonA.TabStop = false;
      this.pic3dsButtonA.Click += new EventHandler(this.pic3dsButtonA_Click);
      this.pic3dsButtonA.MouseEnter += new EventHandler(this.pic3dsButtonA_MouseEnter);
      this.pic3dsCirclePad.Image = (Image) Resources._3ds_button_circle_pad;
      this.pic3dsCirclePad.Location = new Point(239, 67);
      this.pic3dsCirclePad.Name = "pic3dsCirclePad";
      this.pic3dsCirclePad.Size = new Size(52, 52);
      this.pic3dsCirclePad.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pic3dsCirclePad.TabIndex = 112;
      this.pic3dsCirclePad.TabStop = false;
      this.pic3dsCirclePad.Visible = false;
      this.pic3dsButtonB.Cursor = Cursors.Hand;
      this.pic3dsButtonB.Image = (Image) Resources._3ds_button_B;
      this.pic3dsButtonB.Location = new Point(644, 169);
      this.pic3dsButtonB.Name = "pic3dsButtonB";
      this.pic3dsButtonB.Size = new Size(28, 29);
      this.pic3dsButtonB.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pic3dsButtonB.TabIndex = 109;
      this.pic3dsButtonB.TabStop = false;
      this.pic3dsButtonB.Click += new EventHandler(this.pic3dsButtonB_Click);
      this.pic3dsButtonB.MouseEnter += new EventHandler(this.pic3dsButtonB_MouseEnter);
      this.pic3dsButtonY.Cursor = Cursors.Hand;
      this.pic3dsButtonY.Image = (Image) Resources._3ds_button_Y;
      this.pic3dsButtonY.Location = new Point(616, 140);
      this.pic3dsButtonY.Name = "pic3dsButtonY";
      this.pic3dsButtonY.Size = new Size(28, 29);
      this.pic3dsButtonY.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pic3dsButtonY.TabIndex = 111;
      this.pic3dsButtonY.TabStop = false;
      this.pic3dsButtonY.Click += new EventHandler(this.pic3dsButtonY_Click);
      this.pic3dsButtonY.MouseEnter += new EventHandler(this.pic3dsButtonY_MouseEnter);
      this.pic3dsButtonX.Cursor = Cursors.Hand;
      this.pic3dsButtonX.Image = (Image) Resources._3ds_button_X;
      this.pic3dsButtonX.Location = new Point(644, 111);
      this.pic3dsButtonX.Name = "pic3dsButtonX";
      this.pic3dsButtonX.Size = new Size(28, 29);
      this.pic3dsButtonX.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pic3dsButtonX.TabIndex = 110;
      this.pic3dsButtonX.TabStop = false;
      this.pic3dsButtonX.Click += new EventHandler(this.pic3dsButtonX_Click);
      this.pic3dsButtonX.MouseEnter += new EventHandler(this.pic3dsButtonX_MouseEnter);
      this.btnCancel.Location = new Point(462, 249);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(110, 25);
      this.btnCancel.TabIndex = 135;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
      this.btnApply.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnApply.Location = new Point(578, 249);
      this.btnApply.Name = "btnApply";
      this.btnApply.Size = new Size(134, 25);
      this.btnApply.TabIndex = 134;
      this.btnApply.Text = "Apply and accept";
      this.btnApply.UseVisualStyleBackColor = true;
      this.btnApply.Click += new EventHandler(this.btnApply_Click);
      this.chkEnableAnalogToDigital.AutoSize = true;
      this.chkEnableAnalogToDigital.Checked = true;
      this.chkEnableAnalogToDigital.CheckState = CheckState.Checked;
      this.chkEnableAnalogToDigital.Location = new Point(8, 33);
      this.chkEnableAnalogToDigital.Name = "chkEnableAnalogToDigital";
      this.chkEnableAnalogToDigital.Size = new Size(194, 17);
      this.chkEnableAnalogToDigital.TabIndex = 136;
      this.chkEnableAnalogToDigital.Text = "Enable Circle Pad = D-pad mapping";
      this.chkEnableAnalogToDigital.UseVisualStyleBackColor = true;
      this.chkEnableAnalogToDigital.CheckedChanged += new EventHandler(this.chkEnableAnalogToDigital_CheckedChanged);
      this.lblShowCurrentFunction.AutoSize = true;
      this.lblShowCurrentFunction.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblShowCurrentFunction.ForeColor = Color.Green;
      this.lblShowCurrentFunction.Location = new Point(5, 261);
      this.lblShowCurrentFunction.Name = "lblShowCurrentFunction";
      this.lblShowCurrentFunction.Size = new Size(0, 13);
      this.lblShowCurrentFunction.TabIndex = 137;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(721, 283);
      this.Controls.Add((Control) this.lblShowCurrentFunction);
      this.Controls.Add((Control) this.chkEnableAnalogToDigital);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnApply);
      this.Controls.Add((Control) this.chkn3dsLayout);
      this.Controls.Add((Control) this.pic3dsDPadRight);
      this.Controls.Add((Control) this.pic3dsDPadLeft);
      this.Controls.Add((Control) this.pic3dsDPadDown);
      this.Controls.Add((Control) this.pic3dsDPadUp);
      this.Controls.Add((Control) this.pictureBox8);
      this.Controls.Add((Control) this.pic3dsButtonSelect);
      this.Controls.Add((Control) this.pic3dsButtonStart);
      this.Controls.Add((Control) this.pic3dsButtonL);
      this.Controls.Add((Control) this.pic3dsButtonZL);
      this.Controls.Add((Control) this.pic3dsButtonR);
      this.Controls.Add((Control) this.pic3dsButtonZR);
      this.Controls.Add((Control) this.pic3dsCStickRight);
      this.Controls.Add((Control) this.pic3dsCStickLeft);
      this.Controls.Add((Control) this.pic3dsCStickDown);
      this.Controls.Add((Control) this.pic3dsCStickUp);
      this.Controls.Add((Control) this.pic3dsCirclePadRight);
      this.Controls.Add((Control) this.pic3dsCirclePadLeft);
      this.Controls.Add((Control) this.pic3dsCirclePadDown);
      this.Controls.Add((Control) this.pic3dsCirclePadUp);
      this.Controls.Add((Control) this.pic3DS);
      this.Controls.Add((Control) this.pic3dsCStick);
      this.Controls.Add((Control) this.pic3dsButtonA);
      this.Controls.Add((Control) this.pic3dsCirclePad);
      this.Controls.Add((Control) this.pic3dsButtonB);
      this.Controls.Add((Control) this.pic3dsButtonY);
      this.Controls.Add((Control) this.pic3dsButtonX);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.Name = "frmRemapButtons";
      this.Text = "Remap buttons";
      this.FormClosing += new FormClosingEventHandler(this.frmRemapButtons_FormClosing);
      this.Load += new EventHandler(this.frmRemapButtons_Load);
      this.MouseEnter += new EventHandler(this.frmRemapButtons_MouseEnter);
      ((ISupportInitialize) this.pic3dsDPadRight).EndInit();
      ((ISupportInitialize) this.pic3dsDPadLeft).EndInit();
      ((ISupportInitialize) this.pic3dsDPadDown).EndInit();
      ((ISupportInitialize) this.pic3dsDPadUp).EndInit();
      ((ISupportInitialize) this.pictureBox8).EndInit();
      ((ISupportInitialize) this.pic3dsButtonSelect).EndInit();
      ((ISupportInitialize) this.pic3dsButtonStart).EndInit();
      ((ISupportInitialize) this.pic3dsButtonL).EndInit();
      ((ISupportInitialize) this.pic3dsButtonZL).EndInit();
      ((ISupportInitialize) this.pic3dsButtonR).EndInit();
      ((ISupportInitialize) this.pic3dsButtonZR).EndInit();
      ((ISupportInitialize) this.pic3dsCStickRight).EndInit();
      ((ISupportInitialize) this.pic3dsCStickLeft).EndInit();
      ((ISupportInitialize) this.pic3dsCStickDown).EndInit();
      ((ISupportInitialize) this.pic3dsCStickUp).EndInit();
      ((ISupportInitialize) this.pic3dsCirclePadRight).EndInit();
      ((ISupportInitialize) this.pic3dsCirclePadLeft).EndInit();
      ((ISupportInitialize) this.pic3dsCirclePadDown).EndInit();
      ((ISupportInitialize) this.pic3dsCirclePadUp).EndInit();
      ((ISupportInitialize) this.pic3DS).EndInit();
      ((ISupportInitialize) this.pic3dsCStick).EndInit();
      ((ISupportInitialize) this.pic3dsButtonA).EndInit();
      ((ISupportInitialize) this.pic3dsCirclePad).EndInit();
      ((ISupportInitialize) this.pic3dsButtonB).EndInit();
      ((ISupportInitialize) this.pic3dsButtonY).EndInit();
      ((ISupportInitialize) this.pic3dsButtonX).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
