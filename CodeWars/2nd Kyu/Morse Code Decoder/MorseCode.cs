﻿using System.Collections.Generic;

namespace CodeWars.Morse_Code_Decoder
{
    public static class MorseCode
    {
        

        private static readonly Dictionary<string, string> MorseCodes = new Dictionary<string, string>
        {
            {".-", "A"},
            {"-...", "B"},
            {"-.-.", "C"},
            {"-..", "D"},
            {".", "E"},
            {"..-.", "F"},
            {"--.", "G"},
            {"....", "H"},
            {"..", "I"},
            {".---", "J"},
            {"-.-", "K"},
            {".-..", "L"},
            {"--", "M"},
            {"-.", "N"},
            {"---", "O"},
            {".--.", "P"},
            {"--.-", "Q"},
            {".-.", "R"},
            {"...", "S"},
            {"-", "T"},
            {"..-", "U"},
            {"...-", "V"},
            {".--", "W"},
            {"-..-", "X"},
            {"-.--", "Y"},
            {"--..", "Z"},
            {"-----", "0"},
            {".----", "1"},
            {"..---", "2"},
            {"...--", "3"},
            {"....-", "4"},
            {".....", "5"},
            {"-....", "6"},
            {"--...", "7"},
            {"---..", "8"},
            {"----.", "9"},
            {".-.-.-", "."},
            {"--..--", ","},
            {"..--..", "?"},
            {".----.", "'"},
            {"-.-.--", "!"},
            {"-..-.", "/"},
            {"-.--.", "("},
            {"-.--.-", ")"},
            {".-...", "&"},
            {"---...", ","},
            {"-.-.-.", ";"},
            {"-...-", "="},
            {".-.-.", "+"},
            {"-....-", "-"},
            {"..--.-", "_"},
            {".-..-.", "\""},
            {"...-..-", "$"},
            {".--.-.", "@"},
            {"...---...", "SOS"}
        };

        public static string Get(string m)
        {
            return MorseCodes[m];
        }
    }
}