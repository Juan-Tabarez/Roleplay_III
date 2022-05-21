using System;
using RoleplayGame;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Encounters encounters = new Encounters();
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

            encounters.AddHeroForEncounter(gandalf);
            encounters.AddHeroForEncounter(gimli);
            encounters.AddHeroForEncounter(archer);
            encounters.AddHeroForEncounter(knight);

            encounters.AddEnemyForEncounter(enemyArcher);
            encounters.AddEnemyForEncounter(enemyDwarf);
            encounters.AddEnemyForEncounter(enemyWizard);
            encounters.AddEnemyForEncounter(enemyKnight);

            encounters.DoEncounter();

        }
    }
}
