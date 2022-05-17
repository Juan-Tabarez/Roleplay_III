namespace RoleplayGame
{
    public abstract class Character
    {
        string Name { get; set; }

        int Health { get; }

        int AttackValue { get; }

        int DefenseValue { get; }

        public abstract void AddItem(IItem item);

        public abstract void RemoveItem(IItem item);

        public abstract void Cure();

        public abstract void ReceiveAttack(int power);
    }
}