using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class HeroTest
    {
        Archer legolas;

        Bow bow;

        [SetUp]
        public void Setup()
        {
            this.legolas = new Archer("Legolas");
        }

        //Test que demuestra que es posible asignar un nombre distinto.
        [Test]
        public void ValidNameTest()
        {
            this.legolas.Name = "Sarion";
            Assert.AreEqual("Sarion", this.legolas.Name);
        }

        //Test que demuestra que es posible asignar una vida válida.
        [Test]
        public void ValidHealthTest()
        {
            Assert.AreEqual(100, this.legolas.Health);
        }

        //Test para saber el ataque de un personaje.
        [Test]
        public void AttackValue()
        {
            int expectedAttack = 15;
            Assert.AreEqual(expectedAttack, this.legolas.AttackValue);
        }

        //Test para saber la defensa de un personaje.
        [Test]
        public void DefenseValueTest()
        {
            int expectedDefense = 18;
            Assert.AreEqual(expectedDefense, this.legolas.DefenseValue);
        }

        //Test para verificar que un personaje puede atacar a otro personaje.
        [Test]
        public void AttackCharacterTest()
        {
            Archer frey = new Archer("Frey");
            frey.ReceiveAttack(this.legolas.AttackValue);
            int expectedHealth = 100;
            Assert.AreEqual(expectedHealth, frey.Health);
        }

        //Test que demuestra que un personaje puede curarse correctamente.
        [Test]
        public void HealTest()
        {
            this.legolas.ReceiveAttack(this.legolas.AttackValue * 3);
            this.legolas.Cure();
            Assert.AreEqual(100, this.legolas.Health);
        }

        //Test que demuestra que se le puede añadir un item nuevo a un personaje correctamente.
        [Test]
        public void AddItemTest()
        {

            this.bow = new Bow();
            this.legolas.AddItem(bow);
            int expectedAttack = 30;
            Assert.AreEqual(expectedAttack, this.legolas.AttackValue);
        }

        //Test que demuestra que se le puede remover un item nuevo a un personaje correctamente.
        [Test]
        public void RemoveItemTest()
        {
            
            this.bow = new Bow();
            this.legolas.AddItem(bow);
            this.legolas.RemoveItem(bow);
            int expectedAttack = 15;
            Assert.AreEqual(expectedAttack, this.legolas.AttackValue);
        }

        //Test que demuestra que un heroe al matar a un enemigo se queda con sus VP.
        [Test]

        public void AttackTest1()
        {
            EnemyArcher enemyArcher = new EnemyArcher("Varus");
            this.bow = new Bow();
            this.legolas.AddItem(bow);
            this.legolas.AddItem(bow);
            this.legolas.AddItem(bow);
            this.legolas.AddItem(bow);
            this.legolas.AddItem(bow);
            this.legolas.AddItem(bow);
            this.legolas.AddItem(bow);

            this.legolas.Attack(enemyArcher);
            Assert.AreEqual(false, enemyArcher.IsAlive);
            int expectedVPs = 2;
            Assert.AreEqual(expectedVPs, this.legolas.VP);
        }

        //Test que demuestra que un heroe al atacar pero no matar a un enemigo no se queda con sus VP.
        [Test]

        public void AttackTest2()
        {
            EnemyArcher enemyArcher = new EnemyArcher("Varus");
            this.legolas.Attack(enemyArcher);
            int expectedVPs = 0;
            Assert.AreEqual(expectedVPs, this.legolas.VP);
        }

        //Test que demuestra que un heroe muerto no puede atacar.
        [Test]

        public void AttackTest3()
        {
            this.legolas.ReceiveAttack(120);
            EnemyArcher enemyArcher = new EnemyArcher("Varus");
            
            bool expected = false;
            Assert.AreEqual(expected, this.legolas.Attack(enemyArcher));
        }

        //Test que demuestra que un heroe no puede atacar a un enemigo muerto.
        [Test]

        public void AttackTest4()
        {
            EnemyArcher enemyArcher = new EnemyArcher("Varus");
            enemyArcher.ReceiveAttack(120);
            bool expected = false;
            Assert.AreEqual(expected, this.legolas.Attack(enemyArcher));
        }
    }
}