using System;
using System.Collections.Generic;
using System.Linq;

namespace RoleplayGame
{
    public class Encounters
    {
        private static List<Hero> heros = new List<Hero>();

        private static List<Enemy> enemies = new List<Enemy>();

        public static void AddHeroForEncounter(Hero hero)
        {
            heros.Add(hero);
        }

        public static void RemoveHeroFromEncounter(Hero hero)
        {
            heros.Remove(hero);
        }

        public static void AddEnemyForEncounter(Enemy enemy)
        {
            enemies.Add(enemy);
        }

        public static void RemoveEnemyFromEncounter(Enemy enemy)
        {
            enemies.Remove(enemy);
        }

        public static void DoEncounter()
        {
            while (heros.Count > 0 && enemies.Count > 0)
            { 
                HashSet<Hero> toRemove = new HashSet<Hero>();
                int heroPosition = 0;

                for (int enemyPosition = 0 ; enemyPosition < enemies.Count ; enemyPosition++)
                {   
                    //Si el ataque se realizo correctamente(no se atacó a un heroe muerto) y 
                    //el heroe atacado murió en ese ataque, entonces el heroe muerto se agrega a una 
                    //colección auxiliar para poder ser eliminado de "heros" luego del bucle para
                    //que no haya problemas de excepciones.
                    if ((enemies[enemyPosition].Attack(heros[heroPosition])) && (!heros[heroPosition].IsAlive))
                    {   
                        Console.WriteLine("The hero " + heros[heroPosition].Name + " is dead...");
                        toRemove.Add(heros[heroPosition]);
                    }
                    if (heroPosition == heros.Count - 1)
                        heroPosition = 0;                 
                    else
                        heroPosition++;        
                }
                //Se eliminan los heroes muertos de "heros". 
                heros.RemoveAll(toRemove.Contains);

                if (heros.Count > 0)
                {
                    foreach (Hero hero in heros)
                    {   
                        //Si recorro la lista normalmente me da una excepcion por cambiar el orden.
                        foreach (Enemy enemy in enemies.Reverse<Enemy>())
                        {
                            hero.Attack(enemy);

                            if (hero.VP >= 5)
                                hero.Cure();

                            if (!enemy.IsAlive){ 
                                Console.WriteLine("The enemy " + enemy.Name + " is dead...");
                                enemies.Remove(enemy);
                            }
                        }
                    }
                }
            }
            if (enemies.Count > 0)
                Console.WriteLine("Enemies Victory");
            else 
                Console.WriteLine("Heros Victory");  
        }
    }
}
