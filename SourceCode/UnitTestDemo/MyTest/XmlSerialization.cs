using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization; 

namespace MyTest
{
    class XmlSerialization
    {
        private string filePath;

        public XmlSerialization(string filePath)
        {
            this.filePath = filePath;
        }

        public bool WriteXml<T>(T model, string filePath = null) where T : class
        {
            bool result = false;
            if (model == null)
            {
                return result;
            }

            if (string.IsNullOrEmpty(filePath))
            {
                filePath = this.filePath;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter tr = new StreamWriter(filePath))
            {
                serializer.Serialize(tr, model);
                tr.Close();
                result = true;
            }

            return result;
        }

        public T ReadXml<T>(string filePath = null) where T : class
        {
            T model = null;
            if (string.IsNullOrEmpty(filePath))
            {
                filePath = this.filePath;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextReader tr = null;
            try
            {
                tr = new StreamReader(filePath);
                model = (T)serializer.Deserialize(tr);
            }
            catch { }
            finally
            {
                if (tr != null)
                {
                    tr.Close();
                    tr.Dispose();
                }
            }

            return model;
        }
    }
}
