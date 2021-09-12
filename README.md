# What is this?

A simple Base58 encoder/decoder for .NET (written in C#).

* Use it convert long Guid strings into shorter codes
  * e.g. "bf75bdea-1fff-49ee-9122-c0c47da563e8" becomes "VzEH6jbCKMrRVMiaKgfZmH"
* Use it in your Bitcoin projects.
* Use it as a door stop.
* USe it as compost.

# Why Base58?

From [https://tools.ietf.org/id/draft-msporny-base58-01.html](https://tools.ietf.org/id/draft-msporny-base58-01.html)

> Base58 is designed with a number of usability characteristics in mind that Base64 does not consider. First, similar looking letters are omitted such as 0 (zero), O (capital o), I (capital i) and l (lower case L). Doing so eliminates the possibility of a human being mistaking similar characters for the wrong character. Second, the non-alphanumeric characters + (plus), = (equals), and / (slash) are omitted to make it possible to use Base58 values in all modern file systems and URL schemes without the need for further system-specific encoding schemes. Third, by using only alphanumeric characters, easy double-click or double tap selection is possible in modern computer interfaces.

See also [https://en.bitcoinwiki.org/wiki/Base58](https://en.bitcoinwiki.org/wiki/Base58)

# Differences from Bitcoin

* Decode() does not support input with leading or trailing white-space.
* Base58 uses Bitcoin's alphabet by default, but supports use of non-standard alphabets (like those used for Ripple addresses and Flickr short URLs).

# License

Base58 algorithm was invented by the [Bitcoin project](https://github.com/bitcoin/bitcoin). Base58d contains a simple C# port of Bitcoin's [EncodeBase58](https://github.com/bitcoin/bitcoin/blob/master/src/base58.cpp) and [DecodeBase58](https://github.com/bitcoin/bitcoin/blob/master/src/base58.cpp) functions, which are written in C++ and available under the terms of its [MIT license](LICENSE_BITCOIN). Any portions of Base68d considered the property of Bitcoin, are also available under the terms of this license.

All other portions of Base58d are available under the terms of its own [MIT license](LICENSE).

# References

* [base58.cpp](https://github.com/bitcoin/bitcoin/blob/master/src/base58.cpp) (includes EncodeBase58 and DecodeBase58)
* [Bitcoin repo on GitHub](https://github.com/bitcoin/bitcoin)
* [Bitcoin source code license](https://github.com/bitcoin/bitcoin/blob/master/COPYING) (current)