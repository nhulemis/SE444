using managers;

namespace Model
{
    public class PlayerModel
    {
        private int health;

        public int Health
        {
            get { return health; }
            set
            {
                if (value < 0)
                {
                    health = 0;
                }
                else
                {
                    health = value;
                }
                // Notify any listeners about the health change
                HealthService.Instance.NotifyHealthChanged(health);
            }
        }
    }
}