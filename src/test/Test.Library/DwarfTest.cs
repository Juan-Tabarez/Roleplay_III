using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class DwarfTest
    {
        Dwarf gimli;

        Axe axe;

        [SetUp]
        public void Setup()
        {
            this.gimli = new Dwarf("Gimli");
        }

        //Test que demuestra que es posible asignar un nombre distinto.
        [Test]
        public void ValidNameTest()
        {
            this.gimli.Name = "Baldur";
            Assert.AreEqual(this.gimli.Name, "Baldur");
        }

        //Test que demuestra que es posible asignar una vida válida.
        [Test]
        public void ValidHealthTest()
        {
            Assert.AreEqual(this.gimli.Health, 100);
        }

        //Test para saber el ataque de un personaje.
        [Test]
        public void AttackValue()
        {
            int expectedAttack = 25;
            Assert.AreEqual(expectedAttack, this.gimli.AttackValue);
        }

        //Test para saber la defensa de un personaje.
        [Test]
        public void DefenseValueTest()
        {
            int expectedDefense = 18;
            Assert.AreEqual(expectedDefense, this.gimli.DefenseValue);
        }

        //Test para verificar que un personaje puede atacar a otro personaje.
        [Test]
        public void AttackCharacterTest()
        {
            Archer legolas = new Archer("Legolas");
            legolas.ReceiveAttack(this.gimli.AttackValue);
            int expectedHealth = 93;
            Assert.AreEqual(expectedHealth, legolas.Health);
        }

        //Test que demuestra que un personaje puede curarse correctamente.
        [Test]
        public void HealTest()
        {
            this.gimli.ReceiveAttack(this.gimli.AttackValue * 3);
            this.gimli.Cure();
            Assert.AreEqual(this.gimli.Health, 100);
        }

        //Test que demuestra que se le puede añadir un item nuevo a un personaje correctamente.
        [Test]
        public void AddItemTest()
        {

            this.axe = new Axe();
            this.gimli.AddItem(axe);
            int expectedAttack = 50;
            Assert.AreEqual(this.gimli.AttackValue, expectedAttack);
        }

        //Test que demuestra que se le puede remover un item nuevo a un personaje correctamente.
        [Test]
        public void RemoveItemTest()
        {
            
            this.axe = new Axe();
            this.gimli.AddItem(axe);
            this.gimli.RemoveItem(axe);
            int expectedAttack = 25;
            Assert.AreEqual(this.gimli.AttackValue, expectedAttack);
        }
    }
}