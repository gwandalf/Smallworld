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

        private string path;
        public string Path
        {
            get { return path; }
        }

        private string[] files;
        public string[] Files
        {
            get
            {
                if (files == null)
                {
                    string[] brut;
                    brut = Directory.GetFiles(path);
                    files = new string[brut.Length];
                    for (int i = 0; i < brut.Length; i++)
                    {
                        string[] fic = brut[i].Split('\\');
                        string[] name = fic[fic.Length - 1].Split('.');
                        files[i] = name[0];
                    }
                }
                return files;
            }
        }

        public Saver()
        {
            path = "..\\..\\Resources\\Saves\\";
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
                xmlDoc.Save(path + name + ".xml");
            }
        }

        public Partie charger(string name)
        {
            var serializer = new XmlSerializer(typeof(Partie));
            using (var reader = XmlReader.Create(path + name + ".xml"))
            {
                var partie = (Partie)serializer.Deserialize(reader);
                partie.Carte.generateCases();
                partie.Carte.linkJoueurs(partie.Joueurs);
                return partie;
            }
        }
    }
}
