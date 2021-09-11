using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace Base58d.Tests
{
    [TestClass]
    public class ForArray
    {
        [TestMethod]
        public void Encode_array_hello_world()
        {
            var bytes = Encoding.UTF8.GetBytes("Hello World!");
            Assert.AreEqual("2NEpo7TZRRrLZSi2U", Base58.EncodeArray(bytes));
        }

        [TestMethod]
        public void Encode_array_quick_brown_fox()
        {
            var bytes = Encoding.UTF8.GetBytes("The quick brown fox jumps over the lazy dog.");
            Assert.AreEqual("USm3fpXnKG5EUBx2ndxBDMPVciP5hGey2Jh4NDv6gmeo1LkMeiKrLJUUBk6Z", Base58.EncodeArray(bytes));
        }

        [TestMethod]
        public void Encode_array_zeroes()
        {
            var bytes = new byte[10];
            Assert.AreEqual("1111111111", Base58.EncodeArray(bytes));
        }

        [TestMethod]
        [Ignore]
        public void Encode_decode_array_random_guid()
        {
            var guid1 = Guid.NewGuid();
            var guid2 = new Guid(Base58.DecodeArray(Base58.EncodeArray(guid1.ToByteArray())));
            Assert.AreEqual(guid1, guid2);
        }
    }
}