using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace MyTest
{
    [TestClass]
    public class XmlSerializationTest
    {
        [TestMethod]
        public void TestWriteXml()
        {
            UserModel user = new UserModel();
            XmlSerialization serialization = new XmlSerialization();
            bool flag = serialization.WriteXml<UserModel>(user);
            Assert.IsTrue(flag);
        }
    }
}
