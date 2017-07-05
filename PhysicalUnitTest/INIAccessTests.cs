using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Physical.UnitTest
{
    [TestClass]
    public sealed class INIAccessTests
    {
        private INIAccess access;

        [TestInitialize]
        public void TestInitialize()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Lab.ini");

            this.access = new INIAccess(path);
        }

        [TestMethod]
        public void GetValueTest_傳入section為WebSite_傳入key為Google_預期回傳Google網址()
        {
            var section = "WebSite";

            var key = "Google";

            var expected = @"https://www.google.com/";

            var actual = access.GetValue(section, key);

            Assert.AreEqual(expected, actual);
        }
    }
}