using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modele.Jeu;
using Modele.Creation;

namespace test
{
    /// <summary>
    /// Description résumée pour UnitTest1
    /// </summary>
    [TestClass]
    public class DeroulementPartie
    {
        public DeroulementPartie()
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

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void whoCanBeFirst()
        {
            Assert.IsTrue((partie.Joueurs[0].Turn && !partie.Joueurs[1].Turn)
                || (!partie.Joueurs[0].Turn && partie.Joueurs[1].Turn));
        }
    }
}
