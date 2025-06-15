using System;
using Utils;

namespace managers
{
    public class HealthService : Singleton<HealthService>
    {
        private Action<int> onHealthChanged ;
        
        public void RegisterOnHealthChanged(Action<int> callback)
        {
            onHealthChanged += callback;
        }
        
        public void UnregisterOnHealthChanged(Action<int> callback)
        {
            onHealthChanged -= callback;
        }
        
        public void NotifyHealthChanged(int newHealth)
        {
            onHealthChanged?.Invoke(newHealth);
        }
    }
}