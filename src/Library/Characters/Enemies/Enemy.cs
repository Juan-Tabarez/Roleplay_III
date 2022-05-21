using System.Collections.Generic;

namespace RoleplayGame
{
    public abstract class Enemy: Character
    {
        //Esto tiene que ser privado
        private int vp;

        public int VP
        {
            get
            {
                return this.vp;
            }

            //Creo que este set no puede ser privado, sino no le podemos 
            //cambiar los VP a cada personaje particular.
            protected set 
            {
                this.vp = value;
            }
        }

        public bool Attack(Hero hero)
        {
            if (this.IsAlive)
            {
                if (hero.IsAlive)
                {
                    hero.ReceiveAttack(this.AttackValue);
                    return true;
                }
                return false;
            }
            return false;
        } 
    }
}
