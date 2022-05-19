namespace RoleplayGame
{
    public abstract class MagicCharacter: Character
    {
        public abstract void AddItem(IMagicalItem item);

        public abstract void RemoveItem(IMagicalItem item);

        public abstract void AddItem(IItem item);
        

        public abstract void RemoveItem(IItem item);
        

        public abstract void Cure();
        

        public abstract void Attack(Character character);
    }
}
