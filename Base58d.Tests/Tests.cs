using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace Base58d
{
    [TestClass]
    public class Tests
    {
        /// <summary>
        /// Uses confirmed results from Bitcoin code.
        /// </summary>
        [TestMethod]
        public void Encode_hello_world()
        {
            var bytes = Encoding.UTF8.GetBytes("Hello World!");
            Assert.AreEqual("2NEpo7TZRRrLZSi2U", Base58.EncodeArray(bytes));
        }

        /// <summary>
        /// Uses confirmed results from Bitcoin code.
        /// </summary>
        [TestMethod]
        public void Encode_quick_brown_fox()
        {
            var bytes = Encoding.UTF8.GetBytes("The quick brown fox jumps over the lazy dog.");
            Assert.AreEqual("USm3fpXnKG5EUBx2ndxBDMPVciP5hGey2Jh4NDv6gmeo1LkMeiKrLJUUBk6Z", Base58.EncodeArray(bytes));
        }

        [TestMethod]
        public void Encode_zeroes()
        {
            var bytes = new byte[10];
            Assert.AreEqual("1111111111", Base58.EncodeArray(bytes));
        }

        [TestMethod]
        public void Encode_decode_random_guid()
        {
            var guid = Guid.NewGuid();
            var guidReturned = new Guid(Base58.DecodeArray(Base58.EncodeArray(guid.ToByteArray())));
            Assert.AreEqual(guid, guidReturned);
        }

        [TestMethod]
        public void Encode_decode_known_guid()
        {
            var guid = Guid.Parse("bf75bdea-1fff-49ee-9122-c0c47da563e8");
            var test = Base58.EncodeArray(guid.ToByteArray());
            var guidReturned = new Guid(Base58.DecodeArray(Base58.EncodeArray(guid.ToByteArray())));
            Assert.AreEqual(guid, guidReturned);
        }

        [TestMethod]
        public void Encode_decode_lorem_ipsum_html()
        {
            const string text = " <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p> ";
            var bytes = Encoding.UTF8.GetBytes(text);
            var textReturned = Encoding.UTF8.GetString(Base58.DecodeArray(Base58.EncodeArray(bytes)));
            Assert.AreEqual(text, textReturned);
        }
    }
}