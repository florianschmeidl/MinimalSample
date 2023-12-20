namespace DefaultNamespace
{
    public class UniversalUserRepository : IUserRepository
    {
        private readonly LocalJsonUserRepository m_LocalJsonUserRepository;
        private readonly SqLiteUserRepository m_SqLiteUserRepository;
        private readonly IOnlineStateProvider m_OnlineStateProvider;

        public UniversalUserRepository(LocalJsonUserRepository localJsonUserRepository, SqLiteUserRepository sqLiteUserRepository, IOnlineStateProvider onlineStateProvider)
        {
            m_LocalJsonUserRepository = localJsonUserRepository;
            m_SqLiteUserRepository = sqLiteUserRepository;
            m_OnlineStateProvider = onlineStateProvider;
        }

        public User Read(string userName)
        {
            if (m_OnlineStateProvider.IsOnline)
            {
                return m_SqLiteUserRepository.Read(userName);
            }
            else
            {
                return m_LocalJsonUserRepository.Read(userName);
            }
        }
    }
}