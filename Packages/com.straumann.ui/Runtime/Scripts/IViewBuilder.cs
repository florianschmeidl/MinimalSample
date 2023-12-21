using UnityEngine.UIElements;

namespace Straumann.UI
{
    public interface IViewBuilder
    {
        ViewType TargetType { get; }
        void Build(UIDocument uiDocument);
    }
}