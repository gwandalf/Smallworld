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
        public Partie config(List<FabriqueI> fu, MonteurPartie mp)
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
    }
}
