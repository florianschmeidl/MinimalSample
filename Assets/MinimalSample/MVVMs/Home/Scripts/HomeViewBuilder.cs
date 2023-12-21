using Straumann.UI;
using UnityEngine.UIElements;

namespace MVVMs.Home.Scripts
{
    public class HomeViewBuilder : IViewBuilder
    {
        public ViewType TargetType => ViewType.Home;
        public void Build(UIDocument uiDocument)
        {
        }
    }
}