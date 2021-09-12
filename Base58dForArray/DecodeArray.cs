using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base58d
{
    public static partial class Base58
    {
        public static byte[] DecodeArray(string input)
        {
            return DecodeArray(input, Maps.Bitcoin);
        }

        private static byte[] DecodeArray(string input, Map map)
        {
            var bytes = map.Encoding.GetBytes(input.Trim()).ToArray();
            return DecodeArray(bytes, Maps.Bitcoin);
        }

        private static byte[] DecodeArray(byte[] input, Map map)
        {
            // get the character that represents 0x0 according to the curent map
            byte zeroRune = map.ZeroRune; // same as map.EncodeMap.ElementAt(0);

            // count and skip leading "zeroes"
            // leading zeroes have a 1:1 mapping and require no calculation
            int zeroes = 0;
            input = input.SkipWhile(x => { if (x == zeroRune) { zeroes++; return true; } else { return false; } }).ToArray();

            // start count of bytes that follow leading "zeroes"
            // these need to be mathematically calculated
            int length = 0;

            // create buffer for mathematical calculations & mutations
            // allocate enough space in big-endian base256 representation.
            int size = input.Length * 733 / 1000 + 1; // log(58) / log(256), rounded up.
            byte[] b256 = new byte[size];

            // process remaining characters
            foreach (byte b in input)
            {
                // lookup current character in map to find its corresponding integral value
                int carry = map.DecodeMap.ElementAt(b);
                if (carry == -1)
                    throw new ArgumentException($"Invalid character ({b}) found.", nameof(input));

                // perform the Base58 magic
                int i = 0;
                for (; (carry != 0 || i < length) && (i != b256.Length); ++i)
                {
                    byte it = b256[i];
                    carry += 58 * it;
                    b256[i] = (byte)(carry % 256);
                    carry /= 256;
                }
                if (carry != 0)
                    throw new Exception();
                length = i;
            }

            // keep used portion of buffer and reverse it
            // all done
            return b256.Take(length).Reverse().ToArray();
        }
    }
}