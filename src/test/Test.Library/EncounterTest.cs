using NUnit.Framework;
using RoleplayGame;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test.Library
{
    public class EncounterTest
    {
        Wizard wizard;

        EnemyWizard enemyWizard;

        Encounters encounters;

        [SetUp]
        public void SetUp()
        {
            this.encounters = new Encounters();
            this.wizard = new Wizard("Gandalf");
            this.enemyWizard = new EnemyWizard("!Gandalf");
        }
        
        [Test]
        public void AddHeroForEncounterTest()
        {
            this.encounters.AddHeroForEncounter(this.wizard);
            Assert.IsNotEmpty(this.encounters.Heros);
        }

        [Test]
        public void RemoveHeroFromEncounterTest()
        {
            this.encounters.AddHeroForEncounter(this.wizard);
            this.encounters.RemoveHeroFromEncounter(this.wizard);
            Assert.IsEmpty(this.encounters.Heros);
        }

        [Test]
        public void AddEnemyForEncounterTest()
        {
            this.encounters.AddEnemyForEncounter(this.enemyWizard);
            Assert.IsNotEmpty(this.encounters.Enemies);
        }

        [Test]
        public void RemoveEnemyForEncounterTest()
        {
            this.encounters.AddEnemyForEncounter(this.enemyWizard);
            this.encounters.RemoveEnemyFromEncounter(this.enemyWizard);
            Assert.IsEmpty(this.encounters.Enemies);
        }
    }
}