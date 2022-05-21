namespace RoleplayGame
{
    public class EnemyKnight: Enemy
    {
        public EnemyKnight(string name)
        {
            this.Name = name;
            
            this.AddItem(new Sword());
            this.AddItem(new Armor());
            this.AddItem(new Shield());

            this.VP = 3;
        }
    }
}