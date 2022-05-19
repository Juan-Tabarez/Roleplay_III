using System.Collections.Generic;

namespace RoleplayGame
{
    public abstract class Enemy: Character
    {
        protected int vp;

        public int VP
        {
            get
            {
                return this.vp;
            }

            private set 
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
