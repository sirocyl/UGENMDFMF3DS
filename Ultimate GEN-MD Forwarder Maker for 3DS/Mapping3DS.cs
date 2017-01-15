// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.Mapping3DS
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS
{
  public class Mapping3DS
  {
    public const string BUTTON_GENESIS_A = "input_player1_y_";
    public const string BUTTON_GENESIS_B = "input_player1_b_";
    public const string BUTTON_GENESIS_C = "input_player1_a_";
    public const string BUTTON_GENESIS_UP = "input_player1_up_";
    public const string BUTTON_GENESIS_DOWN = "input_player1_down_";
    public const string BUTTON_GENESIS_LEFT = "input_player1_left_";
    public const string BUTTON_GENESIS_RIGHT = "input_player1_right_";
    public const string BUTTON_GENESIS_START = "input_player1_start_";
    public static string[] RETROARCH_FUNCTIONS;
    public const string RETROARCH_FAST_FORWARD_TOGGLE = "input_toggle_fast_forward_";
    public const string RETROARCH_FAST_FORWARD_HOLD = "input_hold_fast_forward_";
    public const string RETROARCH_LOAD_STATE = "input_load_state_";
    public const string RETROARCH_SAVE_STATE = "input_save_state_";
    public const string RETROARCH_QUIT_GAME = "input_exit_emulator_";
    public const string RETROARCH_REWIND = "input_rewind_";
    public const string RETROARCH_PAUSE_TOGGLE = "input_pause_toggle_";
    public const string RETROARCH_RESET_GAME = "input_reset_";
    public const string RETROARCH_AUDIO_MUTE_TOGGLE = "input_audio_mute_";
    public const string RETROARCH_SLOW_MOTION = "input_slowmotion_";
    public const string RETROARCH_MENU_TOGGLE = "input_menu_toggle_";
    private string _button_3ds_b;
    private string _button_3ds_y;
    private string _button_3ds_select;
    private string _button_3ds_start;
    private string _button_3ds_dpad_up;
    private string _button_3ds_dpad_down;
    private string _button_3ds_dpad_left;
    private string _button_3ds_dpad_right;
    private string _button_3ds_a;
    private string _button_3ds_x;
    private string _button_3ds_l;
    private string _button_3ds_r;
    private string _button_3ds_zl;
    private string _button_3ds_zr;
    private string _button_3ds_circlepad_up;
    private string _button_3ds_circlepad_down;
    private string _button_3ds_circlepad_left;
    private string _button_3ds_circlepad_right;
    private string _button_3ds_c_stick_up;
    private string _button_3ds_c_stick_down;
    private string _button_3ds_c_stick_left;
    private string _button_3ds_c_stick_right;
    private bool _analog_to_digital;
    private bool _using_new_3ds;

    public bool UsingNew3DS
    {
      get
      {
        return this._using_new_3ds;
      }
      set
      {
        this._using_new_3ds = value;
      }
    }

    public bool AnalogToDigital
    {
      get
      {
        return this._analog_to_digital;
      }
      set
      {
        this._analog_to_digital = value;
      }
    }

    public string ButtonB
    {
      get
      {
        return this._button_3ds_b;
      }
      set
      {
        this._button_3ds_b = value;
      }
    }

    public string ButtonY
    {
      get
      {
        return this._button_3ds_y;
      }
      set
      {
        this._button_3ds_y = value;
      }
    }

    public string ButtonSelect
    {
      get
      {
        return this._button_3ds_select;
      }
      set
      {
        this._button_3ds_select = value;
      }
    }

    public string ButtonStart
    {
      get
      {
        return this._button_3ds_start;
      }
      set
      {
        this._button_3ds_start = value;
      }
    }

    public string DPadUp
    {
      get
      {
        return this._button_3ds_dpad_up;
      }
      set
      {
        this._button_3ds_dpad_up = value;
      }
    }

    public string DPadDown
    {
      get
      {
        return this._button_3ds_dpad_down;
      }
      set
      {
        this._button_3ds_dpad_down = value;
      }
    }

    public string DPadLeft
    {
      get
      {
        return this._button_3ds_dpad_left;
      }
      set
      {
        this._button_3ds_dpad_left = value;
      }
    }

    public string DPadRight
    {
      get
      {
        return this._button_3ds_dpad_right;
      }
      set
      {
        this._button_3ds_dpad_right = value;
      }
    }

    public string ButtonA
    {
      get
      {
        return this._button_3ds_a;
      }
      set
      {
        this._button_3ds_a = value;
      }
    }

    public string ButtonX
    {
      get
      {
        return this._button_3ds_x;
      }
      set
      {
        this._button_3ds_x = value;
      }
    }

    public string ButtonL
    {
      get
      {
        return this._button_3ds_l;
      }
      set
      {
        this._button_3ds_l = value;
      }
    }

    public string ButtonR
    {
      get
      {
        return this._button_3ds_r;
      }
      set
      {
        this._button_3ds_r = value;
      }
    }

    public string ButtonZL
    {
      get
      {
        return this._button_3ds_zl;
      }
      set
      {
        this._button_3ds_zl = value;
      }
    }

    public string ButtonZR
    {
      get
      {
        return this._button_3ds_zr;
      }
      set
      {
        this._button_3ds_zr = value;
      }
    }

    public string CirclePadUp
    {
      get
      {
        return this._button_3ds_circlepad_up;
      }
      set
      {
        this._button_3ds_circlepad_up = value;
      }
    }

    public string CirclePadDown
    {
      get
      {
        return this._button_3ds_circlepad_down;
      }
      set
      {
        this._button_3ds_circlepad_down = value;
      }
    }

    public string CirclePadLeft
    {
      get
      {
        return this._button_3ds_circlepad_left;
      }
      set
      {
        this._button_3ds_circlepad_left = value;
      }
    }

    public string CirclePadRight
    {
      get
      {
        return this._button_3ds_c_stick_right;
      }
      set
      {
        this._button_3ds_c_stick_right = value;
      }
    }

    public string CStickUp
    {
      get
      {
        return this._button_3ds_c_stick_up;
      }
      set
      {
        this._button_3ds_c_stick_up = value;
      }
    }

    public string CStickDown
    {
      get
      {
        return this._button_3ds_c_stick_down;
      }
      set
      {
        this._button_3ds_c_stick_down = value;
      }
    }

    public string CStickLeft
    {
      get
      {
        return this._button_3ds_c_stick_left;
      }
      set
      {
        this._button_3ds_c_stick_left = value;
      }
    }

    public string CStickRight
    {
      get
      {
        return this._button_3ds_c_stick_right;
      }
      set
      {
        this._button_3ds_c_stick_right = value;
      }
    }

    static Mapping3DS()
    {
      string[] strArray = new string[11];
      int index1 = 0;
      string str1 = "input_toggle_fast_forward_";
      strArray[index1] = str1;
      int index2 = 1;
      string str2 = "input_hold_fast_forward_";
      strArray[index2] = str2;
      int index3 = 2;
      string str3 = "input_load_state_";
      strArray[index3] = str3;
      int index4 = 3;
      string str4 = "input_save_state_";
      strArray[index4] = str4;
      int index5 = 4;
      string str5 = "input_exit_emulator_";
      strArray[index5] = str5;
      int index6 = 5;
      string str6 = "input_rewind_";
      strArray[index6] = str6;
      int index7 = 6;
      string str7 = "input_pause_toggle_";
      strArray[index7] = str7;
      int index8 = 7;
      string str8 = "input_reset_";
      strArray[index8] = str8;
      int index9 = 8;
      string str9 = "input_audio_mute_";
      strArray[index9] = str9;
      int index10 = 9;
      string str10 = "input_slowmotion_";
      strArray[index10] = str10;
      int index11 = 10;
      string str11 = "input_menu_toggle_";
      strArray[index11] = str11;
      Mapping3DS.RETROARCH_FUNCTIONS = strArray;
    }

    public Mapping3DS(Mapping3DS copy)
    {
      this._using_new_3ds = copy.UsingNew3DS;
      this._analog_to_digital = copy.AnalogToDigital;
      this._button_3ds_a = copy.ButtonA;
      this._button_3ds_b = copy.ButtonB;
      this._button_3ds_x = copy.ButtonX;
      this._button_3ds_y = copy.ButtonY;
      this._button_3ds_select = copy.ButtonSelect;
      this._button_3ds_start = copy.ButtonStart;
      this._button_3ds_dpad_up = copy.DPadUp;
      this._button_3ds_dpad_down = copy.DPadDown;
      this._button_3ds_dpad_left = copy.DPadLeft;
      this._button_3ds_dpad_right = copy.DPadRight;
      this._button_3ds_circlepad_up = copy.CirclePadUp;
      this._button_3ds_circlepad_down = copy.CirclePadDown;
      this._button_3ds_circlepad_left = copy.CirclePadLeft;
      this._button_3ds_circlepad_right = copy.CirclePadRight;
      this._button_3ds_l = copy.ButtonL;
      this._button_3ds_zl = copy.ButtonZL;
      this._button_3ds_r = copy.ButtonR;
      this._button_3ds_zr = copy.ButtonZR;
      this._button_3ds_c_stick_up = copy.CStickUp;
      this._button_3ds_c_stick_down = copy.CStickDown;
      this._button_3ds_c_stick_left = copy.CStickLeft;
      this._button_3ds_c_stick_right = copy.CStickRight;
    }

    public Mapping3DS()
    {
      this._using_new_3ds = false;
      this._analog_to_digital = true;
      this._button_3ds_a = "input_player1_a_";
      this._button_3ds_b = "input_player1_b_";
      this._button_3ds_x = "nul";
      this._button_3ds_y = "input_player1_y_";
      this._button_3ds_select = "nul";
      this._button_3ds_start = "input_player1_start_";
      this._button_3ds_dpad_up = "input_player1_up_";
      this._button_3ds_dpad_down = "input_player1_down_";
      this._button_3ds_dpad_left = "input_player1_left_";
      this._button_3ds_dpad_right = "input_player1_right_";
      this._button_3ds_circlepad_up = "nul";
      this._button_3ds_circlepad_down = "nul";
      this._button_3ds_circlepad_left = "nul";
      this._button_3ds_circlepad_right = "nul";
      this._button_3ds_l = "nul";
      this._button_3ds_zl = "nul";
      this._button_3ds_r = "nul";
      this._button_3ds_zr = "nul";
      this._button_3ds_c_stick_up = "nul";
      this._button_3ds_c_stick_down = "nul";
      this._button_3ds_c_stick_left = "nul";
      this._button_3ds_c_stick_right = "nul";
    }

    public static string TranslateFunctionToHumanReadable(string retroarch_function)
    {
            switch (retroarch_function)
            {
                case "input_toggle_fast_forward_": return "RetroArch function - Fast forward toggle";
                case "input_audio_mute_": return "RetroArch function - Audio mute toggle";
                case "input_rewind_": return "RetroArch function - Rewind";
                case "input_exit_emulator_": return "RetroArch function - Quit RetroArch";
                case "input_player1_a_": return "Genesis controller - C Button";

                case "input_player1_y_": return "Genesis controller - A Button";

                case "input_player1_down_": return "Genesis controller - D-pad Down";

                case "input_load_state_": return "RetroArch function - Load state";

                case "input_player1_b_": return "Genesis controller - B Button";

                case "input_menu_toggle_": return "RetroArch function - Menu toggle";

                case "input_reset_": return "RetroArch function - Reset game";

                case "input_player1_up_": return "Genesis controller - D-pad Up";

                case "input_slowmotion_": return "RetroArch function - Slow motion";

                case "input_hold_fast_forward_": return "RetroArch function - Fast forward hold";

                case "input_player1_right_": return "Genesis controller - D-pad Right";

                case "input_player1_left_": return "Genesis controller - D-pad Left";

                case "input_pause_toggle_": return "RetroArch function - Pause toggle";

                case "input_player1_start_": return "Genesis controller - Start Button";

                case "input_save_state_": return "RetroArch function - Save state";
                default: return "(None)";

            }

        }
      
  }
}
