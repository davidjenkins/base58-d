using System;
using System.Collections.Generic;
using System.Text;

namespace Base58d
{
    public static partial class Base58
    {
        /// <summary>
        /// 
        /// </summary>
        /// <seealso href="https://en.bitcoinwiki.org/wiki/Base58"/>
        public static class Alphabets
        {
            /// <summary>
            /// Bitcoin addresses, IPFS hashes. Default.
            /// </summary>
            /// <seealso href="https://github.com/bitcoin/bitcoin/blob/master/src/base58.cpp"/>
            public static readonly IReadOnlyCollection<char> Bitcoin = Array.AsReadOnly("123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz".ToCharArray());

            /// <summary>
            /// Flickr short URLs.
            /// </summary>
            public static readonly IReadOnlyCollection<char> Flickr = Array.AsReadOnly("123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ".ToCharArray());

            /// <summary>
            /// Ripple addresses.
            /// </summary>
            public static readonly IReadOnlyCollection<char> Ripple = Array.AsReadOnly("rpshnaf39wBUDNEGHJKLM4PQRST7VWXYZ2bcdeCg65jkm8oFqi1tuvAxyz".ToCharArray());
        }
    }
}
