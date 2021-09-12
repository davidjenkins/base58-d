
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Base58d
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso href="https://github.com/bitcoin/bitcoin/blob/master/src/base58.cpp"/>
    public static partial class Base58
    {
        /// <summary>
        /// Converts an array of 8-bit unsigned integers to its equivalent string representation
        /// that is encoded with base-58 digits.
        /// Uses standard (Bitcoin) alphabet.
        /// </summary>
        /// <param name="input">An array of 8-bit unsigned integers.</param>
        /// <returns>The string representation, in base 58, of the contents of input.</returns>
        /// <remarks>C# port of Bitcoin's EncodeBase58 function.</remarks>
        /// <seealso href="https://github.com/bitcoin/bitcoin/blob/master/src/base58.cpp"/>
        public static string EncodeArray(byte[] input)
        {
            return EncodeArray(input, Alphabets.Bitcoin);
        }

        /// <summary>
        /// Converts an array of 8-bit unsigned integers to its equivalent string representation
        /// that is encoded with base-58 digits.
        /// </summary>
        /// <param name="input">An array of 8-bit unsigned integers.</param>
        /// <param name="alphabet">
        /// Alphabet to use in conversion.
        /// Allows non-standard alphabets.
        /// </param>
        /// <returns>The string representation, in base 58, of the contents of input.</returns>
        /// <remarks>C# port of Bitcoin's EncodeBase58 function.</remarks>
        /// <seealso href="https://github.com/bitcoin/bitcoin/blob/master/src/base58.cpp"/>
        private static string EncodeArray(byte[] input, IEnumerable<char> alphabet)
        {
            // Skip & count leading zeroes.
            int zeroes = input.TakeWhile(x => x == 0).Count(); ;
            int length = 0;
            input = input.Skip(zeroes).ToArray();
            // Allocate enough space in big-endian base58 representation.
            int size = input.Length * 138 / 100 + 1; // log(256) / log(58), rounded up.
            byte[] b58 = new byte[size];
            // Process the bytes.
            foreach (byte b in input)
            {
                int carry = b;
                int i = 0;
                // Apply "b58 = b58 * 256 + ch".
                // BITCOIN writes to array in reverse (end to beginning)
                // DOTNET will write beginning to end and reverse array later
                for (; (carry != 0 || i < length) && (i != b58.Length); i++)
                {
                    byte it = b58[i];
                    carry += 256 * it;
                    b58[i] = (byte)(carry % 58);
                    carry /= 58;
                }

                if (carry != 0)
                    throw new Exception();
                length = i;
            }
            // Skip leading zeroes in base58 result.
            // BITCOIN b58 array has leading zeroes because it uses reverse iterator when writing
            // DOTNET b58 array has trailing zeroes because no reverse iterator used when writing
            // DOTNET reverses b58 array here to re-align with BITCOIN
            b58 = b58.Take(length).Reverse().SkipWhile(x => x == 0).ToArray();
            // Translate the result into a string.
            StringBuilder str = new StringBuilder(zeroes + b58.Length);
            // BITCOIN pszBase58
            // DOTNET alphabet
            str.Append(new String(alphabet.ElementAt(0), zeroes));
            foreach (byte b in b58)
            {
                str.Append(alphabet.ElementAt(b));
            }
            return str.ToString();
        }
    }
}