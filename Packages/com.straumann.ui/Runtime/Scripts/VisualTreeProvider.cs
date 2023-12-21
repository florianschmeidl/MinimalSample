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
            var notFound = true;
            
            foreach (var databaseEntry in m_VisualTreeDatabase.DatabaseEntries)
            {
                if (databaseEntry.ViewType == viewType)
                {
                    notFound = false;
                    awaitableCompletionSource.SetResult(databaseEntry.VisualTreeAsset);
                }
            }

            if (notFound)
            {
                awaitableCompletionSource.SetResult(null);
            }
            
            return awaitableCompletionSource.Awaitable;
        }
    }
}