namespace RoleplayGame
{
    public abstract class Character
    {
        public string Name { get; set; }

        public int VP { get;}

        public int Health { get; set; }

        public int AttackValue { get; }

        public int DefenseValue { get; }

        /*public abstract void AddItem(IItem item);

        public abstract void RemoveItem(IItem item);

        public abstract void Cure();

         public abstract void ReceiveAttack(int power);*/
    }
}