using System;
using System.Collections.Generic;
using System.Linq;

namespace RoleplayGame
{
    public class Encounters
    {
        private List<Hero> heros = new List<Hero>();

        public List<Hero> Heros
        {
            get
            {
                return this.heros;
            }
        }

        private List<Enemy> enemies = new List<Enemy>();

        public List<Enemy> Enemies
        {
            get
            {
                return this.enemies;
            }
        }

        public void AddHeroForEncounter(Hero hero)
        {
            heros.Add(hero);
        }

        public void RemoveHeroFromEncounter(Hero hero)
        {
            heros.Remove(hero);
        }

        public void AddEnemyForEncounter(Enemy enemy)
        {
            enemies.Add(enemy);
        }

        public void RemoveEnemyFromEncounter(Enemy enemy)
        {
            enemies.Remove(enemy);
        }

        public void DoEncounter()
        {
            while (this.heros.Count > 0 && this.enemies.Count > 0)
            { 
                HashSet<Hero> toRemove = new HashSet<Hero>();
                int heroPosition = 0;

                for (int enemyPosition = 0 ; enemyPosition < this.enemies.Count ; enemyPosition++)
                {   
                    //Si el ataque se realizo correctamente(no se atacó a un heroe muerto) y 
                    //el heroe atacado murió en ese ataque, entonces el heroe muerto se agrega a una 
                    //colección auxiliar para poder ser eliminado de "heros" luego del bucle para
                    //que no haya problemas de excepciones.
                    if ((this.enemies[enemyPosition].Attack(this.heros[heroPosition])) && (!this.heros[heroPosition].IsAlive))
                    {   
                        toRemove.Add(this.heros[heroPosition]);
                    }
                    if (heroPosition == heros.Count - 1)
                        heroPosition = 0;                 
                    else
                        heroPosition++;        
                }
                //Se eliminan los heroes muertos de "heros". 
                this.heros.RemoveAll(toRemove.Contains);

                if (this.heros.Count > 0)
                {
                    foreach (Hero hero in this.heros)
                    {   
                        //Si recorro la lista normalmente me da una excepcion por cambiar el orden.
                        foreach (Enemy enemy in this.enemies.Reverse<Enemy>())
                        {
                            hero.Attack(enemy);

                            if (hero.VP >= 5)
                                hero.Cure();

                            if (!enemy.IsAlive){ 
                                this.enemies.Remove(enemy);
                            }
                        }
                    }
                }
            }
        }
    }
}
