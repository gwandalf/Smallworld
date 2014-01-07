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

        public Saver()
        {
        }

        public void ToXML(Object p, string name)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer xmlSerializer = new XmlSerializer(p.GetType());
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, p);
                xmlStream.Position = 0;
                xmlDoc.Load(xmlStream);
                xmlDoc.Save("..\\..\\Resources\\Saves\\" + name + ".xml");
            }
        }

        public Partie charger(string name)
        {
            var serializer = new XmlSerializer(typeof(Partie));
            using (var reader = XmlReader.Create("..\\..\\Resources\\Saves\\" + name + ".xml"))
            {
                var partie = (Partie)serializer.Deserialize(reader);
                partie.Carte.generateCases();
                partie.Carte.linkJoueurs(partie.Joueurs);
                return partie;
            }
        }
    }
}
