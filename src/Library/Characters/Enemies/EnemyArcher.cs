namespace RoleplayGame
{
    public class EnemyArcher: Enemy
    {
        public EnemyArcher(string name)
        {
            this.Name = name;
            
            this.AddItem(new Bow());
            this.AddItem(new Helmet());

            this.VP = 2;
        }
    }
}