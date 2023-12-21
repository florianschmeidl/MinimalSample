using UnityEngine.UIElements;

namespace Straumann.UI
{
    public interface IViewFactory
    {
        UIDocument Make(ViewType viewType, VisualTreeAsset visualTreeAsset);
    }
}