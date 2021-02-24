using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeWars.Morse_Code_Decoder
{
    public class Decoder
    {
        

        public Decoder()
        {

        }

        private static string decodeSignal(KMeans km, string sig, string pause)
        {
            var res = "";
            var sigLength = sig.Length;
            var pauseLength = pause.Length;
            var sigClusterByPoint = km.FindClusterByPoint(sigLength);
            var pauseClusterByPoint = km.FindClusterByPoint(pauseLength);
            switch (sigClusterByPoint)
            {
                case 0:
                    res += ".";
                    break;
                case 1:
                    res += "-";
                    break;
            }

            switch (pauseClusterByPoint)
            {
                case 1:
                    res += " ";
                    break;
                case 2:
                    res += "   ";
                    break;
            }

            return res;
        }

        public static string decodeBitsAdvanced(string bitStream)
        {
            var morseCode = new string("");
            if (string.IsNullOrEmpty(bitStream)
                || !bitStream.Contains("1"))
            {
                return morseCode;
            }

            bitStream = Regex.Replace(bitStream, @"^0+", string.Empty);
            //  remove leading 0's
            bitStream = Regex.Replace(bitStream, @"0+$", string.Empty);
            //  remove trailing 0's
            var km = new KMeans(bitStream);
            km.Run();
            var ones = Regex.Split(bitStream, @"0+");
            var zeros = Regex.Split(bitStream, @"1+");
            for (var i = 0; i < ones.Length - 1; i++)
            {
                morseCode += decodeSignal(km, ones[i], zeros[i + 1]);
            }

            morseCode += decodeSignal(km, ones[^1], "");
            return morseCode;
        }

        private static string decodeLetter(string letterCode, string space)
        {
            var letter = "";
            letter += MorseCode.Get(letterCode);
            
            if (space.Length == 3)
            {
                letter += " ";
            }

            return letter;
        }

        public static string decodeMorse(string morseCode)
        {
            if (morseCode.Equals(new string("")))
            {
                return "";
            }

            var msg = "";
            morseCode = morseCode.Trim();
            var letters = Regex.Split(morseCode, @" +");
            //  makes an array of letters in morse code
            var spaces = Regex.Split(morseCode, @"[.-]+");
            //  makes an array of spaces in code
            for (var i = 0; i < letters.Length - 1; i++)
            {
                msg += decodeLetter(letters[i], spaces[i + 1]);
            }

            msg += decodeLetter(letters[^1], "");
            return msg;
        }



    }


}

