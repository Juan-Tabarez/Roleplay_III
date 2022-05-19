namespace RoleplayGame
{
    public interface ICharacter
    {
        string Name { get; set; }

        int Health { get; }

        int AttackValue { get; }

        int DefenseValue { get; }

        public void AddItem(IItem item);

        public void RemoveItem(IItem item);

        public void Cure();

        public void ReceiveAttack(int power);
    }
}