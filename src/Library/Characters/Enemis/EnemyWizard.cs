using System.Collections.Generic;
namespace RoleplayGame
{
    public class EnemyWizard: MagicEnemy
    {
        private int health = 100;

        private List<IItem> items = new List<IItem>();

        private List<IMagicalItem> magicalItems = new List<IMagicalItem>();

        public EnemyWizard(string name)
        {
            this.Name = name;
            
            this.AddItem(new Staff());
        }

        public new string Name { get; set; }
        
        public new int AttackValue
        {
            get
            {
                int value = 0;
                foreach (IItem item in this.items)
                {
                    if (item is IAttackItem)
                    {
                        value += (item as IAttackItem).AttackValue;
                    }
                }
                return value;
            }
        }

        public new int DefenseValue
        {
            get
            {
                int value = 0;
                foreach (IItem item in this.items)
                {
                    if (item is IDefenseItem)
                    {
                        value += (item as IDefenseItem).DefenseValue;
                    }
                }
                return value;
            }
        }

        public new int Health
        {
            get
            {
                return this.health;
            }
            private set
            {
                this.health = value < 0 ? 0 : value;
            }
        }

        public new int VP
        {
            get
            {
                return this.VP;
            }

            private set 
            {
                this.VP = value;
            }
        }
        public override void Attack(Character character)
        {
            if (character.Health > 0)
            {
                character.Health -=  this.AttackValue - character.DefenseValue;
                if (character.Health <= 0)
                {
                    this.VP += character.VP;
                }
            }
        }
        public override void Cure()
        {
            this.Health = 100;
        }

        public override void AddItem(IItem item)
        {
            this.items.Add(item);
        }

        public override void RemoveItem(IItem item)
        {
            this.items.Remove(item);
        }

        public override void AddItem(IMagicalItem item)
        {
            this.magicalItems.Add(item);
        }

        public override void RemoveItem(IMagicalItem item)
        {
            this.magicalItems.Remove(item);
        }

    }
}