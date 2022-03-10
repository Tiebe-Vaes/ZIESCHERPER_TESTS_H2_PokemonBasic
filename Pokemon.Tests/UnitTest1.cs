using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPClassBasicsTesterLibrary;
using System;

namespace Pokemon.Tests
{
    [TestClass]
    public class UnitTest1
    {
       
        [TestMethod]
        public void BasicStatsProps()
        {
            TimsEpicClassAnalyzer tester = new TimsEpicClassAnalyzer(new PokemonGottaCatchmAll.Pokemon());

            tester.CheckFullProperty("HP_Base", typeof(int));
            tester.CheckFullProperty("Attack_Base", typeof(int));
            tester.CheckFullProperty("Defense_Base", typeof(int));
            tester.CheckFullProperty("SpecialAttack_Base", typeof(int));
            tester.CheckFullProperty("SpecialDefense_Base", typeof(int));
            tester.CheckFullProperty("Speed_Base", typeof(int));

        }
        [TestMethod]
        public void ExtraStatsProps()
        {
            TimsEpicClassAnalyzer tester = new TimsEpicClassAnalyzer(new PokemonGottaCatchmAll.Pokemon());

            tester.CheckAutoProperty("Naam", typeof(string));
            tester.CheckAutoProperty("Type", typeof(string));
            tester.CheckAutoProperty("Nummer", typeof(int));
        }

        [TestMethod]
        public void LevelTest()
        {
            TimsEpicClassAnalyzer tester = new TimsEpicClassAnalyzer(new PokemonGottaCatchmAll.Pokemon());

            if (tester.CheckFullProperty("Level", typeof(int), propType: TimsEpicClassAnalyzer.PropertyTypes.PrivateSetPublicGet))
            {
                if (tester.CheckMethod("VerhoogLevel", typeof(void)))
                {
                    int startLevel = (int)tester.GetProp("Level");
                    for (int i = 0; i < 5; i++)
                    {
                        tester.TestMethod("VerhoogLevel", null);
                    }
                    Assert.AreEqual(startLevel + 5, tester.GetProp("Level"), "VerhoogLevel in combinatie lijkt niet te werken");
                }
            }
        }

        [TestMethod]
        public void StatistiekenTest()
        {
            TimsEpicClassAnalyzer tester = new TimsEpicClassAnalyzer(new PokemonGottaCatchmAll.Pokemon());

            if (tester.CheckFullProperty("Average", typeof(double), propType: TimsEpicClassAnalyzer.PropertyTypes.NoSet))
            {
                tester.SetProp("HP_Base", 30);
                tester.SetProp("Attack_Base", 30);
                tester.SetProp("Defense_Base", 30);
                tester.SetProp("SpecialAttack_Base", 30);
                tester.SetProp("SpecialDefense_Base", 30);
                tester.SetProp("Speed_Base", 50);
                double avg = ((30 * 5 + 50) / 6.0);
                Assert.AreEqual(avg, tester.GetProp("Average"), "Average berekening klopt niet");
            }
            if (tester.CheckFullProperty("Total", typeof(int), propType: TimsEpicClassAnalyzer.PropertyTypes.NoSet))
            {
                tester.SetProp("HP_Base", 30);
                tester.SetProp("Attack_Base", 30);
                tester.SetProp("Defense_Base", 30);
                tester.SetProp("SpecialAttack_Base", 30);
                tester.SetProp("SpecialDefense_Base", 30);
                tester.SetProp("Speed_Base", 50);
                int tot = ((30 * 5 + 50));
                Assert.AreEqual(tot, tester.GetProp("Total"), " Total berekening klopt niet");
            }
        }

        [TestMethod]
        public void LevelbasedStatsProps()
        {
            TimsEpicClassAnalyzer tester = new TimsEpicClassAnalyzer(new PokemonGottaCatchmAll.Pokemon());

            tester.CheckFullProperty("HP_Full", typeof(int), propType: TimsEpicClassAnalyzer.PropertyTypes.NoSet);
            tester.CheckFullProperty("Attack_Full", typeof(int), propType: TimsEpicClassAnalyzer.PropertyTypes.NoSet);
            tester.CheckFullProperty("Defense_Full", typeof(int), propType: TimsEpicClassAnalyzer.PropertyTypes.NoSet);
            tester.CheckFullProperty("SpecialAttack_Full", typeof(int), propType: TimsEpicClassAnalyzer.PropertyTypes.NoSet);
            tester.CheckFullProperty("SpecialDefense_Full", typeof(int), propType: TimsEpicClassAnalyzer.PropertyTypes.NoSet);
            tester.CheckFullProperty("Speed_Full", typeof(int), propType: TimsEpicClassAnalyzer.PropertyTypes.NoSet);

        }

        [TestMethod]
        public void LevelbasedStatsPropsTest()
        {
            TimsEpicClassAnalyzer tester = new TimsEpicClassAnalyzer(new PokemonGottaCatchmAll.Pokemon());



            tester.SetProp("HP_Base", 30);
            tester.SetProp("Attack_Base", 30);
            tester.SetProp("Defense_Base", 30);
            tester.SetProp("SpecialAttack_Base", 30);
            tester.SetProp("SpecialDefense_Base", 30);
            tester.SetProp("Speed_Base", 50);

            if (tester.CheckFullProperty("HP_Full", typeof(int), propType: TimsEpicClassAnalyzer.PropertyTypes.NoSet))
            {
                int hp = (((30 + 50) * 0) / 50) + 10;
                Assert.AreEqual(hp, tester.GetProp("HP_Full"), "HP_Full berekening klopt niet bij level 0.");
                //Eens kijken wat of het ook na 100 levels klopt
                for (int i = 0; i < 100; i++)
                {
                    tester.TestMethod("VerhoogLevel", null);
                }
                int hpl = (((30 + 50) * 100) / 50) + 10;
                Assert.AreEqual(hpl, tester.GetProp("HP_Full"), "HP_Full berekening klopt niet na 100x levelen.");


            }

            TestLBasesProp("Speed");
            TestLBasesProp("Attack");
            TestLBasesProp("Defense");
            TestLBasesProp("SpecialAttack");
            TestLBasesProp("SpecialDefense");
        }

        static Random r = new Random();

        private void TestLBasesProp(string v)
        {
            TimsEpicClassAnalyzer tester = new TimsEpicClassAnalyzer(new PokemonGottaCatchmAll.Pokemon());
            int basev = r.Next(20, 60);
            tester.SetProp($"{v}_Base", basev);
           
            if (tester.CheckFullProperty($"{v}_Full", typeof(int), propType: TimsEpicClassAnalyzer.PropertyTypes.NoSet))
            {
                int stat = (basev * 0 / 50)+5;
                Assert.AreEqual(stat, tester.GetProp($"{v}_Full"), $"{v}_Full berekening klopt niet bij level 0.");
                //Eens kijken wat of het ook na 100 levels klopt
                for (int i = 0; i < 100; i++)
                {
                    tester.TestMethod("VerhoogLevel", null);
                }
                int hpl = (basev * 100 / 50) + 5;
                Assert.AreEqual(hpl, tester.GetProp($"{v}_Full"), $"{v}_Full berekening klopt niet na 100x levelen.");
            }
        }
    }
}
