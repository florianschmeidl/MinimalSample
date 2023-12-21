using UnityEngine;

namespace Straumann.UI
{
    public interface IViewValidator
    {
        void UpdateViews(ViewType[] mandatoryViews, params ViewType[] optionalViews);
        Awaitable AddView(ViewType viewType);
    }
}