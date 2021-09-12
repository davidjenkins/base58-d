using System;
using System.Collections.Generic;
using System.Text;

namespace Base58d
{
    [Obsolete("Use Map instead.")]
    public static partial class Base58
    {
        /// <summary>
        /// 
        /// </summary>
        /// <seealso href="https://en.bitcoinwiki.org/wiki/Base58"/>
        private static class Alphabets
        {
            /// <summary>
            /// Bitcoin addresses, IPFS hashes. Default.
            /// </summary>
            /// <seealso href="https://github.com/bitcoin/bitcoin/blob/master/src/base58.cpp"/>
            internal static readonly IReadOnlyCollection<char> Bitcoin = Array.AsReadOnly("123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz".ToCharArray());
        }
    }
}
