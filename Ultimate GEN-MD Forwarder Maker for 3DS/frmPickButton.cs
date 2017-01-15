// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.frmPickButton
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
  public class frmPickButton : Form
  {
    private string startingFunction;
    public string pickedFunction;
    private bool windowsClosing;
    private IContainer components;
    private PictureBox picJoystick;
    private PictureBox picUp;
    private Label label1;
    private Label label2;
    private ListBox lstRetroArchFunctions;
    private PictureBox picDown;
    private PictureBox picLeft;
    private PictureBox picRight;
    private Label lblShowCurrentFunction;
    private PictureBox picA;
    private PictureBox picB;
    private PictureBox picC;
    private PictureBox picStart;
    private Label lblShowPickedFunction;
    private Label label3;
    private Button btnUnmap;

    public frmPickButton(string currentFunction)
    {
      this.InitializeComponent();
      this.startingFunction = currentFunction;
      this.pickedFunction = currentFunction;
      this.lblShowCurrentFunction.Text = "Current function: " + Mapping3DS.TranslateFunctionToHumanReadable(currentFunction);
      Point location1 = this.picUp.Location;
      this.picJoystick.Controls.Add((Control) this.picUp);
      this.picUp.Location = new Point(location1.X - this.picJoystick.Location.X, location1.Y - this.picJoystick.Location.Y);
      Point location2 = this.picDown.Location;
      this.picJoystick.Controls.Add((Control) this.picDown);
      this.picDown.Location = new Point(location2.X - this.picJoystick.Location.X, location2.Y - this.picJoystick.Location.Y);
      Point location3 = this.picLeft.Location;
      this.picJoystick.Controls.Add((Control) this.picLeft);
      this.picLeft.Location = new Point(location3.X - this.picJoystick.Location.X, location3.Y - this.picJoystick.Location.Y);
      Point location4 = this.picRight.Location;
      this.picJoystick.Controls.Add((Control) this.picRight);
      this.picRight.Location = new Point(location4.X - this.picJoystick.Location.X, location4.Y - this.picJoystick.Location.Y);
      Point location5 = this.picA.Location;
      this.picJoystick.Controls.Add((Control) this.picA);
      this.picA.Location = new Point(location5.X - this.picJoystick.Location.X, location5.Y - this.picJoystick.Location.Y);
      Point location6 = this.picB.Location;
      this.picJoystick.Controls.Add((Control) this.picB);
      this.picB.Location = new Point(location6.X - this.picJoystick.Location.X, location6.Y - this.picJoystick.Location.Y);
      Point location7 = this.picC.Location;
      this.picJoystick.Controls.Add((Control) this.picC);
      this.picC.Location = new Point(location7.X - this.picJoystick.Location.X, location7.Y - this.picJoystick.Location.Y);
      Point location8 = this.picStart.Location;
      this.picJoystick.Controls.Add((Control) this.picStart);
      this.picStart.Location = new Point(location8.X - this.picJoystick.Location.X, location8.Y - this.picJoystick.Location.Y);
    }

    private void frmPickButton_Load(object sender, EventArgs e)
    {
    }

    private void frmPickButton_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (this.windowsClosing)
        return;
      switch (MessageBox.Show("Do you want to save your changes?", Application.ProductName, MessageBoxButtons.YesNoCancel))
      {
        case DialogResult.Yes:
          break;
        case DialogResult.No:
          this.pickedFunction = this.startingFunction;
          break;
        default:
          e.Cancel = true;
          this.windowsClosing = false;
          break;
      }
    }

    private void picUp_Click(object sender, EventArgs e)
    {
      this.pickedFunction = "input_player1_up_";
      this.windowsClosing = true;
      this.Close();
    }

    private void picDown_Click(object sender, EventArgs e)
    {
      this.pickedFunction = "input_player1_down_";
      this.windowsClosing = true;
      this.Close();
    }

    private void picLeft_Click(object sender, EventArgs e)
    {
      this.pickedFunction = "input_player1_left_";
      this.windowsClosing = true;
      this.Close();
    }

    private void picRight_Click(object sender, EventArgs e)
    {
      this.pickedFunction = "input_player1_right_";
      this.windowsClosing = true;
      this.Close();
    }

    private void picUp_MouseEnter(object sender, EventArgs e)
    {
      this.picUp.BorderStyle = BorderStyle.FixedSingle;
      this.lblShowPickedFunction.Text = "Picking: " + Mapping3DS.TranslateFunctionToHumanReadable("input_player1_up_");
    }

    private void frmPickButton_MouseEnter(object sender, EventArgs e)
    {
      this.picUp.BorderStyle = BorderStyle.None;
      this.picDown.BorderStyle = BorderStyle.None;
      this.picLeft.BorderStyle = BorderStyle.None;
      this.picRight.BorderStyle = BorderStyle.None;
      this.picA.BorderStyle = BorderStyle.None;
      this.picB.BorderStyle = BorderStyle.None;
      this.picC.BorderStyle = BorderStyle.None;
      this.picStart.BorderStyle = BorderStyle.None;
      this.lblShowPickedFunction.Text = "";
    }

    private void picJoystick_MouseEnter(object sender, EventArgs e)
    {
      this.frmPickButton_MouseEnter(sender, e);
    }

    private void picRight_MouseEnter(object sender, EventArgs e)
    {
      this.picRight.BorderStyle = BorderStyle.FixedSingle;
      this.lblShowPickedFunction.Text = "Picking: " + Mapping3DS.TranslateFunctionToHumanReadable("input_player1_right_");
    }

    private void picDown_MouseEnter(object sender, EventArgs e)
    {
      this.picDown.BorderStyle = BorderStyle.FixedSingle;
      this.lblShowPickedFunction.Text = "Picking: " + Mapping3DS.TranslateFunctionToHumanReadable("input_player1_down_");
    }

    private void picLeft_MouseEnter(object sender, EventArgs e)
    {
      this.picLeft.BorderStyle = BorderStyle.FixedSingle;
      this.lblShowPickedFunction.Text = "Picking: " + Mapping3DS.TranslateFunctionToHumanReadable("input_player1_left_");
    }

    private void picStart_Click(object sender, EventArgs e)
    {
      this.pickedFunction = "input_player1_start_";
      this.windowsClosing = true;
      this.Close();
    }

    private void picA_Click(object sender, EventArgs e)
    {
      this.pickedFunction = "input_player1_y_";
      this.windowsClosing = true;
      this.Close();
    }

    private void picB_Click(object sender, EventArgs e)
    {
      this.pickedFunction = "input_player1_b_";
      this.windowsClosing = true;
      this.Close();
    }

    private void picC_Click(object sender, EventArgs e)
    {
      this.pickedFunction = "input_player1_a_";
      this.windowsClosing = true;
      this.Close();
    }

    private void picStart_MouseEnter(object sender, EventArgs e)
    {
      this.picStart.BorderStyle = BorderStyle.FixedSingle;
      this.lblShowPickedFunction.Text = "Picking: " + Mapping3DS.TranslateFunctionToHumanReadable("input_player1_start_");
    }

    private void picA_MouseEnter(object sender, EventArgs e)
    {
      this.picA.BorderStyle = BorderStyle.FixedSingle;
      this.lblShowPickedFunction.Text = "Picking: " + Mapping3DS.TranslateFunctionToHumanReadable("input_player1_y_");
    }

    private void picB_MouseEnter(object sender, EventArgs e)
    {
      this.picB.BorderStyle = BorderStyle.FixedSingle;
      this.lblShowPickedFunction.Text = "Picking: " + Mapping3DS.TranslateFunctionToHumanReadable("input_player1_b_");
    }

    private void picC_MouseEnter(object sender, EventArgs e)
    {
      this.picC.BorderStyle = BorderStyle.FixedSingle;
      this.lblShowPickedFunction.Text = "Picking: " + Mapping3DS.TranslateFunctionToHumanReadable("input_player1_a_");
    }

    private void frmPickButton_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Escape)
        return;
      this.Close();
    }

    private void lstRetroArchFunctions_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.lblShowPickedFunction.Text = "Picking: " + Mapping3DS.TranslateFunctionToHumanReadable(Mapping3DS.RETROARCH_FUNCTIONS[this.lstRetroArchFunctions.SelectedIndex]);
    }

    private void lstRetroArchFunctions_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      this.pickedFunction = Mapping3DS.RETROARCH_FUNCTIONS[this.lstRetroArchFunctions.SelectedIndex];
      this.windowsClosing = true;
      this.Close();
    }

    private void btnUnmap_Click(object sender, EventArgs e)
    {
      this.pickedFunction = "nul";
      this.windowsClosing = true;
      this.Close();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmPickButton));
      this.picJoystick = new PictureBox();
      this.picUp = new PictureBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.lstRetroArchFunctions = new ListBox();
      this.picDown = new PictureBox();
      this.picLeft = new PictureBox();
      this.picRight = new PictureBox();
      this.lblShowCurrentFunction = new Label();
      this.picA = new PictureBox();
      this.picB = new PictureBox();
      this.picC = new PictureBox();
      this.picStart = new PictureBox();
      this.lblShowPickedFunction = new Label();
      this.label3 = new Label();
      this.btnUnmap = new Button();
      ((ISupportInitialize) this.picJoystick).BeginInit();
      ((ISupportInitialize) this.picUp).BeginInit();
      ((ISupportInitialize) this.picDown).BeginInit();
      ((ISupportInitialize) this.picLeft).BeginInit();
      ((ISupportInitialize) this.picRight).BeginInit();
      ((ISupportInitialize) this.picA).BeginInit();
      ((ISupportInitialize) this.picB).BeginInit();
      ((ISupportInitialize) this.picC).BeginInit();
      ((ISupportInitialize) this.picStart).BeginInit();
      this.SuspendLayout();
      this.picJoystick.Image = (Image) Resources.genesis_layout;
      this.picJoystick.Location = new Point(12, 44);
      this.picJoystick.Name = "picJoystick";
      this.picJoystick.Size = new Size(460, 269);
      this.picJoystick.SizeMode = PictureBoxSizeMode.AutoSize;
      this.picJoystick.TabIndex = 0;
      this.picJoystick.TabStop = false;
      this.picJoystick.MouseEnter += new EventHandler(this.picJoystick_MouseEnter);
      this.picUp.BackColor = Color.Transparent;
      this.picUp.Cursor = Cursors.Hand;
      this.picUp.Location = new Point(96, 100);
      this.picUp.Name = "picUp";
      this.picUp.Size = new Size(32, 46);
      this.picUp.SizeMode = PictureBoxSizeMode.AutoSize;
      this.picUp.TabIndex = 1;
      this.picUp.TabStop = false;
      this.picUp.Click += new EventHandler(this.picUp_Click);
      this.picUp.MouseEnter += new EventHandler(this.picUp_MouseEnter);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(12, 28);
      this.label1.Name = "label1";
      this.label1.Size = new Size(134, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Pick a joystick button:";
      this.label2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(474, 28);
      this.label2.Name = "label2";
      this.label2.Size = new Size(174, 30);
      this.label2.TabIndex = 3;
      this.label2.Text = "Or pick a RetroArch function (double click it):";
      this.lstRetroArchFunctions.FormattingEnabled = true;
      ListBox.ObjectCollection items1 = this.lstRetroArchFunctions.Items;
      object[] items2 = new object[11];
      int index1 = 0;
      string str1 = "Fast forward toggle";
      items2[index1] = (object) str1;
      int index2 = 1;
      string str2 = "Fast forward hold";
      items2[index2] = (object) str2;
      int index3 = 2;
      string str3 = "Load state";
      items2[index3] = (object) str3;
      int index4 = 3;
      string str4 = "Save state";
      items2[index4] = (object) str4;
      int index5 = 4;
      string str5 = "Quit RetroArch";
      items2[index5] = (object) str5;
      int index6 = 5;
      string str6 = "Rewind";
      items2[index6] = (object) str6;
      int index7 = 6;
      string str7 = "Pause toggle";
      items2[index7] = (object) str7;
      int index8 = 7;
      string str8 = "Reset game";
      items2[index8] = (object) str8;
      int index9 = 8;
      string str9 = "Audio mute toggle";
      items2[index9] = (object) str9;
      int index10 = 9;
      string str10 = "Slow motion";
      items2[index10] = (object) str10;
      int index11 = 10;
      string str11 = "Menu toggle";
      items2[index11] = (object) str11;
      items1.AddRange(items2);
      this.lstRetroArchFunctions.Location = new Point(483, 61);
      this.lstRetroArchFunctions.Name = "lstRetroArchFunctions";
      this.lstRetroArchFunctions.Size = new Size(165, 147);
      this.lstRetroArchFunctions.TabIndex = 4;
      this.lstRetroArchFunctions.SelectedIndexChanged += new EventHandler(this.lstRetroArchFunctions_SelectedIndexChanged);
      this.lstRetroArchFunctions.MouseDoubleClick += new MouseEventHandler(this.lstRetroArchFunctions_MouseDoubleClick);
      this.picDown.BackColor = Color.Transparent;
      this.picDown.Cursor = Cursors.Hand;
      this.picDown.Location = new Point(96, 177);
      this.picDown.Name = "picDown";
      this.picDown.Size = new Size(32, 46);
      this.picDown.SizeMode = PictureBoxSizeMode.AutoSize;
      this.picDown.TabIndex = 5;
      this.picDown.TabStop = false;
      this.picDown.Click += new EventHandler(this.picDown_Click);
      this.picDown.MouseEnter += new EventHandler(this.picDown_MouseEnter);
      this.picLeft.BackColor = Color.Transparent;
      this.picLeft.Cursor = Cursors.Hand;
      this.picLeft.Location = new Point(51, 145);
      this.picLeft.Name = "picLeft";
      this.picLeft.Size = new Size(46, 32);
      this.picLeft.SizeMode = PictureBoxSizeMode.AutoSize;
      this.picLeft.TabIndex = 6;
      this.picLeft.TabStop = false;
      this.picLeft.Click += new EventHandler(this.picLeft_Click);
      this.picLeft.MouseEnter += new EventHandler(this.picLeft_MouseEnter);
      this.picRight.BackColor = Color.Transparent;
      this.picRight.Cursor = Cursors.Hand;
      this.picRight.Location = new Point((int) sbyte.MaxValue, 145);
      this.picRight.Name = "picRight";
      this.picRight.Size = new Size(46, 32);
      this.picRight.SizeMode = PictureBoxSizeMode.AutoSize;
      this.picRight.TabIndex = 7;
      this.picRight.TabStop = false;
      this.picRight.Click += new EventHandler(this.picRight_Click);
      this.picRight.MouseEnter += new EventHandler(this.picRight_MouseEnter);
      this.lblShowCurrentFunction.AutoSize = true;
      this.lblShowCurrentFunction.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblShowCurrentFunction.ForeColor = Color.Green;
      this.lblShowCurrentFunction.Location = new Point(12, 9);
      this.lblShowCurrentFunction.Name = "lblShowCurrentFunction";
      this.lblShowCurrentFunction.Size = new Size(0, 13);
      this.lblShowCurrentFunction.TabIndex = 138;
      this.picA.BackColor = Color.Transparent;
      this.picA.Cursor = Cursors.Hand;
      this.picA.Location = new Point(305, 166);
      this.picA.Name = "picA";
      this.picA.Size = new Size(42, 42);
      this.picA.TabIndex = 139;
      this.picA.TabStop = false;
      this.picA.Click += new EventHandler(this.picA_Click);
      this.picA.MouseEnter += new EventHandler(this.picA_MouseEnter);
      this.picB.BackColor = Color.Transparent;
      this.picB.Cursor = Cursors.Hand;
      this.picB.Location = new Point(351, 142);
      this.picB.Name = "picB";
      this.picB.Size = new Size(42, 42);
      this.picB.TabIndex = 140;
      this.picB.TabStop = false;
      this.picB.Click += new EventHandler(this.picB_Click);
      this.picB.MouseEnter += new EventHandler(this.picB_MouseEnter);
      this.picC.BackColor = Color.Transparent;
      this.picC.Cursor = Cursors.Hand;
      this.picC.Location = new Point(397, 122);
      this.picC.Name = "picC";
      this.picC.Size = new Size(42, 42);
      this.picC.TabIndex = 141;
      this.picC.TabStop = false;
      this.picC.Click += new EventHandler(this.picC_Click);
      this.picC.MouseEnter += new EventHandler(this.picC_MouseEnter);
      this.picStart.BackColor = Color.Transparent;
      this.picStart.Cursor = Cursors.Hand;
      this.picStart.Location = new Point(315, 76);
      this.picStart.Name = "picStart";
      this.picStart.Size = new Size(53, 38);
      this.picStart.TabIndex = 142;
      this.picStart.TabStop = false;
      this.picStart.Click += new EventHandler(this.picStart_Click);
      this.picStart.MouseEnter += new EventHandler(this.picStart_MouseEnter);
      this.lblShowPickedFunction.AutoSize = true;
      this.lblShowPickedFunction.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblShowPickedFunction.ForeColor = Color.Green;
      this.lblShowPickedFunction.Location = new Point(12, 324);
      this.lblShowPickedFunction.Name = "lblShowPickedFunction";
      this.lblShowPickedFunction.Size = new Size(0, 13);
      this.lblShowPickedFunction.TabIndex = 143;
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(485, 219);
      this.label3.Name = "label3";
      this.label3.Size = new Size(24, 13);
      this.label3.TabIndex = 144;
      this.label3.Text = "Or ";
      this.btnUnmap.Location = new Point(510, 214);
      this.btnUnmap.Name = "btnUnmap";
      this.btnUnmap.Size = new Size(138, 23);
      this.btnUnmap.TabIndex = 145;
      this.btnUnmap.Text = "Unmap current function";
      this.btnUnmap.UseVisualStyleBackColor = true;
      this.btnUnmap.Click += new EventHandler(this.btnUnmap_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(660, 346);
      this.Controls.Add((Control) this.btnUnmap);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.lblShowPickedFunction);
      this.Controls.Add((Control) this.picStart);
      this.Controls.Add((Control) this.picC);
      this.Controls.Add((Control) this.picB);
      this.Controls.Add((Control) this.picA);
      this.Controls.Add((Control) this.lblShowCurrentFunction);
      this.Controls.Add((Control) this.picRight);
      this.Controls.Add((Control) this.picLeft);
      this.Controls.Add((Control) this.picDown);
      this.Controls.Add((Control) this.lstRetroArchFunctions);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.picUp);
      this.Controls.Add((Control) this.picJoystick);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.Name = "frmPickButton";
      this.Text = "Pick a function";
      this.FormClosing += new FormClosingEventHandler(this.frmPickButton_FormClosing);
      this.Load += new EventHandler(this.frmPickButton_Load);
      this.KeyDown += new KeyEventHandler(this.frmPickButton_KeyDown);
      this.MouseEnter += new EventHandler(this.frmPickButton_MouseEnter);
      ((ISupportInitialize) this.picJoystick).EndInit();
      ((ISupportInitialize) this.picUp).EndInit();
      ((ISupportInitialize) this.picDown).EndInit();
      ((ISupportInitialize) this.picLeft).EndInit();
      ((ISupportInitialize) this.picRight).EndInit();
      ((ISupportInitialize) this.picA).EndInit();
      ((ISupportInitialize) this.picB).EndInit();
      ((ISupportInitialize) this.picC).EndInit();
      ((ISupportInitialize) this.picStart).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
