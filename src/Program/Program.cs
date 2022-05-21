using System;
using RoleplayGame;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            SpellsBook book = new SpellsBook();
            book.AddSpell(new SpellOne());
            book.AddSpell(new SpellOne());

            Wizard gandalf = new Wizard("Gandalf");
            gandalf.AddItem(book);

            Dwarf gimli = new Dwarf("Gimli");

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");
            Console.WriteLine($"Gandalf attacks Gimli with ⚔️ {gandalf.AttackValue}");

            gimli.ReceiveAttack(gandalf.AttackValue);

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");

            gimli.Cure();

            Console.WriteLine($"Someone cured Gimli. Gimli now has ❤️ {gimli.Health}");

            Archer archer = new Archer("Legolas");
            Knight knight = new Knight("Dave");

            EnemyDwarf enemyDwarf = new EnemyDwarf("Goblin");
            EnemyArcher enemyArcher = new EnemyArcher("Varus");
            EnemyKnight enemyKnight = new EnemyKnight("Arthur");
            EnemyWizard enemyWizard = new EnemyWizard("Voldemort");

            Encounters.AddHeroForEncounter(gandalf);
            Encounters.AddHeroForEncounter(gimli);
            Encounters.AddHeroForEncounter(archer);
            Encounters.AddHeroForEncounter(knight);

            Encounters.AddEnemyForEncounter(enemyArcher);
            Encounters.AddEnemyForEncounter(enemyDwarf);
            Encounters.AddEnemyForEncounter(enemyWizard);
            Encounters.AddEnemyForEncounter(enemyKnight);

            Encounters.DoEncounter();

        }
    }
}
