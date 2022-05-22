namespace RoleplayGame
{
    public abstract class Hero: Character
    {
        private int vp = 0;

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

        public bool Attack(Enemy enemy)
        {
            if (this.IsAlive)
            {
                if (enemy.IsAlive)
                {
                    enemy.ReceiveAttack(this.AttackValue);
                    if (!enemy.IsAlive)
                    {
                        this.VP += enemy.VP;
                    }
                    return true;
                }
                return false;
            }
            return false;
        }

        
        public void Cure()
        {
            this.Health = 100;
            this.VP -=  5;
        }
    }
}
