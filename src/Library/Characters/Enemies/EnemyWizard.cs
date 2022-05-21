namespace RoleplayGame
{
    public class EnemyWizard: MagicEnemy
    {
        public EnemyWizard(string name)
        {
            this.Name = name;
            
            this.AddItem(new Staff());

            this.VP = 2;
        }
    }
}