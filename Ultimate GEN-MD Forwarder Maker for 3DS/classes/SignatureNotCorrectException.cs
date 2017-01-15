// Decompiled with JetBrains decompiler
// Type: Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes.SignatureNotCorrectException
// Assembly: Ultimate GEN-MD Forwarder Maker for 3DS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 82020B64-3D3F-47E2-B942-8DE416EAB0C5
// Assembly location: E:\gpl\Ultimate GEN-MD Forwarder Maker for 3DS.exe

using System;

namespace Ultimate_GEN_MD_Forwarder_Maker_for_3DS.classes
{
    public class SignatureNotCorrectException : Exception
    {
        public string BadSignature { get; private set; }

        public string CorrectSignature { get; private set; }

        public long Offset { get; private set; }

        public SignatureNotCorrectException(string BadSignature, string CorrectSignature, long Offset) : base(getMsg(BadSignature, CorrectSignature, Offset))
        {
            this.BadSignature = BadSignature;
            this.CorrectSignature = CorrectSignature;
            this.Offset = Offset;

        }

        private static string getMsg(string BadSignature, string CorrectSignature, long Offset)
        {

            string[] strArray = new string[7];
            int index1 = 0;
            string str1 = "Signature '";
            strArray[index1] = str1;
            int index2 = 1;
            string str2 = BadSignature;
            strArray[index2] = str2;
            int index3 = 2;
            string str3 = "' at 0x";
            strArray[index3] = str3;
            int index4 = 3;
            string str4 = Offset.ToString("X8");
            strArray[index4] = str4;
            int index5 = 4;
            string str5 = " does not match '";
            strArray[index5] = str5;
            int index6 = 5;
            string str6 = CorrectSignature;
            strArray[index6] = str6;
            int index7 = 6;
            string str7 = "'.";
            strArray[index7] = str7;
            return string.Concat(strArray);
        }
    }
}
