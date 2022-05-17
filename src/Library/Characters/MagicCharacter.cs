namespace RoleplayGame
{
    public abstract class MagicCharacter: Character
    {
        public abstract void AddItem(IMagicalItem item);

        public abstract void RemoveItem(IMagicalItem item);
    }
}
