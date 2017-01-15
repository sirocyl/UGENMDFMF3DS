// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.frmMain
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using DamienG.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using Ultimate_GEN_MD_Forwarder_Maker_for_3DS.Properties;
using Ultimate_GEN_MD_Forwarder_Maker_for_3DS.YLScsDrawing.Imaging.Filters;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS
{
  public class frmMain : Form
  {
    private byte actualStep = (byte) 1;
    private string longName = "";
    private string shortName = "";
    private string gamePublisher = "";
    private byte[] fileGEN;
    private Bitmap iconBitmap;
    private Bitmap bannerInnerBitmap;
    private bool usingCustomFooterBanner;
    private Bitmap importedCustomFooterBanner;
    private bool usingCustomIconBin;
    private byte[] importedCustomIconBin;
    private bool usingCustomBannerBin;
    private byte[] importedCustomBannerBin;
    private Bitmap importedCustomBottomScreen;
    private frmMain.BannerType bannerType;
    public const string BUTTON_3DS_B = "0";
    public const string BUTTON_3DS_Y = "1";
    public const string BUTTON_3DS_SELECT = "2";
    public const string BUTTON_3DS_START = "3";
    public const string BUTTON_3DS_DPAD_UP = "4";
    public const string BUTTON_3DS_DPAD_DOWN = "5";
    public const string BUTTON_3DS_DPAD_LEFT = "6";
    public const string BUTTON_3DS_DPAD_RIGHT = "7";
    public const string BUTTON_3DS_A = "8";
    public const string BUTTON_3DS_X = "9";
    public const string BUTTON_3DS_L = "10";
    public const string BUTTON_3DS_R = "11";
    public const string BUTTON_3DS_ZL = "12";
    public const string BUTTON_3DS_ZR = "13";
    public const string BUTTON_3DS_CIRCLEPAD_UP = "-1";
    public const string BUTTON_3DS_CIRCLEPAD_DOWN = "+1";
    public const string BUTTON_3DS_CIRCLEPAD_LEFT = "-0";
    public const string BUTTON_3DS_CIRCLEPAD_RIGHT = "+0";
    public const string BUTTON_3DS_C_STICK_UP = "-3";
    public const string BUTTON_3DS_C_STICK_DOWN = "+3";
    public const string BUTTON_3DS_C_STICK_LEFT = "-2";
    public const string BUTTON_3DS_C_STICK_RIGHT = "+2";
    private Mapping3DS MappedButtons;
    private IContainer components;
    private Label lblStep;
    private Panel panelStep1;
    private Panel panel1;
    private Button button2;
    private Button btnPreviousStep;
    private Button btnNextStep;
    private Button btnOpenRom;
    private Label label1;
    private Panel panelStep3;
    private Label label10;
    private PictureBox picSummaryIcon;
    private PictureBox pictureBox2;
    private Label lblSummaryROMFile;
    private Label lblSummaryGamePublisher;
    private TextBox txtBright;
    private Label label16;
    private TrackBar trkBright;
    private Button btnSelectFont;
    private Label label14;
    private Label label13;
    private Label label11;
    private Label label12;
    private ListBox lstInterpolation2;
    private Label label3;
    private TextBox txtFooterBanner;
    private Button btnLoadBannerInnerImage;
    private Label lblFooterBanner;
    private PictureBox picFooterBanner;
    private PictureBox picBannerFrameColor;
    private Panel panelStep4;
    private PictureBox picShuffleProductCode;
    private Label label21;
    private Label label20;
    private Label label19;
    private TextBox txtTitleID;
    private TextBox txtProductCode;
    private PictureBox picShuffleUniqueID;
    public PictureBox picOhana;
    private Label label18;
    private CheckBox chkImportFooterBanner;
    private Label label22;
    private Button btnExport;
    private CheckBox chkImportBannerBin;
    private PictureBox picBannerInnerImage;
    private TextBox txtGamePublisher;
    private Label label5;
    private Label label6;
    private Label label7;
    private PictureBox pictureBox3;
    private PictureBox pictureBox5;
    private PictureBox picIcon24;
    private PictureBox picIcon48;
    private Button btnLoadIcon;
    private Label label8;
    private ListBox lstInterpolation1;
    private Label label9;
    private Label label15;
    private Label label23;
    private CheckBox chkImportIconBin;
    private Panel panelStep2;
    private Label label25;
    private Label label24;
    private TextBox txtLongName;
    private Label label4;
    private Label label2;
    private TextBox txtShortName;
    private Label lblSummaryShortName;
    private Label lblSummaryLongName;
    private Label label29;
    private Button btnBannerStyle;
    private ProgressBar progressBar1;
    private CheckBox chkHeightStretch;
    private GroupBox groupBox1;
    private RadioButton radPixelPerfectPAL;
    private RadioButton radFullScreen;
    private PictureBox picScreenPreview;
    private PictureBox pic3DSBackground;
    private RadioButton radPixelPerfectNTSC;
    private Button button1;
    private CheckBox chkEnableRewind;
    private PictureBox picBottomScreenPreview;
    private GroupBox groupBox2;
    private ListBox lstBottomScreen;
    private Label label17;
    private GroupBox groupBox3;
    private Label label27;
    private TextBox txtCustomResolutionHeight;
    private Label label26;
    private TextBox txtCustomResolutionWidth;
    private RadioButton radCustomResolution;
    private CheckBox chkAutoSaveLoadState;
    private Label label28;

    public frmMain()
    {
      this.InitializeComponent();
      int x = this.picBannerInnerImage.Left - this.picBannerFrameColor.Left;
      int y = this.picBannerInnerImage.Top - this.picBannerFrameColor.Top;
      this.picBannerFrameColor.Controls.Add((Control) this.picBannerInnerImage);
      this.picBannerInnerImage.Location = new Point(x, y);
      this.picBannerInnerImage.BackColor = Color.Transparent;
      Point point = this.picFooterBanner.PointToClient(this.panelStep3.PointToScreen(this.lblFooterBanner.Location));
      this.lblFooterBanner.Parent = (Control) this.picFooterBanner;
      this.lblFooterBanner.Location = point;
      this.lblFooterBanner.BackColor = Color.Transparent;
    }

    private void btnNextStep_Click(object sender, EventArgs e)
    {
      if ((int) this.actualStep < 4)
      {
        this.actualStep = (byte) ((uint) this.actualStep + 1U);
        this.setStep((int) this.actualStep);
      }
      else
      {
        if ((int) this.actualStep != 4)
          return;
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "CIA File (*.cia)|*.cia|All Files|*";
        if (saveFileDialog.ShowDialog() != DialogResult.OK)
          return;
        FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
        string str1 = DateTime.Now.ToString("yyyyMMddHHmmssffff");
        if (!Directory.Exists(Path.GetTempPath() + "\\timeStamp"))
          Directory.CreateDirectory(Path.GetTempPath() + "\\" + str1);
        if (System.IO.File.Exists(saveFileDialog.FileName))
          System.IO.File.Delete(saveFileDialog.FileName);
        this.progressBar1.Maximum = 18;
        this.progressBar1.Value = 0;
        string str2 = Path.GetTempPath() + str1;
        byte[] bytes1 = !this.usingCustomIconBin ? this.CreateIconBinary(this.iconBitmap, this.lstInterpolation1.SelectedIndex) : this.importedCustomIconBin;
        ++this.progressBar1.Value;
        byte[] bytes2 = !this.usingCustomBannerBin ? this.CreateBannerBinary(this.bannerInnerBitmap, this.lstInterpolation2.SelectedIndex) : this.importedCustomBannerBin;
        ++this.progressBar1.Value;
        System.IO.File.WriteAllBytes(str2 + "\\3dstool.exe", Resources._3dstool);
        Utils.Platform platform = Utils.GetPlatform();
        if (platform == Utils.Platform.X64)
          System.IO.File.WriteAllBytes(str2 + "\\ctrtool.exe", Resources._ctrtool);
        else
          System.IO.File.WriteAllBytes(str2 + "\\ctrtool.exe", Resources._ctrtool32);
        Directory.CreateDirectory(str2 + "\\extracted");
        System.IO.File.WriteAllBytes(str2 + "\\BlankFile.cia", Resources.BlankFile);
        ProcessStartInfo startInfo1 = new ProcessStartInfo(str2 + "\\ctrtool.exe");
        int num1 = 1;
        startInfo1.CreateNoWindow = num1 != 0;
        string str3 = str2;
        startInfo1.WorkingDirectory = str3;
        int num2 = 0;
        startInfo1.UseShellExecute = num2 != 0;
        int num3 = 1;
        startInfo1.RedirectStandardError = num3 != 0;
        string str4 = "--content=DecryptedApp \"BlankFile.cia\"";
        startInfo1.Arguments = str4;
        Process process1 = Process.Start(startInfo1);
        process1.WaitForExit();
        process1.StandardError.ReadToEnd();
        int exitCode1 = process1.ExitCode;
        process1.Close();
        ++this.progressBar1.Value;
        System.IO.File.Move(str2 + "\\DecryptedApp.0000.0f5a12c3", str2 + "\\extracted\\DecryptedPartition0.bin");
        ProcessStartInfo startInfo2 = new ProcessStartInfo(str2 + "\\3dstool.exe");
        int num4 = 1;
        startInfo2.CreateNoWindow = num4 != 0;
        string str5 = str2 + "\\extracted";
        startInfo2.WorkingDirectory = str5;
        int num5 = 0;
        startInfo2.UseShellExecute = num5 != 0;
        int num6 = 1;
        startInfo2.RedirectStandardError = num6 != 0;
        string str6 = "-xtf cxi DecryptedPartition0.bin --header HeaderNCCH0.bin --exh DecryptedExHeader.bin --exefs DecryptedExeFS.bin --romfs DecryptedRomFS.bin --logo LogoLZ.bin --plain PlainRGN.bin";
        startInfo2.Arguments = str6;
        Process process2 = Process.Start(startInfo2);
        process2.WaitForExit();
        process2.StandardError.ReadToEnd();
        int exitCode2 = process2.ExitCode;
        process2.Close();
        ++this.progressBar1.Value;
        System.IO.File.Delete(str2 + "\\BlankFile.cia");
        System.IO.File.Delete(str2 + "\\extracted\\DecryptedPartition0.bin");
        ProcessStartInfo startInfo3 = new ProcessStartInfo(str2 + "\\3dstool.exe");
        int num7 = 1;
        startInfo3.CreateNoWindow = num7 != 0;
        string str7 = str2 + "\\extracted";
        startInfo3.WorkingDirectory = str7;
        int num8 = 0;
        startInfo3.UseShellExecute = num8 != 0;
        int num9 = 1;
        startInfo3.RedirectStandardError = num9 != 0;
        string str8 = "-xutf exefs DecryptedExeFS.bin --exefs-dir ExtractedExeFS --header \"HeaderExeFS.bin\"";
        startInfo3.Arguments = str8;
        Process process3 = Process.Start(startInfo3);
        process3.WaitForExit();
        process3.StandardError.ReadToEnd();
        int exitCode3 = process3.ExitCode;
        process3.Close();
        ++this.progressBar1.Value;
        ProcessStartInfo startInfo4 = new ProcessStartInfo(str2 + "\\3dstool.exe");
        int num10 = 1;
        startInfo4.CreateNoWindow = num10 != 0;
        string str9 = str2 + "\\extracted";
        startInfo4.WorkingDirectory = str9;
        int num11 = 0;
        startInfo4.UseShellExecute = num11 != 0;
        int num12 = 1;
        startInfo4.RedirectStandardError = num12 != 0;
        string str10 = "-xtf romfs DecryptedRomFS.bin --romfs-dir ExtractedRomFS";
        startInfo4.Arguments = str10;
        Process process4 = Process.Start(startInfo4);
        process4.WaitForExit();
        process4.StandardError.ReadToEnd();
        int exitCode4 = process4.ExitCode;
        process4.Close();
        ++this.progressBar1.Value;
        System.IO.File.Delete(str2 + "\\extracted\\ExtractedRomFS\\rom.bin");
        System.IO.File.WriteAllBytes(str2 + "\\extracted\\ExtractedRomFS\\rom.bin", this.fileGEN);
        ++this.progressBar1.Value;
        for (int index1 = 0; index1 <= 10; ++index1)
        {
          object[] objArray = new object[4];
          int index2 = 0;
          string str11 = str2;
          objArray[index2] = (object) str11;
          int index3 = 1;
          string str12 = "\\extracted\\ExtractedRomFS\\bottom_";
          objArray[index3] = (object) str12;
          int index4 = 2;
          objArray[index4] = index1;
          int index5 = 3;
          string str13 = ".bin";
          objArray[index5] = (object) str13;
          System.IO.File.Delete(string.Concat(objArray));
        }
        System.IO.File.WriteAllBytes(str2 + "\\magick.exe", Resources.magick);
        switch (this.lstBottomScreen.SelectedIndex)
        {
          case 1:
            Resources.bottom_en.Save(str2 + "\\bottom.bmp");
            break;
          case 2:
            Resources.bottom_de.Save(str2 + "\\bottom.bmp");
            break;
          case 3:
            Resources.bottom_es.Save(str2 + "\\bottom.bmp");
            break;
          case 4:
            Resources.bottom_fr.Save(str2 + "\\bottom.bmp");
            break;
          case 5:
            Resources.bottom_it.Save(str2 + "\\bottom.bmp");
            break;
          case 6:
            Resources.bottom_ja.Save(str2 + "\\bottom.bmp");
            break;
          case 7:
            Resources.bottom_nl.Save(str2 + "\\bottom.bmp");
            break;
          case 8:
            Resources.bottom_pt.Save(str2 + "\\bottom.bmp");
            break;
          case 9:
            Resources.bottom_ru.Save(str2 + "\\bottom.bmp");
            break;
          case 10:
            this.importedCustomBottomScreen.Save(str2 + "\\bottom.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            break;
        }
        ProcessStartInfo startInfo5 = new ProcessStartInfo(str2 + "\\magick.exe");
        int num13 = 1;
        startInfo5.CreateNoWindow = num13 != 0;
        string str14 = str2;
        startInfo5.WorkingDirectory = str14;
        int num14 = 0;
        startInfo5.UseShellExecute = num14 != 0;
        int num15 = 1;
        startInfo5.RedirectStandardError = num15 != 0;
        string str15 = "bottom.bmp -separate -reverse -channel RGB -combine -rotate 90 bottom.rgb";
        startInfo5.Arguments = str15;
        Process process5 = Process.Start(startInfo5);
        process5.WaitForExit();
        process5.StandardError.ReadToEnd();
        int exitCode5 = process5.ExitCode;
        process5.Close();
        System.IO.File.Move(str2 + "\\bottom.rgb", str2 + "\\extracted\\ExtractedRomFS\\bottom.bin");
        ++this.progressBar1.Value;
        System.IO.File.Delete(str2 + "\\extracted\\ExtractedRomFS\\path.txt");
        System.IO.File.WriteAllText(str2 + "\\extracted\\ExtractedRomFS\\path.txt", this.txtTitleID.Text.ToLower());
        ++this.progressBar1.Value;
        string str16 = System.IO.File.ReadAllText(str2 + "\\extracted\\ExtractedRomFS\\retroarch.cfg").Replace("libretro_info_path = \"sdmc:/retroarch/forwarders/ABCD\"", "libretro_info_path = \"sdmc:/retroarch/forwarders/" + this.txtTitleID.Text.ToLower() + "\"").Replace("savefile_directory = \"sdmc:/retroarch/forwarders/ABCD/savefiles\"", "savefile_directory = \"sdmc:/retroarch/forwarders/" + this.txtTitleID.Text.ToLower() + "/savefiles\"").Replace("savestate_directory = \"sdmc:/retroarch/forwarders/ABCD/savestates\"", "savestate_directory = \"sdmc:/retroarch/forwarders/" + this.txtTitleID.Text.ToLower() + "/savestates\"").Replace("aspect_ratio_index = \"0\"", "aspect_ratio_index = \"22\"");
        int num16 = 0;
        int num17 = 0;
        if (this.radPixelPerfectPAL.Checked)
        {
          str16 = str16.Replace("custom_viewport_width = \"400\"", "custom_viewport_width = \"320\"").Replace("custom_viewport_height = \"240\"", "custom_viewport_height = \"240\"");
          num16 = 40;
          num17 = 0;
        }
        else if (this.radPixelPerfectNTSC.Checked)
        {
          str16 = str16.Replace("custom_viewport_width = \"400\"", "custom_viewport_width = \"320\"").Replace("custom_viewport_height = \"240\"", "custom_viewport_height = \"224\"");
          num16 = 40;
          num17 = 8;
        }
        else if (this.radFullScreen.Checked)
        {
          str16 = str16.Replace("custom_viewport_width = \"400\"", "custom_viewport_width = \"400\"").Replace("custom_viewport_height = \"240\"", "custom_viewport_height = \"240\"");
          num16 = 0;
          num17 = 0;
        }
        else if (this.radCustomResolution.Checked)
        {
          str16 = str16.Replace("custom_viewport_width = \"400\"", "custom_viewport_width = \"" + this.txtCustomResolutionWidth.Text + "\"").Replace("custom_viewport_height = \"240\"", "custom_viewport_height = \"" + this.txtCustomResolutionHeight.Text + "\"");
          num16 = 200 - Convert.ToInt32(this.txtCustomResolutionWidth.Text) / 2;
          num17 = 120 - Convert.ToInt32(this.txtCustomResolutionHeight.Text) / 2;
        }
        string str17 = str16.Replace("custom_viewport_x = \"0\"", "custom_viewport_x = \"" + (object) num16 + "\"").Replace("custom_viewport_y = \"0\"", "custom_viewport_y = \"" + (object) num17 + "\"");
        string str18 = !this.chkEnableRewind.Checked ? str17.Replace("rewind_enable = \"true\"", "rewind_enable = \"false\"") : str17.Replace("rewind_enable = \"true\"", "rewind_enable = \"true\"");
        if (this.chkAutoSaveLoadState.Checked)
          str18 = str18.Replace("savestate_auto_save = \"false\"", "savestate_auto_save = \"true\"").Replace("savestate_auto_load = \"false\"", "savestate_auto_load = \"true\"");
        string buttonB = this.MappedButtons.ButtonB;
        if (buttonB != "nul")
        {
          string str11 = buttonB + "btn";
          str18 = str18.Replace(str11 + " = \"nul\"", str11 + " = \"0\"");
        }
        string buttonY = this.MappedButtons.ButtonY;
        if (buttonY != "nul")
        {
          string str11 = buttonY + "btn";
          str18 = str18.Replace(str11 + " = \"nul\"", str11 + " = \"1\"");
        }
        string buttonSelect = this.MappedButtons.ButtonSelect;
        if (buttonSelect != "nul")
        {
          string str11 = buttonSelect + "btn";
          str18 = str18.Replace(str11 + " = \"nul\"", str11 + " = \"2\"");
        }
        string buttonStart = this.MappedButtons.ButtonStart;
        if (buttonStart != "nul")
        {
          string str11 = buttonStart + "btn";
          str18 = str18.Replace(str11 + " = \"nul\"", str11 + " = \"3\"");
        }
        string dpadUp = this.MappedButtons.DPadUp;
        if (dpadUp != "nul")
        {
          string str11 = dpadUp + "btn";
          str18 = str18.Replace(str11 + " = \"nul\"", str11 + " = \"4\"");
        }
        string dpadDown = this.MappedButtons.DPadDown;
        if (dpadDown != "nul")
        {
          string str11 = dpadDown + "btn";
          str18 = str18.Replace(str11 + " = \"nul\"", str11 + " = \"5\"");
        }
        string dpadLeft = this.MappedButtons.DPadLeft;
        if (dpadLeft != "nul")
        {
          string str11 = dpadLeft + "btn";
          str18 = str18.Replace(str11 + " = \"nul\"", str11 + " = \"6\"");
        }
        string dpadRight = this.MappedButtons.DPadRight;
        if (dpadRight != "nul")
        {
          string str11 = dpadRight + "btn";
          str18 = str18.Replace(str11 + " = \"nul\"", str11 + " = \"7\"");
        }
        string buttonA = this.MappedButtons.ButtonA;
        if (buttonA != "nul")
        {
          string str11 = buttonA + "btn";
          str18 = str18.Replace(str11 + " = \"nul\"", str11 + " = \"8\"");
        }
        string buttonX = this.MappedButtons.ButtonX;
        if (buttonX != "nul")
        {
          string str11 = buttonX + "btn";
          str18 = str18.Replace(str11 + " = \"nul\"", str11 + " = \"9\"");
        }
        string buttonL = this.MappedButtons.ButtonL;
        if (buttonL != "nul")
        {
          string str11 = buttonL + "btn";
          str18 = str18.Replace(str11 + " = \"nul\"", str11 + " = \"10\"");
        }
        string buttonR = this.MappedButtons.ButtonR;
        if (buttonR != "nul")
        {
          string str11 = buttonR + "btn";
          str18 = str18.Replace(str11 + " = \"nul\"", str11 + " = \"11\"");
        }
        string buttonZl = this.MappedButtons.ButtonZL;
        if (buttonZl != "nul")
        {
          string str11 = buttonZl + "btn";
          str18 = str18.Replace(str11 + " = \"nul\"", str11 + " = \"12\"");
        }
        string buttonZr = this.MappedButtons.ButtonZR;
        if (buttonZr != "nul")
        {
          string str11 = buttonZr + "btn";
          str18 = str18.Replace(str11 + " = \"nul\"", str11 + " = \"13\"");
        }
        string contents;
        if (this.MappedButtons.AnalogToDigital)
        {
          contents = str18.Replace("input_player1_analog_dpad_mode = \"1\"", "input_player1_analog_dpad_mode = \"1\"");
        }
        else
        {
          contents = str18.Replace("input_player1_analog_dpad_mode = \"1\"", "input_player1_analog_dpad_mode = \"0\"");
          string circlePadUp = this.MappedButtons.CirclePadUp;
          if (circlePadUp != "nul")
          {
            string str11 = circlePadUp + "axis";
            contents = contents.Replace(str11 + " = \"nul\"", str11 + " = \"-1\"");
          }
          string circlePadDown = this.MappedButtons.CirclePadDown;
          if (circlePadDown != "nul")
          {
            string str11 = circlePadDown + "axis";
            contents = contents.Replace(str11 + " = \"nul\"", str11 + " = \"+1\"");
          }
          string circlePadLeft = this.MappedButtons.CirclePadLeft;
          if (circlePadLeft != "nul")
          {
            string str11 = circlePadLeft + "axis";
            contents = contents.Replace(str11 + " = \"nul\"", str11 + " = \"-0\"");
          }
          string circlePadRight = this.MappedButtons.CirclePadRight;
          if (circlePadRight != "nul")
          {
            string str11 = circlePadRight + "axis";
            contents = contents.Replace(str11 + " = \"nul\"", str11 + " = \"+0\"");
          }
        }
        string cstickUp = this.MappedButtons.CStickUp;
        if (cstickUp != "nul")
        {
          string str11 = cstickUp + "axis";
          contents = contents.Replace(str11 + " = \"nul\"", str11 + " = \"-3\"");
        }
        string cstickDown = this.MappedButtons.CStickDown;
        if (cstickDown != "nul")
        {
          string str11 = cstickDown + "axis";
          contents = contents.Replace(str11 + " = \"nul\"", str11 + " = \"+3\"");
        }
        string cstickLeft = this.MappedButtons.CStickLeft;
        if (cstickLeft != "nul")
        {
          string str11 = cstickLeft + "axis";
          contents = contents.Replace(str11 + " = \"nul\"", str11 + " = \"-2\"");
        }
        string cstickRight = this.MappedButtons.CStickRight;
        if (cstickRight != "nul")
        {
          string str11 = cstickRight + "axis";
          contents = contents.Replace(str11 + " = \"nul\"", str11 + " = \"+2\"");
        }
        System.IO.File.Delete(str2 + "\\extracted\\ExtractedRomFS\\retroarch.cfg");
        System.IO.File.WriteAllText(str2 + "\\extracted\\ExtractedRomFS\\retroarch.cfg", contents);
        ++this.progressBar1.Value;
        System.IO.File.Delete(str2 + "\\extracted\\ExtractedExeFS\\icon.icn");
        System.IO.File.WriteAllBytes(str2 + "\\extracted\\ExtractedExeFS\\icon.icn", bytes1);
        ++this.progressBar1.Value;
        System.IO.File.Delete(str2 + "\\extracted\\ExtractedExeFS\\banner.bnr");
        System.IO.File.WriteAllBytes(str2 + "\\extracted\\ExtractedExeFS\\banner.bnr", bytes2);
        ++this.progressBar1.Value;
        byte[] numArray1 = Utils.StringToByteArray(this.txtTitleID.Text);
        byte[] bytes3 = Encoding.ASCII.GetBytes("GEN-P-" + this.txtProductCode.Text);
        byte[] numArray2 = new byte[2];
        int index6 = 0;
        int num18 = (int) numArray1[1];
        numArray2[index6] = (byte) num18;
        int index7 = 1;
        int num19 = (int) numArray1[0];
        numArray2[index7] = (byte) num19;
        byte[] dataWithReplacer = numArray2;
        byte[] bytes4 = Utils.ReplaceByOffset(Utils.ReplaceByOffset(Utils.ReplaceByOffset(System.IO.File.ReadAllBytes(str2 + "\\extracted\\DecryptedExHeader.bin"), dataWithReplacer, 457), dataWithReplacer, 513), dataWithReplacer, 1537);
        System.IO.File.WriteAllBytes(str2 + "\\extracted\\DecryptedExHeader.bin", bytes4);
        ++this.progressBar1.Value;
        byte[] bytes5 = Utils.ReplaceByOffset(Utils.ReplaceByOffset(Utils.ReplaceByOffset(System.IO.File.ReadAllBytes(str2 + "\\extracted\\HeaderNCCH0.bin"), dataWithReplacer, 265), dataWithReplacer, 281), bytes3, 336);
        System.IO.File.WriteAllBytes(str2 + "\\extracted\\HeaderNCCH0.bin", bytes5);
        ++this.progressBar1.Value;
        if (platform == Utils.Platform.X64)
          System.IO.File.WriteAllBytes(str2 + "\\makerom.exe", Resources._makerom);
        else
          System.IO.File.WriteAllBytes(str2 + "\\makerom.exe", Resources._makerom32);
        ProcessStartInfo startInfo6 = new ProcessStartInfo(str2 + "\\3dstool.exe");
        int num20 = 1;
        startInfo6.CreateNoWindow = num20 != 0;
        string str19 = str2 + "\\extracted";
        startInfo6.WorkingDirectory = str19;
        int num21 = 0;
        startInfo6.UseShellExecute = num21 != 0;
        int num22 = 1;
        startInfo6.RedirectStandardError = num22 != 0;
        string str20 = "-ctf romfs CustomRomFS.bin --romfs-dir ExtractedRomFS";
        startInfo6.Arguments = str20;
        Process process6 = Process.Start(startInfo6);
        process6.WaitForExit();
        process6.StandardError.ReadToEnd();
        int exitCode6 = process6.ExitCode;
        process6.Close();
        ++this.progressBar1.Value;
        ProcessStartInfo startInfo7 = new ProcessStartInfo(str2 + "\\3dstool.exe");
        int num23 = 1;
        startInfo7.CreateNoWindow = num23 != 0;
        string str21 = str2 + "\\extracted";
        startInfo7.WorkingDirectory = str21;
        int num24 = 0;
        startInfo7.UseShellExecute = num24 != 0;
        int num25 = 1;
        startInfo7.RedirectStandardError = num25 != 0;
        string str22 = "-ctf exefs CustomExeFS.bin --exefs-dir ExtractedExeFS --header HeaderExeFS.bin";
        startInfo7.Arguments = str22;
        Process process7 = Process.Start(startInfo7);
        process7.WaitForExit();
        process7.StandardError.ReadToEnd();
        int exitCode7 = process7.ExitCode;
        process7.Close();
        ++this.progressBar1.Value;
        ProcessStartInfo startInfo8 = new ProcessStartInfo(str2 + "\\3dstool.exe");
        int num26 = 1;
        startInfo8.CreateNoWindow = num26 != 0;
        string str23 = str2 + "\\extracted";
        startInfo8.WorkingDirectory = str23;
        int num27 = 0;
        startInfo8.UseShellExecute = num27 != 0;
        int num28 = 1;
        startInfo8.RedirectStandardError = num28 != 0;
        string str24 = "-ctf cxi CustomPartition0.bin --header HeaderNCCH0.bin --exh DecryptedExHeader.bin --exefs CustomExeFS.bin --romfs CustomRomFS.bin --logo LogoLZ.bin --plain PlainRGN.bin";
        startInfo8.Arguments = str24;
        Process process8 = Process.Start(startInfo8);
        process8.WaitForExit();
        process8.StandardError.ReadToEnd();
        int exitCode8 = process8.ExitCode;
        process8.Close();
        ++this.progressBar1.Value;
        ProcessStartInfo startInfo9 = new ProcessStartInfo(str2 + "\\makerom.exe");
        int num29 = 1;
        startInfo9.CreateNoWindow = num29 != 0;
        string str25 = str2 + "\\extracted";
        startInfo9.WorkingDirectory = str25;
        int num30 = 0;
        startInfo9.UseShellExecute = num30 != 0;
        int num31 = 1;
        startInfo9.RedirectStandardError = num31 != 0;
        string str26 = "-f cia -content CustomPartition0.bin:0:0x00 -o \"" + fileInfo.FullName + "\"";
        startInfo9.Arguments = str26;
        Process process9 = Process.Start(startInfo9);
        process9.WaitForExit();
        process9.StandardError.ReadToEnd();
        int exitCode9 = process9.ExitCode;
        process9.Close();
        ++this.progressBar1.Value;
        System.IO.File.Delete(str2 + "\\3dstool.exe");
        System.IO.File.Delete(str2 + "\\ctrtool.exe");
        System.IO.File.Delete(str2 + "\\makerom.exe");
        System.IO.File.Delete(str2 + "\\img_converter.exe");
        System.IO.File.Delete(str2 + "\\bottom.bmp");
        System.IO.File.Delete(str2 + "\\extracted\\CustomExeFS.bin");
        System.IO.File.Delete(str2 + "\\extracted\\CustomPartition0.bin");
        System.IO.File.Delete(str2 + "\\extracted\\CustomRomFS.bin");
        System.IO.File.Delete(str2 + "\\extracted\\DecryptedExeFS.bin");
        System.IO.File.Delete(str2 + "\\extracted\\DecryptedExHeader.bin");
        System.IO.File.Delete(str2 + "\\extracted\\DecryptedRomFS.bin");
        System.IO.File.Delete(str2 + "\\extracted\\HeaderExeFS.bin");
        System.IO.File.Delete(str2 + "\\extracted\\HeaderNCCH0.bin");
        System.IO.File.Delete(str2 + "\\extracted\\LogoLZ.bin");
        System.IO.File.Delete(str2 + "\\extracted\\ExtractedExeFS\\code.bin");
        System.IO.File.Delete(str2 + "\\extracted\\ExtractedExeFS\\banner.bnr");
        System.IO.File.Delete(str2 + "\\extracted\\ExtractedExeFS\\icon.icn");
        System.IO.File.Delete(str2 + "\\extracted\\ExtractedExeFS\\logo.bcma.lz");
        Directory.Delete(str2 + "\\extracted\\ExtractedExeFS");
        System.IO.File.Delete(str2 + "\\extracted\\ExtractedRomFS\\bottom.bin");
        System.IO.File.Delete(str2 + "\\extracted\\ExtractedRomFS\\path.txt");
        System.IO.File.Delete(str2 + "\\extracted\\ExtractedRomFS\\retroarch.cfg");
        System.IO.File.Delete(str2 + "\\extracted\\ExtractedRomFS\\rom.bin");
        Directory.Delete(str2 + "\\extracted\\ExtractedRomFS");
        Directory.Delete(str2 + "\\extracted");
        SystemSounds.Beep.Play();
        if (MessageBox.Show("CIA created at " + (object) fileInfo.Directory + "\nWould you like to open the output folder?", "Done!", MessageBoxButtons.YesNo) != DialogResult.Yes)
          return;
        string fullName1 = fileInfo.Directory.FullName;
        string[] strArray = new string[1];
        int index8 = 0;
        string fullName2 = fileInfo.FullName;
        strArray[index8] = fullName2;
        Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.NativeMethods.OpenFolderAndSelectFiles(fullName1, strArray);
      }
    }

    private void setStep(int step)
    {
      switch (step)
      {
        case 1:
          this.lblStep.Text = "Step 1. Rom file selection";
          this.panelStep1.Visible = true;
          this.panelStep2.Visible = false;
          this.panelStep3.Visible = false;
          this.panelStep4.Visible = false;
          this.btnPreviousStep.Visible = false;
          this.btnPreviousStep.Text = "";
          this.btnNextStep.Visible = true;
          this.btnNextStep.Text = "Next step (icon and name)";
          this.btnExport.Visible = false;
          this.enableNextButtonWithCondition(this.fileGEN != null, 1);
          break;
        case 2:
          this.lblStep.Text = "Step 2. Game icon and name";
          this.panelStep1.Visible = false;
          this.panelStep2.Visible = true;
          this.panelStep3.Visible = false;
          this.panelStep4.Visible = false;
          this.btnPreviousStep.Visible = true;
          this.btnPreviousStep.Text = "Previous step (rom file)";
          this.btnNextStep.Visible = true;
          this.btnNextStep.Text = "Next step (3d banner)";
          this.btnExport.Text = "Export icon.bin";
          this.btnExport.Visible = true;
          this.enableNextButtonWithCondition(this.longName != "" && this.shortName != "" && (this.gamePublisher != "" && this.iconBitmap != null) || this.usingCustomIconBin, 2);
          break;
        case 3:
          this.lblStep.Text = "Step 3. Genesis/Mega Drive 3D banners";
          this.panelStep1.Visible = false;
          this.panelStep2.Visible = false;
          this.panelStep3.Visible = true;
          this.panelStep4.Visible = false;
          this.btnPreviousStep.Visible = true;
          this.btnPreviousStep.Text = "Previous step (icon and name)";
          this.btnNextStep.Visible = true;
          this.btnNextStep.Text = "Next step (parameters)";
          this.btnExport.Text = "Export banner.bin";
          this.btnExport.Visible = true;
          this.enableNextButtonWithCondition(this.bannerInnerBitmap != null && (this.txtFooterBanner.Text != "" || this.usingCustomFooterBanner) || this.usingCustomBannerBin, 3);
          break;
        case 4:
          this.lblStep.Text = "Step 4. RetroArch parameters";
          this.panelStep1.Visible = false;
          this.panelStep2.Visible = false;
          this.panelStep3.Visible = false;
          this.panelStep4.Visible = true;
          this.btnPreviousStep.Visible = true;
          this.btnPreviousStep.Text = "Previous step (3d banner)";
          this.btnNextStep.Visible = true;
          this.btnNextStep.Text = "Finish";
          this.btnExport.Visible = false;
          break;
      }
    }

    private void btnPreviousStep_Click(object sender, EventArgs e)
    {
      if ((int) this.actualStep <= 0)
        return;
      this.actualStep = (byte) ((uint) this.actualStep - 1U);
      this.setStep((int) this.actualStep);
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      this.lstBottomScreen.SelectedIndex = 0;
      this.MappedButtons = new Mapping3DS();
      this.picScreenPreview.Left = this.pic3DSBackground.Left + this.pic3DSBackground.Width / 2 - this.picScreenPreview.Width / 2;
      this.picScreenPreview.Top = this.pic3DSBackground.Top + this.pic3DSBackground.Height / 2 - this.picScreenPreview.Height / 2;
      this.setStep(1);
      this.lstInterpolation1.SelectedIndex = 3;
      this.lstInterpolation2.SelectedIndex = 3;
      this.txtProductCode.Text = Utils.RandomString(4, "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");
      this.txtTitleID.Text = this.GetRandomTitleID();
    }

    private byte[] CreateIconBinary(Bitmap iconImage, int interpolationIndex)
    {
      InterpolationMode mode;
      switch (interpolationIndex)
      {
        case 0:
          mode = InterpolationMode.Default;
          break;
        case 1:
          mode = InterpolationMode.NearestNeighbor;
          break;
        case 2:
          mode = InterpolationMode.HighQualityBilinear;
          break;
        case 3:
          mode = InterpolationMode.HighQualityBicubic;
          break;
        default:
          mode = InterpolationMode.Default;
          break;
      }
      Bitmap icon48 = Resources.icon48;
      Bitmap bitmap1 = Utils.FillColor(new Bitmap(40, 40), Color.Black, new Rectangle(0, 0, 40, 40));
      Graphics graphics1 = Graphics.FromImage((Image) bitmap1);
      Bitmap bitmap2 = !this.chkHeightStretch.Checked ? Utils.ResizeBitmap(iconImage, 44, iconImage.Height * 44 / iconImage.Width, mode, false) : Utils.ResizeBitmap(iconImage, iconImage.Width * 44 / iconImage.Height, 44, mode, false);
      Bitmap bitmap3 = bitmap2;
      Rectangle destRect1 = new Rectangle(20 - bitmap2.Width / 2, 20 - bitmap2.Height / 2, bitmap2.Width, bitmap2.Height);
      int srcX1 = 0;
      int srcY1 = 0;
      int width1 = bitmap2.Width;
      int height1 = bitmap2.Height;
      int num1 = 2;
      graphics1.DrawImage((Image) bitmap3, destRect1, srcX1, srcY1, width1, height1, (GraphicsUnit) num1);
      Graphics.FromImage((Image) icon48).DrawImage((Image) bitmap1, new Rectangle(4, 4, 40, 40));
      int num2 = 3;
      int num3 = 1;
      byte[] dataWithReplacer1 = Textures.FromBitmap(icon48, (Textures.ImageFormat) num2, num3 != 0);
      Bitmap icon24 = Resources.icon24;
      Bitmap bitmap4 = Utils.FillColor(new Bitmap(20, 20), Color.Black, new Rectangle(0, 0, 20, 20));
      Graphics graphics2 = Graphics.FromImage((Image) bitmap4);
      Bitmap bitmap5 = !this.chkHeightStretch.Checked ? Utils.ResizeBitmap(iconImage, 22, iconImage.Height * 22 / iconImage.Width, mode, false) : Utils.ResizeBitmap(iconImage, iconImage.Width * 22 / iconImage.Height, 22, mode, false);
      Bitmap bitmap6 = bitmap5;
      Rectangle destRect2 = new Rectangle(10 - bitmap5.Width / 2, 10 - bitmap5.Height / 2, bitmap5.Width, bitmap5.Height);
      int srcX2 = 0;
      int srcY2 = 0;
      int width2 = bitmap5.Width;
      int height2 = bitmap5.Height;
      int num4 = 2;
      graphics2.DrawImage((Image) bitmap6, destRect2, srcX2, srcY2, width2, height2, (GraphicsUnit) num4);
      Graphics.FromImage((Image) icon24).DrawImage((Image) bitmap4, new Rectangle(2, 2, 20, 20));
      int num5 = 3;
      int num6 = 1;
      byte[] dataWithReplacer2 = Textures.FromBitmap(icon24, (Textures.ImageFormat) num5, num6 != 0);
      byte[] dataToModify = new byte[Resources.iconbin.Length];
      Resources.iconbin.CopyTo((Array) dataToModify, 0);
      byte[] dataWithReplacer3 = Utils.FillWithZeroUntil(Encoding.Unicode.GetBytes(this.shortName), 128);
      byte[] dataWithReplacer4 = Utils.FillWithZeroUntil(Encoding.Unicode.GetBytes(this.longName), 256);
      byte[] dataWithReplacer5 = Utils.FillWithZeroUntil(Encoding.Unicode.GetBytes(this.gamePublisher), 128);
      for (int index = 0; index < 16; ++index)
        dataToModify = Utils.ReplaceByOffset(Utils.ReplaceByOffset(Utils.ReplaceByOffset(dataToModify, dataWithReplacer3, 8 + index * 512), dataWithReplacer4, 136 + index * 512), dataWithReplacer5, 392 + index * 512);
      return Utils.ReplaceByOffset(Utils.ReplaceByOffset(dataToModify, dataWithReplacer2, 8256), dataWithReplacer1, 9408);
    }

    private byte[] CreateBannerBinary(Bitmap bannerImage, int interpolationIndex)
    {
      InterpolationMode mode;
      switch (interpolationIndex)
      {
        case 0:
          mode = InterpolationMode.Default;
          break;
        case 1:
          mode = InterpolationMode.NearestNeighbor;
          break;
        case 2:
          mode = InterpolationMode.HighQualityBilinear;
          break;
        case 3:
          mode = InterpolationMode.HighQualityBicubic;
          break;
        default:
          mode = InterpolationMode.Default;
          break;
      }
      Bitmap commoN1 = Resources.COMMON1;
      Graphics graphics = Graphics.FromImage((Image) commoN1);
      Bitmap bitmap1 = Utils.RemoveTransparency(Utils.ResizeBitmap(bannerImage, 120, 101, mode, false), Color.White);
      Bitmap bitmap2 = bitmap1;
      Rectangle destRect = new Rectangle(4, 6, 120, 101);
      int srcX = 0;
      int srcY = 0;
      int width1 = bitmap1.Width;
      int height1 = bitmap1.Height;
      int num1 = 2;
      graphics.DrawImage((Image) bitmap2, destRect, srcX, srcY, width1, height1, (GraphicsUnit) num1);
      Bitmap Picture1 = new Bitmap((Image) commoN1);
      int width2 = 64;
      int height2 = 64;
      int num2 = (int) mode;
      int num3 = 1;
      Bitmap sourceBMP1 = Utils.ResizeBitmap(commoN1, width2, height2, (InterpolationMode) num2, num3 != 0);
      Bitmap Picture2 = new Bitmap((Image) sourceBMP1);
      int width3 = 32;
      int height3 = 32;
      int num4 = (int) mode;
      int num5 = 1;
      Bitmap sourceBMP2 = Utils.ResizeBitmap(sourceBMP1, width3, height3, (InterpolationMode) num4, num5 != 0);
      Bitmap Picture3 = new Bitmap((Image) sourceBMP2);
      int width4 = 16;
      int height4 = 16;
      int num6 = (int) mode;
      int num7 = 1;
      Bitmap Picture4 = new Bitmap((Image) Utils.ResizeBitmap(sourceBMP2, width4, height4, (InterpolationMode) num6, num7 != 0));
      Bitmap Picture5;
      if (this.usingCustomFooterBanner)
      {
        Picture5 = this.importedCustomFooterBanner;
      }
      else
      {
        this.picFooterBanner.CreateGraphics();
        Bitmap bitmap3 = new Bitmap(this.picFooterBanner.Width, this.picFooterBanner.Height);
        this.picFooterBanner.DrawToBitmap(bitmap3, new Rectangle(0, 0, this.picFooterBanner.Width, this.picFooterBanner.Height));
        bitmap3.MakeTransparent(Color.Red);
        Picture5 = new Bitmap((Image) Utils.MakeGrayscale3(bitmap3));
      }
      byte[] dataToModify = Utils.ReplaceByOffset(Utils.ReplaceByOffset(Resources.bannercgfx, Textures.FromBitmap(Picture1, Textures.ImageFormat.RGBA8, false), 70144), Textures.FromBitmap(Picture2, Textures.ImageFormat.RGBA8, false), 135680);
      int num8 = 0;
      int num9 = 0;
      byte[] dataWithReplacer = Textures.FromBitmap(Picture4, (Textures.ImageFormat) num8, num9 != 0);
      byte[] numArray1 = Utils.ReplaceByOffset(Utils.ReplaceByOffset(Utils.ReplaceByOffset(dataToModify, dataWithReplacer, 156160), Textures.FromBitmap(Picture3, Textures.ImageFormat.RGBA8, false), 152064), Textures.FromBitmap(Picture5, Textures.ImageFormat.LA8, false), 37376);
      byte[] bytes = new byte[numArray1.Length];
      Array.Copy((Array) numArray1, (Array) bytes, numArray1.Length);
      string path = Path.GetTempPath() + DateTime.Now.ToString("yyyyMMddHHmmssffff");
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
      if (!Directory.Exists(path + "\\extracted_banner"))
        Directory.CreateDirectory(path + "\\extracted_banner");
      if (System.IO.File.Exists(path + "\\extracted_banner\\banner0.bcmdl"))
        System.IO.File.Delete(path + "\\extracted_banner\\banner0.bcmdl");
      System.IO.File.WriteAllBytes(path + "\\extracted_banner\\banner0.bcmdl", bytes);
      if (System.IO.File.Exists(path + "\\extracted_banner\\banner.bcwav"))
        System.IO.File.Delete(path + "\\extracted_banner\\banner.bcwav");
      if (System.IO.File.Exists(path + "\\extracted_banner\\banner.cbmd"))
        System.IO.File.Delete(path + "\\extracted_banner\\banner.cbmd");
      System.IO.File.WriteAllBytes(path + "\\extracted_banner\\banner.bcwav", Resources.bannerbcwav);
      System.IO.File.WriteAllBytes(path + "\\extracted_banner\\banner.cbmd", Resources.bannercbmd);
      System.IO.File.WriteAllBytes(path + "\\3dstool.exe", Resources._3dstool);
      if (System.IO.File.Exists(path + "\\banner.bin"))
        System.IO.File.Delete(path + "\\banner.bin");
      ProcessStartInfo startInfo = new ProcessStartInfo(path + "\\3dstool.exe");
      int num10 = 1;
      startInfo.CreateNoWindow = num10 != 0;
      string str1 = path;
      startInfo.WorkingDirectory = str1;
      int num11 = 0;
      startInfo.UseShellExecute = num11 != 0;
      int num12 = 1;
      startInfo.RedirectStandardError = num12 != 0;
      string str2 = "-c -t banner -f banner.bin --banner-dir extracted_banner\\";
      startInfo.Arguments = str2;
      Process process = Process.Start(startInfo);
      process.WaitForExit();
      process.StandardError.ReadToEnd();
      int exitCode = process.ExitCode;
      process.Close();
      byte[] numArray2 = System.IO.File.ReadAllBytes(path + "\\banner.bin");
      System.IO.File.Delete(path + "\\3dstool.exe");
      System.IO.File.Delete(path + "\\banner.bin");
      System.IO.File.Delete(path + "\\extracted_banner\\banner.bcwav");
      System.IO.File.Delete(path + "\\extracted_banner\\banner.cbmd");
      for (int index1 = 0; index1 <= 13; ++index1)
      {
        object[] objArray1 = new object[4];
        int index2 = 0;
        string str3 = path;
        objArray1[index2] = (object) str3;
        int index3 = 1;
        string str4 = "\\extracted_banner\\banner";
        objArray1[index3] = (object) str4;
        int index4 = 2;
        objArray1[index4] = index1;
        int index5 = 3;
        string str5 = ".bcmdl";
        objArray1[index5] = (object) str5;
        if (System.IO.File.Exists(string.Concat(objArray1)))
        {
          object[] objArray2 = new object[4];
          int index6 = 0;
          string str6 = path;
          objArray2[index6] = (object) str6;
          int index7 = 1;
          string str7 = "\\extracted_banner\\banner";
          objArray2[index7] = (object) str7;
          int index8 = 2;
          objArray2[index8] = index1;
          int index9 = 3;
          string str8 = ".bcmdl";
          objArray2[index9] = (object) str8;
          System.IO.File.Delete(string.Concat(objArray2));
        }
      }
      return numArray2;
    }

    private void btnLoadIcon_Click(object sender, EventArgs e)
    {
      if (this.usingCustomIconBin)
        return;
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "All supported files (*.png, *.bmp, *.jpg, *.gif) | *.png;*.bmp;*.jpg;*.gif; | PNG Files (*.png) | *.png; | BMP Files (*.bmp) |*.bmp; | JPG Files (*.jpg) | *.jpg; | GIF Files (*.gif) | *.gif; | All Files|*";
      openFileDialog.Multiselect = false;
      this.picIcon24.Image = (Image) null;
      this.picIcon48.Image = (Image) null;
      this.picSummaryIcon.Image = (Image) null;
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        string extension = Path.GetExtension(openFileDialog.FileName);
        if (extension.ToLower() == ".png" || extension.ToLower() == ".bmp" || (extension.ToLower() == ".jpg" || extension.ToLower() == ".gif"))
        {
          this.iconBitmap = new Bitmap(Image.FromFile(openFileDialog.FileName));
          GC.Collect();
          GC.WaitForPendingFinalizers();
        }
        else
        {
          int num = (int) MessageBox.Show("This program only supports icons with .png, .bmp, .jpg or .gif extension.", "Stop!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          this.iconBitmap = (Bitmap) null;
          GC.Collect();
          GC.WaitForPendingFinalizers();
        }
      }
      this.picIcon24.Refresh();
      this.picIcon48.Refresh();
      this.picSummaryIcon.Refresh();
      if (!this.usingCustomBannerBin)
      {
        this.bannerInnerBitmap = this.iconBitmap;
        if (this.iconBitmap != null)
          this.picBannerInnerImage.Image = (Image) this.DistortedInnerImage(this.iconBitmap);
      }
      this.picSummaryIcon.Visible = this.iconBitmap != null;
      this.pictureBox2.Visible = this.iconBitmap != null;
      this.enableNextButtonWithCondition(this.longName != "" && this.shortName != "" && (this.gamePublisher != "" && this.iconBitmap != null) || this.usingCustomIconBin, 2);
    }

    private void txtGamePublisher_TextChanged(object sender, EventArgs e)
    {
      if (this.usingCustomIconBin)
        return;
      string text = this.txtGamePublisher.Text;
      char[] chArray = new char[1];
      int index = 0;
      int num = 32;
      chArray[index] = (char) num;
      this.gamePublisher = text.Trim(chArray);
      this.lblSummaryGamePublisher.Text = this.gamePublisher;
      this.enableNextButtonWithCondition(this.longName != "" && this.shortName != "" && (this.gamePublisher != "" && this.iconBitmap != null) || this.usingCustomIconBin, 2);
    }

    private void enableNextButtonWithCondition(bool condition, int stepCheck)
    {
      if (stepCheck != (int) this.actualStep)
        return;
      if (condition)
      {
        this.btnNextStep.Enabled = true;
        this.btnExport.Enabled = true;
      }
      else
      {
        this.btnNextStep.Enabled = false;
        this.btnExport.Enabled = false;
      }
    }

    private void picIcon48_Paint(object sender, PaintEventArgs e)
    {
      if (this.usingCustomBannerBin)
        return;
      try
      {
        InterpolationMode mode;
        switch (this.lstInterpolation1.SelectedIndex)
        {
          case 0:
            mode = InterpolationMode.Default;
            break;
          case 1:
            mode = InterpolationMode.NearestNeighbor;
            break;
          case 2:
            mode = InterpolationMode.HighQualityBilinear;
            break;
          case 3:
            mode = InterpolationMode.HighQualityBicubic;
            break;
          default:
            mode = InterpolationMode.Default;
            break;
        }
        Bitmap bitmap = !this.chkHeightStretch.Checked ? Utils.ResizeBitmap(this.iconBitmap, 44, this.iconBitmap.Height * 44 / this.iconBitmap.Width - 1, mode, false) : Utils.ResizeBitmap(this.iconBitmap, this.iconBitmap.Width * 44 / this.iconBitmap.Height, 44, mode, false);
        e.Graphics.DrawImage((Image) bitmap, new Rectangle(20 - bitmap.Width / 2, 20 - bitmap.Height / 2, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel);
      }
      catch
      {
      }
    }

    private void lstInterpolation1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.usingCustomIconBin)
        return;
      this.picIcon24.Refresh();
      this.picIcon48.Refresh();
      this.picSummaryIcon.Refresh();
    }

    private void picIcon24_Paint(object sender, PaintEventArgs e)
    {
      if (this.usingCustomBannerBin)
        return;
      try
      {
        InterpolationMode mode;
        switch (this.lstInterpolation1.SelectedIndex)
        {
          case 0:
            mode = InterpolationMode.Default;
            break;
          case 1:
            mode = InterpolationMode.NearestNeighbor;
            break;
          case 2:
            mode = InterpolationMode.HighQualityBilinear;
            break;
          case 3:
            mode = InterpolationMode.HighQualityBicubic;
            break;
          default:
            mode = InterpolationMode.Default;
            break;
        }
        Bitmap bitmap = !this.chkHeightStretch.Checked ? Utils.ResizeBitmap(this.iconBitmap, 22, this.iconBitmap.Height * 22 / this.iconBitmap.Width - 1, mode, false) : Utils.ResizeBitmap(this.iconBitmap, this.iconBitmap.Width * 22 / this.iconBitmap.Height, 22, mode, false);
        e.Graphics.DrawImage((Image) bitmap, new Rectangle(10 - bitmap.Width / 2, 10 - bitmap.Height / 2, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel);
      }
      catch
      {
      }
    }

    private void picSummaryIcon_Paint(object sender, PaintEventArgs e)
    {
      if (this.usingCustomBannerBin)
        return;
      try
      {
        InterpolationMode mode;
        switch (this.lstInterpolation1.SelectedIndex)
        {
          case 0:
            mode = InterpolationMode.Default;
            break;
          case 1:
            mode = InterpolationMode.NearestNeighbor;
            break;
          case 2:
            mode = InterpolationMode.HighQualityBilinear;
            break;
          case 3:
            mode = InterpolationMode.HighQualityBicubic;
            break;
          default:
            mode = InterpolationMode.Default;
            break;
        }
        Bitmap bitmap = !this.chkHeightStretch.Checked ? Utils.ResizeBitmap(this.iconBitmap, 44, this.iconBitmap.Height * 44 / this.iconBitmap.Width - 1, mode, false) : Utils.ResizeBitmap(this.iconBitmap, this.iconBitmap.Width * 44 / this.iconBitmap.Height, 44, mode, false);
        e.Graphics.DrawImage((Image) bitmap, new Rectangle(20 - bitmap.Width / 2, 20 - bitmap.Height / 2, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel);
      }
      catch
      {
      }
    }

    private void btnLoadBannerInnerImage_Click(object sender, EventArgs e)
    {
      if (this.usingCustomBannerBin)
        return;
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "All supported files (*.png, *.bmp, *.jpg, *.gif)|*.png;*.bmp;*.jpg;*.gif|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files|*";
      openFileDialog.Multiselect = false;
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        string str = openFileDialog.SafeFileName.Substring(openFileDialog.SafeFileName.Length - 3);
        if (str.ToLower() == "png" || str.ToLower() == "bmp" || (str.ToLower() == "jpeg" || str.ToLower() == "jpg") || str.ToLower() == "gif")
        {
          this.picBannerInnerImage.Image = (Image) null;
          this.bannerInnerBitmap = new Bitmap(Image.FromFile(openFileDialog.FileName));
          GC.Collect();
          GC.WaitForPendingFinalizers();
        }
        else
        {
          int num = (int) MessageBox.Show("This program only supports icons with .png, .bmp, . jpeg, .jpg or .gif extension.", "Stop!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          this.bannerInnerBitmap = (Bitmap) null;
          GC.Collect();
          GC.WaitForPendingFinalizers();
        }
      }
      this.picBannerInnerImage.Image = (Image) this.DistortedInnerImage(this.bannerInnerBitmap);
      int num1;
      if (this.bannerInnerBitmap != null)
      {
        string text = this.txtFooterBanner.Text;
        char[] chArray = new char[1];
        int index = 0;
        int num2 = 32;
        chArray[index] = (char) num2;
        if (text.Trim(chArray) != "" || this.usingCustomFooterBanner)
        {
          num1 = 1;
          goto label_9;
        }
      }
      num1 = this.usingCustomBannerBin ? 1 : 0;
label_9:
      int stepCheck = 3;
      this.enableNextButtonWithCondition(num1 != 0, stepCheck);
    }

    private void picBannerInnerImage_Paint(object sender, PaintEventArgs e)
    {
      if (this.usingCustomBannerBin)
        return;
      try
      {
        InterpolationMode mode;
        switch (this.lstInterpolation2.SelectedIndex)
        {
          case 0:
            mode = InterpolationMode.Default;
            break;
          case 1:
            mode = InterpolationMode.NearestNeighbor;
            break;
          case 2:
            mode = InterpolationMode.HighQualityBilinear;
            break;
          case 3:
            mode = InterpolationMode.HighQualityBicubic;
            break;
          default:
            mode = InterpolationMode.Default;
            break;
        }
        Bitmap bitmap = Utils.RemoveTransparency(Utils.ResizeBitmap(this.bannerInnerBitmap, 80, 72, mode, false), Color.White);
        e.Graphics.DrawImage((Image) bitmap, new Rectangle(0, 0, 80, 72), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel);
      }
      catch
      {
      }
    }

    private void txtFooterBanner_TextChanged(object sender, EventArgs e)
    {
      if (this.usingCustomFooterBanner)
        return;
      Label label = this.lblFooterBanner;
      string text1 = this.txtFooterBanner.Text;
      char[] chArray1 = new char[1];
      int index1 = 0;
      int num1 = 32;
      chArray1[index1] = (char) num1;
      string str = text1.Trim(chArray1);
      label.Text = str;
      int num2;
      if (this.bannerInnerBitmap != null)
      {
        string text2 = this.txtFooterBanner.Text;
        char[] chArray2 = new char[1];
        int index2 = 0;
        int num3 = 32;
        chArray2[index2] = (char) num3;
        if (text2.Trim(chArray2) != "" || this.usingCustomFooterBanner)
        {
          num2 = 1;
          goto label_5;
        }
      }
      num2 = this.usingCustomBannerBin ? 1 : 0;
label_5:
      int stepCheck = 3;
      this.enableNextButtonWithCondition(num2 != 0, stepCheck);
    }

    private void txtBright_TextChanged(object sender, EventArgs e)
    {
      if (this.usingCustomBannerBin)
        return;
      if (this.usingCustomFooterBanner)
        return;
      try
      {
        int num = Convert.ToInt32(this.txtBright.Text);
        if (num < 0)
        {
          num = 0;
          this.txtBright.Text = "0";
        }
        else if (num > (int) byte.MaxValue)
        {
          num = (int) byte.MaxValue;
          this.txtBright.Text = "255";
        }
        this.lblFooterBanner.ForeColor = Color.FromArgb(num, num, num);
        this.trkBright.Value = num;
      }
      catch
      {
        this.txtBright.Text = "0";
      }
    }

    private void trkBright_Scroll(object sender, EventArgs e)
    {
      if (this.usingCustomBannerBin || this.usingCustomFooterBanner)
        return;
      int num = this.trkBright.Value;
      this.lblFooterBanner.ForeColor = Color.FromArgb(num, num, num);
      this.txtBright.Text = num.ToString();
    }

    private void lstInterpolation2_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.usingCustomBannerBin || this.bannerInnerBitmap == null)
        return;
      this.picBannerInnerImage.Image = (Image) this.DistortedInnerImage(this.bannerInnerBitmap);
    }

    private void picShuffleProductCode_Click(object sender, EventArgs e)
    {
      this.txtProductCode.Text = Utils.RandomString(4, "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");
    }

    private void picShuffleUniqueID_Click(object sender, EventArgs e)
    {
      this.txtTitleID.Text = this.GetRandomTitleID();
    }

    private void btnSelectFont_Click(object sender, EventArgs e)
    {
      if (this.usingCustomBannerBin || this.usingCustomFooterBanner)
        return;
      FontDialog fontDialog = new FontDialog();
      fontDialog.Font = this.lblFooterBanner.Font;
      if (fontDialog.ShowDialog() != DialogResult.OK)
        return;
      this.lblFooterBanner.Font = fontDialog.Font;
    }

    private void txtProductCode_TextChanged(object sender, EventArgs e)
    {
      this.txtProductCode.Text = this.txtProductCode.Text.ToUpper();
      char[] chArray = Enumerable.ToArray<char>((IEnumerable<char>) this.txtProductCode.Text);
      for (int index = 0; index < chArray.Length; ++index)
      {
        if (!Enumerable.Contains<char>((IEnumerable<char>) "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", chArray[index]))
          chArray[index] = '0';
      }
      this.txtProductCode.Text = string.Join<char>("", (IEnumerable<char>) chArray);
    }

    private void txtUniqueID_TextChanged(object sender, EventArgs e)
    {
      this.txtTitleID.Text = this.txtTitleID.Text.ToUpper();
      char[] chArray = Enumerable.ToArray<char>((IEnumerable<char>) this.txtTitleID.Text);
      for (int index = 0; index < chArray.Length; ++index)
      {
        if (!Enumerable.Contains<char>((IEnumerable<char>) "ABCDEF0123456789", chArray[index]))
          chArray[index] = '0';
      }
      this.txtTitleID.Text = string.Join<char>("", (IEnumerable<char>) chArray);
    }

    private void chkImportFooterBanner_CheckedChanged(object sender, EventArgs e)
    {
      if (this.usingCustomBannerBin)
        return;
      if (this.chkImportFooterBanner.Checked)
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "All supported files (*.png, *.bmp, *.jpg, *.gif)|*.png;*.bmp;*.jpg;*.gif|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files|*";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          this.importedCustomFooterBanner = (Bitmap) Image.FromFile(openFileDialog.FileName);
          if (this.importedCustomFooterBanner.Width != 256 || this.importedCustomFooterBanner.Height != 64)
          {
            int num = (int) MessageBox.Show("The image size must be exactly 256x64 and grayscale!");
            this.chkImportFooterBanner.Checked = false;
          }
          else
          {
            this.usingCustomFooterBanner = true;
            this.lblFooterBanner.Visible = false;
            this.picFooterBanner.Image = (Image) this.importedCustomFooterBanner;
            this.picFooterBanner.BackColor = Color.Transparent;
            this.txtFooterBanner.Enabled = false;
            this.btnSelectFont.Enabled = false;
            this.trkBright.Enabled = false;
            this.txtBright.Enabled = false;
          }
        }
        else
          this.chkImportFooterBanner.Checked = false;
      }
      else
      {
        this.usingCustomFooterBanner = false;
        this.lblFooterBanner.Visible = true;
        this.picFooterBanner.Image = (Image) Resources.footerBannerBack;
        this.picFooterBanner.BackColor = Color.FromArgb((int) byte.MaxValue, 0, 0);
        this.txtFooterBanner.Enabled = true;
        this.btnSelectFont.Enabled = true;
        this.trkBright.Enabled = true;
        this.txtBright.Enabled = true;
      }
    }

    private void lnkImportBannerBin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
    }

    private void chkImportIconBin_CheckedChanged(object sender, EventArgs e)
    {
      if (this.chkImportIconBin.Checked)
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "BIN, ICN Files (*.bin, *.icn)|*.bin;*.icn|All Files|*";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          this.importedCustomIconBin = System.IO.File.ReadAllBytes(openFileDialog.FileName);
          this.usingCustomIconBin = true;
          try
          {
            if (Encoding.ASCII.GetString(this.importedCustomIconBin, 0, 4) == "SMDH")
            {
              this.txtLongName.Enabled = false;
              this.txtShortName.Enabled = false;
              this.txtGamePublisher.Enabled = false;
              this.btnLoadIcon.Enabled = false;
              this.lstInterpolation1.Enabled = false;
              this.lblSummaryLongName.Text = Encoding.Unicode.GetString(this.importedCustomIconBin, 136, 256);
              this.lblSummaryShortName.Text = Encoding.Unicode.GetString(this.importedCustomIconBin, 520, 128);
              this.lblSummaryGamePublisher.Text = Encoding.Unicode.GetString(this.importedCustomIconBin, 392, 128);
              this.picSummaryIcon.Visible = false;
              this.pictureBox2.Visible = true;
              this.pictureBox2.Image = (Image) Textures.ToBitmap(Utils.SubArray(this.importedCustomIconBin, 9408L, 4608L), 48, 48, Textures.ImageFormat.RGB565, true);
              this.txtFooterBanner.Text = this.lblSummaryLongName.Text;
              this.bannerInnerBitmap = (Bitmap) null;
              this.btnNextStep.Enabled = true;
              this.btnExport.Enabled = true;
            }
            else
            {
              int num = (int) MessageBox.Show("Invalid or corrupted icon file!");
              this.chkImportIconBin.Checked = false;
            }
          }
          catch
          {
            int num = (int) MessageBox.Show("Invalid or corrupted icon file!");
            this.chkImportIconBin.Checked = false;
          }
        }
        else
          this.chkImportIconBin.Checked = false;
      }
      else
      {
        this.importedCustomIconBin = (byte[]) null;
        this.usingCustomIconBin = false;
        this.lblSummaryLongName.Text = this.longName;
        this.lblSummaryShortName.Text = this.shortName;
        this.lblSummaryGamePublisher.Text = this.gamePublisher;
        if (this.iconBitmap == null)
        {
          this.picSummaryIcon.Visible = false;
          this.pictureBox2.Visible = false;
        }
        else
        {
          this.picSummaryIcon.Visible = true;
          this.pictureBox2.Visible = true;
          this.picSummaryIcon.Image = (Image) this.iconBitmap;
          if (!this.usingCustomBannerBin)
          {
            this.bannerInnerBitmap = this.iconBitmap;
            this.picBannerInnerImage.Image = (Image) this.DistortedInnerImage(this.bannerInnerBitmap);
          }
        }
        this.pictureBox2.Image = (Image) Resources.icon48;
        this.txtLongName.Enabled = true;
        this.txtShortName.Enabled = true;
        this.txtGamePublisher.Enabled = true;
        this.btnLoadIcon.Enabled = true;
        this.lstInterpolation1.Enabled = true;
        if (!this.usingCustomBannerBin && !this.usingCustomFooterBanner)
          this.txtFooterBanner.Text = this.lblSummaryLongName.Text;
        this.enableNextButtonWithCondition(this.longName != "" && this.shortName != "" && (this.gamePublisher != "" && this.iconBitmap != null) || this.usingCustomIconBin, 2);
      }
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      switch (this.actualStep)
      {
        case (byte) 2:
          saveFileDialog.Filter = "BIN, ICN Files (*.bin, *.icn)|*.bin;*.icn|All Files|*";
          if (saveFileDialog.ShowDialog() != DialogResult.OK)
            break;
          byte[] bytes1 = !this.usingCustomIconBin ? this.CreateIconBinary(this.iconBitmap, this.lstInterpolation1.SelectedIndex) : this.importedCustomIconBin;
          System.IO.File.WriteAllBytes(saveFileDialog.FileName, bytes1);
          break;
        case (byte) 3:
          saveFileDialog.Filter = "BIN, BNR Files (*.bin, *.bnr)|*.bin;*.bnr|All Files|*";
          if (saveFileDialog.ShowDialog() != DialogResult.OK)
            break;
          byte[] bytes2 = !this.usingCustomBannerBin ? this.CreateBannerBinary(this.bannerInnerBitmap, this.lstInterpolation2.SelectedIndex) : this.importedCustomBannerBin;
          System.IO.File.WriteAllBytes(saveFileDialog.FileName, bytes2);
          break;
      }
    }

    private void panelStep3_Paint(object sender, PaintEventArgs e)
    {
    }

    private void chkImportBannerBin_CheckedChanged(object sender, EventArgs e)
    {
      if (this.chkImportBannerBin.Checked)
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "BIN, BNR Files (*.bin, *.bnr)|*.bin;*.bnr|All Files|*";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          this.importedCustomBannerBin = System.IO.File.ReadAllBytes(openFileDialog.FileName);
          this.usingCustomBannerBin = true;
          try
          {
            if (Encoding.ASCII.GetString(this.importedCustomBannerBin, 0, 4) == "CBMD")
            {
              this.btnLoadBannerInnerImage.Enabled = false;
              this.btnBannerStyle.Enabled = false;
              this.lstInterpolation2.Enabled = false;
              this.txtFooterBanner.Enabled = false;
              this.btnSelectFont.Enabled = false;
              this.txtBright.Enabled = false;
              this.trkBright.Enabled = false;
              this.chkImportFooterBanner.Enabled = false;
              this.picBannerInnerImage.Visible = false;
              this.picBannerFrameColor.Image = (Image) Resources.bannerNoPreview1;
              this.lblFooterBanner.Visible = false;
              this.picFooterBanner.Image = (Image) Resources.bannerNoPreview2;
              this.btnNextStep.Enabled = true;
              this.btnExport.Enabled = true;
            }
            else
            {
              int num = (int) MessageBox.Show("Invalid or corrupted banner file!");
              this.chkImportBannerBin.Checked = false;
            }
          }
          catch
          {
            int num = (int) MessageBox.Show("Invalid or corrupted banner file!");
            this.chkImportBannerBin.Checked = false;
          }
        }
        else
          this.chkImportBannerBin.Checked = false;
      }
      else
      {
        this.importedCustomBannerBin = (byte[]) null;
        this.usingCustomBannerBin = false;
        this.btnLoadBannerInnerImage.Enabled = true;
        this.btnBannerStyle.Enabled = true;
        this.lstInterpolation2.Enabled = true;
        if (this.usingCustomFooterBanner)
        {
          this.txtFooterBanner.Enabled = false;
          this.btnSelectFont.Enabled = false;
          this.txtBright.Enabled = false;
          this.trkBright.Enabled = false;
          this.lblFooterBanner.Visible = false;
          this.picFooterBanner.Image = (Image) this.importedCustomFooterBanner;
          this.picFooterBanner.BackColor = Color.Transparent;
        }
        else
        {
          this.txtFooterBanner.Enabled = true;
          this.btnSelectFont.Enabled = true;
          this.txtBright.Enabled = true;
          this.trkBright.Enabled = true;
          this.lblFooterBanner.Visible = true;
          this.picFooterBanner.Image = (Image) Resources.footerBannerBack;
          this.picFooterBanner.BackColor = Color.FromArgb((int) byte.MaxValue, 0, 0);
        }
        this.chkImportFooterBanner.Enabled = true;
        this.picBannerInnerImage.Visible = true;
        if (this.bannerType == frmMain.BannerType.USA_GENESIS)
          this.picBannerFrameColor.Image = (Image) Resources.bannerPreview;
        int num1;
        if (this.bannerInnerBitmap != null)
        {
          string text = this.txtFooterBanner.Text;
          char[] chArray = new char[1];
          int index = 0;
          int num2 = 32;
          chArray[index] = (char) num2;
          if (text.Trim(chArray) != "" || this.usingCustomFooterBanner)
          {
            num1 = 1;
            goto label_17;
          }
        }
        num1 = this.usingCustomBannerBin ? 1 : 0;
label_17:
        int stepCheck = 3;
        this.enableNextButtonWithCondition(num1 != 0, stepCheck);
      }
    }

    private int SimpleBoyerMooreSearch(byte[] haystack, byte[] needle)
    {
      int[] numArray = new int[256];
      int num1 = checked (numArray.Length - 1);
      int index1 = 0;
      while (index1 <= num1)
      {
        numArray[index1] = needle.Length;
        checked { ++index1; }
      }
      int num2 = checked (needle.Length - 1);
      int index2 = 0;
      while (index2 <= num2)
      {
        numArray[(int) needle[index2]] = checked (needle.Length - index2 - 1);
        checked { ++index2; }
      }
      int index3 = checked (needle.Length - 1);
      byte num3 = needle[checked (needle.Length - 1)];
      int num4;
      while (index3 < haystack.Length)
      {
        byte num5 = haystack[index3];
        if ((int) haystack[index3] == (int) num3)
        {
          bool flag = true;
          int index4 = checked (needle.Length - 2);
          while (index4 >= 0)
          {
            if ((int) haystack[checked (index3 - needle.Length + index4 + 1)] != (int) needle[index4])
            {
              flag = false;
              break;
            }
            checked { index4 += -1; }
          }
          if (flag)
          {
            num4 = checked (index3 - needle.Length + 1);
            goto label_19;
          }
          else
            checked { ++index3; }
        }
        else
          checked { index3 += numArray[(int) num5]; }
      }
      num4 = -1;
label_19:
      return num4;
    }

    private void btnOpenRom_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "All supported files(*.bin, *.smd, *.md) | *.bin; *.smd; *.md; | BIN Files(*.bin) | *.bin; | SMD Files(*.smd) | *.smd; | MD Files(*.md) | *.md; | All Files | *";
      openFileDialog.Multiselect = false;
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        string extension = Path.GetExtension(openFileDialog.FileName);
        if (extension.ToLower() == ".smd" || extension.ToLower() == ".bin" || extension.ToLower() == ".md")
        {
          try
          {
            this.fileGEN = System.IO.File.ReadAllBytes(openFileDialog.FileName);
            Crc32 crc32 = new Crc32();
            string hash = string.Empty;
            byte[] buffer = Utils.SubArray(this.fileGEN, 0L, (long) this.fileGEN.Length);
            foreach (byte num in crc32.ComputeHash(buffer))
              hash += num.ToString("x2").ToUpper();
            try
            {
              game_info gameInfo = this.GetGameInfo(hash);
              if (gameInfo != null)
              {
                if (!this.usingCustomIconBin)
                {
                  this.txtLongName.Text = gameInfo.description;
                  this.txtShortName.Text = gameInfo.description;
                  this.txtGamePublisher.Text = gameInfo.publisher;
                  this.label29.Text = "Game data found. Some fields are now filled. Release date: " + (object) gameInfo.year;
                  this.label29.ForeColor = Color.Green;
                }
              }
              else
              {
                if (!this.usingCustomIconBin)
                {
                  this.txtLongName.Text = "";
                  this.txtShortName.Text = "";
                  this.txtGamePublisher.Text = "";
                }
                this.label29.Text = "Game not found in database. However, the ROM should be supported.";
                this.label29.ForeColor = Color.Orange;
              }
            }
            catch
            {
              if (!this.usingCustomIconBin)
              {
                this.txtLongName.Text = "";
                this.txtShortName.Text = "";
                this.txtGamePublisher.Text = "";
              }
              this.label29.Text = "Game not found in database. However, the ROM should be supported.";
              this.label29.ForeColor = Color.Orange;
            }
            this.label1.Text = "ROM file: " + openFileDialog.SafeFileName;
            this.lblSummaryROMFile.Text = "File: " + openFileDialog.SafeFileName;
            this.txtProductCode.Text = Utils.RandomString(4, "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");
            this.txtTitleID.Text = this.GetRandomTitleID();
            this.btnNextStep.Enabled = true;
          }
          catch
          {
            int num = (int) MessageBox.Show("This isn't a standard cart!", "Stop!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
        }
        else
        {
          int num1 = (int) MessageBox.Show("This program only supports files with .smd and .bin extension.", "Stop!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      this.enableNextButtonWithCondition(this.fileGEN != null, 1);
    }

    private uint score_header(byte[] data, int size, int addr)
    {
      if (size < addr + 64)
        return 0U;
      int num1 = 0;
      int num2 = (int) data[addr + 60] | (int) data[addr + 60 + 1] << 8;
      int num3 = (int) data[addr + 30] | (int) data[addr + 30 + 1] << 8;
      int num4 = (int) data[addr + 28] | (int) data[addr + 28 + 1] << 8;
      byte num5 = data[addr & (int) short.MinValue | num2 & (int) short.MaxValue];
      byte num6 = (byte) ((uint) data[addr + 21] & 4294967279U);
      if (num2 < 32768)
        return 0U;
      if ((int) num5 == 120 || (int) num5 == 24 || ((int) num5 == 56 || (int) num5 == 156) || ((int) num5 == 76 || (int) num5 == 92))
        num1 += 8;
      if ((int) num5 == 194 || (int) num5 == 226 || ((int) num5 == 173 || (int) num5 == 174) || ((int) num5 == 172 || (int) num5 == 175 || ((int) num5 == 169 || (int) num5 == 162)) || ((int) num5 == 160 || (int) num5 == 32 || (int) num5 == 34))
        num1 += 4;
      if ((int) num5 == 64 || (int) num5 == 96 || ((int) num5 == 107 || (int) num5 == 205) || ((int) num5 == 236 || (int) num5 == 204))
        num1 -= 4;
      if ((int) num5 == 0 || (int) num5 == 2 || ((int) num5 == 219 || (int) num5 == 66) || (int) num5 == (int) byte.MaxValue)
        num1 -= 8;
      if (num3 + num4 == (int) ushort.MaxValue && num3 != 0 && num4 != 0)
        num1 += 4;
      if (addr == 32704 && (int) num6 == 32)
        num1 += 2;
      if (addr == 65472 && (int) num6 == 33)
        num1 += 2;
      if (addr == 32704 && (int) num6 == 34)
        num1 += 2;
      if (addr == 4259776 && (int) num6 == 37)
        num1 += 2;
      if ((int) data[addr + 26] == 51)
        num1 += 2;
      if ((int) data[addr + 22] < 8)
        ++num1;
      if ((int) data[addr + 23] < 16)
        ++num1;
      if ((int) data[addr + 23] < 8)
        ++num1;
      if ((int) data[addr + 25] < 14)
        ++num1;
      if (num1 < 0)
        num1 = 0;
      return (uint) (ushort) num1;
    }

    private uint find_header(byte[] data, int size)
    {
      uint num1 = this.score_header(data, size, 32704);
      uint num2 = this.score_header(data, size, 65472);
      uint num3 = this.score_header(data, size, 4259776);
      if ((int) num3 != 0)
        num3 += 4U;
      if (num1 >= num2 && num1 >= num3)
        return 32704U;
      return num2 >= num3 ? 65472U : 4259776U;
    }

    private byte[] INT2LE(int data)
    {
      byte[] numArray = new byte[4];
      int index1 = 0;
      int num1 = (int) (byte) data;
      numArray[index1] = (byte) num1;
      int index2 = 1;
      int num2 = (int) (byte) ((uint) data >> 8 & (uint) byte.MaxValue);
      numArray[index2] = (byte) num2;
      int index3 = 2;
      int num3 = (int) (byte) ((uint) data >> 16 & (uint) byte.MaxValue);
      numArray[index3] = (byte) num3;
      int index4 = 3;
      int num4 = (int) (byte) ((uint) data >> 24 & (uint) byte.MaxValue);
      numArray[index4] = (byte) num4;
      return numArray;
    }

    private game_info GetGameInfo(string hash)
    {
      game_info gameInfo = new game_info();
      try
      {
        string c = "";
        XElement xelement = XElement.Parse(Resources.genDB);
        bool flag = false;
        for (int index = 0; index < Enumerable.Count<XElement>(xelement.Elements()) && !flag; ++index)
        {
          c = Enumerable.ElementAt<XElement>(xelement.Elements(), index).ToString();
          if (c.Contains("<crc>" + hash + "</crc>"))
            flag = true;
        }
        if (!flag)
          return (game_info) null;
        gameInfo.description = Utils.GetSubstringByString("<description>", "</description>", c);
        string pattern = "(\\[.*\\])|(\".*\")|('.*')|(\\(.*\\))";
        gameInfo.description = Regex.Replace(gameInfo.description, pattern, "");
        int length1 = gameInfo.description.IndexOf(", The");
        if (length1 > -1)
          gameInfo.description = "The " + gameInfo.description.Substring(0, length1) + gameInfo.description.Substring(length1 + 5);
        int length2 = gameInfo.description.IndexOf(", An");
        if (length2 > -1)
          gameInfo.description = "An " + gameInfo.description.Substring(0, length2) + gameInfo.description.Substring(length2 + 4);
        int length3 = gameInfo.description.IndexOf(", A");
        if (length3 > -1)
          gameInfo.description = "A " + gameInfo.description.Substring(0, length3) + gameInfo.description.Substring(length3 + 3);
        gameInfo.description = gameInfo.description.Trim();
        gameInfo.description = WebUtility.HtmlDecode(gameInfo.description);
        gameInfo.publisher = Utils.GetSubstringByString("<manufacturer>", "</manufacturer>", c);
        gameInfo.year = Convert.ToInt32(Utils.GetSubstringByString("<year>", "</year>", c));
        return gameInfo;
      }
      catch
      {
        return (game_info) null;
      }
    }

    private Bitmap DistortedInnerImage(Bitmap innerOriginal)
    {
      FreeTransform freeTransform1 = new FreeTransform();
      freeTransform1.Bitmap = new Bitmap((Image) innerOriginal);
      FreeTransform freeTransform2 = freeTransform1;
      PointF[] pointFArray = new PointF[4];
      int index1 = 0;
      PointF pointF1 = new PointF(0.0f, 5f);
      pointFArray[index1] = pointF1;
      int index2 = 1;
      PointF pointF2 = new PointF(68f, 0.0f);
      pointFArray[index2] = pointF2;
      int index3 = 2;
      PointF pointF3 = new PointF(68f, 66f);
      pointFArray[index3] = pointF3;
      int index4 = 3;
      PointF pointF4 = new PointF(0.0f, 66f);
      pointFArray[index4] = pointF4;
      freeTransform2.FourCorners = pointFArray;
      switch (this.lstInterpolation2.SelectedIndex)
      {
        case 2:
        case 3:
          freeTransform1.IsBilinearInterpolation = true;
          break;
        default:
          freeTransform1.IsBilinearInterpolation = false;
          break;
      }
      return new Bitmap((Image) freeTransform1.Bitmap);
    }

    private void txtLongName_TextChanged(object sender, EventArgs e)
    {
      if (this.usingCustomIconBin)
        return;
      string text = this.txtLongName.Text;
      char[] chArray = new char[1];
      int index = 0;
      int num = 32;
      chArray[index] = (char) num;
      this.longName = text.Trim(chArray);
      this.lblSummaryLongName.Text = this.longName;
      this.txtFooterBanner.Text = this.longName;
      this.enableNextButtonWithCondition(this.longName != "" && this.shortName != "" && (this.gamePublisher != "" && this.iconBitmap != null) || this.usingCustomIconBin, 2);
    }

    private void txtShortName_TextChanged(object sender, EventArgs e)
    {
      if (this.usingCustomIconBin)
        return;
      string text = this.txtShortName.Text;
      char[] chArray = new char[1];
      int index = 0;
      int num = 32;
      chArray[index] = (char) num;
      this.shortName = text.Trim(chArray);
      this.lblSummaryShortName.Text = this.shortName;
      this.enableNextButtonWithCondition(this.longName != "" && this.shortName != "" && (this.gamePublisher != "" && this.iconBitmap != null) || this.usingCustomIconBin, 2);
    }

    private void btnBannerStyle_Click(object sender, EventArgs e)
    {
      if (this.usingCustomBannerBin)
        return;
      this.bannerType = this.bannerType + 1 != (frmMain.BannerType) System.Enum.GetValues(typeof (frmMain.BannerType)).Length ? this.bannerType + 1 : frmMain.BannerType.USA_GENESIS;
      if (this.bannerType == frmMain.BannerType.USA_GENESIS)
        this.picBannerFrameColor.Image = (Image) Resources.bannerPreview;
      this.btnBannerStyle.Text = "Style: " + this.bannerType.ToString().Replace('_', ' ').Replace("slash", "/");
    }

    private string GetRandomTitleID()
    {
      string str = "";
      XElement xelement = XElement.Parse(Resources._3dsreleases);
      bool flag = true;
label_6:
      while (flag)
      {
        flag = false;
        str = Utils.RandomString(4, "ABCDEF0123456789");
        int index = 0;
        while (true)
        {
          if (index < Enumerable.Count<XElement>(xelement.Elements()) && !flag)
          {
            string c = Enumerable.ElementAt<XElement>(xelement.Elements(), index).ToString();
            if (Utils.GetSubstringByString("<titleid>", "</titleid>", c).Length == 16 && Utils.GetSubstringByString("<titleid>", "</titleid>", c).Substring(10, 4) == str)
              flag = true;
            ++index;
          }
          else
            goto label_6;
        }
      }
      return str;
    }

    private void picIcon48_Click(object sender, EventArgs e)
    {
    }

    private void chkHeightStretch_CheckedChanged(object sender, EventArgs e)
    {
      this.picIcon24.Refresh();
      this.picIcon48.Refresh();
      this.picSummaryIcon.Refresh();
    }

    private void pic3dsButtonL_Click(object sender, EventArgs e)
    {
    }

    private void pic3dsButtonZL_Click(object sender, EventArgs e)
    {
    }

    private void radFullScreen_CheckedChanged(object sender, EventArgs e)
    {
      this.picScreenPreview.Width = 400;
      this.picScreenPreview.Height = 240;
      this.picScreenPreview.Left = this.pic3DSBackground.Left + this.pic3DSBackground.Width / 2 - this.picScreenPreview.Width / 2;
      this.picScreenPreview.Top = this.pic3DSBackground.Top + this.pic3DSBackground.Height / 2 - this.picScreenPreview.Height / 2;
    }

    private void radPixelPerfectPAL_CheckedChanged(object sender, EventArgs e)
    {
      this.picScreenPreview.Width = 320;
      this.picScreenPreview.Height = 240;
      this.picScreenPreview.Left = this.pic3DSBackground.Left + this.pic3DSBackground.Width / 2 - this.picScreenPreview.Width / 2;
      this.picScreenPreview.Top = this.pic3DSBackground.Top + this.pic3DSBackground.Height / 2 - this.picScreenPreview.Height / 2;
    }

    private void radPixelPerfectNTSC_CheckedChanged(object sender, EventArgs e)
    {
      this.picScreenPreview.Width = 320;
      this.picScreenPreview.Height = 224;
      this.picScreenPreview.Left = this.pic3DSBackground.Left + this.pic3DSBackground.Width / 2 - this.picScreenPreview.Width / 2;
      this.picScreenPreview.Top = this.pic3DSBackground.Top + this.pic3DSBackground.Height / 2 - this.picScreenPreview.Height / 2;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      frmRemapButtons frmRemapButtons = new frmRemapButtons(this.MappedButtons);
      if (this.MappedButtons.UsingNew3DS)
        frmRemapButtons.Text = "Editing buttons layout (New 3DS mode)";
      else
        frmRemapButtons.Text = "Editing buttons layout (Old 3DS mode)";
      int num = (int) frmRemapButtons.ShowDialog();
      this.MappedButtons = frmRemapButtons.finalMapping;
    }

    private void lstBottomScreen_SelectedIndexChanged(object sender, EventArgs e)
    {
      switch (this.lstBottomScreen.SelectedIndex)
      {
        case 0:
          this.picBottomScreenPreview.Image = (Image) null;
          break;
        case 1:
          this.picBottomScreenPreview.Image = (Image) Resources.bottom_en;
          break;
        case 2:
          this.picBottomScreenPreview.Image = (Image) Resources.bottom_de;
          break;
        case 3:
          this.picBottomScreenPreview.Image = (Image) Resources.bottom_es;
          break;
        case 4:
          this.picBottomScreenPreview.Image = (Image) Resources.bottom_fr;
          break;
        case 5:
          this.picBottomScreenPreview.Image = (Image) Resources.bottom_it;
          break;
        case 6:
          this.picBottomScreenPreview.Image = (Image) Resources.bottom_ja;
          break;
        case 7:
          this.picBottomScreenPreview.Image = (Image) Resources.bottom_nl;
          break;
        case 8:
          this.picBottomScreenPreview.Image = (Image) Resources.bottom_pt;
          break;
        case 9:
          this.picBottomScreenPreview.Image = (Image) Resources.bottom_ru;
          break;
        case 10:
          OpenFileDialog openFileDialog = new OpenFileDialog();
          openFileDialog.Filter = "All supported files (*.png, *.bmp, *.jpg, *.gif) | *.png;*.bmp;*.jpg;*.gif; | PNG Files (*.png) | *.png; | BMP Files (*.bmp) | *.bmp; |JPG Files (*.jpg) | *.jpg; | GIF Files (*.gif) | *.gif; | All Files | *";
          if (openFileDialog.ShowDialog() == DialogResult.OK)
          {
            this.importedCustomBottomScreen = (Bitmap) Image.FromFile(openFileDialog.FileName);
            if (this.importedCustomBottomScreen.Width != 320 || this.importedCustomBottomScreen.Height != 240)
            {
              int num = (int) MessageBox.Show("The image must be exactly 320x240!");
              this.importedCustomBottomScreen = (Bitmap) null;
              this.lstBottomScreen.SelectedIndex = 0;
              break;
            }
            this.picBottomScreenPreview.Image = (Image) this.importedCustomBottomScreen;
            break;
          }
          this.importedCustomBottomScreen = (Bitmap) null;
          this.lstBottomScreen.SelectedIndex = 0;
          break;
      }
    }

    private void groupBox2_Enter(object sender, EventArgs e)
    {
    }

    private void radCustomResolution_CheckedChanged(object sender, EventArgs e)
    {
      if (this.radCustomResolution.Checked)
      {
        this.txtCustomResolutionWidth.Enabled = true;
        this.txtCustomResolutionHeight.Enabled = true;
        this.picScreenPreview.Width = Convert.ToInt32(this.txtCustomResolutionWidth.Text);
        this.picScreenPreview.Height = Convert.ToInt32(this.txtCustomResolutionHeight.Text);
        this.picScreenPreview.Left = this.pic3DSBackground.Left + this.pic3DSBackground.Width / 2 - this.picScreenPreview.Width / 2;
        this.picScreenPreview.Top = this.pic3DSBackground.Top + this.pic3DSBackground.Height / 2 - this.picScreenPreview.Height / 2;
      }
      else
      {
        this.txtCustomResolutionWidth.Enabled = false;
        this.txtCustomResolutionHeight.Enabled = false;
      }
    }

    private void txtCustomResolutionWidth_TextChanged(object sender, EventArgs e)
    {
      char[] chArray = Enumerable.ToArray<char>((IEnumerable<char>) this.txtCustomResolutionWidth.Text);
      for (int index = 0; index < chArray.Length; ++index)
      {
        if (!Enumerable.Contains<char>((IEnumerable<char>) "0123456789", chArray[index]))
          chArray[index] = '0';
      }
      this.txtCustomResolutionWidth.Text = string.Join<char>("", (IEnumerable<char>) chArray);
      this.picScreenPreview.Width = Convert.ToInt32(this.txtCustomResolutionWidth.Text);
      this.picScreenPreview.Height = Convert.ToInt32(this.txtCustomResolutionHeight.Text);
      this.picScreenPreview.Left = this.pic3DSBackground.Left + this.pic3DSBackground.Width / 2 - this.picScreenPreview.Width / 2;
      this.picScreenPreview.Top = this.pic3DSBackground.Top + this.pic3DSBackground.Height / 2 - this.picScreenPreview.Height / 2;
    }

    private void txtCustomResolutionHeight_TextChanged(object sender, EventArgs e)
    {
      char[] chArray = Enumerable.ToArray<char>((IEnumerable<char>) this.txtCustomResolutionHeight.Text);
      for (int index = 0; index < chArray.Length; ++index)
      {
        if (!Enumerable.Contains<char>((IEnumerable<char>) "0123456789", chArray[index]))
          chArray[index] = '0';
      }
      this.txtCustomResolutionHeight.Text = string.Join<char>("", (IEnumerable<char>) chArray);
      this.picScreenPreview.Width = Convert.ToInt32(this.txtCustomResolutionWidth.Text);
      this.picScreenPreview.Height = Convert.ToInt32(this.txtCustomResolutionHeight.Text);
      this.picScreenPreview.Left = this.pic3DSBackground.Left + this.pic3DSBackground.Width / 2 - this.picScreenPreview.Width / 2;
      this.picScreenPreview.Top = this.pic3DSBackground.Top + this.pic3DSBackground.Height / 2 - this.picScreenPreview.Height / 2;
    }

    private void lblStep_Click(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmMain));
      this.lblStep = new Label();
      this.panelStep1 = new Panel();
      this.label29 = new Label();
      this.label10 = new Label();
      this.label1 = new Label();
      this.btnOpenRom = new Button();
      this.panel1 = new Panel();
      this.picSummaryIcon = new PictureBox();
      this.progressBar1 = new ProgressBar();
      this.lblSummaryShortName = new Label();
      this.lblSummaryLongName = new Label();
      this.btnExport = new Button();
      this.picOhana = new PictureBox();
      this.lblSummaryGamePublisher = new Label();
      this.lblSummaryROMFile = new Label();
      this.btnPreviousStep = new Button();
      this.btnNextStep = new Button();
      this.button2 = new Button();
      this.pictureBox2 = new PictureBox();
      this.panelStep3 = new Panel();
      this.label28 = new Label();
      this.btnBannerStyle = new Button();
      this.picBannerInnerImage = new PictureBox();
      this.chkImportBannerBin = new CheckBox();
      this.label22 = new Label();
      this.chkImportFooterBanner = new CheckBox();
      this.label18 = new Label();
      this.txtBright = new TextBox();
      this.label16 = new Label();
      this.trkBright = new TrackBar();
      this.btnSelectFont = new Button();
      this.label14 = new Label();
      this.label13 = new Label();
      this.label11 = new Label();
      this.label12 = new Label();
      this.lstInterpolation2 = new ListBox();
      this.label3 = new Label();
      this.txtFooterBanner = new TextBox();
      this.btnLoadBannerInnerImage = new Button();
      this.lblFooterBanner = new Label();
      this.picFooterBanner = new PictureBox();
      this.picBannerFrameColor = new PictureBox();
      this.panelStep4 = new Panel();
      this.groupBox3 = new GroupBox();
      this.button1 = new Button();
      this.chkAutoSaveLoadState = new CheckBox();
      this.chkEnableRewind = new CheckBox();
      this.groupBox2 = new GroupBox();
      this.label17 = new Label();
      this.lstBottomScreen = new ListBox();
      this.picBottomScreenPreview = new PictureBox();
      this.groupBox1 = new GroupBox();
      this.label27 = new Label();
      this.txtCustomResolutionHeight = new TextBox();
      this.label26 = new Label();
      this.txtCustomResolutionWidth = new TextBox();
      this.radCustomResolution = new RadioButton();
      this.radPixelPerfectPAL = new RadioButton();
      this.radFullScreen = new RadioButton();
      this.picScreenPreview = new PictureBox();
      this.pic3DSBackground = new PictureBox();
      this.radPixelPerfectNTSC = new RadioButton();
      this.picShuffleUniqueID = new PictureBox();
      this.picShuffleProductCode = new PictureBox();
      this.label21 = new Label();
      this.label20 = new Label();
      this.label19 = new Label();
      this.txtTitleID = new TextBox();
      this.txtProductCode = new TextBox();
      this.txtGamePublisher = new TextBox();
      this.label5 = new Label();
      this.label6 = new Label();
      this.label7 = new Label();
      this.pictureBox3 = new PictureBox();
      this.pictureBox5 = new PictureBox();
      this.picIcon24 = new PictureBox();
      this.picIcon48 = new PictureBox();
      this.btnLoadIcon = new Button();
      this.label8 = new Label();
      this.lstInterpolation1 = new ListBox();
      this.label9 = new Label();
      this.label15 = new Label();
      this.label23 = new Label();
      this.chkImportIconBin = new CheckBox();
      this.panelStep2 = new Panel();
      this.chkHeightStretch = new CheckBox();
      this.label25 = new Label();
      this.label24 = new Label();
      this.txtLongName = new TextBox();
      this.label4 = new Label();
      this.label2 = new Label();
      this.txtShortName = new TextBox();
      this.panelStep1.SuspendLayout();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.picSummaryIcon).BeginInit();
      ((ISupportInitialize) this.picOhana).BeginInit();
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      this.panelStep3.SuspendLayout();
      ((ISupportInitialize) this.picBannerInnerImage).BeginInit();
      this.trkBright.BeginInit();
      ((ISupportInitialize) this.picFooterBanner).BeginInit();
      ((ISupportInitialize) this.picBannerFrameColor).BeginInit();
      this.panelStep4.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox2.SuspendLayout();
      ((ISupportInitialize) this.picBottomScreenPreview).BeginInit();
      this.groupBox1.SuspendLayout();
      ((ISupportInitialize) this.picScreenPreview).BeginInit();
      ((ISupportInitialize) this.pic3DSBackground).BeginInit();
      ((ISupportInitialize) this.picShuffleUniqueID).BeginInit();
      ((ISupportInitialize) this.picShuffleProductCode).BeginInit();
      ((ISupportInitialize) this.pictureBox3).BeginInit();
      ((ISupportInitialize) this.pictureBox5).BeginInit();
      ((ISupportInitialize) this.picIcon24).BeginInit();
      ((ISupportInitialize) this.picIcon48).BeginInit();
      this.panelStep2.SuspendLayout();
      this.SuspendLayout();
      this.lblStep.BackColor = SystemColors.ControlLightLight;
      this.lblStep.Dock = DockStyle.Top;
      this.lblStep.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblStep.ForeColor = Color.Black;
      this.lblStep.Location = new Point(0, 0);
      this.lblStep.Name = "lblStep";
      this.lblStep.Size = new Size(842, 24);
      this.lblStep.TabIndex = 2;
      this.lblStep.Text = "Step 1. Rom selection";
      this.lblStep.TextAlign = ContentAlignment.MiddleLeft;
      this.lblStep.Click += new EventHandler(this.lblStep_Click);
      this.panelStep1.BackColor = SystemColors.Control;
      this.panelStep1.Controls.Add((Control) this.label29);
      this.panelStep1.Controls.Add((Control) this.label10);
      this.panelStep1.Controls.Add((Control) this.label1);
      this.panelStep1.Controls.Add((Control) this.btnOpenRom);
      this.panelStep1.Location = new Point(0, 24);
      this.panelStep1.Name = "panelStep1";
      this.panelStep1.Size = new Size(842, 344);
      this.panelStep1.TabIndex = 4;
      this.label29.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label29.Location = new Point(12, 92);
      this.label29.Name = "label29";
      this.label29.Size = new Size(820, 13);
      this.label29.TabIndex = 8;
      this.label10.Location = new Point(12, 12);
      this.label10.Name = "label10";
      this.label10.Size = new Size(600, 44);
      this.label10.TabIndex = 7;
      this.label10.Text = "Welcome to Ultimate GEN-MD Forwarder Maker for 3DS.\r\nThis program is a tool for \"converting\" a Sega Genesis/Mega Drive rom to an installable CIA for 3DS.\r\nJust follow the steps. Enjoy!";
      this.label1.Location = new Point(12, 112);
      this.label1.Name = "label1";
      this.label1.Size = new Size(600, 15);
      this.label1.TabIndex = 6;
      this.btnOpenRom.Location = new Point(12, 59);
      this.btnOpenRom.Name = "btnOpenRom";
      this.btnOpenRom.Size = new Size(170, 27);
      this.btnOpenRom.TabIndex = 5;
      this.btnOpenRom.Text = "Open GEN-SMD File";
      this.btnOpenRom.UseVisualStyleBackColor = true;
      this.btnOpenRom.Click += new EventHandler(this.btnOpenRom_Click);
      this.panel1.BackColor = SystemColors.ControlLight;
      this.panel1.Controls.Add((Control) this.picSummaryIcon);
      this.panel1.Controls.Add((Control) this.lblSummaryShortName);
      this.panel1.Controls.Add((Control) this.lblSummaryLongName);
      this.panel1.Controls.Add((Control) this.btnExport);
      this.panel1.Controls.Add((Control) this.picOhana);
      this.panel1.Controls.Add((Control) this.lblSummaryGamePublisher);
      this.panel1.Controls.Add((Control) this.lblSummaryROMFile);
      this.panel1.Controls.Add((Control) this.btnPreviousStep);
      this.panel1.Controls.Add((Control) this.btnNextStep);
      this.panel1.Controls.Add((Control) this.button2);
      this.panel1.Controls.Add((Control) this.pictureBox2);
      this.panel1.Controls.Add((Control) this.progressBar1);
      this.panel1.Dock = DockStyle.Bottom;
      this.panel1.Location = new Point(0, 367);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(842, 74);
      this.panel1.TabIndex = 6;
      this.picSummaryIcon.BackColor = Color.Black;
      this.picSummaryIcon.Location = new Point(7, 7);
      this.picSummaryIcon.Name = "picSummaryIcon";
      this.picSummaryIcon.Size = new Size(40, 40);
      this.picSummaryIcon.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picSummaryIcon.TabIndex = 12;
      this.picSummaryIcon.TabStop = false;
      this.picSummaryIcon.Visible = false;
      this.picSummaryIcon.Paint += new PaintEventHandler(this.picSummaryIcon_Paint);
      this.progressBar1.Location = new Point(665, 38);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new Size(167, 25);
      this.progressBar1.TabIndex = 21;
      this.lblSummaryShortName.Location = new Point(53, 15);
      this.lblSummaryShortName.Name = "lblSummaryShortName";
      this.lblSummaryShortName.Size = new Size(433, 13);
      this.lblSummaryShortName.TabIndex = 20;
      this.lblSummaryLongName.Location = new Point(53, 2);
      this.lblSummaryLongName.Name = "lblSummaryLongName";
      this.lblSummaryLongName.Size = new Size(433, 13);
      this.lblSummaryLongName.TabIndex = 19;
      this.btnExport.Enabled = false;
      this.btnExport.Location = new Point(665, 38);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new Size(167, 25);
      this.btnExport.TabIndex = 16;
      this.btnExport.Text = "Export ...";
      this.btnExport.UseVisualStyleBackColor = true;
      this.btnExport.Click += new EventHandler(this.btnExport_Click);
      this.picOhana.BackColor = Color.Black;
      this.picOhana.Location = new Point(60, 109);
      this.picOhana.Name = "picOhana";
      this.picOhana.Size = new Size(450, 93);
      this.picOhana.TabIndex = 11;
      this.picOhana.TabStop = false;
      this.picOhana.Visible = false;
      this.lblSummaryGamePublisher.Location = new Point(53, 28);
      this.lblSummaryGamePublisher.Name = "lblSummaryGamePublisher";
      this.lblSummaryGamePublisher.Size = new Size(433, 13);
      this.lblSummaryGamePublisher.TabIndex = 15;
      this.lblSummaryROMFile.Location = new Point(4, 54);
      this.lblSummaryROMFile.Name = "lblSummaryROMFile";
      this.lblSummaryROMFile.Size = new Size(482, 13);
      this.lblSummaryROMFile.TabIndex = 13;
      this.btnPreviousStep.Location = new Point(492, 7);
      this.btnPreviousStep.Name = "btnPreviousStep";
      this.btnPreviousStep.Size = new Size(167, 25);
      this.btnPreviousStep.TabIndex = 8;
      this.btnPreviousStep.UseVisualStyleBackColor = true;
      this.btnPreviousStep.Visible = false;
      this.btnPreviousStep.Click += new EventHandler(this.btnPreviousStep_Click);
      this.btnNextStep.Enabled = false;
      this.btnNextStep.Location = new Point(665, 7);
      this.btnNextStep.Name = "btnNextStep";
      this.btnNextStep.Size = new Size(167, 25);
      this.btnNextStep.TabIndex = 7;
      this.btnNextStep.Text = "Next step (icon)";
      this.btnNextStep.UseVisualStyleBackColor = true;
      this.btnNextStep.Click += new EventHandler(this.btnNextStep_Click);
      this.button2.Location = new Point(524, 365);
      this.button2.Name = "button2";
      this.button2.Size = new Size(97, 25);
      this.button2.TabIndex = 4;
      this.button2.Text = "Step 2 (Icon) >>";
      this.button2.UseVisualStyleBackColor = true;
      this.pictureBox2.Image = (Image) Resources.icon48;
      this.pictureBox2.InitialImage = (Image) null;
      this.pictureBox2.Location = new Point(3, 3);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(48, 48);
      this.pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox2.TabIndex = 11;
      this.pictureBox2.TabStop = false;
      this.pictureBox2.Visible = false;
      this.panelStep3.Controls.Add((Control) this.label28);
      this.panelStep3.Controls.Add((Control) this.btnBannerStyle);
      this.panelStep3.Controls.Add((Control) this.picBannerInnerImage);
      this.panelStep3.Controls.Add((Control) this.chkImportBannerBin);
      this.panelStep3.Controls.Add((Control) this.label22);
      this.panelStep3.Controls.Add((Control) this.chkImportFooterBanner);
      this.panelStep3.Controls.Add((Control) this.label18);
      this.panelStep3.Controls.Add((Control) this.txtBright);
      this.panelStep3.Controls.Add((Control) this.label16);
      this.panelStep3.Controls.Add((Control) this.trkBright);
      this.panelStep3.Controls.Add((Control) this.btnSelectFont);
      this.panelStep3.Controls.Add((Control) this.label14);
      this.panelStep3.Controls.Add((Control) this.label13);
      this.panelStep3.Controls.Add((Control) this.label11);
      this.panelStep3.Controls.Add((Control) this.label12);
      this.panelStep3.Controls.Add((Control) this.lstInterpolation2);
      this.panelStep3.Controls.Add((Control) this.label3);
      this.panelStep3.Controls.Add((Control) this.txtFooterBanner);
      this.panelStep3.Controls.Add((Control) this.btnLoadBannerInnerImage);
      this.panelStep3.Controls.Add((Control) this.lblFooterBanner);
      this.panelStep3.Controls.Add((Control) this.picFooterBanner);
      this.panelStep3.Controls.Add((Control) this.picBannerFrameColor);
      this.panelStep3.Location = new Point(0, 24);
      this.panelStep3.Name = "panelStep3";
      this.panelStep3.Size = new Size(842, 345);
      this.panelStep3.TabIndex = 8;
      this.panelStep3.Visible = false;
      this.panelStep3.Paint += new PaintEventHandler(this.panelStep3_Paint);
      this.label28.AutoSize = true;
      this.label28.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.label28.Location = new Point(599, 14);
      this.label28.Name = "label28";
      this.label28.Size = new Size(134, 16);
      this.label28.TabIndex = 37;
      this.label28.Text = "This is just a preview.";
      this.btnBannerStyle.Location = new Point(286, 34);
      this.btnBannerStyle.Name = "btnBannerStyle";
      this.btnBannerStyle.Size = new Size(195, 24);
      this.btnBannerStyle.TabIndex = 36;
      this.btnBannerStyle.Text = "Style: USA GENESIS";
      this.btnBannerStyle.UseVisualStyleBackColor = true;
      this.btnBannerStyle.Visible = false;
      this.btnBannerStyle.Click += new EventHandler(this.btnBannerStyle_Click);
      this.picBannerInnerImage.BackColor = Color.Transparent;
      this.picBannerInnerImage.Location = new Point(665, 60);
      this.picBannerInnerImage.Name = "picBannerInnerImage";
      this.picBannerInnerImage.Size = new Size(68, 66);
      this.picBannerInnerImage.TabIndex = 35;
      this.picBannerInnerImage.TabStop = false;
      this.chkImportBannerBin.AutoSize = true;
      this.chkImportBannerBin.Location = new Point(111, 11);
      this.chkImportBannerBin.Name = "chkImportBannerBin";
      this.chkImportBannerBin.Size = new Size(223, 17);
      this.chkImportBannerBin.TabIndex = 34;
      this.chkImportBannerBin.Text = "import a pre-made banner.bin (banner.bnr)";
      this.chkImportBannerBin.UseVisualStyleBackColor = true;
      this.chkImportBannerBin.CheckedChanged += new EventHandler(this.chkImportBannerBin_CheckedChanged);
      this.label22.AutoSize = true;
      this.label22.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label22.Location = new Point(12, 12);
      this.label22.Name = "label22";
      this.label22.Size = new Size(98, 13);
      this.label22.TabIndex = 30;
      this.label22.Text = "Fill the fields, or";
      this.chkImportFooterBanner.AutoSize = true;
      this.chkImportFooterBanner.Location = new Point(126, 245);
      this.chkImportFooterBanner.Name = "chkImportFooterBanner";
      this.chkImportFooterBanner.Size = new Size(193, 17);
      this.chkImportFooterBanner.TabIndex = 28;
      this.chkImportFooterBanner.Text = "import and use custom footer image";
      this.chkImportFooterBanner.UseVisualStyleBackColor = true;
      this.chkImportFooterBanner.CheckedChanged += new EventHandler(this.chkImportFooterBanner_CheckedChanged);
      this.label18.AutoSize = true;
      this.label18.Location = new Point(108, 246);
      this.label18.Name = "label18";
      this.label18.Size = new Size(16, 13);
      this.label18.TabIndex = 27;
      this.label18.Text = "or";
      this.txtBright.Location = new Point(626, 282);
      this.txtBright.Name = "txtBright";
      this.txtBright.Size = new Size(59, 20);
      this.txtBright.TabIndex = 24;
      this.txtBright.Text = "64";
      this.txtBright.TextChanged += new EventHandler(this.txtBright_TextChanged);
      this.label16.AutoSize = true;
      this.label16.Location = new Point(626, 266);
      this.label16.Name = "label16";
      this.label16.Size = new Size(59, 13);
      this.label16.TabIndex = 23;
      this.label16.Text = "Brightness:";
      this.trkBright.AutoSize = false;
      this.trkBright.BackColor = SystemColors.Control;
      this.trkBright.Location = new Point(691, 266);
      this.trkBright.Maximum = (int) byte.MaxValue;
      this.trkBright.Name = "trkBright";
      this.trkBright.Size = new Size(96, 24);
      this.trkBright.TabIndex = 22;
      this.trkBright.Value = 64;
      this.trkBright.Scroll += new EventHandler(this.trkBright_Scroll);
      this.btnSelectFont.Location = new Point(531, 266);
      this.btnSelectFont.Name = "btnSelectFont";
      this.btnSelectFont.Size = new Size(89, 24);
      this.btnSelectFont.TabIndex = 21;
      this.btnSelectFont.Text = "Select font";
      this.btnSelectFont.UseVisualStyleBackColor = true;
      this.btnSelectFont.Click += new EventHandler(this.btnSelectFont_Click);
      this.label14.AutoSize = true;
      this.label14.Location = new Point(30, 37);
      this.label14.Name = "label14";
      this.label14.Size = new Size(75, 13);
      this.label14.TabIndex = 20;
      this.label14.Text = "Banner image:";
      this.label13.AutoSize = true;
      this.label13.Location = new Point(41, 199);
      this.label13.Name = "label13";
      this.label13.Size = new Size(64, 13);
      this.label13.TabIndex = 19;
      this.label13.Text = "Banner text:";
      this.label11.BackColor = SystemColors.Info;
      this.label11.BorderStyle = BorderStyle.FixedSingle;
      this.label11.Location = new Point(111, 155);
      this.label11.Name = "label11";
      this.label11.Size = new Size(370, 34);
      this.label11.TabIndex = 18;
      this.label11.Text = "This is for images greater than 40x40. It's the image stretching mode that will be applied when resizing. Bicubic is recommended.";
      this.label11.TextAlign = ContentAlignment.MiddleLeft;
      this.label12.AutoSize = true;
      this.label12.Location = new Point(8, 122);
      this.label12.Name = "label12";
      this.label12.Size = new Size(97, 13);
      this.label12.TabIndex = 17;
      this.label12.Text = "Interpolation mode:";
      this.lstInterpolation2.FormattingEnabled = true;
      ListBox.ObjectCollection items1 = this.lstInterpolation2.Items;
      object[] items2 = new object[4];
      int index1 = 0;
      string str1 = "No shrink";
      items2[index1] = (object) str1;
      int index2 = 1;
      string str2 = "Nearest neighbor";
      items2[index2] = (object) str2;
      int index3 = 2;
      string str3 = "Bilinear";
      items2[index3] = (object) str3;
      int index4 = 3;
      string str4 = "Bicubic";
      items2[index4] = (object) str4;
      items1.AddRange(items2);
      this.lstInterpolation2.Location = new Point(111, 122);
      this.lstInterpolation2.Name = "lstInterpolation2";
      this.lstInterpolation2.Size = new Size(169, 30);
      this.lstInterpolation2.TabIndex = 16;
      this.lstInterpolation2.SelectedIndexChanged += new EventHandler(this.lstInterpolation2_SelectedIndexChanged);
      this.label3.BackColor = SystemColors.Info;
      this.label3.BorderStyle = BorderStyle.FixedSingle;
      this.label3.Location = new Point(111, 61);
      this.label3.Name = "label3";
      this.label3.Size = new Size(370, 58);
      this.label3.TabIndex = 15;
      this.label3.Text = componentResourceManager.GetString("label3.Text");
      this.label3.TextAlign = ContentAlignment.MiddleLeft;
      this.txtFooterBanner.Location = new Point(111, 196);
      this.txtFooterBanner.Multiline = true;
      this.txtFooterBanner.Name = "txtFooterBanner";
      this.txtFooterBanner.Size = new Size(370, 45);
      this.txtFooterBanner.TabIndex = 14;
      this.txtFooterBanner.TextAlign = HorizontalAlignment.Center;
      this.txtFooterBanner.TextChanged += new EventHandler(this.txtFooterBanner_TextChanged);
      this.btnLoadBannerInnerImage.Location = new Point(111, 34);
      this.btnLoadBannerInnerImage.Name = "btnLoadBannerInnerImage";
      this.btnLoadBannerInnerImage.Size = new Size(169, 24);
      this.btnLoadBannerInnerImage.TabIndex = 13;
      this.btnLoadBannerInnerImage.Text = "Load inner image";
      this.btnLoadBannerInnerImage.UseVisualStyleBackColor = true;
      this.btnLoadBannerInnerImage.Click += new EventHandler(this.btnLoadBannerInnerImage_Click);
      this.lblFooterBanner.BackColor = Color.Transparent;
      this.lblFooterBanner.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblFooterBanner.ForeColor = Color.FromArgb(64, 64, 64);
      this.lblFooterBanner.Location = new Point(627, 203);
      this.lblFooterBanner.Name = "lblFooterBanner";
      this.lblFooterBanner.Size = new Size(153, 50);
      this.lblFooterBanner.TabIndex = 12;
      this.lblFooterBanner.TextAlign = ContentAlignment.MiddleCenter;
      this.picFooterBanner.BackColor = Color.Red;
      this.picFooterBanner.Image = (Image) componentResourceManager.GetObject("picFooterBanner.Image");
      this.picFooterBanner.Location = new Point(531, 196);
      this.picFooterBanner.Name = "picFooterBanner";
      this.picFooterBanner.Size = new Size(256, 64);
      this.picFooterBanner.SizeMode = PictureBoxSizeMode.AutoSize;
      this.picFooterBanner.TabIndex = 11;
      this.picFooterBanner.TabStop = false;
      this.picBannerFrameColor.Image = (Image) Resources.bannerPreview;
      this.picBannerFrameColor.Location = new Point(492, 9);
      this.picBannerFrameColor.Name = "picBannerFrameColor";
      this.picBannerFrameColor.Size = new Size(333, 181);
      this.picBannerFrameColor.SizeMode = PictureBoxSizeMode.AutoSize;
      this.picBannerFrameColor.TabIndex = 2;
      this.picBannerFrameColor.TabStop = false;
      this.panelStep4.Controls.Add((Control) this.groupBox3);
      this.panelStep4.Controls.Add((Control) this.groupBox2);
      this.panelStep4.Controls.Add((Control) this.groupBox1);
      this.panelStep4.Controls.Add((Control) this.picShuffleUniqueID);
      this.panelStep4.Controls.Add((Control) this.picShuffleProductCode);
      this.panelStep4.Controls.Add((Control) this.label21);
      this.panelStep4.Controls.Add((Control) this.label20);
      this.panelStep4.Controls.Add((Control) this.label19);
      this.panelStep4.Controls.Add((Control) this.txtTitleID);
      this.panelStep4.Controls.Add((Control) this.txtProductCode);
      this.panelStep4.Location = new Point(0, 24);
      this.panelStep4.Name = "panelStep4";
      this.panelStep4.Size = new Size(842, 344);
      this.panelStep4.TabIndex = 9;
      this.panelStep4.Visible = false;
      this.groupBox3.Controls.Add((Control) this.button1);
      this.groupBox3.Controls.Add((Control) this.chkAutoSaveLoadState);
      this.groupBox3.Controls.Add((Control) this.chkEnableRewind);
      this.groupBox3.Location = new Point(437, 190);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(397, 94);
      this.groupBox3.TabIndex = 38;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Features";
      this.button1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Italic, GraphicsUnit.Point, (byte) 0);
      this.button1.Location = new Point(243, 65);
      this.button1.Name = "button1";
      this.button1.Size = new Size(148, 23);
      this.button1.TabIndex = 34;
      this.button1.Text = "Edit buttons layout";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.chkAutoSaveLoadState.Location = new Point(6, 42);
      this.chkAutoSaveLoadState.Name = "chkAutoSaveLoadState";
      this.chkAutoSaveLoadState.Size = new Size(382, 31);
      this.chkAutoSaveLoadState.TabIndex = 36;
      this.chkAutoSaveLoadState.Text = "Enable automatic save && load state when exit from RA menu and opening game respectively";
      this.chkAutoSaveLoadState.UseVisualStyleBackColor = true;
      this.chkEnableRewind.AutoSize = true;
      this.chkEnableRewind.Location = new Point(6, 19);
      this.chkEnableRewind.Name = "chkEnableRewind";
      this.chkEnableRewind.Size = new Size(296, 17);
      this.chkEnableRewind.TabIndex = 35;
      this.chkEnableRewind.Text = "Enable rewind feature (may cause lag on Old 3ds models)";
      this.chkEnableRewind.UseVisualStyleBackColor = true;
      this.groupBox2.Controls.Add((Control) this.label17);
      this.groupBox2.Controls.Add((Control) this.lstBottomScreen);
      this.groupBox2.Controls.Add((Control) this.picBottomScreenPreview);
      this.groupBox2.Location = new Point(437, 11);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(397, 173);
      this.groupBox2.TabIndex = 37;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Bottom screen";
      this.groupBox2.Enter += new EventHandler(this.groupBox2_Enter);
      this.label17.BackColor = Color.Transparent;
      this.label17.Location = new Point(231, 19);
      this.label17.Name = "label17";
      this.label17.Size = new Size(160, 27);
      this.label17.TabIndex = 38;
      this.label17.Text = "Bottom screen preview";
      this.label17.TextAlign = ContentAlignment.MiddleCenter;
      this.lstBottomScreen.FormattingEnabled = true;
      ListBox.ObjectCollection items3 = this.lstBottomScreen.Items;
      object[] items4 = new object[11];
      int index5 = 0;
      string str5 = "No picture (black & light-off bottom screen)";
      items4[index5] = (object) str5;
      int index6 = 1;
      string str6 = "English VC message";
      items4[index6] = (object) str6;
      int index7 = 2;
      string str7 = "German VC message";
      items4[index7] = (object) str7;
      int index8 = 3;
      string str8 = "Spanish VC message";
      items4[index8] = (object) str8;
      int index9 = 4;
      string str9 = "French VC message";
      items4[index9] = (object) str9;
      int index10 = 5;
      string str10 = "Italian VC message";
      items4[index10] = (object) str10;
      int index11 = 6;
      string str11 = "Japanese VC message";
      items4[index11] = (object) str11;
      int index12 = 7;
      string str12 = "Dutch VC message";
      items4[index12] = (object) str12;
      int index13 = 8;
      string str13 = "Portuguese VC message";
      items4[index13] = (object) str13;
      int index14 = 9;
      string str14 = "Russian VC message";
      items4[index14] = (object) str14;
      int index15 = 10;
      string str15 = "Custom image (320x240 no transparency)";
      items4[index15] = (object) str15;
      items3.AddRange(items4);
      this.lstBottomScreen.Location = new Point(6, 19);
      this.lstBottomScreen.Name = "lstBottomScreen";
      this.lstBottomScreen.Size = new Size(219, 147);
      this.lstBottomScreen.TabIndex = 37;
      this.lstBottomScreen.SelectedIndexChanged += new EventHandler(this.lstBottomScreen_SelectedIndexChanged);
      this.picBottomScreenPreview.BackColor = Color.Black;
      this.picBottomScreenPreview.Location = new Point(231, 46);
      this.picBottomScreenPreview.Name = "picBottomScreenPreview";
      this.picBottomScreenPreview.Size = new Size(160, 120);
      this.picBottomScreenPreview.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picBottomScreenPreview.TabIndex = 36;
      this.picBottomScreenPreview.TabStop = false;
      this.groupBox1.Controls.Add((Control) this.label27);
      this.groupBox1.Controls.Add((Control) this.txtCustomResolutionHeight);
      this.groupBox1.Controls.Add((Control) this.label26);
      this.groupBox1.Controls.Add((Control) this.txtCustomResolutionWidth);
      this.groupBox1.Controls.Add((Control) this.radCustomResolution);
      this.groupBox1.Controls.Add((Control) this.radPixelPerfectPAL);
      this.groupBox1.Controls.Add((Control) this.radFullScreen);
      this.groupBox1.Controls.Add((Control) this.picScreenPreview);
      this.groupBox1.Controls.Add((Control) this.pic3DSBackground);
      this.groupBox1.Controls.Add((Control) this.radPixelPerfectNTSC);
      this.groupBox1.Location = new Point(11, 11);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(420, 323);
      this.groupBox1.TabIndex = 33;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Screen size";
      this.label27.AutoSize = true;
      this.label27.Location = new Point(335, 284);
      this.label27.Name = "label27";
      this.label27.Size = new Size(41, 13);
      this.label27.TabIndex = 47;
      this.label27.Text = "Height:";
      this.txtCustomResolutionHeight.Location = new Point(376, 281);
      this.txtCustomResolutionHeight.Name = "txtCustomResolutionHeight";
      this.txtCustomResolutionHeight.Size = new Size(26, 20);
      this.txtCustomResolutionHeight.TabIndex = 46;
      this.txtCustomResolutionHeight.Text = "240";
      this.txtCustomResolutionHeight.TextChanged += new EventHandler(this.txtCustomResolutionHeight_TextChanged);
      this.label26.AutoSize = true;
      this.label26.Location = new Point(267, 284);
      this.label26.Name = "label26";
      this.label26.Size = new Size(38, 13);
      this.label26.TabIndex = 45;
      this.label26.Text = "Width:";
      this.txtCustomResolutionWidth.Location = new Point(305, 281);
      this.txtCustomResolutionWidth.Name = "txtCustomResolutionWidth";
      this.txtCustomResolutionWidth.Size = new Size(26, 20);
      this.txtCustomResolutionWidth.TabIndex = 44;
      this.txtCustomResolutionWidth.Text = "400";
      this.txtCustomResolutionWidth.TextChanged += new EventHandler(this.txtCustomResolutionWidth_TextChanged);
      this.radCustomResolution.AutoSize = true;
      this.radCustomResolution.Location = new Point(206, 282);
      this.radCustomResolution.Name = "radCustomResolution";
      this.radCustomResolution.Size = new Size(63, 17);
      this.radCustomResolution.TabIndex = 43;
      this.radCustomResolution.Text = "Custom:";
      this.radCustomResolution.UseVisualStyleBackColor = true;
      this.radCustomResolution.CheckedChanged += new EventHandler(this.radCustomResolution_CheckedChanged);
      this.radPixelPerfectPAL.AutoSize = true;
      this.radPixelPerfectPAL.Location = new Point(188, 263);
      this.radPixelPerfectPAL.Name = "radPixelPerfectPAL";
      this.radPixelPerfectPAL.Size = new Size(169, 17);
      this.radPixelPerfectPAL.TabIndex = 42;
      this.radPixelPerfectPAL.Text = "320x240 px (pixel perfect PAL)";
      this.radPixelPerfectPAL.UseVisualStyleBackColor = true;
      this.radPixelPerfectPAL.CheckedChanged += new EventHandler(this.radPixelPerfectPAL_CheckedChanged);
      this.radFullScreen.AutoSize = true;
      this.radFullScreen.Location = new Point(11, 282);
      this.radFullScreen.Name = "radFullScreen";
      this.radFullScreen.Size = new Size(181, 17);
      this.radFullScreen.TabIndex = 41;
      this.radFullScreen.Text = "400x240 px (stretched fullscreen)";
      this.radFullScreen.UseVisualStyleBackColor = true;
      this.radFullScreen.CheckedChanged += new EventHandler(this.radFullScreen_CheckedChanged);
      this.picScreenPreview.Image = (Image) Resources.SONIC1;
      this.picScreenPreview.Location = new Point(11, 19);
      this.picScreenPreview.Name = "picScreenPreview";
      this.picScreenPreview.Size = new Size(320, 224);
      this.picScreenPreview.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picScreenPreview.TabIndex = 39;
      this.picScreenPreview.TabStop = false;
      this.pic3DSBackground.BackColor = Color.Black;
      this.pic3DSBackground.Location = new Point(11, 19);
      this.pic3DSBackground.Name = "pic3DSBackground";
      this.pic3DSBackground.Size = new Size(400, 240);
      this.pic3DSBackground.TabIndex = 38;
      this.pic3DSBackground.TabStop = false;
      this.radPixelPerfectNTSC.AutoSize = true;
      this.radPixelPerfectNTSC.Checked = true;
      this.radPixelPerfectNTSC.Location = new Point(11, 263);
      this.radPixelPerfectNTSC.Name = "radPixelPerfectNTSC";
      this.radPixelPerfectNTSC.Size = new Size(178, 17);
      this.radPixelPerfectNTSC.TabIndex = 37;
      this.radPixelPerfectNTSC.TabStop = true;
      this.radPixelPerfectNTSC.Text = "320x224 px (pixel perfect NTSC)";
      this.radPixelPerfectNTSC.UseVisualStyleBackColor = true;
      this.radPixelPerfectNTSC.CheckedChanged += new EventHandler(this.radPixelPerfectNTSC_CheckedChanged);
      this.picShuffleUniqueID.Image = (Image) Resources.random_shuffle;
      this.picShuffleUniqueID.Location = new Point(615, 320);
      this.picShuffleUniqueID.Name = "picShuffleUniqueID";
      this.picShuffleUniqueID.Size = new Size(16, 16);
      this.picShuffleUniqueID.TabIndex = 26;
      this.picShuffleUniqueID.TabStop = false;
      this.picShuffleUniqueID.Click += new EventHandler(this.picShuffleUniqueID_Click);
      this.picShuffleProductCode.Image = (Image) Resources.random_shuffle;
      this.picShuffleProductCode.Location = new Point(519, 320);
      this.picShuffleProductCode.Name = "picShuffleProductCode";
      this.picShuffleProductCode.Size = new Size(16, 16);
      this.picShuffleProductCode.TabIndex = 25;
      this.picShuffleProductCode.TabStop = false;
      this.picShuffleProductCode.Click += new EventHandler(this.picShuffleProductCode_Click);
      this.label21.AutoSize = true;
      this.label21.Location = new Point(538, 301);
      this.label21.Name = "label21";
      this.label21.Size = new Size(44, 13);
      this.label21.TabIndex = 24;
      this.label21.Text = "Title ID:";
      this.label20.AutoSize = true;
      this.label20.Location = new Point(434, 321);
      this.label20.Name = "label20";
      this.label20.Size = new Size(43, 13);
      this.label20.TabIndex = 23;
      this.label20.Text = "GEN-P-";
      this.label19.AutoSize = true;
      this.label19.Location = new Point(442, 300);
      this.label19.Name = "label19";
      this.label19.Size = new Size(75, 13);
      this.label19.TabIndex = 22;
      this.label19.Text = "Product Code:";
      this.txtTitleID.Location = new Point(574, 318);
      this.txtTitleID.MaxLength = 4;
      this.txtTitleID.Name = "txtTitleID";
      this.txtTitleID.Size = new Size(38, 20);
      this.txtTitleID.TabIndex = 21;
      this.txtTitleID.TextChanged += new EventHandler(this.txtUniqueID_TextChanged);
      this.txtProductCode.Location = new Point(478, 318);
      this.txtProductCode.MaxLength = 4;
      this.txtProductCode.Name = "txtProductCode";
      this.txtProductCode.Size = new Size(38, 20);
      this.txtProductCode.TabIndex = 20;
      this.txtProductCode.TextChanged += new EventHandler(this.txtProductCode_TextChanged);
      this.txtGamePublisher.Location = new Point(97, 147);
      this.txtGamePublisher.MaxLength = 64;
      this.txtGamePublisher.Name = "txtGamePublisher";
      this.txtGamePublisher.Size = new Size(246, 20);
      this.txtGamePublisher.TabIndex = 3;
      this.txtGamePublisher.TextChanged += new EventHandler(this.txtGamePublisher_TextChanged);
      this.label5.AutoSize = true;
      this.label5.Location = new Point(8, 150);
      this.label5.Name = "label5";
      this.label5.Size = new Size(83, 13);
      this.label5.TabIndex = 4;
      this.label5.Text = "Game publisher:";
      this.label6.BackColor = SystemColors.Info;
      this.label6.BorderStyle = BorderStyle.FixedSingle;
      this.label6.Location = new Point(349, 147);
      this.label6.Name = "label6";
      this.label6.Size = new Size(484, 20);
      this.label6.TabIndex = 5;
      this.label6.Text = "Don't use developer name, use publisher name. Example: Sega";
      this.label6.TextAlign = ContentAlignment.MiddleLeft;
      this.label7.AutoSize = true;
      this.label7.Location = new Point(8, 177);
      this.label7.Name = "label7";
      this.label7.Size = new Size(61, 13);
      this.label7.TabIndex = 6;
      this.label7.Text = "Game icon:";
      this.pictureBox3.Image = (Image) Resources.icon48;
      this.pictureBox3.InitialImage = (Image) null;
      this.pictureBox3.Location = new Point((int) sbyte.MaxValue, 173);
      this.pictureBox3.Name = "pictureBox3";
      this.pictureBox3.Size = new Size(48, 48);
      this.pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox3.TabIndex = 7;
      this.pictureBox3.TabStop = false;
      this.pictureBox5.Image = (Image) Resources.icon24;
      this.pictureBox5.InitialImage = (Image) null;
      this.pictureBox5.Location = new Point(97, 175);
      this.pictureBox5.Name = "pictureBox5";
      this.pictureBox5.Size = new Size(24, 24);
      this.pictureBox5.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox5.TabIndex = 8;
      this.pictureBox5.TabStop = false;
      this.picIcon24.BackColor = Color.Black;
      this.picIcon24.Location = new Point(99, 177);
      this.picIcon24.Name = "picIcon24";
      this.picIcon24.Size = new Size(20, 20);
      this.picIcon24.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picIcon24.TabIndex = 9;
      this.picIcon24.TabStop = false;
      this.picIcon24.Paint += new PaintEventHandler(this.picIcon24_Paint);
      this.picIcon48.BackColor = Color.Black;
      this.picIcon48.Location = new Point(131, 177);
      this.picIcon48.Name = "picIcon48";
      this.picIcon48.Size = new Size(40, 40);
      this.picIcon48.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picIcon48.TabIndex = 10;
      this.picIcon48.TabStop = false;
      this.picIcon48.Click += new EventHandler(this.picIcon48_Click);
      this.picIcon48.Paint += new PaintEventHandler(this.picIcon48_Paint);
      this.btnLoadIcon.Location = new Point(181, 173);
      this.btnLoadIcon.Name = "btnLoadIcon";
      this.btnLoadIcon.Size = new Size(162, 25);
      this.btnLoadIcon.TabIndex = 4;
      this.btnLoadIcon.Text = "Load icon image";
      this.btnLoadIcon.UseVisualStyleBackColor = true;
      this.btnLoadIcon.Click += new EventHandler(this.btnLoadIcon_Click);
      this.label8.BackColor = SystemColors.Info;
      this.label8.BorderStyle = BorderStyle.FixedSingle;
      this.label8.Location = new Point(349, 173);
      this.label8.Name = "label8";
      this.label8.Size = new Size(484, 48);
      this.label8.TabIndex = 12;
      this.label8.Text = componentResourceManager.GetString("label8.Text");
      this.label8.TextAlign = ContentAlignment.MiddleLeft;
      this.lstInterpolation1.FormattingEnabled = true;
      ListBox.ObjectCollection items5 = this.lstInterpolation1.Items;
      object[] items6 = new object[4];
      int index16 = 0;
      string str16 = "No shrink";
      items6[index16] = (object) str16;
      int index17 = 1;
      string str17 = "Nearest neighbor";
      items6[index17] = (object) str17;
      int index18 = 2;
      string str18 = "Bilinear";
      items6[index18] = (object) str18;
      int index19 = 3;
      string str19 = "Bicubic";
      items6[index19] = (object) str19;
      items5.AddRange(items6);
      this.lstInterpolation1.Location = new Point(111, 228);
      this.lstInterpolation1.Name = "lstInterpolation1";
      this.lstInterpolation1.Size = new Size(231, 56);
      this.lstInterpolation1.TabIndex = 5;
      this.lstInterpolation1.SelectedIndexChanged += new EventHandler(this.lstInterpolation1_SelectedIndexChanged);
      this.label9.AutoSize = true;
      this.label9.Location = new Point(8, 228);
      this.label9.Name = "label9";
      this.label9.Size = new Size(97, 13);
      this.label9.TabIndex = 14;
      this.label9.Text = "Interpolation mode:";
      this.label15.BackColor = SystemColors.Info;
      this.label15.BorderStyle = BorderStyle.FixedSingle;
      this.label15.Location = new Point(349, 228);
      this.label15.Name = "label15";
      this.label15.Size = new Size(484, 30);
      this.label15.TabIndex = 15;
      this.label15.Text = "This is for icons greater than 40x40. It's the image stretching mode that will be applied when resizing. Bicubic is recommended.";
      this.label15.TextAlign = ContentAlignment.MiddleLeft;
      this.label23.AutoSize = true;
      this.label23.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label23.Location = new Point(12, 12);
      this.label23.Name = "label23";
      this.label23.Size = new Size(98, 13);
      this.label23.TabIndex = 32;
      this.label23.Text = "Fill the fields, or";
      this.chkImportIconBin.AutoSize = true;
      this.chkImportIconBin.Location = new Point(111, 11);
      this.chkImportIconBin.Name = "chkImportIconBin";
      this.chkImportIconBin.Size = new Size(196, 17);
      this.chkImportIconBin.TabIndex = 0;
      this.chkImportIconBin.Text = "import a pre-made icon.bin (icon.icn)";
      this.chkImportIconBin.UseVisualStyleBackColor = true;
      this.chkImportIconBin.CheckedChanged += new EventHandler(this.chkImportIconBin_CheckedChanged);
      this.panelStep2.Controls.Add((Control) this.chkHeightStretch);
      this.panelStep2.Controls.Add((Control) this.label25);
      this.panelStep2.Controls.Add((Control) this.label24);
      this.panelStep2.Controls.Add((Control) this.txtLongName);
      this.panelStep2.Controls.Add((Control) this.label4);
      this.panelStep2.Controls.Add((Control) this.label2);
      this.panelStep2.Controls.Add((Control) this.txtShortName);
      this.panelStep2.Controls.Add((Control) this.chkImportIconBin);
      this.panelStep2.Controls.Add((Control) this.label23);
      this.panelStep2.Controls.Add((Control) this.label15);
      this.panelStep2.Controls.Add((Control) this.label9);
      this.panelStep2.Controls.Add((Control) this.lstInterpolation1);
      this.panelStep2.Controls.Add((Control) this.label8);
      this.panelStep2.Controls.Add((Control) this.btnLoadIcon);
      this.panelStep2.Controls.Add((Control) this.picIcon48);
      this.panelStep2.Controls.Add((Control) this.picIcon24);
      this.panelStep2.Controls.Add((Control) this.pictureBox5);
      this.panelStep2.Controls.Add((Control) this.pictureBox3);
      this.panelStep2.Controls.Add((Control) this.label7);
      this.panelStep2.Controls.Add((Control) this.label6);
      this.panelStep2.Controls.Add((Control) this.label5);
      this.panelStep2.Controls.Add((Control) this.txtGamePublisher);
      this.panelStep2.Location = new Point(0, 24);
      this.panelStep2.Name = "panelStep2";
      this.panelStep2.Size = new Size(842, 344);
      this.panelStep2.TabIndex = 0;
      this.panelStep2.Visible = false;
      this.chkHeightStretch.AutoSize = true;
      this.chkHeightStretch.Location = new Point(182, 203);
      this.chkHeightStretch.Name = "chkHeightStretch";
      this.chkHeightStretch.Size = new Size(106, 17);
      this.chkHeightStretch.TabIndex = 42;
      this.chkHeightStretch.Text = "Stretch by height";
      this.chkHeightStretch.UseVisualStyleBackColor = true;
      this.chkHeightStretch.CheckedChanged += new EventHandler(this.chkHeightStretch_CheckedChanged);
      this.label25.BackColor = SystemColors.Info;
      this.label25.BorderStyle = BorderStyle.FixedSingle;
      this.label25.Location = new Point(449, 33);
      this.label25.Name = "label25";
      this.label25.Size = new Size(385, 56);
      this.label25.TabIndex = 41;
      this.label25.Text = componentResourceManager.GetString("label25.Text");
      this.label25.TextAlign = ContentAlignment.MiddleLeft;
      this.label24.AutoSize = true;
      this.label24.Location = new Point(24, 36);
      this.label24.Name = "label24";
      this.label24.Size = new Size(63, 13);
      this.label24.TabIndex = 40;
      this.label24.Text = "Long name:";
      this.txtLongName.Location = new Point(97, 33);
      this.txtLongName.MaxLength = 128;
      this.txtLongName.Multiline = true;
      this.txtLongName.Name = "txtLongName";
      this.txtLongName.Size = new Size(346, 56);
      this.txtLongName.TabIndex = 1;
      this.txtLongName.TextChanged += new EventHandler(this.txtLongName_TextChanged);
      this.label4.BackColor = SystemColors.Info;
      this.label4.BorderStyle = BorderStyle.FixedSingle;
      this.label4.Location = new Point(449, 95);
      this.label4.Name = "label4";
      this.label4.Size = new Size(385, 46);
      this.label4.TabIndex = 38;
      this.label4.Text = "This is -not always- a short version of the game name.\r\nMax 64 characters. It does support accents and any Unicode char.\r\nExample: Sonic the Hedgehog";
      this.label4.TextAlign = ContentAlignment.MiddleLeft;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(24, 98);
      this.label2.Name = "label2";
      this.label2.Size = new Size(64, 13);
      this.label2.TabIndex = 37;
      this.label2.Text = "Short name:";
      this.txtShortName.Location = new Point(97, 95);
      this.txtShortName.MaxLength = 64;
      this.txtShortName.Multiline = true;
      this.txtShortName.Name = "txtShortName";
      this.txtShortName.Size = new Size(346, 46);
      this.txtShortName.TabIndex = 2;
      this.txtShortName.TextChanged += new EventHandler(this.txtShortName_TextChanged);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(842, 441);
      this.Controls.Add((Control) this.lblStep);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.panelStep4);
      this.Controls.Add((Control) this.panelStep3);
      this.Controls.Add((Control) this.panelStep2);
      this.Controls.Add((Control) this.panelStep1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.Name = "frmMain";
      this.Text = "Ultimate GEN-MD Forwarder Maker for 3DS";
      this.Load += new EventHandler(this.frmMain_Load);
      this.panelStep1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((ISupportInitialize) this.picSummaryIcon).EndInit();
      ((ISupportInitialize) this.picOhana).EndInit();
      ((ISupportInitialize) this.pictureBox2).EndInit();
      this.panelStep3.ResumeLayout(false);
      this.panelStep3.PerformLayout();
      ((ISupportInitialize) this.picBannerInnerImage).EndInit();
      this.trkBright.EndInit();
      ((ISupportInitialize) this.picFooterBanner).EndInit();
      ((ISupportInitialize) this.picBannerFrameColor).EndInit();
      this.panelStep4.ResumeLayout(false);
      this.panelStep4.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      ((ISupportInitialize) this.picBottomScreenPreview).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((ISupportInitialize) this.picScreenPreview).EndInit();
      ((ISupportInitialize) this.pic3DSBackground).EndInit();
      ((ISupportInitialize) this.picShuffleUniqueID).EndInit();
      ((ISupportInitialize) this.picShuffleProductCode).EndInit();
      ((ISupportInitialize) this.pictureBox3).EndInit();
      ((ISupportInitialize) this.pictureBox5).EndInit();
      ((ISupportInitialize) this.picIcon24).EndInit();
      ((ISupportInitialize) this.picIcon48).EndInit();
      this.panelStep2.ResumeLayout(false);
      this.panelStep2.PerformLayout();
      this.ResumeLayout(false);
    }

    private enum BannerType
    {
      USA_GENESIS,
      EUR_MEGADRIVE,
    }
  }
}
