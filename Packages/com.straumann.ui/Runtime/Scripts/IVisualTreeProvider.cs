using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Straumann.UI
{
    public interface IVisualTreeProvider
    {
        Awaitable<VisualTreeAsset> GetAsync(ViewType viewType);
    }
}