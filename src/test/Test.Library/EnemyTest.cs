using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class EnemyTest
    {
        EnemyArcher varus;

        Bow bow;

        [SetUp]
        public void Setup()
        {
            this.varus = new EnemyArcher("Varus");
        }

        //Test que demuestra que es posible asignar un nombre distinto.
        [Test]
        public void ValidNameTest()
        {
            this.varus.Name = "Sarion";
            Assert.AreEqual("Sarion", this.varus.Name);
        }

        //Test que demuestra que es posible asignar una vida válida.
        [Test]
        public void ValidHealthTest()
        {
            Assert.AreEqual(100, this.varus.Health);
        }

        //Test para saber el ataque de un personaje.
        [Test]
        public void AttackValue()
        {
            int expectedAttack = 15;
            Assert.AreEqual(expectedAttack, this.varus.AttackValue);
        }

        //Test para saber la defensa de un personaje.
        [Test]
        public void DefenseValueTest()
        {
            int expectedDefense = 18;
            Assert.AreEqual(expectedDefense, this.varus.DefenseValue);
        }

        //Test para verificar que un personaje puede atacar a otro personaje.
        [Test]
        public void AttackCharacterTest()
        {
            EnemyArcher frey = new EnemyArcher("Frey");
            frey.ReceiveAttack(this.varus.AttackValue);
            int expectedHealth = 100;
            Assert.AreEqual(expectedHealth, frey.Health);
        }

        //Test que demuestra que un personaje puede curarse correctamente.
        [Test]
        public void HealTest()
        {
            this.varus.ReceiveAttack(this.varus.AttackValue * 3);
            this.varus.Cure();
            Assert.AreEqual(100, this.varus.Health);
        }

        //Test que demuestra que se le puede añadir un item nuevo a un personaje correctamente.
        [Test]
        public void AddItemTest()
        {

            this.bow = new Bow();
            this.varus.AddItem(bow);
            int expectedAttack = 30;
            Assert.AreEqual(expectedAttack, this.varus.AttackValue);
        }

        //Test que demuestra que se le puede remover un item nuevo a un personaje correctamente.
        [Test]
        public void RemoveItemTest()
        {
            
            this.bow = new Bow();
            this.varus.AddItem(bow);
            this.varus.RemoveItem(bow);
            int expectedAttack = 15;
            Assert.AreEqual(expectedAttack, this.varus.AttackValue);
        }

        //Test que demuestra que un enemigo al matar a un heroe no se queda con sus VP.
        [Test]

        public void AttackTest1()
        {   
            //Se crea heroe y enemigo auxiliares
            Archer heroArcher = new Archer("Legolas");
            EnemyArcher enemyArcher = new EnemyArcher("Robin");
            this.bow = new Bow();
            heroArcher.AddItem(bow);
            heroArcher.AddItem(bow);
            heroArcher.AddItem(bow);
            heroArcher.AddItem(bow);
            heroArcher.AddItem(bow);
            heroArcher.AddItem(bow);
            heroArcher.AddItem(bow);
            //Leogolas(hero) mata a Robin(enemy) para quedarse con sus VP (2 VP).
            heroArcher.Attack(enemyArcher);
            Assert.AreEqual(false, enemyArcher.IsAlive);
            //Varus(enemy) mata a Legolas(hero) y se demustra que no se queda con sus VP.
            this.varus.AddItem(bow);
            this.varus.AddItem(bow);
            this.varus.AddItem(bow);
            this.varus.AddItem(bow);
            this.varus.AddItem(bow);
            this.varus.AddItem(bow);
            this.varus.AddItem(bow);
            this.varus.Attack(heroArcher);
            Assert.AreEqual(false, heroArcher.IsAlive);
            //En caso de que se acumularan el valor esperado deberia ser 4.
            int expected = 2;
            Assert.AreEqual(expected, this.varus.VP);
        }

        
        //Test que demuestra que un enemigo muerto no puede atacar.
        [Test]

        public void AttackTest2()
        {
            this.varus.ReceiveAttack(120);
            Archer Archer = new Archer("Legolas");
            
            bool expected = false;
            Assert.AreEqual(expected, this.varus.Attack(Archer));
        }

        //Test que demuestra que un enemigo no puede atacar a un heroe muerto.
        [Test]

        public void AttackTest3()
        {
            Archer Archer = new Archer("Legolas");
            Archer.ReceiveAttack(120);
            bool expected = false;
            Assert.AreEqual(expected, this.varus.Attack(Archer));
        }
    }
}