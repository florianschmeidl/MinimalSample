using UnityEngine;
using UnityEngine.UIElements;

namespace Straumann.UI
{
    public class VisualTreeProvider : IVisualTreeProvider
    {
        private readonly IVisualTreeDatabase m_VisualTreeDatabase;

        public VisualTreeProvider(IVisualTreeDatabase visualTreeDatabase)
        {
            m_VisualTreeDatabase = visualTreeDatabase;
        }

        public Awaitable<VisualTreeAsset> GetAsync(ViewType viewType)
        {
            var awaitableCompletionSource = new AwaitableCompletionSource<VisualTreeAsset>();
            bool notFound = true;
            foreach (var dataBaseEntry in m_VisualTreeDatabase.DatabaseEntries)
            {
                if (dataBaseEntry.ViewType == viewType)
                {
                    notFound = false;
                    awaitableCompletionSource.SetResult(dataBaseEntry.VisualTreeAsset);
                }
            }
            if(notFound)
                awaitableCompletionSource.SetResult(null);
            
            return awaitableCompletionSource.Awaitable;
        }
    }
}