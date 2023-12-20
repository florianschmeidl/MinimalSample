using VContainer.Unity;

namespace DefaultNamespace
{
    public class OnlineStateProvider : ITickable, IOnlineStateProvider
    {
        public bool IsOnline { get; private set; }
        
        public void Tick()
        {
            // Check if google is available
            IsOnline = true;
        }
    }
}