using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace MyTest
{
    [TestClass]
    public class XmlSerializationTest
    {
        private XmlSerialization serialization;
        [TestInitialize]
        public void InitTest()
        {
            this.serialization = new XmlSerialization(@"F:\usermodel.seri");
        }

        [TestMethod]
        public void TestWriteXml()
        {
            UserModel user = new UserModel();
            bool flag = serialization.WriteXml<UserModel>(user);
            Assert.IsTrue(flag);
            Assert.IsFalse(serialization.WriteXml<UserModel>(null));
        }

        [TestMethod]
        public void TestReadXml()
        {
            UserModel user = new UserModel();
            user.LoginName = "aa";
            serialization.WriteXml<UserModel>(user);
            UserModel model = serialization.ReadXml<UserModel>();
            Assert.IsNotNull(model);
            Assert.AreEqual(user.LoginName, model.LoginName);

            //路径不存在，应返回null
            UserModel modelnull = serialization.ReadXml<UserModel>(@"C:\notexists.seri");
            Assert.IsNull(modelnull);
        }
    }
}
