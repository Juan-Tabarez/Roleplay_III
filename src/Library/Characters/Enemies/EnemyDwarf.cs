namespace RoleplayGame
{
    public class EnemyDwarf: Enemy
    {
        public EnemyDwarf(string name)
        {
            this.Name = name;
            
            this.AddItem(new Axe());
            this.AddItem(new Helmet());
        }
    }
}