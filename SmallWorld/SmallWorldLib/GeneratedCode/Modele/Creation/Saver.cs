using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Modele.Jeu;

namespace Modele.Creation
{
    public sealed class Saver
    {
        public static readonly Saver INSTANCE = new Saver();
        private int count;

        public Saver()
        {
            count = 1;
        }

        public string ToXML(Object p)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer xmlSerializer = new XmlSerializer(p.GetType());
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, p);
                xmlStream.Position = 0;
                xmlDoc.Load(xmlStream);
                xmlDoc.Save("..\\..\\Resources\\game" + count + ".xml");
                count++;
                return xmlDoc.InnerXml;
            }
        }
    }
}
