using System;
using System.Collections.Generic;
using System.Text;

namespace Base58d
{
    public static partial class Base58
    {
        // TODO: add check that encoding is single-byte
        // TODO: auto-calc DecodeMap
        // TODO: auto-calc EncodeMap
        // TODO: auto-calc ZeroRune
        // TODO: add constructor accepting Alphabet and Encoding
        // TODO: add check that alphabet characters are 0-127
        // TODO: add check that alphabet contains no white-space
        // TODO: add check that alphabet contains letters and digits only
        // TODO: add check that alphabet contains 58 characters
        // TODO: add check that alphabet contains unique characters
        // TODO: make members read-only
        private class Map
        {
            /// <summary>
            /// The 58 characters to use, in 0-57 order.
            /// </summary>
            internal string Alphabet;
            /// <summary>
            /// Map of possible byte values, in 0-255 order, and corresponding rune integral values.
            /// </summary>
            internal IReadOnlyCollection<sbyte> DecodeMap;
            /// <summary>
            /// The 58 characters to use, in 0-57 order.
            /// </summary>
            internal IReadOnlyCollection<byte> EncodeMap;
            internal Encoding Encoding;
            internal byte ZeroRune;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <seealso href="https://en.bitcoinwiki.org/wiki/Base58"/>
        private static class Maps
        {
            /// <summary>
            /// Bitcoin addresses, IPFS hashes. Default.
            /// </summary>
            /// <seealso href="https://github.com/bitcoin/bitcoin/blob/master/src/base58.cpp"/>
            internal static readonly Map Bitcoin = new Map
            {
                Alphabet = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz",
                DecodeMap = Array.AsReadOnly(new sbyte[]
                {
                    -1,-1,-1,-1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1,-1,-1,
                    -1,-1,-1,-1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1,-1,-1,
                    -1,-1,-1,-1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1,-1,-1,
                    -1, 0, 1, 2, 3, 4, 5, 6,  7, 8,-1,-1,-1,-1,-1,-1,
                    -1, 9,10,11,12,13,14,15, 16,-1,17,18,19,20,21,-1,
                    22,23,24,25,26,27,28,29, 30,31,32,-1,-1,-1,-1,-1,
                    -1,33,34,35,36,37,38,39, 40,41,42,43,-1,44,45,46,
                    47,48,49,50,51,52,53,54, 55,56,57,-1,-1,-1,-1,-1,
                    -1,-1,-1,-1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1,-1,-1,
                    -1,-1,-1,-1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1,-1,-1,
                    -1,-1,-1,-1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1,-1,-1,
                    -1,-1,-1,-1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1,-1,-1,
                    -1,-1,-1,-1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1,-1,-1,
                    -1,-1,-1,-1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1,-1,-1,
                    -1,-1,-1,-1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1,-1,-1,
                    -1,-1,-1,-1,-1,-1,-1,-1, -1,-1,-1,-1,-1,-1,-1,-1,
                }),
                EncodeMap = Array.AsReadOnly(Encoding.ASCII.GetBytes("123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz")),
                Encoding = Encoding.ASCII,
                ZeroRune = 49 // ASCII '1'
            };
        }
    }
}
