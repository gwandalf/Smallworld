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
        public CreationTest()
        {
            List<FabriqueI> fi = new List<FabriqueI>(2);
            fi.Add(new Fabrique<Gaulois>());
            fi.Add(new Fabrique<Nain>());
            MonteurPartieDemo mp = new MonteurPartieDemo();

            GameInitiator.INSTANCE.FabriquesUnite = fi;
            GameInitiator.INSTANCE.MonteurPartie = mp;

            //Creation
            partie = (Partie)GameInitiator.INSTANCE.creerPartie();
        }

        private Partie partie;
        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

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

        [TestMethod]
        public void mapInitialization()
        {
            //Test
            Assert.AreEqual(partie.Carte.Dim, partie.Carte.Cases[0].Count);
        }

        [TestMethod]
        public void flyWeightWorks()
        {
            FabriqueCase fab = new FabriqueCase();
            Assert.IsNotNull(fab.Desert);
        }

        //test : 
        // - if each concreate case of the map is not null ;
        // - if each case is generated only once
        // - if the correspondance number/type is respected
        //      (0 : desert ; 1 --> eau ; 2 --> foret ; 3 --> montagne ; 4 --> plaine)
        [TestMethod]
        public void mapCasesGeneration()
        {

            CaseI[] mapKey = { partie.Carte.Fabrique.Desert,
                             partie.Carte.Fabrique.Eau,
                             partie.Carte.Fabrique.Foret,
                             partie.Carte.Fabrique.Montagne,
                             partie.Carte.Fabrique.Plaine};
            bool res = true;
            int i = 0;
            foreach (List<CaseI> rang in partie.Carte.Cases)
            {
                int j = 0;
                foreach (CaseI c in rang)
                {
                    res = res && (c != null) && (c == mapKey[partie.Carte.CarteW.getCases(i, j)]);
                    j++;
                }
                i++;
            }
            //Test
            Assert.IsTrue(res);
        }
    }
}
