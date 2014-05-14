using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Extentions
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Método responsável por gerar uma string serializada de qualquer objeto em formato xml.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>String no formato XML</returns>
        public static string ToXML(object obj)
        {
            StringBuilder sb = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(sb))
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(writer, obj);
            }

            return sb.ToString();
        }
        public static T FromXMLToObject<T>( string obj)
        {
            using (XmlReader reader = XmlReader.Create(new StringReader(obj)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
