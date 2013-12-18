using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wrapper;
using Modele.Jeu;
using Modele.Creation;
using System.Collections.Generic;

namespace test
{
    [TestClass]
    public class CreationTest
    {
        //Configuration : peoples and difficulty
        public unsafe Partie config(List<FabriqueI> fu, MonteurPartie mp)
        {
            GameInitiator.INSTANCE.FabriquesUnite = fu;
            GameInitiator.INSTANCE.MonteurPartie = mp;

            //Creation
            return (Partie)GameInitiator.INSTANCE.creerPartie();
        }

        [TestMethod]
        public void TestMethod1()
        {
            int i = 5;
            //Configuration : peoples and difficulty
            List<FabriqueI> fi = new List<FabriqueI>(2);
            fi.Add(new Fabrique<Gaulois>());
            fi.Add(new Fabrique<Nain>());
            MonteurPartieDemo mp = new MonteurPartieDemo();
            Partie p = config(fi, mp);

            //Test
            Assert.AreEqual(p.NombreTours, i);
        }

        // testons si une unité est bien sur la case où elle doit être et si la case reconnaît bien l'unité
        [TestMethod]
        public void unitesLocation()
        {
            int i = 5;
            //Configuration : peoples and difficulty
            List<FabriqueI> fi = new List<FabriqueI>(2);
            fi.Add(new Fabrique<Gaulois>());
            fi.Add(new Fabrique<Nain>());
            MonteurPartieDemo mp = new MonteurPartieDemo();
            Partie p = config(fi, mp);

            //test variables
            //expected location for each player
            bool[] expLoc = {true, true};
            int[] loc = {0, p.Carte.Dim};

            int k = 0;
            foreach (JoueurI j in p.Joueurs)
            {
                foreach (UniteI u in j.Unites)
                {
                    expLoc[k] = expLoc[k] && (((Tuple<int, int>) u.Carte.PositUnite[u]).Item1 == loc[k]
                                                && ((Tuple<int, int>)u.Carte.PositUnite[u]).Item2 == loc[k]);
                }
                k++;
            }

            //Test
            Assert.IsTrue(expLoc[0] && expLoc[1]);
        }
    }
}
