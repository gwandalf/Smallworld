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
        public Partie config(List<FabriqueUniteI> fu, MonteurPartie mp)
        {
            GameInitiator.INSTANCE.FabriquesUnite = fu;
            GameInitiator.INSTANCE.MonteurPartie = mp;

            //Creation
            return (Partie)GameInitiator.INSTANCE.creerPartie();
        }

        [TestMethod]
        public void TestMethod1()
        {
            //Configuration : peoples and difficulty
            List<FabriqueUniteI> fu = new List<FabriqueUniteI>();
            fu[0] = new FabriqueGaulois();
            fu[1] = new FabriqueNain();
            MonteurPartieDemo mp = new MonteurPartieDemo();
            Partie p = config(fu, mp);

            //Test
            Assert.AreEqual(p.NombreTours, 5);
        }
    }
}
