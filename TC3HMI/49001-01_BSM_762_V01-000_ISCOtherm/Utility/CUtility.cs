namespace App.Utility
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public delegate bool WritePLCValueDelegate(string sPLCVarName, object oValue);
    public delegate bool WritePLCStringDelegate(string sPLCVarName, string oValue, int nLenght);

    public static class CUtility
    {


        public static double ConvMMtoCal(double MM)
        {
            if(Math.Abs(MM) < 99999.0)
                return (double)(MM / 25.4);
            else
                return MM;
        }
        public static float ConvCaltoMMfloat(float Inch)
        { 
            return (float)(Inch * 25.4);
        }
        public static double ConvCaltoMM(double Inch)
        {
            return (double)(Inch * 25.4);
        }

        public static double ConvMpMintoFpMin(double speed)
        {
            return (double)(speed * 3.28084);
        }

        public static double ConvFpMintoMpMin(double speed)
        {
            return (double)(speed / 3.28084);
        }

        public static string DoFormat(string myNumber)
        {
            if (myNumber == null)
                return myNumber;

            if (myNumber == String.Empty)
                return myNumber;

            var temp = Double.Parse(myNumber);
            //temp = Math.Round(temp, 2);

            return String.Format("{0:0.00}", temp);

        }

        public static string DoFormat1(string myNumber)
        {
            if (myNumber == null)
                return myNumber;

            if (myNumber == String.Empty)
                return myNumber;

            var temp = Double.Parse(myNumber);
            //temp = Math.Round(temp, 2);

            return String.Format("{0:0.0}", temp);

        }
        public static string DoFormat2(string myNumber)
        {
            if (myNumber == null)
                return myNumber;

            if (myNumber == String.Empty)
                return myNumber;

            var temp = Double.Parse(myNumber);
            //temp = Math.Round(temp, 2);

            return String.Format("{0:0.000}", temp);

        }

        public static bool CompareArrays(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }

            }
            return true;

        }

        public static class BinaryConverter
        {
            public static bool[] UShortToBinary(ushort numeral)
            {
                // Convert a ushort argument to a byte array.
                var arbyActStatus = BitConverter.GetBytes(numeral);

                // Convert a byte array argument to a bit array.
                BitArray ByteToBinary = new BitArray(arbyActStatus);

                bool[] bits = new bool[ByteToBinary.Count];
                ByteToBinary.CopyTo(bits, 0);

                return bits;
            }
        }
    }
}
