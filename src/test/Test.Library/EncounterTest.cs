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

        SpellsBook spellsBook;

        SpellOne spellOne;

        Dwarf dwarf;

        EnemyKnight enemyKnight1;

        EnemyKnight enemyKnight2;

        EnemyDwarf enemyDwarf;

        Axe axe;

        [SetUp]
        public void SetUp()
        {
            this.encounters = new Encounters();
            this.wizard = new Wizard("Gandalf");
            this.enemyWizard = new EnemyWizard("!Gandalf");
            this.spellOne = new SpellOne();
            this.spellsBook = new SpellsBook();
            this.spellsBook.AddSpell(spellOne);
            this.dwarf = new Dwarf("gimli");
            this.enemyKnight1 = new EnemyKnight("!arthur");
            this.enemyKnight2 = new EnemyKnight("arthurn't");
            this.enemyDwarf = new EnemyDwarf("!gimli");
            this.axe = new Axe();
        }
        
        //Test que demuestra que se puede añadir un hero a un encuentro.
        [Test]
        public void AddHeroForEncounterTest()
        {
            this.encounters.AddHeroForEncounter(this.wizard);
            Assert.IsNotEmpty(this.encounters.Heros);
        }

        //Test que demuestra que se puede remover un hero de un encuentro.
        [Test]
        public void RemoveHeroFromEncounterTest()
        {
            this.encounters.AddHeroForEncounter(this.wizard);
            this.encounters.RemoveHeroFromEncounter(this.wizard);
            Assert.IsEmpty(this.encounters.Heros);
        }

        //Test que demuestra que se puede añadir un enemy a un encuentro.
        [Test]
        public void AddEnemyForEncounterTest()
        {
            this.encounters.AddEnemyForEncounter(this.enemyWizard);
            Assert.IsNotEmpty(this.encounters.Enemies);
        }

        //Test que demuestra que se puede remover un enemy de un encuentro.
        [Test]
        public void RemoveEnemyForEncounterTest()
        {
            this.encounters.AddEnemyForEncounter(this.enemyWizard);
            this.encounters.RemoveEnemyFromEncounter(this.enemyWizard);
            Assert.IsEmpty(this.encounters.Enemies);
        }

        //Test que demuestra que un personaje puede atacar correctamente en un encuentro.
        [Test]
        public void CharacterHealthAfterVictoryTest()
        {
            this.dwarf.AddItem(this.axe);
            this.encounters.AddEnemyForEncounter(this.enemyKnight1);
            this.encounters.AddHeroForEncounter(this.dwarf);
            this.encounters.DoEncounter();
            int expectedHealth = 80;
            Assert.AreEqual(expectedHealth, this.dwarf.Health);
        }

        //Test que demuestra que un hero se cura correctamente después de haber conseguido suficientes VP.
        [Test]
        public void VPCureAfterHeroKillTest()
        {
            this.dwarf.AddItem(this.axe);
            this.dwarf.AddItem(this.axe);
            this.dwarf.AddItem(this.axe);
            this.dwarf.AddItem(this.axe);
            this.dwarf.AddItem(this.axe);
            this.dwarf.AddItem(this.axe);

            this.encounters.AddEnemyForEncounter(this.enemyKnight1);
            this.encounters.AddEnemyForEncounter(this.enemyKnight2);
            this.encounters.AddHeroForEncounter(this.dwarf);
            this.encounters.DoEncounter();
            int expectedHealth = 100;
            Assert.AreEqual(expectedHealth, this.dwarf.Health);
        }

        //Test que demuestra que ocurre si hay más enemies que heroes;
        [Test]
        public void TwoEnemiesAttackOneHeroTest()
        {
            this.dwarf.AddItem(this.axe);
            this.dwarf.AddItem(this.axe);
            this.dwarf.AddItem(this.axe);
            this.dwarf.AddItem(this.axe);
            this.dwarf.AddItem(this.axe);
            this.dwarf.AddItem(this.axe);

            this.encounters.AddEnemyForEncounter(this.enemyKnight1);
            this.encounters.AddEnemyForEncounter(this.enemyDwarf);
            this.encounters.AddHeroForEncounter(this.dwarf);
            this.encounters.DoEncounter();
            int expectedHealth = 91;
            Assert.AreEqual(expectedHealth, this.dwarf.Health);
        }
    }
}