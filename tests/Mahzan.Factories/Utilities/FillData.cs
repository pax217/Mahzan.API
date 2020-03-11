﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace Mahzan.Factories.Utilities
{
    [ExcludeFromCodeCoverage]
    public static class FillData
    {
        #region :: Properties ::

        /// <summary>
        /// Valid CURP.
        /// </summary>
        public readonly static string VALID_CURP = "AAAA850101MJCCDA12";

        /// <summary>
        /// Valid RFC.
        /// </summary>
        public readonly static string VALID_RFC = "AAAA890912HU1";

        /// <summary>
        /// Valid email.
        /// </summary>
        public readonly static string VALID_EMAIL = "mail@mail.com";

        /// <summary>
        /// Valid ZIP code.
        /// </summary>
        public readonly static string VALID_ZIP = "12345";

        /// <summary>
        /// Valid phone.
        /// </summary>
        public readonly static string VALID_PHONE = "1234567890";

        /// <summary>
        /// Valid url.
        /// </summary>
        public readonly static string VALID_URL = "http://www.url.com";

        #endregion

        #region :: Methods ::

        /// <summary>
        /// Gets the bool random.
        /// </summary>
        /// <returns>The bool random.</returns>
        public static bool GetBoolRandom()
        {
            return (GetLongRandom() % 2) == 0;
        }

        /// <summary>
        /// Gets the int random.
        /// </summary>
        /// <returns>The int random.</returns>
        public static int GetIntRandom(int min, int max)
        {
            var random = RandomNumberGenerator.Create();

            byte[] buf = new byte[4];
            random.GetBytes(buf);
            int longRand = BitConverter.ToInt32(buf, 0);
            return (Math.Abs(longRand % (max - min)) + min);
        }
        /// <summary>
        /// Gets the long random.
        /// </summary>
        /// <returns>The long random.</returns>
        public static long GetLongRandom()
        {
            var random = RandomNumberGenerator.Create();

            byte[] buf = new byte[4];
            random.GetBytes(buf);
            return Math.Abs(BitConverter.ToInt32(buf, 0));
        }

        /// <summary>
        /// Gets the long random.
        /// </summary>
        /// <returns>The long random.</returns>
        /// <param name="min">Minimum.</param>
        /// <param name="max">Max.</param>
        public static long GetLongRandom(long min, long max)
        {
            var random = RandomNumberGenerator.Create();

            byte[] buf = new byte[8];
            random.GetBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);
            return (Math.Abs(longRand % (max - min)) + min);
        }

        /// <summary>
        /// Gets the date time now.
        /// </summary>
        /// <returns>The date time now.</returns>
        public static DateTime GetDateTimeNow() => DateTime.Now;

        /// <summary>
        /// Gets the alpha numeric string.
        /// </summary>
        /// <returns>The alpha numeric string.</returns>
        /// <param name="length">Length.</param>
        public static string GetAlphaNumericString(int length)
        {
            StringBuilder sb = new StringBuilder();

            while (0 < length--)
            {
                bool is_letter = (GetLongRandom() % 2).Equals(0)
                    , is_upper = (GetLongRandom() % 2).Equals(0);

                sb.Append((char)(is_letter ? is_upper ? GetLongRandom(65, 90) : GetLongRandom(97, 122)
                    : GetLongRandom(48, 57)));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Get the double
        /// </summary>
        /// <param name="numberA">number A</param>
        /// <param name="numberB">number B</param>
        /// <returns>Double</returns>
        public static double GetDouble(int numberA, int numberB)
        {
            var fraction = (int)Math.Floor(Math.Log10(numberB)) + 1;
            var divider = Math.Pow(10, fraction);


            return numberA + (numberB / divider);
        }

        /// <summary>
        /// Gets the json b.
        /// </summary>
        /// <returns>The json b.</returns>
        /// <param name="size">Size.</param>
        public static long[] GetJsonB(int size)
        {
            long[] jsonb = new long[size];

            for (int i = 0; i < size; i++)
            {
                jsonb[i] = GetLongRandom(10, 200);
            }

            return jsonb;
        }

        /// <summary>
        /// Serializes the json b.
        /// </summary>
        /// <returns>The json b.</returns>
        /// <param name="jsonB">Json b.</param>
        public static string SerializeJsonB(long[] jsonB)
        {
            return JsonConvert.SerializeObject(jsonB);
        }

        public static decimal GetDecimal(int roundPalces = 0)
        {
            decimal result = 0;

            if (roundPalces == 0)
            {
                result = new Random().Next(10000) / 13.6m;
            }
            else
            {
                result = Math.Round(new Random().Next(10000) / 13.6m, roundPalces);
            }

            return result;
        }
        #endregion
    }
}
