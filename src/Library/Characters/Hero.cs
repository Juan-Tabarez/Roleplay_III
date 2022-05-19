namespace RoleplayGame
{
    public abstract class Hero: Character
    {
        
        /*public string Name { get; set; }

        public int VP { get; }

        public int Health { get; }

        public  int AttackValue { get; }

        public  int DefenseValue { get; }*/

        public abstract void AddItem(IItem item);
        

        public abstract void RemoveItem(IItem item);
        

        public abstract void Cure();
        

        public abstract void Attack(Enemy enemy);
        
    }
}
