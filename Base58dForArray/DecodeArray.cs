using System;
using System.Collections.Generic;

namespace Base58d
{
    public static partial class Base58
    {
        public static byte[] DecodeArray(string base58)
        {
            throw new NotImplementedException();
        }

        public static byte[] DecodeArray(string base58, IReadOnlyCollection<char> alphabet)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <seealso href="https://github.com/bitcoin/bitcoin/blob/master/src/util/strencodings.h"/>
        /// <returns></returns>
        static bool IsSpace(char c)
        {
            return c == ' ' || c == '\f' || c == '\n' || c == '\r' || c == '\t' || c == '\v';
        }
    }
}