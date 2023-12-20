using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Straumann.UI
{
    public interface IUIFactory
    {
        Awaitable<UIDocument> Make(string name);
    }
}