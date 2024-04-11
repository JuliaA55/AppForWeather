using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Homework_Weather_
{
    public class Serializer
    {
        public string Serialize<T>(T myType)
        {
            XmlSerializer serializer = new XmlSerializer(myType.GetType());
            using (StringWriter textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, myType);
                return textWriter.ToString();
            }
        }

        public T Deserialize<T>(string input) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(input))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
