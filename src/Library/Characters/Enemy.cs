using System.Collections.Generic;

namespace RoleplayGame
{
    public abstract class Enemy: Character
    {
        
        /*public string Name { get; set; }
        
        public int VP { get; }

        public int Health { get; }

        public int AttackValue { get; }

        public int DefenseValue { get; }*/

        public abstract void AddItem(IItem item);
        
        
        public abstract void RemoveItem(IItem item);
        
        
        public abstract void Cure();
        
        
        public abstract void Attack(Character character);
        
    }
}
