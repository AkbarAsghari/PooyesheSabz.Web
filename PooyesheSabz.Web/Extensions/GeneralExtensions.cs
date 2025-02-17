﻿using MD.PersianDateTime.Standard;
using PooyesheSabz.Web.Utilities;
using System.Globalization;
using System.Text;

namespace PooyesheSabz.Web.Extensions
{
    public static class GeneralExtensions
    {
        public static string Separate3Digits(this long value) => value.ToString("N0");

        public static string Separate3Digits(this int value) => ((long)value).Separate3Digits();

        public static string ToPersianDateTime(this DateTime value) => new PersianDateTime(value).ToLongDateTimeString();

        static Dictionary<char, char> LettersDictionaryFaToEn = new Dictionary<char, char>() {
            {'۰', '0'},
            {'۱', '1'},
            {'۲', '2'},
            {'۳', '3'},
            {'۴', '4'},
            {'۵', '5'},
            {'۶', '6'},
            {'۷', '7'},
            {'۸', '8'},
            {'۹', '9'}
        };

        static Dictionary<char, char> LettersDictionaryEnToFa = new Dictionary<char, char>() {
            {'0', '۰'},
            {'1', '۱'},
            {'2', '۲'},
            {'3', '۳'},
            {'4', '۴'},
            {'5', '۵'},
            {'6', '۶'},
            {'7', '۷'},
            {'8', '۸'},
            {'9', '۹'}
        };

        public static string PersianToEnglishNumbers(this string persianStr)
        {
            StringBuilder sb = new StringBuilder(persianStr);
            foreach (var item in persianStr.Where(x => LettersDictionaryFaToEn.Keys.Contains(x)))
                sb.Replace(item, LettersDictionaryFaToEn[item]);
            return sb.ToString();
        }

        public static string EnglishToPersianNumbers(this string persianStr)
        {
            StringBuilder sb = new StringBuilder(persianStr);
            foreach (var item in persianStr.Where(x => LettersDictionaryEnToFa.Keys.Contains(x)))
                sb.Replace(item, LettersDictionaryEnToFa[item]);
            return sb.ToString();
        }

        public static string CalcRelativeTime(this DateTime dateTime)
        {
            return RelativeTimeCalculator.Calc(dateTime);
        }
    }
}
